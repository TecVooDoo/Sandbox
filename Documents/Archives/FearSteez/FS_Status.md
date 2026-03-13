# FS - Project Status

**Project:** FearSteez (FS) -- 2.5D Beat 'Em Up with RPG Elements
**Platform:** Unity 6 (6000.3.7f1), URP -- Sandbox subproject
**FS Root:** `Assets/_Sandbox/FearSteez/`
**GDD:** v2 (Mar 3, 2026)
**Codebase:** 10 scripts, 1 interface, 9 asmdefs
**Repo (original):** https://github.com/TecVooDoo/FearSteez

**Reference docs:** `FS_DevReference.md` (architecture, standards, lessons), `FS_CodeReference.md` (script API)

---

## Current Work

**Phase:** Active development. Core pipeline proven -- player moves, attacks land, enemy reacts.

**FearSteez-relevant packages confirmed in Sandbox:**
- FS Melee Combat System 2.0.6 -- cherry-pick reference (Animator-based, not runtime dep)
- Animancer Pro 8.2.3 -- animation control
- Frank FS3 + FS4 1.0 -- 243 combat clips (Punch04, Punch05, Kick05 used in combo)
- Frank Slash Pack 3.8 -- ~65 whip/rope clips
- Feel 5.9.1 -- screen shake, freeze frames, hit stop
- EasyPooling 2025.1 -- object pooling (reinstalled after cleanup)
- Boing Kit 1.2.47 -- BoingBones spring physics (hair, loose chains)
- Damage Numbers Pro 4.51 -- damage popups (wired into EnemyHealth)
- Easy Save 3.5.25 -- save/load
- DOTween Pro 1.0.410 -- tweening
- Master Audio 2024 1.0.3 -- music/SFX
- Koreographer Pro 1.6.3 -- BPM sync
- Final IK 2.4 -- full-body IK
- Flexalon Pro 4.4.0 -- UI layout
- Text Animator for Unity 3.5.0 -- text effects
- Full Kamgam UI Toolkit suite (Default UI) -- Blurred Background, Scroll View Pro, Sound Effects, Text Auto Size, Script Components, Custom Shader Image, Shadows/Glow, Particles
- Flow UI Toolkit Extended 1.5.1 -- fluent UI API
- Toolkit for UX 2026 5.0.0 -- UX framework
- Squash & Stretch Kit 1.1.2 -- hit juice (Feel complement)
- Kevin Iglesias Human Melee Animations 2.0.2 -- enemy locomotion/death/stun clips
- Fantacode Studios FS Parkour 1.9.9 -- ParkourAction SO cherry-pick pending

**Removed from Sandbox (Session 49):** Beat 'Em Up Game Template 3D, All In 1 3D-Shader, UFE2 Pro (cherry-pick documented), Photon, FishNet, PurrNet (networking deferred to v3 prototype phase)

**See FS_DevReference.md for full package reference.**

---

## Sessions

**Session 0 (Jan 27, 2026) -- Original Project:**
Created standalone FearSteez project at `E:\Unity\FearSteez`. New documentation system. Initial git commit. Imported all recommended packages. Added FS Melee Combat System for reference. Created folder structure. MCP connection issue unresolved.

