# Blood Miner -- Status Archive

**Purpose:** Full session history (oldest entries moved here from BM_Status.md, newest first).

---

**Session 87 (Apr 28, 2026) -- Outlet backup system + cascade visuals + Ghoul facing/feel polish:**

*Outlet backup system:*
- **RowOutlet queue:** new `_maxQueue` (default 3) and `_graceAfterClear` (1.5s) Inspector fields. Internal `Queue<BodyConfigSO> _backlog` plus `_paused`/`_pauseAllowedAt` runtime state. `PlaceBody` enqueues; if no current body, places one immediately. When `TotalBodies >= _maxQueue` and grace has elapsed, outlet pauses. `ConsumeBody` advances from backlog if non-empty; if fully cleared and was paused, unpauses + records grace window so it can't immediately re-pause.
- **PipeNetwork cascade routing:** `FindCascadeBarrier()` returns the index of the first paused outlet. Round-robin delivery now operates only over `[0, barrier)` -- a paused outlet blocks every downstream outlet from receiving, even if those downstream outlets technically have queue space. `GetClearOutletCount` renamed `GetAcceptingOutletCount` and returns the barrier (matches the cascade semantic).
- **BodyFunnel** uses `accepting` count for tick scaling, so the funnel naturally throttles when upstream outlets pause.
- **Public surface on RowOutlet:** `IsAcceptingBodies`, `BacklogCount`, `TotalBodies`, `IsPaused`, `MaxQueue`, plus UnityEvents `OnPaused` / `OnResumed` for downstream listeners.

*Cascade-aware backup visuals:*
- **PipeTCrossSmall_Heat material** authored at `Assets/_Sandbox/_BM/Materials/PipeTCrossSmall_Heat.mat`. Uses PipeDreamPack's `Heat_Effect.shadergraph` with the demo's `RegularPipeMed2.mat` settings (`_HeatColor=red`, `_HeatIntensity=1.83`, `_PulseSpeed=3.85`, `_ScrollSpeed=0.58`) but pointing at the TCrossSmall textures. Note: building a fresh material from the heat shader gives white because `_BaseMap` and `_HeatColor` default to nothing/white -- copy the demo's full property set when wiring new pipe shapes.
- **Per-outlet hot/cool swap:** `RowOutlet` caches its child `PipeTCrossSmall` renderer + the original (cool) material. New public method `SetBlockedVisual(bool hot)` flips `sharedMaterial` between heat and cool. Per-renderer reference flip -- doesn't bleed into other outlets sharing the cool material.
- **Driven by PipeNetwork cascade, not just self-pause:** `PipeNetwork.Update` walks all outlets each frame and calls `SetBlockedVisual(i >= barrier)`. So a paused outlet AND every cascade-blocked outlet downstream of it both go red. When the upstream outlet drains, the barrier moves and only the still-paused ones stay hot.
- **Lazy renderer cache:** runtime-spawned outlets get the kit child AFTER `RowOutlet.Awake` runs, so the initial `CacheHeatRenderer` finds nothing. `SetBlockedVisual` retries the cache lazily until the kit lands -- without this, runtime-purchased outlets (Outlet 1+) never resolve their renderer and stay cool no matter their state.
- **Surface_Pipe_Connection indicator:** new `SurfacePipeBlockIndicator` component on Surface_Pipe_Connection toggles `RegularPipeMed` (flowing) vs `PipeBlock`+`PipeBaloon` (clogged) each frame based on `ShaftManager.AnyOutletPaused()`. Component finds children by name and self-locates ShaftManager via `FindAnyObjectByType`.
- **Plumbing:** `Row._outletHeatMaterial` + `ShaftManager._outletHeatMaterial` (Inspector fields). `Row.Init()` accepts `outletHeatMaterial` (optional). `Row.AddOutlet()` assigns it onto each new RowOutlet via the `HeatMaterial` setter. `Row.Awake()` back-fills any pre-existing scene outlets that don't have it set.

