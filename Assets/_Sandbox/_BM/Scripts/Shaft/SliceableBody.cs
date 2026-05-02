using UnityEngine;
using BM.Core;

namespace BM.Shaft
{
    /// <summary>
    /// Sits on the root of an Animal_Sliceable.prefab. Owns three nested sub-trees
    /// (Whole, TwoPiece, FourPiece) and cycles them on Hit. The pieces of the FourPiece
    /// branch are CLONED on the final hit so the prefab can return to the pool with its
    /// structure intact.
    /// </summary>
    public sealed class SliceableBody : MonoBehaviour
    {
        public enum State { Whole, TwoPiece, FourPiece }

        [Header("Sub-trees (auto-found by name in Awake if left null)")]
        [SerializeField] private GameObject _whole;
        [SerializeField] private GameObject _twoPiece;
        [SerializeField] private GameObject _fourPiece;

        [Header("Hit FX")]
        [SerializeField] private GameObject _hitFxPrefab;
        [SerializeField] private float _hitFxLifetime = 1.5f;
        [SerializeField] private GameObject _bloodSplatPrefab;
        [SerializeField] private float _bloodSplatLifetime = 6f;

        [Header("Piece physics")]
        [Tooltip("Outward+up impulse magnitude applied to TwoPiece children on Hit 1.")]
        [SerializeField] private float _twoPieceImpulse = 2.5f;
        [Tooltip("Outward+up impulse magnitude applied to FourPiece clones on Hit 2.")]
        [SerializeField] private float _fourPieceImpulse = 6f;
        [Tooltip("Multiplier on Vector3.up added to the outward direction. >0 makes pieces arc upward.")]
        [SerializeField] private float _upwardBias = 1.2f;
        [Tooltip("Auto-destroy time on flung four-piece clones, in seconds.")]
        [SerializeField] private float _fourPieceLifetime = 4f;

        [Header("Organs (Hit 2 final consume)")]
        [SerializeField] private OrganPool _organPool;
        [SerializeField] private int _organCount = 2;
        [SerializeField] private float _organImpulse = 4f;
        [SerializeField] private float _organUpwardBias = 1.5f;
        [SerializeField] private float _organLifetime = 6f;

        private State _state = State.Whole;
        private OrganSize _organSize = OrganSize.Small;

        public State CurrentState => _state;
        /// <summary>True after Hit 2 fires; outlet should release on this transition.</summary>
        public bool IsConsumed => _state == State.FourPiece;

        private void Awake()
        {
            if (_whole == null) { var t = transform.Find("Whole"); if (t != null) _whole = t.gameObject; }
            if (_twoPiece == null) { var t = transform.Find("TwoPiece"); if (t != null) _twoPiece = t.gameObject; }
            if (_fourPiece == null) { var t = transform.Find("FourPiece"); if (t != null) _fourPiece = t.gameObject; }
            ResetState();
        }

        private void OnEnable() => ResetState();

        /// <summary>Reset all three sub-trees to their default states.</summary>
        public void ResetState()
        {
            _state = State.Whole;
            if (_whole != null) _whole.SetActive(true);
            if (_twoPiece != null) _twoPiece.SetActive(false);
            if (_fourPiece != null) _fourPiece.SetActive(false);
        }

        /// <summary>
        /// Configure per-spawn. Caller passes the BodyConfigSO so the body knows
        /// which organ size pool to draw from on consume.
        /// </summary>
        public void Configure(BodyConfigSO config)
        {
            if (config != null) _organSize = config.OrganSize;
        }

        /// <summary>
        /// Advance the chop chain. Returns true on the final hit (Hit 2 / consume).
        /// When oneShot=true the body skips the Whole→TwoPiece step and consumes immediately
        /// on the first hit (used by the Ghoul and by chainsaw-tier ChopMinions).
        /// </summary>
        /// <param name="swingDir">Optional bias direction (e.g. ghoul facing). Pass Vector3.zero to skip directional bias.</param>
        public bool Hit(Vector3 swingDir, bool oneShot = false)
        {
            Vector3 hitPos = transform.position;
            SpawnHitFx(hitPos);

            if (oneShot && _state == State.Whole)
            {
                _state = State.FourPiece;
                if (_whole != null) _whole.SetActive(false);
                if (_twoPiece != null) _twoPiece.SetActive(false);
                CloneAndFlingFourPiece(swingDir);
                SpawnOrgans(hitPos, swingDir);
                return true;
            }

            if (_state == State.Whole)
            {
                _state = State.TwoPiece;
                if (_whole != null) _whole.SetActive(false);
                if (_twoPiece != null)
                {
                    _twoPiece.SetActive(true);
                    ApplyImpulseToChildren(_twoPiece.transform, swingDir, _twoPieceImpulse);
                }
                return false;
            }

            if (_state == State.TwoPiece)
            {
                _state = State.FourPiece;
                if (_twoPiece != null) _twoPiece.SetActive(false);
                CloneAndFlingFourPiece(swingDir);
                SpawnOrgans(hitPos, swingDir);
                return true;
            }

            // Already consumed -- idempotent.
            return true;
        }

