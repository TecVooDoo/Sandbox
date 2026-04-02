# Hide 'N Reap -- Project Status

**Project:** Hide 'N Reap (2.5D Competitive Multiplayer / Social Deception)
**Developer:** TecVooDoo LLC / Rune (Stephen Brandon)
**Unity Version:** 6000.3.10f1 (Unity 6, URP)
**Working Path:** `E:\Unity\Sandbox` (Sandbox incubator)
**HNR Root:** `Assets/_Sandbox/_HNR/`
**Last Updated:** April 2, 2026 (Session 2 -- Mechanics Review)

> **ARCHIVE RULE:** This doc holds only the current state and last ~2 sessions. When adding a new session, move older entries to `HNR_StatusArchive.md` (newest first at top of archive). This keeps the status doc fast to read while preserving full history.

**Reference doc:** `HNR_DevReference.md` -- architecture, standards, AI rules. Read on demand.

---

## Current State

**Phase:** Session 2 -- GDD v2.0 written. Original mechanics restored. Ready for prototyping.

**Session 2 (Apr 2, 2026) -- Mechanics Review:**
- Reviewed GDD against original paper-napkin design (pre-crash)
- Identified significant complexity creep in v1.0/v1.1: phase system, scythe-gated possession, collapse events, Reaper energy drain, Lane Strike/Decay Pulse abilities -- all added to solve problems that the original "possess the dead" mechanic never had
- Restored original core mechanics:
  - Two overlapping worlds (supernatural + living). Possessed players blind to supernatural.
  - Ghosts possess the DEAD only (not living NPCs). Bodies are a scarce resource.
  - Reaper can only reap exposed ghosts. Cannot interact with living world.
  - Scythe and possession are mutually exclusive. Reaper drops scythe voluntarily to go possess.
  - Environmental hazards are the primary body-supply system (random NPC kills).
  - Rot is per-body (not per-ghost), persists across possessions, fresh bodies last longer.
  - Possession cooldown after exiting any body (prevents instant body-hopping).
  - Successful reap drains scythe -- disappears, recharges, respawns randomly.
- CUT: Phase system, Collapse event, Reaper energy, scythe-gated possession, Lane Strike, Decay Pulse
- GDD updated to v2.0
- Graveyard is now the tutorial map (starts with pre-dead bodies)

**Session 1 (Apr 2, 2026) -- Art Direction + Foundations:**
- Visual lineup scene at `Assets/_Sandbox/_HNR/ArtEval/`
- 5 art packs evaluated, multi-pack art direction confirmed
- PurrNet 1.19.1 locked in as netcode
- Single screen confirmed
- 3 maps, 6 NPC types defined

**Session 0 (Apr 1, 2026) -- Bootstrap:**
- GDD v1.0, folder structure, docs created

**Next (Session 3 -- Foundation Sprint):**
- IGhostInput interface + LocalGhostInput (keyboard)
- World layer system (supernatural/living camera culling)
- Ghost controller + movement (2.5D, phasing)
- NPC spawner + lifecycle (alive -> dead)
- Basic possession (enter/exit dead body + cooldown)
- Graveyard test map (primitives, pre-placed bodies)

**Sprint Plan (Single-Player First, Network Last):**

### Sprint 1: Foundation (Local, Primitives)
- IGhostInput interface + LocalGhostInput implementation
- World layer system (camera culling mask toggle on state change)
- Ghost controller + movement (2.5D lane-based, phasing, uses IGhostInput)
- NPC spawner + lifecycle state machine (Alive -> Dead -> Possessed -> Destroyed)
- Possession system (enter/exit dead body, cooldown timer)
- Graveyard test map (primitives -- cubes/capsules, pre-placed bodies at various rot)
- **Playtest:** Move as ghost, possess body, see world layer switch, exit, feel cooldown

### Sprint 2: Scythe + Rot (The Economy)
- Rot system (per-body timer, persists across possessions, damage acceleration, visual decay)
- Scythe system (pickup/drop/drain/recharge/random respawn)
- Reaper state (can see ghosts, reap exposed ghosts, can't possess, can't interact)
- Possessed body interaction (attack other bodies, kill living NPCs -> create fresh bodies)
- Config SOs for all tuning values (rot rates, scythe timers, cooldown duration)
- **Playtest:** Full tactical loop with one player swapping roles. Body economy feel check.

### Sprint 3: NPC Behavior + Hazards (The Deception)
- NPC behavior trees (Behavior Designer Pro -- living NPC patterns, NOT player mimic)
- Body-type movement (body determines capabilities: climb, fly, burrow, etc.)
- Environmental hazard system (1-2 types, random timing, NPC area kills)
- Possessed player detection (aggression, unnatural stillness, rot visuals)
- Possessed player combat (attack other bodies, kill NPCs)
- **Playtest:** Can possessed players spot each other? Does body-type movement feel right?

### Sprint 4: AI Opponents (Single-Player Complete)
- AIGhostInput (implements IGhostInput, driven by Behavior Designer Pro)
- AI ghost behavior (find bodies, evaluate rot, possess, act naturally, attack strategically)
- AI Reaper behavior (hunt exposed ghosts, drop-possess-chaos-reap loop)
- Match flow (start, timer, scoring, end screen)
- Difficulty tuning
- **Playtest:** Full single-player game. 1 human vs 2-3 AI ghosts. Is it fun?

