# Sandbox - Project Status

**Project:** Sandbox (Asset Evaluation Environment)
**Developer:** TecVooDoo LLC / Rune (Stephen Brandon)
**Unity Version:** 6000.3.10f1 (Unity 6, URP)
**Project Path:** `E:\Unity\Sandbox`
**Document Version:** Reconstructed Feb 23, 2026 (after data loss)
**Last Updated:** April 11, 2026 (Session 74)

> **NOTE:** This document was reconstructed after the Sandbox project became corrupt on Feb 23, 2026. Content recovered from session context and MEMORY.md.

> **ARCHIVE RULE:** This doc holds only the current state and last ~2 sessions. When adding a new session, move older entries to `Sandbox_StatusArchive.md` (newest first at top of archive). This keeps the status doc fast to read while preserving full history.

---

## Purpose

Sandbox is a dedicated asset evaluation environment AND game incubator for ALL TecVooDoo projects. Assets are imported, tested, and evaluated here before being used in actual projects. New game projects bootstrap here with on-demand asset loading, then migrate to standalone when proven.

**Primary output:** `Sandbox_AssetLog.md` -- 327 asset evaluations as of Session 72.

**Reference doc:** `Sandbox_DevReference.md` -- coding standards, MCP gotchas, eval standards, AI rules. Read on demand.

---

## Session 74 (Apr 11, 2026) -- Soul Minor: Design Pivot, GDD v2.0

**Status:** Design pivot. Sprint 1 playtest revealed the IMT three-bottleneck framing wasn't landing visually or conceptually. Rebuilt the design around a row-based body processing factory. GDD v2.0 written, rebuild plan drafted. No code changes yet -- next session starts Phase 1 scaffolding.

**What changed in v2.0:**
- Mine/Elevator/Warehouse -> Rows/Pipes/Gatherers
- Rank system (8 ranks) -> removed (descent itself is progression)
- Zones -> removed (single continuous shaft)
- Mythology/fiction framing -> dropped ("forget the why, it just happens")
- Reaper is still the player avatar but moves down manually, one-way, never returns up
- Blood bar on each row's floor fills with chops; tool upgrade button appears when full
- Gatherers (max 10) with speed/carry-tier upgrades feed bodies into a funnel

**Keep from Sprint 1:** SoulManager, GameEvent system, NumberPop, ComboSystem, SaveManager (ES3), BodyConfigSO, body prefabs, KayKit art, UI click-through fix, UpgradeSystem math

**Delete after new scene playable:** MineLevel, Elevator, Warehouse, RankSystem, 8 RankConfigSOs, ZoneConfigSO, SM_ShallowGraves.unity

**New docs:**
- `Documents/SoulMinor/GDD/SM_GDD.md` v2.0 -- full rewrite of sections 2-17
- `Documents/SoulMinor/SM_RebuildPlan.md` -- keep/adapt/delete tables, 8-phase build order, scene hierarchy + UI layout targets

**Next Session (75) -- Sprint 2 Phase 1:**
- Create `SM_Shaft.unity` scene
- Create `SM.Shaft` and `SM.Gatherer` namespaces
- Write stub scripts per rebuild plan
- First milestone: single row vertical slice (Phase 2)

---

## Session 73 (Apr 10, 2026) -- Soul Minor: Environment, Save/Load, Ranks, UI

**Status:** Soul Minor Sprint 1 core complete and stable. Tap loop works end-to-end with persistence, 8 ranks, visible upgrade feedback, and fixed UI click-through. Three-bottleneck pipeline deferred to Sprint 2 per user preference.

**Environment Rebuild (SM_ShallowGraves):**
- Rebuilt shaft with correct 2u block spacing (KayKit Block Bits are 2.09u, not 1u)
- Added overlap scanner tool: script-execute iterates [Environment] AABBs and reports clipping pairs above threshold
- Iterated 341 -> 24 -> 12 -> 2 -> 0 overlaps
- Added surface ground, dead trees raised, bottom cap stone floor
- Removed vestigial InnerWalls that were clipping

