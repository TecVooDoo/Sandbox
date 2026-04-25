# New Project Setup Brief

**Purpose:** Standard setup checklist for any new TecVooDoo Unity project.
**Last Updated:** April 1, 2026 (default package list reevaluated)

---

## 1. Unity Project Creation

- **Engine:** Unity 6 (6000.x)
- **Render Pipeline:** URP (Universal Render Pipeline) unless project-specific reason for HDRP
- **Root folder:** `Assets/_<ProjectName>/` (underscore prefix sorts to top in Project window)

---

## 2. OpenUPM Registry Setup

Add this to `Packages/manifest.json` under `scopedRegistries` (or verify it exists):

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

**Packages from OpenUPM:**

| Package | ID | Notes |
|---------|----|-------|
| UniTask | `com.cysharp.unitask` | Prefer over local file copy -- OpenUPM stays updated |
| MCP for Unity | `com.ivanmurzak.unity.mcp` | Check latest version, updates frequently |
| MCP Animation | `com.ivanmurzak.unity.mcp.animation` | Optional, for animation tools |
| MCP ProBuilder | `com.ivanmurzak.unity.mcp.probuilder` | Optional, for ProBuilder tools |

**DO NOT install:** `com.ivanmurzak.unity.mcp.particlesystem` -- McpPlugin.Instance API mismatch causes CS0117 errors.

---

## 3. Package Installation Order

**Order matters.** Some packages scan all FBX files on first import or depend on packages that must exist first.

### Phase 1: Prerequisites (install FIRST)

| Package | Why First |
|---------|-----------|
| Addressables | Master Audio 2024 depends on it |
| TextMesh Pro | DOTween Pro depends on it |

### Phase 2: Core Infrastructure

| Package | Source | Notes |
|---------|--------|-------|
| UniTask | OpenUPM (`com.cysharp.unitask`) | async/await over coroutines |
| com.tecvoodoo.utilities | Local file ref | Shared utility library |
| com.tecvoodoo.mcp-tools | Local file ref | Custom MCP tools (35 tools) |
| com.tecvoodoo.games | Local file ref | Shared gameplay library (depends on utilities) |
| MCP for Unity | OpenUPM | AI agent bridge |

**Local file references** in manifest.json:
```json
"com.tecvoodoo.utilities": "file:../../DefaultUnityPackages/com.tecvoodoo.utilities",
"com.tecvoodoo.mcp-tools": "file:../../DefaultUnityPackages/com.tecvoodoo.mcp-tools",
"com.tecvoodoo.games": "file:../../DefaultUnityPackages/com.tecvoodoo.games"
```

Path assumes project is at `E:\Unity\<ProjectName>`. Adjust `../../` depth if project is nested differently (e.g., VNPC is at `E:\Unity\VNPC\VisualNovelPointClick` -- needs `../../../`).

### Phase 3: Default Asset Store Packages

These 15 packages are used consistently across all TecVooDoo projects. Install in every new project.

**Prerequisites first:** Addressables before Master Audio 2024. TextMesh Pro before DOTween Pro.

| Package | Version | Notes |
|---------|---------|-------|
| Odin Inspector and Serializer | 4.0.1.4 | **Never remove once installed.** Cascading errors. |
| DOTween Pro | 1.0.410 | Requires TextMesh Pro |
| Easy Save 3 | 3.5.25 | Save/load |
| Master Audio 2024 | 1.0.4 | Requires Addressables |
| ALINE | 1.7.9 | Debug visualization |
| Flexalon Pro | 4.4.0 | 3D & UI layouts |
| Text Animator | 3.5.0 | UI Toolkit + TMP text effects |
| Asset Inventory 4 | 4.1.1 | Asset management |
| vHierarchy 2 | 2.1.8 | Editor QoL |
| vFolders 2 | 2.1.14 | Editor QoL |
| vFavorites 2 | 2.0.14 | Editor QoL |
| Wingman | 1.3.0 | Inspector tool |
| Ultimate Preview Window Pro | 1.3.2 | Editor preview |
| Audio Preview Tool | 1.1.0 | Audio preview |
| Markdown for Unity | 1.0.0 | Markdown rendering |

### Phase 4: Animation Tools (install BEFORE 3D art assets)

Only install if the project uses 3D art with FBX files.

| Package | Why Before Art |
|---------|----------------|
| Animancer Pro | Catalogs every .fbx on first import -- very slow with large art libraries |
| More Mountains engines (Corgi, TopDown, etc.) | Same FBX catalog scan. **Feel does NOT trigger this** |

### Phase 5: Project-Specific Packages

Install only what the specific project needs. These are NOT defaults.

