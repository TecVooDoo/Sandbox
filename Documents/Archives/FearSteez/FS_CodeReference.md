# FearSteez - Code Reference

Purpose: Quick reference for existing code, APIs, and conventions. Check this before writing new code to avoid referencing non-existent classes or methods.

Last Updated: 2026-03-08

---

## File Locations Quick Reference

| Type | Location |
|------|----------|
| Scripts | `Assets/_Sandbox/FearSteez/Scripts/<Namespace>/` |
| GameEvent SOs | `Assets/_Sandbox/FearSteez/Data/Events/` |
| Data SOs | `Assets/_Sandbox/FearSteez/Data/<Type>/` |
| Input Actions | `Assets/_Sandbox/FearSteez/Settings/` |
| Scenes | `Assets/_Sandbox/FearSteez/Scenes/` |
| Prefabs | `Assets/_Sandbox/FearSteez/Prefabs/` |

---

## Assembly Definitions

| Assembly | Root Namespace | References |
|----------|---------------|------------|
| FS.Data | FS.Data | (none) |
| FS.Core | FS.Core | FS.Data, UniTask |
| FS.Combat | FS.Combat | FS.Data, FS.Core, Kybernetik.Animancer |
| FS.Player | FS.Player | FS.Data, FS.Core, FS.Combat, Kybernetik.Animancer, Unity.InputSystem |
| FS.Enemy | FS.Enemy | FS.Data, FS.Core, FS.Combat, Kybernetik.Animancer, Unity.AI.Navigation |
| FS.Progression | FS.Progression | FS.Data, FS.Core, UniTask |
| FS.UI | FS.UI | FS.Data, FS.Core, FS.Progression, UniTask, Flexalon |
| FS.Audio | FS.Audio | FS.Core, UniTask |
| FS.Editor | FS.Editor | All above + Kybernetik.Animancer.Editor, Unity.Cinemachine.Editor |

**Key rule:** FS.Player and FS.Enemy are peers -- neither references the other. Cross-cutting contracts live in FS.Combat (e.g., IDamageable). Master Audio and Koreographer have no asmdefs (Assembly-CSharp); bridge via GameEvent SOs.

---

## Namespaces

| Namespace | Purpose | Status |
|-----------|---------|--------|
| FS.Core | Game state, managers, shared utilities | Planned |
| FS.Player | Player movement, combat, input | Active |
| FS.Enemy | Enemy AI, behavior, spawning | Active |
| FS.Combat | Damage, hitboxes, combos | Active |
| FS.Progression | XP, levels, stats | Planned |
| FS.UI | Menus, HUD, overlays | Planned |
| FS.Audio | Music, SFX managers | Planned |
| FS.Data | ScriptableObject definitions | Active |
| FS.Editor | Editor utilities, tools | Planned |

---

## Scripts

### FS.Player

---

#### FSInputHandler
**File:** `Scripts/Player/FSInputHandler.cs`
**Requires:** MonoBehaviour on same GameObject as FSPlayerController
**Purpose:** Wraps FSInputActions InputActionAsset. Reads move each frame, fires events for buttons.

```csharp
// Serialized
[SerializeField] private InputActionAsset actions; // assign FSInputActions asset

// Public API
public Vector2 MoveInput { get; private set; }   // read each frame in Update
public event Action OnAttackPressed;               // fired on J / Gamepad West performed
public event Action OnJumpPressed;                 // fired on Space / Gamepad North performed
```

**Notes:**
- Enables/disables the entire action asset in OnEnable/OnDisable.
- Subscribe to events in OnEnable, unsubscribe in OnDisable.

---

#### FSPlayerController
**File:** `Scripts/Player/FSPlayerController.cs`
**Requires:** CharacterController, AnimancerComponent (both on same GameObject)
**Purpose:** Beat 'em up movement on XZ plane. Reads FSInputHandler.MoveInput, drives CharacterController, clamps Z to lane, rotates to face X, drives Animancer locomotion.

```csharp
// Serialized
[SerializeField] private FSInputHandler input;
[SerializeField] private float moveSpeed = 5f;
[SerializeField] private float gravity   = -20f;
[SerializeField] private float turnSpeed = 720f;  // deg/sec
[SerializeField] private float zMin = -4f;        // lane near boundary
[SerializeField] private float zMax =  4f;        // lane far boundary
[SerializeField] private AnimationClip idleClip;
[SerializeField] private AnimationClip runClip;

// Internal API (called by FSCombatController)
internal void OnAttackEnded(); // resets clip tracking so locomotion resumes after attack
```

