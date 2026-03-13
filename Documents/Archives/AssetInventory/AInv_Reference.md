# Asset Inventory - Reference

**Purpose:** Stable reference for Asset Inventory 3 configuration, database, and workflows. Read on demand, not every session.
**Last Updated:** February 24, 2026

---

## Asset Inventory 4

Version 4.x (Mar 2025). Evaluated Sandbox ENTRY-252. **Default label -- install in every TecVooDoo project.**

Upgraded from v3.6.1. Key v4 additions: URP auto-adapter (Adapt to Render Pipeline: Activate), Project Window toolbar, custom preview pipeline, animation preview, AI captions (optional).

### Multi-Project Shared Config (v4 Workflow)

The database is external and shared. Any project with AI4 installed + the env var set gets full access with no rebuild.

**Setup for a new project:**
1. Import Asset Inventory 4 from Asset Store
2. Set system env var: `ASSETINVENTORY_CONFIG_PATH=C:\Users\steph\OneDrive\Documents\AssetInventoryConfig.json`
3. Restart Unity
4. AI4 connects to the shared database -- no indexing required

**The dedicated AssetInventoryProject is now obsolete.** Archive it once Sandbox install is confirmed.

---

### Configuration File

AI3 uses a single JSON config file. The active config location is shown in Settings > Locations > Configuration.

**Active config:** `C:\Users\steph\OneDrive\Documents\AssetInventoryConfig.json`

**Stale config (older copy):** `E:\NitroDadFiles\Documents\AssetInventoryConfig.json` (Jan 11, 2026 -- predates the active one. Has 4 folders configured vs 2 in active, and has correct Package Cache path. Was the original location before C: drive space issues moved things to OneDrive.)

**NOTE:** The config path is baked into the AI3 installation. To change it, either copy the JSON into your Unity project folder or set the `ASSETINVENTORY_CONFIG_PATH` environment variable (per the AI3 settings UI).

### Current Settings (Feb 24, 2026 -- post-rebuild, verified)

#### Actions to Perform

| Action | Config Key | Current | Recommendation |
|--------|-----------|---------|----------------|
| Fetch Asset Store Purchases | AssetStorePurchases | ON | ON -- core functionality |
| Fetch Asset Store Details | AssetStoreDetails | ON | ON -- metadata |
| Scan Asset Store Cache | AssetStoreCacheScan | ON | ON -- finds downloaded packages |
| Index Store Assets | AssetStoreCacheIndex | ON | ON -- indexes package contents |
| Download & Index New Packages | AssetStoreDownloads | OFF | OFF -- downloads ALL packages. Heavy bandwidth/storage. Only enable when actively wanting to cache everything |
| Index Additional Folders | FoldersIndex | ON | ON |
| Index Media Folders | MediaFoldersIndex | ON | ON |
| Index Package Cache | PackageCacheIndex | ON | ON -- needed to index UPM registry packages |
| Index Unity Asset Manager | AssetManagerIndex | OFF | OFF unless using Unity Asset Manager |
| Extract Colors | ColorIndexer | OFF | OFF -- overhead with no benefit for file extraction workflow |
| Create Backups | Backup | OFF | OFF unless wanted |
| Create AI Captions | AICaptions | OFF | OFF |

#### Indexing

| Setting | Current Value | Notes |
|---------|---------------|-------|
| Asset Cache Location | Custom: `E:/Unity/01UnityAssetSystem/Unity/Asset Store-5.x` | Correct |
| Package Cache Location | Custom: `E:/Unity/02UnityCacheSystem/Unity/cache/upm` | FIXED Feb 23 (was wrong) |
| Index Sub-Packages | ON | |
| Keep Downloaded Assets | OFF | |
| Limit Package Size | OFF | |
| Pause Indexing Regularly | ON -- every 20 min for 20 sec | |

#### Additional Folders (Rebuild Target)

| Path | Type (folderType) | scanFor | Notes |
|------|-------------------|---------|-------|
| `E:/Game Assets` | Unity Packages (0) | -- | 195 .unitypackage files across subfolders |
| `E:/Game Assets` | Media Folder (1) | All Media (0) | Images + models (audio moved out) |
| `E:/GameAssetsAudio` | Media Folder (1) | Audio (2) | SFX, Music, Loops -- separated to avoid overlap |