**Gameplay / Combat:** Feel, Damage Numbers Pro, EasyPooling 2025, Boing Kit, RayFire 2, Rope Toolkit
**Character / Animation:** Final IK, Malbers AC (Horse Animset Pro), Ragdoll Animator 2, Retarget Pro
**AI / Navigation:** Behavior Designer Pro, SensorToolkit2, A* Pathfinding Pro
**Audio:** Koreographer Pro
**Shaders / VFX:** Toon Kit 2, Outlines Post-Process, Advanced Dissolve, Buto, Weather Maker
**UI:** Kamgam UI Toolkit suite, Flow UI Toolkit Extended, Inventory Framework 2
**Dialogue:** Dialogue System for Unity
**2.5D:** Kamgam 2.5D Terrain, Bridge Builder, Looping

See `Sandbox_AssetLog.md` (315+ entries) for full eval details on any package.

---

## 4. MCP Setup

See [MCP_ConnectionBrief.md](MCP_ConnectionBrief.md) for full details.

**Quick version:**
1. MCP plugin (v0.66+) installs server exe to `Library/mcp-server/win-x64/`
2. Open AI Game Developer panel in Unity, note the port number
3. In the panel: set **Transport: http**, then click **Reconfigure** under MCP — writes `.mcp.json` in URL+`type:http` form
4. Mirror the `ai-game-developer` entry into `.claude/mcp.json` by hand
5. Manually add Blender entry to both `.mcp.json` and `.claude/mcp.json`
6. Add project path to `additionalDirectories` in global `~/.claude/settings.json`
7. Update port registry in MCP_ConnectionBrief.md

**Critical:** never put `command`/`args` for `ai-game-developer` in `.mcp.json` — that re-introduces the pre-v0.66 stdio port-race that fails intermittently while showing a green connection light.

---

## 5. Folder Structure

```
Assets/
  _<ProjectName>/
    Scripts/
      Core/           -- Event system, managers, singletons
      Player/         -- Player controller, input, abilities
      Enemy/          -- AI, spawning, behavior
      Combat/         -- Damage, weapons, projectiles
      UI/             -- UI controllers (UI Toolkit preferred)
      Data/           -- ScriptableObject definitions
      Editor/         -- Editor-only tools
      Test/           -- Debug/test scripts (production quality)
    Art/
      Animations/
      Materials/
      Models/
      Textures/
      VFX/
    Audio/
      Music/
      SFX/
    Data/             -- ScriptableObject instances
    Prefabs/
    Scenes/
    Settings/         -- Input actions, render settings
    UI/               -- UXML/USS files (UI Toolkit)

Documents/
  <ProjectName>/
    <Name>_Status.md
    <Name>_StatusArchive.md
    <Name>_DevReference.md
    <Name>_CodeReference.md
    GDD/
      <Name>_GDD.md
```

---

## 6. Documentation Structure

Every project needs these docs. Create them at project start, not after.

| Doc | Purpose | Who Updates |
|-----|---------|-------------|
| `<Name>_Status.md` | Current state, last ~2 sessions, what's next | AI after each session |
| `<Name>_StatusArchive.md` | Full session history (older sessions moved here) | AI when Status.md grows |
| `<Name>_DevReference.md` | Architecture, standards, AI rules, lessons | AI when patterns emerge |
| `<Name>_CodeReference.md` | Script inventory, API reference | AI when code changes |
| `GDD/<Name>_GDD.md` | Game design document | **User only** (AI updates when asked) |

**"Where are we at?" always points to Status.md.**

### Status Doc / Archive Pattern

The Status doc should stay **small and focused** -- only the current state and last ~2 sessions. When a new session starts:

1. Move older session entries from `<Name>_Status.md` to `<Name>_StatusArchive.md`
2. Keep only the most recent 2 sessions in Status.md
3. Archive entries go at the **top** of StatusArchive.md (newest first)

This keeps the Status doc quick to read while preserving full session history in the archive. Both docs must exist from project start -- create the StatusArchive.md stub when creating the project.

---

## 7. Asset Evaluation

**All asset evaluations live in Sandbox**, regardless of which project triggered the need.

| Resource | Location |
|----------|----------|
| Asset evaluation log | `E:\Unity\Sandbox\Documents\Sandbox_AssetLog.md` |
| MCP tool candidates | `Sandbox_AssetLog.md` -- MCP Candidates section (end of doc) |
| TecVooDoo Utilities candidates | `Sandbox_AssetLog.md` -- TecVooDoo Utilities Candidates section (end of doc) |
| Full asset inventory CSV | `E:\Unity\03UnityAssetInventory\Documents\assets02272026.csv` (~2,331 assets) |

