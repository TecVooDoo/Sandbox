# FearSteez - Project Instructions

**Project:** FearSteez
**Developer:** TecVooDoo LLC
**Designer:** Rune (Stephen Brandon)
**Unity Version:** 6.2 (Target)
**Project Path:** E:\TecVooDoo\Projects\Games\2 Planning\FearSteez
**Document Version:** 1
**Last Updated:** December 25, 2025

---

## Version History

| Version | Date | Summary |
|---------|------|---------|
| v1 | Dec 25, 2025 | Initial standardized document from concept docs |

---

## IMPORTANT: Project Path

**The project is located at:** `E:\TecVooDoo\Projects\Games\2 Planning\FearSteez`

This is a **Planning** stage project. When development begins, Unity project will be at: `E:\Unity\FearSteez`

---

## Project Overview

**FearSteez** is a 2.5D side-scrolling beat 'em up inspired by Streets of Rage and Double Dragon, combined with RPG progression elements reminiscent of Blaster Master. Players control FearSteez (a real Atlanta-based rapper/singer) fighting through city streets to reach his concert while an evil rap-hating sorcerer sends waves of minions and zombies to stop him.

### Core Concept

- **Genre:** 2.5D Beat 'Em Up with RPG Elements
- **Inspiration:** Streets of Rage + Double Dragon + Blaster Master
- **Unique Hook:** Real artist's music drives the soundtrack; day/night cycle affects enemy types
- **Day Enemies:** Sorcerer's minions (human/magical)
- **Night Enemies:** Zombies and undead

---

## Critical Development Protocols

### NEVER Assume Names Exist

**CRITICAL: Verify before referencing**

- NEVER assume file names, method names, or class names exist
- ALWAYS read/search for the actual names in the codebase first
- Incorrect assumptions waste context and force complete rewrites

### Step-by-Step Verification Protocol

**CRITICAL: Never rush ahead with multiple steps**

- Provide ONE step at a time
- Wait for user confirmation via text OR screenshot before proceeding
- User will verify each step is complete before moving forward
- If a step fails, troubleshoot that specific step before continuing
- Assume nothing - verify everything

### Documentation Research Protocol

**CRITICAL: Use current documentation**

- ALWAYS fetch the most up-to-date documentation for Unity and packages
- User prefers waiting for accurate information over redoing work later
- Do not rely on potentially outdated knowledge - verify current APIs
- This applies to Unity 6.2, Input System, URP, etc.

---

## File Conventions

### Encoding Rule

**CRITICAL: ASCII Only**

