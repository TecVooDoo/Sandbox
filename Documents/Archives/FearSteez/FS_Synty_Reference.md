# FearSteez - Synty Sidekick Characters Reference

**Purpose:** Complete reference for the Synty Sidekick Characters system as used in FearSteez.
**Last Updated:** March 7, 2026
**Asset path:** `Assets/Synty/SidekickCharacters/`

---

## Summary

Synty Sidekick Characters is the production character system for FearSteez. All enemies and any future NPCs use Sidekick prefabs. The animation packs installed cover full locomotion, sword combat (attacks, hit reactions, death), emotes, and facial expressions. The Apocalypse character sets map directly to FearSteez's day/night enemy split.

---

## Pre-Built Character Sets

All located in `Assets/Synty/SidekickCharacters/Characters/`. Each character is a self-contained prefab with its own mesh, material (color map texture), and Mecanim avatar.

| Set | Count | FearSteez Role |
|-----|-------|---------------|
| **ApocalypseOutlaws** | 5 | Day enemies -- street thugs, sorcerer's minions |
| **ApocalypseZombies** | 5 | Night enemies -- undead |
| **ApocalypseSurvivors** | 5 | Potential civilians / allies |
| ElvenWarriors | 6 | Fantasy -- not FearSteez relevant |
| VikingWarriors | 6 | Fantasy -- not FearSteez relevant |
| FantasyKnights | 6 | Fantasy -- not FearSteez relevant |
| FantasySkeletons | 2+ | Fantasy undead -- could substitute for unique zombie variants |

**Priority for next session:** Drop an ApocalypseOutlaw prefab into TestScene and wire up FSEnemyBrain + EnemyHealth. Then ApocalypseZombie for the night enemy.

---

## Skeleton

- **Rig:** Standard Unity Mecanim Humanoid
- **Extra bones (beyond standard):** `IK_foot_root`, `IK_hand_root`
  - Handle in Final IK setup and any bone remapping operations
  - Animancer does NOT care about extra bones -- they pass through fine
- **Default facing direction:** +Z (same as standard Unity humanoid)
- **Weapon socket bone:** `Hand_R` -> `Prop_R` -> `Prop_R_Socket` (created by SyntyPropBoneTool)

---

## Animation Packs Installed

### Naming Convention

| Prefix | Rig | Use for |
|--------|-----|---------|
| `A_MOD_BL_*` | Sidekick Base Locomotion (human rig) | Human/civilian enemies |
| `A_MOD_GBL_*` | Sidekick Goblin Base Locomotion | Goblin-boned characters (zombies) |
| `A_MOD_SWD_*` | Sidekick Sword Combat | Both -- combat actions retarget fine |
| `A_MOD_EMOT_*` | Sidekick Emotes | Both |
| `A_POLY_` / Polygon folder | Polygon humanoid rig | Avoid -- `A_MOD_*` is always preferred |
| `_RM_` suffix | Root motion | Also `_RMH_` (horizontal only), `_RMV_` (vertical only) |
| `_Neut_` | Gender neutral | Use unless you need `_Femn_` or `_Masc_` variant |
| `_Masc_` / `_Femn_` | Gender variants | BL clips require gender suffix; GBL and SWD use `_Neut_` |

**Rule for FearSteez:** Always use the `A_MOD_*` Sidekick-rig clips. Match the rig prefix to the character's bone set (BL for human, GBL for goblin).

---

### AnimationGoblinLocomotion

Path: `Assets/Synty/SidekickCharacters/Animations/AnimationGoblinLocomotion/`
Sidekick clips: `Animations/Sidekick/Neutral/`

Complete locomotion set. All directions (8-directional strafing). **Use this for enemy patrol and chase movement.**

| Use | Clip |
|-----|------|
| Idle (patrol/cooldown) | `A_MOD_GBL_Idle_Standing_Neut` |
| Idle (menacing) | `A_MOD_GBL_Idle_Fidget_Menacing_Neut` |
| Walk forward (patrol) | `A_MOD_GBL_Walk_F_Neut` |
| Run forward (chase) | `A_MOD_GBL_Run_F_Neut` |
| Sprint | `A_MOD_GBL_Sprint_F_Neut` (check Sidekick folder) |
| Crouch idle | `A_MOD_GBL_Idle_Crouching_Neut` |
| Additive head look | `A_MOD_GBL_HeadLook_L/R/U/D_Additive_Neut` |

---

### AnimationSwordCombat

