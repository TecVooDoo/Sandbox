# SyntyAssets — Status

**Version:** 1.2 | **Updated:** 2026-02-17

## Purpose

Asset evaluation and learning hub for Synty Studios packages.

- Evaluate individual Synty packs — verdict, content notes, integration patterns
- Learn Synty conventions (material setup, prefab structure, PNB shader, atlas workflow)
- Stage and export tested setups to production projects (HOK, future projects)

**Active Production Project:** Hooked on Kharon → `E:/Unity/HookedOnKharon`
**Sandbox Reference:** `E:/Unity/Sandbox/Documents` (visible in workspace sidebar)

---

## Pack Inventory

**78 packs installed** across 4 series.

| Series | Count | Evaluated | Approved | Conditional | Rejected |
|--------|-------|-----------|----------|-------------|----------|
| Polygon | 47 | 8 | 0 | 8 | 0 |
| PolygonMini | 4 | 0 | 0 | 0 | 0 |
| Simple | 19 | 0 | 0 | 0 | 0 |
| Other | 8 | 1 | 0 | 1 | 0 |
| **Total** | **78** | **9** | **0** | **9** | **0** |

---

## Evaluation Queue

*(Add packs here when ready to evaluate — move to AssetLog when done)*

| Priority | Pack | Reason |
|----------|------|--------|
| — | — | — |

---

## Sessions

### Session 3 — 2026-02-17 | Kharon Sidekick + Weapon Lineup

**Goal:** Replace on-duty Carny placeholder with SidekickCharacters custom Kharon; stage all weapon/rod options for comparison.

**Packs touched:** SidekickCharacters, PolygonHorrorMansion (Count mask), PolygonDungeonRealms (staffs), PolygonAncientEmpire (scythe), PolygonFarm (scythe), PolygonFantasyCharacters (staffs)

**Results:**
- On-duty body replaced: Wizard robe → Carny placeholder → **Sidekick "Kharon"** custom character (has better customization options, built-in IK bones, attachment points)
- Sidekick bone naming differs from Polygon series: lowercase (hand_l, head, pelvis) with dedicated prop_l/prop_r and headAttach/faceAttach bones
- 6 GanzSe fishing rod types placed on hand_r with _Grip wrappers (all hidden, toggle to compare)
- 3 scythes + 8 staffs placed on hand_l with _Grip wrappers (HorrorMansion scythe active)
- Skull scaled up to ~1.68x and hood to ~1.25x by user for better fit on Sidekick head
- SM_Prop_Mask_Count_01 (HorrorMansion) instantiated as backup mask option
- Mixamo sitting animation downloaded and applied — works but seat height mismatch requires Y offset adjustment; IK foot bones available for future knee adjustment
- Grip wrapper pattern established: empty GameObject with grip transform on hand bone, weapon mesh as child at local origin — enables swapping weapons by toggling wrappers

**Scene:** Assets/Scenes/HOK/HOK.unity

---

### Session 2 — 2026-02-17 | Kharon Character Proof of Concept

**Goal:** Build two-state Kharon character (on-duty grim reaper / off-duty fisherman) using Synty cross-pack parts plus GanzSe fishing rod.

**Packs touched:** PolygonHorrorCarnival, PolygonDungeonRealms, PolygonFantasyCharacters, PolygonTown, PolygonExplorers, PolygonFarm, PolygonStreetRacer

**Results:**
- On-duty: Character_Male_Wizard (FantasyCharacters) + SM_Chr_Attach_Hood_01 (DungeonRealms, parented to Head bone) + SM_Chr_Attach_Undead_Knight_Skull_01 (DungeonRealms, full skull head replacement) standing on SM_Prop_Cooler_01 (PolygonTown)
- Off-duty: SM_Chr_Carny_01 skin on HorrorCarnival Slim rig + SM_Chr_Attach_Beard_01 (PolygonExplorers) on Head bone + GanzSe FP_FishingRodComplite_Type1 parented to Hand_R
- GanzSe rod confirmed compatible with HorrorCarnival rig (both world scale 1); localScale ~(0.65, 0.65, 0.80) for natural grip
- Key discovery: FantasyCharacters Root bone uses 0.01 scale; HorrorCarnival uses 1.0 — see Lessons Learned #3 and #4

**Scene:** Assets/Scenes/HOK/HOK.unity

---

### Session 1 — 2026-02-17 | Project Setup

- Installed Unity-MCP v0.47.0 + AI ProBuilder v1.0.24 via OpenUPM
- Configured MCP stdio transport (port 57871); do NOT click Start in Unity — Connect only
- Created document system: Status, AssetLog, Archives
- Workspace file created to expose Sandbox Documents in VS Code sidebar
- Note: E: drive is exFAT — Windows junctions not supported; use workspace folders instead

