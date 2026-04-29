# Blood Miner -- Project Status

**Project:** Blood Miner (Mobile Idle/Incremental -- Cute + Gore)
**Developer:** TecVooDoo LLC / Rune (Stephen Brandon)
**Unity Version:** Unity 6 (URP)
**Working Path:** `E:\Unity\Sandbox` (Sandbox incubator)
**SM Root:** `Assets/_Sandbox/_BM/`
**Last Updated:** April 30, 2026 (Session 89 -- Damageable minions + Generic rig conversion for KayKit Skeletons)

> **ARCHIVE RULE:** This doc holds only the current state and last ~2 sessions. When adding a new session, move older entries to `BM_StatusArchive.md` (newest first at top of archive). This keeps the status doc fast to read while preserving full history.

**Reference doc:** `BM_DevReference.md` -- architecture, standards, AI rules. Read on demand.

---

## Current State

**Phase:** Sprint 2 Phase 1-9 IN PROGRESS. Pipe "sides" kit integrated via prefabs; needs playtest tuning.

## Queued / Design Decisions (not yet implemented)

These came out of design discussions during sessions 85/86 and are awaiting implementation. Order reflects current intended priority.

### Mechanics track
- **Animal falling animation** — bodies should drop into outlets (Rigidbody fall + ground collider) instead of teleporting to BodyDrop. Pairs with outlet backup (queued bodies stack visibly).
- **Animatronic + Dragon as button replacements** — Animatronic = visual replacement for **auto-upgrade button activation** (idles + prods the Dragon when fired). Dragon = visual replacement for **tool upgrade button** (animates emptying leftovers when triggered). FBXs imported in Session 88 (Animatronic_Normal/Creepy under `_BM/Art/Characters/KayKit_Animatronic/`, DragonPADefault is in `RPGMonsterBundlePolyart`). Wiring into the actual buttons is downstream work.

### Polish track
- **UI frame tweaks** — frame backgrounds for top/bottom panels need refinement (sizes/borders), separate from the readability pass already done.
- **Tool tier visual feedback** — tier label / button tint shift / floating "+tier" popup / capacity readout. Currently no on-screen confirmation when an upgrade fires (manual or auto).
- **Surface_Pipe_Connection alignment polish** — current placement uses fake-it-till-you-make-it offsets to compensate for the `[Surface]` parent's tilt. Could revisit if the visual mismatch ever shows.

### Big features (need their own design pass)
- **Prestige / reset system** — row 25 cap → reset blood/rows/outlets/minions/auto-buttons but persist tool tiers, gatherer count, gatherer speed. Reset trigger and prestige currency (if any) still TBD.

---

**Session 89 (Apr 30, 2026) -- Damageable minions + Generic rig conversion for KayKit Skeletons:**

*Generic rig conversion (root cause of "minion sinks into floor on death"):*
- KayKit's `Skeletons_Death` / `Skeletons_Death_Pose` / `Skeletons_Death_Resurrect` clips animate bones flying APART from each other (the skeleton-falls-apart effect). Mecanim's Humanoid avatar abstracts the rig into ~15 muscle joints with rigid hierarchy, so Humanoid retargeting strips out the bone-separation entirely (collapsed it to a "humanoid crumples to ground" pose). Generic preserves per-bone translations because the clip's curves drive bones directly by name.
- Inspector showed the smoking gun: *"Some generic clip(s) animate transforms that are already bound by a Humanoid avatar. These transforms can only be changed by Humanoid clips."* Unity blocks Generic clips on Humanoid models.
- **Converted to Generic + NoAvatar:** `Skeleton_Minion.fbx`, `Skeleton_Warrior.fbx`, and all KayKit anim FBXs (`Rig_Medium_*.fbx`, `CharAnim_Rig_Medium_*.fbx`). Animatronic stays Humanoid (Synty retarget chain unchanged).
- All KayKit anim clips share the same `Rig_Medium` skeleton hierarchy → Generic clips drive bones by name across every model + every clip without retargeting.
- **BM_Shaft scene rewire:** Cleared `Skeleton_WarriorAvatar` reference on the Ghoul's WarriorModel Animator (avatar sub-asset deleted when FBX went Generic). Runtime-spawned minions/gatherers are handled automatically because they instantiate from the now-Generic FBX prefabs.
- Memory `project_bm_skeleton_rig_type.md` written with the full reasoning.

