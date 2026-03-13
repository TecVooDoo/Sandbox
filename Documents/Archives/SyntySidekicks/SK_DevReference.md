# SyntySidekicks - Dev Reference

| Field | Value |
|-------|-------|
| Last Updated | 2026-02-27 |

---

## Project Structure

```
Assets/
  _Project/
    Characters/
      HOK/               -- Kharon, Merchants, Souls, Shades
      FearSteez/         -- Player, Enemies, Bosses
      _Shared/           -- Shared character assets
    Exports/
      HOK/               -- .unitypackage exports for HookedOnKharon
      FearSteez/         -- .unitypackage exports for FearSteez
    Scripts/             -- Project-specific scripts
    Scenes/              -- Project-specific scenes
  Synty/
    SidekickCharacters/
      _Demos/            -- 20 demo scenes + scripts
      Scripts/
        Editor/          -- ModularCharacterWindow, PartTypeControls, ToolDownloader, etc.
        Runtime/         -- SidekickRuntime, DatabaseManager, Combiner, etc.
      Characters/        -- Pre-built character prefabs + .sk save files (50+)
      Database/          -- Side_Kick_Data.db (SQLite, 2.3MB)
      Animations/        -- Facial animation clips (cycles + poses)
      Resources/         -- Base meshes, materials, shaders, UI
      Plugins/           -- unity-sqlite-net-1.2.4
      Documentation/     -- SidekickCharacters_UserGuide.pdf
    SyntyPackageHelper/  -- Synty editor utilities
  PolygonDarkFantasy/    -- Non-Sidekick Synty pack (static meshes, materials)
  Scenes/                -- Project scenes (SidekickStage)
  Settings/              -- URP settings
Documents/               -- Project documentation (this folder)
```

---

## Installed Packages (Full List)

### Asset Store
| Package | Version | Use For |
|---------|---------|---------|
| Advanced Dissolve | 2025.4 | Shader effects |
| Amplify Shader Editor | 1.9.9.8 | Shader authoring |
| Animation Path Visualizer | 2.0.0 | Animation debugging |
| Audio Preview Tool | 1.1.0 | Audio workflow |
| Curve Master | 1.2.2 | Animation curves |
| Default Playables | 1.9 | Timeline playables |
| DOTween Pro | 1.0.410 | Tweening/animation |
| Fullscreen Editor | 2.2.10 | Editor workflow |
| Markdown for Unity | 1.0.0 | In-editor markdown |
| Mesh Optimizer | 1.1 | Mesh optimization |
| Odin Inspector and Serializer | 4.0.1.3 | Inspector/serialization |
| RNGNeeds - Probability Distribution | 1.0.0 | Random/probability |
| Scriptable Sheets | 1.8.0 | Data management |
| Text Animator for Unity | 3.1.1 | UI text effects |
| UDebug Panel | 1.3.3 | Debug tools |
| Ultimate Preview Window - Pro | 1.3.1 | Asset preview |
| vFavorites 2 | 2.0.14 | Editor workflow |
| vFolders 2 | 2.1.12 | Project organization |
| vHierarchy 2 | 2.1.7 | Hierarchy organization |
| Wingman | 1.2.3 | Editor assistant |
| Final IK | 2.4 | Full-body IK system (RootMotion) |
| Amplify Shader Pack | 2.3.9-r2 | Shader collection |
| Animancer Pro | 8.2.3 | State-based animation (Kybernetik) |
| Magica Cloth 2 | 2.17.1 | Cloth/hair physics simulation |
| Timeflow Animation System | 1.10.0 | Animation timeline (Axon Genesis) |
| UMotion Pro - Animation Editor | 1.29p04 | In-editor animation authoring |
| Ultimate Selector | 3.4.8 | Selection system |

### Custom/Local
| Package | Version | Source |
|---------|---------|--------|
| TecVooDoo Utilities | 1.0.0 | Local |
| UniTask | 2.5.10 | Local (Cysharp) |
| LWS Scriptable Sheets | 1.8.0 | Custom |
| RNGNeeds | 1.0.0 | Custom (Starphase Lab) |
| Starphase Core | 0.1.2 | Custom (Starphase Lab) |

### Ivan Murzak MCP
| Package | Version |
|---------|---------|
| AI Game Developer (Unity MCP) | 0.50.1 |
| AI Animation | 1.0.32 |
| AI Particle System | 1.0.20 |
| AI ProBuilder | 1.0.32 |
| PlayerPrefsEx | 2.1.2 |

