# Sandbox - Project Status

**Project:** Sandbox
**Developer:** TecVooDoo LLC / Rune (Stephen Brandon)
**Platform:** Unity 6 (6000.3.7f1)
**Source:** `E:\Unity\Sandbox`
**Document Version:** 44
**Last Updated:** February 14, 2026

**Archive:** `Sandbox_Status_Archive.md` (old sessions, version history, completed experiments)

**Last Session (Feb 14, 2026 - Session 37):** HOK documentation restructuring. Created dedicated HOK document set at `Documents/HOK/Documents/`: HOK_Status.md, HOK_CodeReference.md, HOK_Troubleshooting.md, HOK_Refactor.md, HOK_Status_Archive.md, HOK_Troubleshooting_Archive.md. Migrated HOK-specific content (spatial convention, architecture, vertical slice details, HOK sessions) from this doc to HOK_Status.md. Sandbox_Status.md slimmed to focus on asset evaluation and package management. No asset evaluations this session.

**Previous Session (Feb 13, 2026 - Sessions 32-36):** HOK Milestone 3 fishing system development (5 sessions). Created FishingController (12-phase state machine), FishFightController, FishTensionSystem, HokFishingLine, HokFishingZone, HokFishData. Power-cast system, reel mechanics, line physics, fish data transition from Sunfish to HOK-native. See `HOK/Documents/HOK_Status.md` for full session details.

**Previous Session (Feb 12, 2026 - Sessions 30-31):** HOK Vertical Slice kickoff. Milestones 1 (Raft on Spline) and 2 (Camera System) COMPLETE. Milestone 3 started. See `HOK/Documents/HOK_Status.md` for details.

**Previous Session (Feb 12, 2026 - Session 29):** Asset evaluation continuation. NuGetForUnity rejected (ENTRY-065). Unity-Technologies sweep: 8 entries (ENTRY-066-072), Git URL packages broken -- converted to local file refs. ML-Agents v4.0.2 installed (ENTRY-068). Cysharp sweep: 10 entries (ENTRY-073 to 082). 82 total entries.

**Previous Session (Feb 12, 2026 - Session 28):** River Acheron scene refinement. River widened, gorge wall clipping fixed, 82 inner cliff walls placed. Final: 0 clips.

*(Session 27 and earlier archived to Sandbox_Status_Archive.md)*

---

## Purpose

Sandbox is an asset trial and evaluation project. It is NOT a game. Its sole purpose is to explore, test, and evaluate assets, packages, and techniques before committing them to active projects (primarily HOK - Hooked on Kharon).

**This project is disposable.** Scenes, scripts, and configurations created here exist only to validate assets. Nothing in Sandbox should be treated as production code.

---

## Quick Context

**Primary Evaluation Target:** HOK (Hooked on Kharon) - Cozy low-poly 3D fishing sim, Unity 6, URP
**Evaluation Criteria:** Does the asset work with our stack? Is it performant? Is it worth the integration cost?
**Tracking Document:** `Sandbox_AssetLog.md` - All asset evaluations recorded there

**HOK Development Status:** For HOK-specific development status (vertical slice progress, fishing system, architecture, coding standards), see `HOK/Documents/HOK_Status.md`. HOK code lives at `Assets/Sandbox/HOK/` inside this Sandbox project until it breaks out to its own Unity project.

**Current Phase:** HOK vertical slice implementation on Acheron. Sandbox continues as the proving ground for asset evaluation. Assets tested here graduate to the HOK design docs when proven.

**Document flow:**
- **Sandbox docs** (this Status, AssetLog, Troubleshooting) track asset evaluation and package management
- **HOK docs** (HOK_Status, CodeReference, Troubleshooting, Refactor) track HOK development
- **HOK design docs** (GDD, research docs, art list) define what to build
- Assets proven in Sandbox get noted in the Art Asset List; design decisions recorded in the GDD

---

## Development Priorities (Inherited from HOK)

1. **Use installed assets first** - before writing custom code, check if an installed package already provides the functionality
2. **SOLID principles** - single responsibility, open/closed, Liskov substitution, interface segregation, dependency inversion
3. **Memory efficiency** - no per-frame allocations, no per-frame LINQ, object pooling where appropriate
4. **Clean code** - readable, maintainable, consistent formatting
5. **Self-documenting code** - clear naming over comments; if code needs a comment, consider refactoring first
6. **Platform best practices** - Unity > C#, Cloudflare/Supabase > HTML/JS (platform-specific wins over language-generic)

