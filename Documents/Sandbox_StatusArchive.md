# Sandbox - Status Archive

**Project:** Sandbox (Asset Evaluation Environment)

**Archive of older session entries from Sandbox_Status.md. Newest first.**

---

## Session 59 (Mar 19, 2026) -- SpaceSucks Asset Evals

**Status:** Asset evaluations for SpaceSucks project (zero-G ECS/DOTS puzzle platformer). Evals performed in SpaceSucks project, logged here.

**Session 59 Work:**
- 4 new asset evaluations: com.unity.charactercontroller 1.4.2 (ENTRY-302, Approved Recommended -- ECS character controller foundation for SpaceSucks), KINERACTIVE 1.11 (ENTRY-303, Approved -- IK interaction for station controls), customized objects gravity (ENTRY-304, Rejected -- superseded by Heathen ENTRY-209), Camera System Gaskellgames (ENTRY-305, Rejected -- non-functional, redundant with Cinemachine).
- MCP controllability assessed for 6 assets (ENTRY-302 through 305 + GrabMaster ENTRY-239 + SensorToolkit 2 ENTRY-231).
- SpaceSucks architecture decision: dropped Opsive UCC (ENTRY-165) in favor of com.unity.charactercontroller for pure ECS/DOTS stack.

**Asset Log:** 306 entries (5 new: ENTRY-302 through 306).

---

## Session 58 (Mar 12, 2026) -- COMPLETE

**Status:** A Quokka Story Sprint 1 foundation -- scripts, input, placeholder character, GitHub setup.

**Session 58 Work:**
- AQS Sprint 1 start: GameEvent system, QuokkaController (hop movement, jump, ground detection), QuokkaInputHandler, Input Actions asset
- Imported Scorch from HOK as placeholder character (models, materials, animations only)
- Created .gitignore with third-party asset exclusions, initial commit + push to GitHub
- Debugged Unity 6 compile issues: `GetContacts(List<>)` silent failure, 2D vs 3D physics types for 2.5D
- Asset audit: 30 relevant assets identified from AssetLog for AQS across 5 sprints
- Boing Kit vs All In 1 Springs comparison (Boing Kit wins for AQS)

**Asset Log:** 293 entries (2 new: ENTRY-292 Boing Kit install, ENTRY-293 Rope Toolkit install confirmed).

---

## Session 57 (Mar 12, 2026) -- COMPLETE

**Status:** FearSteez standalone migration complete. Doc consolidation -- single source of truth for asset evals, MCP candidates, and TecVooDoo Utilities candidates.

