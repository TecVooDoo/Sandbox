# Soul Minor -- Sprint 2 Rebuild Plan

**Created:** April 11, 2026
**Trigger:** Playtest revealed the IMT three-bottleneck structure wasn't landing visually or conceptually. Pivoted to a row-based body processing factory. GDD v2.0 replaces v1.0.

---

## Philosophy

This isn't a blank slate. The Sprint 1 work gave us:
- A working Unity project with all the packages, materials, and art imported
- A proven save/load system (Easy Save 3)
- A working GameEvent ScriptableObject architecture
- NumberPop VFX, Cute Pet body models, KayKit environment props
- The SMHUD click-through fix, Layer 6 setup, placeholder prefabs
- All the plumbing that was painful to build the first time

What changes is the **gameplay core**: Mine/Elevator/Warehouse are replaced with Rows/Pipes/Gatherers. The scene needs a rebuild but most scripts can be reused or adapted.

---

## Keep As-Is

These don't need changes for the pivot:

| Asset / System | Why Keep |
|----------------|----------|
| `SM.Core.GameEvent` / `GameEvent<T>` / listeners | Event architecture is sound |
| `SoulManager` | Currency tracking is unchanged |
| `SaveManager` (Easy Save 3) | Save system works, will adapt data shape |
| `NumberPop` (SM.VFX) | Floating numbers on chop are still wanted |
| `ComboSystem` (SM.Harvest) | Combo-while-actively-clicking is in v2.0 |
| `BodyConfigSO` | Still describes a body type (value, prefab, sound) |
| Body prefabs (Body_Cat, Body_Dog) | Reusable |
| Cute Pet materials (URP/Lit conversions) | Done, reusable |
| KayKit Halloween/BlockBits props | Environment dressing still wanted |
| GameEvent SO instances (OnSoulBalanceChanged, etc.) | Most still relevant |
| Layer 6 "Body" setup | Raycast layer still needed |
| Input System setup | Touch + mouse click input still used |

---

## Adapt / Rewrite

These need significant changes but not full replacement:

| Asset / System | Change |
|----------------|--------|
| `TapHarvester` | Keep click handling + UI pick check. Remove MineLevel lookup, target whatever the reaper is standing on (Row). |
| `SMHUD` | Rewrite UI. Currency header stays. Replace mine/elevator/warehouse buttons with contextual per-row upgrade panel. Add descend button, tool upgrade button, gatherer panel. |
| `SM_HUD.uxml` / `.uss` | Rewrite layout. Header (souls, row depth). Right-side per-row panel (outlets, tool upgrade, auto-button, descend). Bottom panel gatherers. |
| `UpgradeSystem` + `UpgradeConfigSO` | Keep the cost curve math. Retarget to row outlets, tool tiers, auto-button minions, gatherer count/tier. |
| `BodyPile` | Replace with `RowOutlet` -- a pipe outlet that spawns bodies at intervals instead of a pile that depletes. |
| `ZoneInitializer` | Replace with `ShaftManager` -- manages row lifecycle, descent, row unlocks. |

---

## Delete

These are Sprint 1 dead ends for v2.0:

| Script / Asset | Reason |
|----------------|--------|
| `MineLevel` | Replaced by Row concept |
| `Elevator` | Removed in v2.0 |
| `Warehouse` | Removed in v2.0 |
| `RankSystem` + 8 RankConfigSO instances | Ranks removed (may return as cosmetic later) |
| `GameState.cs` zone-switching logic | Single shaft, no zones |
| ZoneConfigSO (Shallow Graves) | Zones removed |
| Scene hierarchy under `[Mine]` | Full rebuild |
| Elevator/Warehouse UpgradeConfigSOs | Targets no longer exist |

---

## New Scripts to Write

### SM.Shaft namespace (new)