        private void SpawnHitFx(Vector3 pos)
        {
            if (_hitFxPrefab != null)
            {
                var fx = Instantiate(_hitFxPrefab, pos, Quaternion.identity);
                // The Synty FX_Explosion_Body_Bloody asset has startDelay=0.1 + loop=true on its
                // particle systems, which makes the burst feel late and trickly. Override per-instance
                // so the FX bursts immediately on swing impact instead of 0.1s after.
                NormalizeFxForBurst(fx);
                if (_hitFxLifetime > 0f) Destroy(fx, _hitFxLifetime);
            }
            if (_bloodSplatPrefab != null)
            {
                var splat = Instantiate(_bloodSplatPrefab,
                    new Vector3(pos.x, pos.y + 0.01f, pos.z),
                    Quaternion.Euler(90f, Random.Range(0f, 360f), 0f));
                NormalizeFxForBurst(splat);
                if (_bloodSplatLifetime > 0f) Destroy(splat, _bloodSplatLifetime);
            }
        }

        /// <summary>Strip startDelay (and force one-shot) on all child particle systems of a spawned FX so it bursts on impact.</summary>
        private static void NormalizeFxForBurst(GameObject fxRoot)
        {
            var systems = fxRoot.GetComponentsInChildren<ParticleSystem>(true);
            for (int i = 0; i < systems.Length; i++)
            {
                var ps = systems[i];
                var main = ps.main;
                main.startDelay = 0f;
                main.loop = false;
                ps.Clear(true);
                ps.Play(true);
            }
        }

        private void ApplyImpulseToChildren(Transform branch, Vector3 swingDir, float impulse)
        {
            for (int i = 0; i < branch.childCount; i++)
            {
                var child = branch.GetChild(i);
                var rb = child.GetComponent<Rigidbody>();
                if (rb == null) continue;
                Vector3 outward = (child.position - branch.position);
                if (outward.sqrMagnitude < 0.0001f) outward = Random.onUnitSphere;
                else outward.Normalize();
                Vector3 dir = (outward + Vector3.up * _upwardBias + swingDir.normalized).normalized;
                rb.AddForce(dir * impulse, ForceMode.Impulse);
                rb.AddTorque(Random.insideUnitSphere * impulse, ForceMode.Impulse);
            }
        }

        private void CloneAndFlingFourPiece(Vector3 swingDir)
        {
            if (_fourPiece == null) return;
            // The 4 quarter prefab children all sit at localPos(0,0,0) -- meshes are pre-sliced and
            // are visually distinct only via their geometry, not via spawn position. Hard-code an
            // outward quadrant direction per child by name suffix so each quarter flies into its own
            // octant instead of using a random direction (which can stack 2 pieces visually).
            Transform survivor = transform.parent;
            for (int i = 0; i < _fourPiece.transform.childCount; i++)
            {
                var src = _fourPiece.transform.GetChild(i);
                var clone = Instantiate(src.gameObject, src.position, src.rotation, survivor);
                clone.SetActive(true);
                clone.name = src.name + "_flung";

                var rb = clone.GetComponent<Rigidbody>();
                if (rb == null) rb = clone.AddComponent<Rigidbody>();
                rb.isKinematic = false;
                rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;

                Vector3 quadrant = QuadrantDirection(src.name);
                Vector3 dir = (quadrant + Vector3.up * _upwardBias + swingDir.normalized * 0.5f).normalized;
                rb.AddForce(dir * _fourPieceImpulse, ForceMode.Impulse);
                rb.AddTorque(Random.insideUnitSphere * _fourPieceImpulse, ForceMode.Impulse);

                if (_fourPieceLifetime > 0f) Destroy(clone, _fourPieceLifetime);
            }
        }

        /// <summary>Map quarter name suffix to outward direction so each piece flies into its own quadrant. Top/Bot drives Y, Left/Right drives X (head-to-tail sagittal cut).</summary>
        private static Vector3 QuadrantDirection(string pieceName)
        {
            float y = pieceName.Contains("Top") ? 1f : (pieceName.Contains("Bot") ? -0.3f : 0f);
            float x = pieceName.Contains("Left") ? -1f : (pieceName.Contains("Right") ? 1f : 0f);
            // Z kicker so pieces don't all hug the XY plane -- alternate sides per piece via hash.
            float z = (pieceName.GetHashCode() & 1) == 0 ? 0.4f : -0.4f;
            return new Vector3(x, y, z).normalized;
        }

        private void SpawnOrgans(Vector3 pos, Vector3 swingDir)
        {
            if (_organPool == null) return;
            Transform survivor = transform.parent;
            for (int i = 0; i < _organCount; i++)
            {
                var prefab = _organPool.PickRandom(_organSize);
                if (prefab == null) continue;
                var organ = Instantiate(prefab, pos,
                    Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f)),
                    survivor);

                var rb = organ.GetComponent<Rigidbody>();
                if (rb == null) rb = organ.AddComponent<Rigidbody>();
                rb.isKinematic = false;

                Vector3 jitter = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
                Vector3 dir = (jitter + Vector3.up * _organUpwardBias + swingDir.normalized * 0.5f).normalized;
                rb.AddForce(dir * _organImpulse, ForceMode.Impulse);
                rb.AddTorque(Random.insideUnitSphere * _organImpulse, ForceMode.Impulse);

                if (_organLifetime > 0f) Destroy(organ, _organLifetime);
            }
        }
    }
}
