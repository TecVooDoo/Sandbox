# FearSteez - Game Design Document

**Project:** FearSteez
**Developer:** TecVooDoo LLC
**Designer:** Rune (Stephen Brandon)
**Unity Version:** 6 (6000.3.7f1, URP) -- Sandbox environment
**Project Path:** `E:\Unity\Sandbox` (subproject: `Assets/Sandbox/FearSteez/`)
**Document Version:** 2
**Last Updated:** March 3, 2026

---

## Version History

| Version | Date | Summary |
|---------|------|---------|
| v1 | Dec 25, 2025 | Initial standardized document from concept docs |
| v2 | Mar 3, 2026 | Art style confirmed (3D on 2.5D), player states (Steez/FearSteez), weapon system, cosmic entities/lore, BPM sync goal |

---

## High Concept

**FearSteez** is a 2.5D side-scrolling beat 'em up where you play as a real Atlanta rapper fighting through waves of enemies to reach your concert. An evil rap-hating sorcerer has cursed the city - his minions patrol by day, zombies rise at night. Your fists, your music, and your skills are all that stand between you and the stage.

**Genre:** 2.5D Beat 'Em Up with RPG Elements

**Inspirations:**
- Streets of Rage + Double Dragon (combat feel)
- Blaster Master (RPG progression)
- River City Girls (2.5D movement, shops)
- Scott Pilgrim (music integration, leveling)

**Unique Hooks:**
- Real artist (FearSteez) with real music drives the soundtrack
- Day/night cycle affects enemy types (minions vs zombies)
- Classic beat 'em up combat with modern RPG depth

---

## Core Pillars

| Pillar | Description |
|--------|-------------|
| **Authentic Artist** | FearSteez is a real person with real music - the game celebrates that |
| **Classic Beat 'Em Up** | Streets of Rage meets Double Dragon - accessible, satisfying combat |
| **RPG Depth** | Blaster Master-style progression keeps players invested |
| **Day/Night Duality** | Two distinct enemy rosters create variety - coordinated humans by day, undead swarms at night |
| **Music-Driven** | FearSteez's actual tracks drive the experience; BPM syncs to gameplay rhythm |
| **Dual Identity** | Steez and FearSteez are the same character - the Oni mask transforms power, weapons, and visual style |
| **Co-op** | Phased: single player launch, local co-op v2, online co-op v3. No AI companion, no second character if solo |

---

## Game Flow

### Core Loop

```
APPROACH -> ATTACK -> COMBO -> CROWD CONTROL -> REPEAT
```

1. **Approach:** Navigate 2.5D plane to engage enemies
2. **Attack:** Light and heavy attacks with distinct purposes
3. **Combo:** Chain attacks for bonus damage/effects
4. **Crowd Control:** Manage multiple enemies, use environment
5. **Repeat:** Clear wave, progress, face tougher enemies

### Session Flow

1. Player selects level/zone
2. Navigate through streets fighting waves of enemies
3. Day levels feature sorcerer's minions
4. Night levels feature zombies and undead
5. Gain XP, level up, unlock skills
6. Reach concert venue (final goal)

---

## World / Setting

### Location

**Atlanta, Georgia -- street level.** The game follows FearSteez on foot from **Little Five Points** through **Oakland Cemetery** to **Piedmont Park**, where his concert is being held.

This is a real Atlanta route. The full path is too long to represent literally -- the game picks distinctive landmarks and environments along it. The journey grounds the game in an authentic place and gives the level design a clear geographic spine.

### Level Geography (Draft)

| Zone | Vibe | Day/Night Tie-in | Notes |
|------|------|-----------------|-------|
| **Little Five Points** | Grungy bohemian, record shops, tattoo parlors, vintage | Day -- minions in the streets | Opening level. Familiar territory for FearSteez. Low stakes intro. |
| **Oakland Cemetery** | Historic 1850s cemetery, ornate gates, old mausoleums | Night -- zombies rising from the actual graves | Natural night transition. Undead emerging from a real Atlanta landmark. |
| **Between zones** | Urban streets, storefronts, alleyways | Either | Connector sections. Opportunities for unique Atlanta set dressing. |
| **Piedmont Park** | Open greenspace, festival grounds, concert stage | Climax -- both types converge | Final level. The destination. Concert stage as the win condition backdrop. |

