# Sandbox - Project Status

**Project:** Sandbox (Asset Evaluation Environment)
**Developer:** TecVooDoo LLC / Rune (Stephen Brandon)
**Unity Version:** 6000.3.10f1 (Unity 6, URP)
**Project Path:** `E:\Unity\Sandbox`
**Document Version:** Reconstructed Feb 23, 2026 (after data loss)
**Last Updated:** April 27, 2026 (Session 81)

> **NOTE:** This document was reconstructed after the Sandbox project became corrupt on Feb 23, 2026. Content recovered from session context and MEMORY.md.

> **ARCHIVE RULE:** This doc holds only the current state and last ~2 sessions. When adding a new session, move older entries to `Sandbox_StatusArchive.md` (newest first at top of archive). This keeps the status doc fast to read while preserving full history.

---

## Purpose

Sandbox is a dedicated asset evaluation environment AND game incubator for ALL TecVooDoo projects. Assets are imported, tested, and evaluated here before being used in actual projects. New game projects bootstrap here with on-demand asset loading, then migrate to standalone when proven.

**Primary output:** `Sandbox_AssetLog.md` -- 345 asset evaluations as of Session 81.

**Reference doc:** `Sandbox_DevReference.md` -- coding standards, MCP gotchas, eval standards, AI rules. Read on demand.

---

## Session 81 (Apr 27, 2026) -- Asset Evals: Modular 3D Text + Pipe Dream + Ultimate Preview + EasyPooling + ORK Framework (ENTRY-341 through 345)

**Status:** Five asset evaluations completed. Three were retroactive documentation of pre-existing installs (Pipe Dream Pack already in BM use, Ultimate Preview daily-driver, EasyPooling installed but unevaluated). Two were fresh installs this session (Modular 3D Text — installed during session, ORK Framework — installed mid-session).

**New Evals (5):**

| ENTRY | Asset | Verdict | Highlights |
|-------|-------|---------|------------|
| 341 | Modular 3D Text (Tiny Giant Studio) | **Approved, Recommended** | Mesh-based 3D text + UI controls (Buttons, Sliders, Toggles, Dropdowns, InputFields, Lists, HorizontalSelector). 85 bundled font assets, 16 demo scenes, Modules system (`AddPhysics` / `PlayParticles` / `ScaleChange` per character). All 3 RPs via packaged setup files (URP applied). Compilation green; 2 cosmetic warnings about publisher's own moved stylesheets. Strong fit for **VNPC** (3D dialog framing), **AQS** (stylized signs), **M3** (chapter cards), **HOK** (carved-stone inscriptions). Coexists cleanly with TMP (screen-space) and DamageNumbersPro (high-volume billboards). 538 MB Plugins + 45 MB Sample. **MCP: Medium-High** — `m3dt-*` group queued (6 tools) but defer until a project scripts runtime usage. |
| 342 | Pipe Dream Pack (One Potato Kingdom) | **Approved** | **Active in Blood Miner** — eval is retrospective documentation. 37 stylized pipe + valve + balloon + cap meshes, 37 URP materials, 222 textures, 1 demo scene. URP-only shaders (no BiRP/HDRP). Single utility `PipeShaker.cs` (47-line Perlin-noise shake component). 2 ShaderGraphs (Heat_Effect for refraction, Pipe_GrassWindShader for demo terrain). 371 MB total — most is demo-scene textures, prunable to ~70-100 MB at standalone migration. Niche art content; no Default/Recommended label. **MCP: N/A**. |
| 343 | Ultimate Preview (Voxel Labs) | **Approved, Default (QoL)** | **Daily-driver editor tool** — eval is retrospective documentation. v1.3.4. Replaces Unity's built-in asset preview window with rich camera/lighting/skybox/VFX/animator/grid controls. Harmony-injection-based (`VoxelLabs.Harmony.dll`) + 2 closed-source DLLs + small open-source `Lib/` helper layer. 40 MB editor-only footprint, zero runtime cost. Optional URP/HDRP PRO upgrade unitypackages ship unextracted. Should be on every TecVooDoo standalone project's standard install list alongside vHierarchy / vFolders. **MCP: N/A** — editor window. |
| 344 | EasyPooling 2025 (GUPS) | **Approved** | Source-based singleton pooling framework. `GlobalPool` (persistent), `AGamePool<T>` (abstract), named `BlueprintPoolDefinition` sub-pools, `EPoolingStrategy` (DEFAULT/FILL/GROW), `SpawnPolicy` + shapes (Box/EPlane) + random distributions (Uniform/Gaussian/PerlinNoise), `IDecorator`/`IUnDecorator` lifecycle hooks, `IPoolAble` interface (DefaultPoolAble shipped). Two demo scenes (BlackHole + Sun). 40 MB w/ demos. Strong fit for **BM** (body + VFX pool), **FearSteez** (zombies + projectiles), **HnR** (corpses + VFX). Already noted as Medium MCP candidate at line 10922 — `script-execute` adequate; not property-dense enough for dedicated tools. |
| 345 | ORK Framework 3.19.5 + Makinom 2.23 (Gaming Is Love) | **Approved, Recommended** | Canonical Asset Store RPG framework. **DLL-based with Pro source-code zips bundled** (full license install). 8 DLLs (4 runtime + 4 editor, ORK + Makinom split): ORK runtime 6.1 MB, Makinom runtime 2.4 MB. 45 component icons (24 Makinom + 21 ORK). Pipeline-agnostic. Editor window at `Window > Gaming Is Love > Makinom`. Combatants/Battles/Equipment/Items/Move AI/Battle Grids/Shops/Quests + Makinom schematic engine underneath. Best fit: **HOK** (boatman + soul cargo + optional combat). Selective-use fit: **VNPC** (inventory + quests alongside Dialogue System). Pairs deeply with Dialogue System (ENTRY-214), BD Pro (ENTRY-229), SensorToolkit, MasterAudio, FinalIK, Vefects, DNP. Frequent vendor updates (3.0 → 3.19.5 lifecycle), large community (forum.orkframework.com). **MCP: High** — `ork-*` group queued (7 tools) but defer until HOK or another project actively scripts ORK runtime calls. |