| Script | Purpose |
|--------|---------|
| `ShaftManager` | Top-level controller. Tracks rows, current reaper row, handles descent. |
| `Row` | A single row. Holds outlets, minions, blood bar state, tool tier. |
| `RowOutlet` | A pipe outlet. Spawns bodies at interval. |
| `RowWorker` (base) | Base class for reaper + minions. Handles "chop at this outlet" logic. |
| `Reaper` : RowWorker | Player avatar. Player clicks to chop, combo tracked. |
| `ChopMinion` : RowWorker | Auto-chops. Spawned when outlet is purchased. |
| `BloodBar` | Per-row fill progress. Events on full / emptied. |
| `ToolUpgradeController` | Per-row tool tier. Triggers button availability. |
| `AutoButtonMinion` | Optional per-row. Watches ToolUpgradeController, presses when ready. |
| `PipeNetwork` | Visual + logical pipe routing from funnel to outlets. |

### SM.Gatherer namespace (new)

| Script | Purpose |
|--------|---------|
| `GathererManager` | Tracks count (1-10), speed tier, spawns gatherers, manages body arrival rate into the funnel |
| `Gatherer` | Single minion. Walks off-screen, returns with a body, drops in funnel |
| `BodyFunnel` | Receives bodies from gatherers, feeds them into the pipe network |

### Refactored SM.Harvest / VFX

| Script | Purpose |
|--------|---------|
| `TapHarvester` (modified) | Targets the reaper's current row outlet when player clicks bodies on that row |
| `NumberPop` (unchanged) | Still pools floating numbers |

---

## Data Shape

### New SOs

| SO | Fields |
|----|--------|
| `RowConfigSO` | baseBodyRate, baseSoulMultiplier, unlockBodyTypes[], depth |
| `UpgradeConfigSO` (reused) | Retargeted to: Outlet, ToolTier, AutoButton, GathererCount, GathererTier |

### Save Data (ES3)

```
SM_Souls (double)
SM_LifetimeSouls (double)
SM_ReaperRowIndex (int)
SM_RowsBuilt (int)                  -- how many rows have ever existed
SM_RowData (Dictionary<int, RowState>)
    RowState: { outletCount, toolTier, bloodBarValue, autoButtonOwned }
SM_GathererCount (int)
SM_GathererTier (int)
SM_LastSaveTime (long)
```

---

## Scene Hierarchy (Target)

```
SM_Shaft (scene)
├── [GameManager]
│   ├── SoulManager
│   ├── ShaftManager
│   ├── GathererManager
│   ├── UpgradeSystem
│   └── SaveManager
├── [Input]
│   ├── TapHarvester
│   ├── ComboSystem
│   └── NumberPop
├── [Shaft]
│   ├── Surface
│   │   ├── Platform
│   │   ├── BodyFunnel
│   │   └── Gatherers (spawn point)
│   ├── PipeNetwork (visual mesh + logic)
│   ├── Row_0
│   │   ├── Outlets (1-4)
│   │   ├── Workers (reaper + minions)
│   │   ├── BloodBar
│   │   └── ToolUpgradeButton (world-space trigger)
│   ├── Row_1
│   ├── Row_2
│   └── ...
└── [UI]
    ├── UIDocument (SM_HUD.uxml)
    └── SMHUD
```

---

## UI Layout (Target)

Portrait 9:16+.

```
┌─────────────────────────┐
│ [Souls: 12.5K] [Row 3]  │  <- Top header, always visible
├─────────────────────────┤
│                         │
│       [Viewport]        │  <- Main 3D view, scrollable
│   (scroll vertically    │     vertically to see rows
│    to see any row)      │
│                         │
├─────────────────────────┤
│ [Current Row: 3]        │  <- Contextual panel: shows upgrades
│ [+Outlet $50] [Auto $1K]│     for the row centered in viewport
│ [Tool Upgrade $200]     │     (NOT necessarily reaper's row)
│ [Descend $0] (when row  │
│  fully built)           │
├─────────────────────────┤
│ [Gatherers: 3/10] [+]   │  <- Global panel: gatherer controls
│ [Speed Tier 2] [+]      │
└─────────────────────────┘
```

