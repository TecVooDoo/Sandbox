# Sandbox - Asset Evaluation Log (Archive)

**Purpose:** This document archives detailed ENTRY-XXX evaluation blocks from the live document [Sandbox_AssetLog.md](Sandbox_AssetLog.md). As the live AssetLog grew beyond manageable size (2,858 lines), completed evaluation phases are moved here to keep the working document within token limits while preserving all historical evaluation data.

**Last Updated:** February 9, 2026 (Session 13)

---

## Archive Instructions

- Detailed ENTRY blocks move here when their evaluation phase is marked COMPLETE in Sandbox_Status.md
- Entries are organized by evaluation phase
- Cross-asset interactions get logged as Lessons Learned in the live doc (not modifications to archived entries)
- Archived entries are historical records
- To find a specific entry, search by ENTRY number (e.g., "ENTRY-013")

---

## Editor Tools Phase (Sessions 3-5)

ENTRY-001 through ENTRY-027

---

#### ENTRY-001: Malbers Inventory System

| Field | Value |
|-------|-------|
| **Asset** | Malbers Inventory System |
| **Source** | Asset Store (Malbers Animations) |
| **Version** | 2.3 |
| **Category** | Other |
| **Date Started** | 2026-02-06 |
| **Date Completed** | 2026-02-07 |
| **Verdict** | Conditional |
| **HOK Applicable** | Maybe |

**What It Does:**
Slot-based list inventory system integrated with the Malbers Animal Controller ecosystem. Provides item definitions (ScriptableObjects), inventory containers with fixed slot counts, stacking, hotbar, equipment/armor system, currency/wallet, cooking/recipes, lootbags, shop system, and a complete uGUI interface with drag-and-drop. Save/load via Newtonsoft JSON with optional AES-256 encryption.

**What We Tested:**
Session 1 (Feb 6): Import and compile error fix only. Session 6 (Feb 7): Full code review of all 82 scripts. Architecture analysis of InventoryMaster, Inventory, Item, slot system, save/load, and AC integration points.

**Results:**
Functionally complete slot-based inventory. Well-separated data layer (Inventory + Item ScriptableObjects) from UI layer (InventorySlot + HotbarSlot). Uses AC's Reaction2 system for item effects (use, equip, drop) which makes item behaviors data-driven and Inspector-configurable.

Architecture concerns: InventoryMaster.cs is monolithic at 1,383 lines mixing UI setup, data management, serialization, game state, and currency. LINQ allocations in Inventory.cs AddStackableItem() and SortInventory() - these are called on item pickup and sort, not per-frame, but still create garbage. JSONDataService has hardcoded AES key and IV (security theater, not actual security). Dual-list synchronization pattern (itemList + quantityList must stay in sync) is fragile.

AC coupling is properly loose - uses ILockCharacter interface to freeze player during inventory. No direct MAnimal references in inventory code.

**Pros:**
- Clean data/UI separation (Inventory manages data, InventorySlot manages display)
- Item definitions as ScriptableObjects (data-driven, Inspector-friendly)
- Reaction2 system for item effects (same pattern as AC states/modes)
- Multiple inventory support (player, chests, shops)
- Complete save/load infrastructure (JSON + encryption option)
- Hotbar system with bidirectional slot linking
- Rarity color-coding system
- Durability tracking per item instance
- Loose coupling to AC via ILockCharacter interface
- Proper asmdef isolation (MalbersAnimations.Inventory.asmdef)

**Cons:**
- Ships with compile error (Lootbag.cs [SerializeField] on class - fixed in Sandbox)
- InventoryMaster.cs is monolithic (1,383 lines, 8+ responsibilities)
- LINQ allocations in item add/sort operations (garbage on each pickup)
- Hardcoded AES encryption key/IV in JSONDataService (security concern)
- Dual-list synchronization pattern (itemList + quantityList) is fragile
- Debug.Log statements left in shipped code
- var keyword throughout (not penalized per Lesson #10)
- Not grid-based - cannot serve as foundation for Tetris-style inventory
- No networking/multiplayer support
- Hardcoded save paths ("/playerInventories.json")

**Integration Notes:**
Compile error fix applied in Session 1. No other conflicts with installed packages. Requires Newtonsoft.Json (included via Unity Registry). Uses TextMeshPro for UI text. The MalbersAnimations.Inventory.asmdef references the core MalbersAnimations assembly.

**Performance:**
Not runtime profiled. Code review shows LINQ allocations in AddStackableItem() (.Select, .Where, .ToList) and SortInventory() (.OrderBy). These are event-driven (item pickup, sort button press), not per-frame. Acceptable for a fishing sim with infrequent item additions, but would need attention if items are added at high frequency.

**Verdict Rationale:**
Conditional. Functionally complete slot-based inventory that integrates cleanly with AC via interfaces. The monolithic InventoryMaster and LINQ allocations are code quality concerns but not blockers for a fishing sim where inventory operations are infrequent. The real question for HOK is whether a slot-based inventory meets the design vision or if the planned Tetris-style grid requires a ground-up build. If slot-based is acceptable for MVP, Malbers Inventory saves months of work. If grid is required from day one, this becomes reference material only.

**HOK Notes:**
HOK's planned "Cooler Inventory System" is Tetris-style grid. Malbers Inventory is slot-based list - fundamentally different layout model. Cannot be extended to grid without a complete rewrite of slot allocation, UI rendering, and drag-drop collision.

However, the non-layout systems are reusable patterns:
- Item definition ScriptableObjects (rarity, durability, stacking rules)
- Reaction2-based item effects (use, equip, drop triggering AC states)
- Save/load infrastructure (JSON serialization with item instance tracking)
- Currency/wallet system (if HOK has a soul-coin economy)
- Hotbar quick-access pattern

**Recommendation:** Keep installed as part of the Malbers ecosystem. Use as reference architecture for HOK's custom inventory. The Item.cs ScriptableObject pattern and Reaction2 integration are worth studying. Do not attempt to force-fit grid layout onto this slot system.

---

#### ENTRY-002: Procedural Generation Grid (FImpossible Creations)

| Field | Value |
|-------|-------|
| **Asset** | Procedural Generation Grid (Beta) |
| **Source** | Asset Store (FImpossible Creations) |
| **Version** | 1.6.6.2.12 |
| **Category** | Tools |
| **Date Started** | 2026-02-06 |
| **Date Completed** | 2026-02-07 |
| **Verdict** | Rejected (HOK) |
| **HOK Applicable** | No (but valid for other projects) |

**What It Does:**
Three-layer procedural grid-based level generation framework. Layer 1: FieldSetup + SpawnRules (per-cell rule evaluation). Layer 2: Mod Graph (visual node-based rule programming). Layer 3: Build Planner (layout generation with 185 planner nodes, A* pathfinding, shape generators). Includes GridPainter for manual cell painting, async generation, terrain integration, CSG mesh operations, Object Stamper, Tile Designer, and Pipe Generator sub-modules.

**What We Tested:**
Full code review of all 801 C# files (~155K lines) across PGG core and bundled dependencies (Shared Tools, Generators Shared, Object Stamper, Tile Designer, Pipe Generator, Mesh Operations CSG). Compile error fix verified. Architecture assessment. Head-to-head comparison with Prefab World Builder.

**Results:**
Architecturally ambitious framework with genuine depth. Three-layer design is well-conceived. 185 planner nodes, 130 spawn rules, A* pathfinding, and async generation represent substantial capability. Namespace discipline is clean (`FIMSpace.*` hierarchy). Zero external dependencies.

However, critical implementation issues: No asmdef for 801 files (all compile into default assemblies, destroying incremental compilation). ~99K lines of runtime code ships to builds whether runtime generation is used or not. Beta quality confirmed: WIP folders, dead code folders, `NotAvailable()` is copy-paste of `Available()` (inverted logic bug), method named `DONT_USE_IT_YET` actively called from 7 sites, 71 "neightbour" misspellings baked into public API, heavy commented-out debug code. Shipped compile error on import ([SerializeField] on class).

**Pros:**
- Genuinely powerful procedural generation framework (3 layers, 185 nodes, pathfinding)
- Clean namespace discipline (FIMSpace.* hierarchy)
- Zero external dependencies, fully self-contained
- Supports runtime generation (seed-based, async)
- Some allocation caching in critical paths shows performance awareness
- Long maintenance history (backward compat to Unity 2017)

**Cons:**
- No asmdef for 801 files - catastrophic compilation impact
- ~99K lines runtime code ships to all builds regardless of usage
- Beta quality: WIP folders, dead code, logic bugs, deprecated backups shipped
- Ships with compile error out of the box
- `NotAvailable()` copy-paste logic bug (dead code but dangerous)
- 192 `var` usages, 70 LINQ calls in runtime code
- Per-cell List allocations in generation hot paths
- `DONT_USE_IT_YET_OnReadPort` method actively called despite name
- 71 "neightbour" misspellings in public API (unfixable without breaking serialization)

**Integration Notes:**
Fix applied: `[SerializeField]` to `[System.Serializable]` on PortHandler class. Bundled dependencies (Shared Tools, Generators Shared, etc.) share the FImpossible Creations folder - removing PGG requires removing the entire folder tree.

**Performance:**
801 files with no asmdef means every script change in the project triggers full recompilation of PGG. Runtime footprint: ~99K lines / 565 files compile into player builds. Per-cell List allocations during generation can cause GC spikes on large grids.

**Verdict Rationale:**
Rejected for HOK. A cozy fishing sim with themed, narrative-driven environments needs hand-crafted level design, not procedural dungeon generation. The 99K-line runtime footprint adds massive build bloat for zero HOK benefit. Removed from Sandbox but NOT tagged "dont use" in Asset Store - this package has legitimate value for projects that need runtime procedural generation (roguelikes, infinite worlds, dungeon crawlers).

**HOK Notes:**
Not applicable to HOK. HOK's environments (River Styx, Kharon's realm) are thematic and hand-crafted. Prefab World Builder is the correct tool for HOK's level design needs. If HOK ever needs limited procedural elements (randomized fish spawns, underwater terrain variation), lighter custom solutions or RNGNeeds would be more appropriate than PGG's 155K-line framework.

---

#### ENTRY-003: vHierarchy 2

| Field | Value |
|-------|-------|
| **Asset** | vHierarchy 2 |
| **Source** | Asset Store |
| **Version** | 2.1.7 |
| **Category** | Tools |
| **Date Started** | 2026-02-06 |
| **Date Completed** | 2026-02-06 |
| **Verdict** | Approved |
| **HOK Applicable** | Yes |

**What It Does:**
Enhanced Unity Hierarchy window with visual customization, icons, color-coded rows, component indicators, alternating row backgrounds, minimal separators, active toggles, and drag-and-drop organization features. Adds at-a-glance visibility of what components are attached to each GameObject.

**What We Tested:**
- Import and compilation (clean, no errors)
- Assembly definition verification (editor-only via VHierarchy.asmdef)
- Active use in the Sandbox project hierarchy
- UI integration with Unity 6 editor

**Results:**
Clean compile, zero runtime footprint. Editor-only assembly definition confirms no impact on builds. Immediate quality-of-life improvement for hierarchy navigation. Component icons, row coloring, and active toggles are all functional out of the box.

**Pros:**
- Zero runtime footprint (editor-only asmdef)
- No configuration required - works immediately after import
- Component icons provide instant visual feedback
- Alternating row colors and separators improve readability
- Active/inactive toggle directly in hierarchy saves clicks
- Lightweight, no dependencies on other packages

**Cons:**
- None identified

**Integration Notes:**
No conflicts with any installed packages. Editor-only, so no interaction with runtime systems. Settings accessible via Tools > vHierarchy menu.

**Performance:**
Editor-only. No build size impact, no runtime cost. Negligible editor overhead.

**Verdict Rationale:**
Immediate, tangible workflow improvement with zero risk. Clean code, proper editor-only isolation. Promoted to default package for all TecVooDoo Unity projects.

**HOK Notes:**
Standard install for all projects including HOK. Improves hierarchy readability which is valuable for any project with moderate scene complexity.

---

#### ENTRY-004: vFolders 2

| Field | Value |
|-------|-------|
| **Asset** | vFolders 2 |
| **Source** | Asset Store |
| **Version** | 2.1.12 |
| **Category** | Tools |
| **Date Started** | 2026-02-06 |
| **Date Completed** | 2026-02-06 |
| **Verdict** | Approved |
| **HOK Applicable** | Yes |

**What It Does:**
Enhanced Unity Project window with folder colorization, custom icons, folder ordering, and visual organization features. Makes the Project panel more navigable at a glance by adding color and icon cues to folder structures.

**What We Tested:**
- Import and compilation (clean, no errors)
- Assembly definition verification (editor-only via VFolders.asmdef)
- Active use in the Sandbox project browser
- UI integration with Unity 6 editor

**Results:**
Clean compile, zero runtime footprint. Editor-only assembly definition confirmed. Folder coloring and custom icons work immediately. Significant improvement for projects with many top-level asset folders (Sandbox has 20+ asset folders).

**Pros:**
- Zero runtime footprint (editor-only asmdef)
- Folder colors make asset categories visually distinct
- Custom icons per folder aid rapid navigation
- No dependencies on other packages
- Works immediately after import

**Cons:**
- None identified

**Integration Notes:**
No conflicts with any installed packages. Editor-only, no runtime interaction. Settings accessible via Tools > vFolders menu.

**Performance:**
Editor-only. No build size impact, no runtime cost. Negligible editor overhead.

**Verdict Rationale:**
Immediate workflow improvement for project navigation. Especially valuable in asset-heavy projects. Clean isolation, zero risk. Promoted to default package for all TecVooDoo Unity projects.

**HOK Notes:**
Standard install for all projects including HOK. HOK has a growing asset folder structure that benefits from visual organization.

---

#### ENTRY-005: vFavorites 2

| Field | Value |
|-------|-------|
| **Asset** | vFavorites 2 |
| **Source** | Asset Store |
| **Version** | 2.0.14 |
| **Category** | Tools |
| **Date Started** | 2026-02-06 |
| **Date Completed** | 2026-02-06 |
| **Verdict** | Approved |
| **HOK Applicable** | Yes |

**What It Does:**
Favorites panel for Unity Editor that allows bookmarking frequently-used assets, scenes, folders, and GameObjects. Provides quick access to commonly-needed items without navigating deep folder structures. Supports multiple favorite groups/tabs for different workflows.

**What We Tested:**
- Import and compilation (clean, no errors)
- Assembly definition verification (editor-only via VFavorites.asmdef)
- Active use bookmarking frequently-accessed assets
- UI integration with Unity 6 editor

**Results:**
Clean compile, zero runtime footprint. Editor-only assembly definition confirmed. Bookmarking and quick-access features work as described. Multiple tabs allow organizing favorites by workflow (e.g., art assets vs scripts vs scenes).

**Pros:**
- Zero runtime footprint (editor-only asmdef)
- Eliminates repetitive folder navigation
- Multiple favorite tabs support different workflows
- Drag-and-drop bookmarking is intuitive
- No dependencies on other packages

**Cons:**
- None identified

**Integration Notes:**
No conflicts with any installed packages. Editor-only, no runtime interaction. Accessible from a dedicated panel in the editor.

**Performance:**
Editor-only. No build size impact, no runtime cost. Negligible editor overhead.

**Verdict Rationale:**
Solves a genuine productivity pain point - repeatedly navigating to the same assets. Particularly valuable as project size grows. Clean isolation, zero risk. Promoted to default package for all TecVooDoo Unity projects.

**HOK Notes:**
Standard install for all projects including HOK. HOK frequently accesses specific SO assets, prefabs, and scene files that benefit from quick bookmarking.

---

#### ENTRY-006: Ultimate Preview Window - Pro Edition

| Field | Value |
|-------|-------|
| **Asset** | Ultimate Preview Window - Pro Edition |
| **Source** | Asset Store (Voxel Labs) |
| **Version** | 1.3 |
| **Category** | Tools |
| **Date Started** | 2026-02-06 |
| **Date Completed** | 2026-02-06 |
| **Verdict** | Approved |
| **HOK Applicable** | Yes |

**What It Does:**
Enhanced asset preview window for Unity Editor. Provides larger, more detailed previews of 3D models, materials, textures, and prefabs directly in the editor without needing to place them in a scene. Supports orbit/zoom preview, multiple rendering modes, and side-by-side comparison.

**What We Tested:**
- Import and compilation (clean, no errors)
- Assembly definition verification (editor-only via VoxelLabs.UltimatePreview.Lib.asmdef)
- Active use previewing 3D models and prefabs from installed art packs
- UI integration with Unity 6 editor

**Results:**
Clean compile, zero runtime footprint. Editor-only assembly definition confirmed (references one GUID dependency, also editor-only). Preview quality is significantly better than Unity's built-in preview. Orbit and zoom controls are responsive. Useful for evaluating art assets without scene placement.

**Pros:**
- Zero runtime footprint (editor-only asmdef)
- Much better preview quality than Unity default
- Orbit/zoom for 3D model inspection
- Useful for art asset evaluation workflows
- No extra scene setup required to inspect assets

**Cons:**
- Has one assembly reference dependency (GUID:c98d06bf67fbf344893ff49cb62779e2) - still editor-only but slightly more coupled than the v-series tools

**Integration Notes:**
No conflicts with any installed packages. Editor-only with one internal assembly reference. Accessible via Window menu or context menu on assets.

**Performance:**
Editor-only. No build size impact, no runtime cost. Preview rendering uses editor GPU but is on-demand only.

**Verdict Rationale:**
Significant improvement over Unity's built-in preview for 3D asset inspection. Especially valuable during asset evaluation workflows (which is literally what Sandbox exists for). Clean editor isolation. Promoted to default package for all TecVooDoo Unity projects.

**HOK Notes:**
Standard install for all projects including HOK. Particularly useful for evaluating low-poly art assets, fishing props, and character models against HOK's visual style without scene placement.

---

#### ENTRY-007: Unity Utility Library (Git Amend)

| Field | Value |
|-------|-------|
| **Asset** | Unity Utility Library |
| **Source** | GitHub (adammyhre/Unity-Utils) |
| **Version** | 1.0.21 |
| **Category** | Tools |
| **Date Started** | 2026-02-06 |
| **Date Completed** | 2026-02-06 |
| **Verdict** | Conditional |
| **HOK Applicable** | Yes |

**What It Does:**
Collection of extension methods, helpers, attributes, singletons, and utilities for Unity. 41 C# files across 3 assemblies: runtime (UnityUtils), editor extensions (UnityUtils.Editor), and hotkeys (UnityUtils.Hotkeys). Installed as local package from `E:\Unity\DefaultUnityPackages\com.gitamend.unityutils`.

**What We Tested:**
Full code review of all runtime scripts (no runtime testing - evaluating code quality, usefulness, and alignment with TecVooDoo coding standards).

**Results:**
Mixed quality. Contains genuinely useful zero-alloc utilities alongside dead weight and patterns that contradict TecVooDoo coding standards.

**Useful (keep):**
- `WaitFor.Seconds()` - cached WaitForSeconds instances, eliminates repeated coroutine allocations
- `AllocCounter` - profiling tool for verifying zero-alloc code paths (uses Unity Recorder API)
- `Vector3.With()` / `Vector3.Add()` - immutable vector modification, very readable (`position.With(y: 0)`)
- `Vector3.InRangeOf()` - uses sqrMagnitude (no sqrt), correct approach
- `Vector3.RandomPointInAnnulus()` - proper uniform distribution with square root correction
- `Vector3.Quantize()` - grid snapping utility
- `GameObject.GetOrAdd<T>()` - standard get-or-add-component pattern
- `GameObject.OrNull<T>()` - correctly handles Unity's fake null for null-coalescing chains
- `Transform.DestroyChildren()` / `ForEveryChild()` - iterates in reverse (correct for destruction)
- `Transform.InRangeOf()` - combined distance + FOV check
- `RigidbodyExtensions` - has proper `UNITY_6000_0_OR_NEWER` guards for velocity -> linearVelocity rename
- Three singleton variants (Singleton, PersistentSingleton, RegulatorSingleton)
- `ListExtensions.Shuffle()` - Fisher-Yates implementation