---

## Coding Standards (Inherited from HOK)

- Prefer async/await (UniTask) over coroutines unless trivial
- Avoid allocations in Update
- No per-frame LINQ
- No `var` keyword - explicit types always
- ASCII-only documentation and identifiers
- Clear separation between logic and UI

These standards apply even in Sandbox. Test code should reflect how the asset would be used in production.

**HOK architecture, namespaces, folder structure, and refactoring guidelines:** See `HOK/Documents/HOK_Status.md` and `HOK/Documents/HOK_Refactor.md`.

---

## Implementation Lessons

Carried forward from HOK prototype and Sandbox work. These are hard-won -- do not relearn them. HOK-specific lessons are also copied to `HOK/Documents/HOK_Status.md`.

| # | Lesson | Source |
|---|--------|--------|
| 1 | Input Action GUIDs must be valid hex. When manually editing .inputactions files, all GUID characters must be hexadecimal (0-9, a-f only). Invalid characters cause parse errors on reimport. | HOK Session |
| 2 | Third-party model scales vary wildly. Backrock Studios models needed 0.2x to 40x scale. Always test scale visually per-model, not per-category. | HOK Session |
| 3 | Spline position fights external transform control. ApplySplinePosition() runs every frame and teleports the raft. Any system that moves the raft off-spline (docking, cutscenes) must lock movement first via SetMovementLocked(). On unlock, blend back onto the spline. | HOK Session |
| 4 | Dual modes proven (Active/Idle fishing). Resistance-based reeling is skill-based and engaging. Keep as-is from Cast n' Chill analysis. | HOK Design |
| 5 | SOAP architecture works for fish, gear, merchant definitions. Use ScriptableObject event channels for decoupled communication. | HOK Design |
| 6 | Ferry mechanics need equal depth to fishing. Both halves deserve full design. Interconnected systems beat separate systems -- soul decay ties fishing gear to ferry routes. | HOK Design |
| 7 | Environmental storytelling over exposition. Background events, no pop-ups, no tutorials. Rewards mythology knowledge. | HOK Design |
| 19 | Unity Terrain meshes are single-sided. U_Terrain pieces used as cave ceilings are transparent when viewed from below. Use mesh primitives (cubes) or double-sided shader for overhead terrain. | Acheron Session 21 |
| 23 | MCP extension packages installed mid-session are NOT visible to Claude Code until session restart. Claude Code caches the MCP tool list at startup. Plan MCP extension installs at session start, or restart after installing. | AI-ProBuilder Session 26 |
| 24 | ProBuilder API changed in Unity 6. Use `ShapeGenerator.GenerateCube/GenerateCylinder/etc.` (not GenerateShape). `positions` returns `IList<Vector3>`. Avoid `using UnityEditor.ProBuilder;` (EditorUtility conflict). Always call `ToMesh()` then `Refresh()` after mesh modifications. | AI-ProBuilder Session 26 |
| 25 | ProBuilder shapes created via script-execute get transient default materials (pink/null in URP). Always explicitly assign a URP/Lit material after creating ProBuilder shapes via code. | AI-ProBuilder Session 26 |
| 26 | Re-evaluate asset AI capabilities when MCP tooling changes. With script-execute (Roslyn), any asset with a public C# API becomes Claude-accessible. Periodically audit older evaluations when MCP capabilities expand. | ENTRY-026/027 Session 26 |
| 27 | MCP for Unity updates may break due to NuGet dependency gaps on OpenUPM. Pin to known-good versions. Cannot remove/update MCP via its own tools (file locks). Edit manifest.json directly. | MCP Update Session 27 |
| 28 | GitHub Git URL packages in UPM require `?path=` parameter when `package.json` is NOT at the repo root. Always check where package.json lives before adding a Git URL. | Git URL Packages Session 29 |
| 29 | ML-Agents is overkill for hand-crafted creature AI. Boids + hierarchical state machine + SO parameters is the HOK recommendation. Do NOT install com.unity.sentis alongside ML-Agents 4.x on Unity 6.3 -- dual ONNX importer conflict. | ML-Agents Research Session 29 |
| 30 | Cinemachine 3.x is a full rewrite from v2. Key renames: VirtualCamera -> Camera, Transposer -> Follow, Composer -> RotationComposer. Priority-based switching. TrackerSettings struct for damping. | Vertical Slice Session 30 |
| 31 | Materials assigned via script-execute need SerializedObject to persist in scene. Use `SerializedObject(renderer)` -> `FindProperty("m_Materials")` -> `ApplyModifiedProperties()` for guaranteed persistence. | Vertical Slice Session 30 |
| 32 | Gameplay objects need a parent/child hierarchy: root parent at (1,1,1) scale for movement/logic, art mesh as child with own scale. Non-uniform parent scale causes stretching on parented children. | Vertical Slice Session 30 |
| 33 | Malbers MEvent runtime subscription: Create MEventItemListener, set Event/Response/Owner, call RegisterListener(). New scripts need AssetDatabase.Refresh() before MCP script-execute sees serialized properties. | Fishing Integration Session 31 |
| 34 | Malbers AC prefab variants may ship with null State entries. Causes NullRef in MAnimal.UpdateInputSource(). Fix: remove null entry from Animal Controller States list. Check ALL Malbers-derived prefabs. | Demo Validation Session 31 |
| 35 | Cinemachine BindingMode determines how FollowOffset is interpreted. WorldSpace = absolute, LockToTargetWithWorldUp = target-relative. TrackerSettings is a struct -- must box, modify, write back. | Camera Fix Session 32 |
| 36 | Animator.GetBoneTransform throws InvalidOperationException on non-humanoid Animators. Always check animator.isHuman first. Cascading: early Awake() throw means objects created after are null for all subsequent calls. | HokFishCatcher Bug Session 32 |