Path: `Assets/Synty/SidekickCharacters/Animations/AnimationSwordCombat/`
Sidekick clips: `Animations/Sidekick/`

**This is the primary combat pack for enemies.** All state machine categories present:

#### Idle
| Clip | Notes |
|------|-------|
| `A_MOD_SWD_Idle_Base_Neut` | Combat ready stance |
| `A_MOD_SWD_Idle_Menacing01_Loop_Neut` | Patrol/aggro idle variant |

#### Attack (use for FSEnemyBrain `_attacks` array)
All under `Attack/LightCombo01/` and `Attack/HeavyCombo01/`:
- `A_MOD_SWD_Attack_LightCombo01A_Neut` -- fast jab
- `A_MOD_SWD_Attack_LightCombo01B_Neut`
- `A_MOD_SWD_Attack_LightCombo01C_Neut`
- `A_MOD_SWD_Attack_HeavyCombo01A_Neut` -- power hit
- `A_MOD_SWD_Attack_HeavyCombo01B_Neut`
- `A_MOD_SWD_Attack_HeavyCombo01C_Neut`
- `A_MOD_SWD_Attack_HeavyStab01_Neut` -- lunge attack
- `A_MOD_SWD_Attack_HeavyFlourish01_Neut` -- stylish heavy

Each attack has `_ReturnToIdle_Neut` and `_RM_Neut` variants.

#### Hit Reactions (stagger -- use for FSEnemyBrain.Stagger())
| Clip | Notes |
|------|-------|
| `A_MOD_SWD_Hit_F_React_Neut` | Quick flinch forward hit |
| `A_MOD_SWD_Hit_B_React_Neut` | Quick flinch back hit |
| `A_MOD_SWD_Hit_L_React_Neut` | Quick flinch left |
| `A_MOD_SWD_Hit_R_React_Neut` | Quick flinch right |
| `A_MOD_SWD_Hit_F_Stagger_Neut` | Full stagger forward (longer) |
| `A_MOD_SWD_Hit_B_Stagger_Neut` | Full stagger back |
| `A_MOD_SWD_KnockDown_Enter_Neut` | Gets knocked down |
| `A_MOD_SWD_KnockDown_Loop_Neut` | Lying on ground loop |
| `A_MOD_SWD_KnockDown_Exit_Neut` | Gets back up |
| `A_MOD_SWD_Stun_Enter/Loop/Exit_Neut` | Stunned state |

#### Death
| Clip | Notes |
|------|-------|
| `A_MOD_SWD_Death_F_Neut` | Falls forward (facing player) |
| `A_MOD_SWD_Death_B_Neut` | Falls backward |
| `A_MOD_SWD_Death_L_Neut` | Falls left |
| `A_MOD_SWD_Death_R_Neut` | Falls right |
| `A_MOD_SWD_Death_F_Pose_Neut` | Static pose (end of death anim) |

#### Dodge / Block
Available but lower priority for enemy AI. Block: Enter/Loop/Exit + Parry variants. Dodge: B/F/L/R + DodgeRoll variants.

---

### AnimationBaseLocomotion

Path: `Assets/Synty/SidekickCharacters/Animations/AnimationBaseLocomotion/`
Clips at: `Animations/Polygon/Masculine/` and `Animations/Polygon/Feminine/`

Standard human locomotion. Two rig variants:
- **Polygon rig:** `Animations/Polygon/Masculine/` -- clips like `A_Idle_Standing_Masc`, `A_Run_F_Masc`
- **Sidekick rig (`A_MOD_BL_*`):** `Animations/Sidekick/Masculine/` -- clips like `A_MOD_BL_Idle_Standing_Masc`, `A_MOD_BL_Walk_F_Masc`

**Always use `A_MOD_BL_*` for human-boned Sidekick characters** -- authored natively on the Sidekick rig, no retargeting needed.

| Use | Clip |
|-----|------|
| Idle | `A_MOD_BL_Idle_Standing_Masc` (or `_Femn`) |
| Walk / patrol | `A_MOD_BL_Walk_F_Masc` |
| Run / chase | `A_MOD_BL_Run_F_Masc` |
| Sprint | `A_MOD_BL_Sprint_F_Masc` |

---

### AnimationEmotesAndTaunts

Path: `Assets/Synty/SidekickCharacters/Animations/AnimationEmotesAndTaunts/`
Sidekick clips: `A_MOD_EMOT_*_Femn/Masc`

Categories: Affection, Aggressive, Angry, Celebrate, Dance, Greet, Happy, Reproach, Sad, Sporty, Taunt.

