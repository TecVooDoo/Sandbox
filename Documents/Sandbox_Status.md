# Sandbox - Project Status

**Project:** Sandbox (Asset Evaluation Environment)
**Developer:** TecVooDoo LLC / Rune (Stephen Brandon)
**Unity Version:** 6000.3.10f1 (Unity 6, URP)
**Project Path:** `E:\Unity\Sandbox`
**Document Version:** Reconstructed Feb 23, 2026 (after data loss)
**Last Updated:** March 28, 2026 (Session 61)

> **NOTE:** This document was reconstructed after the Sandbox project became corrupt on Feb 23, 2026. Content recovered from session context and MEMORY.md.

> **ARCHIVE RULE:** This doc holds only the current state and last ~2 sessions. When adding a new session, move older entries to `Sandbox_StatusArchive.md` (newest first at top of archive). This keeps the status doc fast to read while preserving full history.

---

## Purpose

Sandbox is a dedicated asset evaluation environment for ALL TecVooDoo projects. It is NOT a game project. Assets are imported, tested, and evaluated here before being used in actual projects (HOK, DLYH, FearSteez, etc.).

**Primary output:** `Sandbox_AssetLog.md` -- 291 asset evaluations as of Session 57.

**Reference doc:** `Sandbox_DevReference.md` -- coding standards, MCP gotchas, eval standards, AI rules. Read on demand.

---

## Session 60 (Mar 20, 2026) -- MCP Tools Session 4: Evals + Build

**Status:** MCP controllability evals for 13 assets + built 7 new tool groups (36 tools). Package now at v1.3.0 with ~126 tools across 24 groups.

**MCP Evals Completed:**
- **Candidates built:** DOTween Pro (4), Behavior Designer Pro (4), SensorToolkit 2 (5), UCC (5), A* Pathfinding Pro (6), Master Audio 2024 (6), Dialogue System for Unity (6)
- **Deferred:** GOAP v3 (Medium, revisit when adopted), Breeze (Medium-High, revisit when adopted)
- **Not candidates:** BD Senses Pack (task nodes), Procedural Dialogue Addon (auto-hooks), Follow & Protect Agent (ML black box, removed due to missing ml-agents dependency)
- **Also evaluated:** GOAP v3 3.1.1, Breeze 1.0.2, Follow & Protect Agent 1.0 (first evals for all three)

**Tools Built (36 new):** Master Audio (6: ma-query/play/group-control/bus-control/playlist/configure-ducking), A* Pathfinding (6: astar-query/configure-grid/configure-recast/configure-agent/scan/configure-seeker), Dialogue System (6: ds-query/conversation/quest/variable/bark/lua), SensorToolkit 2 (5: sensor-query/add-range/add-los/configure-steering/query-detections), UCC (5: uc-query/configure-locomotion/ability-control/configure-attribute/item-control), Behavior Designer (4: bd-query/set-variable/control/list-trees), DOTween Pro (4: dotween-query/add-animation/play/global).

**Compile fixes:** BD Pro tools rewritten against actual v2.x API after agents assumed v1.x methods. Lesson learned: agents must verify actual source before writing code.

**Key lesson saved to memory:** Never assume any API -- always verify against actual installed source code before writing code or making claims.

**ECS/DOTS tools (Session 4b):** Unity Entities (5 tools: ecs-query-worlds/query-entities/inspect-entity/modify-entity/create-destroy) + Unity Physics (4 tools: uphys-query/configure-body/configure-step/configure-shape). Package at v1.4.0, ~135 tools across 26 groups.

---

## Session 61 (Mar 28, 2026) -- Infrastructure Standardization

**Status:** Cross-project infrastructure audit and standardization. MCP configs, permissions, docs, and package management unified across all active projects.

**Session 61 Work:**

*AQS Snake AC Experiment (parked) + Raccoon Belly Weapon:*
- Snake AC experiment parked -- IsPending blocker, enemies don't need Malbers AC.
- Raccoon_Weapon_Test created from PA Player prefab. Belly weapon system wired: Belly_WeaponPoint on Spine1, Belly_Weapon_Test prefab (Bolt projectile), MWeaponManager configured, Pistol mode (ID=300) added. Weapon equips successfully. LMB routing still blocked (Attack1 melee intercepts) -- same issue from rabbit Session 8. Next session: fix input routing.

*MCP Connection Standardization:*
- Created `MCP_ConnectionBrief.md` -- complete reference for MCP setup across all projects.
- Audited all 8 projects: fixed FearSteez port collision (54815 -> 59431), fixed missing `authorization=none`, fixed backslashes, created missing `.claude/mcp.json` for AudioProject.
- Added Blender MCP (`uvx blender-mcp`, port 9876) to all projects: Sandbox, HOK, FearSteez, SpaceSucks, AudioProject, AnimationProject.
- Port registry documented: Sandbox=54815, FearSteez=59431, HOK=54111, AudioProject=50774, AnimationProject=52516, SpaceSucks=29794, DLYH=51240.
- MCP plugin updated to v0.62.0. Documented v0.61.0+ behavior change (tools surface as skills/deferred tools).

*Global Permissions Cleanup:*
- Cleaned global `~/.claude/settings.json`: removed 12 redundant individual MCP entries (covered by `mcp__*` wildcard).
- Added all 8 active projects to `additionalDirectories`.

*Package Management:*
- Switched UniTask from local file to OpenUPM (`com.cysharp.unitask` v2.5.10).
- Switched Image Loader from local file to OpenUPM (`extensions.unity.imageloader` v7.0.1).
- Switched Unity Theme from local file to OpenUPM (`extensions.unity.theme` v4.2.0).
- Added `com.cysharp.unitask` to OpenUPM scoped registry.

*New Project Setup Brief:*
- Created `NewProjectSetup_Brief.md` -- standard setup checklist for any new TecVooDoo Unity project.
- Covers: OpenUPM registry, package install order (with dependency chains), MCP setup, folder structure, doc structure, asset evaluation workflow, coding conventions, source control.
- References Sandbox AssetLog as single source of truth for all asset evaluations.

*Status Doc Archive System:*
- Created StatusArchive files for 4 projects: Sandbox (571 lines), AQS (360 lines), AudioProject (600 lines), AnimationProject (stub).
- Trimmed status docs: Sandbox 665->104, AQS 561->211, AudioProject 782->192.
- Added ARCHIVE RULE instruction to all 4 status docs so future sessions maintain the pattern.
- Updated NewProjectSetup_Brief.md with StatusArchive pattern documentation.

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
