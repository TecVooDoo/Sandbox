# Soul Minor -- Project Status

**Project:** Soul Minor (Mobile Idle/Incremental -- Cute + Gore)
**Developer:** TecVooDoo LLC / Rune (Stephen Brandon)
**Unity Version:** Unity 6 (URP)
**Working Path:** `E:\Unity\Sandbox` (Sandbox incubator)
**SM Root:** `Assets/_Sandbox/_SM/`
**Last Updated:** April 4, 2026 (Session 4 -- Save/Load, Ranks, UI Click-through)

> **ARCHIVE RULE:** This doc holds only the current state and last ~2 sessions. When adding a new session, move older entries to `SM_StatusArchive.md` (newest first at top of archive). This keeps the status doc fast to read while preserving full history.

**Reference doc:** `SM_DevReference.md` -- architecture, standards, AI rules. Read on demand.

---

## Current State

**Phase:** Sprint 1 core complete. Tap loop working end-to-end with save/load, 8 ranks, floating numbers, upgrade feedback. Three-bottleneck pipeline intentionally deferred to Sprint 2.

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
- SM_ShallowGraves scene fully wired:
  - [GameManager]: SoulManager, RankSystem, GameState, SaveManager, UpgradeSystem
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

**Known Issues:**
- Three-bottleneck pipeline not connected (tap goes direct to SoulManager) -- deferred to Sprint 2 per user preference. Not visible in current play.
- Environment dressing has a few visual gaps between the dirt floor rows (aesthetic only, not blocking gameplay)
- KayKit props: directional ones (skulls, gravestones) may render backwards at default rotation -- needs manual (0,180,0) check. Memory saved: `feedback_kaykit_prop_orientation.md`
- Assembly Kit vs KayKit Skeletons decision still pending for player character

**Next (Session 5):**
- Optional: connect three-bottleneck pipeline (Mine pending -> Elevator -> Warehouse -> Collect). GDD Sprint 2 scope.
- Body respawn tuning (currently 5s per body, one at a time)
- Rank-up feedback UI (promotion letter popup, title change animation)
- Pick character rank prefabs from KayKit Skeletons to replace Assembly Kit for player

**Session 0 (Apr 3, 2026) -- Concept:**
- Soul Minor concept revived from TecVooDoo Projects napkin entry
- Concept doc written at `E:\TecVooDoo\Projects\Games\1 Concepts\Soul Miner or Soul Minor\Documents\SoulMinor_Concept.md`
- Idle Miner Tycoon structure confirmed (vertical shaft, three bottlenecks)
- Cute + gore identity locked (Happy Tree Friends meets IMT)
- GDD v1.0 drafted, docs structure created

---

## Sprint Plan

### Sprint 1: Core Tap Loop (Vertical Slice Foundation)
- SoulManager (currency tracking, earn/spend)
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
| Dev Reference | `Documents\SoulMinor\SM_DevReference.md` |
| Code Reference | `Documents\SoulMinor\SM_CodeReference.md` |
| GDD | `Documents\SoulMinor\GDD\SM_GDD.md` (v1.0) |
| Concept Doc (original) | `E:\TecVooDoo\Projects\Games\1 Concepts\Soul Miner or Soul Minor\Documents\SoulMinor_Concept.md` |
| Sandbox Status | `Documents\Sandbox_Status.md` |

---

**End of Document**
