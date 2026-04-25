# MCP Connection Brief

**Plugin:** `com.ivanmurzak.unity.mcp` v0.66.0+ (updates frequently)
**Transport:** `streamableHttp` (single shared server per project)
**Last architecture change:** April 25, 2026 — migrated from stdio to HTTP
**First verified project:** Sandbox (April 25, 2026)

> **For a project Claude reading this:** if you're being pointed here to migrate a project, jump to **[Per-Project Migration](#per-project-migration-checklist)** below. The user already flipped Transport in Unity and restarted; your job is to verify and (if needed) hand-edit `.claude/mcp.json` to match `.mcp.json`.
>
> **DO NOT write stdio-form config under any circumstances.** This brief documents the HTTP transport only. The old stdio form (`command` + `args` with `client-transport=stdio`) is the cause of the port-race bug we migrated away from — writing it back into a project would re-introduce the bug. If HTTP verification fails for a project, stop and document the failure in `Documents/MCP_StreamableHttp_Test.md` rather than reverting.

---

## Architecture (v0.66.0+)

Each Unity project runs **one** MCP server, located at:
```
{ProjectRoot}/Library/mcp-server/win-x64/unity-mcp-server.exe
```

The Unity plugin's `McpServerManager` auto-starts the server in `streamableHttp` mode when Unity opens. Per the plugin wiki: "The server is always launched with `client-transport=streamableHttp` regardless of the transport setting in the plugin UI." VS Code Claude **does not spawn its own server** — it connects to the URL the Unity-launched server is already listening on.

### Why this matters (the bug we fixed)

Under the OLD stdio config, VS Code Claude launched its own server in `stdio` mode via `command`/`args`. That server fought to bind the same port the plugin wanted → port race → bind failures → tools intermittently dead while the green light kept lying. The error log showed repeated `Failed to bind to address http://0.0.0.0:XXXXX: address already in use` entries.

Under the NEW HTTP config, only Unity launches the server. VS Code Claude just connects to its URL. No race, no bind contention, multiple Claude windows can share one server.

Blender MCP is unrelated — it runs via `uvx` and always uses port 9876.

---

## Per-Project Migration Checklist

Run this **once per project**. Do not bulk-migrate — finish one project completely before starting the next.

### Unity-side (user does this)

1. Open the project in Unity. Wait for compile.
2. Open the **AI Game Developer** panel.
3. Note the port shown next to **Server URL** (`http://localhost:XXXXX`).
4. Flip **Transport** from `stdio` → `http`.
5. Click **Reconfigure** at the bottom — this regenerates `.mcp.json` in URL form. (May overwrite manual edits in `.mcp.json`; the plugin keeps a `.mcp.json.bak`.)
6. Expand **Manual Configuration Steps** to see whether `.claude/mcp.json` needs a manual edit too (the plugin may only write `.mcp.json`).
7. Close VS Code completely. Close Unity. (Optional: Task Manager → kill any lingering `unity-mcp-server.exe` processes.)
8. Open Unity. Wait for the panel to show **MCP server: Running (http)** in green.
9. Open VS Code in the project folder. Start a fresh Claude chat. Point it at this brief.

### Claude-side (the project Claude does this)

