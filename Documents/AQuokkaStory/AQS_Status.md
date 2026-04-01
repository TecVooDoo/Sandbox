# A Quokka Story -- Project Status

**Project:** A Quokka Story (2.5D Metroidvania Platformer)
**Developer:** TecVooDoo LLC / Rune (Stephen Brandon)
**Unity Version:** 6000.3.11f1 (Unity 6, URP)
**Working Path:** `E:\Unity\Sandbox` (Sandbox incubator)
**AQS Root:** `Assets/_Sandbox/_AQS/`
**Last Updated:** March 30, 2026 (Session 12 -- Projectile direction fix + mortar arc)

> **NOTE:** Original project lost to crash (pre-GitHub backup era). Resurrecting from archived docs at `Documents/Archives/`. All code is lost -- starting from scratch. Concept art and design docs survived.

> **ARCHIVE RULE:** This doc holds only the current state and last ~2 sessions. When adding a new session, move older entries to `AQS_StatusArchive.md` (newest first at top of archive). This keeps the status doc fast to read while preserving full history.

**Reference doc:** `AQS_DevReference.md` -- architecture, standards, AI rules. Read on demand.

---

## Current State

**Phase:** Sprint 1 -- Core Feel. Raccoon belly weapon fires mortar-arc bolts, stance-gated. 2.5D greybox level with Cinemachine follow camera. Malbers zones next. Recipe in `AQS_MalbersRecipe.md`.

**Session 12 (Mar 30, 2026) -- Projectile Direction Fix + Mortar Arc:**
Three issues resolved from Session 11's "bolt fires but direction wrong":
- **Belly_WeaponPoint rotation fixed.** Spine1 bone forward is world -X (skeleton Y=270). Belly_WeaponPoint localRot set to (0, 270, 0) to remap visual weapon forward to +Z.
- **Aim.UseCamera=false (the real fix).** Aim component was using camera-center raycast, hitting the ground plane far ahead (AimPoint Y=-24). Direction from AimOrigin to that ground point angled bolt 15 degrees downward at 145 m/s -- invisible. Set UseCamera=false so Aim uses AimOrigin.forward (+Z) instead.
- **Mortar arc configured.** Weapon changed from bullet to mortar: UseAimAngle=true, AimAngle=35, gravity=(0,-9.81,0), Force=15 (was 200). Bolt now launches upward at 35 degrees and arcs down with gravity. MProjectile's FlyingProjectile coroutine uses kinematic equation: `pos = start + V*t + G*t^2/2`. Bolt prefab already had rotation=FollowTrajectory.
- **Duplicate Player Core removed.** Two identical Player Core children on Raccoon_Weapon_Test (copy-paste contamination from prefab setup). Second one deleted -- 7 duplicate child objects removed with it.
- **Standing stance gates firing.** C2_AnimalStance condition (CurrentStance==Stand) on Belly_Weapon_Test prefab's PreAttackConditions. Weapon only fires when raccoon is in Stand stance (F key / Action4). MWeaponManager.PreAttackConditions was wrong location (passes Weapon as target, not MAnimal). Weapon.PreAttackConditions passes MWeaponManager (same GO as MAnimal) so C2_AnimalStance resolves correctly. Stand stance currently hold-to-maintain (persistent=false) -- toggle vs hold TBD for final quokka.

**Key learnings:**
- MShootable.CalculateVelocity uses `(AimPoint - AimOrigin.position).normalized * Power` -- NOT the fire point forward.
- Aim.DirectionFromDirection uses `AimOrigin.forward` when UseCamera=false.
- Aim.DirectionFromCamera uses screen-center raycast when UseCamera=true -- inappropriate for non-aiming belly weapons.
- **MWeaponManager.PreAttackConditions.Evaluate(Weapon)** passes the weapon object, NOT the animal. **Weapon.PreAttackConditions.Evaluate(this)** passes MWeaponManager which shares GO with MAnimal -- use the weapon's conditions for animal-based checks.
- **Mode.EnterConditions** only gates mode activation (equip/draw), NOT weapon firing. Firing bypasses the mode system entirely via MWeaponManager.MainAttack.
- Mortar tuning values (Force, AimAngle) need adjustment once level geometry exists. Current values arc a bit high/far for 2.5D side-view.
- Toolkit for Ballistics (Heathen) installed for future trajectory visualization (Sprint 2 Joey launch).

