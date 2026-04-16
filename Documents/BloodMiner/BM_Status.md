# Blood Miner -- Project Status

**Project:** Blood Miner (Mobile Idle/Incremental -- Cute + Gore)
**Developer:** TecVooDoo LLC / Rune (Stephen Brandon)
**Unity Version:** Unity 6 (URP)
**Working Path:** `E:\Unity\Sandbox` (Sandbox incubator)
**SM Root:** `Assets/_Sandbox/_BM/`
**Last Updated:** April 15, 2026 (Session 79 -- UI frame fix, auto-upgrade, gatherer skeletons, viewport scrolling)

> **ARCHIVE RULE:** This doc holds only the current state and last ~2 sessions. When adding a new session, move older entries to `BM_StatusArchive.md` (newest first at top of archive). This keeps the status doc fast to read while preserving full history.

**Reference doc:** `BM_DevReference.md` -- architecture, standards, AI rules. Read on demand.

---

## Current State

**Phase:** Sprint 2 Phase 1-9 IN PROGRESS. UI frames fixed, auto-upgrade per-row, gatherer skeletons, viewport scrolling.

**Session 79 (Apr 15, 2026) -- UI frame fix + auto-upgrade + gatherer skeletons + viewport scrolling:**
- **UI frame fix:** Swapped both HUD panels from `Box_Hotbar_01`/`Box_Hotbar_03` (no proper 9-slice) to `Frame_Box_Large_07` (1024x1024, uniform 80px borders). Root cause: Hotbar sprites had no top/bottom borders (280,0,280,0 and 0,0,0,0). Top bar restructured to 3-column layout mirroring bottom: Speed button | Info box | Gatherers button. Bottom panel back to 3 buttons (Buy Outlet, Buy Minion, Descend). 4px margin from screen edges.
- **AutoButtonMinion (per-row auto-upgrade):** `AutoButtonMinion` now extends `RowWorker`. Each row gets a gold in-world `WorldAutoUpgradeButton` cube (0.6x0.4x0.6) below the tool upgrade button. Click to spend blood (200 * depth multiplier) and spawn an AutoButtonMinion that auto-presses the tool upgrade. Purchase button hides after click. Row 0 gets one in Awake.
- **Gauge scaling:** `ToolUpgradeController.TryUpgrade()` now increases `LeftoversGauge` capacity by 1.5x per tier (100 -> 150 -> 225 -> 337...). Added `LeftoversGauge.SetCapacity()`.
- **Gatherer skeleton models:** `Gatherer.SetupModel()` instantiates Skeleton_Minion at 0.4 scale with direction flipping based on movement. `AC_Gatherer` animator controller (Idle/Walk with IsWalking bool). `GathererManager` passes model/anim/material to spawned gatherers. Drives `IsWalking` in Update. Removed green cube MeshFilter/MeshRenderer from Gatherer prefab.
- **Viewport scrolling:** Up/Down arrows scroll view between row 0 and active row. `_viewedRowIndex` tracks which row is in view. `ScrollView(direction)` shifts `_rowParent.position.y`. HUD shows "Viewing Row X" when scrolled away from active row. Descend resets view to new active row.
- **Gauge/empty-row alignment:** Shifted gauge and empty row BG x from 1.5 to 1.0 (left 0.5 units) to align with row content.

**Session 78 (Apr 13, 2026) -- Phase 9 viewport scrolling + character fixes + surface masking:**
- **Core viewport design established:** Camera is FIXED at (1.5, 2, 18) FOV 40. Player stays at fixed screen position. On descent, `_rowParent.position.y += _rowSpacing` shifts all rows UP so the next row slides into the player's position. Completed rows scroll up behind a surface mask. No camera movement at all.
- **Camera overhaul:** FOV 65->40 (eliminated fish-eye distortion), rotation flattened (5,180,0)->(0,180,0), Z pushed from 10->18 to compensate for narrower FOV.
- **Surface mask (functional):** Runtime-created quad parented to `_surfaceRoot` at localPosition (1.5, 19, 2) with Y=180 rotation (faces camera at +Z). Scale (40, 31, 1). Uses camera background color as URP/Unlit material. Hides completed rows scrolling behind gather area. Surface children pushed to Z=3 to render in front of mask.
- **Empty row visual:** `CreateEmptyRowBelow()` places a dark gauge-BG-only decorative row below the active row to fill the viewport. Created both at game start (below Row 0) and on each descent. Single instance recycled.
- **Surface pinning:** `_surfaceRoot` serialized field on ShaftManager. [Surface] parent Y=1.5 moves all gather content (funnel, gatherers, pickup/drop points) up together. Mask Y=19 compensates.
- **Ghoul fixes:** Y position 0.65->0 (feet on ground). Scale reset (0.9,1.1,0.9)->(1,1,1). Purple placeholder cube MeshRenderer/MeshFilter removed. WarriorModel scaled to 0.5, faces sideways (Y=270).
- **Ghoul facing:** Model child rotates between Y=270 (face left) and Y=90 (face right) based on movement direction during walk. Direction flipping in Update() based on `dirX`.
- **Minion fixes:** Model scale 0.7->0.5. Rotated to face sideways (Y=90, facing right toward outlets). Spawn position changed from `(outlet.x, 0, 0.5)` to `(outlet.x - 0.8, 0, 0)` -- to the left of outlets, no longer overlapping with bodies.
- **USS updates:** Top-bar 9-slice reduced (280->60), bottom-panel (80->40). Font sizes bumped across all elements (9-13px -> 14-20px). Button backgrounds made semi-transparent (0.85->0.55 alpha). Padding increased on all panels and buttons. Border width 1->2px, border-radius 4->6px.
- **Scene changes:** [Surface] parent Y moved to 1.5. Ghoul MeshRenderer/MeshFilter removed. WarriorModel scale 0.5, rotation Y=270. Camera at (1.5, 2, 18) FOV 40 rotation (0, 180, 0).

