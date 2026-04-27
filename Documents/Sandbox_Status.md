# Sandbox - Project Status

**Project:** Sandbox (Asset Evaluation Environment)
**Developer:** TecVooDoo LLC / Rune (Stephen Brandon)
**Unity Version:** 6000.3.10f1 (Unity 6, URP)
**Project Path:** `E:\Unity\Sandbox`
**Document Version:** Reconstructed Feb 23, 2026 (after data loss)
**Last Updated:** April 26, 2026 (Session 80)

> **NOTE:** This document was reconstructed after the Sandbox project became corrupt on Feb 23, 2026. Content recovered from session context and MEMORY.md.

> **ARCHIVE RULE:** This doc holds only the current state and last ~2 sessions. When adding a new session, move older entries to `Sandbox_StatusArchive.md` (newest first at top of archive). This keeps the status doc fast to read while preserving full history.

---

## Purpose

Sandbox is a dedicated asset evaluation environment AND game incubator for ALL TecVooDoo projects. Assets are imported, tested, and evaluated here before being used in actual projects. New game projects bootstrap here with on-demand asset loading, then migrate to standalone when proven.

**Primary output:** `Sandbox_AssetLog.md` -- 340 asset evaluations as of Session 80.

**Reference doc:** `Sandbox_DevReference.md` -- coding standards, MCP gotchas, eval standards, AI rules. Read on demand.

---

## Session 80 (Apr 26, 2026) -- Asset Evals: Blood VFX + CityGen3D (ENTRY-339, 340)

**Status:** Two asset evaluations completed. Blood VFX particle library (Vefects) and procedural city/world toolkit (CityGen3D, 2 GB). Second eval done autonomously while user was AFK.

**New Evals (2):**

| ENTRY | Asset | Verdict | Highlights |
|-------|-------|---------|------------|
| 339 | Vefects Blood VFX URP (Vefects) | **Approved, Recommended** | URP-native blood/impact library. 759 prefabs across 10 categories (Blood Drip, Blood Puddle, Decals, Wound Decals, Underwater Blood + Performance Versions of Bullet Hit / Bursts / Slashes / Splashes / Wounds). 12 color variants per category (default red + Blue/Brown/Censor/Cyan/Dark/Orange/Pink/Purple/Toxic/White/Yellow — Censor and Toxic stand out for content-rating toggles + non-blood reuse). Loop + Once modes for the perf categories. 15 hand-written URP shaders (ASE-built), 0 scripts (pure ParticleSystem prefabs), 7 WAV SFX, 2 demo scenes, 798 MB. **No pipeline swap needed.** Strong fit for BM (chop/arrival/cascade VFX), FearSteez, HideNReap, M3 episodes. Supersedes Real Blood (ENTRY-329) which can be deprecated. **MCP: Low** — covered by generic `assets-find` / `assets-prefab-instantiate` / `particle-system-modify`; optional `vefects-spawn` convenience deferred. |
| 340 | CityGen3D (Citygen Technologies) | **Approved, Recommended** | Enterprise procedural city generator. **2.0 GB on disk (largest eval to date).** DLL-based core (`CityGen3D.dll` 943 KB + `CityGen3D.EditorExtension.dll` 431 KB w/ shipped `.pdb` debug symbols), 13 .cs scripts (8 user-side + 5 ShaderPackager), 121 prefabs, 19 building blueprints, 121 materials, 13 `.citygenshader` packaged shaders, 3 demo scenes (BiRP/URP/HDRP), 5 Generator prefab variants. **All 3 pipelines via Jason Booth's ShaderPackager** (auto-detects active RP, no manual swap). 61 components in `CityGen3D.*` namespace. Real-world data import: **SRTM `.hgt` elevation tiles + Mapbox roads/buildings + GeoJSON coastlines** (sample UK SRTM tile + UK&Ireland coastline shipped). Floating origin support (`OriginManager`), chunked streaming (`LayerCulling`/`UnloadedLandscape`), GPU instancing (`DetailInstancer`/`TreeInstancer`). 11-module Generator hierarchy: Water/Highways/Heightmap/Generator/Entities/Features/Buildings/Detail/Splatmap/Roadside/Trees. **Strong fit for SetDesign + M3 episodes + FearSteez urban maps.** N/A for BM/HOK/AQS. Manual PDF (21 MB) unreadable in Claude tooling this session (pdftoppm missing) — eval is structural + DLL-reflection only. **MCP: Medium** — `cg` group queued (6 tools: `cg-generator-configure`, `cg-generate`, `cg-query-map`, `cg-find-road-at`, `cg-find-feature-at`, `cg-add-blueprint`); build deferred until SetDesign or M3 uses asset for a concrete task. |

