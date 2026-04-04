# Soul Minor -- Code Reference

**Purpose:** Script inventory and API reference for Soul Minor.
**Last Updated:** April 3, 2026 (Session 0 -- no code yet)

---

## Script Inventory

No scripts yet. Planned systems (aligned with GDD v1.0):

### SM.Core
| Script | Purpose |
|--------|---------|
| SoulManager | Currency tracking (earn, spend, balance). Lifetime total for rank progression. |
| RankSystem | Track current rank, check thresholds, trigger rank-up events. |
| GameState | Overall game state (active zone, current rank, settings). |
| SaveManager | Easy Save 3 wrapper. Auto-save, load, offline time delta. |

### SM.Harvest
| Script | Purpose |
|--------|---------|
| TapHarvester | Process tap input, select body from pile, trigger harvest, award souls. |
| ScytheController | Animate scythe swing per body type. Visual only. |
| ComboSystem | Track consecutive taps, apply combo multiplier, reset on timeout. |

### SM.Mine
| Script | Purpose |
|--------|---------|
| MineLevel | Single level in a shaft. Manages body pile, harvest rate, upgrade state. |
| BodyPile | Visual body pile. Tracks which bodies are harvested, respawn timer. |
| Elevator | Soul transport from levels to surface. Capacity, speed, queue. |
| Warehouse | Surface storage. Capacity, auto-collect rate, overflow handling. |
| ZoneManager | Manages zones (shafts). Zone unlock, zone switching. |

### SM.Upgrade
| Script | Purpose |
|--------|---------|
| UpgradeSystem | Process upgrade purchases. Apply to target (level, elevator, warehouse). |
| UpgradeCurve | Calculate cost and output at any level given base + multiplier SO. |
| AutomationManager | Manage minions. Assign to levels, track harvest automation. |

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
