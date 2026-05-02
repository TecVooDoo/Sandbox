# Sandbox Fresh Install -- Minimal Package List

**Purpose:** Packages to install on the fresh Sandbox rebuild. SM-focused + eval-ready.
**Date:** April 3, 2026

> Install in order. Ctrl+R between phases. Set Auto Refresh: Disabled FIRST.

---

## Before Anything Else

1. Edit > Preferences > Asset Pipeline > **Auto Refresh: Disabled**
2. Edit > Preferences > Asset Pipeline > Script Changes While Playing: **Recompile After Finished Playing**

---

## Phase 1: Prerequisites (install FIRST)

| Package | Source | Why First |
|---------|--------|-----------|
| Addressables | Unity Registry | Master Audio dependency |
| TextMesh Pro | Unity Registry | DOTween Pro dependency |

## Phase 2: Core Infrastructure

| Package | Source | manifest.json |
|---------|--------|---------------|
| UniTask | OpenUPM | `"com.cysharp.unitask": "2.5.10"` |
| MCP for Unity | OpenUPM | `"com.ivanmurzak.unity.mcp": "0.63.3"` |
| MCP Animation | OpenUPM | `"com.ivanmurzak.unity.mcp.animation": "1.1.22"` |
| MCP ProBuilder | OpenUPM | `"com.ivanmurzak.unity.mcp.probuilder": "1.0.61"` |
| MCP ParticleSystem | OpenUPM | `"com.ivanmurzak.unity.mcp.particlesystem": "1.0.52"` (previously flagged Don't Use due to McpPlugin.Instance API mismatch; **fixed**, install with the others) |
| com.tecvoodoo.utilities | Local | `"com.tecvoodoo.utilities": "file:../../DefaultUnityPackages/com.tecvoodoo.utilities"` |
| com.tecvoodoo.games | Local | `"com.tecvoodoo.games": "file:../../DefaultUnityPackages/com.tecvoodoo.games"` |
| com.tecvoodoo.mcp-tools | Local | `"com.tecvoodoo.mcp-tools": "file:../../DefaultUnityPackages/com.tecvoodoo.mcp-tools"` |

**OpenUPM scoped registry** (add to manifest.json):
```json
"scopedRegistries": [
  {
    "name": "package.openupm.com",
    "url": "https://package.openupm.com",
    "scopes": [
      "com.cysharp.unitask",
      "com.ivanmurzak",
      "extensions.unity",
      "org.nuget.com.ivanmurzak",
      "org.nuget.microsoft",
      "org.nuget.system",
      "org.nuget.r3"
    ]
  }
]
```

## Phase 3: Default Packages (INSTALL)

| Package | Source | Notes |
|---------|--------|-------|
| Odin Inspector | Asset Store | Universal. Never remove once installed. |
| DOTween Pro | Asset Store | Requires TMP. Juice + UI animation. |
| Easy Save 3 | Asset Store | Save/load + offline earnings. |
| Master Audio 2024 | Asset Store | Requires Addressables. Audio. |
| Text Animator | Asset Store | Floating numbers, text effects. |

### Editor QoL (install with Phase 3 -- used every project)

| Package | Source | Notes |
|---------|--------|-------|
| vFolders 2 | Asset Store | Editor QoL -- standard |
| vHierarchy 2 | Asset Store | Editor QoL -- standard |
| Wingman | Asset Store | Inspector tool -- standard |
| Ultimate Preview 2 (Voxel Labs) | Asset Store | Preview -- standard. v2 (succeeds Ultimate Preview Window Pro 1.3.4 — same publisher, same install path, ENTRY-343 + v2 addendum). HDRP users: import bundled `UltimatePreview_HDRP.unitypackage` after install. |
| Power Pivot (Kamgam) | Asset Store | Mesh pivot editing -- standard (fixes Synty/KayKit FBX pivots in-place; sibling-asset-saved meshes survive FBX reimport via `MeshImportListener`; ENTRY-346) |
| Technie Collider Creator 2 (Triangular Pixels) | Asset Store | Paint-based collider authoring + VHACD auto-decomp -- standard (ENTRY-330; pipeline-agnostic; pairs with Power Pivot — fix pivot first, then paint colliders) |
| ALINE | Asset Store | Debug visualization -- standard (used in every project; promoted out of "install on demand") |
| Markdown for Unity | Asset Store | Markdown rendering -- standard |
| Audio Preview Tool | Asset Store | Audio preview -- standard |

**14 defaults total.** Down from 15 originally; back up after readding ALINE + TCC + Power Pivot.

## Phase 4: SM Art Assets (when ready for jumpstart)

| Asset | Source | Notes |
|-------|--------|-------|
| Cute Pet (Suriyun) | Asset Store | Body models. The core art. |
| Assembly Kit (ForActionGames) | Asset Store | Ghost/Skeleton/Reaper player character. |
| KayKit Halloween | CC0 / local | Environment props. |
| KayKit Environment | CC0 / local | Additional environment. |

## SKIP -- Install On Demand Only

| Package | Why Skip |
|---------|----------|
| Flexalon Pro | Not needed for SM. Install for UI layout evals. |
| Asset Inventory 4 | 24 DLLs = huge domain reload hit. Install only for batch asset searches. |
| vFavorites 2 | Not in standard QoL set. Install if wanted. |
| ALL TMCP-supported assets | Now live in TecVooDoo project. |

---

## MCP Setup (after Phase 2)

1. Open AI Game Developer panel in Unity (`Window > AI Game Developer`)
2. Note the port number
3. In the panel: set **Transport: http** (do NOT use stdio)
4. Click **Reconfigure** under Model Context Protocol (MCP) — writes `.mcp.json` in URL+`type:http` form
5. Mirror the `ai-game-developer` entry into `.claude/mcp.json` by hand (plugin doesn't touch this file)
6. Manually add Blender entry to both `.mcp.json` and `.claude/mcp.json` (Reconfigure only writes ai-game-developer)
7. Update port registry in `MCP_ConnectionBrief.md`

See [MCP_ConnectionBrief.md](MCP_ConnectionBrief.md) for full details.

---

## Expected Result

- ~10 packages total (5 defaults + 5 infrastructure)
- Compile time: < 5 seconds
- Domain reload: < 20 seconds
- Ready for SM jumpstart

---

**End of Document**
