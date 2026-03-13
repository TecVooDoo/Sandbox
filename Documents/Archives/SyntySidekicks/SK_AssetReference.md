# SyntySidekicks - Asset Reference

| Field | Value |
|-------|-------|
| Sidekick Tool Version | 1.0.37 |
| Last Updated | 2026-02-26 |

---

## Character Packs Installed (18 categories, 50+ prefabs)

| Pack | Prefab Prefix | Count | Theme | Drop |
|------|---------------|-------|-------|------|
| Starter | Starter_* | 4 | Basic | Launch (free) |
| HumanSpecies | HumanSpecies_* | 4 | Base species | Launch |
| ElvenSpecies | ElvenSpecies_* | 2 | Base species | Drop 06 |
| ElvenWarriors | ElvenWarriors_* | 6 | Fantasy | Drop 06 |
| GoblinSpecies | GoblinSpecies_* | 5 | Base species | Launch |
| GoblinFighters | GoblinFighter_* | 5 | Fantasy | Launch |
| FantasyKnights | FantasyKnights_* | 6 | Fantasy | Drop 02 |
| FantasySkeletons | FantasySkeletons_* | 5 | Fantasy | Drop 05 |
| ApocalypseOutlaws | ApocalypseOutlaw_* | 5 | Apocalyptic | Launch |
| ApocalypseSurvivors | ApocalypseSurvivor_* | 5 | Apocalyptic | Launch |
| ApocalypseZombies | ApocalypseZombie_* | 5 | Apocalyptic | Launch |
| ModernCivilians | ModernCivilian_* | 2+ | Modern | -- |
| PirateCaptains | PirateCaptain_* | -- | Historical | Launch |
| SamuraiWarriors | SamuraiWarrior_* | -- | Historical | Drop 04 |
| ScifiCivilians | ScifiCivilian_* | -- | Sci-Fi | Drop 03 |
| ScifiRobots | ScifiRobot_* | -- | Sci-Fi | -- |
| ScifiSoldiers | ScifiSoldier_* | -- | Sci-Fi | Launch |
| VikingWarriors | VikingWarrior_* | -- | Historical | Drop 01 |

---

## Character Part Types (37 from CharacterPartType enum)

### Head Group (10)
Head, Hair, EyebrowLeft, EyebrowRight, EyeLeft, EyeRight, Nose, Teeth, Tongue, Wrap

### Ears & Facial (3)
EarLeft, EarRight, FacialHair

### Upper Body Group (7)
Torso, ArmUpperLeft, ArmUpperRight, ArmLowerLeft, ArmLowerRight, HandLeft, HandRight

### Lower Body Group (5)
Hips, LegLeft, LegRight, FootLeft, FootRight

### Attachments (14)
AttachmentHead, AttachmentFace, AttachmentBack, AttachmentHipsFront, AttachmentHipsBack, AttachmentHipsLeft, AttachmentHipsRight, AttachmentShoulderLeft, AttachmentShoulderRight, AttachmentElbowLeft, AttachmentElbowRight, AttachmentKneeLeft, AttachmentKneeRight

### Part Groups (PartGroup enum)
- **Head** = 1 -- Head parts + ears + facial hair
- **UpperBody** = 2 -- Torso through hands
- **LowerBody** = 3 -- Hips through feet

---

## Body Blend Shapes

| Blend Shape Name | Property | Range | Default |
|-----------------|----------|-------|---------|
| masculineFeminine | BodyTypeBlendValue | -100 to 100 | 50 |
| defaultSkinny | BodySizeSkinnyBlendValue | 0 to 100 | 0 |
| defaultHeavy | BodySizeHeavyBlendValue | 0 to 100 | 0 |
| defaultBuff | MusclesBlendValue | -100 to 100 | 50 |

---

## Facial Blend Shapes (40+, ARKit Compatible)

### Eyebrows (per eye)
Frown, Inner raise, Outer raise

### Eyes (per eye)
Up, Down, Left, Right, Blink, Squint, Wide

### Nose
Sneer (per nostril)

### Cheeks
Hollow, Puff

### Jaw
Open/Close, Left/Right, Forward/Back

### Mouth
Position, Funnel, Pucker, Shrug, Roll, Close, Smile/Frown, Press/Stretch, Upper Up