### Unity (Key Packages)
| Package | Version |
|---------|---------|
| AI Navigation | 2.0.9 |
| Animation Rigging | 1.4.1 |
| Burst | 1.8.27 |
| Cinemachine | 3.1.6 |
| Input System | 1.18.0 |
| Mathematics | 1.3.3 |
| ProBuilder | 6.0.8 |
| Shader Graph | 17.3.0 |
| Splines | 2.8.2 |
| Timeline | 1.8.11 |
| URP | 17.3.0 |
| Visual Scripting | 1.9.9 |

---

## Character Prefab Hierarchy

```
CharacterRoot [Animator]
  mesh [SkinnedMeshRenderer]
  root
    ik_foot_root                    ← IK targets (independent of FK skeleton)
      ik_foot_l                     ← Foot IK target (terrain adaptation)
      ik_foot_r
    ik_hand_root
      ik_hand_gun                   ← Two-handed weapon grip parent
        ik_hand_l                   ← Hand IK target (grab points, weapon holds)
        ik_hand_r
    pelvis                          ← FK skeleton starts here
      hipAttach_l/r/Back/Front      ← Hip attachment points
      spine_01
        spine_02
          spine_03
            neck_01
              head                  ← Head + face bones
            clavicle_l/r
              upperarm_l/r
                lowerarm_l/r
                  hand_l/r          ← Actual hand bones
                    index/middle/pinky/ring/thumb_01  ← Fingers
                    prop_l/r        ← Held object attachment points
      thigh_l/r
        calf_l/r
          foot_l/r
            ball_l/r
```

### IK vs FK Bones
- **IK bones** (`ik_*`) sit at root level, separate from the skeleton. They're Mecanim humanoid IK targets used with `Animator.SetIKPosition/Rotation()`.
- **`ik_hand_gun`** parents both hand IK targets -- move it to position both hands for two-handed weapon grips.
- **`prop_l` / `prop_r`** inside `hand_l/r` are for attaching held objects directly to hands.
- **Attachment bones** (`hipAttach_*`, `shoulderAttach_*`, `kneeAttach_*`, etc.) are constraint targets for equipment.

---

## Sidekick System Architecture

### Core Runtime Scripts

| Script | Purpose |
|--------|---------|
| SidekickRuntime.cs | Main API: part selection, blend shapes, colors, mesh combining, serialization |
| DatabaseManager.cs | SQLite connection management (path: `Assets/Synty/SidekickCharacters/Database/Side_Kick_Data.db`) |
| Combiner.cs | Merges multiple SkinnedMeshRenderers into one optimized mesh |
| FacialController.cs | Real-time facial expression control (40+ blend shapes, Editor-only) |
| BlendShapeUtils.cs | Blend shape frame extraction/restoration |
| BlendshapeJointAdjustment.cs | Hardcoded Vector3 offsets for Feminine/Heavy/Skinny/Bulk blend shapes |
| MeshUtils.cs | Deep mesh copying with all UV/normal/weight data |
| PartUtils.cs | Part name parsing (IsBaseSpeciesPart) |
| CharacterPartTypeUtils.cs | Part type shortcode conversion, tooltips |

### Editor Scripts

| Script | Purpose |
|--------|---------|
| ModularCharacterWindow.cs | Main editor UI (Synty > Sidekick Character Tool) |
| PartTypeControls.cs | Part selection dropdown + nav buttons |
| MenuBootstrapController.cs | Auto-opens window on first load |
| ToolDownloader.cs | Downloads/updates tool from GitHub releases |
| DatabaseUpdateController.cs | Deprecated (empty class kept for compatibility) |

### Filter System

| Class | Purpose |
|-------|---------|
| FilterGroup.cs | Combines filter items with And/Or/Not logic |
| FilterItem.cs | Wraps a SidekickPartFilter with cached results |
| PresetFilterItem.cs | Wraps a SidekickPresetFilter with cached results |
| ParsedPart.cs | Parses part filenames into species/outfit/area components |

### Data Layer (SQLite - 24 Tables)

