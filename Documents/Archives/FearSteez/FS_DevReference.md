# FS - Development Reference

**Purpose:** Stable reference for FearSteez architecture, coding standards, and conventions. Read on demand, not every session.
**Last Updated:** March 3, 2026

---

## Architecture

### Namespaces

| Namespace | Purpose | Status |
|-----------|---------|--------|
| `FS.Core` | Game state, managers, shared utilities | Planned |
| `FS.Player` | Player movement, combat, input | Planned |
| `FS.Enemy` | Enemy AI, behavior, spawning | Planned |
| `FS.Combat` | Damage, hitboxes, combos | Planned |
| `FS.Progression` | XP, levels, stats | Planned |
| `FS.UI` | Menus, HUD, overlays | Planned |
| `FS.Audio` | Music, SFX managers | Planned |
| `FS.Data` | ScriptableObject definitions | Planned |
| `FS.Editor` | Editor utilities, tools | Planned |

### Folder Structure

```
Assets/Sandbox/FearSteez/
  Art/
    Animations/  - Animation clips, animator controllers
    Materials/   - Materials for 3D models
    Models/      - 3D character/environment models
    Textures/    - Textures
  Audio/         - Music, SFX
  Data/          - ScriptableObjects (config, events)
  Prefabs/       - Reusable GameObjects
  Scenes/        - Game scenes
  Scripts/       - C# code
  Settings/      - Input actions, configs
  UI/            - UI Toolkit assets (UXML, USS)
  VFX/           - Particle systems, visual effects
```

### ScriptableObject Architecture

TecVooDoo standard -- vanilla Unity SOs with custom event system. No SOAP asset.

| Pattern | Implementation |
|---------|---------------|
| Game data | ScriptableObjects (EnemyData, AttackData, CharacterData, etc.) |
| Events | Custom GameEvent / GameEventListener pattern |
| Runtime state | ScriptableObject variables where appropriate |

### Combat Framework

FearSteez combat is built from scratch using Animancer Pro. Both reference packages are cherry-pick only -- neither is the foundation.

| Package | Role | Cherry-Pick Targets |
|---------|------|---------------------|
| FS Melee Combat System 2.0.6 | Reference | `AttackData` SO structure, hitbox timing (impactStartTime/End), damage/reaction concepts, camera shake integration |
| Beat 'Em Up Game Template 3D 1.4 | Reference | Combat tuning values, hit stun durations, enemy wave patterns, beat 'em up feel |

**Why not build on FS Melee:** Uses Unity Animator + proprietary `AnimGraph`/`AnimGraphClipInfo` -- incompatible with Animancer. Also assumes 3D target-lock combat, not beat 'em up directional attacks.

**What we build:**
- `FSFighter` -- Animancer-driven character state machine
- `FSCombatController` -- directional attacks, no target lock, beat 'em up hit arcs
- `FSInputHandler` -- New Input System
- `FSEnemy` -- AI Navigation + behavior states
- SO data layer adopts FS Melee's `AttackData`/`AttackContainer` concepts, adapted for Animancer clips

### Weapon Animation System

Each equippable weapon is a `WeaponData` ScriptableObject with its own `AttackContainer[]`. Swapping weapons at runtime swaps the active attack set -- Animancer plays whatever clips the active `WeaponData` references.

| Weapon State | Animation Source | Pack |
|---|---|---|
| No weapon (fists) | Punch, Kick, Grapple, Combo_Cut | Frank FS3 + FS4 |
| Microphone / Rope dart | Whip Attack, Combo_Cut | Frank Whip |
| Bat / Crowbar (blunt) | 2-Handed or Warrior clips | Frank Slash Pack |
| Thrown (vinyl, knife) | FS3 aerial/throw animations | Frank FS3 |

**Known gap -- placeholder locomotion:** Environmental weapon pickups (bat, crowbar, etc.) will use FS3 base locomotion while held -- there are no weapon-specific walk/run cycles in the Frank packs for blunt weapons. This is acceptable for prototype. When final Steez animations are commissioned, weapon-specific locomotion sets must be created for each holdable weapon type. Track in: [FS_Art_AssetList.md](FS_Art_AssetList.md).

### Dependencies (Active in Sandbox)

**UPM:**
| Package | Version | Purpose |
|---------|---------|---------|
| UniTask | 2.5.10 | Async/await instead of coroutines |
| Animancer | 8.2.3 | Animancer Pro runtime (Kybernetik) |
| Cinemachine | 3.1.5 | Camera system |
| Input System | 1.18.0 | Player input |
| AI Navigation | 2.0.11 | NavMesh (enemy pathing) |
| ProBuilder | 6.0.9 | Level blockout geometry |
| TecVooDoo Utilities | 1.0.0 | Internal utilities |