**Notes:**
- Horizontal movement is zeroed during `FSCombatController.IsAttacking` OR `FSPlayerHealth.IsStaggered`.
- Rotation only tracks X input (left/right facing); Z input does not affect rotation.
- moveInput.y maps directly to world Z (positive = away from camera = deeper into scene).

---

#### FSCombatController
**File:** `Scripts/Player/FSCombatController.cs`
**Requires:** AnimancerComponent, FSInputHandler (both on same GameObject)
**Purpose:** 3-hit combo system. Subscribes to OnAttackPressed, plays combo attack animations via Animancer, sphere-overlaps during impact window, applies damage via IDamageable.

```csharp
// Serialized
[SerializeField] private FSAttackData[] _comboAttacks; // assign 3 FSAttackData SOs
[SerializeField] private LayerMask      _enemyLayer;   // default -1 (Everything)

// Public API
public bool IsAttacking { get; private set; }
```

**Combo flow:**
1. J pressed -> `StartAttack()`: plays `_comboAttacks[0].Clip` with 0.1f fade.
2. J pressed again when `NormalizedTime >= ImpactEnd`: advances `_comboIndex`, plays next clip.
3. `Update()`: polls `NormalizedTime`. Activates hitbox between ImpactStart and ImpactEnd.
4. Animation end (`NormalizedTime >= 1f` OR `!IsPlaying`) -> `EndAttack()`: resets `_comboIndex` to 0, notifies FSPlayerController.
5. Last hit in combo blocks further chaining until reset.
6. `!IsPlaying` fallback covers cases where stagger or another system overwrites the attack animation.

**Gizmo:** Red sphere in Scene view shows hitbox position when FSCombatController is selected.

---

#### FSPlayerHealth
**File:** `Scripts/Player/FSPlayerHealth.cs`
**Requires:** AnimancerComponent (on same GameObject)
**Implements:** IDamageable
**Purpose:** Player health, hit reactions, death. Enemies damage Steez through IDamageable. Stagger freezes movement briefly. Invincibility window prevents stun-lock.

```csharp
// Serialized
[SerializeField] private float _maxHp = 100f;
[SerializeField] private AnimationClip _hitClip;              // hit reaction anim
[SerializeField] private AnimationClip _deathClip;            // death anim
[SerializeField] private float _staggerDuration = 0.4f;       // movement freeze on hit
[SerializeField] private float _invincibilityDuration = 0.6f; // i-frames after hit

// Public API
public bool  IsStaggered { get; }  // true while stagger timer active
public bool  IsDead      { get; }  // true after HP <= 0
public float CurrentHp   { get; }  // for UI binding
public float MaxHp       { get; }  // for UI binding

// Implements IDamageable
public void TakeDamage(float amount);
```

**Notes:**
- On hit: plays hitClip, starts stagger timer + invincibility timer.
- FSPlayerController checks `IsStaggered` to freeze horizontal movement (same pattern as `IsAttacking`).
- On death: disables FSInputHandler, FSCombatController, FSPlayerController. Plays deathClip.
- Invincibility window prevents rapid-fire hits from multiple enemies causing permanent stun-lock.

---

#### FSTestCombatController
**File:** `Scripts/Player/FSTestCombatController.cs`
**Requires:** AnimancerComponent, FSInputHandler (on same GameObject)
**Purpose:** Numpad 0-9 fires specific FSAttackData SOs for systematic animation evaluation. Allows interrupting current attack for rapid testing. No combo chaining.

```csharp
// Serialized
[SerializeField] private FSAttackData[] _attacks;    // 10 slots (numpad 0-9)
[SerializeField] private LayerMask      _enemyLayer; // default -1

// Public API
public bool IsAttacking { get; }
```

**Notes:**
- Numpad 0-9 maps to `_attacks[0..9]`. Missing slot = no action.
- Logs `[TEST ATTACK] Slot X: AttackName (Level/Weight/Direction)` on each fire.
- Same hitbox/impact window system as FSCombatController.
- FSPlayerController checks `_testCombat.IsAttacking` to freeze movement.
- Designed for use with EnemyTestDummy (stationary target for evaluating hit reactions).

---

### FS.Enemy

---

#### EnemyTestDummy
**File:** `Scripts/Enemy/EnemyTestDummy.cs`
**Requires:** AnimancerComponent (on same GameObject)
**Purpose:** Stationary test dummy for evaluating hit reaction clips. Faces player, plays idle, does not move or attack. Handles its own stagger recovery.