**Asset retention (post-eval):**
- **Modular 3D Text:** Retained in Sandbox for hands-on integration tests against VNPC/AQS use cases in subsequent sessions. Cherry-pick fonts at standalone migration.
- **Pipe Dream Pack:** Retained — referenced by BM body-pool prefab work. Cherry-pick to ~70-100 MB subset (drop demo textures, drop unused shader) at BM standalone migration.
- **Ultimate Preview:** Retained — daily-driver QoL.
- **EasyPooling:** Retained — reference framework for future BM/FearSteez/HnR optimization passes.
- **ORK Framework:** **Removed mid-session by user** before commit. ENTRY-345 captures the structural eval data (DLL listing, component surface, architecture, project fit) but the asset itself is no longer in the project. Re-import directly into HOK standalone when HOK enters its content-heavy phase. Install-residue: orphan folder `meta` files for `Assets/Gaming Is Love/`, `Assets/Gaming Is Love/Makinom 2/`, `Assets/Gaming Is Love/Makinom 2/DLL/` left untracked in the working tree (delete in a future hygiene pass or let Unity GC them on next refresh).

**TMCP Candidates Queued (this session):**
- **`m3dt` group (ENTRY-341):** 6 tools — `m3dt-query`, `m3dt-set-text`, `m3dt-configure`, `m3dt-add-module`, `m3dt-find-fonts`, `m3dt-create-control`.
- **`ork` group (ENTRY-345):** 7 tools — `ork-query-combatant`, `ork-modify-combatant`, `ork-inventory`, `ork-quest`, `ork-battle`, `ork-schematic-run`, `ork-database-query`.

Both groups defer build until a project actively uses runtime APIs.

**Docs Updated:** `Sandbox_AssetLog.md` (5 new summary rows + ENTRY-341 through 345 detailed entries), `Sandbox_Status.md` (this).

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