---

## Integration Patterns

*(Populate as patterns are learned per session)*

| Pattern | Notes | Source Pack |
|---------|-------|-------------|
| Showcase prefab | Single prefab holds multiple character skins as disabled SkinnedMeshRenderers on one shared rig; toggle activeSelf to switch skin | HorrorCarnival, FantasyCharacters, StreetRacer |
| Static mesh attachment | Synty `SM_Chr_Attach_*` prefabs are MeshFilter+MeshRenderer (not SkinnedMesh); parent directly to target bone, set localPosition/Rotation as needed | DungeonRealms, Explorers |
| Root bone scale 0.01 | Some packs (FantasyCharacters) export at 100x scale with Root bone at localScale 0.01; static attachments parented to bones in these rigs must set localScale=(100,100,100) to appear at world scale 1 | FantasyCharacters |
| Root bone scale 1.0 | Other packs (HorrorCarnival) use standard world scale; no counterscale needed for attachments | HorrorCarnival |
| Cross-pack rig compatibility | All Polygon series characters share the same humanoid bone naming (Root/Hips/Spine_01-03/Neck/Head, Hand_L/R, etc.); attachments from any pack fit any Polygon rig | DungeonRealms → HorrorCarnival |
| GanzSe rod on Synty hand | FP_FishingRodComplite parented to Hand_R bone; localScale ~(0.65, 0.65, 0.80) for natural grip on Slim rig | HorrorCarnival + GanzSe |
| Grip wrapper pattern | Empty GameObject with grip transform parented to hand bone; weapon mesh as child at local origin; toggle wrapper activeSelf to swap weapons without repositioning each one | Session 3 |
| Sidekick bone naming | SidekickCharacters uses lowercase bones (hand_l, head, pelvis) with dedicated attachment bones (prop_l/r, headAttach, faceAttach, hipAttach, backAttach) — differs from Polygon PascalCase convention | SidekickCharacters |
| Sidekick IK bones | Built-in ik_foot_l/r and ik_hand_l/r bones under root — need Animation Rigging or OnAnimatorIK to activate | SidekickCharacters |
| Mixamo animation retargeting | Download Mixamo FBX "Without Skin"; set Rig to Humanoid in Unity; Humanoid retargeting maps bones automatically regardless of naming convention | Session 3 |

---

## Lessons Learned

*(Numbered, added as discovered)*

| # | Lesson |
|---|--------|
| 1 | E: drive is exFAT — NTFS junctions/symlinks not supported; use .code-workspace multi-folder instead |
| 2 | Unity MCP: use Connect only (not Start) — Start switches to HTTP; VS Code stdio handles server launch |
| 3 | Synty root bone scale varies by pack: HorrorCarnival=1.0, FantasyCharacters=0.01 (centimeter-space FBX export) |
| 4 | Static mesh attachments parented to a 0.01-scale rig bone are invisible (1% size); fix with localScale=(100,100,100) |
| 5 | Synty `SM_Chr_Attach_*` prefabs are static meshes, not SkinnedMeshRenderers — they follow bones as rigid children, no bone binding needed |
| 6 | SM_Chr_Attach_Undead_Knight_Skull_01 is a full skull head replacement, not a face mask — the character's own head mesh shows through underneath |
| 7 | GanzSe Fantasy Fishing Props ships with a URP extras package (in Render Pipeline Extras folder) — must be extracted separately for correct URP materials |
| 8 | No standalone fishing rod exists in any of the 78 Synty packs; fisherman character rods are baked into the character mesh |
| 9 | SidekickCharacters uses different bone naming from Polygon series (lowercase, different hierarchy); attachments from Polygon packs work but may need position adjustment |
| 10 | Mixamo sitting animations assume standard chair height (~45cm); shorter seats like coolers require lowering the character root Y and potentially IK adjustment for feet |
| 11 | Grip wrapper pattern: parent an empty to the hand bone with the grip transform, then child the weapon at local origin — all weapons sharing the same wrapper transform can be swapped by toggling the wrapper |

---

## Installed Packages

**Unity Registry**
- ProBuilder 6.0.8
- URP 17.3.0 + ShaderGraph 17.3.0
- Cinemachine 3.1.5, Input System 1.18.0, AI Navigation 2.0.10
- Timeline 1.8.10, Visual Scripting 1.9.9

**OpenUPM**
- com.ivanmurzak.unity.mcp 0.47.0
- com.ivanmurzak.unity.mcp.probuilder 1.0.24

**Local**
- com.cysharp.unitask (file: E:/Unity/DefaultUnityPackages/com.cysharp.unitask)
