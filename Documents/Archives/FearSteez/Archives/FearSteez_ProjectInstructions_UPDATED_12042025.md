# FearSteez - Claude Project Instructions

**Project:** FearSteez  
**Developer:** TecVooDoo LLC  
**Designer:** Rune (Stephen Brandon)  
**Unity Version:** 6.2 (Target)  
**Project Stage:** Concept  
**Date Created:** December 4, 2025  
**Last Updated:** December 4, 2025  

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

## Core Development Philosophy

### Step-by-Step Verification Protocol

**CRITICAL: Never rush ahead with multiple steps**

- Provide ONE step at a time
- Wait for user confirmation via text OR screenshot before proceeding
- User will verify each step is complete before moving forward
- If a step fails, troubleshoot that specific step before continuing
- Assume nothing - verify everything

### File Encoding Rule

**CRITICAL: ASCII Only**

- All scripts and text files MUST use ASCII encoding
- Do NOT use UTF-8 or other encodings
- Avoid special characters, smart quotes, em-dashes, etc.
- Use standard apostrophes (') not curly quotes
- Use regular hyphens (-) not em-dashes

### File Naming Convention

**When creating updated documentation or files:**

Format: `OriginalFileName_UPDATED_MMDDYYYY.ext`

**Examples:**
- `FearSteez_GDD_UPDATED_12042025.md`
- `FearSteez_DesignDecisions_UPDATED_12042025.md`

### Code Style Preferences

**CRITICAL: Explicit over implicit**

- **NO `var` keyword** - Always use explicit type declarations
- Clear, readable code always wins over clever code
- Consistent naming conventions (PascalCase for public, camelCase for private)
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
- Direct MCP edits are preferred when connection is stable

---

## Unity MCP Tools

### Overview

Unity MCP allows Claude to directly interact with the Unity Editor. The project uses:
- **MCP Package:** Unity MCP for Claude
- **Transport:** Stdio (required for Claude Desktop)
- **Unity Version:** 6.2 (Target)

### Script Operations

| Tool | Purpose | When to Use |
|------|---------|-------------|
| `manage_script` (read) | Read script contents | Legacy - still works |
| `get_sha` | Get SHA256 hash + file size | Precondition checks before edits |
| `validate_script` | Check syntax/structure | Before and after edits |
| `create_script` | Create new C# scripts | New files (also overwrites existing) |
| `delete_script` | Remove scripts | By URI or Assets-relative path |

### Script Editing Tools (Preferred)

**`script_apply_edits`** - Structured C# edits with safer boundaries:
- `replace_method` - Replace entire method body
- `insert_method` - Add new method (position: start/end/after/before)
- `delete_method` - Remove a method
- `replace_class` / `delete_class` - Class-level operations
- `anchor_insert` / `anchor_delete` / `anchor_replace` - Pattern-based edits

**`apply_text_edits`** - Precise text edits:
- Line/column coordinate-based changes
- Atomic multi-edit batches
- Precondition SHA256 hashes for safety

### Asset and Scene Operations

| Tool | Purpose |
|------|---------|
| `manage_asset` | Import, create, modify, delete, search assets |
| `manage_scene` | Load, save, create scenes, get hierarchy |
| `manage_gameobject` | Create, modify, find GameObjects and components |
| `manage_prefabs` | Open/close prefab stage, create from GameObject |
| `manage_editor` | Play/pause/stop, tags, layers, editor state |

### Console and Testing

| Tool | Purpose |
|------|---------|
| `read_console` | Get Unity console messages (errors, warnings, logs) |
| `run_tests` | Execute EditMode or PlayMode tests |

### MCP Best Practices

1. **Read before editing:** Use `manage_script` read or view the file before making changes
2. **Validate after edits:** Run `validate_script` to catch syntax errors immediately
3. **Use structured edits:** Prefer `script_apply_edits` over raw text edits for methods
4. **Check console:** Use `read_console` after changes to catch runtime issues
5. **SHA256 preconditions:** For critical edits, use `get_sha` to ensure file hasn't changed

---

## Project Architecture (Planned)

### Folder Structure

```
Assets/
+-- Art/
|   +-- Sprites/
|   |   +-- Characters/       # FearSteez, enemies, bosses
|   |   +-- Effects/          # Hit sparks, magic effects
|   |   +-- Environment/      # Backgrounds, platforms
|   +-- Animations/
|   +-- Materials/
+-- Audio/
|   +-- Music/
|   |   +-- FearSteez/        # Licensed tracks from the artist
|   |   +-- Ambient/          # Day/night atmosphere
|   +-- SFX/
|       +-- Combat/           # Punches, kicks, impacts
|       +-- Environment/      # City sounds, zombie groans
+-- Prefabs/
|   +-- Player/
|   +-- Enemies/
|   |   +-- DayMinions/
|   |   +-- NightZombies/
|   +-- Environment/
|   +-- Pickups/              # Health, power-ups, currency
+-- Scenes/
|   +-- MainMenu/
|   +-- Levels/
+-- Scripts/
|   +-- Core/                 # Managers, events, utilities
|   +-- Player/               # FearSteez controller, combat
|   +-- Enemy/                # Enemy AI, spawning
|   +-- Combat/               # Hit detection, combos, damage
|   +-- RPG/                  # Stats, progression, inventory
|   +-- Audio/                # Music manager, dynamic mixing
|   +-- UI/                   # HUD, menus, dialogue
|   +-- World/                # Day/night cycle, level management
+-- ScriptableObjects/
|   +-- Characters/           # CharacterDefinition SOs
|   +-- Enemies/              # EnemyDefinition SOs
|   +-- Moves/                # AttackDefinition SOs
|   +-- Items/                # ItemDefinition SOs
|   +-- Events/               # GameEventSO channels
|   +-- Variables/            # Runtime variable SOs
+-- Settings/
    +-- Input/                # Input System actions
```

### Core Systems Architecture

**SOAP (ScriptableObject Architecture Pattern):**
- All game data as ScriptableObjects
- Event channels for decoupled communication
- Runtime sets for object tracking
- Variables as ScriptableObjects

**Key ScriptableObjects (Planned):**
- `CharacterDefinition` - Base stats, move sets, audio references
- `EnemyDefinition` - AI settings, attack patterns, drops
- `AttackDefinition` - Damage, range, hitstun, combos
- `ItemDefinition` - Pickups, equipment, consumables
- `GameEventSO` - Event channels for system communication

---

## Asset Integration (Recommended)

### Beat 'Em Up Core

| Asset | Purpose | Priority |
|-------|---------|----------|
| **FS Melee Combat System** | Combat framework | EVALUATE |
| **Flexible 2D Character Controller** | Movement base | HIGH |
| **Animancer Pro v8** | Animation state machine | HIGH |

### RPG Systems

| Asset | Purpose | Priority |
|-------|---------|----------|
| **SOAP** | ScriptableObject architecture | HIGH |
| **Easy Save** | Save/load progression | HIGH |
| **Odin Inspector** | Better inspector UX | HIGH |

### Enemy AI

| Asset | Purpose | Priority |
|-------|---------|----------|
| **SensorToolkit 2** | Detection, aggro ranges | MEDIUM |
| **Blaze AI Engine** | Visual behavior editor | MEDIUM |

### Visuals and Audio

| Asset | Purpose | Priority |
|-------|---------|----------|
| **All In 1 Sprite Shader** | Visual effects | HIGH |
| **Feel** | Game juice, hit feedback | HIGH |
| **Master Audio 2024** | Music system | HIGH |
| **DOTween Pro** | Tweening, animations | HIGH |

### Utilities

| Asset | Purpose | Priority |
|-------|---------|----------|
| **Graphy** | Performance monitoring | MEDIUM |
| **UniTask** | Async/await (GitHub) | HIGH |
| **EasyPooling v2025** | Object pooling | HIGH |

### GitHub Packages (Not in Asset Store)

Install via Package Manager -> Add from Git URL:

```
UniTask: https://github.com/Cysharp/UniTask.git
Unity-Event-Bus: https://github.com/git-amend/Unity-Event-Bus.git
Unity-Improved-Timers: https://github.com/git-amend/Unity-Improved-Timers.git
```

---

## Development Guidelines

### SOLID Principles (Mandatory)

- **S** - Single Responsibility: Each class has one reason to change
- **O** - Open/Closed: Use inheritance and interfaces, extend via ScriptableObjects
- **L** - Liskov Substitution: All enemies implement IEnemy, all attacks implement IAttack
- **I** - Interface Segregation: ICombatant, IDamageable, IInteractable
- **D** - Dependency Inversion: Depend on abstractions, not concrete classes

### Performance-First Development

**In Gameplay Loops (Update, FixedUpdate):**
- NO allocations (`new`, string concatenation, LINQ)
- Cache all component references in Awake/Start
- Use object pooling for enemies, projectiles, VFX

**Profiling:**
- Use Graphy for FPS monitoring during development
- Profile early on target hardware (i5-8300H, 12GB RAM, 4GB GPU)
- Beat 'em ups can have many on-screen enemies - pool aggressively

### Input System

Using Unity's new Input System with InputAction syntax for Unity 6:

```csharp
// Correct Unity 6 InputAction syntax
private InputAction moveAction;
private InputAction attackAction;
private InputAction jumpAction;
private InputAction specialAction;

private void Awake()
{
    moveAction = InputSystem.actions.FindAction("Move");
    attackAction = InputSystem.actions.FindAction("Attack");
    jumpAction = InputSystem.actions.FindAction("Jump");
    specialAction = InputSystem.actions.FindAction("Special");
}

private void OnEnable()
{
    moveAction.Enable();
    attackAction.Enable();
    jumpAction.Enable();
    specialAction.Enable();
}
```

---

## Hardware Constraints

**Development Machine (NitroDad Laptop):**
- Intel i5-8300H
- 12 GB RAM
- 4 GB GPU
- 238 GB SSD (176 GB used)
- Windows 11 Home 24H2

**Implications:**
- Object pooling essential for enemy waves
- Keep max simultaneous enemies reasonable (10-15)
- Profile particle effects early
- Test day/night transition performance

---

## Key Reminders

**Always:**
- [X] Wait for user verification before proceeding
- [X] Provide COMPLETE file replacements when giving code manually
- [X] Use MCP tools for direct edits when connection is stable
- [X] Use ASCII encoding only
- [X] Use explicit types (no `var` keyword)
- [X] Look up current Unity 6 documentation
- [X] Use Odin Inspector for data structures
- [X] Use DOTween Pro for animations
- [X] Follow SOLID principles
- [X] Use SOAP architecture with event channels
- [X] Profile early on target hardware

**Never:**
- [ ] Rush ahead with multiple steps
- [ ] Use `var` keyword
- [ ] Use incremental edits when providing code for manual copy/paste
- [ ] Use UTF-8 or special characters
- [ ] Assume old Unity knowledge is current
- [ ] Use deprecated APIs
- [ ] Create allocations in Update loops

---

## Scope Control

**This is a CONCEPT-STAGE project.**

- Focus on core loop first: Move, punch, enemies react
- Day/night system can be simple toggle initially
- RPG elements can start minimal (XP and level only)
- Music integration is a priority but can use placeholder tracks
- One enemy type per category (day/night) for MVP

---

## Questions Protocol

1. **Clarify the context** - What are you trying to accomplish?
2. **Look up current information** - Search Unity 6 docs
3. **Check asset inventory** - Do we own something that solves this?
4. **Provide step-by-step solution** - One step at a time
5. **Explain the reasoning** - Why this approach?

---

**End of Project Instructions**

These instructions should be followed for every conversation in this project.
