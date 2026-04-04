# Soul Minor -- Code Reference

**Purpose:** Script inventory and API reference for Soul Minor.
**Last Updated:** April 3, 2026 (Session 1 -- 19 scripts)

---

## Script Inventory

19 scripts compiling clean. Sprint 1 foundation:

### SM.Core (IMPLEMENTED)
| Script | Purpose | Status |
|--------|---------|--------|
| GameEvent | Void SO event, observer pattern | Done |
| GameEventListener | MonoBehaviour listener for GameEvent | Done |
| GameEvent<T> / DoubleGameEvent / IntGameEvent | Generic typed SO events | Done |
| BodyConfigSO | Body type config (soul value, prefabs, audio) + BodyType enum | Done |
| ZoneConfigSO | Zone config (body pool, multiplier, level count) | Done |
| RankConfigSO | Rank config (threshold, title, promotion letter) | Done |
| UpgradeConfigSO | Upgrade curve config (cost, output, max level) + UpgradeTarget enum | Done |
| SoulManager | Currency tracking (earn, spend, balance). Lifetime total for rank. | Done |
| RankSystem | Track current rank, check thresholds, trigger rank-up events. | Done |
| GameState | Overall game state (active zone, current rank, zone switching). | Done |
| SaveManager | PlayerPrefs fallback + ES3 #if. Auto-save 30s, offline delta (8h cap). | Done |

### SM.Harvest (IMPLEMENTED)
| Script | Purpose | Status |
|--------|---------|--------|
| TapHarvester | Touch/mouse input, raycast to BodyPile, harvest + award souls. | Done |
| ScytheController | Animate scythe swing per body type. Visual only. | Planned |
| ComboSystem | Consecutive taps, timeout reset, multiplier (configurable). | Done |

### SM.Mine (IMPLEMENTED)
| Script | Purpose | Status |
|--------|---------|--------|
| MineLevel | Single shaft level. Body pile ref, upgrade state, pending souls. | Done |
| BodyPile | Body instances, harvest by raycast hit, respawn timer. | Done |
| Elevator | Soul transport. Capacity, trip timer, load/deliver cycle. | Done |
| Warehouse | Surface storage. Capacity, auto-collect, manual collect. | Done |
| ZoneManager | Manages zones (shafts). Zone unlock, zone switching. | Planned |

### SM.Upgrade (IMPLEMENTED)
| Script | Purpose | Status |
|--------|---------|--------|
| UpgradeSystem | Purchase upgrades for mine/elevator/warehouse. Tracks per-level state. | Done |
| UpgradeCurve | Static: cost/output at level N from UpgradeConfigSO. | Done |
| AutomationManager | Manage minions. Assign to levels, track harvest automation. | Planned |

### SM.VFX
| Script | Purpose |
|--------|---------|
| GoreBurst | Body-type-specific gore effect. Blood spray + body parts + particles. |
| SoulWisp | Ethereal wisp rising from gore. Color by soul value. Float to elevator. |
| BloodSpray | Directional blood particle system. Pooled. |
| BodyPartPhysics | Short-lived tumbling limbs/tails/feathers. Pooled. |
| ScreenShake | Camera shake on harvest. Scales with body size. |

### SM.UI (UI Toolkit)
| Script | Purpose |
|--------|---------|
| CurrencyDisplay | Soul counter, Dark Gem counter. Top of screen. |
| UpgradePanel | Side drawer. Level, elevator, warehouse upgrade buttons with costs. |
| RankUpScreen | Full-screen promotion letter overlay. Rank title + flavor text. |
| NumberPop | Floating "+X" numbers on harvest. Pooled. |
| ComboDisplay | Combo counter ("x5!", "x10!"). Scales with combo. |

### SM.Audio
| Script | Purpose |
|--------|---------|
| HarvestAudio | Play crunch + chime on harvest. Pitch varies by body type + combo. |
| AmbientManager | Zone-specific ambient loops. Crossfade on zone switch. |

### SM.Monetization
| Script | Purpose |
|--------|---------|
| AdManager | Rewarded ad integration. 2x boost, free gems. |
| IAPManager | Dark Gem packs, Auto-Collect Pass. |
| OfflineEarnings | Calculate and display earnings since last session. |

---

## SO Types (Planned)

| Type | Create Menu | Key Fields |
|------|-------------|------------|
| RankConfigSO | SM/Rank Config | title, soulThreshold, promotionLetterText, characterPrefab, unlocksZoneIndex |
| ZoneConfigSO | SM/Zone Config | zoneName, flavorText, bodyTypePool[], soulMultiplier, ambientClip, bgPrefab |
| BodyConfigSO | SM/Body Config | bodyType, baseSoulValue, gorePrefab, harvestSound, particleColor, bodyPartPrefabs[] |
| UpgradeConfigSO | SM/Upgrade Config | upgradeName, baseCost, costMultiplier, baseOutput, outputPerLevel, maxLevel |
| MinionConfigSO | SM/Minion Config | tierName, harvestSpeedMultiplier, cost, prefab |

---

**End of Document**
