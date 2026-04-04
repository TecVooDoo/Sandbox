# Evaluation Guide

**Purpose:** Standard methodology for all three evaluation types. Any project can reference this when doing evals.
**Last Updated:** April 3, 2026

> **All evaluations are documented in Sandbox** regardless of which project triggered the need. Sandbox is the single source of truth for eval results.

---

## 1. Asset Evaluation

**When:** Before installing any Asset Store package in a game project.
**Where to check first:** `E:\Unity\Sandbox\Documents\Sandbox_AssetLog.md` (315+ entries). It may already be evaluated.
**Where to document:** Same file, new ENTRY-XXX entry.

### Entry Format

```
### ENTRY-XXX: Package Name vX.X.X
**Verdict:** [Approved | Recommended | Conditional | Deferred | Rejected]
**Triggered by:** [Project name or general need]
**Date:** [YYYY-MM-DD]

**What it does:** [One sentence]
**Problem it solves:** [Why we looked at it]

**Eval Results:**
- [Installation notes, first impressions]
- [API quality, documentation quality]
- [Performance observations]

**Project Fit:**
- [Which active projects benefit and why]

**MCP Controllability:** [If tested]
- component-add: [pass/fail]
- component-get: [pass/fail]
- component-modify: [pass/fail]
- script-execute: [pass/fail]
- [Gotchas discovered]

**Key Gotchas:**
- [Anything that caused problems]

**Cherry-pick Targets:** [If Conditional/Deferred -- what specifically is worth using]
```

### Verdict Definitions

| Verdict | Meaning | Action |
|---------|---------|--------|
| **Approved** | Install and use freely | Add to project as needed |
| **Recommended** | Strong fit, should be default | Consider for NewProjectSetup_Brief defaults |
| **Conditional** | Useful but has caveats | Document conditions, cherry-pick specific features |
| **Deferred** | Not needed now but worth revisiting | Note what would trigger re-eval |
| **Rejected** | Not suitable | Document why to avoid re-evaluating |

### Rules
- Always check Sandbox_AssetLog.md before evaluating -- don't re-eval what's already decided
- Entry numbers are sequential (never reuse)
- Note which project triggered the eval
- Test MCP controllability if the asset has runtime components
- Be honest about gotchas -- future-you will thank past-you

---

## 2. MCP Tool Candidate Evaluation

**When:** During any eval or project work, you encounter an asset whose components would benefit from MCP tool access.
**Where to document:** `E:\Unity\Sandbox\Documents\Sandbox_AssetLog.md` -- **MCP Candidates** section (end of doc).
**Where candidates get built:** `E:\Unity\TecVooDoo` project (all TMCP-supported assets installed).
**Package source:** `E:\Unity\DefaultUnityPackages\com.tecvoodoo.mcp-tools\`
**Package docs:** `E:\Unity\DefaultUnityPackages\com.tecvoodoo.mcp-tools\Documents\TMCP_Status.md` and `TMCP_Reference.md`

### Candidate Criteria

An asset is a good MCP tool candidate if:
- It has **inspector-configurable components** that Claude Code would need to set up frequently
- Manual configuration is **tedious or error-prone** (many fields, specific value ranges, complex dependencies)
- The asset is **used across multiple projects** (or will be)
- The asset's API is **stable** (not changing every update)

### Candidate Entry Format

```
### MCP-CANDIDATE-XXX: Asset Name
**Asset:** [Package name, ENTRY-XXX ref from asset eval]
**Tool groups needed:** [e.g., Query, Configure, Add]
**Why:** [What's tedious to do manually]
**Priority:** [High | Medium | Low]
**Status:** [Candidate | In Progress | Complete]
```

### What to Test Before Promoting

Before creating a tool group, verify in Sandbox or TecVooDoo:
1. `component-add` works for the asset's main components
2. `component-get` returns readable data (watch for NativeArray crashes)
3. `component-modify` can set key fields
4. `script-execute` can access the asset's API
5. Note any HTML encoding issues (`<>`, `&&`) that need workarounds

---

## 3. TecVooDoo Utilities Candidate Evaluation

**When:** During any session, you write code that could be reused across projects.
**Where to document:** `E:\Unity\Sandbox\Documents\Sandbox_AssetLog.md` -- **TecVooDoo Utilities Candidates** section (end of doc).
**Package source:** `E:\Unity\DefaultUnityPackages\com.tecvoodoo.utilities\`
**Package docs:** `E:\Unity\DefaultUnityPackages\com.tecvoodoo.utilities\Documents\TVU_Status.md` and `TVU_Reference.md`

### Candidate Criteria -- ALL Must Be True

1. **Zero project dependency** -- no references to any game-specific types or namespaces
2. **Genuinely reusable** -- would benefit 2+ active projects right now, not hypothetically
3. **No equivalent exists** -- check TVU_Reference.md first
4. **Not editor-only** -- editor helpers go in MCP tools, not Utilities
5. **Not a wrapper** -- don't wrap third-party packages (DOTween, Animancer, etc.)

### Good Candidates
Extension methods on Unity types, generic data structures, math helpers, lightweight design patterns, PlayerLoop utilities, zero-alloc collections.

### Poor Candidates
Game-specific managers, SO types, anything with a project namespace, wrappers around third-party packages.

### Candidate Entry Format

```
### TVU-CANDIDATE-XXX: Name
**What:** [One sentence description]
**Source:** [Which project/session it came from]
**Module:** [Which TVU module it fits in, or "New module"]
**Why reusable:** [Which projects would use it]
**Status:** [Candidate | In Progress | Added]
```

### Tracking Tags in Session Docs

When noting candidates during session work in any project's Status.md:
- `[UTILITIES CANDIDATE]` -- identified, needs promotion
- `[UTILITIES ADDED]` -- promoted to TVU, update TVU_Status.md + TVU_Reference.md

---

## 4. TecVooDoo Games Candidate Evaluation

**When:** During game project work, you write gameplay code that applies to multiple games.
**Where to document:** `E:\Unity\Sandbox\Documents\Sandbox_AssetLog.md` -- **TecVooDoo Games Candidates** section (end of doc).
**Package source:** `E:\Unity\DefaultUnityPackages\com.tecvoodoo.games\`
**Package docs:** `E:\Unity\DefaultUnityPackages\com.tecvoodoo.games\Documents\TVG_Status.md` and `TVG_Reference.md`

### Candidate Criteria

1. **Gameplay logic** -- not utility code (that goes in TVU)
2. **Not editor-only** -- editor helpers go in MCP tools
3. **Reusable across games** -- event systems, game state machines, scoring, save integration patterns
4. **Depends only on com.tecvoodoo.utilities** -- no other package dependencies
5. **No equivalent exists** -- check TVG_Reference.md first

### Candidate Entry Format

```
### TVG-CANDIDATE-XXX: Name
**What:** [One sentence description]
**Source:** [Which project/session it came from]
**Why reusable:** [Which games would use it]
**Status:** [Candidate | In Progress | Added]
```

---

## Quick Reference

| Eval Type | Document In | Candidates Built In | Package |
|-----------|-------------|--------------------|---------| 
| Asset eval | Sandbox_AssetLog.md (ENTRY-XXX) | N/A | N/A |
| MCP tool candidate | Sandbox_AssetLog.md (MCP Candidates section) | TecVooDoo project | com.tecvoodoo.mcp-tools |
| TVD Utilities candidate | Sandbox_AssetLog.md (TVU Candidates section) | Any project | com.tecvoodoo.utilities |
| TVD Games candidate | Sandbox_AssetLog.md (TVG Candidates section) | Any project | com.tecvoodoo.games |

---

**End of Document**
