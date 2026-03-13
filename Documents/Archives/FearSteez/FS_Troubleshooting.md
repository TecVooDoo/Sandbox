# FearSteez Troubleshooting (Active)

## Document Purpose

This document defines a repeatable troubleshooting method used to diagnose, track, and resolve complex issues across the FearSteez project.

The method is **process-first**, not domain-specific. While the current issue focus may vary, this same structure is intended to be reused for:
- Combat / Hitboxes
- Movement / Physics
- AI / Enemy Behavior
- UI / Layout
- Audio
- Input
- Networking (future)
- Performance
- Build / Platform-specific issues

Each troubleshooting effort should follow the same lifecycle: observation -> hypothesis -> intervention -> validation -> classification.

---

## Troubleshooting Principles

- Evidence over assumption
- Measure real runtime state, not editor expectations
- One variable change per iteration
- Fix root causes, not symptoms
- Explicitly document constraints and tradeoffs

---

## Issue Classification

All discovered issues must be classified into one of the following categories:

- **Engineering Bug** - Incorrect logic, physics, configuration, or implementation
- **System Constraint** - Engine, platform, or hardware limitation
- **Design / UX Decision** - Tradeoffs that require intentional acceptance
- **Unknown** - Requires additional instrumentation or telemetry

Classification determines whether an issue is fixed, deferred, accepted, or redesigned.

---

## Current Investigation

*No active investigations - project in setup phase*

---

## Investigation Template

When opening a new investigation, copy this template:

```markdown
**Issue: [Brief Description]**

- **Domain:** [Combat/Movement/AI/UI/Audio/Performance/etc.]
- **Session:** [Session number]
- **Date opened:** [Date]
- **Status:** [Investigating/Root cause identified/Fix in progress/Resolved]

---

### Problem Statement

[Clear description of what's wrong]

---

### Test Configuration

- **Conditions:** [How to reproduce]
- **Expected behavior:** [What should happen]
- **Actual behavior:** [What actually happens]

---

### Observations

[Console logs, measurements, visual evidence]

---

### Root Cause Analysis

[What's actually causing the problem]

---

### Affected Code

**File:** `[filename]`
**Location:** [Lines or methods]

---

### Required Fix

[What needs to change]

---

### Guardrails

[Rules to prevent breaking other systems while fixing]
```

---

## Previous Investigations

*None yet - see `FS_Troubleshooting_Archive.md` for closed investigations*

---

## Notes

*Add project-specific troubleshooting notes here as discovered*

---

**End of Troubleshooting Document**