---

## Facial Animations

### Cycles (Looping)
Anger, Neutral, Sadness

### Poses (Static Expressions, 15)
Happy, Sad, Angry, Surprised, Scared, Disgusted, Enraged, Content, Delighted, Grumpy, In Pain, Neutral, Smug, Suspicious, Distraught

### Animator Layers
- **FaceAnim_NeutralCycle** -- Base layer with neutral idle
- **Emotion_Additive** -- Additive layer for expression blending

---

## Color System

### Color Groups (ColorGroup enum)
Species = 1, Outfits, Attachments, Materials, Elements

### Color Types (ColorType enum -- texture channels)
MainColor, Metallic, Smoothness, Reflection, Emission, Opacity

### Color Part Types (ColorPartType enum)
- Group: AllParts, Species, Outfit, Attachments, Materials, Elements
- Body groups: CharacterHead, CharacterUpperBody, CharacterLowerBody
- Individual: mirrors CharacterPartType values

### How Colors Work
- Each colorable attribute (SidekickColorProperty) has a name, ColorGroup, and UV coordinates (u, v)
- Colors are applied as 2x2 pixel blocks on texture maps at those UV positions
- 6 texture channels per color: Color, Metallic, Smoothness, Reflection, Emission, Opacity
- Colors stored as hex strings (e.g., "FF0000" for red)
- Color sets contain multiple color rows (one per property)
- Color presets provide themed combinations

---

## Mesh Naming Convention

```
SK_HUMN_BASE_01_01HEAD_HU01.fbx
│  │    │    │  │      │
│  │    │    │  │      └─ Species variant (HU = Human, 01 = variant)
│  │    │    │  └─ Part type shortcode (01HEAD, 10TORS, etc.)
│  │    │    └─ Variant number
│  │    └─ Part category
│  └─ Species code (HUMN, ELVN, GBLN, SKLT, etc.)
└─ Sidekick prefix
```

### Asset Naming Prefixes
| Prefix | Type |
|--------|------|
| A_ | Animation |
| AC_ | Animator Controller |
| M_ | Material |
| PF_ | Prefab |
| PM_ | Physics Material |
| SK_ | Skinned Mesh |
| SM_ | Static Mesh |
| T_ | Texture |

**Base model:** `SK_BaseModel.fbx` (Resources/Meshes/) -- shared skeleton rig for all characters
**Base material:** `M_BaseMaterial` (Resources/Materials/) -- shared material

---

## Demo Scenes (20)

### Runtime API Demos
| Scene | Purpose |
|-------|---------|
| Sidekick_RuntimePartsDemo | Programmatic part swapping |
| Sidekick_RuntimeColorDemo | Runtime color customization |
| Sidekick_RuntimePresetDemo | Applying saved presets |
| Sidekick_Facial_Demo | Facial expression animation |

### Character Pack Demos
| Scene | Pack |
|-------|------|
| Sidekick_Characters_Starter_Demo | Starter |
| Sidekick_Characters_ApocalypseOutlaws_Demo | Apocalypse Outlaws |
| Sidekick_Characters_ApocalypseSurvivors_Demo | Apocalypse Survivors |
| Sidekick_Characters_ApocalypseZombies_Demo | Apocalypse Zombies |
| Sidekick_Characters_ElvenWarriors_Demo | Elven Warriors |
| Sidekick_Characters_FantasyKnights_Demo | Fantasy Knights |
| Sidekick_Characters_FantasySkeletons_Demo | Fantasy Skeletons |
| Sidekick_Characters_GoblinFighters_Demo | Goblin Fighters |
| Sidekick_Characters_ModernCivilians_Demo | Modern Civilians |
| Sidekick_Characters_PirateCaptains_Demo | Pirate Captains |
| Sidekick_Characters_SamuraiWarriors_Demo | Samurai Warriors |
| Sidekick_Characters_ScifiCivilians_Demo | Sci-Fi Civilians |
| Sidekick_Characters_ScifiRobots_Demo | Sci-Fi Robots |
| Sidekick_Characters_ScifiSoldiers_Demo | Sci-Fi Soldiers |
| Sidekick_Characters_VikingWarriors_Demo | Viking Warriors |