**Session 77 (Apr 12, 2026) -- Phase 7 economy + cameras + save/load + UI skin:**
- **Tool tier multiplier wired:** `Row.OnChop` now multiplies blood by `1 + toolTier`. Both gauge fill and BloodManager currency get the boosted amount. Tier 0 = 1x, Tier 1 = 2x, etc.
- **Per-row body type escalation:**
  - `BodyConfigSO` new `_unlockRow` field. Cat/Dog unlock row 1, Pig row 3, Sheep row 5, Rabbit/Chicken row 7, Cow row 9.
  - `RowWorker.Chop()` reads body's `BaseBloodValue` and multiplies chop amount (Cat=1x, Dog=1.5x, Pig=3x, Sheep=4x, Rabbit/Chicken=2x, Cow=10x).
  - `GathererManager` renamed `_availableBodies` -> `_allBodies`, added `_unlockedBodies` filtered list + `UpdateUnlockedBodies(rowDepth)`.
  - `ShaftManager.Descend()` calls `UpdateUnlockedBodies` on each descent.
  - 5 new BodyConfigSO assets created (Pig, Sheep, Rabbit, Chicken, Cow) with GDD values. All 7 wired to `_allBodies`.
- **Two-camera pinned-surface viewport:**
  - `SurfaceCamera` (top 25%, depth 1) fixed at (0,5,6.5) looking at gatherer area. Untagged.
  - `RowCamera` (bottom 75%, depth 0, MainCamera tag) follows ghoul's current row. Centers between previous and active row on descent.
  - `ShaftManager.Descend()` camera logic updated: midpoint between prev/active row + 1.5 offset.
- **ES3 save/load:**
  - `BM_SaveManager` on `[GameManager]`. Saves blood balance/lifetime, ghoul row, per-row outlets/minions/tool tier/gauge fill, gatherer count/speed/slots.
  - Auto-saves on `OnApplicationPause`/`OnApplicationQuit`. Auto-loads on `Start()`.
  - Context menu: Save Game, Load Game, Clear Save Data.
- **Synty Dark Fantasy Interface UI skin:**
  - Imported `Synty/InterfaceDarkFantasyHUD` and `Synty/PolygonParticleFX`.
  - `BM_HUD.uss` reskinned: `Box_Hotbar_01` (top bar), `Box_Hotbar_03` (bottom panel), Pirata One font for titles/counter, warm gold/amber text colors, text shadows for readability.