- All scripts and text files MUST use ASCII encoding
- Do NOT use UTF-8 or other encodings
- Avoid special characters, smart quotes, em-dashes
- Use standard apostrophes (') not curly quotes
- Use regular hyphens (-) not em-dashes

### Core Document Naming Convention

**Format:** `FS_DocumentName_v#_MMDDYYYY.md`

**Rules:**
- All four core documents share the SAME version number
- Increment version for ALL documents when ANY document is updated
- If a document has no changes, update the filename only
- Move old versions to `Documents/Archives/` folder

**Core Documents:**
- `FS_ProjectInstructions_v#_MMDDYYYY.md`
- `FS_GDD_v#_MMDDYYYY.md`
- `FS_Architecture_v#_MMDDYYYY.md`
- `FS_DesignDecisions_v#_MMDDYYYY.md`

---

## Code Style Preferences

### Explicit over Implicit

- **NO `var` keyword** - Always use explicit type declarations
- Clear, readable code always wins over clever code
- Consistent naming (PascalCase for public, camelCase for private)
- Avoid God classes/managers - keep classes focused

### Code Editing Preference

**For manual copy/paste (when providing code to user):**
- Provide COMPLETE file replacements
- Easier than hunting for specific lines
- Reduces errors from partial edits

**For MCP direct edits (Claude editing via tools):**
- Use `script_apply_edits` for method-level changes
- Use `apply_text_edits` for precise line/column edits
- Use `validate_script` to check for errors
- Direct MCP edits preferred when connection stable

---

## SOLID Principles (Mandatory)

- **S** - Single Responsibility: Each class has one reason to change
- **O** - Open/Closed: Use inheritance and interfaces, extend via ScriptableObjects
- **L** - Liskov Substitution: All enemies implement IEnemy, all attacks implement IAttack
- **I** - Interface Segregation: ICombatant, IDamageable, IInteractable
- **D** - Dependency Inversion: Depend on abstractions, not concrete classes

---

## Performance Guidelines

### In Gameplay Loops (Update, FixedUpdate)

- NO allocations (`new`, string concatenation, LINQ)
- Cache all component references in Awake/Start
- Use object pooling for enemies, projectiles, VFX

### Profiling

- Use Graphy for FPS monitoring during development
- Profile early on target hardware (i5-8300H, 12GB RAM, 4GB GPU)
- Beat 'em ups can have many on-screen enemies - pool aggressively

---

## Hardware Constraints

**Development Machine (NitroDad Laptop):**
- Intel i5-8300H
- 12 GB RAM
- 4 GB GPU
- 238 GB SSD
- Windows 11 Home 24H2

**Implications:**
- Object pooling essential for enemy waves
- Keep max simultaneous enemies reasonable (10-15)
- Profile particle effects early
- Test day/night transition performance

---

## Unity MCP Tools Reference

### Script Operations

| Tool | Purpose |
|------|---------|
| `manage_script` (read) | Read script contents |
| `get_sha` | Get SHA256 hash for preconditions |
| `validate_script` | Check syntax/structure |
| `create_script` | Create new C# scripts |
| `delete_script` | Remove scripts |

### Script Editing

| Tool | Purpose |
|------|---------|
| `script_apply_edits` | Structured C# edits (replace_method, insert_method, etc.) |
| `apply_text_edits` | Precise line/column edits |

### Asset Operations

| Tool | Purpose |
|------|---------|
| `manage_asset` | Import, create, modify, delete, search assets |
| `manage_scene` | Load, save, create scenes, get hierarchy |
| `manage_gameobject` | Create, modify, find GameObjects and components |
| `manage_prefabs` | Open/close prefab stage, create from GameObject |
| `manage_editor` | Play/pause/stop, tags, layers, editor state |
| `read_console` | Get Unity console messages |
| `run_tests` | Execute EditMode or PlayMode tests |

### MCP Best Practices

1. Read before editing - view the file before making changes
2. Validate after edits - run `validate_script` to catch errors
3. Use structured edits - prefer `script_apply_edits` for methods
4. Check console - use `read_console` after changes
5. SHA256 preconditions - use `get_sha` for critical edits

---

## Project Documents

| Document | Purpose |
|----------|---------|
| FS_GDD | Game design and mechanics |
| FS_Architecture | Tech stack, systems, code structure |
| FS_DesignDecisions | History, lessons learned, decisions, red flags |
| FS_ProjectInstructions | Development protocols (this document) |

**Note:** User will ask Claude to review core docs at the start of each chat.

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

## Quick Reference Checklist

**Always:**
- [ ] Verify file/method/class names exist before referencing
- [ ] Wait for user verification before proceeding
- [ ] Use ASCII encoding only
- [ ] Use explicit types (no `var` keyword)
- [ ] Follow SOLID principles
- [ ] Use SOAP architecture with event channels
- [ ] Profile early on target hardware
- [ ] Look up current Unity 6 documentation

**Never:**
- [ ] Assume names exist without checking
- [ ] Rush ahead with multiple steps
- [ ] Use UTF-8 or special characters
- [ ] Use `var` keyword
- [ ] Use deprecated APIs
- [ ] Create allocations in Update loops
- [ ] Assume old Unity knowledge is current

---

## Lessons from Other TecVooDoo Projects

1. **Extract controllers early** - Don't let MonoBehaviours grow large
2. **SOAP architecture works** - Use event channels for decoupling
3. **Collision over raycast** - Simpler detection is more reliable
4. **GitHub over Unity VC** - Better workflow
5. **Profile early** - Beat 'em ups can stress with enemy counts
6. **Asset inventory matters** - Check what you own before building

---

## Questions Protocol

1. **Clarify the context** - What are you trying to accomplish?
2. **Look up current information** - Search Unity 6 docs
3. **Check asset inventory** - Do we own something that solves this?
4. **Provide step-by-step solution** - One step at a time
5. **Explain the reasoning** - Why this approach?

---

**End of Project Instructions**

These instructions should be followed for every conversation in this project. User will ask Claude to review these docs at the start of each chat session.