**Session 57 Work:**
- FearSteez migration Phase 1 (packages) + Phase 2 (code/asset export) complete. Standalone project at `E:\Unity\FearSteez` with own Claude instance. Sandbox subproject archived.
- Created full FearSteez standalone doc set: FS_Status.md, FS_CodeReference.md, FS_DevReference.md, FS_Migration_Manifest.md, FS_Art_AssetList.md, FS_Synty_Reference.md, FS_Status_Archive.md, GDD/FS_GDD.md.
- Created Sandbox_DevReference.md -- coding standards, MCP gotchas, eval standards, AI rules.
- Created TecVooDoo Utilities docs: TVU_Status.md, TVU_Reference.md at `E:\TecVooDoo\Projects\Other\TecVooDooUtilities\Documents\`.
- Created TecVooDoo MCP Tools docs: TMCP_Status.md, TMCP_Reference.md at `E:\TecVooDoo\Projects\Other\TecVooDooMCPTools\Documents\`.
- Fixed MCP Tools package sync: copied FinalIK + PrefabWorldBuilder folders from source to UPM package. All 35 tools now in package.
- Consolidated asset evals into Sandbox_AssetLog.md: added 11 new entries (ENTRY-281 through 291) from VNPC (Ink Integration), AudioProject (PATWA), and SyntyAssets (9 Synty pack evals).
- Added Sandbox ENTRY cross-references to MCP Candidates and VNPC AI-Friendliness tables (replaced all VNPC-### and MCP-EVAL-### local numbering with Sandbox ENTRY numbers).
- Fixed MagicaCloth 2 ENTRY: TBD -> ENTRY-095.
- Archived 5 project subfolders to `Documents/Archives/`: SyntyAssets, AudioProject, SyntySidekicks, AssetInventory, FearSteez (Sandbox).
- Updated coding standards across HOK, FearSteez, Sandbox DevReferences: removed 800-1200 line rule, added responsibility-based extraction, added interfaces/generics preference.

**Asset Log:** 291 entries (was 280). New: ENTRY-281 Ink Integration, ENTRY-282 PATWA, ENTRY-283-291 Synty Polygon pack evals.

---

## Session 56 (Mar 9, 2026) -- COMPLETE

**Status:** MCP controllability eval for 5 rope/physics assets; Rope Toolkit full eval; meteor hammer weapon design discussion.

**Session 56 Work:**
- Completed full MCP eval on 5 rope/physics assets: Rope Toolkit, Toolkit for Unity Physics 2026, Toolkit for Verlet Motion 2026, FS Grappling Hook System, FS Rope Swinging System.
- Full asset evaluation for Rope Toolkit 2.2.3 (ENTRY-271) -- Approved Recommended. Jobs/Burst rope physics, 4 connection types, dynamic splitting, rich public API.
- ENTRY-272: MCP Controllability Eval for Rope/Physics Assets.
- Discovered MCP serializer crash pattern: components using Unity.Collections NativeArrays (Rope, VerletLine) crash `component-get` and must use `script-execute` instead.
- FearSteez meteor hammer weapon concept: hybrid approach recommended -- Frank Slash body animations retargeted to Sidekick rig + Rope Toolkit for cord physics.

**Key Findings:**
- **Rope Toolkit:** component-add ✅, component-get ❌ (NativeArray crash), component-modify ✅ (simple fields), script-execute ✅ (full API access -- read/write all settings, PushSpawnPoint, GetCurrentLength, PushSpawnPoint). **Best MCP candidate** -- full control via script-execute.
- **Unity Physics 2026:** All 4 components (PhysicsData, BuoyantBody, ForceEffectField, ForceEffectReceiver) fully MCP-controllable via standard add/get/modify pipeline.
- **Verlet Motion 2026:** VerletTransforms works via standard pipeline; VerletLine crashes serializer (same NativeArray pattern as Rope).
- **FS Grappling Hook / Rope Swinging:** Components add/read/modify fine, but functionally useless without the full Fantacode PlayerController/ItemEquipper/AnimGraph stack.

---

## Session 55 (Mar 6, 2026) -- COMPLETE

**Status:** Full MCP tool evaluation -- all custom and built-in extensions verified in SyntyAssets project.

**Session 55 Work:**
- Completed full evaluation of all 3 IvanMurzak built-in MCP extensions (Animation, ParticleSystem, ProBuilder) with detailed gotcha documentation.
- Completed full evaluation of all 5 custom MCP tool groups (Flexalon, PWB, RayFire, MagicaCloth2, FinalIK) and AssetInventory tools.
- Fixed `flexalon-create-random-layout` NullReferenceException: `FlexalonLayoutBase [RequireComponent(typeof(FlexalonObject))]` auto-adds FlexalonObject; original code used `AddComponent<FlexalonObject>()` (returns null duplicate); fix: use `GetComponent<FlexalonObject>()`.
- ENTRY-267: Custom MCP Tool Extensions (Sessions 52-55) -- 35 custom tools built across 6 assets.
- Updated ENTRY-024 (PWB), ENTRY-168 (RayFire), ENTRY-226 (Flexalon) with MCP tool capability notes.
- Evaluated Retarget Pro 4.2.1 for MCP tool potential -- decided against (only batch-bake would be useful; profile setup requires UI; not worth 1 tool). ENTRY-243 updated with note.

**Key Findings (built-in MCP extensions):**
- **Animation:** `componentType` must use full namespace (`UnityEngine.Transform` not `Transform`); `RemoveCurve` uses internal names (`m_LocalPosition.x` not `localPosition.x`). All 6 animation tools confirmed working.
- **ParticleSystem:** MinMaxCurve via `value:{}` is BROKEN -- values corrupt on assignment. Workaround: use `*Multiplier` scalar companions (e.g., `startLifetimeMultiplier: 4.0`). Simple float/bool/int properties work fine.
- **ProBuilder:** Prefer semantic `faceDirection` over vertex/face index arrays. Must re-read mesh info after each modifying operation (indices change). All 13 tools confirmed working.

**Key Findings (custom tools):**
- **Flexalon (8 tools):** All working. Use `instanceID` not name for `layoutRef`. `[RequireComponent]` bug fixed.
- **PWB (4 tools):** All working. Palettes persist across sessions. `brushName` partial match preferred over index.
- **FinalIK (5 tools):** All working. Pass character root GameObject; auto-detect works on humanoid rigs.
- **MagicaCloth2 (6 tools):** All working. `add-mesh-cloth` needs MeshRenderer or SkinnedMeshRenderer on target.
- **RayFire (7 tools):** Setup tools work; `rayfire-demolish` and `rayfire-apply-damage` crash Unity from MCP context (runtime physics conflict with `MainThread.Run()`).

---

## Session 54 (Mar 6, 2026) -- COMPLETE

**Status:** AssetInventory import tool + package filter + custom MCP fixes (SyntyAssets project).

**Session 54 Work:**
- Built `asset-inventory-import` tool: async `Assets.CopyTo()` works via `EditorApplication.delayCall += async () => { ... }` (not `.Wait()` which deadlocks, not `async void` which freezes).
- Added `packageFilter` parameter to `asset-inventory-search` and `asset-inventory-search-prefabs` (partial match, case-insensitive).
- Documented RayFire runtime crash: `DemolishForced()` and `ApplyDamage()` crash Unity from MCP context.
- Sidekick mesh transfer pattern: remap `bones[]` array by name, remap `rootBone`, swap `sharedMaterial`.
- Fixed various compile issues; confirmed 111 total MCP tools in Unity.

---

## Session 53 (Mar 5-6, 2026) -- COMPLETE

**Status:** Custom MCP tools phase 2 -- RayFire, MagicaCloth2, FinalIK, AssetInventory (SyntyAssets project).

**Session 53 Work:**
- Built `rayfire-add-rigid`, `rayfire-configure-rigid`, `rayfire-add-shatter`, `rayfire-fragment`, `rayfire-list-rigid`, `rayfire-demolish`, `rayfire-apply-damage` (7 tools).
- Built `magica-add-bone-cloth`, `magica-add-mesh-cloth`, `magica-list-cloth`, `magica-add-sphere-collider`, `magica-add-capsule-collider`, `magica-add-wind` (6 tools).
- Built `finalik-add-fbbik`, `finalik-set-effector`, `finalik-add-lookat`, `finalik-add-aim`, `finalik-list-ik` (5 tools).
- Built `asset-inventory-search`, `asset-inventory-search-prefabs`, `asset-inventory-list-packages` (3 tools).
- Built `MCPToolsDefineManager.cs` preprocessor guard system: auto-detect via `[InitializeOnLoad]` + `Type.GetType()`, adds/removes `HAS_*` defines for each asset.

---

## Session 52 (Mar 5, 2026) -- COMPLETE

**Status:** Custom MCP tools phase 1 -- Flexalon, PWB (SyntyAssets project).

**Session 52 Work:**
- Built custom MCP tool extension pattern following Ivan Murzak's ProBuilder extension as template.
- Built `flexalon-list-layouts`, `flexalon-create-grid-layout`, `flexalon-create-circle-layout`, `flexalon-create-flexible-layout`, `flexalon-create-random-layout`, `flexalon-add-child`, `flexalon-add-prefab-children`, `flexalon-set-object-size` (8 tools).
- Built `pwb-list-palettes`, `pwb-add-to-palette`, `pwb-place-brush`, `pwb-place-line` (4 tools).
- Key architecture: `MainThread` lives in `ReflectorNet.dll` -- asmdef needs `overrideReferences: true` + precompiled ref. Namespace collision: use `global::` prefix for ambiguous types.

---

## Session 51 (Mar 5, 2026) -- COMPLETE

**Status:** Synty asset workflow testing and PolygonParticleFX evaluation (SyntyAssets project).

**Session 51 Work:**
- Restructured SyntyAssets project fresh. Imported Coffee Shop, Shops, Shopping Plaza Map, NatureBiomes, SidekickCharacters, PolygonPrototype, PolygonStarter, PolygonParticleFX via Synty Store Importer.
- ENTRY-265: Synty Store Importer -- Approved. Bundled tool in SyntyPass packs for importing content into Unity projects from local SyntyPass folder.
- ENTRY-266: PolygonParticleFX (Synty Studios) -- Approved (Art, VFX, Low Poly). ~170 gameplay VFX prefabs covering combat, magic, fire/explosions, environmental, UI/pickups, impacts, projectiles, cartoony feel. Complements content pack ambient FX (NatureBiomes wildlife/atmosphere). Minimal overlap between the two.
- Built test scene via MCP: street with coffee shop, two greybox buildings (Prototype pieces), road, outdoor props, car, environment.
- Built swamp area behind coffee shop using NatureBiomes swamp assets (water, fog, trees, shack, jetty, vegetation, props).
- Tested ParticleFX in scene: blizzard (heavy snow, great mood transformation), rainbow sparkle (close-up ring effect, not sky-arc), nuke (full mushroom cloud + shockwave).
- **Greyboxing workflow findings:** ProBuilder → Synty direct (skip Prototype); nature scenes skip greybox entirely. Documented in asset log as workflow reference.
- Evaluated in SyntyAssets project (E:\Unity\SyntyAssets).

---

## Session 50 (Mar 5, 2026) -- COMPLETE

**Status:** Easy Build System evaluation (from SyntyAssets project).

**Session 50 Work:**
- ENTRY-264: Easy Build System (PolarInteractive) -- Approved. 101 scripts, ~17.2K LOC, socket-based building/snapping system. Dual input system support (new + legacy). Bundled integrations: FishNet, Mirror, PUN V2, Game Creator 2, PlayMaker, Rewired, XR. URP/HDRP support packages. 11 demo scenes + 5 addon scenes. No asmdef by default. HOK-relevant for base/dock building.
- Evaluated in SyntyAssets project (E:\Unity\SyntyAssets) rather than Sandbox due to project restructuring.

---

## Session 49 (Mar 4, 2026) -- COMPLETE

**Status:** Sandbox cleanup + Default UI Toolkit promotion.

**Session 49 Work:**
- Removed 22 non-Default, non-FearSteez asset folders from Assets/ and Plugins/
- Removed: BeatEmUp_GameTemplate3D, BundleDemos, Frank_Fighting_Set4, Frank_Slash_Pack, Graphy, GUPS, Photon, polyperfect, RayFire, SABI, SICS_Games, Synty, TutorialInfo, UFE, UnityTechnologies, Voxel Labs, WeatherMaker, Kamgam (error -- reinstalled Easy Pooling + UI Toolkit), Plugins/AllIn13DShader, Plugins/PlayMaker, Plugins/RelationsInspector, Plugins/Timeflow, Plugins/Pixel Crushers
- Fixed: RelationsInspector residual in Plugins/Editor, Timeflow Presets residual in Plugins/Timeflow
- User uninstalled via Package Manager: Timeflow, Dialogue System for Unity, Magic Animation Blend (KINEMATION)
- FishNet + PurrNet also uninstalled by user (will reinstall when prototype testing begins)
- **Kamgam deletion error:** Kamgam folder contained Easy Pooling (FearSteez dependency) + all UI Toolkit Default packages. User reimported Easy Pooling + UI Toolkit packages from Asset Store cache.
- **Default UI Toolkit promotion:** All Kamgam UI Toolkit packages (116, 118-123, 125-126) + Flow UI Toolkit Extended (134) + Toolkit for UX 2026 (131) promoted from Recommended/Conditional to **Default UI** label. All current and future TecVooDoo projects use UI Toolkit.
- Updated MEMORY.md "New Project Setup" with full 38-item Default list (27 Default + 11 Default UI).

**Kept for pending cherry-pick:**
- Fantacode Studios (FS Parkour) -- ParkourAction SO data pattern not yet extracted for FearSteez traversal

---

## Session 48 (Mar 4, 2026) -- COMPLETE

**Status:** Sale asset batch -- UFE2 Pro full eval, Squash & Stretch Kit, Boing Kit, FishNet, PurrNet evals. PurrNet also added (was not in original list).

**Session 48 Work:**
- ENTRY-253: UFE2 Pro 2.7.0a -- Approved (cherry-pick reference, no primary label). Cherry-pick for FearSteez: frame data vocabulary (startUpFrames/activeFrames/recoveryFrames as explicit ints), per-body-part hitbox assignment, hit stop + camera shake in hit SO, frame link windows.
- ENTRY-254: Magic Animation Blend 3.2.2 -- Deferred (not yet installed).
- ENTRY-255: Squash & Stretch Kit 1.1.2 -- Conditional. Redundant with Feel's built-in squash & stretch for objects in the Feel pipeline. Useful for physics objects and anything needing continuous motion-driven deformation outside Feel.
- ENTRY-256: Boing Kit 1.2.47 -- Approved. BoingBones fills a real gap: transform-based spring bone chain physics, no SMR requirement, clean Animancer compatibility. `AnimationBlend` per bone is production-quality. Use alongside MagicaCloth 2 (different roles: BoingBones = bone chains, MC2 = mesh cloth).
- ENTRY-257: DS OpenAI + ElevenLabs Addon -- Deferred (not yet installed).
- ENTRY-258: FS Parkour and Climbing System -- Deferred (not yet installed).
- ENTRY-259: FishNet 4.6.22r -- Approved. Viable Photon Fusion 2 alternative. Eliminates CCU costs; tradeoff is self-managed hosting/relay.
- ENTRY-260: PurrNet 1.19.0 -- Approved. Edges out FishNet for FearSteez v3: `SyncInput<T>` handles combo input timing cleanly, `NetworkBones` built-in for bone sync, per-RPC delta packing. Modern API, smaller community.

**Key findings:**
- UFE2 Pro's MoveData SO = textbook FGC frame data. FSAttackData should upgrade from normalized floats to explicit frame counts (startUp/active/recovery at 60fps).
- BoingBones + MagicaCloth 2 = complementary, not competing. BoingBones: bone chains (hair, ears, loose chains). MC2: mesh cloth (mic cord, cape).
- PurrNet is the current top networking candidate for FearSteez v3. Next step: minimal host/client prototype (2 players, position + NetworkBones sync, SyncInput attack combo).

---

## Session 47 (Mar 4, 2026) -- COMPLETE

**Status:** FearSteez dev (sessions 5-6) + Asset Inventory 4 eval.

**Session 47 Work:**
- FearSteez Sessions 5-6: Full prototype pipeline -- player movement, 3-hit combo, EnemyPatrol, EnemyHealth with Damage Numbers Pro, look-at IK. See `FS_Status.md` for full detail.
- ENTRY-252: Asset Inventory 4 -- Approved, **Default**, QoL (Wetzold Studios). External shared SQLite database. URP auto-adapter. Project Window toolbar. Install in every project via `ASSETINVENTORY_CONFIG_PATH` env var. Dedicated AssetInventoryProject model now obsolete.
- Updated MEMORY.md with "New Project Setup" section listing all Default assets.
- Next session candidate: remove art assets from Sandbox, test AI4 selective import from uninstalled packages.

**Key findings:**
- AI4's shared database model works across all projects -- one install point, zero per-project indexing cost.
- URP auto-adapter is the headline upgrade over v3 -- eliminates manual BIRP→URP conversion step after import.

---

## Session 45 (Feb 28, 2026) -- COMPLETE

**Status:** Full retroactive label system overhaul across all 232 entries.

**Session 45 Work:**
- Redesigned primary label system: Default (truly universal) + Recommended (dynamic best-in-class) + Don't Use (beyond redemption) + no label (situational)
- Removed obsolete primary labels: Default 3D, Default Mobile, Default Audio, Default Audio Mobile, Default UI, Default uGUI, Default UI Audio
- Added Low Poly as a secondary label
- Updated summary table: all 232 entries reclassified under new system
- Fixed misclassified verdicts: Buto (182), Megapack (180), Better Bloom (186), Outlines Post-Process (191), Ultimate Lit Shader (196) -- all were incorrectly Rejected|Don't Use (removed for space, not rejected)
- Fixed ENTRY block labels across all 116+ evaluated detailed entries
- Fixed DevTrails (022): removed incorrect Don't Use label (Conditional verdict)
- Fixed Unity-PlayerPrefsEx (059): removed Default label (Conditional verdict)
- Fixed Crosshairs (176, 177): removed Default (shooter-specific, not universal)
- Key Recommended winners per domain: SW3 (water), Animancer Pro (animation), Final IK (IK), MagicaCloth 2 (cloth), UModeler X Plus (modeling), A* Pathfinding (pathfinding), UCC (character), RayFire (destruction), Kamgam suite (mesh tools), Altos (sky/weather), Buto (fog), Koreographer (music sync), etc.

**Key Findings:**
- ~45 entries moved from Default 3D/Audio/UI → Recommended (not universal, but best-in-class)
- ~30 entries moved from Default 3D/Audio/UI → -- (situational, no label)
- ~11 entries corrected from Rejected|Don't Use → Approved|-- or Approved|Recommended (removed for space, not rejected)
- Default count reduced from ~80 to ~30 genuinely universal tools (QoL, audio systems, async, inspector, tweening, MCP, etc.)

---

## Session 44 (Feb 28, 2026) -- COMPLETE

**Status:** Aline, Photon PUN 2+, Behavior Designer Pro, Senses Pack, SensorToolkit2, Interactor.

**Session 44 Work:**
- ENTRY-227: Aline 1.7.9 -- Approved, Default (28 scripts, Burst-safe in-game gizmos, URP+HDRP, supersedes Unity built-in Gizmos)
- ENTRY-228: Photon PUN 2+ 2.5.2 -- Approved, -- (217 scripts; de facto multiplayer standard, not needed in all projects)
- ENTRY-229: Behavior Designer Pro 2.1.12 -- Approved, Default (262 scripts, DOTS-based behavior trees, 16 demos, utility theory, ECS support)
- ENTRY-230: Senses Pack for BD 1.0.3 -- Conditional (34 scripts; vision/hearing/smell/temp add-on for BD; overlaps with SensorToolkit2 for basic sensing)
- ENTRY-231: SensorToolkit2 2.5.17 -- Approved, Default 3D (157 scripts; range/arc/LOS/NavMesh sensors + Burst VO steering, 16 demos, BD integration)
- ENTRY-232: Interactor 0.999b -- Conditional (95 scripts; 9 interaction types + full-body IK; pre-1.0 + no asmdef + no demo scenes)

**Key Findings:**
- Behavior Designer (229) + SensorToolkit2 (231) form a strong AI stack -- BD handles decision-making, ST2 handles detection. They have an explicit integration pack.
- Senses Pack (230) overlaps ST2 for vision/range/proximity. Only add Senses Pack if scent trails or thermal mechanics are specifically needed.
- Interactor (232) bundles IK, pathfinding, and inventory -- impressive but pre-1.0 and those bundled systems partially duplicate ENTRY-169, ENTRY-224.
- Aline (227) replaces Unity's built-in Gizmos entirely -- Burst-safe, in-game rendering, text labels.
- Assembly-CSharp bloat warning: PUN 2 (217) + Dialogue System (727) both have no asmdef. Adding Interactor (95, no asmdef) to the same project means ~1,039 scripts in Assembly-CSharp.

---

## Previous Session (Session 43 - Feb 28, 2026) -- COMPLETE

**Status:** Flexalon 3D Layouts evaluation.

**Session 43 Work:**
- ENTRY-226: Flexalon 3D Layouts 4.4.1 -- Approved, Default (82 scripts, 4 asmdefs, 7 layout types, drag-drop interaction, data-driven cloner, 24 demos, Unity 6 native)

**Key Findings:**
- Flexalon replaces Unity's built-in LayoutGroup entirely and extends to 3D world space -- no Unity equivalent for world-space layouts
- `FlexalonCloner` + `FlexalonDataSource` = runtime data-driven UI generation (dynamic inventory lists, leaderboards, etc.)
- `FlexalonInteractable` + `FlexalonDragTarget` = drag-and-drop between layouts without custom input code
- HIGH relevance for DLYH (letter grid), HOK (inventory/HUD), any game with non-trivial UI or 3D arranged objects

---

## Previous Session (Session 42 - Feb 28, 2026) -- COMPLETE

**Status:** Mixed batch -- Pixel Crushers, FImpossible Creations, Fantacode Studios, Fish Alive, RootMotion.

**Session 42 Work:**
- ENTRY-214: Dialogue System for Unity 2.2.66 -- Approved, Default (727 scripts, Lua, Yarn/Articy import, 30+ integrations)
- ENTRY-215: Dialogue System Addon - Procedural Dialogue 1.0.5 -- Approved, -- (add-on; gendered grammar, pluralization, 26 scripts)
- ENTRY-216: Ragdoll Animator 2 1.0.4.1 -- Approved, Default 3D (95 scripts, physics-blend ragdoll, 20+ extra modules)
- ENTRY-217: F Texture Tools 1.1.5 -- Approved, Default (18 scripts editor-only; 9 texture processing windows)
- ENTRY-218: Ground Fitter 1.2.2 -- Approved, Default 3D (15 scripts; terrain slope alignment, ZoneCast, NavMesh)
- ENTRY-219: FS Melee Combat System 2.0.6 -- Approved, Default 3D (33 scripts + shared base; combo system, AI, 4 demos)
- ENTRY-220: FS Rope Swinging System 1.2.4 -- Approved, -- (12 scripts; grapple/swing, niche mechanic)
- ENTRY-221: FS Shooter System 1.2 -- Approved, Default 3D (38 scripts; 3P+1P, cover system, 3 demos)
- ENTRY-222: Fish Alive Freshwater Set 1.2 -- Approved, Default 3D (shared 12 scripts; FishMotion, schooling, HOK-primary)
- ENTRY-223: Fish Alive Marine Set 1.2 -- Approved, Default 3D (shared scripts; reef/open-water species)
- ENTRY-224: PuppetMaster 1.4 -- Approved, Default 3D (154 scripts; muscle puppet, Baker, RagdollManager, 31 demos)
- ENTRY-225: Body Poser 1.4 -- Approved, Default 3D (3 scripts; humanoid pose editor, JSON, batch tool)
- ENTRY-033 (Fish Alive early) superseded by ENTRY-222 and ENTRY-223

**Key Findings:**
- Fantacode Studios (Melee + Shooter + Rope) share a common FS_Core + FS_ThirdPerson base -- all three systems are additive on one character
- FS Melee (219) supersedes Beat Em Up Template (166) as FearSteez build foundation; 166 becomes reference only
- Ragdoll Animator 2 (216) + PuppetMaster (224) are complementary: RA2 for lightweight hit blending, PM for full puppet simulation
- Dialogue System (214) is the single most script-heavy asset (727) -- expect compile time impact
- Fish Alive HOK path confirmed: FishMotion.SetAutoMotion(false) + drive bone_mouth toward lure + SetReachMode(true)

---

## Previous Session (Session 41 - Feb 28, 2026) -- COMPLETE

**Status:** Heathen Engineering package evaluations + Steamworks.NET install.

**Session 41 Work:**
- Installed Steamworks.NET (com.rlabrecque.steamworks.net v20.2.0) via OpenUPM -- added scope + dependency to manifest.json
- ENTRY-207: Toolkit for Verlet Motion 2026 -- Approved, Default 3D (transform-chain cloth/rope/chain, 17 scripts)
- ENTRY-208: Toolkit for Ballistics 2026 -- Approved, Default 3D (2D+3D projectile trajectory, TrickShot ricochet, 27 scripts). Replaces OccaSoftware Ballistics (ENTRY-203).
- ENTRY-209: Toolkit for Unity Physics 2026 -- Approved, Default 3D (BuoyantBody + ForceEffectFields + Breakable destruction, 62 scripts, includes MIConvexHull)
- ENTRY-210: Toolkit for Steamworks 2026 -- Approved, Default (full Steam SDK wrapper, 303 scripts, 11 example scenes, all API surfaces)
- ENTRY-211: Toolkit for Discord Social Preview -- Conditional (v0.2.0 preview, Discord SDK uncertain future)
- ENTRY-212: UX Flat Icons [Free] -- Approved, Default UI (304 PNG icons, pairs with UX 2026)
- ENTRY-213: Toolkits for Unity Bundle 2026 -- bundle purchase unlock (individual packages are the content)
- All OccaSoftware packages removed from project post-evaluation to free space

**Key findings:**
- Heathen Engineering = professional engineering-first packages. Consistent API.* static pattern, Unity 6 native, clean namespaces.
- Steamworks (210) is the deepest Unity-Steam integration available -- replaces any bespoke Steam wrapper
- Verlet (207) + Physics (209) together fill ALL Unity physics gaps: cloth/chain simulation + buoyancy + force fields + destruction
- Ballistics (208) supersedes OccaSoftware Ballistics (ENTRY-203) -- more features (2D, ricochet, targeting)
- Discord Social (211) blocked by Preview status and uncertain Discord SDK future

---

## Previous Session (Session 40 - Feb 27-28, 2026) -- COMPLETE

**Status:** FearSteez character swap testing + RayFire/Inventory eval + OccaSoftware batch import + OccaSoftware evaluations.

**Session 40 Work:**
- Removed `com.ivanmurzak.unity.mcp.particlesystem` package (CS0117 errors -- McpPlugin.Instance API mismatch with main MCP 0.51.1)
- ENTRY-168: RayFire 2 -- Approved, Default 3D (runtime destruction, 98 scripts, ~44K LOC, native C++ kernel)
- ENTRY-169: Inventory Framework 2 FREE -- Approved, Default UI (UI Toolkit inventory, 179 scripts, ~7.5K LOC, 3 bag types)
- Asset Store label system expanded to two-tier: Primary (project scope) + Secondary (functional domain -- Animation, Art, Character, Mesh, Shader, Environment, Physics, AI, VFX, Text, QoL)
- Batch-imported OccaSoftware collection via `OccaSoftwareBatchImporter.cs` then reinstalled via Package Manager for full installs
- ENTRY-170 to 178: 9 packages in `Assets/OccaSoftware/` (traditional .unitypackage). Fully evaluated.
- ENTRY-181 to 206: 26 UPM packages in `Packages/com.occasoftware.*`. All installed and fully evaluated.
- ENTRY-179 (LocalGI): Rejected -- Unity 6 RenderTargetHandle removed. ENTRY-180 (Megapack): Rejected -- readme only.
- **OccaSoftware Atmosphere Ecosystem identified:** Altos (181) + Buto (182) + LSPP (185) + Dynamic Cloud Shadows (184) + Auto Exposure (187) + Better Bloom (186) = full URP atmospheric rendering stack. Priority install for all outdoor 3D projects.

**Key findings:**
- OccaSoftware packages span shaders, post-process, VFX, art, scripting -- NOT a single-domain collection
- Best of OccaSoftware by rating: Buto (5★/56), Crosshairs (5★/49), Altos (5★/39), Super Simple Sky (5★/35), LSPP (5★/14)
- Atmosphere pipeline (Altos+Buto+LSPP) is the highest-value subset -- fills genuine URP gaps (no built-in volumetric fog, no procedural sky)
- Wireframe Shader (199) has 1/5 rating -- investigate before use
- Local Global Illumination (179) superseded by Unity 6's built-in SSGI and APV

---

## Previous Session (Session 39 - Feb 25, 2026) -- COMPLETE

**Status:** FearSteez subproject setup + asset evaluations + character swap testing.

**Session 39 Completed:**
- Converted FearSteez docs to HOK doc system (DevReference split, GDD subfolder, path updates)
- Removed redundant Documents/ subfolder, slimmed FS_Status.md from 364 to ~120 lines
- FearSteez docs now at `E:\Unity\Sandbox\Documents\FearSteez\`
- Scanned for Session 38 leftovers -- clean, no remnants
- ENTRY-166: Beat 'Em Up - Game Template 3D -- Approved (60 scripts, 4.8K LOC, 13 systems, OLD Input System)
- ENTRY-167: Frank Slash Pack -- Approved, Default 3D (1,034 FBX, 10 weapon types, ~65 whip clips)
- **Character swap test SUCCESS:** Synty SidekickCharacter swapped into Player1 prefab. Humanoid retargeting worked perfectly -- Biped animations played correctly on Synty skeleton with proper hit/kick alignment. Only 2 manual remaps needed (weaponBone -> hand_r, FollowBone -> pelvis).
- Enemy swap attempted with Low Poly Animated People (man_zombie) -- black silhouettes + idle-only. Material URP conversion and animator controller assignment needed.
- Professional strategy assessment: "Don't fork template -- use as playable reference, build clean with modern systems"

**Key findings:**
- Humanoid retargeting between Biped and Synty skeletons works seamlessly
- Beat 'Em Up template uses OLD Input System (Input.GetKey), SendMessage coupling, no namespaces, no asmdef
- Template combat tuning values (movement speeds, combo timing, hitbox sizes) are the key cherry-pick targets

---

## Previous Session (Session 38 - Feb 24, 2026) -- COMPLETE

**Status:** Completed remaining batch items + Amplify bundle + misc assets. 18 new entries (148-165). Total: 165 evaluations.

**Session 38 Completed:**
- ENTRY-148: Fluffy Grooming Tool (v1.2.3, free) -- Approved, fur/hair grooming & rendering
- ENTRY-149: Runtime Transform Handles (Battlehub, v3.x, $60) -- Approved, Default 3D
- ENTRY-150: Mesh Optimizer (IndieChest, $15) -- Approved, Default 3D, mesh decimation/LOD
- ENTRY-151: Decal Collider (Occlusionn, v1.1.3, $4.99) -- Approved, Default 3D
- ENTRY-152: EditorSculpt (htomioka, v1.70, free) -- Approved, Default 3D, mesh sculpting
- ENTRY-153: Deform (Beans, free) -- Approved, Default 3D, 44 deformers, Burst/Jobs
- ENTRY-154: Realistic Mesh Deformation (BoneCracker, free) -- Rejected, Don't Use (superseded by Deform)
- ENTRY-155: Curved World (Amazing Assets, v2025.5, $45) -- Approved, Default 3D
- ENTRY-156: Advanced Dissolve (Amazing Assets, v2025.4, $35) -- Approved, Default (has 2D support)
- ENTRY-157: Lattice Modifier (Harry Heath, v1.3.2, $25) -- Approved, Default 3D, GPU compute FFD
- ENTRY-158: Amplify Shader Editor (Amplify Creations, $110 bundle) -- Approved, Default
- ENTRY-159: Amplify Shader Pack (Amplify Creations) -- Approved, Default, 130+ shaders
- ENTRY-160: Street Props - Barricades (Amplify Creations, free) -- Approved, Default 3D
- ENTRY-161: Amplify Impostors (Amplify Creations) -- Approved, Default 3D, billboard LOD
- ENTRY-162: Amplify LUT Pack (Amplify Creations) -- Rejected, Don't Use (requires BiRP-only Amplify Color)
- ENTRY-163: Lighting Box 2 (ALIyerEdon, $10) -- Rejected, Don't Use (BiRP-only, shader errors on Unity 6)
- ENTRY-164: A* Pathfinding Project Pro (Aron Granberg, v5.x, $140) -- Approved, Default
- ENTRY-165: Ultimate Character Controller (Opsive, v3.x, $249) -- Approved, Default 3D

**Key findings:**
- Deformation ecosystem clarified: three complementary approaches -- Deform (153, Burst/Jobs CPU, 44 deformers), MegaFiers 2 (136, legacy CPU, Max-style modifiers), Lattice Modifier (157, GPU compute, FFD specialist). Realistic Mesh Deformation (154) fully superseded by Deform.
- Amazing Assets pattern: Curved World (155) and Advanced Dissolve (156) share installer pattern (nested unitypackages per pipeline), proper asmdefs/namespaces, hand-written shaders.
- Amplify bundle: 4/5 approved, LUT Pack rejected for BiRP-only Amplify Color dependency. ASE generates native HLSL (not Shader Graph wrapper). Shader Pack works without ASE.
- LOD pipeline: Mesh Optimizer (150, mid-range decimation) + Amplify Impostors (161, far-range billboards) = complete strategy.
- BiRP-only rejections: Amplify LUT Pack (162), Lighting Box 2 (163). Both require BiRP post-processing stacks.
- A* Pathfinding Pro (164): Industry-standard, Burst/Jobs/ECS, 6 graph types, RVO local avoidance.
- Ultimate Character Controller (165): Complete character framework -- kinematic movement, 39+ abilities, item/inventory, FP+TP switching.
- Session verdict split: 15 Approved, 3 Rejected.

**Next session:**
- FearSteez subproject setup in Sandbox (like HOK started as a subproject before standalone split)
- Beat 'em Up Game Template -- first FearSteez asset evaluation (deeper hands-on, potential cherry-pick)
- OccaSoftware Bundle (deferred -- many sub-assets, downloading from Asset Store takes time)
- Shader packs and texture packs (user has "a ton" queued)

---

## Previous Session (Session 37 - Feb 24, 2026) -- COMPLETE

**Status:** Chris West batch evaluation nearly complete. 12 assets evaluated + 2 bonus (MudBun, RTG).

**Session 37 Completed:**
- ENTRY-136: MegaFiers 2 (v1.58, $150) -- Approved, 57+ mesh deformation modifiers
- ENTRY-137: Mega Shapes (v2.54, $100) -- Approved, spline/loft/rope geometry
- ENTRY-138: MegaBook 2 (v1.17, $60) -- Approved, 3D page-turning book (VN-viable)
- ENTRY-139: Vulcan (v1.03, $60) -- Conditional, procedural flame mesh VFX (niche)
- ENTRY-140: Full Rig (v1.07, $50) -- Approved, catenary rope physics
- ENTRY-141: Mega Cache (v1.46, $29) -- Approved, mesh/particle/point cloud caching
- ENTRY-142: Texture Studio (v1.13, $100) -- Approved, GPU texture compositing with runtime API
- ENTRY-143: Mega Flow (v1.44, $65) -- Approved, 3D vector field / flow simulation
- ENTRY-144: Mega Scatter (v1.50, $50) -- Approved, spline-based procedural placement
- ENTRY-145: Mega Wires (v1.22, $45) -- Approved, dynamic wire/cable physics
- ENTRY-096-R: Full Sail (v1.26, $50) -- Rejected (upheld), desk re-eval
- ENTRY-146: MudBun (v1.6.52, $75) -- Approved, volumetric SDF modeling/VFX
- ENTRY-147: Runtime Transform Gizmos (v1.2.0, $25) -- Approved, Default 3D label
- Added TecVooDoo project portfolio (44 projects) to MEMORY.md for cross-project relevance scoring
- Updated entries 136-140 with full portfolio relevance sections
- Chris West ecosystem overlap analysis added to AssetLog
- JSONL recovery of ENTRY blocks 001-115 attempted
- Backed up Sandbox docs to `E:\TecVooDoo\Projects\Documents\SandboxDocuments\`

**Key findings:**
- Chris West ecosystem: 11 assets evaluated, no true redundancy. Three rope/wire approaches for different use cases. MegaShapes is the foundation dependency.
- Mega Flow and Mega Scatter install to `Assets/Mega-Fiers/` (hyphenated old convention) -- safe but inconsistent with MegaFiers 2's `Assets/MegaFiers/`
- All Chris West assets lack namespaces (global scope) -- consistent pattern
- None use Burst/Jobs -- all legacy System.Threading where threaded
- MudBun is the most technically sophisticated asset in the batch (Burst/Jobs/Compute, proper asmdef)
- Runtime Transform Gizmos earns Default 3D label -- useful across all 3D projects

---

## Session 36 Summary (Feb 23, 2026) -- COMPLETE

**Status:** Recovery complete. New Sandbox rebuilt and stable.

**Session 36 Completed:**
- Rebuilt Sandbox project with full package baseline after corruption
- Fixed MCP connectivity (needed both `.vscode/mcp.json` AND `.claude/mcp.json`)
- Installed IvanMurzak AI packages: Animation 1.0.30, ProBuilder 1.0.30, ParticleSystem 1.0.18
- MegaFiers 2 v1.58 imported -- first Chris West asset ready for evaluation
- Established one-at-a-time import protocol for Chris West batch

---

## Previous Session (Session 35 - Feb 22, 2026)

**Completed:** Full UI Toolkit asset evaluation batch (20 assets, entries 116-135).

**Key work:**
- Evaluated all 20 UI Toolkit assets loaded for DLYH Phase F polish evaluation
- Created Default UI and Default uGUI labels (scope-specific labels for UI framework assets)
- Created Default UI Audio label, assigned to Sound Effects (ENTRY-125)
- Text Animator (117) promoted to Default -- works for both TMP and UI Toolkit
- Text Animation 2 (116) = Default UI -- tighter Kamgam ecosystem integration
- Found and evaluated 6 initially-missed assets (3 in Assets/, 3 as embedded packages)
- Added UI Toolkit Pipeline ecosystem map
- Retroactive cherry-pick scan of all 135 assets for TecVooDoo Utilities candidates
- SimpleBoids refactored from NVJOB Boids into TecVooDoo Utilities

---

## Previous Session (Session 34 - Feb 22, 2026)

**Completed:** UI Toolkit evaluation setup (Phases 1-2).
- Phase 1: Understood DLYH architecture (single UIDocument, screen/modal pattern, GameEvent wiring)
- Phase 2: Built UIToolkitTestBed (3 screens, 4 modals mimicking DLYH patterns)
- UIToolkitTestBed.uxml, UIToolkitTestBed.uss (~550 lines dark/teal theme), UIToolkitTestBedController.cs

---

## Installed Packages (Session 36 Baseline - Feb 23, 2026)

New Sandbox rebuilt after data loss. Previous Asset Store packages not yet re-imported (evaluated previously, labels already assigned in AssetLog).

### Asset Store (Session 40)
| Package | Version | Label | Notes |
|---------|---------|-------|-------|
| Beat 'Em Up - Game Template 3D | 1.4 | Approved | FearSteez template reference |
| Frank Slash Pack - 11 Assets | 3.8 | Default 3D | Whip animations for FearSteez |
| Low Poly Animated People (polyperfect) | -- | Evaluating | 118 humanoid character prefabs |
| Odin Inspector/Serializer | -- | Default | Dev tool (loaded Session 39) |
| Animancer Pro | -- | Default 3D | Animation system (loaded Session 39) |
| RayFire 2 | 2.05 | Default 3D | Runtime destruction system |
| Inventory Framework 2 FREE | 2.0 | Default UI | UI Toolkit inventory system |

### Third-Party Packages
| Package | Version | Notes |
|---------|---------|-------|
| UniTask (Cysharp) | 2.5.10 | Local |
| R3 (Cysharp/NuGet) | 1.3.0 | Warning icon -- NuGet noise, not an error |
| AI Animation (IvanMurzak) | 1.0.30 | OpenUPM |
| AI Game Developer / MCP (IvanMurzak) | 0.51.1 | OpenUPM -- Warning icon NuGet noise |
| ~~AI Particle System (IvanMurzak)~~ | ~~1.0.18~~ | Removed Session 40 (McpPlugin.Instance API mismatch) |
| AI ProBuilder (IvanMurzak) | 1.0.30 | OpenUPM |
| Image Loader (IvanMurzak) | 7.0.1 | Local |
| PlayerPrefsEx (IvanMurzak) | 2.1.2 | OpenUPM -- Warning icon NuGet noise |
| Unity Theme (IvanMurzak) | 4.2.0 | Local |
| TecVooDoo Utilities | 1.0.0 | Local |

### Unity Built-In (Key Packages)
URP 17.3.0, Splines 2.8.2, ProBuilder 6.0.9, Cinemachine 3.1.5, Input System 1.18.0, Burst 1.8.28, Mathematics 1.3.3, Animation Rigging 1.4.1, Terrain Tools 5.3.1, AI Navigation 2.0.11, Timeline 1.8.10, Visual Scripting 1.9.9

### Microsoft / NuGet (MCP Dependencies)
~40 Microsoft.AspNetCore, Microsoft.Extensions, System.* packages. All show warning icons -- this is normal NuGet resolution noise from MCP's dependency chain. Not errors.

---

## Completed Evaluation Batch (Sessions 37-38)

**Batch:** Chris West / Mega series + related VFX/shader/deformation assets + Amplify bundle + misc

**Status:** COMPLETE -- All batch items evaluated except OccaSoftware Bundle (deferred).

**Chris West / Mega series (Sessions 37):**
- [x] MegaFiers 2 1.58 -- ENTRY-136, Approved
- [x] Mega Shapes 2.54 -- ENTRY-137, Approved
- [x] MegaBook 2 1.17 -- ENTRY-138, Approved
- [x] Vulcan 1.03 -- ENTRY-139, Conditional
- [x] Full Rig 1.07 -- ENTRY-140, Approved
- [x] Mega Cache 1.46 -- ENTRY-141, Approved
- [x] Texture Studio 1.13 -- ENTRY-142, Approved
- [x] Mega Flow 1.44 -- ENTRY-143, Approved
- [x] Mega Scatter 1.50 -- ENTRY-144, Approved
- [x] Mega Wires 1.22 -- ENTRY-145, Approved
- [x] Full Sail 1.26 -- ENTRY-096-R, Rejected (upheld, desk re-eval)
- [x] MudBun 1.6.52 -- ENTRY-146, Approved
- [x] Runtime Transform Gizmos 1.2.0 -- ENTRY-147, Approved (Default 3D)

**Session 38 additions:**
- [x] Fluffy Grooming Tool 1.2.3 -- ENTRY-148, Approved
- [x] Runtime Transform Handles 3.x -- ENTRY-149, Approved (Default 3D)
- [x] Mesh Optimizer -- ENTRY-150, Approved (Default 3D)
- [x] Decal Collider 1.1.3 -- ENTRY-151, Approved (Default 3D)
- [x] EditorSculpt 1.70 -- ENTRY-152, Approved (Default 3D)
- [x] Deform (Beans) -- ENTRY-153, Approved (Default 3D)
- [x] Realistic Mesh Deformation -- ENTRY-154, Rejected (Don't Use, superseded by Deform)
- [x] Curved World 2025.5 -- ENTRY-155, Approved (Default 3D)
- [x] Advanced Dissolve 2025.4 -- ENTRY-156, Approved (Default)
- [x] Lattice Modifier 1.3.2 -- ENTRY-157, Approved (Default 3D)
- [x] Amplify Shader Editor -- ENTRY-158, Approved (Default)
- [x] Amplify Shader Pack -- ENTRY-159, Approved (Default)
- [x] Street Props - Barricades -- ENTRY-160, Approved (Default 3D)
- [x] Amplify Impostors -- ENTRY-161, Approved (Default 3D)
- [x] Amplify LUT Pack -- ENTRY-162, Rejected (Don't Use, BiRP-only)
- [x] Lighting Box 2 -- ENTRY-163, Rejected (Don't Use, BiRP-only + shader errors)
- [x] A* Pathfinding Project Pro -- ENTRY-164, Approved (Default)
- [x] Ultimate Character Controller -- ENTRY-165, Approved (Default 3D)

**Deferred:**
- [ ] OccaSoftware Bundle - VFX and Shader Megapack 1.0 (many sub-assets, deferred to future session)

**Known issues from this batch:**
- Mega Flow and Mega Scatter install to `Assets/Mega-Fiers/` (hyphenated) -- coexists with MegaFiers 2's `Assets/MegaFiers/` but naming inconsistency
- All Chris West assets lack namespaces -- global scope pattern
- MudBun requires Burst/Jobs/Compute -- won't work on low-end mobile GPUs
- Amplify LUT Pack 1024x32 strip format NOT compatible with URP Color Grading
- Lighting Box 2 has shader compilation errors on Unity 6 (float3 to float4 conversion)