**All folders should have:** createPreviews=true, removeOrphans=true, attachToPackage=true, detectUnityProjects=true

#### Import Settings

| Setting | Current Value |
|---------|---------------|
| Structure | Keep Original Folder Structure |
| Destination | Into Specific Folder |
| Target Folder | `Assets/ThirdParty` |
| Calculate FBX Dependencies | ON |
| Cross-Package Dependencies | ON |

#### Locations

| Location | Path |
|----------|------|
| Database | `E:\Unity\03UnityAssetInventory\Documents\AssetInventory` |
| Database file (actual) | `E:\Unity\03UnityAssetInventory\Documents\AssetInventory\AssetInventory.db` (268MB post-rebuild) |
| Backups | `[Default] ...\AssetInventory\Backups` |
| Previews | `[Default] ...\AssetInventory\Previews` |
| Cache/Extracted | `E:\Unity\03UnityAssetInventory\Documents\AssetInventory\Extracted` |
| Cache Limit | 60 GB |
| Configuration | `C:\Users\steph\OneDrive\Documents\AssetInventoryConfig.json` |
| Export Folder | `E:\Unity\03UnityAssetInventory\Documents` |

---

## Additional Folders -- Best Practices (from AI3 source)

AI3 supports 4 folder types, each with a different importer:

| Type | folderType | What It Does |
|------|-----------|--------------|
| **Unity Packages** | 0 | Scans for `*.unitypackage` files. Creates a package entry per file. Auto-links to Asset Store entries. Extracts previews from package. |
| **Media Folder** | 1 | Scans for image/audio/model files (configurable). Creates a package entry per subfolder name. Generates previews during indexing. |
| **Archives** | 2 | Scans for zip/7z/rar. Creates a package entry per archive. Extracts and indexes contents. |
| **Dev Packages** | 3 | Scans for `package.json` files. Creates registry package entries. For local development packages. |

### `E:/Game Assets` Structure

Mixed content folder:
- **195 .unitypackage files** (scattered across subfolders, none at root)
- **33 subfolders** (GameDevTV, Synty, Kenny, Audio, 2D, Fab, GitRepos, etc.)
- **Loose media files** in subfolders (textures, audio, models from non-Unity sources)
- **1 archive** (FearSteez3dmodels.zip at root)

### Folder Plan (Implemented Feb 23, verified Feb 24)

Audio files moved from `E:/Game Assets/Audio/` to `E:/GameAssetsAudio/`. Unity Packages and Media Folder both scan `E:/Game Assets` without duplication -- the Media scan picks up loose images/models while Unity Packages picks up .unitypackage files.

**Post-rebuild verification:** 2,331 assets, no config-driven duplication. The 54 duplicate names are nested sub-packages (e.g., each MagicPigGames pack embeds the same shader .unitypackage, each Synty pack embeds URP_ExtractMe).

**scanFor values:** 0=All Media, 1=All Files, 2=Audio, 3=Images, 4=Models, 5=Custom

---

## Cache Locations (System-Wide)

| Cache Type | Path | Purpose |
|------------|------|---------|
| Asset Cache | `E:\Unity\01UnityAssetSystem\Unity` | Downloaded .unitypackage files (in Asset Store-5.x subfolder) |
| Package Cache (UPM) | `E:\Unity\02UnityCacheSystem\Unity\cache\upm` | Unity Package Manager registry packages |
| AI3 Database | `E:\Unity\03UnityAssetInventory\Documents\AssetInventory` | SQLite database, previews, extracted cache |

---

## CSV Export Configuration

When exporting from Asset Inventory 3, use these 24 columns:

**Select:**
```
Id, ForeignId, AssetRating, AssetSource, AssetLink,
BIRPCompatible, DisplayCategory, DisplayName, DisplayPublisher,
HDRPCompatible, Keywords, LastRelease, LatestVersion, Location,
PackageSize, PriceUsd, PurchaseDate, RatingCount,
SafeCategory, SafeName, SafePublisher, SupportedUnityVersions,
URPCompatible, Version
```