---

## Pre-Built Characters

Each pack folder in `Characters/` contains per-variant:
- Character prefab (.prefab) with Animator + SkinnedMeshRenderer
- Associated .sk save file
- Meshes/, Materials/, Textures/ subdirectories

All characters share:
- `SK_BaseModel` skeleton rig
- `M_BaseMaterial` base material
- Humanoid avatar (Mecanim compatible)
- IK target bones (ik_hand_l/r, ik_foot_l/r, ik_hand_gun)
- Attachment bones (hipAttach, shoulderAttach, kneeAttach, etc.)
- Prop bones (prop_l, prop_r inside hand bones)

---

## Synty Animation Packs (6)

| Pack | Location | Content |
|------|----------|---------|
| Base Locomotion | Assets/Synty/AnimationBaseLocomotion/ | Core humanoid movement (walk, run, strafe, jump, etc.) |
| Bow Combat | Assets/Synty/AnimationBowCombat/ | Ranged combat (draw, aim, fire, reload, etc.) |
| Emotes and Taunts | Assets/Synty/AnimationEmotesAndTaunts/ | Social animations (wave, dance, taunt, etc.) |
| Goblin Locomotion | Assets/Synty/AnimationGoblinLocomotion/ | Goblin-specific movement (smaller skeleton) |
| Idles | Assets/Synty/AnimationIdles/ | Idle variations (standing, sitting, fidget, etc.) |
| Sword Combat | Assets/Synty/AnimationSwordCombat/ | Melee combat (swing, block, combo, etc.) |

All Synty animation packs are designed for the Humanoid rig and work with Sidekick characters via Mecanim retargeting.

## Synty Tools

| Tool | Location | Purpose |
|------|----------|---------|
| SyntyPropBoneTool | Assets/Synty/Tools/SyntyPropBoneTool/ | Prop/weapon attachment to character bones |

---

## Third-Party Asset Packages (in Assets folder, not Package Manager)

| Asset | Location | Purpose |
|-------|----------|---------|
| Final IK + Baker | Assets/Plugins/RootMotion/ | Full-body IK, look-at, FABRIK, Baker for animation baking |
| DOTween Pro | Assets/Plugins/Demigiant/ | Tweening engine |
| Odin Inspector | Assets/Plugins/Sirenix/ | Advanced inspector/serialization |
| Text Animator | Assets/Plugins/Febucci/ | Animated text effects |
| Timeflow | Assets/Plugins/Timeflow/ | Timeline animation system |
| Magica Cloth 2 | Assets/MagicaCloth2/ | Cloth/hair physics simulation |
| UMotion Pro | Assets/UMotionEditor/ + Assets/UMotionExamples/ | In-editor animation authoring |
| Ultimate Selector | Assets/Malbers Animations/Ultimate Selector/ | Selection system (eval) |
| Malbers Common | Assets/Malbers Animations/Common/ | Malbers scripting framework (Input, Scripts, Shaders) |
| Advanced Dissolve | Assets/Amazing Assets/Advanced Dissolve/ | Dissolve shader effects |
| Amplify Shader Editor | Assets/AmplifyShaderEditor/ | Visual shader authoring |
| Amplify Shader Pack | Assets/AmplifyShaderPack/ | Pre-built shader collection |
| Mesh Optimizer | Assets/Mesh Optimizer/ | Mesh optimization/LOD |
| UDebug Panel | Assets/DebugPanel/ | Runtime debug UI |
| Curve Master | Assets/CurveMaster/ | Animation curve editor |
| Animation Path Visualizer | Assets/AnimationPathVisualizer/ | Animation path debugging |
| Default Playables | Assets/UnityTechnologies/DefaultPlayables/ | Timeline playable templates |
| Ultimate Preview | Assets/Voxel Labs/Ultimate Preview/ | Asset preview window |
| Audio Preview Tool | Assets/WarpedImagination/AudioPreviewTool/ | Audio workflow |
| Wingman | Assets/Wingman/ | Editor assistant |
| vFavorites/vFolders/vHierarchy | Assets/vFavorites/, vFolders/, vHierarchy/ | Editor organization |
| Markdown for Unity | Assets/Plugins/MarkdownViewer/ | In-editor markdown rendering |