---

## Installed Packages

### Features (Unity Hub)

| Feature | Packages |
|---------|----------|
| 3D Characters and Animation | 4 packages |
| 3D World Building | 3 packages |

### Asset Store

| Package | Version | Purpose | Also in HOK? |
|---------|---------|---------|--------------|
| City People Mega-Pack | 1.4.0 | Character models | No |
| DA PolyPaint - Atlas Color Mapper | 0.9.7 | Texture/color mapping | No |
| DevTrails - Developer Statistics | 1.7.x | Dev analytics/statistics | No |
| Dynamic Effects for Stylized Water 3 | 3.1.1 | SW3 displacement, wake, ripples | No |
| Environment / Weather / Nature VFX pack | 1.1.3 | Nature VFX (Conditional - BiRP shaders need URP conversion) | No |
| Fish Alive - Animated Polyart Fish | 1.0 | Animated fish models | No |
| Fishing for Animal Controller | 1.1.2 | Fishing system (Malbers integration) | No |
| GanzSe Fantasy Low Poly Fishing Props | 1.0 | Low-poly fishing props | No |
| Horse Animset Pro (Riding System) | 4.5.1 | Animal riding/animation | No |
| Low Poly Animated Animals | 4.1.1 | Low-poly animal models | No |
| Low Poly Animated People | 3.02 | Low-poly people models | No |
| Low Poly Modular Terrain Pack | 1.5 | Modular terrain + cave pieces (Approved) | No |
| Low Poly Rocks Pack | 1.3.8 | Rocks, crystals, minerals (Approved) | No |
| Malbers Inventory System | 2.3 | Inventory system (Malbers) | No |
| Odin Inspector and Serializer | 4.0.1.2 | Enhanced inspector, serialization | Yes |
| Odin Validator | 4.0.1.2 | Data validation | Yes |
| Poly Art: Raccoon | 4.0 | Low-poly raccoon model | No |
| Poly Universal Pack | 4.8 | Low-poly universal models | No |
| Prefab World Builder | 4.9 | Level design tool | No |
| River Modeler | 1.0.4 | Spline-based river geometry, SW3 integration (Approved) | No |
| RNGNeeds - Probability Distribution | 1.0.0 | Weighted random | No |
| Scriptable Sheets | 1.8.0 | Spreadsheet data import | No |
| SOAP - ScriptableObject Architecture | 3.7.1 | ScriptableObject event/variable system | Yes |
| Stylized Water 3 | 3.2.5 | Water rendering (CRITICAL) | No |
| UDebug Panel - Ingame Debug Tools | 1.3.3 | Runtime debug UI | No |
| Ultimate Preview Window - Pro Edition | 1.3 | Enhanced preview window | No |
| Ultimate Selector | 3.4.8 | Selection system | No |
| Underwater Rendering for Stylized Water 3 | 3.2.x | SW3 underwater effects | No |
| vFavorites 2 | 2.0.14 | Editor favorites | No |
| vFolders 2 | 2.1.12 | Enhanced folder view | No |
| vHierarchy 2 | 2.1.7 | Enhanced hierarchy view | No |
| Wingman - Your Inspector's Best Friend | 1.2.3 | Inspector enhancement | No |

