# Blood Miner -- Project Status

**Project:** Blood Miner (Mobile Idle/Incremental -- Cute + Gore)
**Developer:** TecVooDoo LLC / Rune (Stephen Brandon)
**Unity Version:** Unity 6 (URP)
**Working Path:** `E:\Unity\Sandbox` (Sandbox incubator)
**SM Root:** `Assets/_Sandbox/_BM/`
**Last Updated:** May 2, 2026 (Session 94 -- Animal scales tuned by true-AABB; Ghoul replaced with Skeleton_Rogue + dual axes + dual-wield Slice + one-click kill; cape rendered double-sided; minion AT split for chainsaw 2H_Spin; gates reverted, old meshes cleaned)

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

**Session 94 (May 2, 2026) -- Animal scales by true-AABB + Ghoul replaced with Skeleton_Rogue + dual-axe Slice + one-click kill + cape double-sided + chainsaw minion split:**

*Animal scales finalized via true skinned-vertex AABB measurement.* `SkinnedMeshRenderer.bounds` was misleading for several animals (Cow inflated 2.5×, others varying), so my first-pass "match by SMR.bounds" tuning produced a Cow that was actually the smallest visible animal in playtest despite reporting biggest bounds. Switched to computing each prefab's actual bone-weighted AABB (the same compute the slicer uses) and tuned each animal's `_Sliceable.prefab` Whole/TwoPiece/FourPiece subtree scales until the user-confirmed visible sizes were:
- Chicken **3.82** → avg 0.59
- Cat **3.00** → avg 0.70 (reference, untouched)
- Dog **3.26** → avg 0.70 (matches Cat)
- Rabbit **2.85** → avg 0.70 (matches Cat)
- Pig **3.74** → avg 0.91 (between Cat and Sheep)
- Sheep **4.02** → avg 1.02 (between Pig and Cow)
- Cow **4.95** → avg 1.12 (largest)

*Ghoul → Skeleton_Rogue + dual axes + Dualwield_Slice anim:* Replaced the Skeleton_Warrior visual with KayKit Skeleton_Rogue. Dual `Skeleton_Axe` instances attached to `handslot.r` AND `handslot.l` (dual-wield). New `AC_TestGhoul_Dualwield_Slice` controller using `Melee_Dualwield_Attack_Slice` (1.17s). Also created `_Chop` and `_Stab` variants for swap-in testing.

*Cape rendered double-sided via duplicate-mesh-with-flipped-normals:* The Skeleton_Rogue's cape is a single-sided plane mesh — invisible from the front by default. Tried URP/Lit + Cull=Off (back-facing fragments rendered with the front-facing normal, making the inside read brighter than the outside). User wanted "same color as the hood." Final approach: built `Assets/_Sandbox/_BM/Art/Characters/Skeleton_Rogue_Cape_DoubleSided.asset` (62 verts → 124 verts, 84 tris → 168 tris) with each triangle duplicated in reverse winding + flipped normals, so URP/Lit + default back-culling renders both sides naturally with proper lighting. Cape uses the embedded `skeleton` material (same as the hood) — color now matches.

*Chop-chain one-click kill for Ghoul (carryover from user request):* Added `RowWorker._oneShotKill` SerializeField + public `OneShotKill` property. New `SliceableBody.Hit(swingDir, bool oneShot=false)` overload — when `oneShot=true` and state is Whole, advance directly to FourPiece (skip TwoPiece): hide Whole, hide TwoPiece, clone+fling the 4 pieces with full impulse, spawn organs, return consumed=true. Outlet release fires immediately. `RowWorker.ChopImpactRoutine` passes `_oneShotKill` through to `slice.Hit()`. BM_Shaft Ghoul instance has `_oneShotKill = true` baked into the YAML. ChopMinion stays default-false (2-hit); chainsaw-tier ChopMinions will set it to true at runtime once the weapon-tier system lands.

*Minion AT scene split (animation evaluation):* The `Skeleton_Minion` in AnimationTest now has 5 weapons stacked on `handslot.r` for visual A/B testing — Wrench, Skeleton_Dagger, Machete, Axe (all sized individually by user), and ChainSaw. The original minion uses `AC_TestMinion_2HChop` for the four standard weapons (ChainSaw deactivated). A new duplicate `Skeleton_Minion_ChainSaw` at +1.5 X offset has only the ChainSaw active and uses `AC_TestMinion_2HSpin`. Minion root scale 0.6, weapons compensate by scaling 1/0.6 ≈ 1.667 to render at full size. Eight new test controllers created at `Assets/_Sandbox/_BM/Scenes/AnimationTest_Controllers/`: dual-wield Slice/Chop/Stab and 2H Slice/Chop/Stab/Spin/Spinning.