*Ghoul facing + feel polish (continued from Session 86):*
- **Click-side facing:** `Ghoul.SwingAt(screenPos, camera)` projects the ghoul's screen position and compares to click X, sets `_facingDir` to point at whichever side was clicked, then plays the swing. Lets the player stand between two outlets and chop either side without using A/D. A/D held still sets facing every frame, so movement keys override the click-side flip on the next frame.
- **Hit-side filter:** `FindOutletInFront` only considers bodies on the side the ghoul currently faces (`signed * _facingDir >= 0`). Bodies behind the ghoul are never chopped without the player turning first. No more auto-pivot toward stale targets.
- **Chop impact timing:** `_chopImpactDelay` on the scene Ghoul restored to 0.7s (was tuned down to 0.2s in Session 86 for snap, but it landed on the upswing visually). Body now dies on the downswing matching where the visual axe lands. ChopMinion stays at 0.7s.
- **Other Ghoul tunings (carried from Session 86):** `_swingCooldown=0.15`, `_walkSpeed=3.5`, `_chopReach=1.4`.
- **Cross-row bug fixes:** ShaftManager.Descend now reparents the Ghoul BEFORE `MoveToRow(rowIndex, newRow)`, and `Ghoul.MoveToRow` refreshes the cached `_row` field. Without this the Ghoul could descend then fail to find any chop targets on the new row (cached `_row` pointed at empty Row_0). Same fix applied to ScrollView.
- **ChopMinion target-side chop:** also added a face-target step right before the chop fires in the already-at-goal branch, fixing the case where a target re-pick within `arriveDistance` skipped the walk-and-face step and chopped with stale rotation.

**Session 86 (Apr 28, 2026) -- Blood splat VFX + Ghoul input rework:**