*Damageable minions (Queued / Mechanics → done):*
- **AC_ChopMinion.controller** extended: 5 states now (Idle, Attack, **Death**, **DeathPose**, **Resurrect**) with new triggers `Death` + `Revive`. AnyState→Death on `Death` trigger interrupts whatever the minion was doing. Death → DeathPose (auto on exit) → Resurrect (on `Revive` trigger) → Idle (auto on exit).
- **ChopMinion.cs** new `LifeState { Active, Dying, Dead, Reviving }` + public `Hit()` and `IsAlive`. `Hit()` fires `Death` trigger, releases outlet target, sets timer. During non-Active states: skips normal AI, ticks `_lifeTimer`, transitions through Dying → Dead (waits `_deadDuration` = 3s, then fires `Revive`) → Reviving (waits resurrect anim length) → Active.
- `Target` getter returns null when not Active so other minions don't get blocked from claiming the same outlet.
- **Tunable defaults on ChopMinion:** `_deathAnimLength = 2s`, `_deadDuration = 3s` offline, `_resurrectAnimLength = 2.7s`. **Total downtime per hit ≈ 7.7s.**
- **Ghoul.cs DoSwing()** new `HitMinionsInFront()` runs before the body-chop. Finds all `ChopMinion` components in the current row, filters by `_facingDir` (must be on side Ghoul faces) and `_chopReach`, calls `Hit()` on each living one. Swings hit ALL living minions in that wedge — not just the first. The same swing chops the body AND knocks down minions standing too close, adding tactical weight (don't hit your own workers; bonus minion #2 is redundancy insurance).

*Test scene reference:* `Assets/_Sandbox/_BM/Scenes/AnimationTest.unity` runs `AC_TestMinionDeathCycle.controller` on the Skeleton_Minion (Idle_A → Skeletons_Death → Skeletons_Death_Pose → Skeletons_Death_Resurrect → Idle_A, auto-cycling). Verified bone-separation playing cleanly after Generic conversion.

*Slice animation + weapons wired (later in same session, after damageable minions verified):*
- `Melee_1H_Attack_Chop` looked like a jab once weapons were in hand. Swapped Attack-state motion on `AC_ChopMinion.controller` and `AC_Ghoul.controller` to `Melee_1H_Attack_Slice_Horizontal` (1.37s, Generic). The queued "swap Chop → Slice_Horizontal" item from Session 88 is now done.
- **Weapon prop pipeline:** new `_weaponPrefab` + `_weaponMaterial` serialized fields on ChopMinion. `SetupModel()` walks the rig hierarchy to find the `hand.r` bone and parents the weapon there with Mat_Skeleton applied. Plumbed through `Row._minionWeaponPrefab` → `Row.Init(... minionWeaponPrefab)` → `ShaftManager._minionWeaponPrefab` so dynamically-spawned rows inherit. Scene wired with `Skeleton_Dagger` for minions. `Skeleton_Axe` parented onto the BM_Shaft Ghoul's `hand.r` bone (path: `[Shaft]/Row_0/Ghoul/WarriorModel/Rig_Medium/root/hips/spine/chest/upperarm.r/lowerarm.r/wrist.r/hand.r`).
- **Hit timing fix:** initial implementation hit minions on the upswing. `Ghoul.HitMinionsAfterImpact()` is now a coroutine that waits `_minionHitDelay` before applying `Hit()`. This is a **separate field** from the inherited `_chopImpactDelay` (0.7s, used for the body-chop landing). Code default `_minionHitDelay = 0.55s`, **tuned in BM_Shaft scene to 0.4s** — minion-on-axe contact is a hair earlier than body-chop impact since the minion is roughly at the Ghoul's X while the body sits at the outlet. Verified in playtest: Ghoul swings → brief pause → minion crumples on the downswing where the visual axe lands.

*Gatherer starting count rebalanced (2 → 1):*
- Pipe-block cascades + minion downtime per Ghoul swing made the throughput pressure too friendly at start with 2 gatherers. `GathererManager._count` code default flipped 2 → 1 and BM_Shaft scene's serialized `_count` patched from 2 → 1. Slot gating unchanged (1 per 5 rows, 5 earnable + 1 start = 6 max).

*Status of current BM scene:* Sprint 2 still in progress. Production controller + script changes landed; BM_Shaft Ghoul avatar cleared, weapons attached, Slice motion wired, hit timing matched to swing impact. Playtest confirmed minion damageable cycle reads cleanly.

---

**Session 88 (Apr 29, 2026) -- Animation test scene + Animatronic/Dragon imports + KayKit weapons:**

*New AnimationTest scene at `Assets/_Sandbox/_BM/Scenes/AnimationTest.unity`:*
- Created an isolated humanoid retarget sandbox so animation/weapon tests don't pollute `BM_Shaft`. Lined up Skeleton_Minion, Skeleton_Warrior (used for Ghoul role), and Animatronic_Normal on a 60×20 ground plane. Tear-down controllers under `Assets/_Sandbox/_BM/Scenes/AnimationTest_Controllers/`.
- Confirmed Mecanim humanoid retarget works: KayKit characters (Skeleton_Minion/Warrior, Animatronic) all import as Humanoid with auto-generated avatars. Synty Idles + Emotes/Taunts clips are also Humanoid → drive the KayKit avatars cleanly through Mecanim with no extra setup.

*Animatronic + Dragon role decisions captured (memory `project_bm_animation_sources.md`):*
- **Animatronic** (KayKit Mystery Monthly #5, November 2023) = visual replacement for the **auto-upgrade button when activated**. Stands idle most of the time and "prods the Dragon to go to work" when fired. Synty Idles + Emotes/Taunts packs earmarked for its animation library (humanoid retarget). Guitar prop imported from same pack but not confirmed canonical for production.
- **Dragon** (DragonPADefault from `RPGMonsterBundlePolyart`) = visual replacement for the **tool upgrade button**. Animates emptying leftovers when the button fires. Non-humanoid, uses its own bundled `Dragon` AnimatorController (16 clips: `IdleNormal`, `IdleBattle`, `Attack01/02`, `FlyFWD`, `SenseSomethingST/RPT`, etc.) — never retarget anything onto it.

*Asset imports:*
- `Animatronic_Normal.fbx`, `Animatronic_Creepy.fbx` (Humanoid rig, scale 1, materials externalized) → `Assets/_Sandbox/_BM/Art/Characters/KayKit_Animatronic/`. Texture `animatronic_A.png`/`B.png` → `Textures/`. URP/Lit `Mat_Animatronic_A.mat` and `Mat_Animatronic_B.mat` created for the two skin variants.
- `Guitar.fbx` (Animatronic prop) → `KayKit_Animatronic/Props/Guitar.fbx`.
- 19 KayKit Skeleton **weapons** copied from `KayKit Skeletons 1.1/assets/fbx(unity)/` → `Assets/_Sandbox/_BM/Art/Characters/KayKit_Skeletons/Weapons/`: Axe, Blade, Dagger, Mace, Mace_Large, Scythe, Staff, Golem_Axe, Golem_Axe_Large, Crossbow, Arrow (+Half/Broken/Broken_Half), Quiver, Shield_Large_A/B, Shield_Small_A/B. Mat_Skeleton (existing) auto-applies via the script that attached the test props.
- KayKit Skeleton character pack's bundled texture (`skeleton_texture_A.png`) intentionally not re-imported — already in project.

*Validation findings:*
- **`Melee_1H_Attack_Chop` reads as a jab once a weapon is in the hand.** It's a 1.07s straight-thrust clip (full clip range, not truncated). With nothing in the hand it looked plausible; with `Skeleton_Axe`/`Dagger`/Guitar attached it's clearly wrong. Slice variants tested: `Slice_Diagonal` (1.00s), `Slice_Horizontal` (1.37s), `2H_Attack_Slice` (1.10s). **Slice_Horizontal reads best with weapons in hand for both Minion and Ghoul.** Queued as a real swap to the BM controllers (see Queued / Design Decisions).
- Synty AirGuitar (`A_POLY_EMOT_Celebrate_AirGuitar_Masc.fbx`, 4.33s) retargets cleanly to the Animatronic — fun pairing with the Guitar prop, but NOT canonical given the Animatronic's auto-upgrade-button role. Tagged in memory as test-only.
- Mild clipping observed on Skeleton_Minion's narrower torso during full-arm Synty motions (e.g. `Eat_Large`). Owner: Retarget Pro (purchased; not yet reinstalled in Sandbox). Plan is to bake retargeted clips per-rig with Retarget Pro rather than tweak avatar muscles.

*Memory updates:*
- `project_bm_animation_sources.md` rewritten with character roles (Ghoul/Minion/Animatronic/Dragon), pack assignments (KayKit melee → Minion/Ghoul, Synty Idles + Emotes/Taunts → Animatronic, Dragon's bundled clips for Dragon), and the Retarget Pro queue.
- Indexed in `MEMORY.md`.

*Status of current BM scene:* unchanged — Sprint 2 Phase 1-9 still in progress. Test-scene experimentation only; no `BM_Shaft` edits.

---

**Controls reference:**
- A / Left → move left | D / Right → move right
- Up / Down → scroll viewed row
- Click / Tap / Space → Swing (chops nearest body within reach)
- Descend = HUD button only

---

**Next:**

1. **AC_ChopMinion Walk state** — minions currently slide on the Idle pose while walking between outlets. Add a Walk state mirroring AC_Ghoul (Idle ↔ Walk via IsWalking bool, motion = Walking_A which is already loop-imported). Minor, but visible if you're watching.
2. **Multi-row cascade audit** — `PipeNetwork._registeredOutlets` currently holds outlets across ALL rows (Row.AddOutlet calls the global `_pipeNetwork.RegisterOutlet`). With one row this works fine, but at depth Row 0's paused outlet 2 would cascade-block Row 1's outlets too. Likely fix: one PipeNetwork per row. Sniff-test before it bites.
3. **Tune Ghoul movement bounds in scene** — defaults are `_minLocalX=-1.5`, `_maxLocalX=4.7`. Layout uniform across rows so should be fine, but verify at depth on first multi-row playtest.
4. **Balance pass v2 playthrough** — Session 84 balance pass hasn't been re-tested with the new outlet backup mechanic + damageable minions + 1-gatherer start. Throughput pressure may need re-tuning.

Sprint 3 Polish (deferred):
- Body gravity-drop from outlet to floor (Rigidbody + ground collider)
- Progressive-emergence squash on body arrival (see `project_bm_outlet_arrival_pop.md`)
- LeftoversGauge glass-top transparency tuning (alpha/material swap)
- T-connector visual between rows on completion
- Pool blood splats via EasyPooling 2025 if profiling shows GC pressure
- Per-body-type splat color (could plug into the Vefects color variants — Pink for cute pets, Dark for cow, etc.)
- Sound: hook chop impact to Master Audio (whetstone/squelch SFX)

**Design consideration (undecided):** Rows still busy with 2 minions per row at 4-outlet density. Re-evaluate during deeper-row playtest now that the chop sells the kill more clearly and the player has direct positional control over the Ghoul.

Carryover cleanup:
- Delete `Assets/Knife/Real Blood/Shaders/BloodPuddle.shader.bak` (leftover from ASE port probe)
- Destroy `RB_Test` cube in `BM_Shaft` scene (Real Blood render test baseline)
- Optional: clean up `_Sandbox/_BM/Scripts/Core/SceneTint.cs` entirely (now a data-only stub) or delete any dangling SceneTint component references in scene
- LeftoversGauge transparency/glass-top pass (top quad with URP/Lit Surface=Transparent or one of the existing glass shaders) so characters look like they stand on the recessed gauge cover instead of floating above empty space

Reference: `BM_RebuildPlan.md` for the full 8-phase build order and scene/UI targets.

---

## Sprint Plan

### Sprint 1: Core Tap Loop (Vertical Slice Foundation)
- BloodManager (currency tracking, earn/spend)
- TapHarvester (input -> harvest -> soul reward -> VFX trigger)
- Mine level SO config (soul yield, harvest speed, body type pool)
- Basic UI (soul counter, tap feedback, upgrade button)
- Single zone with 3 levels (static layout, no scrolling yet)
- Save/load (Easy Save 3 -- soul count, level states)
- **Playtest:** Tap bodies, see numbers go up, buy an upgrade, see numbers go up faster

### Sprint 2: Three Bottlenecks (IMT Structure)
- Elevator system (soul transport from levels to surface, capacity limit)
- Warehouse system (surface collection, storage cap, auto-collect upgrade)
- Level upgrade curves (exponential cost, linear output)
- Vertical scroll between levels
- Balance pass on all three bottlenecks
- **Playtest:** Do I feel the bottleneck? Do I want to upgrade the right thing?

### Sprint 3: Gore + Juice (The Identity)
- Scythe swing animation per body type
- Blood spray VFX (directional, body-type specific particles)
- Body part physics (limbs, tails, feathers -- short trajectory, fade)
- Soul wisp release (beautiful ethereal rise from gore)
- Screen shake, number pops, combo multiplier feedback
- Audio: wet crunch + chime, squelch per type, soul whoosh
- **Juicy Actions** -- install at standalone migration. Use SO-based action sequences for all juice: tap feedback (scale punch + shake), combo multiplier popups (spring actions), harvest gore bursts (action groups), elevator arrival (timed sequences), upgrade purchase (post-processing flash). Replaces custom coroutine-based VFX scripting.
- **Playtest:** Does the harvest FEEL incredible? Violence-to-beauty transition working?

### Sprint 4: Ranks + Zones (Progression)
- Rank system (8 ranks, lifetime soul thresholds)
- Rank-up UI (promotion letter from Management, character visual change)
- Multiple zones (3-4 at launch), zone unlock on rank
- Zone-specific body types, art themes, soul values
- Minion system (auto-harvest, tier 1-3)
- **Playtest:** Does ranking up feel rewarding? Do zones feel different?

### Sprint 5: Idle + Monetization (Mobile Ready)
- Offline earnings calculation (timestamp delta)
- Return-to-game collection moment
- Rewarded ads (2x offline, temporary boost)
- IAP integration (Dark Gem packs, Auto-Collect Pass)
- Prestige system (Rank 5+ ascension for permanent multipliers)
- Daily rewards
- **Playtest:** Does idle-return feel satisfying? Is monetization non-intrusive?

### Sprint 6: Polish + Ship
- All body type gore VFX polished
- All zone art passes
- Audio pass (ambient per zone, full SFX suite)
- Tutorial/onboarding (first 2 minutes)
- App Store assets (screenshots, description, icon)
- Analytics integration
- Soft launch
- **Ship it**

---

## Key Decisions

| Decision | Choice | Rationale |
|----------|--------|-----------|
| Platform | Mobile-first (iOS/Android), portrait | Learn mobile, ship fast |
| Genre | Idle/Incremental (IMT structure) | Proven formula, low complexity |
| Art style | Cute + gore (Happy Tree Friends tone) | Differentiator, shareable content |
| Presentation | 3D diorama, fixed side-view | Reuse existing 3D assets, looks polished |
| Bodies | Cute Pet (Suriyun) animals | Already evaluated, perfect fit |
| Player character | Assembly Kit Ghost/Skeleton/Reaper | Rank progression visual |
| Environment | KayKit Halloween + KayKit | Dark but stylized |
| Reference game | Idle Miner Tycoon | Three-bottleneck structure |
| Monetization | F2P with rewarded ads + IAP | Standard mobile idle model |
| Scope | Jumpstart in Sandbox, migrate when proven | Same pattern as HNR, AQS, FearSteez |

---

## Asset Needs

| Need | Decision | Status |
|------|----------|--------|
| Body models | Cute Pet (Suriyun) -- cat, dog, pig, sheep, rabbit, chicken, cow | Already in Sandbox |
| Player character | Assembly Kit (Sigmoid/ForActionGames) -- ghost, skeleton, reaper | Already in Sandbox |
| Environment | KayKit Halloween + KayKit environment | CC0, download when needed |
| Gore VFX | Custom particle systems + shaders | Build during Sprint 3 |
| UI | UI Toolkit (all UI) | Built-in |
| Save/Load | Easy Save 3 | Already in Sandbox (default package) |
| Audio | Master Audio 2024 | Already in Sandbox (default package) |
| Tweening | DOTween Pro | Already in Sandbox (default package) |
| Text effects | Text Animator | Already in Sandbox (default package) |
| Action sequencing / juice | Juicy Actions 1.0.3 (Magic Pig Games) | Evaluated in Sandbox (ENTRY-316, Approved/Recommended). Install at standalone migration -- too heavy for Sandbox (604 scripts, ~108K LOC). Covers screen shake, scale punch, spring physics, combo feedback, post-processing effects. Replaces need for custom VFX coroutines in Sprint 3. |
| Blood shader | TBD -- may need eval | Sprint 3 |

---

## Known Issues

None yet -- pre-development.

---

## Reference Documents

| Document | Path |
|----------|------|
| Dev Reference | `Documents\BloodMiner\BM_DevReference.md` |
| Code Reference | `Documents\BloodMiner\BM_CodeReference.md` |
| GDD | `Documents\BloodMiner\GDD\BM_GDD.md` (v1.0) |
| Concept Doc (original) | `E:\TecVooDoo\Projects\Games\1 Concepts\Soul Miner or Blood Miner\Documents\BloodMiner_Concept.md` |
| Sandbox Status | `Documents\Sandbox_Status.md` |

---

**End of Document**