```csharp
// Serialized
[SerializeField] private Transform     _player;
[SerializeField] private AnimationClip _idleClip;

// Called by EnemyHealth
public void Stagger(float duration);
```

**Notes:**
- Sets `applyRootMotion = false` in Awake (normally done by FSEnemyBrain, which is disabled on test dummies).
- Faces player via X direction comparison (Y=90/-90 rotation).
- After stagger timer expires, automatically returns to idle animation.
- EnemyHealth routing: dummy (if enabled) is checked before brain (if enabled) before patrol.
- Replaces FSEnemyBrain and EnemyPatrol during testing -- disable those components, enable this one.

---

#### EnemyHealth
**File:** `Scripts/Enemy/EnemyHealth.cs`
**Requires:** AnimancerComponent (on same GameObject)
**Implements:** IDamageable
**Purpose:** Receives damage, spawns damage number popup, plays hit/death reactions, coordinates with FSEnemyBrain or EnemyPatrol.

```csharp
// Serialized
[SerializeField] private float              _maxHp           = 50f;
[SerializeField] private FrankHitReactionDB _hitReactionDB;  // project-wide reaction DB
[SerializeField] private AnimationClip      _fallbackHitClip; // fallback when DB absent
[SerializeField] private AnimationClip      _deathClip;       // fallback KO when DB absent
[SerializeField] private DamageNumber       _damagePopup;     // DamageNumbersPro prefab
[SerializeField] private Vector3            _popupOffset;     // world offset for popup spawn
[SerializeField] private LayerMask          _groundLayer = -1; // death snap raycast

// Public API
public bool IsDead { get; }

// Implements IDamageable
public void TakeDamage(float amount, HitLevel hitLevel, HitWeight hitWeight, HitDirection hitDirection);
```

**Notes:**
- On hit: spawns damage popup, queries FrankHitReactionDB for reaction clip (falls back to _fallbackHitClip). Passes HitDirection to DB for directional matching.
- Stagger routing: checks EnemyTestDummy (if enabled) -> FSEnemyBrain (if enabled) -> EnemyPatrol. The `.enabled` check is critical because GetComponentInParent finds disabled components.
- On death: snaps to ground (disables own colliders permanently), draws KO clip from DB or _deathClip, calls brain.Die(), disables self.
- SnapToGround: disables all colliders in parent hierarchy so raycast doesn't self-hit. Colliders stay disabled -- dead enemies don't block movement.

---

#### EnemyPatrol
**File:** `Scripts/Enemy/EnemyPatrol.cs`
**Requires:** AnimancerComponent (on same GameObject), humanoid avatar
**Purpose:** X-axis patrol between spawnX +- patrolRange. Pauses at each end. Freezes during hit stagger. Head look-at IK tracks player when nearby.

```csharp
// Serialized -- Patrol
[SerializeField] private float _patrolRange   = 3f;   // +- X from spawn position
[SerializeField] private float _moveSpeed     = 1.5f;
[SerializeField] private float _pauseDuration = 0.6f;

// Serialized -- Animations
[SerializeField] private AnimationClip _idleClip;
[SerializeField] private AnimationClip _walkClip;

// Serialized -- Look At
[SerializeField] private Transform _player;            // drag Steez here
[SerializeField] private float     _lookAtPlayerRange = 4f;
[SerializeField] private float     _lookAtWeight      = 0.7f;  // tune -- currently near-180 at close range
[SerializeField] private float     _lookAtEyeHeight   = 1.5f;

// Called by EnemyHealth
public void Stagger(float duration); // freezes patrol movement for duration seconds
```

**Notes:**
- `applyRootMotion = false` set in Awake -- required or walk animation overrides rotation.
- `Layers[0].ApplyAnimatorIK = true` enables OnAnimatorIK callback for look-at.
- Kevin Iglesias HumanM rig: face points in local +X. Y=0 = facing screen right, Y=180 = facing left.
- Look-at uses `transform.right` (local +X) as forward direction for patrol target point.
- _lookAtWeight needs tuning down -- at 0.7f the head over-rotates on close approach.

---

#### FSEnemyBrain
**File:** `Scripts/Enemy/FSEnemyBrain.cs`
**Requires:** AnimancerComponent (on same GameObject), humanoid avatar
**Purpose:** Beat 'em up enemy AI. Enum state machine: Patrol -> Chase -> AttackWindup -> Attack -> Cooldown. Replaces EnemyPatrol for combat-capable enemies.

