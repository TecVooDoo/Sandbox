# FearSteez - Design Decisions

**Project:** FearSteez
**Developer:** TecVooDoo LLC
**Designer:** Rune (Stephen Brandon)
**Unity Version:** 6.2 (Target)
**Project Path:** E:\TecVooDoo\Projects\Games\2 Planning\FearSteez
**Document Version:** 1
**Last Updated:** December 25, 2025

---

## Version History

| Version | Date | Summary |
|---------|------|---------|
| v1 | Dec 25, 2025 | Initial standardized document from concept docs |

---

## Purpose

This document tracks design decisions, lessons learned, and red flags for FearSteez development.

---

## Core Design Decisions

### Genre Choice

| Decision | Choice | Rationale |
|----------|--------|-----------|
| Primary genre | 2.5D Beat 'Em Up | Classic accessible combat + room for RPG depth |
| RPG integration | Blaster Master-style progression | Meaningful upgrades, not just stat boosts |
| Music integration | Artist's actual tracks | Unique selling point, authentic experience |
| Day/night system | Level-based with transitions | Variety without complexity |

### Combat Design

| Decision | Choice | Rationale |
|----------|--------|-----------|
| Attack philosophy | Mash-friendly with depth | Accessible to casual, rewarding for skilled |
| Combo limit | Enemies recover after X hits | No infinite loops, fair combat |
| Special resource | Stamina bar | Risk/reward for powerful moves |
| Environmental | Throw enemies into walls/each other | Adds tactical depth |

### Technical Choices

| Decision | Choice | Rationale |
|----------|--------|-----------|
| Engine | Unity 6.2 | Consistent with other TecVooDoo projects |
| Architecture | SOAP pattern | Proven in A Quokka Story |
| Input | New Input System | Modern, flexible, cross-platform |
| Combat framework | Custom + evaluate FS Melee | Full control, study existing patterns |

---

## Day/Night Implementation Decision

### Options Considered

| Approach | Pros | Cons |
|----------|------|------|
| Real-time cycle | Immersive, dynamic | Complex, pacing issues |
| Level-based | Predictable, easier design | Less dynamic |
| Player choice | Maximum control | Loses narrative weight |
| Story-driven | Narrative integration | Railroaded |

### Decision

**Level-based with some real-time elements:**
- Certain levels locked to day or night
- Some levels transition mid-level for drama
- Balances variety with design control

---

## Music System Decision

### Options Considered

| Approach | Description | Complexity |
|----------|-------------|------------|
| Jukebox | Full tracks play during levels | Simple |
| Beat-sync | Attacks sync to music for bonuses | Medium |
| Stem mixing | Layers respond to gameplay | Complex |
| Hybrid | Full tracks + stem accents | Medium |

### Decision

**Phased approach:**
1. MVP: Jukebox (full tracks)
2. V1: Beat-sync for special moves
3. Future: Full stem system

---

## Art Style Decision

### Options Under Consideration

| Style | Reference | Achievability |
|-------|-----------|---------------|
| HD Pixel | River City Girls, Scott Pilgrim | Solo-achievable |
| Stylized 2D | Streets of Rage 4 | Animation heavy |
| 2.5D/3D | TMNT Shredder's Revenge | Technical complexity |

### Current Status

**TBD** - Depends on art resources. HD pixel is most achievable for solo development.

---

## Framework Decisions

### Why NOT Use Existing Engines?

| Framework | Reason Against |
|-----------|----------------|
| Corgi Engine | 2D platformer focus, not beat 'em up |
| TopDown Engine | Top-down focus, not side-scroller |
| FS Melee Combat | Evaluate for patterns, but custom preferred |

### Decision

Custom implementation with SOAP architecture. Study FS Melee Combat System for patterns but maintain full control.

---

## Open Design Questions

### Design Questions