### Local Packages

| Package | Version | Purpose | Also in HOK? |
|---------|---------|---------|--------------|
| MCP for Unity (AI Game Developer) | 0.46.2 | Claude Code MCP bridge (52 tools) | Yes |
| UniTask | 2.5.10 | Async/await | Yes |
| TecVooDoo Utilities | 1.0.0 | Timers, extensions, singletons, gameplay utilities | Pending migration |
| Unity-ImageLoader (IvanMurzak) | 7.0.1 | Async image loading, dual RAM/disk cache | Maybe (codex portraits) |
| Unity-Theme (IvanMurzak) | 4.2.0 | Color palette system, runtime theme switching | Maybe (river theming) |
| AI-ProBuilder (IvanMurzak) | 1.0.24 | MCP extension: 13 ProBuilder mesh tools, FaceDirection selection | Maybe (greyboxing) |
| AI-Animation (IvanMurzak) | 1.0.24 | MCP extension: 6 animation tools (clip+controller create/get/modify) | Maybe (animation work) |
| AI-ParticleSystem (IvanMurzak) | 1.0.12 | MCP extension: 2 particle system tools (COMPILATION BUG - not functional) | Maybe (VFX work) |
| Unity Toon Shader (Unity-Technologies) | 0.13.1-preview | Cel-shading, outlines, rim lighting for URP (Git URL) | Yes |
| BuildReportInspector (Unity-Technologies) | 0.4.5-preview | Build analysis, asset duplication detection (Git URL) | Yes |

**Removed (replaced by TecVooDoo Utilities):**
- ~~Improved Timers 1.0.4~~ (com.gitamend.improvedtimers)
- ~~Unity Utility Library 1.0.21~~ (com.gitamend.unityutils)

### Other (Custom/Tarball)

| Package | Version | Purpose | Also in HOK? |
|---------|---------|---------|--------------|
| Addressables | 2.7.6 (Custom) | Asset management | No |
| Fullscreen Editor | 2.2.10 (Custom) | Fullscreen game view | No |
| LWS Scriptable Sheets | 1.8.0 (Custom) | Scriptable Sheets runtime | No |
| RNGNeeds | 1.0.0 (Custom) | Starphase probability engine | No |
| Starphase Core | 0.1.2 (Custom) | RNGNeeds dependency | No |
| UModeler X | 1.0.55+plus.f3 (Tarball) | 3D modeling in-editor | No |

### Unity Registry

| Package | Version | Also in HOK? |
|---------|---------|--------------|
| 2D Sprite | 1.0.0 | Yes |
| AI Navigation | 2.0.10 | No |
| AI Toolkit | 1.5.0-pre.2 (Pre) | No |
| Animation Rigging | 1.4.1 | No |
| App UI | 2.1.1 | No |
| Assistant | 1.5.0-pre.2 (Pre) | No |
| Autodesk FBX SDK for Unity | 5.1.3 | No |
| Burst | 1.8.27 | No |
| Cinemachine | 3.1.5 | Yes |
| Collections | 2.6.2 | No |
| Custom NUnit | 2.0.5 | No |
| Editor Coroutines | 1.0.1 | No |
| FBX Exporter | 5.1.5 | No |
| Generators | 1.5.0-pre.2 (Pre) | No |
| Input System | 1.18.0 | Yes |
| Mathematics | 1.3.3 | No |
| Mono Cecil | 1.11.6 | No |
| Multiplayer Center | 1.0.1 | No |
| Newtonsoft Json | 3.2.2 | No |
| Performance testing API | 3.2.0 | No |
| ProBuilder | 6.0.8 | Yes |
| Scriptable Build Pipeline | 2.5.1 | No |
| Scriptable Render Pipeline Core | 17.3.0 | No |
| Searcher | 4.9.4 | No |
| ML-Agents | 4.0.1 | Yes |
| Sentis | 2.5.0 | No |
| Serialization | 3.1.3 | No |
| Settings Manager | 2.1.1 | No |
| Shader Graph | 17.3.0 | No |
| Splines | 2.8.2 | Yes |
| Terrain Tools | 5.3.1 | No |
| Test Framework | 1.6.0 | No |
| Timeline | 1.8.10 | Yes |
| uGUI | 2.0.0 | No |
| Unity glTFast | 6.14.1 | No |
| Unity Profiling Core API | 1.0.3 | No |
| Unity Version Control | 2.11.3 | No |
| Universal Render Pipeline | 17.3.0 | Yes |
| Universal Render Pipeline Config | 17.0.3 | No |
| Visual Effect Graph | 17.3.0 | No |
| Visual Scripting | 1.9.9 | No |
| Visual Studio Editor | 2.0.27 | No |

