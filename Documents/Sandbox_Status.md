# Sandbox - Project Status

**Project:** Sandbox (Asset Evaluation Environment)
**Developer:** TecVooDoo LLC / Rune (Stephen Brandon)
**Unity Version:** 6000.3.10f1 (Unity 6, URP)
**Project Path:** `E:\Unity\Sandbox`
**Document Version:** Reconstructed Feb 23, 2026 (after data loss)
**Last Updated:** April 3, 2026 (Session 66)

> **NOTE:** This document was reconstructed after the Sandbox project became corrupt on Feb 23, 2026. Content recovered from session context and MEMORY.md.

> **ARCHIVE RULE:** This doc holds only the current state and last ~2 sessions. When adding a new session, move older entries to `Sandbox_StatusArchive.md` (newest first at top of archive). This keeps the status doc fast to read while preserving full history.

---

## Purpose

Sandbox is a dedicated asset evaluation environment AND game incubator for ALL TecVooDoo projects. Assets are imported, tested, and evaluated here before being used in actual projects. New game projects bootstrap here with on-demand asset loading, then migrate to standalone when proven.

**Primary output:** `Sandbox_AssetLog.md` -- 315 asset evaluations as of Session 63.

**Reference doc:** `Sandbox_DevReference.md` -- coding standards, MCP gotchas, eval standards, AI rules. Read on demand.

---

## Session 66 (Apr 3, 2026) -- HNR Migration, TecVooDoo Project, Sandbox Rebuild, Soul Minor

**Status:** Massive infrastructure session. HNR migrated to standalone. TecVooDoo project created. Sandbox rebuilt from scratch (fresh project, lean packages). Soul Minor chosen as next jumpstart.

**HNR Migration COMPLETE:**
- HNR standalone at `E:\Unity\HideNReap` (Unity 6, URP)
- 14 scripts migrated (GhostController, NPCLifecycle, PossessionSystem, BodyController, configs, etc.)
- All docs migrated, MCP configured, compiling clean
- Sprint 1 partially tested -- ghost movement + possess/exit works, body stand-up needs fix

**TecVooDoo Project Created:**
- `E:\Unity\TecVooDoo` -- dedicated TMCP/TVDGames/TVDUtilities development
- All TMCP-supported assets will be installed here (replacing Sandbox for that role)
- Docs: TVD_Status.md, TVD_DevReference.md
- TMCP define manager bug flagged as HIGH priority

**Sandbox Complete Rebuild:**
- Old Sandbox compile times: 15 min (692s script compilation + 100s domain reload)
- Diagnosed via Editor.log: 5,500+ .cs files from TMCP-supported assets
- Stripped ~3,220 .cs files, still 10 min due to domain reload / stale Library
- Nuclear option: deleted entire project, recreated fresh, copied back Documents + configs
- Fresh install: 11 packages (5 defaults + 6 QoL + infrastructure)
- MCP connected on port 24815
- Expected compile times: < 20s

**Asset Uninstall Log (from old Sandbox):**
- PurrNet: clean (locked empty folder)
- Dialogue System + addon: clean (TMCP define stuck, manual strip)
- Behavior Designer Pro + UCC: must uninstall together (shared Opsive folders)
- Feel: clean (TMCP define stuck, DLL locked folder)
- Final IK: clean (TMCP define stuck, wouldn't clear even after strip)
- AllIn1 3D Shader: clean
- Damage Numbers Pro: clean (DLL locked folder)

**TMCP Define Manager Bug (confirmed pattern):**
- Asset removal leaves `HAS_*` defines in ProjectSettings
- Compile errors prevent define manager from running to clean them up
- Every TMCP-supported asset removal requires manual define stripping
- Flagged in TecVooDoo TVD_Status.md as HIGH priority

**New Docs Created:**
- Eval_Guide.md (standalone eval methodology for all eval types)
- Sandbox_FreshInstall.md (minimal package list for fresh rebuild)
- NewProjectSetup_Brief.md updated (Auto Refresh disabled, editor preferences section)

**Soul Minor -- Next Jumpstart:**
- Concept revived from TecVooDoo Projects napkin entry
- Full concept doc at `E:\TecVooDoo\Projects\Games\1 Concepts\Soul Miner or Soul Minor\Documents\SoulMinor_Concept.md`
- GDD v1.0 + Status + DevReference + CodeReference created in `Documents\SoulMinor\`
- Idle Miner Tycoon structure (vertical shaft, three bottlenecks)
- Cute + gore identity (Happy Tree Friends meets IMT -- scythe bodies, blood + soul wisps)
- Mobile-first, portrait, 3D diorama. 8-12 week ship target.
- Chosen over Shift Happens: Nurse Edition (ships faster, teaches mobile)

**Shift Happens: Nurse Edition:**
- Concept doc created at `E:\TecVooDoo\Projects\Games\1 Concepts\Shift Happens Nurse Edition\Documents\ShiftHappens_Concept.md`
- Bomber Crew in a hospital. Career ladder, delegation, three task categories (work, training, BS from cat-driven admin)
- Edition model for franchise (Nurse -> Aircraft Maintenance -> Kitchen -> etc.)
- Deferred as follow-up project after Soul Minor ships

---

## Session 65 (Apr 1, 2026) -- Hide 'N Reap Bootstrap + TMCP Fix

**Status:** Hide 'N Reap bootstrapped as new Sandbox incubation project. TMCP stale defines bug fixed.

**Hide 'N Reap Bootstrap:**
- GDD v1.0 created (phase-driven competitive deception, 2.5D, 3-6 players)
- Folder structure: `Assets/_Sandbox/_HNR/` (Scripts, Art, Audio, Data, Prefabs, Scenes)
- Docs: Status, DevReference, CodeReference, StatusArchive, GDD
- 8 namespaces planned: Core, Player, Reaper, Ghost, Possession, NPC, Network, UI, Audio
- Sprint 1 priority: netcode evaluation (NGO vs FishNet vs Mirror)
- No packages installed yet -- on-demand per new Sandbox approach

**TMCP Stale Defines Fix:**
- Root cause: `MCPToolsDefineManager` added `HAS_*` defines but couldn't clean them when assets removed (compilation errors blocked domain reload)
- Fix: Added `RemoveStaleDefines()` method + `MCPToolsAssetPostprocessor` (`OnPostprocessAllAssets`) to catch deletions BEFORE recompilation
- Added `#if HAS_MALBERS_AC` guards to all 8 MalbersAC tool files
- Converted MalbersAC asmdef to GUID reference
- Manually removed stale defines from both Sandbox and AQS ProjectSettings
- Memory: `feedback_tmcp_stale_defines.md`

**NewProjectSetup_Brief.md updated:**
- 3-tier package structure: Default (15 packages) / Animation / Project-Specific

---

## Session 64 (Apr 1, 2026) -- AQS Migration + Sandbox Cleanup

**Status:** AQS migrated to standalone project at `E:\Unity\AQuokkaStory`. Sandbox bloat cleanup: ~735 MB removed.

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