**Questionable (dead weight or standards violations):**
- `FrameRateLimiter` - MonoBehaviour using old Input system (`Input.GetKey`). TecVooDoo uses new Input System. Dead code.
- `ListExtensions.IsNullOrEmpty()` - uses LINQ `.Any()` on `IList<T>` instead of `.Count == 0`. Comment admits GC overhead. Violates no-LINQ standard.
- `ListExtensions.Filter()` - reimplements `Where().ToList()`. Marginal value.
- `ReflectionExtensions` - 400 lines of heavy reflection (dynamic casting via `Expression.Lambda`, method rebasing). Runtime reflection is antithetical to performance-sensitive game code.
- `EnumerableExtensions.ForEach()` - encourages LINQ-style patterns in hot paths
- `StringExtensions` rich text helpers - allocate strings on every call. Fine for UI setup, bad if used per-frame.
- `RendererExtensions.EnableZWrite()` - accesses `.materials` (plural) which clones the material array. Known Unity allocation trap.
- `Helpers.cs` - only 2 methods, one is a wrapper for WaitFor. Thin.

**Code quality concerns:**
- `allowUnsafeCode: true` on runtime asmdef but no unsafe code found in reviewed files. Unnecessary flag.
- `WaitFor` class has no namespace (global namespace). Inconsistent with rest of library.
- Two GUID references in runtime asmdef create coupling to unknown packages.

**Pros:**
- Several genuinely useful zero-alloc utilities (WaitFor, AllocCounter, Vector3.With)
- Good Unity 6 awareness in RigidbodyExtensions
- Well-documented with XML comments
- Singleton implementations are reasonable
- Editor hotkeys assembly is properly isolated

**Cons:**
- Runtime assembly has dead weight that ships with builds (FrameRateLimiter, ReflectionExtensions)
- Some patterns violate TecVooDoo coding standards (LINQ in IsNullOrEmpty, .materials allocation)
- Unnecessary `allowUnsafeCode` flag
- Mixed namespace discipline (WaitFor in global, everything else in UnityUtils)
- The useful parts could be written from scratch in about 30 minutes

**Integration Notes:**
Installed as local package from `E:\Unity\DefaultUnityPackages\`. No dependencies in package.json. Runtime asmdef references 2 GUIDs. Has version defines for Unity.Mathematics and URP detection.

**Performance:**
Runtime assembly ships with builds. Most extension methods are lightweight (inline-able), but ReflectionExtensions and RendererExtensions contain allocation-heavy patterns. FrameRateLimiter has per-frame Input polling. WaitFor and AllocCounter are allocation-free by design.

**Verdict Rationale:**
Conditional. Contains useful utilities but also dead weight and standards violations. Two paths forward: (1) Keep as-is if the useful parts justify the baggage. (2) Cherry-pick the good utilities into a custom TecVooDoo utility library and drop this package. The condition is: determine whether any project code actually references UnityUtils, and if so, which parts.

**HOK Notes:**
HOK could benefit from WaitFor (if using coroutines), AllocCounter (for profiling), Vector3.With, GetOrAdd, OrNull, and the singleton patterns. However, HOK prefers UniTask async/await over coroutines, which reduces WaitFor's value. The singleton patterns may conflict with SOAP architecture patterns. Recommend auditing actual usage before deciding to keep or replace.

---

#### ENTRY-008: Hierarchy Designer

| Field | Value |
|-------|-------|
| **Asset** | Hierarchy Designer |
| **Source** | Asset Store |
| **Version** | 2.9.1 |
| **Category** | Tools |
| **Date Started** | 2026-02-06 |
| **Date Completed** | 2026-02-06 |
| **Verdict** | Rejected |
| **HOK Applicable** | No |

**What It Does:**
Enhanced hierarchy window with component icons, tag/layer display, tree branches (4 styles), folder system (6 icon styles), headers, separators, lock/visibility buttons, presets, and extensive visual customization (100+ configurable properties).

**What We Tested:**
Code review, asmdef analysis, head-to-head comparison against vHierarchy 2.

**Results:**
Rejected in favor of vHierarchy 2. Key issues: (1) No asmdef - all code dumps into Assembly-CSharp. (2) Has a Runtime folder with `HierarchyDesignerFolder.cs`, a MonoBehaviour that ships with builds for a feature that should be editor-only. (3) HD_Manager.cs alone is 99KB - massively over-engineered. (4) Ships with 8+ promotional PNG images for developer's other assets in Editor/Resources. (5) Default setting `DisableHierarchyDesignerDuringPlayMode = true` suggests performance concerns in play mode.

**Verdict Rationale:**
vHierarchy 2 does the same core job with proper editor-only asmdef isolation, zero runtime footprint, minimal configuration, and no bloat. Hierarchy Designer is a kitchen-sink approach with poor engineering practices.

---

#### ENTRY-009: Folder System (Gaskellgames)

| Field | Value |
|-------|-------|
| **Asset** | Folder System |
| **Source** | Asset Store (Gaskellgames) |
| **Version** | 1.4.6 |
| **Category** | Tools |
| **Date Started** | 2026-02-06 |
| **Date Completed** | 2026-02-06 |
| **Verdict** | Rejected |
| **HOK Applicable** | No |

**What It Does:**
Project folder organization and colorization tool.

**What We Tested:**
Asmdef analysis, comparison against vFolders 2.

**Results:**
Rejected in favor of vFolders 2. Has a runtime asmdef (`Gaskellgames.FolderSystem`) with empty `includePlatforms`, meaning it ships with builds. A folder organization tool has no business being in a runtime assembly. vFolders 2 does the same job with proper editor-only isolation.

**Verdict Rationale:**
Duplicate of vFolders 2 with worse engineering (runtime asmdef for an editor-only feature). Removed from project, tagged "dont use" in Asset Store.

---

#### ENTRY-010: Visual Console

| Field | Value |
|-------|-------|
| **Asset** | Visual Console |
| **Source** | Asset Store (Chris Game Dev) |
| **Version** | 1.2 |
| **Category** | Tools |
| **Date Started** | 2026-02-06 |
| **Date Completed** | 2026-02-06 |
| **Verdict** | Rejected |
| **HOK Applicable** | No |

**What It Does:**
Styled Unity Console replacement as an EditorWindow. Provides color-coded log output with named colors (140+ presets), log prefixes, and a visual debug API (`VisualDebug.Log()`). 5 files total.

**What We Tested:**
Full code review of all 5 files: VisualDebug.cs (static facade, 357 lines), VisualConsoleWindow.cs (1092 lines EditorWindow), VisualConsole_SO.cs (ScriptableObject config), VisualConsole_loader.cs (bootstrap MonoBehaviour), VisualConsole.asmdef.

**Results:**
Functional but poorly engineered. The asmdef is runtime (`"includePlatforms": []`) even though all meaningful code is wrapped in `#if UNITY_EDITOR`. This means the assembly ships with builds but contributes nothing. Thread safety is declared but broken: a `queueLock` object is created but never actually used in any lock statement, making the thread-safe queue promise hollow. Static fields have race conditions. The SO singleton has no null checks. The bootstrap loader is a MonoBehaviour that exists only to trigger editor initialization.

**Pros:**
- 140+ named colors is a nice touch for styled console output
- Simple API surface (VisualDebug.Log with color parameter)
- Small footprint (5 files)

**Cons:**
- Thread safety is broken: declares `queueLock` but never uses it in any lock statement
- Race conditions on static fields (concurrent access to log queue)
- Runtime asmdef with all code behind `#if UNITY_EDITOR` - empty assembly ships with builds
- SO singleton has no null checks - will throw NullReferenceException if config asset is missing
- Bootstrap MonoBehaviour (VisualConsole_loader) is unnecessary complexity
- Limited value over Unity's built-in console for the engineering cost

**Integration Notes:**
No asmdef conflicts. Runtime assembly ships with builds but contains no runtime code. Bootstrap loader MonoBehaviour exists in scenes.

**Performance:**
Empty runtime assembly ships with builds. Thread-unsafe static queue could corrupt under concurrent logging from multiple threads.

**Verdict Rationale:**
Rejected. Thread safety bugs, race conditions, and a runtime asmdef that ships an empty assembly. The styled console concept is nice but the implementation is not trustworthy. Unity's built-in console or UDebug Panel are both better options.

**HOK Notes:**
Not applicable. HOK already has In-Game Debug Console for runtime logging. UDebug Panel selected as the debug tool for this category.

---

#### ENTRY-011: Runtime Debugger Toolkit

| Field | Value |
|-------|-------|
| **Asset** | Runtime Debugger Toolkit |
| **Source** | Asset Store |
| **Version** | 1.0.0 |
| **Category** | Tools |
| **Date Started** | 2026-02-06 |
| **Date Completed** | 2026-02-06 |
| **Verdict** | Rejected |
| **HOK Applicable** | No |

**What It Does:**
In-game debug HUD with FPS graph, runtime console, collider visualizer, time-scale controller, and foldable menu system. 8 runtime scripts, no asmdef.

**What We Tested:**
Full code review of all 8 scripts after fixing the Cinemachine compile error (deleted Demo/Starter Assets folder which referenced old Cinemachine 2.x namespace).

**Results:**
Critical performance and build issues throughout.

**Critical issues:**
- `FPSGraph.cs`: Destroys and recreates 100+ GameObjects every 0.2 seconds to update the FPS graph. Uses `Instantiate`/`Destroy` in a loop instead of object pooling or UI manipulation. Catastrophic for GC pressure.
- `RuntimeColliderDebugger.cs`: Calls `FindObjectsOfType<Collider>()` every render frame to draw debug gizmos. O(n) scene scan every frame. Also contains `using UnityEditor;` without `#if UNITY_EDITOR` guard, meaning it will not compile for any build target.
- `InGameConsoleDisplay.cs`: Maintains an unbounded `fullLogHistory` list that never clears. Memory leak that grows indefinitely during play sessions.
- No asmdef: All scripts dump into Assembly-CSharp.

**Pros:**
- `DebuggerToolManager.cs` has clean dual input system support (old + new Input System with `#if` guards)
- Time-scale controller concept is useful for debugging
- Foldable menu UI approach is reasonable

**Cons:**
- FPS graph destroys/recreates 100+ GameObjects 5x per second
- Collider debugger scans entire scene every frame with FindObjectsOfType
- `using UnityEditor` in runtime script without guard - won't compile for builds
- Console has unbounded memory leak (fullLogHistory never cleared)
- No asmdef - everything in Assembly-CSharp
- Demo folder shipped with old Cinemachine 2.x references causing compile errors in Unity 6

**Integration Notes:**
Required deleting `Demo/Starter Assets` folder to fix Cinemachine compile error. No asmdef means all scripts are in Assembly-CSharp. The `using UnityEditor` in RuntimeColliderDebugger.cs will cause build failures.

**Performance:**
Catastrophic. FPS graph alone generates hundreds of allocations per second. Collider debugger does full scene scan every frame. Console leaks memory unboundedly. Ironically, a debug performance tool that itself destroys performance.

**Verdict Rationale:**
Rejected. A debug toolkit that tanks performance is worse than no debug toolkit. The `using UnityEditor` in a runtime script means it literally cannot build. Even fixing that, the FPS graph's destroy/recreate pattern and the collider debugger's per-frame FindObjectsOfType make this unusable in any real project. HOK already has In-Game Debug Console which does the runtime console part properly.

**HOK Notes:**
Not applicable. HOK has In-Game Debug Console for runtime debug logging. UDebug Panel covers the editor-side debug workflow.

---

#### ENTRY-012: Backbone Logger

| Field | Value |
|-------|-------|
| **Asset** | Backbone Logger |
| **Source** | Asset Store |
| **Version** | 1.0 |
| **Category** | Tools |
| **Date Started** | 2026-02-06 |
| **Date Completed** | 2026-02-06 |
| **Verdict** | Conditional |
| **HOK Applicable** | Maybe |

**What It Does:**
Category-based logging facade with `ENABLE_LOGGING` build-define stripping, color-coded categories, custom editor inspector, and import/merge support for sharing logging configs across projects. 5 files total.

**What We Tested:**
Full code review of all 5 files: Logger.cs (static facade with category filtering), LoggerManager.cs (MonoBehaviour bootstrap), LoggerConfig.cs (ScriptableObject with default categories), LoggerConfigEditor.cs (462-line custom inspector), TestLogger.cs (demo).

**Results:**
Cleanest architecture of the four debug tools reviewed. The `ENABLE_LOGGING` build define approach means all logging calls compile to nothing in release builds - zero runtime cost when disabled. Category filtering (AI, UI, Gameplay, Network, General) allows targeted debugging. The editor UI is well-implemented with grouping, category management, build define toggle, and config import/merge functionality.

**Pros:**
- `ENABLE_LOGGING` build define stripping - zero cost in release builds
- Category-based filtering is genuinely useful for complex projects
- Clean editor UI with category management, color coding, build define toggle
- Config import/merge for sharing logging setups across projects
- 5 default categories (AI, UI, Gameplay, Network, General) cover common needs
- Small footprint (5 files, well-organized)

**Cons:**
- No asmdef: All code dumps into Assembly-CSharp
- String allocations per log call (category name lookup, string formatting) when logging IS enabled
- Silent failure on missing categories: logging calls with unregistered categories silently do nothing
- No thread safety: static Logger class has no synchronization for concurrent access
- `LoggerManager` MonoBehaviour bootstrap pattern adds scene dependency
- Dictionary lookup per log call for category validation

**Integration Notes:**
No asmdef means it compiles into Assembly-CSharp. LoggerManager MonoBehaviour needs to exist in scene. LoggerConfig ScriptableObject needs to be created. Build define `ENABLE_LOGGING` must be toggled via editor UI or Player Settings.

**Performance:**
When `ENABLE_LOGGING` is not defined: zero cost (calls compile out entirely). When enabled: string allocations per call, Dictionary lookup for category validation, Debug.Log call overhead. Acceptable for development builds.

**Verdict Rationale:**
Conditional. The concept is solid - category-based logging with build stripping is exactly what complex projects need. The implementation is good enough to use but has engineering gaps (no asmdef, string allocations, no thread safety). Two paths: (1) Use as-is for development builds where the build stripping handles release performance. (2) Cherry-pick the pattern into a TecVooDoo utility library with proper asmdef isolation, pooled string formatting, and thread safety.

**HOK Notes:**
HOK could benefit from category-based logging (AI for fishing AI, UI for HUD, Gameplay for rod/reel mechanics, Network for future multiplayer). The `ENABLE_LOGGING` stripping aligns with performance-conscious development. However, the lack of asmdef and thread safety are concerns. Best used as a design reference rather than directly integrated. If a TecVooDoo logging utility is created, this pattern should inform the design.

---

#### ENTRY-013: UDebug Panel

| Field | Value |
|-------|-------|
| **Asset** | UDebug Panel |
| **Source** | Asset Store |
| **Version** | 1.3.3 |
| **Category** | Tools |
| **Date Started** | 2026-02-06 |
| **Date Completed** | 2026-02-06 |
| **Verdict** | Approved |
| **HOK Applicable** | Yes |

**What It Does:**
Professional in-game debug panel framework with 17 action types, 16 widget types, 9 popup types, extensible architecture, and full editor integration. 126 files across 3 properly separated assemblies: DebugPanel.Runtime, DebugPanel.Editor, DebugPanel.Examples.

**What We Tested:**
Full code review of all 126 files across runtime, editor, and example assemblies. Reviewed architecture, code quality, performance patterns, and alignment with TecVooDoo coding standards.

**Results:**
A+ code quality. This is the most professionally engineered asset reviewed in Sandbox to date. The architecture demonstrates senior-level C# practices throughout.