| Table | DTO Class | Purpose |
|-------|-----------|---------|
| sk_species | SidekickSpecies | Character species (name, code) |
| sk_species_image | SidekickSpeciesImage | Species preview images |
| sk_part | SidekickPart | Individual parts (type, group, file location, file_exists) |
| sk_part_image | SidekickPartImage | Part preview images |
| sk_part_filter | SidekickPartFilter | Filters (Species, Outfit, PartType) |
| sk_part_filter_row | SidekickPartFilterRow | Filter-to-part junction table |
| sk_part_preset | SidekickPartPreset | Outfit presets by PartGroup |
| sk_part_preset_row | SidekickPartPresetRow | Parts composing each preset |
| sk_part_preset_image | SidekickPartPresetImage | Preset preview images |
| sk_part_species_link | SidekickPartSpeciesLink | Which parts available for which species |
| sk_color_set | SidekickColorSet | Color palettes (paths to 6 texture maps) |
| sk_color_row | SidekickColorRow | Individual colors within a set (hex strings) |
| sk_color_property | SidekickColorProperty | Colorable attributes (name, UV coords, ColorGroup) |
| sk_color_preset | SidekickColorPreset | Themed color schemes |
| sk_color_preset_row | SidekickColorPresetRow | Colors within a preset |
| sk_color_preset_image | SidekickColorPresetImage | Color preset images |
| sk_color_filter | SidekickColorFilter | Color filter definitions |
| sk_body_shape_preset | SidekickBodyShapePreset | Body shape presets (bodyType, bodySize, musculature) |
| sk_body_shape_preset_image | SidekickBodyShapePresetImage | Body shape images |
| sk_preset_filter | SidekickPresetFilter | Outfit preset filters |
| sk_preset_filter_row | SidekickPresetFilterRow | Preset-to-filter junction |
| sk_blend_shape_rig_movement | SidekickBlendShapeRigMovement | Bone offsets per blend shape type |
| sk_pmdata | SidekickPartMetaData | Extensible part metadata |
| sk_vdata | SidekickDBVersion | Database version (currently 1.0.2) |

### Serialization (.sk files)

Characters save/load via `.sk` files containing:
- Character name, Species ID
- Selected parts list (SerializedPart: name, type, version)
- Color set (SerializedColorSet: species, name, texture paths)
- Color rows (SerializedColorRow: property + 6 hex color channels)
- Blend shape values (SerializedBlendShapeValues: bodyType=50, bodySize=0, muscle=50 defaults)

---

## Runtime API Quick Reference

### Constructor
```csharp
new SidekickRuntime(baseModel, material, animController?, dbManager?)
```

### Loading Data
```csharp
await SidekickRuntime.PopulateToolData(runtime);  // Loads parts + presets
runtime.LoadPartLibrary();                          // Parts only
runtime.PopulatePresetLibrary();                    // Presets only
```

### Creating Characters
```csharp
// From individual parts
runtime.CreateCharacter(name, List<SkinnedMeshRenderer>, combineMesh, processBoneMovement, existingModel?)
// Uncombined (separate meshes)
runtime.CreateModelFromParts(parts, name, existingModel?)
```

### Body Customization
```csharp
runtime.BodyTypeBlendValue = 50f;        // -100 (feminine) to 100 (masculine)
runtime.BodySizeSkinnyBlendValue = 0f;   // 0 to 100
runtime.BodySizeHeavyBlendValue = 0f;    // 0 to 100
runtime.MusclesBlendValue = 50f;         // -100 (lean) to 100 (buff)
runtime.UpdateBlendShapes(model);
runtime.ProcessBoneMovement(model);
```

### Colors
```csharp
runtime.UpdateColor(ColorType.MainColor, colorRow);
runtime.UpdateTexture(texture, color, u, v);
runtime.PopulateUVDictionary(usedParts);
```

### Data Access
```csharp
runtime.MappedPartDictionary           // Parts by type, then by name
runtime.AllPartsLibrary                // All parts by type
runtime.MappedBasePartDictionary       // Base parts by species then type
runtime.MappedPresetFilterDictionary   // Presets by filter
runtime.MappedBasePresetDictionary     // Presets by species
runtime.FilterPartDictionary           // Filtered parts
runtime.PartOutfitMap                  // Parts grouped by outfit
runtime.CurrentSpecies                 // Active species
runtime.PartCount                      // Total loaded parts
```

---

## Character Creation Approaches

### 1. Editor Window (Manual)
- Menu: Synty > Sidekick Character Tool
- Full GUI: species selection, part browsing, color picking, blend shape sliders
- Save/load .sk files, export to prefab

