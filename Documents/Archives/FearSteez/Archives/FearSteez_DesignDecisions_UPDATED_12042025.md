# FearSteez - Design Decisions and Insights

**Version:** 1.0  
**Date Created:** December 4, 2025  
**Last Updated:** December 4, 2025  
**Developer:** TecVooDoo LLC  
**Designer:** Rune (Stephen Brandon)  
**Project Stage:** Concept  

---

## Project Identity

### The Pitch

**FearSteez** is a 2.5D side-scrolling beat 'em up where you play as a real Atlanta rapper fighting through waves of enemies to reach your concert. An evil rap-hating sorcerer has cursed the city - his minions patrol by day, zombies rise at night. Your fists, your music, and your skills are all that stand between you and the stage.

### Core Pillars

| Pillar | Description |
|--------|-------------|
| **Authentic Artist** | FearSteez is a real person with real music - the game celebrates that |
| **Classic Beat 'Em Up** | Streets of Rage meets Double Dragon - accessible, satisfying combat |
| **RPG Depth** | Blaster Master-style progression keeps players invested beyond the action |
| **Day/Night Duality** | Two distinct enemy rosters create variety and strategic choice |
| **Music-Driven** | FearSteez's actual tracks power the experience |

### Genre Reference Games

| Game | What to Study |
|------|---------------|
| **Streets of Rage 4** | Modern beat 'em up combat feel, combo system, visual feedback |
| **Double Dragon Neon** | Humor, style, RPG elements, co-op |
| **Blaster Master Zero** | RPG progression in action game, zone structure |
| **River City Girls** | 2.5D movement, shops, RPG mechanics |
| **Scott Pilgrim** | Music integration, pixel art style, leveling |

---

## Combat Design

### Core Loop

```
APPROACH -> ATTACK -> COMBO -> CROWD CONTROL -> REPEAT
```

1. **Approach:** Navigate 2.5D plane to engage enemies
2. **Attack:** Light and heavy attacks with distinct purposes
3. **Combo:** Chain attacks for bonus damage/effects
4. **Crowd Control:** Manage multiple enemies, use environment
5. **Repeat:** Clear wave, progress, face tougher enemies

### Attack System (Initial Design)

| Input | Attack | Purpose |
|-------|--------|---------|
| Light (X/Square) | Jab combo | Fast, safe, combo starter |
| Heavy (Y/Triangle) | Power hit | Launcher, combo ender, armor break |
| Jump + Attack | Air attack | Crowd control, style |
| Special (B/Circle) | Signature move | Costs resource, high damage/utility |
| Grab (near enemy) | Throw/slam | Repositioning, crowd damage |

### Combo Philosophy

**Design Principle:** Easy to start, rewarding to master.

- **Mash-friendly:** Button mashing produces decent results
- **Depth available:** Timing and variety increase damage/style
- **No infinite combos:** Enemies recover after X hits
- **Environmental combos:** Throw enemies into walls, each other

### Damage and Health

| Decision | Choice | Rationale |
|----------|--------|-----------|
| Health display | Hearts or HP bar? | TBD - test both |
| Damage numbers | Yes/No? | Leaning yes for RPG feel |
| Hitstun | Medium duration | Long enough to combo, short enough to feel fair |
| I-frames | On knockdown recovery | Prevents stun-lock deaths |

---

## Day/Night System

### Core Concept

The sorcerer's curse manifests differently depending on time:
- **Day:** Human minions, magical constructs, hired thugs
- **Night:** Zombies, undead, supernatural creatures

### Implementation Options

| Approach | Pros | Cons |
|----------|------|------|
| **Real-time cycle** | Immersive, dynamic | Complex, pacing issues |
| **Level-based** | Predictable, easier design | Less dynamic |
| **Player choice** | Maximum control | Loses narrative weight |
| **Story-driven** | Narrative integration | Railroaded |

**Initial Decision:** Level-based with some real-time elements. Certain levels are locked to day or night; some levels transition mid-level for dramatic effect.

### Enemy Roster Split

**Day Enemies (Minions):**
- Street thugs (basic melee)
- Magic users (ranged, shields)
- Bouncers (heavy, armored)
- Sorcerer's apprentices (mini-bosses)

