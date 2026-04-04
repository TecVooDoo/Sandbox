# Soul Minor -- Dev Reference

**Purpose:** Architecture, coding standards, and AI rules for Soul Minor. Read on demand -- primary doc is `SM_Status.md`.
**Last Updated:** April 3, 2026

---

## Project Overview

**Genre:** Idle/Incremental Tycoon (Cute + Gore)
**Engine:** Unity 6 (URP)
**Platform:** Mobile-first (iOS/Android), portrait orientation
**Working Path:** `E:\Unity\Sandbox` (Sandbox incubator)
**SM Root:** `Assets/_Sandbox/_SM/`

**Core Identity:** Sickeningly cute dead animals + visceral scythe gore + satisfying idle progression. Idle Miner Tycoon structure with a Happy Tree Friends skin.

---

## Namespaces

| Namespace | Purpose |
|-----------|---------|
| `SM.Core` | Currency, rank system, game state, save/load |
| `SM.Harvest` | Tap input, scythe harvest, soul extraction, combo system |
| `SM.Mine` | Mine levels, body piles, zone management, elevator, warehouse |
| `SM.Upgrade` | Upgrade system, cost curves, automation unlocks |
| `SM.VFX` | Gore effects, soul wisps, blood spray, body parts, screen shake |
| `SM.UI` | All UI (UI Toolkit) -- currency display, upgrade panels, rank-up screen |
| `SM.Audio` | Audio cues, ambient, harvest sounds |
| `SM.Monetization` | Ad integration, IAP, offline earnings |

---

## Folder Structure

```
Assets/_Sandbox/_SM/
|
+-- Scripts/
|   +-- Core/           -- SoulManager, RankSystem, GameState, SaveManager
|   +-- Harvest/        -- TapHarvester, ScytheController, ComboSystem
|   +-- Mine/           -- MineLevel, BodyPile, Elevator, Warehouse, ZoneManager
|   +-- Upgrade/        -- UpgradeSystem, UpgradeCurve, AutomationManager
|   +-- VFX/            -- GoreBurst, SoulWisp, BloodSpray, BodyPartPhysics, ScreenShake
|   +-- UI/             -- CurrencyDisplay, UpgradePanel, RankUpScreen, SettingsPanel
|   +-- Audio/          -- HarvestAudio, AmbientManager
|   +-- Monetization/   -- AdManager, IAPManager, OfflineEarnings
|
+-- Art/
|   +-- Bodies/         -- Cute Pet models (configured for gore)
|   +-- Characters/     -- Ghost, Skeleton, Reaper (player progression)
|   +-- Environment/    -- KayKit Halloween props, zone backdrops
|   +-- VFX/            -- Blood textures, particle materials, soul wisp materials
|   +-- UI/             -- UXML/USS files
|
+-- Audio/
|   +-- SFX/            -- Harvest sounds, gore sounds, UI sounds
|   +-- Music/          -- Zone ambient, rank-up fanfare
|
+-- Data/
|   +-- Ranks/          -- RankConfigSO instances (8 ranks)
|   +-- Zones/          -- ZoneConfigSO instances (6 zones)
|   +-- Bodies/         -- BodyConfigSO instances (7 body types)
|   +-- Upgrades/       -- UpgradeConfigSO instances
|   +-- Events/         -- GameEvent SOs
|
+-- Prefabs/
|   +-- Bodies/         -- Body prefabs with gore components
|   +-- VFX/            -- Gore burst, soul wisp, blood spray prefabs
|   +-- Mine/           -- Mine level, elevator car, warehouse prefabs
|
+-- Scenes/
+-- Animations/
```

---

## Architecture

### Core Data Flow

```
TAP INPUT --> TapHarvester --> SoulManager (add currency)
                |                    |
                v                    v
          GoreBurst VFX      UpgradeSystem (check affordability)
          SoulWisp VFX              |
          ScreenShake               v
          AudioCue           MineLevel (upgrade stats)
                             Elevator (upgrade throughput)
                             Warehouse (upgrade capacity)
```

### ScriptableObject Architecture

Everything tunable is an SO. No magic numbers in code.

| SO Type | Purpose | Key Fields |
|---------|---------|------------|
| RankConfigSO | Rank definition | title, soulThreshold, promotionLetter, characterPrefab, unlocksZone |
| ZoneConfigSO | Zone definition | zoneName, bodyTypePool, soulMultiplier, ambientClip, backgroundPrefab |
| BodyConfigSO | Body type | bodyType, baseSoulValue, gorePrefab, deathSound, particleColor |
| UpgradeConfigSO | Upgrade curve | baseCost, costMultiplier, baseOutput, outputPerLevel, maxLevel |
| MinionConfigSO | Minion tier | tierName, harvestSpeed, cost, prefab |