*Weapon-tier visual progression — design locked, implementation deferred:*
- Geometric ramp on `ToolUpgradeController._toolTier` per row: Tier 1-2 = Wrench, 3-5 = Dagger, 6-9 = Machete, 10-14 = Axe, 15+ = ChainSaw (the cap, intentionally aspirational).
- ChainSaw uses `Melee_2H_Attack_Spin` instead of the default `2H_Chop` — implemented via `AnimatorOverrideController` overriding the Attack clip on `AC_ChopMinion` (lighter than parallel state machines).
- Architecture: a `WeaponTierMapSO` ScriptableObject holds entries `(minTier, weaponPrefab, attackClipOverride)`. Each `Row` listens to its `ToolUpgradeController.OnTierChanged(int)` and calls a refresh method on its ChopMinions to swap weapon + override controller.
- ChainSaw-tier ChopMinion sets `OneShotKill = true` at equip — reuses the `RowWorker._oneShotKill` field landed this session.

*Gate revert + cleanup:* BodyConfig `_unlockRow` and `_carryTierRequired` restored from S93's testing-only flatten (Cat/Dog=1, Pig=3/2, Sheep=5/3, Chicken=7/3, Rabbit=7/3, Cow=9/4). 28 old `_TopFront/_TopBack/_BotFront/_BotBack` mesh assets deleted (orphaned by S93's head-to-tail re-bake). Cape's interim `BM_Skeleton_DoubleSided.mat` (URP/Unlit attempt) deleted, replaced by the geometry-based double-sided mesh.

*BM_Shaft scene-edit gotcha (worth remembering for future sessions):* `script-execute` Roslyn calls run against the currently-loaded assembly. When you edit a `[SerializeField]` field on a script and immediately try to set that field via reflection on a scene instance, the assembly hasn't recompiled yet — the field doesn't exist on the runtime type. Two workarounds that worked: (a) trigger `AssetDatabase.Refresh()` + wait for compile to complete before reading the new field, or (b) edit the scene YAML directly (`_oneShotKill: 1`) and let Unity deserialize on next scene reload. (b) is robust and bypasses the compile race entirely.

*Open visual issue confirmed resolved:* The S93 "BM_Shaft body scale mismatch" — Cat/Dog rendered at correct scale, Pig/Sheep/Chicken/Rabbit/Cow tiny. Root cause: Cat/Dog `_Sliceable.prefab` had `Whole.localScale = 3` + each TwoPiece/FourPiece child = 3, while the other 5 had everything at 1. Compounded by SMR-baseline variance (Cow 0.43, Pig 0.75). True-AABB measurement gave the right scale targets per-animal. **All 7 animals now playtest-confirmed at correct in-shaft sizes.**

---

**Session 93 (May 1, 2026) -- All 7 animals sliceable: head-to-tail X-axis bake + BM_BloodCap on cut faces + chop-chain timing tuning + containment off + BodyConfigs wired:**

*Re-cut all 7 animals on world X (sagittal / head-to-tail) instead of world Z (front/back):* Carryover from S92 next-list item #1 — the canonical butcher cut. New mesh suffixes `_TopLeft / _TopRight / _BotLeft / _BotRight`. `SliceableBody.QuadrantDirection` re-mapped: Top → +Y, Bot → -Y, Left → -X, Right → +X, with a Z kicker (was the X kicker before). Old `_TopFront / _TopBack / _BotFront / _BotBack` mesh assets retained but unreferenced — cleanup pending visual confirmation across all 7 animals.

*Y-cut bias to bring more body bulk into the top half:* Plane is `bounds.center.y + size.y * -0.12f` (12% of body height below center). Cat top/bot ratio went from 17%/83% to 28%/72%. User confirmed "much better."

*BM_BloodCap.mat (new at `Assets/_Sandbox/_BM/Materials/`):* URP/Lit, dark butcher red (R=0.55, G=0.05, B=0.05, smoothness 0.35, metallic 0). Replaces the dim `PolygonParticleFX_Blood` additive cap from S91. Knocks out S92 next-list item #8 ("Cap material upgrade").

