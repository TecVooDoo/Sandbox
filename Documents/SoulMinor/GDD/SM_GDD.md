# Soul Minor -- Game Design Document

**Project:** Soul Minor
**Genre:** Idle/Incremental Tycoon
**Platform:** Mobile-first (iOS/Android), portrait orientation
**Players:** Single player
**Version:** 1.0
**Last Updated:** April 3, 2026

---

## 1. High Concept

You died. Nothing special. Now you're a Soul Minor -- the lowest rank in the underworld's soul-harvesting bureaucracy. The afterlife is backed up. Bodies are piling up. Someone has to mine the souls out of them with a scythe. That someone is you.

Tap to scythe adorable body piles. Watch the blood fly and the souls rise. Automate. Rank up. Become the Grim Reaper.

**The name:** "Soul Minor" (you're a nobody) + "Soul Miner" (you mine souls). Title screen: the 'e' in Miner flickers between 'e' and 'o'.

**The tone:** As bloody gory as it is sickeningly cute. Happy Tree Friends meets Idle Miner Tycoon. Chubby cats with big eyes, stacked in adorable piles. You hack them apart with a scythe. Blood splatters across pastel fur. Beautiful ethereal soul wisps rise from the carnage. The contrast IS the brand.

---

## 2. Reference Game

**Idle Miner Tycoon (Kolibri Games)** -- 100M+ downloads. Vertical shaft structure with three balanced bottlenecks (mine, elevator, warehouse). Proven idle loop. Soul Minor uses the same structural formula with a unique skin.

---

## 3. Core Loop

```
TAP to scythe a body pile
    --> GORE BURST (blood, fur, limbs fly)
    --> SOUL WISP rises beautifully from the carnage
    --> CURRENCY earned
    --> SPEND on upgrades (harvest speed, elevator, warehouse, automation)
    --> RANK UP when lifetime threshold reached
    --> NEW ZONE unlocks (deeper, harder, richer, gorier)
    --> OFFLINE PROGRESS accumulates while away
    --> RETURN --> collect offline earnings --> repeat
```

**Session types:**
- **Active (30s-5min):** Tap to harvest, spend currency, trigger abilities
- **Idle (hours):** Souls accumulate passively via minions
- **Return:** Big satisfying collect moment, push progress

---

## 4. The Shaft (IMT Structure)

Portrait orientation. Side-view cross-section of a vertical shaft into the underworld.

### 4.1 Three Bottlenecks

| System | What It Does | Upgrade Focus |
|--------|-------------|--------------|
| **Mine Levels** | Body piles. Tap to harvest souls. | Soul yield, harvest speed, pile size |
| **Elevator** | Bone-and-chain conveyor. Moves souls from levels to surface. | Speed, capacity, number of cars |
| **Warehouse** | Surface collection point. Stores souls until collected. | Storage cap, auto-collect rate |

If any one system is underleveled, the pipeline chokes. Balance investment across all three.

### 4.2 Mine Levels (Body Piles)

Each level is a horizontal area with a cute body pile:
- **Tap** --> scythe swings --> gore burst --> soul wisp rises
- Each tap has: impact flash, screen shake, wet crunch + chime audio, blood spray, body-type particles, then the ethereal soul wisp
- **Assign minions** for auto-harvest (idle play)
- **Upgrade** to increase yield, speed, pile size
- **Bodies respawn** over time -- "more keep arriving"

### 4.3 Elevator

Bone-and-chain elevator on the left side:
- Souls queue at each level waiting for pickup
- Elevator capacity limits throughput
- Upgrade: speed, capacity, car count
- Visual: ghostly wisps riding a creaky bone elevator upward

### 4.4 Warehouse

Surface collection point:
- Warehouse has max capacity -- overflow is lost
- Tap to collect (or auto-collect with upgrade)
- Collected souls become spendable currency
- Upgrade: storage size, auto-collect rate

---

## 5. The Harvest Moment (Core Feel)

This is THE moment. Every tap must feel incredible:

1. **Tap** -- character swings scythe
2. **Impact** -- screen flash, slight shake, crunchy wet sound
3. **Gore burst** -- blood spray, body-type particles (fur/feathers/wool), limb physics
4. **Soul release** -- beautiful ethereal wisp rises from the mess, glowing, peaceful
5. **Number pop** -- soul value floats up ("+5", "+50", etc.)

The **violence-to-beauty transition** in steps 3-->4 is the emotional hook. Something awful produces something beautiful. That one-second arc is the entire game feel.

---

## 6. Bodies

### 6.1 Design Principle

The cuter the body, the gorier the harvest, the more satisfying the reward. Maximize the contrast at every level.

### 6.2 Body Types

| Type | Look | Gore Signature | Sound |
|------|------|---------------|-------|
| **Cat** | Curled up, big closed eyes, peaceful smile | Fur puffs + red mist, tiny paw flies off | Soft splat |
| **Dog** | On back, tongue out, belly up | Big wet splatter, tail spins away | Heavy splat |
| **Pig** | Perfectly round, content smile | Massive blood burst, snout bounces | Deep squelch |
| **Sheep** | Fluffy wool cloud, eyes closed | Wool explodes like blood-soaked cotton ball | Poof + splat |
| **Rabbit** | Tiny ball, impossibly cute | Small intense red spray, ears tumble | Quick snap |
| **Chicken** | Legs up, cartoonishly stiff | Feather explosion + red confetti + comedic "bawk" | Bawk + pop |
| **Cow** | Large, takes up pile space | Biggest splatter in the game + screen shake | BOOM |

### 6.3 Body Piles

Each mine level has 5-15 bodies:
- Random mix from zone's type pool
- Stacked, overlapping, some upside down -- cute and undisturbed before harvest
- Faint soul glow where souls remain
- Post-harvest: pile gets messier (blood pools, scattered parts, grey-out)
- Respawn clean over time

### 6.4 Soul Wisps

Harvested souls rise as glowing wisps:
- White = common, Blue = uncommon, Gold = rare
- Float to elevator shaft with particle trail
- Clean and ethereal -- stark contrast to the gore they emerged from

---

## 7. Zones

Each zone is a separate shaft with its own levels, body types, and visual theme.

| Zone | Rank | Theme | Body Pool | Flavor Text |
|------|------|-------|-----------|-------------|
| **Shallow Graves** | 0 | Dirt, wooden crosses, wilting flowers | Cat, Dog | "Fresh arrivals. Still warm." |
| **The Cemetery** | 1 | Iron fences, crypts, dead trees | Cat, Dog, Rabbit | "Organized death. How quaint." |
| **Catacombs** | 2 | Stone walls, candles, cobwebs | Cat, Pig, Sheep | "They've been here a while." |
| **Purgatory** | 3 | Fog, floating platforms, grey | All types tangled | "Nobody leaves. Nobody arrives." |
| **The Bone Yard** | 4 | Skeletal structures, bone furniture | Skeletal variants | "Even the dead have a junkyard." |
| **The Abyss** | 5+ | Infinite darkness, glowing soul-light | Prestige variants | "You've gone too deep." |

---

## 8. Rank Progression

Ranks = lifetime souls harvested (spending doesn't reduce rank progress).

| Rank | Title | Promotion Letter | Unlock |
|------|-------|-----------------|--------|
| 0 | Soul Minor | "Welcome to the afterlife. Here's a shovel. Don't ask questions." | Tutorial, Shallow Graves |
| 1 | Grave Attendant | "You've shown adequate competence. Don't let it go to your head." | Cemetery, first minion |
| 2 | Crypt Warden | "Congratulations. You now supervise dead things in a slightly nicer room." | Catacombs, elevator upgrades |
| 3 | Soul Foreman | "Management is impressed. Well, 'impressed' is strong. 'Aware' is closer." | Purgatory, manager automation |
| 4 | Death's Bookkeeper | "Your throughput numbers are... acceptable. Here's a desk." | Bone Yard, prestige preview |
| 5 | Harbinger | "The living have started to notice you. That's either very good or very bad." | The Abyss, prestige system |
| 6 | Pale Rider | "You've been assigned a horse. It's also dead. You'll get along." | Mount speed bonus, cosmetics |
| 7 | Grim Reaper | "Welcome to Management." | All zones, reap mechanic, title screen changes |

---

## 9. Your Character

Visual progression through ranks:
- **Rank 0-2:** Tiny ghost with comically oversized scythe
- **Rank 3-4:** Skeletal figure, scythe fits now
- **Rank 5-6:** Hooded figure, dark robes, scythe glows
- **Rank 7:** Full Grim Reaper. Blood drips from the blade.

Character appears at whatever level you're tapping. Does a harvest swing animation. Gets progressively bloodier as you harvest (resets on zone change).

---

## 10. Upgrade Systems

### 10.1 Tap Upgrades (Active Play)
- Tap Power: souls per tap
- Multi-tap: harvest radius
- Combo Multiplier: chain taps for increasing bonus
- Critical Tap: % chance for 10x value

### 10.2 Automation (Idle Play)
- Minion Count: auto-harvesters per level
- Minion Speed: harvest rate
- Offline Multiplier: % of active earnings while away
- Soul Magnet: auto-collect nearby surface souls

### 10.3 Infrastructure
- Elevator Speed, Capacity, Car Count
- Warehouse Size, Auto-Collect Rate

### 10.4 Prestige (Permanent)
- Starting rank bonus
- Base multiplier per prestige
- Earlier automation unlock
- Cosmetic unlocks

---

## 11. Currencies

| Currency | Source | Spent On |
|----------|--------|----------|
| **Souls** (primary) | Harvesting | Level/elevator/warehouse upgrades, minions |
| **Dark Gems** (premium) | Rank-ups, ads, IAP | Managers, instant upgrades, cosmetics |
| **Prestige Essence** | Ascension reset | Permanent multipliers |

---

## 12. Prestige System

Rank 5+: "Ascend" -- reset all progress for Prestige Essence.
- Permanent multipliers (harvest speed, soul value, offline rate)
- Each ascension faster than last (multipliers compound)
- Prestige count as badge
- Visual changes: shaft darker/more ornate per prestige
- Endgame: optimize ascension speed

---

## 13. Monetization

| Method | Implementation |
|--------|---------------|
| Rewarded Ads | 2x offline earnings, temporary boost, free Dark Gems |
| Interstitial Ads | Between zone transitions or rank-ups |
| IAP: Dark Gem Packs | Premium currency bundles |
| IAP: Starter Pack | One-time discounted bundle |
| IAP: Auto-Collect Pass | Permanent 2x offline earnings |
| IAP: Cosmetics | Reaper skins, scythe styles |
| No Pay-to-Win | All content reachable F2P |

---

## 14. Audio

- **Harvest:** Wet crunch + satisfying chime simultaneously. Crunch sells violence, chime sells reward.
- **Gore:** Squelch, splat, rip -- varies by body type. Chickens get comedic "bawk."
- **Soul release:** Ethereal whoosh/shimmer. Beautiful, clean, contrasts the gore.
- **Combo:** Sounds pitch up with each tap, building to crescendo.
- **Elevator:** Creaky chain, continuous when running.
- **Rank-up:** Dramatic fanfare, screen flash.
- **Idle return:** Big "cha-ching" collection.
- **Ambient:** Low hum, distant echoes. Deeper zones = lower pitch.

---

## 15. Visual Presentation

- **Portrait orientation**, 9:16+
- **Side-view cross-section** of vertical shaft
- **Vertical scroll** to see deeper levels
- **3D models in fixed camera diorama** (Cute Pet bodies, Assembly Kit characters, KayKit Halloween props)
- **Dark background**, bright cute bodies POP
- **Soul wisps** are the visual focus -- glowing, ethereal
- **UI:** Dark theme with glowing accents. "Corporate underworld memo" aesthetic.

---

## 16. Backstory (Light Touch)

Delivered through:
1. **Promotion letters** -- 2-3 sentences per rank-up from "Management." Darkly funny, bureaucratic.
2. **Zone flavor text** -- one-liner on entering each zone.
3. **Loading tips** -- underworld workplace safety ("Souls are non-refundable", "Please do not fraternize with the bodies").
4. **Your tombstone** -- title screen shows your tombstone. Blank at Rank 0. Adds titles. At Rank 7: "GRIM REAPER" and it cracks.

No cutscenes. No dialogue. The humor speaks for itself.

---

## 17. Prototype Scope (DO NOT EXPAND YET)

- 1 zone (Shallow Graves)
- 3 mine levels
- Core tap loop + gore VFX
- Elevator + warehouse (three bottlenecks)
- Save/load
- 1 upgrade per bottleneck
- 1 minion tier
- No monetization, no prestige, no multiple zones
- **Prove the feel.** Does tapping bodies feel incredible? Does the cute+gore contrast land?

---

**End of Document**
