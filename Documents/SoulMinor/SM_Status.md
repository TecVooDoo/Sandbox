# Soul Minor -- Project Status

**Project:** Soul Minor (Mobile Idle/Incremental -- Cute + Gore)
**Developer:** TecVooDoo LLC / Rune (Stephen Brandon)
**Unity Version:** Unity 6 (URP)
**Working Path:** `E:\Unity\Sandbox` (Sandbox incubator)
**SM Root:** `Assets/_Sandbox/_SM/`
**Last Updated:** April 3, 2026 (Session 1 -- Jumpstart)

> **ARCHIVE RULE:** This doc holds only the current state and last ~2 sessions. When adding a new session, move older entries to `SM_StatusArchive.md` (newest first at top of archive). This keeps the status doc fast to read while preserving full history.

**Reference doc:** `SM_DevReference.md` -- architecture, standards, AI rules. Read on demand.

---

## Current State

**Phase:** Sprint 1 in progress. Core scripts compiling. Scene created. Ready for scene wiring + config SO instances.

**Session 1 (Apr 3, 2026) -- Jumpstart Sprint:**
- Full folder structure created under `Assets/_Sandbox/_SM/`
- 19 scripts written and compiling clean (0 errors):
  - **SM.Core (11):** GameEvent, GameEventListener, GameEvent<T>/DoubleGameEvent/IntGameEvent, BodyConfigSO, ZoneConfigSO, RankConfigSO, UpgradeConfigSO, SoulManager, RankSystem, GameState, SaveManager
  - **SM.Harvest (2):** TapHarvester, ComboSystem
  - **SM.Mine (4):** MineLevel, BodyPile, Elevator, Warehouse
  - **SM.Upgrade (2):** UpgradeSystem, UpgradeCurve
- SM_ShallowGraves scene created
- Hit Unity import pipeline bug: .cs files written via filesystem Write tool weren't imported as MonoScripts with auto-refresh disabled. Required deletion + recreation via MCP `script-update-or-create` tool. Feedback memory saved.

**Next (Session 2):**
- Create config SO instances: 2 BodyConfigSOs (Cat, Dog), 1 ZoneConfigSO (Shallow Graves), 3 UpgradeConfigSOs (mine, elevator, warehouse), 2 RankConfigSOs (Rank 0-1)
- Wire SM_ShallowGraves scene: GameState, SoulManager, RankSystem, SaveManager, Elevator, Warehouse, 3 MineLevels with BodyPiles
- Basic UI (soul counter, upgrade buttons) -- UI Toolkit
- Phase 4 art assets (Cute Pet, Assembly Kit, KayKit)
- First playtest: tap bodies, see numbers go up

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