- **Greybox test level built.** ProBuilder geometry: start platform, water pool with ramps, mid platform, side climb wall (profile), upper platform, far-side climb wall (back to camera), ledge platform, end ground. All along Z axis. LockAxis (LockX=true) added to raccoon.
- **Cinemachine 2.5D follow camera.** CinemachineBrain on Main Camera, CM_2_5D_Follow virtual camera with CinemachineFollow: offset=(4,2,0) WorldSpace, damping=(1,0.5,1), rotation=(10,270,0). Camera on +X side looking -X for natural left-to-right platformer direction. RotationComposer removed (fixed angle, not dynamic look-at). Rotation damping zeroed to prevent drift.
- **Z-fighting fixed.** Old "Ground" plane (100x100 at Y=0) was overlapping ProBuilder ground meshes. Deactivated.
- **Water volume transparent.** URP Lit material with alpha=0.3 blue so raccoon is visible while swimming.
- **Shadow settings tuned.** Distance reduced from 50 to 20, cascades from 4 to 2 to reduce flicker during camera movement.
- **Artist package created.** QuokkaMom_ArtistPackage.zip (22MB) with FBX reference model, concept art, GDD, and technical brief for 3D artist.

**Scene state:** BlankTest scene -- Raccoon_Weapon_Test active at origin with LockAxis, GreyBox_TestLevel parent with 11 children, CM_2_5D_Follow virtual camera, old Ground plane deactivated. Camera follows raccoon from +X side.

**Zones status:** All core zones WORKING.
- **Swim:** Water_Volume trigger on layer 4 (Water) -- auto-triggers Swim state.
- **Climb:** Walls need tag=Climb + Climbable physics material + BoxCollider on Default layer. Press E (Interact) to start climbing. The missing Climbable physmat was the root cause of earlier failures -- NOT corrupted prefab hierarchy. Raccoon prefab hierarchy matches original exactly (ClimbHit/LedgeHit positions and inactive state are normal -- MAnimal manages them at runtime).
- **LedgeGrab:** Triggers at top of climb wall (not from below). Drop-down from above also works.
- **Far-side climb:** Works when wall is repositioned off the travel path. User manually positioned ClimbWall_FarSide for side approach.

**Key Malbers zone learnings:**
- Climb state uses THREE detection requirements: (1) ClimbLayer mask matches surface layer, (2) Surface physmat matches collider physmat, (3) tag=Climb on surface. ALL THREE must be present.
- ClimbHit/LedgeHit children on the raccoon are INACTIVE in editor and have "garbage" positions -- this is NORMAL. MAnimal activates and positions them at runtime.
- LedgeGrab is NOT a "jump up and grab from below" mechanic -- it detects the top edge of a climb surface while climbing.
- Original Raccoon PA Player prefab has TWO Player Core children -- this is the intended structure, not duplication.
- Raccoon_Fresh_Test instantiated from clean prefab confirmed same behavior as Raccoon_Weapon_Test -- proved issue was greybox geometry, not raccoon.

**Next:**
- Re-apply weapon changes to fresh raccoon (or keep Raccoon_Weapon_Test since hierarchy is fine)
- Mortar tuning with level geometry
- Stand stance toggle vs hold decision
- Remove remaining CustomPatch debug logs from MShootable.cs
- Far-side climb in 2.5D design investigation (works with manual positioning, but LockAxis interaction TBD)

**What survived the crash:**
- Full GDD (multiple versions, latest Dec 2025)
- Architecture plan (namespaces, file structure, system design)
- Design decisions document (rationale for key choices)
- Concept art (Quokka Mom + 7 Joey character sheets, front/back/side)
- Fundraiser campaign plan
- Project starter document

**What was lost:**
- All Unity project files, scenes, prefabs
- All scripts (PlayerController, ClimbController, GroundDetector were DONE)
- All asset imports and configurations
- GitHub repo (did not exist yet)

---

## Phase 1 TODO (Foundation -- Redo)

These items were completed before the crash and need to be rebuilt:

| Item | Old Status | New Status |
|------|-----------|------------|
| Project setup (Unity 6, URP, GitHub) | Was DONE | DONE |
| Core player movement (hop, jump) | Was DONE | IN PROGRESS -- Malbers AC with LockAxis 2.5D, Cinemachine follow camera, mortar weapon working |
| Climbing system with stamina | Was DONE | TODO |
| Input System integration | Was DONE | DONE -- AQS_InputActions asset + QuokkaInputHandler |
| Ground detection (collision-based) | Was DONE | DONE -- collision enter/stay/exit with normal check |
| Joey prefab (base visuals) | Was DONE | TODO |
| JoeyDefinition/AbilityDefinition SOs | Was IN PROGRESS | TODO |
| MVP launch mechanic | Was TODO | TODO |
| Package installation + configuration | Was DONE | DONE -- Sprint 1 packages installed |
| Asset eval for new candidates | N/A | DONE -- 30 relevant assets identified |
| GameEvent/GameEventListener system | Was DONE | DONE -- AQS.Core namespace |
| Placeholder character (Scorch) | N/A | DONE -- imported with anims, no scripts |