```csharp
// Serialized -- Detection
[SerializeField] private Transform _player;
[SerializeField] private float _detectionRange = 6f;
[SerializeField] private float _attackRange    = 1.2f;

// Serialized -- Movement
[SerializeField] private float _patrolSpeed = 1.5f;
[SerializeField] private float _chaseSpeed  = 2.5f;
[SerializeField] private float _patrolRange = 3f;

// Serialized -- Combat
[SerializeField] private FSAttackData[] _attacks;        // reuses same SO as player combo
[SerializeField] private float _windupDuration  = 0.35f; // telegraph pause before attack
[SerializeField] private float _cooldownDuration = 0.8f; // pause after attack
[SerializeField] private LayerMask _playerLayer;          // layer(s) to hit

// Serialized -- Animations
[SerializeField] private AnimationClip _idleClip;
[SerializeField] private AnimationClip _walkClip;         // patrol movement
[SerializeField] private AnimationClip _runClip;          // chase movement (falls back to walkClip)

// Public API (called by EnemyHealth)
public bool IsIncapacitated { get; }         // true if Stagger or Dead
public void Stagger(float duration);         // interrupt any state, freeze
public void Die();                           // permanent disable
```

**State machine:**
1. **Patrol** -- walk +-patrolRange from spawn. Checks detection range each frame.
2. **PatrolPause** -- idle at patrol endpoint. Still checks detection.
3. **Chase** -- move toward player on XZ plane. Uses runClip. Loses interest at 1.5x detection range (hysteresis).
4. **AttackWindup** -- brief idle pause (telegraph). Faces player. Position locked.
5. **Attack** -- plays random FSAttackData clip, checks hitbox during impact window via OverlapSphere. Position locked.
6. **Cooldown** -- post-attack idle pause, then re-evaluates (chase or patrol). Position locked.
7. **Stagger** -- frozen by EnemyHealth hit. Position locked. Returns to chase or patrol after duration.
8. **Dead** -- permanently disabled.

**Position locking:** States 4-7 lock `transform.position` to the value captured at AttackWindup/Stagger entry. Prevents root motion in humanoid attack/hit clips from sliding the enemy.

**Facing convention:** Kevin Iglesias HumanM mesh faces +Z (standard Unity). `FaceDirection()` uses Y=90 for screen right, Y=-90 for screen left. Uses Forward locomotion clips (Walk01_Forward, Run01_Forward), NOT strafe clips.

**Gizmos:** Yellow wire = detection range, red wire = attack range, blue line = patrol range, red sphere = attack hitbox.

**Key difference from EnemyPatrol:** FSEnemyBrain handles patrol AND combat. Use one or the other, not both. EnemyHealth auto-detects which is present.

---

### FS.Combat

---

#### IDamageable (interface)
**File:** `Scripts/Combat/IDamageable.cs`
**Purpose:** Decouples FS.Player from FS.Enemy. Any entity that can take damage implements this.

```csharp
public interface IDamageable
{
    bool IsDead { get; }
    void TakeDamage(float amount, HitLevel hitLevel = HitLevel.High, HitWeight hitWeight = HitWeight.Full, HitDirection hitDirection = HitDirection.Front);
}
```

---

#### FSCombatLogger
**File:** `Scripts/Combat/FSCombatLogger.cs`
**Purpose:** Debug logging for hit reactions and KO clips. G-key flags current reaction as BAD CLIP for review.

```csharp
public static void LogReaction(string enemyName, string clipName, string hitLevel, string hitWeight, string hitDirection);
public static void LogKO(string enemyName, string clipName, string hitLevel);
```

---

### FS.Data

---

#### FSAttackData (ScriptableObject)
**File:** `Scripts/Data/FSAttackData.cs`
**Menu:** Assets > Create > FS > Attack Data
**Purpose:** Data container for one attack move. Drives FSCombatController and FSTestCombatController.

```csharp
public AnimationClip Clip           { get; }  // attack animation
public HitLevel      HitLevel      { get; }  // High/Mid/Low/Sweep/Launch
public HitWeight     HitWeight     { get; }  // Lite (jab/flinch) or Full (heavy stagger)
public HitDirection  HitDirection  { get; }  // Front/Left/Right/Back (attacker's perspective)
public int           StartupFrames { get; }  // frames before hitbox activates (60fps)
public int           ActiveFrames  { get; }  // frames hitbox is active
public int           RecoveryFrames { get; } // frames after active until animation ends
public float         ImpactStart   { get; }  // normalized time derived from frame counts
public float         ImpactEnd     { get; }  // normalized time derived from frame counts
public float         Damage        { get; }  // damage applied to IDamageable
public float         HitboxRadius  { get; }  // sphere radius in world units
public Vector3       HitboxOffset  { get; }  // local-space offset from attacker origin
```

