# FearSteez -- Migration Manifest

**Purpose:** Step-by-step plan for migrating FearSteez from Sandbox subproject to standalone Unity project.
**Source:** `E:\Unity\Sandbox` -- subproject at `Assets/_Sandbox/FearSteez/`
**Target:** `E:\Unity\FearSteez` -- standalone Unity 6 (6000.3.10f1) URP project
**Status:** Planning -- not started
**Created:** March 2026

---

## Overview

FearSteez is currently a subproject inside Sandbox. The standalone project already exists at
`E:\Unity\FearSteez` with just SampleScene and an empty Documents folder.

Migration breaks into four phases:
1. Set up the standalone project (packages, UPM, settings)
2. Export + import custom FearSteez assets
3. Import third-party animation assets from SyntyAssets
4. Verify, fix broken references, confirm scene plays

---

## Phase 1 -- Standalone Project Setup

Install all required packages BEFORE importing art assets to avoid Animancer/TopDown Engine FBX
catalog scan issues (see Critical Gotchas in MEMORY.md).

### Built-in / Registry Packages (via Package Manager)

| Package | Type | Notes |
|---------|------|-------|
| Input System | com.unity.inputsystem | Already built-in |
| Cinemachine | com.unity.cinemachine | Already built-in |
| AI Navigation | com.unity.ai.navigation | Already built-in |
| TextMeshPro | com.unity.textmeshpro | Already built-in |

### OpenUPM Packages

| Package | Install Command |
|---------|----------------|
| MCP for Unity (IvanMurzak) | `openupm add com.ivanmurzak.unity.mcp` |

### Local File Packages (DefaultUnityPackages)

Add to manifest.json:
```json
"com.tecvoodoo.mcp-tools": "file:../../DefaultUnityPackages/com.tecvoodoo.mcp-tools",
"com.unity.unitask": "file:../../DefaultUnityPackages/com.unity.unitask"
```

### Asset Store Packages (install via Unity Editor)

**Install in this order -- Animancer MUST be first before any FBX art:**

| # | Package | Entry | Notes |
|---|---------|-------|-------|
| 1 | Animancer Pro v8 | ENTRY-012 | MUST install before any FBX art |
| 2 | Odin Inspector + Validator | -- | Never remove once installed |
| 3 | DOTween Pro | ENTRY-010 | |
| 4 | Easy Save 3 | ENTRY-011 | |
| 5 | Final IK | ENTRY-014 | |
| 6 | Feel | ENTRY-015 | Does NOT trigger FBX scan |
| 7 | Flexalon Pro | ENTRY-016 | |
| 8 | Master Audio 2024 | ENTRY-103 | |
| 9 | Koreographer Pro | ENTRY-017 | |
| 10 | Damage Numbers Pro | -- | Used by EnemyHealth |
| 11 | Boing Kit | ENTRY-256 | BoingBones for hair/chains |
| 12 | EasyPooling 2025 | -- | |
| 13 | Text Animator for Unity | ENTRY-117 | |
| 14 | ALINE | ENTRY-007 | Debug drawing |
| 15 | vHierarchy 2, vFolders 2, vFavorites 2 | ENTRY-003/004/005 | Editor QoL |
| 16 | Full Kamgam UI Toolkit suite | ENTRY-116/118-123/125/126 | All 8 packages |
| 17 | Flow UI Toolkit Extended | ENTRY-134 | |
| 18 | Toolkit for UX 2026 | ENTRY-131 | |
| 19 | Asset Inventory 4 | ENTRY-252 | Set ASSETINVENTORY_CONFIG_PATH env var first |

### MCP Configuration

After MCP for Unity install, create both config files:
- `.vscode/mcp.json` -- VS Code format
- `.claude/mcp.json` -- Claude CLI format (manual, with `mcpServers` key pointing to Library exe)

---

## Phase 2 -- Custom FearSteez Asset Export

### What to Export from Sandbox

Export `Assets/_Sandbox/FearSteez/` as a `.unitypackage` from Sandbox.
**Include everything** -- Unity will carry .meta files preserving GUIDs.

Export path: `E:\Unity\Sandbox\Exports\FearSteez_Export_[date].unitypackage`

**Contents being exported (83 files):**

| Category | Count | Key Items |
|----------|-------|-----------|
| C# Scripts | 16 | All 9 namespaces |
| Assembly Defs | 9 | FS.Data, FS.Core, FS.Combat, FS.Player, FS.Enemy, FS.UI, FS.Audio, FS.Progression, FS.Editor |
| ScriptableObjects | 10 | 9x FSAttackData + FrankHitReactionDB |
| Prefabs | 8 | FearSteez, Steez, Civilian01, Zombie01, OniMan, RobotWoman, EnemyFS, Steez(char) |
| Scenes | 2 | TestScene, FearSteez |
| UI Toolkit | 2 | PlayerHUD.uxml, PlayerHUD.uss |
| Input Actions | 1 | FSInputActions.inputactions |
| Materials | 5 | Per-character .mat files |
| Textures | 15 | Color maps + Steez masks |
| Shader Graphs | 1 | Sidekick_ShaderGraph |
| Synty .sk files | 4 | Civilian01, Zombie01, OniMan, RobotWoman |
| Mesh/Avatar assets | 10 | Per-character .asset files |