**Asset retention (post-eval):**
- **Vefects Blood VFX URP:** Retained in Sandbox for Session 81+ deeper integration tests (BM impact-combo prototype + FearSteez kill-VFX wire-up). Marked for inclusion in BM standalone migration manifest (subset only — drop Underwater Blood + half the color variants if size budget tight).
- **CityGen3D:** **Removed at end of session** to reclaim 2.0 GB. Eval data in `Sandbox_AssetLog.md` ENTRY-340 is the reference snapshot. Re-import directly into SetDesign or M3 when a concrete environment task arrives.

**Install-residue after CityGen3D removal** (ships in this session's commits, documented + left in place):
- `Packages/manifest.json`: `com.unity.collections` 2.6.4 (generic utility, harmless), `com.unity.postprocessing` 3.5.1 (legacy PPSv2, unused by URP project, harmless).
- `Packages/packages-lock.json`: lock entries for the two packages above.
- `ProjectSettings/ProjectSettings.asset`: `UNITY_POST_PROCESSING_STACK_V2` scripting define added to Standalone, EmbeddedLinux, GameCoreScarlett, GameCoreXboxOne, Kepler, LinuxHeadlessSimulation, Nintendo Switch 2, PS5, QNX, VisionOS targets (consistent now that `com.unity.postprocessing` is installed; was the *inverse* drift from Session 78 which removed the define after COZY uninstall).

All three files auto-modified by Unity during CityGen3D import; not auto-reverted when the asset folder was deleted. Per Session 78 COZY-residue precedent: document + ship as-is, revertable in a future hygiene pass.

**TMCP Candidates Queued:**
- **`cg` group (ENTRY-340):** 6 tools — `cg-generator-configure`, `cg-generate`, `cg-query-map`, `cg-find-road-at`, `cg-find-feature-at`, `cg-add-blueprint`. Defer build until SetDesign / M3 is on a real task; setup is heavy (Mapbox API key, lat/lon selection, 11-module config) and wrapper value only emerges once a concrete workflow is in motion.

**PDF reader gap discovered this session:** `Read` tool failed on the CityGen3D 21 MB PDF manual (`pdftoppm not found`). All other inspection paths (DLL reflection via `gameobject-component-list-all`, scene probe via `scene-get-data`, prefab YAML via `Read`) worked. Workaround for future large-PDF evals: open PDF outside Claude, or rely on DLL reflection + filesystem inspection (sufficient for structural eval but misses workflow narrative).

**Docs Updated:** `Sandbox_AssetLog.md` (2 new summary rows + ENTRY-339 + ENTRY-340 detailed entries), `Sandbox_Status.md` (this), `Sandbox_StatusArchive.md` (Session 78 moved per archive rule).

---

## Session 79 (Apr 25, 2026) -- Asset Eval: RPG Monster Bundle Polyart (ENTRY-338)

**Status:** One asset eval (BM body-pool driver) and a session-cleanup pass — committed pile of Session 78 residue + new MCP infra + the new monster bundle as separate logical commits, then pushed.

**New Eval (1):**

| ENTRY | Asset | Verdict | Highlights |
|-------|-------|---------|------------|
| 338 | RPG Monster Bundle Polyart (Pxltiger) | **Approved, Conditional** | 30 stylized fantasy monsters (3 waves, 10 each: Skeleton/Slime/Dragon/Demon King/...). Per-monster animator + 14-17 anims. ~523 MB, 574 FBX, 83 prefabs. **Built-in RP shader** ships as default — `HDRP_URP/URP.zip` must be unpacked over `CommonStuffs/` before any URP render works. **BM fit:** body-pool expansion for rows 10+ + boss-coffin contents. Style-clash risk if used as Ghoul/ChopMinion (KayKit Skeleton already in those roles). MCP: N/A (covered by generic asset/animator/gameobject tools). |

**Session-cleanup pass:** Per new workflow rule (saved as `feedback_session_close_trigger.md` — "update docs as necessary" = doc updates + grouped commits + push), separated working tree into 4 commits: (1) Session 78 eval residue (8 evals + Cozy package wiring + retained Synty/Technie assets), (2) MCP/skills infra (mcp.json + tcc-* skills + MCP docs), (3) ENTRY-338 eval + asset import, (4) stragglers (_SM.meta delete, harmless BM_SaveManager.meta auto-rewrite, drifted Killers.mat). Then pushed to origin/master.

**Docs Updated:** `Sandbox_AssetLog.md` (1 new summary row + ENTRY-338 detailed entry), `Sandbox_Status.md` (this), `MEMORY.md` (added session-close trigger pointer + new feedback memory file).

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
