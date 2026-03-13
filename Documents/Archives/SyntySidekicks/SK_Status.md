# SyntySidekicks - Project Status

| Field | Value |
|-------|-------|
| Project | SyntySidekicks |
| Developer | TecVooDoo |
| Unity Version | 6000.3.7f1 |
| Render Pipeline | URP 17.3.0 |
| Document Version | 1.0 |
| Last Updated | 2026-02-27 |

---

## Purpose

Test and evaluate Synty Sidekick Characters to determine how much can be done programmatically (via MCP and scripts) versus manually in the Editor. The goal is to create characters for other game projects using only the Synty Sidekick system.

## Key Questions to Answer

- How much character creation can be automated via MCP tools and runtime API?
- What requires manual Editor interaction (Modular Character Window)?
- Can characters be created, customized, and exported entirely through code?
- What are the limitations of the Runtime API vs the Editor workflow?
- How well do Sidekick characters integrate into other project pipelines?

---

## Current Phase

**Phase 2: Character Creation Testing**

## Active Work

- [x] Project created (Unity 6000.3.7f1, URP)
- [x] Ivan Murzak MCP packages installed (v0.50.1 + animation/particle/probuilder extensions)
- [x] MCP server connected (localhost:54292)
- [x] Project documentation created
- [x] All Synty Sidekick packs imported (18 categories, 50+ prefabs)
- [x] Default packages installed (DOTween, Odin, UniTask, TecVooDoo Utilities, Cinemachine, etc.)
- [x] Deep research: Runtime API, database schema, IK skeleton, tool changelog, web resources
- [x] Confirmed Runtime API is fully programmatic (not editor-only)
- [x] Test character creation via MCP script-execute (direct Resources.Load + bone remapping)
- [x] Test cross-pack attachment swap (Dark Fantasy hat on Sidekick character)
- [x] Project folder structure created (_Project/Characters/HOK, FearSteez, Exports, etc.)
- [x] PolygonDarkFantasy pack imported
- [ ] Test character creation via SidekickRuntime API (namespace issue in Roslyn — needs workaround)
- [ ] Test color system programmatically (per-character material instances)
- [ ] Test animation integration (Synty animation packs on Sidekick characters)
- [ ] Create first HOK character prototype
- [ ] Test export workflow (.unitypackage for other projects)

---

## Installed Packages (Non-Standard)

| Package | Version | Purpose |
|---------|---------|---------|
| com.ivanmurzak.unity.mcp | 0.50.1 | Unity MCP server (AI game dev tools) |
| com.ivanmurzak.unity.mcp.animation | 1.0.32 | MCP animation tools |
| com.ivanmurzak.unity.mcp.particlesystem | 1.0.20 | MCP particle system tools |
| com.ivanmurzak.unity.mcp.probuilder | 1.0.32 | MCP ProBuilder tools |

## Synty Assets Present

| Asset | Location |
|-------|----------|
| Sidekick Characters (v1.0.37) | Assets/Synty/SidekickCharacters/ |
| SQLite-net (v1.2.4) | Assets/Synty/SidekickCharacters/Plugins/ |
| PolygonDarkFantasy | Assets/PolygonDarkFantasy/ |

---

## Session History

### Session 1 (2026-02-26) -- Setup & Deep Research
- Created Unity project with URP
- Installed Ivan Murzak MCP packages via OpenUPM scoped registry
- Configured .mcp.json for MCP server (port 54292)
- Verified MCP tools connected and operational
- Created project documentation (Status, DevReference, AssetReference)
- Imported all Synty Sidekick character packs (18 categories)
- Installed default packages (DOTween, Odin, UniTask, Animation Rigging, Cinemachine, etc.)
- Deep research completed: full Runtime API surface, 24-table database schema, 62 source files analyzed
- Investigated IK skeleton structure (ik_hand_root/ik_foot_root are Mecanim IK targets, separate from FK skeleton)
- Confirmed: Runtime API supports full programmatic character creation without editor window
- Known limitation: body blend saves for in-game use not yet supported by Synty

### Session 2 (2026-02-27) -- MCP Character Creation & Cross-Pack Testing
- Created character via MCP script-execute using direct Resources.Load + bone remapping (bypassed SidekickRuntime due to Roslyn namespace issue)
- Key findings from MCP character creation:
  - SK_BaseModel comes with 24 default SK_SPEC_ parts that must be removed after instantiation
  - M_BaseMaterial alone doesn't render correctly — must use Sidekick_ShaderGraph with populated color textures
  - Each character needs its own material instance for unique colors
  - Direct part loading + bone remapping works without SidekickRuntime API
- Investigated combined mesh bug: `mesh` child has 2116 bones all NULL after save/reload (vertices collapse to origin)
- Confirmed SkinnedMeshRenderer parts ignore Transform.scale (bone-weighted vertices)
- Discovered attachment bone distinction: skinned parts (22AHED, 23AFAC) vs attachment point bones (headAttach, prop_l/r) — bone Transforms DO respond to scale
- Imported PolygonDarkFantasy pack
- Successfully swapped hat on Human-Custom: replaced SK_APOC_SURV_04_22AHED_HU01 with SM_Chr_Attach_Gravedigger_Hat_01
  - Static meshes (SM_ prefix) parent to attachment bones and follow skeleton
  - Scale 1:1 between Dark Fantasy and Sidekick characters
  - Y offset = negative mesh bounds center Y to seat on bone (hat needed localY=-0.2)
  - Different materials coexist fine (URP/Lit alongside Sidekick_ShaderGraph)
- Created _Project folder structure for HOK and FearSteez character exports

---

## Known Issues

| Issue | Severity | Status | Notes |
|-------|----------|--------|-------|
| SidekickRuntime namespace not found in Roslyn | Medium | Open | `Synty.SidekickCharacters.API` can't resolve in MCP script-execute. Workaround: direct Resources.Load + bone remapping |
| Combined mesh NULL bones on reload | Medium | Documented | Combiner's `mesh` child loses all 2116 bone refs. Fix: delete mesh child or use combineMesh:false |
| Per-character material instances needed | Low | Open | Borrowing material from existing character works but need proper per-character material creation workflow |

---

## Session Close Checklist

- [ ] Update Active Work section
- [ ] Add session summary to Session History
- [ ] Update Known Issues if applicable
- [ ] Move old sessions to SK_Status_Archive.md when this file exceeds ~10 sessions

---

## Reference Documents

- [SK_DevReference.md](SK_DevReference.md) -- Architecture, Sidekick system overview, coding patterns
- [SK_AssetReference.md](SK_AssetReference.md) -- Complete Sidekick asset inventory (parts, species, colors, animations)
