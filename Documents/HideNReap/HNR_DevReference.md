# Hide 'N Reap -- Dev Reference

**Purpose:** Architecture, coding standards, and AI rules for Hide 'N Reap. Read on demand -- primary doc is `HNR_Status.md`.
**Last Updated:** April 1, 2026 (Session 0 -- Bootstrap)

---

## Project Overview

**Genre:** Competitive Multiplayer / Social Deception / Action-Humor
**Engine:** Unity 6 (6000.3.10f1), URP
**Working Path:** `E:\Unity\Sandbox` (Sandbox incubator)
**HNR Root:** `Assets/_Sandbox/_HNR/`

**Core Innovation:** Phase-driven deception game where the scythe is a contested power object. Possession is conditional on the scythe existing -- lose it and everyone is exposed.

---

## Namespaces

| Namespace | Purpose | Status |
|-----------|---------|--------|
| `HNR.Core` | Match state, phase manager, game events, scythe system | Planned |
| `HNR.Player` | Ghost controller, input, player state | Planned |
| `HNR.Reaper` | Reaper abilities, energy, detection | Planned |
| `HNR.Possession` | Possession system, body management, rot | Planned |
| `HNR.NPC` | NPC behavior, state machines, variation | Planned |
| `HNR.Network` | Netcode abstraction, state sync, RPCs | Planned |
| `HNR.UI` | HUD, score, match flow UI | Planned |
| `HNR.Audio` | SFX, music, audio cues | Planned |

---

## Folder Structure

```
Assets/_Sandbox/_HNR/
|
+-- Scripts/
|   +-- Core/           -- MatchManager, PhaseManager, ScytheSystem, GameEvent
|   +-- Player/         -- GhostController, PlayerInput, PlayerState
|   +-- Reaper/         -- ReaperController, ReaperAbilities, EnergySystem
|   +-- Ghost/          -- GhostMovement, GhostPhasing
|   +-- Possession/     -- PossessionSystem, BodyManager, RotSystem
|   +-- NPC/
|   |   +-- Behaviors/  -- HumanBehavior, DogBehavior, BirdBehavior
|   +-- Network/        -- NetworkManager, StateSync, PhaseSync
|   +-- UI/
|   +-- Audio/
|   +-- Test/
|
+-- Art/
|   +-- Characters/     -- Ghost, Reaper, NPC models
|   +-- Environments/   -- Street, interiors, vertical spaces
|   +-- VFX/            -- Collapse, possession, reap effects
|   +-- UI/
|
+-- Audio/
|   +-- SFX/
|   +-- Music/
|
+-- Data/
|   +-- NPCs/           -- NPC behavior template SOs
|   +-- Events/          -- GameEvent SOs
|   +-- Scythe/          -- Scythe config SOs
|   +-- Maps/            -- Map layout data
|
+-- Prefabs/
+-- Scenes/
+-- Animations/
```

---

## Architecture

### Phase State Machine (Core Loop Driver)

```
                    +------------------+
                    |   MATCH START    |
                    +--------+---------+
                             |
                    +--------v---------+
              +---->| POSSESSION PHASE |<----+
              |     | (Scythe Active)  |     |
              |     +--------+---------+     |
              |              |               |
              |     Reaper energy depletes   |
              |     or takes enough damage   |
              |              |               |
              |     +--------v---------+     |
              |     | COLLAPSE PHASE   |     |
              |     | (All Exposed)    |     |
              |     +--------+---------+     |
              |              |               |
              |     +--------v---------+     |
              +-----| SCRAMBLE PHASE   +-----+
                    | (Scythe Respawn) |
                    +------------------+
```

### Network Authority Model (TBD -- depends on netcode choice)

**State that MUST be server-authoritative:**
- Scythe ownership (who is Reaper)
- Phase transitions (Possession -> Collapse -> Scramble)
- Possession state (which player owns which NPC body)
- Reap events (score changes)
- Rot progression