**Skip:** ParentId (always 0), Revision (redundant), PackageSource (always "Unknown"), PackageTags (empty), License (empty)

**Avoid:** Description, KeyFeatures, ReleaseNotes (HTML bloat)

---

## Key Workflows

### Extract Individual Files

1. Search for the file (e.g., "hammer", "wooden texture")
2. Filter by category (3D Models, Textures, Audio)
3. Preview before importing
4. Right-click > Import with Dependencies (prefabs, materials) or Import File Only (standalone)
5. Files go to configured Target Folder (`Assets/ThirdParty`)

### Update Database

Window > Asset Inventory > Asset Inventory > Settings > Run Actions

### Maintenance

Maintenance Wizard "fast scans" are sufficient for routine cleanup. Run monthly or after major changes. Preview recreations process automatically during "Run Actions".

---

## Troubleshooting

| Issue | Cause | Solution |
|-------|-------|----------|
| "Could not find registry package download folder" | Package Cache Location mismatch | Set to `E:\Unity\02UnityCacheSystem\Unity\cache\upm` |
| Assets not appearing in search | Not indexed | Run Actions |
| Missing previews | Preview extraction disabled | Enable "Extract Full Previews from Web" |
| Slow searches | Large database + thumbnails | Disable Search Thumbnails and Search Metadata in Audio |
| Duplicate database entries | Multiple index sources overlapping same packages | See "Additional Folders" section above |
| 3D model previews missing | Package not in cache | Download package to cache first; images/textures show immediately |
| Database file not where expected | Check customStorageLocation subfolder | `E:\Unity\03UnityAssetInventory\Documents\AssetInventory\AssetInventory.db` |
| Config file scattered | C: drive space issues moved files to E: or OneDrive | Check both `C:\Users\steph\OneDrive\Documents\` and `E:\NitroDadFiles\Documents\` |

---

## Lessons Learned

1. Local packages have minimal metadata (no display name, publisher) -- use Tags or Package Override
2. 3D model previews only appear after package is downloaded to cache
3. Maintenance Wizard fast scans sufficient for routine cleanup
4. Preview recreations process automatically during Run Actions
5. Package Cache Location must be set manually when using custom cache paths
6. MCP stable config: port 54430, `client-transport=stdio`, `plugin-timeout=10000`
7. Old AIBridge file-exchange scripts replaced by Unity-MCP direct connection
8. Database carries stale entries across config changes -- delete and rebuild when settings change significantly
9. Having Unity Packages + Media Folder on the same root path causes duplicate entries
10. After rebuild, the .db file is at `E:\Unity\03UnityAssetInventory\Documents\AssetInventory\AssetInventory.db` (inside the customStorageLocation subfolder)
11. Two config files exist due to C: drive space migration -- only the OneDrive one is active

---

## MCP Configuration

### Files

| File | Purpose |
|------|---------|
| `.mcp.json` | Root MCP config (Claude Code reads this) |
| `.vscode/mcp.json` | VS Code MCP config |
| `.claude/settings.local.json` | Claude Code permissions + enabled servers |

### Server

- **Name:** ai-game-developer
- **Binary:** `E:/Unity/AssetInventoryProject/Library/mcp-server/win-x64/unity-mcp-server.exe`
- **Port:** 54430
- **Transport:** stdio

---

## Coding Standards

Applies only to custom scripts in this project (minimal codebase).

- No `var` keyword -- explicit types always
- ASCII-only in docs and identifiers
- No per-frame allocations, no per-frame LINQ
- Be direct, flag broken systems and stale docs

---

## Cross-Project Reference

| Document | Path |
|----------|------|
| Sandbox Status | `E:\Unity\Sandbox\Documents\Sandbox_Status.md` |
| Sandbox Asset Log (135 entries) | `E:\Unity\Sandbox\Documents\Sandbox_AssetLog.md` |
| HOK Status | `E:\Unity\HookedOnKharon\Documents\HOK_Status.md` |
| TecVooDoo Projects | `E:\TecVooDoo\Projects\Documents\TecVooDoo_Projects.csv` |

---

**End of Reference**