**Night Enemies (Undead):**
- Walkers (basic zombie)
- Crawlers (fast, low to ground)
- Bruisers (tank zombies)
- Risen (former day enemies, corrupted)

### Mechanical Differences

| Aspect | Day Enemies | Night Enemies |
|--------|-------------|---------------|
| Behavior | Coordinated, tactical | Swarm, relentless |
| Weakness | None special | Fire? Light? TBD |
| Drops | Cash, items | XP-focused, rare items |
| Density | Moderate waves | High numbers |

---

## RPG Systems

### Progression Philosophy

**Blaster Master Inspiration:** Meaningful upgrades that change how you play, not just stat boosts.

### Planned Systems

| System | Description | Priority |
|--------|-------------|----------|
| **Experience/Levels** | Traditional XP -> Level Up | HIGH (MVP) |
| **Stats** | STR, DEF, SPD, etc. | HIGH (MVP) |
| **Skills** | Unlockable moves and passives | MEDIUM |
| **Equipment** | Gear that affects gameplay | MEDIUM |
| **Currency** | Buy items, upgrades | MEDIUM |

### Stats (Initial Design)

| Stat | Effect |
|------|--------|
| **Strength** | Damage dealt |
| **Defense** | Damage reduction |
| **Speed** | Movement and attack speed |
| **Stamina** | Special move resource |
| **Style** | Bonus XP/drops (risk/reward) |

### Skill Tree Ideas

- **Brawler Branch:** Raw damage, combos, crowd damage
- **Finesse Branch:** Speed, dodges, counters
- **Showman Branch:** Style bonuses, special effects, audience power-ups

---

## Music System

### Vision

FearSteez's actual music drives the game. Unlike A Quokka Story's stem-based adaptive approach, FearSteez uses the artist's recorded tracks more directly.

### Integration Options

| Approach | Description | Complexity |
|----------|-------------|------------|
| **Jukebox** | Full tracks play during levels | Simple |
| **Beat-sync** | Attacks sync to music for bonuses | Medium |
| **Stem mixing** | Layers respond to gameplay | Complex |
| **Hybrid** | Full tracks + stem accents | Medium |

**Initial Decision:** Start with Jukebox, explore beat-sync for special moves. Full stem system is future scope.

### Music-Gameplay Connection Ideas

- **Combo meter affects music:** Higher combo = more intense mix
- **Special moves trigger music accents:** Signature hits have musical stingers
- **Boss fights have unique tracks:** Each boss = specific FearSteez song
- **Style meter unlocks vocals:** Hit style threshold = vocals fade in

---

## Visual Style

### Art Direction (TBD)

| Style | Reference | Pros | Cons |
|-------|-----------|------|------|
| **HD Pixel** | River City Girls, Scott Pilgrim | Clear, nostalgic | Art intensive |
| **Stylized 2D** | Streets of Rage 4 | Modern, fluid | Animation heavy |
| **2.5D/3D** | TMNT Shredder's Revenge | Depth, polish | Technical complexity |

**Decision:** TBD - depends on art resources. HD pixel is achievable solo.

### Visual Feedback Requirements

- **Hit sparks:** Clear impact visualization
- **Screen shake:** Proportional to hit power
- **Freeze frames:** On big hits (2-4 frames)
- **Enemy flash:** Damage indication
- **Health bars:** Floating above enemies

---

## Technical Decisions

### Why Unity 6?

- Matches other TecVooDoo projects
- Modern rendering pipeline (URP)
- Active support and documentation
- Asset store compatibility

### Architecture Approach

Following SOAP (ScriptableObject Architecture Pattern) for consistency with other projects:

| Pattern | Purpose |
|---------|---------|
| **CharacterDefinition SO** | Stats, moves, audio for player/enemies |
| **AttackDefinition SO** | Damage, range, hitstun, effects |
| **EnemyDefinition SO** | AI settings, spawn rules, drops |
| **GameEventSO** | Decoupled communication |

### Why NOT Use Existing Frameworks?