**Sandbox is the single source of truth** for all asset evals, MCP candidate evals, and TecVooDoo Utilities candidate tracking. Other projects reference Sandbox docs for asset decisions -- they do not maintain their own eval logs (except VNPC and AudioProject which have project-specific eval sections).

When evaluating a new asset for any project:
1. Check `Sandbox_AssetLog.md` first -- it may already be evaluated (301+ entries)
2. Add new evals to Sandbox AssetLog with the entry number convention (ENTRY-XXX)
3. Note which project triggered the eval

---

## 8. Coding Conventions

These apply to ALL TecVooDoo projects:

| Rule | Rationale |
|------|-----------|
| No `var` keyword | Explicit types always |
| No per-frame allocations | No `new`, no LINQ in Update/FixedUpdate |
| ASCII only | No smart quotes, em-dashes, or special characters in code or docs |
| `sealed` on MonoBehaviours | Unless inheritance is specifically intended |
| Prefer async/await (UniTask) | Over coroutines |
| Prefer interfaces and generics | Decouple systems, reduce duplication |
| GameEvent/GameEventListener | Custom event system (NOT SOAP) |
| Vanilla ScriptableObject architecture | For data, config, and events |
| Set state BEFORE firing events | Handlers check state immediately |
| Extract by responsibility | Not by line count. One responsibility per class. |
| Production-quality test code | Even in Sandbox |

### Unity 6 Specifics

| Old API | Unity 6 API |
|---------|-------------|
| `rb.velocity` | `rb.linearVelocity` |
| `rb.angularVelocity` | `rb.angularVelocity` (unchanged) |
| `collider.material` | `collider.sharedMaterial` (context-dependent) |

### Assembly Definition Rules

- Scripts without asmdef compile to `Assembly-CSharp`
- Named asmdef code **cannot see** Assembly-CSharp types
- Fix: give target folder its own asmdef with GUID reference
- Custom MCP tools asmdef needs `overrideReferences: true` + `ReflectorNet.dll`

---

## 9. Source Control

- **GitHub** for all projects
- **UPM Git URLs don't work on this machine** -- clone repos and use `file:` references
- `Library/` is git-ignored (each machine downloads its own)
- `.claude/mcp.json` should be committed (project-specific config)
- `.claude/settings.json` should be committed if it has project-specific settings
- Never commit `.env`, credentials, or API keys

---

## 10. Project-Specific Standards

Some projects override or extend the universal conventions:

| Project | Override |
|---------|----------|
| HOK | Custom Animator Controllers only (no Malbers AC). 8 namespaces. |
| AQS | Malbers AC for player movement. 3D physics with LockAxis for 2.5D. |
| FearSteez | UI Toolkit only (no uGUI). Collision-based ground detection. |
| VNPC | Adventure Creator integration. |

Document project-specific rules in that project's `DevReference.md`.

---

## 11. Editor Preferences (Claude Code Workflow)

These settings prevent Unity from triggering full reimports every time Claude Code writes a file externally. Apply to every project.

**Edit > Preferences > Asset Pipeline:**

| Setting | Value | Why |
|---------|-------|-----|
| Auto Refresh | **Disabled** | Prevents reimport on every external file write. Compile manually with **Ctrl+R**. |
| Script Changes While Playing | **Recompile After Finished Playing** | Safer than hot-reload, avoids mid-play domain reload crashes. |

Without these, writing multiple scripts via Claude Code triggers a separate reimport cycle for each file -- catastrophic on large projects with many assets (Sandbox reimport takes 10+ minutes).

**Workflow:** Claude writes all scripts, then user hits Ctrl+R once to compile the batch.

---

## Quick Setup Checklist

- [ ] Unity 6 project created with URP
- [ ] Root folder: `Assets/_<ProjectName>/`
- [ ] **Editor Preferences set** (Auto Refresh disabled, Recompile After Finished Playing)
- [ ] OpenUPM scoped registry added to manifest.json
- [ ] Phase 1 prerequisites installed (Addressables, TextMesh Pro)
- [ ] Phase 2 core packages installed (UniTask, TecVooDoo packages, MCP)
- [ ] Phase 3 default Asset Store packages installed (15 packages)
- [ ] Phase 4 animation tools installed (if using 3D art -- BEFORE importing FBX)
- [ ] Phase 5 project-specific packages installed as needed
- [ ] MCP configured (see MCP_ConnectionBrief.md)
- [ ] GitHub repo created
- [ ] Documents folder created with Status, DevReference, CodeReference, GDD stubs
- [ ] Project added to global `~/.claude/settings.json` additionalDirectories
- [ ] Port added to MCP_ConnectionBrief.md port registry
