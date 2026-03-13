# FearSteez - Architecture Document

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

## Technology Stack

### Engine
- **Unity 6.2** - Matches other TecVooDoo projects
- **URP** - Universal Render Pipeline for performance
- **Input System** - New Input System for flexible controls

### Architecture Pattern
**SOAP (ScriptableObject Architecture Pattern)**
- Consistent with other TecVooDoo projects (A Quokka Story)
- Data-driven design via ScriptableObjects
- Event channels for decoupled communication
- Runtime sets for object tracking

---

## Project Structure (Planned)

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

---

## Core ScriptableObjects

### CharacterDefinition
```csharp
[CreateAssetMenu(fileName = "Character", menuName = "FearSteez/CharacterDefinition")]
public class CharacterDefinition : ScriptableObject
{
    public string characterName;
    public Sprite portrait;

    [Header("Base Stats")]
    public int baseStrength;
    public int baseDefense;
    public int baseSpeed;
    public int baseStamina;

    [Header("Combat")]
    public AttackDefinition[] moveSet;
    public float attackSpeed;
    public float moveSpeed;

    [Header("Audio")]
    public AudioClip[] attackSounds;
    public AudioClip[] hurtSounds;
}
```

### EnemyDefinition
```csharp
[CreateAssetMenu(fileName = "Enemy", menuName = "FearSteez/EnemyDefinition")]
public class EnemyDefinition : ScriptableObject
{
    public string enemyName;
    public EnemyType enemyType; // Day or Night

    [Header("Stats")]
    public int health;
    public int damage;
    public float moveSpeed;
    public float attackRange;

    [Header("AI")]
    public float aggroRange;
    public float attackCooldown;
    public AIBehaviorType behavior;

    [Header("Drops")]
    public int xpValue;
    public LootTable lootTable;
}
```

### AttackDefinition
```csharp
[CreateAssetMenu(fileName = "Attack", menuName = "FearSteez/AttackDefinition")]
public class AttackDefinition : ScriptableObject
{
    public string attackName;
    public AttackType attackType;

    [Header("Damage")]
    public int baseDamage;
    public float damageMultiplier;
    public DamageType damageType;

    [Header("Timing")]
    public int startupFrames;
    public int activeFrames;
    public int recoveryFrames;

    [Header("Effects")]
    public float hitstunDuration;
    public float knockbackForce;
    public bool causesLaunch;
    public bool canComboInto;

    [Header("Audio/Visual")]
    public AudioClip hitSound;
    public GameObject hitEffect;
}
```

---

## System Architecture

### Combat System

```
PlayerCombatController
├── InputBuffer (queue attacks during recovery)
├── ComboTracker (current combo state)
├── AttackExecutor (perform attacks via AttackDefinition)
└── HitDetector (collision-based hit detection)

EnemyCombatController
├── AIDecisionMaker (when to attack/retreat)
├── AttackExecutor (same as player)
└── DamageReceiver (process incoming damage)

DamageSystem (Static/Singleton)
├── CalculateDamage(attacker, defender, attack)
├── ApplyDamage(target, damage)
├── ApplyKnockback(target, force, direction)
└── TriggerHitEffects(position, attackDef)
```

### Progression System

```
ProgressionManager
├── ExperienceTracker
│   ├── CurrentXP
│   ├── XPToNextLevel
│   └── OnXPGained event
├── LevelManager
│   ├── CurrentLevel
│   ├── StatPointsAvailable
│   └── OnLevelUp event
└── StatManager
    ├── BaseStats (from CharacterDefinition)
    ├── BonusStats (from equipment/skills)
    └── CalculatedStats (final values)
```

### Day/Night System

```
DayNightManager
├── CurrentTimeState (Day/Night enum)
├── TransitionProgress (0-1 for visual lerp)
├── EnemySpawnRules (which enemies spawn when)
└── Events
    ├── OnDayStarted
    ├── OnNightStarted
    └── OnTransitionBegan
```

---

## Input System Configuration

### Action Map: Player