**Key interaction:** the contextual per-row panel shows upgrades for whichever row is centered in the viewport, not necessarily the reaper's row. That way scrolling up to an old row lets you click its tool upgrade button from the panel, not from a tiny world-space button.

---

## Build Order

Rough sprint breakdown, not rigid:

### Phase 1 -- Cleanup + Scaffolding
1. Create new scene `SM_Shaft.unity` (keep `SM_ShallowGraves.unity` as-is for reference; don't delete yet)
2. Create `SM.Shaft` and `SM.Gatherer` namespace folders
3. Write stub scripts: ShaftManager, Row, RowOutlet, RowWorker, Reaper, ChopMinion, BloodBar, ToolUpgradeController, GathererManager, Gatherer, BodyFunnel, PipeNetwork
4. Write empty RowConfigSO

### Phase 2 -- Single Row Vertical Slice
5. Build Row 0 manually in scene: 1 outlet, 1 reaper, blood bar
6. Wire tap input to reaper chop
7. Implement BloodBar fill logic
8. Tool upgrade button (placeholder UI)
9. Play: chop, fill bar, upgrade, chop again with tier 2

### Phase 3 -- Gatherers Feed the Row
10. Build surface + funnel
11. Spawn 1 gatherer, make it walk off and return with a body
12. Funnel → pipe → outlet spawning
13. Replace "bodies appear at outlet" with "bodies arrive via pipe"

### Phase 4 -- Row Upgrades
14. Outlet upgrade (adds outlet + minion)
15. ChopMinion auto-chop
16. 4-outlet full row
17. T-connector auto-build visual

### Phase 5 -- Descent
18. Build Row 1 under Row 0
19. Descend button
20. Reaper transition animation/movement
21. Auto-button minion

### Phase 6 -- Multiple Rows + Save
22. Build out to Row 5 for testing
23. Adapt SaveManager to new data shape
24. Test save/load mid-row and between rows
25. Row depth multiplier

### Phase 7 -- UI Rebuild
26. Rewrite SM_HUD.uxml/uss with new panel layout
27. Rewrite SMHUD.cs to drive contextual per-row panel
28. Wire all upgrade buttons
29. Polish: tool upgrade button "ready" glow, combo indicator

### Phase 8 -- Playtest + Tune
30. Balance pass on costs, fill rates, multipliers
31. Play it. Does it feel better than Sprint 1?
32. Iterate.

---

## Archival Plan for Sprint 1 Work

Keep the old scene and scripts around during the rebuild -- they work and may have reusable patterns. Once the new rebuild is playable and proven:

1. Move `SM_ShallowGraves.unity` to `Assets/_Sandbox/_SM/Scenes/Archive/`
2. Move `MineLevel.cs`, `Elevator.cs`, `Warehouse.cs`, `ZoneInitializer.cs`, `RankSystem.cs` to `Assets/_Sandbox/_SM/Scripts/Archive/` (or delete if nothing's reused)
3. Remove RankConfigSO instances from `Data/Ranks/`
4. Remove Elevator/Warehouse UpgradeConfigSO instances
5. Keep body configs, game events, and gatherer/row configs going forward

Don't do this yet -- do it after the new scene runs.

---

## Risk / Things to Watch

- **Scope creep on art.** Temptation will be to make the shaft look perfect before the loop works. Don't. Grey boxes + placeholders until the loop is proven.
- **Pipe visualization.** Getting pipes to visually connect from funnel through rows is a real 3D modeling problem. Start with literal cylinders, worry about the look later.
- **Scroll UX.** UI Toolkit scrollable 3D viewport is not trivial. May need to separate the 3D camera scroll from UI.
- **Data migration.** Save files from Sprint 1 won't work with Sprint 2. Either write a migration path or accept that existing saves are wiped on the pivot. (Recommend the latter -- Sprint 1 was a prototype.)
- **Manual descent gate.** Make sure the player can't accidentally descend. Confirmation dialog? Double-tap? Worth testing both.

---

**End of Document**
