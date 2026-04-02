# Hide 'N Reap -- Game Design Document

**Project:** Hide 'N Reap
**Genre:** Competitive Multiplayer / Social Deception / Action-Humor
**Camera:** 2.5D (side view with limited depth lanes)
**Players:** 1-5 (single player vs AI, mixed human/AI, or pure PvP)
**Version:** 2.0
**Last Updated:** April 2, 2026

---

## 1. High Concept

Players are ghosts in a world of the living. The dead are your hiding places -- possess a corpse and pretend to be alive. One ghost claims the scythe to become the Reaper, who can reap exposed ghosts for points. But the Reaper can't touch the living world. To create chaos, the Reaper must drop the scythe, possess a body, and do damage the old-fashioned way -- then race back to reap the ghosts that pop out. Most reaps wins.

---

## 2. Core Gameplay Pillars

1. **Two Worlds Overlap** -- The supernatural world (ghosts, Reaper, scythe) and the living world (NPCs, props, hazards) occupy the same space. Possessed players see only the living world. Ghosts and the Reaper see both but can only interact with the supernatural.
2. **The Dead Don't Walk Right** -- Possessing a corpse means faking life. Rot, stiffness, behavioral mistakes expose you.
3. **Power is a Choice** -- The Reaper can drop the scythe at any time. Possession and the scythe are mutually exclusive. Every transition is a player decision with risk.
4. **Chaos Creates Opportunity** -- Environmental hazards randomly kill NPCs. Possessed players kill NPCs. More death = more hiding spots = more targets.

---

## 3. Two Worlds

### 3.1 Supernatural Layer

**Who exists here:** Ghosts, the Reaper, the scythe.

**What they see:** Each other, the scythe, AND the living world (NPCs, buildings, props, hazards). Both layers are visible.

**What they can do:** Move freely, phase through objects, pick up the scythe. CANNOT interact with the living world in any way.

### 3.2 Living Layer

**Who exists here:** Living NPCs, dead bodies, possessed bodies, props, environmental hazards.

**What possessed players see:** The living world ONLY. Cannot see ghosts, the Reaper, or the scythe. Completely blind to the supernatural.

**What possessed players can do:** Full physical interaction. Kill NPCs, attack other possessed bodies, knock over props, trigger hazards.

### 3.3 Information Asymmetry

- **Ghosts** know where the Reaper is but can't do anything about it without a body.
- **The Reaper** can see all exposed ghosts but can't tell which NPCs are possessed vs genuine.
- **Possessed players** are blind to the supernatural. The Reaper could be right next to you and you'd never know. You must exit your body (exposing yourself) to check.

---

## 4. Match Flow (Core Loop)

### Start of Match
- All players spawn as ghosts in the supernatural layer
- NPCs are alive and walking in the living world
- Scythe spawns at a random location (visible to ghosts only)
- No dead bodies yet (except on Graveyard map)

### Core Loop (Continuous -- No Phases)
- Environmental hazards kill NPCs -> dead bodies appear
- Ghosts possess dead bodies, start mimicking living behavior
- Possessed players interact with the living world (kill NPCs, attack other possessed bodies, create chaos)
- A ghost picks up the scythe -> becomes Reaper
- Reaper hunts exposed ghosts (ghosts without bodies, ghosts ejected by rot, ghosts peeking out)
- Successful reap -> scythe drains, disappears, recharges, respawns randomly
- Reaper becomes a regular ghost after reap (needs a body now)
- Rot ejects ghosts from bodies over time -> exposed, vulnerable
- Match ends on timer or first to target reap count

**There are no phases.** The game flows continuously. Tension comes from the body economy and the two-world information gap.

---

## 5. Win Condition

Player with the highest number of reaps wins.

---

## 6. Player States

### 6.1 Ghost (Default State)

**Abilities:**
- Fast movement
- Phase through objects
- See both worlds (supernatural + living)
- Possess dead bodies (subject to cooldown)
- Pick up the scythe

**Limitations:**
- Cannot interact with the living world
- Vulnerable to instant reap by the Reaper
- Subject to possession cooldown after exiting a body

### 6.2 Possessed State

**Requirements:**
- A dead body must exist
- Ghost must not be in possession cooldown