### 2. Runtime API (Programmatic)
- `SidekickRuntime` class for all operations
- Part swapping, color application, blend shape manipulation
- Mesh combining for performance
- Character serialization/deserialization
- **Note:** Synty describes this as "currently a highly technical solution"
- **Limitation:** Body blend functionality for saving characters for in-game use is NOT yet part of the system

### 3. MCP Tools (AI-Assisted)
- Use `script-execute` to call SidekickRuntime API
- GameObject/component tools for scene manipulation
- Asset tools for prefab creation
- Screenshot tools for visual verification

### 4. Direct Part Loading (MCP Workaround)
When SidekickRuntime namespace fails in Roslyn, use direct Resources.Load:
```csharp
// 1. Instantiate base model
var baseModel = Resources.Load<GameObject>("Meshes/SK_BaseModel");
var character = Object.Instantiate(baseModel);

// 2. Remove 24 default SK_SPEC_ parts
foreach (Transform child in character.transform)
    if (child.name.StartsWith("SK_SPEC_")) Object.DestroyImmediate(child.gameObject);

// 3. Build bone lookup from skeleton
var boneMap = new Dictionary<string, Transform>();
foreach (var t in character.GetComponentsInChildren<Transform>())
    boneMap[t.name] = t;

// 4. Load and attach parts
var partPrefab = Resources.Load<GameObject>("Meshes/Outfits/ModernCivilians/SK_MDRN_CIVL_05_10TORS_HU01");
var smr = partPrefab.GetComponentInChildren<SkinnedMeshRenderer>();
var partGO = new GameObject(partPrefab.name);
partGO.transform.SetParent(character.transform);
var newSMR = partGO.AddComponent<SkinnedMeshRenderer>();
newSMR.sharedMesh = smr.sharedMesh;
newSMR.rootBone = boneMap["root"];

// 5. Remap bones
var newBones = new Transform[smr.bones.Length];
for (int i = 0; i < smr.bones.Length; i++)
    if (smr.bones[i] != null && boneMap.ContainsKey(smr.bones[i].name))
        newBones[i] = boneMap[smr.bones[i].name];
newSMR.bones = newBones;

// 6. Material: use Sidekick_ShaderGraph (NOT M_BaseMaterial)
newSMR.sharedMaterial = existingCharacterMaterial; // from Sidekick-created character
```

---

## Cross-Pack Asset Mixing

Non-Sidekick Synty packs (e.g., PolygonDarkFantasy) can be mixed with Sidekick characters:

### Static Mesh Attachments (SM_ prefix)
- Parent to attachment bones: `headAttach`, `hipAttach_*`, `shoulderAttach_*`, `prop_l/r`, etc.
- **Scale is 1:1** between Polygon packs and Sidekick characters
- **Y offset** = negative of mesh bounds center Y to seat on bone (e.g., hat with bounds center Y=0.20 needs localY=-0.2)
- Materials coexist fine (URP/Lit alongside Sidekick_ShaderGraph)
- Attachment bones are regular Transforms — **scaling works** (unlike skinned parts)

### Attachment Types Comparison
| Type | Examples | Renderer | Scale Works? | How to Attach |
|------|----------|----------|-------------|---------------|
| Skinned attachment (SK_) | 22AHED, 23AFAC parts | SkinnedMeshRenderer | No (bone-weighted) | Bone remapping to skeleton |
| Static attachment (SM_) | SM_Chr_Attach_* | MeshRenderer | Yes | Parent to attachment bone |
| Attachment bones | headAttach, prop_l/r | Transform only | Yes | Parent objects here |

### Tested Combinations
- PolygonDarkFantasy `SM_Chr_Attach_Gravedigger_Hat_01` on Sidekick Human → headAttach, localY=-0.2, scale 1.0

---

## Render Pipeline Compatibility

| Pipeline | Status |
|----------|--------|
| Built-in | Compatible |
| URP | Compatible (current project) |
| HDRP | **NOT compatible** |

---

## Animation System

### Skeleton
- Unity Humanoid (Mecanim) rig based on `SK_BaseModel.fbx`
- Fully retargetable with any Humanoid-compatible animations
- Mixamo animations work but require retargeting setup