### Three Bottlenecks (IMT Core)

```
MINE LEVELS -----> ELEVATOR -----> WAREHOUSE
(harvest rate)     (throughput)    (storage + collection)

Each is independently upgradeable.
If any one is underleveled, the pipeline chokes.
Player must balance investment across all three.
```

### Event Architecture

GameEvent ScriptableObjects (same as all TecVooDoo projects):

```
TapHarvester
    +--- OnSoulHarvested ---> SoulManager (add), VFX (gore burst + wisp), Audio (crunch + chime)
    +--- OnComboHit ---> UI (combo counter), Audio (pitch increase)

SoulManager
    +--- OnSoulBalanceChanged ---> UI (currency display update)
    +--- OnSoulSpent ---> UI (upgrade confirmation)

RankSystem
    +--- OnRankUp ---> UI (promotion letter), Audio (fanfare), Character (swap model)

Elevator
    +--- OnSoulDelivered ---> Warehouse (add to storage)

Warehouse
    +--- OnWarehouseFull ---> UI (collect prompt), Audio (cha-ching)
    +--- OnCollected ---> SoulManager (add spendable currency)
```

### Design Patterns

1. **Vanilla ScriptableObject architecture** -- GameEvent/GameEventListener for events. Config SOs for all tuning.
2. **UI Toolkit only** -- all UI is UXML/USS. No uGUI Canvas.
3. **Object pooling** -- gore particles, soul wisps, body parts, number pops. Pool everything.
4. **Offline calculation** -- timestamp delta * idle rate. No simulation while away.
5. **State pattern** -- zone states, rank states, upgrade states.

---

## Coding Standards

Same as all TecVooDoo projects:

- **No `var`** -- explicit types always
- **No per-frame allocations/LINQ** -- cache, pool, reuse
- **ASCII only** in docs and identifiers
- **sealed on MonoBehaviours** -- unless inheritance intended
- **Prefer async/await (UniTask)** -- over coroutines
- **Prefer interfaces and generics** -- decouple systems
- **Vanilla SO architecture** -- GameEvent/GameEventListener (NOT SOAP)
- **Extract by responsibility** -- not by line count
- **Production-quality test code** -- even in Sandbox prototype
- **UI Toolkit only** -- no uGUI

### SM-Specific Standards

- **Portrait orientation** -- all UI must be designed for 9:16 (or taller) aspect ratio
- **Touch input** -- all interactions must work with touch. No keyboard shortcuts in gameplay.
- **Config SOs for ALL tuning** -- soul values, cost curves, harvest rates, gore intensity. No magic numbers.
- **Offline-safe** -- every system must handle time jumps (player returns after hours/days)
- **Pool everything visual** -- gore particles, soul wisps, body parts, number pops. Mobile memory is tight.
- **Battery-conscious** -- cap frame rate when idle, reduce particle counts on low-end devices

---

## Mobile Considerations

| Concern | Approach |
|---------|----------|
| Touch input | Input System with touch support. Tap = harvest, scroll = navigate levels. |
| Screen sizes | UI Toolkit responsive layout. Test on 9:16, 9:19.5, 9:21 aspect ratios. |
| Performance | Object pooling, LOD on body models, particle count caps. Target 60fps on mid-range. |
| Battery | Reduce update frequency when idle. Cap particle systems. |
| Save frequency | Auto-save every 30s + on app pause/quit. |
| Offline earnings | Timestamp-based calculation. Cap at 8 hours to prevent exploit. |
| Ads | Rewarded only (player-initiated). Interstitial at natural break points only. |
| IAP | Non-consumable (Auto-Collect Pass) + consumable (Dark Gem packs). |

---

## AI Rules

1. **Primary doc:** `SM_Status.md` -- read first, always.
2. **Working directory:** `E:\Unity\Sandbox`
3. **SM root:** `Assets/_Sandbox/_SM/`
4. **GDD is user's doc** -- update only when asked.
5. **Mobile-first** -- every decision should consider touch input, portrait orientation, battery life.
6. **No feature creep** -- IMT structure is proven. Don't invent new mechanics. Execute the formula with a unique skin.
7. **Gore is the identity** -- if a feature doesn't serve the cute+gore contrast, question whether it belongs.
8. **Config SOs for everything** -- if it's a number, it's an SO field.
9. **Build single-zone first** -- prove the tap loop before adding progression.
10. **All TecVooDoo coding standards apply.**
11. **MCP tools available** -- use for scene setup, component configuration, testing.
12. **Asset evaluations live in Sandbox** -- reference `Sandbox_AssetLog.md`.

---

**End of Document**