### Tone

Real Atlanta, stylized for action. Not gritty realism -- the sorcerer's curse means the city is visibly wrong. Posters peel in unnatural patterns, streetlights flicker at noon, enemies patrol where they shouldn't be.

---

## Combat System

### Attack Types

| Input | Attack | Purpose |
|-------|--------|---------|
| Light (X/Square) | Jab combo | Fast, safe, combo starter |
| Heavy (Y/Triangle) | Power hit | Launcher, combo ender, armor break |
| Jump + Attack | Air attack | Crowd control, style |
| Special (B/Circle) | Signature move | Costs resource, high damage |
| Grab (near enemy) | Throw/slam | Repositioning, crowd damage |

### Combo Philosophy

**Design Principle:** Easy to start, rewarding to master.

- **Mash-friendly:** Button mashing produces decent results
- **Depth available:** Timing and variety increase damage/style
- **No infinite combos:** Enemies recover after X hits
- **Environmental combos:** Throw enemies into walls, each other

### Damage and Health

| Element | Design |
|---------|--------|
| Health display | TBD - Hearts or HP bar |
| Damage numbers | Yes (RPG feel) |
| Hitstun | Medium duration (combo-friendly but fair) |
| I-frames | On knockdown recovery (prevents stun-lock) |

---

## Player States

### Two Independent Power-Up Axes

The player has two separate power-up sources that combine independently:

| Power-Up | Source | Effect |
|----------|--------|--------|
| **Oni Mask** | The Oni (cosmic guide) | Activates FearSteez state -- more powerful martial arts moves and animations |
| **Robot Woman** | Chrome Robot Woman (cosmic guide) | Upgrades signature weapon -- microphone becomes rope dart |

### State Combinations

| Oni Mask | Robot Woman | Character State | Signature Weapon |
|----------|-------------|----------------|-----------------|
| No | No | Steez | Corded microphone |
| Yes | No | FearSteez | Corded microphone |
| No | Yes | Steez | Rope dart |
| Yes | Yes | FearSteez | Flaming rope dart |

**Key Design Notes:**
- The two axes are independent -- either can be active without the other
- "Flaming rope dart" is the full-power state requiring both active simultaneously
- Both power-ups use the same animation set -- Oni mask changes move power, not animations entirely
- Acquisition/activation method for each: TBD (pickup? charged meter? story-gated?)

---

## Weapon System

### Signature Weapon (Exclusive)

- **Base:** Corded microphone (meteor hammer style) -- not droppable, not usable by enemies
- **Robot Woman upgrade:** Rope dart -- microphone replaced/transformed
- **Both power-ups active:** Flaming rope dart -- the full combined state

### Environmental Weapons (Shared)

Any character -- player or enemy -- can pick up and throw environmental weapons:

| Weapon | Type | Notes |
|--------|------|-------|
| Crowbar | Melee/Thrown | Street classic |
| Baseball bat | Melee/Thrown | Swings and throws |
| Knife | Thrown | Short-range melee, medium throw |
| Vinyl record | Thrown | Disc projectile, music-themed |
| Enemy body | Thrown | Grab and throw into crowd |

### Weapon Philosophy

- Music-themed first -- most of Steez's arsenal references his musician identity
- Environmental weapons keep combat dynamic and enemy-aware
- Enemies picking up weapons creates threat escalation
- The microphone exclusivity reinforces Steez's identity

---

## Day/Night System

### Core Concept

The sorcerer is a cosmic entity -- he cannot enter the world directly. His power manifests differently by time of day:
- **Day:** He uses mind control on humans -- street thugs, magical constructs, hired muscle
- **Night:** He raises the dead -- zombies, undead, monsters from beyond

### Implementation