## Key Decisions (Session 0)

| Decision | Choice | Rationale |
|----------|--------|-----------|
| Platformer framework | Custom (NOT Corgi Engine) | Quokka movement is unique -- hop-based, not walk. Need full control over Joey stat modifiers. |
| Placeholder character | Scorch from HOK | Can climb trees, stand on hind legs, closest to quokka movement until custom model |
| Destruction | RayFire (ENTRY-168) | Already evaluated, MCP tools built (ENTRY-267) |
| Music system | Handled by AudioProject (PATWA) | Adaptive music system being built as drop-in for any project. Not Sandbox scope. |
| Quokka models | TBD -- son might model later | No good marsupial animation assets exist. Very specialized movement (fast/slow hop, bipedal stance, hand use). |

## Asset Audit (from Sandbox AssetLog -- 293 entries)

Searched all evaluated assets for AQS relevance. Results by gameplay need:

### Sprint 1-2: Install Now (Confirmed + Ready)

These are already evaluated, approved, and owned. Install during Sprint 1 package setup.

| Entry | Asset | Purpose | Sprint |
|-------|-------|---------|--------|
| 208 | Toolkit for Ballistics 2026 (Heathen) | Joey launch trajectory arc + projectile physics | 1 |
| 195 | Toon Kit 2 (OccaSoftware) | Cel shading -- "thick outlines, vibrant colors" art direction | 1 |
| 191 | Outlines Post-Process (OccaSoftware) | Full-scene toon outlines | 1 |
| 200 | Outline Objects (OccaSoftware) | Per-mesh outlines for interactables | 1 |
| 269 | All In 1 Shader Nodes | Glow, hit flash, hologram nodes for ASE/Shader Graph | 1 |
| 271 | Rope Toolkit | Vine swinging, rope puzzles, bridge physics | 2 |

### Sprint 3-4: Install When Needed

| Entry | Asset | Purpose | Sprint |
|-------|-------|---------|--------|
| 136 | MegaFiers 2 (Chris West) | Helium Joey inflate (FFD, morph targets) | 3 |
| 153 | Deform (Beans) | Squash/stretch for platforming feel | 3 |
| 231 | SensorToolkit2 (Micosmo) | Enemy vision cones, range detection, LOS (has 2D variants) | 4 |
| 229 | Behavior Designer Pro (Opsive) | Enemy behavior trees (patrol, chase, attack) | 4 |
| 164 | A* Pathfinding Pro (Aron Granberg) | GridGraph for 2D enemy navigation | 4 |
| 036 | Low Poly Animated Animals (Polyperfect) | Placeholder enemy models (snake, hawk, dog, cat) | 4 |
| 216 | Ragdoll Animator 2 (FImpossible) | Joey impact, enemy death ragdoll blending | 4 |

### Sprint 5+: Polish and Environment

| Entry | Asset | Purpose | Sprint |
|-------|-------|---------|--------|
| 182 | Buto (OccaSoftware) | Volumetric fog -- swamp atmosphere | 5 |
| 185 | LSPP God Rays (OccaSoftware) | Light shafts through swamp canopy | 5 |
| 202 | VFX Library (OccaSoftware) | Fireflies, wisps, swamp bubbles | 5 |
| 156 | Advanced Dissolve (Amazing Assets) | Enemy death dissolves, biome transitions | 5 |
| 170 | Ghost Effect Shader (OccaSoftware) | Ghost/spirit visual effects | 5 |
| 265 | Weather Maker (Digital Ruby) | Rain, fog, lightning for swamp mood | 5+ |
| 245 | FS Grappling Hook (Fantacode) | Metroidvania grapple traversal | 5+ |
| 169 | Inventory Framework 2 | UI Toolkit inventory for Joey/collectible management | 5+ |
| 214 | Dialogue System for Unity | Joey dialogue bubbles, found audio logs | 5+ |

### Bonus Finds (Reference / Cherry-Pick)

| Entry | Asset | Relevance | Notes |
|-------|-------|-----------|-------|
| 240 | Corgi Engine | Study reference | CharacterAbility pattern for custom movement architecture |
| 209 | Toolkit for Unity Physics (Heathen) | Helium float | Force fields, buoyancy -- Helium Joey float physics |
| 157 | Lattice Modifier (Harry Heath) | Alternate inflate | GPU lattice/FFD, faster but less control than MegaFiers |
| 098 | All In 1 3D Shader | Multi-effect | Toon + ghost + dissolve in one shader (overlaps dedicated picks) |
| 155 | Curved World (Amazing Assets) | 2.5D depth | Subtle world curvature for parallax depth |
| 158 | Amplify Shader Editor | Shader authoring | Custom shader creation for visual style |