*Bake uses `createSubmeshForIntersection=true` for both cuts:* output meshes have 3 submeshes (body + Y-cap + X-cap). Each 4Piece child SMR.sharedMaterials set to `[bodyMat, BloodCap, BloodCap]`. User playtested: "the cat visual looks good." Cuts now read as colored butcher faces, not white.

*Cow needed a true-AABB compute path — `SkinnedMeshRenderer.bounds` was 2.5× the actual skinned-vertex AABB:* SMR.bounds reported center.y=0.33 / size.y=0.52, but actual skinned vertex range was y[-0.001..0.196]. My initial Y-cut at y=0.27 was above the entire mesh, so Y-cut returned null. Fix: mirror the slicer's bone-weighted vertex transform once before placing the plane (compute true AABB from `bones[i].localToWorldMatrix * bindposes[i] * mesh.vertex[i]`). Other 6 animals had similar bounds inflation but enough vertex spread to not fail outright; their cut placement may still be off — re-bake any animal that looks wrong with the true-AABB path.

*Chop-chain timing fixes (carryover from S92 next-list item #2 + the rapid-click bug surfaced in playtest):*
- `Ghoul._swingCooldown` 0.15 → 0.7 (gate input to roughly half the 1.367s attack anim — second click can't pre-empt the first swing's recovery; rapid double-click no longer fires the body-fly-apart before the visual swing peak).
- `Ghoul._chopImpactDelay` 0.2 → 0.3 (S92's "a breath too quick" retune now that the axe-pose fix landed in S92's `handslot.r` reparent).
- `Ghoul._minionHitDelay` 0.4 → 0.5 (rebalanced relative to the new 0.3s impact).
- `RowWorker._chopImpactDelay` script default 0.7 → 0.3. Affects runtime-spawned ChopMinions (Ghoul carries its scene Inspector override; minions are `AddComponent<ChopMinion>()` at runtime and read script defaults). Closes out the S92 carryover note about minions having Ghoul-old slow-impact timing.

*Row_0 Containment disabled (parts fly free across rows now):* User playtested with the X-axis pieces and decided the chunk-corral was over-tight: "remove the container completely or at least we need to let the parts fly." The 6 wall GameObjects under `Row_0/Containment` are SetActive(false) and preserved as a layout reference for the future organ-only containment volume. As a side effect, this also fixed an unrelated bug: the wall colliders had been intercepting the Row_0 tool-upgrade button click via Unity's `OnMouseDown` raycast.

*BodyConfigs wired to Sliceable prefabs:* All 7 BodyConfigs now point `_bodyPrefab` at the matching `<Animal>_Sliceable.prefab`. The S92 status note "other 6 still point at legacy single-chop prefabs" was slightly off — only Dog had a legacy `Body_Dog` reference; the other 5 were null.

*Body picker logic worth remembering:* `GathererManager.PickRandomBody(int carryTierLimit)` filters by **both** `UnlockRow <= currentRowDepth + 1` **AND** `CarryTierRequired <= carryTierLimit`. The carry-tier limit comes from each `Gatherer._carryTier` field (default 1, **separate upgrade from gatherer count + walk speed**). User had walk speed 3 + 3 gatherers at row 11 but still only saw Cat/Dog because the carry-tier upgrade wasn't raised — gatherer tier was still 1.

*⚠ TESTING-ONLY GATE FLATTEN — DO NOT COMMIT WITHOUT REVERTING:* All 7 BodyConfigs have `_unlockRow=1` and `_carryTierRequired=1` set for testing every body type from row 1. Originals to restore before commit:
- **unlockRow:** Cat=1, Dog=1, Pig=3, Sheep=5, Chicken=7, Rabbit=7, Cow=9
- **carryTierRequired:** Cat=1, Dog=1, Pig=2, Sheep=3, Chicken=3, Rabbit=3, Cow=4

*Open visual issue surfaced this session — BM_Shaft body scale mismatch:* Only Cat and Dog render at correct scale in the live shaft; Pig/Sheep/Chicken/Rabbit/Cow render tiny. The AnimationTest scene has these same animals at correct scale, so the underlying prefabs are fine — the issue is somewhere in the spawn path (likely the BM-canonical Cat/Dog were authored at a different scale than the raw Suriyun Pig/Sheep/Chicken/Rabbit/Cow Sliceable prefabs, or the BodyPool / RowOutlet placement applies a scale that only Cat/Dog were authored to expect). Queued for next session.

---

**Controls reference:**
- A / Left → move left | D / Right → move right
- Up / Down → scroll viewed row
- Click / Tap / Space → Swing (chops nearest body within reach)
- Descend = HUD button only

---

**Next:**

1. **Implement weapon-tier visual progression** (design locked S94). Build `WeaponTierMapSO` ScriptableObject with the geometric ramp: Tier 1-2 = Wrench, 3-5 = Dagger, 6-9 = Machete, 10-14 = Axe, 15+ = ChainSaw. ChainSaw entry includes an `AnimatorOverrideController` that overrides AC_ChopMinion's Attack clip to `Melee_2H_Attack_Spin`. `Row` listens to `ToolUpgradeController.OnTierChanged(int)` and calls a refresh method on its ChopMinions to swap weapon prefab + override controller. ChainSaw-tier ChopMinion sets `OneShotKill = true` at equip.
2. **Re-bake any animal with off-balance Y-cut placement** using the true-AABB path (Cow uses it; the other 5 used SMR.bounds and may look wrong since their bounds are also inflated to varying degrees). Check at depth, not just from the front camera.
3. **Organs layer + collision matrix** — make organs (and possibly 4-piece chunks) push-but-don't-block when player/minions walk into them. Phase A.5. Pattern: organs on `Organs` layer, Player & Minion ignore `Organs` in matrix, each gets a child trigger collider on a "Pusher" layer that detects organs and applies force on contact.
4. **Outlet → floor rigidbody drop** — animals drop from outlet to ground floor under physics instead of teleport-to-spawn-point. Pieces will then fly from floor level instead of from the outlet. Once it lands, set `RowOutlet._postConsumeDelay=0` since drop time naturally spaces arrivals. (Sprint 3 polish item, prerequisite for the dragon flow visually.)
5. **Organ-only containment volume** — corral spawned organs to the row area while letting body parts fly free across rows. The disabled `Row_0/Containment` walls are still in the scene as a layout reference. Likely one volume per row, sized similar to the orange reference cube from S92.
6. **Sprint 3 dragon + animatronic flow** — captured fully in S91 design lock-in. Dragon asleep → player wakes → eats organs (drains gauge) → walks home → burp particle FX → tool upgrade fires → sleeps. Animatronic = visual auto-upgrade button cycling random idle states + waking the dragon. Big rework — own session(s) when prioritized.
7. **Per-`SliceableBody` tuning sweep** — per-animal pass on `_twoPieceImpulse` / `_fourPieceImpulse` / `_upwardBias` / `_fourPieceLifetime` / `_organCount` so cow chunks fly less than chicken chunks, large organs scatter less than small, etc. Note: with Ghoul one-click kill, `_twoPieceImpulse` doesn't apply on Ghoul hits (skipped state); only `_fourPieceImpulse` matters.
8. **AC_ChopMinion Walk state** — minions currently slide on the Idle pose while walking between outlets. Add a Walk state mirroring AC_Ghoul (Idle ↔ Walk via IsWalking bool, motion = Walking_A which is already loop-imported).
9. **Multi-row cascade audit** — `PipeNetwork._registeredOutlets` currently holds outlets across ALL rows. With one row this works fine, but at depth Row 0's paused outlet 2 would cascade-block Row 1's outlets too. Likely fix: one PipeNetwork per row.
10. **Tune Ghoul movement bounds in scene** — defaults are `_minLocalX=-1.5`, `_maxLocalX=4.7`. Verify at depth on first multi-row playtest.
11. **Balance pass v2 playthrough** — Session 84 balance pass hasn't been re-tested with the new outlet backup mechanic + damageable minions + 1-gatherer start + sliceable chop chain + Ghoul one-click kill. Throughput pressure may need re-tuning.
12. **SMB-driven impact frame (optional)** — if the new 0.7s `_swingCooldown` + click-time-based `_chopImpactDelay` ever feels sluggish for a 2-hit chain, replace the coroutine delay with a `StateMachineBehaviour` on the Attack state that fires `OnSwingImpact()` at a configurable normalizedTime. Decouples impact from cooldown and matches the visual swing peak regardless of input cadence. Both AC_Ghoul and AC_ChopMinion use the same `Melee_1H_Attack_Slice_Horizontal` clip (1.367s) so one SMB serves both.

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