| Question | Context | Priority | Status |
|----------|---------|----------|--------|
| Art style? | Determines scope and feel | HIGH | OPEN |
| Co-op support? | Classic beat 'em up feature | MEDIUM | OPEN |
| How many levels? | Scope definition | HIGH | OPEN |
| Boss design approach? | Multi-phase? Patterns? | MEDIUM | OPEN |
| Mobile port? | Affects control design | LOW | OPEN |

### Technical Questions

| Question | Context | Priority | Status |
|----------|---------|----------|--------|
| FS Melee Combat useful? | Evaluate the asset | MEDIUM | OPEN |
| Combo system architecture? | Input buffering, cancels | HIGH | OPEN |
| Save system scope? | Checkpoints? Full state? | MEDIUM | OPEN |

---

## Red Flags / Watch Items

### Current Status: Concept Phase

| Flag | Severity | Status | Notes |
|------|----------|--------|-------|
| Art resources | MEDIUM | OPEN | No art pipeline established |
| Music licensing | HIGH | OPEN | Need formal agreement with artist |
| Scope creep risk | MEDIUM | Monitor | RPG features could expand |
| Unity project not created | LOW | Expected | Normal for concept phase |

---

## Lessons from Other Projects

### From A Quokka Story

| Lesson | Application to FearSteez |
|--------|--------------------------|
| SOAP architecture works | Use same pattern |
| Collision over raycast | Simpler detection for combat |
| GitHub over Unity VC | Same workflow |
| Profile early | Beat 'em ups can have many enemies |
| Asset inventory matters | Check owned assets before building |

### From Beat 'Em Up Genre Research

| Lesson | Application |
|--------|-------------|
| Frame data matters | Define startup/active/recovery for all moves |
| Screen position = fairness | Off-screen enemies shouldn't attack |
| Food heals | Classic pickup design works |
| Bosses need patterns | Learnable, punishable windows |

---

## Asset Decisions

### Relevant Owned Assets

| Asset | Relevance | Decision |
|-------|-----------|----------|
| FS Melee Combat System | Combat foundation | EVALUATE FIRST |
| Animancer Pro v8 | Animation | USE |
| Feel | Game juice | USE |
| Master Audio 2024 | Music system | USE |
| SOAP | Architecture | USE |
| Odin Inspector | Editor tools | USE |
| SensorToolkit 2 | Enemy detection | USE |
| DOTween Pro | Tweening | USE |
| Easy Save | Progression | USE |
| All In 1 Sprite Shader | Visual effects | USE |

### Not Relevant

| Asset | Why Not |
|-------|---------|
| Corgi Engine | Platformer-focused |
| A* Pathfinding Pro | Beat 'em ups use simpler navigation |
| Dialogue System | Minimal story in MVP |
| AA Map System | No exploration/minimap needed |

---

## MVP Scope Control

### What's IN MVP

- FearSteez movement (8-directional)
- Basic attack combo (3-hit)
- One day enemy type
- One night enemy type
- Health system
- XP and level up
- One FearSteez track
- Win condition (clear waves)

### What's OUT of MVP

- Full skill tree
- Equipment system
- Multiple levels
- Boss fights
- Story/cutscenes
- Full polish (juice, particles)
- Co-op
- Mobile

---

## Decision Log

| Date | Decision | Rationale | Decided By |
|------|----------|-----------|------------|
| Dec 4, 2025 | Initial concept documented | Project formalization | Rune |
| Dec 25, 2025 | Standardized documentation | Align with TecVooDoo format | Rune |

---

## Reference Materials

### Concept Art
- `FearSteez_Concept.PNG` - Initial concept image

### Archived Documents
- `FearSteez_ProjectInstructions_UPDATED_12042025.md`
- `FearSteez_DesignDecisions_UPDATED_12042025.md`

---

**End of Design Decisions Document**

This is a living document updated as:
- Concept evolves into production
- Design questions are resolved
- Playtesting provides feedback
- Technical discoveries change approach