1. Read `Documents/MCP_ConnectionBrief.md` (this file).
2. Run the [Verification Commands](#verification-commands) below.
3. If `.claude/mcp.json` for `ai-game-developer` still has any `command`, `args`, or port-args fields, **delete those keys** and replace with `"url"` + `"type": "http"` matching `.mcp.json`. Use the project's actual port from the Unity panel.
4. Confirm `tool-list` returns at least the base IvanMurzak tools (~95) plus whatever TMCP groups are active for that project.
5. Update the [Port Registry](#port-registry) at the bottom with verified status + date.

---

## Required Config Files (per project)

### `.mcp.json` (project root) — NEW HTTP form

This is the file Claude Code's VS Code extension reads. The Unity MCP plugin auto-generates it via Reconfigure. You only need to add Blender (or other servers) manually.

```json
{
  "mcpServers": {
    "ai-game-developer": {
      "url": "http://localhost:XXXXX",
      "type": "http"
    },
    "blender": {
      "command": "C:/Users/steph/AppData/Local/Microsoft/WinGet/Packages/astral-sh.uv_Microsoft.Winget.Source_8wekyb3d8bbwe/uvx.exe",
      "args": ["blender-mcp"],
      "env": {
        "DISABLE_TELEMETRY": "true"
      }
    }
  }
}
```

The `"type": "http"` field is **required** — Claude Code uses it to detect HTTP-transport. The Unity plugin's Reconfigure button adds it automatically. Both fields (`url`, `type`) must be present; no `command`, `args`, or any port-related arg.

### `.claude/mcp.json` — same format

Used by Claude Code CLI (terminal mode). Same `mcpServers` key, same URL form. **Often must be hand-edited** — depending on plugin version, Reconfigure may only write the root `.mcp.json` and leave this one stale. Always check both files match after Reconfigure.

### `.vscode/mcp.json` — Claude Code does not use this file

Used by VS Code Copilot Chat MCP. **Claude Code ignores it.** Don't read, write, or sync it as part of a Claude migration. If the user uses Copilot Chat too, migrating that file is a separate, out-of-scope task they own.

---

## Global Permissions: `~/.claude/settings.json`

This file lives at `C:\Users\steph\.claude\settings.json` and applies to **all projects**. No per-project permission files needed.

```json
{
  "permissions": {
    "allow": [
      "Bash(*)",
      "Edit(*)",
      "Write(*)",
      "Read(*)",
      "Glob(*)",
      "Grep(*)",
      "WebFetch(*)",
      "WebSearch(*)",
      "Task(*)",
      "NotebookEdit(*)",
      "mcp__*"
    ],
    "defaultMode": "bypassPermissions",
    "additionalDirectories": [
      "E:\\Unity\\VNPC\\VisualNovelPointClick",
      "E:\\Unity\\Sandbox",
      "E:\\Unity\\HookedOnKharon",
      "E:\\Unity\\FearSteez",
      "E:\\Unity\\AudioProject",
      "C:\\Unity\\DontLoseYourHead",
      "E:\\Unity\\SpaceSucks",
      "E:\\Unity\\AnimationProject"
    ]
  }
}
```

**Key points:**
- `"mcp__*"` covers ALL MCP tools (Unity, Blender, Photoshop, etc.) — no individual entries needed
- `"defaultMode": "bypassPermissions"` means no approval prompts for any tool
- `additionalDirectories` lets any Claude instance access any project's files
- Add new projects here as they're created

---

## Verification Commands

These run from the project root and exercise the MCP server end-to-end. Requires `npx unity-mcp-cli` (v0.66+).

```bash
# 1. Server reachable + Unity connected
npx unity-mcp-cli status

# 2. Round-trip a system tool (echoes the message back)
npx unity-mcp-cli run-system-tool ping --input '{"message":"streamableHttp test"}'

# 3. Round-trip a Unity tool (lists opened scenes)
npx unity-mcp-cli run-tool scene-list-opened --input '{}'

# 4. Enumerate all registered tools (sanity check on TMCP define detection)
npx unity-mcp-cli run-tool tool-list --input '{}'
```

### Process & log checks (PowerShell)

```powershell
# Should show exactly ONE unity-mcp-server.exe, parented to Unity.exe (NOT Code.exe)
$procs = Get-Process unity-mcp-server -ErrorAction SilentlyContinue
$procs | ForEach-Object {
  $parent = (Get-CimInstance Win32_Process -Filter "ProcessId=$($_.Id)").ParentProcessId
  $parentName = (Get-Process -Id $parent -ErrorAction SilentlyContinue).ProcessName
  "PID $($_.Id) parent=$parent ($parentName)"
}
```

```bash
# Last dated entries should all PREDATE this project's most recent Unity restart.
# Any "Failed to bind to address" entries with timestamps after the restart = migration failed.
grep -nE "^[0-9]{4}-[0-9]{2}-[0-9]{2}" Library/mcp-server/win-x64/logs/server-log-error.txt | tail -10
```

### Pass criteria

- `status` reports Connected
- `ping` echoes the message
- `scene-list-opened` returns the scene list (not HTTP 500)
- `tool-list` returns ≥95 tools
- Exactly **one** `unity-mcp-server.exe`, parented to **Unity.exe**
- No new `Failed to bind to address` entries since the restart

---

## Port Registry

**Each Unity project has its own port.** Get the canonical port from each project's AI Game Developer panel — the entries below are last-known. Mark `Verified` after running the [Verification Commands](#verification-commands) successfully under HTTP transport.

| Project | Port | Path | HTTP Verified |
|---------|------|------|---------------|
| Sandbox | 24815 | `E:/Unity/Sandbox` | ✅ 2026-04-25 |
| FearSteez | 59431 | `E:/Unity/FearSteez` | — |
| HOK | 54111 | `E:/Unity/HookedOnKharon` | ✅ 2026-04-25 |
| AudioProject | 50774 | `E:/Unity/AudioProject` | — |
| AnimationProject | 52516 | `E:/Unity/AnimationProject` | — |
| SpaceSucks | 29794 | `E:/Unity/SpaceSucks` | — |
| DLYH | 51240 | `C:/Unity/DontLoseYourHead` | — |
| HideNReap | 26876 | `E:/Unity/HideNReap` | — |
| TecVooDoo | 23611 | `E:/Unity/TecVooDoo` | ✅ 2026-04-25 |
| GRIMMORPG | 23845 | `E:/Unity/GRIMMORPG` | ✅ 2026-04-25 |
| SetDesign | 29671 | `E:/Unity/SetDesign` | ✅ 2026-04-25 |
| AQS | check Unity | `E:/Unity/AQuokkaStory` | — |
| VNPC | check Unity | `E:/Unity/VNPC/VisualNovelPointClick` | — |
| M3AnimatedSeries | check Unity | `E:/Unity/M3AnimatedSeries` | — |
| Blender (all projects) | 9876 | N/A (runs via `uvx`) | n/a |

> Project Claude: when verification passes for your project, edit the row above to add `✅ YYYY-MM-DD` and commit the brief if appropriate.

---

## When HTTP Verification Fails

If verification doesn't pass for a project, **stop and document — do not silently revert to stdio.** Reverting brings back the port-race bug.

1. Capture the exact failure (commands run, output, log entries) in `Documents/MCP_StreamableHttp_Test.md` under a "Failure Notes — {project}" heading.
2. Mark the Port Registry row below with `❌ YYYY-MM-DD` and a one-line reason.
3. Stop the migration on this project and tell the user.

The user keeps `.mcp.json.bak` and `.claude/mcp.json.bak` from when Reconfigure ran, so a manual rollback is possible — but that's the user's call, not yours, and it requires flipping Transport back in Unity too. Don't do it as a workaround.

---

## Troubleshooting

| Symptom | Likely Cause | Fix |
|---------|-------------|-----|
| AI Game Developer "AI agent" dot stays orange | Cosmetic — plugin can't auto-detect Claude in HTTP mode | Ignore. MCP server green = tools work. |
| `tool-list` 404 / "not found" warning | Called `run-system-tool tool-list` instead of `run-tool tool-list` | Use `run-tool` — `tool-list` is a regular tool, not a system tool. System tools are only `ping`, `unity-skill-create`, `unity-skill-generate`. |
| HTTP 500 "Response data is null" on first call | Bridge not warmed up yet (Unity finished launching server but hub not ready) | Wait 1–2 sec, retry. If persistent, restart Unity. |
| Two `unity-mcp-server.exe` running | A stale process lingered after VS Code crash, OR a not-yet-migrated project is also open and racing | Task Manager → kill the orphan parented to Code.exe. The one parented to Unity.exe is correct. Migrate the other project before reopening it. |
| Claude tools dead but Unity panel green | Claude is reading the wrong config file | Check both `.mcp.json` AND `.claude/mcp.json` are URL form. Reconfigure may have only written the root one. |
| Bind errors after restart | Something else is on the port (older zombie server, or another Unity instance with same port) | Kill stale process. If you have two Unity projects with overlapping ports, edit one project's port in the AI Game Developer panel. |
| Connects briefly then drops | Stale server holding port from previous session | Kill `unity-mcp-server.exe`, restart Unity. |
| Backslashes in path | Windows path separators in URL | Not applicable to URL form (only stdio used `command`). If you see backslashes in a URL, hand-edit. |
| Tools missing from `tool-list` | TMCP `HAS_*` define for that asset isn't firing | Tools > TecVooDoo > **Rescan MCP Defines**, then check console for the detection result. |

The MCP plugin's "Manual Configuration Steps" expander in the AI Game Developer panel always shows the canonical config for the current Transport mode — use it as the source of truth if files drift.

---

## v0.66.0+ Behavior Notes

- **MCP tools surface as skills + deferred tools** in Claude Code, not direct tool calls. This started in v0.61.0 and continues. Tools work the same; they're invoked via `Skill` or via `npx unity-mcp-cli run-tool`.
- **`unity-mcp-cli`** is the CLI companion. Install with `npm install -g unity-mcp-cli` or use `npx`. Used by both humans and Claude for direct tool calls bypassing the skill layer.
- **TMCP tools (custom)** auto-detect via `HAS_*` defines. Active groups vary per project depending on what's installed. See `E:\Unity\DefaultUnityPackages\com.tecvoodoo.mcp-tools\Documents\TMCP_Status.md`.

---

## Getting the Server Exe

The server exe is automatically downloaded into `Library/mcp-server/` when Unity imports the package. If the folder doesn't exist:
1. Make sure `com.ivanmurzak.unity.mcp` is in the project's `manifest.json`
2. Open the project in Unity and wait for import to complete
3. The exe will appear at `Library/mcp-server/win-x64/unity-mcp-server.exe`

**Library is git-ignored** — the exe does not commit to source control. Every machine/project that opens the Unity project will download its own copy.

The server exe version must match the plugin version. Check:
- Plugin version: `Packages/manifest.json` → `"com.ivanmurzak.unity.mcp"`
- Server version: `Library/mcp-server/win-x64/version` (plain text file)

If they don't match, update `manifest.json` to the correct version and re-open Unity to trigger the download.

---

## Optional: Supabase & Cloudflare MCP Servers

DLYH uses additional MCP servers for Supabase and Cloudflare. Any project that needs these can copy the entries below into its config files. They run via `npx mcp-remote` and use OAuth tokens cached globally — run them once and authenticate in the browser. These were not affected by the streamableHttp migration.

> ⚠️ **The `"type": "stdio"` shown in the `.vscode/mcp.json` examples below is the correct transport for `mcp-remote` over Copilot Chat.** It is NOT a fallback or template for `ai-game-developer`. Never copy `command`/`args` patterns from this section into the `ai-game-developer` entry.

### Supabase

Provides database queries, migrations, edge functions, project management.

`.claude/mcp.json` format:
```json
"supabase": {
  "command": "npx",
  "args": ["-y", "mcp-remote", "https://mcp.supabase.com/mcp"]
}
```

`.vscode/mcp.json` format (add `"type": "stdio"`):
```json
"supabase": {
  "command": "npx",
  "args": ["-y", "mcp-remote", "https://mcp.supabase.com/mcp"],
  "type": "stdio"
}
```

### Cloudflare (8 servers)

Each covers a different Cloudflare product area. Add whichever are relevant.

| Server name | URL | Purpose |
|-------------|-----|---------|
| `cloudflare-docs` | `https://docs.mcp.cloudflare.com/mcp` | Search Cloudflare documentation |
| `cloudflare-workers-bindings` | `https://bindings.mcp.cloudflare.com/mcp` | KV, R2, D1, Hyperdrive, Workers code |
| `cloudflare-workers-builds` | `https://builds.mcp.cloudflare.com/mcp` | CI/CD builds for Workers |
| `cloudflare-observability` | `https://observability.mcp.cloudflare.com/mcp` | Worker logs and metrics |
| `cloudflare-logpush` | `https://logs.mcp.cloudflare.com/mcp` | Logpush jobs |
| `cloudflare-autorag` | `https://autorag.mcp.cloudflare.com/mcp` | AutoRAG |
| `cloudflare-casb` | `https://casb.mcp.cloudflare.com/mcp` | CASB asset/integration scanning |
| `cloudflare-graphql` | `https://graphql.mcp.cloudflare.com/mcp` | GraphQL analytics API |

All Cloudflare servers follow the same pattern:

`.claude/mcp.json` format:
```json
"cloudflare-docs": {
  "command": "npx",
  "args": ["-y", "mcp-remote", "https://docs.mcp.cloudflare.com/mcp"]
}
```

`.vscode/mcp.json` format (add `"type": "stdio"`):
```json
"cloudflare-docs": {
  "command": "npx",
  "args": ["-y", "mcp-remote", "https://docs.mcp.cloudflare.com/mcp"],
  "type": "stdio"
}
```

### Per-project permissions for extra servers

If the project has a `.claude/settings.local.json`, add the server names to `enabledMcpjsonServers`:
```json
{
  "permissions": {
    "allow": ["mcp__*"]
  },
  "enableAllProjectMcpServers": true,
  "enabledMcpjsonServers": [
    "ai-game-developer",
    "supabase",
    "cloudflare-docs",
    "cloudflare-workers-bindings",
    "cloudflare-workers-builds",
    "cloudflare-observability",
    "cloudflare-logpush",
    "cloudflare-autorag",
    "cloudflare-casb",
    "cloudflare-graphql"
  ]
}
```

The global `"mcp__*"` permission already covers tool execution — this list just tells Claude Code which servers to connect to from this project.

---

## REAPER MCP Server (DAW / Audio)

**Plugin:** `reaper-mcp-server` v0.1.1 (installed via `uv tool install reaper-mcp-server`)
**Last verified:** April 13, 2026

Not affected by the streamableHttp migration — REAPER's MCP server is its own thing.

### How It Works

The REAPER MCP server uses `python-reapy` to communicate with REAPER via a web interface on port 2307. Unlike Unity/Blender, there's only one REAPER instance — it's not per-project.

### Prerequisites (already done)

1. **Python 3.13** at `C:\Python313` with `python-reapy` and `psutil` installed to user site-packages (`C:\Users\steph\AppData\Roaming\Python\Python313\site-packages`)
2. **REAPER preferences** configured: ReaScript enabled, Python path set to `C:\Python313`, dll set to `python313.dll`
3. **reapy dist API enabled**: Web interface on port 2307 added to `reaper.ini` (`csurf_0=HTTP 0 2307 '' 'index.html' 0 ''`), reapy server activation script registered in `reaper-kb.ini`, ext state in `reaper-extstate.ini`
4. **ReWire disabled**: `rewire=0` in `reaper.ini` and `REAPERReWireDev.dll` renamed to `.disabled` in `E:\Reaper\`

### Config Files

REAPER config lives at: `C:\Users\steph\AppData\Roaming\REAPER\`
- `reaper.ini` — main config (web interface, Python path, rewire=0)
- `reaper-kb.ini` — registered scripts (activate_reapy_server.py)
- `reaper-extstate.ini` — reapy action mapping

### Adding to a Project

Add to `.mcp.json` at the project root:
```json
"reaper": {
  "command": "C:/Users/steph/.local/bin/reaper-mcp-server.exe",
  "args": []
}
```

### Startup Order (Important!)

1. Open **REAPER** first
2. In REAPER: **Actions > Show action list** > filter "reapy" > run **"Custom: activate_reapy_server.py"** (must run each time REAPER starts — it runs in the background)
3. Then start/restart **Claude Code** session

If Claude Code starts before the reapy server is activated, tools will fail with `module 'reapy.reascript_api' has no attribute 'EnumProjects'`.

### REAPER Python Site-Packages Note

REAPER's embedded Python doesn't see user site-packages by default. The activate_reapy_server script works because it was registered with the full path. If you need to run custom Python scripts in REAPER's ReaScript editor, add this at the top:
```python
import sys
sys.path.insert(0, r"C:\Users\steph\AppData\Roaming\Python\Python313\site-packages")
```

### REAPER Troubleshooting

| Symptom | Cause | Fix |
|---------|-------|-----|
| `EnumProjects` error | reapy server not activated in REAPER | Run activate_reapy_server.py from Actions list |
| ReWire Client Error on launch | ReWire DLL still active | Verify `E:\Reaper\REAPERReWireDev.dll.disabled` exists |
| `NameError: psutil` in ReaScript | Missing package in Python 3.13 | `C:\Python313\python.exe -m pip install psutil` |
| MCP server not found | `uv` bin not on PATH | Use full path: `C:/Users/steph/.local/bin/reaper-mcp-server.exe` |
| `analyze_frequency_spectrum` renders audio | It exports a temp file to analyze | Be aware it's not instant — it renders the project first |

---

## Quick Setup Checklist for a New Project

- [ ] `com.ivanmurzak.unity.mcp` v0.66.0+ added to `manifest.json`
- [ ] Unity opened and import completed (server exe appears in Library)
- [ ] AI Game Developer panel: Transport set to `http`
- [ ] Port noted from AI Game Developer panel
- [ ] Reconfigure clicked → `.mcp.json` regenerated with `url`+`type=http`
- [ ] `.claude/mcp.json` matches `.mcp.json` (hand-edit if Reconfigure didn't write it)
- [ ] Blender entry added manually to both files (Unity plugin only writes `ai-game-developer`)
- [ ] All URLs use `http://localhost:XXXXX` form (no backslashes, no `command`/`args`)
- [ ] Project path added to `additionalDirectories` in global `~/.claude/settings.json`
- [ ] [Verification Commands](#verification-commands) all pass
- [ ] Process count = 1, parented to Unity.exe
- [ ] No new bind errors in `server-log-error.txt`
- [ ] Port Registry updated with `✅ YYYY-MM-DD`