### Still Need Evaluation

| Need | Status | Notes |
|------|--------|-------|
| AA Map and Minimap | NOT EVALUATED | Metroidvania exploration -- needs formal eval |
| Smart Lighting 2D | NOT EVALUATED | Swamp bioluminescence -- needs formal eval |
| Line renderer asset | LIKELY NOT NEEDED | ALINE + Toolkit for Ballistics covers trajectory display |
| Nine Volt Audio | OWNED -- VERIFY | Stem library for music system |

---

## Development Plan (Sandbox Sprints)

### Sprint 1: Core Feel
- Install Tier 1 packages (defaults + confirmed AQS stack)
- Import Scorch from HOK as placeholder character
- Prototype Mom movement: hop-based locomotion (fast hop, slow hop), bipedal stance, climb with stamina
- Gray-box test level with platforms, walls, climbable surfaces
- Get platforming feel right before adding Joey mechanics

### Sprint 2: Joey Launch MVP
- Implement aim + trajectory arc + launch + recall
- One Joey (Lead) with bowling ball ability
- Basic hit detection and feedback (Feel + Damage Numbers Pro)
- RayFire for breakable barriers (Lead Joey smashes through)
- Trajectory display: Toolkit for Ballistics 2026 (ENTRY-208) + ALINE

### Sprint 3: Joey Variety
- Add 2-3 more Joeys (Ballet freeze, Helium inflate, Ninja shuriken)
- Inflate mechanic prototype (start with DOTween scale tween, eval MegaFiers 2 ENTRY-136 or Deform ENTRY-153 if needed)
- Pouch management (swap active Joey, equipped Joey modifies Mom stats)
- Rope Toolkit (ENTRY-271) for vine swinging traversal

### Sprint 4: Enemies
- 2-3 enemy types with basic AI (patrol, chase, attack)
- Joey-specific weaknesses working
- Placeholder animal models: Low Poly Animated Animals (ENTRY-036)
- AI stack: SensorToolkit2 (ENTRY-231) + Behavior Designer Pro (ENTRY-229) + A* Pathfinding Pro (ENTRY-164)
- Ragdoll Animator 2 (ENTRY-216) for enemy death reactions

### Sprint 5: Vertical Slice
- One playable level (Tutorial or Swamp)
- All core systems integrated
- Ready to migrate to standalone project with GitHub

---


---

## Known Issues

| Issue | Severity | Status | Notes |
|-------|----------|--------|-------|
| Raccoon bolt direction wrong | High | RESOLVED (S12) | Two fixes: Belly_WeaponPoint localRot=(0,270,0) for visual alignment, Aim.UseCamera=false for flight direction. |
| Duplicate Player Core on Raccoon | Low | RESOLVED (S12) | Second Player Core deleted. Copy-paste contamination from prefab setup. |
| Mortar arc too high/far for 2.5D | Low | TUNING | Force=15, AimAngle=35. Needs adjustment with level geometry. |
| Standing stance not required for firing | Medium | RESOLVED (S12) | C2_AnimalStance on weapon PreAttackConditions. Hold F to stand, then fire. Toggle vs hold TBD. |
| Holster ID mismatch warning | Low | OPEN | "Default Holster does not exist on Holster ID list" on Play. Cosmetic, doesn't affect firing. |
| LockNextTarget Vector2 type warning | Low | OPEN | Input action type mismatch. Cosmetic. |
| Rabbit mouth weapon fires into ground | Low | TUNING | Same UseCamera issue as raccoon. Apply UseCamera=false fix when revisiting rabbit. |
| Remaining CustomPatch debug logs in MShootable.cs | Low | TODO | Remove MShootable-TRACE Debug.Log lines (temporary debugging). |
| All code lost | Critical | Accepted | Rebuilding from docs |
| GDD may need design updates | Medium | TODO | User to review after format cleanup |

---

## Reference Documents

| Document | Path |
|----------|------|
| Dev Reference | `E:\Unity\Sandbox\Documents\AQuokkaStory\AQS_DevReference.md` |
| GDD | `E:\Unity\Sandbox\Documents\AQuokkaStory\GDD\AQS_GDD.md` |
| Concept Art | `Documents\Archives\Quokka Mom and Joeys Concept Art\` |
| Archived Docs (pre-crash) | `Documents\Archives\` |
| Sandbox Status | `E:\Unity\Sandbox\Documents\Sandbox_Status.md` |
| Sandbox Asset Log | `E:\Unity\Sandbox\Documents\Sandbox_AssetLog.md` |

---

**End of Document**