**Session 1 (Feb 25, 2026) -- Sandbox Subproject:**
Moved FearSteez docs to Sandbox at `E:\Unity\Sandbox\Documents\FearSteez\`. Converted doc system to match HOK pattern (DevReference split, GDD subfolder, Archives cleanup). Imported Beat 'Em Up Game Template and Frank Slash Pack into Sandbox. Synty placeholder character at `Assets/Sandbox/FearSteez/`.

**Session 2 (Mar 3, 2026) -- Design Foundations:**
Doc review and ground-up design session. Key decisions locked: 3D on 2.5D plane, SO architecture (no SOAP), FS Melee Combat as base (Beat 'em Up Template cherry-pick only). New GDD content: player states (Steez/FearSteez Oni mask), weapon system (microphone exclusive + environmental pickups), cosmic entities (Oni guide, Chrome Robot Woman guide, Sorcerer antagonist), day/night framing (mind control vs raised dead), music BPM sync goal. GDD updated to v2. DevReference and CodeReference cleaned of SOAP references.

**Session 3 (Mar 3, 2026) -- Package Setup & Architecture:**
Completed Sandbox package audit. Confirmed full FearSteez-relevant package set (FS Melee, Animancer, Frank packs, Feel, EasyPooling, DOTween, All In 1, Koreographer, Master Audio, Final IK, UI Toolkit suite, Flexalon). UI Toolkit direction confirmed (no uGUI). Verified Timeflow/Animancer compatibility -- complementary, no conflict. GDD additions: co-op phasing (SP launch, local v2, online v3), DJ as Player 2 placeholder, online co-op uses Photon Fusion 2 (v3 concern only). Audio format confirmed: WAV 44.1kHz 24-bit stereo + stems. Next session plan established (see Active TODO).

**Session 4 (Mar 3, 2026) -- Audits & Weapon System Design:**
Audited FS Melee Combat System source code. Finding: uses Unity Animator + proprietary AnimGraph/AnimGraphClipInfo -- incompatible with Animancer. Also assumes 3D target-lock combat, wrong for beat 'em up. Both FS Melee AND Beat 'Em Up Template 3D are now cherry-pick reference only. Combat built from scratch with Animancer. Audited Frank Whip Pack (~80 clips) and FS3/FS4 unarmed packs (243 clips). Mapped Steez/FearSteez animation split to Whip pack. Designed weapon animation system: WeaponData SO with AttackContainer[] -- swap weapon = swap active attack set at runtime. Documented known gap: no weapon-specific locomotion for environmental pickups (bat, crowbar). Acceptable for prototype -- track for future Steez animation commission. Docs updated: FS_DevReference.md (Combat Framework rewrite, Weapon Animation System added), FS_Status.md (this entry).

**Session 6 (Mar 4, 2026) -- Combo System + Enemy Patrol:**
Damage Numbers Pro wired into EnemyHealth (popup spawns at hit position). FSCombatController rewritten: single `_attackData` replaced with `_comboAttacks[]` array -- J during recovery advances combo index, animation end resets to 0, last hit blocks further chaining. EnemyPatrol written: X-axis patrol between spawnX +- patrolRange, pause at each endpoint, stagger freeze on hit (called by EnemyHealth), death disables patrol. EnemyHealth updated: caches EnemyPatrol in Awake, calls Stagger(hitClip.length) on hit, sets patrol.enabled=false on death. Kevin Iglesias HumanM rig orientation documented: face in local +X (Y=0 = facing screen right, Y=180 = facing left). Root motion disabled on EnemyPatrol (applyRootMotion=false). Head look-at IK implemented via OnAnimatorIK + Layers[0].ApplyAnimatorIK=true: looks at player within LookAtPlayerRange, otherwise looks in direction of travel (transform.right * 5f). Look-at weight needs tuning (currently does near-full 180 rotation on close approach). Known Timeflow bug documented: triggers AssetDatabase.ImportPackage in play mode on selection change -- harmless, no workaround needed.

**Session 7 (Mar 4, 2026) -- Enemy AI + Player Health:**
FSEnemyBrain written: enum state machine (Patrol/PatrolPause/Chase/AttackWindup/Attack/Cooldown/Stagger/Dead). Replaces EnemyPatrol for combat-capable enemies. Detection range with 1.5x hysteresis for disengage. Attack uses FSAttackData SOs (same as player) with random pick. Windup telegraph (0.35s idle) before attack gives player reaction window. Cooldown (0.8s) after attack prevents spam. EnemyHealth updated to notify FSEnemyBrain (preferred) or EnemyPatrol. FSPlayerHealth written: IDamageable on player, hit reaction with stagger timer (0.4s movement freeze), invincibility window (0.6s) prevents stun-lock from multiple enemies. On death disables input/combat/movement. FSPlayerController updated to check IsStaggered alongside IsAttacking for movement freeze. All gizmos wired: yellow=detection, red=attack range, blue=patrol. Pending: TestScene wiring (add FSEnemyBrain to enemy, FSPlayerHealth to Steez, create enemy attack SOs, set Player layer).

**Session 15 (Mar 8, 2026) -- Player HUD + Enemy Death Polish + Playtest:**
Player health bar HUD built with UI Toolkit: PlayerHUD.uxml + PlayerHUD.uss + FSPlayerHUD.cs. Green->yellow->red gradient as HP drops, numeric display. FS.UI asmdef updated to reference FS.Player. FSPlayerHealth upgraded: FrankHitReactionDB wired for varied hit reactions (same pattern as EnemyHealth). ResolveHitClip(level, weight, direction) added; Die() queries DB for KO clip. Multi-enemy playtest with 4 Civilian01s + 2 Zombie01s confirmed combat pipeline working. FearSteez takes damage from enemies with varied reactions, health bar updates live. Floating dead body bug investigated extensively: (1) SnapToGround raycast with _groundLayer=Everything could hit nearby living enemy colliders -- fixed by setting _groundLayer to Ground layer in Inspector. (2) KO animation clips have baked hip-bone Y displacement as body animation (not root motion) -- transform stays at ground but mesh floats. Attempted fixes: PinToGround coroutine (transform correct but mesh still floats), applyRootMotion toggle (clips don't have extractable root motion), hip-bone offset compensation (Animator overwrites bone positions each frame). Working fix: disable Animator after KO clip finishes (bones freeze at final pose), then offset transform down using hip bone world Y. Visual artifact remains: body floats during KO animation then drops to ground when Animator is disabled -- needs smoothing. Enemy bodies now destroyed after configurable delay (_destroyDelay, default 5s). Removed SnapToGround/groundLayer system -- replaced by Animator-disable + hip-offset approach.

**Session 14 (Mar 8, 2026) -- HitDirection System + Animation Test Rig:**
Dead enemy collider fix: SnapToGround no longer re-enables colliders -- dead enemies don't block player movement. HitDirection enum (Front/Left/Right/Back) added as third dimension to hit reaction system -- explicit values (Front=0, Left=1, Right=2, Back=3) preserve serialized data. FSAttackData now carries HitDirection (from attacker's perspective). FrankHitReactionDB flips attacker direction to victim perspective (Left punch -> Right reaction, Front/Back unchanged) and pools are now keyed by (HitLevel, HitWeight, HitDirection). Fallback chain: exact direction match -> Front pool -> _fallbackClip. IDamageable.TakeDamage extended with HitDirection param. FSCombatLogger.LogReaction includes direction. FrankHitReactionDBPopulator updated: CSV Context column maps to HitDirection (Front/empty -> Front, Back -> Back, Left -> Left, Right -> Right). Animation test rig built: FSTestCombatController (numpad 0-9 fires specific FSAttackData SOs, allows interrupting for rapid evaluation, auto-disables FSCombatController OnEnable to prevent shared AnimancerComponent conflicts) + EnemyTestDummy (faces player, plays idle, handles stagger recovery via timer). CivilianTest created in TestScene (copy of Civilian01 with brain disabled, dummy enabled, HP=9999, FrankHitReactionDB wired). Bugs fixed: (1) test dummy sinking into ground -- EnemyTestDummy.Awake sets applyRootMotion=false (normally done by FSEnemyBrain). (2) Enemy frozen in hit reaction -- GetComponentInParent finds disabled FSEnemyBrain, so Stagger called on disabled brain whose Update never runs. Fix: EnemyHealth checks _dummy.enabled first, then _brain.enabled, then patrol. (3) Bad uppercut reactions -- Back-context clips mixed into Center pool. Fixed by splitting Center into Front/Back with separate pools. (4) Damage_Strong_F1/F2 body-folds-in-air -- reclassified from Reaction to Conditional in CSV (weapon-only). (5) Same-frame double-hit on clip replay -- TryAttack now returns immediately, skipping impact window check that frame. Multi-hit bug partially reduced but not fully resolved -- diagnostic OverlapSphere logging added for next test.

**Session 13 (Mar 8, 2026) -- DB Population + Civilian Conversion Design:**
FrankHitReactionDBPopulator fixes: (1) OOM crash fix confirmed -- narrowed ScanFolders to 6 specific subfolders. (2) Trailing-space trim on clip names fixed Whip Hit02/Hit05/Hit_Skill02/Die02. (3) FS4 typo alias (Hit_High_Lfte -> Hit_High_Left). (4) 2Handed Root_Motion exemption added for Knockback/Knockdown clips. Final result: 164 matched / 15 missed (all misses are weapon-specific Critical clips from unscanned weapon folders -- intentional). DB populated: High/Lite 10, High/Full 64, Mid/Lite 12, Mid/Full 7, Low/Lite 5, Low/Full 15, Sweep/Full 22, Launch/Full 8; KO High 13, Mid 4, Low 4. Animation layer split clarified: Synty = civilian layer (idle, walk, run, emotes, taunts, flee, spectate); Frank = combat layer (attacks, hit reactions from DB, KOs, blocks) -- only active on hostile NPCs. Civilian conversion design noted: Tecnomancer controls civilians (3/5 convertible), remaining run or spectate; defeated enemies can trigger spectator conversion; zombies convert civilians to zombies.

**Session 12 (Mar 7, 2026) -- HitWeight System + Frank Slash Pack Catalog:**
HitWeight enum (Lite/Full) added to FSAttackData.cs alongside HitLevel. IDamageable.TakeDamage extended to 3 parameters: `(float amount, HitLevel hitLevel = HitLevel.High, HitWeight hitWeight = HitWeight.Full)`. FSCombatController and FSEnemyBrain both pass data.HitWeight through. FSPlayerHealth signature updated to match interface (still ignores level and weight). EnemyHealth overhauled: HitReactionEntry struct removed; _defaultHitClip/_hitReactions[] replaced by FrankHitReactionDB reference (_hitReactionDB) + _fallbackHitClip. ResolveHitClip(level, weight) queries DB first, falls to fallback. Die(killingLevel) draws KO clip from DB, falls back to _deathClip if no DB assigned. Frank_AnimCatalog.csv expanded: Slash Pack Damage reactions catalogued (~80 rows covering High/Mid/Low directional, Strong body-part, KnockDown, Air, Wall, Bound, Sting, Parrying, Critical, Stun state machine, Electric Shock); Slash KO/Getup rows added; Whip set fully enumerated (78 clips -- equip, 8-way locomotion, guard walk, jump, evade, guard/block, hit reactions, die, Attack01-06, Skill01-02, Combo01-05 All + splits); 2Handed set fully enumerated (57 clips -- all combat categories, 5 combo lines). Design decision locked: Whip = Steez mic cord/rope dart weapon; 2Handed = bat/crowbar enemy types. Next session: create FrankHitReactionDB SO asset and populate from catalog.

**Session 11 (Mar 7, 2026) -- Synty Enemy Setup:**
Deep research into Synty Sidekick Characters system. FS_Synty_Reference.md created covering skeleton, all animation packs, naming conventions, FacialController, PropBoneTool, and FSEnemyBrain integration tables. Key finding: Frank FS3 is the correct punch/kick source for ALL enemies (Synty SWD pack has sword/bow attacks only, no straight punches or kicks). Mecanim retargeting means the player's existing Punch01/Punch02 FSAttackData SOs work directly on Synty humanoid enemies. Naming convention locked: `A_MOD_BL_*` = BaseLocomotion (human/civilian rig), `A_MOD_GBL_*` = GoblinBaseLocomotion (goblin-boned zombies), `A_MOD_SWD_*` = SwordCombat (retargets to both). Civilian01 set up in TestScene: ApocalypseOutlaw prefab, FSEnemyBrain + EnemyHealth, `A_MOD_BL_*` locomotion clips, Punch01/Punch02 attack SOs, `Frank_FS3@Hit_High_F` stagger, `Frank_FS3@KO_Mid_2` death. Zombie01 set up: ApocalypseZombie prefab, FSEnemyBrain + EnemyHealth, `A_MOD_GBL_*` locomotion clips, Swipe01/Swipe02 custom attack SOs, same Frank hit/death clips. Both confirmed working in playtest. EnemyPatrol NOT wired (FSEnemyBrain handles patrol internally and disables it). Dummy HumanM character removed from TestScene -- now contains FearSteez + Civilian01 + Zombie01. Future polish: HitLevel enum on FSAttackData to match stagger clip to attack level (high/mid/low/sweep).

**Session 10 (Mar 7, 2026) -- Prefab Swap + Bug Fixes:**
Swapped old Steez prefab in TestScene for new FearSteez prefab (Oni mask + sunglasses, Synty Sidekick). New prefab is art-only -- manually re-added all 6 components (CharacterController, AnimancerComponent, FSInputHandler, FSPlayerController, FSCombatController, FSPlayerHealth) and re-wired all Inspector fields. SwapPlayerPrefab.cs one-shot editor script used to handle prefab replacement and FSEnemyBrain._player re-wiring. Bugs fixed: (1) FearSteez floating -- CharacterController Center Y was 0, needs Y=1 for correctly-pivoted Synty humanoid. (2) No hit detection on FearSteez -- missing CapsuleCollider (trigger, Center Y=1, Radius=0.3, Height=1.8) needed for enemy OverlapSphere. (3) Player attacks not landing -- FSCombatController and FSEnemyBrain used GetComponent<IDamageable>() -- changed to GetComponentInParent for robustness when collider is on child GO. Enemy layer on FSCombatController had been changed to Ledge -- reset to Enemy. (4) Enemy death bug -- EnemyHealth used GetComponent<FSEnemyBrain>() which returned null when on child GO; changed to GetComponentInParent. Also EnemyHealth.Die() only disabled EnemyPatrol if brain was null (else-if) -- both are now always disabled. (5) Enemy running against strong wind -- EnemyPatrol and FSEnemyBrain both active simultaneously, fighting for transform.position and rotation (different Y rotation conventions). Fixed by disabling EnemyPatrol in FSEnemyBrain.Awake(). (6) Camera not following -- Cinemachine Tracking Target reference went stale after prefab swap; re-assigned by dragging FearSteez from Hierarchy.

**Session 9 (Mar 6, 2026) -- Asset Evals + Package Cleanup:**
Continued from Session 8 context limit. AssetLog gaps filled: ENTRY-261/262/263 (Breeze, GOAP v3, Convai) detailed blocks written (Deferred). Three new assets installed and evaluated: All In 1 Springs Toolkit 1.7 (ENTRY-268, Conditional -- unique value is ShaderFloat/AudioSource/Light springs; overlaps Feel/Boing Kit for other types), All In 1 Shader Nodes 1.12 (ENTRY-269, Recommended -- 101 ASE nodes + SG subgraphs for every common shader effect), Advanced FPS Counter 1.5.7 (ENTRY-270, Approved -- FPS + memory + device info overlay, complements Ninja Profiler). com.tecvoodoo.mcp-tools package cleaned: orphaned FinalIK.meta and PrefabWorldBuilder.meta deleted. FearSteez prefab updated: `Assets/_Sandbox/FearSteez/Prefabs/FearSteez/` -- new default prefab with Oni face mask and sunglasses (activate/deactivate to switch between Steez/FearSteez power states).

**Session 8 (Mar 4, 2026) -- Bug Fixes + Playtesting:**
FBX loopTime bug: Frank_FS3@Idle and Frank_FS3@Run(Fast) lost loopTime=true when Frank Fighting Set 4 was reimported during Sandbox cleanup. Fixed by adding explicit clipAnimations entries with loopTime=1 in FBX meta. Note: adding explicit clip entries changes internal clip IDs -- serialized references must be re-assigned. Enemy sliding during attack/stagger: humanoid attack and hit reaction clips have baked root bone motion that moves the transform even with applyRootMotion=false. Fixed by locking transform.position during AttackWindup, Attack, Cooldown, and Stagger states. Position captured at state entry and enforced each frame. Player can't punch again after landing first hit: FSCombatController EndAttack() only triggered on NormalizedTime >= 1f. If another system (stagger) overwrites the attack animation, IsPlaying becomes false but NormalizedTime never reaches 1 -- player stuck in ghost IsAttacking=true state. Added !_attackState.IsPlaying fallback check. Enemy facing direction confirmed working: Y=90/-90 for +Z-facing Kevin Iglesias mesh with Forward locomotion clips.

**Session 5 (Mar 3, 2026) -- Core Pipeline: Movement + Combat:**
Built full prototype pipeline from scratch. asmdef structure established (9 assemblies: FS.Data, FS.Core, FS.Combat, FS.Player, FS.Enemy, FS.Progression, FS.UI, FS.Audio, FS.Editor). Input: FSInputActions.inputactions (Move/Attack/Jump, WASD + Arrow Keys + Gamepad), FSInputHandler wrapping InputActionAsset. Movement: FSPlayerController -- 8-directional CharacterController on XZ plane, Z-constrained to beat 'em up lane (+-4 units), Animancer locomotion (idle/run with 0.15f crossfade), turn-to-face-X. FBX loop bug fixed: Idle and Run(Fast) clips set to loopTime=true via ModelImporter. Combat: IDamageable interface (FS.Combat), FSAttackData SO (clip + impact window 0-1 normalized + hitbox offset/radius), FSCombatController (subscribes to OnAttackPressed, plays attack clip, OverlapSphere during impact window), EnemyHealth (implements IDamageable, plays hit/death clips). TestScene wired: Steez with all components, HumanM_Dummy_Red as enemy (AnimancerComponent + EnemyHealth + CapsuleCollider, Enemy layer 14). Bugs fixed this session: FBX animation loop, Z-depth movement inversion, character sliding while attacking, attack chain delay (now re-triggers after ImpactEnd, not full animation). Camera moved from (0,3,-12) to (0,2,-8). Pipeline confirmed: punch lands, stun animation plays, damage logged.

---

## Active TODO

### Next Session -- Enemy Polish + Combat Upgrades

| Task | Status | Notes |
|------|--------|-------|
| Audit FS Melee Combat System demos and architecture | DONE | Cherry-pick only -- incompatible with Animancer |
| Audit Frank animation packs -- map clips to GDD move set | DONE | Whip pack mapped, weapon system designed |
| Create TestScene -- 2.5D plane, Cinemachine, Steez prefab | DONE | `Assets/_Sandbox/FearSteez/Scenes/TestScene.unity` |
| Player movement (8-directional, New Input System, 2.5D constrained) | DONE | FSPlayerController + FSInputHandler |
| One attack landing on one enemy | DONE | Full pipeline confirmed: input > anim > hitbox > damage > reaction |
| Basic combo system (3-hit string) | DONE | _comboAttacks[] array, J during recovery advances index |
| Enemy idle + patrol | DONE | EnemyPatrol: X-axis, pause at endpoints, stagger on hit |
| Enemy AI -- detect player, walk toward, melee attack | DONE | All bugs resolved Session 10. Enemy dies, stays dead. |
| Player health + damage reaction | DONE | Both player hits and enemy hits confirmed working. |
| Camera dynamic zoom (closes on fight, opens on spread) | DONE | FSCameraZoom on CM_SideScroll. SmoothDamp drives CinemachineCamera.Lens.FieldOfView. |
| Synty Civilian01 enemy (ApocalypseOutlaw) | DONE | A_MOD_BL_* locomotion, Frank FS3 attacks, confirmed working. |
| Synty Zombie01 enemy (ApocalypseZombie) | DONE | A_MOD_GBL_* locomotion, Swipe SOs, confirmed working. |
| FSAttackData frame-count upgrade | DONE | startupFrames/activeFrames/recoveryFrames at 60fps; ImpactStart/End computed as properties |
| HitLevel + HitWeight system | DONE | Both enums on FSAttackData; IDamageable.TakeDamage(amount, level, weight); EnemyHealth queries FrankHitReactionDB |
| Delete SwapPlayerPrefab.cs | DONE | Already gone |
| HitDirection system | DONE | Front/Left/Right/Back on FSAttackData; DB pools keyed by (Level, Weight, Direction); flip attacker->victim in DB; fallback: exact -> Front -> _fallbackClip |
| Animation test rig | DONE | FSTestCombatController (numpad 0-9) + EnemyTestDummy; CivilianTest in TestScene |
| Dead enemy collider fix | DONE | SnapToGround no longer re-enables colliders |
| Fix uppercut HitDirection | DONE | Changed to Front (was Right). Front/Back split resolved bad reaction clips. Damage_Strong_F1/F2 marked Conditional. |
| Investigate multi-hit per attack | DONE | Animancer reuses AnimancerState for same clip -- NormalizedTime not reset. Fix: `_attackState.Time = 0` after Play(). Applied to FSTestCombatController, FSCombatController, FSEnemyBrain. |
| Add more test attacks (slots 6-9) | TODO | FS4 Punch_L/R or kicks to fill numpad slots |
| Continue reaction clip evaluation | TODO | More attacks + reactions to evaluate with test rig |
| Tune Zombie01 speed + HP | TODO | Patrol 0.8, chase 1.4, HP 75-100 |
| Multi-enemy playtest (duplicate enemies in TestScene) | DONE | 4 Civilian01 + 2 Zombie01. Combat pipeline confirmed. Spread zoom working. |
| Player health bar HUD (UI Toolkit) | DONE | PlayerHUD.uxml/uss + FSPlayerHUD.cs. Green->yellow->red gradient. |
| FSPlayerHealth FrankHitReactionDB upgrade | DONE | Varied hit reactions from enemy attacks. Same pattern as EnemyHealth. |
| Create FrankHitReactionDB SO asset | DONE | 164/179 clips matched. 15 misses = weapon-specific Critical clips (intentional). |
| Wire FrankHitReactionDB onto enemies | DONE | DB + fallback clips wired on Civilian01 + Zombie01 + FearSteez |
| Smooth KO body drop | TODO | Body floats during KO anim then drops when Animator disabled. Need gradual offset during clip or different approach. |
| Civilian conversion system | TODO | Tecnomancer converts civilians (3/5 convertible); Synty idle/locomotion layer, Frank combat layer on conversion |

### Completed This Phase

| Task | Status |
|------|--------|
| Import FS Melee Combat System to Sandbox | DONE |
| Import Animancer Pro to Sandbox | DONE |
| Package audit and setup | DONE |
| UI Toolkit direction confirmed | DONE |

---

## Known Issues

| Issue | Severity | Notes |
|-------|----------|-------|
| MCP connection (original project) | Low | Was an issue in standalone project. Sandbox MCP is working. |
| Z depth movement needs player testing | Low | Camera diagnostic confirmed +Z = away from camera is correct. Reverted to original. Verify feel in play. |
| Attack hitbox is a sphere in front of player | Low | Intentional for prototype. Per-limb hitboxes (hand/foot) are the production target. |
| Enemy look-at weight needs tuning | Low | Head nearly does 180 on close approach. Tune _lookAtWeight and clampWeight in EnemyPatrol Inspector. |
| FBX reimport resets loopTime | Info | Reimporting .unitypackage resets clipAnimations to []. Must re-add clip entries and re-assign serialized references. Document per-FBX. |
| KO body floats then drops | Medium | KO clips have baked hip Y displacement as body animation. Animator disabled after clip freezes pose, transform offset drops body to ground. Visible "float then drop" artifact. Needs gradual correction during KO or clip import setting fix (Root Transform Position Y: Bake Into Pose, Based Upon Feet). |
| Player punch lockout after stagger | FIXED | Added !IsPlaying fallback in FSCombatController. Confirmed working. |
| Enemy doesn't die at 0 HP | FIXED | EnemyHealth used GetComponent (returned null when on child GO) → GetComponentInParent. EnemyPatrol not disabled on death when brain present (else-if) → always disable both. EnemyPatrol + FSEnemyBrain fighting each other → FSEnemyBrain.Awake() disables EnemyPatrol. |

---

## Quick Context

**What is this game?** A 2.5D side-scrolling beat 'em up where you play as a real Atlanta rapper (FearSteez) fighting through waves of enemies to reach your concert. An evil sorcerer has cursed the city -- his minions patrol by day, zombies rise at night.

**Inspirations:** Streets of Rage + Double Dragon + Blaster Master + River City Girls

**Unique Hooks:**
- Real artist (FearSteez) with real music drives the soundtrack
- Day/night cycle affects enemy types (minions vs zombies)
- Classic beat 'em up combat with modern RPG depth

---

## Build Checklist

Before each build:
1. **Update version number** in Player Settings
   - Current: 0.1 (initial)
   - Format: Major.Minor
2. Version displays on main menu via `Application.version`

---

## Reference Documents

| Document | Path | Purpose |
|----------|------|---------|
| **Dev Reference** | `FS_DevReference.md` | Architecture, standards, lessons |
| **Code Reference** | `FS_CodeReference.md` | Script API, namespaces, conventions |
| **Art Asset List** | `FS_Art_AssetList.md` | Art pipeline tracking |
| **Troubleshooting** | `FS_Troubleshooting.md` | Active debugging process |
| **GDD** | `GDD/FS_GDD.md` | Game Design Document |
| **Status Archive** | `FS_Status_Archive.md` | Historical reference |

**Archived docs:** `Archives/` -- old versioned files from planning phase

---

## Session Close Checklist

- [ ] Update sessions with date and summary
- [ ] Update Active TODO
- [ ] Add any new issues to Known Issues
- [ ] Update FS_DevReference.md if standards/architecture changed
- [ ] Update FS_CodeReference.md if scripts/APIs added or changed
- [ ] Back up docs

---

**End of Project Status**