**Soul Minor Systems Added/Fixed:**
- NumberPop VFX: pooled TextMesh world-space floating numbers, color-shifts on combo
- TapHarvester reads MineLevel.SoulYieldMultiplier -- Mine upgrades visibly change tap value
- Cute Pet Cat/Dog body prefabs (3x scale, Layer 6, animators stripped, URP/Lit materials)
- SaveManager Start() auto-load added (was only saving, never loading)
- SaveManager switched to Easy Save 3 (was PlayerPrefs fallback -- I was wrong about ES3 not being in project)
- SaveManager persists upgrade state (UpgradeSystem.RestoreState + ReapplyAllUpgrades on load)
- 6 new RankConfigSOs (Rank 2-7 from GDD) -- rank bar progresses naturally through all 8 ranks
- Removed Collect button (vestigial -- warehouse unused in direct flow)
- TapHarvester UI click-through fix: panel.Pick() checks before 3D raycast. Clicks on buttons no longer double-fire.

**Memory Added:**
- `feedback_kaykit_prop_orientation.md` -- KayKit directional props (skulls, gravestones) often need (0,180,0) rotation to face camera

**Commit tracking:**
- Session 70: NumberPop, upgrade feedback, Cute Pet bodies, environment dressing
- Session 73 (this): Environment rebuild, save/load, ranks, UI fixes

**Next Session:**
- Optional: connect three-bottleneck pipeline (Mine pending -> Elevator -> Warehouse -> Collect)
- Rank-up feedback UI (promotion letter popup)
- Pick character rank prefabs from KayKit Skeletons
- Body respawn tuning

---

## Session 72 (Apr 9, 2026) -- Humble Bundle + Backfill Evals

**Status:** Massive eval session. 11 new asset evals (ENTRY-317 through ENTRY-327), 1 TMCP addendum (Juicy Actions ENTRY-316), 3 backfill candidate lines (Long Bunny Labs ENTRY-146/255/256). New eval process rule: always include TMCP + TUtilities + TGames candidate assessments in main eval.

**New Evals (11):**
| ENTRY | Asset | Verdict | Highlights |
|-------|-------|---------|------------|
| 317 | Endless Book (echo17) | Approved | 3D animated book, state machine, per-page materials |
| 318 | Remo (CapyTools) | Approved | Remote runtime inspector, DLL-based |
| 319 | English Tracing Book (Indie Games Studio) | Conditional | Tracing pattern useful, code too coupled to extract |
| 320 | Game Launcher (Legend) | Conditional | Windows desktop launcher/patcher, no runtime value |
| 321 | Action Adventure Kit (SoftLeitner) | **Approved, Recommended** | 463 scripts, 62 interfaces, 13 decoupled systems. Best framework eval to date |
| 322 | Real Time Weather Pro (Assist Software) | Approved | 5 weather API providers, 7 sky/water adapters. MCP: High |
| 323 | Mesh to Terrain (Infinity Code) | Approved | Editor-only mesh-to-terrain conversion |
| 324 | Procedural UI (DTT) | Conditional | SDF rounded corners, BiRP-only shaders -- dealbreaker for URP |
| 325 | Lumen (Distant Lands) | Approved | Stylized mesh-based god rays/lights, URP-only, UPM package |
| 326 | Ultimate Terrain (Pampel Games) | **Approved, Recommended** | Burst-compiled terrain gen, 14 modules, runtime editing. MCP: High |
| 327 | Map Graph (Insane Scatterbrain) | Approved | Graph-based procedural 2D map gen (BSP, WFC, Voronoi, A*) |

**TMCP Addendum:** Juicy Actions (ENTRY-316) -- Medium-Low MCP. SO-asset workflow limits TMCP value. 2 tools proposed: `juicy-query`, `juicy-play`.

**Backfill Candidate Lines (3):** MudBun (146) MCP Medium, Squash & Stretch (255) MCP Low, Boing Kit (256) MCP Medium.

**Uninstall Notes:** DLL lock errors on Remo, RTW Pro, Juicy Actions, Game Launcher removal. English Tracing Book marked Do Not Use.

**Process Rule Added:** All evals now include TMCP + TUtilities + TGames candidate lines. Feedback memory saved.

**Docs Updated:** Sandbox_AssetLog.md (11 new entries + 4 addendums), Sandbox_Status.md, Sandbox_StatusArchive.md (Session 69 archived), feedback memory (eval_includes_tmcp.md)

---

## Session 71 (Apr 8, 2026) -- MCP Evals (Decal Collider + Texture Studio)

