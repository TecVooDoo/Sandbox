# Sandbox - Project Status

**Project:** Sandbox (Asset Evaluation Environment)
**Developer:** TecVooDoo LLC / Rune (Stephen Brandon)
**Unity Version:** 6000.3.10f1 (Unity 6, URP)
**Project Path:** `E:\Unity\Sandbox`
**Document Version:** Reconstructed Feb 23, 2026 (after data loss)
**Last Updated:** April 25, 2026 (Session 79)

> **NOTE:** This document was reconstructed after the Sandbox project became corrupt on Feb 23, 2026. Content recovered from session context and MEMORY.md.

> **ARCHIVE RULE:** This doc holds only the current state and last ~2 sessions. When adding a new session, move older entries to `Sandbox_StatusArchive.md` (newest first at top of archive). This keeps the status doc fast to read while preserving full history.

---

## Purpose

Sandbox is a dedicated asset evaluation environment AND game incubator for ALL TecVooDoo projects. Assets are imported, tested, and evaluated here before being used in actual projects. New game projects bootstrap here with on-demand asset loading, then migrate to standalone when proven.

**Primary output:** `Sandbox_AssetLog.md` -- 337 asset evaluations as of Session 78.

**Reference doc:** `Sandbox_DevReference.md` -- coding standards, MCP gotchas, eval standards, AI rules. Read on demand.

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

## Session 78 (Apr 21, 2026) -- Asset Evals: 8-Entry Eval Marathon (ENTRY-330 through 337)

**Status:** Eight new asset evaluations. Physics authoring, UI skin, stylized post-processing, interaction framework, standalone chess game, forest-animal content, and stylized weather. Four MCP candidates queued (`tcc`, `mkedge`, `pe`, `cozy`).

**New Evals (8):**

| ENTRY | Asset | Verdict | Highlights |
|-------|-------|---------|------------|
| 330 | Technie Collider Creator 2 (Triangular Pixels) | **Approved, Recommended** | Paint-based collider authoring + VHACD auto-decomp. 7 hull types. Pipeline-agnostic output. Scriptable API via `RigidColliderCreatorWindow`. MCP: **High** -- 6-7 tools proposed for new `tcc` group |
| 331 | Synty InterfaceCore | Approved | Required dependency for any Synty Interface pack. 3 UI scripts (ported from Unity UI Extensions), 4 UI shaders, 514 master sprites. No standalone value. MCP: N/A |
| 332 | Synty InterfaceDarkFantasyHUD | **Approved, Recommended** | 317 prefabs across 20 categories, 6 pre-made HUD screens (1st/3rd-person, ARPG x2, SoulsLike, Survival), 1,671 sprites, 35 demo scenes, 2 SDF fonts. Already in use in Blood Miner. MCP: covered by existing generic tools |
| 333 | MK Edge Detection (Michael Kremmel) | **Approved, Recommended** | Screen-space edge detection / outline / sketch post-processing. **5 pipeline flavors** (BiRP ImageEffects, PPSv2, URP RendererFeature, URP VolumeComponent, HDRP VolumeComponent). 36 parameters, RenderGraph-ready on Unity 6. Strong lookdev fit for HOK, FS, HnR, VNPC, M3. MCP: **High** -- 4 tools proposed for new `mkedge` group |
| 334 | PressE PRO 2 (Fast Studios) | **Approved, Recommended** | "Press E to interact" framework. Interactable / InteractionManager / Key / Condition / Lerp helpers / 4 prompt templates. Strong fit for HOK, HnR. MCP: **Medium-High** -- 4 tools proposed for new `pe` group |
| 335 | The Coolest Chess (Freedom Developer) | Approved | Complete chess game w/ 2 native AI tiers + Stockfish integration (WebGL bundled, desktop user-provides). PGN parsing + corpus, puzzle editor, 9 scenes, 177 scripts, 7 asmdefs, shipped unit tests. Narrow use case (chess minigame / standalone). MCP: **Low-Medium**, no tools queued |
| 336 | Poly Art: Animal Forest Set (Malbers Animations) | **Approved, Recommended** | 10 forest animals (Bear/Boar/Cougar/Deer/Fox/Moose/Rabbit/Raccoon/Tiger/Wolf), AC-ready prefabs + per-animal demo scenes. 134 FBX, 52 prefabs. Strong fit for AQS + HideNReap. MCP: **N/A** -- fully covered by existing `ac-*` tool group |
| 337 | COZY 3: Stylized Weather (Distant Lands) | **Approved, Recommended** | UPM pkg v3.6.17. Modular weather/atmosphere/time-of-day/biome system. 76 runtime scripts, 17 modules, 8 profile SOs, 12 FX types, 11 stylized cloud/fog shaders (Ghibli/Luxury/Painted Skies/etc.), 5 sample packs, URP+HDRP+BiRP support. Strong fit for HOK, AQS, HideNReap, M3, SetDesign. MCP: **Medium-High** -- 5 tools proposed for new `cozy` group |

**TMCP Candidates Queued:**
- **`tcc` group (ENTRY-330):** 6-7 tools -- `tcc-create`, `tcc-add-hull`, `tcc-generate`, `tcc-configure-vhacd`, `tcc-bulk`, `tcc-query`, `tcc-delete-generated` -- **shipped** (visible as `tcc-*` in the available TMCP toolset this session)
- **`mkedge` group (ENTRY-333):** 4 tools -- `mkedge-configure`, `mkedge-query`, `mkedge-preset` (shipped named presets: comic / sketch / blueprint / souls-like / etc.), `mkedge-toggle`
- **`pe` group (ENTRY-334):** 4 tools -- `pe-create-interactable`, `pe-configure-interactable`, `pe-create-grabbable`, `pe-query`
- **`cozy` group (ENTRY-337):** 5 tools -- `cozy-query`, `cozy-set-weather`, `cozy-set-time`, `cozy-configure-module`, `cozy-set-biome`

Remaining (mkedge + pe + cozy) implementation deferred to TecVooDoo project.

**Compile fixes applied this session (for COZY install):**
1. `Packages/manifest.json` -- added `com.unity.modules.wind` (`UnityEngine.WindZone` dependency for `CozyWindModule`).
2. `ProjectSettings/ProjectSettings.asset:862` -- added `COZY_URP` define and removed stale `UNITY_POST_PROCESSING_STACK_V2` (the package wasn't installed; `VisualFX.cs` took the URP branch correctly after the swap). Other platform targets still have PPSv2 defined -- clean up on build-target switch.

**Assets currently in project (post-eval state):**
- **Retained:** Technie Collider Creator 2 (user request), Synty InterfaceCore + InterfaceDarkFantasyHUD (Blood Miner active use)
- **Removed post-eval:** MK Edge Detection, PressE PRO 2, The Coolest Chess, Poly Art: Animal Forest Set, COZY 3: Stylized Weather. All five are Approved (four Recommended) and should be re-imported when their target project/use case is in scope.
- **Compile-fix residue left in project after Cozy uninstall:** `com.unity.modules.wind` in `manifest.json` (harmless — generic Unity module), `COZY_URP` scripting define in `ProjectSettings.asset:862` (harmless — unused when Cozy is absent), and **stale `UNITY_POST_PROCESSING_STACK_V2` remains removed from Standalone** (clean-up, correct to leave removed since `com.unity.postprocessing` is not installed).

**Docs Updated:** `Sandbox_AssetLog.md` (10 new summary rows 328-337 + 8 new detailed entries), `Sandbox_Status.md` (this).

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