### Sprint 5: Art Pass + Second Map
- Swap primitives for real art (Kenney, Cute Pet, Assembly Kit, KayKit)
- City Street map (zero starting bodies, hazard-dependent economy)
- Audio cues (death, scythe, reap, rot warnings, hazard warnings)
- Rot VFX (progressive visual decay)
- **Playtest:** Does it look/feel like a game? City Street vs Graveyard feel different?

### Sprint 6: Networking (PurrNet)
- NetworkGhostInput (implements IGhostInput, PurrNet RPCs)
- Server-authoritative state sync (scythe, rot, NPC lifecycle, possession)
- AI players on host
- Purr Transport relay (lobby, room creation, player count + AI fill)
- Per-client world layer rendering
- **Playtest:** 2-player test over relay. Same feel as local?

### Sprint 7: Playable Prototype
- 3-4 player mixed (human + AI) testing
- Barnyard map
- Final tuning pass
- Evaluate standalone migration

---

## Key Decisions

| Decision | Choice | Rationale |
|----------|--------|-----------|
| Camera | 2.5D single screen | Lane-based design, full playfield visibility for observation-based detection |
| Networking | PurrNet 1.19.1 (ENTRY-260) | Per-component ownership, built-in relay, awaitable RPCs |
| NPC AI | Behavior Designer Pro (state machines) | Already evaluated, TMCP tools built, simple patterns |
| Art style | Bright cartoon horror (multi-pack) | See Art Direction below |
| Core mechanic | Possess the dead (original design) | Emergent body economy replaces artificial phase system |
| World model | Two overlapping worlds | Supernatural (ghosts/Reaper/scythe) + Living (NPCs/bodies/props) |
| Scythe economy | Drain on reap, random respawn | Prevents Reaper camping, forces regular state transitions |
| Scope | Prototype in Sandbox, migrate when proven | New bootstrap approach -- on-demand assets only |

---

## Art Direction (Session 1 -- Apr 2, 2026)

Evaluated KayKit, Kenney, Tiny Treats, Cute Pet (Suriyun), Assembly Kit (Sigmoid) in a visual lineup scene (`Assets/_Sandbox/_HNR/ArtEval/`). Multi-pack strategy confirmed -- distinct roles per pack prevent style clash and add to the overall aesthetic.

| Role | Pack | Notes |
|------|------|-------|
| **Human NPCs** | Kenney Animated Characters (Medium) | Smooth shading pairs with Cute Pet. Scale 1. Medium only -- Large clashes. |
| **Child NPCs** | Kenney Animated Characters (Small) | Scale 0.5. Same UV/skins as Medium. |
| **Animals** | Cute Pet (Suriyun) | Smooth chibi style. Scale ~5x to match Kenney characters. |
| **Reaper / Ghost** | Assembly Kit (Sigmoid / ForActionGames) | Perfect style match with Cute Pet. Same scale. Has Reaper with scythe + Ghost built in. |
| **Buildings / Environment** | KayKit + Tiny Treats (Isa Lousberg) | Chunky atlas style. Tiny Treats scale ~0.3x to match KayKit. |
| **Horror props** | KayKit Halloween | Gravestones, coffins, skull posts. |
| **Items / Pickups** | Assembly Kit (Sigmoid) | Sword, key, bomb, treasure, etc. Smooth style matches characters. |
| **Scythe** | KayKit Skeletons | Skeleton_Scythe.fbx. Atlas textured. |

**Rejected:** Kenney Graveyard Kit (blocky/voxel). Kenney Large characters (proportion clash). KayKit characters as NPCs (atlas clash with Cute Pet).

**Skin library:** Kenney Bundle has 50+ skins -- all work on both Medium and Small meshes.

---

## Asset Needs

| Need | Decision | Status |
|------|----------|--------|
| Netcode | PurrNet 1.19.1 (ENTRY-260, already installed) | RESOLVED -- Session 1 |
| Character models | Kenney Animated Characters (Medium + Small) | RESOLVED -- Session 1 |
| Animals | Cute Pet (Suriyun) -- already installed | RESOLVED -- Session 1 |
| Reaper / Ghost | Assembly Kit (ForActionGames) -- already installed | RESOLVED -- Session 1 |
| Environment | KayKit + Tiny Treats (CC0, external) | RESOLVED -- Session 1 |
| Horror props | KayKit Halloween (CC0, external) | RESOLVED -- Session 1 |
| Items / Pickups | Assembly Kit (ForActionGames) | RESOLVED -- Session 1 |
| Scythe model | KayKit Skeletons pack (Skeleton_Scythe.fbx) | RESOLVED -- Session 1 |
| Ghost VFX / supernatural layer | OccaSoftware Ghost Shader (ENTRY-315), VFX Library | Sprint 1 -- TBD |
| Rot VFX | Shader-based decay, particle effects | Sprint 2 -- TBD |
| NPC AI | Behavior Designer Pro 3 (ENTRY-229, already eval'd) | Sprint 2 -- TBD |
| Map tileset / ProBuilder | ProBuilder (already in Sandbox) | Sprint 1 -- TBD |

---

## Known Issues

None yet -- fresh bootstrap.

---

## Reference Documents

| Document | Path |
|----------|------|
| Dev Reference | `Documents\HideNReap\HNR_DevReference.md` |
| Code Reference | `Documents\HideNReap\HNR_CodeReference.md` |
| GDD | `Documents\HideNReap\GDD\HNR_GDD.md` (v2.0) |
| Sandbox Status | `Documents\Sandbox_Status.md` |
| Sandbox Asset Log | `Documents\Sandbox_AssetLog.md` |

---

**End of Document**
