# A Quokka Story -- Project Status

**Project:** A Quokka Story (2.5D Metroidvania Platformer)
**Developer:** TecVooDoo LLC / Rune (Stephen Brandon)
**Unity Version:** 6000.3.10f1 (Unity 6, URP)
**Working Path:** `E:\Unity\Sandbox` (Sandbox incubator)
**AQS Root:** `Assets/_Sandbox/_AQS/`
**Last Updated:** March 12, 2026 (Session 1 -- Sprint 1 Start)

> **NOTE:** Original project lost to crash (pre-GitHub backup era). Resurrecting from archived docs at `Documents/Archives/`. All code is lost -- starting from scratch. Concept art and design docs survived.

**Reference doc:** `AQS_DevReference.md` -- architecture, standards, AI rules. Read on demand.

---

## Current State

**Phase:** Sprint 1 -- Core Feel. Foundation scripts in, Scorch imported, debugging complete. Next: greybox scene + wire up player.

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
| Core player movement (hop, jump) | Was DONE | IN PROGRESS -- QuokkaController compiles, needs scene wiring |
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

## Session 1 (Mar 12, 2026) -- COMPLETE

**Status:** Sprint 1 foundation. Scripts compiling, Scorch imported, GitHub repo created.

**Session 1 Work:**
- Created GameEvent/GameEventListener system (AQS.Core) adapted from HOK
- Created QuokkaController (AQS.Player) -- hop-based movement, jump with coyote time + buffer + cut, fall gravity, collision-based ground detection
- Created QuokkaInputHandler (AQS.Player) -- wires Input System to controller
- Created AQS_InputActions.inputactions -- Gameplay map with Move/Jump/LaunchJoey, keyboard + gamepad
- Imported Scorch from HOK as placeholder character (models, materials, animations -- no scripts)
- Created .gitignore with third-party asset exclusions (207 tracked files, 27.8MB)
- Initial commit + push to https://github.com/TecVooDoo/Sandbox
- Fixed compile errors: `Collision2D.GetContacts(List<>)` overload doesn't work in Unity 6 -- use `collision.contactCount` + `collision.GetContact(i)` instead
- Fixed physics type: 2.5D uses 3D physics (Rigidbody, CapsuleCollider, Collision) with Z locked, NOT 2D physics (Rigidbody2D)
- Boing Kit vs All In 1 Springs comparison: Boing Kit wins for AQS (BoingBones for ear/tail, AnimationBlend works with Animancer)

**Key Gotchas Discovered:**
- Unity 6 `Rigidbody` uses `linearVelocity` (not `velocity`) -- confirmed by linter
- Unity 6 `Collision2D.GetContacts(List<ContactPoint2D>)` silently fails to compile -- use index-based access
- 2.5D with 3D models = 3D physics + `RigidbodyConstraints.FreezePositionZ | FreezeRotation`
- 3D `Rigidbody` has no `gravityScale` -- use `AddForce` with `Physics.gravity` multiplier instead

**Next Session:**
- Create AQS_Greybox scene with ProBuilder platforms, walls, climbable surfaces
- Wire up player GameObject (Rigidbody, CapsuleCollider, PlayerInput, QuokkaController, QuokkaInputHandler)
- Set up Ground layer
- Test hop movement + jump feel
- Begin climb system if time permits

---

## Session 0.5 (Mar 12, 2026) -- COMPLETE

**Status:** Asset audit. Searched Sandbox AssetLog (293 entries) for AQS-relevant assets.

**Session 0.5 Work:**
- Searched AssetLog across 10 categories: mesh deformation, projectile/trajectory, enemy AI, destruction, platformer, animal models, ragdoll, lighting, shaders, map/minimap
- Identified ~30 relevant assets with sprint-aligned install schedule
- Key finding: Toolkit for Ballistics 2026 + ALINE eliminates need for separate line renderer asset
- Key finding: Toon Kit 2 + Outlines Post-Process matches GDD art direction ("thick outlines, vibrant colors")
- Key finding: SensorToolkit2 + Behavior Designer Pro + A* Pathfinding Pro = complete AI stack
- Key finding: AA Map and Minimap, Smart Lighting 2D still need formal evaluation
- Updated AQS_Status.md with full asset audit results organized by sprint
- Updated AQS_DevReference.md with AssetLog-sourced recommendations in dependency tables

---

## Session 0 (Mar 12, 2026) -- COMPLETE

**Status:** Project resurrection. Docs recovered from Google Drive, reformatted to current doc system.

**Session 0 Work:**
- Retrieved archived docs from `E:\Unity\Sandbox\Documents\AQuokkaStory\Documents\Archives\`
- Created AQS_Status.md, AQS_DevReference.md, GDD/AQS_GDD.md in current format
- Updated architecture: SOAP dropped (vanilla SO + GameEvent/GameEventListener), Dynamic Bone replaced by BoingBones, Unity-Event-Bus/Improved-Timers replaced by TecVooDoo Utilities, Service Locator replaced by PersistentSingleton
- Created `Assets/_Sandbox/_AQS/` working folder in Sandbox
- Flagged assets needing re-evaluation for current ecosystem
- Decided: custom movement (not Corgi Engine), Scorch from HOK as placeholder, RayFire for destruction
- Created 5-sprint development plan for Sandbox gameplay prototyping

---

## Known Issues

| Issue | Severity | Status | Notes |
|-------|----------|--------|-------|
| All code lost | Critical | Accepted | Rebuilding from docs |
| Package stack needs re-evaluation | Medium | DONE | Asset audit complete -- 30 relevant assets identified from AssetLog |
| GDD may need design updates | Medium | TODO | User to review after format cleanup |
| No GitHub repo yet | Medium | DONE | https://github.com/TecVooDoo/Sandbox |

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