Level-based with some real-time elements:
- Certain levels are locked to day or night
- Some levels transition mid-level for dramatic effect
- Creates variety and strategic depth

### Enemy Roster

**Day Enemies (Minions):**
| Enemy | Role |
|-------|------|
| Street thugs | Basic melee |
| Magic users | Ranged, shields |
| Bouncers | Heavy, armored |
| Sorcerer's apprentices | Mini-bosses |

**Night Enemies (Undead):**
| Enemy | Role |
|-------|------|
| Walkers | Basic zombie |
| Crawlers | Fast, low to ground |
| Bruisers | Tank zombies |
| Risen | Corrupted former enemies |

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

### Core Systems

| System | Description | Priority |
|--------|-------------|----------|
| **Experience/Levels** | Traditional XP -> Level Up | MVP |
| **Stats** | STR, DEF, SPD, etc. | MVP |
| **Skills** | Unlockable moves and passives | Post-MVP |
| **Equipment** | Gear that affects gameplay | Post-MVP |
| **Currency** | Buy items, upgrades | Post-MVP |

### Stats

| Stat | Effect |
|------|--------|
| **Strength** | Damage dealt |
| **Defense** | Damage reduction |
| **Speed** | Movement and attack speed |
| **Stamina** | Special move resource |
| **Style** | Bonus XP/drops (risk/reward) |

### Skill Tree (Planned)

- **Brawler Branch:** Raw damage, combos, crowd damage
- **Finesse Branch:** Speed, dodges, counters
- **Showman Branch:** Style bonuses, special effects, audience power-ups

---

## Music System

### Vision

FearSteez's actual recorded music drives the game. The artist's tracks are not placeholder -- they are core to the experience. Tracks are not yet delivered; integration will follow when music is received.

### Implementation Approach

| Phase | Approach |
|-------|----------|
| MVP | Jukebox - Full tracks play during levels |
| V1 | Beat-sync - BPM drives gameplay rhythm, attack windows, enemy timing |
| Future | Stem mixing - Layers respond to gameplay state |

### BPM Sync Goal

The game should "breathe" with the music. BPM changes in tracks map to pacing shifts in gameplay. The core idea: because FearSteez is a musician, his fighting style literally moves to the beat. Specifics to be designed once tracks are delivered.

### Music-Gameplay Connections

- Combo meter affects music intensity
- Special moves trigger musical stingers
- Boss fights have unique FearSteez tracks
- Style meter unlocks vocal layers

---

## Visual Style

### Art Direction (CONFIRMED)

**3D characters on a 2.5D side-scrolling plane.** Reference: TMNT Shredder's Revenge, Final Fight 3D mods.

- 3D character models and animations
- Camera locked to a side-scroll plane (with minor depth for movement on the play field)
- URP rendering pipeline

### Visual Feedback Requirements

- **Hit sparks:** Clear impact visualization
- **Screen shake:** Proportional to hit power
- **Freeze frames:** On big hits (2-4 frames)
- **Enemy flash:** Damage indication
- **Health bars:** Floating above enemies

---

## Development Status

### Current Phase: Concept

| Feature | Status |
|---------|--------|
| FearSteez movement | NOT STARTED |
| Basic attack combo | NOT STARTED |
| Day enemy type | NOT STARTED |
| Night enemy type | NOT STARTED |
| Health system | NOT STARTED |
| XP and level up | NOT STARTED |
| Music integration | NOT STARTED |
| Win condition | NOT STARTED |

### MVP Definition

**Goal:** One complete level demonstrating core loop.

**Includes:**
- FearSteez movement (8-directional)
- Basic attack combo (3-hit)
- One day enemy type
- One night enemy type
- Health system
- XP and level up
- One FearSteez track
- Win condition (clear waves)

**Does NOT Include:**
- Full skill tree
- Equipment system
- Multiple levels
- Boss fights
- Story/cutscenes
- Full polish

---

## Development Phases

### Phase 1: Foundation
- Project setup (Unity 6, GitHub)
- Player movement (2.5D navigation)
- Basic attack (single hit)
- One enemy type (stand and get hit)
- Placeholder art