**State that can be client-predicted:**
- Ghost movement
- NPC behavior playback (deterministic state machines)
- Visual effects (collapse, VFX)

### Event Architecture

Communication via GameEvent ScriptableObjects (same as all TecVooDoo projects):

```
ScytheSystem
    +--- OnScytheClaimed ---> PhaseManager (enter Possession Phase)
    +--- OnScytheLost ---> PhaseManager (enter Collapse Phase)
    +--- OnScytheRespawn ---> PhaseManager (enter Scramble Phase)

PossessionSystem
    +--- OnBodyPossessed ---> RotSystem (start decay timer)
    +--- OnBodyEjected ---> VFX (ghost emerge effect)
    +--- OnCollapseTriggered ---> ALL bodies (explode, eject all)

ReaperSystem
    +--- OnReapSuccess ---> ScoreManager (increment kills)
    +--- OnEnergyDepleted ---> ScytheSystem (scythe lost)
    +--- OnReaperDamaged ---> EnergySystem (drain energy)

MatchManager
    +--- OnMatchStart ---> All systems (initialize)
    +--- OnMatchEnd ---> UI (show scoreboard)
```

### Design Patterns

1. **Vanilla ScriptableObject Architecture** -- GameEvent/GameEventListener for events, config SOs for NPC behaviors, scythe settings, map data.
2. **Phase State Machine** -- TecVooDoo Games StateMachine (CRTP) for match flow.
3. **Interface Segregation** -- `IPossessable`, `IReapable`, `IDetectable`, `IPhaseListener`
4. **Object Pooling** -- EasyPooling 2025 for VFX, ghost trails, collapse particles.
5. **PersistentSingleton** -- TecVooDoo Utilities for MatchManager, NetworkManager.

---

## Coding Standards

Same as all TecVooDoo projects:

- **No `var`** -- explicit types always
- **No per-frame allocations/LINQ** -- cache, pool, reuse
- **ASCII only** in docs and identifiers
- **sealed on MonoBehaviours** -- unless inheritance intended
- **Prefer async/await (UniTask)** -- over coroutines
- **Prefer interfaces and generics** -- decouple systems, reduce duplication
- **Vanilla SO architecture** -- GameEvent/GameEventListener (NOT SOAP)
- **Extract by responsibility** -- not by line count
- **Production-quality test code** -- even in Sandbox prototype

### Multiplayer-Specific Standards

- **Server-authoritative state changes** -- clients request, server validates and broadcasts
- **Deterministic NPC behavior** -- same seed = same behavior on all clients
- **Network abstraction layer** -- wrap netcode behind interfaces so we can swap NGO/FishNet/Mirror
- **Phase transitions are atomic** -- no partial states during Collapse

---

## 2.5D Setup

Same approach as AQS:
- **3D physics** -- Rigidbody + CapsuleCollider, freeze Z rotation
- **Lane-based movement** -- 2-3 depth lanes (Z positions), not free Z movement
- **Cinemachine 2.5D camera** -- side-view with CinemachineFollow
- **LockAxis** -- if using Malbers AC (TBD), otherwise custom lane snapping
- **Unity 6 API** -- `rb.linearVelocity` not `velocity`

---

## AI Rules

1. **Primary doc:** `HNR_Status.md` -- read first, always.
2. **Working directory:** `E:\Unity\Sandbox`
3. **HNR root:** `Assets/_Sandbox/_HNR/`
4. **GDD is user's doc** -- update only when asked.
5. **NPC behavior must be mimic-able** -- if a player can't replicate it, it's too complex.
6. **No UI detection markers** -- detection is purely observational.
7. **Phase transitions are the heartbeat** -- every system must respect the current phase.
8. **All TecVooDoo coding standards apply.**
9. **MCP tools available** -- use for scene setup, component configuration, testing.
10. **Asset evaluations live in Sandbox** -- reference `Sandbox_AssetLog.md`.

---

**End of Document**
