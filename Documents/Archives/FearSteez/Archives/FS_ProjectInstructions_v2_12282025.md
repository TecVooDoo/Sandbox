# FearSteez - Project Instructions

**Project:** FearSteez
**Developer:** TecVooDoo LLC
**Designer:** Rune (Stephen Brandon)
**Unity Version:** 6.2 (Target)
**Project Path:** E:\TecVooDoo\Projects\Games\2 Planning\FearSteez
**Document Version:** 2
**Last Updated:** December 28, 2025

---

## Shared Documentation

**This project follows TecVooDoo standards. Review these documents:**

| Document | Location | Purpose |
|----------|----------|---------|
| Core Protocols | `E:\TecVooDoo\Projects\Documents\CORE_DevelopmentProtocols.md` | Universal development rules |
| Unity Standards | `E:\TecVooDoo\Projects\Documents\Type\TYPE_Unity.md` | Unity-specific patterns and tools |

---

## Project Paths

**Planning Location:** `E:\TecVooDoo\Projects\Games\2 Planning\FearSteez`

**When development begins:** `E:\Unity\FearSteez`

---

## Project Documents

| Document | Purpose |
|----------|---------|
| FS_GDD | Game design and mechanics |
| FS_Architecture | Tech stack, systems, code structure |
| FS_DesignDecisions | History, lessons learned, decisions |
| FS_ProjectInstructions | Development protocols (this document) |

**Naming Convention:** `FS_DocumentName_v#_MMDDYYYY.md`

All four documents share the same version number. Increment all when any document is updated.

---

## Project Overview

**FearSteez** is a 2.5D side-scrolling beat 'em up inspired by Streets of Rage and Double Dragon, combined with RPG progression elements.

### Core Concept

- **Genre:** 2.5D Beat 'Em Up with RPG Elements
- **Inspiration:** Streets of Rage + Double Dragon + Blaster Master
- **Unique Hook:** Real artist's music drives the soundtrack; day/night cycle affects enemy types
- **Day Enemies:** Sorcerer's minions (human/magical)
- **Night Enemies:** Zombies and undead

---

## Hardware Constraints

**Development Machine (NitroDad Laptop):**
- Intel i5-8300H, 12 GB RAM, 4 GB GPU

**Implications:**
- Object pooling essential for enemy waves
- Keep max simultaneous enemies reasonable (10-15)
- Profile particle effects early
- Test day/night transition performance

---

## Development Status

### Current Phase: Concept/Planning

| Item | Status |
|------|--------|
| Core concept | DEFINED |
| GDD | COMPLETE |
| Architecture plan | COMPLETE |
| Unity project | NOT STARTED |
| Prototype | NOT STARTED |

---

## Scope Control

**This is a CONCEPT-STAGE project.**

- Focus on core loop first: Move, punch, enemies react
- Day/night system can be simple toggle initially
- RPG elements can start minimal (XP and level only)
- Music integration is priority but can use placeholder tracks
- One enemy type per category (day/night) for MVP

---

## Project-Specific Notes

### Beat 'Em Up Performance

- Pool aggressively for enemies, projectiles, VFX
- Beat 'em ups can have many on-screen enemies
- Profile early with full enemy waves

### SOLID for Combat

- All enemies implement IEnemy
- All attacks implement IAttack
- ICombatant, IDamageable, IInteractable interfaces

---

## Known Issues / TODO for Next Session

- Create Unity project at E:\Unity\FearSteez when ready
- Prototype core combat loop
- Define enemy pool sizes based on hardware testing

---

**End of Project Instructions**

Review CORE_DevelopmentProtocols.md and TYPE_Unity.md for full development standards.