- **KayKit Skeletons noted:** 6 characters + animations. External path: `E:\Game Assets\Itch\apps\kaykit-complete\`
- **Camera pivot (mid-session):** Dual-camera approach abandoned -- different viewport aspect ratios made identical FOV/rotation look completely different between surface and row views. Pivoted to single full-screen camera (FOV 65, pos (2,2,10), rotation (5,180,0)). SurfaceCamera disabled. Camera pans down on descent, surface scrolls off naturally.
- **Layer system established:** Layer 7=Surface, Layer 9=Shaft, Layer 6=Body. Set up for future camera isolation if needed.
- **PanelSettings Match=0** (width-only) for mobile portrait compatibility.

**Session 77 cont. (Apr 12, 2026) -- Phase 8 KayKit Skeleton characters:**
- **Skeleton FBX import:** Skeleton_Warrior.fbx + Skeleton_Minion.fbx + skeleton_texture_A.png imported to `Assets/_Sandbox/_BM/Art/Characters/KayKit_Skeletons/`. 10 animation FBXs imported to `Animations/` subfolder (General, MovementBasic, CombatMelee, etc.). All set to Humanoid rig.
- **Mat_Skeleton material:** URP/Lit with skeleton_texture_A (1024x1024). Assigned to all Ghoul/Minion mesh parts.
- **AC_Ghoul animator:** 3 states (Idle->Idle_A, Walk->Walking_A, Attack->Melee_1H_Attack_Chop). Parameters: IsWalking(Bool), Attack(Trigger). 5 transitions with 0.1s blend.
- **AC_ChopMinion animator:** 2 states (Idle->Idle_A, Attack->Melee_1H_Attack_Chop). Parameter: Attack(Trigger). 2 transitions.
- **Ghoul.cs updated:** Gets Animator from children in Awake. Sets `IsWalking` on GoToOutlet, clears + triggers `Attack` on arrival.
- **ChopMinion.cs updated:** `SetupModel(prefab, ctrl, mat)` method instantiates Skeleton_Minion at 0.7 scale, assigns material + animator. Falls back to green cube if no model provided. Triggers `Attack` on each chop.
- **Row.cs + ShaftManager.cs updated:** Minion model/animator/material references passed through `Row.Init()` and `ShaftManager.UnlockNextRow()` so dynamically spawned rows create animated minions.
- **Ghoul in scene:** Skeleton_Warrior model instantiated as child of Ghoul GO, 10 mesh parts with Mat_Skeleton, AC_Ghoul controller assigned.

**Session 76 (Apr 12, 2026) -- Phase 4 multi-outlet + player Ghoul + ChopMinions:**
- **Chop now consumes body:** `RowWorker.Chop()` calls `_assignedOutlet.ConsumeBody()` before adding blood. Guards against empty outlets. `ShaftTapHarvester` no longer double-consumes.
- **Dynamic outlet spawning:** `Row.AddOutlet()` creates Outlet_N at runtime with BodyDrop child, PipeVisual (KayKit pipe at 0.4 scale), registers in PipeNetwork. Max 4 outlets per row. Spacing 1.5 units to fit within gauge width.
- **ChopMinion with visual:** Green placeholder cube (0.3 scale), auto-chops on 1s interval when body present at assigned outlet. `Row.AddChopMinion(outlet)` spawns at floor level (y=0, z=0.5 offset). `GetNextUnminionedOutlet()` cycles through outlets without duplicating.
- **Player-controlled Ghoul (design correction):** Ghoul is NOT auto-patrol. Player taps a body -> `ShaftTapHarvester` calls `Ghoul.GoToOutlet(outlet)` -> Ghoul walks to outlet SpawnPoint -> chops on arrival. Idle otherwise. Memory updated.
- **Keyboard shortcuts for prototyping:** O = add outlet, M = add minion to next un-minioned outlet (via `ShaftManager.Update`)
- **Pipe Dream Pack discovered:** `Assets/OnePotatoKingdom_PipeDreamPack/` — low poly pipes + fluid VFX, URP materials included. 33 prefabs: RegularPipe, PipeCurve, PipeTCross, PipeBaloon, PipeCap variants. PipeBaloon noted as potential "blocked outlet" visual. Deferred to visual pass.
- **Body gravity-drop idea noted:** Bodies could fall from outlet to floor via Rigidbody + ground collider instead of teleporting to BodyDrop. Sprint 3 polish item.

**Session 76 cont. (Apr 12, 2026) -- Phase 5 row completion + descent + dynamic rows:**
- **Row completion detection:** `Row.IsFullyBuilt` now requires 4 outlets AND 4 ChopMinions (Ghoul excluded via `ChopMinionCount` property). Auto-triggers `UnlockNextRow()`.
- **Dynamic row spawning:** `ShaftManager.UnlockNextRow()` creates Row_N at Y = -N * rowSpacing with full component set: LeftoversGauge (dark BG + red fill + visual driver), ToolUpgradeController + WorldUpgradeButton (grey/red color toggle on fill), 1 starting outlet, all wired to shared PipeNetwork/BodyPool.
- **Descent:** D key moves Ghoul to next row (reparented), camera snaps to new row Y + 2.2 offset. One-way. `_nextRowUnlocked` flag prevents duplicate row creation.
- **Row-restricted clicking:** `ShaftTapHarvester` checks body's parent Row matches Ghoul's Row — can't click animals on other rows.
- **UnityEvent initialization fix:** All public `UnityEvent` fields across `LeftoversGauge`, `ToolUpgradeController`, `RowOutlet` initialized with `= new UnityEvent()` to prevent NullRef when components are created at runtime via `AddComponent` (Awake runs before reflection can set fields).
- **WorldUpgradeButton collider fix:** Button component added to `buttonCube` (has BoxCollider from CreatePrimitive) instead of empty parent GO — `[RequireComponent(typeof(Collider))]` was blocking AddComponent.
- **Manual event wiring:** `WorldUpgradeButton` Awake can't subscribe to controller events (null at Awake time). OnReady/OnTierChanged listeners wired via lambdas in `CreateUpgradeButtonForRow` after reflection setup.
- **Row.Init()** accepts `outletSpacing` parameter (default 1.5) so dynamic rows match Row 0 layout.
- **Playtest CONFIRMED:** Full loop: build Row 0 -> Row 1 auto-unlocks -> D to descend -> build Row 1 with working gauge + upgrade button -> Row 2 unlocks -> repeat.

**Session 76 cont. (Apr 12, 2026) -- Phase 6 UI overhaul + currency + gatherer upgrades:**
- **BloodManager currency wired:** `Row.OnChop` now feeds both LeftoversGauge (row-local fill) and BloodManager (global spendable currency). BloodManager on [GameManager] GO.
- **HUD rewrite (UI Toolkit):** `BM_HUD.uxml` + `BM_HUD.uss` replaced Sprint 1 mine/elevator/warehouse layout. New layout:
  - Top bar: blood counter, row number, outlet/minion counts, gatherer speed upgrade button, buy gatherer button
  - Bottom bar: Buy Outlet (red), Buy Minion (blue), Descend (green)
- **BMHUD.cs controller:** Queries ShaftManager/BloodManager each frame, enables/disables buttons based on affordability + state, formats numbers (K/M).
- **Cost curves:** Outlet 50 base x2 per purchase. Minion 30 base x1.8. Gatherer speed 100 base x3 (max 5 tiers). Gatherer count 80 base x2.
- **Row depth multiplier:** All row purchases multiplied by `1.0 + rowIndex * 0.1` (Row 0 = 1x, Row 1 = 1.1x, etc.).
- **Gatherer count gated by row progression:** 1 slot unlocks per new row completed (testing). Production: 1 per 10 rows. Button shows "New row needed" when no slots. Max 10 gatherers.
- **Outlet + minion split:** Separate purchases per user feedback — row starts with 1 outlet 0 minions, buy each independently.
- **Ghoul positioning fixes:** Spawns at x=-1 (left edge, not under outlet). Stops 0.5 units before body (`_chopReach`) instead of walking on top.
- **Upgrade button position matched:** New row buttons use UpgradeButtonVisual at local (2.13, 0.5, 0) matching Row 0's editor-placed position.
- **O/M shortcuts removed:** UI buttons are the only purchase path. D key kept as backup for descent.
- **TODO next session:** Wire `ToolUpgradeController.ToolTier` to actually multiply blood yield in `Row.OnChop` (currently tier increments but has no gameplay effect). See memory note.

**Session 75 (Apr 11, 2026) -- Phase 1+2 vertical slice + Real Blood eval (ENTRY-329):**
- **Phase 1 Scaffolding:** Created `BM_Shaft.unity` scene. Unloaded `BM_ShallowGraves.unity` (kept on disk as reference). Wrote 14 stub scripts:
  - `BM.Shaft` namespace: `ShaftManager`, `Row`, `RowOutlet`, `RowWorker` (base), `Ghoul`, `ChopMinion`, `LeftoversGauge`, `ToolUpgradeController`, `AutoButtonMinion`, `PipeNetwork`, `WorldUpgradeButton`, `LeftoversGaugeVisual`
  - `BM.Gatherer` namespace: `GathererManager`, `Gatherer`, `BodyFunnel`
  - `BM.Core`: `RowConfigSO`, `SceneTint` (later neutered to data-only after MPB issues)
  - `BM.Harvest`: `ShaftTapHarvester` (new, replaces MineLevel-coupled `TapHarvester`)
- **Phase 2 Vertical Slice:**
  - `[GameManager]` root with `ShaftManager`
  - `[Input]` root with `ShaftTapHarvester`
  - `[Shaft]/Row_0` with `Row` + children: `Outlet_0` (RowOutlet + PipeVisual), `Ghoul` (cube, SM_Reaper material), `LeftoversGauge` (dark floor + red fill quad, BloodBarVisual), `ToolUpgrade` (ToolUpgradeController + UpgradeButtonVisual cube)
  - `Body_Dummy` cube on Outlet_0 (Layer 6 "Body", pink SM_Body material) -- click target
  - Gameplay glue in `RowWorker`: `Chop()` -> `Row.OnChop(amount)` -> `BloodBar.Add`
  - `ToolUpgradeController` subscribes to `BloodBar.OnFilled` and raises `OnReady` event
  - `WorldUpgradeButton` uses MPB to flip the button cube color (grey idle -> red ready -> grey on tier-up); `OnMouseDown` calls `TryUpgrade()`
  - `LeftoversGaugeVisual` drives the red fill quad's localScale/position from `BloodBar.Normalized` each frame
- **KayKit Platformer pipe kit imported:** `Assets/KayKit/Platformer/blue/` -- 7 FBXs (straight A/B, 90 A/B, 180 A/B, end) + 2 textures. Used `pipe_straight_A_blue` as the outlet visual anchor.
- **Materials pipeline:** Created 5 `SM_*.mat` assets under `Assets/_Sandbox/_BM/Materials/`. **Required URP/Unlit, not URP/Lit** -- URP/Lit created at runtime via `new Material(shader)` didn't render colors correctly (missing keyword setup). URP/Unlit + `SetColor("_BaseColor", c)` works.
- **Unity crash recovered:** `DestroyImmediate` on `SceneTint` components in edit mode crashed the editor mid-operation. Safer path: edit the SceneTint source file to no-op (data-only class), let Unity recompile, references quietly stop applying. Done. MCP server also disconnected during the crash; worked around by using `npx unity-mcp-cli run-tool` directly via shell.
- **Serialized refs wiped after crash, re-wired via reflection script-execute:** `ShaftTapHarvester.{_bodyLayer=64, _reaper, _camera}`, `Row.{_outlets, _workers, _bloodBar, _toolUpgrade, _rowIndex}`, `Reaper._assignedOutlet`, `ToolUpgradeController._bloodBar`, `BloodBarVisual.{_bloodBar, _fill}`, `WorldUpgradeButton.{_controller, _renderer}`, `ShaftManager._rowParent`.
- **Playtest PASS:** User confirmed click pink cube -> red blood fills floor -> 10 chops fills BloodBar -> button turns red -> click button -> tier increments -> fill resets. Full loop works. User named Layer 6 "Body" in TagManager.
- **Design rule captured:** Reaper physically patrols row outlets when multiple exist. ChopMinions stay bound to single outlet. Phase 4 work. Saved as project memory for future sessions.
- **Real Blood eval (ENTRY-329):** Knife/Real Blood imported and evaluated. Shaders are all Built-in RP (Amplify Shader Editor surface shaders), render full magenta in URP. Confirmed visually with test quad + BigPuddle material in BM_Shaft. **Rejected for URP/SM** -- overkill for mobile idle anyway. Salvage path: textures + particle prefabs + decal scripts for a future `BM.VFX.BloodBurst` micro-system in Sprint 3. ASE exposes programmatic template-swap APIs (`SetTemplateShader(URPLitGUID, false)`) but hits OnGUI threading blocker when driven from `script-execute`. Details in `reference_ase_programmatic_api.md` memory.

**Session 75 cont. (Apr 11, 2026) -- Phase 3 Gatherer->Funnel->Outlet flow + Blood Miner rename + scene polish:**
- **Full rename Soul Minor -> Blood Miner mid-session:** Reaper -> Ghoul, souls -> blood, BloodBar -> LeftoversGauge (chose "Leftovers" over "Gore Meter" / "Entrails Gauge"), folder `_SM/` -> `_BM/`, namespace `SM.*` -> `BM.*`. Used `[FormerlySerializedAs]` on renamed fields (`_bloodBar`, `_reaper`) to preserve scene refs across rename.
- **Phase 3 chain wired end-to-end:**
  - `BodyFunnel` (Queue<BodyConfigSO>): accepts bodies from gatherers, ticks at `_baseTickInterval / clearOutletCount` (paused when 0 clear, faster as more outlets clear)
  - `PipeNetwork.DeliverBody`: round-robins to first clear `RowOutlet`
  - `BodyPool` (central): rents/returns typed `GameObject` per `BodyConfigSO`. Falls back to primitive cube on Layer "Body" if config has no prefab. Inactive parking under `_inactiveParent` (gauge layout-irrelevant)
  - `RowOutlet.PlaceBody`: rents from pool, parents under `_spawnPoint`, attaches `ClickableBody`, fires `OnBodyPlaced`
  - `ClickableBody`: tag component bound to owning outlet + config, click -> chop -> `Outlet.ConsumeBody` -> returns to pool -> fires `OnBodyCleared`
  - `Gatherer` state machine: WalkToPickup -> Gathering (carry random body of allowed tier) -> WalkToDrop -> drop into funnel
  - `GathererManager.SetCount(n)` for spawn count, `PickRandomBody(tier)` for body selection
- **Phase 3 visibility debug saga:** Body spawned active with valid renderer bounds but invisible. Iterated through diagnostics:
  1. RowOutlet `_spawnPoint` was null -> added Awake fallback
  2. Pool body parented at outlet world (1.50, 1.50, 0) coincided with PipeVisual cylinder -> created `BodyDrop` child of Outlet_0 at world (0, 0, 0), wired as `_spawnPoint` via reflection
  3. Tested `localScale = Vector3.one` reset -> body became visible but TINY because spawnPoint chain had inherited 3x scale -- removed the override, kept inherited scale
  4. Camera flipped Reaper-style: was at (1.5, 2.2, -6.5), bodies face +Z so camera saw their backs. Moved to (0, 2.2, +6.5) looking back at row center -- bodies now face camera, no yaw artifacts (centered on x=0)
  5. LeftoversGauge fill clipped through dog/ghoul/upgrade button at floor level -> dropped gauge to world Y=-0.3 (slightly below ground). Glass-top recess deferred to later transparency pass.
- **Playtest CONFIRMED:** Cute Pet dogs/cats visibly arrive at the outlet, walk-by gatherer drops feed the funnel queue, pipeline ticks dispatch bodies on schedule. Full Phase 3 visual loop is live.
- **Memories saved (re-usable across sessions):**
  - `project_bm_ghoul_movement.md` -- Ghoul is player-controlled (tap to move + chop), NOT auto-patrol (updated Session 76)
  - `project_bm_outlet_arrival_pop.md` -- Bodies should "extrude" out of pipe with progressive squash (deferred to Sprint 3 polish, deformer asset already in project)
  - `project_bm_pinned_surface_scroll.md` -- Phase 5 viewport: surface stays pinned at top, rows scroll up showing last + active row only. Two-camera approach planned.
  - `reference_ase_programmatic_api.md` -- ASE template swap API + OnGUI blocker

**Session 74 (Apr 11, 2026) -- Design Pivot, GDD v2.0, Rebuild Plan:**

**Session 74 (Apr 11, 2026) -- Design Pivot, GDD v2.0, Rebuild Plan:**
- Playtest feedback: mine/elevator/warehouse didn't visually tell a story. "Why are animals appearing? What does the elevator do?" The IMT framing wasn't fitting the soul-harvesting fiction.
- Explored the mythology (reaper/psychopomp role) briefly, decided to drop the "why" entirely and focus on a legible factory loop
- **New core structure:**
  - Gatherers (surface, max 10, upgrade speed/carry-tier) fetch bodies and drop them in a funnel
  - Bodies flow through pipes down to rows
  - Reaper (player) starts on Row 0 with 1 outlet, chops manually
  - Row upgrades: 4 outlets max, each outlet adds a chop-minion
  - Blood bar on each row floor fills as chops happen
  - When blood bar full, Tool Upgrade button available (soul multiplier for that row)
  - Auto-button minion (per-row purchase) presses tool upgrade automatically
  - When row fully built (4 outlets + 4 minions), T-connector auto-builds and next row unlocks
  - Reaper moves down manually via Descend button. One-way.
  - Deeper rows = higher multipliers + new body types (cat/dog, +pig, +sheep, +rabbit/chicken, +cow)
  - Coffins occasionally drop for bonus rewards
  - Rank system + zones REMOVED in v2.0
- Wrote `BM_GDD.md` v2.0 -- full replacement of sections 2-10 and 17
- Wrote `BM_RebuildPlan.md` -- keep/adapt/delete tables, build order, scene hierarchy target, UI layout target
- **Kept from Sprint 1** (still reusable): BloodManager, GameEvent system, NumberPop, ComboSystem, SaveManager (ES3), BodyConfigSO, Cute Pet body prefabs, KayKit art, Layer 6 setup, UpgradeSystem math, UI click-through fix
- **To delete** (after Sprint 2 scene proven): MineLevel, Elevator, Warehouse, RankSystem, 8 RankConfigSOs, ZoneConfigSO, BM_ShallowGraves scene

**Previous Sprint 1 work (kept for reference, not gameplay-current):**
See `BM_StatusArchive.md` (to be created) for sessions 1-73 if needed. Key outputs:
- 21 scripts in BM.Core/Harvest/Mine/Upgrade/UI/VFX
- ES3 save/load working
- Full UI Toolkit HUD
- KayKit Halloween + Skeletons + Block Bits art imports
- Environment dressing with overlap scanner
- Cute Pet material fixes (Toon/Toon -> URP/Lit)

**Session 4 (Apr 4, 2026) -- Save/Load, Rank Progression, UI Fixes:**
- Fixed floating bodies: BodyPile spawn Y lowered to 0.05
- SaveManager now auto-loads on Start() and uses Easy Save 3 directly (was using PlayerPrefs fallback -- I had incorrectly said ES3 wasn't in project)
- UpgradeSystem persistence: exposed ElevatorUpgradeLevel, WarehouseUpgradeLevel, GetMineUpgradeSnapshot, RestoreState, ReapplyAllUpgrades
- SaveManager wired with references to UpgradeSystem + all MineLevels + Elevator + Warehouse + 3 configs to reapply stats on load
- 6 new RankConfigSOs created (Rank 2-7 from GDD: Crypt Warden, Soul Foreman, Death's Bookkeeper, Harbinger, Pale Rider, Grim Reaper). All 8 ranks wired into RankSystem -- rank bar now progresses naturally
- Removed Collect button from UXML (vestigial -- warehouse never receives in direct flow)
- Fixed UI click pass-through: TapHarvester now checks `UIDocument.rootVisualElement.panel.Pick()` before raycasting. Clicks on buttons no longer fire both UI and 3D harvest
- ES3 known issue: old PlayerPrefs saves won't migrate; first ES3 launch starts fresh. `Clear Save Data` context menu on SaveManager component.

**Session 3 (Apr 4, 2026) -- NumberPop, Upgrade Feedback, Cute Pet, Environment:**
- NumberPop system: pooled world-space TextMesh rises + fades on harvest
- TapHarvester reads MineLevel.SoulYieldMultiplier so Mine upgrades visibly increase tap value
- Cute Pet Cat/Dog prefabs: 3x scale, colliders, Layer 6, animators stripped, Suriyun Toon/Toon materials converted to URP/Lit
- Environment dressing rebuilt with 2u block spacing: KayKit Halloween props (graves, fences, candles, coffins, ribcage, bones) + BlockBits shaft (dark stone walls, dirt floors, grass ground, bottom cap). 0 overlaps.
- Scanner tool: script-execute walks [Environment] AABBs and reports clipping pairs
- Collider/renderer bounds scan integrated into workflow for placement verification

**Session 2 (Apr 4, 2026) -- Scene Wiring, UI, Art Assets:**
- 18 config SO instances created: 2 BodyConfigSOs (Cat, Dog), 2 RankConfigSOs (Rank 0-1), 1 ZoneConfigSO (Shallow Graves), 3 UpgradeConfigSOs (mine/elevator/warehouse), 11 GameEvent SOs
- BM_ShallowGraves scene fully wired:
  - [GameManager]: BloodManager, RankSystem, GameState, SaveManager, UpgradeSystem
  - [Input]: TapHarvester, ComboSystem
  - [Mine]: ZoneInitializer, Elevator, Warehouse, 3 MineLevels with BodyPiles (Box colliders on Layer 6 "Body")
  - [UI]: UIDocument + SMHUD controller
- New scripts: ZoneInitializer (BodyPile init + IGameEventListener<double> for Elevator->Warehouse), SMHUD (UI Toolkit controller)
- UI Toolkit HUD: soul counter, rank bar, combo indicator, 3 upgrade buttons, collect button. PanelSettings 1080x1920 portrait.
- UI fix: pickingMode=Ignore on root so clicks pass through to 3D body piles
- Placeholder body prefabs: pink cube (Cat), brown cube (Dog)
- Camera: side-view, dark purple bg, 45 FOV
- **Art assets imported:**
  - KayKit Skeletons (6 characters + 2 anim sets) -- player rank progression
  - KayKit Halloween (102 props) -- Shallow Graves/Cemetery zones
  - KayKit Block Bits (58 tiling blocks) -- mine shaft walls/floors
  - Suriyun Cute Pet + ForActionGames Assembly Kit already in project
- **First playtest:** Tap cubes -> disappear -> soul counter increments -> upgrade buttons work. UI click-through fixed. Upgrades run but no visible feedback yet.

**Known Issues (carryover from Sprint 1 -- mostly irrelevant after pivot):**
- IMT three-bottleneck framing didn't land -- resolved by the pivot
- Environment dressing gaps -- will be redesigned for row-factory layout anyway
- KayKit prop orientation quirks -- still relevant for new scene, memory saved
- Assembly Kit vs KayKit Skeletons decision -- irrelevant, new design has single reaper visual

**Next (Session 80):**

Phase 9 cont. -- Polish + visual pass:
1. **Surface mask tweaking:** Verify masking on different screen sizes. [Surface] parent at Y=1.5, mask at localY=19.
2. **Top bar UI fine-tuning:** 3-column layout done, verify content fits on mobile aspect ratios.
3. Pipe Dream Pack visual swap (replace KayKit pipe cylinders with PipeDreamPack prefabs)
4. LeftoversGauge transparency/glass-top pass
5. Playtest + balance pass (cost curves, body values, tool tier scaling, gauge capacity growth)
6. Save/load: persist auto-button state, gauge capacity, viewed row

**Design consideration (undecided):** Rows feel very busy with 4 minions. Options: reduce to 1 minion per 2 outlets (shared, positioned between them) or 1 minion per row that moves between all 4 outlets. Would affect row completion logic (`IsFullyBuilt`), buy-minion cost curves, and minion spawn/assignment code. Evaluate during next playtest.

Sprint 3 Polish (deferred):
- Body gravity-drop from outlet to floor (Rigidbody + ground collider)
- Progressive-emergence squash on body arrival (see `project_bm_outlet_arrival_pop.md`)
- Pipe Dream Pack visual swap (replace KayKit pipes, PipeBaloon for blocked outlets)
- LeftoversGauge glass-top transparency
- Blood splat VFX on chop
- T-connector visual between rows on completion

Carryover cleanup:
- Delete `Assets/Knife/Real Blood/Shaders/BloodPuddle.shader.bak` (leftover from ASE port probe)
- Destroy `RB_Test` cube in `BM_Shaft` scene (Real Blood render test baseline)
- Optional: clean up `_Sandbox/_BM/Scripts/Core/SceneTint.cs` entirely (now a data-only stub) or delete any dangling SceneTint component references in scene
- LeftoversGauge transparency/glass-top pass (top quad with URP/Lit Surface=Transparent or one of the existing glass shaders) so characters look like they stand on the recessed gauge cover instead of floating above empty space

Reference: `BM_RebuildPlan.md` for the full 8-phase build order and scene/UI targets.

**Session 0 (Apr 3, 2026) -- Concept:**
- Blood Miner concept revived from TecVooDoo Projects napkin entry
- Concept doc written at `E:\TecVooDoo\Projects\Games\1 Concepts\Soul Miner or Blood Miner\Documents\BloodMiner_Concept.md`
- Idle Miner Tycoon structure confirmed (vertical shaft, three bottlenecks)
- Cute + gore identity locked (Happy Tree Friends meets IMT)
- GDD v1.0 drafted, docs structure created

---

## Sprint Plan

### Sprint 1: Core Tap Loop (Vertical Slice Foundation)
- BloodManager (currency tracking, earn/spend)
- TapHarvester (input -> harvest -> soul reward -> VFX trigger)
- Mine level SO config (soul yield, harvest speed, body type pool)
- Basic UI (soul counter, tap feedback, upgrade button)
- Single zone with 3 levels (static layout, no scrolling yet)
- Save/load (Easy Save 3 -- soul count, level states)
- **Playtest:** Tap bodies, see numbers go up, buy an upgrade, see numbers go up faster

### Sprint 2: Three Bottlenecks (IMT Structure)
- Elevator system (soul transport from levels to surface, capacity limit)
- Warehouse system (surface collection, storage cap, auto-collect upgrade)
- Level upgrade curves (exponential cost, linear output)
- Vertical scroll between levels
- Balance pass on all three bottlenecks
- **Playtest:** Do I feel the bottleneck? Do I want to upgrade the right thing?

### Sprint 3: Gore + Juice (The Identity)
- Scythe swing animation per body type
- Blood spray VFX (directional, body-type specific particles)
- Body part physics (limbs, tails, feathers -- short trajectory, fade)
- Soul wisp release (beautiful ethereal rise from gore)
- Screen shake, number pops, combo multiplier feedback
- Audio: wet crunch + chime, squelch per type, soul whoosh
- **Juicy Actions** -- install at standalone migration. Use SO-based action sequences for all juice: tap feedback (scale punch + shake), combo multiplier popups (spring actions), harvest gore bursts (action groups), elevator arrival (timed sequences), upgrade purchase (post-processing flash). Replaces custom coroutine-based VFX scripting.
- **Playtest:** Does the harvest FEEL incredible? Violence-to-beauty transition working?

### Sprint 4: Ranks + Zones (Progression)
- Rank system (8 ranks, lifetime soul thresholds)
- Rank-up UI (promotion letter from Management, character visual change)
- Multiple zones (3-4 at launch), zone unlock on rank
- Zone-specific body types, art themes, soul values
- Minion system (auto-harvest, tier 1-3)
- **Playtest:** Does ranking up feel rewarding? Do zones feel different?

### Sprint 5: Idle + Monetization (Mobile Ready)
- Offline earnings calculation (timestamp delta)
- Return-to-game collection moment
- Rewarded ads (2x offline, temporary boost)
- IAP integration (Dark Gem packs, Auto-Collect Pass)
- Prestige system (Rank 5+ ascension for permanent multipliers)
- Daily rewards
- **Playtest:** Does idle-return feel satisfying? Is monetization non-intrusive?

### Sprint 6: Polish + Ship
- All body type gore VFX polished
- All zone art passes
- Audio pass (ambient per zone, full SFX suite)
- Tutorial/onboarding (first 2 minutes)
- App Store assets (screenshots, description, icon)
- Analytics integration
- Soft launch
- **Ship it**

---

## Key Decisions

| Decision | Choice | Rationale |
|----------|--------|-----------|
| Platform | Mobile-first (iOS/Android), portrait | Learn mobile, ship fast |
| Genre | Idle/Incremental (IMT structure) | Proven formula, low complexity |
| Art style | Cute + gore (Happy Tree Friends tone) | Differentiator, shareable content |
| Presentation | 3D diorama, fixed side-view | Reuse existing 3D assets, looks polished |
| Bodies | Cute Pet (Suriyun) animals | Already evaluated, perfect fit |
| Player character | Assembly Kit Ghost/Skeleton/Reaper | Rank progression visual |
| Environment | KayKit Halloween + KayKit | Dark but stylized |
| Reference game | Idle Miner Tycoon | Three-bottleneck structure |
| Monetization | F2P with rewarded ads + IAP | Standard mobile idle model |
| Scope | Jumpstart in Sandbox, migrate when proven | Same pattern as HNR, AQS, FearSteez |

---

## Asset Needs

| Need | Decision | Status |
|------|----------|--------|
| Body models | Cute Pet (Suriyun) -- cat, dog, pig, sheep, rabbit, chicken, cow | Already in Sandbox |
| Player character | Assembly Kit (Sigmoid/ForActionGames) -- ghost, skeleton, reaper | Already in Sandbox |
| Environment | KayKit Halloween + KayKit environment | CC0, download when needed |
| Gore VFX | Custom particle systems + shaders | Build during Sprint 3 |
| UI | UI Toolkit (all UI) | Built-in |
| Save/Load | Easy Save 3 | Already in Sandbox (default package) |
| Audio | Master Audio 2024 | Already in Sandbox (default package) |
| Tweening | DOTween Pro | Already in Sandbox (default package) |
| Text effects | Text Animator | Already in Sandbox (default package) |
| Action sequencing / juice | Juicy Actions 1.0.3 (Magic Pig Games) | Evaluated in Sandbox (ENTRY-316, Approved/Recommended). Install at standalone migration -- too heavy for Sandbox (604 scripts, ~108K LOC). Covers screen shake, scale punch, spring physics, combo feedback, post-processing effects. Replaces need for custom VFX coroutines in Sprint 3. |
| Blood shader | TBD -- may need eval | Sprint 3 |

---

## Known Issues

None yet -- pre-development.

---

## Reference Documents

| Document | Path |
|----------|------|
| Dev Reference | `Documents\BloodMiner\BM_DevReference.md` |
| Code Reference | `Documents\BloodMiner\BM_CodeReference.md` |
| GDD | `Documents\BloodMiner\GDD\BM_GDD.md` (v1.0) |
| Concept Doc (original) | `E:\TecVooDoo\Projects\Games\1 Concepts\Soul Miner or Blood Miner\Documents\BloodMiner_Concept.md` |
| Sandbox Status | `Documents\Sandbox_Status.md` |

---

**End of Document**