**Status:** MCP controllability evals for Decal Collider and Texture Studio. Driven by SetDesign graffiti/wall art need. Both assets temporarily installed for eval, then removed. Eval scene created at `Assets/_Sandbox/Evals/Scenes/EvalTestScene.unity` to isolate from SM project.

**MCP Evals Completed:**
- **Decal Collider (ENTRY-151)** -- Rating: **High**. Candidate for 3 tools: `decal-query`, `decal-configure`, `decal-rebuild`.
- **Texture Studio (ENTRY-142)** -- Rating: **Medium-High**. Candidate for 3 tools: `texstudio-query`, `texstudio-set-param`, `texstudio-render`.

**Tool builds deferred to TecVooDoo project.**

**AQS Migration COMPLETE:**
- AQS standalone at `E:\Unity\AQuokkaStory` (Unity 6, 6000.3.11f1, URP)
- GitHub: TecVooDoo/AQuokkaStory (private)
- All docs migrated, CLAUDE.md created, MCP configured
- Playtest confirmed working -- Sprint 1 complete, Sprint 2 starting
- Sandbox AQS docs archived to `Documents/Archives/AQuokkaStory/`

**Sandbox Cleanup (~735 MB removed):**
- `Assets/_Sandbox/_AQS/` (28 MB) -- migrated to standalone
- `Assets/2.5D Terrain/` (60 MB) -- evaluated (ENTRY-311), MCP tools built, removed
- `Assets/2.5D Looping/` (20 MB) -- evaluated (ENTRY-313), removed
- `Assets/BridgeBuilder2.5D/` (23 MB) -- evaluated (ENTRY-312), MCP tools built, removed
- `Assets/Suriyun/` (501 MB) -- evaluated (ENTRY-314), removed
- `Assets/Ghost and Shaders PRO/` (103 MB) -- evaluated (ENTRY-315), removed
- Orphaned settings assets (2.5DTerrainSettings, 2.5D Looping Settings) removed
- `QuokkaMom_ArtistPackage.zip` removed
- Export unitypackage removed

All removed assets can be reinstalled from Asset Store cache when needed for future evals.

**NewProjectSetup_Brief.md updated:**
- New 3-tier package structure: Default (15 packages) / Animation / Project-Specific
- Old monolithic default set replaced with minimum-install approach

---

## Session 63 (Mar 31, 2026) -- Asset Evals + TMCP 2.5D Tools

**Status:** 5 new asset evaluations (ENTRY-311 through 315). 7 new MCP tools built for Kamgam 2.5D Terrain and Bridge Builder. MCP plugin updated to v0.63.2.

**Asset Evaluations (5 new, 315 total):**

| # | Asset | Verdict | Key Finding |
|---|-------|---------|-------------|
| 311 | 2.5D Terrain 2.2.1 (Kamgam) | Approved | Spline-to-mesh pipeline with ClipperLib/Poly2Tri. Beveled terrain, 2D colliders, foliage scattering. HIGH MCP compatibility. AQS primary target. |
| 312 | 2.5D Bridge Builder 1.1.0 (Kamgam) | Approved | Destructible rope bridge with HingeJoint2D/SpringJoint2D chain, damage, proximity, checkpoint/reset. Uses Unity 6 API correctly. |
| 313 | 2.5D Looping 1.2.0 (Kamgam) | Conditional | Z-depth management for looping paths. Niche mechanic. Complex 7+ trigger setup. Import only when specifically needed. |
| 314 | Mega Cute Pet Zoo 3.3 (Suriyun) | Approved | 65 species, ~280 FBX, 191 prefabs. Low-poly cute animals + basic NavMesh AI. AQS animal source (Koala, Platypus, Kangaroo, Possum, Raccoon, Fox). |
| 315 | Ghost and Shaders PRO 1.0 (SR Studios) | Approved | Shader Graph ghost effect (URP), 100+ material presets, Fresnel+dual overlay+distortion. Build-breaking `using UnityEditor;` without guard. HOK underworld fit. |

**TMCP 2.5D Tools Built (7 new tools, 2 new groups):**