**Asset Store -- Combat & Animation:**
| Package | Version | Purpose |
|---------|---------|---------|
| FS Melee Combat System | 2.0.6 | Cherry-pick reference only (ENTRY-219) -- AttackData SO pattern, hitbox concepts |
| FS Parkour and Climbing | 1.9.9 | Cherry-pick reference (ENTRY-258) -- ParkourAction SO data pattern for traversal |
| Animancer Pro | 8.2.3 | Animation state machine, runtime control |
| Frank FS3 + FS4 | 1.0 | 243 combat clips (punches, kicks, combos, grapples) |
| Frank Slash Pack | 3.8 | ~65 whip/rope clips -- Steez signature weapon |
| Human Melee Animations | 2.0.2 | Enemy locomotion, stun, death clips (Kevin Iglesias) |
| Final IK | 2.4 | Full-body IK -- procedural hand/foot placement |
| Boing Kit | 1.2.47 | BoingBones spring physics -- hair, ponytail, loose chains (ENTRY-256) |

**Asset Store -- Audio:**
| Package | Version | Purpose |
|---------|---------|---------|
| Master Audio 2024 | 1.0.3 | Music system, SFX management |
| Koreographer Pro | 1.6.3 | BPM sync -- music-driven gameplay (ENTRY TBD) |

**Asset Store -- Game Systems:**
| Package | Version | Purpose |
|---------|---------|---------|
| Feel | 5.9.1 | Screen shake, freeze frames, hit stop |
| Squash & Stretch Kit | 1.1.2 | Velocity-based deformation -- hit juice complement to Feel |
| EasyPooling | 2025.1 | Object pooling for enemies, VFX |
| Damage Numbers Pro | 4.51 | Damage popups (wired into EnemyHealth) |
| Easy Save | 3.5.25 | Save/load progression |
| DOTween Pro | 1.0.410 | Tweening, UI animations |

**Asset Store -- UI:**
| Package | Version | Purpose |
|---------|---------|---------|
| Flexalon Pro | 4.4.0 | 3D and UI layout engine |
| Flow UI Toolkit Extended | 1.5.1 | Fluent API for UI Toolkit |
| Toolkit for UX 2026 | 5.0.0 | UX framework (Default UI) |
| Text Animator for Unity | 3.5.0 | Text effects (UI Toolkit + TMP) |
| UI Toolkit Text Animation 2 | 2.0.3 | Kamgam text effects (Default UI) |
| UI Toolkit Blurred Background | 1.4.1 | Pause/overlay menu blur |
| UI Toolkit Scroll View Pro | 1.6.7 | Menus, skill lists |
| UI Toolkit Sound Effects | 1.0.1 | UI audio feedback |
| UI Toolkit Text Auto Size | 1.0.1 | Best-fit text (Default UI) |
| UI Toolkit Script Components | 1.1.0 | UIT code components (Default UI) |
| UI Toolkit Custom Shader Image | 1.0.3 | URP shader effects in UI (Default UI) |
| UI Toolkit Shadows/Glow | 1.3.4 | Visual polish (Default UI) |
| UI Toolkit Particles | 1.3.5 | Particle effects in UI (Default UI) |

**Asset Store -- Editor / QoL:**
| Package | Version | Purpose |
|---------|---------|---------|
| Odin Inspector | 4.0.1.4 | Editor tooling |
| Graphy | 3.0.5 | In-game performance overlay |
| Ninja Profiler | 2.0.0 | Editor performance profiling |
| vFavorites 2 / vFolders 2 / vHierarchy 2 | 2.x | Project organization |
| Ultimate Preview Window | 1.3.1 | Asset preview |

---

## Coding Standards

- No `var` keyword -- explicit types always
- No per-frame allocations or LINQ
- Prefer async/await (UniTask) over coroutines
- Clear separation between logic and UI
- UI Toolkit only -- no uGUI Canvas (use UIDocument, UXML, USS)
- ASCII-only in documentation and identifiers
- 800-1200 lines per file (extract when exceeding)

---

## Development Priorities (Ordered)

1. **Use installed packages first** -- check if a package solves the problem before writing custom code
2. **SOLID principles second** -- interfaces, single responsibility
3. **Memory efficiency third** -- no per-frame allocations
4. **Clean code fourth** -- readable, maintainable
5. **Self-documenting code fifth** -- clear naming over comments
6. **Platform best practices sixth** -- Unity patterns

