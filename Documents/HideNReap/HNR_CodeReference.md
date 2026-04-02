# Hide 'N Reap -- Code Reference

**Purpose:** Script inventory and API reference for HNR.
**Last Updated:** April 2, 2026 (Session 2 -- Mechanics Review, no code yet)

---

## Script Inventory

No scripts yet. Planned systems (aligned with GDD v2.0):

### HNR.Core
| Script | Purpose |
|--------|---------|
| MatchManager | Match lifecycle (start, timer, scoring, end) |
| ScytheSystem | Scythe pickup, drop, drain, recharge, random respawn |
| WorldLayerManager | Camera culling mask toggle (supernatural/living visibility) |
| GameEvent / GameEventListener | Standard TecVooDoo event system |

### HNR.Input
| Script | Purpose |
|--------|---------|
| IGhostInput | Interface: GetMoveDirection, TryPossess, TryExitBody, TryPickupScythe, TryDropScythe, TryReap, TryAttack |
| LocalGhostInput | Keyboard/gamepad implementation of IGhostInput |
| NetworkGhostInput | PurrNet RPC implementation of IGhostInput (Sprint 6) |
| AIGhostInput | Behavior Designer Pro implementation of IGhostInput (Sprint 4) |

### HNR.Ghost
| Script | Purpose |
|--------|---------|
| GhostController | Ghost state management, consumes IGhostInput |
| GhostMovement | 2.5D lane-based movement, phasing through objects |
| CooldownTimer | Possession cooldown tracking after body exit |
| PlayerState | Current role (Ghost, Possessed, Reaper), score |

### HNR.Reaper
| Script | Purpose |
|--------|---------|
| ReaperController | Reaper movement, reap targeting (exposed ghosts only) |
| ReapSystem | Reap execution, score increment, scythe drain trigger |
| ScytheDrain | Scythe disappear -> recharge timer -> random respawn |

### HNR.Possession
| Script | Purpose |
|--------|---------|
| PossessionSystem | Enter/exit dead body, cooldown enforcement |
| BodyController | Possessed body movement, world interaction, attack |
| RotSystem | Per-body rot timer, passive decay, possession acceleration, damage conversion |
| BodyManager | Track all dead bodies, rot values, possession state |

### HNR.NPC
| Script | Purpose |
|--------|---------|
| NPCSpawner | Spawn and manage living NPC pool |
| NPCLifecycle | State machine: Alive -> Dead -> Possessed -> Destroyed |
| NPCBehavior (base) | Behavior interface for NPC types |
| HumanBehavior | Walk - Pause - Resume |
| DogBehavior | Wander - Sniff - Sit |
| CatBehavior | Roam - Pounce - Groom |
| PigBehavior | Slow waddle - Root - Rest |
| SheepBehavior | Herd movement - Graze - Bleat |
| ChickenBehavior | Peck - Scatter - Short flight |

### HNR.Hazard
| Script | Purpose |
|--------|---------|
| HazardManager | Random hazard scheduling, min/max intervals |
| HazardEvent (base) | Area-of-effect NPC kill, map-specific subtypes |

### HNR.AI
| Script | Purpose |
|--------|---------|
| AIGhostBrain | Tactical decision-making: find body, evaluate rot, possess, mimic |
| AIReaperBrain | Hunt exposed ghosts, drop-possess-chaos-reap loop |
| AIBodySelector | Evaluate available bodies by rot, distance, risk |

### HNR.Network
| Script | Purpose |
|--------|---------|
| NetworkInputProvider | PurrNet wrapper implementing IGhostInput |
| StateSync | Server-authoritative sync for scythe, rot, NPC lifecycle |
| BodySync | Body ownership transfer via PurrNet per-component ownership |

### HNR.UI
| Script | Purpose |
|--------|---------|
| ScoreHUD | Reap count display |
| MatchTimerUI | Match timer |
| RotWarningUI | Rot threshold warning for possessing player |

### HNR.Audio
| Script | Purpose |
|--------|---------|
| AudioCueManager | SFX triggers for death, scythe, reap, hazard, rot |

---

**End of Document**