### Facial Animation
- 40+ individual blend shapes (ARKit compatible)
- Animator layers: `FaceAnim_NeutralCycle` (base) + `Emotion_Additive` (expressions)
- 15 emotion poses + 3 looping cycles
- Controlled via `Animator.CrossFadeInFixedTime()` on emotion layer

### Dynamic Joints
- Physics-driven secondary motion (capes, hair, beards)
- Uses uniVRM Springbone integration
- Naming convention identifies dynamic joint bones

### Constraints (Attachment Meshes)
- Aim Constraint, Look At Constraint, Parent Constraint
- Position Constraint, Rotation Constraint, Scale Constraint
- Used for equipment attachment points

---

## Blender Mesh Editing Workflow

Sidekick FBX parts can be edited in Blender for customization the tool doesn't support (e.g., scaling hoods/masks, reshaping geometry). No source files are provided — the FBX files ARE the source.

**Steps:**
1. Open the FBX from `Resources/Meshes/Outfits/<pack>/` or `Resources/Meshes/Species/<species>/` in Blender
2. Edit the mesh (scale, reshape, add geometry, etc.)
3. Export back as FBX (to same location for override, or `_Project/` for custom variant)
4. Unity reimports automatically; mesh works with Sidekick rig

**Rules to preserve compatibility:**
- Do NOT rename or delete bones
- Keep vertex groups (bone weights) intact
- Do NOT change UV layout (colors applied via UV coordinates will break)
- Blend shapes survive if vertex count/order is preserved

**Why this matters:** SkinnedMeshRenderer parts ignore Transform.scale in Unity because vertices are positioned by bone weights. Blender is the only way to resize individual attachments.

---

## Known Limitations

1. HDRP not supported
2. Body blend shapes cannot be saved/baked for in-game use yet (planned)
3. Runtime API is "highly technical" -- not plug-and-play
4. Custom parts not recommended (compatibility risk with updates)
5. Some colors on some parts are preset and unchangeable
6. Species-specific part restrictions (not all parts fit all species)
7. Must delete previous install before updating tool versions
8. Combined mesh bone references don't survive save/reload (all 2116 bones become NULL) — delete `mesh` child or use combineMesh:false
9. SkinnedMeshRenderer parts ignore Transform.scale — must edit mesh in Blender to resize attachments

---

## Synty Asset Search Tools

| Tool | Access | Notes |
|------|--------|-------|
| SyntyDex | dex.syntystore.com | Official WebGL browser app — search/filter all Synty assets. Not scriptable. |
| Synty Prefab Search v1.4 | Assets/editor/SyntyStore_Search/ | Community Unity editor tool — offline search of local Synty packages. Menu: Tools > Synty Prefab Search |

---

## Synty GitHub Resources

| Repo | URL | Purpose |
|------|-----|---------|
| SidekicksToolRelease | github.com/SyntyStudios/SidekicksToolRelease | Release channel (v1.0.37 latest) |
| SidekicksToolReleaseDev | github.com/SyntyStudios/SidekicksToolReleaseDev | Dev channel (v1.0.38) |
| synty-store-importer-unity | github.com/SyntyStudios/synty-store-importer-unity | Batch import tool |

---

## Tool Version History (Drops)

| Drop | Content | Key Tool Feature |
|------|---------|-----------------|
| Launch | 1,400+ parts, 4 themes | Character Creator tool |
| Drop 01 | Viking Warriors | **Runtime API** added |
| Drop 02 | -- | Unity 6 preprocessors, WebGL SQLite support |
| Drop 03 | Sci-Fi Civilians | Part filtering by theme |
| Drop 04 | Samurai Warriors | Randomize + Lock buttons per part group |
| Drop 05 | Fantasy Skeletons | QoL improvements |
| Drop 06 | Elven Warriors | Preset filtering, Shader Graph switch, speed improvements |
| v1.0.37 | Robots added to DB | Misc fixes |

---

## Coding Conventions

- Follow existing Synty namespace patterns when extending
- Use SidekickRuntime API rather than direct mesh/material manipulation
- Query SQLite database via DatabaseManager for part/color/species data
- Save characters via .sk serialization format for portability
- Combine meshes via Combiner for runtime performance
- **Prefer installed packages** (DOTween, UniTask, Odin, Animation Rigging, etc.) over custom solutions
- Colors stored as hex strings (RGB), parsed via `ColorUtility.TryParseHtmlString`
- FK pointer pattern: `PtrX` (int) + `[Ignore] X` property for navigation