**Enums (defined in FSAttackData.cs):**
- `HitLevel`: High, Mid, Low, Sweep, Launch
- `HitWeight`: Lite (quick flinch), Full (real stagger)
- `HitDirection`: Front (straight/uppercut, head snaps back), Left (attacker's left hand), Right (attacker's right hand), Back (hit from behind, rare)

---

#### FrankHitReactionDB (ScriptableObject)
**File:** `Scripts/Data/FrankHitReactionDB.cs`
**Menu:** Assets > Create > FS > Frank Hit Reaction DB
**Purpose:** Project-wide pool of Frank hit reaction and KO clips. Enemies reference this SO instead of per-enemy clip arrays.

```csharp
// Lookup: (HitLevel, HitWeight, HitDirection) -> random AnimationClip
public AnimationClip GetReactionClip(HitLevel level, HitWeight weight, HitDirection attackerDirection = HitDirection.Front);
public AnimationClip GetKOClip(HitLevel level);
```

**Direction flip:** Attacker's Left -> victim's Right (and vice versa). Front/Back stay absolute. Fallback: exact match -> Front pool -> _fallbackClip.
**KO pools:** _koHigh (also collects Sweep/Launch), _koMid, _koLow.
**Population:** FS > Populate FrankHitReactionDB editor menu reads Frank_AnimCatalog.csv.

---

## Input Actions

**Asset:** `Assets/_Sandbox/FearSteez/Settings/FSInputActions.inputactions`

### Player Map

| Action | Type | Keyboard | Gamepad |
|--------|------|----------|---------|
| Move | Vector2 | WASD + Arrow Keys | Left Stick |
| Attack | Button | J | West (Square/X) |
| Jump | Button | Space | North (Triangle/Y) |

**Control Schemes:** Keyboard&Mouse, Gamepad

---

## Interfaces

| Interface | Namespace | Status | Notes |
|-----------|-----------|--------|-------|
| IDamageable | FS.Combat | Active | Implemented by EnemyHealth and FSPlayerHealth. |
| IEnemy | FS.Combat | Planned | Base enemy contract |
| IAttack | FS.Combat | Planned | Attack action contract |
| ICombatant | FS.Combat | Planned | Entity that can fight |
| IInteractable | FS.Combat | Planned | Objects player can interact with |

---

## ScriptableObjects

| Type | Namespace | Status | Menu Path | Notes |
|------|-----------|--------|-----------|-------|
| FSAttackData | FS.Data | Active | FS/Attack Data | One per attack move (Level/Weight/Direction + frame data) |
| FrankHitReactionDB | FS.Data | Active | FS/Frank Hit Reaction DB | Project-wide reaction + KO clip pools |
| WeaponData | FS.Data | Planned | FS/Weapon Data | AttackContainer[] -- swap = swap attack set |
| EnemyData | FS.Data | Planned | FS/Enemy Data | Stats, behavior config |
| ProgressionData | FS.Data | Planned | FS/Progression Data | Level thresholds |

---

## Scene -- TestScene

**Path:** `Assets/_Sandbox/FearSteez/Scenes/TestScene.unity`

**Hierarchy:**
- Directional Light
- Ground (Plane, 200x30 units)
- Wall_Left / Wall_Right (boundaries at +-100 X)
- Main Camera + CinemachineBrain
- CM_SideScroll (CinemachineCamera + CinemachineFollow, offset (0,2,-8) WorldSpace)
- FearSteez (CharacterController, AnimancerComponent, FSInputHandler, FSPlayerController, FSCombatController, FSTestCombatController, FSPlayerHealth, Layer=Player)
- Civilian01 (AnimancerComponent, EnemyHealth, FSEnemyBrain, CapsuleCollider, Layer=Enemy) -- hidden during testing
- Zombie01 (AnimancerComponent, EnemyHealth, FSEnemyBrain, CapsuleCollider, Layer=Enemy) -- hidden during testing
- CivilianTest (AnimancerComponent, EnemyHealth, EnemyTestDummy, CapsuleCollider, Layer=Enemy) -- brain disabled, dummy enabled

---

## Conventions

### Coding Standards