```csharp
// Input Action references
private InputAction moveAction;
private InputAction attackAction;
private InputAction heavyAttackAction;
private InputAction jumpAction;
private InputAction specialAction;
private InputAction grabAction;

private void Awake()
{
    moveAction = InputSystem.actions.FindAction("Move");
    attackAction = InputSystem.actions.FindAction("Attack");
    heavyAttackAction = InputSystem.actions.FindAction("HeavyAttack");
    jumpAction = InputSystem.actions.FindAction("Jump");
    specialAction = InputSystem.actions.FindAction("Special");
    grabAction = InputSystem.actions.FindAction("Grab");
}
```

### Control Mappings

| Action | Keyboard | Gamepad |
|--------|----------|---------|
| Move | WASD / Arrows | Left Stick |
| Attack | J / X | X / Square |
| Heavy Attack | K / C | Y / Triangle |
| Jump | Space | A / X |
| Special | L / V | B / Circle |
| Grab | U / F | RB / R1 |

---

## Recommended Assets

### Combat & Animation

| Asset | Purpose | Priority |
|-------|---------|----------|
| FS Melee Combat System | Combat framework (EVALUATE) | MEDIUM |
| Animancer Pro v8 | Animation state machine | HIGH |
| Feel | Game juice, hit feedback | HIGH |

### RPG & Data

| Asset | Purpose | Priority |
|-------|---------|----------|
| SOAP | ScriptableObject architecture | HIGH |
| Easy Save | Save/load progression | HIGH |
| Odin Inspector | Better inspector UX | HIGH |

### Enemy AI

| Asset | Purpose | Priority |
|-------|---------|----------|
| SensorToolkit 2 | Detection, aggro ranges | MEDIUM |
| Blaze AI Engine | Visual behavior editor | MEDIUM |

### Audio & Visual

| Asset | Purpose | Priority |
|-------|---------|----------|
| Master Audio 2024 | Music system | HIGH |
| All In 1 Sprite Shader | Visual effects | HIGH |
| DOTween Pro | Tweening, animations | HIGH |

### Utilities

| Asset | Purpose | Priority |
|-------|---------|----------|
| Graphy | Performance monitoring | MEDIUM |
| UniTask | Async/await | HIGH |
| EasyPooling v2025 | Object pooling | HIGH |

---

## Performance Guidelines

### Hardware Target

**Development Machine:**
- Intel i5-8300H
- 12 GB RAM
- 4 GB GPU

### Optimization Requirements

**In Update Loops:**
- NO allocations (new, string concat, LINQ)
- Cache all component references in Awake/Start
- Use object pooling for enemies, projectiles, VFX

**Enemy Management:**
- Max 10-15 simultaneous enemies
- Pool aggressively for wave spawning
- Profile day/night transitions

**Profiling:**
- Use Graphy during development
- Test on target hardware early
- Beat 'em ups stress test with enemy counts

---

## GitHub Packages

Install via Package Manager -> Add from Git URL:

```
UniTask: https://github.com/Cysharp/UniTask.git
Unity-Event-Bus: https://github.com/git-amend/Unity-Event-Bus.git
Unity-Improved-Timers: https://github.com/git-amend/Unity-Improved-Timers.git
```

---

## MCP Tool Reference

### Script Operations

| Tool | Purpose |
|------|---------|
| `manage_script` (read) | Read script contents |
| `get_sha` | SHA256 hash for precondition checks |
| `validate_script` | Check syntax/structure |
| `create_script` | Create new C# scripts |
| `script_apply_edits` | Structured method-level edits |
| `apply_text_edits` | Precise line/column edits |

### Asset Operations

| Tool | Purpose |
|------|---------|
| `manage_asset` | Import, create, modify, delete, search assets |
| `manage_scene` | Load, save, create scenes, get hierarchy |
| `manage_gameobject` | Create, modify, find GameObjects |
| `manage_prefabs` | Prefab stage operations |
| `manage_editor` | Play/pause/stop, tags, layers |
| `read_console` | Get Unity console messages |
| `run_tests` | Execute EditMode or PlayMode tests |

---

## Development Status

### Current Phase: Concept

| Item | Status |
|------|--------|
| Unity project setup | NOT STARTED |
| Project structure | NOT STARTED |
| Input configuration | NOT STARTED |
| Player controller | NOT STARTED |
| Combat system | NOT STARTED |
| Enemy AI | NOT STARTED |
| Progression system | NOT STARTED |

---

**End of Architecture Document**