---

## Packages in HOK but NOT in Sandbox

These HOK packages are not installed here. Install on-demand if an asset trial requires them:

| Package | Version (HOK) | Purpose |
|---------|---------------|---------|
| Dialogue System for Unity | 2.2.65 | Soul dialogue, merchant conversations |
| DOTween Pro | 1.0.386 | Animation, UI transitions |
| Dreamteck Splines | 3.0.6 | River paths, ferry routes |
| Easy Save 3 | 3.5.x | Save/load system |
| In-game Debug Console | 1.8.4 | Runtime debugging |
| Lean GUI | 2.1.0 | UI polish, tooltips, transitions |
| Text Animator | 3.1.1 | Animated dialogue text |

---

## Active Experiments

**Malbers Ecosystem Evaluation - COMPLETE** (see Sandbox_Status_Archive.md)

**Low-Poly Art Pipeline - COMPLETE** (see Sandbox_Status_Archive.md)

**Stylized Water 3 Ecosystem - COMPLETE** (see Sandbox_Status_Archive.md)

**Editor Tools - COMPLETE** (see Sandbox_Status_Archive.md)

**HOK Vertical Slice - IN PROGRESS** - See `HOK/Documents/HOK_Status.md` for full milestone progress, fishing system details, and scene status.

**Environment Art Pipeline - IN PROGRESS** - Low Poly Modular Terrain Pack (Approved - 5,062 FBX, cave modules, snap-together). Low Poly Rocks Pack (Approved - 1,045 meshes, crystals for Styx). Environment/Weather/Nature VFX Pack (Conditional - BiRP shaders need URP conversion, ~40% cave-usable). Same publisher for terrain + rocks (JustCreate) ensures style consistency.

**HOK Design Phase - COMPLETE** - Research complete (5 docs). GDD v1.6 written. All 41 design decisions locked (see GDD Sec. 11). Full details in HOK design docs.

**River Acheron Scene Build - COMPLETE** - Acheron greybox done. 5 zones (X=0 to X=500), 291 renderers, 82 inner cliff walls. See HOK_Status.md.

---

## Reference Documents

### Sandbox Documents

| Document | Path | Purpose |
|----------|------|---------|
| **Asset Log** | `Sandbox_AssetLog.md` | **PRIMARY** - All asset evaluations |
| **Asset Log Archive** | `Sandbox_AssetLog_Archive.md` | Detailed entries from completed evaluation phases |
| **Troubleshooting** | `Sandbox_Troubleshooting.md` | Process-driven issue investigation |
| **Troubleshooting Archive** | `Sandbox_Troubleshooting_Archive.md` | Resolved investigations |
| **Status Archive** | `Sandbox_Status_Archive.md` | Old sessions, versions, completed experiments |

### HOK Documents (at `Documents/HOK/Documents/`)

| Document | Purpose |
|----------|---------|
| **HOK_Status.md** | HOK development status, architecture, milestones, lessons |
| **HOK_CodeReference.md** | Full API reference for all HOK scripts |
| **HOK_Troubleshooting.md** | HOK-specific issue investigation |
| **HOK_Refactor.md** | Refactoring guidelines, SOLID, codebase inventory |
| **HOK_Status_Archive.md** | Archived HOK sessions and milestones |
| **HOK_Troubleshooting_Archive.md** | Archived HOK investigations |
| **HOK_GDD.md** | **PRIMARY** - Game vision, pillars, core loop, 41 locked decisions |
| **HOK_Art_AssetList.md** | Art team handoff, placeholder tracking |
| **HOK_Migration_Manifest.md** | Migration tiers for project breakout |
| **Acheron_SceneLayout.md** | 5-zone layout, prefab assignments |
| Research docs | Five Rivers, Kharon, Bake-Danuki, Creatures, Merchants, Ferry, Mythology |
| HOK Prototype (Archived) | `Archives/HOK_Status.md`, `Archives/HOK_CodeReference.md` |

