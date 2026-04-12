# Blood Miner -- Game Design Document

**Project:** Blood Miner
**Genre:** Idle/Incremental (Body Processing Factory)
**Platform:** Mobile-first (iOS/Android), portrait orientation
**Players:** Single player
**Version:** 2.0 (major pivot from IMT three-bottleneck to row-based factory)
**Last Updated:** April 11, 2026

---

## 1. High Concept

You are the Reaper. Bodies pile up faster than anyone can process them. Your job: chop them, extract the souls, descend deeper. There are always more bodies.

Bodies are gathered from above, dropped through pipes into chopping rows, and the reaper (you) hacks them up. Blood fills the floor. Tools get upgraded. Minions take over old rows. You descend. The shaft keeps going down.

**The name:** "Blood Miner" (you're a nobody) + "Soul Miner" (you mine souls). Title screen: the 'e' in Miner flickers between 'e' and 'o'.

**The tone:** Sickeningly cute bodies + visceral chopping + clean soul extraction. Chubby cats with big eyes get hacked apart. Blood splatters. The contrast is the brand. No "why" -- it just happens. The afterlife is a factory and you run the line.

---

## 2. Core Loop

```
GATHERERS (top) bring bodies to the funnel
    --> bodies flow down PIPES to the reaper's row
    --> REAPER (player) chops bodies manually
    --> MINIONS on the row auto-chop when purchased
    --> BLOOD BAR fills on the row's floor
    --> TOOL UPGRADE button becomes available
    --> press it (or let the auto-button minion do it)
    --> BUY MORE OUTLETS (adds a minion each) until row is fully built
    --> T-CONNECTOR AUTO-BUILDS, next row unlocks
    --> DESCEND (one-way) to the new row
    --> repeat forever, going deeper
```

**Session types:**
- **Active (30s-5min):** Click to chop alongside minions on the current row, buy upgrades, press tool upgrade buttons on rows without auto-minions
- **Idle (hours):** All rows with minions self-sustain. Blood bars fill, auto-buttons press upgrades (if purchased). Souls accumulate.
- **Return:** Big offline earnings collect, then push deeper.

---

## 3. Layout

Portrait orientation. Side-view cross-section of a vertical body processing shaft.

```
[SURFACE PLATFORM]       <- gatherer spawn/return, body funnel
       |
       v  (pipes zig-zag down)
       |
[ROW 0 - Reaper starts here, 1-4 outlets, chopping floor, blood bar]
       |
       v
[ROW 1 - unlocks when Row 0 is fully built]
       |
       v
[ROW 2, 3, ..., N]
```

**Camera:**
- Portrait 9:16+
- Player scrolls vertically to see any row
- Reaper stays locked to its current row when scrolling (camera decoupled from reaper)

---

## 4. Gatherers (Global)

Minions on the surface platform who fetch bodies and feed the funnel.

| Property | Value |
|----------|-------|
| Starting count | 1 |
| Max count | 10 (hard cap) |
| Upgrade | Speed tier (1-5), repeatable purchase |
| Behavior | Walk off-screen, return with a body, dump in funnel |

**Speed tiers gate carry capacity:**
- Tier 1: cats only
- Tier 2: + dogs
- Tier 3: + pigs
- Tier 4: + sheep / rabbit / chicken
- Tier 5: + cows

Higher speed = faster round trip AND they can carry heavier bodies. One upgrade path, not separate "speed" and "strength" purchases.

**Visual:** Each gatherer is a small figure. They walk off the right edge, screen-wipe a second, walk back dragging a body (sized to body type). Drop it in the funnel. Walk off again.

---

## 5. The Pipe Network

Bodies travel from the funnel through pipes down to the reaper's row.

- **Funnel** at the top, always accepts bodies from gatherers
- **Main pipe** carries bodies downward
- **T-connectors** split the main pipe to feed each row
- **Row outlets** are where bodies drop onto the chopping floor
- Each row starts with **1 outlet**, can be upgraded to **4 outlets** (3 upgrade purchases)
- When a row reaches 4 outlets AND 4 minions, the T-connector to the next row **auto-builds** and the next row unlocks

Bodies only flow down. No backflow, no re-routing. Simple and visible.

---

## 6. The Row (Gameplay Unit)

Each row is a horizontal chopping platform. The whole game happens on rows.

### 6.1 Row Components

```
[PIPE OUTLETS]  <- 1 to 4, bodies drop here
     |
     v
[REAPER or MINIONS chop]  <- one worker per outlet
     |
     v
[BLOOD BAR]  <- floor fills with blood as bodies are chopped
     |
[TOOL UPGRADE BUTTON]  <- appears when blood bar is full
```

### 6.2 Row Lifecycle

1. **Row opens** — 1 outlet active. Reaper alone. Player clicks to chop manually.
2. **Outlet 2 upgrade purchased** — adds outlet + 1 auto-chop minion (minion handles that outlet)
3. **Outlet 3 upgrade purchased** — adds outlet + 1 minion
4. **Outlet 4 upgrade purchased** — adds outlet + 1 minion. Row is now "fully built."
5. **T-connector auto-builds** — visually extends pipe to next row, next row unlocks. Reaper stays on current row.
6. **Auto-button minion** purchase becomes available (expensive, one-time per row). Presses the tool upgrade button automatically when it's ready.
7. **Tool upgrade button** — appears on this row whenever the blood bar is full. Costs souls. Resets blood bar, raises the row's tool tier, boosts soul yield per chop on this row.
8. **Descend button** appears after the T-connector builds. Player clicks when ready (manual gate). Reaper walks down to the next row. **One-way.**

### 6.3 While the Reaper Is on a Row

- Player can click to chop bodies on the reaper's outlet manually (active play bonus)
- Combo multiplier builds on consecutive player taps
- Minions on other outlets of this row auto-chop
- Blood bar fills from all chops (reaper + minions)

### 6.4 When the Reaper Leaves a Row

- All 4 minions stay and self-sustain
- Blood bar keeps filling, tool upgrades keep being available
- Auto-button minion (if purchased) keeps pressing upgrades
- If no auto-button minion: player must scroll up and manually press tool upgrade when available

---

## 7. Blood Bar

Each row has its own blood bar -- the row's "floor."

- Fills as bodies are chopped on that row (from reaper + any minions)
- When full, the **Tool Upgrade button** for that row becomes available
- Pressing the button: spend souls, bar resets, row's tool tier +1
- **Tool tier** is the soul multiplier for every chop on that row (both reaper and minions)
- Rows level up tool tier independently -- Row 0 tier 15, Row 1 tier 8, etc.
- There is no hard cap on tool tier, but costs scale exponentially so you'll always be chasing it

---

## 8. Souls (Currency)

### 8.1 Formula

```
souls_per_chop =
    base_yield
    * body_type_value
    * row_depth_multiplier
    * row_tool_tier
    * combo_multiplier (reaper only, when actively clicking)
```

### 8.2 Body Type Values

| Body | Value | Unlocks on Row |
|------|-------|----------------|
| Cat | 1 | 1 |
| Dog | 1.5 | 1 |
| Pig | 3 | 3 |
| Sheep | 4 | 5 |
| Rabbit | 2 | 7 |
| Chicken | 2 | 7 |
| Cow | 10 | 9 |
| **Coffin** (rare, any row) | Special bonus | Any row |

New body types appear in the gatherer pool as the reaper reaches each unlock row. Each row's pipe pool includes all currently unlocked body types.

### 8.3 Coffins

Occasional rare body drop at any depth. Chopping a coffin grants a **bonus reward** -- TBD: large soul bundle OR instant blood bar fill (pick one during tuning). Designed to create "oh!" moments and break the rhythm.

### 8.4 Row Depth Multiplier

Deeper rows are worth more. Exact curve TBD, but target: row N is roughly `1 + 0.5N` multiplier (linear) or `1.2^N` (exponential). Pick during balance.

---

## 9. Upgrade Summary

### 9.1 Per-Row Upgrades

| Upgrade | Type | Count | Effect |
|---------|------|-------|--------|
| Outlet + Minion | One-time | 3 per row | Adds pipe outlet + auto-chop minion |
| Tool Tier | Repeatable | Unlimited | Soul multiplier for this row |
| Auto-Button Minion | One-time | 1 per row | Auto-presses tool upgrade button |

### 9.2 Global Upgrades

| Upgrade | Type | Count | Effect |
|---------|------|-------|--------|
| Gatherer Count | One-time | 9 (1 -> 10) | Adds a gatherer on the surface |
| Gatherer Speed/Tier | Repeatable | 5 tiers | Faster round trips + bigger body carry capacity |

### 9.3 Descend (Row Progression Gate)

- Appears after a row is fully built (4 outlets + T-connector built)
- Manual click, one-way
- Player can delay to chop alongside minions on the current row for combo bonuses

---

## 10. The Reaper (Player Avatar)

- Single reaper, no rank progression visuals yet (visual evolution deferred -- TBD)
- Starts on Row 0 when a new save begins
- Descends manually via the Descend button
- **One-way down** -- reaper never moves back up
- Player can scroll the camera freely without moving the reaper
- On the reaper's current row, player taps bodies to chop manually (stacks with minions, builds combo)
- On rows without an auto-button minion, player scrolls up to press tool upgrade buttons when ready

---

## 11. Currencies

| Currency | Source | Spent On |
|----------|--------|----------|
| **Souls** (primary) | Chopping bodies | Outlet upgrades, tool upgrades, minions, gatherers, auto-buttons |
| **Dark Gems** (premium, future) | Rank-ups, ads, IAP | Instant upgrades, cosmetics |
| **Prestige Essence** (future) | Ascension reset | Permanent multipliers |

Sprint 1/2 scope: Souls only. Dark Gems and Prestige deferred.

---

## 12. Audio (Unchanged)

- **Chop:** Wet crunch + chime simultaneously. Crunch sells the violence, chime sells the reward.
- **Body-specific sounds:** Squelch, splat, feather poof, "bawk," cow BOOM.
- **Soul release:** Ethereal whoosh when a body is fully processed.
- **Combo:** Sounds pitch up with each reaper tap, building to crescendo.
- **Blood bar full / tool upgrade available:** Distinct "ready" chime.
- **Gatherers:** Footsteps, body drop thud.
- **Ambient:** Low hum, distant echoes. Deeper rows = lower pitch.

---

## 13. Visual Presentation

- **Portrait orientation**, 9:16+
- **Side-view cross-section** of a vertical pipe-and-row factory
- **Vertical scroll** to look at any row
- **3D models** (Cute Pet bodies, KayKit props for shaft geometry)
- **Bright cute bodies** POP against dark shaft background
- **Blood** is the color/progression indicator -- each row's floor darkens as it fills
- **Pipes** are visually prominent -- the player should always know where bodies are coming from
- **UI:** Dark theme with glowing accents. "Corporate underworld memo" aesthetic.

---

## 14. What Was Removed in v2.0

Keeping this list so I remember what we cut and why:

- **Rank progression (ranks 0-7)** -- removed. Descent itself is the progression. Rank titles may return later as cosmetic flavor.
- **Zones (Shallow Graves, Cemetery, Catacombs...)** -- removed. The shaft is one continuous descent. Visual theming changes gradually with depth instead of discrete zones.
- **Elevator** -- removed. Replaced with pipe network (bodies flow down, not souls flowing up).
- **Warehouse** -- removed. Souls are credited directly to the player on chop. No storage, no overflow.
- **IMT three-bottleneck structure** -- removed entirely. Each row is now a self-contained mini-factory.
- **Tap Power / Multi-tap / Combo-as-upgrade / Critical Tap** -- simplified. Combo is automatic when actively chopping. No separate tap upgrades.
- **Mythology / fiction framing (reaping separates soul from body)** -- deliberately dropped. "Forget the why, it just happens."

Rank progression, zones, and the mythology framing may return in later sprints if there's space. For now, the loop is what matters.

---

## 15. Prototype Scope (Sprint 2 Rebuild)

Replaces the Sprint 1 three-bottleneck scope entirely.

**In scope:**
- 1 shaft (single continuous descent)
- 5-10 rows (enough to prove the loop + depth multiplier feel)
- Gatherer system: 1 gatherer, no speed upgrade yet
- Single body type to start (cat), add dog at row 2 for unlock testing
- Per-row systems: outlets, minions, blood bar, tool upgrade, auto-button minion, T-connector
- Manual descent
- Save/load (reuse existing ES3 system, adapt to new data shape)
- Basic VFX: chop effect, soul wisp, floating number pop
- UI: currency header, per-row upgrade panels (contextual, only visible when scrolled to that row)

**Out of scope (defer):**
- Coffins (add after base loop feels good)
- More body types beyond cat/dog
- Visual reaper rank progression
- Dark Gems, Prestige, monetization
- Offline earnings (add once the active loop is tuned)
- Audio beyond placeholder

**Success criteria:**
1. Can you build Row 0 from scratch to fully-upgraded in 1-3 minutes of active play?
2. Does watching minions chop feel satisfying, or is it boring?
3. When you descend to Row 1, does it feel like progress?
4. Does scrolling up to an old row to press tool upgrade buttons feel like meaningful babysitting or annoying chore?
5. Is the reaper-on-current-row active bonus worth clicking, or is it dominated by auto-chop?

---

## 16. Open Design Questions

- **Tool upgrade cost curve:** steep enough to create tension with outlet/gatherer purchases, not so steep that the button is rarely affordable
- **Blood bar fill rate:** should it fill in ~5-15s once row is fully built? Too fast = button spam, too slow = dead rows
- **Coffin payoff:** soul bundle (one-shot bonus) or blood bar instant-fill (row ready to upgrade right now)?
- **Descent animation:** does the reaper walk/fall down the pipe to the next row, or just teleport with a visual flourish?
- **Deep-row fatigue:** at row 50, is the player still invested or are they just watching numbers? Need variation triggers (new body types, visual shifts, rare events)
- **Tool upgrade button visual:** where does it live? Floating UI above the row? On the blood bar itself?
- **Auto-button minion:** is it visibly a minion standing next to the button, or an abstract automation toggle?

---

**End of Document**