**Abilities:**
- Full physical interaction with the living world
- Kill NPCs (creates new dead bodies)
- Attack other possessed bodies (accelerates rot/damage, can force ejection)
- Interact with props and hazards
- Mimic NPC behavior to blend in

**Limitations:**
- CANNOT see ghosts, the Reaper, or the scythe
- Body rots over time (rot is on the body, not the ghost)
- Damage to body reduces remaining rot time
- Full rot = ejected, body destroyed
- Possession cooldown on exit (voluntary or forced)

### 6.3 Reaper (Scythe Holder)

**Activation:** Ghost picks up the scythe.

**Abilities:**
- Reap exposed ghosts (scores a point)
- See both worlds (supernatural + living)
- Move freely in the supernatural layer

**Limitations:**
- CANNOT possess bodies while holding the scythe
- CANNOT interact with the living world
- CANNOT reap possessed players (must wait for ejection)
- CANNOT directly identify which NPCs are possessed (watches for behavioral tells)
- Successful reap drains the scythe (disappears, recharges, respawns randomly)
- After reap, becomes a regular ghost with possession cooldown

**Voluntary Drop:** The Reaper can drop the scythe at any time, becoming a regular ghost. The scythe remains where dropped, visible to all ghosts, available for pickup.

---

## 7. Core Systems

### 7.1 Scythe System

A world object visible only in the supernatural layer.

**States:**
- **Available** -- on the ground, any ghost can pick it up
- **Held** -- a ghost has it, is the Reaper
- **Draining** -- successful reap, scythe disappears
- **Recharging** -- off the field, timer counting down
- **Respawning** -- appears at a random location

**Rules:**
- Pick up = become Reaper
- Drop = voluntary, scythe stays where dropped
- Successful reap = scythe drains, disappears, respawns randomly after recharge timer
- Only one scythe exists

### 7.2 Possession System

**Rules:**
- Ghosts can only possess dead bodies (not living NPCs)
- Possession cooldown after exiting any body (voluntary exit or rot ejection)
- Cooldown applies equally -- no instant body-hopping
- Ghost enters body -> body stands up, ghost controls it
- Ghost exits body -> body drops, ghost appears in supernatural layer, cooldown starts
- The Reaper cannot possess bodies (scythe blocks possession)

### 7.3 NPC Lifecycle

**States:**
- **Alive** -- walking, behaving, part of the living world
- **Dead** -- killed by hazard, possessed player, or other NPC interaction. Body on the ground. Possessable.
- **Possessed** -- ghost inside, body animated, mimicking life. Rot ticking.
- **Destroyed** -- rot reached zero or excessive damage. Body gone. Ghost ejected.

### 7.4 Rot System

**Rot is a property of the body, not the ghost.**

- Each body has a rot meter representing remaining usable time
- **Fresh kill:** maximum rot time available
- **Old corpse:** reduced rot time (e.g., graveyard bodies start partially rotted)
- **Ancient remains:** too far gone to possess at all
- Rot ticks down whether the body is possessed or not (dead things decay)
- Rot ticks faster when possessed (animation accelerates decay)
- Damage to the body reduces remaining rot time directly
- Rot persists across possessions -- ghost leaves, rot continues, next ghost gets whatever time is left
- At zero rot, body is destroyed and any ghost inside is ejected

**Tuning levers:**
- Base rot rate (passive decay)
- Possession rot multiplier (how much faster while animated)
- Damage-to-rot conversion (how much rot time damage removes)
- Fresh kill rot time vs. hazard kill rot time vs. pre-placed body rot time

### 7.5 Environmental Hazard System

Random events that kill NPCs in the living world. This is the primary body-supply system.

**Examples:**
- Runaway vehicle (City Street)
- Falling debris / collapsing structure
- Meteor strike (random area)
- Tornado (sweeps a lane)
- Lightning strike
- Animal stampede (Barnyard)

**Rules:**
- Map-specific hazard pools
- Random timing with min/max intervals
- Kill NPCs in an area -> create fresh dead bodies
- Can also damage/destroy possessed bodies caught in the area
- NOT player-controlled (pure environmental chaos)
- Possessed players can see and attempt to avoid hazards

### 7.6 Detection System

**No UI markers.** Detection is purely observational.

