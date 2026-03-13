# Asset Inventory - Project Status

**Project:** Asset Inventory (Asset Library Management)
**Developer:** TecVooDoo LLC / Rune (Stephen Brandon)
**Unity Version:** 6000.3.7f1 (Unity 6, URP)
**Project Path:** `E:\Unity\AssetInventoryProject`
**Last Updated:** March 4, 2026 (Session 3)

> **STATUS:** Asset Inventory 4 has been evaluated (Sandbox ENTRY-252, Default label). The dedicated project model is OBSOLETE. AI4 should be installed in every active project using the shared config approach. This project can be archived once confirmed working from Sandbox.

**Reference doc:** `AInv_Reference.md` (settings, database, workflows)

---

## Purpose

This project manages the asset library using Asset Inventory 3. It is NOT for evaluating assets (that is Sandbox's job) and NOT a game project.

**What this project does:**
- Index and search all purchased/downloaded Unity assets
- Extract individual files from packages into game projects
- Tag and organize the asset library
- Track asset metadata, versions, and compatibility

**What this project does NOT do:**
- Evaluate asset quality (use Sandbox: `E:\Unity\Sandbox`)
- Test assets in scenes (use Sandbox)
- Track per-game asset recommendations (use Sandbox's `Sandbox_AssetLog.md`)

---

## Current Work

**MCP status:** Installed (v0.48.1), configured for Claude Code. Port 54430.

**Database status:** Rebuilt and healthy. 268MB database, 2,331 assets indexed (Feb 24).

**Rebuild results (Feb 24):**
- 2,331 total assets (2,162 unique names)
- By source: 1,623 Asset Store, 355 Custom Packages, 353 Registry Packages
- 530 extracted packages, 1,755 previews
- 54 "duplicate" names are legitimate nested sub-packages (e.g., each MagicPigGames character pack embeds the same shader sub-packages, each Synty pack embeds URP_ExtractMe). No config-driven duplication.
- Export: `E:\Unity\03UnityAssetInventory\Documents\assets02242026.csv`

---

## Sessions

**Session 1 (Feb 23, 2026):** Project setup for Claude Code. Installed Unity-MCP (v0.48.1) via OpenUPM. Created MCP config files (`.mcp.json`, `.vscode/mcp.json`, `.claude/settings.local.json`). Removed obsolete AIBridge scripts and `ClaudeAssetInventory/` folder. Added `com.tecvoodoo.utilities`. Identified database duplication -- root causes: (1) Package Cache pointing to Asset Store path instead of UPM cache, (2) Unity Packages + Media Folder both scanning same `E:/Game Assets` root, (3) stale entries from multiple config changes over time. Fixed Package Cache Location. Fixed Cache/Extracted location. Moved audio to `E:/GameAssetsAudio`. Set up 3 Additional Folders (Game Assets Unity Packages, Game Assets All Media, GameAssetsAudio Audio). Turned OFF Extract Colors, turned ON Index Package Cache, turned OFF Download New. Wiped database + Extracted + Previews for clean rebuild. Found two config files (OneDrive active, NitroDadFiles stale) due to C: drive space migration. Replaced old doc system with new two-doc + memory system. Deleted old `AssetInventoryProject_Status.md`. Started full reindex.

**Session 3 (Mar 4, 2026):** Asset Inventory 4 released and evaluated (Sandbox ENTRY-252). Key upgrades over v3: URP auto-adapter, Project Window toolbar, custom preview pipeline, animation preview. Shared database confirmed viable -- external SQLite at `E:\Unity\03UnityAssetInventory\Documents\AssetInventory` works across any project with ASSETINVENTORY_CONFIG_PATH set. Dedicated project model obsolete. AI4 is now a Default label asset for all TecVooDoo projects. Stats as of this session: 2,652 packages, 1,257/2,219 indexed, 332.4 MB database.

**Session 2 (Feb 24, 2026):** Verified rebuild completed overnight. 2,331 assets indexed (268MB database). No config-driven duplication -- 54 duplicate names are legitimate nested sub-packages. Exported `assets02242026.csv`. Updated status docs.

---

## Known Issues

| Issue | Severity | Status | Notes |
|-------|----------|--------|-------|
| Database duplication | High | Resolved | Rebuild clean. 54 "duplicate" names are nested sub-packages, not config duplication. |
| Scattered config files | Low | Documented | Active: OneDrive. Stale: NitroDadFiles. C: drive space migration caused scatter. |

---

## Installed Packages

### Third-Party
| Package | Version | Source | Notes |
|---------|---------|--------|-------|
| Asset Inventory 3 | 3.6.1+ | Asset Store | Core project asset |
| Unity-MCP / AI Game Developer | 0.48.1 | OpenUPM | Claude Code integration |
| TecVooDoo Utilities | 1.0.0 | Local | Shared utility package |

### Unity (Key Packages)
URP 17.3.0, Input System 1.18.0, AI Navigation 2.0.11, Timeline 1.8.10, Visual Scripting 1.9.9, Shader Graph 17.3.0, Vector Graphics 3.0.0-preview.7, 2D Enhancers 1.0.0

---

## Session Close Checklist

- [ ] Update session summary (1-2 lines)
- [ ] Update known issues if changed
- [ ] Update `AInv_Reference.md` if settings changed
- [ ] Update MEMORY.md if lessons learned

---

**End of Project Status**