| Framework | Reason Against |
|-----------|----------------|
| **Corgi Engine** | 2D platformer focus, not beat 'em up |
| **TopDown Engine** | Top-down focus, not side-scroller |
| **FS Melee Combat** | Evaluate first, may be useful |

**Decision:** Custom with SOAP, study FS Melee Combat System for patterns.

---

## Open Questions

### Design Questions

| Question | Context | Priority |
|----------|---------|----------|
| Art style? | Determines scope and feel | HIGH |
| Co-op support? | Classic beat 'em up feature | MEDIUM |
| How many levels? | Scope definition | HIGH |
| Boss design approach? | Multi-phase? Patterns? | MEDIUM |
| Mobile port? | Affects control design | LOW |

### Technical Questions

| Question | Context | Priority |
|----------|---------|----------|
| FS Melee Combat useful? | Evaluate the asset | MEDIUM |
| Combo system architecture? | Input buffering, cancels | HIGH |
| Save system scope? | Checkpoints? Full state? | MEDIUM |

---

## MVP Definition

### Minimum Playable Demo

**Goal:** One complete level demonstrating core loop.

| Feature | Status |
|---------|--------|
| FearSteez movement (8-directional) | NOT STARTED |
| Basic attack combo (3-hit) | NOT STARTED |
| One day enemy type | NOT STARTED |
| One night enemy type | NOT STARTED |
| Health system | NOT STARTED |
| XP and level up | NOT STARTED |
| One FearSteez track playing | NOT STARTED |
| Win condition (clear waves) | NOT STARTED |

### What MVP Does NOT Include

- Full skill tree
- Equipment system
- Multiple levels
- Boss fights
- Story/cutscenes
- Polish (juice, particles)

---

## Asset Inventory Notes

### Relevant Owned Assets

| Asset | Relevance to FearSteez |
|-------|------------------------|
| **FS Melee Combat System** | Potential combat foundation - EVALUATE |
| **Animancer Pro v8** | Animation state machine |
| **Feel** | Game juice, hit feedback |
| **Master Audio 2024** | Music system |
| **SOAP** | Architecture |
| **Odin Inspector** | Editor tools |
| **SensorToolkit 2** | Enemy detection |
| **DOTween Pro** | Tweening |
| **Easy Save** | Progression saving |
| **All In 1 Sprite Shader** | Visual effects |

### Assets NOT Relevant

| Asset | Why Not |
|-------|---------|
| **Corgi Engine** | Platformer-focused |
| **A* Pathfinding Pro** | Beat 'em ups use simpler navigation |
| **Dialogue System** | Minimal story in MVP |
| **AA Map System** | No exploration/minimap needed |

---

## Development Phases (Rough)

### Phase 1: Foundation

- [ ] Project setup (Unity 6, GitHub)
- [ ] Player movement (2.5D navigation)
- [ ] Basic attack (single hit)
- [ ] One enemy type (stand and get hit)
- [ ] Placeholder art

### Phase 2: Combat Core

- [ ] Combo system (3-hit chain)
- [ ] Enemy AI (approach, attack, react)
- [ ] Health and damage
- [ ] Basic HUD

### Phase 3: Progression

- [ ] XP and leveling
- [ ] Stat increases on level up
- [ ] Day/night enemy split
- [ ] Music integration (jukebox)

### Phase 4: Polish and Content

- [ ] Multiple enemy types
- [ ] Level design
- [ ] Visual feedback (Feel)
- [ ] Audio polish
- [ ] Boss fight

---

## Lessons from Other Projects

### From A Quokka Story

- **SOAP architecture works** - Use it here
- **Collision over raycast** - Simpler detection is more reliable
- **GitHub over Unity Version Control** - Better workflow
- **Profile early** - Beat 'em ups can have many enemies on screen
- **Asset inventory matters** - Check what you own before building

### From Beat 'Em Up Genre

- **Frame data matters** - Startup, active, recovery frames define feel
- **Screen position affects fairness** - Off-screen enemies shouldn't attack
- **Food heals** - Classic pickup design works for a reason
- **Bosses need patterns** - Learnable, punishable windows

---

**End of Design Decisions Document**

This is a living document updated as:
- Concept evolves into production
- Design questions are resolved
- Playtesting provides feedback
- Technical discoveries change approach
