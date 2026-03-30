# MCP Connection Brief

**Plugin:** `com.ivanmurzak.unity.mcp` v0.63.1 (updates frequently)
**Last verified:** March 28, 2026

---

## How It Works

Each Unity project runs its own MCP server exe, located at:
```
{ProjectRoot}/Library/mcp-server/win-x64/unity-mcp-server.exe
```

The server is a bridge between Claude Code and the Unity Editor plugin. Two config files tell Claude Code where to find that server. Both must exist and both must point to the **same project's** Library folder.

Blender MCP is separate -- it runs via `uvx` and always uses port 9876 regardless of project.

---

## Required Config Files (per project)

### File 1: `.vscode/mcp.json`
Used by the VS Code extension. Replace `YOUR_PROJECT` with project path and `XXXXX` with port from Unity Editor.
```json
{
    "servers": {
        "ai-game-developer": {
            "command": "E:/Unity/YOUR_PROJECT/Library/mcp-server/win-x64/unity-mcp-server.exe",
            "args": [
                "port=XXXXX",
                "plugin-timeout=10000",
                "client-transport=stdio",
                "authorization=none"
            ],
            "type": "stdio"
        },
        "blender": {
            "command": "cmd",
            "args": ["/c", "uvx", "blender-mcp"],
            "env": {
                "DISABLE_TELEMETRY": "true"
            },
            "type": "stdio"
        }
    },
    "inputs": []
}
```

### File 2: `.claude/mcp.json`
Used by the Claude Code CLI. **Must be created manually** -- Claude Code does not create this automatically.
```json
{
  "mcpServers": {
    "ai-game-developer": {
      "command": "E:/Unity/YOUR_PROJECT/Library/mcp-server/win-x64/unity-mcp-server.exe",
      "args": [
        "port=XXXXX",
        "plugin-timeout=10000",
        "client-transport=stdio",
        "authorization=none"
      ]
    },
    "blender": {
      "command": "cmd",
      "args": ["/c", "uvx", "blender-mcp"],
      "env": {
        "DISABLE_TELEMETRY": "true"
      }
    }
  }
}
```

### Key Differences Between the Two Files

| | `.vscode/mcp.json` | `.claude/mcp.json` |
|---|---|---|
| Outer key | `"servers"` | `"mcpServers"` |
| `"type": "stdio"` | Required on each server | Not used |
| `"inputs": []` | Required at root | Not used |
| Created by | VS Code / MCP plugin | **You, manually** |

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
- `"mcp__*"` covers ALL MCP tools (Unity, Blender, Photoshop, etc.) -- no individual entries needed
- `"defaultMode": "bypassPermissions"` means no approval prompts for any tool
- `additionalDirectories` lets any Claude instance access any project's files
- Add new projects here as they're created

---

## Port Assignment

**Each Unity project has a unique port.** Blender always uses port 9876.

The Unity port is shown in the AI Game Developer panel in Unity Editor. Use whatever port it shows -- do not share ports across projects.

### Current Port Registry

| Project | Port | Path |
|---------|------|------|
| Sandbox | 54815 | `E:/Unity/Sandbox` |
| FearSteez | 59431 | `E:/Unity/FearSteez` |
| HOK | 54111 | `E:/Unity/HookedOnKharon` |
| AudioProject | 50774 | `E:/Unity/AudioProject` |
| AnimationProject | 52516 | `E:/Unity/AnimationProject` |
| SpaceSucks | 29794 | `E:/Unity/SpaceSucks` |
| DLYH | 51240 | `C:/Unity/DontLoseYourHead` |
| VNPC | check Unity | `E:/Unity/VNPC/VisualNovelPointClick` |
| Blender (all projects) | 9876 | N/A (runs via `uvx`) |

---

## Getting the Server Exe

The server exe is automatically downloaded into `Library/mcp-server/` when Unity imports the package. If the folder doesn't exist:
1. Make sure `com.ivanmurzak.unity.mcp` is in the project's `manifest.json`
2. Open the project in Unity and wait for import to complete
3. The exe will appear at `Library/mcp-server/win-x64/unity-mcp-server.exe`

**Library is git-ignored** -- the exe does not commit to source control. Every machine/project that opens the Unity project will download its own copy.

---

## Version Must Match

The server exe version must match the plugin version. Check:
- Plugin version: `Packages/manifest.json` -> `"com.ivanmurzak.unity.mcp"`
- Server version: `Library/mcp-server/win-x64/version` (plain text file)

If they don't match, update `manifest.json` to the correct version and re-open Unity to trigger the download.

---

## v0.61.0+ Behavior Change

In v0.61.0+, MCP tools are now **surfaced as skills and deferred tools** in Claude Code, not as direct tool calls. This is intentional -- not a bug. The tools still work exactly the same, just invoked through the Skill tool or via CLI.

If a project connects (shows green) but the tools aren't visible in the old way, this is expected v0.61.0+ behavior.

---

## Why One Project Connects and Others Don't

| Symptom | Likely Cause | Fix |
|---------|-------------|-----|
| Shows orange immediately | `.claude/mcp.json` missing | Create it manually (see above) |
| Connects briefly then drops | Port already in use (zombie process) | Kill `unity-mcp-server.exe` processes in Task Manager |
| Two projects share a port | Port collision | Check AI Game Developer panel for each project's actual port |
| Never connects | Server exe not downloaded yet | Open project in Unity, wait for import |
| Connects but tools missing | v0.61.0+ behavior change | Expected -- tools are now skills |
| Version mismatch errors | Plugin != server exe version | Update `manifest.json`, reimport |
| Backslashes in path | Windows path separators | Use forward slashes: `E:/Unity/...` not `E:\Unity\...` |
| Missing `authorization=none` | Auth blocking connection | Add `"authorization=none"` to args |

**The most common miss:** `.claude/mcp.json` does not exist. Claude Code will not find the server without it. `.vscode/mcp.json` alone is not enough.

---

## Optional: Supabase & Cloudflare MCP Servers

DLYH uses additional MCP servers for Supabase and Cloudflare. Any project that needs these can copy the entries below into its config files. They run via `npx mcp-remote` and use OAuth tokens cached globally -- run them once and authenticate in the browser.

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

The global `"mcp__*"` permission already covers tool execution -- this list just tells Claude Code which servers to connect to from this project.

---

## Quick Setup Checklist for a New Project

- [ ] `com.ivanmurzak.unity.mcp` added to `manifest.json`
- [ ] Unity opened and import completed (server exe appears in Library)
- [ ] Port noted from AI Game Developer panel in Unity Editor
- [ ] `.vscode/mcp.json` created with correct project path + port + Blender (copy template above)
- [ ] `.claude/mcp.json` created manually with correct project path + port + Blender (copy template above)
- [ ] Both files use forward slashes in the path (`E:/Unity/...` not `E:\Unity\...`)
- [ ] Both files point to **this project's** Library, not another project's
- [ ] `authorization=none` present in args
- [ ] Project path added to `additionalDirectories` in global `~/.claude/settings.json`