*Blood splat VFX:*
- **Vefects burst wired into chop pipeline:** `RowWorker` gained five Inspector fields under "Chop VFX" header: `_bloodSplatPrefab`, `_bloodSplatLocalOffset`, `_bloodSplatLocalEuler`, `_bloodSplatScale` (=1f), `_bloodSplatLifetime` (=1.5f). New private `SpawnBloodSplat(outlet)` is called in `ChopImpactRoutine` immediately before `outlet.ConsumeBody()` so the burst plays as the body is consumed. Spawned as a child of the outlet's spawn point, with `Destroy(splat, lifetime)` for cleanup.
- **Public `BloodSplatPrefab` setter on RowWorker** so spawn paths can assign at runtime.
- **Threaded prefab through dynamic spawning:** `Row` got a serialized `_bloodSplatPrefab` (Header "Chop VFX"). `Row.Init()` accepts `bloodSplatPrefab` (default null, only overwrites if non-null so scene-set value isn't clobbered). `Row.AddChopMinion()` assigns the prefab onto the new minion via the public setter. `ShaftManager` got serialized `_bloodSplatPrefab` and passes it through `row.Init()` in `UnlockNextRow`.
- **Scene wiring (via reflection script-execute):** Set `VFX_Blood_Burst_Medium.prefab` (Once variant, default red) on Ghoul, Row_0, and ShaftManager. Saves so the field survives a scene reload.
- **AutoButtonMinion inherits the field** (extends RowWorker) but never calls `Chop()`, so no spurious blood — it only presses the upgrade button.
- **No pooling for first pass:** straight Instantiate + Destroy. Chop rate caps at ~1/0.7s per worker so it's safe; revisit with EasyPooling 2025 (approved Default) if profiling shows a hit.

*Ghoul input rework:*
- **Movement:** `Ghoul.cs` rewritten. Removed click-to-walk pathing (`GoToOutlet`, `_targetOutlet`, `_arriveDistance`). `Update()` polls A/D (Left/Right arrows as fallback), moves continuously via `transform.localPosition.x`, clamped to serialized `_minLocalX`/`_maxLocalX` (defaults -1.5/4.7 to span the row's outlet column range). Camera is rotated 180° around Y, so A/Left maps to world +X (=screen-left) and D/Right maps to world -X (=screen-right). Model facing rotation: Y=90 when moving world +X, Y=270 when moving world -X.
- **Swing:** new public `Swing()` method. Triggers Attack anim and finds the nearest outlet with a body within `_chopReach` of the Ghoul's X. Default reach bumped 0.7 → 1.2 (scene Ghoul also patched 0.5 → 1.2 — the prior 0.7 was the walk-stop distance, not a hit radius, and felt too tight for tap-the-swing). `_swingCooldown` (0.45s) prevents button-mash spam. If no body is in reach the swing still plays — sets up the future damageable-minion AoE.
- **Input source:** `ShaftTapHarvester` simplified to forward click/touch (and optional Space-bar) to `_ghoul.Swing()`. Removed the body-layer raycast, the row-match check, and the `_camera`/`_bodyLayer` serialized fields. UI pick-through guard kept.
- **D key freed:** `ShaftManager.Update` no longer calls `Descend()` on D press (UI button is the only descend trigger now). Up/Down arrows still scroll the view via `ScrollView`.
- **Walk loop import fix:** `Walking_A` clip on `Rig_Medium_MovementBasic.fbx` had `loopTime=false`, so after the 1.07s clip ended the animator held the last frame while the Ghoul kept moving (the "moonwalk slide" in the playtest report). Set `loopTime`+`loopPose` on Walking_A/B/C, Running_A/B (in `Rig_Medium_MovementBasic.fbx`) and Idle_A/B (in `Rig_Medium_General.fbx`); `SaveAndReimport`. Bonus: AC_ChopMinion's `Idle_A` is now looping too (shared FBX).
- **AC_ChopMinion still has no Walk state** — only Idle and Attack. Minions slide on the idle pose while walking between outlets. Not user-visible enough to fix this session; flagged for follow-up.

**Session 85 (Apr 23, 2026) -- Mobile minions + unlock-ready gate + viewed-row purchases + HUD readability:**
- **Descend fix when scrolled up:** `ShaftManager.Descend()` incremented `_rowParent.y` by one row spacing, assuming viewport was aligned to active row. If player scrolled up to a lower row and pressed descend, the shaft position was one row past the view anchor, making the new active row fly offscreen. Now sets `_rowParent.y = _viewedRowIndex * _rowSpacing` directly (matches `ScrollView` pattern).
- **Mobile minions + count redesign:**
  - `Row._maxChopMinions = 2` (new serialized field). Minion AI rewrite in ChopMinion: walk/chop like Ghoul, find nearest unclaimed outlet with body, claim/release via new `Row.IsOutletClaimedByMinion(outlet, except)` helper so two minions can't race the same body. Serialized `_walkSpeed=2.0`, `_arriveDistance=0.15`, `_chopReach=0.7`.
  - `AddChopMinion()` no longer takes an outlet arg; spawns minion N at outlet-N's column so they start apart.
  - Target-release on ConsumeBody happens naturally: after the chop impact, the outlet goes `IsClear`, next Update frame clears `_target`, minion re-picks.
- **Unlock gate + luxury minion:**
  - Renamed `Row.IsFullyBuilt` -> `IsUnlockReady` (4 outlets + 1 minion). Added `IsComplete` (4 outlets + 2 minions) for informational/UI use.
  - Next-row unlock now fires on `IsUnlockReady`. 2nd minion is an optional "bonus" purchase; not required to descend.
  - Minion cost refactored: `count==0 ? 480 : 2640` times depth (flat values, no 1.8 exponent since count caps at 2). M1 is the required worker; M2 is luxury (~5.5x).
- **Viewed-row purchases:** `TryBuyOutlet()` and `TryBuyMinion()` now operate on `ViewedRow ?? ActiveRow` instead of strictly `ActiveRow`. HUD uses `viewedRow` for cost labels + button gates. Player can scroll to any unlocked row and buy outlets/minions for it (matching the auto-upgrade button's per-row behavior). Descend gate still locked to active row's `IsUnlockReady`.
- **Gatherer tuning:**
  - Starting count 1 -> 2 (code default + scene patch -- scene had stale `_count: 1` from before the code bump).
  - Slot gating: 1 per 5 rows via `_rowsPerGathererSlot` (configurable). 25-row cap -> 5 earnable slots + 2 start = 7 max.
  - Speed cost `100*3^(t-1)` -> `500*4^(t-1)`; count cost `80*2^(c-1)` -> `500*3^(c-1)` (steeper, from session 84).
- **HUD readability:**
  - Fonts bumped ~30%: blood counter 22->26, blood icon 16->20, row label 12->16, upgrade title 14->18, upgrade cost 11->14, upgrade level 9->12.
  - Bottom buttons given near-opaque dark base (alpha 0.55 -> 0.92) with darkened color tint preserved via border: upgrade `(40,10,10,.92)`, minion `(10,15,35,.92)`, auto `(35,22,8,.92)`, descend `(10,30,10,.92)`. Row backdrop blocks no longer bleed through button text.
  - Minion cost label shows "BONUS: X" after M1 is bought, "MAX" at 2, "Cost: X" at 0. Outlet label shows `X/MaxChopMinions` instead of `X/OutletCount`.
- **Save/load guard for reduced max:** `while (row.ChopMinionCount < savedMinions && row.BuyMinion())` now bails if BuyMinion returns false, protecting against old saves with 3-4 minions against new cap of 2.

**Session 84 (Apr 22, 2026) -- Save/load multi-row fix + balance pass:**
- **Ghoul descent X fix (commit a9c78ba0):** `Descend()` and `ScrollView()` in ShaftManager were reparenting the Ghoul at hardcoded `(-1, 0, 0)` (old outlet_0-minion slot). Updated to `(0.24, 0, 0)` to match the scene starting slot after the outlet-layout overhaul.
- **Save/load multi-row unlock fix:** Load could only unlock Row 0 and Row 1 — the UnlockNextRow safeguard (added Session 80 to prevent premature second-below-ghoul unlocks) blocked repeat unlocks because the ghoul index hadn't advanced yet. BM_SaveManager now interleaves `UnlockNextRow() + Descend()` pairwise, matching the saved ghoul row; a final single UnlockNextRow handles the "one extra unlocked below ghoul" case. Tested to row 24 with all rows restored and no click-to-descend needed.
- **Balance pass (first pacing pass):**
  - **Depth multiplier:** `1 + 0.1*row` (linear) -> `1.2^row` (exponential). Row 0 stays at 1.0; Row 5 = 2.49; Row 10 = 6.19; Row 25 = 95.4. Was the main culprit making post-Row-0 too fast.
  - **Outlet base:** `50` -> `100` (doubled).
  - **Minion base:** `30` -> `60` (doubled).
  - **Auto-button base:** `200` -> `1600`. Was trivially cheap; now ~13% above the combined outlets+minions for that row at every depth. Ratio holds because it uses the same depth multiplier.
  - **Gatherer speed cost:** `100 * 3^(tier-1)` -> `500 * 4^(tier-1)`. Old max-to-T5 cost was 4k (trivial); new is 42,500.
  - **Gatherer count cost:** `80 * 2^(count-1)` -> `500 * 3^(count-1)`. Old was trivial at every tier.
  - **Gatherer slot gating:** 1 slot per row unlocked -> 1 slot per N rows (`_rowsPerGathererSlot` serialized, default 5). With 25-row cap, 5 slots total earnable. Starting count 1 + 5 earned = max 6 gatherers per run.
- **Numbers for Row 0 (depth=1.0) after balance:** outlets 100/200/400, minions 60/108/194/350, combined 1412, auto-button 1600.

**Session 83 cont. (Apr 22, 2026) -- Surface scene-placed + minion drift fix + Ghoul slot:**
- **Minion root-motion drift fix:** ChopMinions were slowly rotating toward camera and sinking into the gauge over time -- classic root motion accumulation, the animator clips had tiny positional/rotational deltas that compounded each cycle. `Animator.applyRootMotion = false` set in `ChopMinion.SetupModel()`, `ChopMinion.Awake()` auto-detect branch, and `Ghoul.Awake()`. Transforms are fully driven by code now; animation plays in place.
- **Ghoul starts in 2nd-minion slot:** Scene Ghoul moved from (-1.15, 0, 0) (outlet_0's minion slot, same side) to (0.24, 0, 0) = outlet_1's minion slot (1.39 + (-1.15)) -- on the right side of outlet_0 so Ghoul and the first ChopMinion don't stack.
- **Surface area scene-placed for manual tuning:** User wanted to hand-tune the surface pieces. `SurfaceMask`, `Surface_Pipe_Connection`, and Row_0's `PipesSides` now live as persistent scene children. `CreateSurfaceMask`, `CreateSurfacePipes`, and `CreateRowPipesSides` all skip-if-exists so scene-placed wins, dynamic rows still auto-spawn. Surface mask Material baked as asset at `Assets/_Sandbox/_BM/Materials/SurfaceMask.mat`.
- **Surface parent tilt discovery:** `[Surface]` root had an unexpected X tilt that threw off all child alignments. User manually retuned surface pipes (moved forward + reduced scale), funnel (moved to avoid mask occlusion), overlay. Pipes and funnel now FAKE the connection visually rather than aligning in world space. Explains the "odd" local values (e.g. Surface_Pipe_Connection at localZ=3.0 with smaller scale).
- **Gatherer Z alignment:** PickupPoint + DropPoint under `[Surface]` moved from localZ=0 to localZ=3 so gatherers walk on the same Z plane as the surface pipe visual (which user tuned to Z=3). BodyFunnel left alone at its user-tuned localZ=2.71.
- **Minion offset scene serialization fix:** Row_0's serialized `_minionXOffset` was stuck at -1 from when the field was first introduced with that default; bumping the source default to -1.15 didn't retroactively update the serialized instance. Scene value hand-patched to -1.15.

**Session 83 (Apr 21, 2026) -- Per-outlet Pipes_Outlet kit + KayKit anim import + layout alignment:**
- **Per-outlet Pipes_Outlet kit:** `Row.AddOutlet` now instantiates the full 5-piece `Pipes_Outlet.prefab` (T-cross + 3 caps) named `PipesOutletKit` instead of a single `RegularPipeShort`. Transform fields `_outletKitLocalPos/Euler/Scale` Inspector-tunable. `UpdateOutletCaps()` toggles children after each add: last kit shows `PipeCapRound (3)` (end cap), prior kits show `PipeCapWhole (2)` (through cap). Scene's `ShaftManager._pipeVisualPrefab` and Row 0's field both swapped to `Pipes_Outlet.prefab` (GUID `c52f4b7ae002cb24882d5c45064095ca`).
- **Scene Row 0 migration:** Row 0's Outlet_0 still had the legacy single-mesh `PipeVisual` child. Replaced in-scene with a full `Pipes_Outlet` kit (named `PipesOutletKit`, end cap visible) via script-execute, so Scene view now shows the kit without needing play mode. `Row.Awake` also does this migration at runtime as a fallback: if an outlet has a legacy `PipeVisual` and no `PipesOutletKit`, destroy the legacy and spawn the kit.
- **Outlet spacing 1.5 -> 1.39:** Outlet GameObject spacing now matches the visual pipe kit step so minions/ghoul positions align with the kit visuals. Removed the per-index `_outletKitXStepCorrection` drift correction (no longer needed). Changed in Row field default, Init param default, ShaftManager's call, and scene's Row 0 serialized value.
- **Surface pipe connection:** `ShaftManager.CreateSurfacePipes()` instantiates `Pipes_Surface.prefab` under `_surfaceRoot` as `Surface_Pipe_Connection` with serialized local pos (-1.21, 0.51, -0.17), rot (0, 90, 90), scale (3, 3, 3). Runs AFTER `CreateSurfaceMask()` so the mask's Z=3 child-push doesn't clobber the serialized Z (user's decision -- Z push disconnected the pipe from PipesSides visually). `SetLayerRecursive()` pushes the whole kit onto `_surfaceRoot`'s layer so nested pipe pieces inherit the surface layer (7).
- **KayKit animation import (10 FBXs):** Imported Rig_Large `CombatMelee, MovementAdvanced, Simulation, Special` and Rig_Medium `CombatMelee, CombatRanged, MovementAdvanced, Simulation, Special, Tools` from `E:\Game Assets\Itch\apps\kaykit-complete\...\KayKit Character Animations 1.1\Animations`. Import settings synced from `Rig_*_General.fbx` via script-execute (Generic rig, avatar setup, scale, compression, etc.) so all new FBXs drive the same skeleton.
- **Layout alignment (Row/ChopMinion/Ghoul/BodyDrop):**
  - `_bodyDropXOffset = -0.6f` serialized on Row -- BodyDrop shifts left under the kit visual instead of outlet-center.
  - `_minionXOffset = -1.15f` serialized on Row -- ChopMinions stand 1.15 left of outlet (negative=left). `OnValidate` makes it live during play mode (repositions existing ChopMinions + BodyDrops without having to respawn).
  - `Ghoul._chopReach = 0.7f` (was 0.5).
  - Scene Ghoul moved from local (1.5, 0, 0) (stale from old 1.5 spacing) to (-1.15, 0, 0) so it starts beside outlet_0's body drop instead of floating where outlet_1 used to be.
  - Backdrop local center Z -1 -> -2 (code default + scene Row 0 value) so it no longer overlaps the LeftoversGauge.
- **ChopMinion polish:**
  - Removed green placeholder cube leak: `Awake` created `CreatePlaceholderVisual()` (green cube) when no animator was detected, then `SetupModel` added the real model but never deleted the placeholder. `SetupModel` now destroys any `MinionVisual` child before instantiating the real model.
  - `_modelYRotation` (default 90) serialized on ChopMinion with `OnValidate` -- tune live in Inspector if the model prefab's internal rotation makes Y=90 look like 45 visually.

**Session 82 (Apr 21, 2026) -- Pipe visual kit (PipeDreamPack) + reference scene:**
- **Reference scene `BM_Shaft_Pipes`:** New scene at `Assets/_Sandbox/_BM/Scenes/BM_Shaft_Pipes.unity` with hand-placed pipe layouts showing the target look. Contains `Surface_Pipe_Connection` (funnel->pipe decor with togglable `PipeBlock`/`PipeBaloon`), 4 `PipesOutlets` instances, `PipesSides` (unlocked state), `PipesSides (1)` (locked state).
- **Prefabs extracted to `Assets/_Sandbox/_BM/Prefabs/Pipes/`:** `Pipes_Surface.prefab`, `Pipes_Outlet.prefab`, `Pipes_Sides_Unlocked.prefab`, `Pipes_Sides_Locked.prefab`.
- **ShaftManager pipe sides integration:** Replaced rough pipe rail + T-connector (session 82 first pass) with a cleaner per-row "PipesSides" kit. `CreateRowPipesSides(Row row, bool unlocked)` instantiates the appropriate prefab as a child of the row and destroys any existing one so state swaps are idempotent. On row creation: locked state. When the next row is unlocked: previous row's sides swap to unlocked (pipe continues). Default local offset from user's eyeballed reference: pos (-1.21, 2.04, -0.05), rot (0, 90, 90), scale (3, 3, 3) -- all Inspector-exposed.
- **Pipe rail + T-connector fields removed:** The old `_pipeRailPrefab` and `_tConnectorPrefab` serialized fields are gone (superseded by the kit prefabs).
- **PipesSides end-cap toggle (after playtest):** Every row now spawns in UNLOCKED state (PipeCapRound (2) = end cap visible). When a new row is created below, the previous row's PipeCapRound (2) is hidden via `HideRowEndCap()` so the pipe visually flows through. New row becomes the new "end" with its own end cap.
- **Gauge/BG X alignment fix:** `CreateGaugeForRow` and empty-row `BG` were placing new gauges at x=1.0, but Row 0 scene instance was at x=1.5. Aligned to 1.5 so dynamic rows match Row 0. Default `_pipesSidesLocalPos.y` tuned 2.04 -> 1.94 (scene field updated too).

**Session 81 (Apr 20, 2026) -- Chop animation sync + row backdrops:**
- **Chop impact delay:** `RowWorker.Chop()` no longer consumes the body immediately. Instead it starts a coroutine that waits `_chopImpactDelay` (default 0.7s) before calling `ConsumeBody`/`OnChop`. Fixes the bug where animals disappeared during the chop wind-up; now they despawn when the swing lands. Tunable per-worker via serialized field.
- **Row backdrops (KayKit BlockBits):** `ShaftManager.CreateRowBackdrop()` tiles 10x3 BlockBits cubes behind each row at local (1, 0, -1). Variant cycles by depth every `_rowsPerBackdropVariant` rows (default 2): dirt → gravel → stone → stone_dark → stone_with_copper → stone_with_silver → stone_with_gold. Colliders stripped. Called in Awake for Row 0 and in UnlockNextRow for dynamic rows. Array wired on ShaftManager in scene.
- **Initial Z bug:** Backdrop defaulted to z=+1 (in front of rows); fixed to z=-1 (behind). Camera at Z=18 looking -Z means lower Z = further from camera.

**Session 80 (Apr 18, 2026) -- Save/load expansion + glass-top gauge + pipe swap:**
- **Save/load auto-button + gauge capacity:** `BM_SaveManager` now persists `hasAutoButton` and `gaugeCapacity` per-row. On load, capacity is restored BEFORE fill so the cap applies correctly. Auto-button is re-bought via `row.BuyAutoButton()` and its purchase cube hidden so it doesn't require re-paying.
- **Glass-top transparency:** `CreateGaugeForRow()` now adds a translucent glass quad (0.6, 0.7, 0.8, 0.25 alpha) at localY=0.35 on top of the gauge. URP/Unlit with transparent surface keywords. Characters appear to stand on a glass cover over the red fill instead of floating.
- **Pipe Dream Pack swap:** `ShaftManager._pipeVisualPrefab` swapped from KayKit Platformer pipe to `OnePotatoKingdom_PipeDreamPack/Prefabs/RegularPipeShort.prefab`. Also replaced existing Row 0 Outlet_0 PipeVisual in scene with the new prefab. New rows created via `UnlockNextRow()` inherit the new prefab through Row.Init.
- **Pipe tuning (after playtest):** Pipe rotation set to Z=90 (was Y=90), scale to (0.5, 3, 3) (was 0.4 uniform). Applied in `Row.AddOutlet` and retroactively to scene outlets.
- **Glass-top Y:** Moved from 0.35 to 0.265 in code and existing scene instance so characters stand on it correctly.
- **Row 0 prefab ref fix:** Row 0's scene-serialized `_pipeVisualPrefab` still pointed at old KayKit pipe. Updated to new PipeDreamPack prefab so save-load-driven BuyOutlet calls on Row 0 use the new pipe.
- **Row unlock safeguard:** `UnlockNextRow()` now refuses to run if `_rows.Count > _ghoulRowIndex + 1` and logs a warning. Prevents premature unlock of a second-below row (e.g. Row 4 appearing while on Row 3). Bug didn't reproduce after first fix, but safeguard stays as defensive guard.

**Session 79 (Apr 15, 2026) -- UI frame fix + auto-upgrade + gatherer skeletons + viewport scrolling:**
- **UI frame fix:** Swapped both HUD panels from `Box_Hotbar_01`/`Box_Hotbar_03` (no proper 9-slice) to `Frame_Box_Large_07` (1024x1024, uniform 80px borders). Root cause: Hotbar sprites had no top/bottom borders (280,0,280,0 and 0,0,0,0). Top bar restructured to 3-column layout mirroring bottom: Speed button | Info box | Gatherers button. Bottom panel back to 3 buttons (Buy Outlet, Buy Minion, Descend). 4px margin from screen edges.
- **AutoButtonMinion (per-row auto-upgrade):** `AutoButtonMinion` now extends `RowWorker`. Each row gets a gold in-world `WorldAutoUpgradeButton` cube (0.6x0.4x0.6) below the tool upgrade button. Click to spend blood (200 * depth multiplier) and spawn an AutoButtonMinion that auto-presses the tool upgrade. Purchase button hides after click. Row 0 gets one in Awake.
- **Gauge scaling:** `ToolUpgradeController.TryUpgrade()` now increases `LeftoversGauge` capacity by 1.5x per tier (100 -> 150 -> 225 -> 337...). Added `LeftoversGauge.SetCapacity()`.
- **Gatherer skeleton models:** `Gatherer.SetupModel()` instantiates Skeleton_Minion at 0.4 scale with direction flipping based on movement. `AC_Gatherer` animator controller (Idle/Walk with IsWalking bool). `GathererManager` passes model/anim/material to spawned gatherers. Drives `IsWalking` in Update. Removed green cube MeshFilter/MeshRenderer from Gatherer prefab.
- **Viewport scrolling:** Up/Down arrows scroll view between row 0 and active row. `_viewedRowIndex` tracks which row is in view. `ScrollView(direction)` shifts `_rowParent.position.y`. HUD shows "Viewing Row X" when scrolled away from active row. Descend resets view to new active row.
- **Gauge/empty-row alignment:** Shifted gauge and empty row BG x from 1.5 to 1.0 (left 0.5 units) to align with row content.
- **Top bar UI fix (cont.):** Blood counter moved into center info box. Top bar changed from column to single horizontal row: Speed btn | Info (blood + Row + Outlets + Minions) | Gatherers btn. Row/Outlet/Minion info condensed to one line. Eliminated vertical stacking that caused overflow.
- **Ghoul scroll movement:** ScrollView now reparents ghoul to the viewed row so player physically moves there. Can click tool upgrade and auto-upgrade buttons on any visited row. Buy Outlet/Minion buttons disabled when viewing non-active row. HUD shows viewed row's outlet/minion counts.

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
21 scripts in BM.Core/Harvest/Mine/Upgrade/UI/VFX. ES3 save/load working. Full UI Toolkit HUD. KayKit Halloween + Skeletons + Block Bits art imports. Environment dressing with overlap scanner. Cute Pet material fixes (Toon/Toon -> URP/Lit).

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

**Session 0 (Apr 3, 2026) -- Concept:**
- Blood Miner concept revived from TecVooDoo Projects napkin entry
- Concept doc written at `E:\TecVooDoo\Projects\Games\1 Concepts\Soul Miner or Blood Miner\Documents\BloodMiner_Concept.md`
- Idle Miner Tycoon structure confirmed (vertical shaft, three bottlenecks)
- Cute + gore identity locked (Happy Tree Friends meets IMT)
- GDD v1.0 drafted, docs structure created

---

**End of Archive**