**Architecture highlights:**
- 14 logic classes with zero MonoBehaviour dependencies (pure C#)
- 9 data classes following SOAP-compatible immutable patterns
- Sealed singleton facade (`DebugPanel`) as single entry point
- Constructor dependency injection throughout
- Full separation of concerns: runtime logic, editor tooling, and examples each in their own asmdef
- 48 out of 101 runtime files use nullable reference types (`#nullable enable`)
- Frame slicing for reflection-heavy operations (no single-frame stalls)

**Code quality specifics:**
- No `var` keyword usage (explicit types throughout)
- No LINQ in runtime code paths
- No per-frame allocations in hot paths
- Sealed classes prevent unintended inheritance
- Dual input system support (old + new Input System with proper `#if` guards)
- Proper use of `readonly`, `const`, and immutable patterns

**Pros:**
- Proper asmdef separation (Runtime, Editor, Examples) - clean build isolation
- 126 files but zero bloat - every file has a clear purpose
- A+ code quality matching TecVooDoo coding standards
- Constructor DI instead of service locator or singleton abuse
- Nullable reference types demonstrate modern C# awareness
- Frame slicing for reflection prevents stalls
- Dual input system support without runtime cost for unused system
- Extensible widget/action/popup system for project-specific debug tools
- No per-frame allocations, no LINQ in runtime, no dead weight

**Cons:**
- Runtime assembly ships with builds (intentional - it IS a runtime debug tool)
- 126 files is a larger footprint than simpler alternatives
- Requires some setup to create custom debug panels (not zero-config)

**Integration Notes:**
Three asmdef assemblies: `DebugPanel.Runtime` (ships with builds), `DebugPanel.Editor` (editor-only), `DebugPanel.Examples` (can be deleted). No conflicts with installed packages. The runtime assembly is intentionally included in builds since this is a runtime debug panel. Can be stripped via build defines or conditional compilation for release builds.

**Performance:**
Runtime assembly is designed for zero per-frame allocation. Frame slicing prevents reflection stalls. Widget updates are event-driven, not polled. Memory footprint is proportional to active debug panels only. Negligible impact when debug panel is not visible.

**Verdict Rationale:**
Approved. The clear winner of the debug tools head-to-head. Professional architecture that matches or exceeds TecVooDoo coding standards. Proper asmdef separation, zero-alloc runtime paths, extensible design, and clean SOAP-compatible patterns. The runtime footprint is intentional and justified for an in-game debug tool. This is the kind of code you learn from, not just use.

**HOK Notes:**
Strong candidate for HOK integration. Custom debug panels could be created for: fishing rod physics tuning, fish AI behavior visualization, SOAP variable inspection, river/spline debugging, inventory state display. The extensible widget system means HOK-specific debug tools can be built on top of UDebug Panel's framework rather than from scratch. The SOAP-compatible architecture means it won't fight HOK's existing patterns.

---

#### ENTRY-014: Code Monkey Toolkit

| Field | Value |
|-------|-------|
| **Asset** | Code Monkey Toolkit |
| **Source** | Asset Store (Code Monkey) |
| **Version** | 1.0.2 |
| **Category** | Tools |
| **Date Started** | 2026-02-06 |
| **Date Completed** | 2026-02-06 |
| **Verdict** | Conditional |
| **HOK Applicable** | Maybe |

**What It Does:**
Massive tutorial/prototyping toolkit with ~153 C# scripts covering scheduling (FunctionTimer/Updater/Periodic), UI systems (tooltip, input dialog, cinematic bars, text popup, typewriter, health bar), game systems (HealthSystem, Key/Door, interaction), grid systems (XZ/XY/Hex generics), character controllers, mesh/draw utilities, and data helpers (WebRequests, FPSCounter, screenshot, save file format, random data).

**What We Tested:**
Full code review of all ~153 scripts across runtime and editor assemblies. Overlap analysis with Git Amend Unity Utility Library.

**Results:**
Zero `var` usage (passes standards). Zero LINQ in runtime (passes). But 99% legacy Input System, 14+ ad-hoc singletons creating hidden GameObjects, per-frame allocations in interaction systems (new List every frame), duplicated 384-line MeshUtils, phone-home telemetry to unitycodemonkey.com. Coroutine-only, zero UniTask awareness. Java-style getter methods instead of C# properties.

**Cherry-pick candidates for TecVooDoo utility:**
1. HealthSystem - Pure C# event-driven with MonoBehaviour wrapper + IGetHealthSystem interface. Generalizable to ResourceSystem.
2. GridSystem<T> / GridSystemXY<T> / GridHexXZ<T> - Three generic grid implementations including hex. Non-trivial to write from scratch.
3. GridPosition struct - IEquatable, HashCode.Combine, operator overloads.
4. TooltipUI - Screen-edge clamping math, Func<string> dynamic text.
5. SaveFileImage - Binary format combining JSON + PNG with header-based byte offsets.
6. LookAtCamera - Billboard with 4 modes, near production-ready.
7. TextWriter - Typewriter effect using invisible character trick for layout preservation.
8. ErrorDetectorUI - Runtime error display with dedup and clipboard.

**Overlap with Git Amend:** Minimal. Only singletons (Git Amend better) and some vector math in RandomData. Different problem spaces.

**Verdict Rationale:**
Conditional - cherry-pick only. The package as a whole is prototyping-grade (ad-hoc singletons, legacy Input, coroutine-only, per-frame allocations). But it contains several non-trivial algorithms and systems worth extracting: grid math, hex grid, health system, tooltip edge detection, save file format, billboard modes, typewriter invisible-character technique. All cherry-picked items need refactoring (remove singletons, UniTask, new Input System, properties over getters).

**HOK Notes:**
HealthSystem pattern is directly relevant (fishing rod durability, character health). Grid systems could apply to future inventory or map features. LookAtCamera for world-space UI (fish name tags, health bars). TextWriter for NPC dialog. None should be used as-is - all need TecVooDoo refactoring.

---

#### ENTRY-015: Fullscreen Editor

| Field | Value |
|-------|-------|
| **Asset** | Fullscreen Editor |
| **Source** | Asset Store (MibDev) |
| **Version** | 2.2.10 |
| **Category** | Tools |
| **Date Started** | 2026-02-06 |
| **Date Completed** | 2026-02-06 |
| **Verdict** | Approved |
| **HOK Applicable** | Yes |

**What It Does:**
True fullscreen for any editor window (Game View, Scene View, any focused view). Multi-monitor support with mosaic mode (display game across 2-8 screens). Fullscreen-on-play replacing Unity's Maximize-on-Play. Placeholder window showing live preview in original dock position. Optional Scene View rendering suppression for performance.

**What We Tested:**
Full code review of all 30 C# scripts. Assembly definition analysis. Platform compatibility review.

**Results:**
Mature, well-engineered editor tool (v2.2.10). Correct editor-only asmdef with justified `allowUnsafeCode` (method hooking for SceneView suppression). Callback-driven architecture with decoupled feature modules. Cross-platform (Windows full, macOS Retina, Linux X11). `[Conditional("FULLSCREEN_DEBUG")]` for zero-cost debug logging. Zero dependencies. Active maintenance spanning Unity 2017 through Unity 6.1+ with proper preprocessor guards. References specific GitHub issues in code comments.

**Pros:**
- Zero runtime footprint (editor-only asmdef)
- Zero dependencies, completely self-contained
- Mature and actively maintained across many Unity versions
- Clean callback architecture with decoupled feature modules
- Multi-monitor and mosaic support
- Proper unsafe code justification (SceneView method patching)
- Compact: only 30 C# scripts, no bloat

**Cons:**
- Minor bug: missing `throw` on Exception in BeforeOpening (backstopped by other checks)
- Minor bug: `wantsToQuit +=` in OnDisable should be `-=` (benign, callback is idempotent)
- Dead code: Cmd.cs has zero callers
- Heavy reflection on Unity internals (inherent to problem domain, well-mitigated)

**Verdict Rationale:**
Approved. Professional editor tool with exemplary engineering for its domain. Two minor bugs are non-blocking. Standalone keeper - install and use as-is.

**HOK Notes:**
Standard install for all projects including HOK. Fullscreen Game View is essential for testing gameplay feel. Mosaic mode useful if multi-monitor testing is needed.

---

#### ENTRY-016: Scripts Vault - Free: A Time Saver Pack

| Field | Value |
|-------|-------|
| **Asset** | Scripts Vault - Free: A Time Saver Pack |
| **Source** | Asset Store (ProjektSumperk) |
| **Version** | 1.0 |
| **Category** | Tools |
| **Date Started** | 2026-02-06 |
| **Date Completed** | 2026-02-06 |
| **Verdict** | Rejected |
| **HOK Applicable** | No |

**What It Does:**
Collection of 27 utility modules covering raycasting, passwords, Android permissions, scene loading, cameras (controller/shake/position), timers, encrypted prefs, event bus, file I/O, fluent transforms, FPS counter, input validation, internet checks, IP address, JSON/text read-write, resource loading, mobile swipe, object pool, photo/video galleries, pinch zoom, screenshots, slow motion, stopwatch, and UI drag/snap.

**What We Tested:**
Full code review of all 50 C# files. Security analysis of EncryptedPlayerPrefs. Thread safety analysis of Screenshots. Platform compatibility check.

**Results:**
Fundamental design flaws throughout. No asmdef (all code dumps into Assembly-CSharp). EncryptedPlayerPrefs stores its AES key in plaintext in the same PlayerPrefs file as the encrypted data, with a zero IV making identical plaintexts produce identical ciphertexts. InternetConnectionChecker does synchronous HTTP on the main thread. Screenshots spawns raw Threads with no synchronization. FluentTransform has a Lerp math bug (uses current position as start, causing exponential decay instead of intended easing). FPSCounter uses System.Diagnostics.Process which won't compile on mobile/console/WebGL.

**Cherry-pick candidates (all need rewrites):**
1. CameraShake (Perlin noise algorithm), 2. LoadFromResource (cached Resources.Load<T>), 3. DragAndSnapUI (snap-to-nearest with callback), 4. SlowMotion concept (TimeScale transition with fixedDeltaTime correction), 5. SwipeManager algorithm (DPI-aware directional detection)

**Verdict Rationale:**
Rejected. Security flaws, thread safety issues, main-thread blocking, math bugs, no asmdef, and platform compatibility failures are not surface-level problems - they are design flaws requiring architectural rework. The 5 cherry-pick candidates represent total extractable value, and all need significant rewrites.

**HOK Notes:**
Not applicable as a package. CameraShake algorithm and SlowMotion fixedDeltaTime correction pattern may be worth cherry-picking into TecVooDoo utility.

---

#### ENTRY-017: RNGNeeds - Probability Distribution

| Field | Value |
|-------|-------|
| **Asset** | RNGNeeds - Probability Distribution |
| **Source** | Asset Store (Starphase Lab) |
| **Version** | 1.0.0 |
| **Category** | Tools |
| **Date Started** | 2026-02-06 |
| **Date Completed** | 2026-02-06 |
| **Verdict** | Conditional |
| **HOK Applicable** | Yes |

**What It Does:**
Generic weighted probability system with `ProbabilityList<T>` for any type. 5 selection methods (Linear, LinearBurst, CumulativeProbability, CumulativeProbabilityBurst, Random). Repeat prevention (Spread/Repick/Shuffle). Depletable items (limited stock). Probability influence system via `IProbabilityInfluenceProvider`. Lock/unlock, enable/disable per item. Pick history with pooling. Custom seed providers. Visual probability bar editor in Inspector.

**What We Tested:**
Full code review of 29 runtime, 35 editor, and 41 sample C# files. Hot-path allocation analysis. Burst compilation verification. HOK applicability mapping.

**Results:**
Well-architected probability engine. The selection hot path (the actual pick) is clean: NativeArray/NativeList, manual loops, Unity.Mathematics.Random, proper Dispose. Burst-compiled variants for high-volume picks. Object pooling on PickHistory. 11 LINQ calls exist in ProbabilityList.cs but are confined to configuration-time operations (add/remove/normalize), NOT the selection path. 219 uses of `var` (author's style). Depends on `com.starphaselab.core` (tiny 7-file utility), Unity.Collections, Unity.Mathematics, Unity.Burst.

**HOK applicability is near-perfect:**
- Fish rarity tiers: `ProbabilityList<FishData>` with weights
- Loot tables per zone: `PLCollection<Item>` nested lists
- Bait modifiers: `IProbabilityInfluenceProvider`
- Depleting fishing spots: IsDepletable + Units/MaxUnits
- No repeat catches: `PreventRepeatMethod.Spread`
- Testing/replays: Custom seed providers

**Pros:**
- Proper asmdef separation (Runtime, Editor, Samples)
- Selection hot path is zero-alloc with Burst compilation
- Extensible via ISelectionMethod, IProbabilityInfluenceProvider, ISeedProvider
- Visual Inspector editor with probability bars
- Object pooling on PickHistory entries
- Comprehensive samples including TreasureChest (near-1:1 template for fishing loot)

**Cons:**
- 11 LINQ calls in ProbabilityList.cs (config-time, not hot path, but still allocates)
- 219 uses of `var` (third-party style, don't modify)
- `using UnityEditor` without `#if UNITY_EDITOR` guard in RNGNeedsCore.cs (compiles fine but sloppy)
- Dead code stubs (migration placeholder, commented-out methods)
- PickHistory uses O(n^2) insert-at-0 pattern

**Verdict Rationale:**
Conditional. Approved for use as a black-box dependency with caveats: (1) Don't modify package source. (2) Don't call NormalizeProbabilities/SetItemWeight per-frame. (3) Use Burst selection methods for batch picks. (4) Design influence providers as ScriptableObjects using IProbabilityInfluenceProvider. The `var` usage is the package author's style and doesn't contaminate your codebase since you consume it, not maintain it.

**HOK Notes:**
Strong candidate for HOK's core fishing/loot mechanics. The TreasureChest sample is almost a template for a fishing loot system. IProbabilityInfluenceProvider maps directly to bait effectiveness and time-of-day effects. Depletable items map to fishing spot depletion. Custom seed providers enable deterministic testing. Should be one of the first packages integrated when HOK's loot system is built.

---

#### ENTRY-018: Scriptable Sheets

| Field | Value |
|-------|-------|
| **Asset** | Scriptable Sheets |
| **Source** | Asset Store (Luna Wolf Studios) |
| **Version** | 1.8.0 |
| **Category** | Tools |
| **Date Started** | 2026-02-06 |
| **Date Completed** | 2026-02-06 |
| **Verdict** | Approved |
| **HOK Applicable** | Yes |

**What It Does:**
Spreadsheet-like editor window for viewing and editing ScriptableObjects, Prefabs, and Components in a table format. CRUD operations on SOs. CSV/TSV/JSON import/export. Google Sheets import (no API key needed - uses public CSV endpoint). Smart paste from Excel/Google Sheets. Advanced search filters with property-based queries. Pagination, sorting, column visibility, virtualization, keyboard navigation.

**What We Tested:**
Full code review of 74 editor, 14 test, and 61 sample C# files. Assembly definition analysis. Google Sheets integration review. Odin Inspector compatibility check.

**Results:**
Professional editor extension with exemplary assembly structure. All 11 asmdef files are editor-only. Zero runtime footprint. 14-file test suite. Broad Unity version support (2020.3 through Unity 6). Lightweight Google Sheets integration using HTTP GET to public CSV endpoint (no OAuth, no API keys). Session persistence across domain reloads. Only dependency is `com.unity.nuget.newtonsoft-json`.

**Pros:**
- 11 fine-grained editor-only assemblies with proper platform targeting
- Zero runtime impact - completely stripped from builds
- Comprehensive test suite
- Google Sheets import without API credentials
- Rich data management features (import/export, smart paste, advanced search)
- Session persistence across editor restarts
- 8 sample projects demonstrating diverse use cases

**Cons:**
- 1,160-line monolithic OnGUI method (maintainability concern)
- LINQ in render loop (editor tool, not gameplay)
- Uses `var` throughout (third-party style)
- No Odin integration (Odin non-serialized fields invisible in table)
- Minor double-precision bug in float field drawing
- Swallowed exceptions in search filter parsing

**Verdict Rationale:**
Approved. Well-engineered editor tool with exemplary assembly structure and zero runtime impact. The monolithic OnGUI and LINQ in render loop are acceptable trade-offs for editor tooling. Google Sheets integration is clever and lightweight. Standalone keeper.

**HOK Notes:**
Excellent for managing HOK's data-heavy ScriptableObjects: fish definitions, loot tables, rod/reel stats, bait properties, NPC dialog. Spreadsheet view enables rapid bulk editing that Unity's default Inspector doesn't support well. Google Sheets import allows designers to work in familiar tools and import directly.

---

#### ENTRY-019: Improved Timers (Git Amend)

| Field | Value |
|-------|-------|
| **Asset** | Improved Timers |
| **Source** | GitHub (adammyhre/Improved-Timers) |
| **Version** | 1.0.4 |
| **Category** | Tools |
| **Date Started** | 2026-02-06 |
| **Date Completed** | 2026-02-06 |
| **Verdict** | Conditional |
| **HOK Applicable** | Yes |

**What It Does:**
Timer system hooking directly into Unity's PlayerLoop. Four timer types: CountdownTimer (counts down, auto-stops at zero), FrequencyTimer (fires N times per second), IntervalTimer (countdown with periodic events), StopwatchTimer (counts up for duration measurement). IDisposable lifecycle management. TimerManager with sweep-list pattern for safe iteration.

**What We Tested:**
Full code review of all 8 runtime scripts. PlayerLoop integration analysis. Architecture assessment for TecVooDoo utility absorption.

**Results:**
Solid architecture. PlayerLoop injection eliminates MonoBehaviour Update overhead. Sweep list pattern in TimerManager prevents modification-during-iteration bugs. IDisposable with GC.SuppressFinalize for proper cleanup. Proper namespace (`ImprovedTimers`). No LINQ, no per-frame allocations in Tick paths.

**Pros:**
- PlayerLoop injection (zero MonoBehaviour overhead)
- IDisposable pattern for cleanup
- Sweep list pattern prevents modification-during-iteration
- Clean abstract base class with Start/Stop/Pause/Resume/Reset
- Proper namespace discipline
- No LINQ, no allocations in Tick paths

**Cons:**
- Uses `var` in TimerManager and PlayerLoopUtils
- `using UnityEditor` in TimerBootstrapper.cs without `#if UNITY_EDITOR` guard on the using statement
- `Action OnTimerStart` is a public field, not an event (callers can overwrite entire invocation list)
- No thread safety on TimerManager statics
- `timers.Remove(timer)` is O(n) - fine for small counts but concern at scale
- Runtime asmdef with empty includePlatforms (ships with builds - intentional)

**Verdict Rationale:**
Conditional - TecVooDoo utility absorption candidate. The timer architecture and PlayerLoop integration are worth keeping. Fix `var` usage, make Actions into events, consider HashSet or indexed removal for DeregisterTimer, add `#if UNITY_EDITOR` guard on the using statement.

**HOK Notes:**
Directly useful for HOK: fishing timers (cast duration, reel cooldown), buff/debuff timers, UI countdown displays, spawn intervals. The FrequencyTimer maps well to tick-based systems (fish AI updates). IntervalTimer suits periodic checks (fishing spot regeneration). All timer types should be absorbed into TecVooDoo utility library with fixes applied.

---

#### ENTRY-020: Wingman

| Field | Value |
|-------|-------|
| **Asset** | Wingman - Your Inspector's Best Friend |
| **Source** | Asset Store |
| **Version** | 1.2.3 |
| **Category** | Tools |
| **Date Started** | 2026-02-07 |
| **Date Completed** | 2026-02-07 |
| **Verdict** | Approved - Default Package |
| **HOK Applicable** | Yes |

**What It Does:**
Component mini-map / quick-navigation bar added to every Inspector window. Toggle buttons per component for show/hide isolation, cross-component fuzzy property search, component copy/paste via SerializedObject, drag-to-hierarchy (create new GO or copy to existing), context menu (copy, edit script, remove). Multi-Inspector and locked Inspector support. 7 C# scripts, 22 files total.

**What We Tested:**
Full code review of all 7 scripts. Assembly definition analysis. Odin Inspector overlap assessment.

**Results:**
Fills a genuine gap Odin does not cover. Odin handles how components look (drawers, attributes, serialization). Wingman handles navigating between components on complex GameObjects. Zero functional overlap. Zero `var` usage. All code is `#if UNITY_EDITOR` guarded - functionally editor-only.

**Pros:**
- Zero `var` usage (passes TecVooDoo standards)
- Complementary to Odin, not competing
- Component isolation toggles are genuinely useful for 10+ component GameObjects
- Cross-component fuzzy property search with inline editing
- Lightweight (7 scripts, 1,888 lines total)
- No external dependencies
- Proper Undo support for all destructive operations
- Unity 6 version-aware code

**Cons:**
- asmdef targets all platforms but code is `#if UNITY_EDITOR` (functionally correct but architecturally sloppy)
- Single LINQ call (`FirstOrDefault`) in `WingmanContainer.cs` - fires rarely
- Empty catch block in `InitAsset()` with infinite retry and no max count
- Fragile reflection on Unity internal `m_AllInspectors` field - could break on Unity updates
- Dead code: `CheckForComponentListUpdate()` defined but never called, `UpdateModifiers()` defined but logic duplicated inline
- Multiple typos: `InspectorScrolllassName`, `skipedCount`, `CenterRectHorizonally`
- `OnSettingsChanged` is public `Action` not `event`

**Verdict Rationale:**
Conditional. Genuinely useful for complex GameObjects (Sandbox has many multi-component prefabs). The asmdef issue is cosmetic. The fragile reflection is the main risk - monitor after Unity updates. The empty catch block could cause editor hangs in theory but hasn't in practice. Approve for continued use with awareness of the reflection fragility.

**HOK Notes:**
Useful for HOK prefabs with many components (fishing rod = physics, animation, input, FX, audio components). Component isolation speeds up Inspector work on complex GameObjects.

---

#### ENTRY-021: Init(args)

| Field | Value |
|-------|-------|
| **Asset** | Init(args) |
| **Source** | Asset Store (Sisus) |
| **Version** | 1.5.6 |
| **Category** | Tools |
| **Date Started** | 2026-02-07 |
| **Date Completed** | 2026-02-07 |
| **Verdict** | Rejected |
| **HOK Applicable** | No |

**What It Does:**
Dependency injection framework for Unity's MonoBehaviour/ScriptableObject lifecycle. Provides `MonoBehaviour<T1..T12>` generic base classes that accept typed arguments via `Init()` instead of `Awake()` + `GetComponent`. `[Service]` attribute for singleton registration. Wrapper system for POCO lifecycle forwarding. 405 shipped scripts across 5 assemblies + Sisus Shared companion (17 scripts).

**What We Tested:**
Full code review of core runtime, service system, wrapper system, and editor assemblies. SOAP/Odin/UniTask overlap analysis. Performance assessment.

**Results:**
Architecturally competes with SOAP. Both solve dependency management for MonoBehaviours but with fundamentally different philosophies: SOAP uses ScriptableObject channels (event-driven decoupling), Init(args) uses constructor-injection-style initialization. Using both means every new component requires a decision about which DI system to use. 3,198 `var` usages, 195 LINQ calls in runtime code, `async void Awake()` anti-pattern, `Unity.InternalAPIEditorBridgeDev.004` naming hack for internal API access.

**Verdict Rationale:**
Rejected. SOAP conflict is the primary disqualifier. Between Odin (`[Required]` for null guards), SOAP (SO variable decoupling), and UniTask (async patterns), everything Init(args) does is already covered. The 3,198 `var` usages alone make it incompatible with coding standards. The InternalAPIEditorBridge hack is fragile and could break on any Unity update.

**HOK Notes:**
Not applicable. HOK uses SOAP architecture. Adopting Init(args) would create a second competing DI system. Remove `com.sisus.init-args` and `com.sisus.shared` from Packages folder.

---

#### ENTRY-022: DevTrails

| Field | Value |
|-------|-------|
| **Asset** | DevTrails - Developer Statistics Made Easy |
| **Source** | Asset Store (Tiny Giant Studio) |
| **Version** | 1.7.x |
| **Category** | Tools |
| **Date Started** | 2026-02-07 |
| **Date Completed** | 2026-02-07 |
| **Verdict** | Conditional |
| **HOK Applicable** | Maybe |

**What It Does:**
Editor-only developer statistics dashboard tracking time in editor (total, focused, active), play mode entries/duration, scene saves/opens, undo/redo count, compilation count/time/domain reload time, console logs (by severity, split by editor vs play mode), build stats (time, success/fail, warnings, errors), and crash detection. Three scopes: Today (resets daily), Project (cumulative), Global (cross-project). Weekly/monthly bar graphs. Usage goals with configurable targets.

**What We Tested:**
Full code review of 18 DevTrails scripts plus ~12 Common library scripts. Bug analysis. Performance assessment.

**Results:**
Properly editor-only (both asmdefs `includePlatforms: ["Editor"]`). Zero runtime code. Passive tracking requires no configuration. Confirmed bugs: BuildRecord.cs assigns `totalErrors` to both warnings AND errors (build warning stats always wrong), play mode time tracking inflates duration to full editor uptime (sets `_timeOfEnteringPlaymode = 0` before using it). Massive code duplication (SmallStringTime copy-pasted into 5 classes, SaveToDisk into 4, acknowledged with "Will fix it later" comments). 32 `var` usages.

**Pros:**
- Zero runtime footprint (proper editor-only asmdefs)
- Passive operation, no configuration needed
- Time tracking and build stats are genuinely useful for solo dev productivity
- ConcurrentQueue for log batching is well-designed
- Daily/weekly/monthly graphs provide usage trends

**Cons:**
- BuildRecord.cs warning bug (warnings = errors always)
- Play mode time tracking bug (inflated duration)
- Massive code duplication across 5+ files
- 32 `var` usages
- Registers 8-10 editor event listeners on every domain reload even if window is never opened
- Thread.Sleep(100) in file save retries blocks main thread
- Dead code: UserStats_Loader.cs entirely commented out, empty Save() methods

**Verdict Rationale:**
Conditional. Safe to keep as a passive editor-only tool. The bugs only affect accuracy of its own displayed statistics, not your project. If you find the time-tracking useful, keep it. If you check it fewer than once a week, the domain-reload overhead is not worth it.

**HOK Notes:**
Optional. Same verdict applies to HOK if installed. Build time tracking could be useful as HOK grows in complexity. No risk to keep installed.

---

#### ENTRY-023: Binding System 2

| Field | Value |
|-------|-------|
| **Asset** | Binding System 2 |
| **Source** | Asset Store (Gheorghii Postica) |
| **Version** | 2.5.2 |
| **Category** | Tools |
| **Date Started** | 2026-02-07 |
| **Date Completed** | 2026-02-07 |
| **Verdict** | Rejected |
| **HOK Applicable** | No |

**What It Does:**
General-purpose property/data binding system. `Bind<T>` connects any serialized field to any property/field/method on another object via inspector-driven path strings. Modifier pipelines (math, PID controllers, clamping, tweening, color ops). Type converters. BindingEngine hooks into PlayerLoop for polling-based refresh. ProxyBindings as external assets. Material property binding. Fast reflection via raw pointer offsets (native DLL). 290 C# files, 12 assemblies, good Odin integration (8-file extension).

**What We Tested:**
Full code review of core runtime, accessor factory, binding engine, modifier/converter systems, Odin extension. SOAP overlap analysis. Performance assessment.

**Results:**
Technically impressive (pointer-based field access is near-native speed, good Odin integration) but architecturally conflicts with SOAP. Both solve the same core problem (connecting data with change notification) but with fundamentally different models: SOAP is event-driven (zero cost for unchanged values), Binding System polls every bind every frame. 850+ `var` usages, LINQ in 17 runtime files. Confirmed bug: `PauseBind` sets `IsPaused = false` instead of `true`. Black-box native DLL (`PointerLibStandard.dll`) with no source code.

**Verdict Rationale:**
Rejected. SOAP overlap is the dealbreaker. Adding a polling-based binding system alongside SOAP's event-driven architecture creates two parallel data flow mechanisms, debugging complexity, and unnecessary per-frame overhead. The unique features (modifier pipelines, material binding) can be achieved more simply with DOTween + direct Material.SetFloat() calls. 850+ `var` usages make the codebase permanently incompatible with coding standards. The black-box native DLL adds crash risk with no diagnostic capability.

**HOK Notes:**
Not applicable. HOK uses SOAP for all data binding and observation. Remove `com.postica.binding-system` from Packages folder.

---

#### ENTRY-024: Prefab World Builder

| Field | Value |
|-------|-------|
| **Asset** | Prefab World Builder |
| **Source** | Asset Store (PluginMaster / Omar Duarte) |
| **Version** | 4.9 |
| **Category** | Tools |
| **Date Started** | 2026-02-07 |
| **Date Completed** | 2026-02-07 |
| **Verdict** | Conditional |
| **HOK Applicable** | Yes |

**What It Does:**
Comprehensive level design / prefab placement editor tool with 14 interactive tools: Pin (single placement), Brush (scatter paint), Gravity (drop to surface), Line (bezier paths), Shape (circle/polygon), Tiling (grid patterns), Floor (modular floors), Wall (modular walls with corners), Eraser, Replacer, Selection (box select + transform), Circle Select, Extrude, Mirror. Multi-palette system with drag-and-drop prefab organization. Full terrain integration (flattening, tree clearing, slope filtering). Profile system for saving/loading tool presets. Unity 2021.2+ Scene View overlay toolbar.

**What We Tested:**
Full code review of all 56 C# scripts. Assembly definition analysis. Runtime footprint assessment. Head-to-head comparison with Procedural Generation Grid.

**Results:**
Entirely editor-only (all code under `Editor/` folder). Zero runtime footprint - placed objects are standard Unity GameObjects with no dependency on PWB. 14 well-featured tools covering the full spectrum of manual level design: single placement, scatter painting, path placement, modular building, and modification/selection. Embedded BoundsOctree (BSD, properly attributed) for spatial queries. Long maintenance history (v2.8 through v4.9 migration code). Unity theme support (light/dark icons).

Code quality is typical of mature Asset Store tools: functional but not pristine. PWBIO God Object split across 16 partial files (~15K lines combined). 3,549 `var` usages, 721 LINQ calls (editor-only so no runtime impact). Pervasive typos in public API (`RepainWindow` called 54 times, `Toogle`, `Circunference`). No asmdef files (56 scripts in default editor assembly).

**Pros:**
- Zero runtime footprint (entirely in Editor/ folder)
- 14 genuinely deep placement tools covering all manual level design needs
- Output is clean standard Unity GameObjects (no PWB dependency at runtime)
- Full Unity Undo integration for all operations
- Terrain integration (surface alignment, flattening, tree/detail clearing)
- Multi-palette with custom thumbnails and folder filtering
- Profile system for saving tool presets
- Zero external dependencies
- Long maintenance history, cross-version support back to Unity 2019
- Removable at any time without breaking builds

**Cons:**
- No asmdef (56 files in default editor assembly, increases compilation time)
- 3,549 `var` usages (black box - never modify source)
- 721 LINQ calls including allocation-heavy property getters (editor-only, so no gameplay impact)
- PWBIO God Object across 16 partial files (~15K lines)
- Pervasive typos in public API (entrenched, cannot fix)
- Flat `PluginMaster` namespace could conflict with other PluginMaster products
- `PWBData.txt` settings file is not version-control friendly

**Integration Notes:**
No conflicts with installed packages. Entirely editor-only by folder convention. Outputs standard scene data. All PluginMaster code lives under `Assets/PluginMaster/` - clean removal path. Shared `Common/` and `CommonPaint/` folders may be used by other PluginMaster products if installed.

**Performance:**
Editor-only. No build size impact, no runtime cost. 56 scripts without asmdef add to editor compilation time. LINQ-heavy property getters (`.ToArray()` on every access) may cause minor editor hitching during intensive Scene View painting sessions on large scenes.

**Verdict Rationale:**
Conditional. Use as a black box editor tool - never modify source. The 14-tool suite is genuinely comprehensive for hand-crafted level design. Zero runtime impact means zero risk to builds. The code quality issues (God Object, typos, LINQ, var) are the author's problem, not yours, as long as you never need to touch the source. The tool's output is clean Unity scene data that survives PWB removal.

**HOK Notes:**
Strong candidate for HOK environment building. HOK's themed environments (River Styx shores, fishing spots, Kharon's dock, underwater areas) need hand-crafted level design, not procedural generation. PWB's brush tools for scattering props (rocks, vegetation, fishing equipment), line tools for path decoration, and tiling tools for terrain features map directly to HOK's needs. The gravity tool is particularly useful for placing objects on uneven terrain (river banks, rocky shores).

---

#### ENTRY-025: UniTask (Cysharp)

| Field | Value |
|-------|-------|
| **Asset** | UniTask |
| **Source** | GitHub (Cysharp / Yoshifumi Kawai) |
| **Version** | 2.5.10 |
| **Category** | Tools |
| **Date Started** | 2026-02-07 |
| **Date Completed** | 2026-02-07 |
| **Verdict** | Approved - Default |
| **HOK Applicable** | Yes |

**What It Does:**
Zero-allocation async/await integration for Unity. Replaces Task/ValueTask with a custom `UniTask` struct that hooks directly into Unity's PlayerLoop system. Provides async versions of all Unity lifecycle events, AsyncOperation wrappers, cancellation token support, async LINQ operators, and MonoBehaviour trigger extensions. The standard for async programming in Unity projects.

**What We Tested:**
Full code review for TecVooDoo absorption feasibility. Architecture analysis of PlayerLoop integration, AsyncMethodBuilder compiler hooks, assembly structure, and dependency chain. Assessed whether core async/await support could be extracted into TecVooDoo utility library.

**Results:**
70,163 lines of code across 153 files and 6 assemblies. Deep PlayerLoop integration with 14+ custom loop stages and 56 timing variants. Uses C# compiler's `[AsyncMethodBuilder]` attribute for custom async state machines. Pure managed C# - zero unsafe code, zero native DLLs, zero Burst. MIT licensed.

Absorption assessment: technically possible but practically foolish. The PlayerLoop integration is the heartbeat of the entire system - every `await` triggers PlayerLoop scheduling. Extracting even the core struct requires the method builder, which requires the scheduling, which requires PlayerLoop hooks. The 70K LOC includes aggressive inlining, task pooling, and generated trigger code that would be weeks of review/test work to merge, and you'd own all future maintenance when Unity updates break PlayerLoop (happens every few releases). Cysharp maintains this for free. A typical project uses 10-15% of UniTask's surface area but depends on the full infrastructure underneath.

**Pros:**
- Zero-allocation async/await (struct-based, no heap pressure)
- Deep Unity PlayerLoop integration (14+ timing points)
- 6 clean assemblies with proper separation (core, LINQ, editor, optional integrations)
- Zero external dependencies
- MIT license, actively maintained, battle-tested in thousands of shipped titles
- Async wrappers for all Unity AsyncOperations, uGUI, MonoBehaviour lifecycle
- Full async LINQ operator library (73 operators)
- Production-grade task pooling and state machine caching

**Cons:**
- Large codebase (70K LOC) for what feels like a utility - but every line serves the scheduling/pooling infrastructure
- No asmdef customization needed but ships runtime code (by design - it IS the runtime async system)
- T4-generated trigger code means maintenance burden if absorbed (not relevant as black box)

**Integration Notes:**
Already a default package across all TecVooDoo projects. Installed as local package at `E:\Unity\DefaultUnityPackages\com.cysharp.unitask`. Zero conflicts with any other installed package. Referenced by project code via `using Cysharp.Threading.Tasks`.

**Verdict Rationale:**
Approved as permanent standalone default package. Absorption into TecVooDoo utility rejected - same reasoning as RNGNeeds (Lesson #6). The package is too deeply optimized, too tightly integrated with Unity internals, and too well-maintained by its author to justify the maintenance burden of merging. If TecVooDoo-flavored convenience methods are needed, create a thin wrapper namespace that calls UniTask underneath rather than absorbing the source.

**HOK Notes:**
Core infrastructure for all async operations in HOK. Fishing cast/reel mechanics, save/load, scene transitions, network calls, and UI animations all use UniTask. Non-negotiable dependency.

---

#### ENTRY-026: UModeler X Plus

| Field | Value |
|-------|-------|
| **Asset** | UModeler X Plus |
| **Source** | Asset Store (Tripolygon) |
| **Version** | 1.0.55+plus.f3 (Hub 1.1.12) |
| **Category** | Tools |
| **Date Started** | 2026-02-07 |
| **Date Completed** | 2026-02-07 |
| **Verdict** | Approved - Default 3D |
| **HOK Applicable** | Yes |

**What It Does:**
Complete in-editor 3D modeling suite. Full polygon modeling pipeline including: 11 primitive shapes (box, cylinder, sphere, icosphere, torus, pipe, capsule, cone, room, stair, spiral stair), 7 drawing tools (polyline, arc, rectangle, disk, text, etc.), 15 modeling tools (knife, bevel, bridge, subdivide, loop cut, inset, arrays, mirror, etc.), 8 removal tools (detach, eraser, target weld, collapse, merge, etc.), 6 deform brushes (relax, smooth, standard, flatten, move, pinch), 9 modifiers (bend, subdivide, shell, mirror, FFD, push, decimate, arrays), full UV editor with auto/quad/boundary unwrapping, rigging mode with weight painting, painting mode with layers and brushes, curve mesh tools, boolean operations, and Gen 3D AI integration (Tripo, Meshy). Also includes retopology via InstantMeshes and Hotspot Texturing.

**What We Tested:**
Full installation analysis (Hub + main package). Assembly definition review. Feature comparison against DA PolyPaint for color/painting overlap. Online manual review (docs.umodeler.com).

**Results:**
Installed across two locations: Hub in Assets/UModeler-Hub (690 files, management UI), main package in Library/PackageCache (2,082 files). Architecture is primarily compiled DLLs with thin PureCode source wrappers. Two assemblies: editor-only (Tripolygon.UModelerX.PureCode.Editor) and runtime (Tripolygon.UModelerX.Runtime.PureCode). Runtime DLL includes geometry processing libraries (libigl, OpenSubdiv, MessagePack). Editor DLL includes InstantMeshes, WebP, GifDecoder. Full Input System support with pressure-sensitive pen/tablet detection for brush tools.

Color/painting features confirmed: Vertex Color Brush (pressure-sensitive), Vertex Color tool (direct assignment), Face Color tool (per-face color), plus a full Painting Mode with layers and brushes. These use vertex color data, NOT atlas/UV-based color mapping like DA PolyPaint.

**Pros:**
- Complete 3D modeling pipeline - replaces need for external modeling tools for simple/medium assets
- Proper asmdef separation (editor + runtime assemblies)
- Full Input System integration with pen/tablet pressure sensitivity
- 80+ individual tools across modeling, UV editing, rigging, and painting
- ProBuilder integration for workflow compatibility
- Modifier stack (non-destructive bend, subdivide, shell, mirror, FFD, etc.)
- Gen 3D AI integration for rapid prototyping
- Boolean operations for CSG-style modeling
- Active maintenance (Dec 2025 release)
- Extensive online documentation (docs.umodeler.com)

**Cons:**
- Large footprint (2,082 files + 690 Hub files)
- Primarily compiled DLLs - cannot inspect or modify core code
- Runtime assembly ships geometry processing libraries (libigl, OpenSubdiv) that add to build size even if only editor modeling is used
- Hub system adds overhead (country flags, sign-in UI, licensing infrastructure)
- Third-party DLL dependencies (7 editor, 3 runtime) increase attack surface and maintenance risk
- Expensive purchase (Black Friday sale price)

**Integration Notes:**
No compile errors. Hub installed in Assets/, main package installed via Packages/ as .tgz. ProBuilder reference in asmdef links to Unity Registry ProBuilder (already installed). HDRP/URP references use version defines for conditional compilation. Input System integration uses the new Input System (already in project).

**Verdict Rationale:**
Approved. This is a committed purchase - evaluation is about understanding capabilities, not deciding whether to keep it. The tool is a complete in-editor modeling suite that covers primitive creation, polygon editing, UV mapping, rigging, painting, and AI-assisted generation. Future 3D tool assets should be evaluated against UModeler X's capabilities to avoid redundant purchases. The runtime DLL footprint is the main concern - need to verify build size impact.

**Claude/MCP Capability Assessment (Session 26 Re-evaluation):**

The original evaluation (Session 5) predated MCP for Unity. With script-execute (Roslyn), UModeler X's compiled DLLs expose a **partial** public API via static Processor classes in the `Tripolygon.UModelerX.Editor` namespace.

| Capability | Claude Can Do? | Notes |
|---|---|---|
| Combine meshes | Yes | `UMXMeshOpsCombineProcessor.Execute()` -- merge multiple UModeler objects |
| Split/separate parts | Yes | `UMXMeshOpsSplitPartsProcessor.Excute()` -- split disconnected parts (note: typo in actual API) |
| Umodelerize meshes | Yes | `UMXMeshOpsUmodelerizeProcessor.Execute(GameObject[])` -- convert standard meshes to UModeler editable |
| Check umodelerize eligibility | Yes | `UMXMeshOpsUmodelerizeProcessor.CheckUmodelerize(GameObject[])` |
| Delete UModeler objects | Yes | `UMXMeshOpsDeleteProcessor.DeleteSelectedObjects(GameObject[])` |
| Set pivot (top/center/bottom) | Yes | `MeshOpsPivotProcessor.SetTopCenter()`, `.SetCenter()`, `.SetBottomCenter()` |
| Sync editable mesh | Yes | `UModelerXEditableMeshEvents.Sync()` |
| Create primitive shapes | No | No public CreateCube/CreatePlane/etc. API exposed |
| Face extrusion/inset | No | GUI-only operation |
| UV mapping/unwrapping | No | GUI-only operation |
| Vertex painting | No | GUI-only operation |
| Knife/bevel/bridge | No | GUI-only operation |
| Boolean operations | No | GUI-only operation |
| Deform brushes | No | GUI-only operation |
| Modifier stack | No | GUI-only operation |

**Verdict:** Partial upgrade. The callable operations (combine, split, umodelerize, pivot, delete) are **post-processing utilities**, not creation tools. The core modeling pipeline (80+ tools for creation, extrusion, UV, painting, booleans) remains locked behind compiled DLLs with no public API and no XML documentation.

**Comparison with ProBuilder (AI-ProBuilder MCP, ENTRY-055):** ProBuilder via script-execute and AI-ProBuilder MCP tools covers MORE scriptable mesh creation (primitives, extrusion, face selection, materials, edge operations) than UModeler X's exposed API. For AI-driven greyboxing, ProBuilder is the stronger tool. UModeler X's value remains in its manual GUI workflow for detailed modeling.

**Practical use for Claude:** Convert imported meshes to UModeler editable format (`Umodelerize`), then the artist uses UModeler X's GUI to modify them. Claude handles the batch conversion; human handles the creative editing. Also useful for combining multiple ProBuilder greybox pieces into a single UModeler mesh for further manual refinement.

**HOK Notes:**
Useful for creating custom environmental props (docks, fishing equipment, river features), modifying imported low-poly assets to fit HOK's style, and rapid prototyping of game-specific meshes. Painting mode can color models built in-editor. For imported Asset Store models, DA PolyPaint's atlas-based approach may be more appropriate (see ENTRY-027).

**Updated HOK Notes (Session 26):** With MCP, Claude can batch-umodelerize imported meshes and combine ProBuilder greybox pieces, but all creative modeling remains manual. The AI-driven workflow is: Claude creates greybox geometry via ProBuilder (ENTRY-055), then the artist refines in UModeler X. Claude can also combine finished pieces via `UMXMeshOpsCombineProcessor`.

---

#### ENTRY-027: DA PolyPaint - Atlas Color Mapper

| Field | Value |
|-------|-------|
| **Asset** | DA PolyPaint - Atlas Color Mapper |
| **Source** | Asset Store |
| **Version** | 0.9.7 (beta) |
| **Category** | Tools |
| **Date Started** | 2026-02-07 |
| **Date Completed** | 2026-02-07 |
| **Verdict** | Conditional |
| **HOK Applicable** | Yes |

**What It Does:**
Polygon face painter that uses UV remapping against a palette texture. Select a color from a palette texture (a grid of solid colors), click on mesh faces in the Scene view, and the tool remaps those faces' UV coordinates to point at the selected color location in the atlas. This is NOT vertex coloring - it's pure UV coordinate manipulation. The model renders through a standard diffuse material with the palette as its texture.

**What We Tested:**
Full code review of all 4 scripts (~3,200 lines). Architecture analysis. Head-to-head comparison with UModeler X's painting features. Technique comparison (UV remapping vs vertex colors).

**Results:**
Tiny, focused package: 4 scripts (Painter.cs 1,045 lines, PolyPaintWindow.cs 1,743 lines, ObjFormat.cs 187 lines, PolyPaintWindowTypes.cs 289 lines). Zero dependencies. EditorWindow-based UI registered at Tools/DA/Poly Paint.

Core technique: per-face UV assignment. The mesh is restructured so each triangle gets three identical UV coordinates pointing to one location in the palette texture. Painting a face updates its UVs to point at the newly selected color. Supports flood fill, replace color, element fill, quad-loop painting, and mirror painting. Can remap an entire model from one palette texture to another (finds closest color match for each face). OBJ import/export for external round-tripping.

Supports both MeshFilter (static) and SkinnedMeshRenderer (skinned meshes baked at paint time). Does NOT support multi-submesh meshes (merged into single submesh).

**Pros:**
- Unique technique - UV remapping is fundamentally different from vertex colors
- No special shader required - works with any material that reads a diffuse texture
- Palette-based workflow perfect for low-poly art style consistency
- Remap feature can swap entire model palettes in one operation
- Mirror painting for symmetrical models
- Supports skinned meshes
- Zero dependencies, self-contained
- Tiny footprint (4 files, ~3,200 lines)
- OBJ import/export for external tool round-tripping

**Cons:**
- No asmdef - Painter.cs compiles into builds despite being editor-only in practice
- Version 0.9.7 (beta) - may have undiscovered issues
- No multi-submesh support (merges to single submesh)
- Hardcoded loop iteration limits (1000) with no explanation
- Dead code present (InvalidFaceRemoval never called)
- No batch operations or scripting API
- Allocations during painting operations (List/HashSet creation, no pooling)
- Single undo granularity (no per-stroke undo within a paint session)

**Integration Notes:**
No compile errors. No conflicts with any installed package including UModeler X. Located in Assets/ under DA PolyPaint folder. Clean removal path. The lack of asmdef means Painter.cs and ObjFormat.cs ship in builds - minimal size impact but technically unnecessary runtime code.

**Head-to-Head: DA PolyPaint vs UModeler X Painting**

| Feature | DA PolyPaint | UModeler X |
|---------|-------------|------------|
| Technique | UV remapping to palette texture | Vertex color painting |
| Color storage | UV coordinates in mesh | Vertex color data in mesh |
| Shader requirement | Standard (reads diffuse texture) | Needs vertex color shader support |
| Palette-based | Yes - pick from texture grid | No - free color picker |
| Remap to new palette | Yes - one-click full model remap | No |
| Pressure sensitivity | No | Yes (pen/tablet) |
| Layers | No | Yes |
| Best for | Recoloring imported low-poly models | Coloring models built in UModeler |

**Verdict:** Complementary tools. Different techniques for different workflows.

**Verdict Rationale:**
Conditional. Fills a specific niche that UModeler X does not cover: palette-based UV color mapping for imported low-poly assets. The atlas technique means you can enforce a project-wide color palette across all models regardless of their original texturing. For a low-poly game like HOK with a consistent art style, this is directly useful. The beta version number and lack of asmdef are concerns but not blockers given the small scope and editor-only usage.

**Claude/MCP Capability Assessment (Session 26 Re-evaluation):**

The original evaluation (Session 5) predated MCP for Unity. With script-execute (Roslyn), the Painter class is fully accessible programmatically. The class documentation explicitly states: "Can be used in play mode." -- meaning it works outside the EditorWindow context.

| Capability | Claude Can Do? | Notes |
|---|---|---|
| Initialize Painter on a mesh | Yes | `new Painter()` then `SetMeshAndRebuild(mesh, null, texture)` via script-execute |
| Paint individual faces by index | Yes | `Set(faceIndex, uvCoordinate)` then `RefreshUVs()` |
| Remap entire model to new palette | Yes | `RemapTo(newTexture)` -- nearest-color matching algorithm, one call |
| Flood fill connected faces | Yes | `FillPaint(startFace, uv)` |
| Fill entire element | Yes | `FillElement(face, uv)` |
| Repaint entire mesh one color | Yes | `FullRepaint(uv)` |
| Query face UV/color | Yes | `GetUV(face)`, `GetTextureColor(uv)` |
| Query mesh topology | Yes | `FindQuad(face)`, `FindLoop(f1, f2)`, `GetFaceLinks(face)` |
| Save results | Yes | `RefreshUVs()` then `EditorUtility.SetDirty(mesh)` + `AssetDatabase.SaveAssets()` |
| Undo/redo | Partial | `Undo_SaveState()`, `Undo_Undo()`, `Undo_Redo()` -- tied to Editor state |
| Use EditorWindow GUI | No | Manual -- Tools/DA/Poly Paint |
| Visual color picking from palette | No | Manual -- need to calculate UV coordinates for desired palette position |
| Visual verification of results | No | Manual -- need to see Scene/Game view |

**Key API Methods (public, callable from Roslyn):**
- `Painter.SetMeshAndRebuild(Mesh target, Mesh skinnedMesh, Texture2D texture)` -- required initialization
- `Painter.Set(int face, Vector2 uvc)` -- core UV remapping primitive per face
- `Painter.RemapTo(Texture2D tex2d, bool switchTexture)` -- batch remap to new palette (nearest-color match)
- `Painter.FillPaint(int startFace, Vector2 uvc, bool DontCheckColor)` -- flood fill
- `Painter.FillElement(int face, Vector2 UV)` -- fill disconnected element
- `Painter.FullRepaint(Vector2 uvc)` -- paint entire mesh
- `Painter.RefreshUVs()` -- commit UV changes to mesh (calls `_targetMesh.SetUVs`)

**HOK Workflow Example (one Roslyn script):**
1. Load HOK underworld palette texture from Assets
2. For each imported Asset Store model (fish, animals, props):
   a. Get MeshFilter.sharedMesh and Renderer material texture
   b. `new Painter()` -> `SetMeshAndRebuild(mesh, null, texture)`
   c. `RemapTo(hokPaletteTexture)` -- auto-remap all faces to nearest HOK colors
   d. `RefreshUVs()` -> `SetDirty()` -> `SaveAssets()`
3. Result: entire model recolored to HOK palette in one script call per model

**Significance:** This is a major capability upgrade. DA PolyPaint was originally assessed as "manual only" (Session 5, no MCP). With MCP script-execute, Claude can batch-recolor imported models to a project palette without any manual interaction. The `RemapTo()` method alone makes this one of the most AI-accessible painting tools in the project.

**HOK Notes:**
Primary use case: recoloring imported Asset Store low-poly models (fish, animals, characters, props) to match HOK's Greek Underworld color palette. Create a single HOK palette texture, then use PolyPaint to remap all imported models to that palette. This enforces visual consistency across assets from different publishers. UModeler X painting handles models built in-editor; PolyPaint handles everything imported.

**Updated HOK Notes (Session 26):** With MCP script-execute access, the workflow becomes: create one HOK underworld palette texture, then batch-remap all imported models in a single Roslyn script. This could recolor dozens of models (polyperfect animals, JustCreate rocks, GanzSe fishing props, EmaceArt raft) in one automated pass. No manual click-by-click painting needed for palette enforcement.



## Malbers Ecosystem Phase (Session 6)

ENTRY-028 through ENTRY-032
---

#### ENTRY-028: Malbers Animal Controller (AC)

| Field | Value |
|-------|-------|
| **Asset** | Malbers Animal Controller |
| **Source** | Asset Store (Malbers Animations) |
| **Version** | Bundled with Horse Animset Pro 4.5.1 (AC version not separately numbered) |
| **Category** | Animation |
| **Date Started** | 2026-02-07 |
| **Date Completed** | 2026-02-07 |
| **Verdict** | Approved |
| **HOK Applicable** | Yes |

**What It Does:**
Complete character controller framework for animals and humanoids. Provides a state machine (Locomotion, Jump, Fall, Swim, Fly, Climb, etc.), mode system (Attack, Action, Ability), AI brain with pluggable tasks/decisions, damage system, interaction system, stats (health, stamina), riding/mount system, weapon system, and IK management. All data-driven through ScriptableObjects. The core component is `MAnimal` which orchestrates states, modes, stances, and animator parameters through a partial-class architecture split across 4 files (MAnimal.cs, MAnimalLogic.cs, MAnimalVariables.cs, MAnimalCallBacks.cs).

**What We Tested:**
Full code review of the Common/Scripts folder (565 .cs files). Architecture analysis of state machine, mode system, AI brain, damage, interactions, and ScriptableObject variable system. Assembly definition audit. SOAP compatibility assessment. Performance pattern analysis.

**Results:**

**Architecture - Strong:**
- Partial class pattern for MAnimal keeps the main controller manageable despite its complexity
- 12+ interfaces on MAnimal (IAnimatorListener, ICharacterMove, IGravity, IObjectCore, etc.) shows proper interface segregation
- States are ScriptableObjects instantiated per-animal - data-driven, Inspector-configurable, swappable at runtime
- Modes use serializable classes with priority, conditions, and reaction chains
- AI brain uses a pluggable task/decision FSM (not a behavior tree) - simpler but adequate for NPC behavior
- Reaction system (Reaction/Reaction2) provides a generic action-chain pattern for responding to events
- DefaultExecutionOrder(-10) on MAnimal ensures it runs before dependent systems

**ScriptableObject Variable System - SOAP Compatible:**
FloatVar.cs line 6 explicitly credits "Game Architecture with Scriptable Objects by Ryan Hipple" - the same GDC talk that inspired SOAP. Malbers implements:
- ScriptableVar base class (FloatVar, IntVar, BoolVar, StringVar, Vector3Var, etc.)
- ReferenceVar pattern with UseConstant toggle (local value vs global SO asset)
- RuntimeGameObjects / RuntimeCollection (runtime sets)
- OnValueChanged events on variable mutation

This is architecturally the same lineage as SOAP's ScriptableVariable system. They can coexist because they use the same pattern - just different namespaces. HOK can use SOAP for game-wide architecture and Malbers ScriptableVars for AC-internal state without conflict.

**Assembly Definitions - Proper:**
- MalbersAnimations.asmdef (core runtime)
- MalbersAnimations.Editor.asmdef (editor only)
- MalbersAnimations.InputSystem.asmdef (New Input System integration)
- MalbersAnimations.Cinemachine.asmdef (Cinemachine integration)
- MalbersAnimations.Inventory.asmdef (Inventory system)
- All have allowUnsafeCode: false

**Code Quality Metrics (Common/Scripts, 565 files):**
- `var` keyword: ~1,700+ usages across ~335 files (widespread but per Lesson #10, not penalized for third-party code)
- LINQ: 58 total occurrences across 30 files; 14 of those in Editor-only code. ~44 runtime LINQ calls - moderate, not catastrophic
- AggressiveInlining: 59 usages across 14 files on hot-path getters/setters (Mode, State, Stats, MAnimalLogic) - shows performance awareness
- Update/LateUpdate/FixedUpdate: 74 files with frame callbacks
- new List/Dictionary/HashSet allocations: 62 across 49 files (need to verify if these are in init or per-frame paths)
- Namespace discipline: clean MalbersAnimations.* hierarchy throughout

**Pros:**
- Mature, feature-complete character controller (70+ demo scenes, years of updates)
- Data-driven architecture via ScriptableObjects matches HOK's SOAP philosophy
- Proper asmdef isolation (5 assemblies, editor separated)
- Interface-heavy design enables custom implementations
- Performance-conscious where it matters (AggressiveInlining on hot paths, AI brain pre-allocates arrays)
- Extensive demo scenes covering every feature (AI, combat, platforming, mobile, riding)
- Active maintenance with online documentation (GitBook)
- Cinemachine and New Input System integrations included
- Supports both animals and humanoids in one framework

**Cons:**
- Large footprint: 671 total .cs files across all Malbers packages
- `var` usage throughout (not a penalty per Lesson #10 but means any code you read will use var)
- ~44 runtime LINQ calls (moderate risk, concentrated in non-hot paths like AI decisions and setup code)
- Static singleton patterns: MAnimal.Animals (static list), MAnimal.MainAnimal (static player ref), Reaction.Delay (static MonoBehaviour)
- RemoveAll with lambda in RuntimeGameObjects.Item_GetClosest (allocation on each call)
- Some commented-out code blocks remain in shipped files
- The Reaction system has two versions (Reaction and Reaction2) coexisting - migration in progress

**Integration Notes:**
No compile errors (the Lootbag.cs error was in the Inventory integration, not AC core). No conflicts with any installed package. AC uses its own animator parameter system via delegate Actions rather than direct Animator calls - this means it can work with any animator setup. Cinemachine integration is via optional asmdef. Input System integration is via optional asmdef with proper version defines.

**Performance:**
Not runtime-tested yet. Code review indicates: AggressiveInlining on hot paths is good. AI brain pre-allocates arrays (MaxAlloc=20) to avoid per-frame allocation. State cache pattern avoids repeated list iteration. The 44 runtime LINQ calls are a concern but would need profiling to determine actual frame impact - most appear to be in initialization or infrequent operations, not per-frame.

**Verdict Rationale:**
Approved. The Animal Controller is a well-architected, mature framework that aligns with HOK's ScriptableObject-first philosophy. The Ryan Hipple lineage means its variable system is conceptually compatible with SOAP rather than fighting it. The asmdef isolation is proper. The code shows performance awareness in hot paths while being pragmatic elsewhere. The 671-file total is large but well-organized across logical assemblies. The static singletons are a minor architectural concern but standard practice for a character controller that needs global access patterns. For HOK, AC provides the animal behavior foundation (Scorch the dog/raccoon, fish AI, NPC animals) that would take months to build from scratch.

**HOK Notes:**
AC is the foundation for the entire Malbers ecosystem. Every other Malbers package (Inventory, Fishing, Horse, Selector) depends on it. For HOK specifically:
- **Scorch (companion animal):** AC provides the full state machine (Idle, Locomotion, Swim, interact, fetch) plus AI brain for autonomous behavior when not player-directed
- **Fish AI:** AC's AI brain with patrol/flee tasks could drive fish schooling and behavior underwater
- **NPC Animals:** Decorative animals in the Underworld using AC states for ambient behavior
- **SOAP Coexistence:** Malbers ScriptableVars and SOAP ScriptableVariables share the same Ryan Hipple lineage. Use SOAP for game architecture (events, game state, save data) and Malbers ScriptableVars for AC-internal configuration (state priorities, mode settings, AI parameters). No bridge needed - they operate in parallel.
- **Potential Concern:** MAnimal.MainAnimal static reference vs SOAP's approach of using ScriptableObject references for the player. May need a thin adapter to expose the active player MAnimal to SOAP consumers.

---

#### ENTRY-029: Ultimate Selector

| Field | Value |
|-------|-------|
| **Asset** | Ultimate Selector |
| **Source** | Asset Store (Malbers Animations) |
| **Version** | 3.4.8 |
| **Category** | UI |
| **Date Started** | 2026-02-07 |
| **Date Completed** | 2026-02-07 |
| **Verdict** | Approved |
| **HOK Applicable** | Yes |

**What It Does:**
Animated item/character selection carousel with four layout modes: Radial (circular wheel), Linear (scrolling list), Grid (table), and Custom (manual positioning). Provides drag/swipe/click/hover input, inertia physics, idle animations on focused items, auto-frame camera, material/mesh switching per item, coin-based unlock/purchase system, and persistence via PlayerPrefs. Complete with 24 demo scenes covering every layout mode and configuration.

**What We Tested:**
Full code review of all 16 .cs files (11 runtime, 5 editor). Architecture analysis of SelectorController (partial class across 3 files), SelectorManager (hub), SelectorUI (display), MItem (item component), SelectorData (persistence), and SelectorEditor (layout). Dependency chain assessment. HOK use-case mapping.

**Results:**
Clean, well-organized partial-class architecture. SelectorController splits input logic (956 lines), variables (354 lines), and callbacks (110 lines) into separate files. SelectorManager acts as the orchestration hub (801 lines) connecting controller, UI, data, and item spawning. MItem (375 lines) represents individual items with events, material/mesh switching, and lock/unlock state.

Does NOT require MAnimal or Animal Controller. Only depends on Malbers core utilities (Events, Scriptables, MTools) which are part of the Common/Scripts shared library. This makes it usable for any GameObject-based selection without the character controller overhead.

**Pros:**
- Four layout modes (Radial, Linear, Grid, Custom) cover all common selection UI patterns
- Drag/swipe with inertia physics feels polished (configurable curves, momentum)
- Event-driven (OnSelected, OnFocused, OnLocked, OnUnlocked, OnAmountChanged) - easy to integrate
- Built-in persistence (PlayerPrefs save/load for unlock status, coins, item amounts)
- Camera auto-framing based on item bounding box size
- Does not require Animal Controller - works with any GameObject
- 24 demo scenes demonstrate every configuration
- Material/mesh switching per item (color variants, model variants)
- Supports both old and new Input System
- Modular: can strip purchase/coin system and keep just the carousel

**Cons:**
- Uses legacy UnityEngine.UI.Text, not TextMeshPro (SelectorUI.cs)
- goto statement in SelectorEditor.cs (functional but archaic)
- Hard-coded layer 5 for UI placement (magic number)
- Coroutine-based animation (not async/await, but acceptable for UI tween work)
- No bounds checking on _ReduceAmountSelected - amount could go negative
- Some null safety inconsistencies
- var keyword throughout (not penalized per Lesson #10)
- SelectorManager is moderately monolithic at 801 lines

**Integration Notes:**
No compile errors. No conflicts. Depends only on Malbers Common (Events, Scriptables, MTools) - no AC dependency. The 24 demo scenes are useful reference but add to project size. Uses standard UnityEngine.UI which is already included via the uGUI package.

**Performance:**
Coroutine-based animations are lightweight. No per-frame allocations visible in the selection loop. Inertia calculations use cached values. Camera framing uses Bounds calculations (single-frame, not continuous). No LINQ in runtime paths. Performance should be negligible for a selection UI that's only active during menu screens.

**Verdict Rationale:**
Approved. A polished, self-contained selection carousel that covers HOK's UI needs for bait/lure wheels, fish collection browsers, and character customization without requiring the full Animal Controller stack. The radial mode alone is a natural fit for a fishing game's quick-select wheel. The persistence system handles collection unlock tracking. The event-driven architecture integrates cleanly with SOAP events.

**HOK Notes:**
Three direct use cases in HOK:
- **Bait/Lure Selection Wheel:** Radial mode. Player swipes to select bait before casting. MItem events fire into SOAP to update the active bait ScriptableVariable. Smooth, animated, feels premium.
- **Fish Collection/Encyclopedia:** Grid mode. Displays caught fish with locked/unlocked state. Persistence tracks which fish have been caught. Material switching could show normal vs "golden" variants.
- **Character Customization:** Linear or Radial mode. If HOK allows Scorch appearance variants (hats, collars, accessories), Ultimate Selector provides the selection UI with material/mesh switching built in.

The purchase/coin system could map directly to HOK's soul-coin economy if that's part of the design. Otherwise, strip it and use the carousel core only.

---

#### ENTRY-030: Fishing for Animal Controller

| Field | Value |
|-------|-------|
| **Asset** | Fishing for Animal Controller |
| **Source** | Asset Store (Sunfish Creations) |
| **Version** | 1.1.2 |
| **Category** | Other |
| **Date Started** | 2026-02-07 |
| **Date Completed** | 2026-02-07 |
| **Verdict** | Approved |
| **HOK Applicable** | Yes |

**What It Does:**
Complete fishing system built as a Malbers Animal Controller State integration. Provides physics-based casting (raycasts to find water surfaces), bobber animation (arc flight, submersion, idle bobbing, nibble taps, bite pull), fishing line rendering (parabolic sag), rod bending (bone-based deformation), hand IK, reeling, and three fishing modes: Simple (one-button catch), Reeling (two-phase pull), and Tug of War (active struggle with fish-pulls-against-player mechanics). Fish are defined as ScriptableObjects with per-species weight, nibble count, strike timer, flee speed, struggle duration, and prefab reference.

**What We Tested:**
Full code review of all 41 C# files. Architecture analysis of casting system (FishingCaster), bobber system (BobberController + FishingBobber), fish simulation (FishableArea + FishData), tug-of-war mechanics (FishTugOfWar), AC state integration (Fishing : State), fishing modes (strategy pattern), rod IK, and line rendering. Dependency and namespace analysis.

**Results:**
Professional-grade integration. The Fishing class inherits from Malbers' State base class, registering as State ID 16 in AC's state machine. This means fishing uses the same activation/deactivation lifecycle as Locomotion, Swim, Jump, etc. - no parallel systems, no hacks.

The casting system uses Physics.OverlapSphere to find water colliders, then raycasts to verify the point isn't blocked by terrain. An 8-iteration bisection algorithm finds the shore retrieval point, preventing the bobber from landing on dry land. Cast direction alternates left/right bias for natural variety.

The bobber system is the visual centerpiece: arc flight to water, submersion splash, surface bob, nibble taps (3 alternating taps before bite), hard bite pull-down, and tug-of-war flee movement. All animation parameters are exposed via AnimationCurves and ScriptableObject references.

FishableArea manages the fishing simulation: idle wait, random nibble timing, strike chance escalation (0% early, 50% mid, 100% at max nibbles), and bite window with a 4x time multiplier when player reels too early. This prevents cheese strategies.

Three fishing modes use a strategy pattern: SimpleFishingMode (instant catch - cozy), ReelingFishingMode (reel to shore - moderate), TugOfWarMode (active struggle with dot-product opposition calculation - challenging). All three can coexist and be selected per scenario.

**Pros:**
- Inherits from AC State - fully native integration, no parallel systems
- Physics-based casting with shore detection and terrain blocking
- Three difficulty modes via strategy pattern (Simple/Reeling/TugOfWar)
- Fish defined as ScriptableObjects - new species = new asset + prefab, zero code
- Bobber animation is polished (submersion, idle bob, nibbles, hard bite, flee)
- Fishing line with parabolic sag (10-segment LineRenderer, distance-scaled)
- Rod bone bending (windup, release, pull-back, hard-bite phases)
- Hand IK for reel grip and handle grip
- Event-driven (OnFishNibble, OnFishBite, OnBiteWindowEnd, OnReelerComplete)
- Zero per-frame allocations in Update loops
- No LINQ in runtime code (1 LINQ usage in editor-only MenuOpenVariables.cs)
- Clean namespace discipline (SunfishCreations.*)
- Proper cleanup (StopCoroutine with stored references)
- Gizmo debugging built in for cast range, water detection, shore points
- All physics and timing values exposed as Inspector parameters

**Cons:**
- No asmdef (41 files compile into default assembly - minor impact)
- Magic number: fishingMode.Value == 2 to detect Tug of War (should use enum)
- var keyword in editor-only code (1 file, acceptable per Lesson #10)
- No fish schooling/AI (fish exist only as a simulation in FishableArea, no visible fish swimming)
- Coroutine-based (not async/await, but appropriate for animation timing)
- No line tension/snap mechanic (tug of war has resistance but line never breaks)
- Documentation is online only (Sunfish Fishing GitBook, 37 pages indexed in Session 3)

**Integration Notes:**
No compile errors. No conflicts with any installed package. Depends on Malbers Animal Controller (State base class, input system, stance system). Uses AC's Reaction2 system for fish catch events. The custom Fishing state slots into AC's state machine alongside existing states. Fishing rod uses AC's existing weapon/equip infrastructure (MMelee base). FishData ScriptableObjects live in the Data folder and can be extended without modifying source.

**Performance:**
Code review shows zero per-frame allocations. FishableArea.Update is ~65 lines of conditional checks (lightweight). BobberController.Update is a single conditional + movement calculation. Coroutines handle all timed sequences. LineRenderer update is 10 points with basic parabola math. No profiling concerns for a fishing game with one active line.

**Verdict Rationale:**
Approved. This is the core gameplay system for HOK. The architecture is clean, the AC integration is native (not bolted on), the fishing modes cover the cozy-to-challenging spectrum, and the ScriptableObject fish definitions make content creation trivial. The bobber/rod/line visual systems are polished enough for a released game. The only missing features (fish schooling, line snap) are game-design decisions that can be added on top, not architectural gaps.

**HOK Notes:**
This is HOK's fishing engine. Direct mapping:
- **FishData ScriptableObjects = Soul Species.** Each soul type (Shade, Wraith, Revenant, etc.) gets a FishData asset defining difficulty, weight, and prefab. Low-poly spirit models swap in per species.
- **FishableArea = Styx Fishing Spots.** Place FishableArea components at river locations. Each area can have different fish pools (shallow spots = easy souls, deep spots = rare souls).
- **Fishing Modes = Difficulty Progression.** Start players on Simple mode (cozy catch), unlock Reeling mode (moderate challenge), endgame uses Tug of War (boss souls).
- **Bobber = Spectral Float.** Replace bobber prefab with underworld-themed model (skull float, ghost orb, ethereal lure). All animation logic carries over - just swap the mesh.
- **Rod = Charon's Tackle.** Rod bending system works with any bone-rigged rod model. Theme as Greek Underworld fishing pole.
- **Missing: Visible Fish.** FishableArea simulates fish presence but no visible fish swim in the water. For HOK, add spectral fish AI using AC's brain system swimming near fishing spots. This is an additive feature, not a modification to Fishing for AC.
- **Missing: Line Snap.** No mechanic for line breaking under tension. If HOK wants a tension meter with snap risk, add a custom TugOfWar extension that tracks cumulative tension and triggers line break. The event system supports this cleanly.
- **SOAP Bridge:** FishData catches can fire SOAP events (OnSoulCaught ScriptableEvent) via the existing UnityEvent hooks on FishableArea and Fishing state. No bridge code needed - just wire UnityEvents to SOAP event raisers in the Inspector.

---

#### ENTRY-031: Poly Art: Raccoon

| Field | Value |
|-------|-------|
| **Asset** | Poly Art: Raccoon (Forest Pack) |
| **Source** | Asset Store (Malbers Animations) |
| **Version** | 4.0 (AC integration package 1.5.0) |
| **Category** | Animation |
| **Date Started** | 2026-02-07 |
| **Date Completed** | 2026-02-07 |
| **Verdict** | Approved |
| **HOK Applicable** | Yes |

**What It Does:**
Low-poly raccoon character model with 42+ animation states, facial animation support (blink, semi-closed, closed eyes), 6 color/species variants (default, brown, black, albino, cub, red panda), and 19 material options. Includes a pre-configured AC integration package (unitypackage) and a demo scene. Part of the Malbers Forest Pack.

**What We Tested:**
Full asset inventory: FBX models, animation clips (24 FBX files), materials/textures, prefab variants, animation controller state machine, AC integration package contents. Evaluated against HOK Scorch companion requirements: swimming, idle variety, companion personality, facial expression, and low-poly art style compatibility.

**Results:**

**Animation Coverage - Excellent:**
- **Locomotion:** Walk (2 variants), WalkBack, Trot, Run, Sneak (+Sneak Idle), Climb (+Climb Drop)
- **Idle:** Idle (base), Idle01, Idle Look Left/Right, Idle Scratch, Idle Smell, Idle Yaw, Stand Idle
- **Actions:** Eat, Dig, Drink, Crawl (from controller state machine)
- **Combat:** Attack Paw Left/Right, Attack Paws, Attack Bite Left/Right, Dodge, Rolling
- **Environmental:** Swim, Jump, Fall, Turn
- **States:** Sleep, Lie, Seat, Stun, Wounded, Death (2 variants), GetHit Left/Right
- **Facial:** Blink, Semi-closed eyes, Closed eyes (dedicated Raccoon Eyes controller)

Swimming animation is present - critical for a River Styx fishing game.

**Model Quality:**
- Low-poly art style confirmed (simple albedo textures, no complex normal/detail maps)
- 4 PNG textures (brown, black, gray, albino base colors)
- 19 material variants for visual variety (including Gold, Demon, Poison - thematically useful for underworld)
- Cub variant available (smaller proportions, potential young Scorch)
- Single SkinnedMeshRenderer - efficient single draw call
- Bone structure: ~40-50 bones with finger detail

**AC Integration:**
- Unitypackage available but NOT imported: `Raccoon PolyArt 4.0 AC (1.5.0).unitypackage`
- Can use raw FBX + animations without AC dependency
- Animation controller (Raccon Anims.controller) has 42+ states with full transition graph
- Root motion enabled

**Pros:**
- 42+ animation states - far exceeds companion character requirements
- Swimming animation present (critical for HOK water setting)
- 5+ idle variations create natural companion personality
- Facial animation support (blink + eye states) adds life
- Low-poly art style matches HOK aesthetic perfectly
- 6 prefab color variants + 19 materials = extensive visual customization
- Cub variant available for size options
- Demon/Poison/Gold material variants fit underworld theme
- Can import FBX only without AC dependency
- Single SkinnedMeshRenderer (efficient rendering)
- Established Malbers quality (maintained, versioned)

**Cons:**
- Scale needs visual verification (Backrock models needed 0.2x-40x in HOK; expect similar tuning)
- No flame VFX included (HOK's Scorch uses proximity-based flame effects - must be custom)
- No "hidden in robes" animation for Kharon ferry on-duty state (use visibility toggle)
- No explicit "excited/bark" animation (use idle + audio + VFX for personality moments)
- AC unitypackage not yet imported/tested (raw FBX approach recommended for HOK)
- Demo scene not runtime-tested yet

**Integration Notes:**
No compile errors from the model/animation files. The AC integration package is a separate unitypackage that can be imported optionally. For HOK, the recommended approach is to extract FBX model + animation FBX files and build a custom CompanionController in HOK's SOAP architecture, bypassing Malbers AC entirely for the companion. The raw animations are standard Unity animation clips usable with any Animator controller.

**Performance:**
Single low-poly SkinnedMeshRenderer with ~40-50 bones. Estimated 1,000-2,000 vertices. One material, one draw call. Memory footprint estimated 2-5 MB for model + all animations. Negligible impact on any target platform.

**Verdict Rationale:**
Approved. The Raccoon is a strong replacement candidate for HOK's Scorch companion character (currently a Wolf_v1 placeholder). The animation catalog far exceeds what a companion needs. Swimming support is essential for the River Styx setting. The low-poly art style is a direct match. The mischievous raccoon personality (trash panda + underworld = trickster spirit companion) fits HOK's cozy-with-dark-humor tone better than a fierce wolf. The Demon and Gold material variants are thematically appropriate for the Greek Underworld.

**HOK Notes:**
Scorch replacement assessment:
- **Current:** Wolf_v1 placeholder (Backrock Studios, fierce/predatory, 20x scale needed)
- **Proposed:** Raccoon Poly Art (cute/mischievous, companion feel, swim-capable)
- **Tone Match:** Raccoon fits "cozy fishing sim with dark humor" better than wolf. A raccoon as a hell-hound companion is inherently funny - the trickster archetype works in Greek mythology context.
- **Animation Mapping for Scorch:**
  - Fishing idle: Random selection from Idle/Scratch/Smell/Yaw
  - Rare fish detection: Sneak Idle + Sneak Look + custom flame VFX intensity
  - Ferry rest: Sleep/Lie/Seat on cooler
  - Following player: Walk/Trot/Run based on distance
  - Water: Swim state when near River Styx
  - Personality: Eat/Dig/Drink for ambient actions
  - On-duty toggle: Visibility toggle (no special animation needed)
- **Implementation:** Post-MVP. Extract FBX, build custom CompanionController.cs in HOK.Companion namespace, wire to KharonStateController for on-duty visibility, add ScorchFlameVFX component for proximity-based flame detection.
- **Next Step:** Load Raccoon Demo PolyArt.unity in Sandbox to visually verify scale, animation quality, and art style compatibility.

---

#### ENTRY-032: Horse Animset Pro (Riding System)

| Field | Value |
|-------|-------|
| **Asset** | Horse Animset Pro (Riding System) |
| **Source** | Asset Store (Malbers Animations) |
| **Version** | 4.5.1 |
| **Category** | Animation |
| **Date Started** | 2026-02-07 |
| **Date Completed** | 2026-02-07 |
| **Verdict** | Deferred |
| **HOK Applicable** | No |

**What It Does:**
Horse riding, combat, and mount system for Malbers Animal Controller. Includes horse models (Poly Art + Realistic), rider animations, mount/dismount sequences, carriage/wagon support, Pegasus flight, combat while mounted (3 combat styles), and AI mount behavior. Provides 18 demo scenes and 47 prefabs.

**What We Tested:**
High-level asset inventory only. File counts, folder structure, prefab listing, demo scene enumeration. No code review performed because this package contains zero scripts of its own - all riding system code (11 files) lives in Common/Scripts/Riding System/ which was already reviewed as part of the AC evaluation (ENTRY-028).

**Results:**
Pure content package. Zero .cs files in the Horse AnimSet Pro folder. All riding logic is in the shared Common/Scripts/Riding System/ (Mount.cs, MRider.cs, Carriage/, etc.). The package provides: 2 horse model types (Poly Art + Realistic), 7 horse variants (base, Pegasus, Unicorn, Wings, AI, Ragdoll), rider prefabs, wagon/carriage prefabs, mount/dismount animations, combat animations while mounted, and 18 demo scenes.

**Pros:**
- Two art styles (Poly Art matches HOK aesthetic if ever needed)
- Comprehensive demo scenes (18) demonstrate full riding capability
- Zero additional code footprint (uses shared riding system)
- Carriage/wagon system could theoretically be adapted for Kharon's ferry (stretch)

**Cons:**
- No HOK use case - no animal riding planned for any current project
- Content adds to project size without providing current value
- Horse models would need heavy reskinning for Greek Underworld theme

**Integration Notes:**
Already installed and compiled as part of the Malbers package bundle. No compile errors. The riding system code in Common/Scripts/ is loaded regardless of whether HAP content is used. Removing HAP content would be asset deletion only (models, animations, prefabs, demo scenes) - no code impact.

**Performance:**
No runtime impact unless HAP prefabs are placed in scenes. Content is dormant.

**Verdict Rationale:**
Deferred. No riding mechanic exists in HOK or any other active TecVooDoo project. The asset is installed as part of the Malbers bundle and has zero runtime cost when unused. Not worth evaluating further until a project requires mounted gameplay. The riding system code in Common/Scripts/ was already assessed as part of ENTRY-028 (AC) and is architecturally clean.

**HOK Notes:**
No direct use case. The only tangential connection is the carriage system - Kharon's ferry could theoretically use mount/vehicle patterns, but the ferry is a simple platform with a spline path, not a mounted vehicle. Keep installed as part of the Malbers bundle, ignore for HOK.



## Low-Poly Art Pipeline Phase (Session 7)

ENTRY-033 through ENTRY-038
---

#### ENTRY-033: Fish Alive - Animated Polyart Fish

| Field | Value |
|-------|-------|
| **Asset** | Fish Alive - Animated Polyart Fish |
| **Source** | Asset Store (Denys Almaral) |
| **Version** | 1.0 |
| **Category** | Animation / AI |
| **Date Started** | 2026-02-07 |
| **Date Completed** | 2026-02-07 |
| **Verdict** | Approved |
| **HOK Applicable** | Yes |

**What It Does:**
NOT just a model pack. Fish Alive is a complete fish behavior system with 9 low-poly rigged fish species (~460 triangles each), 63 animation clips (7 per species: 3 swim, 3 idle, 1 bite), schooling/group management, target-following AI, obstacle avoidance, food interaction system, speed-based animation blending, and body-bend tracking for realistic swimming motion. Includes a coral reef environment, bubble particle effects, and 3 demo scenes including a benchmark for stress testing.

**What We Tested:**
Full code review of all 9 C# scripts (FishMotion 916 lines, GroupOfFish 417 lines, FishInteract 103 lines, ReachPoint 112 lines, SwimConfig 39 lines, SpeedBubbles 35 lines, FishConstant constants, GroupOfFishEditor gizmos, DemoBenchmark demo UI). Architecture analysis, per-frame cost assessment, integration point mapping with HOK fishing system.

**Results:**

**Fish Behavior System (FishMotion.cs - 916 lines):**
Target-following AI with four reach modes: Wander (swim around target loosely), Position (reach exact spot), Transform (reach spot + rotation), PositionToBite (align mouth bone for bite). Swimming uses realistic acceleration/deceleration with cubic motion curves and configurable liquid drag. Body bending is tracked via motion history (MotionBendTracking) and fed to the animator as a blend parameter. Ping system periodically re-evaluates target position with random precision offset for natural variation. Three distance-based acceleration tiers (fast/normal/slow) create convincing approach behavior.

**Schooling System (GroupOfFish.cs - 417 lines):**
Manages groups of fish with shared or individual targets. Spawns fish via FishMultiplier array (configure species and count). Creates AI-controlled target points that wander within configurable soft limits. Hard limits enforce absolute boundaries. Target updates run every 0.2s (not per-frame). Auto-adds bubble particle effects and FishInteract components to spawned fish.

**Food Interaction (FishInteract.cs - 103 lines):**
Autonomous feeding behavior. Scans sphere around fish for "food" tagged objects on layer 20. Hunger cooldown (7s default) and probabilistic eating chance. Temporarily redirects fish to food target, triggers bite, then returns to previous target. Uses System.Action delegates for events (OnBiting, OnBitingEnds, OnTargetReached).

**Obstacle Avoidance (Avoidance nested class in FishMotion):**
Soft avoidance using spherecast ahead. Cone-search for escape directions. Not strict - fish can clip through if no escape found. Prioritizes visual appeal over perfect collision. Configurable and toggleable per fish.

**SwimConfig (ScriptableObject):**
Data-driven swimming presets (Agile, Normal, Clumsy). Configurable: ping frequency, target precision, acceleration tiers, liquid drag, bite animation reference, mouth bone reference. Swap presets to change fish behavior without code.

**Code Quality:**
- Clean namespace: `FishAlive` isolates all code
- No asmdef (9 files compile into default assembly - minor impact)
- 51 `var` usages (not penalized per Lesson #10)
- Zero LINQ in runtime code (System.Linq imported but unused)
- Zero per-frame allocations in Update (just Motion + Timers + optional avoidance)
- Animator parameters cached as int hashes (good practice)
- GroupOfFish.Update throttled to 0.2s intervals
- System.Action delegates for events (no boxing, no UnityEvent overhead)
- Dead import: `using UnityEngine.AI` but no NavMesh usage
- One commented-out debug line (minor)

**Pros:**
- Complete behavior system, not just art - schooling, feeding, avoidance, target following
- 9 species at ~460 tris each (extremely lean, ideal for schools of 50-100+)
- All fish are bone-rigged (not vertex animation) - enables custom mouth positions per species
- ScriptableObject swim presets (data-driven behavior tuning)
- Event-driven: OnBiting, OnBitingEnds, OnTargetReached hook into external systems
- GroupOfFish handles spawning, bounds management, and target AI
- Bubble particle effects integrated per fish
- 3 demo scenes including performance benchmark
- No external dependencies (no Malbers, no third-party packages)
- Clean Update (Motion + Timers, throttled target updates)
- Coral reef environment included

**Cons:**
- No asmdef (9 files, minor compilation impact)
- Dead `using UnityEngine.AI` import
- No size/weight variation per instance (all same-species fish are identical)
- Food detection hardcoded to layer 20 and "food" tag (configurable but requires matching setup)
- No concept of fish rarity, value, or catch difficulty (would need extension for HOK)
- Avoidance is soft - fish can clip through obstacles
- No Malbers AC integration (independent system)
- Commented-out debug code (1 instance)

**Integration Notes:**
No compile errors. No conflicts with any installed package. Completely standalone - no Malbers dependency. This is important: Fish Alive fish and Malbers AC fish behavior are independent systems. For HOK, Fish Alive provides the visible swimming fish that the player sees in the water, while Fishing for AC's FishableArea simulates the invisible "are they biting" mechanic. The two systems complement each other.

**Performance:**
~460 triangles per fish. FishMotion.Update is lightweight (position/rotation math + animator parameter set). GroupOfFish throttles target updates to 5x/second. No per-frame allocations. Benchmark demo exists for stress testing. Expect 100+ fish on screen with no performance concern on PC. Mobile targets may want to cap at 30-50 depending on device.

**Verdict Rationale:**
Approved. Fish Alive fills the critical "visible fish" gap in HOK's fishing experience. Fishing for AC simulates the catch mechanics but has no visible fish swimming in the water. Fish Alive provides the visual layer: schools of low-poly fish swimming around fishing spots with natural behavior (wandering, feeding, avoidance). The event system (OnBiting, OnTargetReached) enables integration with HOK's catch mechanics. The ScriptableObject swim presets allow per-species behavior tuning (lazy catfish vs darting minnows). At ~460 tris per fish, schools of 50+ are feasible.

**HOK Notes:**
Fish Alive and Fishing for AC are the two halves of HOK's fishing experience:
- **Fishing for AC** = invisible simulation. Handles casting, bobber, bite timing, reeling, tug-of-war. Fish exist only as FishData ScriptableObjects defining difficulty.
- **Fish Alive** = visible layer. Schools of animated fish swim near fishing spots. Players see fish before casting. Fish react to bobber/bait (set as target).

**Integration approach for HOK:**
- Place GroupOfFish at each FishableArea location. Configure species mix per area (shallow = small fish, deep = large rare souls).
- Set bobber/bait as FishMotion.target when cast lands. Fish approach the bait visually while FishableArea runs the bite simulation independently.
- On successful catch (Fishing for AC event), destroy the closest Fish Alive fish to simulate removal from the school.
- Extend FishMotion or create a thin FishAliveHOKAdapter to add: rarity tier, soul-coin value, weight/size variance per instance, spectral VFX toggle.
- Restyle fish prefabs: replace tropical textures with underworld-themed materials (ghostly, ethereal, spectral glow). The bone-rigged models accept any material.
- SwimConfig presets per soul type: restless wraiths (Agile), ancient shades (Clumsy), common spirits (Normal).

**Key Insight:** Neither system knows about the other. They communicate through game events: "bobber lands" sets Fish Alive targets, "fish caught" removes a Fish Alive instance. SOAP events bridge the gap cleanly - no code coupling needed.

---

#### ENTRY-034: GanzSe Fantasy Low Poly Fishing Props

| Field | Value |
|-------|-------|
| **Asset** | GanzSe Fantasy Low Poly Fishing Props |
| **Source** | Asset Store (GanzSe) |
| **Version** | 1.0 |
| **Category** | Art |
| **Date Started** | 2026-02-07 |
| **Date Completed** | 2026-02-07 |
| **Verdict** | Approved |
| **HOK Applicable** | Yes |

**What It Does:**
70 low-poly fantasy-themed fishing props: rods (complete and empty), hooks, floats, bait, nets, hand nets, harpoons, lobster traps, tackle boxes (full and empty), buckets, worm jars, a fishing boat, chair, hanging posts, direction signs, notice boards, an oar, and 20 fish model variants. All share a single palette texture (one material for all props). URP-ready.

**What We Tested:**
Asset inventory. Model count, prefab count, material system, scripts, animations, URP compatibility.

**Results:**
Clean static mesh pack. 70 FBX models with 1:1 prefab ratio. Single shared material using URP/Lit shader with a color palette texture (same technique as polyperfect packs). Zero scripts. Zero animations. Zero animator controllers. Prefabs are bare (Transform + MeshFilter + MeshRenderer, no colliders, no LOD). Includes 1 demo scene and a PDF readme.

**Pros:**
- Fantasy fishing theme fits HOK's underworld setting better than realistic fishing gear
- Single palette texture = easy to restyle for Greek Underworld color scheme (swap palette)
- 70 props cover every fishing scenario (rod, tackle, bait, boat, signs, fish)
- URP/Lit materials ready to go
- Zero scripts = zero runtime overhead, zero integration risk
- 20 fish models as static props (for display, market stalls, caught fish on hooks)

**Cons:**
- No colliders on prefabs (need manual setup for interaction)
- No LOD groups
- Not animated (fish are static - use Fish Alive for swimming fish)
- Single material means all props share the same color palette (limited per-object color control without DA PolyPaint or UModeler X recoloring)

**HOK Notes:**
Direct use cases: fishing rod props for Kharon's tackle shop, tackle boxes on the raft, direction signs at fishing spots, notice boards for quest info, fishing chair for idle animation, boat as environmental set dressing, static fish on hooks/in buckets for caught-fish display. The fantasy theme (not modern/realistic) makes these feel at home in an underworld setting. Swap the palette texture to match HOK's color scheme using DA PolyPaint's remap feature.

---

#### ENTRY-035: Poly Universal Pack

| Field | Value |
|-------|-------|
| **Asset** | Poly Universal Pack |
| **Source** | Asset Store (polyperfect) |
| **Version** | 4.8 |
| **Category** | Art |
| **Date Started** | 2026-02-07 |
| **Date Completed** | 2026-02-07 |
| **Verdict** | Approved |
| **HOK Applicable** | Yes |

**What It Does:**
Massive low-poly static mesh library: 6,029 FBX models and 6,385 prefabs across 24 themed categories. Includes Fantasy (medieval buildings, boats, furniture, weapons, armor, market stalls), City (buildings, signs, lamps), Nature (trees, flowers, mushrooms, plants), Modular Parts (walls, roofs, stairs, doors, windows), Survival (tents, cabins, traps), Steampunk, Halloween, Farm, Food, Drinks, Sports, Vehicles, and seasonal themes. No animations. 2 demo scripts (MouseLook, PlayerMovement).

**What We Tested:**
Asset inventory. Category breakdown, model counts, animation check, script check.

**Results:**
Strictly static meshes - no animations, no animator controllers. polyperfect visual style consistent across all 6,029 models. 2 trivial demo scripts (camera look + player movement for demo scenes). The Fantasy category alone includes buildings, boats, furniture, equipment, flags, statues, weapons, armor, helmets, shields, cooking items, wood structures, bridges, tents, and market stalls - all potentially useful for HOK's underworld dock/market areas.

**Pros:**
- 6,029 models = essentially any prop you could need for prototyping
- Fantasy category directly applicable to HOK (medieval/mythological aesthetic)
- Nature category (trees, mushrooms, plants) for underworld environment
- Modular building parts for dock/market construction
- Consistent polyperfect visual style across all categories
- Halloween category (cauldrons, scythes, candles) fits underworld theme
- Zero meaningful scripts = zero integration risk

**Cons:**
- Massive package size (6,029 models, most unused)
- No animations (static only)
- No LOD groups
- Models are generic low-poly, not underworld-themed (need recoloring)
- 2 demo scripts compile into default assembly (trivial but present)

**HOK Notes:**
Utility pack for rapid prototyping. When HOK needs a barrel, a market stall, a medieval table, a boat, a torch holder, or any set-dressing prop, check Poly Universal first. The Fantasy and Nature categories are the most relevant. For production, restyle with DA PolyPaint to match HOK's underworld palette. Not every model will ship - this is a prototyping resource that prevents blocking on custom modeling.

---

#### ENTRY-036: Low Poly Animated Animals (polyperfect)

| Field | Value |
|-------|-------|
| **Asset** | Low Poly Animated Animals |
| **Source** | Asset Store (polyperfect) |
| **Version** | 4.1.1 |
| **Category** | Animation / Art |
| **Date Started** | 2026-02-07 |
| **Date Completed** | 2026-02-07 |
| **Verdict** | Approved |
| **HOK Applicable** | Yes |

**What It Does:**
50+ low-poly animated animal species with wander AI. 155 FBX files (rig + animation pairs per species), 162 prefabs, 81 animation clips, 74 animator controllers. Includes mammals (bear, wolf, lion, elephant, horse, deer), marine life (dolphin, whale, shark, seahorse, crab, starfish, jellyfish), birds (eagle, penguin, seagull), reptiles (crocodile, snake), and small creatures (rabbit, squirrel, bee). Each animal has idle, walk, run, attack, eat, and death animations. Marine animals have swim animations. Birds have fly animations. Comes with a simple wander AI system (11 scripts).

**What We Tested:**
Asset inventory. Species count, animation coverage, script list, demo scenes, Malbers AC compatibility check.

**Results:**
Comprehensive animal library with consistent polyperfect style. Each species has its own animator controller and animation set (idle, walk, run, attack, eat, die as baseline, plus species-specific actions). Deep script review found 25 total scripts (not 11 - the Common/ shared folder was missed in initial count). Architecture uses wrapper pattern: thin Animal_* classes delegate to Common_* base implementations. The heart is Common_WanderScript.cs (~960 lines) - a complete autonomous AI system with predator-prey ecosystem, stamina economy, and 6-state machine (Idle/Wander/Chase/Evade/Attack/Dead). NO Malbers AC integration - fundamentally incompatible due to CharacterController vs Rigidbody movement and direct SetBool() animation control vs state machine layers. Includes URP material conversion package. 17 demo scenes.

**Script Inventory (25 files):**

| Script | Purpose | Malbers Safe? |
|--------|---------|---------------|
| Common_WanderScript.cs (~960 lines) | Full AI: state machine, predator-prey, stamina, combat | NO - CRITICAL |
| AIStats.cs (ScriptableObject) | Dominance/stamina/power/toughness/aggression config | Standalone OK |
| AIState.cs, IdleState.cs, MovementState.cs | State data classes (animationBool, speed, weight) | AI-only |
| Common_WanderManager.cs (Singleton) | Global peace mode, mass kill | AI-only |
| Common_AudioManager.cs (Singleton) | Object-pooled spatial audio (20 sources) | YES |
| Common_SurfaceRotation.cs | Terrain slope alignment via raycast | Rotation conflict |
| Common_PlaySound.cs | Animation event to audio bridge | YES |
| Common_AnimSpeed.cs | Random animation speed variation (0.85-1.25x) | YES |
| Common_RandomInt.cs | StateMachineBehaviour for death/attack variants | YES |
| Common_AnimationControl.cs | Legacy animator parameter utility (unused) | YES |
| Common_KillSwitch.cs | Debug: press 1 to kill (unused) | Cruft |
| RandomCharacterPlacer.cs | Editor: spawn prefabs at random NavMesh positions | Editor-only |
| Animal_WanderScript.cs | 1-line wrapper -> Common_WanderScript | NO |
| Animal_AIStats.cs | 1-line wrapper -> AIStats | Standalone OK |
| Animal_SurfaceRotation.cs | 1-line wrapper -> Common_SurfaceRotation | Conflict |
| AnimalAudioManager.cs | 1-line wrapper -> Common_AudioManager | YES |
| AnimalPlaySound.cs | 1-line wrapper -> Common_PlaySound | YES |
| AnimalWanderManager.cs | 1-line wrapper -> Common_WanderManager | AI-only |
| SceneAnimatorController.cs | Demo: manual animation state setter | Demo-only |
| AnimalViewerManager.cs | Demo: character/animation browser UI | Demo-only |
| Polyperfect_CameraController.cs | Demo: orbit camera with scroll zoom | Demo-only |
| ToggleEvent.cs | Demo: UI toggle utility | Demo-only |
| Animals_WanderScriptEditor.cs | Editor: custom inspector for wander script | Editor-only |

**AI System Details:**
- **Movement:** Dual-mode - NavMeshAgent.destination (preferred) or CharacterController.SimpleMove() (fallback). RequireComponent forces CharacterController on every animal.
- **Animation:** Direct animator.SetBool() parameter control. ClearAnimatorBools() disables all before setting new state. Requires exact parameter name matching between AIState configs and Animator Controller.
- **AI Decisions:** Coroutine-throttled to every 0.7-1.0 seconds (not per-frame). Scans static AllAnimals list for threats (higher dominance) and prey (lower dominance). O(n^2) scaling with animal count.
- **Stamina:** Chase/Evade drain 1.0/s, Idle/Wander restore 1.0/s. Chase requires >90% stamina, flee requires >10%.
- **Combat:** Melee damage every attackSpeed seconds (default 0.5s). Damage = power stat. Death at toughness <= 0.
- **UnityEvents:** deathEvent, attackingEvent, idleEvent, movementEvent for external hooks.
- **Gizmos:** Blue=wander zone, Magenta=awareness, Red=scent range, Green=movement target.

**Pros:**
- 50+ species with consistent visual style
- Marine animals (dolphin, whale, shark, seahorse, jellyfish, crab, starfish) directly useful for underwater HOK scenes
- Each species has full animation set (idle, walk, run, attack, eat, die)
- Sophisticated predator-prey ecosystem with stamina economy (not "simple wander AI")
- Good performance design: coroutine-throttled AI, visibility-culled terrain alignment
- Object-pooled audio system reusable for other purposes
- ScriptableObject-driven stats (AIStats) for easy per-species tuning
- UnityEvents on state changes for external integration
- Consistent polyperfect style matches Poly Universal Pack
- URP conversion package included

**Cons:**
- **NOT compatible with Malbers AC** - three critical conflicts: CharacterController vs Rigidbody movement, direct SetBool() vs state machine animation, competing AI decision systems
- 25 scripts with no asmdef (compile into default assembly)
- O(n^2) predator-prey detection via static AllAnimals list (50 animals = ~2,500 checks/cycle)
- Hard-coded layer names ("Terrain", "Walkable")
- Magic numbers throughout (1.0f contingency, 2.0f attackReach, 0.2f threshold)
- AllAnimals list never cleared on scene change (potential memory leak)
- Common_KillSwitch and Common_AnimationControl are unused cruft
- `var` keyword used inconsistently

**HOK Notes:**
Two use paths (unchanged from initial assessment, now validated by deep review):
1. **As-is with wander AI:** Ambient underworld creatures. Place jellyfish, crabs, seahorses near fishing spots for atmosphere. The AI is more sophisticated than initially assessed - full predator-prey ecosystem with stamina, not just random wandering. Good for 10-30 ambient NPCs without AC.
2. **With Malbers AC:** Must fully disable/remove all polyperfect scripts. Keep only meshes, rigs, animation clips, and animator controllers. Rebuild animator parameters for AC's state machine approach. This is a significant retargeting effort. Whether the models can be driven by AC depends on rig type (humanoid vs generic) - needs runtime testing.

**Safe components to keep alongside Malbers:** Common_AudioManager (audio pooling), Common_AnimSpeed (variation), Common_RandomInt (death variants), RandomCharacterPlacer (editor spawn tool).

The marine animal selection (dolphin, whale, shark, seahorse, jellyfish, crab, starfish) is particularly valuable for HOK's River Styx environment. These could serve as underworld spirit-animals swimming around the player's raft.

---

#### ENTRY-037: Low Poly Animated People (polyperfect)

| Field | Value |
|-------|-------|
| **Asset** | Low Poly Animated People |
| **Source** | Asset Store (polyperfect) |
| **Version** | 3.02 |
| **Category** | Animation / Art |
| **Date Started** | 2026-02-07 |
| **Date Completed** | 2026-02-07 |
| **Verdict** | Approved |
| **HOK Applicable** | Yes |

**What It Does:**
80+ low-poly human character types with animations and IK system. 307 FBX files, 128 prefabs, 11 animator controllers. Characters span casual, fantasy (knight, wizard, viking, pirate, ninja), professional (police, doctor, pilot, chef), sports, and creative types. Includes male, female, boy, and girl variants across most professions. Animations: walk, run, idle variants, combat (punch, kick, stab, slash), death (3 variants), crouching, texting, waving, dancing (5 styles), exercise. Notable: 8 disability-representation characters (wheelchair, crutches, prosthetic, blind, cane). 19 scripts including wander AI, IK system (PolyIk), character morpher, atlas generator, and 3rd-person controller.

**What We Tested:**
Asset inventory. Character diversity, animation coverage, script list, IK system presence, Malbers AC compatibility check.

**Results:**
Deep script review found 23 total scripts (not 19 - Common/ shared folder adds 4). Same wrapper architecture as Animals: thin People_* classes delegate to Common_* base implementations. The AI system is identical (Common_WanderScript). People-specific additions: PolyIk.cs (full IK with foot/hand/head targets and pole hints via OnAnimatorIK), PlayerController.cs (basic 3rd person Rigidbody controller), PolyMorpher.cs (procedural body scaling), CustomPeople.cs (UI slider morphing), AtlasGenerator.cs (color palette texture creation), and MakeCharacters.cs (editor rig generator). NO Malbers AC integration - fundamentally incompatible (same reasons as Animals, plus IK conflict). Characters use 256x256 palette textures with shared UV layout. Fantasy characters (knight, wizard, viking, pirate) directly relevant to HOK.

**Script Inventory (23 files):**

| Script | Purpose | Malbers Safe? |
|--------|---------|---------------|
| Common_WanderScript.cs (~960 lines) | Full AI (shared with Animals) | NO - CRITICAL |
| Common_WanderManager.cs | Global peace mode (shared) | AI-only |
| Common_AudioManager.cs | Audio pooling (shared) | YES |
| Common_SurfaceRotation.cs | Terrain alignment (shared) | Rotation conflict |
| Common_AnimationControl.cs | Animator parameter utility (shared) | YES |
| AIStats.cs, AIState.cs, IdleState.cs, MovementState.cs | State data (shared) | AI-only |
| People_WanderScript.cs | 1-line wrapper -> Common_WanderScript | NO |
| People_WanderManager.cs | 1-line wrapper -> Common_WanderManager | AI-only |
| People_AudioManager.cs | 1-line wrapper -> Common_AudioManager | YES |
| People_SurfaceRotation.cs | 1-line wrapper -> Common_SurfaceRotation | Conflict |
| People_AIStats.cs | 1-line wrapper -> AIStats | Standalone OK |
| **PolyIk.cs** (~120 lines) | Full IK: foot/hand/head with pole hints | NO - CRITICAL |
| HumanBoneOffset.cs | IK bone rotation offset data class | IK-only |
| **PlayerController.cs** (~78 lines) | 3rd person Rigidbody controller (WASD+mouse) | NO - CRITICAL |
| **PolyMorpher.cs** (~98 lines) | Random body part scaling (0.9-1.1x) | YES |
| **CustomPeople.cs** (~63 lines) | UI slider-driven body morphing | YES |
| **AtlasGenerator.cs** (~162 lines) | Color palette texture generation | YES |
| **MakeCharacters.cs** (~143 lines) | Editor rig generator + prefab saver | Editor-only |
| CharacterManager.cs (~296 lines) | Demo: character/animation browser UI | Demo-only |
| LayoutGameobjectInGrid.cs | Demo: grid layout utility | Demo-only |
| SimpleWater.cs (~69 lines) | Procedural water grid mesh | YES |
| EditorExtensions.cs | Sprite-to-PNG export utility | Editor-only |
| PolyIkEditor.cs (~278 lines) | Custom inspector for PolyIk | Editor-only |
| AtlasEditor.cs (~67 lines) | Custom inspector for AtlasGenerator | Editor-only |

**IK System Details (PolyIk.cs):**
- Full OnAnimatorIK() implementation for humanoid avatars
- **Foot IK:** Position + rotation targets with knee pole hints for natural bending
- **Hand IK:** Position + rotation targets with elbow pole hints
- **Look-At IK:** Head + eye weight control with target tracking
- **Spine offsets:** HumanBoneOffset list for per-bone rotation tweaks
- **Weight controls:** 0-1 range sliders for each limb (blend between IK and animation)
- **Editor preview:** ExecuteInEditMode with animator.Update(0) for scene view preview
- **Humanoid-only:** Validates avatar type in Start(), disables if not humanoid rig
- **Custom inspector:** PolyIkEditor creates IK target GameObjects at bone positions with one click

**PlayerController Details:**
- Requires Rigidbody (not CharacterController like AI system)
- WASD movement via Rigidbody.MovePosition()
- Mouse look rotation
- Sprint (LeftShift doubles speed)
- Jump (Space + AddForce impulse)
- Ground detection via Physics.Raycast to layer 9
- Animation via blend float parameters (Vertical/Horizontal/WalkSpeed)

**Pros:**
- 80+ character types with consistent polyperfect style
- Fantasy characters (knight, wizard, viking, pirate) adaptable to Greek mythology NPCs
- Full IK system (PolyIk.cs) with foot/hand/head + pole targets - professional implementation
- PolyMorpher procedural variation (0.9-1.1x body part scaling) safe for any pipeline
- CustomPeople UI-driven morphing via AvatarMask-based part detection
- AtlasGenerator for procedural color palette textures (8x8 grid, 256-2048px)
- Palette texture system allows easy reskinning (same as GanzSe concept)
- Disability representation (inclusive design)
- Multiple animation types per character (idle, walk, combat, death, dance)
- MakeCharacters editor tool automates rig variant creation + prefab saving

**Cons:**
- **NOT compatible with Malbers AC** - four critical conflicts: CharacterController vs Rigidbody movement, direct SetBool() vs state machine animation, OnAnimatorIK() competing with Malbers IK, PlayerController fighting Malbers for Rigidbody control
- 23 scripts with no asmdef (compile into default assembly)
- PlayerController uses hard-coded input (Input.GetAxis, KeyCode) instead of Input System
- PlayerController ground check uses magic layer number (9)
- PolyIk has inconsistent casing (LeftHandTarget vs leftHandTarget, LookAtEyesWeight)
- AI system identical to Animals pack (same O(n^2) scaling, static list, etc.)
- `var` keyword used inconsistently

**HOK Notes:**
NPC souls in the underworld. The fantasy characters (knights, wizards, vikings, pirates) become departed warriors/adventurers waiting at Kharon's ferry dock. Professional characters become everyday souls. The palette texture swap lets you give all NPCs a ghostly/spectral color scheme with a single texture change.

**Integration paths:**
1. **Standalone (no Malbers):** Use People_WanderScript for basic NPC behavior. PolyIk adds foot placement and look-at. Good for background NPCs that don't need AC's full behavior system.
2. **With Malbers AC:** Must fully disable/remove People_WanderScript, PolyIk, PlayerController, and People_SurfaceRotation. Keep only meshes, rigs, animation clips. Rebuild animator controllers for AC's state machine. Use Malbers' own IK (MAIKFootPlacement). Significant retargeting effort.

**Safe components to keep alongside Malbers:** PolyMorpher (variation), CustomPeople (morphing), AtlasGenerator (palettes), Common_AudioManager (audio pooling), SimpleWater (mesh), People_AudioManager.

---

#### ENTRY-038: City People Mega-Pack

| Field | Value |
|-------|-------|
| **Asset** | City People Mega-Pack |
| **Source** | Asset Store (Denys Almaral) |
| **Version** | 1.4.0 |
| **Category** | Animation / Art |
| **Date Started** | 2026-02-07 |
| **Date Completed** | 2026-02-07 |
| **Verdict** | Approved |
| **HOK Applicable** | Yes |

**What It Does:**
157+ low-poly character models across 12 demographic categories: City, Downtown, Young Adults, Kids, Little Kids, Elders, Beach, Professions (chef, nurse, doctor, police, firefighter), Construction, Disabilities (8 specialized characters), Costumes, and Extras. 29 animation FBX files covering locomotion (walk, slow walk, jogging, running, phone walking), idles (4 variants), dancing (5 styles: afro, flossing M/F, hype, riverdance), exercise, and construction tool use (drill, hammer, handsaw, wrench, screwdriver, pipe wrench). Same Polyart style as Fish Alive (same author: Denys Almaral). Uses palette texture system - any character can receive any palette material. 6 scripts including auto-play animation cycling and palette material swapper.

**What We Tested:**
Asset inventory. Character count, animation coverage, scripts, palette system, URP compatibility.

**Results:**
Broader demographic range than polyperfect People but fewer fantasy types. Same Polyart visual style as Fish Alive (same author). ~2,000 tris per character. Single-mesh design (not modular). Palette texture at 256x256 with shared UV mapping. Animation naming includes frame counts (e.g., `idle_m_1_200f.fbx`). 11 animator controllers. 6 scripts: CityPeople.cs (auto-play + palette swap), DemoCamera.cs, DemoSpinner.cs, SwapAndToolController.cs, ToolConfig.cs, PackageExporterRefs.cs. URP materials included.

**Pros:**
- Same visual style as Fish Alive (Denys Almaral) - consistent look in scenes together
- Age diversity (kids 3-5, youth 10-15, young adults, adults, elders 60-70)
- Disability representation (wheelchair, crutches, prosthetic, blind, cane - 8 characters)
- Construction tool animations (drill, hammer, saw, wrench) could be repurposed
- Dancing animations (5 styles) for festival/celebration scenes
- Palette texture swap for easy mass reskinning
- URP-ready

**Cons:**
- Modern/contemporary character designs (not fantasy/mythological)
- 6 scripts with no asmdef
- No Malbers AC integration
- Less relevant to HOK's Greek Underworld than polyperfect's fantasy characters
- No combat or death animations (limited action set)

**HOK Notes:**
Secondary to polyperfect People for NPC variety, but the demographic diversity adds realism to the ferry dock crowd. Elders become ancient souls, kids become young spirits, construction workers become underworld laborers (building the dock). The palette texture swap transforms modern clothing into ghostly/underworld tones with a single texture change. The dancing animations could be used for underworld celebration scenes. Same author as Fish Alive means the visual style is guaranteed consistent when both assets appear in the same scene.



## SW3 Ecosystem Phase (Sessions 8-9)

ENTRY-039 through ENTRY-042
---

#### ENTRY-039: Stylized Water 3 (Staggart Creations)

| Field | Value |
|-------|-------|
| **Asset** | Stylized Water 3 |
| **Source** | Asset Store (Staggart Creations) |
| **Version** | 3.2.5 |
| **Category** | Rendering |
| **Date Started** | 2026-02-07 |
| **Date Completed** | 2026-02-07 |
| **Verdict** | Approved |
| **HOK Applicable** | Yes - Critical |

**What It Does:**
Production-ready stylized water rendering solution for Unity 6 URP. Gerstner wave system with up to 64 layers via ScriptableObject WaveProfiles. GPU-based height query system for buoyancy/alignment. Planar reflections. Water decals (oil, weeds, targeting reticles). Ocean mesh component (8x8km with gradual vertex density). Render Graph architecture. 74 C# scripts (41 runtime, 31 editor, 2 demo), 31 shader files (5 .shader, 26 .hlsl), 3 custom .watershader3 files. Namespace: `StylizedWater3`.

**What We Tested:**
Package structure analysis, script inventory, asmdef architecture, API review (WaterObject, AlignToWater, Gerstner, HeightQuerySystem), shader library structure, material presets, wave profiles, changelog review. No runtime testing yet.

**Results:**
Exemplary architecture. Proper asmdef separation: `sc.stylizedwater3.runtime` (41 scripts, dependencies: URP 17.0.3, Unity.Mathematics) and `sc.stylizedwater3.editor` (31 scripts, Editor-only platform). Conditional compilation via versionDefines for optional packages (VFX Graph, Splines, XR, Input System). WaterObject component uses static Instances list for global water tracking. AlignToWater demonstrates dual-mode height queries: CPU (Gerstner wave replication) or GPU (async readback with callback). WaveProfile is a ScriptableObject with AnimationCurve-driven wave parameters. 9 preset profiles included (Ocean, River, Lake, Waterfall, etc.). 49 material presets covering stylized, realistic, toon, lowpoly, mobile, lava, frozen, toxic styles. 5 quick-start prefabs. 4 demo scenes. Actively maintained - latest update Feb 5, 2026 (2 days before evaluation).

**Script Architecture:**

| Subsystem | Scripts | Purpose |
|-----------|---------|---------|
| Core Components | 8 | WaterObject, AlignToWater, WaterGrid, OceanFollowBehaviour, etc. |
| Rendering | 5 | StylizedWaterRenderFeature, HeightPrePass, PlanarReflectionRenderer |
| Height Queries | 5 | GPU/CPU height sampling with async callbacks |
| Dynamic Effects | 8 | Real-time displacement, shoreline waves, data passes |
| Underwater | 9 | Underwater areas, fog, shading, waterline, mask passes |
| Gerstner/Waves | 3 | Wave computation, WaveProfile SO, ShaderParams |
| Utilities | 3 | PipelineUtilities, RenderTargetDebugger, Extension base |
| Editor | 31 | Inspectors, property drawers, shader tools, windows |

**Key API (StylizedWater3 namespace):**
- `WaterObject.Instances` - Static list of all water objects in scene
- `WaterObject.Find(position, rotationSupport)` - Find water at world position
- `WaterObject.CustomTime` - Network-synchronized wave time override
- `WaterObject.PositionOffset` - Floating-point origin support
- `AlignToWater` - Snap transform to water surface (4-point sampling, normal derivation, Rigidbody support)
- `HeightQuerySystem.Sampler` - Define sample positions, get height values
- `HeightQuerySystem.AsyncRequest` - GPU readback with onCompleted callback
- `Gerstner.ComputeHeight()` - CPU wave height computation
- `WaveProfile` - ScriptableObject (waveLengthMultiplier, amplitudeMultiplier, steepness, AnimationCurves, up to 64 layers)

**Pros:**
- Exemplary code quality: clean namespace, XML doc comments, proper asmdef separation
- Dual-mode height queries (GPU async readback + CPU Gerstner replication)
- ScriptableObject-driven wave profiles with 9 presets
- 49 material presets covering every water style imaginable
- Render Graph architecture (Unity 6 native)
- Conditional compilation for optional features (VFX Graph, Splines, XR)
- Floating-point origin support (WaterObject.PositionOffset)
- Custom time control for network sync or cutscenes
- Actively maintained (latest update 2 days before evaluation)
- 26 modular HLSL shader includes (caustics, foam, fog, lighting, normals, refraction, etc.)
- SRP Batcher and GPU Resident Drawer compatible
- Desktop/console focus with mobile preset available

**Cons:**
- Assets folder install (not UPM Package Manager), though has package.json
- Demo content authored for desktop/console (no mobile-specific demo)
- Copyright-restricted source (DMCA-protected, cannot redistribute)
- Large shader library (31 files) increases compile time

**HOK Notes:**
**Critical asset for HOK.** The River Styx is the central gameplay environment. This provides:
1. **River water:** River wave profile + river material preset. Stylized look matches low-poly art direction.
2. **Buoyancy for Kharon's raft:** AlignToWater component with Rigidbody support. GPU height queries for precise wave-following.
3. **Fishing interaction:** HeightQuerySystem lets fishing line/bobber track water surface height programmatically.
4. **Water decals:** Oil slicks, underwater weeds, targeting reticles for fishing spot indicators.
5. **Waterfall prefabs:** Three sizes for underworld environment decoration.
6. **Custom styles:** Lava, toxic goop, frozen, swamp presets for different underworld regions.
7. **Network sync:** CustomTime property for potential multiplayer wave synchronization.

The AlignToWater component is particularly well-suited for HOK's raft - it samples 4 points, derives a surface normal, and applies smoothed position/rotation to a Rigidbody. This is exactly what Kharon's ferry needs.

---

#### ENTRY-040: Dynamic Effects for Stylized Water 3 (Staggart Creations)

| Field | Value |
|-------|-------|
| **Asset** | Dynamic Effects for Stylized Water 3 (Extension) |
| **Source** | Asset Store (Staggart Creations) |
| **Version** | 3.1.1 |
| **Category** | Rendering |
| **Date Started** | 2026-02-07 |
| **Date Completed** | 2026-02-07 |
| **Verdict** | Approved |
| **HOK Applicable** | Yes |

**What It Does:**
Extension for Stylized Water 3 adding real-time water surface displacement, foam, and normal modification. Decal-like projection system from top-down perspective. Accepts input from particle systems, trail renderers, and static meshes. Shoreline wave spawner along splines with audio emitter integration. 8 runtime scripts (DynamicEffect, ShorelineWaveSpawner, render passes). 12 dynamic effect materials included. Render feature embedded into core SW3 render feature.

**What We Tested:**
Package structure analysis (integrated into SW3 folder), script inventory, material presets, documentation review. No runtime testing yet.

**Results:**
Tightly integrated with base SW3 package - shares the same render feature rather than adding a separate one. 8 runtime scripts handle displacement data rendering, height-to-normals conversion, and setup. 4 editor scripts provide inspectors for DynamicEffect and ShorelineWaveSpawner. 12 material presets: wake, ripple, foam particle, shore wave, whirlpool, wind gust, directional ripples, ramp, trail line, stationary foam, shore foam, default. 3 shader files (2 .shader + 1 .hlsl). SRP Batcher and GPU Resident Drawer compatible. The displacement system recalculates surface normals from Y-axis displacement only.

**Pros:**
- Embedded render feature (no extra pass overhead)
- SRP Batcher + GPU Resident Drawer compatible
- 12 effect material presets covering common scenarios
- Works with particle systems, trail renderers, and meshes
- Shoreline wave spawner with spline support and audio integration
- Effects readable through C# (scripting integration)
- Proper asmdef (shared with SW3 runtime)

**Cons:**
- Rendering resolution scales inversely with range (detail drops at +1000m)
- Requires base SW3 package (not standalone)
- Limited documentation extracted (SPA-style site)

**HOK Notes:**
Directly useful for:
1. **Raft wake effects:** Trail renderer or particle-based wake behind Kharon's ferry
2. **Fishing splash:** Ripple particles when casting line or reeling in fish
3. **Shoreline waves:** Spline-based shore waves along the River Styx banks with audio
4. **Environmental effects:** Whirlpool for dangerous water areas, wind gusts for atmosphere
5. **NPC interaction:** Foam/displacement when souls enter the water

---

#### ENTRY-041: Underwater Rendering for Stylized Water 3 (Staggart Creations)

| Field | Value |
|-------|-------|
| **Asset** | Underwater Rendering for Stylized Water 3 (Extension) |
| **Source** | Asset Store (Staggart Creations) |
| **Version** | 3.2.x |
| **Category** | Rendering |
| **Date Started** | 2026-02-07 |
| **Date Completed** | 2026-02-07 |
| **Verdict** | Approved |
| **HOK Applicable** | Yes |

**What It Does:**
Extension for Stylized Water 3 adding underwater rendering via box collider trigger zones. Camera-following particle effects (sunshafts, bubbles) with depth limits. Custom underwater fog, lighting, and shading. Waterline effect at surface intersection. Revised transparency shader for underwater particles. 9 runtime scripts. Requires SW3 v3.2.0+. Rewritten for Unity 6 Render Graph. Mobile hardware support.

**What We Tested:**
Package structure analysis (integrated into SW3 folder), script inventory, render pass architecture, documentation review. No runtime testing yet.

**Results:**
9 runtime scripts organized into passes: SetupPrePass, UnderwaterMaskPass, UnderwaterShadingPass, WaterlinePass. UnderwaterArea component defines trigger zones via box colliders (discrete zones, not volume blending). UnderwaterResources ScriptableObject for configuration. 5 HLSL shader files (UnderwaterFog, UnderwaterLighting, UnderwaterMask, UnderwaterShading, Common). 2 editor scripts (RenderFeatureEditor, UnderwaterAreaEditor). Complete rewrite for Render Graph. COZY weather integration documented. Mobile hardware support (new in v3).

**Pros:**
- Box collider trigger zones (simple, predictable underwater detection)
- Mobile hardware support (new feature)
- Full Render Graph architecture
- No full-screen post-processing required (performance improvement)
- Camera-following particle effects with depth limits
- COZY weather system integration
- Proper render pass pipeline (mask -> shading -> waterline)

**Cons:**
- Requires SW3 v3.2.0+ (version coupling)
- No blur/distortion effects (not ported from v2)
- No volume-based settings blending (removed feature)
- Box collider zones must be manually placed (not automatic)

**HOK Notes:**
Directly useful for:
1. **Underwater fishing view:** Player camera dips below Styx surface to see fish. Box collider trigger zones define fishable underwater areas.
2. **Sunshaft particles:** Atmospheric light filtering through the River Styx
3. **Underworld atmosphere:** Custom fog color/density for each underwater zone (different areas of the Styx could have different mood)
4. **Waterline effect:** Visual transition when camera crosses water surface while fishing
5. **Mobile support:** Important if HOK targets mobile platforms

**Note:** Blur/distortion effects were removed from v2 and not ported. If HOK needs underwater distortion, this would need a custom post-processing solution.

---

#### ENTRY-042: Ripple Shader Pack -- Real-Time Water Ripples (Eldvmo)

| Field | Value |
|-------|-------|
| **Asset** | Ripple Shader Pack -- Real-Time Water Ripples |
| **Source** | Asset Store (Eldvmo) |
| **Version** | 1.0.0 |
| **Category** | Rendering |
| **Date Started** | 2026-02-08 |
| **Date Completed** | 2026-02-08 |
| **Verdict** | Rejected |
| **HOK Applicable** | No |

**What It Does:**
Standalone ripple effect system with 4 ripple types: Object-Triggered (moving objects create ring ripples via trigger+raycast), Mouse Input (click-based ring ripples), Raindrop (random ripple distribution), and Continuous (cosine wave for stationary floating objects). Ripples are UV-based vertex displacement on a flat water plane mesh. 5 C# scripts, 4 CG/HLSL shaders, 6 materials, 5 prefabs, 4 demo scenes. Namespace: `Eldvmo.Ripples`. No asmdef.

**What We Tested:**
Full source review of all 5 scripts, all 4 shaders, README, folder structure, third-party notices. Compared feature-by-feature against Stylized Water 3 Dynamic Effects (ENTRY-040).

**Results:**

**Shader Architecture:**
All 4 shaders use legacy Built-in Render Pipeline (`CGPROGRAM`, `#include "UnityCG.cginc"`). Not URP-compatible. On Unity 6 URP these either won't render or will render incorrectly.

| Shader | Purpose | Array Size | Wave Model |
|--------|---------|------------|------------|
| RingRipple_Lite | Object-triggered ripples | 10 | Expanding ring, linear decay |
| RingRipple_Intensive | Mouse/rain high-density | 100 | Same ring model, higher count |
| ContinuousRipple | Stationary floating | 1 (single vec4) | Cosine wave, distance decay |
| HideWaterShader | Stencil utility | N/A | None (stencil write only) |

**Script Issues Found:**

| File | Issue | Severity |
|------|-------|----------|
| MouseInputForRipple.cs:3 | `using Unity.VisualScripting` imported, never used | Minor |
| MouseInputForRipple.cs:25 | `Camera.main` called every FixedUpdate (uncached, uses FindWithTag internally) | Performance |
| MouseInputForRipple.cs:26 | `Physics.Raycast(ray, out hit, waterLayerMask)` passes layer mask int as maxDistance parameter (wrong overload, silent bug - raycast hits ALL layers) | Bug |
| ObjectCollisionRipple.cs:65 | `ripplePlane.material.SetVectorArray()` allocates new material instance every FixedUpdate (should use MaterialPropertyBlock or cache) | Performance/GC |
| RaindropRipple.cs:50 | Same per-frame `.material` allocation | Performance/GC |
| BoatFloatControl.cs:21 | `ripplePlane.gameObject.GetComponent<MeshRenderer>()` when ripplePlane IS already MeshRenderer | Redundant |
| BoatControl.cs | Legacy Input API `Input.GetKey("w")` - no Input System support | Compatibility |
| All scripts | No asmdef, unused System.Collections imports | Minor |

**Head-to-Head vs SW3 Dynamic Effects (ENTRY-040):**

| Capability | Ripple Shader Pack | SW3 Dynamic Effects |
|-----------|-------------------|-------------------|
| Object wake/trail | ObjectCollisionRipple (10 point ring) | DynamicEffect_Wake.mat (trail renderer, unlimited) |
| Click/touch ripple | MouseInputForRipple (100 point ring) | DynamicEffect_RippleParticle.mat (particle system) |
| Rain/environment | RaindropRipple (random UV points) | Particle emitter + RippleParticle material |
| Continuous displacement | ContinuousRipple (cosine wave) | DynamicEffect_StationairyFoam.mat + default displacement |
| Directional ripples | Not supported | DynamicEffect_DirectionalRipples.mat |
| Shoreline waves | Not supported | DynamicEffect_ShoreWave.mat + ShorelineWaveSpawner |
| Whirlpool | Not supported | DynamicEffect_Whirlpool.mat |
| Wind gusts | Not supported | DynamicEffect_WindGust.mat |
| Foam generation | Not supported | Per-effect foamAmount control |
| Normal modification | Not supported | Per-effect normalStrength control |
| Render pipeline | BiRP only (CGPROGRAM) | URP Render Graph native |
| Integration with water | Standalone plane (replaces water) | Overlays onto SW3 water surface |
| Height query feedback | None | Displacement feeds into SW3 height system |

**Pros:**
- Simple, focused concept (4 files per ripple type)
- Proper namespace (`Eldvmo.Ripples`)
- Ring ripple wave math is clean and readable
- CC0-licensed textures (no licensing concerns for art assets)

**Cons:**
- **Built-in Render Pipeline shaders** - won't work on Unity 6 URP without full rewrite
- **Cannot layer onto SW3** - replaces the water surface entirely, losing Gerstner waves, foam, caustics, reflections, refraction, and all other SW3 features
- **Silent raycast bug** - MouseInputForRipple passes layerMask as maxDistance (wrong overload)
- **Per-frame GC allocations** - `.material` property creates new material instances every physics tick
- **Uncached Camera.main** - FindWithTag call every FixedUpdate
- **Legacy Input API** - no Input System support
- **No asmdef** - scripts compile into Assembly-CSharp
- **Hardcoded array sizes** - 10/100 ripple limit baked into both shader and script
- **No height query system** - objects can't read back ripple height (BoatFloatControl replicates the wave math CPU-side instead)
- **Tested on Unity 2022.3** - no Unity 6 testing confirmed by developer

**HOK Notes:**
**Not applicable.** HOK uses Unity 6 URP with Stylized Water 3 as the water rendering system. This asset's BiRP shaders are incompatible, and every ripple capability it provides is already covered by SW3 Dynamic Effects with superior integration. Using this alongside SW3 would require running separate water meshes with separate shaders, losing all SW3 visual features in ripple areas. There is zero use case where this asset adds value over the existing SW3 stack.

---


---

**End of Asset Evaluation Log Archive**
