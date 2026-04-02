# Hide 'N Reap -- Project Status

**Project:** Hide 'N Reap (2.5D Competitive Multiplayer / Social Deception)
**Developer:** TecVooDoo LLC / Rune (Stephen Brandon)
**Unity Version:** 6000.3.10f1 (Unity 6, URP)
**Working Path:** `E:\Unity\Sandbox` (Sandbox incubator)
**HNR Root:** `Assets/_Sandbox/_HNR/`
**Last Updated:** April 1, 2026 (Session 0 -- Bootstrap)

> **ARCHIVE RULE:** This doc holds only the current state and last ~2 sessions. When adding a new session, move older entries to `HNR_StatusArchive.md` (newest first at top of archive). This keeps the status doc fast to read while preserving full history.

**Reference doc:** `HNR_DevReference.md` -- architecture, standards, AI rules. Read on demand.

---

## Current State

**Phase:** Session 0 -- Bootstrap. GDD written. Folder structure created. No code yet.

**Session 0 (Apr 1, 2026) -- Bootstrap:**
- GDD v1.0 created from design notes
- Sandbox folder structure created at `Assets/_Sandbox/_HNR/`
- Docs created: Status, DevReference, CodeReference, GDD
- No packages installed yet (on-demand per new Sandbox approach)

**Next (Session 1 -- Netcode Evaluation):**
- Evaluate netcode options: Unity NGO, FishNet, Mirror
  - Need: authoritative server, state sync for phase transitions, possession ownership
  - Evaluate in Sandbox AssetLog
- Prototype scope: 1 map, 2-3 players, scythe pickup, ghost movement

**Sprint Plan (Sandbox Incubation):**

### Sprint 1: Core Feel + Netcode
- Netcode evaluation and selection
- Ghost movement (2.5D lane-based, phasing)
- Scythe world object (spawn, pickup, ownership transfer)
- Phase state machine (Possession -> Collapse -> Scramble -> loop)
- 2-3 player connection test

### Sprint 2: Possession + NPCs
- NPC behavior state machines (Human: walk-pause-resume)
- Possession system (enter/exit body, scythe-gated)
- Behavior mimicry (player controls NPC actions)
- Collapse event (mass ejection, body explosion VFX)

### Sprint 3: Reaper + Detection
- Reaper role (scythe grants abilities)
- Reaper energy drain + loss conditions
- Lane Strike, Decay Pulse abilities
- Rot system (gradual visual decay on possessed bodies)
- Detection by observation (no UI markers)

### Sprint 4: Playable Prototype
- Score tracking (reap count)
- Match flow (start, loop, end)
- 1 complete map (street + vertical layer)
- 4-player test
- Ready to evaluate standalone migration

---

## Key Decisions (Session 0)

| Decision | Choice | Rationale |
|----------|--------|-----------|
| Camera | 2.5D (3D world, side-view camera) | Lane-based design, AQS 2.5D experience transfers |
| Networking | TBD (eval Sprint 1) | Need authoritative state sync for phase transitions |
| NPC AI | Behavior Designer Pro (state machines) | Already evaluated, TMCP tools built, simple patterns |
| Art style | Bright cartoon horror | Strong silhouettes, clear readability for multiplayer |
| Scope | Prototype in Sandbox, migrate when proven | New bootstrap approach -- on-demand assets only |

---

## Asset Needs (To Be Evaluated)

| Need | Candidates | Priority |
|------|-----------|----------|
| Netcode | NGO, FishNet, Mirror | Sprint 1 -- CRITICAL |
| Character models | Synty, Polyperfect, or placeholder | Sprint 1 |
| Ghost VFX | OccaSoftware Ghost Shader (ENTRY-315), VFX Library | Sprint 2 |
| Explosion VFX | Feel, RayFire (collapse event) | Sprint 2 |
| NPC AI | Behavior Designer Pro 3 (ENTRY-229, already eval'd) | Sprint 2 |
| Scythe model | Asset Store or custom | Sprint 1 |
| Map tileset / ProBuilder | ProBuilder (already in Sandbox) | Sprint 1 |

---

## Known Issues

None yet -- fresh bootstrap.

---

## Reference Documents

| Document | Path |
|----------|------|
| Dev Reference | `Documents\HideNReap\HNR_DevReference.md` |
| Code Reference | `Documents\HideNReap\HNR_CodeReference.md` |
| GDD | `Documents\HideNReap\GDD\HNR_GDD.md` |
| Sandbox Status | `Documents\Sandbox_Status.md` |
| Sandbox Asset Log | `Documents\Sandbox_AssetLog.md` |

---

**End of Document**
