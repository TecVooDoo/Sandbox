# Soul Minor -- Project Status

**Project:** Soul Minor (Mobile Idle/Incremental -- Cute + Gore)
**Developer:** TecVooDoo LLC / Rune (Stephen Brandon)
**Unity Version:** Unity 6 (URP)
**Working Path:** `E:\Unity\Sandbox` (Sandbox incubator)
**SM Root:** `Assets/_Sandbox/_SM/`
**Last Updated:** April 3, 2026 (Session 0 -- Concept)

> **ARCHIVE RULE:** This doc holds only the current state and last ~2 sessions. When adding a new session, move older entries to `SM_StatusArchive.md` (newest first at top of archive). This keeps the status doc fast to read while preserving full history.

**Reference doc:** `SM_DevReference.md` -- architecture, standards, AI rules. Read on demand.

---

## Current State

**Phase:** Pre-development. Concept doc complete. GDD v1.0 drafted. Sandbox strip-down in progress. Jumpstart begins after Sandbox is lean.

**Session 0 (Apr 3, 2026) -- Concept:**
- Soul Minor concept revived from TecVooDoo Projects napkin entry
- Concept doc written at `E:\TecVooDoo\Projects\Games\1 Concepts\Soul Miner or Soul Minor\Documents\SoulMinor_Concept.md`
- Idle Miner Tycoon structure confirmed (vertical shaft, three bottlenecks)
- Cute + gore identity locked (Happy Tree Friends meets IMT -- sickeningly cute bodies, visceral scythe harvesting)
- Mobile-first, portrait orientation, 3D diorama presentation
- Chosen over Shift Happens: Nurse Edition as next jumpstart (ships faster, teaches mobile)
- GDD v1.0 drafted, docs structure created

**Next (Session 1 -- Jumpstart Sprint):**
- Sandbox strip-down must complete first (compile times still 9+ min)
- Create `Assets/_Sandbox/_SM/` folder structure
- Core scripts: SoulManager, TapHarvester, UpgradeSystem, RankSystem
- Config SOs: RankConfigSO, ZoneConfigSO, BodyConfigSO, UpgradeConfigSO
- Vertical slice target: 1 zone (Shallow Graves), 3 mine levels, tap + elevator + warehouse

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