**Tells that expose a possessed player:**
- Behavioral inconsistencies (wrong movement pattern for that NPC type)
- Movement errors (human-like input on an animal body)
- Rot visuals (decaying appearance gets worse over time)
- Timing mistakes (pausing, hesitating, reacting to things an NPC wouldn't)
- A "dead" NPC suddenly walking again in a suspicious area
- Attacking other NPCs (living NPCs don't typically murder each other)

**Who detects:**
- The Reaper watches from the supernatural layer for behavioral tells
- Other possessed players watch each other in the living world (but can't see if the Reaper is nearby to capitalize)

---

## 8. Environment Design

**Structure:** 2.5D Lane-Based, Single Screen
- 2-3 depth lanes maximum
- Single screen (no scrolling) -- all players visible at all times
- Vertical layers provide density (street + rooftop, ground + loft)

**Single Screen Rationale:**
- Detection is observation-based -- players must see the whole playfield to spot behavioral mistakes
- Both worlds overlap on the same screen
- Hazard events need full visibility for dramatic impact
- Scythe respawns need equal awareness

**Design Rules:**
- Compact maps
- High visibility
- No excessive empty space
- Every lane/layer must be observable from any position

---

## 8.1 Map Roster

| Map | Theme | Art Packs | NPCs | Body Economy | Design Hook |
|-----|-------|-----------|------|-------------|-------------|
| **Graveyard** (tutorial) | Horror | KayKit Halloween (gravestones, coffins, skull posts) | Humans, Cats (Cute Pet) | Starts with many pre-dead bodies at various rot stages. Forgiving. | Teaches possession, rot awareness, body selection. Some graves ancient (unusable), some fresh. |
| **City Street** | Urban | KayKit buildings + Halloween props, Tiny Treats houses | Humans (Kenney Medium), Dogs (Cute Pet) | Starts with zero bodies. Dependent on hazards + possessed players. Scarce, competitive. | Classic map. Runaway vehicles, falling debris. Walking humans easiest to mimic. |
| **Barnyard** | Rural | Tiny Treats houses, KayKit environment | Dogs, Pigs, Sheep, Chickens (Cute Pet) | Animal deaths from hazards and stampedes. | Possess dead animals. Mimicking animal behavior is a totally different observation challenge. |

---

## 9. NPC Types

| Type | Behavior Pattern | Mimic Difficulty | Art Pack |
|------|-----------------|------------------|----------|
| Human | Walk - Pause - Resume | Easy | Kenney Animated Characters (Medium) |
| Dog | Wander - Sniff - Sit | Medium | Cute Pet (Suriyun) |
| Cat | Roam - Pounce - Groom | Hard (erratic) | Cute Pet (Suriyun) |
| Pig | Slow waddle - Root - Rest | Easy | Cute Pet (Suriyun) |
| Sheep | Herd movement - Graze - Bleat | Medium (herd sync) | Cute Pet (Suriyun) |
| Chicken | Peck - Scatter - Short flight | Hard (unpredictable) | Cute Pet (Suriyun) |

**Design Rule:** Behavior must be observable and mimic-able. Players need to be able to learn patterns by watching.

---

## 10. Player Modes + Architecture

### 10.1 Player Modes
- **Single player:** 1 human vs chosen number of AI opponents (2-4 AI ghosts)
- **Multiplayer:** 2-5 players, any mix of human and AI opponents
- **Pure PvP:** All human players, no AI ghosts

### 10.2 Input Architecture
Ghost and body controllers accept commands from an input provider interface. The game systems do not distinguish between human, network, or AI input sources. A ghost is a ghost whether a person or AI is driving it.

**Input providers:**
- Local player (keyboard/gamepad)
- Network player (PurrNet)
- AI player (Behavior Designer Pro)

**AI players must handle the full tactical loop:** possess bodies, mimic NPC behavior, decide when to grab/drop the scythe, execute hunting strategies, evaluate body rot and body selection.

### 10.3 Network Requirements
- Clear visual readability across both world layers
- Reliable state synchronization:
  - Scythe state (available, held, draining, respawning)
  - Possession state per player
  - Body rot values (per-body, server-authoritative)
  - NPC lifecycle (alive, dead, possessed, destroyed)
  - Possession cooldown timers
- PurrNet per-component ownership maps well to body ownership transfer
- AI players run server-side (host manages AI decisions)

---

## 11. Visual Style

- Bright, stylized, cartoon horror
- Exaggerated animations for clarity
- Strong silhouettes
- Supernatural layer: desaturated/ethereal overlay or ghost shader effect
- Living layer: full color, vibrant
- Rot: progressive visual decay on possessed bodies (color drain, particle effects)

---

## 12. Audio Style

- Light, playful tone
- Sharp audio cues for:
  - NPC death (body available)
  - Scythe respawn (supernatural layer only)
  - Reap event
  - Environmental hazard warning
  - Rot threshold warnings (for the possessing player)

---

## 13. Technical Direction

- Engine: Unity 6 (URP, 3D with 2.5D camera)
- NPC AI: State machine-driven (Behavior Designer Pro)
- Ghost AI: Behavior Designer Pro (same tool, handles full ghost tactical loop)
- Input architecture: Interface-based input providers (local, network, AI) -- game systems input-source agnostic
- Networking: PurrNet 1.19.1 (per-component ownership, built-in relay, awaitable RPCs)
- World layering: Camera culling layers or shader-based visibility per player state

---

## 14. Prototype Scope (DO NOT EXPAND YET)

- 1 map (Graveyard -- tutorial, pre-placed bodies for easier testing)
- 2-3 players
- Core systems only:
  - Two-world visibility (supernatural vs living layer)
  - NPC lifecycle (alive -> dead -> possessable -> destroyed)
  - Scythe pickup/drop/drain/respawn
  - Ghost possession of dead bodies + cooldown
  - Reaper reap (exposed ghosts only)
  - Basic rot (per-body timer + visual)
  - 1 environmental hazard
  - Score tracking (reap count)

---

## 15. Key Risks

| Risk | Impact | Mitigation |
|------|--------|------------|
| Not enough NPCs dying | No bodies to possess, ghosts exposed too long | Tune hazard frequency, ensure minimum body supply |
| Too many NPCs dying | Too easy to hide, Reaper frustrated | Reduce hazard frequency, faster rot |
| Rot too fast | Constant ejection, no time to play | Increase fresh body rot time |
| Rot too slow | Body camping, no tension | Decrease rot time, increase possession rot multiplier |
| Scythe never dropped | One player sits as Reaper doing nothing | Scythe auto-drains after inactivity? Or natural gameplay pressure -- no reaps if no exposed ghosts |
| Possession cooldown too short | Instant body-hopping, no exposure risk | Increase cooldown |
| Possession cooldown too long | Ghosts stuck exposed, frustrating | Decrease cooldown |
| Two-world rendering complexity | Performance, visual clarity | Start simple (camera culling layers), iterate |

---

## 16. Design Summary

Hide 'N Reap is a continuous-flow competitive deception game built on two overlapping worlds. Ghosts hide in dead bodies and pretend to be alive. The Reaper hunts exposed ghosts but can't touch the living world. Environmental chaos creates the bodies everyone needs. Every action -- possessing, attacking, dropping the scythe, peeking at the supernatural world -- carries risk. Simple rules, emergent tactics.

---

## Art Direction (Session 1, Apr 2 2026)

| Role | Pack | Scale | Notes |
|------|------|-------|-------|
| Human NPCs | Kenney Animated Characters (Medium) | 1 | 50+ skins. Small variant (scale 0.5) for children only. |
| Animals | Cute Pet (Suriyun) | ~5x | Cat, Dog, Pig, Sheep, Chicken, Cow, etc. |
| Reaper / Ghost | Assembly Kit (Sigmoid / ForActionGames) | native | Reaper with scythe + Ghost built in. Style matches Cute Pet. |
| Buildings / Environment | KayKit + Tiny Treats (Isa Lousberg) | TT at 0.3x | Chunky atlas style. CC0. |
| Horror props | KayKit Halloween | native | Gravestones, coffins, skull posts. |
| Items / Pickups | Assembly Kit (Sigmoid) | native | Sword, key, bomb, treasure, etc. |
| Scythe | KayKit Skeletons | native | Skeleton_Scythe.fbx |

**Rejected:** Kenney Large characters, Kenney Graveyard Kit (voxel), KayKit characters as NPCs.

---

**End of Document**