### Phase 2: Combat Core
- Combo system (3-hit chain)
- Enemy AI (approach, attack, react)
- Health and damage
- Basic HUD

### Phase 3: Progression
- XP and leveling
- Stat increases on level up
- Day/night enemy split
- Music integration (jukebox)

### Phase 4: Polish and Content
- Multiple enemy types
- Level design
- Visual feedback (Feel)
- Audio polish
- Boss fight

---

## Reference Games

| Game | What to Study |
|------|---------------|
| **Streets of Rage 4** | Modern beat 'em up combat, combo system, visual feedback |
| **Double Dragon Neon** | Humor, style, RPG elements, co-op |
| **Blaster Master Zero** | RPG progression in action game |
| **River City Girls** | 2.5D movement, shops, RPG mechanics |
| **Scott Pilgrim** | Music integration, pixel art style, leveling |

---

## Characters and Lore

### Player Characters

**Steez / FearSteez (Player 1)** -- A real Atlanta rapper/singer on his way to his concert. Uses music as his weapon literally -- a corded microphone as a meteor hammer, vinyl records as throwing weapons. When he dons the Oni mask he becomes FearSteez: more powerful, visually transformed, wielding a flaming rope dart.

**DJ (Player 2, co-op only)** -- Same powers, same move set, same weapon system as Steez. Visually distinct -- different hairstyle or color scheme, placeholder name "DJ". No unique mechanics. If no second player is present, DJ does not appear -- no AI companion. Exact visual design TBD.

### Cosmic Guides (Cannot Enter Game Directly)

| Guide | Description | Role |
|-------|-------------|------|
| **The Oni** | Ancient cosmic entity of martial arts and spirit power | Provides the Oni mask power-up. Activates FearSteez state -- enhanced martial arts moves and power. |
| **Chrome Robot Woman** | Sorayama-style chrome female figure -- sleek, cosmic, otherworldly. Visual: mirror-finish chrome, feminine form, pink swimsuit, futuristic. | Provides the weapon upgrade power-up. Transforms the corded microphone into a rope dart. When combined with the Oni mask, produces the flaming rope dart. |

Both guides operate in the main combat loop. Neither enters the fight directly -- they empower Steez through their respective power-up objects. How they appear in-game (visions, overlays, voice, etc.) is TBD.

### Main Antagonist

**The Sorcerer/Necromancer** -- A cosmic entity and the true villain. Cannot enter the world directly (mirrors the guides in this limitation). Communicates his hatred through proxy:
- By day: mind-controls humans (thugs, muscle, magical constructs)
- By night: raises the dead (zombies, monsters, corrupted creatures)

**Motive (tentative):** He hates FearSteez's music and cannot tolerate it reaching an audience. Whether this is personal, cultural, or cosmic is TBD.

---

## Open Questions

| Question | Priority |
|----------|----------|
| Vehicle level type? | MEDIUM | Top-down (GTA1 style) or side-scroll vehicle (Blaster Master style) as stage transitions -- or both. Independent of Chrome Robot Woman (her role is in main combat loop). |
| Co-op support? | RESOLVED | Phased -- v1: single player. v2: local co-op. v3: online co-op. Player 2 is DJ -- same powers/weapons as Steez, different visual. No AI companion. Networking (v3): Photon Fusion 2. |
| How many levels? | HIGH | Route: Little Five Points → Oakland Cemetery → Piedmont Park. Full path is too long to represent literally -- pick distinctive landmarks. Zone count and connector breakpoints TBD. |
| Boss design approach? | MEDIUM | |
| Power-up activation? | MEDIUM | How are Oni mask and Robot Woman power-ups acquired/activated? Pickup in level? Charged meter? Story-gated? Same method for both or different? |
| Guides in-game presence? | LOW | How do the Oni and Chrome Robot Woman appear? Visions, voice, UI overlay, brief apparition? |
| Sorcerer motive depth? | LOW | Hates his music -- how much narrative weight? |
| Mobile port? | LOW | |

---

**End of Game Design Document**
