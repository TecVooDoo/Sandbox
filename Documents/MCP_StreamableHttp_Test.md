# MCP streamableHttp — Migration Failure Log

**Purpose:** Per-project record of HTTP-transport migration verification failures.
**Pointer:** `MCP_ConnectionBrief.md` is the canonical procedure, troubleshooting, and port registry. This file only exists to capture project-specific failures so they don't get lost.

---

## When to write here

Per the [brief's failure protocol](MCP_ConnectionBrief.md#when-http-verification-fails): if the verification commands fail for a project, capture the failure here under a `## Failure Notes — {project}` heading and stop. Do **not** silently revert to stdio — that re-introduces the port-race bug we migrated away from.

What to capture per failure:
- Project name + port + plugin/server version
- Exact verification command(s) run
- Exact output / error text
- Relevant tail of `Library/mcp-server/win-x64/logs/server-log-error.txt`
- Process list snapshot (`Get-Process unity-mcp-server`)
- What was tried before giving up

Then mark the [Port Registry](MCP_ConnectionBrief.md#port-registry) row in the brief with `❌ YYYY-MM-DD` + a one-line reason and tell the user.

---

## Failure Notes

*(none yet — empty until a project's verification fails)*