### Import Target in Standalone

Import to: `Assets/FearSteez/` (drop the `_Sandbox` prefix -- this is now the root project)

### Post-Import Fixes

The asmdef files reference assemblies by GUID in Unity 6. Check each for broken references after import:
- `FS.Enemy` references `DamageNumbersPro` -- will resolve once DNP is installed (Phase 1)
- `FS.UI` references `Flexalon` -- will resolve once Flexalon is installed (Phase 1)
- `FS.Player` references `Unity.Cinemachine` -- built-in, should auto-resolve
- `FS.Core`, `FS.Progression`, `FS.Audio` reference `UniTask` -- resolve after UniTask installed

---

## Phase 3 -- Animation Asset Transfer from SyntyAssets

These assets live in `E:\Unity\SyntyAssets` and must be copied/exported to FearSteez standalone.
**Do NOT delete SyntyAssets project** -- HOK also needs these.

### Frank Animation Packs

| Pack | Source Path in SyntyAssets | Notes |
|------|---------------------------|-------|
| Frank FS3 | `Assets/FrankFS3/` (verify path) | Punches, kicks, hit reactions |
| Frank FS4 | `Assets/FrankFS4/` (verify path) | Additional attacks, KO clips |
| Frank Slash Pack | `Assets/FrankSlashPack/` (verify path) | Whip/rope dart clips |

Export each as .unitypackage from SyntyAssets, import into FearSteez standalone.

### Synty Character Packs

| Pack | Source | Notes |
|------|--------|-------|
| Synty Sidekick Characters | SyntyAssets | Civilian01, Zombie01, OniMan, RobotWoman meshes/rigs |
| Synty Apocalypse (or relevant pack) | SyntyAssets | Enemy character meshes |

### Kevin Iglesias Human Melee Animations

| Pack | Notes |
|------|-------|
| Human Melee Animations 2.0.2 | Enemy locomotion/death/stun clips |

### FrankHitReactionDB Re-population

After animation assets are imported, the `FrankHitReactionDB.asset` serialized references will be
broken (GUIDs changed). Two options:
- **Option A (preferred):** Re-run `FrankHitReactionDBPopulator` editor tool -- it scans by clip name,
  so as long as the Frank packs are in the same relative folder structure, it will re-match all 164 clips.
- **Option B (fallback):** Manually re-assign clips in Inspector.

Use Option A. Confirm folder structure matches before running.

---

## Phase 4 -- Verification

### Checklist

- [ ] Project compiles with 0 errors
- [ ] All 9 asmdef assemblies resolve cleanly
- [ ] FearSteez prefab loads in TestScene without missing references
- [ ] Civilian01 + Zombie01 prefabs load cleanly
- [ ] FrankHitReactionDB has 164 matched clips (run populator, verify count)
- [ ] FSAttackData SOs have correct clip references
- [ ] Player moves + attacks land on enemy
- [ ] Enemy AI works (patrol, chase, attack, stagger, death)
- [ ] Health bar HUD displays and updates
- [ ] Dead enemy settles and destroys after delay
- [ ] No console errors during play

### Known Re-wiring Required (Inspector)

These serialized references point to scene objects and must be re-assigned after scene import:

**TestScene:**
- FSEnemyBrain._player → FearSteez transform
- FSPlayerHUD._playerHealth → FearSteez FSPlayerHealth
- CinemachineCamera tracking target → FearSteez transform
- All enemy EnemyHealth._hitReactionDB → FrankHitReactionDB asset
- All enemy FSEnemyBrain attack SOs → FSAttackData assets

**FearSteez prefab:**
- FSCombatController._comboAttacks[] → punch SOs
- FSPlayerHealth._hitReactionDB → FrankHitReactionDB asset

---

## File Size Estimate

| Component | Estimated Size |
|-----------|---------------|
| Custom FearSteez scripts/assets | ~5 MB |
| Frank FS3 + FS4 + Slash Pack | ~500 MB |
| Synty Sidekick Characters | ~200 MB |
| Kevin Iglesias Human Melee | ~50 MB |
| Third-party packages (new installs) | ~2 GB |
| **Total standalone project** | **~3 GB** |

---

## Migration Log

| Date | Phase | Action | Status |
|------|-------|--------|--------|
| -- | -- | Manifest created | Done |