### Package-First Development

Before writing custom code, check if an installed package handles it:

| Need | Use This Package | Status |
|------|-----------------|--------|
| Animation control | Animancer Pro | In Sandbox |
| Object pooling | EasyPooling | In Sandbox |
| Tweening/easing | DOTween Pro | In Sandbox |
| Async operations | UniTask | In Sandbox |
| Save/load data | Easy Save | In Sandbox |
| Screen shake, freeze frames, hit stop | Feel | In Sandbox |
| Hit flash, outlines, dissolve | All In 1 3D-Shader | In Sandbox |
| Audio playback | Master Audio 2024 | In Sandbox |
| BPM sync | Koreographer Pro | In Sandbox |
| Full-body IK | Final IK | In Sandbox |
| UI layout | Flexalon Pro | In Sandbox |
| UI text effects | Text Animator for Unity | In Sandbox |
| Combat foundation | FS Melee Combat System | In Sandbox |
| Combat reference | Beat 'em Up Game Template 3D | In Sandbox (cherry-pick) |

**Only write custom code when packages don't cover the use case.**

---

## Lessons Learned

### Unity/C# Patterns

1. **Set state BEFORE firing events** -- handlers may check state immediately
2. **Initialize UI to known states** -- don't rely on defaults
3. **Use New Input System** -- `Keyboard.current`, not `Input.GetKeyDown`
4. **No `var` keyword** -- explicit types always
5. **800 lines max** -- extract controllers when approaching limit
6. **Prefer UniTask over coroutines** -- `await UniTask.Delay(1000)`
7. **No allocations in Update** -- cache references, use object pooling
8. **Validate after MCP edits** -- run validate_script to catch syntax errors

### Project-Specific

9. **Pool aggressively** -- beat 'em ups have many on-screen enemies
10. **Profile early with full waves** -- test worst-case performance
11. **Use E: drive path** -- not backup folders
12. **Lock position during combat states** -- humanoid clips (Kevin Iglesias, Frank) have baked root bone motion that slides the transform even with `applyRootMotion=false`. Capture position at state entry, enforce each frame during attack/stagger/cooldown.
13. **FBX loopTime survives via clipAnimations** -- when `clipAnimations: []` in meta, Unity uses FBX defaults (no loop). Adding explicit clip entry with `loopTime: 1` enables loop. Reimporting .unitypackage resets to `[]` -- must re-add and re-assign serialized refs.
14. **Kevin Iglesias HumanM faces +Z** -- use Y=90 for screen right, Y=-90 for screen left when using Forward locomotion clips. NOT Y=0/180 (that was old strafe clip convention).

---

## Bug Patterns to Avoid

| Bug Pattern | Cause | Prevention |
|-------------|-------|------------|
| State set AFTER events | Handlers see stale state | Set state BEFORE firing events |
| Old screen still visible | Only showing new | Hide ALL other screens when showing new |
| Animation slides character | Root bone motion in humanoid clips | Lock transform.position during non-movement states |
| Attack state never ends | Another system overwrites anim state | Check `!IsPlaying` as fallback alongside `NormalizedTime >= 1f` |
| FBX loop resets on reimport | .unitypackage overwrites meta | Re-add clipAnimations entry, re-assign serialized clip refs |

---

## AI Rules

1. **Read FS_CodeReference.md first** -- check existing APIs before writing new code
2. **Use installed packages first** -- don't reinvent what packages already do
3. **Working directory is `E:\Unity\Sandbox`** -- FearSteez subproject at `Assets/Sandbox/FearSteez/`
4. **Verify names exist** -- search before referencing files/methods/classes
5. **Step-by-step verification** -- one step at a time, wait for confirmation
6. **Read before editing** -- always read files before modifying
7. **ASCII only** -- no smart quotes, em-dashes, or special characters
8. **Be direct** -- give honest assessments, don't sugar-coat
9. **Update FS_CodeReference.md** -- when adding/changing scripts, APIs, or data models

---

## Reference Documents

| Document | Path | Purpose |
|----------|------|---------|
| **Status** | `FS_Status.md` | Current work, sessions, milestones |
| **Code Reference** | `FS_CodeReference.md` | Script API, namespaces, conventions |
| **Art Asset List** | `FS_Art_AssetList.md` | Art pipeline tracking |
| **Troubleshooting** | `FS_Troubleshooting.md` | Active debugging process |
| **GDD** | `GDD/FS_GDD.md` | Game Design Document (user-maintained) |

---

**End of Development Reference**
