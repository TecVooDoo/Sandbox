# Hide 'N Reap -- Code Reference

**Purpose:** Script inventory and API reference for HNR.
**Last Updated:** April 1, 2026 (Session 0 -- Bootstrap, no code yet)

---

## Script Inventory

No scripts yet. Planned systems:

### HNR.Core
| Script | Purpose |
|--------|---------|
| MatchManager | Match lifecycle (start, phase loop, end, scoring) |
| PhaseManager | Phase state machine (Possession, Collapse, Scramble) |
| ScytheSystem | Scythe spawn, pickup, ownership, loss, respawn |
| GameEvent / GameEventListener | Standard TecVooDoo event system |

### HNR.Player
| Script | Purpose |
|--------|---------|
| GhostController | Ghost movement, phasing, lane switching |
| PlayerState | Current role (Ghost, Possessed, Reaper), score |

### HNR.Reaper
| Script | Purpose |
|--------|---------|
| ReaperController | Reaper movement, ability activation |
| ReaperAbilities | Lane Strike, Decay Pulse, Hazard triggers |
| EnergySystem | Energy drain, damage handling, loss condition |

### HNR.Possession
| Script | Purpose |
|--------|---------|
| PossessionSystem | Enter/exit body, scythe-gated enable/disable |
| BodyManager | Track which bodies are possessed, available |
| RotSystem | Gradual decay, visual cues, collapse clear |

### HNR.NPC
| Script | Purpose |
|--------|---------|
| NPCBehavior (base) | State machine interface for NPC types |
| HumanBehavior | Walk - Pause - Resume |
| DogBehavior | Wander - Sniff - Sit |
| BirdBehavior | Perch - Hop - Short flight |

### HNR.Network
| Script | Purpose |
|--------|---------|
| INetworkService | Abstraction over netcode (swap NGO/FishNet/Mirror) |
| PhaseSync | Synchronize phase transitions across clients |
| PossessionSync | Synchronize possession ownership |
| ScytheSync | Synchronize scythe state |

---

**End of Document**