| Tool | What It Does |
|------|-------------|
| `terrain25d-query` | Full terrain state: mesh gen settings, collider, foliage, spline count |
| `terrain25d-configure-mesh` | 27 params: bevel, middle, erosion, snow, mesh properties, 3D collider |
| `terrain25d-generate` | Trigger mesh + optional collider/foliage generation |
| `bridge25d-query` | Full bridge state: physics, prefabs, parts, edges, proximity |
| `bridge25d-configure` | 19 params: physics, damage, visuals, broken-state physics |
| `bridge25d-control` | Actions: recreate, break, physics-on/off, add/remove proximity |

**MCP audit:** All prior candidate tool groups (37) already built. 2.5D Looping rated Low (no tools). Mega Cute Pet Zoo and Ghost Shaders PRO are art/shader assets (no tools needed).

**Package:** `com.tecvoodoo.mcp-tools` v1.5.0, ~184 tools across 39 groups. MCP plugin v0.63.2.

---

## Session 62 (Mar 30, 2026) -- BD Pro 3 Upgrade + TMCP Fix

**Status:** Behavior Designer Pro 2 removed, Pro 3.0.0 installed. TMCP tools updated for BD3 API. Asmdef crash bug fixed.

**Behavior Designer Pro 3 upgrade:**
- BD Pro 2.1.12 removed, BD Pro 3.0.0 installed via UPM (`com.opsive.behaviordesigner`).
- DOTS-powered: behavior trees run on ECS entities. MonoBehaviour API backward compatible with v2.

**TMCP BD tool updates (5 tools, was 4):**
- `bd-control` -- added `pause`/`unpause`/`resume` actions
- `bd-query` -- added UpdateMode, runtime state queries
- `bd-tick` -- NEW: manual tick for Manual update mode trees
- BD asmdef crash bug fixed (converted to `#if HAS_BEHAVIOR_DESIGNER` pattern)

---

## Evaluation Philosophy

- Evaluate for ALL TecVooDoo projects, not just HOK
- **Asset Store labels:** Default, Default 3D, Default Mobile, Default Audio, Default Audio Mobile, Default UI, Default uGUI, Default UI Audio, Don't Use
- Focus on: asset interactions, what Claude can do vs manual Unity work, replacement chains
- Ecosystem maps track cross-asset relationships by domain (in Sandbox_AssetLog.md)
- Small standalone utilities worth cherry-picking go into TecVooDoo Utilities

---

## Key Rules

1. **Never remove Odin Inspector/Validator** -- cascading errors. Leave it if installed.
2. **Chris West / Mega series import note** -- check for duplicate folder names (with/without hyphen). Older imports may leave a `Mega-Fiers` folder alongside new `MegaFiers`.
3. **Sandbox docs are at risk** -- they live inside the Unity project folder. Consider backing up to `E:\TecVooDoo\Projects\Documents\` after each session.
4. **MCP NuGet warnings** -- ~40 Microsoft/System packages always show warning icons due to MCP's NuGet dependency chain. This is normal.

---

## TecVooDoo Utilities Cherry-Pick Candidates

Now tracked in `Sandbox_AssetLog.md` -- TecVooDoo Utilities Candidates section (end of doc). Full docs at `E:\TecVooDoo\Projects\Other\TecVooDooUtilities\Documents\`.

---

## Reference Documents

| Document | Path |
|----------|------|
| Asset Log (291 entries) | `E:\Unity\Sandbox\Documents\Sandbox_AssetLog.md` |
| Dev Reference | `E:\Unity\Sandbox\Documents\Sandbox_DevReference.md` |
| HOK Status | `E:\Unity\HookedOnKharon\Documents\HOK_Status.md` |
| FearSteez Status | `E:\Unity\FearSteez\Documents\FS_Status.md` |
| TecVooDoo Utilities | `E:\TecVooDoo\Projects\Other\TecVooDooUtilities\Documents\TVU_Status.md` |
| TecVooDoo MCP Tools | `E:\TecVooDoo\Projects\Other\TecVooDooMCPTools\Documents\TMCP_Status.md` |
| TecVooDoo Projects | `E:\TecVooDoo\Projects\Documents\TecVooDoo_Projects.csv` |
| Archived project docs | `E:\Unity\Sandbox\Documents\Archives\` |
| Memory | `C:\Users\steph\.claude\projects\e--Unity-Sandbox\memory\MEMORY.md` |
| Session JSONL (Sess 35) | `C:\Users\steph\.claude\projects\e--Unity-Sandbox\99250266-b660-4ea0-88f0-61e5b98f52e1.jsonl` |

---

**End of Document**