- No `var` -- explicit types always
- No per-frame allocations or LINQ
- Prefer async/await (UniTask) over coroutines
- ASCII-only in code and comments
- `sealed` on MonoBehaviours unless inheritance is intended
- Private fields: `_camelCase` with underscore prefix

### Naming

- Namespaces: `FS.<System>`
- Scripts: PascalCase, FS prefix for project scripts
- Private fields: `_camelCase`
- Serialized fields: `[SerializeField] private Type _fieldName`
- Events: `OnVerbNoun` (e.g., `OnAttackPressed`)

### Animancer Usage

- Always use `AnimancerComponent` (not Animator directly for character animation)
- `_animancer.Play(clip, fadeDuration)` -- returns `AnimancerState`
- Loop clips: must set `loopTime=true` in FBX ModelImporter (not at runtime -- `IsLooping` is get-only)
- Non-looping attack clips: check `state.NormalizedTime >= 1f` OR `!state.IsPlaying` for end detection
- Animancer Pro 8.2.3 assembly name: `Kybernetik.Animancer`
- IK: `_animancer.Layers[0].ApplyAnimatorIK = true` enables `OnAnimatorIK` callback. Set in Awake. Required for `SetLookAtWeight`/`SetLookAtPosition` to fire.
- Root motion: set `_animancer.Animator.applyRootMotion = false` when script drives transform movement, or walk clips will fight script rotation. Even with this, humanoid clips may have baked root bone motion -- lock `transform.position` during attack/stagger states as a safety measure.

### Roslyn (MCP script-execute)

- Cannot use `using FS.Player;` directly -- use `Type.GetType("FS.Player.FSInputHandler, FS.Player")`
- HTML-encodes `<>` and `&&` -- use `typeof()` casts and nested if-statements
- Call `.Save()` / `SetDirty()` / `SaveAssets()` -- changes don't auto-persist
- MCP disconnects during domain reload -- wait for auto-reconnect

---

## Dependencies Reference

### Animancer Pro 8.2.3

```csharp
using Animancer;

AnimancerComponent _animancer = GetComponent<AnimancerComponent>();
AnimancerState state = _animancer.Play(clip, fadeDuration);
float t = (float)state.NormalizedTime; // 0..1 for non-looping, wraps for looping
```

### New Input System

```csharp
using UnityEngine.InputSystem;

// Recommended pattern (FSInputHandler style):
InputActionMap map = actions.FindActionMap("Player", throwIfNotFound: true);
InputAction move = map.FindAction("Move", throwIfNotFound: true);
Vector2 val = move.ReadValue<Vector2>();
```

### UI Toolkit

No uGUI. All UI uses UIDocument + UXML + USS.

```csharp
using UnityEngine.UIElements;

VisualElement root = uiDocument.rootVisualElement;
Label healthLabel = root.Q<Label>("health-label");
button.RegisterCallback<ClickEvent>(OnClick);
```

### UniTask

```csharp
using Cysharp.Threading.Tasks;

await UniTask.Delay(1000);
await UniTask.WaitUntil(() => condition);
```

### DOTween

```csharp
using DG.Tweening;

transform.DOMove(targetPos, duration);
transform.DOScale(targetScale, duration).SetEase(Ease.OutBack);
```

### ScriptableObject Architecture (Custom -- No SOAP Asset)

TecVooDoo standard: vanilla Unity SOs + custom GameEvent/GameEventListener pattern.

```csharp
// GameEvent SO -- raise a signal
[CreateAssetMenu(menuName = "FS/Events/GameEvent")]
public class GameEvent : ScriptableObject
{
    private readonly List<GameEventListener> listeners = new List<GameEventListener>();
    public void Raise() { for (int i = listeners.Count - 1; i >= 0; i--) listeners[i].OnEventRaised(); }
    public void RegisterListener(GameEventListener l) { if (!listeners.Contains(l)) listeners.Add(l); }
    public void UnregisterListener(GameEventListener l) { listeners.Remove(l); }
}

// GameEventListener component
public class GameEventListener : MonoBehaviour
{
    [SerializeField] private GameEvent gameEvent;
    [SerializeField] private UnityEvent response;
    private void OnEnable()  { gameEvent.RegisterListener(this); }
    private void OnDisable() { gameEvent.UnregisterListener(this); }
    public void OnEventRaised() { response.Invoke(); }
}

// Raising an event
[SerializeField] private GameEvent onPlayerDied;
onPlayerDied.Raise();
```

---

**End of Code Reference**