Relevant for FearSteez enemies: Aggressive (`Roar_High/Low`, `MenacingFists`), Taunt (`LaughAndPoint`, `MockCrying`), Sporty (`Boxing`, `MartialArts_Flourish`).

---

### AnimationIdles

Path: `Assets/Synty/SidekickCharacters/Animations/AnimationIdles/`
Polygon-only (`A_POLY_IDL_*_Masc/Femn`). NPC idle variety -- looking around, stretching, bored, etc.
Can be retargeted to Sidekick via Mecanim avatar. Lower priority for enemies.

---

### FacePoses and FaceCycles

Path: `Assets/Synty/SidekickCharacters/Animations/FacePoses/` (or equivalent)
Clip names: `A_FacePose_Angry`, `A_FacePose_Happy`, `A_FacePose_Scared`, etc. (14 total).

**Important:** The demo `ExpressionSwitcher.cs` uses Unity Animator with a dedicated `Emotion_Additive` layer. Clips play via `CrossFadeInFixedTime`. This is NOT compatible with Animancer-only setup. Options:
1. Keep a separate Unity Animator component just for the face layer (Animancer coexists with Animator on different layers).
2. Drive blendshapes directly at runtime via `SkinnedMeshRenderer.SetBlendShapeWeight()`.

For FearSteez enemies, facial expressions are low priority. Defer until polish phase.

---

## FacialController (Editor-Only)

`Scripts/Runtime/Blendshapes/FacialController.cs` -- `#if UNITY_EDITOR` only. Does NOT run in builds.

Used for authoring facial poses in the editor. All 47 parameters drive blendshapes on all child `SkinnedMeshRenderer` components.

### Eye Bones
- Bone names: `eye_l`, `eye_r` (found via `GetComponentsInChildren<Transform>`)
- Rotated directly (not blendshapes) for gaze direction
- Original rotation: `(0.024, 270, 90)`
- Up: `(-9.5, 270, 90)`, Down: `(13.5, 270, 90)`
- Left L: `(0, 270, 68)`, Right L: `(0, 270, 105)` -- mirrored for R

### Blendshape Parameters (47 total)
Named on the SMR as `{category}{side}{param}`:
- **Eyebrows:** `ebrl/ebrrFrown/Inner/OuterBlendValue`
- **Eyes:** `eyel/eyerUpDown/LeftRight/Blink/Squint/WideBlendValue`
- **Nose:** `nosl/nosrSneerBlendValue`
- **Cheeks:** `chkl/chkrHollowPuffBlendValue`
- **Jaw:** `jawOpenClose/LeftRight/BackForwardBlendValue`
- **Mouth:** `mthLeftRight/Funnel/Pucker/ShrugUpper/ShrugLower/RollUpper/RollOutUpper/RollLower/RollOutLower/Close/FrownSmile/PressStretch/UpperUp/LowerDown` (L/R where applicable)
- **Tongue:** `tongDownUp/InOut/LowerRaise/TwistLeftRight/CurlDownUp/CurlLeftRight/CurlSideDownUp`

`SetBlendValue(string blendName, float value)` is the public API. Value 0-1 maps to 0-100 on the SMR.

---

## Body Shape Blendshapes

`BlendShapeType` enum: `Feminine`, `Heavy`, `Skinny`, `Bulk`.
Set via `SidekickRuntime` API or directly on SMR. NOT facial -- body proportions only.

---

## Modular Character Assembly

Handled by `SidekickRuntime.cs` + SQLite database. Used via the editor window (`Window > Synty > Sidekick Characters`).

| Type | Detail |
|------|--------|
| `CharacterPartType` | 37 types: Head, Hair, Eyebrows, Eyes, Ears, FacialHair, Nose, Teeth, Tongue, Torso, Arms, Hands, Hips, Legs, Feet, Wrap, plus 12 Attachment slots |
| `ColorPartType` | Color regions per part (primary/secondary/tertiary etc.) |
| `ColorGroup` | Groupings for batch color changes |
| Serialization | `SerializedCharacter` -> JSON for save/load character configurations |

For FearSteez: Use pre-built prefabs rather than runtime assembly. The modular system is for creating new characters in editor, not for runtime enemy variation.

---

## SyntyPropBoneTool

`Assets/Synty/Tools/SyntyPropBoneTool/`

Runtime weapon/prop attachment. Works via `PropBoneBinder` component + `PropBoneConfig` ScriptableObject.