---

## AI Rules (Inherited from HOK)

### Critical Protocols
1. **Verify names exist** - search before referencing files/methods/classes
2. **Step-by-step verification** - one step at a time, wait for confirmation
3. **Read before editing** - always read files before modifying
4. **ASCII only** - no smart quotes, em-dashes, or special characters
5. **Validate after MCP edits** - run validate_script to catch syntax errors
6. **Use E: drive path** - never worktree paths
7. **Be direct** - give honest assessments, don't sugar-coat
8. **Acknowledge gaps** - say explicitly when something is missing or unclear

### Sandbox-Specific Rules
9. **Log every evaluation** - any asset tested must get an entry in Sandbox_AssetLog.md
10. **Note HOK applicability** - every evaluation should state whether the asset is suitable for HOK and why
11. **Test with production standards** - even throwaway test code should follow coding standards, since that's what we're evaluating compatibility with

---

## Cross-Project Reference

**All TecVooDoo projects:** `E:\TecVooDoo\Projects\Documents\TecVooDoo_Projects.csv`
**HOK Development Status:** `E:\Unity\Sandbox\Documents\HOK\Documents\HOK_Status.md`
**HOK Old Prototype:** `E:\Unity\Hooked On Kharon`

---

## Session Close Checklist

After each work session, update this document:

- [ ] Update "Last Session" date and summary (if applicable)
- [ ] Ensure all tested assets are logged in Sandbox_AssetLog.md
- [ ] Update package lists if any were added/removed
- [ ] Increment version number in header
- [ ] Archive version history entries beyond the 9 most recent
- [ ] Archive session summaries beyond Last + 3 most recent Previous sessions
- [ ] Archive completed experiment sections when marked COMPLETE
- [ ] Move finalized ENTRY details to AssetLog Archive when their evaluation phase completes

---

## Version History

| Version | Date | Summary |
|---------|------|---------|
| 44 | Feb 14, 2026 | Session 37: HOK documentation restructuring. Created 6 HOK docs (Status, CodeReference, Troubleshooting, Refactor, Status Archive, Troubleshooting Archive). Migrated HOK content (spatial convention, architecture, folder structure, vertical slice details) to HOK_Status.md. Sandbox_Status slimmed from ~514 to ~390 lines. Reference Documents split into Sandbox + HOK sections. |
| 40 | Feb 13, 2026 | Session 34: Milestone 3 scene wiring + play-test fixes. Old Kharon deleted, Kharon_Fisher wired. Line sag fix. Double-bite fix. Bait flow corrected. |
| 35 | Feb 12, 2026 | Session 29: Asset evaluation. NuGetForUnity rejected (ENTRY-065). Unity-Technologies sweep (ENTRY-066-072). ML-Agents v4.0.2. Cysharp sweep (ENTRY-073-082). 82 total entries. |
| 34 | Feb 12, 2026 | Session 28: River Acheron scene build. Gorge wall clipping fixed. 82 inner cliff walls. |
| 33 | Feb 11, 2026 | Session 27 (continued): AI-Animation and AI-ParticleSystem evaluation. Both Conditional. |
| 32 | Feb 11, 2026 | Session 27: Full IvanMurzak GitHub sweep (54 repos). 3 new entries (ENTRY-062-064). 64 total entries. |
| 31 | Feb 11, 2026 | Session 26 (continued): MCP capability re-audit. DA PolyPaint scriptable. HOK MCP tools asmdef created. |
| 30 | Feb 11, 2026 | Session 26: AI-ProBuilder evaluation. 13 tools verified. ENTRY-055 upgraded to Conditional. |
| 29 | Feb 11, 2026 | Session 25: Ivan Murzak ecosystem complete. ENTRY-056 (MCP for Unity, Approved - Default). 61 total entries. |
*(v28 and earlier archived to Sandbox_Status_Archive.md)*

---

**End of Project Status**