**Default socket for humanoid rig:**
- Parent bone: `Hand_R`
- Prop bone: `Prop_R`
- Socket: `Prop_R_Socket`

**Workflow:**
1. Add `PropBoneBinder` to character root
2. Assign `Animator` and a `PropBoneConfig` asset
3. Click "Create Prop Bones" in editor to add the bone hierarchy
4. Click "Bind Prop Bones" to wire up the bindings
5. Parent your weapon mesh to `Prop_R_Socket`

Updates in `LateUpdate` by default (after animator). Set `updateType = Manual` to call `UpdateBones()` yourself if needed.

---

## FSEnemyBrain Integration Notes

**GBL = Goblin.** Use `A_MOD_GBL_*` only for goblin-boned characters (zombies). Use BaseLocomotion `A_*_Masc/Femn` for human-boned characters (civilians).

### Civilian enemy (human bones, Masculine variant) -- Civilian01 confirmed working
| FSEnemyBrain field | Clip / Asset |
|--------------------|------|
| `_idleClip` | `A_MOD_BL_Idle_Standing_Masc` (BaseLocomotion/Sidekick) |
| `_walkClip` | `A_MOD_BL_Walk_F_Masc` (BaseLocomotion/Sidekick) |
| `_runClip` | `A_MOD_BL_Run_F_Masc` (BaseLocomotion/Sidekick) |
| `_attacks[0]` | `Punch01` FSAttackData SO (`Frank_FS3@Punch01` -- retargets via Mecanim) |
| `_attacks[1]` | `Punch02` FSAttackData SO (`Frank_FS3@Punch02`) |
| Stagger (EnemyHealth `_hitClip`) | `Frank_FS3@Hit_High_F` (Frank Fighting Set 4) |
| Death (EnemyHealth `_deathClip`) | `Frank_FS3@KO_Mid_2` (Frank Fighting Set 4) |

**Note:** Synty SWD pack has sword/bow attacks only -- no straight punches or kicks. Use Frank FS3 for all unarmed combat. Frank FS3 clips retarget to any Mecanim humanoid including Synty Sidekick.

### Zombie enemy (goblin bones) -- Zombie01 confirmed working
| FSEnemyBrain field | Clip / Asset |
|--------------------|------|
| `_idleClip` | `A_MOD_GBL_Idle_Standing_Neut` (GoblinLocomotion) |
| `_walkClip` | `A_MOD_GBL_Walk_F_Neut` (GoblinLocomotion) |
| `_runClip` | `A_MOD_GBL_Run_F_Neut` (GoblinLocomotion) |
| `_attacks[0]` | `Swipe01` FSAttackData SO (custom -- zombie swipe clip) |
| `_attacks[1]` | `Swipe02` FSAttackData SO (custom -- zombie swipe clip) |
| Stagger (EnemyHealth `_hitClip`) | `Frank_FS3@Hit_High_F` (Frank Fighting Set 4) |
| Death (EnemyHealth `_deathClip`) | `Frank_FS3@KO_Mid_2` (Frank Fighting Set 4) |

**FaceDirection convention:** Synty Sidekick faces +Z by default. This matches the existing `FaceDirection()` in `FSEnemyBrain` (Y=90 -> +X/screen right, Y=-90 -> -X/screen left). No changes needed.

**Root motion:** All combat clips have both `_Neut` (in-place) and `_RM_Neut` (root motion) variants. Use in-place (`_Neut`) and let `FSEnemyBrain` control position directly (same as current approach with `_lockedPosition`).

---

## Known Gotchas

- **IK_foot_root / IK_hand_root:** Two extra bones beyond standard Mecanim humanoid. Don't delete them. Handle specially in Final IK VRIK setup.
- **FacialController is editor-only:** Any runtime facial expression system must drive blendshapes directly or use a separate Unity Animator layer.
- **Sidekick avatar vs Polygon avatar:** Each character has its own `-avatar.asset`. The `A_MOD_` clips are authored on the Sidekick rig. `A_POLY_` clips retarget via Mecanim. Animancer handles this automatically when the Animator has the correct avatar set.
- **No hit reaction in GoblinLocomotion:** Hit/stagger/death clips are in AnimationSwordCombat, not GoblinLocomotion. You need both packs for a complete enemy.
- **Apocalypse set textures:** Single color map texture per character. URP-compatible. No atlas sharing between characters.
- **`.sk` files:** Sidekick character database format used by the modular window. Not needed for prefab-based workflow.
