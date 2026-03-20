# Sandbox - Asset Evaluation Log

**Purpose:** Track every asset, package, and technique evaluated in Sandbox. This is the primary document for the project.

**Last Updated:** March 16, 2026 (AQS Session 7 -- merged 4 Sandbox2D evals)

> **NOTE:** This document was reconstructed on Feb 23, 2026 after the Sandbox project became corrupt and the Documents folder was lost. The summary table (all 135 entries) has been fully recovered from session context. Detailed ENTRY blocks for entries 001-115 are pending recovery from session JSONL at `C:\Users\steph\.claude\projects\e--Unity-Sandbox\99250266-b660-4ea0-88f0-61e5b98f52e1.jsonl`. Entries 116-135 (Session 35 UI Toolkit batch) are summarized in the session transcript.

---

## How to Use This Document

Every asset tested in Sandbox gets an entry here. Entries are never deleted - failed evaluations are just as valuable as successful ones.

### Three-Dimension Lookup

For any asset, three independent questions can be answered:

| Question | Where to Look | Not Listed Means |
|----------|--------------|-----------------|
| Asset evaluated? | Summary Table + ENTRY block below | Not yet evaluated |
| MCP tool candidate? | **MCP Candidates** section (end of doc) | Not yet evaluated for MCP |
| TecVooDoo Utilities candidate? | **TecVooDoo Utilities Candidates** section (end of doc) | Not a candidate or not yet evaluated |

### Entry Lifecycle

1. **Add entry** when you start evaluating an asset (status: Testing)
2. **Update verdict** when evaluation is complete
3. **Add notes** about quirks, performance, integration cost
4. **Assign Asset Store label** (Default, Default 3D, Don't Use, etc.)

### Asset Store Labels

Labels are applied in two tiers: **Primary** (when to use) + **Secondary** (what domain). Filter by Primary to decide imports, filter by Secondary to find specific tools.

#### Primary Labels (project scope)

| Label | Meaning |
|-------|---------|
| **Default** | Include in every project, regardless of type. The bar is high: you would be wrong not to include it. General-purpose QoL tools, universal systems (audio, async, inspector), and things every developer reaches for repeatedly. |
| **Recommended** | Best-in-class for a given domain. Dynamic -- loses this label when a better option arrives. Only one winner per domain slot at a time. Import for a project when that domain is relevant. |
| **Don't Use** | Beyond redemption: broken, bad quality, or thoroughly superseded. Also applies to assets absorbed into TecVooDoo Utilities. NOT for assets removed from Sandbox to make room for the next eval batch. |
| *(no label)* | Evaluated and works (or is Conditional/Deferred). Situational: not universally applicable, not currently best-in-class in a competed slot. Import when the specific need arises. |

#### Secondary Labels (functional domain)

| Label | Meaning |
|-------|---------|
| **Animation** | Animation systems, IK, tweening, motion clips, sequencers |
| **Art** | Pure content packs -- models, textures, environments (no significant code) |
| **Character** | Character controllers, character rigs, character art |
| **Low Poly** | Low-poly art style assets (used alongside Art or other secondary labels) |
| **Mesh** | Mesh editing, deformation, sculpting, optimization, LOD tools |
| **Shader** | Shader authoring, shader packs, visual material effects |
| **Environment** | Water, terrain, sky, foliage, lighting, atmospheric effects |
| **Physics** | Cloth, destruction, rope, fluid, soft-body simulation |
| **AI** | Pathfinding, navigation, behavior systems |
| **VFX** | Particle effects, volumetric effects, runtime visual FX |
| **Text** | Text animation, text rendering, markdown, rich text tools |
| **QoL** | Unity Editor quality-of-life tools (hierarchy, folders, inspector, debug) |

### Cross-Reference: Three Evaluation Dimensions

Any asset can be checked across three independent dimensions:

| Dimension | Where to Look | "Not Listed" Means |
|-----------|--------------|-------------------|
| **Asset Eval** | Summary Table + Detailed Entries (this doc) | Not yet evaluated |
| **MCP Candidate** | MCP Candidates section (end of doc) | Not yet evaluated for MCP use |
| **TecVooDoo Utilities Candidate** | TecVooDoo Utilities Candidates section (end of doc) | Not a utilities candidate |

### Evaluation Focus

Evaluate assets for ANY TecVooDoo project, not just HOK. Key questions:
- **Asset Interactions:** Does it integrate with or conflict with other evaluated assets?
- **Claude Capability:** What can Claude set up via code/MCP vs what requires manual Unity work?
- **Replacement:** Does this asset supersede or get superseded by another?

### Verdict Definitions

| Verdict | Meaning |
|---------|---------|
| **Approved** | Works well, recommended for use in target project |
| **Conditional** | Works but has caveats (performance, compatibility, workflow) |
| **Rejected** | Does not meet requirements or has blocking issues |
| **Testing** | Evaluation in progress |
| **Deferred** | Not tested yet, queued for future evaluation |

---

## Summary Table

Quick-reference of all evaluations. See detailed entries below for full notes.

| # | Asset | Source | Category | Verdict | Label | Date |
|---|-------|--------|----------|---------|-------|------|
| 001 | Malbers Inventory System | Asset Store | UI / Inventory | Conditional | -- | 2026-03-14 |
| 002 | Procedural Generation Grid (FImpossible Creations) | Asset Store | Tools | Rejected | -- | 2026-02-06 |
| 003 | vHierarchy 2 | Asset Store | Tools | Approved | Default | 2026-02-06 |
| 004 | vFolders 2 | Asset Store | Tools | Approved | Default | 2026-02-06 |
| 005 | vFavorites 2 | Asset Store | Tools | Approved | Default | 2026-02-06 |
| 006 | Ultimate Preview Window - Pro Edition | Asset Store | Tools | Approved | Default | 2026-02-06 |
| 007 | Unity Utility Library (Git Amend) | GitHub | Tools | Conditional | -- | 2026-02-06 |
| 008 | Hierarchy Designer | Asset Store | Tools | Rejected | Don't Use | 2026-02-06 |
| 009 | Folder System (Gaskellgames) | Asset Store | Tools | Rejected | Don't Use | 2026-02-06 |
| 010 | Visual Console | Asset Store | Tools | Rejected | Don't Use | 2026-02-06 |
| 011 | Runtime Debugger Toolkit | Asset Store | Tools | Rejected | Don't Use | 2026-02-06 |
| 012 | Backbone Logger | Asset Store | Tools | Conditional | -- | 2026-02-06 |
| 013 | UDebug Panel | Asset Store | Tools | Approved | Default | 2026-02-06 |
| 014 | Code Monkey Toolkit | Asset Store | Tools | Conditional | -- | 2026-02-06 |
| 015 | Fullscreen Editor | Asset Store | Tools | Approved | Default | 2026-02-06 |
| 016 | Scripts Vault - Free | Asset Store | Tools | Rejected | Don't Use | 2026-02-06 |
| 017 | RNGNeeds - Probability Distribution | Asset Store | Tools | Conditional | -- | 2026-02-06 |
| 018 | Scriptable Sheets | Asset Store | Tools | Approved | Default | 2026-02-06 |
| 019 | Improved Timers (Git Amend) | GitHub | Tools | Conditional | -- | 2026-02-06 |
| 020 | Wingman | Asset Store | Tools | Approved | Default | 2026-02-07 |
| 021 | Init(args) | Asset Store | Tools | Rejected | Don't Use | 2026-02-07 |
| 022 | DevTrails | Asset Store | Tools | Conditional | -- | 2026-02-07 |
| 023 | Binding System 2 | Asset Store | Tools | Rejected | Don't Use | 2026-02-07 |
| 024 | Prefab World Builder (PluginMaster) | Asset Store | Tools / Level Design | Approved | Recommended | 2026-02-07 (re-eval 2026-03-05) |
| 025 | UniTask (Cysharp) | GitHub | Tools | Approved | Default | 2026-02-07 |
| 026 | UModeler X Plus | Asset Store | Tools | Approved | Recommended | 2026-02-07 |
| 027 | DA PolyPaint - Atlas Color Mapper | Asset Store | Tools | Conditional | -- | 2026-02-07 |
| 028 | Malbers Animal Controller (AC) 4.5.1 | Asset Store | Animation / Character | Approved | Recommended | 2026-03-14 |
| 029 | Ultimate Selector 3.4.8 (Malbers) | Asset Store | UI | Approved | -- | 2026-03-14 |
| 030 | Fishing for Animal Controller | Asset Store | Other | Approved | -- | 2026-02-07 |
| 031 | Poly Art: Raccoon 4.0 (Malbers) | Asset Store | Animation / Art | Approved | -- | 2026-03-14 |
| 032 | Horse Animset Pro 4.5.1 (Riding System) | Asset Store | Animation / Character | Approved | -- | 2026-03-14 |
| 033 | Fish Alive - Animated Polyart Fish | Asset Store | Animation / AI | Approved | -- | 2026-02-07 |
| 034 | GanzSe Fantasy Low Poly Fishing Props | Asset Store | Art | Approved | -- | 2026-02-07 |
| 035 | Poly Universal Pack | Asset Store | Art | Approved | -- | 2026-02-07 |
| 036 | Low Poly Animated Animals 4.1.1 (polyperfect) | Asset Store | Animation / Art | Approved | Art | 2026-03-14 |
| 037 | Low Poly Animated People (polyperfect) | Asset Store | Animation / Art | Approved | -- | 2026-02-07 |
| 038 | City People Mega-Pack | Asset Store | Animation / Art | Approved | -- | 2026-02-07 |
| 039 | Stylized Water 3 (Staggart Creations) | Asset Store | Rendering | Approved | Recommended | 2026-02-07 |
| 040 | Dynamic Effects for SW3 (Staggart Creations) | Asset Store | Rendering | Approved | Recommended | 2026-02-07 |
| 041 | Underwater Rendering for SW3 (Staggart Creations) | Asset Store | Rendering | Approved | Recommended | 2026-02-07 |
| 042 | Ripple Shader Pack (Eldvmo) | Asset Store | Rendering | Rejected | Don't Use | 2026-02-08 |
| 043 | Environment / Weather / Nature VFX Pack (Kripto289) | Asset Store | VFX | Conditional | -- | 2026-02-08 |
| 044 | Low Poly Modular Terrain Pack (JustCreate) | Asset Store | Art | Approved | -- | 2026-02-08 |
| 045 | River Modeler (Staggart Creations) | Asset Store | Tools | Approved | -- | 2026-02-08 |
| 046 | Low Poly Rocks Pack (JustCreate) | Asset Store | Art | Approved | -- | 2026-02-08 |
| 047 | Free Low Poly - Raft on the Desert (EmaceArt) | Asset Store | Art | Conditional | -- | 2026-02-09 |
| 048 | Raft Builder Kit | Asset Store | Art | Conditional | -- | 2026-02-09 |
| 049 | Blaze AI Engine (Pathiral) | Asset Store | AI | Deferred | -- | 2026-02-09 |
| 050 | Unity-Theme (IvanMurzak) | GitHub | UI | Approved | Default | 2026-02-11 |
| 051 | Unity-ImageLoader (IvanMurzak) | GitHub | UI | Approved | Default | 2026-02-11 |
| 052 | Unity-AI-Animation (IvanMurzak) | OpenUPM | Tools (MCP Ext) | Approved | Default | 2026-02-11 |
| 053 | Unity-AI-ParticleSystem (IvanMurzak) | OpenUPM | VFX (MCP Ext) | Approved | Default | 2026-02-11 |
| 054 | Unity-Package-Template (IvanMurzak) | GitHub | Tools (Dev) | Deferred | -- | 2026-02-11 |
| 055 | Unity-AI-ProBuilder (IvanMurzak) | OpenUPM | Tools (MCP Ext) | Approved | Default | 2026-02-11 |
| 056 | MCP for Unity / AI Game Developer (IvanMurzak) | OpenUPM | Tools | Approved | Default | 2026-02-11 |
| 057 | Unity-AI-Tools-Template (IvanMurzak) | GitHub | Tools (Dev) | Deferred | -- | 2026-02-11 |
| 058 | Unity-EFCore-SQLite (IvanMurzak) | OpenUPM | Data | Deferred | -- | 2026-02-11 |
| 059 | Unity-PlayerPrefsEx (IvanMurzak) | OpenUPM | Data | Conditional | -- | 2026-02-11 |
| 060 | Unity-Extensions (IvanMurzak) | npm | Tools (Utility) | Rejected | Don't Use | 2026-02-11 |
| 061 | Unity-AudioLoader (IvanMurzak) | OpenUPM | Audio | Conditional | -- | 2026-02-11 |
| 062 | Unity-AI-Meshy (IvanMurzak) | OpenUPM | Tools (MCP Ext) | Deferred | -- | 2026-02-11 |
| 063 | MCP-Plugin-dotnet (IvanMurzak) | GitHub/NuGet | AI / MCP | Deferred | -- | 2026-02-11 |
| 064 | UBuilder (IvanMurzak) | OpenUPM | Tools (Build) | Deferred | -- | 2026-02-11 |
| 065 | NuGetForUnity (GlitchEnzo) | GitHub/OpenUPM | Tools (Package Mgmt) | Rejected | Don't Use | 2026-02-12 |
| 066 | Unity Toon Shader (Unity-Technologies) | GitHub | Rendering | Testing | -- | 2026-02-12 |
| 067 | BuildReportInspector (Unity-Technologies) | GitHub | Tools (Build) | Testing | -- | 2026-02-12 |
| 068 | ML-Agents (Unity-Technologies) | GitHub/Registry | AI | Conditional | -- | 2026-02-12 |
| 069 | BoatAttack (Unity-Technologies) | GitHub | Rendering (Reference) | Deferred | -- | 2026-02-12 |
| 070 | PaddleGameSO (UnityTechnologies) | GitHub | Architecture (Reference) | Deferred | -- | 2026-02-12 |
| 071 | Game Programming Patterns (UnityTechnologies) | GitHub | Architecture (Reference) | Deferred | -- | 2026-02-12 |
| 072 | Sentis Samples (Unity-Technologies) | GitHub | AI (Reference) | Deferred | -- | 2026-02-12 |
| 073 | ZString (Cysharp) | GitHub | Tools (Performance) | Deferred | -- | 2026-02-12 |
| 074 | R3 (Cysharp) | GitHub | Architecture (Reactive) | Deferred | -- | 2026-02-12 |
| 075 | MemoryPack (Cysharp) | GitHub | Data (Serialization) | Deferred | -- | 2026-02-12 |
| 076 | ZLinq (Cysharp) | GitHub | Tools (Performance) | Deferred | -- | 2026-02-12 |
| 077 | MessagePipe (Cysharp) | GitHub | Architecture (Messaging) | Deferred | -- | 2026-02-12 |
| 078 | ObservableCollections (Cysharp) | GitHub | UI (Data Binding) | Deferred | -- | 2026-02-12 |
| 079 | MasterMemory (Cysharp) | GitHub | Data (Database) | Deferred | -- | 2026-02-12 |
| 080 | UnitGenerator (Cysharp) | GitHub | Tools (Code Gen) | Deferred | -- | 2026-02-12 |
| 081 | StructureOfArraysGenerator (Cysharp) | GitHub | Tools (Performance) | Deferred | -- | 2026-02-12 |
| 082 | CsprojModifier (Cysharp) | GitHub | Tools (IDE) | Deferred | -- | 2026-02-12 |
| 083 | Simple Boids / #NVJOB Boids (NVJOB) | Asset Store | AI (Boids) | Rejected | -- | 2026-02-13 |
| 084 | Mesh Extractor (Kamgam) | Asset Store | Tools (Mesh Editing) | Approved | Recommended | 2026-02-17 |
| 085 | Make Mesh Double-Sided (Kamgam) | Asset Store | Tools (Mesh Editing) | Approved | Recommended | 2026-02-17 |
| 086 | Mesh Smoother (Kamgam) | Asset Store | Tools (Mesh Editing) | Approved | Recommended | 2026-02-17 |
| 087 | Polygon Material Painter (Kamgam) | Asset Store | Tools (Mesh Editing) | Approved | Recommended | 2026-02-17 |
| 088 | UV Editor (Kamgam) | Asset Store | Tools (Mesh Editing) | Approved | Recommended | 2026-02-17 |
| 089 | Animancer Pro v8 (Kybernetik) | Asset Store | Animation | Approved | Recommended | 2026-02-18 |
| 090 | Final IK (RootMotion) | Asset Store | Animation (IK) | Approved | Recommended | 2026-02-18 |
| 091 | UMotion Pro - Animation Editor (Soxware) | Asset Store | Animation (Authoring) | Approved | Recommended | 2026-02-18 |
| 092 | IK Helper Tool (Kevin Iglesias) | Asset Store | Animation (IK) | Rejected | Don't Use | 2026-02-18 |
| 093 | Human Crafting Animations (Kevin Iglesias) | Asset Store | Animation (Clips) | Approved | -- | 2026-02-18 |
| 094 | Human Basic Motions (Kevin Iglesias) | Asset Store | Animation (Clips) | Approved | -- | 2026-02-18 |
| 095 | Magica Cloth 2 (Magica Soft) | Asset Store | Physics (Cloth Sim) | Approved | Recommended | 2026-02-20 |
| 096 | Full Sail (Chris West) | Asset Store | VFX (Sail Simulation) | Conditional | -- | 2026-02-20 |
| 097 | Dynamic Bone (Will Hong) | Asset Store | Physics (Bone Sim) | Rejected | Don't Use | 2026-02-20 |
| 098 | All In 1 3D Shader (Seaside Studio) | Asset Store | Shader (Multi-Effect) | Approved | -- | 2026-02-20 |
| 099 | Character Creator Framework (TelePresent) | Asset Store | Character (Customization) | Rejected | Don't Use | 2026-02-20 |
| 100 | Timeflow Animation System (Axon Genesis) | Asset Store | Animation (Sequencer) | Conditional | -- | 2026-02-21 |
| 101 | Koreographer Professional (Sonic Bloom) | Asset Store | Audio (Music Sync) | Approved | Recommended | 2026-02-21 |
| 102 | Audio Preview Tool (Warped Imagination) | Asset Store | Editor Tool (Audio QoL) | Approved | Default | 2026-02-21 |
| 103 | Master Audio 2024 (DarkTonic) | Asset Store | Audio (Complete System) | Approved | Default | 2026-02-21 |
| 104 | Audio Manager (Krayzborn Assets) | Asset Store | Audio (Simple Manager) | Rejected | Don't Use | 2026-02-21 |
| 105 | Native Audio (Exceed7 Experiments) | Asset Store | Audio (Low-Latency) | Conditional | -- | 2026-02-21 |
| 106 | Default Playables (Unity Technologies) | Asset Store | Animation (Timeline) | Approved | Default | 2026-02-21 |
| 107 | Animation Path Visualizer (JulesGilli) | Asset Store | Editor Tool (Anim Debug) | Approved | Default | 2026-02-21 |
| 108 | Curve Master (Yan-K / NekoLab) | Asset Store | Editor Tool (Curve Editor) | Approved | Default | 2026-02-21 |
| 109 | Odin Inspector and Serializer (Sirenix) | Asset Store | Tools (Inspector/Serialization) | Approved | Default | 2026-02-21 |
| 110 | Odin Validator (Sirenix) | Asset Store | Tools (Validation) | Approved | Default | 2026-02-21 |
| 111 | DOTween Pro (Demigiant) | Asset Store | Animation (Tweening) | Approved | Default | 2026-02-21 |
| 112 | Chunity: ChucK for Unity (Stanford CCRMA) | Asset Store | Audio (Procedural Synthesis) | Conditional | -- | 2026-02-21 |
| 113 | FMOD for Unity (FMOD) | Asset Store | Audio (Complete Middleware) | Conditional | -- | 2026-02-21 |
| 114 | Universal Sound Manager Lite (Kitler Dev) | Asset Store | Audio (Simple Manager) | Rejected | Don't Use | 2026-02-21 |
| 115 | DryWetMIDI (Melanchall) | Asset Store | Audio (MIDI Data/Devices) | Approved | Recommended | 2026-02-21 |
| 116 | UI Toolkit Text Animation 2 (Kamgam) | Asset Store | UI (Text Effects) | Approved | Default UI | 2026-02-22 |
| 117 | Text Animator for Unity (Febucci) | Asset Store | UI (Text Effects) | Approved | Default | 2026-02-22 |
| 118 | UI Toolkit Blurred Background (Kamgam) | Asset Store | UI (Visual Polish) | Approved | Default UI | 2026-02-22 |
| 119 | UI Toolkit Shadows, Outlines & Glow (Kamgam) | Asset Store | UI (Visual Polish) | Approved | Default UI | 2026-02-22 |
| 120 | UI Toolkit Particles (Kamgam) | Asset Store | UI (Visual Polish) | Approved | Default UI | 2026-02-22 |
| 121 | UI Toolkit Custom Shader Image URP (Kamgam) | Asset Store | UI (Shader Effects) | Approved | Default UI | 2026-02-22 |
| 122 | UI Toolkit Scroll View Pro (Kamgam) | Asset Store | UI (Layout/UX) | Approved | Default UI | 2026-02-22 |
| 123 | UI Toolkit Text Auto Size (Kamgam) | Asset Store | UI (Layout/UX) | Approved | Default UI | 2026-02-22 |
| 124 | UI Toolkit World Image (Kamgam) | Asset Store | UI (3D Integration) | Conditional | -- | 2026-02-22 |
| 125 | UI Toolkit Sound Effects (Kamgam) | Asset Store | UI (Audio Integration) | Approved | Default UI | 2026-02-22 |
| 126 | UI Toolkit Script Components (Kamgam) | Asset Store | UI (Framework) | Approved | Default UI | 2026-02-22 |
| 127 | UGS Friends Sample (Unity) | Asset Store | UI (Social/Networking) | Conditional | -- | 2026-02-22 |
| 128 | Fortune Wheel for UI Toolkit (StillHumanMedia) | Asset Store | UI (Game Mechanic) | Conditional | -- | 2026-02-22 |
| 129 | GDS - Inventory for UI Toolkit | Asset Store | UI (Game System) | Approved | -- | 2026-02-22 |
| 130 | Toolkit for On-Screen Keyboard 2026 (Heathen) | Asset Store | UI (Input) | Conditional | -- | 2026-02-22 |
| 131 | Toolkit for UX 2026 (Heathen) | Asset Store | UI (UX Framework) | Approved | Default UI | 2026-02-22 |
| 132 | UIToolkit Theme Style Sheet (Denis535) | Asset Store | UI (Theming) | Conditional | -- | 2026-02-22 |
| 133 | Settings & Options Menu Creator - Lite (CitrioN) | Asset Store | UI (Settings) | Approved | -- | 2026-02-22 |
| 134 | Flow UI Toolkit Extended (SABI) | Asset Store | UI (Fluent API) | Approved | Default UI | 2026-02-22 |
| 135 | Markdown for Unity (TJIN) | Asset Store | Editor Tool (Documentation) | Approved | Default | 2026-02-22 |
| 136 | MegaFiers 2 (Chris West) | Asset Store | Tools (Mesh Deformation) | Approved | -- | 2026-02-24 |
| 137 | Mega Shapes (Chris West) | Asset Store | Tools (Spline/Loft Geometry) | Approved | -- | 2026-02-24 |
| 138 | MegaBook 2 (Chris West) | Asset Store | Tools (Book/Page System) | Approved | -- | 2026-02-24 |
| 139 | Vulcan (Chris West) | Asset Store | VFX (Procedural Flame Mesh) | Conditional | -- | 2026-02-24 |
| 140 | Full Rig (Chris West) | Asset Store | Physics (Rope/Catenary Simulation) | Approved | -- | 2026-02-24 |
| 141 | Mega Cache (Chris West) | Asset Store | Tools (Mesh/Particle/PointCloud Caching) | Approved | -- | 2026-02-24 |
| 142 | Texture Studio (Chris West) | Asset Store | Tools (GPU Texture Compositing) | Approved | -- | 2026-02-24 |
| 143 | Mega Flow (Chris West) | Asset Store | Tools (3D Vector Field / Flow Simulation) | Approved | -- | 2026-02-24 |
| 144 | Mega Scatter (Chris West) | Asset Store | Tools (Spline-Based Procedural Placement) | Approved | -- | 2026-02-24 |
| 145 | Mega Wires (Chris West) | Asset Store | Tools (Dynamic Wire/Cable Physics) | Approved | -- | 2026-02-24 |
| 096-R | Full Sail (Chris West) | Asset Store | VFX (Sail Simulation) | Conditional | -- | 2026-02-24 |
| 146 | MudBun (Long Bunny Labs) | Asset Store | Tools (Volumetric SDF Modeling/VFX) | Approved | -- | 2026-02-24 |
| 147 | Runtime Transform Gizmos (Octamodius) | Asset Store | Tools (Runtime Transform Handles) | Approved | -- | 2026-02-24 |
| 148 | Fluffy Grooming Tool (Daniel Zeller) | Asset Store | Tools (Fur/Hair Grooming & Rendering) | Approved | -- | 2026-02-24 |
| 149 | Runtime Transform Handles (Battlehub) | Asset Store | Tools (Runtime Transform Handles) | Approved | -- | 2026-02-24 |
| 150 | Mesh Optimizer (IndieChest) | Asset Store | Tools (Mesh Decimation / LOD Generation) | Approved | Recommended | 2026-02-24 |
| 151 | Decal Collider (Occlusionn) | Asset Store | Tools (Runtime Mesh & Collision Decals) | Approved | -- | 2026-02-24 |
| 152 | EditorSculpt (htomioka) | Asset Store | Editor Tool (Mesh Sculpting / Texture Paint) | Approved | Recommended | 2026-02-24 |
| 153 | Deform (Beans) | Asset Store | Tools (Runtime Mesh Deformation Framework) | Approved | Recommended | 2026-02-24 |
| 154 | Realistic Mesh Deformation (BoneCracker Games) | Asset Store | Tools (Collision-Based Mesh Deformation) | Rejected | Don't Use | 2026-02-24 |
| 155 | Curved World (Amazing Assets) | Asset Store | Shaders (Vertex Displacement / World Bending) | Approved | -- | 2026-02-24 |
| 156 | Advanced Dissolve (Amazing Assets) | Asset Store | Shaders (Dissolve / Cutout / Geometric Slicing) | Approved | Recommended | 2026-02-24 |
| 157 | Lattice Modifier (Harry Heath) | Asset Store | Tools (GPU Lattice / FFD Mesh Deformation) | Approved | Recommended | 2026-02-24 |
| 158 | Amplify Shader Editor (Amplify Creations) | Asset Store | Editor Tool (Node-Based Shader Authoring) | Approved | Recommended | 2026-02-24 |
| 159 | Amplify Shader Pack (Amplify Creations) | Asset Store | Shaders (Multi-Pipeline Shader Library) | Approved | Recommended | 2026-02-24 |
| 160 | Street Props - Barricades (Amplify Creations) | Asset Store | 3D Models (Street Furniture / Traffic Props) | Approved | -- | 2026-02-24 |
| 161 | Amplify Impostors (Amplify Creations) | Asset Store | Tools (Impostor/Billboard LOD Generation) | Approved | -- | 2026-02-24 |
| 162 | Amplify LUT Pack (Amplify Creations) | Asset Store | Textures (Color Grading LUT Library) | Rejected | Don't Use | 2026-02-24 |
| 163 | Lighting Box 2 (ALIyerEdon) | Asset Store | Editor Tool (Lighting/Post-Processing Preset System) | Rejected | Don't Use | 2026-02-24 |
| 164 | A* Pathfinding Project Pro (Aron Granberg) | Asset Store | AI (Pathfinding / Navigation / Local Avoidance) | Approved | Recommended | 2026-02-24 |
| 165 | Ultimate Character Controller (Opsive) | Asset Store | Framework (Character Controller / Ability System) | Approved | Recommended | 2026-02-24 |
| 166 | Beat 'Em Up - Game Template 3D (Osarion) | Asset Store | Game Template (Complete Beat 'Em Up Framework) | Approved | -- | 2026-02-25 |
| 167 | Frank Slash Pack - 11 Assets (Frank climax) | Asset Store | Animation (Multi-Weapon Combat Animation Library) | Approved | -- | 2026-02-25 |
| 168 | RayFire 2 (RayFire Studios) | Asset Store | Tool (Runtime Destruction/Demolition System) | Approved | Recommended | 2026-02-27 |
| 169 | Inventory Framework 2 FREE (Game Dev Simplified) | Asset Store | Framework (UI Toolkit Inventory System) | Approved | Recommended | 2026-02-27 |
| 170 | Ghost Effect Shader (OccaSoftware) | Asset Store | Shader (Transparency / Shader Graph) | Approved | Recommended | 2026-02-28 |
| 171 | Responsive Smokes (OccaSoftware) | Asset Store | VFX (Interactive Volumetric Smoke) | Approved | Recommended | 2026-02-28 |
| 172 | Opaque Water Shader (OccaSoftware) | Asset Store | Shader (Stylized Water / Shader Graph) | Conditional | -- | 2026-02-28 |
| 173 | Triplanar Shader (OccaSoftware) | Asset Store | Shader (Triplanar Mapping / Shader Graph) | Approved | Recommended | 2026-02-28 |
| 174 | 150 Realistic Textures (OccaSoftware) | Asset Store | Art (PBR Texture Library) | Approved | -- | 2026-02-28 |
| 175 | Low Poly Fantasy Village (OccaSoftware) | Asset Store | Art (Low-Poly Environment Pack) | Approved | Art, Low Poly | 2026-02-28 |
| 176 | Crosshairs (OccaSoftware) | Asset Store | Art / UI (Crosshair Texture Pack) | Approved | -- | 2026-02-28 |
| 177 | Crosshairs Pro (OccaSoftware) | Asset Store | Art / UI (Crosshair Texture Pack - Extended) | Approved | -- | 2026-02-28 |
| 178 | Texture Channel Packer (OccaSoftware) | Asset Store | Editor Tool (RGBA Channel Packing) | Approved | Recommended | 2026-02-28 |
| 179 | Local Global Illumination (OccaSoftware) | Asset Store | Shader (Fake GI Post-Process) | Rejected | Don't Use | 2026-02-28 |
| 180 | OccaSoftware Bundle - Megapack (OccaSoftware) | Asset Store | Bundle (Readme Unlock Only) | Approved | -- | 2026-02-28 |
| 181 | Altos v7.17.0 (OccaSoftware) | Packages/ UPM | Shader / Environment (Sky + Clouds + Weather) | Approved | Recommended | 2026-02-28 |
| 182 | Buto v7.11.6 (OccaSoftware) | Packages/ UPM | Shader / Environment (Volumetric Fog + Lighting) | Approved | Recommended | 2026-02-28 |
| 183 | Super Simple Sky v5.0.0 (OccaSoftware) | Packages/ UPM | Shader / Environment (Procedural Skybox) | Approved | -- | 2026-02-28 |
| 184 | Dynamic Cloud Shadows v2.1.0 (OccaSoftware) | Packages/ UPM | Shader / Environment (Cloud Shadow Projector) | Approved | -- | 2026-02-28 |
| 185 | LSPP v3.3.1 (OccaSoftware) | Packages/ UPM | Shader / Environment (God Rays / Volumetric Lighting) | Approved | Recommended | 2026-02-28 |
| 186 | Better Bloom v0.2.0 (OccaSoftware) | Packages/ UPM | Shader (Post-Process Bloom) | Conditional | -- | 2026-02-28 |
| 187 | Auto Exposure v3.2.2 (OccaSoftware) | Packages/ UPM | Shader (Post-Process Auto Exposure) | Approved | -- | 2026-02-28 |
| 188 | Motion Blur v3.2.1 (OccaSoftware) | Packages/ UPM | Shader (Post-Process Motion Blur) | Conditional | -- | 2026-02-28 |
| 189 | HazeFX v0.5.2 (OccaSoftware) | Packages/ UPM | Shader (Post-Process Heat / Haze Distortion) | Approved | -- | 2026-02-28 |
| 190 | Gaussian Blur v3.0.1 (OccaSoftware) | Packages/ UPM | Shader (Screen / Object / UI Blur) | Approved | Recommended | 2026-02-28 |
| 191 | Outlines Post-Process v1.1.1 (OccaSoftware) | Packages/ UPM | Shader (Post-Process Edge Outline) | Approved | -- | 2026-02-28 |
| 192 | Radial Blur v3.0.0 (OccaSoftware) | Packages/ UPM | Shader (Post-Process Radial Blur) | Approved | -- | 2026-02-28 |
| 193 | Negative Space v1.0.0 (OccaSoftware) | Packages/ UPM | Shader (Post-Process Color Inversion) | Conditional | -- | 2026-02-28 |
| 194 | Ascii Shader v3.5.0 (OccaSoftware) | Packages/ UPM | Shader (Post-Process ASCII / Pixelizer) | Conditional | -- | 2026-02-28 |
| 195 | Toon Kit 2 v2.3.0 (OccaSoftware) | Packages/ UPM | Shader (Cel / Toon Shading System) | Approved | Recommended | 2026-02-28 |
| 196 | Ultimate Lit Shader v3.5.2 (OccaSoftware) | Packages/ UPM | Shader (Custom PBR Lit Material Blend) | Approved | -- | 2026-02-28 |
| 197 | Fluff Grass v2.1.0 (OccaSoftware) | Packages/ UPM | Shader / Environment (Interactive Stylized Grass) | Approved | Recommended | 2026-02-28 |
| 198 | LCD Shader v2.0.0 (OccaSoftware) | Packages/ UPM | Shader (Pixel / Moire / LCD Effect) | Approved | -- | 2026-02-28 |
| 199 | Wireframe Shader v2.0.2 (OccaSoftware) | Packages/ UPM | Shader (Wireframe Overlay / Geometry) | Rejected | Don't Use | 2026-02-28 |
| 200 | Outline Objects v3.1.18 (OccaSoftware) | Packages/ UPM | Shader (Per-Mesh Stencil Outline) | Approved | Recommended | 2026-02-28 |
| 201 | Deep Surfaces v0.1.0 (OccaSoftware) | Packages/ UPM | Shader (Volumetric Parallax / Gem / Ice) | Approved | -- | 2026-02-28 |
| 202 | VFX Library v3.0.0 (OccaSoftware) | Packages/ UPM | VFX (Environmental Ambient FX Collection) | Approved | Recommended | 2026-02-28 |
| 203 | Ballistics v2.0.0 (OccaSoftware) | Packages/ UPM | Scripting (Physics Projectile / Bullet Drop) | Approved | -- | 2026-02-28 |
| 204 | Orbit Camera v0.1.2 (OccaSoftware) | Packages/ UPM | Scripting (Orbit / Inspection Camera) | Conditional | -- | 2026-02-28 |
| 205 | Free Fly Camera v0.1.0 (OccaSoftware) | Packages/ UPM | Scripting (Drone / Fly Camera Controller) | Conditional | -- | 2026-02-28 |
| 206 | Ninja Profiler v1.1.0 (OccaSoftware) | Packages/ UPM | Editor Tool (Runtime Performance Overlay) | Approved | Default | 2026-02-28 |
| 207 | Toolkit for Verlet Motion 2026 (Heathen) | Packages/ UPM | Physics (Transform-Chain Cloth/Rope/Chain) | Approved | Recommended | 2026-02-28 |
| 208 | Toolkit for Ballistics 2026 (Heathen) | Packages/ UPM | Scripting (Trajectory/Projectile Physics) | Approved | Recommended | 2026-02-28 |
| 209 | Toolkit for Unity Physics 2026 (Heathen) | Packages/ UPM | Physics (Buoyancy/Force Fields/Destruction) | Approved | Recommended | 2026-02-28 |
| 210 | Toolkit for Steamworks 2026 (Heathen) | Packages/ UPM | Scripting (Steam Platform Integration SDK) | Approved | Recommended | 2026-02-28 |
| 211 | Toolkit for Discord Social Preview (Heathen) | Packages/ UPM | Scripting (Discord Social Layer SDK) | Conditional | -- | 2026-02-28 |
| 212 | UX Flat Icons [Free] (Heathen) | Asset Store | Art (UI Icon Pack -- 304 icons) | Approved | Recommended | 2026-02-28 |
| 213 | Toolkits for Unity Bundle 2026 (Heathen) | Asset Store | Bundle (Purchase Unlock Only) | Approved | -- | 2026-02-28 |
| 214 | Dialogue System for Unity 2.2.66 (Pixel Crushers) | Asset Store | Scripting (Dialogue / Narrative Framework) | Approved | Recommended | 2026-02-28 |
| 215 | Dialogue System Addon - Procedural Dialogue 1.0.5 (Pixel Crushers) | Asset Store | Scripting (Procedural Text Generation Add-On) | Approved | -- | 2026-02-28 |
| 216 | Ragdoll Animator 2 1.0.4.1 (FImpossible Creations) | Asset Store | Physics (Physically-Animated Ragdoll Blending) | Approved | Recommended | 2026-02-28 |
| 217 | F Texture Tools 1.1.5 (FImpossible Creations) | Asset Store | Editor Tool (Texture Processing Suite) | Approved | Default | 2026-02-28 |
| 218 | Ground Fitter 1.2.2 (FImpossible Creations) | Asset Store | Scripting (Terrain Slope Alignment System) | Approved | -- | 2026-02-28 |
| 219 | FS Melee Combat System 2.0.6 (Fantacode Studios) | Asset Store | Scripting (Third-Person Melee Combat Framework) | Approved | -- | 2026-02-28 |
| 220 | FS Rope Swinging System 1.2.4 (Fantacode Studios) | Asset Store | Scripting (Grapple / Rope Swing Controller) | Approved | -- | 2026-02-28 |
| 221 | FS Shooter System 1.2 (Fantacode Studios) | Asset Store | Scripting (Third/First-Person Shooter Framework) | Approved | -- | 2026-02-28 |
| 222 | Fish Alive Freshwater Set 1.2 (Denys Almaral) | Asset Store | Animation / AI (Freshwater Fish Swim Simulation) | Approved | -- | 2026-02-28 |
| 223 | Fish Alive Marine Set 1.2 (Denys Almaral) | Asset Store | Animation / AI (Marine Fish Swim Simulation) | Approved | -- | 2026-02-28 |
| 224 | PuppetMaster 1.4 (RootMotion) | Asset Store | Physics (Muscle-Based Physics Puppet System) | Approved | Recommended | 2026-02-28 |
| 225 | Body Poser 1.4 (Revolving Gear Studios) | Asset Store | Editor Tool (Humanoid Pose Editor / Scene Dressing) | Approved | -- | 2026-02-28 |
| 226 | Flexalon 3D Layouts 4.4.1 (Virtual Maker) | Asset Store | Scripting (3D + UI Layout System) | Approved | Recommended | 2026-02-28 |
| 227 | Aline 1.7.9 (Aron Granberg) | Packages/ UPM | Editor Tool (In-Game Debug Drawing / Gizmos) | Approved | Default | 2026-02-28 |
| 228 | Photon PUN 2+ 2.5.2 (Exit Games) | Asset Store | Scripting (Online Multiplayer Networking SDK) | Approved | Recommended | 2026-02-28 |
| 229 | Behavior Designer Pro 2.1.12 (Opsive) | Packages/ UPM | AI (DOTS-Based Behavior Tree System) | Approved | Recommended | 2026-02-28 |
| 230 | Senses Pack for Behavior Designer 1.0.3 (Opsive) | Asset Store | AI (Sensory Perception Add-On for BD) | Conditional | -- | 2026-02-28 |
| 231 | SensorToolkit2 2.5.17 (Micosmo Games) | Asset Store | AI (Detection Sensors + Velocity Obstacle Steering) | Approved | Recommended | 2026-02-28 |
| 232 | Interactor 0.999b (Nega Games) | Asset Store | Scripting (Full-Body IK Interaction System) | Conditional | -- | 2026-02-28 |
| 233 | PlayMaker 1.9.9f1 (Hutong Games) | Asset Store | Scripting (Visual FSM Scripting System) | Approved | Recommended | 2026-03-02 |
| 234 | UI Toolkit Playmaker Integration 1.3.0 (Kamgam) | Asset Store | Scripting (UIT/Playmaker Bridge) | Approved | -- | 2026-03-02 |
| 235 | Damage Numbers Pro 4.5.1 (Ekin Cantas) | Asset Store | VFX (Floating Number Popup System) | Approved | Recommended | 2026-03-02 |
| 236 | Easy Save 3 3.5.25 (Moodkie) | Asset Store | Scripting (Save / Serialization System) | Approved | Default | 2026-03-02 |
| 237 | Grabbit 6.0.1 (Jungle Juice Games) | Asset Store | QoL (Physics Scene Placement Tool) | Approved | Recommended | 2026-03-02 |
| 238 | Weather Maker 8.0.3 (Digital Ruby) | Asset Store | Environment (Weather / Sky / Atmosphere System) | Approved | Recommended | 2026-03-02 |
| 239 | GrabMaster 1.0 | Asset Store | Scripting (FPS Physics Grab / Interaction System) | Approved | -- | 2026-03-02 |
| 240 | Corgi Engine 9.4 (More Mountains) | Asset Store | Framework (2D/2.5D Platformer Engine / Character System) | Approved | Recommended | 2026-03-02 |
| 241 | Feel 5.9.1 (More Mountains) | Asset Store | Scripting (Game Feel / Juice / Haptics System) | Approved | Recommended | 2026-03-02 |
| 242 | FPS Animation Framework 4.9.3 (Kinemation) | Asset Store | Scripting (Layer-Based FPS Arm/Weapon Animation System) | Approved | Recommended | 2026-03-02 |
| 243 | Retarget Pro 4.2.1 (Kinemation) | Asset Store | Scripting (Runtime Animation Retargeting System) | Approved | Recommended | 2026-03-02 |
| 244 | Advanced Look Component 2.0.0 (Kinemation) | Asset Store | Scripting (Look-At IK Component) | Approved | Recommended | 2026-03-02 |
| 245 | FS Grappling Hook System 1.2.5 (Fantacode Studios) | Asset Store | Scripting (Physics Grapple Hook / Swing System) | Approved | -- | 2026-03-02 |
| 246 | Frank FS4 - Fighting Set 4 + FS3 1.0 (Frank Climax) | Asset Store | Animation (Fighting / Beat Em Up Animation Library) | Approved | -- | 2026-03-02 |
| 247 | fBasic Assets 1.2.7 (FImpossible Creations) | Asset Store | Scripting (Shared Base Library / Starter Kit) | Approved | -- | 2026-03-02 |
| 248 | Spoke 1.2.2 | Asset Store | Scripting (Reactive Programming / Signals Library) | Conditional | -- | 2026-03-02 |
| 249 | Photon Fusion 2.0.9 (Exit Games) | Asset Store | Scripting (Next-Gen Multiplayer Networking SDK) | Approved | Recommended | 2026-03-02 |
| 250 | Motion Warping 3.2.0 (Kinemation) | Asset Store | Scripting (Root Motion Warp / Traversal System) | Approved | Recommended | 2026-03-02 |
| 251 | Adventure Creator 1.85.5 (Icebox Studios / Chris Burton) | Asset Store | Framework (2D/2.5D/3D Adventure Game / Point-and-Click Engine) | Approved | Recommended | 2026-03-02 |
| 252 | Asset Inventory 4 (Wetzold Studios) | Asset Store | Tools (Asset Management) | Approved | Default, QoL | 2026-03-04 |
| 253 | Universal Fighting Engine 2 Pro 2.7.0a (Mind Studios) | Asset Store | Combat (1v1 Fighting Game Engine) | Approved | -- (cherry-pick ref) | 2026-03-04 |
| 254 | Magic Animation Blend 3.2.2 (KINEMATION) | Asset Store | Animation | Conditional | -- | 2026-03-04 |
| 255 | Squash & Stretch Kit 1.1.2 (Long Bunny Labs) | Asset Store | Animation / VFX | Conditional | -- | 2026-03-04 |
| 256 | Boing Kit 1.2.47 (Long Bunny Labs) | Asset Store | Animation / Physics | Approved | -- | 2026-03-04 |
| 257 | Dialogue System OpenAI + ElevenLabs Addon 1.0.34 (Pixel Crushers) | Asset Store | Dialogue / AI | Approved | -- | 2026-03-04 |
| 258 | FS Parkour and Climbing System 1.9.9 (Fantacode Studios) | Asset Store | Character / Animation | Conditional | -- | 2026-03-04 |
| 259 | FishNet Networking Evolution 4.6.22r (First Gear Games) | Asset Store | Networking | Approved | -- | 2026-03-04 |
| 260 | PurrNet 1.19.0 | Asset Store | Networking | Approved | -- | 2026-03-04 |
| 261 | Breeze (Breeze Assets) | Asset Store | AI (NPC Combat/Patrol/Companion System) | Deferred | -- | 2026-03-04 |
| 262 | GOAP v3 (crashkonijn) | Asset Store | AI (Goal Oriented Action Planning) | Deferred | -- | 2026-03-04 |
| 263 | NPC AI Engine (Convai) | Asset Store | AI (Conversational NPC / LLM Integration) | Deferred | -- | 2026-03-04 |
| 264 | Easy Build System (PolarInteractive) | Asset Store | Building / Construction | Approved | -- | 2026-03-05 |
| 265 | Synty Store Importer | SyntyPass | Tools (Asset Import) | Approved | -- | 2026-03-05 |
| 266 | PolygonParticleFX (Synty Studios) | SyntyPass | VFX (Gameplay Particle FX Library) | Approved | Art, VFX, Low Poly | 2026-03-05 |
| 267 | Custom MCP Tool Extensions (TecVooDoo) | Internal | Tools (MCP Extensions) | Approved | Default | 2026-03-06 |
| 268 | All In 1 Springs Toolkit 1.7 | Asset Store | Physics (Spring Animation System) | Conditional | -- | 2026-03-06 |
| 269 | All In 1 Shader Nodes 1.12 | Asset Store | Tools (ASE/SG Node Library) | Approved | Recommended | 2026-03-06 |
| 270 | Advanced FPS Counter 1.5.7 (CodeStage) | Asset Store | QoL (Runtime FPS/Memory/Device Counter) | Approved | -- | 2026-03-06 |
| 271 | Rope Toolkit 2.2.3 | Asset Store | Physics (Rope Simulation) | Approved | Recommended | 2026-03-08 |
| 272 | MCP Eval: Rope/Physics Assets (5) | Internal | Tools (MCP Controllability) | Approved | -- | 2026-03-09 |
| 273 | Naninovel 1.21 (Elringus) | Asset Store | Framework (Visual Novel / Storytelling Engine) | Approved | Recommended | 2026-03-09 |
| 274 | Bro Audio 2.2.2 (Ami/Wuyu) | Asset Store | Audio (Mixing/API) | Conditional | Default Audio | 2026-03-11 |
| 275 | Procedural Music Generator 2.0.0 (Stanford) | Asset Store | Audio (Procedural Music) | Conditional | Recommended | 2026-03-11 |
| 276 | Maestro MIDI 2.18.0 Free (Thierry Bachmann) | Asset Store | Audio (MIDI Synth) | Conditional | Default Audio | 2026-03-11 |
| 277 | Kalend Music and Playlist Player 1.0 | Asset Store | Audio (Music Playback) | Rejected | Don't Use | 2026-03-11 |
| 278 | Localized Audio 1.0 (Fenikkel) | UPM | Audio (Localization) | Rejected | Don't Use | 2026-03-11 |
| 279 | VoiceGPT 2.0 (AiKodex) | Asset Store | Audio (TTS/Editor) | Rejected | Don't Use | 2026-03-11 |
| 280 | Photon Voice 2 2.63 (Exit Games) | Asset Store | Audio (Networking/Voice) | Rejected | Don't Use | 2026-03-11 |
| 281 | Ink Integration for Unity 1.1.8 (Inkle) | GitHub | Scripting (Narrative) | Approved | Recommended | 2026-02-21 |
| 282 | PATWA (com.tecvoodoo.patwa) | Internal | Audio (Adaptive Music System) | Testing | -- | 2026-03-11 |
| 283 | PolygonHorrorCarnival (Synty) | Synty | Art (Character) | Conditional | Art | 2026-02-17 |
| 284 | PolygonDungeonRealms (Synty) | Synty | Art (Character) | Conditional | Art | 2026-02-17 |
| 285 | PolygonFantasyCharacters (Synty) | Synty | Art (Character) | Conditional | Art | 2026-02-17 |
| 286 | PolygonTown (Synty) | Synty | Art (Props) | Conditional | Art | 2026-02-17 |
| 287 | PolygonExplorers (Synty) | Synty | Art (Character) | Conditional | Art | 2026-02-17 |
| 288 | PolygonFarm (Synty) | Synty | Art (Character) | Conditional | Art | 2026-02-17 |
| 289 | PolygonStreetRacer (Synty) | Synty | Art (Character) | Conditional | Art | 2026-02-17 |
| 290 | PolygonHorrorMansion (Synty) | Synty | Art (Props) | Conditional | Art | 2026-02-17 |
| 291 | SidekickCharacters (Synty) | Synty | Art (Character) | Conditional | Art | 2026-02-17 |
| 292 | City Characters 1.2 (ITHappy) | Asset Store | Art + Character Customization System | Approved | Character | 2026-03-12 |
| 293 | Urban Traffic System Full Pack 2.0 (Aglobex) | Asset Store | AI / Simulation (Urban Traffic) | Approved | AI | 2026-03-12 |
| 294 | Drake the Dragonkin 4.0 (Malbers) | Asset Store | Animation / Art | Approved | -- | 2026-03-14 |
| 295 | Undead Horse & Knight 4.0 (Malbers) | Asset Store | Animation / Art | Approved | -- | 2026-03-14 |
| 296 | Low Poly Cowboy 1.1 (Malbers) | Asset Store | Art (Character) | Approved | -- | 2026-03-14 |
| 297 | Malbers Quest Forge 1.0 | Asset Store | Scripting (Quest/Dialogue/Map) | Approved | -- | 2026-03-14 |
| 298 | Flare Engine 2D Tools 1.8.5 | Asset Store | Scripting (2D Framework) | Approved | Recommended | 2026-03-16 |
| 299 | Character Editor 4D 7.6 | Asset Store | Art (Character) | Conditional | -- | 2026-03-16 |
| 300 | 2D Art Maker Casual Characters 1.0.14 | Asset Store | Art (Character) / Scripting | Approved | Recommended | 2026-03-16 |
| 301 | TopDown Engine 4.5 (More Mountains) | Asset Store | Scripting (2D/3D Framework) | Approved | Recommended | 2026-03-16 |
| 302 | com.unity.charactercontroller 1.4.2 (Unity / Philippe St-Amand) | Registry | Character Controller (ECS/DOTS Kinematic) | Approved | Recommended | 2026-03-19 |
| 303 | KINERACTIVE 1.11 (Clean Shirt Labs) | Asset Store | Scripting (IK Interaction System) | Approved | -- | 2026-03-19 |
| 304 | customized objects gravity 1.0 (YAHYABK) | Asset Store | Scripting (Surface Gravity) | Rejected | Don't Use | 2026-03-19 |
| 305 | Camera System 1.6.4 (Gaskellgames) | Asset Store | Scripting (Camera) | Rejected | Don't Use | 2026-03-19 |
| 306 | ECS N-Body Orbit Simulation 1.0.0 (Parallel Cascades) | Asset Store | Scripting (ECS Physics Simulation) | Conditional | -- | 2026-03-19 |

---

## Detailed Evaluations

> **NOTE:** Detailed ENTRY blocks for entries 001-115 pending recovery from session JSONL:
> `C:\Users\steph\.claude\projects\e--Unity-Sandbox\99250266-b660-4ea0-88f0-61e5b98f52e1.jsonl`
>
> Session 35 UI Toolkit entries (116-135) are documented in the session transcript and will be re-entered as needed.
>
> Key findings from Session 35 (UI Toolkit batch):
> - **Text Animation 2 (116) vs Text Animator (117):** Complementary, not competing. Text Animator = Default (TMP + UI Toolkit). Text Animation 2 = Default UI (tighter Kamgam ecosystem integration).
> - **Kamgam UI assets (118-125):** Full Kamgam ecosystem -- Blur requires URP define `KAMGAM_RENDER_PIPELINE_URP`. BlurRenderer uses IBlurRenderer interface for pipeline abstraction.
> - **Sound Effects (125):** SoundEffectManipulator pattern, 30+ event types, CustomPlayFunc hook for Master Audio integration.
> - **Heathen UX (131):** Supports both uGUI and UI Toolkit, GameEvent pattern compatible with HOK event system.
> - **SMC (133):** CitrioN Settings Menu Creator -- dual uGUI/UI Toolkit support, project-specific (no label).
> - **Flow Extended (134):** SABI fluent API, generic extension methods where T : VisualElement.
> - **Markdown (135):** Editor-only, TJIN.Markdown.Editor.dll, Default for all projects.
>
> Key findings from prior sessions (lessons):
> - **Odin:** Never remove from installed project -- cascading errors. Leave it.
> - **RNGNeeds:** Burst-compiled, black box only. Never absorb.
> - **MagicaCloth 2 + MeshRenderer:** MeshCloth locks all verts. Must use SkinnedMeshRenderer.
> - **SimpleBoids (083):** Rejected as package, core algorithm cherry-picked into TecVooDoo Utilities as SimpleBoids.cs.

### ENTRY-024: Prefab World Builder (PluginMaster) | Approved, Recommended | 2026-02-07 (re-eval 2026-03-05)

| Field | Value |
|-------|-------|
| Source | Asset Store |
| Category | Tools / Level Design |
| Verdict | **Approved** |
| Labels | **Recommended**, Level Design |
| Scripts | 191 |
| LOC | ~43,300 |
| Asmdef | None |
| Namespace | `PluginMaster` (single) |
| Editor-only | Yes — all scripts under `Editor/` folders |
| Path | `Assets/PluginMaster/DesignTools/Editor/` |

**What it does:**
Editor-only level design toolkit for painting, placing, and arranging prefabs in the Scene view. Covers the full spectrum of editor-time world building — from individual placement to mass painting, tiling, and procedural arrangement.

**Tools:**
- **Brush** — Paint prefabs on surfaces with configurable density, radius, and randomization
- **Line** — Place prefabs along a line with spacing control
- **Shape** — Arrange prefabs in circles, arcs, and other geometric shapes
- **Tiling** — Tile prefabs in rectangular or hexagonal grids
- **Pin** — Single-prefab placement with surface snapping
- **Eraser** — Remove placed objects by painting over them
- **Gravity** — Drop objects to the nearest surface below
- **Replacer** — Swap placed prefabs for different ones in bulk
- **Mirror** — Mirror placement across configurable axes
- **Extrude** — Duplicate and extrude selections along a direction
- **Circle Select** — Radial selection tool
- **Selection** — Advanced multi-object selection and manipulation
- **Wall** — Build walls from prefabs along spline paths
- **Floor** — Fill floor areas with tiled prefabs

**Architecture:**
- Grid system: rectangular + radial grids, snap to grid/vertex/bounding box
- Palette system with auto-generated thumbnails, multibrush support, and brush creation presets
- Octree-based spatial queries (`BoundsOctree`) for fast scene object lookups
- Persistent data system (`PWBData`) for control points and object poses across sessions
- Unity 6 overlays/toolbars integration

**Integration notes:**
- Zero runtime footprint — entirely editor scripts, nothing ships in builds
- No asmdef boundaries — compiles into the default editor assembly
- Works alongside runtime building systems (e.g. Easy Build System) without conflict: PWB is for editor-time level design, EBS is for runtime player-driven building
- Large codebase (43K LOC) but self-contained under `PluginMaster` namespace

**Verdict rationale:**
Best-in-class editor-time prefab placement tool. The breadth of tools (14 distinct modes), octree-backed performance, and persistent data system set it apart from simpler alternatives. Upgraded from Conditional to **Approved, Recommended** after full re-inspection confirmed scope and quality. Complementary to runtime building systems — they solve different problems.

**MCP Tools (Session 52-55):** 4 custom tools built -- `pwb-list-palettes`, `pwb-add-to-palette`, `pwb-place-brush`, `pwb-place-line`. Palettes persist across sessions in PWB's own data storage. Use `brushName` partial match (not index). `pwb-place-line` creates a named container GO. All 4 tools confirmed working ✅.

---

### ENTRY-136: MegaFiers 2 (Chris West)

| Field | Value |
|-------|-------|
| Source | Asset Store |
| Version | 1.58 |
| Price | $150 |
| Rating | 5 stars (360 ratings) |
| Publisher | Chris West |
| Category | Editor Extensions / Modeling |
| Verdict | **Approved** |
| Label | -- (project-specific) |
| Date | 2026-02-24 |
| URP | Yes |
| HDRP | Yes |
| Min Unity | 2019.4.14 |

**What it is:** Production-grade mesh deformation framework inspired by 3ds Max modifier stack. 57+ modifier types with Burst/Jobs integration for real-time performance.

**Architecture:**
- 318 C# scripts, no asmdef (all Assembly-CSharp)
- 200MB asset size
- Core pattern: `MegaModifyObject` (controller) + stacked `MegaModifier` components
- Channel-based deformation (Verts, UV, Normals, Tris, Colors separately)
- Every modifier has Job-based + fallback implementations
- 98 custom Editor scripts with gizmo visualization
- MegaShape system (25 scripts) BUILT IN -- spline/path primitives included

**Modifier Categories (57+ types):**
- **Deformation:** Bend, Stretch, Squeeze, Taper, Skew, Twist, Bulge, Hump, Melt, Globe, Spherify, Cylindrify, Push, Poke, Bubble
- **FFD:** 7 variants (2x2, 3x3, 4x4, 2x2x2, 3x3x3, 4x4x4)
- **Path/Curve:** PathDeform, WorldPathDeform, CurveDeform, CurveSculpt, RopeDeform
- **Dynamic:** Ripple, Wave, DynamicRipple, CollisionDeform, HitDeform, Rubber
- **Displacement:** Displace (texture), DisplaceRT (render texture), DisplaceWebCam
- **Morph:** MegaMorph blend shape system, PointCache (6 variants)
- **Warps:** 24 world-space warp variants (parallel to local-space modifiers)
- **Utility:** Paint, Selection (5 types), PageFlip, TreeBend, Noise, VertNoise

**Included Shape Primitives:** Circle, Rectangle, Star, NGon, Ellipse, Arc, Helix, Line + SVG/KML/OSM import

**Code Quality:**
- Clean visitor/component pattern -- modifiers attach to controller, stack applies in order
- Deep Burst/Jobs integration (NativeArray<Vector3>, BurstCompile on all heavy compute)
- Change detection system skips unnecessary updates
- Matrix-based transformation system (tm/invtm) for local-space calculations
- Region support (from/to) on most spatial modifiers for partial application
- 3ds Max parameter parity -- artists with Max experience can transfer knowledge directly

**Claude Interaction:**
- Can add/configure modifiers via script-execute (standard MonoBehaviour components)
- No asmdef = all in Assembly-CSharp (accessible but adds to compile time)
- Clean public API on modifier classes (angle, amount, axis, from, to, etc.)
- Editor scripts provide gizmo preview in Scene view

**Cross-Asset Notes:**
- MegaShape (splines) is BUILT INTO MegaFiers 2 -- the separate MegaShapes asset in the Chris West batch may be redundant or an older standalone. Verify before importing both.
- No conflict with MagicaCloth 2 (different deformation targets)
- Complements ProBuilder/UModeler (modeling vs deformation)
- PathDeform relevant to HOK (raft path, rope/hose effects)
- Wave/Ripple relevant to HOK water effects (geometry-based alternative to shader-only)

**Concerns:**
- 200MB + 318 scripts in Assembly-CSharp = slower compile iteration
- ReadMe says "currently in beta" (2021 copyright) but actively maintained (last release Feb 2025)
- No asmdef isolation -- cannot selectively exclude from builds
- $150 price point -- premium, justified by depth

**Verdict Rationale:** Approved without default label. This is the definitive Unity mesh deformation tool with no real competitor at this scope. Essential for projects needing procedural geometry (path-based objects, dynamic deformation, morph targets, rope/hose, page flip). Not every 3D project needs it, so project-specific rather than Default 3D.

**HOK Relevance:** HIGH. PathDeform for raft spline movement, Wave/Ripple for Acheron water, RopeDeform for fishing line, TreeBend for vegetation. High value if geometry-based effects are preferred over shader-only.

**FearSteez Relevance:** MEDIUM. Mesh deformation for impact effects (punched walls bending, floor warping), FFD for stylized character squash/stretch during attacks. 2.5D allows visible mesh deformation on background elements.

**3D Concept Projects Relevance:** HIGH. Universal mesh deformation toolkit for any 3D game -- terrain morphing, procedural animation, environmental effects. Particularly valuable for horror (Miracle Worker, Murder Malady & Monsters) and fantasy (Cursed Fantasy) where organic deformation sells atmosphere.

**VN Projects Relevance:** LOW. Visual novels don't typically need mesh deformation. Exception: MegaBook 2 (138) has its own built-in page deformation.

---

### ENTRY-137: Mega Shapes (Chris West)

| Field | Value |
|-------|-------|
| Source | Asset Store |
| Version | 2.54 |
| Price | $100 |
| Rating | 4 stars (167 ratings) |
| Publisher | Chris West |
| Category | Editor Extensions / Modeling |
| Verdict | **Approved** |
| Label | -- (project-specific) |
| Date | 2026-02-24 |
| URP | Yes |
| HDRP | Yes |
| Min Unity | 2019.4.14 |

**What it is:** Spline-based procedural geometry system -- lofts, rope physics, path following, terrain carving, object scatter. Companion to MegaFiers 2 (deformation), not a replacement.

**Architecture:**
- 138 C# scripts total, no asmdef (all Assembly-CSharp, `MegaFiers` namespace)
- Installs into `Assets/MegaFiers/Scripts/MegaShape/` (116 core) + utility scripts
- Core pattern: `MegaShape` (spline container) -> `MegaShapeLoft` (mesh builder) -> `MegaLoftLayer*` (30+ layer strategy pattern)
- Includes MegaGrab (3 scripts) -- screenshot/DOF capture utility (bonus, unrelated to splines)
- Test scene with demo scripts (13 scripts)

**Key Systems:**
- **Loft System:** 30+ layer types -- Simple, Complex, CloneSimple/Spline/Rules, ScatterSimple/Spline, MultiMat variants. Builds meshes from spline cross-sections.
- **Rope/Chain Physics:** Verlet integrator-based (MegaRope, MegaRopeSolver, MegaRopeSpring). 7 scripts.
- **Hose/Connector:** Flexible hose between two points (MegaHose, 4 variants)
- **Vehicle Tracks:** Tank treads, wheel systems (MegaTracks, MegaTankWheels)
- **Path Following:** Character, train, rigidbody path followers (MegaCharacterFollow, MegaTrainFollow, MegaPathFollow)
- **Terrain Integration:** MegaLoftTerrainCarve -- carve spline paths into terrain
- **Shape Primitives:** Arc, Circle, Ellipse, Helix, Line, NGon, Rectangle, Star + SVG/KML/OSM import
- **Lathe/Extrude:** MegaShapeLathe for revolution solids
- **Runtime Drawing:** MegaDrawSpline, MegaDrawLoft for runtime spline creation

**Relationship to MegaFiers 2 (ENTRY-136):**
- **Complementary, not redundant.** MegaFiers 2 = mesh deformation. MegaShapes = mesh generation from splines.
- MegaFiers 2 includes 25 basic shape scripts (primitives only). MegaShapes adds the full loft/rope/scatter/terrain system (116 scripts).
- Both share the `MegaFiers` namespace intentionally (v2.43 fix).
- **Safe to install together** since v2.42/v2.43. Utility classes renamed (MegaUtils -> MegaShapeHelper, MegaMatrix -> MegaShapeMatrix, etc.) to avoid filename conflicts.
- Previous crash (Session 36) was caused by old `Mega-Fiers` folder (hyphenated) coexisting with new `MegaFiers` folder, NOT by MegaShapes vs MegaFiers conflict.

**Code Quality:**
- Strategy pattern for loft layers -- clean extensibility
- Verlet-based rope physics is lightweight and stable
- Shared namespace with MegaFiers 2 allows cross-referencing
- Editor scripts (26) provide custom inspectors for all layer types
- v2.42-2.43 changelog shows proactive conflict resolution with MegaFiers 2

**Claude Interaction:**
- Can create shapes and configure loft layers via script-execute
- Path following components are standard MonoBehaviours -- easy to wire up
- No asmdef = Assembly-CSharp (accessible but adds compile time)

**Concerns:**
- No asmdef -- 138 more scripts in Assembly-CSharp
- Last release May 2024 (10 months ago) vs MegaFiers 2 Feb 2025 -- slightly less active
- $100 on top of MegaFiers 2's $150 = $250 total for the Chris West pipeline
- MegaGrab (screenshot tool) is random bloat unrelated to core purpose

**Verdict Rationale:** Approved without default label. The loft/rope/terrain-carve system fills a real gap that MegaFiers 2 doesn't cover. Project-specific -- include when you need procedural geometry generation from splines (roads, rivers, fences, ropes, tracks).

**HOK Relevance:** HIGH. Rope physics for fishing line, path following for raft navigation, terrain carving for Acheron riverbed, loft layers for procedural riverbank geometry. Pairs with MegaFiers 2 for a complete procedural pipeline.

**FearSteez Relevance:** LOW. 2.5D beat 'em up doesn't need spline-based procedural geometry. Hand-crafted stage geometry is more appropriate.

**3D Concept Projects Relevance:** HIGH. Roads, rivers, fences, tracks, bridges, tunnels -- any 3D game with linear environmental features benefits from loft/path extrusion. Space Garbage Man and GRIMMORPG (3D Point 'N Click) would use this heavily for corridor/path construction.

**VN Projects Relevance:** LOW. Visual novels don't need spline geometry.

---

### ENTRY-138: MegaBook 2 (Chris West)

| Field | Value |
|-------|-------|
| Source | Asset Store |
| Version | 1.17 |
| Price | $60 |
| Rating | 4 stars (91 ratings) |
| Publisher | Chris West |
| Category | Editor Extensions / Modeling |
| Verdict | **Approved** |
| Label | -- (project-specific) |
| Date | 2026-02-24 |
| URP | Yes |
| HDRP | Yes |
| Min Unity | 2019.4.14 |

**What it is:** Realistic 3D page-turning book system with Burst/Jobs mesh deformation. Pages support textures, video, TextMeshPro, and attached GameObjects with UI Canvas overlay. Fully standalone -- no dependency on MegaFiers or MegaShapes.

**Architecture:**
- 40 scripts (28 runtime, 12 editor), 11,213 LOC total, no asmdef
- Clean `MegaBook` namespace (separate from MegaFiers)
- Core pattern: `MegaBookBuilder` (4,005 lines) manages page stack + three deformation layers (Turner, Lander, Flexer)
- Each page = procedural mesh with front/back textures + attached GameObjects
- Burst/Jobs for all mesh deformation (`MegaBookBendMod`, `[BurstCompile]`)
- UnityEvent callbacks: `MegaBookBuiltEvent`, `MegaBookPageTurnEvent`
- 32 prefab templates, 11 cover styles, 12 book styles

**Page Content System:**
- **Textures:** Front/back per page, alpha masking, background blending, runtime swap via `SetPageTexture()`
- **Video:** VideoClip front/back with visibility-driven playback, volume control
- **TextMeshPro:** Integrated for in-page text rendering
- **Attached GameObjects:** `MegaBookPageObject` system -- any GameObject/UI Canvas attaches to pages with:
  - Position/rotation/scale transforms (dynamic, not baked)
  - Visibility curves (fade in/out via AnimationCurve)
  - CanvasGroup alpha control for UI elements
  - WorldSpace Canvas support
- **Dynamic textures:** `DownloadTexture(url, page, front)` for web-loaded content
- **Multi-mesh pages:** `MBComplexPage` for complex page content

**Page Turn Control:**
- API: `NextPage()`, `PrevPage()`, `SetPage(float)`, `Flip` property
- `turntime` (seconds), `Snap` (instant vs animated)
- AnimationCurve per page for spread dynamics
- Per-page overrides via `MegaBookPageParams`
- `Flip` is animatable -- works with Timeline/animation recording
- Pluggable input (default MegaBookMouseControl uses raycasts, replaceable)

**Visual Novel Viability: EXCELLENT**
- UI overlay via attached WorldSpace Canvas with CanvasGroup fade
- Dynamic content switching at runtime (textures, video, GameObjects)
- Programmatic page control (scripted story progression)
- TextMeshPro for dialogue/narration on pages
- Event callbacks for triggering VN logic on page turns
- Architecture for VN: Book -> Page meshes -> Attached UI Canvas children (dialogue, portraits, choices)

**Code Quality:**
- Burst/Jobs mesh deformation, no per-frame allocations noted
- Extensive serialization and editor tooling (2,347-line main editor)
- Full Undo support in editor
- PDF documentation (802 KB) + inline tooltips
- `MegaBookBuilder.cs` at 4,005 lines is large but functionally cohesive

**Cross-Asset Notes:**
- Completely standalone -- zero dependencies on MegaFiers/MegaShapes
- TextMeshPro integration built in
- UI Canvas attachment compatible with UI Toolkit (WorldSpace Canvas)
- No conflict with any evaluated asset

**Concerns:**
- `MegaBookBuilder.cs` at 4,005 lines is monolithic
- No asmdef (Assembly-CSharp)
- Demo scene references several Asset Store art packages (not required for core)
- Page mesh complexity scales with page count -- memory consideration for large books

**Verdict Rationale:** Approved without default label. Production-ready book system with genuine VN potential via the attachment/Canvas system. The Burst/Jobs deformation is overkill for simple page flips but ensures smooth performance even with complex page content. Project-specific -- include when a 3D book interface is needed (visual novels, in-game journals, tutorials, menus).

**VN Project Relevance:** HIGH. The attachment system cleanly separates page mesh (engine-controlled) from game logic (UI Canvas children). Story text via TMP, character portraits via attached Images, choice buttons via attached UI -- all with per-page visibility curves for fade in/out. Dynamic content switching supports branching narrative. The primary implementation work is the VN content pipeline, not the book engine itself. Directly applicable to Encapsulated Fear, Genie in a Test Tube, and Murder Malady & Monsters (all 2D Visual Novel concepts).

**HOK Relevance:** LOW. No book/journal mechanic planned for HOK.

**FearSteez Relevance:** LOW. Beat 'em up doesn't use book interfaces.

**3D Concept Projects Relevance:** MEDIUM. In-game journals, lore books, or tutorial manuals for any 3D game (GRIMMORPG, Miracle Worker). The WorldSpace Canvas system makes it a versatile 3D UI element beyond just VN use.

---

### ENTRY-139: Vulcan (Chris West)

| Field | Value |
|-------|-------|
| Source | Asset Store |
| Version | 1.03 |
| Price | $60 |
| Rating | 0 stars (1 rating) |
| Publisher | Chris West |
| Category | Editor Extensions / Modeling |
| Verdict | **Conditional** |
| Label | -- (project-specific) |
| Date | 2026-02-24 |
| URP | Yes |
| HDRP | Yes |
| Min Unity | 2021.3.32 |

**What it is:** Procedural mesh-based flame/thruster VFX system. Generates real-time 3D flame geometry -- NOT a particle system. Designed for engine afterburners, rocket exhaust, sci-fi thrusters. Think "mesh-based flame synthesizer."

**Architecture:**
- 26 scripts (10 runtime, 13 editor, 3 demo), ~8,500 LOC, no asmdef
- Clean `VulcanFlames` namespace
- Core pattern: `Flame` MonoBehaviour + `FlameDesc` serializable configs (multi-layer)
- Three mesh generation strategies: `RoundMesh` (cylindrical), `PlaneMesh` (flat sheets), `SliceMesh` (ring stacks)
- ScriptableObject-driven: `GradientMap`, `FlameNoiseMap`, `FlameBlendMap`
- `[ExecuteInEditMode]` for live editor preview
- Custom shaders: Built-in RP (.shader) + URP (.shadergraph) variants
- 100+ parameters per flame layer (geometry, animation, color, lighting)

**Key Features:**
- Multi-layer flame stacking (rings + planes + cylinders combined)
- HDR color + rim lighting + texture scrolling shader pipeline
- Procedural noise animation (OpenSimplex2 included)
- Seeded randomization for reproducible variation
- AnimationCurve-driven profiles (bend, flutter, pulse, scale)
- Per-layer material assignment + blendshape support
- Collider-based ground collision effects
- 23 pre-built materials (F-15, Raptor, Saturn, Rocket Engine variants)
- 4 prefab templates + 2 flame presets

**Code Quality:**
- Clean namespace isolation (`VulcanFlames`)
- Static mesh generator classes with budget-first pattern (GetCounts -> BuildMesh)
- ScriptableObject data architecture
- FlameEditor.cs at 1,962 lines is bloated but functional
- No Burst/Jobs (managed mesh generation -- potential mobile perf concern)
- Standalone -- no dependencies on MegaFiers or anything else

**Concerns:**
- Only 1 rating -- very little community validation
- Last release May 2024 (10 months ago)
- No Burst optimization for mesh generation (managed code only)
- FlameLayer.cs is an empty stub class (unused)
- UV channel packing (TEXCOORD0-3 for custom data) is brittle
- Very niche use case -- only thruster/engine flames
- $60 for a single-purpose VFX tool

**Verdict Rationale:** Conditional. Well-architected for its specific purpose, but extremely niche. Only valuable for projects with engine/thruster/rocket flame VFX needs. The mesh-based approach gives more control than particles for high-fidelity flames, but the lack of Burst optimization and minimal community adoption are concerns. No default label -- project-specific inclusion only.

**HOK Relevance:** LOW. No engine/thruster needs. Tartarus environmental flames are better served by particles/VFX Graph.

**FearSteez Relevance:** LOW. Beat 'em up doesn't need engine flame VFX.

**3D Concept Projects Relevance:** MEDIUM for sci-fi only. Alpha Foxtrot Uniform (tactical shooter -- vehicle exhaust, explosions), Space Garbage Man (space setting -- thruster plumes). Low for fantasy/horror projects.

**VN/2D Projects Relevance:** NONE.

---

### ENTRY-140: Full Rig (Chris West)

| Field | Value |
|-------|-------|
| Source | Asset Store |
| Version | 1.07 |
| Price | $50 |
| Rating | 5 stars (3 ratings) |
| Publisher | Chris West |
| Category | Editor Extensions / Modeling |
| Verdict | **Approved** |
| Label | -- (project-specific) |
| Date | 2026-02-24 |
| URP | Yes |
| HDRP | Yes |
| Min Unity | 2020.3.44 |

**What it is:** Physics-based rope/catenary simulation toolkit. NOT character rigging despite the name. Simulates hanging ropes with realistic sag, swing, and tension. Designed for ship rigging, bridges, cables, telegraph lines.

**Architecture:**
- 15 scripts (5 core, 4 editor, 6 demo), no asmdef
- Clean `FullRig` namespace
- Core: `Rope.cs` (760 lines) -- catenary curve solver with iterative refinement
- ScriptableObject data: `RopeType` (13 presets: 1/2/4/6 strand variants), `RopeEnd` (24 connection points: deadeyes, pulleys, hooks)
- Custom shader with `MaterialPropertyBlock` (no per-frame allocs) -- passes catenary math to GPU
- `[ExecuteAlways]` for live editor preview
- 20 prefabs, 28 FBX models (chains, deadeyes, masts, knots, pulleys), 16 materials

**Key Features:**
- **Catenary physics:** Real mathematical catenary solver (not fake drooping splines). Configurable iteration count (4-128).
- **Rope hierarchies:** Rope-to-rope attachment -- one rope's endpoint attaches to a position on another rope. Builds complex rigging webs.
- **Swing animation:** Sinusoidal oscillation with per-rope amplitude, frequency, phase offset
- **Tension forces:** Optional Rigidbody force application at endpoints
- **Attached objects:** GameObjects follow rope curve with auto-rotation (deadeyes, knots, pulleys)
- **Lanyard system:** `RopeLanyard` converts mesh to SkinnedMeshRenderer with two-bone weights for bending
- **Editor tools:** Scene view handles, snap-to-target, hotkeys for cycling rope meshes (3-key) and connection objects (1/2-key)
- **Visibility culling:** `OnBecameVisible`/`OnBecameInvisible` for performance

**Code Quality:**
- Clean namespace isolation (`FullRig`)
- Mathematically sophisticated catenary solver
- Efficient MaterialPropertyBlock shader communication
- Professional editor integration (scene handles, snapping, undo)
- Rope.cs at 760 lines is manageable but monolithic
- No Burst/Jobs (managed code, acceptable for rope count in typical scenes)

**Cross-Asset Notes:**
- Completely standalone -- no MegaFiers dependency (commented-out namespace reference is residual)
- Orthogonal to Final IK (090), Animation Rigging, Animancer (089) -- rope physics, not skeletal
- Overlaps somewhat with MegaShapes (137) rope system (Verlet-based). Different approaches: Full Rig uses catenary math (analytical), MegaShapes uses Verlet integration (numerical). Full Rig is more physically accurate for static/slow-swinging ropes; MegaShapes is better for dynamic rope interaction.
- Catenary approach = better for environmental rigging (hanging, swaying). Verlet = better for interactive rope (pulling, grabbing).

**Concerns:**
- Only 3 ratings (limited community)
- URP/HDRP shaders in .rar archives -- requires manual extraction
- No Burst optimization (fine for ~50 ropes, may matter for 200+)

**Verdict Rationale:** Approved without default label. Professional rope simulation with genuine mathematical rigor. Project-specific -- include when you need environmental rope/cable systems (ship rigging, bridges, power lines, architectural cables).

**HOK Relevance:** HIGH. Kharon's ferry could use catenary ropes for raft rigging, mast bracing, and dock tethering. The rope-to-rope hierarchy system maps directly to ship rigging topology. Swing animation adds atmosphere (wind-blown ropes on the Acheron). Complements MegaShapes' Verlet rope for interactive fishing line while Full Rig handles static/environmental rigging.

**FearSteez Relevance:** LOW. Beat 'em up doesn't need catenary rope physics.

**3D Concept Projects Relevance:** HIGH. Ship rigging, bridges, power lines, architectural cables for any 3D game. GRIMMORPG (horror atmosphere -- chains, ropes), Cursed Fantasy (fantasy bridges, castle rigging), Space Garbage Man (tether cables in space).

**VN/2D Projects Relevance:** NONE. Static catenary physics is purely 3D.

---

### ENTRY-141: Mega Cache (Chris West)

| Field | Value |
|-------|-------|
| Source | Asset Store |
| Version | 1.46 |
| Price | $29 |
| Rating | 4 stars (50 ratings) |
| Publisher | Chris West |
| Category | Editor Extensions / Modeling |
| Verdict | **Approved** |
| Label | -- (project-specific) |
| Date | 2026-02-24 |
| URP | Yes |
| HDRP | Yes |
| Min Unity | 2020.3 |

**What it is:** Mesh sequence, particle, and point cloud caching system. Imports OBJ sequences, 3ds Max/Maya particle exports (PRT/PDA), and point cloud data (CSV/XYZ/PLY) for high-fidelity baked animation playback in Unity. Designed for pre-computed simulations (fluid, cloth, destruction, smoke) that would be too expensive to run at runtime.

**Architecture:**
- 34 scripts (25 runtime, 9 editor), no asmdef, NO namespace (global/Assembly-CSharp)
- Installs into `Assets/MegaFiers/MegaCache/` -- shares parent folder with MegaFiers 2 but has NO code dependency on it
- 117 MB total, but 101 MB is demo scene -- pure code is ~500 KB
- Three caching subsystems: Mesh (OBJ), Particle (PRT/PDA), Point Cloud (CSV/XYZ/PLY)

**Key Features:**
- **Mesh caching:** Import OBJ sequences with automatic compression (16-bit vertices, 8-bit normals/UVs). Three playback modes: all-in-memory (fastest), file-streaming (balanced), ScriptableObject image (best load time).
- **Particle caching:** Import 3ds Max Particle Flow (PRT) or Maya (PDA) exports. Bridges to Shuriken particle system. Per-particle position, velocity, rotation, scale, spin, lifetime tracking.
- **Point cloud caching:** CSV, XYZ, XYZRGB, PLY formats. Optional multi-threaded intensity updates.
- **Threading:** Custom thread pool for background frame preloading (configurable core count). NOT Burst/Jobs -- legacy System.Threading.
- **Compression:** 16-bit vertex encoding (6 bytes vs 12), 8-bit normals (3 bytes vs 12), optional optimized particle byte arrays (~1/3 memory).
- **Material import:** Reads MTL files, auto-creates Unity materials with URP/HDRP shader selection.
- **MegaCacheOBJRef:** Reference component to share one cached dataset across multiple GameObjects (instancing).

**Code Quality:**
- No namespace (global scope) -- consistent with Chris West pattern but messy for large projects
- Compression math is solid (quantization with bounds remapping)
- Thread pool implementation is functional but dated (no async/await, no Jobs)
- Editor scripts are straightforward custom inspectors with file dialog import
- No Burst/Jobs -- acceptable for playback workload (decompression is lightweight)

**Cross-Asset Notes:**
- Standalone despite living in `Assets/MegaFiers/` folder -- menu items use `[AddComponentMenu("MegaFiers/...")]` for organization only
- Complementary to MegaFiers 2 (136): MegaFiers does real-time mesh deformation, Mega Cache plays back pre-baked deformation. Use MegaFiers for interactive, Mega Cache for cinematic.
- No overlap with VFX Graph/Particle System -- Mega Cache replays external sim data, doesn't generate effects
- Point cloud feature overlaps with PCX (Keijiro) but adds animation/sequence playback

**Concerns:**
- No namespace increases collision risk in large projects
- Legacy threading (System.Threading) instead of Jobs -- functional but won't benefit from Burst
- 101 MB demo scene is wasteful -- delete after import
- OBJ import workflow requires external DCC tool to export sequences (Blender, Houdini, Maya, Max)
- Point cloud formats are ASCII-only (no binary PLY) -- large datasets will be slow to import

**Verdict Rationale:** Approved without default label. Solid niche tool for playing back pre-computed simulations. The DCC-to-Unity pipeline is the entire value prop -- if your workflow includes Houdini/Blender fluid sims, destruction caches, or particle exports, this is the bridge. Not needed otherwise.

**HOK Relevance:** MEDIUM. Acheron river could use cached fluid/smoke simulations for cinematic moments (Styx mist, Tartarus fire). Cached cloth simulation for Kharon's cloak in cutscenes (higher fidelity than runtime cloth). Low priority compared to MegaFiers real-time deformation, but valuable for baked VFX sequences.

**FearSteez Relevance:** LOW. Beat 'em up games typically use real-time particle effects rather than baked simulation caches. Possible use for cinematic destruction sequences or environmental smoke, but unlikely to be core pipeline.

---

### ENTRY-142: Texture Studio (Chris West)

| Field | Value |
|-------|-------|
| Source | Asset Store |
| Version | 1.13 |
| Price | $100 |
| Rating | 5 stars (6 ratings) |
| Publisher | Chris West |
| Category | Editor Extensions / Painting |
| Verdict | **Approved** |
| Label | -- (project-specific) |
| Date | 2026-02-24 |
| URP | Yes |
| HDRP | Yes |
| Min Unity | 2020.3.44 |

**What it is:** GPU-accelerated layer-based texture compositing system -- essentially Photoshop layers running inside Unity. Creates composite textures from stacked layers with 26 blend modes, channel operations, text (TMP), color replacement, LUT grading, and mesh deformation. Works both as an editor tool AND at runtime for dynamic texture generation.

**Architecture:**
- 22 scripts (5 runtime, 16 editor, 1 demo), plus PSD.asmdef for Photoshop import
- No namespace (global/Assembly-CSharp)
- Installs to `Assets/Texture Studio/` -- standalone, NO MegaFiers dependency
- 146 MB total (119 MB is demo scene -- core engine ~12 MB)
- Core: `CompositeMap` (ScriptableObject) manages layer stack, renders to RenderTexture via GPU
- 5 custom shaders (CGPROGRAM, all pipelines compatible)

**Key Features:**
- **26 Photoshop blend modes:** Multiply, Screen, Overlay, SoftLight, HardLight, Dodge, Burn, VividLight, LinearLight, PinLight, Add, Subtract, Difference, Exclusion, HardMix, Dissolve, etc.
- **Channel operations:** Per-channel swizzle (11 options including inverted/constants), remapping, per-channel levels, multiply
- **Color replacement:** 8 simultaneous color replacements with fuzzy range matching per layer
- **Text layers:** Full TextMeshPro integration -- font, size, style, color, outline, alignment
- **Layer masking:** Per-layer mask with channel selection, blend mask, mask clipping, inherited parent masks
- **Mesh deformation:** 4-corner perspective warp, cylindrical bend, configurable subdivision (6-64 segments)
- **LUT color grading:** Per-layer and final output LUT application
- **Adjustments:** Hue, saturation, contrast, brightness, levels (black/white point), blur
- **PSD import:** Reads Photoshop .psd/.psb files via Ntreev.Library.Psd.dll (editor only)
- **Runtime API:** `SetParam()` overloads for dynamic texture changes (player names, team colors, damage states, liveries)
- **Output:** RenderTexture (real-time), Texture2D bake (16 to 16k), PNG export, direct material assignment
- **Sprite atlas support:** U2D SpriteAtlas and manual column/row texture atlases

**Code Quality:**
- GPU-centric -- all compositing in shaders, no per-frame CPU allocations
- ScriptableObject-based CompositeMap is clean and serialization-friendly
- Professional editor UI with undo/redo coverage
- No namespace (Chris West pattern) -- collision risk in large projects
- Shader code uses CGPROGRAM (works everywhere but dated vs ShaderGraph)
- Runtime param system is well-designed for dynamic use cases

**Cross-Asset Notes:**
- Completely standalone -- no MegaFiers/MegaShapes dependency despite same publisher
- Complementary to MegaFiers 2 (136): MegaFiers deforms meshes, Texture Studio composites their textures
- No overlap with Unity's Shader Graph -- Texture Studio operates on texture assets, not material shaders
- Text layer system is independent of Text Animator (117) / Text Animation 2 (116) -- different domains (texture baking vs UI text effects)

**Concerns:**
- Only 6 ratings (small community despite 5-star rating)
- Last release Nov 2024 -- not ancient but not recent either
- No namespace
- CGPROGRAM shaders work but are legacy syntax
- PSD import depends on third-party DLL (Ntreev.Library.Psd) -- editor only, no runtime PSD loading
- 119 MB demo content should be deleted after evaluation

**Verdict Rationale:** Approved without default label. Powerful GPU texture compositing with genuine runtime capability. Project-specific -- include when you need dynamic texture generation (vehicle liveries, character customization, procedural decals, team color systems, damage overlays). The runtime param system makes it a real game feature, not just an editor convenience.

**HOK Relevance:** LOW. Kharon's ferry and environment don't require dynamic texture compositing. Static textures from Blender/Substance workflow are sufficient for HOK's needs.

**FearSteez Relevance:** MEDIUM. Beat 'em up character customization (player colors, team emblems, damage overlays on fighter textures) is a natural fit for the runtime param system. Dynamic fight stage textures (graffiti, blood splatter layers) could add visual flair.

**DLYH/VN Relevance:** MEDIUM. Visual novel projects could use runtime text-on-texture for dynamic journal entries, letters, or UI backgrounds with layered composition.

---

### ENTRY-143: Mega Flow (Chris West)

| Field | Value |
|-------|-------|
| Source | Asset Store |
| Version | 1.44 |
| Price | $65 |
| Rating | 4 stars (21 ratings) |
| Publisher | Chris West |
| Category | Editor Extensions / Effects |
| Verdict | **Approved** |
| Label | -- (project-specific) |
| Date | 2026-02-24 |
| URP | Yes |
| HDRP | Yes |
| Min Unity | 2019.4.14 |

**What it is:** 3D vector field system for particle advection and flow simulation. Imports pre-computed fluid simulations (FumeFX, RealFlow, Krakatoa/Blender FGA) or generates flow fields procedurally from MegaShapes splines. Drives Unity particle systems, rigid bodies, and arbitrary GameObjects through vector field sampling. Multi-threaded physics.

**Architecture:**
- 36 scripts (19 runtime ~6,100 lines, 17 editor ~4,650 lines), no asmdef, NO namespace (global)
- **WARNING:** Installs to `Assets/Mega-Fiers/MegaFlow/` -- uses HYPHENATED `Mega-Fiers` folder (old naming convention). If MegaFiers 2 is also installed (which uses `Assets/MegaFiers/` without hyphen), both folders coexist safely -- different paths. But be aware of the naming inconsistency.
- 71 MB total (59.6 MB is demo scenes -- core code ~350 KB)
- Core data: `MegaFlowFrame` (ScriptableObject) stores grid-based velocity/smoke/force vectors
- 1 custom shader (simple wireframe visualization)

**Key Features:**
- **Import pipelines (editor):** FumeFX .fxd (3ds Max), FGA (Krakatoa/Blender), RealFlow .bin (particle cache), Maya Fluids, native FLW format
- **Procedural generation:** Create vector fields from MegaShapes spline curves (Attract/Repulse/Flow modes with falloff curves). This is the only MegaShapes dependency.
- **Particle advection:** Drives Shuriken particles through vector field with drag-based physics (density, cross-section, Reynolds number). Multi-threaded across CPU cores.
- **Frame animation:** Multi-frame sequences with temporal interpolation for animated flow fields
- **Rigid body control:** Drag force application via vector field lookup per frame
- **Generic object control:** Position advection, rotation alignment to flow direction, gradient coloring by speed
- **Smoke gun:** Object/particle emitter with lifetime pooling, random rotation/scale
- **Moving sources:** Flow follows a tracked target transform with fadeout trail
- **Memory optimization:** Optional byte-packing reduces memory 4x (float to byte per component)
- **Mesh voxelization:** Convert 3D geometry into flow-aware grid via MegaFlowMatchShape
- **Texture3D export:** Convert flow data to GPU-accessible 3D texture

**Code Quality:**
- Physics model is genuine (drag coefficient, Reynolds number, mass/area) -- not just noise displacement
- Multi-threaded particle updates via System.Threading (not Burst/Jobs -- legacy but functional)
- Trilinear interpolation for smooth field sampling
- No namespace (Chris West pattern) -- all global scope
- Soft-body physics solver is mostly disabled (`#if false`) -- vestigial code
- ReadMe.txt doubles as comprehensive changelog and feature reference

**Cross-Asset Notes:**
- **Optional MegaShapes dependency:** `MegaFlowCreateFromSplines.cs` references `MegaShape` class for procedural flow creation. All other scripts are standalone. Without MegaShapes, you can still import external flow data and use all particle/rigidbody controllers.
- Complementary to Mega Cache (141): Mega Cache replays baked mesh/particle data, Mega Flow provides live vector field physics. Use together for full DCC-to-Unity simulation pipeline.
- No overlap with VFX Graph -- Mega Flow provides data (vector fields), VFX Graph could consume it via Texture3D export
- Orthogonal to Staggart water pipeline (039-041) -- different approach to water effects

**Concerns:**
- **Hyphenated folder name** (`Mega-Fiers`) is the old convention -- won't cause compile errors but is inconsistent with MegaFiers 2's folder naming
- No namespace
- Legacy threading (System.Threading, not Jobs/Burst)
- Requires external DCC tools (FumeFX, RealFlow, Houdini) OR MegaShapes for content creation -- no standalone flow solver
- Last code update May 2024 (store page updated Jan 2026 -- likely just compatibility tag)
- Soft-body solver is abandoned code (`#if false` blocks)

**Verdict Rationale:** Approved without default label. Professional vector field system with genuine physics (not fake wind noise). The DCC import pipeline is strong and the multi-threaded particle advection scales well. Project-specific -- include when you need physically-driven particle flow (smoke, water currents, wind tunnels, leaves, lava). Requires either external sim data or MegaShapes for content creation.

**HOK Relevance:** MEDIUM-HIGH. Acheron river currents could drive floating debris particles. Styx mist flowing around obstacles. Wind affecting Full Rig (140) rope swing. Tartarus smoke/flame particle advection. The MegaShapes spline-based flow creation maps well to river/channel paths already defined in HOK's spline system.

**FearSteez Relevance:** LOW. Beat 'em up gameplay doesn't need fluid simulation. Possible minor use for environmental smoke/dust in fight arenas, but standard particle systems are simpler.

**3D Concept Projects Relevance:** MEDIUM. Action/adventure games (Alpha Foxtrot Uniform, Cursed Fantasy, Miracle Worker) could use flow fields for environmental effects -- wind, water, volcanic smoke.

---

### ENTRY-144: Mega Scatter (Chris West)

| Field | Value |
|-------|-------|
| Source | Asset Store |
| Version | 1.50 |
| Price | $50 |
| Rating | 5 stars (54 ratings) |
| Publisher | Chris West |
| Category | Editor Extensions / Modeling |
| Verdict | **Approved** |
| Label | -- (project-specific) |
| Date | 2026-02-24 |
| URP | Yes |
| HDRP | Yes |
| Min Unity | 2019.4.14 |

**What it is:** Spline-based procedural object/vegetation scattering system. Defines placement regions via MegaShapes splines (closed areas or along paths), then fills them with randomized meshes or GameObjects. Supports texture-driven density, slope/height constraints, overlap detection, and mesh batching for reduced draw calls.

**Architecture:**
- 14 scripts (8 runtime ~4,800 lines, 6 editor ~2,900 lines), no asmdef, NO namespace (global)
- Installs to `Assets/Mega-Fiers/MegaScatter/` (hyphenated folder, same as Mega Flow)
- 118 MB total (102 MB is demo content -- core code ~13 KB)
- 6 custom surface shaders for wind-animated vegetation
- Two output modes: combined mesh (batched, 1 draw call per layer) or individual GameObjects

**Key Features:**
- **Spline regions:** Closed MegaShapes splines define scatter areas with hole detection (nested splines = exclusion zones). Open splines define scatter-along paths.
- **Six scatter variants:** MegaScatterMesh/Object (inside closed spline), MegaScatterMeshAlong/ObjectAlong (along spline path), MegaScatterMeshTexture/ObjectTexture (texture-driven density)
- **Per-layer randomization:** Scale (uniform/non-uniform, per-axis), rotation (per-axis with curves), offset, color variation (gradient list + texture), vertex noise (Perlin jitter)
- **Placement constraints:** Min/max slope angle, min/max height, overlap radius detection, min/max distance from spline, snap-to-grid (position + rotation)
- **Texture-driven density:** RGB channels control placement likelihood, scale, and density. Reads UV coordinates from raycast hits.
- **Mesh batching:** Combined mesh mode = single draw call per layer. Vertex limit configurable (default 65,535).
- **Runtime scatter:** `buildOnStart` flag + coroutine mode (`FillCo()`) spreads placement over frames for progressive loading
- **Wind shaders:** 6 surface shader variants with vertex-animated wind sway (sin/cos displacement, global speed/distance/scale parameters)
- **Collision proxy:** Optional simplified mesh collider separate from visual mesh
- **Callback system:** `MegaScatterQuery` virtual class for custom per-project placement rules

**Code Quality:**
- Clean layer-based architecture with well-separated concerns (base/mesh/object/along/texture variants)
- No per-frame allocations in placement loop (pre-allocated arrays)
- Raycast-based ground snapping with multi-point validation (avoids holes/gaps)
- No namespace (Chris West pattern)
- No Burst/Jobs (managed code, acceptable for editor-time scatter)
- `[ExecuteInEditMode]` for live preview during spline editing

**Cross-Asset Notes:**
- **Requires MegaShapes** -- tight dependency on `MegaShape` class for spline containment, nearest-point queries, and area calculations. Cannot function without MegaShapes (137) or MegaFiers 2 (136, which includes basic MegaShape).
- Complementary to Mega Flow (143): scatter vegetation, then Mega Flow drives wind animation on the scattered objects
- Wind shaders overlap slightly with GPU Instancer or Nature Renderer patterns, but are self-contained
- No overlap with Unity Terrain detail system -- different approach (spline regions vs heightmap painting)
- Orthogonal to ProBuilder (geometry) -- Mega Scatter places objects ON surfaces, ProBuilder creates the surfaces

**Concerns:**
- Hyphenated `Mega-Fiers` folder (old naming convention)
- No namespace
- MegaShapes dependency is hard (not optional like Mega Flow)
- Surface shaders are legacy (not URP Shader Graph) -- wind animation works but shaders may need URP conversion for production
- Demo content is 102 MB (delete after eval)
- No GPU instancing support in scatter code (mesh batching is CPU-side)

**Verdict Rationale:** Approved without default label. Professional spline-based scattering with genuine placement constraints and batching. The spline-driven approach is more flexible than terrain painting for defined areas (paths, groves, riverbanks, battlefields). Project-specific -- include alongside MegaShapes when you need procedural vegetation/object placement in spline-defined regions.

**HOK Relevance:** HIGH. Acheron riverbanks with scattered reeds/rocks along spline paths. Underworld vegetation zones defined by area splines. Dock areas with scattered debris/equipment. The along-spline mode maps directly to HOK's existing spline-based river/path system.

**FearSteez Relevance:** LOW. 2.5D beat 'em up stages are typically hand-crafted, not procedurally scattered.

**3D Concept Projects Relevance:** HIGH. Any 3D project with outdoor environments (Alpha Foxtrot Uniform, Cursed Fantasy, Miracle Worker, GRIMMORPG, Space Garbage Man) would benefit from spline-based vegetation/prop scattering.

**A Quokka Story Relevance:** MEDIUM. 2.5D Metroidvania could use along-spline scattering for background vegetation layers, though foreground elements are typically placed by hand.

---

### ENTRY-145: Mega Wires (Chris West)

| Field | Value |
|-------|-------|
| Source | Asset Store |
| Version | 1.22 |
| Price | $45 |
| Rating | 4 stars (23 ratings) |
| Publisher | Chris West |
| Category | Editor Extensions / Modeling |
| Verdict | **Approved** |
| Label | -- (project-specific) |
| Date | 2026-02-24 |
| URP | Yes |
| HDRP | Yes |
| Min Unity | 2019.4.14 |

**What it is:** Dynamic wire/cable physics system with Verlet mass-spring simulation. Generates procedural stranded cable meshes between poles with real-time wind response, object attachment (with weight), and an integrated pole planting workflow. Designed for power lines, telegraph wires, hanging cables, suspension bridges, and environmental rigging.

**Architecture:**
- 31 scripts (17 runtime ~5,600 lines, 14 editor ~1,800 lines), no asmdef, NO namespace (global)
- Installs to `Assets/MegaWire/` (NOT in `Mega-Fiers` or `MegaFiers` -- standalone folder)
- 59 MB total (demo scene ~3 MB, most size is 42 pole FBX models + textures)
- No custom shaders (uses Standard materials)
- Verlet integration solver with Catmull-Rom spline interpolation for smooth curves

**Key Features:**
- **Verlet mass-spring physics:** Iterative constraint solver with configurable stiffness, damping, and stretch. Gravity sag responds naturally to span length and mass.
- **Multi-strand cables:** Procedural mesh extrusion with twisted strand support (realistic braided cables, not just tubes)
- **Wind system:** Dedicated `MegaWireWind` with planar (directional) and spherical (radial) modes, Perlin noise turbulence, strength/direction variation over time
- **Object attachment:** `MegaWireAttach` (non-physical, follows wire) and `MegaWireHanger` (adds weight, affects sag). Birds on wires, hanging signs, lanterns.
- **Pole planting:** `MegaWirePlantPolesList` for waypoint-based auto-placement with terrain conforming, random variation, and closed-loop support
- **LOD system:** Distance/visibility-based disable for performance
- **Floating origin:** `MegaWireOrigin` handles large-world coordinate shifts
- **42 pole prefabs:** Pre-configured FBX models with connection point definitions
- **MegaFlow integration:** Commented out (`#if false`) but designed to use Mega Flow vector fields as wind source
- **MegaShapes integration:** Commented out (`#if false`) for spline-based pole planting

**Code Quality:**
- Clean separation: physics solver, mesh builder, wind system, pole planter are all independent modules
- Verlet solver is straightforward and well-structured
- Catmull-Rom interpolation gives smooth visual curves from coarse physics masses
- No namespace (Chris West pattern)
- No Burst/Jobs (managed Verlet -- fine for typical wire counts)
- `[ExecuteInEditMode]` for live editor preview

**Cross-Asset Notes -- Chris West Rope/Wire/Cable Overlap:**

This is the key comparison across the Chris West catalog:

| Feature | Full Rig (140) | Mega Wires (145) | MegaShapes Rope (137) |
|---------|---------------|-------------------|----------------------|
| **Physics** | Catenary (analytical) | Verlet mass-spring | Verlet integration |
| **Best for** | Static/slow-swing ropes | Dynamic cables with wind | Interactive/dynamic rope |
| **Wind response** | Sinusoidal swing only | Full wind system (Perlin) | None built-in |
| **Object attach** | Attached objects follow curve | Hangers with weight affect sag | No |
| **Stranded mesh** | No (single rope) | Yes (twisted multi-strand) | No (loft profile) |
| **Pole system** | No | Yes (42 prefabs) | No |
| **LOD** | Visibility culling | Distance + visibility | No |
| **Floating origin** | No | Yes | No |
| **CPU cost** | Lowest (analytical) | Medium (iterative Verlet) | Medium (Verlet) |
| **MegaFiers dep** | No | No (optional MegaShapes/Flow) | Part of MegaShapes |
| **Use case** | Ship rigging, dock tethers | Power lines, cables, hanging objects | Rope bridges, grapple ropes |

**Recommendation:** For HOK, Full Rig (140) and Mega Wires (145) serve different roles. Full Rig for Kharon's ferry rigging (static catenary ropes). Mega Wires for dock/harbor cables, hanging lanterns, telegraph wires between Acheron waypoints. They complement, not compete.

**Concerns:**
- No namespace
- MegaFlow/MegaShapes integration disabled (`#if false`) -- would need manual uncommenting
- No Burst/Jobs
- Last code update May 2024 (store page updated Jan 2026)

**Verdict Rationale:** Approved without default label. Professional dynamic wire system with genuine physics, wind, and object attachment. The pole planting workflow and 42 included pole prefabs make it immediately productive. Project-specific -- include when you need dynamic cables/wires with environmental interaction (power lines, harbor rigging, hanging objects, suspension bridges).

**HOK Relevance:** MEDIUM-HIGH. Dock/harbor cables, hanging lanterns along the Styx, telegraph-style wires between underworld waypoints. The hanger system (objects that affect wire sag) adds environmental storytelling. Complements Full Rig's static rigging on Kharon's ferry.

**FearSteez Relevance:** LOW. Beat 'em up doesn't typically need wire physics. Possible minor use for background power lines in urban stages.

**3D Concept Projects Relevance:** HIGH. Power lines, cables, and hanging objects are universal environmental props for any 3D game (Alpha Foxtrot Uniform, Cursed Fantasy, Miracle Worker, GRIMMORPG, Space Garbage Man).

---

### ENTRY-096-R: Full Sail -- Re-Evaluation (Desk Review, Chris West)

| Field | Value |
|-------|-------|
| Source | Asset Store |
| Version | 1.26 |
| Price | $50 |
| Rating | 5 stars (6 ratings) |
| Publisher | Chris West |
| Category | Editor Extensions / Modeling |
| Verdict | **Conditional** |
| Label | -- |
| Date | 2026-02-24 (re-eval) |
| URP | Yes (separate .rar extraction) |
| HDRP | Yes (separate .rar extraction) |

**Original verdict (ENTRY-096, Session 34):** Rejected, Don't Use. Sail simulation VFX.

**Re-evaluation context:** Does Full Sail gain value when considered alongside the full Chris West ecosystem (MegaFiers 2, MegaShapes, Full Rig, Mega Wires, Mega Flow, Mega Scatter)?

**Assessment:**
- Full Sail handles furl/unfurl mechanics that MagicaCloth 2 cannot replicate -- it's specialized sail behavior, not general cloth simulation
- HOK's ferry (Kharon's raft) is a 3m x 2m raft -- no mast or sails. Not relevant to HOK.
- No other active TecVooDoo project currently involves sailing, but any future naval or ship project would need exactly this
- The furl/unfurl capability is genuinely unique -- no other evaluated asset covers it
- Only 6 ratings suggests very niche community
- URP/HDRP shaders ship as .rar archives requiring manual extraction (same pattern as Full Rig)

**Verdict: Rejected upheld.** No current or planned TecVooDoo project needs sail simulation. If a sailing project enters the pipeline, re-evaluate at that time.

---

### Chris West Ecosystem -- Internal Overlap Analysis

After evaluating 11 Chris West assets (136-145 + 096), here's how they relate to each other:

**Tier 1 -- Foundation (install these first if using any Chris West assets):**
- **MegaFiers 2 (136)** -- Core mesh deformation. Includes basic MegaShape primitives.
- **MegaShapes (137)** -- Full spline/loft system. Required by Mega Scatter, optional for Mega Flow/Mega Wires.

**Tier 2 -- Physics/Simulation (pick based on project needs):**
- **Full Rig (140)** -- Static catenary ropes (ship rigging, dock tethers). Standalone.
- **Mega Wires (145)** -- Dynamic cables with wind/hangers (power lines, harbor). Standalone.
- **Mega Flow (143)** -- Vector field physics (river currents, wind, smoke). Optional MegaShapes dep.

**Tier 3 -- Content Creation (project-specific):**
- **Mega Scatter (144)** -- Procedural vegetation/prop placement. Requires MegaShapes.
- **Mega Cache (141)** -- DCC simulation playback (Houdini/Blender bakes). Standalone.
- **Texture Studio (142)** -- GPU texture compositing with runtime API. Standalone.
- **MegaBook 2 (138)** -- 3D page-turning book. Standalone.

**Tier 4 -- Niche/Skip:**
- **Vulcan (139)** -- Procedural flame mesh (rocket thrusters only). Conditional.
- **Full Sail (096)** -- Sail simulation. Rejected (no sailing projects).

**Key overlap areas:**
- **Rope/Wire/Cable:** Full Rig (catenary/static) vs Mega Wires (Verlet/dynamic) vs MegaShapes (Verlet/interactive). Three different approaches for three different use cases. No true redundancy.
- **Flow/Wind:** Mega Flow provides vector fields. Mega Wires has its own wind system. Mega Scatter has wind shaders. These are independent implementations -- Mega Flow COULD drive Mega Wires wind (`#if false` integration exists) but doesn't by default.
- **Mesh deformation vs caching:** MegaFiers 2 (real-time deform) vs Mega Cache (baked playback). Complementary, not competing.
- **Spline dependency chain:** MegaShapes -> Mega Scatter (hard dep), Mega Flow (optional), Mega Wires (optional). If you're using Mega Scatter, you already have MegaShapes.

---

### ENTRY-146: MudBun: Volumetric VFX & Modeling (Long Bunny Labs)

| Field | Value |
|-------|-------|
| Source | Asset Store |
| Version | 1.6.52 |
| Price | $75 |
| Rating | 5 stars (45 ratings) |
| Publisher | Long Bunny Labs (Ming-Lun "Allen" Chou) |
| Category | Editor Extensions / Effects |
| Verdict | **Approved** |
| Label | -- (project-specific) |
| Date | 2026-02-24 |
| URP | Yes (full shader graph support) |
| HDRP | Yes (full shader graph support) |
| Min Unity | 2021.3.23 |

**What it is:** GPU-accelerated volumetric SDF (Signed Distance Field) modeling and VFX system. Create, combine, and deform SDF primitives in real-time to generate meshes, splats, decals, ray-marched surfaces, or ray-traced voxels. Think "digital clay sculpting in Unity" with boolean operations, noise deformation, and multiple rendering modes.

**Architecture:**
- 85 scripts (68 runtime, 17 editor) with 4 asmdef files (`MudBun`, `MudBun.Editor`, `MudBun.Manager`, `MudBun.Customization.Editor`)
- Proper namespace isolation via asmdef (unlike Chris West assets)
- `allowUnsafeCode: true` for native memory operations
- 10 compute shaders for GPU mesh generation
- 54 CGINC shader includes (SDF math, noise, marching cubes, voxel hashing)
- 44 material files (URP/HDRP/Built-in presets: Clay, Claymation, Floater, Brush Strokes, etc.)
- 94 MB total, 605 files
- Uses Burst, Jobs, and Compute Shaders extensively

**Key Features:**
- **SDF Primitives:** Sphere, Box (rounded), Cylinder, Cone, Torus, Solid Angle, Catmull-Rom curves (simple + full)
- **Boolean Operations:** Union, Intersection, Subtraction -- each with 6 smooth blending variants (quad, cubic, round, chamfer, exponential, power)
- **Modifiers:** Noise deformation (FBM, Voronoi, lattice), Onion shells
- **Distortions:** Fish-eye, Pinch, Quantize (voxelize), Twist
- **5 Rendering Modes:** Mesh, Splats, Decal, Ray-Marched Surface, Ray-Traced Voxels
- **4 Meshing Algorithms:** Marching Cubes, Dual Contouring, Surface Nets, Dual Meshing -- all GPU compute
- **CPU SDF Evaluation:** Burst-compiled `SdfEval` for gameplay code (raycasts, distance queries, material sampling) with async job support
- **Particle System Integration:** `MudParticleSystem` bridges Unity particles to SDF brushes
- **Brush Groups:** Hierarchical brush organization with per-group blend radius
- **Mesh Locking:** Bake dynamic SDF to static mesh for performance
- **15+ Material Presets:** Clay, Claymation, Floater, Leaf, Floof, Brush Strokes, Outline, SDF Ripple, Stopmotion, alpha-blended variants
- **Custom Brush API:** `RegisterSdfBrushEvalFuncAttribute` for user-defined SDF functions

**Code Quality:**
- Professional architecture with proper asmdef isolation
- Heavy Burst/Jobs usage for CPU paths (~10x speedup)
- GPU compute for mesh generation (marching cubes, dual contouring, surface nets)
- AABB tree spatial acceleration for brush evaluation
- Object pooling, native arrays, minimal GC allocations
- Amplify Shader Editor integration for material authoring
- Well-documented shader math (references Inigo Quilez SDF functions)

**Cross-Asset Notes:**
- Standalone -- no dependencies beyond Unity packages (Burst, Collections, Jobs)
- No overlap with MegaFiers 2 (136): MegaFiers deforms existing meshes, MudBun generates new meshes from SDF. Complementary.
- Could work alongside ProBuilder: ProBuilder for hard-surface editing, MudBun for organic/blobby shapes
- No overlap with VFX Graph -- different domain (mesh generation vs particle effects)
- The SDF evaluation API could theoretically feed into other systems (custom colliders, AI navigation, etc.)

**Concerns:**
- $75 is moderate but justified for the tech depth
- 94 MB footprint (43 MB is Amplify Shader Editor integration)
- Compute shader requirement -- won't work on low-end mobile GPUs without fallback
- Learning curve is steep (SDF concepts, boolean operations, meshing algorithm tradeoffs)
- Last update Feb 2025 -- active development
- 30+ internal compatibility .unitypackage files for different pipeline versions -- setup could be confusing

**Verdict Rationale:** Approved without default label. Genuinely impressive technical asset -- GPU SDF mesh generation with multiple algorithms, full Burst/Jobs optimization, and proper asmdef architecture. This is the right tool for dynamic organic geometry (clay, blobs, terrain sculpting, VFX meshes). Project-specific -- include when you need runtime volumetric mesh generation or SDF-based VFX.

**HOK Relevance:** MEDIUM. Potential for dynamic underworld terrain morphing (Tartarus lava bubbles, Styx mist volumes), SDF-based water splash VFX, or procedural coral/rock generation. The clay/claymation material presets fit HOK's casual art style. Not core pipeline but valuable for VFX polish.

**FearSteez Relevance:** MEDIUM. Beat 'em up VFX -- impact deformation, destructible environment pieces, stylized hit effects (clay splatter, stopmotion). The splat and brush stroke rendering modes could create a distinctive visual identity.

**3D Concept Projects Relevance:** HIGH. Any 3D project benefits from SDF modeling for prototyping, terrain, VFX, and organic geometry. Particularly valuable for:
- GRIMMORPG (horror -- organic morphing environments)
- Miracle Worker (action-horror -- body horror VFX)
- Forensic Science Practical Lab (VR -- procedural tissue/organ models for education)

**A Quokka Story / 2D Projects Relevance:** LOW. 2D games don't need volumetric mesh generation.

---

### ENTRY-147: Runtime Transform Gizmos Standard (Octamodius)

| Field | Value |
|-------|-------|
| Source | Asset Store |
| Version | 1.2.0 |
| Price | $25 |
| Rating | 5 stars (33 ratings) |
| Publisher | Octamodius |
| Category | Editor Extensions / Modeling |
| Verdict | **Approved** |
| Label | Default 3D |
| Date | 2026-02-24 |
| URP | Yes (render features included) |
| HDRP | Not tested |
| Min Unity | 6000.0.36 (Unity 6) |

**What it is:** Full runtime transform gizmo system -- move, rotate, scale, box-scale, and combined TRS handles that work in built games, not just the editor. Provides Unity-editor-style transform manipulation at runtime for level editors, sandbox tools, modding systems, or any game that lets players place/arrange objects.

**Architecture:**
- 209 scripts (188 runtime, 6 editor inspectors, 9 editor UI, 6 tutorials), NO asmdef
- `RTGStandard` namespace -- clean isolation despite no asmdef
- 66 MB total (mostly textures and tutorial scenes -- core code ~1.2 MB)
- 5 custom shaders (unlit handle rendering, grid, 2D gizmo, camera background)
- Self-contained singleton architecture: RTG (core), RTGizmos (engine), RTScene, RTCamera, RTInput, RTUndo
- Modular: gizmo engine, input system, undo/redo, math library, mesh utils, resource managers

**Key Features:**
- **5 Transform Gizmos:** Move (with vertex snap), Rotate, Scale, BoxScale (interactive box resize), TRS (combined)
- **13+ Component Gizmos:** BoxCollider, CapsuleCollider, SphereCollider (2D+3D), DirectionalLight, PointLight, SpotLight, AudioSource, AudioReverbZone, CharacterController, Terrain, Camera, ExtrudeGizmo
- **Pivot modes:** Pivot (individual) and Center (group center)
- **Transform spaces:** Local and Global coordinate systems
- **Snapping:** Grid-based (absolute/relative), vertex snapping for move operations
- **Undo/Redo:** Full undo system with 14+ component-specific state types (transform, collider, light, audio, terrain)
- **Input system:** Configurable shortcuts, profiles, multiple input devices
- **View gizmo:** Mini orientation gizmo (like Unity editor corner widget)
- **Multi-viewport:** Multiple camera viewport support
- **Skin system:** Customizable gizmo appearance via ScriptableObject skins
- **URP integration:** 3 render feature scripts for proper gizmo rendering in SRP
- **Selection manager:** Multi-object selection with scene object tree (AABB spatial acceleration)

**Code Quality:**
- Clean `RTGStandard` namespace throughout
- Extensive math library (23 scripts -- geometry, intersection, ray-casting, snapping)
- Professional handle system (GizmoLineSlider, GizmoPlaneSlider, GizmoCap, GizmoArc)
- Full undo/redo architecture with operation pattern
- No Burst/Jobs (managed code -- appropriate for UI-frequency gizmo interactions)
- 38 extension method classes for Unity types (comprehensive utility library)
- `[ExecuteInEditMode]` for editor preview

**Cross-Asset Notes:**
- Standalone -- zero external dependencies
- No overlap with Unity's built-in editor handles (those only work in editor, this works at runtime)
- Could integrate with ProBuilder for a runtime level editor pipeline
- Complementary to any asset that needs runtime object placement (Mega Scatter for design-time, RTG for player-time)

**Concerns:**
- No asmdef (compiles into Assembly-CSharp) despite having a namespace
- 66 MB is chunky for what's essentially a UI tool (tutorial scenes + textures)
- Unity 6 minimum -- won't work in older projects
- "Standard" version implies a "Pro" tier may exist with additional features

**Verdict Rationale:** Approved with **Default 3D** label. Any 3D project that might need runtime object manipulation benefits from having this available. Level editors, sandbox modes, debug tools, modding support -- this is foundational infrastructure. The $25 price point is excellent for the feature depth.

**HOK Relevance:** MEDIUM. Runtime placement of fishing spots, dock furniture, or player-customizable raft decorations. Debug tool for positioning spline waypoints at runtime.

**FearSteez Relevance:** LOW. Beat 'em up doesn't typically expose object placement to players. Could be useful as a dev debug tool for stage layout.

**3D Concept Projects Relevance:** HIGH across the board:
- GRIMMORPG (3D Point 'N Click) -- room/puzzle object placement
- Space Garbage Man (3D Point 'N Click) -- item interaction/placement
- Alpha Foxtrot Uniform, Cursed Fantasy, Miracle Worker -- level editor/modding support
- Forensic Science Practical Lab (VR) -- evidence placement, scene reconstruction

**2D Projects Relevance:** LOW. 2D games don't need 3D transform gizmos. A 2D equivalent would be needed for DLYH, Shrunken Head Toss, etc.

---

### ENTRY-148: Fluffy Grooming Tool (Daniel Zeller)

| Field | Value |
|-------|-------|
| Source | Asset Store |
| Version | 1.2.3 |
| Price | $60 |
| Rating | 5 stars (42 ratings) |
| Publisher | Daniel Zeller |
| Category | Editor Extensions / Modeling |
| Verdict | **Approved** |
| Label | -- (project-specific) |
| Date | 2026-02-24 |
| URP | Yes |
| HDRP | Yes (15.0.6+) |
| Min Unity | 2021.2.0 |

**What it is:** GPU-accelerated fur/hair grooming and rendering system. Paint-based workflow for creating, styling, and rendering fur/hair strands on any mesh. Includes Verlet physics simulation, SDF collision, LOD, frustum culling, depth sorting, and Alembic animation support. Think "Blender hair grooming inside Unity."

**Architecture:**
- 81 scripts (41 runtime ~4,800 lines, 38 editor ~4,800 lines, 2 example), 2 asmdef files
- `FluffyGroomingTool` namespace with proper asmdef isolation (`allowUnsafeCode: true`)
- 294 MB total (150 MB is pre-groomed example assets, 84 MB textures -- core engine ~5 MB)
- 9 compute shaders (grooming, physics, culling, sorting, baking, SDF collision, Alembic skinning)
- Data: FurContainer (strand data SO), GroomContainer (paint properties SO)

**Key Features:**
- **15 paint operations:** Height, Width, Raise, Direction Root/Bend/Orientation, Twist, Wind contribution, Clumping Mask, Color Override, Add/Delete Fur, Reset, Smooth, Attract, Mask
- **Layer system:** Multi-layer grooming with per-layer height range, width range, randomness
- **Clumping:** Layer-based clump modifiers with independent spacing control
- **Verlet physics:** Runtime simulation with gravity, drag, collision, shape constraints
- **SDF collision:** Custom SDF collider system (sphere/capsule) for body collision
- **Rendering:** GPU instanced strand rendering (LINE or TRIANGLE_MESH modes), frustum culling, bitonic merge sort for depth ordering
- **LOD system:** Distance-based strand reduction via FluffyRenderersController
- **Mesh baking:** Bake strands to static mesh for performance (MeshBaker compute shader)
- **Alembic support:** Import groomed animations from DCC tools (optional dependency)
- **Mirror painting:** Symmetric grooming across defined axis
- **Undo/Redo:** Custom undo recorder for all paint operations
- **24 pre-groomed examples:** Character hair, body fur, collar fur with layered styling

**Code Quality:**
- Professional architecture with proper asmdef isolation and namespace
- Heavy compute shader usage for GPU-driven pipeline (9 compute shaders)
- AsyncGPUReadback for non-blocking GPU-to-CPU data transfer
- Custom threading (PointsOnMeshJob) but NOT using Unity.Jobs IJob interface
- No Burst compilation -- managed C# with compute shader offload
- FurContainer/GroomContainer ScriptableObject pattern for serialized groom data
- Well-separated editor/runtime concerns via dual asmdef

**Cross-Asset Notes:**
- Standalone -- no dependencies on other evaluated assets
- No conflict with MagicaCloth 2 -- different domains (fur rendering vs cloth simulation). Could coexist on same character (cloth for garments, Fluffy for hair/fur).
- MegaFiers 2 (136) mesh deformation could drive the source mesh that Fluffy grooms onto
- No overlap with Dynamic Bone (not used in HOK pipeline anyway)
- SDF collider system is independent and simpler than MudBun's (146) SDF -- purpose-built for body collision, not volumetric modeling

**Concerns:**
- 294 MB footprint is large (but 234 MB is examples/textures that can be deleted)
- Last update Feb 2024 -- over a year old, unclear if Unity 6 tested
- No Burst optimization for CPU paths
- Compute shader requirement -- won't work on platforms without compute support
- URP shader support requires importing separate .unitypackage (Assets/FluffyGroomingTool/Shaders/UrpShaders.unitypackage)
- Pipeline-specific examples also require separate .unitypackage imports
- Fur rendering is GPU-intensive -- mobile viability is limited

**Verdict Rationale:** Approved without default label. Production-quality grooming pipeline with genuine paint-based workflow and GPU-accelerated rendering. Project-specific -- include when characters or creatures need fur/hair. The compute shader architecture ensures good performance on desktop/console but limits mobile use.

**HOK Relevance:** MEDIUM. Kharon could have a fur-lined cloak or hood. Companion creatures (if any) would benefit from groomed fur. The raft could have rope fraying effects using strand rendering. Not core pipeline but adds visual polish for character detail.

**FearSteez Relevance:** LOW. 2.5D beat 'em up characters are typically stylized with painted textures, not strand-based fur/hair. Possible use for a furry/beast character but unlikely to be core pipeline.

**3D Concept Projects Relevance:** HIGH for creature/character-heavy projects:
- A Quokka Story -- quokka protagonist needs fur (MEDIUM, 2.5D may limit value)
- Cursed Fantasy -- fantasy creatures with fur/hair
- Miracle Worker -- horror creatures
- Murder Malady & Monsters (3D VN) -- monster character fur/hair
- Alpha Foxtrot Uniform -- tactical military, LOW (human characters, no fur)

**2D/VN Projects Relevance:** NONE. Fur grooming is purely 3D.

---

### ENTRY-149: Runtime Transform Handles (Battlehub / Vadim Andriyanov)

| Field | Value |
|-------|-------|
| Source | Asset Store |
| Version | 4.4.4 |
| Price | $25 |
| Rating | 5 stars (61 ratings) |
| Publisher | Vadim Andriyanov (Battlehub) |
| Category | Editor Extensions / Modeling |
| Verdict | **Approved** |
| Label | Default 3D |
| Date | 2026-02-24 |
| URP | Yes (separate .unitypackage) |
| HDRP | Yes (separate .unitypackage) |
| Min Unity | 2021.3.31 |

**What it is:** Runtime transform handles system for in-game object manipulation -- move, rotate, scale, rect tool, scene gizmo, grid, box selection, undo/redo. Designed for runtime level editors, modding tools, and sandbox games. Full mobile touch support and experimental VR tools.

**Architecture:**
- 170 scripts (106 runtime, 4 editor, ~60 demo/third-party), 5 asmdef files
- `Battlehub.RTHandles` and `Battlehub.RTCommon` namespaces with proper asmdef isolation
- 136 MB total (30+ MB demo character FBX, rest is scenes/materials -- core engine ~2 MB)
- 23 custom shaders (axis rendering, grid, selection outline, handle shapes)
- Includes UIShapesKit third-party library for UI shape drawing
- Command buffer rendering for efficient procedural handle drawing

**Key Features:**
- **5 transform tools:** Move (Position), Rotate, Scale, Rect (2D orthographic), View
- **Vertex snapping:** Snap to mesh vertices during move
- **Snap-to-ground:** Physics raycast snapping with rotation alignment
- **Bounding-box snapping:** Snap to bounds corners of other objects
- **2D constraint modes:** XY, XZ, YZ constrained movement
- **Free rotation:** Full quaternion rotation, not just gimbaled axes
- **Screen-space rotation:** Camera-aligned rotation mode
- **Scene gizmo:** 6-axis orientation cube with orthographic/perspective toggle
- **Infinite grid:** Configurable ground plane (SceneGrid)
- **Box selection:** Frustum-culled marquee selection
- **Outline rendering:** Custom selection outline prepass
- **Mobile touch support:** Full touch-based UI with MobileSceneControls
- **VR experimental:** 5 VR-specific tools included
- **Runtime undo/redo:** Full state tracking system
- **Custom handle models:** Replaceable visual models (arrows, rings, cubes)
- **Per-axis locking:** LockObject system for constraining axes
- **Multi-select:** RuntimeSelectionComponent with filtering and events
- **Pivot modes:** Center, Pivot, Custom
- **Local/Global toggle:** Per-object coordinate space

**Code Quality:**
- Professional architecture with 5 asmdef files and clean namespace separation
- Command buffer rendering for efficient handle drawing (no per-frame mesh creation)
- Proper input abstraction (desktop + mobile + VR)
- Event-driven drag system (BeforeDrag, Drag, Drop callbacks)
- RuntimeUndo with full state tracking
- v4.4.4 -- mature, well-iterated codebase
- Good documentation with GitHub docs site

**Comparison with Runtime Transform Gizmos (ENTRY-147, Octamodius):**

| Feature | RTHandles (149, Battlehub) | RTGizmos (147, Octamodius) |
|---------|---------------------------|---------------------------|
| **Price** | $25 | $25 |
| **Ratings** | 61 (5-star) | 33 (5-star) |
| **Version** | 4.4.4 (mature) | 1.2.0 (newer) |
| **asmdef** | Yes (5 files) | No |
| **Namespace** | Battlehub.RTHandles | RTGStandard |
| **Mobile** | Full touch support | No |
| **VR** | Experimental (5 tools) | No |
| **Component gizmos** | No | Yes (13+ types: colliders, lights, audio, terrain) |
| **Scene gizmo** | Yes (orientation cube) | Yes (view gizmo) |
| **Box selection** | Yes | Yes |
| **Vertex snap** | Yes | Yes |
| **Snap-to-ground** | Yes (raycast) | No explicit |
| **2D modes** | Yes (XY/XZ/YZ) | No explicit |
| **Rect tool** | Yes | No |
| **Outline** | Yes (custom prepass) | No |
| **Command buffer** | Yes | No (direct render) |
| **Size** | 136 MB | 66 MB |

**Bottom line:** RTHandles (Battlehub) is the better **runtime editor framework** -- mobile/VR, command buffer rendering, more mature. RTGizmos (Octamodius) is the better **component manipulation tool** -- 13+ specialized component gizmos (colliders, lights, audio). They target slightly different use cases. For a general-purpose "Default 3D" pick, RTHandles edges ahead on maturity and platform coverage, but RTGizmos fills gaps RTHandles doesn't (component-level editing).

**Recommendation:** Keep BOTH with Default 3D label. Use RTHandles for player-facing editors/sandbox modes. Use RTGizmos for developer debug tools needing component gizmos.

**Cross-Asset Notes:**
- Direct competitor to Runtime Transform Gizmos (147) -- see comparison table above
- Could integrate with ProBuilder for a full runtime level editor
- No conflict with any other evaluated asset
- Battlehub also sells "RT Editor" (full runtime editor) which is the extended version of this

**Concerns:**
- 136 MB is chunky (30 MB is demo character FBX)
- URP/HDRP require separate .unitypackage extraction
- Demo assets are substantial -- should be deleted for production
- UIShapesKit third-party dependency is bundled (not a separate package)
- v4.4.4 but last store update Oct 2024 -- 4 months old

**Verdict Rationale:** Approved with **Default 3D** label. More mature than RTGizmos (v4.4.4 vs v1.2.0), more community validation (61 vs 33 ratings), and broader platform coverage (mobile + VR). Same $25 price point. The command buffer rendering and proper asmdef architecture make it the stronger pick for production runtime editors.

**HOK Relevance:** MEDIUM. Same as RTGizmos -- runtime object placement, debug tools, potential player-customizable raft decorations. Mobile support is a plus if HOK targets mobile.

**FearSteez Relevance:** LOW. Beat 'em up doesn't need runtime transform handles.

**3D Concept Projects Relevance:** HIGH across the board -- same as RTGizmos (147). Runtime level editors, modding support, sandbox mechanics. The mobile/VR support adds value for Forensic Science Practical Lab (VR project).

**2D Projects Relevance:** LOW. The Rect tool and 2D modes exist but are overkill vs simpler 2D handle solutions.

---

### ENTRY-150: Mesh Optimizer (IndieChest / Mattias Edlund)

| Field | Value |
|-------|-------|
| Source | Asset Store |
| Version | 1.1 |
| Price | Free ($0) |
| Rating | 4 stars (62 ratings) |
| Publisher | IndieChest (original author: Mattias Edlund / Whinarn) |
| Category | Scripting / Modeling |
| Verdict | **Approved** |
| Label | Default 3D |
| Date | 2026-02-24 |
| URP | Yes |
| HDRP | Yes |
| Min Unity | 2019.4.32 |

**What it is:** QEM-based mesh decimation and LOD generation tool. Simplifies meshes by iteratively collapsing edges with the lowest error (Quadric Error Metric / Garland-Heckbert algorithm). Runtime-capable -- can decimate meshes in built games, not just the editor. Includes automatic LOD group generation and mesh combining. MIT licensed.

**Architecture:**
- 17 scripts (14 runtime ~5,600 lines, 3 editor ~660 lines), 2 asmdef files
- `IndMeshSimplifier` namespace with proper asmdef isolation (`Whinarn.IndMeshSimplifier.Runtime`, `.Editor`)
- 106 MB total (19 MB is example OBJ city model -- core engine ~500 KB)
- Pure C# -- no Burst, Jobs, compute shaders, or native plugins
- Based on open-source Fast-Quadric-Mesh-Simplification

**Key Features:**
- **Quality-based decimation:** `SimplifyMesh(float quality)` -- target vertex count as fraction of original (0.0-1.0). Configurable iteration count and aggressiveness.
- **Lossless simplification:** `SimplifyMeshLossless()` -- removes only zero-error edges (redundant geometry)
- **Edge preservation:** Preserve border edges (silhouette), UV seam edges, UV foldover edges
- **Vertex welding:** Automatic linking of coincident vertices with configurable max distance
- **Double-precision math:** Custom `Vector3d` struct (64-bit) for precise QEM calculations
- **LOD generation:** `LODGenerator` static class for one-click LOD group creation with configurable quality levels, screen transition heights, and cross-fade modes
- **Mesh combining:** `MeshCombiner` combines multiple static or skinned renderers into single mesh (reduces draw calls)
- **Blend shape preservation:** Maintains morph targets through decimation
- **Skinned mesh support:** Preserves bone weights and bindposes during simplification
- **All UV channels:** Handles 4-8 UV channels with proper interpolation during vertex collapse
- **Runtime capable:** MeshSimplifier works at runtime for dynamic LOD or procedural mesh optimization

**Code Quality:**
- Clean, well-documented implementation (2,606-line core engine is readable)
- `SymmetricMatrix` struct for QEM algorithm is mathematically correct
- Double-precision throughout prevents floating-point drift on large meshes
- Proper asmdef isolation with namespace
- MIT license -- can freely modify and redistribute
- Single-threaded (no parallelization) -- may stall on 100K+ triangle meshes
- `ResizableArray<T>` avoids GC allocations during simplification

**Cross-Asset Notes:**
- Standalone -- no dependencies on any other asset
- Complementary to MegaFiers 2 (136): decimate deformed meshes for performance
- Complementary to MudBun (146): simplify SDF-generated meshes before baking
- Complementary to Fluffy Grooming (148): simplify base mesh before grooming
- No overlap with ProBuilder (ProBuilder creates meshes, Mesh Optimizer reduces them)
- Could feed simplified meshes to Mega Cache (141) for lighter baked sequences

**Concerns:**
- Single-threaded CPU only -- no Burst/Jobs acceleration. Large meshes will block main thread.
- 4-star rating (vs 5-star for most evaluated assets) -- some quality concerns from community
- Free asset -- limited publisher support commitment
- v1.1 with last release Jul 2025 -- minimal iteration history
- Example model is 19 MB (delete after eval)
- QEM algorithm is well-known and available open-source -- this is a convenience wrapper, not unique tech

**Verdict Rationale:** Approved with **Default 3D** label. Free, MIT-licensed, runtime-capable mesh decimation is universally useful for any 3D project. The LOD generation workflow saves significant manual work. The single-threaded limitation is acceptable for editor-time use and small-medium runtime meshes. Being free with no licensing concerns makes it an easy default include.

**HOK Relevance:** MEDIUM. Generate LODs for Acheron environment meshes, ferry, dock structures. Runtime simplification for distant objects. Mesh combining for reducing draw calls on scattered environment props.

**FearSteez Relevance:** LOW-MEDIUM. 2.5D beat 'em up has limited 3D mesh complexity, but LOD generation for background 3D elements is still useful.

**3D Concept Projects Relevance:** HIGH across the board. Every 3D project needs LOD generation and mesh optimization. Particularly valuable for:
- Open-world games (Cursed Fantasy, Alpha Foxtrot Uniform) -- heavy environment LOD needs
- VR (Forensic Science Practical Lab) -- performance-critical, LODs essential
- Point 'N Click (GRIMMORPG, Space Garbage Man) -- mesh combining reduces draw calls

**2D Projects Relevance:** NONE. 2D games don't use 3D meshes.

---

### ENTRY-151: Decal Collider (Occlusionn)

| Field | Value |
|-------|-------|
| **Asset** | DECAL COLLIDER -- Ultimate Runtime Mesh & Collision Decals |
| **Publisher** | Occlusionn |
| **Source** | Asset Store |
| **Category** | Tools (Runtime Mesh & Collision Decals) |
| **Price** | $4.99 |
| **Rating** | 5 stars (8 ratings) |
| **Version** | 1.1.3 |
| **Last Release** | Jan 28, 2026 |
| **Unity Versions** | 2022.3.27+, 6000.0.58+ |
| **Pipeline** | URP, HDRP, BiRP (all three) |
| **Dependencies** | Shader Graph (URP/HDRP) |
| **Install Size** | ~34 MB (includes demo scene + textures) |
| **Slug** | https://assetstore.unity.com/packages/slug/320572 |
| **Purchased** | Dec 10, 2025 |
| **Evaluated** | Feb 24, 2026 (Session 37) |
| **Asset Store Label** | Default 3D |
| **Verdict** | **Approved** |

**What It Does:** Runtime and editor-time decal projection that generates actual mesh geometry conforming to target surfaces, with physics collider generation. Two projection modes: GridProjection (grid-based UV projection onto terrain/meshes) and MeshProjection (project a source mesh onto a target). Unlike Unity's built-in decal projector (screen-space), this creates real geometry that can have colliders, interact with physics, and persist as scene objects.

**Key Features:**
- **Dual projection:** GridProjection for flat/terrain surfaces, MeshProjection for complex geometry
- **Physics-aware collider generation:** Projects decals and generates matching MeshColliders -- useful for walkable decal surfaces, ramps, patches
- **TMP text projection:** Project TextMeshPro text onto 3D surfaces as geometry
- **Sprite live-link:** Reference sprites directly; updates propagate to projected geometry
- **LOD support:** Multiple detail levels for projected meshes
- **Alpha masking:** Texture-based masking for irregular decal shapes
- **Runtime API:** Create and project decals at runtime via script

**Architecture:**
- 6 scripts, 4,802 total lines
- Namespaces: `DecalCollider.Runtime`, `DecalCollider.Editor`
- No asmdef (minor negative, but small codebase)
- Clean namespace usage despite no asmdef
- MonoBehaviour-based components (GridProjection, MeshProjection)
- Custom editor inspectors with preview

**Concerns:**
- Small publisher, low rating count (8) -- longevity risk
- No asmdef means global Assembly-CSharp inclusion
- 34 MB install includes demo assets that should be deleted after eval
- Shader Graph dependency adds pipeline coupling
- Relatively new asset (first release ~late 2025) -- limited track record

**Overlap Analysis:**
- Unity's built-in URP Decal Projector is screen-space only -- no mesh generation, no colliders. This is complementary, not redundant.
- No overlap with any other evaluated asset. Mesh deformation (MegaFiers) operates on existing meshes; this generates new projection meshes.

**Verdict Rationale:** Approved with **Default 3D** label. At $4.99 this is an extremely low-cost tool that solves a real problem -- conforming decals to geometry with actual mesh output and physics colliders. The collider generation is the standout feature: placing walkable patches, ramps, or impact marks that interact with physics. The dual projection system covers both simple (grid) and complex (mesh-to-mesh) use cases. Small publisher risk is mitigated by the low price point and the fact that the core functionality (mesh projection) is straightforward enough to maintain if updates stop.

**HOK Relevance:** MEDIUM-HIGH. Acheron river environment benefits from:
- Dock/pier decals conforming to rock surfaces with colliders for walkability
- Water edge effects projected onto shoreline geometry
- Signage/markings on curved ferry hull
- TMP text projection for in-world labels on irregular surfaces

**FearSteez Relevance:** LOW-MEDIUM. 2.5D beat 'em up has limited use for mesh-conforming decals, but graffiti/damage decals on environment surfaces could add visual flavor. Collider generation less relevant for side-scrolling gameplay.

**3D Concept Projects Relevance:** HIGH across action/adventure titles:
- Alpha Foxtrot Uniform, Cursed Fantasy, Miracle Worker -- environmental storytelling through projected decals with physics (blood splatter you can slip on, ice patches with colliders, magic sigils as walkable surfaces)
- GRIMMORPG, Space Garbage Man (point 'n click) -- projected interaction markers on irregular geometry
- Forensic Science Practical Lab (VR) -- evidence markers projected onto crime scene surfaces with colliders for interaction

**2D Projects Relevance:** NONE. Mesh projection is inherently 3D.

---

### ENTRY-152: EditorSculpt (htomioka)

| Field | Value |
|-------|-------|
| **Asset** | EditorSculpt |
| **Publisher** | htomioka |
| **Source** | Asset Store |
| **Category** | Editor Tool (Mesh Sculpting / Texture Paint) |
| **Price** | Free ($0) |
| **Rating** | 4 stars (38 ratings) |
| **Version** | 1.70 |
| **Last Release** | Oct 13, 2025 |
| **Unity Versions** | 2019.4.41+ (including Unity 6000.3) |
| **Pipeline** | URP, HDRP, BiRP (all three) |
| **License** | MIT (open source as of v1.70) |
| **Dependencies** | None |
| **Install Size** | ~3.7 MB |
| **Slug** | https://assetstore.unity.com/packages/slug/63320 |
| **Purchased** | Sep 27, 2025 |
| **Evaluated** | Feb 24, 2026 (Session 37) |
| **Asset Store Label** | Default 3D |
| **Verdict** | **Approved** |

**What It Does:** In-editor mesh sculpting, texture painting, vertex color painting, blendshape creation, and animation pose editing. A ZBrush-lite experience inside Unity -- deform meshes with brushes, paint textures directly onto surfaces, create morph targets, and edit bone poses without leaving the editor.

**Key Features:**
- **18 standard brushes + 8 beta:** Move, Draw, Lower, Extrude, Dig, Inflate, Pinch, Flatten, Smooth, plus Decal/Spline/Cut beta brushes
- **Texture Paint:** Paint materials directly onto mesh surfaces with blending
- **Vertex Color / Weight Paint:** Direct vertex attribute editing
- **Blendshape creation:** Sculpt morph targets and record them as blend shapes
- **Animation editing:** Sculpt bone poses, create keyframes, MIXAMO/accuRIG compatible
- **AutoRemesh mode:** Dynamic tessellation -- auto-subdivides as you sculpt
- **Symmetry sculpting:** X, Y, Z axis mirroring
- **Mesh primitives:** Create plane, sphere, cube directly in editor
- **Export:** Save as Unity asset or .obj with vertex colors

**Architecture:**
- 2 C# files: EditorSculpt.cs (24,329 lines), EditorSculptPref.cs (26 lines)
- 3 custom shaders (sculpt display, decal, texture mix)
- Namespaces: `EditorSculptEditor`, `EditorSculptPreference`
- No asmdef
- **Editor-only** -- no runtime code, no build impact
- Monolithic single-class architecture (24K lines, 150+ static fields)
- NativeArray usage (126 instances) for mesh data, but no Burst/Jobs
- System.Threading with configurable thread count (default 4)
- 70+ versions over its lifetime -- mature, actively maintained

**Concerns:**
- Monolithic 24K-line class is extreme -- but it's editor-only and self-contained, so the code quality concern is isolated
- 150+ static fields for state management -- fragile but only affects editor
- No asmdef -- compiles into Assembly-CSharp, but editor-only scripts won't affect builds
- NativeArray without Jobs/Burst -- threading via System.Thread instead
- Deprecated DLL still physically present (4 KB, superseded by source in v1.70)
- Heavy undo operations clone entire meshes -- memory concern on large models
- LINQ usage in editor code (.ToArray() chains) -- acceptable for editor, not runtime

**Overlap Analysis:**
- Complements MegaFiers 2 (136) -- MegaFiers deforms meshes procedurally via modifiers; EditorSculpt deforms manually via brushes. Different workflows, both useful.
- Complements Mesh Optimizer (150) -- sculpt a mesh, then decimate/LOD it
- Complements MudBun (146) -- MudBun is SDF volumetric modeling; EditorSculpt is polygon sculpting. Different paradigms.
- No conflict with any evaluated asset. Editor-only means zero runtime interaction concerns.

**Verdict Rationale:** Approved with **Default 3D** label. Free, MIT-licensed, zero-dependency in-editor mesh sculpting is remarkably valuable. The ability to tweak meshes, paint textures, create blendshapes, and edit animation poses without leaving Unity eliminates constant round-trips to Blender/ZBrush. The monolithic code architecture is a legitimate concern, but it's entirely editor-side -- no runtime cost, no build bloat, no namespace pollution in player builds. 70+ versions and Unity 6 support demonstrate sustained maintenance. Being free and MIT-licensed means zero risk to include.

**HOK Relevance:** MEDIUM-HIGH. Direct utility for:
- Sculpting terrain detail on Acheron environment meshes without Blender round-trips
- Creating blendshapes for character expressions (Kharon, companion)
- Texture painting dock/rock surfaces in-editor
- Tweaking bone poses for fishing animations
- Vertex color painting for shader-driven effects (moss, weathering)

**FearSteez Relevance:** MEDIUM. 2.5D beat 'em up benefits from:
- Quick mesh tweaks on character models and environment props
- Blendshape creation for hit reactions and expressions
- Vertex color painting for damage/effect zones on 3D elements

**3D Concept Projects Relevance:** HIGH across all 3D titles:
- Open-world (Cursed Fantasy, Alpha Foxtrot Uniform) -- in-engine environment sculpting, terrain detail
- VR (Forensic Science Practical Lab) -- rapid iteration on 3D props without DCC round-trips
- Point 'N Click (GRIMMORPG, Space Garbage Man) -- sculpt environment details, paint textures
- Action (Miracle Worker) -- blendshape creation for horror creature deformations

**2D Projects Relevance:** NONE. Editor mesh sculpting has no application in 2D games.

**Visual Novel Projects Relevance:** LOW. Only relevant if VN projects (Encapsulated Fear, Genie in a Test Tube, Murder Malady & Monsters) use 3D character models or environments, which is unlikely for 2D VN format.

---

### ENTRY-153: Deform (Beans / Keenan Woodall)

| Field | Value |
|-------|-------|
| **Asset** | Deform |
| **Publisher** | Beans (Keenan Woodall) |
| **Source** | Asset Store (UPM package) |
| **Category** | Tools (Runtime Mesh Deformation Framework) |
| **Price** | Free ($0) |
| **Rating** | 5 stars (54 ratings) |
| **Version** | 1.2.2 |
| **Last Release** | Oct 7, 2024 |
| **Unity Versions** | 2022.3.45+ |
| **Pipeline** | URP, HDRP, BiRP (all three) |
| **License** | MIT |
| **Dependencies** | com.unity.burst (v1.4.8+), com.unity.mathematics |
| **Install Size** | UPM package (~16K LOC across 164 files) |
| **Package ID** | com.beans.deform |
| **Slug** | https://assetstore.unity.com/packages/slug/148425 |
| **Purchased** | Sep 7, 2025 |
| **Evaluated** | Feb 24, 2026 (Session 37) |
| **Asset Store Label** | Default 3D |
| **Verdict** | **Approved** |

**What It Does:** Runtime mesh deformation framework using a component-based deformer chain. Attach a `Deformable` component to any mesh, stack deformers (bend, twist, noise, ripple, etc.), and they execute as Burst-compiled parallel Jobs at runtime. Think of it as a modular modifier stack for real-time vertex manipulation.

**Key Features:**
- **44 deformers:** 31 standard (Bend, Twist, Taper, Squash/Stretch, Ripple, Wave, Lattice, Magnet, Melt, Skew, etc.), 4 noise (Perlin, Simplex, Cellular), 4 masks (Box, Sphere, VertexColor, VerticalGradient), 5 utility (Group, Repeater, RecalculateBounds/Normals)
- **ElasticDeformable:** Physics-based spring/damping vertex simulation -- jelly, wobble, soft-body effects
- **Burst + Jobs throughout:** 77 Burst-compiled job structs. All deformation runs on worker threads via IJobParallelFor
- **Masking system:** Restrict deformation to vertex subsets via spatial masks or vertex colors
- **DeformableManager:** Singleton scheduler batches and dispatches jobs across all active Deformables
- **MeshFilter + SkinnedMeshRenderer:** Works with both mesh types
- **Non-destructive:** Original meshes preserved; dynamic copies modified at runtime
- **Creator Window:** Editor tool for browsing and quick-adding deformers by category

**Architecture (exemplary):**
- 164 scripts, 16,153 total lines -- all files well under 500 LOC
- **5 asmdef files:** Deform, DeformEditor, Beans.Unity.Collections, Beans.Unity.Editor, Beans.Unity.Mathematics -- zero Assembly-CSharp pollution
- **Clean namespaces:** `Deform`, `Deform.Masking`, `DeformEditor`, `Beans.Unity.*`
- UPM package format (com.beans.deform) -- proper dependency management
- Interface-driven design: `IDeformable`, `IDeformer<T>`, `IFactor`
- NativeArray throughout for data layout -- Jobs-compatible memory
- Bundled utility libraries (Beans.Unity.*) with their own asmdefs

**Concerns:**
- **Last release Oct 2024** -- 16 months without update. Open source mitigates abandonment risk (MIT, fork-friendly)
- No Compute Shader path -- all CPU/Jobs. For extreme vertex counts (100K+), GPU deformation would be faster
- ElasticDeformable marked as WIP -- functional but experimental
- MeshCollider recalculation lags one frame behind mesh updates (documented, expected)
- Requires Read/Write enabled on mesh assets

**Overlap Analysis -- MegaFiers 2 (136) comparison:**

| Aspect | Deform (153) | MegaFiers 2 (136) |
|--------|-------------|-------------------|
| Architecture | Burst/Jobs, 5 asmdefs, namespaced | System.Threading, no asmdef, no namespace |
| Deformers | 44 (component-based chain) | 50+ (Max-style modifier stack) |
| Performance | Burst-compiled parallel jobs | Legacy threading, single-threaded fallback |
| Unique features | ElasticDeformable (soft-body), masking | FFD, Morph, Warp, Path Deform, Hose |
| Spline integration | None (vertex-only) | Deep (MegaShapes dependency, path deform) |
| Price | Free / MIT | $150 commercial |
| Maintenance | Last update Oct 2024 | Active (Feb 2025) |

**These are complementary, not redundant.** Deform excels at runtime VFX-style deformations (wobble, ripple, noise, elastic) with superior performance via Burst. MegaFirs excels at DCC-style modifier stacks (FFD, morph targets, path deformation) with spline integration. Use Deform for runtime effects; MegaFirs for authoring/procedural geometry.

- Complements EditorSculpt (152) -- EditorSculpt is manual brush-based sculpting; Deform is procedural component-based deformation
- Complements Mesh Optimizer (150) -- deform at runtime, optimize at build time
- No conflicts with any evaluated asset

**Verdict Rationale:** Approved with **Default 3D** label. This is how a Unity asset should be built -- Burst/Jobs, proper asmdefs, clean namespaces, UPM format, MIT license, and it's free. The 44-deformer library covers virtually every common mesh deformation need with excellent runtime performance. The slight staleness (16 months since last update) is fully mitigated by MIT licensing and clean architecture -- easy to maintain or fork if needed. Complements MegaFirs 2 rather than replacing it: Deform for runtime effects, MegaFirs for authoring pipelines.

**HOK Relevance:** HIGH. Direct applications:
- Raft deformation (wave response, impact wobble via ElasticDeformable)
- Fish mesh deformation (squash/stretch on catch, wobble on line)
- Water surface vertex displacement (Ripple, Wave, Noise deformers)
- Rope/line physics visualization (Bend, Twist along spline-driven paths)
- Environment props reacting to player (Magnet deformer for interactive foliage)

**FearSteez Relevance:** MEDIUM. 2.5D beat 'em up uses:
- Hit impact deformation (SquashAndStretch on characters)
- ElasticDeformable for jelly/wobble on impact effects
- Environment destruction deformation (Melt, Inflate on props)

**3D Concept Projects Relevance:** HIGH across all 3D titles:
- Open-world (Cursed Fantasy, Alpha Foxtrot Uniform) -- terrain deformation, environmental effects, weapon impact
- VR (Forensic Science Practical Lab) -- interactive object deformation for tactile feedback
- Point 'N Click (GRIMMORPG, Space Garbage Man) -- animated environment effects, horror deformation
- Action (Miracle Worker) -- creature deformation, horror body-horror effects

**2D/2.5D Projects Relevance:** LOW. A Quokka Story (2.5D Metroidvania) and HumiliNation (2.5D physics sim) could use squash/stretch on 3D elements, but most deformers target full 3D meshes.

**2D Projects Relevance:** NONE. Pure 2D games (DLYH, Shrunken Head Toss, Dots and Boxes) have no mesh deformation needs.

---

### ENTRY-154: Realistic Mesh Deformation (BoneCracker Games)

| Field | Value |
|-------|-------|
| **Asset** | Realistic Mesh Deformation |
| **Publisher** | BoneCracker Games |
| **Source** | Asset Store |
| **Category** | Tools (Collision-Based Mesh Deformation) |
| **Price** | Free ($0) |
| **Rating** | 5 stars (3 ratings) |
| **Version** | 1.2 |
| **Last Release** | Jun 3, 2025 |
| **Unity Versions** | 2021.3.2+ |
| **Pipeline** | URP, HDRP, BiRP (all three) |
| **Dependencies** | None |
| **Install Size** | ~2.5 MB (includes demo scene, textures, FBX) |
| **Slug** | https://assetstore.unity.com/packages/slug/229669 |
| **Purchased** | Jul 10, 2025 |
| **Evaluated** | Feb 24, 2026 (Session 37) |
| **Asset Store Label** | Don't Use |
| **Verdict** | **Rejected** |

**What It Does:** Collision-impact mesh deformation with smooth repair. Attach `RMD_Deformation` to a GameObject, and when something collides with it, vertices near the impact point get pushed inward proportional to collision impulse. Call Repair() to smoothly lerp vertices back to their original positions. Essentially a "dent and un-dent" system.

**Key Features:**
- **Collision deformation:** Vertices within configurable radius displaced by collision impulse
- **Smooth/Fast modes:** Lerp deformation over time or apply instantly
- **Repair system:** Smooth vertex restoration to original positions
- **Resolution control:** Skip every Nth vertex for performance (deformResolution 1-100)
- **Mobile demo:** Includes joystick, drag camera, projectile shooter

**Architecture:**
- 11 scripts total (8 runtime, 3 editor), 1,084 total lines
- **No namespace** -- all classes in global scope with RMD_ prefix
- **No asmdef** -- everything in Assembly-CSharp
- **No Burst/Jobs/Compute** -- all vertex math runs single-threaded in Update()
- Auto-injects `BCG_RMD` scripting define symbol on first import
- Shows publisher dialog on first import (blocking)
- Runtime `FindObjectOfType` calls without caching

**Concerns:**
- **Completely superseded by Deform (153):** Deform has 44 deformers including ElasticDeformable (spring/damping soft-body), all Burst-compiled with parallel Jobs. RMD has exactly one deformation mode (collision push) running single-threaded.
- **Shared mesh bug:** Directly modifies the mesh on the MeshFilter. If multiple GameObjects share the same mesh asset, they'll interfere with each other. No mesh instancing.
- **FindObjectOfType in UI callbacks:** `RMD_Canvas` calls `FindObjectOfType<RMD_Shooter>()` three times without caching. `RepairAll()` calls `FindObjectsOfType<RMD_Deformation>()`.
- **Per-frame vertex iteration:** Update loops through all vertices every frame during deform/repair with no early-out optimization.
- **3 ratings total** -- minimal community validation.
- **No namespace, no asmdef** -- pollutes global scope and Assembly-CSharp.

**Overlap Analysis:**
- **Deform (153) completely supersedes this.** Deform's ElasticDeformable provides collision-reactive mesh deformation with spring/damping physics, Burst-compiled, with masking support. It does everything RMD does but faster, with more control, and better architecture.
- **MegaFirs 2 (136) also supersedes** via its mesh deformation modifier stack.
- No unique capability that isn't covered better by existing evaluated assets.

**Verdict Rationale:** Rejected with **Don't Use** label. This is a toy-scale implementation that Deform (153) renders completely obsolete. The comparison is stark: 11 scripts / 1K LOC / no Jobs / no namespace / one deformation mode vs Deform's 164 scripts / 16K LOC / Burst+Jobs / 5 asmdefs / 44 deformers. Even the one thing RMD specializes in -- collision-based deformation -- Deform's ElasticDeformable handles with superior performance and physics simulation. The shared mesh bug, FindObjectOfType abuse, and global namespace pollution are additional strikes. Being free doesn't offset being unnecessary when a free, MIT-licensed, architecturally superior alternative already exists.

**Portfolio Relevance:** N/A -- Rejected. No TecVooDoo project should use this when Deform (153) is available.

---

### ENTRY-155: Curved World (Amazing Assets)

| Field | Value |
|-------|-------|
| **Asset** | Curved World |
| **Publisher** | Amazing Assets |
| **Source** | Asset Store |
| **Category** | Shaders (Vertex Displacement / World Bending) |
| **Price** | $45 |
| **Rating** | 5 stars (194 ratings) |
| **Version** | 2025.5 |
| **Last Release** | Dec 18, 2025 |
| **Unity Versions** | 2019.4+, 2020.3+, 2021.3+, 2022.3+, 6000.0.23+, 6000.3.0+ |
| **Pipeline** | URP, HDRP, BiRP (all three, separate installer packages) |
| **Dependencies** | None (optional TMP integration) |
| **Install Size** | ~40 MB per pipeline package (1,656 files for URP) |
| **Slug** | https://assetstore.unity.com/packages/slug/173251 |
| **Purchased** | Nov 22, 2025 |
| **Evaluated** | Feb 24, 2026 (Session 37) |
| **Asset Store Label** | Default 3D |
| **Verdict** | **Approved** |

**What It Does:** Vertex shader displacement system that bends the visible world without modifying actual geometry, physics, or colliders. Attach a `CurvedWorldController` to your scene, assign curved-world-enabled materials, and the entire visible environment warps -- curved horizons, little planet effects, spiral twists, cylindrical wraps. All purely visual; physics, AI, and collision remain on the flat, unmodified geometry.

**Key Features:**
- **11 bend types:** Classic Runner, Cylindrical Rolloff, Cylindrical Tower, Little Planet (X/Y/Z), Spiral Horizontal/Vertical (single/double/rolloff), Twisted Spiral
- **32 parameter IDs per bend type** -- stack multiple bend effects simultaneously
- **Full pipeline coverage:** Separate installer packages for URP, HDRP, and BiRP with pipeline-specific shader implementations
- **Shader integration for everything:** Lit, Unlit, 2D Sprites, Particles, Terrain, SpeedTree 8
- **Physics-independent:** Zero impact on colliders, raycasts, pathfinding, animation -- purely visual vertex displacement in the vertex shader
- **Material duplication tool:** Editor window to batch-convert existing materials to curved-world variants
- **Rich example content:** Endless runner demo, 2D platformer, Unity Tanks, SimpleTownLite

**Architecture:**
- 43 C# scripts (6 runtime core + 37 editor)
- 600+ shader include files (CGINC/HLSL) -- the bulk of the asset
- **4 asmdef files:** `AmazingAssets.CurvedWorld`, `AmazingAssets.CurvedWorld.Editor`, `AmazingAssets.CurvedWorld.Editor.Universal.ShaderGUI`, `AmazingAssets.CurvedWorld.Examples`
- **Namespace:** `AmazingAssets.CurvedWorld` -- clean, no global pollution
- **Hand-written shaders** -- no Shader Graph dependency, just CGINC/HLSL includes
- No Burst/Jobs needed -- all work happens in the GPU vertex shader
- Installer pattern: imports as unitypackage chooser, you pick your pipeline

**Runtime Components:**
- `CurvedWorldController` -- main component, sets global shader properties for bend type/strength
- `CurvedWorldCamera` -- camera integration for proper frustum handling
- `CurvedWorldBoundingBox` -- adjusts bounding boxes so curved objects don't get culled incorrectly
- `CurvedWorldRenderPipeline` -- pipeline detection utility
- `CurvedWorldBendType` -- bend type enum definitions
- `CurvedWorldUtilities` -- helper methods

**Concerns:**
- **40 MB per pipeline** -- large install, mostly shader includes. Delete unused pipeline packages and example content after import.
- **Material workflow overhead** -- every material that should bend needs a curved-world shader variant. The duplication tool helps, but it's still a per-material setup step.
- **600+ include files** -- increases project compilation time. The parametric ID system (32 variants x 11 types) generates many files.
- **Installer pattern** -- asset imports as a chooser, not directly usable. Must run the internal URP/BiRP/HDRP unitypackage installer after import.
- **Third-party shader compatibility** -- custom shaders from other assets need manual curved-world integration (add include + vertex displacement call). Won't automatically bend shaders it doesn't know about.

**Overlap Analysis:**
- **Fundamentally different from Deform (153) and MegaFirs (136).** Those modify actual mesh vertex data on CPU. Curved World modifies vertex positions only in the GPU vertex shader -- the mesh data is never touched. They solve different problems:
  - Deform/MegaFirs: actual mesh deformation (physics-interactive, persistent)
  - Curved World: visual-only world warping (physics-independent, cosmetic)
- **No overlap with any evaluated asset.** This is the only vertex-shader world-bending system in the inventory.
- **Compatible with Advanced Dissolve** (same publisher, Amazing Assets) -- designed to work together.

**Verdict Rationale:** Approved with **Default 3D** label. 194 ratings at 5 stars makes this one of the highest-rated assets evaluated. The endless-runner curved horizon effect alone justifies the $45 price for any 3D game wanting that visual style. The 11 bend types cover a wide range of visual effects from subtle horizon curvature to dramatic little-planet warping. Clean architecture (4 asmdefs, proper namespace, hand-written shaders) and active maintenance (Dec 2025 update, Unity 6 support). The material workflow overhead is the main friction point, but the batch duplication tool mitigates it. The physics-independence is actually a feature -- you get dramatic visual effects with zero gameplay-side complexity.

**HOK Relevance:** MEDIUM. Subtle curved horizon on the Acheron river would add visual depth. Classic Runner or Cylindrical Rolloff bend type could create a sense of the river stretching into the distance. Little Planet mode could be a fun camera effect for UI/menu screens. Low integration cost since HOK's materials would need curved-world variants, but the raft/dock/river are limited enough to be manageable.

**FearSteez Relevance:** HIGH. 2.5D beat 'em up is a natural fit for Classic Runner curvature -- streets curving away into the distance creates cinematic depth for a side-scrolling game. This is literally the genre Curved World was designed for.

**3D Concept Projects Relevance:** MEDIUM-HIGH selectively:
- Open-world (Cursed Fantasy, Alpha Foxtrot Uniform) -- Little Planet effect for world maps, subtle horizon curvature for immersion
- Point 'N Click (GRIMMORPG, Space Garbage Man) -- Twisted Spiral for horror/surreal environments, Cylindrical Tower for space station interiors
- VR (Forensic Science Practical Lab) -- LOW, VR + vertex displacement can cause motion sickness if misapplied
- Action (Miracle Worker) -- Spiral effects for supernatural/horror atmosphere

**2D Projects Relevance:** LOW-MEDIUM. Has 2D sprite shader support, so A Quokka Story (2.5D Metroidvania) could use subtle curvature for depth. Pure 2D games (DLYH, Shrunken Head Toss) unlikely to benefit.

---

### ENTRY-156: Advanced Dissolve (Amazing Assets)

| Field | Value |
|-------|-------|
| **Asset** | Advanced Dissolve |
| **Publisher** | Amazing Assets |
| **Source** | Asset Store |
| **Category** | Shaders (Dissolve / Cutout / Geometric Slicing) |
| **Price** | $35 |
| **Rating** | 5 stars (85 ratings) |
| **Version** | 2025.4 |
| **Last Release** | Dec 8, 2025 |
| **Unity Versions** | 2019.4+, 2020.3+, 2021.3+, 2022.3+, 6000.0.23+, 6000.3.0+ |
| **Pipeline** | URP, HDRP, BiRP (all three, separate installer packages) |
| **Dependencies** | None (optional TMP for examples) |
| **Install Size** | 138 MB total (URP 37 MB, BiRP 63 MB, HDRP 38 MB) |
| **Slug** | https://assetstore.unity.com/packages/slug/111598 |
| **Purchased** | Dec 7, 2025 |
| **Evaluated** | Feb 24, 2026 (Session 37) |
| **Asset Store Label** | Default |
| **Verdict** | **Approved** |

**What It Does:** Multi-mode dissolve/cutout shader system with both texture-based and geometric-shape dissolution. Attach a controller to any object, and it dissolves away using noise textures, geometric planes, spheres, cubes, capsules, or cones -- with configurable edge glow, color gradients, and UV distortion. Supports global control IDs so you can synchronize dissolves across entire scenes.

**Key Features:**
- **Texture-based cutout:** 1-3 blended cutout maps with per-map tiling, offset, scroll, intensity, channel selection, and invert. Mapping modes: Default, Triplanar, Screen Space.
- **Geometric cutout:** Plane, Sphere, Cube, Capsule, Cone slicing with up to 4 simultaneous targets. Transform-driven or Vector3 position-driven.
- **Edge effects:** Color from cutout standard, custom map, gradient map, gradient color, or user-defined. UV distortion on dissolution edges.
- **Global control system:** 4 global IDs for synchronizing dissolves across all materials/objects -- city-wide destruction, portal effects, etc.
- **Runtime controllers:** C# API via `AdvancedDissolvePropertiesController`, `AdvancedDissolveGeometricCutoutController`, `AdvancedDissolveKeywordsController`. Update modes: FixedUpdate, EveryFrame, Manual.
- **Full pipeline coverage:** Lit, SimpleLit, Unlit, BakedLit, ComplexLit, Particles (3 variants), 2D renderer -- all with dissolve support.
- **Shader Graph integration:** Subgraph for dissolve logic, reusable in custom Shader Graph shaders.
- **13 tutorial scenes** with progressive complexity.

**Architecture:**
- 60 scripts total (18 runtime / 42 editor), ~4,016 runtime LOC
- **5 asmdef files:** Runtime (pure, no deps), Editor, Editor.ShaderGraph, Editor.Universal.ShaderGUI, Examples -- clean isolation
- **Namespace:** `AmazingAssets.AdvancedDissolve` -- no global pollution
- 52 shader files + 37 HLSL includes -- hand-written shaders (not Shader Graph generated) with parallel Shader Graph implementations
- Installer pattern (same as Curved World) -- pick your pipeline unitypackage
- Keyword-driven feature branching (`_AD_` prefix) -- unused features compile out

**Concerns:**
- **Monolithic properties class:** `AdvancedDissolveProperties.cs` is 1,844 lines -- a single data class housing all shader property IDs and setters. Functional but hard to navigate.
- **Installer pattern:** Must manually import the correct pipeline unitypackage after initial import. No UPM/Package Manager support.
- **138 MB total footprint** across 3 pipeline packages -- only import the one you need.
- **Keyword-based variants** can increase shader compilation time and build size if many combinations are active.
- **No Burst/Jobs** -- geometric cutout updates run on main thread. Fine for typical use (4 targets max), but not for scaling to dozens of simultaneous dissolves.
- **Same publisher quirks as Curved World (155):** Amazing Assets uses consistent patterns -- installer delivery, editor ReadMe, property drawer heavy inspectors. Familiar if you've used one.

**Overlap Analysis:**
- **Designed to work with Curved World (155)** -- same publisher, keywords reference "curved world" in CSV tags. Materials can have both curved world bending AND dissolve effects simultaneously.
- **No overlap with any other evaluated asset.** This is the only dissolve/cutout shader system in the inventory.
- **Complements Deform (153)** -- Deform deforms mesh geometry, Advanced Dissolve visually removes it. Different effects, combinable (deform + dissolve for destruction sequences).

**Verdict Rationale:** Approved with **Default** label (not just Default 3D -- dissolve effects are useful in 2D/2.5D projects too via 2D renderer support). 85 ratings at 5 stars from a proven publisher. The geometric cutout system is the standout feature -- real-time plane/sphere/cube slicing with edge glow goes far beyond simple noise dissolves. The global control system enables cinematic synchronized effects. Shader Graph subgraph means custom shaders can integrate dissolve without reimplementing. $35 is reasonable for the depth of functionality. The installer workflow and monolithic properties class are friction points but not blockers.

**HOK Relevance:** MEDIUM-HIGH. Direct applications:
- Fish catch sequence -- dissolve fish into particles/light as it's reeled in (catch celebration effect)
- UI transitions -- dissolve screen overlays for scene changes
- Environmental storytelling -- ghostly objects fading in/out along the Acheron
- Geometric plane slicing for underwater/surface boundary effects

**FearSteez Relevance:** HIGH. Beat 'em up combat effects:
- Enemy death dissolves (texture-based with edge glow)
- Geometric slicing for sword/weapon cut effects
- Stage transition dissolves
- Power-up appearance/disappearance effects

**3D Concept Projects Relevance:** HIGH across the board:
- Action/Adventure (Alpha Foxtrot Uniform, Cursed Fantasy, Miracle Worker) -- death effects, destruction, supernatural dissolution
- Point 'N Click (GRIMMORPG, Space Garbage Man) -- horror dissolve effects, object reveal/hide mechanics
- VR (Forensic Science Practical Lab) -- evidence reveal via controlled dissolve (peel back layers)
- Visual Novels (Encapsulated Fear, Murder Malady & Monsters) -- scene transition dissolves, horror atmosphere

**2D/2.5D Projects Relevance:** MEDIUM. 2D renderer support means:
- A Quokka Story (2.5D Metroidvania) -- enemy death dissolves, world transitions
- HumiliNation (2.5D physics sim) -- comedic dissolution effects
- DLYH, Shrunken Head Toss -- screen transition dissolves (limited but available)

---

### ENTRY-157: Lattice Modifier (Harry Heath)

| Field | Value |
|-------|-------|
| **Asset** | Lattice Modifier for Unity |
| **Publisher** | Harry Heath |
| **Source** | Asset Store (UPM package) |
| **Category** | Tools (GPU Lattice / FFD Mesh Deformation) |
| **Price** | $25 |
| **Rating** | 5 stars (22 ratings) |
| **Version** | 1.3.2 |
| **Last Release** | Nov 24, 2025 |
| **Unity Versions** | 2021.3.5+ |
| **Pipeline** | URP, HDRP, BiRP (all three) |
| **Dependencies** | None (compute shader support required) |
| **Install Size** | UPM package (~5.2K LOC across 40 files + compute shader) |
| **Package ID** | com.heath.lattice |
| **Slug** | https://assetstore.unity.com/packages/slug/293850 |
| **Purchased** | Nov 28, 2025 |
| **Evaluated** | Feb 24, 2026 (Session 37) |
| **Asset Store Label** | Default 3D |
| **Verdict** | **Approved** |

**What It Does:** GPU-accelerated Free-Form Deformation (FFD) via 3D lattice grids. Place a lattice around any mesh, drag control handles in the scene view, and the mesh warps smoothly to follow. All vertex deformation runs on the GPU via compute shader -- positions, normals, and tangents deformed in a single dispatch. Works with MeshFilter, SkinnedMeshRenderer, and Transform targets.

**Key Features:**
- **GPU compute deformation:** Single compute shader dispatches vertex position + normal + tangent updates. No CPU vertex math.
- **Three modifier types:** `LatticeModifier` (MeshFilter/MeshRenderer), `SkinnedLatticeModifier` (pre/post-skinning), `TransformLatticeModifier` (deform Transform properties)
- **Interpolation:** Linear (sharp/smooth) and Cubic (tricubic basis functions)
- **Masking system:** Per-lattice vertex selection by material index, vertex color channel, UV channel, or texture
- **Stretch/Squish encoding:** Deformation magnitude encoded in UV channel for shader-driven effects (color shift on stretch)
- **Update modes:** Manual, WhenVisible (default), Always
- **Scene editing:** Full gizmo-based handle manipulation with multi-selection, color coding, connection lines
- **11 sample scenes:** Pipes, skinned, cloth drapes, interactive face grab, animated elephant, masking demos

**Architecture (exemplary):**
- 40 C# files, 5,229 total lines -- all files under 540 LOC
- **2 asmdef files:** `Lattice.Runtime` (zero deps, all platforms), `Lattice.Editor` (editor only, depends on runtime) + 4 sample asmdefs
- **Namespace:** `Lattice`, `Lattice.Editor` -- clean, no pollution
- **UPM package format** (com.heath.lattice) -- proper dependency management
- **Compute shader** (324 lines) with keyword-driven multi_compile variants
- GraphicsBuffer API for zero-copy GPU vertex data
- Player loop integration (PostLateUpdate injection before skinning)
- No Burst/Jobs needed -- all heavy lifting on GPU
- No LINQ, no per-frame allocations, proper buffer release patterns
- XML doc comments throughout

**Concerns:**
- **Compute shader required** -- won't work on platforms without compute support (rare for modern targets, but worth noting)
- **1024 handle limit** hardcoded in LatticeFeature -- adequate for typical use, but can't do ultra-high-resolution grids
- **GPU memory bandwidth** -- copy-back pattern resets from cached original each frame. Large vertex counts = expensive
- **No LOD integration** -- always deforms full resolution mesh
- **Known Unity editor crash workaround** -- uses 3 compute shader instances to avoid keyword explosion bug (documented, handled gracefully)

**Overlap Analysis -- Deformation Asset Comparison:**

| Aspect | Lattice Modifier (157) | Deform (153) | MegaFiers 2 (136) |
|--------|----------------------|-------------|-------------------|
| Execution | **GPU compute shader** | CPU Burst/Jobs | CPU System.Threading |
| Focus | FFD lattice only | 44 deformer types | 50+ Max-style modifiers |
| FFD quality | Cubic interpolation, GPU | LatticeDeformer (CPU, basic) | FFD 2x2, 3x3, 4x4 (CPU) |
| Skinned mesh | Pre/post-skinning GPU | MeshFilter + SMR | MeshFilter + SMR |
| Masking | Per-lattice (color/UV/tex) | Box/Sphere/Color/Gradient | None |
| Package format | UPM | UPM | Asset folder |
| Price | $25 | Free | $150 |

**These three are complementary.** Lattice Modifier is the FFD specialist with GPU acceleration -- faster and higher quality than either Deform's or MegaFirs's CPU lattice implementations. Use Lattice Modifier for FFD, Deform for runtime VFX deformations (ripple, noise, elastic), MegaFirs for authoring modifier stacks (morph, path deform, hose).

- Complements EditorSculpt (152) -- sculpt meshes manually, then apply lattice deformation on top
- Complements Mesh Optimizer (150) -- lattice-deform at runtime, optimize LODs at build time
- No conflicts with any evaluated asset

**Verdict Rationale:** Approved with **Default 3D** label. This is a focused, expertly built tool. GPU compute for lattice deformation is the right architectural choice -- vertex displacement is massively parallel and belongs on the GPU. The UPM format, clean namespaces, 2 asmdefs, zero dependencies, and 11 polished samples demonstrate production quality. $25 is excellent value for GPU-accelerated FFD with skinned mesh support. The 1024 handle limit and compute requirement are reasonable constraints. Fills a specific niche that Deform (153) and MegaFirs (136) serve less efficiently at the CPU level.

**HOK Relevance:** HIGH. Direct applications:
- Fishing rod bend deformation via lattice handles driven by line tension
- Raft hull flex responding to wave forces
- Fish body deformation during struggle/reel-in (SkinnedLatticeModifier on fish model)
- Dock/pier wood flexing under weight
- Character squash/stretch for cartoon-style animations

**FearSteez Relevance:** MEDIUM-HIGH. 2.5D beat 'em up uses:
- Character hit deformation (squash on impact, stretch on launch)
- Environmental props bending/breaking on interaction
- Cartoony exaggeration for combo finishers

**3D Concept Projects Relevance:** HIGH across all 3D titles:
- Action/Adventure (Alpha Foxtrot Uniform, Cursed Fantasy, Miracle Worker) -- weapon impact deformation, character body warping, environmental flex
- VR (Forensic Science Practical Lab) -- interactive object deformation for haptic-style feedback, moldable evidence
- Point 'N Click (GRIMMORPG, Space Garbage Man) -- horror body deformation, environmental warping puzzles
- A Quokka Story (2.5D Metroidvania) -- character squash/stretch for platforming feel

**2D Projects Relevance:** NONE. GPU lattice deformation is inherently 3D mesh-based.

---

### ENTRY-158: Amplify Shader Editor (Amplify Creations)

| Field | Value |
|-------|-------|
| **Asset** | Amplify Shader Editor |
| **Publisher** | Amplify Creations |
| **Source** | Asset Store (via Amplify Bundle) |
| **Category** | Editor Tool (Node-Based Shader Authoring) |
| **Price** | $110 (Amplify Bundle: ASE + Impostors + LUT Pack) |
| **Rating** | 5 stars (bundle: 3 ratings; ASE standalone has 1,000+ on store page) |
| **Version** | 1.9.9.8 |
| **Unity Versions** | 2019.4+ through Unity 6 (6000.3+) |
| **Pipeline** | URP, HDRP, BiRP (all three, first-class) |
| **Dependencies** | None |
| **Install Size** | ~305 MB (includes 270 MB of example unitypackages) |
| **Bundle Slug** | https://assetstore.unity.com/packages/slug/173849 |
| **Purchased** | Feb 24, 2026 |
| **Evaluated** | Feb 24, 2026 (Session 37) |
| **Asset Store Label** | Default |
| **Verdict** | **Approved** |

**What It Does:** Node-based visual shader editor that generates native HLSL/Cg shader code. NOT a wrapper over Unity's Shader Graph -- it's an independent, mature code generation system. Build shaders by connecting nodes on a canvas, and ASE outputs real `.shader` files with optimized HLSL. Supports BiRP surface shaders, URP templates (2D, Lit, Unlit, Particles), and HDRP templates (Lit, Unlit, Hair, Fabric, Eyes, Decal).

**Key Features:**
- **256 node types:** Operators (52+), Textures (10+), Constants/Properties (52+), Vertex (24), Helper Functions (30+), Noise, Logic, Image Effects, SRP-specific nodes
- **101 pre-built shader functions:** Reusable node templates for common operations (Triplanar, Dissolve, Voronoi, Parallax Occlusion Mapping, SSS, Fresnel, Noise generators)
- **78 shader templates:** BiRP (Standard, Unlit, Custom), URP (Lit/Unlit/2D/Sprite/Decal, versions 10x-17.3), HDRP (Lit/Unlit/Hair/Fabric/Eyes/Decal, versions 10x-17.3)
- **Native code generation:** Outputs HLSL/Cg directly -- not Shader Graph, not visual scripting. Real shader files.
- **Live preview:** Each node renders a preview quad; canvas updates reflect in scene view
- **Texture Array Creator:** Built-in editor tool for building 2D texture arrays
- **Full source code:** 488 C# scripts, all inspectable and modifiable

**Architecture:**
- 488 scripts, ~305 MB total (270 MB is example unitypackages -- deletable)
- **1 asmdef:** `AmplifyShaderEditor` -- **Editor-only** (includePlatforms: Editor). Zero runtime code, zero build impact.
- **Namespace:** `AmplifyShaderEditor` -- clean, no global pollution
- Core files: `AmplifyShaderEditorWindow.cs` (6,167 lines -- main canvas), `ParentGraph.cs` (4,117 lines -- graph serialization), `ParentNode.cs` (3,939 lines -- base node class)
- Dual-path code generation: `MasterNodeDataCollector` (BiRP) and `TemplateDataCollector` (URP/HDRP)
- No Burst/Jobs/Compute -- pure editor GUI tool
- No unsafe code, no precompiled DLLs
- Generates standard `.shader` files that work with Unity's material system

**Concerns:**
- **305 MB footprint** -- large, but 270 MB is example packages (safe to delete). Core is ~35 MB.
- **Large individual files** -- main window is 6,167 lines, graph is 4,117 lines. Monolithic but editor-only.
- **Online-only documentation** -- manual and node reference at amplify.pt, not included locally
- **NOT compatible with Shader Graph** -- separate ecosystem. Can't import/export Shader Graph assets. Both can coexist in the same project.
- **Learning curve** -- 256 node types is powerful but overwhelming initially. Search and context menu help.
- **Serialization fragility** -- graph data relies on Unity serialization. Corrupt graph requires manual repair.

**ASE vs Unity Shader Graph:**

| Aspect | Amplify Shader Editor | Unity Shader Graph |
|--------|----------------------|-------------------|
| Output | Native .shader files (HLSL/Cg) | Shader Graph assets (.shadergraph) |
| BiRP support | Full (surface shaders) | None (SRP only) |
| Node count | 256 types + 101 functions | ~150 types |
| Code access | Full generated HLSL visible/editable | Abstracted, limited code access |
| Custom nodes | Create via C# or Shader Functions | Create via Sub Graphs or C# |
| Maturity | 8+ years, industry standard | 5+ years, improving rapidly |
| Price | $110 (bundle) / ~$80 standalone | Free (included with Unity) |
| Maintenance | Active (v1.9.9.8, URP 17.3 support) | Unity-maintained |

**Both have a place.** ASE generates cleaner, more portable shader code and has BiRP support. Shader Graph is free, tightly integrated with Unity's visual tools, and improving fast. For TecVooDoo: ASE for complex custom shaders where code control matters; Shader Graph for quick material prototyping.

**Overlap Analysis:**
- **Coexists with Shader Graph** -- both can live in the same project. Use ASE for complex/custom shaders, Shader Graph for simple ones.
- **Complements Curved World (155)** -- ASE can generate shaders with Curved World integration (custom nodes for vertex displacement)
- **Complements Advanced Dissolve (156)** -- ASE-authored shaders can incorporate dissolve via shader functions
- **No conflict with any evaluated asset.** Editor-only, outputs standard shader files.

**Verdict Rationale:** Approved with **Default** label (all projects benefit from custom shader authoring). ASE is the industry standard for a reason -- 256 nodes, 101 functions, 78 templates, full source, all three pipelines, and it generates real HLSL you can inspect and modify. The $110 bundle price (ASE + Impostors + LUT Pack) is excellent value for what is essentially a complete shader development environment. Editor-only means zero runtime cost. The "gold standard" reputation is earned. The only question is whether it's worth the investment over free Shader Graph -- and for any project needing custom shaders beyond basic PBR, the answer is yes.

**HOK Relevance:** HIGH. Custom URP shaders for:
- Water surface (caustics, refraction, depth-based transparency, foam)
- Fish scales (subsurface scattering approximation, iridescence)
- Raft wood (weathering, wet/dry zones, vertex-painted moss)
- Acheron river environment (fog, atmospheric effects, distance fade)
- UI effects (dissolve transitions, glow)

**FearSteez Relevance:** HIGH. 2.5D beat 'em up custom shaders:
- Character hit flash/outline effects
- Environment destruction shaders
- Stylized lighting for beat 'em up aesthetic
- 2D sprite shader customization via URP 2D templates

**3D Concept Projects Relevance:** HIGH across the board:
- Every 3D project benefits from custom shader authoring capability
- VR (Forensic Science Practical Lab) -- performance-optimized custom shaders critical for VR frame budgets
- Horror (GRIMMORPG, Miracle Worker, Encapsulated Fear) -- atmosphere heavily shader-driven
- Open-world (Cursed Fantasy, Alpha Foxtrot Uniform) -- terrain, foliage, water all need custom shaders

**2D Projects Relevance:** MEDIUM. URP 2D/Sprite templates available. DLYH and Shrunken Head Toss could use custom sprite effects. Shader Graph is likely sufficient for simple 2D needs, but ASE gives more control.

**Visual Novel Projects Relevance:** LOW-MEDIUM. VN character rendering could use custom shaders for expression/mood lighting effects, but likely overkill for the genre.

---

### ENTRY-159: Amplify Shader Pack (Amplify Creations)

| Field | Value |
|-------|-------|
| **Asset** | Amplify Shader Pack |
| **Publisher** | Amplify Creations |
| **Source** | Asset Store (included with Amplify Bundle) |
| **Category** | Shaders (Multi-Pipeline Shader Library) |
| **Price** | Included with Amplify Bundle ($110) |
| **Rating** | N/A (bundled, no standalone listing) |
| **Version** | 2.3.9 (Jan 2026) |
| **Unity Versions** | 2019.4.40+ through Unity 6 (6000.3+) |
| **Pipeline** | URP, HDRP, BiRP (all three, separate sample packages) |
| **Dependencies** | None required (ASE needed only to edit shaders) |
| **Install Size** | ~690 MB (575 MB assets + 115 MB sample unitypackages) |
| **Evaluated** | Feb 24, 2026 (Session 37) |
| **Asset Store Label** | Default |
| **Verdict** | **Approved** |

**What It Does:** Comprehensive shader example library showcasing what Amplify Shader Editor can produce. 130+ production-ready shaders across all three pipelines, plus 20 reusable shader functions, 461 prefabs, and 262 textures. Functions as both a learning resource and a ready-to-use shader collection.

**Key Features:**
- **130+ shaders across categories:** PBR/Lighting (Standard, Specular, Cutout, Fabric, Hair, Transmission, Translucent), Effects (Fire, Burn/Dissolve, Water, Snow, Dithering, Glint, Heat Haze, Pixelization, Blur, Refraction), Toon (Outline, Custom Lighting, XRay, Matcap), Terrain (Single-Pass, 4/8-layer, Water Flow), Decals (SciFi, Parallax), Advanced (Tessellation, Parallax Mapping, Interior Mapping, Triplanar, Vector Displacement), UI/Sprite effects, Particles
- **20 reusable shader functions:** PBR Core, Masking, Burn Effect, Terrain layers, UI masking, UV projections -- pluggable into custom ASE graphs
- **461 prefabs** organized by pipeline (149 BiRP, 151 URP, 161 HDRP) -- ready to drop into scenes
- **262 textures:** PBR maps, decals, hair, terrain (AmbientCG-sourced), VDM maps
- **16 sample unitypackages** covering URP v10-v17.3 and HDRP v10-v17.3

**Architecture:**
- 23 C# scripts (7 editor, 13 samples, 3 core), 2,096 total lines
- **No asmdef** -- scripts in Assembly-CSharp (minor negative, but mostly editor/sample code)
- **Namespace:** `AmplifyShaderPack` for editor tools; sample scripts use mixed namespaces
- **Does NOT require ASE to use** -- shaders are pre-compiled .shader files. ASE only needed to edit/customize them.
- Editor auto-detects installed SRP version and suggests compatible sample package

**Concerns:**
- **690 MB is large** -- but 270 MB is example unitypackages (deletable). Import only the pipeline you need.
- **No asmdef** -- editor/sample scripts pollute Assembly-CSharp. Minor since they're utility scripts.
- **SRP version sensitivity** -- wrong version = pink/magenta materials. Must import correct version-matched sample package.
- **Shader editing requires ASE** -- can use shaders out-of-box, but customizing them needs ENTRY-158.

**Overlap Analysis:**
- **Companion to ASE (158)** -- this is the "what ASE can do" showcase. ASE is the tool, Shader Pack is the output library.
- **Overlaps with Advanced Dissolve (156)** in dissolve/burn effects -- but Advanced Dissolve's geometric cutout system goes deeper. Both can coexist.
- **Water shaders overlap with Staggart water pipeline (039-041)** -- Staggart's water is more specialized. ASP's water is a simpler reference implementation.

**Verdict Rationale:** Approved with **Default** label. Even without ASE, the 130+ pre-built shaders are immediately usable across all pipelines. The reusable shader functions are the real gem -- pluggable modules for common effects. The texture/prefab library provides production-ready materials. As a learning resource for ASE it's invaluable. The 690 MB size is the main friction, but selective import keeps it manageable.

**HOK Relevance:** MEDIUM-HIGH. Reference implementations for:
- Water shaders (flow, parallax) -- study/adapt for Acheron river
- Terrain shaders (4/8-layer, snow) -- Acheron environment
- Translucent/Transmission -- fish scales, water surface
- Dissolve/Burn -- catch celebration effects

**FearSteez Relevance:** HIGH. Directly usable:
- Toon/Outline shaders for beat 'em up aesthetic
- Heat Haze/Refraction for power-up VFX
- Sprite effects for 2.5D layers
- Matcap for stylized character rendering

**3D Concept Projects Relevance:** HIGH. Universal shader reference library for any 3D project. Interior Mapping alone is valuable for GRIMMORPG, Space Garbage Man (building interiors without geometry).

**2D Projects Relevance:** LOW-MEDIUM. UI/Sprite shader examples available but limited utility for pure 2D games.

---

### ENTRY-160: Street Props - Barricades and Channelizing (Amplify Creations)

| Field | Value |
|-------|-------|
| **Asset** | Street Props (Barricades and Channelizing) |
| **Publisher** | Amplify Creations |
| **Source** | Asset Store (Free) |
| **Category** | 3D Models (Street Furniture / Traffic Props) |
| **Price** | Free ($0) |
| **Rating** | N/A (not found in inventory CSV) |
| **Version** | Unknown (no version file) |
| **Unity Versions** | 2019.4+ |
| **Pipeline** | URP, HDRP, BiRP (separate unitypackages per pipeline) |
| **Dependencies** | None (does NOT require Amplify Shader Editor) |
| **Install Size** | ~44 MB unpacked (URP version) |
| **Install Path** | Assets/Prototype Collection/ |
| **Evaluated** | Feb 24, 2026 (Session 37) |
| **Asset Store Label** | Default 3D |
| **Verdict** | **Approved** |

**What It Does:** Free collection of high-quality street barricade and traffic safety props. 8 prop categories with clean/old/used weathering variants and full LOD chains (LOD0-LOD4). Standard URP/Lit materials -- no custom shaders, no Amplify dependency despite the publisher name.

**Props Included (8 categories, 115 prefabs):**
- **Barrel** -- 3 weathering variants (Clean, Old, Used) + 5 LOD levels
- **Barrel Light (Traffic Light)** -- 3 variants + LODs + extra bolt detail
- **Blocks** -- 15 variants: Barrier (2 types), Cube, Parking, Trim in Bare/Red Stripes/Yellow Stripes
- **Channelizing** -- 3 variants + LODs
- **Cone (Traffic Cone)** -- 3 variants + LODs
- **Pedestrian Barrier** -- 2 types x 3 variants + LODs
- **Vertical Panel** -- 3 variants + LODs
- **Water Barricade** -- 2 types x 3 variants + LODs

**Architecture:**
- **Zero scripts** -- pure content (meshes, materials, textures, prefabs)
- Standard URP/Lit shader -- no custom shaders
- LODGroup configured on all props (5 levels: 0.298, 0.198, 0.100, 0.050, 0.025 screen height)
- 45 materials, ~348 texture files (4K source -- resize for production)
- 1 demo scene per pipeline
- Separate unitypackages: BiRP (1.8 MB), URP (310 KB), HDRP (377 KB)

**Concerns:**
- **4K source textures** -- oversized for most use cases. Documentation explicitly says "resize externally to reduce actual project size."
- **No FBX included** -- models baked into prefabs. Can't re-export or modify geometry.
- **Installs to `Assets/Prototype Collection/`** -- generic folder name, not obviously linked to the asset name. Easy to lose track of.
- **Not in inventory CSV** -- likely a free download not captured in the asset inventory.

**Overlap Analysis:**
- No overlap with any evaluated asset. First 3D prop collection evaluated.
- Standard URP materials mean zero conflict with any shader system.

**Verdict Rationale:** Approved with **Default 3D** label. Free, zero-dependency, well-organized street props with excellent LOD chains. The 3 weathering variants per prop add visual variety. Standard URP/Lit materials mean instant compatibility. The 4K textures need downsizing for production, but that's a normal art pipeline step. At $0 there's no reason not to include this in any 3D project that needs urban/industrial set dressing.

**HOK Relevance:** LOW. Fishing sim on the river Acheron has limited use for traffic barricades. Possibly useful for dock area set dressing (water barricades, barriers).

**FearSteez Relevance:** HIGH. Beat 'em up set in Atlanta -- street barricades, traffic cones, barriers are perfect urban environment props. Weathered variants add gritty realism. LODs handle background props efficiently.

**3D Concept Projects Relevance:**
- Alpha Foxtrot Uniform (tactical shooter) -- HIGH, military/urban barricade set dressing
- Cursed Fantasy -- LOW, fantasy setting doesn't need modern traffic props
- GRIMMORPG -- MEDIUM, urban horror could use abandoned street barriers
- Space Garbage Man -- LOW, sci-fi setting
- Miracle Worker -- MEDIUM, modern urban horror setting

**2D Projects Relevance:** NONE. 3D props have no application in 2D games.

---

### ENTRY-161: Amplify Impostors (Amplify Creations)

| Field | Value |
|-------|-------|
| **Asset** | Amplify Impostors |
| **Publisher** | Amplify Creations |
| **Source** | Asset Store (via Amplify Bundle) |
| **Category** | Tools (Impostor/Billboard LOD Generation) |
| **Price** | Included with Amplify Bundle ($110) |
| **Rating** | N/A (bundled, no standalone CSV entry) |
| **Version** | 1.0.3 |
| **Unity Versions** | 2021.3+ through Unity 6 (6000.3+) |
| **Pipeline** | URP, HDRP, BiRP (all three, auto-detected) |
| **Dependencies** | None required (ASE optional for custom impostor shaders) |
| **Install Size** | ~222 MB (207 MB examples -- deletable; core is ~15 MB) |
| **Evaluated** | Feb 24, 2026 (Session 37) |
| **Asset Store Label** | Default 3D |
| **Verdict** | **Approved** |

**What It Does:** Bakes high-poly 3D objects into ultra-low-polygon impostor billboards for use as distant LODs. Renders the object from 256 angles (16x16 grid), packs the results into atlas textures (Albedo, Normals, Specular, Occlusion, Emission, Depth), and creates a 4-6 triangle impostor mesh that the runtime shader samples based on camera view direction. Replace a 50K polygon tree with a 4-triangle billboard that still looks correct from every angle.

**Key Features:**
- **3 impostor types:** Spherical (single quad, full parallax), Octahedron (6 triangles, compact normal encoding), HemiOctahedron (upper hemisphere only -- trees, rocks)
- **Multi-atlas baking:** Generates 6 packed texture atlases per object (Albedo+Alpha, Normals+Depth, Specular+Smoothness, Occlusion, Emission, Position)
- **Atlas resolution:** 512 to 8192, configurable frames per axis (default 16x16 = 256 views)
- **LODGroup integration:** 6 insertion modes (ReplaceCulled, ReplaceLast, InsertAfter, etc.) -- automatically adds impostor as final LOD
- **Custom mesh outline:** Triangulator generates silhouette-matching impostor mesh (4-16 vertices) instead of simple quad
- **Bake presets:** ScriptableObject configs for texture format (PNG/TGA/EXR), compression, channel selection, scale
- **Pipeline auto-detection:** Runtime shader selection via `RenderPipelineInUse` enum -- no manual pipeline config needed
- **Parallax depth:** Optional position atlas enables parallax effect on impostors for added depth perception
- **Shadow/GI support:** Impostors cast shadows and receive GI in all three pipelines

**Architecture:**
- 14 C# scripts, ~6,925 total lines
- **2 asmdef files:** `AmplifyImpostors.Runtime` (zero deps, all platforms), `AmplifyImpostors.Editor` (editor only, refs runtime)
- **Conditional ASE integration:** `AIToASE.asmdef` with `defineConstraints: ["AMPLIFY_SHADER_EDITOR"]` -- only compiles when ASE present
- **Namespace:** `AmplifyImpostors` -- clean, no global pollution
- 4 baking shaders (editor-only) + 2 runtime shaders + 2 CGINC includes
- No Burst/Jobs/Compute -- baking uses GPU via RenderTexture cameras; runtime is pure shader sampling
- Adds `AMPLIFY_IMPOSTORS` define symbol (can be disabled in Preferences)

**Concerns:**
- **207 MB examples** -- bulk of the install. Delete after reviewing; core is only 15 MB.
- **Bake time** -- rendering 256 views at high resolution takes seconds to minutes per object. One-time cost.
- **VRAM for 8K atlases** -- all 256 frames loaded simultaneously. 2K-4K recommended for most use cases; 8K only for hero objects.
- **Custom Triangulator** -- marching-squares-style silhouette detection. May produce unexpected shapes for highly concave objects; configurable vertex count (4-16) and tolerance mitigate this.
- **No per-frame streaming** -- entire atlas in VRAM at all times per impostor.

**Overlap Analysis:**
- **Complements Mesh Optimizer (150)** -- Mesh Optimizer decimates geometry for mid-range LODs; Impostors replace geometry entirely for far-range LODs. Different LOD tiers, perfect pipeline together.
- **Complements ASE (158)** -- optional integration lets you author custom impostor shaders in ASE's node editor.
- **No overlap with any other evaluated asset.** This is the only impostor/billboard system in the inventory.

**Verdict Rationale:** Approved with **Default 3D** label. Impostor LODs are essential for any 3D project with vegetation, props, or environment objects visible at distance. Replacing distant 50K-poly trees with 4-triangle billboards is a massive performance win. The multi-atlas approach preserves visual quality from all angles -- not just a flat billboard. Clean architecture (2 asmdefs, proper namespace, conditional ASE integration), mature codebase (30+ patches), and all-pipeline support. The 222 MB install is misleading -- core is 15 MB; examples are optional. Part of the $110 Amplify Bundle makes it excellent value alongside ASE.

**HOK Relevance:** HIGH. Critical for Acheron environment performance:
- Riverside trees/vegetation as impostor LODs at distance
- Rock formations along the river banks
- Background architectural elements (dock structures, distant landmarks)
- LODGroup pipeline: high-poly (near) -> Mesh Optimizer decimated (mid) -> Amplify Impostor (far)

**FearSteez Relevance:** LOW-MEDIUM. 2.5D beat 'em up has limited depth -- background 3D elements could use impostors, but the camera angle is mostly fixed. Useful if there are distant 3D environment layers.

**3D Concept Projects Relevance:** HIGH for open-world and environment-heavy titles:
- Open-world (Cursed Fantasy, Alpha Foxtrot Uniform) -- CRITICAL. Large environments need impostor LODs for vegetation, buildings, props at distance. Performance requirement.
- VR (Forensic Science Practical Lab) -- HIGH. VR frame budgets are tight; impostors for background objects essential.
- Point 'N Click (GRIMMORPG, Space Garbage Man) -- MEDIUM. Static camera angles reduce need, but still useful for distant scene elements.
- Action (Miracle Worker) -- HIGH. Horror environments with distant scenery benefit from impostor LODs.

**2D Projects Relevance:** NONE. Billboard impostor generation is inherently 3D.

---

### ENTRY-162: Amplify LUT Pack (Amplify Creations)

| Field | Value |
|-------|-------|
| **Asset** | Amplify LUT Pack |
| **Publisher** | Amplify Creations |
| **Source** | Asset Store (via Amplify Bundle) |
| **Category** | Textures (Color Grading LUT Library) |
| **Price** | Included with Amplify Bundle ($110) |
| **Rating** | N/A (bundled) |
| **Version** | Unknown (no version file) |
| **Unity Versions** | 2019.4+ |
| **Pipeline** | BiRP only (requires Amplify Color) |
| **Dependencies** | **Amplify Color** (REQUIRED -- not functional without it) |
| **Install Size** | ~61 MB |
| **Install Path** | Assets/AmplifyColor/ |
| **Evaluated** | Feb 24, 2026 (Session 37) |
| **Asset Store Label** | Don't Use |
| **Verdict** | **Rejected** |

**What It Does:** Library of 207 pre-made color grading LUT textures organized into 10 categories, plus an editor browser window for previewing and applying them. The LUTs are designed exclusively for the **Amplify Color** post-processing component (BiRP-only).

**LUT Library (207 textures across 10 categories):**
- Base (32) -- fundamental adjustments (bleach, tint, contrast, exposure, vibrance)
- Popular Looks (35) -- cinema-inspired grades (Blockbuster, Mad Max references, etc.)
- Stylized Misc (33) -- atmospheric effects (desert, alien, underwater, isolation)
- Stylized Retro (29) -- vintage/game looks (NES, Spectrum, ZX, Comic, Gamebob)
- Film Color (23) -- film emulation with color cast
- Stock Film Standard (14) -- professional film stocks
- Stock Film Base (14) -- film stock base curves
- Stock Film Vintage (12) -- aged film simulation
- Film Mono (8) -- black & white variants (high/low contrast, sepia)
- Color Blindness (7) -- accessibility simulation (Protanopia, Deuteranopia, Tritanopia)

**Architecture:**
- 1 C# script: `LUTBrowser.cs` (565 lines) -- EditorWindow for LUT browsing/preview
- 1 preview shader (84 lines) -- 4 passes for sRGB/Linear preview rendering
- **No asmdef** -- compiles into Assembly-CSharp
- **Namespace:** `AmplifyColor`
- LUT format: 1024x32 px 2D strip (32x32x32 color cube flattened), PNG, 8-bit RGBA
- Uses reflection to find `AmplifyColorEffect` component -- fails silently without Amplify Color

**Why Rejected:**
- **Requires Amplify Color** -- the LUT browser uses reflection to hook into `AmplifyColorEffect`, which is a BiRP-only post-processing component. Without Amplify Color installed, the browser window is non-functional.
- **NOT compatible with URP Color Grading** -- URP's Volume-based Color Grading uses a different LUT format (3D LUT textures or .cube files). These 1024x32 2D strip LUTs cannot be directly imported into URP's color grading system.
- **NOT compatible with HDRP Color Grading** -- same format incompatibility.
- **All TecVooDoo projects use URP** -- no project in the portfolio uses BiRP. Amplify Color (the required middleware) is itself BiRP-only and was already skipped for this reason.
- **The LUT textures themselves are nice** -- 207 well-categorized grades with color blindness accessibility support. But they're locked behind a BiRP-only pipeline.

**Could the LUTs be converted?** Technically yes -- a script could read the 1024x32 strips and convert to URP-compatible 3D LUT textures or .cube files. But that's custom tooling work for something URP already provides natively via its Color Grading volume and free LUT packs available online.

**Overlap Analysis:**
- URP's built-in Color Grading volume with Color Lookup override provides the same functionality natively, for free, with no dependencies.
- Amplify Color (the required companion) was already identified as BiRP-only and skipped.

**Verdict Rationale:** Rejected with **Don't Use** label. Beautiful LUT collection, wrong pipeline. Every TecVooDoo project uses URP. These LUTs require Amplify Color (BiRP-only) to function. URP's native Color Grading volume handles color grading without any third-party dependency. The format incompatibility (2D strip vs URP 3D LUT) means even the raw textures can't be directly used. Not worth the conversion effort when free URP-compatible LUT packs exist.

**Portfolio Relevance:** N/A -- Rejected. No TecVooDoo project uses BiRP.

---

### ENTRY-163: Lighting Box 2 (ALIyerEdon)

| Field | Value |
|-------|-------|
| **Asset** | Lighting Box 2 - Next-Gen Lighting Solution |
| **Publisher** | ALIyerEdon |
| **Source** | Asset Store |
| **Category** | Editor Tool (Lighting / Post-Processing Preset System) |
| **Price** | $10 |
| **Rating** | 4 stars (285 ratings) |
| **Version** | 2.9.9.7 |
| **Last Release** | Apr 13, 2025 |
| **Unity Versions** | 2022.3.59+ |
| **Pipeline** | BiRP ONLY (URP: NO, HDRP: NO -- confirmed by CSV) |
| **Dependencies** | Post Processing Stack v2 (deprecated) |
| **Install Size** | ~255 files, ~61 MB |
| **Slug** | https://assetstore.unity.com/packages/slug/93057 |
| **Purchased** | Jul 12, 2025 |
| **Evaluated** | Feb 24, 2026 (Session 37) |
| **Asset Store Label** | Don't Use |
| **Verdict** | **Rejected** |

**What It Does:** One-click lighting/post-processing preset system for BiRP. ScriptableObject profiles configure scene lighting (directional lights, ambient, fog, shadows), apply Post Processing Stack v2 effects (bloom, AO, SSR, DoF, etc.), and provide day/night cycle, volumetric lighting, terrain shaders, and a runtime settings menu. Comprehensive for BiRP -- completely non-functional for URP/HDRP.

**Key Features (BiRP only):**
- Lighting profiles via ScriptableObject presets
- Post Processing Stack v2 integration (bloom, AO, SSR, motion blur, etc.)
- Day/night cycle with automatic lighting adjustment
- Volumetric lighting (CommandBuffer-based god rays)
- Stochastic screen-space reflections
- Terrain shaders (4/6/8 layer splat maps)
- Foliage/snow/wind systems
- Runtime settings menu with PlayerPrefs persistence
- 9 HDRI skybox cubemaps

**Architecture:**
- 33 scripts, 11,333 total lines, 20 shaders
- **Namespace:** `LightingBox.Effects` -- clean
- **No asmdef** -- Assembly-CSharp
- No Burst/Jobs/Compute
- Heavy `[ExecuteInEditMode]` usage (5 scripts)
- Depends on Post Processing Stack v2 (54 references)

**Why Rejected (three blocking issues):**

1. **Shader compilation errors on Unity 6:**
   - `LightingBox/Nature/Snow-Leave Standard`: cannot implicitly convert from 'const float3' to 'float4' at line 142
   - `LightingBox/Snow/Leave Standard`: same error at line 139
   - Asset ships broken on the current Unity version.

2. **BiRP-only, confirmed:** CSV explicitly lists URP: FALSE, HDRP: FALSE. All shaders use BiRP Standard surface shader model. No URP `RenderPipeline` tags. VolumetricLight uses BiRP CommandBuffer API that doesn't integrate with URP's renderer.

3. **Post Processing Stack v2 dependency:** PPS v2 is deprecated in Unity 2022+. URP projects use the Volume system natively. The entire post-processing profile system (the core value proposition) is tied to a deprecated API.

**Overlap Analysis:**
- URP's built-in Volume system + Lighting Settings + Environment Lighting provides all of this functionality natively for free.
- Advanced Dissolve (156) and Curved World (155) handle shader effects that Lighting Box 2 partially covers, and they work with URP.

**Verdict Rationale:** Rejected with **Don't Use** label. Triple failure: shader errors on Unity 6, BiRP-only (all TecVooDoo projects use URP), and hard dependency on deprecated Post Processing Stack v2. The concept is sound -- preset-driven lighting configuration is genuinely useful -- but this implementation is locked to a dead pipeline. At $10 the financial loss is minimal.

**Portfolio Relevance:** N/A -- Rejected. No TecVooDoo project uses BiRP, and the asset doesn't even compile cleanly on Unity 6.

---

### ENTRY-164: A* Pathfinding Project Pro (Aron Granberg)

| Field | Value |
|-------|-------|
| **Asset** | A* Pathfinding Project Pro |
| **Publisher** | Aron Granberg |
| **Source** | Asset Store |
| **Category** | AI (Pathfinding / Navigation / Local Avoidance) |
| **Price** | $140 |
| **Rating** | 5 stars (827 ratings) |
| **Version** | 5.4.6 |
| **Last Release** | Jan 22, 2026 |
| **Unity Versions** | 2021.3.45+ / 2022.3.12+ |
| **Pipeline** | Pipeline-agnostic (includes URP/HDRP render pass features for debug visualization) |
| **Dependencies** | com.unity.burst (1.8.7), com.unity.collections (1.5.1), com.unity.mathematics (1.2.6), com.unity.entities (1.1.0-pre.3, optional) |
| **Install Size** | ~627 MB (includes examples; core is much smaller) |
| **Package ID** | com.arongranberg.astar |
| **Slug** | https://assetstore.unity.com/packages/slug/87744 |
| **Purchased** | Nov 19, 2025 |
| **Evaluated** | Feb 24, 2026 (Session 37) |
| **Asset Store Label** | Default |
| **Verdict** | **Approved** |

**What It Does:** Industry-standard pathfinding and navigation system. Replaces and far exceeds Unity's built-in NavMesh. Provides multiple graph types, 7+ pathfinding algorithms, 4 movement controllers, local avoidance (RVO), ECS support, and runtime graph updates. Used in hundreds of shipped titles.

**Key Features:**
- **6 graph types:** GridGraph (2D/3D, hex, isometric), LayerGridGraph (multi-level 3D), RecastGraph (auto-generated navmesh from geometry), NavMeshGraph (Unity navmesh wrapper), PointGraph (waypoint-based), LinkGraph (off-mesh links)
- **7 pathfinding algorithms:** ABPath (A*), ConstantPath (flood fill within cost), MultiTargetPath (one-to-many), FleePath (away from target), RandomPath (probabilistic), FloodPath/FloodPathTracer (BFS flood)
- **4 movement controllers:** AIPath (basic), AILerp (smooth interpolation), RichAI (advanced navmesh with funnel modifier), FollowerEntity (NEW v5.4 -- ECS-based, multithreaded)
- **RVO local avoidance:** Reciprocal Velocity Obstacles with quadtree acceleration, Burst-compiled
- **Full ECS integration (v5.4):** Components, Systems, Jobs for high-performance agents. FollowerEntity bakes to pure entities.
- **8 path modifiers:** Funnel, Raycast, SimpleSmooth, AdvancedSmooth, Radius, StartEnd, AlternativePath
- **Runtime graph updates:** GraphUpdateScene, NavmeshCut, NavmeshAdd for dynamic environments
- **Multithreaded pathfinding:** Queue-based work distribution with configurable thread count

**Architecture (exemplary):**
- 360 runtime scripts, ~33,725 LOC
- **4 asmdef files:** Runtime, Editor, Examples, BurstTriangulator -- proper isolation
- **28 namespaces** -- deep, well-organized hierarchy
- UPM package format (com.arongranberg.astar)
- Burst/Jobs throughout (grid collision, RVO, navmesh voxelization)
- Custom memory management: ObjectPool, ListPool, ArrayPool, BinaryHeap, SlabAllocator, NativeCircularBuffer
- Built-in profiler markers for pathfinding stages
- Serialization system for saving/loading graphs at runtime
- 10+ years of active maintenance

**Concerns:**
- **627 MB total** -- examples and documentation are bulk. Core is much smaller.
- **Pro version at $140** -- significant investment, but 827 ratings at 5 stars validates the value
- **ECS is new (v5.4)** -- FollowerEntity doesn't support Point graphs or hexagonal grids yet
- **Precompiled DLLs:** Clipper2Lib.dll and modified DotNetZip for graph serialization
- **Learning curve** -- 6 graph types, 7 algorithms, 4 movement controllers is a lot to learn

**Overlap Analysis:**
- **Replaces Unity NavMesh** entirely -- superior in every dimension (graph types, algorithms, local avoidance, ECS, runtime updates)
- **Complements UCC (165)** -- UCC has NavMeshAgentMovement and PathfindingMovement abilities that can integrate with A*
- **Complements Behavior Designer** (also by Opsive, in CSV) -- A* for pathfinding, BD for decision-making
- No conflict with any evaluated asset

**Verdict Rationale:** Approved with **Default** label (any project with AI agents needs pathfinding). This is THE pathfinding solution for Unity -- 827 ratings at 5 stars, 10+ years of development, Burst/Jobs/ECS, 6 graph types, and active maintenance (Jan 2026 update). The Pro version's $140 price is justified by the depth: RVO local avoidance, Recast navmesh generation, ECS FollowerEntity, and runtime graph updates are features no free alternative matches. Even 2D projects benefit from GridGraph pathfinding.

**HOK Relevance:** HIGH. Direct applications:
- NPC navigation on Acheron environment (RichAI on RecastGraph)
- Fish AI pathfinding in water volumes (PointGraph or GridGraph)
- Companion AI following Kharon (FollowerEntity for performance)
- Local avoidance for multiple NPCs near the dock/ferry (RVO)
- Dynamic navigation updates when ferry moves (NavmeshCut)

**FearSteez Relevance:** HIGH. Beat 'em up enemy AI:
- GridGraph or LayerGridGraph for 2.5D level navigation
- AIPath for enemy movement toward player
- MultiTargetPath for enemies choosing between multiple targets
- FleePath for enemies retreating when low health
- RVO for crowd movement without overlap

**3D Concept Projects Relevance:** HIGH across all titles with AI:
- Open-world (Cursed Fantasy, Alpha Foxtrot Uniform) -- RecastGraph for large navmeshes, ECS FollowerEntity for crowd scale
- VR (Forensic Science Practical Lab) -- GridGraph for room navigation
- Point 'N Click (GRIMMORPG, Space Garbage Man) -- PointGraph for click-to-move navigation
- Action (Miracle Worker) -- RichAI + RVO for horror enemy swarms

**2D Projects Relevance:** MEDIUM. GridGraph supports 2D natively. A Quokka Story (Metroidvania) could use GridGraph for enemy AI. DLYH/Shrunken Head Toss unlikely to need pathfinding.

---

### ENTRY-165: Ultimate Character Controller (Opsive)

| Field | Value |
|-------|-------|
| **Asset** | Ultimate Character Controller |
| **Publisher** | Opsive |
| **Source** | Asset Store |
| **Category** | Framework (Character Controller / Ability System / Item System) |
| **Price** | $249 |
| **Rating** | 5 stars (135 ratings) |
| **Version** | 3.3.3p1 |
| **Last Release** | Dec 31, 2025 |
| **Unity Versions** | 2021.3+, 2022.1+, 2022.3+ |
| **Pipeline** | URP, HDRP, BiRP (integration packages for URP/HDRP) |
| **Dependencies** | com.opsive.shared (v2.1.0, bundled) |
| **Install Size** | ~485 scripts, 58,383 LOC (+ 1002 animations, 201 audio files in demo) |
| **Package ID** | com.opsive.ultimatecharactercontroller |
| **Slug** | https://assetstore.unity.com/packages/slug/233710 |
| **Purchased** | Nov 19, 2025 |
| **Evaluated** | Feb 24, 2026 (Session 37) |
| **Asset Store Label** | Default 3D |
| **Verdict** | **Approved** |

**What It Does:** Complete character controller framework with kinematic movement, modular ability system, item/inventory management, first-person and third-person perspective support (with runtime switching), camera system, surface detection, and networking scaffolding. This is an entire game character foundation, not just a controller.

**Edition:** Full package (First Person + Third Person combined).

**Key Systems:**

- **Character Locomotion:** Kinematic (non-Rigidbody) movement with root motion support, gravity direction control, ground detection, slope handling, moving platform support, skin width mechanics. Predictable and precise.
- **Ability System (39+ built-in):** Modular abilities with priority-based stacking, input binding (ButtonDown, DoublePress, LongPress, Tap, Axis), and network sync. Built-in: Jump, Fall, Slide, HeightChange, Drive, Ride, Interact, Ragdoll, Die, Revive, NavMeshAgentMovement, plus all item abilities (Equip, Use, Reload, Aim, Block, MeleeCounterAttack).
- **Item & Action System:** CharacterItem → PerspectiveItem → ItemAction pipeline. Modular action types: Melee, Shootable, Throwable, Magic. Per-item state variables (ammo, cooldown).
- **Inventory:** ItemCollection, ItemSet loadout management, ItemSetRules for auto-switching, network-aware tracking.
- **Camera:** Perspective switching (FP/TP at runtime), ViewType system (Adventure, Combat), anchor offset, zoom, timescale sync.
- **Surface System:** SurfaceManager + SurfaceType + SurfaceIdentifier for contextual effects (footsteps, impacts, decals by material).
- **State System:** Animator parameter management via state names, conditional activation.

**Architecture:**
- 485 scripts total (361 runtime + 124 editor), 58,383 LOC
- **4 asmdef files:** Runtime, Editor, Demo, Demo.Editor
- **Namespace:** `Opsive.UltimateCharacterController.*` (deeply organized by module)
- Depends on `com.opsive.shared` (63 scripts -- shared audio/input/utility framework)
- UPM package format
- **No Burst/Jobs** -- pure managed C#, single-threaded. Appropriate for action game logic where frame-precise control matters more than throughput.
- Kinematic physics (raycasts + manual velocity) instead of Rigidbody -- more predictable, better suited for character controllers
- Heavy use of `[SerializeReference]` for polymorphic ability/item lists
- Object pooling for projectiles/effects
- 14 networking scripts (framework-agnostic scaffolding -- no specific Netcode/Mirror/Photon)

**Demo Content (substantial):**
- 1 demo scene (URP + Input System)
- 1,002 animations (FBX -- movement, combat, items)
- 201 audio files (footsteps, impacts, voice)
- 100+ prefabs (characters, weapons, effects)
- Player "Atlas" + Enemy "EnemyAtlas" with full loadouts

**Concerns:**
- **$249 is the highest-priced asset evaluated** -- justified by scope (it's an entire game framework), but significant investment
- **58K LOC is massive** -- steep learning curve. Online documentation essential.
- **No Burst/Jobs** -- all logic runs on main thread. Fine for typical action games but won't scale to hundreds of simultaneous characters
- **Opinionated kinematic model** -- excellent for action games, but not flexible for physics-heavy simulations
- **Minimal in-package docs** -- QuickStart.pdf + README.txt only. Relies on opsive.com documentation
- **Deep inheritance** -- CharacterLocomotion → UltimateCharacterLocomotion chains can be hard to debug
- **Editor asmdef references Assembly-CSharp** -- unusual, may cause issues with custom asmdef setups

**Overlap Analysis:**
- **Complements A* Pathfinding (164)** -- UCC has NavMeshAgentMovement and PathfindingMovement abilities designed for A* integration
- **Complements Behavior Designer** (Opsive, in CSV) -- same publisher, designed to work together. BD for AI decisions, UCC for character execution.
- **Replaces Unity's CharacterController** for any project that needs abilities, items, or perspective switching
- **Does NOT overlap with HOK's custom systems** -- HOK uses custom event system, custom animation controllers. UCC is a different architectural approach.

**Verdict Rationale:** Approved with **Default 3D** label. At $249, UCC is a substantial investment that pays off for any 3D project needing a full character controller with combat, items, and abilities. The ability system alone (39+ built-in abilities with modular input binding and priority stacking) would take months to build from scratch. FP+TP perspective switching at runtime is a premium feature. The kinematic movement system is battle-tested and predictable. Active maintenance (Dec 2025 update), URP/HDRP support, and the Opsive ecosystem (Behavior Designer, shared framework) add long-term value. The learning curve and price are the main barriers.

**HOK Relevance:** LOW-MEDIUM. HOK uses custom systems (custom event system, custom animation controllers). UCC's ability system could handle Kharon's movement and fishing mechanics as custom abilities, but retrofitting HOK's existing architecture onto UCC would be more work than benefit at this stage. Better suited as a foundation for NEW 3D projects.

**FearSteez Relevance:** VERY HIGH. Beat 'em up is UCC's sweet spot:
- Melee combat abilities (punch, kick, block, counter) -- built-in
- Item system for weapons (bats, pipes, throwables)
- Third-person camera with combat view
- Enemy AI via PathfindingMovement ability + A* integration
- Surface system for contextual hit effects (punch on metal vs flesh)
- Damage/Health traits for combat
- Ragdoll + Die + Revive abilities

**3D Concept Projects Relevance:** HIGH for action-oriented titles:
- Alpha Foxtrot Uniform (tactical shooter) -- VERY HIGH. Shootable items, FP controller, inventory, networking scaffolding
- Cursed Fantasy (action adventure) -- HIGH. Ability system for combat + exploration abilities
- Miracle Worker (action horror) -- HIGH. Melee/magic items, FP/TP switching for horror camera
- GRIMMORPG (point 'n click) -- LOW. Click-to-move doesn't need a full character controller
- Forensic Science Practical Lab (VR) -- LOW-MEDIUM. Basic VR support exists but limited

**2D Projects Relevance:** NONE. Kinematic 3D character controller has no application in 2D games.

---

### ENTRY-166: Beat 'Em Up - Game Template 3D (Osarion)

| Field | Value |
|-------|-------|
| **Asset** | Beat 'Em Up - Game Template 3D |
| **Publisher** | Osarion |
| **Source** | Asset Store |
| **Category** | Game Template (Complete Beat 'Em Up Framework) |
| **Price** | $85 |
| **Rating** | 5 stars (37 ratings) |
| **Version** | 1.4 |
| **First Published** | May 20, 2020 |
| **Unity Versions** | 2017.2.1, 2018.3.0, 2019.3.0 |
| **Pipeline** | Pipeline-agnostic (no custom shaders, standard materials) |
| **Dependencies** | None -- fully self-contained |
| **Install Size** | 755 files, 60 scripts (4,817 LOC), 5 scenes, 45 prefabs |
| **Slug** | https://assetstore.unity.com/packages/slug/98013 |
| **Publisher YouTube** | https://www.youtube.com/channel/UC9QvPxEcK2XUvaRT2kdpLhg |
| **Evaluated** | Feb 25, 2026 (Session 39) |
| **Asset Store Label** | Default 3D |
| **Verdict** | **Approved** |

**What It Does:** Complete, playable beat 'em up game template with 13 interconnected systems: Input, Movement, Combat (combos, weapons, defense, knockdown), Enemy AI (5 tactics, distance-based decisions), Wave/Progression spawning, Health/Damage, Camera (multi-target follow), Audio (AudioMixer, 3D spatial), Items (weapon pickup with degradation), UI (menus, HUD, character/level selection, touch controls), Level management, Animation, and environmental destruction. Ships with 2 playable characters, 1 enemy type, 5 scenes, and a training room.

**Key Systems:**

- **Combat:** PlayerCombat.cs (799 lines) -- punch/kick combos with time windows, running attacks, jump kicks, ground attacks. Defense with 360-degree blocking option. Weapon system: melee (baseball bat) + ranged (gun, knife) with degradation (on-use or on-hit). IDamagable<T> generic interface.
- **Enemy AI:** EnemyAI.cs (180 lines) + EnemyActions.cs (595 lines) -- distance-based decision making (attack/close/mid/far range). 5 tactics: Engage, KeepCloseDistance, KeepMediumDistance, KeepFarDistance, StandStill. Z-spread to prevent stacking. Defend chance property. Random or sequential attack selection.
- **Movement:** PlayerMovement.cs (314 lines) -- walk/run (double-tap to run), jumping, Z-axis depth movement. Wall detection via capsule overlap. Air acceleration. Separate ground/air physics.
- **Wave System:** EnemyWaveSystem.cs (176 lines) -- wave-based spawning with area triggers. MaxAttackers limiter. Slow-motion on last kill. Level progression on wave clear.
- **Input:** InputManager.cs (224 lines) -- keyboard, joypad, touchscreen. Custom InputControl serializable class. Event-driven (onInputEvent, onDirectionInputEvent). Auto-switches to touch on mobile. **Uses OLD Input System** (Input.GetKey/GetAxis, NOT Unity's New Input System package).
- **Camera:** CameraFollow.cs (101 lines) -- multi-target follow with per-axis damping. Height offset, view angle. Area collider constraints for wave boundaries. CamShake for impacts.
- **UI:** UIManager.cs -- screen management with named screens. UIFader for transitions. Virtual joystick for mobile. Character selection (2 chars), level selection, game over, level complete screens.
- **Audio:** AudioPlayer.cs (107 lines, BeatEmUpTemplate namespace) -- AudioItem system with volume/loop/min-time-between-calls. 3D spatial support. 41 audio clips included.
- **Items:** WeaponPickup.cs + HealthPickup.cs -- weapon degradation (working/broken states), ranged projectiles, melee hand weapons. Spawns loot on enemy destroy.

**Architecture:**
- 60 scripts, 4,817 LOC total. Well-organized by domain (13 subfolders under Scripts/).
- **Only 1 namespace:** `BeatEmUpTemplate` (AudioPlayer.cs only). All 59 other scripts in global Assembly-CSharp scope.
- **No asmdef files.** Everything compiles to Assembly-CSharp.
- Uses SendMessage for loose coupling between systems.
- Event delegates for input, health, and unit destruction.
- Singleton pattern for AudioPlayer, InputManager (static references).
- Serializable data objects (DamageObject, Weapon, InputControl, UI_Screen) -- all designer-configurable via Inspector.
- UNITSTATE enum-based state machine for characters.
- 7 prefabs auto-instantiated from Resources/ on scene load (AudioPlayer, GameCamera, HitEffect, InputManager, UI, ProjectileBullet, ProjectileKnife).

**Included Content:**
- 5 Scenes: MainMenu, Game, CharacterSelection, LevelSelection, TrainingRoom
- 2 playable characters (Player1, Player2) with full animation sets
- 1 enemy type with AI
- 45 prefabs (characters, weapons, pickups, destructibles, effects, UI)
- 5 Animator Controllers (Player, Enemy, DrumBarrel, TrainingDummy, WoodenCrate)
- 41 audio clips + AudioMixer
- 115 materials/textures
- Environmental destructibles (crates, barrels, cardboard boxes, garbage)
- GameSettings ScriptableObject for volume/difficulty

**Concerns:**
- **Old Input System** -- uses Input.GetKey/GetAxis, not the New Input System package. Would need migration for modern projects.
- **No namespaces** -- 59/60 scripts in global scope. Risk of name collisions in larger projects.
- **No asmdef** -- everything in Assembly-CSharp. Slower compile times, no assembly isolation.
- **SendMessage usage** -- fragile string-based messaging. Works but not type-safe.
- **FindObjectOfType scattered** -- performance concern at scale (called in initialization, not per-frame).
- **Tag-dependent** -- heavy reliance on "Player" and "Enemy" tags.
- **Magic strings for animations** -- string-based trigger names prone to typos.
- **Published 2020, Unity 2017-2019 targets** -- works on Unity 6 but wasn't designed for it. No Burst/Jobs, no ECS patterns.
- **Limited publisher presence** -- YouTube channel only, no comprehensive documentation site.
- **uGUI (Canvas/Button/Image/Text)** -- not UI Toolkit. Fine for prototyping but may need migration for modern projects.

**Overlap Analysis:**
- **Complements Frank Slash Pack (167)** -- template provides the game framework (movement, AI, waves, camera, UI), Slash Pack provides premium animations (whip combos). Template's combat system can be adapted to use Slash Pack's whip animations.
- **Partially overlaps UCC (165)** -- UCC is a far more sophisticated character controller. Template's PlayerMovement/PlayerCombat could be replaced by UCC abilities for production, but template is better for rapid prototyping.
- **A* Pathfinding (164) could replace** the built-in distance-based EnemyAI for more sophisticated navigation and pathfinding.
- **Feel (not installed)** could replace CamShake and add more game juice.
- **Animancer Pro (not installed)** could replace string-based animation triggering for type-safe animation control.

**Verdict Rationale:** Approved with **Default 3D** label. Despite its age (2020), this template delivers a complete, playable beat 'em up out of the box. The 13 interconnected systems provide an excellent architectural reference and rapid-prototyping foundation for FearSteez. At $85, it saves weeks of foundational work. The old Input System and lack of namespaces/asmdef are real concerns, but acceptable for a template that will be adapted rather than shipped as-is. The combat system (799 lines with combos, weapons, defense, knockdown) and enemy AI (5 tactics, distance-based) are the primary value. For FearSteez specifically: the 2.5D movement with Z-axis depth, wave-based progression, and weapon pickup/degradation system map directly to the GDD.

**FearSteez Relevance:** VERY HIGH.
- 2.5D movement with Z-axis depth -- exactly what FearSteez needs
- Combo system with punch/kick chains -- maps to GDD's combat design
- Wave-based enemy spawning -- core beat 'em up progression
- Weapon pickup with degradation -- environmental combat variety
- Training room scene -- immediate development testbed
- Mobile touch controls -- future platform target
- 2-player character selection -- extensible for co-op

**Other 3D Projects Relevance:**
- HumiliNation (physics simulator) -- LOW. Template is action-focused, not physics.
- Alpha Foxtrot Uniform (tactical shooter) -- LOW. Wrong genre, use UCC instead.
- A Quokka Story (metroidvania) -- MEDIUM. Side-scrolling combat patterns transferable, but 2D.

---

### ENTRY-167: Frank Slash Pack - 11 Assets (Frank climax)

| Field | Value |
|-------|-------|
| **Asset** | Frank Slash Pack - 11 Assets |
| **Publisher** | Frank climax |
| **Source** | Asset Store |
| **Category** | Animation (Multi-Weapon Combat Animation Library) |
| **Price** | $99.99 |
| **Rating** | 4 stars (66 ratings) |
| **Version** | 3.8 |
| **Last Release** | Jan 20, 2026 |
| **Unity Versions** | 2022.3.12, 6000.0.63 |
| **Pipeline** | Pipeline-agnostic (humanoid FBX animations + standard materials) |
| **Dependencies** | None -- pure animation/model asset |
| **Install Size** | 1,034 animation FBX files, 17 character meshes, 48 materials, 68 animator controllers |
| **Slug** | https://assetstore.unity.com/packages/slug/141184 |
| **Publisher YouTube** | https://www.youtube.com/channel/UCLPo0S-jGP3ktbGaz74u-lA |
| **Evaluated** | Feb 25, 2026 (Session 39) |
| **Asset Store Label** | Default 3D |
| **Verdict** | **Approved** |

**What It Does:** Massive combat animation library covering 10 weapon types with complete animation sets for each: equip/unequip, 8-way locomotion (root motion AND in-place variants), evade (4-directional), attacks, combos (full + individual cuts), skills, hit reactions, death, jump, guard/block. Includes character meshes and weapon meshes per weapon type. No scripts -- pure animation/rig content.

**Weapon Types (10 sets):**

| Weapon | FBX Files | Notes |
|--------|-----------|-------|
| 2Handed | 75 | Two-handed sword |
| Assassin | 166 | Stealthy blade work |
| Critical Skills | 14 | Shared critical/finisher moves |
| Damages | 158 | Shared damage reactions library |
| Dual | 113 | Dual-wield blades |
| GreatSword | 76 | Heavy sword |
| Katana | 149 | Japanese sword |
| Spear | 83 | Polearm |
| StealthKill | 11 | Assassination animations |
| Sword2 | 22 | Sword + shield |
| Warrior | 135 | Generic warrior |
| **Whip** | **14** | **Primary FearSteez interest** |

**Whip Animation Set (Primary Interest -- ~65 clips):**
- **Equip/Unequip:** 4 clips (equip, unequip, equip idle, unequip idle)
- **Locomotion:** 8-way walk + 8-way run + guard walk + turbo run. Both Root Motion (RM) and In Place (IP) variants.
- **Evade:** 4-directional dodge (Forward, Left, Right, Back)
- **Attacks:** 6 single attacks (Attack01-06)
- **Combos:** 5 full combo chains + 15 individual combo cuts (3 parts each for granular control)
- **Skills:** 2 special abilities + 1 critical attack
- **Hit Reactions:** 7 hit states with escalating severity + Guard + Block
- **Death:** 4 death animation variants
- **Jump:** 3 full jumps + double jump + 0-height variants (start/air/end)
- **Damage Man:** 3 damage receiver animations (Skill01, Skill02, Critical_Attack hit reactions)
- **Weapon Animation:** Separate whip weapon mesh animations (whip cracking/unfurling)

**Character Models:**
- 17 FBX character meshes total (one per weapon style + damage man + weapon meshes)
- Whip: Frank_Whip_Body_Only.FBX (1.8 MB), Frank_Whip_Weapon.FBX (118 KB), Frank_Whip_WithCam.FBX (includes camera rig)
- Modular: body and weapon meshes separated -- can retarget animations to any humanoid character
- Medium-poly (estimated 10k-30k body, 2k-5k weapons based on file sizes)

**Animation Quality:**
- **Humanoid rigged** -- all animations retargetable to any humanoid avatar (including Synty SidekickCharacter)
- **Root Motion AND In-Place variants** -- critical for FearSteez (2.5D needs in-place for code-driven movement)
- **Baked FBX format** -- frame ranges documented in 11 motion list text files
- **Looping:** Locomotion/idle clips loop; attacks/skills/deaths are one-shot
- **Combo cuts:** Each combo split into individual parts (1, 2, 3) allowing granular combo state machine control
- **68 Animator Controllers included** -- pre-built state machines for each weapon type

**Documentation:** 11 motion list text files with frame ranges for every animation in every FBX. Publisher contact: climax0625@gmail.com (custom animation requests available, charges apply).

**Concerns:**
- **$99.99 is premium** -- but 1,034 animations across 10 weapon types is substantial value per-clip
- **No scripts** -- requires full gameplay implementation. Animation-only asset.
- **FBX multi-clip format** -- animations baked into master FBX files with frame ranges. Unity auto-extracts, but renaming/reorganizing individual clips takes manual effort.
- **Single slash effect texture** -- only 1 TGA file (fx_Pinkslash_D.TGA). VFX is minimal.
- **Limited publisher presence** -- YouTube channel only. Contact email for support.
- **Whip set is the smallest** (14 FBX files) -- still comprehensive for FearSteez needs, but other weapon types have 5-10x more content
- **No facial animations or dialogue** -- body combat only

**Overlap Analysis:**
- **Complements Beat 'Em Up Template (166)** -- template provides framework, Slash Pack provides premium whip animations. Template's combo system can drive Slash Pack's whip combos.
- **Complements Animancer Pro** (not installed) -- Animancer's runtime animation control would simplify Slash Pack animation management vs. string-based animator triggers.
- **Damages library (158 FBX files) is shared** -- hit/knockdown/death reactions usable by both player AND enemies regardless of weapon type. Significant value add.
- **Does NOT overlap with FS Melee Combat System** (from original standalone project) -- that asset provides code/framework, this provides animation content.

**Verdict Rationale:** Approved with **Default 3D** label. The whip animation set alone justifies inclusion for FearSteez -- ~65 clips covering the complete combat lifecycle (equip, 8-way locomotion, evade, 6 attacks, 5 combos with granular cuts, 2 skills, 7 hit reactions, 4 deaths, jumps). The in-place variants are essential for 2.5D movement. Beyond whip, the 158 shared damage animations provide enemy hit reactions. The remaining 9 weapon types are bonus value for future projects or enemy variety. Humanoid rigging means all animations retarget to any character mesh (confirmed working with Synty models). At $1 per 10 animations, price-per-clip value is excellent.

**FearSteez Relevance:** VERY HIGH.
- Whip is FearSteez's signature weapon -- 65 whip animations provide the complete moveset
- In-place variants suit 2.5D code-driven movement
- Combo cuts (individual parts) enable the GDD's "easy to start, rewarding to master" combo philosophy
- 4-directional evade maps to beat 'em up dodge mechanics
- 158 shared damage animations work for ALL enemy types
- Skills and critical attacks map to GDD's "Special (B/Circle) = Signature move"
- Humanoid rig retargets to Synty placeholder and eventual custom FearSteez character

**Other 3D Projects Relevance:**
- Cursed Fantasy (action adventure) -- HIGH. Katana, GreatSword, Dual weapon sets
- Alpha Foxtrot Uniform (tactical shooter) -- LOW. No ranged weapon animations
- A Quokka Story (metroidvania) -- MEDIUM. Assassin/Dual sets for side-scrolling combat
- Miracle Worker (action horror) -- MEDIUM. Warrior/2Handed sets for horror combat

---

## ENTRY-001: Malbers Inventory System 2.3

**Date:** 2026-03-14 (Session 58 -- Malbers Ecosystem Re-eval)
**Source:** Asset Store (Malbers Animations)
**Category:** UI / Inventory
**Verdict:** Conditional
**Label:** --
**Path:** Included in `Assets/Malbers Animations/` (shared Common dependency)

**What it is:** Inventory system designed for the Malbers ecosystem. Item management, equipment slots, drag-and-drop UI. Part of the broader Malbers framework -- shares Common scripts and ScriptableObject architecture with Animal Controller.

**Ecosystem Context:** Malbers sells this standalone, but it's designed to plug into the AC ecosystem. Equipment affects animal/character stats through the shared Stats system. Works best when paired with AC characters that already have the stat framework wired up.

**Why Conditional:**
- ENTRY-169 (Inventory Framework 2 FREE) uses modern UI Toolkit vs uGUI -- better for new projects
- However, if a project is already deep in the Malbers ecosystem (using AC, Stats, Modes), this inventory integrates natively with zero adapter code
- For AQS specifically: Joey pouch management is custom-designed and wouldn't benefit from a generic inventory system

**Project Relevance:**
- AQS: LOW -- custom pouch/Joey management system planned
- HOK: N/A -- HOK doesn't use Malbers
- 3D Action/Adventure concepts using AC: MEDIUM -- native stat integration useful
- Projects not using AC: LOW -- use ENTRY-169 instead

**Asset Interactions:** Native integration with AC Stats system, MInput, and Malbers ScriptableObject architecture. Competes with ENTRY-169 (Inventory Framework 2) which is more modern but ecosystem-agnostic.

---

## ENTRY-028: Malbers Animal Controller (AC) 4.5.1

**Date:** 2026-03-14 (Session 58 -- Malbers Ecosystem Re-eval)
**Source:** Asset Store (Malbers Animations)
**Category:** Animation / Character
**Verdict:** Approved
**Label:** Recommended
**Path:** `Assets/Malbers Animations/Animal Controller/` + `Assets/Malbers Animations/Common/`
**Namespace:** `MalbersAnimations.Controller`

**What it is:** Scriptable-architecture animation framework controller for any creature or humanoid character. Root-motion or in-place animation support. The core of the entire Malbers ecosystem -- all other Malbers character packs depend on it. v4.5.1 (Jan 17, 2026), Unity 6 compatible (6000.0.60+), 3,067 files, 344.83 MB.

**Package Dependencies:** Cinemachine 3 (Unity 6), Unity Input System, Shader Graph, Spline tools, Text Mesh Pro, AI Navigation.

**Architecture -- Three Pillars:**
1. **States** (16 built-in): Idle, Locomotion, Jump, JumpBasic, Fall, Fly, Glide, Swim, SwimUnderwater, Climb, WallRun, WallRunVertical, Slide, LedgeGrab, Death. ScriptableObject-based, hot-swappable at runtime via `State_Replace()`. Priority system controls transitions.
2. **Modes:** Reusable ability containers (attack, action, damage, etc.). Each mode holds multiple Abilities with cooldown, status modifiers, and reactions. Not separate files -- serialized lists on the MAnimal component.
3. **Stances:** Posture/behavior modifiers (combat stance, crouch, sneak). Affect how States and Modes behave without changing the state itself.

**Core Component:** `MAnimal` (partial class across 3 files: MAnimal.cs, MAnimalCallBacks.cs, MAnimalVariables.cs). Implements IAnimatorListener, ICharacterMove, IGravity, IObjectCore, IMDamagerSet, ILockCharacter, IDeltaRootMotion, and more.

**Scripting API Surface (100+ public methods):**
- State control: `State_Activate(ID)`, `State_Force(ID)`, `State_TryActivate(ID)`, `State_Enable/Disable(ID)`, `State_Replace(State)`, `State_Get(ID)`
- Mode control: `Mode_Activate(ID, AbilityIndex)`, `Mode_ForceActivate(ID)`, `Mode_TryActivate(ID)`, `Mode_Stop()`, `Mode_Interrupt()`, `Mode_Enable/Disable(ID)`
- Stance control: `Stance_Set(ID)`, `Stance_Toggle(ID)`, `Stance_Activate(ID)`, `Stance_Reset()`
- Movement: `Move(Vector3)`, `Move(Vector2)`, `StopMoving()`, `SpeedUp()`, `SpeedDown()`, `Sprint_Set(bool)`, `Strafe_Toggle()`, `Always_Forward(bool)`
- Speed: `Speed_CurrentIndex_Set(int)`, `SpeedSet_Set_Active(string, int)`, `Speed_Lock(bool)`, `SetCustomSpeed(MSpeed)`
- Physics: `Force_Add(Vector3, float)`, `Force_Remove()`, `Gravity_ResetDirection()`, `CheckIfGrounded()`
- Teleport: `Teleport(Vector3)`, `TeleportRot(Transform)`
- Animator: `SetAnimatorSpeed(float)`, `SetAnimParameter(hash, value)`, `SetRandom(value, priority)`
- Events: `State_EnterEvent_AddListener/RemoveListener`, `Stance_EnterEvent_AddListener/RemoveListener`
- Player: `SetMainPlayer()`, `DisableMainPlayer()`, `ResetInputSource()`

**Key Properties:** `ActiveState`, `ActiveStateID`, `ActiveStance`, `ActiveMode`, `Grounded`, `Sprint`, `Strafe`, `FreeMovement`, `MovementAxis`, `Position`, `Rotation`, `Gravity`, `GravityPower`, `UseGravity`, `IsPlayingMode`, `MovementDetected`

**ID System:** Type-safe ScriptableObject IDs (`StateID`, `ModeID`, `StanceID`) -- avoids magic ints. IDs located in `Common/Scriptable Assets/`.

**Input:** `MInput` component with `RemapInput(name, KeyCode)`, `SetMap(int/string)`, `Enable(bool)`, `ResetInputs()`. Supports Unity New Input System and Rewired.

**Included Characters:** Wolf Lite (quadruped demo), Human (humanoid demo with holster/weapon systems). Empty Controller template for custom characters.

**Demo Scenes (23):** Forest, PlayGround (Empty/Human/Wolf), Interactables, Mobile, Point-Click/Top-Down, **2.5 Platformer**, Timeline, MPath Constraint, Replace States at Runtime, Swap Characters, Stat Health, Ragdoll Death, Surface Effects, Carry Box (IK), Animal Tracker, Ground Aligner.

**2.5D Platformer Demo:** Built-in demo at `1-Demos/-- 01 Main Demos --/5 - 2.5 Platformer/`. Directly relevant to AQS -- demonstrates side-scrolling movement with AC's state machine handling jump, fall, locomotion, and climb on a 3D character constrained to a 2D plane.

**Animator Behaviours:** 5 types that attach to Animator states: Message Behaviour (event dispatch), Random Behaviour (idle variation), IsKinematic Behaviour, Sound Behaviour, Rigid Constraint Behaviour.

**Third-Party Integrations:** Invector, Opsive UCC, Game Kit Controller, A* Pathfinding, Rewired. Integration scripts in dedicated folder + Google Drive.

**Common Folder (shared dependency):** 48+ script categories, extensive human animation library (30+ categories: Actions, Attacks, Balance, Block, Crouch, Deaths, Dodge, Fall, Fly, Free Climb, Glide, Hit, Idle, Jumps, Knock Back, Ladder, Locomotion, PushPull, Recover, Slide, Stances, Swim, Traversal, WallRun, Weapons, Zipline). Shared audio, materials, particles, physics materials, Cinemachine integration, prefabs (AI, environments, interactables, mobile input, UI, weapons, zones).

**Concerns:**
- Large footprint (344 MB, 3,067 files) -- brings a lot even if you only need basic movement
- Learning curve -- States/Modes/Stances is a different mental model from typical CharacterController scripts
- Previous convention was "NOT Malbers AC" for HOK -- that was project-specific, not ecosystem-wide
- Upgrading: remove `MalbersAnimations/Common/` folder and reimport if scripts cause errors

**Project Relevance:**
- AQS: **HIGH** -- 2.5D platformer demo directly applicable. Climb, Jump, Fall, Swim states handle core quokka movement. Raccoon AC pack provides ready-to-use character. Would replace custom QuokkaController.
- HOK: N/A -- HOK explicitly doesn't use AC (custom movement)
- 3D Action/Adventure concepts: HIGH -- full combat/traversal state machine
- FearSteez: MEDIUM -- 2.5D beat-em-up could use AC's mode system for attacks
- VNPC: LOW -- point-and-click doesn't need this complexity

---

## ENTRY-029: Ultimate Selector 3.4.8 (Malbers)

**Date:** 2026-03-14 (Session 58 -- Malbers Ecosystem Re-eval)
**Source:** Asset Store (Malbers Animations)
**Category:** UI
**Verdict:** Approved
**Label:** --
**Path:** `Assets/Malbers Animations/Ultimate Selector/`

**What it is:** Radial/carousel character selection system. Animated item transitions, UI overlay, save/lock states. Designed for character select screens or runtime item swapping.

**Key API:**
- `SelectorController`: `SelectNextItem(bool/int/MItem/string)`, `UpdateLockItems()`, `_PlayAnimation(string)`, `_PlayAnimationPreviousItem(string)`, `_PlayAnimationTransform(TransformAnimation)`
- `SelectorManager`: manages multiple selector instances
- `SelectorUI`: UI rendering
- `MItem`/`MItemSet`: item definitions as ScriptableObjects

**Demo:** Dedicated scene with animated character carousel, transform animations, lock/unlock states.

**Project Relevance:**
- AQS: LOW -- no character selection needed (Mom is the only playable character, Joey swapping is pouch-based)
- HOK: LOW -- single playable character
- 3D Action/Adventure concepts: MEDIUM -- character selection for multi-character games
- Any project with character/loadout selection: MEDIUM

**Asset Interactions:** Works standalone but integrates with AC for character swapping (see AC Demo 10 - Swap Characters).

---

## ENTRY-030: Fishing for Animal Controller

**Date:** 2026-02-07 (original) / 2026-03-14 (re-eval notes)
**Source:** Asset Store (Malbers Animations)
**Category:** Other (Fishing Minigame)
**Verdict:** Approved
**Label:** --

**What it is:** Fishing system add-on for Animal Controller. Cast, reel, fish AI, catch mechanics. Requires AC as base.

**Project Relevance:**
- HOK: Explicitly listed as DON'T USE (HOK has custom fishing system)
- AQS: N/A -- no fishing
- 3D Action/Adventure with fishing minigame: HIGH -- drop-in fishing system for AC-based characters

**Note:** No re-evaluation performed this session. Original verdict stands. Included in Malbers ecosystem listing for completeness.

---

## ENTRY-031: Poly Art: Raccoon 4.0 (Malbers)

**Date:** 2026-03-14 (Session 58 -- Malbers Ecosystem Re-eval)
**Source:** Asset Store (Malbers Animations)
**Category:** Animation / Art
**Verdict:** Approved
**Label:** --
**Path:** `Assets/Malbers Animations/Animals Packs/01 Forest Pack/`

**What it is:** Low-poly raccoon character pack. Ships as part of the Forest Pack. Includes two implementations:

1. **Raccoon (Legacy/Standard):** Basic model + animations at `Raccoon/Raccoon Demo PolyArt/`. Standalone animations, no AC dependency.
2. **Raccoon AC (Animal Controller integration):** Full AC-wired character at `_Forest Pack (AC)/Raccoon AC/`. Includes 7 demo scenes: Forest, PlayGround, Mobile, AI Sample (2 variants), Point Click, Callbacks, AI Brain. Also includes `Rideable (Requires HAP) PA/` for mounting.

**Models:** Adult Raccoon (Poly Art style) + **Raccoon Cub** (smaller model, potential Joey placeholder for AQS).

**Animation Set:** Full quadruped set -- Idle, Locomotion (walk/trot/run), Jump, Fall, Swim, Climb, Attack, Death, Sleep, Blink, Semi-closed eyes. Controlled via Raccoon Eyes animator controller.

**Currently in Use:** Installed in Sandbox for AQS. Scorch (HOK placeholder) was the original stand-in, but the Raccoon is closer to quokka movement patterns. Raccoon Cub is a candidate for Joey visual placeholders.

**Project Relevance:**
- AQS: **HIGH** -- primary placeholder character. Raccoon AC provides complete state machine for 2.5D platformer. Raccoon Cub for Joey placeholders.
- HOK: N/A -- Scorch is HOK's character
- Any AC-based project needing quadruped: HIGH

**Asset Interactions:** Requires Common folder. AC integration via UnityPackage in `_Forest Pack (AC)/`. Rideable variant requires Horse Animset Pro (ENTRY-032).

---

## ENTRY-032: Horse Animset Pro 4.5.1 (Riding System)

**Date:** 2026-03-14 (Session 58 -- Malbers Ecosystem Re-eval)
**Source:** Asset Store (Malbers Animations)
**Category:** Animation / Character
**Verdict:** Approved
**Label:** --
**Path:** `Assets/Malbers Animations/Horse AnimSet Pro/`
**Previously:** Deferred (2026-02-07, never tested)

**What it is:** Animation framework + Riding System module for Animal Controller. v4.5.1 (Jan 17, 2026). **Everything in Animal Controller is included in HAP** -- it's a superset. 80+ horse animation clips, rider system with 132 animation clips.

**Key Components:**
- **Horse:** 3 visual styles (Realistic, Poly Art, MineCraft), multiple texture sets per style with LOD support. Saddle + armor options. Unity Cloth for reins/mane. Swimming, falling, jumping, attacking, death, gaits (walk/trot/canter/gallop/sprint).
- **Rider:** Cowboy character model with texture variants. 3rd-person and 1st-person. Combat (bows, pistols, melee). Compatible with Invector/Opsive controllers.
- **Undead Horse:** Add-on variant (see ENTRY-295) with effects and materials.
- **Wagon System:** Horse-drawn wagon mechanics.

**Demo Scenes (18):** Horse Only, Riding Only, Riding Combat (3 variants: Holsters, Inventory, Assassin Creed), TopDown, AI Sample, FPS, Ragdoll, Mobile (+ Pegasus), AI Pegasus Travel, AI Sample Carriage, Point Click, MineCraft, Wagon, Call Horse.

**Why Approved (previously Deferred):**
- Now installed and confirmed working in Unity 6
- AC included -- installing HAP gives you the full Animal Controller
- Horse is the install vehicle for AC on Asset Store (buy HAP, get AC)
- Riding system is bonus content even if you only need AC

**Project Relevance:**
- AQS: LOW direct use (no horses), but **HIGH indirect** -- this is how AC gets installed
- HOK: N/A
- 3D Action/Adventure with mounts: HIGH -- complete rideable animal system
- Any project needing AC: install HAP to get everything

**Asset Interactions:** Superset of AC (ENTRY-028). Raccoon Rideable (ENTRY-031) requires HAP for mounting. Undead Horse (ENTRY-295) requires HAP prefabs.

---

## ENTRY-036: Low Poly Animated Animals 4.1.1 (polyperfect)

**Date:** 2026-03-14 (Session 58 -- Malbers Ecosystem Re-eval)
**Source:** Asset Store (polyperfect)
**Category:** Animation / Art
**Verdict:** Approved
**Label:** Art
**Path:** `Assets/polyperfect/Low Poly Animated Animals/`
**Namespace:** `Polyperfect.Animals` (wraps `Polyperfect.Common`)

**What it is:** Massive low-poly animal collection. 162 prefabs (120 unique animals + color variants + legacy + demo versions), 74 animator controllers, 68 AI stat configurations, 17 demo scenes, 28 scripts. Completely separate ecosystem from Malbers.

**Animal Categories (68 species):**
- Large Mammals: Bear (4 variants), Lion, Tiger, Leopard, Cheetah, Gorilla (3), Elephant (2), Hippo, Rhino, Giraffe (2), Horse (3), Zebra, Deer (2), Reindeer, Camel (2), Yak, Buffalo, Wildebeest, Cow (6), Boar, Walrus, Seal, Tapir, Panda, Badger, Anteater, Aardvark
- Small Mammals: Rabbit (2), Squirrel, Rat, Capybara, Meerkat, Porcupine, Hedgehog, Guinea Pig, Fox, Beaver, Wolf
- Dogs: Chihuahua (2), Golden Retriever, Great Dane (2)
- Cats: Cat (3 colors)
- Birds: Eagle, Hawk, Owl, Vulture, Flamingo, Seagull, Penguin, Ostrich, Parrot, Dove, Hen, Rooster, Chick, Goose, Toucan
- Reptiles: Snake (2), Crocodile, Lizard, Tortoise
- Insects: Spider (3), Bee (2), Cockroach, Ant
- Aquatic: Shark (2), Orca, Dolphin, Whale, Jellyfish (3), Octopus, Squid, Seahorse, Starfish, Crab, Stingray, Fish

**AI System:** `Common_WanderScript` (973 lines). 6-state machine: Idle, Wander, Chase, Evade, Attack, Dead. Predator/prey detection via range-based awareness/scent. `AIStats` ScriptableObject per species: dominance (food chain rank), stamina, power, toughness, aggression, attackSpeed, territorial, stealthy.

**Key API:**
- `Common_WanderScript`: `TakeDamage(float)`, `Die()`, `SetPeaceTime(bool)`, `CurrentState`, `AllAnimals` (static list)
- Events: `deathEvent`, `attackingEvent`, `idleEvent`, `movementEvent`
- Movement via CharacterController (or NavMeshAgent if present), NOT root motion

**Animation:** All states controlled via Animator bools (isSleeping, isWalking, isRunning, isAttacking, isDead). Per-animal Animator Controllers (74 total). Abrupt state transitions, no blending.

**Compatibility with Malbers AC:**
- **NOT designed to work together on same GameObject.** Different movement systems (CharacterController vs Rigidbody), different animator parameter patterns (bools vs AC's hash system), different AI architecture.
- **Coexistence strategy:** Polyperfect for ambient AI herd/background animals. Malbers AC for player character + key gameplay creatures. Separate layers, no cross-system interaction needed.

**Concerns:**
- No asmdef, no namespace isolation (wraps Common namespace but scripts compile to Assembly-CSharp area)
- AI is simplistic -- flat state machine, no line of sight, no pack behavior, no waypoints
- Animation transitions are abrupt (bool on/off), no blend trees
- Legacy prefabs present -- indicates some deprecation
- Low-poly style: great for background, less suitable for close-up hero characters

**Project Relevance:**
- AQS: **HIGH** -- placeholder enemy models (snake, hawk, dog/cat as predators). GDD Sprint 4 lists "Low Poly Animated Animals (ENTRY-036)" for placeholder enemies. Predator/prey AI is bonus for environmental flavor.
- HOK: LOW -- wrong art style for fishing sim
- 3D Action/Adventure: HIGH -- instant wildlife population
- Any 3D project needing ambient animals: HIGH

**MCP Potential:** Low. Simple API (3 public methods), CharacterController-based movement. Standard component pipeline sufficient -- no custom MCP tools needed. Can spawn/configure via `component-modify` on AIStats fields.

**Asset Interactions:** Independent from Malbers ecosystem. Can coexist in same project without conflicts (different folders, different namespaces). Could pair with Behavior Designer Pro (ENTRY-229) or SensorToolkit2 (ENTRY-231) for more sophisticated enemy AI by replacing the WanderScript.

---

## ENTRY-294: Drake the Dragonkin 4.0 (Malbers)

**Date:** 2026-03-14 (Session 58 -- Malbers Ecosystem Re-eval)
**Source:** Asset Store (Malbers Animations)
**Category:** Animation / Art
**Verdict:** Approved
**Label:** --
**Path:** `Assets/Malbers Animations/Dragons/7 - Drake the Dragonkin/`

**What it is:** Dragon character pack for Animal Controller. Includes Drake AC integration, animations, materials/textures, and 3D models. Poly Art style matching the Raccoon pack aesthetic.

**Structure:** `1 - Drake AC/` (AC-integrated prefab), `Animations/`, `Materials & Textures/`, `Models/`.

**Project Relevance:**
- AQS: LOW -- no dragons in quokka metroidvania (unless future boss/enemy)
- 3D Action/Adventure: HIGH -- dragon companion, mount, or enemy
- Fantasy RPG concepts: HIGH

**Asset Interactions:** Requires Common folder + AC. AC states (Fly, Glide, Attack) directly applicable to dragon behavior.

---

## ENTRY-295: Undead Horse & Knight 4.0 (Malbers)

**Date:** 2026-03-14 (Session 58 -- Malbers Ecosystem Re-eval)
**Source:** Asset Store (Malbers Animations)
**Category:** Animation / Art
**Verdict:** Approved
**Label:** --
**Path:** `Assets/Malbers Animations/Horse AnimSet Pro/Undead Horse/`

**What it is:** Undead variant of the HAP horse. Includes demo scene, effects, materials/textures, models, and prefabs. Requires Horse Animset Pro (ENTRY-032) for base prefab/animations.

**Structure:** Demo Scene, Effects, Materials & Textures, Models, Prefabs (Requires Horse Animset).

**Project Relevance:**
- HOK: MEDIUM -- Kharon's ferry could use undead horse aesthetic for supernatural mount
- 3D Action/Adventure (dark fantasy): HIGH
- AQS: NONE

**Asset Interactions:** Depends on HAP (ENTRY-032). Uses same riding system and AC states as standard horse.

---

## ENTRY-296: Low Poly Cowboy 1.1 (Malbers)

**Date:** 2026-03-14 (Session 58 -- Malbers Ecosystem Re-eval)
**Source:** Asset Store (Malbers Animations)
**Category:** Art (Character)
**Verdict:** Approved
**Label:** --
**Path:** `Assets/Malbers Animations/Cowboy/`

**What it is:** Low-poly cowboy humanoid character. Materials, models, prefabs, textures. Designed as the rider character for HAP demos. Multiple texture variants.

**Structure:** `Materials/`, `Model/`, `Prefabs/`, `Textures/`.

**Note:** This is primarily an art asset -- the character model. The rider animations and controller logic come from HAP (ENTRY-032). The Cowboy model is what you see in HAP's riding demos.

**Project Relevance:**
- Any project using HAP riding: HIGH -- ready rider character
- AQS/HOK/FearSteez: LOW -- not needed
- Western-themed concepts: HIGH

**Asset Interactions:** Pairs with HAP (ENTRY-032) rider system. Humanoid rigged, retargetable to other animation sets.

---

## ENTRY-297: Malbers Quest Forge 1.0

**Date:** 2026-03-14 (Session 58 -- Malbers Ecosystem Re-eval)
**Source:** Asset Store (Malbers Animations)
**Category:** Scripting (Quest / Dialogue / Map)
**Verdict:** Approved
**Label:** --
**Path:** `Assets/Malbers Animations/Integrations/Malbers Quest Forge/`
**Namespace:** `MalbersAnimations.QuestForge`

**What it is:** Full quest, dialogue, minimap/world map, compass, and save/load system built for the Malbers AC ecosystem. 146 C# scripts (65,168 LOC), ~40 prefabs, graph-based dialogue editor. Production-quality, feature-complete system for RPGs and narrative-driven games.

**Five Subsystems:**

1. **Quest System:** `Quest` (SO template), `QuestInstance` (runtime), `QuestManager` (singleton lifecycle). Objective types: Kill, Collect, Visit Location, Talk to NPC, Interact, Reach Waypoint. Quest types: Main, Side, Daily, Repeatable. Prerequisite chains (AND/OR logic). Extensible reward system (`IQuestReward`). Distance-to-objective tracking with color-coded ranges.

2. **Dialogue System:** `DialogueContainerSO` (graph SO), `DialogueManager` (runtime executor), `DialogueUI` (renderer). Graph-based editor with node types: Simple, Choice (branching), Events, Quest Actions (start/complete/fail), Wait, Conditions, Cinemachine, Timeline, Audio, Modal Windows. Speaker definitions with voice/animation settings.

3. **Minimap & World Map:** `MinimapUI`, `POIManager`, `WorldMapUI`. Points of interest with icons, player indicator, camera cone overlay. Fog of war, fast travel, quest marker integration.

4. **Compass Bar:** `CompassBarUI` -- direction indicator showing tracked quest objectives.

5. **Save/Load:** `QuestSaveSystem` + `DialogueSaveSystem`. JSON serialization via Newtonsoft.Json. Custom `Vector3Converter`. Persists quest progress + dialogue state.

**Event Architecture:** `QuestEventBus` (Observer pattern) with `QuestEventType` enum (EnemyKilled, ItemCollected, LocationReached, NPCTalkedTo, etc.). `QuestEventReporter` broadcasts game events to quest system. Decoupled from AC -- communicates via events, not direct references.

**Dependencies:** Cinemachine 3, Newtonsoft.Json, Timeline, Splines, URP, and Malbers Animal Controller.

**Concerns:**
- First release (v1.0) -- may have rough edges
- 65K LOC is a large code surface to maintain
- Competes with established assets: Dialogue System for Unity (ENTRY-214), Adventure Creator (ENTRY-251), Ink (ENTRY-281) for narrative. But those are standalone -- Quest Forge is AC-native.
- Minimap/world map competes with dedicated map assets (AA Map and Minimap, still unevaluated for AQS)

**Project Relevance:**
- AQS: MEDIUM -- metroidvania needs quest tracking, map reveal, NPC dialogue. If AC is adopted, Quest Forge integrates natively. But AQS's narrative needs are lighter than a full RPG.
- VNPC: LOW -- VNPC already uses Dialogue System (ENTRY-214) + Ink (ENTRY-281) + Adventure Creator (ENTRY-251). Quest Forge would be redundant.
- 3D Action/Adventure concepts using AC: **HIGH** -- complete RPG quest/dialogue/map stack with zero adapter code.
- HOK: N/A -- doesn't use AC.

**MCP Potential:** Medium-High. `QuestManager` singleton pattern, ScriptableObject quest definitions, event bus architecture -- all scriptable via Roslyn. Dialogue graphs are SO-based and could potentially be built programmatically. Quest creation/tracking/completion all have public API. Worth formal MCP eval if adopted.

**Asset Interactions:** Native AC integration. Competes with but doesn't conflict with ENTRY-214 (Dialogue System), ENTRY-251 (Adventure Creator), ENTRY-281 (Ink). Uses Newtonsoft.Json (already a Unity package dependency). Timeline and Cinemachine integration for cinematic dialogue sequences.

---

## ENTRY-298: Flare Engine 2D Tools 1.8.5

**Date:** 2026-03-16 (Sandbox2D Session 0)
**Source:** Asset Store
**Category:** Scripting (2D Framework)
**Verdict:** Approved
**Label:** Recommended

**What it is:** Comprehensive 2D game framework covering platformer, RPG, AI, dialogue, inventory, quest, saving, weapons, and camera systems. 30+ player abilities, behavior tree AI, pathfinding, Chronos time-rewind system, dialogue/inventory/quest/saving systems.

**Concerns:**
- No custom asmdef -- sits in Assembly-CSharp
- Unity 6 manual setup required
- Successor asset reportedly in development by publisher

**Project Relevance:**
- AQS: HIGH -- 2.5D metroidvania platformer; 30+ abilities, weapons, AI brain all directly applicable
- Bob Christ / Story Weaver: HIGH -- RPG/narrative systems
- Shift Happens: MEDIUM -- platformer mechanics applicable but top-down physics focus doesn't fully match
- FearSteez: MEDIUM -- combat/ability systems could inform, but FearSteez uses Malbers AC

**TVG Candidates:**
- Chronos rewind system -- time manipulation mechanic
- Reaction Profile game-feel system
- WorldEvents bus pattern
- AbilityManager priority system

---

## ENTRY-299: Character Editor 4D 7.6

**Date:** 2026-03-16 (Sandbox2D Session 0)
**Source:** Asset Store
**Category:** Art (Character)
**Verdict:** Conditional
**Label:** --

**What it is:** 4-directional 2D character editor with sprite art packs. Runtime character customization for 2D top-down or side-view games.

**Critical Blocker:** BiRP ONLY -- URP is NOT supported. All TecVooDoo projects use URP, making the C# runtime system unusable.

**Concerns:**
- Publisher retroactively removes content from purchased assets
- Multi-year unresolved bugs reported in reviews
- Newtonsoft.Json DLL conflict with Unity's built-in package

**Usability:** Art assets (sprites) can be extracted and used independently. Runtime character editor system is dead on arrival for URP projects.

**Project Relevance:** LOW across all projects due to URP blocker. Art extraction only.

---

## ENTRY-300: 2D Art Maker Casual Characters 1.0.14

**Date:** 2026-03-16 (Sandbox2D Session 0)
**Source:** Asset Store
**Category:** Art (Character) / Scripting
**Verdict:** Approved
**Label:** Recommended

**What it is:** Spine-based runtime character customization system with 16 part slots. Supports dual Spine rendering (SkeletonAnimation for world, SkeletonGraphic for UI). Runtime atlas optimization, color tinting by body zone, prefab export with thumbnail generation, random character generation.

**Concerns:**
- Tight demo singleton coupling (not production-ready out of box)
- Per-frame color application (performance concern for many characters)
- Spine 4.2 dependency required

**Project Relevance:**
- Bob Christ / Story Weaver: HIGH -- runtime character customization for narrative games
- AQS: MEDIUM -- Joey visual variants could use part-slot system
- FearSteez: MEDIUM -- character variety for fighters

**TVG Candidate:** SpineCharacterCustomizer -- extract PartsManager pattern with injectable config interface.

---

## ENTRY-301: TopDown Engine 4.5 (More Mountains)

**Date:** 2026-03-16 (Sandbox2D Session 0)
**Source:** Asset Store (More Mountains)
**Category:** Scripting (2D/3D Framework)
**Verdict:** Approved
**Label:** Recommended

**What it is:** More Mountains' top-down action framework supporting both 2D and 3D. CharacterAbility composition system, AI Brain/Action/Decision system (30+ Actions, 20+ Decisions), full weapons suite, inventory integration, procedural tilemap generation. Bundles MMFeedbacks (Feel ~$65 value included).

**Architecture Quality:**
- 9 proper asmdefs (excellent modularity)
- Explicit typing: only 14 `var` usages across 225 runtime scripts
- Negligible LINQ in runtime code
- 12 demo scenes

**Project Relevance:**
- Bob Christ / Story Weaver / FearSteez: HIGH -- combat, AI, weapons, inventory all directly applicable
- AQS: MEDIUM -- overworld/hub segments could use top-down mechanics; CharacterAbility pattern is excellent study reference
- Shift Happens: MEDIUM -- physics focus differs but AI system applicable

**MCP Potential:** HIGH -- automated playtesting via AI Brain system. Character abilities are component-based and inspectable.

**Note:** Same publisher as Corgi Engine (ENTRY-240) and Feel (ENTRY-242). Install BEFORE 3D art assets -- triggers FBX catalog scan on first import (same as Corgi Engine).

---

## ENTRY-168: RayFire 2

| Field | Value |
|-------|-------|
| **Asset** | RayFire 2 |
| **Publisher** | RayFire Studios |
| **Source** | Asset Store (https://assetstore.unity.com/packages/slug/342492) |
| **Version** | 2.05 (Feb 16, 2026) |
| **Price** | $95.00 |
| **Category** | Editor Extensions / Game Toolkits |
| **Rating** | 5/5 (83 ratings) |
| **Size** | ~33 MB |
| **Unity Version** | 2022.3.62+ |
| **BIRP/URP/HDRP** | Yes / Yes / Yes |
| **Purchased** | Feb 24, 2026 |
| **Session** | 39 |
| **Verdict** | Approved |
| **Label** | Recommended |
| **CSV ID** | 2355 |

**What It Is:** Runtime destruction and demolition system. Pre-fragment meshes at design time or runtime, then trigger breakage via collisions, explosions, projectiles, blades, structural stress, or damage accumulation. Fragments become independent physics objects with material-based properties, fading, pooling, and particle effects.

**Folder:** `Assets/RayFire/`

**Scale:** 98 scripts, ~44,816 LOC. Native C++ fragmentation kernel via platform-specific DLLs (Win/Mac/Linux/Android/iOS).

**Architecture:**
- **Namespace:** `RayFire` (all code isolated)
- **Asmdef:** `RayFireAssembly.asmdef` (1 precompiled ref: `RFLib_DotNet_2018.dll`)
- **Singleton Manager:** `RayfireMan` -- global physics settings, fragment pooling, time-quota demolition processing (0.03s default)
- **Component-based:** 22 MonoBehaviour components, each a distinct feature
- **Custom events:** Local + global delegates for demolition, activation, restriction events

**Key Components (22):**
- `RayfireRigid` -- primary demolition controller
- `RayfireShatter` -- pre-fragmentation authoring (10+ algorithms: Voronoi, Splinters, Slabs, Radial, Hex, Custom, Slices, Bricks, Voxels, Decompose)
- `RayfireMan` -- singleton manager (pooling, physics, quotas)
- `RayfireBomb` -- explosive detonation with falloff
- `RayfireGun` -- projectile-based destruction
- `RayfireBlade` -- planar cut/slice
- `RayfireVortex` / `RayfireWind` -- force fields
- `RayfireConnectivity` -- structural integrity analysis
- `RayfireRagdoll` -- character ragdoll integration
- `RayfireDebris` / `RayfireDust` -- particle effects
- `RayfireSound` -- impact + demolition SFX
- `RayfireRecorder` / `RayfireSnapshot` -- record/playback, state save/restore

**Material Presets:** 10 built-in (HeavyMetal, Rock, Concrete, Glass, Wood, etc.) with density, drag, friction, bounciness.

**Performance Features:** Fragment pooling, time-sliced demolition, mesh precaching, convex collider optimization, kinetic energy culling, mesh combining.

**Documentation:** 18 component docs (RTF/DOCX), 17 tutorial scenes, 11 demo prefabs (Barrel, Door, Fence, Rock, Vase, Column, etc.), HowTo guides, YouTube tutorials, FAQ, Discord support.

**Editor Tools:** 20+ custom inspectors with foldable property groups, shatter preview in Scene view, connectivity gizmos, UV region painter, mesh export pipeline.

**Concerns:**
- **$95 premium price** -- justified by native C++ kernel and comprehensive feature set
- **Native DLLs** -- platform-specific binaries add deployment complexity (but all major platforms covered)
- **44K+ LOC** -- large codebase, but well-isolated in its own assembly
- **Singleton pattern** -- RayfireMan is global state, but manageable since it's an infrastructure tool

**Overlap Analysis:**
- **No conflicts** with any evaluated assets -- destruction is a unique domain
- **Complements physics systems** -- works with Unity's built-in Rigidbody/collision
- **Complements VFX** -- debris/dust particles integrate with any particle system

**Verdict Rationale:** Approved with **Default 3D** label. Production-grade destruction system with native performance, comprehensive component set, and excellent documentation. The isolated assembly and zero external dependencies make it safe to include in any 3D project. Multi-platform support (Win/Mac/Linux/Android/iOS) covers all TecVooDoo deployment targets.

**Project Relevance:**
- FearSteez (beat 'em up) -- HIGH. Destructible environment props (crates, barrels, walls), enemy ragdoll on death
- HOK (fishing sim) -- LOW. Limited destruction needs
- Cursed Fantasy (action adventure) -- HIGH. Environmental destruction, dungeon demolition
- Alpha Foxtrot Uniform (tactical shooter) -- VERY HIGH. Cover destruction, building collapse
- HumiliNation (physics sim) -- HIGH. Core demolition gameplay
- A Quokka Story (metroidvania) -- MEDIUM. Breakable walls, secret paths

**MCP Tools (Session 53-55):** 7 custom tools built -- `rayfire-add-rigid`, `rayfire-configure-rigid`, `rayfire-add-shatter`, `rayfire-fragment`, `rayfire-list-rigid`, `rayfire-demolish`, `rayfire-apply-damage`. **5 setup tools work ✅; 2 runtime tools crash Unity ❌.** `DemolishForced()` and `ApplyDamage()` conflict with MCP's `MainThread.Run()` context (physics object spawning/destruction during execution). Setup and fragmentation workflows fully scriptable via MCP. Runtime demolition must remain manual or triggered via game code.

---

## ENTRY-169: Inventory Framework 2 FREE (UI Toolkit)

| Field | Value |
|-------|-------|
| **Asset** | Inventory Framework 2 FREE (UI Toolkit) |
| **Publisher** | Game Dev Simplified |
| **Source** | Asset Store (https://assetstore.unity.com/packages/slug/283656) |
| **Version** | 2.0 (Feb 17, 2026) |
| **Price** | $0 (FREE) / PRO: $19.90 |
| **Category** | Scripting / GUI |
| **Rating** | 4/5 (14 ratings) -- PRO: 5/5 (3 ratings) |
| **Size** | ~1.4 MB |
| **Unity Version** | 2022.3.58+ |
| **BIRP/URP/HDRP** | Yes / Yes / Yes |
| **Purchased** | Sep 27, 2025 (FREE) / Feb 25, 2026 (PRO) |
| **Session** | 39 |
| **Verdict** | Approved |
| **Label** | Recommended |
| **CSV IDs** | 2351 (FREE), 2381 (PRO) |

**What It Is:** Complete inventory management framework built 100% on UI Toolkit. Three bag types (List, Set, Grid), drag-and-drop, item stacking/splitting, slot tag filtering, event-driven architecture. Includes 4 full game demos and 14 progressive tutorial examples.

**Folder:** `Assets/GDS/`

**Scale:** 179 scripts, ~7,573 LOC. Lean and focused.

**Architecture:**
- **Namespaces:** `GDS.Core`, `GDS.Core.Events` (clean 2-namespace design)
- **Asmdefs:** 7 total (Core, Core.Editor, Common, 4 demo assemblies)
- **Event-driven:** Custom `EventBus` with typed events (PickItem, PlaceItem, BuyItem, SellItem, etc.)
- **ScriptableObject stores:** Abstract `Store` SO owns EventBus + Observable ghost item

**Core System (The Trinity):**
- `Bag.cs` (68 LOC) -- abstract base with virtual Add/Remove/CanAdd/CanRemove. Implements `IEnumerable<Item>`
- `Item.cs` (84 LOC) -- unique ID + link to `ItemBase` SO (icon, tags, max stack). Extensions: Clone, CanStack, TransferAll, SplitHalf
- `Slot.cs` (27 LOC) -- container with tag-based filtering

**Three Bag Types:**
- `ListBag` (128 LOC) -- ordered list, auto-stacking. Standard RPG inventory
- `SetBag` (83 LOC) -- one item per slot. Equipment/loadout screens
- `GridBag` (240 LOC) -- 2D grid with item shapes, Tetris-style placement. Survival game inventory (Diablo/RE4)

**UI Views (12 scripts, all VisualElement-based):**
- `ListBagView`, `SetBagView`, `GridBagView` -- bag renderers
- `ItemView`, `SlotView`, `GridItemView` -- item/slot renderers
- `WindowView`, `TooltipView` -- panels and hover info
- Builder pattern via `Dom.cs` utility (313 LOC) for fluent VisualElement construction

**Manipulators (4 reusable interaction handlers):**
- `DragDropManipulator` (103 LOC) -- full drag-drop with modifier keys (Ctrl=move bag, Shift=split)
- `HighlightSlotManipulator` (87 LOC) -- visual drop zone feedback
- `TooltipManipulator` (130 LOC) -- hover tooltips with 500ms delay
- `RotateManipulator` (34 LOC) -- right-click rotation for grid items

**Demo Scenes (4 complete games):**
- **Arpg** -- RPG with equipment, shops, character sheet, 50+ item definitions
- **Backpack** -- Tetris-style grid inventory with rotation and shop
- **Basic** -- Simple list inventory with crafting bench
- **Dayz** -- Survival game inventory with hands/ground interactions

**Examples:** 14 progressive tutorials (Beginner through Advanced + Grid)

**Editor Tools:** 16 scripts -- BagPropertyDrawer, ItemBaseEditor, ShapeEditor (visual grid shape definition), custom attributes (@Required, @ShowField, @InlineEditor), auto-reset SOs on play.

**Documentation:** README, inline comments, progressive examples serve as documentation.

**Concerns:**
- **FREE version used** -- PRO also owned ($19.90). May need to evaluate PRO differences
- **Small rating count** (14 FREE, 3 PRO) -- newer publisher, but code quality is solid
- **UXML loaded from Resources** -- tied to hardcoded paths
- **Demos can't be separated** from install (not a separate package)
- **No save/load built-in** -- BagSO provides serialization hooks but persistence is DIY

**Overlap Analysis:**
- **Supersedes Malbers Inventory System (001)** -- modern UI Toolkit vs uGUI, better architecture, event-driven
- **No conflicts** with other evaluated assets
- **Complements UI Toolkit** ecosystem -- fits naturally with Default UI label assets
- **Grid system complements** survival/ARPG game templates

**Verdict Rationale:** Approved with **Default UI** label. Clean event-driven architecture, 100% UI Toolkit, three distinct bag types covering all major inventory patterns (list, equipment, grid). The 4 demo scenes are complete reference implementations. Code quality is high -- explicit types, proper namespaces, 7 asmdefs, lean core (~2K LOC). Free version appears feature-complete. Excellent for any project needing inventory management.

**Project Relevance:**
- FearSteez (beat 'em up) -- HIGH. Item pickups, weapon inventory, power-ups
- HOK (fishing sim) -- HIGH. Fish inventory, tackle/bait management, collectibles
- Aunt T's (card battler) -- MEDIUM. Card/item collection
- A Quokka Story (metroidvania) -- HIGH. Equipment + collectible inventory
- Cursed Fantasy (action adventure) -- HIGH. RPG-style equipment + items
- DLYH (word game) -- LOW. Minimal inventory needs
- Shrunken Head Toss (casual) -- LOW. No inventory

---

## ENTRY-170: Ghost Effect Shader (OccaSoftware)

| Field | Value |
|-------|-------|
| **Asset** | Ghost Effect Shader with Shader Graph |
| **Publisher** | OccaSoftware |
| **Source** | Asset Store (https://assetstore.unity.com/packages/slug/215366) |
| **Price** | $5.00 |
| **Category** | Shaders |
| **Rating** | 0/5 (2 ratings) |
| **Session** | 40 |
| **Verdict** | Approved |
| **Label** | Recommended |
| **CSV ID** | ForeignId 215366 |

**What It Is:** Two Shader Graph materials for a ghost/transparency effect -- Lit and Unlit variants. Uses triplanar mapping subgraph for seamless texture projection on any mesh without UV seams.

**Folder:** `Assets/OccaSoftware/Ghost Shader/`

**Scale:** 2 shader graphs, 2 subgraphs (GhostSubGraph, TriplanarMapping), 2 materials, 1 demo mesh. One dummy .cs file for shader reference only (no runtime code).

**Key Features:**
- Ghost Lit: receives lighting/shadows while maintaining ghost transparency
- Ghost Unlit: flat emission-style ghost (no lighting influence)
- TriplanarMapping subgraph shared with Triplanar package -- procedural UV projection from world-space normals
- Demo scene with adjustable material parameters

**Concerns:**
- Very low rating count (2) -- likely just underrated due to simplicity
- URP only (Shader Graph)
- No scripts -- purely a material drop-in

**Overlap Analysis:**
- **Complements All In 1 3D Shader (098)** -- All In 1 has its own ghost/transparency effects but Ghost Shader provides a dedicated Shader Graph version editable in the Shader Graph editor
- **Shares subgraph** with Triplanar (173) -- both use TriplanarMapping.shadersubgraph

**Verdict Rationale:** Approved with **Default 3D** label. At $5, it is a clean one-purpose shader that covers ghost/spirit/hologram use cases for any 3D project. The Lit variant is particularly useful -- most ghost shaders are unlit, but lit ghosts look better in dynamic lighting environments.

**Project Relevance:** HOK (Charon as ghostly ferryman -- MEDIUM), Cursed Fantasy (undead/ghost enemies -- HIGH), A Quokka Story (ghost abilities -- MEDIUM).

---

## ENTRY-171: Responsive Smokes (OccaSoftware)

| Field | Value |
|-------|-------|
| **Asset** | Responsive Smokes - Interactive Volumetric Smokes for Unity URP |
| **Publisher** | OccaSoftware |
| **Source** | Asset Store (https://assetstore.unity.com/packages/slug/252410) |
| **Price** | $12.00 |
| **Category** | Shaders |
| **Rating** | 5/5 (3 ratings) |
| **Session** | 40 |
| **Verdict** | Approved |
| **Label** | Recommended |
| **CSV ID** | ForeignId 252410 |

**What It Is:** VFX system for interactive, physics-responsive volumetric smoke, explosions, and projectile trails. Smoke reacts to nearby projectiles, explosions, and player movement rather than looping passively.

**Folder:** `Assets/OccaSoftware/ResponsiveSmokes/`

**Scale:** 11 scripts, 4 asmdefs (Runtime, Editor, Shaders, Demo). Full interactive demo with character controller, gun, throwables, and weapon system.

**Key Components:**
- `InteractiveSmoke.cs` -- smoke VFX controller, responds to nearby `InteractiveExplosion` and `InteractiveProjectile` events
- `InteractiveExplosion.cs` -- area-of-effect explosion that drives smoke displacement
- `InteractiveProjectile.cs` -- projectile that trails and displaces smoke on contact
- `ResponsiveSmokeMaterialEditorGUI.cs` -- custom material property editor
- Demo system: full character controller + gun + throwable (5 scripts, own asmdef)

**Architecture Notes:**
- Runtime assembly isolated: `OccaSoftware.ResponsiveSmokes.Runtime.asmdef`
- Shaders in their own assembly (separate compile unit)
- Demo uses `IVS_` prefix (Interactive Visual System) -- fully self-contained, safe to delete

**Concerns:**
- URP only
- Demo scripts use their own asmdef -- no conflict with project code
- Only 3 ratings but all 5-star

**Overlap Analysis:**
- **Complements RayFire 2 (168)** -- RayFire drives explosions, Responsive Smokes provides the visual smoke response. The `InteractiveExplosion` component bridges them naturally.
- **Complements VFX Library (202)** if installed -- ambient FX + reactive smokes = full environmental VFX pipeline

**Verdict Rationale:** Approved with **Default 3D** label. The reactive/physics-driven approach to smoke is a meaningful upgrade over passive looping particle effects. At $12 with a complete demo system, it is solid value. The isolated assembly design is clean.

**Project Relevance:** FearSteez (combat smoke effects -- HIGH), Cursed Fantasy (explosions, magical smoke -- HIGH), Alpha Foxtrot Uniform (gunfire smoke -- VERY HIGH), HOK (campfire/mist effects -- LOW).

---

## ENTRY-172: Opaque Water Shader (OccaSoftware)

| Field | Value |
|-------|-------|
| **Asset** | Opaque Water Shader Graph for Unity |
| **Publisher** | OccaSoftware |
| **Source** | Asset Store (https://assetstore.unity.com/packages/slug/250126) |
| **Price** | $0 (FREE) |
| **Category** | Shaders |
| **Rating** | 0/5 (0 ratings) |
| **Session** | 40 |
| **Verdict** | Conditional |
| **Label** | -- |
| **CSV ID** | ForeignId 250126 |

**What It Is:** Opaque (non-transparent) stylized water shader built in Shader Graph. Designed for cases where transparency/depth-buffer tricks are unavailable or undesirable (e.g., VR, certain mobile targets, performance-constrained projects).

**Folder:** `Assets/OccaSoftware/OpaqueWaterShader/`

**Scale:** 1 shader graph, subgraphs, demo materials, demo geometry. No scripts.

**Concerns:**
- Zero ratings -- very new or very obscure
- Opaque water is a niche use case. Most modern 3D projects prefer transparent water (Stylized Water 3)
- No foam, no refraction, no depth effects by design -- these require transparency

**Overlap Analysis:**
- **Superseded by Stylized Water 3 (039) in most cases** -- SW3 has full transparency, foam, caustics, dynamic effects, and underwater rendering. Opaque Water is only useful when SW3's transparency approach is unavailable.
- **Complementary for specific targets** -- mobile projects where transparent water is too expensive, or stylized games where flat opaque water fits the art direction (e.g., cartoon games)

**Verdict Rationale:** Conditional with **Default 3D** label. Keep as a fallback water option for performance-constrained platforms or stylized art directions. For HOK and most TecVooDoo projects, Stylized Water 3 is superior and should be the default choice. This asset is free, so the cost of keeping it is zero.

**Project Relevance:** HOK -- LOW (SW3 is far superior for fishing sim). Mobile games -- MEDIUM (if transparent water is too expensive).

---

## ENTRY-173: Triplanar Shader (OccaSoftware)

| Field | Value |
|-------|-------|
| **Asset** | Triplanar Shader - Advanced Texture Mapping for Unity URP |
| **Publisher** | OccaSoftware |
| **Source** | Asset Store (https://assetstore.unity.com/packages/slug/245588) |
| **Price** | $25.00 |
| **Category** | Shaders |
| **Rating** | 0/5 (2 ratings) |
| **Session** | 40 |
| **Verdict** | Approved |
| **Label** | Recommended |
| **CSV ID** | ForeignId 245588 |

**What It Is:** Triplanar texture mapping system for Shader Graph (URP). Projects textures from world-space XYZ axes to eliminate UV seams on complex geometry (terrain, rocks, organic meshes). Includes custom HLSL function node library.

**Folder:** `Assets/OccaSoftware/Triplanar/`

**Scale:** 1 shader graph, custom HLSL (`TriplanarCFN.hlsl`), multiple subgraphs, demo materials. No runtime scripts.

**Key Features:**
- World-space triplanar projection -- no UV unwrap needed
- Custom Function Node library (HLSL) reusable in any Shader Graph
- Subgraphs for blend modes, normal blending, and projection axis control
- Works with any PBR textures (Albedo, Normal, Metallic, AO, Emission)

**Concerns:**
- $25 is significant for a single-purpose shader technique
- Triplanar mapping is built into Unity's Shader Graph natively (the `Triplanar` node exists) -- this package provides a more complete, polished implementation with custom HLSL helpers
- Low rating count (2) -- not widely reviewed

**Overlap Analysis:**
- **Complements 150 Realistic Textures (174)** -- triplanar projection is the ideal way to apply photogrammetric/PBR textures on terrain and organic meshes without UV seams
- **Complements Texture Channel Packer (178)** -- packed textures work directly with triplanar projection
- **Ghost Shader subgraph** shares the same TriplanarMapping subgraph -- indicates OccaSoftware designed their shader ecosystem to reuse these building blocks

**Verdict Rationale:** Approved with **Default 3D** label. The HLSL custom function node library is the differentiator -- it gives Shader Graph authors reusable, optimized triplanar functions beyond what Unity's built-in `Triplanar` node provides. The ecosystem integration (shared subgraphs with Ghost Shader) adds value.

**Project Relevance:** HOK (rock/terrain texturing -- HIGH), Cursed Fantasy (dungeon stone/organic -- HIGH), all 3D projects with non-UV-unwrapped geometry.

---

## ENTRY-174: 150 Realistic Textures (OccaSoftware)

| Field | Value |
|-------|-------|
| **Asset** | 150 Realistic Textures |
| **Publisher** | OccaSoftware |
| **Source** | Asset Store (https://assetstore.unity.com/packages/slug/248317) |
| **Price** | $25.00 |
| **Category** | Textures Materials |
| **Rating** | 0/5 (0 ratings) |
| **Session** | 40 |
| **Verdict** | Approved |
| **Label** | -- |
| **CSV ID** | ForeignId 248317 |

**What It Is:** 150 PBR material sets covering common surface types: asphalt, bark, brick, concrete, dirt, metal, wood, stone, cloth, rubber, tile. Each material includes Albedo, Normal, Metallic/Roughness, AO maps. 150 preview cube prefabs included.

**Folder:** `Assets/OccaSoftware/RealisticTextures/`

**Scale:** 150 materials, 300 texture directories (~600+ individual map files), 150 prefabs, 1 demo scene. No scripts.

**Coverage (sample):** Asphalt (10+), Bark (7), Brick (18+), Concrete (20+), Dirt/Soil (15+), Metal (10+), Wood (12+), Stone (granite, marble, pebbles), Cloth, Rubber, Tile.

**Concerns:**
- Zero ratings -- appears new or low-visibility
- No LOD/atlas variants -- each material is full-resolution individual maps
- File count is very high (~600+ textures) -- adds to project size
- No HDRI skies, emissive surfaces, or special-purpose materials in the set

**Overlap Analysis:**
- **Complements Triplanar Shader (173)** -- ideal match. Triplanar projection + these PBR textures = seamless surface coverage on any complex mesh
- **Complements Amplify Shader Editor (158)** -- these textures can be used as inputs in custom shaders
- **Partially overlaps** with the PBR texture inputs in Stylized Water 3 (foam/normal textures) but not conflicting

**Verdict Rationale:** Approved with **Default 3D** label. A comprehensive PBR texture library at $25 is solid value for any 3D project needing realistic surface materials. The 150-material breadth covers virtually all common environment surfaces. The include of preview prefabs makes material browsing efficient.

**Project Relevance:** HOK (riverbank, dock, stone, wood surfaces -- HIGH), Cursed Fantasy (dungeon walls, floors -- HIGH), Alpha Foxtrot Uniform (military environment surfaces -- HIGH), all 3D environment-building projects.

---

## ENTRY-175: Low Poly Fantasy Village (OccaSoftware)

| Field | Value |
|-------|-------|
| **Asset** | Low Poly Fantasy Village Environment |
| **Publisher** | OccaSoftware |
| **Source** | Asset Store (https://assetstore.unity.com/packages/slug/286054) |
| **Price** | $0 (FREE) |
| **Category** | 3D Models / Environments / Fantasy |
| **Rating** | 4/5 (3 ratings) |
| **Session** | 40 |
| **Verdict** | Approved |
| **Label** | -- |
| **CSV ID** | ForeignId 286054 |

**What It Is:** Low-poly fantasy village environment art pack. 96 FBX models and matching prefabs covering buildings, props, foliage, and landscape elements. Two demo scenes (showcase + sample scene).

**Folder:** `Assets/OccaSoftware/Low Poly Fantasy Village/`

**Scale:** 96 FBX models, 96 prefabs, demo scenes, materials, textures. No scripts.

**What Is Included (general categories):** Cottage/inn/shop buildings, fences, stone walls, trees, bushes, barrels, crates, torches, carts, wells, bridges, pathways, terrain accents.

**Concerns:**
- Small pack by low-poly art standards (96 pieces) -- many competitors offer 300-500+ pieces
- Fantasy-specific style -- limited utility for non-fantasy or realist 3D projects
- No LODs included
- 4/5 rating from only 3 reviews

**Overlap Analysis:**
- **Overlaps with Poly Universal Pack (035)** which has a broader multi-genre library. Low Poly Fantasy Village fills in fantasy-specific architectural pieces.
- **Complements Low Poly Modular Terrain (044)** -- terrain from 044, structures from this pack = full fantasy overworld layout

**Verdict Rationale:** Approved (no label -- project-specific). Free, clean low-poly art pack useful for fantasy game prototyping or small-scope fantasy environments. Not broad enough to warrant Default 3D label, but good to have available.

**Project Relevance:** HOK (Greek underworld aesthetic -- MEDIUM, not classic fantasy but could work for Elysium areas), Cursed Fantasy (VERY HIGH -- exactly on-genre), A Quokka Story (fantasy environments -- MEDIUM).

---

## ENTRY-176: Crosshairs (OccaSoftware)

| Field | Value |
|-------|-------|
| **Asset** | Crosshairs |
| **Publisher** | OccaSoftware |
| **Source** | Asset Store (https://assetstore.unity.com/packages/slug/216732) |
| **Price** | $0 (FREE) |
| **Category** | Textures Materials / Icons UI |
| **Rating** | 5/5 (49 ratings) |
| **Session** | 40 |
| **Verdict** | Approved |
| **Label** | -- |
| **CSV ID** | ForeignId 216732 |

**What It Is:** Crosshair texture pack with Editor utility for browsing and selecting from included designs. Free tier crosshair library.

**Folder:** `Assets/OccaSoftware/Crosshairs/`

**Scale:** 1 Editor script (`StartMenu.cs`), 1 asmdef (Editor only), art/texture folder, demo resources.

**Key Features:**
- Editor browser window for crosshair preview and selection
- Multiple crosshair styles (dot, cross, circle, chevron variants)
- PNG sprites ready for use as UI Image components

**Concerns:**
- Free tier -- CrosshairsPro (177) has 2,970 textures vs this pack's smaller set
- Editor script -- no runtime scripts, purely a texture library

**Overlap Analysis:**
- **Superseded by CrosshairsPro (177)** for projects that need variety. But for basic needs, this free version is sufficient.

**Verdict Rationale:** Approved with **Default** label. At zero cost with a 5/5 rating from 49 reviews, this is the best-reviewed OccaSoftware asset and requires zero overhead. Any game with aiming mechanics benefits from a crosshair library.

**Project Relevance:** Alpha Foxtrot Uniform (shooter -- VERY HIGH), FearSteez (targeting reticle -- MEDIUM), any project with ranged weapons or targeting.

---

## ENTRY-177: Crosshairs Pro (OccaSoftware)

| Field | Value |
|-------|-------|
| **Asset** | Crosshairs Pro |
| **Publisher** | OccaSoftware |
| **Source** | Asset Store (https://assetstore.unity.com/packages/slug/239049) |
| **Price** | $6.00 |
| **Category** | Textures Materials / GUI Skins |
| **Rating** | 0/5 (0 ratings) |
| **Session** | 40 |
| **Verdict** | Approved |
| **Label** | -- |
| **CSV ID** | ForeignId 239049 |

**What It Is:** Extended crosshair texture pack with 2,970 individual PNG textures organized by style. Includes Figma source file (CrosshairsPro.fig) for custom crosshair authoring.

**Folder:** `Assets/OccaSoftware/CrosshairsPro/`

**Scale:** 2,970 texture files, 0 scripts. Figma design source included.

**Concerns:**
- 2,970 files is significant overhead -- consider importing only needed subsets
- Zero ratings -- not reviewed despite being a paid asset
- Figma source file only useful if you have Figma access

**Overlap Analysis:**
- **Extends Crosshairs (176)** -- same publisher, same purpose, more variety. Keep both since the free one's editor browser is useful for quick browsing.

**Verdict Rationale:** Approved with **Default** label. At $6 with essentially unlimited crosshair variety (2,970 textures), any shooter or targeting-based game has its needs covered. The Figma source is a bonus for custom designs.

**Project Relevance:** Same as Crosshairs (176) -- shooter and aiming mechanics.

---

## ENTRY-178: Texture Channel Packer (OccaSoftware)

| Field | Value |
|-------|-------|
| **Asset** | Texture Channel Packer by OccaSoftware |
| **Publisher** | OccaSoftware |
| **Source** | Asset Store (https://assetstore.unity.com/packages/slug/247650) |
| **Price** | $8.00 |
| **Category** | Editor Extensions / Utilities |
| **Rating** | 0/5 (2 ratings) |
| **Session** | 40 |
| **Verdict** | Approved |
| **Label** | Recommended |
| **CSV ID** | ForeignId 247650 |

**What It Is:** Unity Editor window tool for packing separate grayscale textures (Metallic, AO, Detail, Smoothness, etc.) into RGBA channels of a single texture. Essential for optimizing PBR texture sets -- Unity's standard shader expects packed masks.

**Folder:** `Assets/OccaSoftware/TextureChannelPacker/`

**Scale:** 2 scripts (`TextureChannelPackerWindow.cs`, `TextureData.cs`), 1 asmdef (Editor only). Menu: `Tools > Texture Channel Packer`.

**Key Features:**
- Assign any texture to any RGBA channel via GUI
- Output as PNG to any project folder
- Non-destructive -- reads source textures, writes new packed file
- Demo terrain levels included for testing

**Concerns:**
- Editor-only tool (no runtime overhead)
- Zero ratings from 2 reviewers -- possibly used without being rated
- Basic UI -- no batch mode for multiple textures at once

**Overlap Analysis:**
- **Complements 150 Realistic Textures (174)** -- if any included textures need channel repacking for specific shaders (e.g., custom Shader Graph nodes expecting MAOHS packing), this tool handles it
- **Complements Amplify Shader Editor (158)** -- Amplify shaders often use custom texture channel conventions; this packer bridges the gap

**Verdict Rationale:** Approved with **Default 3D** label. Editor utility that every 3D project needs when working with PBR textures. At $8 it is inexpensive, Editor-only (zero runtime cost), and fills a real gap in Unity's built-in texture workflow.

**Project Relevance:** Any 3D project with custom PBR shaders -- HIGH across all 3D TecVooDoo projects.

---

## ENTRY-179: Local Global Illumination (OccaSoftware)

| Field | Value |
|-------|-------|
| **Asset** | Local Global Illumination for Unity URP |
| **Publisher** | OccaSoftware |
| **Source** | Asset Store (https://assetstore.unity.com/packages/slug/247160) |
| **Price** | $12.00 |
| **Category** | Shaders |
| **Rating** | 3/5 (6 ratings) |
| **Session** | 40 |
| **Verdict** | Rejected |
| **Label** | Don't Use |
| **CSV ID** | ForeignId 247160 |

**What It Is:** Post-process effect for simulating local/indirect global illumination in URP using screen-space techniques.

**Blocking Issue:** CS0619 compile error in Unity 6. Uses `RenderTargetHandle` which was deprecated in Unity 2022.1 and removed from Unity 2023.1+. This package is broken in the Sandbox's Unity 6000.3.7f1 environment.

**Error:** `CS0619: 'RenderTargetHandle' is obsolete: 'RenderTargetHandle has been deprecated.'`

**Status:** NOT installed (import failed / files deleted to resolve error). Do not import.

**Verdict Rationale:** Rejected with **Don't Use** label. Incompatible with Unity 6. Publisher has not updated for Unity 2023.1+ API changes. Unity's built-in URP Adaptive Probe Volumes (APV) and Screen Space Global Illumination (SSGI) cover this use case natively in Unity 6.

---

## ENTRY-180: OccaSoftware Bundle - VFX and Shader Megapack

| Field | Value |
|-------|-------|
| **Asset** | OccaSoftware Bundle - VFX and Shader Megapack for Unity |
| **Publisher** | OccaSoftware |
| **Source** | Asset Store (https://assetstore.unity.com/packages/slug/238480) |
| **Price** | $95.00 |
| **Category** | Shaders / Fullscreen Camera Effects |
| **Rating** | 0/5 (2 ratings) |
| **Session** | 40 |
| **Verdict** | Approved |
| **Label** | -- |
| **CSV ID** | ForeignId 238480 |

**What It Is:** NOT a content pack. This is a bundle purchase asset -- buying it on the Asset Store unlocks the individual OccaSoftware packages as free downloads. The `.unitypackage` file contains only a README explaining this. All actual content is in the individual packages (ENTRY-170 through ENTRY-206).

**Status:** Intentionally skipped during batch import (`SkipFile` constant in `OccaSoftwareBatchImporter.cs`).

**Verdict Rationale:** Approved. The bundle serves its purpose correctly as a purchase vehicle. No importable content by design -- evaluate each individual package (ENTRY-170 through ENTRY-206) on its own merits.

---

## ENTRY-181: Altos (OccaSoftware)

| Field | Value |
|-------|-------|
| **Asset** | Altos - Volumetric Clouds Skybox and Weather for Unity URP |
| **Publisher** | OccaSoftware |
| **Source** | Packages/ UPM (`com.occasoftware.altos`) |
| **Version** | 7.17.0 |
| **Price** | $45.00 |
| **Category** | Shaders / Fullscreen Camera Effects |
| **Rating** | 5/5 (39 ratings) |
| **Session** | 40 |
| **Verdict** | Approved |
| **Label** | Recommended |
| **CSV ID** | ForeignId 221227 |

**What It Is:** Full sky, weather, and volumetric cloud system for URP. Handles the entire atmospheric vertical: procedural skybox, day/night cycle, sun/moon/stars, volumetric clouds, atmospheric scattering, precipitation (rain/snow), wind zones, and cloud shadow casting. Uses Unity VFX Graph for clouds.

**Package:** `Packages/com.occasoftware.altos/`

**Scale:** 63 scripts, 5 asmdefs, 39 shader/HLSL/VFX files.

**Asmdefs:** `OccaSoftware.Altos.Runtime`, `OccaSoftware.Altos.Editor`, `OccaSoftware.Altos.ShaderLibrary`, `OccaSoftware.Altos.Shaders`, `OccaSoftware.Altos.Demo`.

**Key Components:**
- `AltosData` (ScriptableObject) -- master configuration for all sky settings. Single asset drives the whole system.
- `SkyDefinition`, `CloudDefinition`, `AtmosphereDefinition`, `StarDefinition`, `PrecipitationDefinition`, `TemperatureDefinition` -- SO subconfigs for each sky layer
- `AltosLight` (MonoBehaviour) -- marks a light as the sun or moon for Altos to control
- `ReflectionTrigger` -- triggers reflection probe updates on sky change
- `InheritOriginDemo`, `FloatingPointOffsetDemo`, `SetOriginOffsetDemo` -- floating origin / large world support components
- `FreeCamera` -- built-in debug camera for sky evaluation

**Architecture Notes:**
- Depends on VFX Graph (`com.unity.visualeffectgraph 14.0.7`) -- clouds are VFX Graph assets
- `CloudmapPreviewEditorWindow` -- Editor window for previewing cloud texture maps
- `CreateGameObjectContextMenus` -- context menu shortcuts to add Altos components

**Samples:** Demo, Cloud Shadow Implementation, Precipitation Occlusion, Transparency.

**Ecosystem Role:** Top tier of the OccaSoftware atmosphere stack. Altos = sky/clouds/weather. Pairs with Buto (fog), LSPP (god rays), Cloud Shadows (shadow projection), Auto Exposure, Better Bloom.

**Concerns:**
- VFX Graph dependency -- requires VFX Graph package, adds to project setup cost
- $45 is the most expensive single OccaSoftware package alongside Ultimate Lit Shader
- Floating point offset utilities suggest large-world design -- relevant for open-world projects

**Overlap Analysis:**
- **No direct overlap** with any evaluated asset -- fills a genuine gap (Unity has no built-in volumetric cloud system for URP)
- **Competes with** Unity's built-in HDRI/Gradient sky but adds volumetric clouds, weather, and full day/night scripted cycle
- **Designed to pair with Buto (182)** -- Altos handles sky level, Buto handles ground-level fog

**Verdict Rationale:** Approved with **Default 3D** label. Best-in-class URP sky system. 5/5 from 39 ratings is strong validation. The SkyDefinition ScriptableObject architecture means Claude can configure and swap sky presets entirely via script. VFX Graph dependency is manageable. Required for any outdoor 3D project wanting convincing atmosphere.

**Project Relevance:**
- HOK (Acheron/Styx outdoor overworld -- VERY HIGH. Gloomy sky, mist, day cycle for time-of-day fishing mechanics)
- Cursed Fantasy (outdoor environments -- VERY HIGH)
- Alpha Foxtrot Uniform (outdoor tactical -- HIGH)
- All outdoor 3D projects -- HIGH

---

## ENTRY-182: Buto (OccaSoftware)

| Field | Value |
|-------|-------|
| **Asset** | Buto - Volumetric Fog and Volumetric Lighting for URP |
| **Publisher** | OccaSoftware |
| **Source** | Packages/ UPM (`com.occasoftware.buto`) |
| **Version** | 7.11.6 |
| **Price** | $40.00 |
| **Category** | Shaders / Fullscreen Camera Effects |
| **Rating** | 5/5 (56 ratings) |
| **Session** | 40 |
| **Verdict** | Approved |
| **Label** | Recommended |
| **CSV ID** | ForeignId 258881 |

**What It Is:** Volumetric fog and volumetric lighting system for URP. URP has no built-in volumetric fog (that is HDRP-only), making Buto a direct gap-filler. Creates depth haze, atmospheric distance fog, and light-scattering effects around scene lights.

**Package:** `Packages/com.occasoftware.buto/`

**Scale:** 27 scripts, 4 asmdefs, 8 shaders.

**Asmdefs:** `OccaSoftware.Buto.Runtime`, `OccaSoftware.Buto.Editor`, `OccaSoftware.Buto.Shaders`, `OccaSoftware.Buto.Demo`.

**Key Components:**
- `ButoVolumetricFog` -- main Volume Override (Volume component that configures fog settings via the Unity Volume system)
- `ButoRenderFeature` + `ButoRenderPass` -- URP Renderer Feature, attach to URP Renderer asset
- `FogDensityMask` -- per-object fog density override (reduce fog inside buildings, increase in caves)
- `ButoLight` (MonoBehaviour) -- marks a light for volumetric scattering. Supports directional, spot, point.
- `ButoWindZone` -- animates fog movement with wind
- `DisableButoRendering` -- per-camera flag to disable Buto on specific cameras (e.g., UI camera)
- `AnimateButoSetting` -- runtime fog parameter animation (for dynamic weather transitions)
- `VolumeNoise` -- generates noise textures for fog variation

**Editor Tools:**
- `ButoLightMenuItem`, `FogDensityMaskMenuItem` -- Create menu shortcuts
- `ButoLightEditor`, `FogDensityMaskEditor`, `VolumetricFogEditor` -- custom inspectors
- `AddCustomScriptingSymbols` -- auto-adds `BUTO` scripting symbol (enables Buto-aware code paths in other assets)

**Integration Notes:**
- Uses Unity Volume system -- configure fog via Volume Profiles, same workflow as URP post-process
- `BUTO` scripting define symbol enables Buto-aware code paths in other packages
- `FogDensityMask` enables per-zone fog control -- critical for indoor/outdoor transitions

**Concerns:**
- $40 is significant
- Highest rating count in the entire OccaSoftware catalog (56) -- very well validated

**Overlap Analysis:**
- **No conflict with any evaluated asset** -- fills a URP-only gap
- **Designed to pair with Altos (181)** -- Altos sky + Buto ground fog = full atmospheric stack
- **Pairs with LSPP (185)** -- Buto handles fog density volume, LSPP handles directional light shaft scattering

**Verdict Rationale:** Approved with **Default 3D** label. The highest-rated OccaSoftware package (5/5, 56 reviews). URP simply has no volumetric fog -- this is not a nice-to-have, it is a required purchase for any URP project needing atmospheric depth. The `FogDensityMask` component for per-area fog control is particularly powerful. Claude can configure all fog settings via script through the Volume Override API.

**Project Relevance:**
- HOK (Acheron river mist -- VERY HIGH. Core atmosphere asset for the underworld setting)
- Cursed Fantasy (dungeon/cave fog -- VERY HIGH)
- All outdoor 3D projects where atmosphere matters -- HIGH

---

## ENTRY-183: Super Simple Sky (OccaSoftware)

| Field | Value |
|-------|-------|
| **Asset** | Super Simple Skybox Dynamic Procedural Skybox |
| **Publisher** | OccaSoftware |
| **Source** | Packages/ UPM (`com.occasoftware.super-simple-skybox`) |
| **Version** | 5.0.0 |
| **Price** | $8.00 |
| **Category** | Textures Materials / Skies |
| **Rating** | 5/5 (35 ratings) |
| **Session** | 40 |
| **Verdict** | Approved |
| **Label** | -- |
| **CSV ID** | ForeignId 210177 |

**What It Is:** Lightweight procedural skybox shader with scripted day/night cycle, sun/moon placement, and atmospheric color gradient controls. Simpler and lower-cost than Altos -- no volumetric clouds, no weather simulation -- but excellent value for projects that just need a better sky.

**Package:** `Packages/com.occasoftware.super-simple-skybox/`

**Scale:** 10 scripts, 3 asmdefs, 2 shaders.

**Asmdefs:** `OccaSoftware.SuperSimpleSkybox.Runtime`, `OccaSoftware.SuperSimpleSkybox.Editor`, `OccaSoftware.SuperSimpleSkybox.Demo`.

**Key Components:**
- `Sun`, `Moon` -- MonoBehaviours that drive directional light position based on time-of-day
- `SunStatic`, `MoonStatic` -- variants for fixed (non-animated) celestial bodies
- `DirectionalLight` -- companion to Sun/Moon for controlling light color/intensity along the day arc
- `SetStarRotation` -- animates star dome rotation independently of sun/moon
- `VRSkybox` -- VR-compatible skybox rendering variant
- `OnSunriseSunsetDemo` -- callback example for triggering events at sunrise/sunset
- `SkyboxEditorGUI` -- custom material inspector with color pickers for sky/horizon/ground

**Samples:** Demo (day/night system with event callbacks at sunrise/sunset).

**Ecosystem Role:** Lightweight alternative to Altos. Use Super Simple Sky when:
- Volumetric clouds are not needed (indoor-heavy games, side-scrollers)
- Performance budget is tight (mobile, older hardware)
- Simpler art direction (stylized, cartoon, low-poly)

**Overlap Analysis:**
- **Simpler alternative to Altos (181)** -- use one or the other per-project, not both. Both are OccaSoftware; compatible scripting interfaces.
- **Pairs with Buto (182)** -- Buto's fog works independently of sky choice
- **Pairs with LSPP (185)** -- god rays work with any directional light sky

**Verdict Rationale:** Approved with **Default 3D** label. At $8 with 5/5 from 35 reviews, this is outstanding value. Every 3D project benefits from a proper sky. Use SSS when Altos's full atmospheric stack is overkill. The callback system for sunrise/sunset events is a clean hook for gameplay time-of-day systems.

**Project Relevance:** All outdoor 3D projects as lightweight sky fallback. HOK stylized variant -- MEDIUM (Altos preferred for HOK's atmospheric goal). Mobile 3D projects -- HIGH.

---

## ENTRY-184: Dynamic Cloud Shadows (OccaSoftware)

| Field | Value |
|-------|-------|
| **Asset** | Dynamic Cloud Shadows |
| **Publisher** | OccaSoftware |
| **Source** | Packages/ UPM (`com.occasoftware.cloud-shadows`) |
| **Version** | 2.1.0 |
| **Price** | $10.00 |
| **Category** | Shaders |
| **Rating** | 0/5 (2 ratings) |
| **Session** | 40 |
| **Verdict** | Approved |
| **Label** | -- |
| **CSV ID** | ForeignId 247771 |

**What It Is:** URP Renderer Feature that projects animated cloud shadow patterns onto scene geometry from a directional light. Uses a tiling cloud texture scrolled over time to simulate moving cloud shadows on terrain and buildings.

**Package:** `Packages/com.occasoftware.cloud-shadows/`

**Scale:** 4 scripts, 3 asmdefs, 2 shaders.

**Asmdefs:** `OccaSoftware.CloudShadows.Runtime`, `OccaSoftware.CloudShadows.Editor`, `OccaSoftware.CloudShadows.Shaders`.

**Key Components:**
- `CloudShadows` (MonoBehaviour) -- master component. Controls cloud texture, scroll speed, shadow intensity, scale, and light source reference.
- `CloudShadowsEditor` -- custom inspector
- `CloudShadowsMaterialEditorGUI` -- material GUI helper

**Depends on:** Shader Graph (`com.unity.shadergraph 12.1.6`).

**Concerns:**
- Low rating count (2 reviews, 0/5 average) -- unrated rather than bad. Package is likely used silently.
- Lightweight add-on, minimal setup

**Overlap Analysis:**
- **Extension to Altos (181)** -- Altos handles volumetric clouds; Cloud Shadows makes those clouds cast dynamic shadows on the ground. Independent of Altos but designed to complement it.

**Verdict Rationale:** Approved with **Default 3D** label. Cheap ($10), simple, and fills the detail gap between "sky has clouds" and "clouds cast shadows on terrain." Noticeable visual quality upgrade for outdoor scenes. The unrated status is not a concern given its simplicity and OccaSoftware's track record.

**Project Relevance:** HOK (Acheron outdoor areas -- HIGH), any outdoor environment with visible terrain and sky -- HIGH.

---

## ENTRY-185: LSPP - God Rays / Volumetric Lighting (OccaSoftware)

| Field | Value |
|-------|-------|
| **Asset** | LSPP - God Rays Volumetric Lighting Light Shafts for Unity URP |
| **Publisher** | OccaSoftware |
| **Source** | Packages/ UPM (`com.occasoftware.lspp`) |
| **Version** | 3.3.1 |
| **Price** | $25.00 |
| **Category** | Shaders / Fullscreen Camera Effects |
| **Rating** | 5/5 (14 ratings) |
| **Session** | 40 |
| **Verdict** | Approved |
| **Label** | Recommended |
| **CSV ID** | ForeignId 259947 |

**What It Is:** Screen-space volumetric light scattering (god rays / light shafts) for URP. Simulates sunlight or artificial light beams scattering through atmosphere, dust, or gaps in geometry using a radial sampling blur from the light source position.

**Package:** `Packages/com.occasoftware.lspp/`

**Scale:** 8 scripts, 3 asmdefs, 6 shaders.

**Asmdefs:** `OccaSoftware.LSPP.Runtime`, `OccaSoftware.LSPP.Shaders`, `OccaSoftware.LSPP.Demo`.

**Key Components:**
- `LightScatteringPostProcess` -- Volume Override controlling scattering density, quality, and color
- `LightScatteringRenderFeature` + `LightScatteringRenderPass` -- URP Renderer Feature
- `OverrideLightSettings` (MonoBehaviour) -- per-light override for scattering color, intensity, and screen-space position clamping
- `ChangeLightScatteringColor` -- runtime animation helper for dynamic scattering color changes

**Samples:** Demo with multiple light configurations.

**Ecosystem Role:** Third element of the OccaSoftware atmosphere pipeline. Altos = sky, Buto = fog density, LSPP = light scattering beams. Together they provide:
- Sky with dynamic clouds and weather (Altos)
- Fog/haze depth (Buto)
- Visible light shafts through that fog (LSPP)

**Overlap Analysis:**
- **Complements Buto (182)** directly -- light shafts are most visible when there is volumetric medium for them to scatter through. LSPP + Buto = complete volumetric lighting experience.
- **Requires a directional light** (typically the Altos sun) -- works naturally within the Altos + Buto stack.

**Verdict Rationale:** Approved with **Default 3D** label. 5/5 from 14 reviews. The `OverrideLightSettings` per-light component enables fine control over individual light sources, allowing different scattering properties for sun vs. artificial lights. Claude can configure via Volume Override script access. Strong visual impact for any outdoor or atmospheric 3D scene.

**Project Relevance:**
- HOK (sunlight through Acheron mist -- VERY HIGH. Core visual pillar of the underworld aesthetic)
- Cursed Fantasy (dungeon torch god rays -- HIGH)
- Alpha Foxtrot Uniform (battlefield haze, spotlight beams -- HIGH)

---

## ENTRY-186: Better Bloom (OccaSoftware)

| Field | Value |
|-------|-------|
| **Asset** | Better Bloom |
| **Publisher** | OccaSoftware |
| **Source** | Packages/ UPM (`com.occasoftware.bloom`) |
| **Version** | 0.2.0 |
| **Price** | $9.00 |
| **Category** | Shaders / Fullscreen Camera Effects |
| **Rating** | 0/5 (0 ratings) |
| **Session** | 40 |
| **Verdict** | Conditional |
| **Label** | -- |
| **CSV ID** | ForeignId 285826 |

**What It Is:** Custom URP post-process bloom override. Aims to replace or augment Unity's built-in Bloom post-process with an alternative implementation offering different quality/performance tradeoffs.

**Package:** `Packages/com.occasoftware.bloom/`

**Scale:** 3 scripts, 2 asmdefs. Minimal.

**Asmdefs:** `OccaSoftware.Bloom.Runtime`, `OccaSoftware.Bloom.Shaders`.

**Key Components:**
- `Bloom` (MonoBehaviour) -- main bloom controller
- `BloomOverride` -- Volume Override for the URP Volume system

**Concerns:**
- Version 0.2.0 -- very early release
- Zero ratings -- brand new package, completely unvalidated
- Unity 6 URP already ships with high-quality Bloom (including Lens Dirt and high quality/performance modes). The case for a replacement bloom needs to be demonstrated.

**Overlap Analysis:**
- **Competes with URP built-in Bloom** -- Unity 6's bloom is already very good. Better Bloom must offer a distinct advantage (quality, performance, or specific look).

**Verdict Rationale:** Conditional with **Default 3D** label. Needs hands-on testing against Unity 6's built-in bloom before committing. The 0.2.0 version number and zero ratings make this a "watch" item rather than a confident recommendation. Low risk to keep installed but do not use as default until tested.

---

## ENTRY-187: Auto Exposure (OccaSoftware)

| Field | Value |
|-------|-------|
| **Asset** | Auto Exposure for URP |
| **Publisher** | OccaSoftware |
| **Source** | Packages/ UPM (`com.occasoftware.auto-exposure`) |
| **Version** | 3.2.2 |
| **Price** | $19.00 |
| **Category** | Shaders / Fullscreen Camera Effects |
| **Rating** | 4/5 (11 ratings) |
| **Session** | 40 |
| **Verdict** | Approved |
| **Label** | -- |
| **CSV ID** | ForeignId 259942 |

**What It Is:** Eye adaptation / auto exposure system for URP. Simulates how the eye adjusts to changes in scene brightness -- going from bright outdoor to dark indoor causes temporary overexposure, then gradual adjustment. URP has no built-in auto exposure (again, HDRP-only feature).

**Package:** `Packages/com.occasoftware.auto-exposure/`

**Scale:** 8 scripts, 4 asmdefs, 7 shaders.

**Asmdefs:** `OccaSoftware.AutoExposure.Runtime`, `OccaSoftware.AutoExposure.Editor`, `OccaSoftware.Exposure.Shaders`, `OccaSoftware.AutoExposure.Demo`.

**Key Components:**
- `AutoExposureRenderFeature` + `AutoExposureComputeRenderPass` + `AutoExposureFragmentRenderPass` -- URP Renderer Feature (two-pass: compute histogram then apply)
- `AutoExposureOverride` -- Volume Override for min/max EV, adaptation speed, metering mode
- `AutoExposureEditor` -- custom inspector
- `RenderingUtilsHelper`, `MonitorFramerate` -- utility components

**Notes:**
- Uses compute shader pass for histogram-based exposure metering (accurate to actual scene luminance)
- Separate compute and fragment passes for correct exposure calculation

**Concerns:**
- $19 for a single effect
- 4/5 from 11 reviews -- solid but not perfect

**Overlap Analysis:**
- **Complements Better Bloom (186)** -- auto exposure + bloom together create a complete cinematic camera simulation
- **No conflict** with any other asset

**Verdict Rationale:** Approved with **Default 3D** label. URP has no auto exposure -- this fills another genuine gap. The compute shader approach for luminance histogram metering is the right implementation (not a simple average). At $19 it is reasonably priced for what it adds to any 3D game wanting photorealistic camera behavior.

**Project Relevance:** HOK (transitioning between Acheron darkness and Elysium brightness -- HIGH), any game with dramatic lighting transitions -- HIGH.

---

## ENTRY-188: Motion Blur (OccaSoftware)

| Field | Value |
|-------|-------|
| **Asset** | Motion Blur - Object Motion Blur Camera Motion Blur Cinematic Motion Blur |
| **Publisher** | OccaSoftware |
| **Source** | Packages/ UPM (`com.occasoftware.motion-blur`) |
| **Version** | 3.2.1 |
| **Price** | $40.00 |
| **Category** | Shaders / Fullscreen Camera Effects |
| **Rating** | 4/5 (6 ratings) |
| **Session** | 40 |
| **Verdict** | Conditional |
| **Label** | -- |
| **CSV ID** | ForeignId 248129 |

**What It Is:** Motion blur system with per-object motion blur (velocity buffer approach) plus camera motion blur. Provides both object and camera blur independently, with masking support to exclude specific objects.

**Package:** `Packages/com.occasoftware.motion-blur/`

**Scale:** 16 scripts, 3 asmdefs.

**Asmdefs:** `OccaSoftware.MotionBlur.Runtime`, `OccaSoftware.MotionBlur.Editor`, `OccaSoftware.MotionBlur.Demo`.

**Key Components:**
- `BetterMotionBlur` -- Volume Override for blur intensity, shutter angle, and masking
- `MotionBlurRendererFeature` + `MotionBlurRenderPass` + `MotionBlurMaskRenderPass` -- URP Renderer Feature (two passes: velocity + mask)
- `OverrideAPI` -- runtime API for dynamic blur parameter changes (useful for hit-stop effects or speed boost)
- `VehicleController` -- demo vehicle with blur masking example

**Concerns:**
- $40 is steep for motion blur
- Unity 6 URP ships with built-in Motion Blur (camera-based). The "per-object" blur is the differentiator -- Unity's built-in only blurs based on camera movement.
- 4/5 from 6 reviews -- low sample size

**Overlap Analysis:**
- **Competes with URP built-in Motion Blur** for camera blur. Per-object blur is a distinct feature not in URP built-in.

**Verdict Rationale:** Conditional. The per-object motion blur (individual fast-moving objects blur independently of camera) is genuinely not in URP built-in and is valuable for action games. But $40 is a lot for this specific use case. No label -- assign Default 3D if per-object blur is needed for a specific project.

**Project Relevance:** FearSteez (hit-stop/speed blur impact effects -- MEDIUM), racing or vehicle games -- HIGH, most games -- LOW.

---

## ENTRY-189: HazeFX (OccaSoftware)

| Field | Value |
|-------|-------|
| **Asset** | HazeFX Advanced Heat Distortion Blur and Fog Effects for Unity URP |
| **Publisher** | OccaSoftware |
| **Source** | Packages/ UPM (`com.occasoftware.haze-fx`) |
| **Version** | 0.5.2 |
| **Price** | $9.00 |
| **Category** | Shaders / Fullscreen Camera Effects |
| **Rating** | 0/5 (2 ratings) |
| **Session** | 40 |
| **Verdict** | Approved |
| **Label** | -- |
| **CSV ID** | ForeignId 255186 |

**What It Is:** Screen-space heat distortion, shimmer, and distance haze post-process for URP. Creates visible heat shimmer above hot surfaces, desert/tarmac mirage effects, and distance-based blur haze.

**Package:** `Packages/com.occasoftware.haze-fx/`

**Scale:** 6 scripts, 2 asmdefs, 6 shaders.

**Asmdefs:** `OccaSoftware.HazeFX.Runtime`, `OccaSoftware.HazeFX.Editor`.

**Key Components:**
- `HazeFX` -- Volume Override for shimmer intensity, frequency, distance falloff
- `HazeFXFeature` + `HazeFXPass` -- URP Renderer Feature
- `HazeFXEditor` -- custom inspector

**Concerns:**
- Version 0.5.2 -- pre-1.0
- Zero rating / 2 reviews -- unvalidated

**Verdict Rationale:** Approved with **Default 3D** label. Cheap ($9), fills a specific visual effect niche (heat shimmer, desert environments, exhaust/fire proximity distortion). Not available in URP built-in. The low version number and unrated status are noted but at $9 the risk is minimal.

**Project Relevance:** Alpha Foxtrot Uniform (desert/tarmac environments -- HIGH), HOK (heat shimmer off Acheron embers -- MEDIUM), Cursed Fantasy (fire/lava zones -- MEDIUM).

---

## ENTRY-190: Gaussian Blur (OccaSoftware)

| Field | Value |
|-------|-------|
| **Asset** | Gaussian Blur Screen Object and UI Blur for Unity URP |
| **Publisher** | OccaSoftware |
| **Source** | Packages/ UPM (`com.occasoftware.gaussian-blur`) |
| **Version** | 3.0.1 |
| **Price** | $9.00 |
| **Category** | Shaders / Fullscreen Camera Effects |
| **Rating** | 2/5 (3 ratings) |
| **Session** | 40 |
| **Verdict** | Approved |
| **Label** | Recommended |
| **CSV ID** | ForeignId 246861 |

**What It Is:** Gaussian blur for three distinct targets: full screen, per-object (world-space mesh blur), and UI (VisualElement/RectTransform blur). Three different use cases, three modes in one package.

**Package:** `Packages/com.occasoftware.gaussian-blur/`

**Scale:** 6 scripts, 2 asmdefs, 2 shaders.

**Asmdefs:** `OccaSoftware.GaussianBlur.Runtime`, `OccaSoftware.GaussianBlur.Editor`.

**Key Components:**
- `GaussianBlur` (MonoBehaviour) -- attach to camera or object for blur effect
- `BlurRenderFeature` -- URP Renderer Feature for screen-space pass
- `CopyCanvas`, `CopyImage`, `CopyRectTransform` -- UI blur utilities for copying UI elements into blurred composite
- `GaussianBlurEditorGUI` -- custom inspector

**Concerns:**
- 2/5 rating from 3 reviews -- below average. Suggests real issues. Investigate before use.
- The low rating may indicate setup complexity or edge cases (UI blur in particular is notoriously tricky in URP)

**Overlap Analysis:**
- **UI blur** use case complements Kamgam UI Toolkit Blurred Background (118) but for uGUI rather than UI Toolkit

**Verdict Rationale:** Approved with **Default 3D** label, but flag the 2/5 rating. The three-mode coverage (screen, object, UI) in one package is valuable breadth. Test carefully -- the low rating suggests something needs attention (possibly setup steps that aren't obvious). The uGUI blur utility is the differentiator from Kamgam's UI Toolkit blur.

**Project Relevance:** FearSteez (depth-of-field or focus blur for UI -- MEDIUM), any project needing per-object blur -- MEDIUM.

---

## ENTRY-191: Outlines Post-Process (OccaSoftware)

| Field | Value |
|-------|-------|
| **Asset** | Outlines Post-Process - Universal Outline Shader for Unity URP |
| **Publisher** | OccaSoftware |
| **Source** | Packages/ UPM (`com.occasoftware.outlines`) |
| **Version** | 1.1.1 |
| **Price** | $40.00 |
| **Category** | Shaders / Fullscreen Camera Effects |
| **Rating** | 0/5 (2 ratings) |
| **Session** | 40 |
| **Verdict** | Approved |
| **Label** | -- |
| **CSV ID** | ForeignId 285824 |

**What It Is:** Full-scene post-process outline effect using depth and normal edge detection. Applies outlines uniformly across all geometry in the scene pass -- the "cell-shaded / toon" look applied globally.

**Package:** `Packages/com.occasoftware.outlines/`

**Scale:** 7 scripts, 2 asmdefs.

**Asmdefs:** `OccaSoftware.Outlines.Runtime`, `OccaSoftware.Outlines.Shaders`.

**Key Components:**
- `OutlinesRenderfeature` -- URP Renderer Feature (attach to URP Renderer)
- `OutlineRenderPass` -- screen-space depth/normal edge detection pass
- `OutlineVolumeSettings` -- Volume Override (thickness, color, depth/normal sensitivity)
- `EnqueueOutlinePass` (MonoBehaviour) -- per-camera outline enable/disable
- `RenderingUtilsHelper` -- URP utility

**Approach:** Edge detection via depth buffer + normal buffer differencing. This creates outlines on geometry edges naturally, without requiring per-mesh setup. All objects in the scene get outlines uniformly.

**vs Outline Objects (200):**
- Outlines Post-Process: uniform full-scene, depth/normal-based, no per-object setup, natural toon look
- Outline Objects: per-mesh stencil, selective (only objects with the component), custom color per object

**Verdict Rationale:** Approved with **Default 3D** label. The full-scene approach is ideal for consistently stylized games (Toon Kit 2 + Outlines Post-Process = complete cel-shaded look). At $40 it is expensive for a post-process effect but the depth/normal approach requires no per-object setup which saves art time. Unrated (0/5, 2 reviews) is a watch flag.

**Project Relevance:** FearSteez (cel-shaded action game -- HIGH), Shrunken Head Toss (cartoon style -- HIGH), Toon Kit 2 partner.

---

## ENTRY-192: Radial Blur (OccaSoftware)

| Field | Value |
|-------|-------|
| **Asset** | Radial Blur for URP by OccaSoftware |
| **Publisher** | OccaSoftware |
| **Source** | Packages/ UPM (`com.occasoftware.radial-blur`) |
| **Version** | 3.0.0 |
| **Price** | $16.00 |
| **Category** | Shaders / Fullscreen Camera Effects |
| **Rating** | 5/5 (4 ratings) |
| **Session** | 40 |
| **Verdict** | Approved |
| **Label** | -- |
| **CSV ID** | ForeignId 259959 |

**What It Is:** Radial blur post-process effect for URP. Blurs the screen radially outward from a configurable screen-space center point. Used for speed effects, impact hit-stop, teleportation transitions, or boss entry effects.

**Package:** `Packages/com.occasoftware.radial-blur/`

**Scale:** 8 scripts, 3 asmdefs, 2 shaders.

**Asmdefs:** `OccaSoftware.RadialBlur.Runtime`, `OccaSoftware.RadialBlur.Shaders`, `OccaSoftware.RadialBlur.Demo`.

**Key Components:**
- `RadialBlurPostProcess` -- Volume Override (intensity, center position, quality)
- `RadialBlurFeature` + `RadialBlurPass` -- URP Renderer Feature
- `SetRadialBlurExamples` -- runtime API example (set center from world position)
- `SetCenterFromClick` -- demo: set blur center from mouse click position

**Key Feature:** The blur center can be driven from a world-space position projected to screen space -- so you can blur radially outward from an explosion, a character's fist, or a portal.

**Verdict Rationale:** Approved with **Default 3D** label. 5/5 from 4 reviews. The world-to-screen-space center projection makes this a practical combat/action effect tool. Strong use case for FearSteez hit-stop mechanics and Alpha Foxtrot Uniform impact effects.

**Project Relevance:** FearSteez (combo finisher blur, hit-stop -- HIGH), Alpha Foxtrot Uniform (explosion radial blast -- HIGH), HOK -- LOW.

---

## ENTRY-193: Negative Space (OccaSoftware)

| Field | Value |
|-------|-------|
| **Asset** | Negative Space Post-Process Effect |
| **Publisher** | OccaSoftware |
| **Source** | Packages/ UPM (`com.occasoftware.negative-space`) |
| **Version** | 1.0.0 |
| **Price** | $8.00 |
| **Category** | Shaders / Fullscreen Camera Effects |
| **Rating** | 0/5 (0 ratings) |
| **Session** | 40 |
| **Verdict** | Conditional |
| **Label** | -- |
| **CSV ID** | ForeignId 285830 |

**What It Is:** Color inversion / negative post-process effect for URP. Inverts the screen colors on trigger, creating a brief negative-film flash.

**Package:** `Packages/com.occasoftware.negative-space/`

**Scale:** 2 scripts, 2 asmdefs, 1 shader.

**Key Components:**
- `NegativeSpaceManager` (MonoBehaviour) -- main controller, trigger effect
- `PlayEffect` -- demo trigger

**Verdict Rationale:** Conditional. Niche stylistic effect. Useful for specific moments (camera flash, damage flash, stylized game-over screens). No label -- project-specific use only.

**Project Relevance:** DLYH (word game wrong-answer flash -- MEDIUM), stylized games needing screen flash effects -- LOW-MEDIUM generally.

---

## ENTRY-194: Ascii Shader / Pixelizer (OccaSoftware)

| Field | Value |
|-------|-------|
| **Asset** | Ascii Shader Pixelizer by OccaSoftware |
| **Publisher** | OccaSoftware |
| **Source** | Packages/ UPM (`com.occasoftware.ascii`) |
| **Version** | 3.5.0 |
| **Price** | $6.00 |
| **Category** | Shaders / Fullscreen Camera Effects |
| **Rating** | 0/5 (1 rating) |
| **Session** | 40 |
| **Verdict** | Conditional |
| **Label** | -- |
| **CSV ID** | ForeignId 208849 |

**What It Is:** Full-screen ASCII art / pixelizer post-process for URP. Converts the rendered frame into ASCII character patterns or pixelated blocks. Includes custom font asset for ASCII rendering.

**Package:** `Packages/com.occasoftware.ascii/`

**Scale:** 5 scripts, 2 asmdefs, 3 shaders + Font Assets folder.

**Asmdefs:** `OccaSoftware.Ascii.Runtime`, `OccaSoftware.Ascii.Demo`.

**Key Components:**
- `ASCIIRenderFeature` + `ASCIIRenderPass` -- URP Renderer Feature
- `ASCIIShaderParams` -- shader parameter constants
- `VideoPlayerManager` -- demo: renders video through ASCII filter

**Verdict Rationale:** Conditional. Fun stylization effect -- ASCII art game aesthetic, retro computer terminal look. No label -- project-specific. At $6 it is inexpensive for a specialty effect.

**Project Relevance:** Concept games with retro/terminal aesthetic -- MEDIUM. No current TecVooDoo projects are strongly aligned, but Encapsulated Fear (horror visual novel) could use this for disturbing screen effects.

---

## ENTRY-195: Toon Kit 2 (OccaSoftware)

| Field | Value |
|-------|-------|
| **Asset** | Toon Kit 2 Advanced Cel-Shading System for Unity URP |
| **Publisher** | OccaSoftware |
| **Source** | Packages/ UPM (`com.occasoftware.toon-kit-2`) |
| **Version** | 2.3.0 |
| **Price** | $12.00 |
| **Category** | Shaders |
| **Rating** | 5/5 (10 ratings) |
| **Session** | 40 |
| **Verdict** | Approved |
| **Label** | Recommended |
| **CSV ID** | ForeignId 239411 |

**What It Is:** Cel shading / toon shading shader system for URP. Multi-step shading bands, configurable ramp textures, rim light, specular stylization, and outline-friendly normals. Full Shader Graph implementation.

**Package:** `Packages/com.occasoftware.toon-kit-2/`

**Scale:** 8 scripts, 4 asmdefs, 4 shaders.

**Asmdefs:** `OccaSoftware.ToonKit2.Runtime`, `OccaSoftware.ToonKit2.Editor`, `OccaSoftware.ToonKit2.Shaders`, `OccaSoftware.ToonKit2.Demo`.

**Key Components:**
- `ToonKit2Manager` (MonoBehaviour) -- global toon manager, controls scene-wide shading parameters
- `ToonKit2EditorGUI` -- custom material inspector (live preview of shading bands, ramp editor)
- Demo scripts: `ButtonController`, `CameraController`, `Oscillate`, `Pan`, `Rotate`

**Samples:** Demo (full character showcase), SimpleDemo (minimal setup example).

**Overlap Analysis:**
- **Complements Outlines Post-Process (191)** -- Toon Kit 2 handles surface shading (bands, rim, spec), Outlines PP handles edge lines. Together = complete toon look.
- **Overlaps with All In 1 3D Shader (098)** -- All In 1 includes toon shading. Toon Kit 2 is dedicated and likely more refined for cel-shading primary projects.

**Verdict Rationale:** Approved with **Default 3D** label. At $12 with 5/5 from 10 reviews, this is the best-value dedicated toon shader in the Sandbox. The `ToonKit2Manager` global controller means the shading style can be adjusted in code. Essential for FearSteez's stylized visual direction.

**Project Relevance:** FearSteez (stylized beat 'em up -- VERY HIGH), Shrunken Head Toss (cartoon -- HIGH), A Quokka Story (stylized platformer -- HIGH).

---

## ENTRY-196: Ultimate Lit Shader (OccaSoftware)

| Field | Value |
|-------|-------|
| **Asset** | Lit Shader - PBR Materials Realistic Lighting Custom Lit Material Blend |
| **Publisher** | OccaSoftware |
| **Source** | Packages/ UPM (`com.occasoftware.ultimate-lit-shader`) |
| **Version** | 3.5.2 |
| **Price** | $65.00 |
| **Category** | Shaders |
| **Rating** | 5/5 (6 ratings) |
| **Session** | 40 |
| **Verdict** | Approved |
| **Label** | -- |
| **CSV ID** | ForeignId 246472 |

**What It Is:** Custom PBR lit shader extending Unity's built-in Lit shader with two-layer material blending, height-based blending, and advanced secondary texture controls. The custom `LitMaterialEditorGUI` replaces Unity's standard material inspector with a specialized UI.

**Package:** `Packages/com.occasoftware.ultimate-lit-shader/`

**Scale:** 1 script (Editor only), 1 asmdef, 2 shaders.

**Asmdefs:** `OccaSoftware.UltimateLitShader.Editor` (Editor-only).

**Key Components:**
- `LitMaterialEditorGUI` -- custom material inspector for the ULS shaders. Exposes height-blend controls, secondary UV, emission blend, etc.
- 2 shader files (URP Lit shader variants with blending nodes)

**Key Feature:** Material blending -- blend two complete PBR material layers (Albedo + Normal + Metallic/Roughness) using a height map. Classic use case: blend dirt/snow into stone at crevices, or sand into rock at the base.

**Concerns:**
- $65 is the highest single-package price from OccaSoftware
- Only 6 ratings despite 5/5 -- small sample
- Editor-only asmdef + 2 shaders = very lean package for the price

**Overlap Analysis:**
- **Complements 150 Realistic Textures (174)** -- blend two sets of textures from the library seamlessly
- **Competes with Amplify Shader Editor (158)** for custom PBR shading. ASE can build the same effects with more flexibility, but ULS provides a ready-made solution.

**Verdict Rationale:** Approved with **Default 3D** label. Two-layer PBR blending is a genuine need for environment art (terrain-to-rock transitions, multi-surface mesh blending). The specialized custom inspector makes the material setup user-friendly. At $65 the value depends on how often this blending workflow is needed -- for HOK's Acheron environment it is directly applicable.

**Project Relevance:** HOK (stone/mud Acheron banks -- HIGH), Cursed Fantasy (dungeon surfaces -- HIGH), any 3D project with detailed environment art.

---

## ENTRY-197: Fluff Grass (OccaSoftware)

| Field | Value |
|-------|-------|
| **Asset** | Fluff Grass for URP |
| **Publisher** | OccaSoftware |
| **Source** | Packages/ UPM (`com.occasoftware.fluff`) |
| **Version** | 2.1.0 |
| **Price** | $8.00 |
| **Category** | Shaders |
| **Rating** | 5/5 (4 ratings) |
| **Session** | 40 |
| **Verdict** | Approved |
| **Label** | Recommended |
| **CSV ID** | ForeignId 242152 |

**What It Is:** Stylized animated grass shader system for URP. Grass blades respond to wind and optionally to player/object interaction (grass pushes aside as a character walks through it).

**Package:** `Packages/com.occasoftware.fluff/`

**Scale:** 3 scripts, 3 asmdefs, 2 shaders.

**Asmdefs:** `OccaSoftware.Fluff.Runtime`, `OccaSoftware.Fluff.Editor`, `OccaSoftware.Fluff.Demo`.

**Key Components:**
- `RenderInteractiveGrass` (MonoBehaviour) -- attach to camera or character to drive interaction area. Passes interaction position to the shader.
- `GrassMaterialEditorGUI` -- custom material inspector for tuning wind, color variation, blade density
- `SphereController` -- demo movement controller

**Key Feature:** Interactive grass (player interaction) -- the `RenderInteractiveGrass` component writes the character's world position into a shader global, and grass blades bend away from that point.

**Concerns:**
- Shader-based grass (not geometry instancing / GPU instancing) -- density limits depend on how the mesh is set up
- URP only

**Overlap Analysis:**
- **No direct overlap** with any evaluated asset -- no other grass shader in the Sandbox

**Verdict Rationale:** Approved with **Default 3D** label. At $8 with 5/5 from 4 reviews, it is excellent value. The interactive grass feature is a memorable gameplay/visual touch. HOK's riverside and Elysian Fields areas are directly relevant.

**Project Relevance:** HOK (Elysian Fields grass bank -- HIGH), Cursed Fantasy (forest environments -- HIGH), A Quokka Story (outdoor environments -- HIGH).

---

## ENTRY-198: LCD Shader (OccaSoftware)

| Field | Value |
|-------|-------|
| **Asset** | LCD Shader - Pixel and Moire Shader for Objects with Shader Graph |
| **Publisher** | OccaSoftware |
| **Source** | Packages/ UPM (`com.occasoftware.lcd-shader`) |
| **Version** | 2.0.0 |
| **Price** | $6.00 |
| **Category** | Shaders |
| **Rating** | 5/5 (4 ratings) |
| **Session** | 40 |
| **Verdict** | Approved |
| **Label** | -- |
| **CSV ID** | ForeignId 259945 |

**What It Is:** Shader for simulating LCD pixel grids and moire patterns on in-world surfaces (monitors, screens, arcade cabinets, kiosks). Makes flat surfaces look like actual displays with visible pixel substructure.

**Package:** `Packages/com.occasoftware.lcd-shader/`

**Scale:** 2 scripts, 2 asmdefs, 1 Shader Graph.

**Key Components:**
- `LCDShaderGUI` -- custom material inspector
- `AutoPlayVideo` (MonoBehaviour) -- automatically plays a video texture on the LCD material surface

**Key Feature:** `AutoPlayVideo` integration -- pair a VideoPlayer with the LCD shader to show video content (cutscenes, environment screens, retro arcade screens) through a realistic pixel grid filter.

**Concerns:**
- Very niche use case -- specifically for rendering "screen-looking" surfaces

**Verdict Rationale:** Approved with **Default 3D** label. At $6 with 5/5 from 4 reviews, it is cheap and clearly delivers. The `AutoPlayVideo` + LCD shader combination is immediately useful for any environment with screens, monitors, or arcade machines. Relevant for Alpha Foxtrot Uniform (military command screens), FearSteez (retro arcade environment props).

**Project Relevance:** Alpha Foxtrot Uniform (command screens, monitors -- HIGH), FearSteez (arcade/bar environment props -- MEDIUM), Cursed Fantasy (magical crystal displays -- LOW-MEDIUM).

---

## ENTRY-199: Wireframe Shader (OccaSoftware)

| Field | Value |
|-------|-------|
| **Asset** | Wireframe Shader for Unity URP |
| **Publisher** | OccaSoftware |
| **Source** | Packages/ UPM (`com.occasoftware.wireframe-shader`) |
| **Version** | 2.0.2 |
| **Price** | $14.00 |
| **Category** | Shaders |
| **Rating** | 1/5 (3 ratings) |
| **Session** | 40 |
| **Verdict** | Conditional |
| **Label** | -- |
| **CSV ID** | ForeignId 279711 |

**What It Is:** Wireframe overlay shader for URP. Renders mesh edges as visible lines, either as a pure wireframe or as a wireframe overlay on top of the normal material. Uses geometry shader or barycentric coordinates technique.

**Package:** `Packages/com.occasoftware.wireframe-shader/`

**Scale:** 6 scripts, 4 asmdefs, 3 shaders.

**Asmdefs:** `OccaSoftware.Wireframe.Runtime`, `OccaSoftware.Wireframe.Editor`, `OccaSoftware.Wireframe.Shaders`, `OccaSoftware.Wireframe.Demo`.

**Key Components:**
- `MakeWireframe` (MonoBehaviour) -- applies wireframe preprocessing to a mesh
- `CreateWireframeMesh` -- Editor utility to bake wireframe-ready mesh
- `WireframeMaterialEditorGUI` -- custom inspector
- `Rendering` -- internal rendering pass
- `Turntable` -- demo rotation script

**Concerns:**
- 1/5 rating from 3 reviews -- significant red flag. Investigate before use.
- May require mesh preprocessing (baking barycentric coordinates), which adds workflow steps
- `MakeWireframe` + `CreateWireframeMesh` suggest mesh must be pre-processed -- not a simple material swap

**Verdict Rationale:** Conditional. The 1/5 rating demands investigation. Could be a Unity version compatibility issue, geometry shader limitations on mobile, or workflow friction with the mesh baking step. Test before use. No label until validated.

**Project Relevance:** Debug visualization, sci-fi/hologram aesthetics -- LOW-MEDIUM. No current project has strong need.

---

## ENTRY-200: Outline Objects (OccaSoftware)

| Field | Value |
|-------|-------|
| **Asset** | Outline Objects - Quick Outlines for Meshes in URP |
| **Publisher** | OccaSoftware |
| **Source** | Packages/ UPM (`com.occasoftware.outline-objects`) |
| **Version** | 3.1.18 |
| **Price** | $8.00 |
| **Category** | Shaders |
| **Rating** | 4/5 (6 ratings) |
| **Session** | 40 |
| **Verdict** | Approved |
| **Label** | Recommended |
| **CSV ID** | ForeignId 215454 |

**What It Is:** Per-mesh stencil outline system for URP. Add an outline to specific objects by attaching a component and choosing outline color and thickness. Selective (only outlines meshes with the component), unlike the post-process approach.

**Package:** `Packages/com.occasoftware.outline-objects/`

**Scale:** 5 scripts, 3 asmdefs, 2 shaders.

**Asmdefs:** `OccaSoftware.OutlineObjects.Runtime`, `OccaSoftware.OutlineObjects.Editor`, `OccaSoftware.OutlineObjects.Demo`.

**Key Components:**
- `SmoothNormals` (MonoBehaviour) -- pre-processes mesh normals for clean outline rendering (eliminates hard-edge seams in outlines)
- `SmoothNormalsWindow` (Editor) -- batch normal smoothing for selected assets
- `OutlineObjectsShaderGUI` -- custom material inspector
- `GenerateNormals` -- normal generation utility
- `FloatAndSpin` -- demo bobbing animation

**Key Feature:** `SmoothNormals` bakes smoothed normals into mesh tangents so outline width is consistent across hard edges. This is the correct technique for high-quality mesh outlines (required for characters with hard normals).

**vs Outlines Post-Process (191):**
- Outline Objects: selective per-mesh, custom color per object, requires component, works well for item highlights
- Outlines Post-Process: uniform full-scene, zero per-object setup, better for full toon look

**Verdict Rationale:** Approved with **Default 3D** label. The `SmoothNormals` preprocessing is a strong technical differentiator -- most outline systems produce seam artifacts on hard-edged meshes; this one does not. At $8 it is excellent value. Use for interactive object highlights (quest items, interactables, selected units).

**Project Relevance:** HOK (highlighted interactive objects -- HIGH), FearSteez (highlighted enemies -- MEDIUM), all 3D games with interactable item indication -- HIGH.

---

## ENTRY-201: Deep Surfaces (OccaSoftware)

| Field | Value |
|-------|-------|
| **Asset** | Deep Surfaces Shader Volumetric Ice Crystal and Gem Effects for Unity |
| **Publisher** | OccaSoftware |
| **Source** | Packages/ UPM (`com.occasoftware.deep-surfaces`) |
| **Version** | 0.1.0 |
| **Price** | $6.00 |
| **Category** | Shaders / Substances |
| **Rating** | 0/5 (0 ratings) |
| **Session** | 40 |
| **Verdict** | Approved |
| **Label** | -- |
| **CSV ID** | ForeignId 285832 |

**What It Is:** Volumetric parallax shader for gemstones, ice, crystals, and translucent mineral surfaces. Simulates visual depth inside a surface without actual geometry -- layers appear to exist below the surface plane.

**Package:** `Packages/com.occasoftware.deep-surfaces/`

**Scale:** 1 script, 1 asmdef, 1 shader.

**Key Components:**
- `LightBinding` (MonoBehaviour) -- binds a light source to the shader for dynamic specular sparkle response

**Verdict Rationale:** Approved with **Default 3D** label. At $6 with a single-script lean implementation, this is zero-risk to keep. Gem and crystal rendering is a common fantasy/RPG asset need. The `LightBinding` component for dynamic sparkle is a smart touch.

**Project Relevance:** Cursed Fantasy (gems, magical crystals -- HIGH), HOK (Charon's ferrying gems, underworld minerals -- MEDIUM), all fantasy 3D projects.

---

## ENTRY-202: VFX Library (OccaSoftware)

| Field | Value |
|-------|-------|
| **Asset** | VFX Library - Environmental and Ambient FX Collection |
| **Publisher** | OccaSoftware |
| **Source** | Packages/ UPM (`com.occasoftware.vfx-library`) |
| **Version** | 3.0.0 |
| **Price** | $15.00 |
| **Category** | Particle Systems / Water |
| **Rating** | 0/5 (2 ratings) |
| **Session** | 40 |
| **Verdict** | Approved |
| **Label** | Recommended |
| **CSV ID** | ForeignId 209648 |

**What It Is:** Collection of environmental ambient VFX using Unity's VFX Graph. Prefab effects for fireflies, dust motes, floating particles, leaf fall, snowflakes, embers, and similar ambient atmospheric particles.

**Package:** `Packages/com.occasoftware.vfx-library/`

**Scale:** 2 scripts, 1 asmdef (Demo only), VFX folder, VFX Subgraph Blocks, VFX Subgraph Operators.

**Key Content (from folder structure):**
- `VFX/` -- VFX Graph effect assets
- `VFX Subgraph Blocks/` -- reusable VFX subgraph building blocks
- `VFX Subgraph Operators/` -- reusable operator nodes
- `Prefabs/`, `Materials/`, `Meshes/`, `Textures/` -- supporting assets

**Notes:**
- Uses VFX Graph (same dependency as Altos)
- Subgraph architecture means the included blocks can be used in your own VFX Graph effects -- not just consuming the included prefabs

**Overlap Analysis:**
- **Complements Responsive Smokes (171)** -- Smokes handles reactive combat/explosion VFX, VFX Library handles ambient environmental FX. Together = full environmental VFX coverage.
- **VFX Graph subgraphs** are bonus value -- reusable building blocks for custom VFX

**Verdict Rationale:** Approved with **Default 3D** label. Ambient environmental particles are needed in virtually every 3D game. Fireflies for forests, dust for caves, embers for fires -- these make scenes feel alive. At $15 the value is solid. The VFX subgraph blocks are a meaningful technical bonus.

**Project Relevance:** HOK (Acheron embers, river mist particles -- VERY HIGH), Cursed Fantasy (dungeon dust, cave drips -- HIGH), all outdoor/atmospheric 3D environments.

---

## ENTRY-203: Ballistics (OccaSoftware)

| Field | Value |
|-------|-------|
| **Asset** | Ballistics - Physically-Based Bullet Drop and Projectile Framework |
| **Publisher** | OccaSoftware |
| **Source** | Packages/ UPM (`com.occasoftware.ballistics`) |
| **Version** | 2.0.0 |
| **Price** | $0 (FREE) |
| **Category** | Scripting / Physics |
| **Rating** | 0/5 (2 ratings) |
| **Session** | 40 |
| **Verdict** | Approved |
| **Label** | -- |
| **CSV ID** | ForeignId 220232 |

**What It Is:** Physics-based projectile framework with realistic bullet drop, aerodynamic drag, and ballistic arc calculation. ScriptableObject-driven configuration for projectile types and environment conditions.

**Package:** `Packages/com.occasoftware.ballistics/`

**Scale:** 13 scripts, 3 asmdefs.

**Asmdefs:** `OccaSoftware.Ballistics.Runtime`, `OccaSoftware.Ballistics.Editor`, `OccaSoftware.Ballistics.Demo`.

**Key Components:**
- `BallisticsProjectile` (MonoBehaviour) -- attach to any projectile. Reads a `ProjectileSO` config for mass, drag, muzzle velocity.
- `BallisticsCore` -- physics simulation core (drag model, gravity integration, step function)
- `DragReferenceTables` -- aerodynamic drag coefficient lookup tables (G1/G7 ballistic models)
- `EnvironmentSO` (ScriptableObject) -- defines air density, gravity, wind for a scene zone
- `ProjectileSO` (ScriptableObject) -- defines projectile properties (mass, sectional density, ballistic coefficient)
- `SimulationConfigSO` (ScriptableObject) -- simulation quality settings (step size, max range)
- `BallisticsPerformanceDemo` -- demo performance benchmark

**Architecture Highlights:**
- Fully data-driven via ScriptableObjects -- define any number of projectile types and environment conditions as assets
- G1/G7 ballistic coefficient models -- industry-standard bullet drop calculations

**Overlap Analysis:**
- **Complements Responsive Smokes (171)** -- `InteractiveProjectile` in Smokes can be driven by Ballistics projectiles
- **Complements RayFire 2 (168)** -- Ballistics projectile impact → RayFire demolition trigger

**Verdict Rationale:** Approved with **Default 3D** label. Free, ScriptableObject-driven, data-table ballistic models. The G1/G7 drag models go beyond simple arc math and provide realistic behavior for sniper shots, thrown objects, and artillery. Zero cost, clean architecture. Claude can configure projectile types entirely via SO creation.

**Project Relevance:** Alpha Foxtrot Uniform (shooter -- VERY HIGH), FearSteez (thrown weapons -- MEDIUM), Necro Ricochet (projectile mechanics -- HIGH).

---

## ENTRY-204: Orbit Camera (OccaSoftware)

| Field | Value |
|-------|-------|
| **Asset** | Orbit Camera Controller |
| **Publisher** | OccaSoftware |
| **Source** | Packages/ UPM (`com.occasoftware.orbit-camera`) |
| **Version** | 0.1.2 |
| **Price** | $5.00 |
| **Category** | Scripting / Camera |
| **Rating** | 0/5 (2 ratings) |
| **Session** | 40 |
| **Verdict** | Conditional |
| **Label** | -- |
| **CSV ID** | ForeignId 285834 |

**What It Is:** Simple orbit/inspection camera controller. Rotate around a target point, zoom in/out. All render pipeline support (URP, HDRP, Built-in).

**Package:** `Packages/com.occasoftware.orbit-camera/`

**Scale:** 1 script (`OrbitCamera.cs`), 1 asmdef.

**Verdict Rationale:** Conditional. A single-script orbit camera at $5. Cinemachine can replicate this behavior with more control. Keep for simple item inspection UIs or demos where Cinemachine is overkill. No label.

---

## ENTRY-205: Free Fly Camera (OccaSoftware)

| Field | Value |
|-------|-------|
| **Asset** | Free Fly Camera Drone and Fly Camera Controls for Unity |
| **Publisher** | OccaSoftware |
| **Source** | Packages/ UPM (`com.occasoftware.free-fly-camera`) |
| **Version** | 0.1.0 |
| **Price** | $11.00 |
| **Category** | Scripting / Camera |
| **Rating** | 0/5 (1 rating) |
| **Session** | 40 |
| **Verdict** | Conditional |
| **Label** | -- |
| **CSV ID** | ForeignId 285828 |

**What It Is:** Drone-style free-fly camera controller using Unity Input System. Move in any direction, control speed, smooth acceleration. All render pipeline support.

**Package:** `Packages/com.occasoftware.free-fly-camera/`

**Scale:** 1 script (`FreeFlyCamera.cs`), 1 asmdef.

**Depends on:** `com.unity.inputsystem 1.5.1` (New Input System).

**Verdict Rationale:** Conditional. Single-script fly camera at $11 -- overpriced for what it is. Useful for debug fly-through or cinematics, but `FreeCamera` in the Altos demo package and Unity's Cinemachine both cover this use case. Keep for convenience but no label.

---

## ENTRY-206: Ninja Profiler (OccaSoftware)

| Field | Value |
|-------|-------|
| **Asset** | Ninja Profiler |
| **Publisher** | OccaSoftware |
| **Source** | Packages/ UPM (`com.occasoftware.ninja`) |
| **Version** | 1.1.0 |
| **Price** | $0 (FREE) |
| **Category** | Editor Extensions / Utilities |
| **Rating** | 0/5 (2 ratings) |
| **Session** | 40 |
| **Verdict** | Approved |
| **Label** | Default |
| **CSV ID** | ForeignId 249140 |

**What It Is:** Lightweight runtime performance overlay. Displays FPS, memory usage, and draw call count as an on-screen HUD during play mode. Minimal setup -- add the `Ninja` MonoBehaviour to any persistent GameObject.

**Package:** `Packages/com.occasoftware.ninja/`

**Scale:** 1 script (`Ninja.cs`), 1 asmdef. No samples folder.

**Key Component:** `Ninja` (MonoBehaviour) -- single component, displays overlay at runtime. Zero configuration.

**Concerns:**
- No samples folder -- no demo scene. Add the component manually.
- Zero configuration shown in docs suggests minimal customization options

**Overlap Analysis:**
- **Complements UDebug Panel (013)** -- UDebug is a full runtime debug system; Ninja is just performance numbers. Both can coexist; use Ninja for always-on lightweight perf monitoring, UDebug for interactive debugging sessions.

**Verdict Rationale:** Approved with **Default** label. Free, single-component, zero setup. Every project benefits from always-on FPS/memory/draw call monitoring during development. No reason not to include in every project's debug toolkit.

**Project Relevance:** All projects -- DEFAULT.

---

## ENTRY-207: Toolkit for Verlet Motion 2026 (Heathen Engineering)

| Field | Value |
|-------|-------|
| **Asset** | Toolkit for Verlet Motion 2026 |
| **Publisher** | Heathen Engineering |
| **Source** | Packages/ UPM (`com.heathen.verlet`) |
| **Version** | 5.0.0 |
| **Price** | Paid |
| **Category** | Physics / Simulation |
| **Session** | 40 |
| **Verdict** | Approved |
| **Label** | Recommended |

**What It Is:** Transform-chain cloth, rope, and chain simulation using time-corrected Verlet integration. Operates entirely on transforms -- no SkinnedMeshRenderer required. Works with any mesh attached to a transform chain. Supports 2D and 3D, pin constraints, spring elasticity (Hooke's Law), and hierarchical transform trees.

**Package:** `Packages/com.heathen.verlet/`

**Scale:** 17 scripts, 1 asmdef. Clean namespace `Heathen.Verlet`.

**Key Classes:**
- `Verlet` (static) -- `TimeCorrectedVerletIntegration()`, `ElasticityAcceleration()` core math
- `VerletTransforms` / `VerletTransforms2D` -- MonoBehaviour chain simulators
- `VerletTransformTree` -- branching chain structures (hair, antlers, multi-strand cloth)
- `VerletLine` -- simplified linear chain (rope, cable, tail)
- `VerletSystemPin` -- pin/anchor constraint component

**Architecture:** Static math utilities + MonoBehaviour wrappers. No Jobs/Burst dependency -- pure managed code on transforms.

**Concerns:**
- Transform-based (not SMR) -- correct for rigid chain links, stylized cloth, tails. Not for smooth skinned cloth where MagicaCloth 2 is better.
- No Burst/Jobs -- CPU-bound. Fine for typical counts (ropes, tails, hair strands). Scales poorly to 100+ independent chains.

**Overlap Analysis:**
- **vs MagicaCloth 2 (ENTRY-095):** Different approach. MagicaCloth = Jobs/Burst + SMR skinned cloth. Heathen Verlet = managed transforms. Use Verlet for chain links, rigid jewelry, tails; MagicaCloth for fabric, garment cloth.
- **vs MegaShapes rope (ENTRY-137):** Both are Verlet-based. MegaShapes uses mesh deformation; Heathen Verlet uses raw transforms. Complements rather than replaces -- Heathen is better for game objects, MegaShapes for rendered rope meshes.
- **vs Full Rig ropes (ENTRY-TBD):** Full Rig = catenary (analytical/static). Heathen Verlet = dynamic simulation. Not competing -- Full Rig for static rigging, Heathen for interactive simulation.

**Verdict Rationale:** Approved with **Default 3D** label. Unity has no built-in transform-chain physics. Heathen Verlet fills a genuine gap: game-ready rope/chain/tail/hair simulation for any 3D project. Free of MagicaCloth's SMR requirement, so usable on rigid bodies (chains, pendulums, tail fins). Clean API, Unity 6 native, good 2D support.

**Project Relevance:** HOK (Kharon's chains, dangling objects), FearSteez (weapon chains, whips), any 3D project with dangling or swinging game objects.

---

## ENTRY-208: Toolkit for Ballistics 2026 (Heathen Engineering)

| Field | Value |
|-------|-------|
| **Asset** | Toolkit for Ballistics 2026 |
| **Publisher** | Heathen Engineering |
| **Source** | Packages/ UPM (`com.heathen.ballistics`) |
| **Version** | 5.0.0 |
| **Price** | Paid |
| **Category** | Scripting / Physics |
| **Session** | 40 |
| **Verdict** | Approved |
| **Label** | Recommended |

**What It Is:** 2D and 3D projectile trajectory system. Solves ballistic arcs analytically -- given a launch point, target, and velocity, computes the correct angle to hit the target. Also handles path visualization (draw the arc before firing), targeting helpers, and trick shots.

**Package:** `Packages/com.heathen.ballistics/`

**Scale:** 27 scripts, 1 asmdef. Clean namespace `Heathen.Ballistics`.

**Key Classes:**
- `API.Ballistics` (static) -- main solver: `SolveAngle()`, `GetTrajectoryPoints()`, launch angle calculation
- `BallisticAim` / `BallisticAim2D` -- MonoBehaviour turret/cannon aiming component
- `BallisticPath` / `BallisticPath2D` -- trajectory arc visualization (LineRenderer)
- `BallisticTargeting` -- target acquisition and lead computation
- `TrickShot` -- multi-bounce / ricochet trajectory solver

**Architecture:** Static solver + MonoBehaviour wrappers. Analytical math -- no simulation, no iteration. Instant solution per frame.

**Overlap Analysis:**
- **vs OccaSoftware Ballistics (ENTRY-203):** Direct overlap. OccaSoftware Ballistics is also a projectile trajectory solver. Heathen adds 2D support, `TrickShot` ricochet solver, and the full `BallisticTargeting` lead system. Heathen is the stronger package -- more features, same domain. With OccaSoftware removed, no conflict.
- **vs Unity Physics:** Unity Physics has no built-in ballistic arc solver. This fills that gap entirely.

**Concerns:**
- Two Ballistics packages in ecosystem (OccaSoftware ENTRY-203 and this). OccaSoftware is now removed, so no conflict -- Heathen is the active ballistics system.

**Verdict Rationale:** Approved with **Default 3D** label. Any 3D game with projectiles (guns, grenades, arrows, fishing casting arc) benefits from an analytical arc solver. Heathen Ballistics is clean, Unity 6 native, and adds 2D + ricochet on top of what OccaSoftware offered. Replaces ENTRY-203 as the active ballistics package.

**Project Relevance:** HOK (fishing cast arc visualization), FearSteez (thrown weapons, projectiles), any 3D/2D action project.

---

## ENTRY-209: Toolkit for Unity Physics 2026 (Heathen Engineering)

| Field | Value |
|-------|-------|
| **Asset** | Toolkit for Unity Physics 2026 |
| **Publisher** | Heathen Engineering |
| **Source** | Packages/ UPM (`com.heathen.unityphysics`) |
| **Version** | 5.0.0 |
| **Price** | Paid |
| **Category** | Physics / Simulation |
| **Session** | 40 |
| **Verdict** | Approved |
| **Label** | Recommended |

**What It Is:** Extensions to Unity's built-in physics system covering three main domains: (1) buoyancy simulation, (2) force effect fields (gravity wells, wind zones, repulsion fields), and (3) breakable object destruction. Includes MIConvexHull library for runtime convex decomposition.

**Package:** `Packages/com.heathen.unityphysics/`

**Scale:** 62 scripts, 4 asmdefs (core + MIConvexHull + 2 support). Namespace `Heathen.UnityPhysics`.

**Key Classes:**
- `BuoyantBody` -- Rigidbody buoyancy component. Calculates displaced volume against a water surface, applies realistic upward force. Works with any water surface (flat plane or Staggart/SW3 wave displacement with adapter).
- `ForceEffect` / `ForceEffectField` / `ForceEffectReceiver` -- Configurable physics force zones. Modes: gravity well, radial repulsion, directional wind, vortex. Field defines the zone; receiver tags which objects respond.
- `GravityEffect` -- Per-object gravity override (low-gravity zones, upside-down gravity, zero-G).
- `AttractEffect` -- Magnetic/gravitational pull between specific objects.
- `Breakable` -- Destroys a mesh into fragments on impact. Uses MIConvexHull for runtime convex hulls on fragments.

**Architecture:** MonoBehaviour components -- no special setup, attach and configure. 4 asmdefs cleanly separate MIConvexHull (third-party math lib) from Heathen's own code.

**Integration Notes:**
- `BuoyantBody` works with any flat water plane by default; can be extended to sample wave height from SW3's water system.
- `ForceEffectField` + `ForceEffectReceiver` pair cleanly with any physics object -- no SDK coupling.

**Overlap Analysis:**
- **vs Unity built-in:** Unity has no buoyancy, no force fields, no breakable destruction built in. This fills three separate gaps with one package.
- **vs Staggart Water (SW3, ENTRY-039):** No overlap -- `BuoyantBody` complements SW3. SW3 provides the surface; BuoyantBody makes objects float on it.
- **vs Destructive Physics (if evaluated):** `Breakable` component is a lightweight destruction system. Full destruction suites (e.g., Rayfire) are much heavier. Use Heathen's `Breakable` for simple breakables; evaluate Rayfire for complex destruction simulations.

**Verdict Rationale:** Approved with **Default 3D** label. Three genuinely missing Unity physics features in one package (buoyancy, force fields, destruction). Unity 6 native, clean component architecture, no setup friction. Buoyancy alone is worth the label for HOK (Kharon's raft, debris, fish floats). Force fields cover every 2D/3D physics game that needs hazard zones or environmental forces.

**Project Relevance:** HOK (raft buoyancy, river current force field), FearSteez (wind zones, arena hazards), any 3D project with water or physics interactions.

---

## ENTRY-210: Toolkit for Steamworks 2026 (Heathen Engineering)

| Field | Value |
|-------|-------|
| **Asset** | Toolkit for Steamworks 2026 |
| **Publisher** | Heathen Engineering |
| **Source** | Packages/ UPM (`com.heathen.steamworks`) |
| **Version** | 5.1.15 |
| **Price** | Paid |
| **Category** | Scripting / Platform Integration |
| **Session** | 40 |
| **Verdict** | Approved |
| **Label** | Recommended |
| **Dependency** | `com.rlabrecque.steamworks.net` v20.2.0 (OpenUPM) |

**What It Is:** Full-featured Unity wrapper around Valve's Steamworks SDK. Covers the entire Steam platform API: app init, achievements, stats, leaderboards, cloud saves, lobbies, matchmaking, peer-to-peer networking, Workshop, Inventory, Steam Input, and the Steam overlay. Built on top of Steamworks.NET (the low-level C# binding).

**Package:** `Packages/com.heathen.steamworks/`

**Scale:** 303 scripts, 3 asmdefs. Huge -- largest Heathen package by far. Includes 11 UI prefabs (lobby list, friend list, achievement popup, etc.) and 11 example scenes.

**Key Classes / API:**
- `SteamworksFoundationManager` -- MonoBehaviour that boots the Steam SDK. Must be in scene.
- `API.SteamworksApp` (static) -- App-level: init, overlay, DLC, beta info
- `API.StatsAndAchievements` -- Achievements: `SetAchievement()`, `IndicateAchievementProgress()`, stat tracking
- `API.Leaderboards` -- Create, query, upload scores
- `API.RemoteStorage` -- Steam Cloud save/load
- `API.Lobbies` -- Create/join/list lobbies, lobby metadata, lobby chat
- `API.Matchmaking` -- Match sessions, server browser
- `API.SteamInput` -- Controller/gamepad input mapping through Steam's input overlay
- `API.Inventory` -- Steam item inventory, trading
- `API.Workshop` -- UGC workshop items, upload/download

**Architecture:** `SteamworksFoundationManager` (singleton MonoBehaviour) initializes the Steam context. All other systems are static `API.*` classes. Mirrors Heathen's pattern across all packages. UI prefabs use uGUI (compatible with ENTRY-131 UX Toolkit).

**Dependencies:** `com.rlabrecque.steamworks.net` 20.2.0 (Steamworks.NET -- already installed in manifest.json as of this session).

**Concerns:**
- Steam requires the app to be running through Steam client (or via `steam_appid.txt` during dev). Never runs standalone without Steam.
- 303 scripts is large -- expect non-trivial compile time addition. However, asmdefs isolate it.
- Lobby/P2P systems require Steamworks.NET callbacks -- must be handled in the Unity main thread.

**Verdict Rationale:** Approved with **Default** label. Every TecVooDoo game that ships on Steam needs Steamworks integration. This is the most comprehensive Unity-Steamworks solution available -- 5+ years of active development, 303 scripts covering every API surface, pre-built UI prefabs. The `Default` label means it goes in every project targeting Steam. Heathen's clean `API.*` static pattern makes it maintainable alongside other systems.

**Project Relevance:** ALL projects targeting Steam release -- HOK, FearSteez, Shrunken Head Toss, etc.

---

## ENTRY-211: Toolkit for Discord Social Preview (Heathen Engineering)

| Field | Value |
|-------|-------|
| **Asset** | Toolkit for Discord Social Preview |
| **Publisher** | Heathen Engineering |
| **Source** | Packages/ UPM (`com.heathen.discordsocial`) |
| **Version** | 0.2.0 |
| **Price** | Paid |
| **Category** | Scripting / Platform Integration |
| **Session** | 40 |
| **Verdict** | Conditional |
| **Label** | -- |
| **Dependency** | `com.rlabrecque.steamworks.net` v20.2.0 (OpenUPM) |

**What It Is:** Unity wrapper for Discord's Game SDK social features. Covers rich presence (Discord activity status), lobbies, user profiles, and OAuth2 authentication within a Unity game. Provides uGUI prefabs for Discord user display and lobby UI.

**Package:** `Packages/com.heathen.discordsocial/`

**Scale:** 19 scripts, 2 asmdefs. Namespace `Heathen.DiscordSocial`. Smallest Heathen package.

**Key Classes:**
- `DiscordSocialSettings` (ScriptableObject) -- App credentials, OAuth config
- `API.DiscordSocialApp` (static) -- Init/shutdown, activity (rich presence)
- `API.Lobbies` -- Discord lobby create/join (separate from Steam lobbies)
- `API.Users` -- User profile queries, relationship data

**Architecture:** Follows Heathen's `API.*` static pattern. `DiscordSocialSettings` SO holds app ID and OAuth secrets (must be configured per-project). 2 asmdefs.

**Concerns:**
- **Preview (v0.2.0)** -- Pre-release status. API may break between updates. Not production-ready.
- Discord's Game SDK has had an uncertain future since Discord deprecated their GameSDK v1 in 2023. Verify Discord's current SDK status before committing to this integration path.
- Requires a registered Discord Application (developer.discord.com) with a valid App ID -- per-project setup required.
- "Requires Steamworks.NET" as a dependency is odd for a Discord integration -- likely a Heathen package dependency artifact, not a functional requirement.

**Verdict Rationale:** Conditional. Discord social layer (rich presence, Discord lobbies) is a nice-to-have for multiplayer or community-driven games. But the preview status, uncertain Discord SDK support direction, and per-project OAuth setup overhead make this a case-by-case decision. Not a **Default** -- only worth adding when a specific project targets Discord-active audiences. Re-evaluate when v1.0 ships.

**Project Relevance:** Low for current portfolio. HOK is single-player; FearSteez and Shrunken Head Toss have no Discord-specific need. May be relevant for any future multiplayer title.

---

## ENTRY-212: UX Flat Icons [Free] (Heathen Engineering)

| Field | Value |
|-------|-------|
| **Asset** | UX Flat Icons [Free] |
| **Publisher** | Heathen Engineering |
| **Source** | Asset Store (installed to `Assets/_Heathen Engineering/`) |
| **Version** | 5.0.0 |
| **Price** | $0 (FREE) |
| **Category** | Art / UI |
| **Session** | 40 |
| **Verdict** | Approved |
| **Label** | Recommended |

**What It Is:** 304 flat-design PNG icon sprites organized by category. Includes standard UI icons (arrows, checkmarks, settings gear, close/minimize/maximize, media controls, social logos, game controller glyphs) plus a set of corporate/brand logos. Designed to complement the Heathen UX Toolkit (ENTRY-131).

**Package:** `Assets/_Heathen Engineering/` (traditional Asset Store import)

**Scale:** 304 PNG textures. 1 asmdef (`HeathenEngineering.UX.asmdef`). No scripts -- art content only. Samples/ folder has example usage scenes.

**Overlap Analysis:**
- **Complements ENTRY-131 (UX 2026):** Heathen UX Toolkit's buttons/panels pair naturally with these icons. The icon set was clearly designed alongside the UX framework.
- **vs Unity built-in icons:** Unity 6 ships basic editor-only icons. These are runtime-ready UI sprites in a consistent flat style -- different use case.

**Concerns:**
- PNG format (not SVG) -- resolution-dependent. The included sizes cover most screen densities for mobile and desktop, but custom resolutions may need upscaling.
- 304 icons is not exhaustive -- check coverage for specific game genre needs (e.g., fishing-themed icons are unlikely here).

**Verdict Rationale:** Approved with **Default UI** label. Free, 304 consistent flat-style icons, ready to drop into any UI. Every project with a UI eventually needs icon assets. The flat style is versatile -- works in casual, utility, and stylized projects. No reason not to include in any uGUI or UI Toolkit project.

**Project Relevance:** All projects with UI. HOK (fishing HUD icons), FearSteez (character/ability icons), DLYH (keyboard/letter icons), SHT (game UI), etc.

---

## ENTRY-213: Toolkits for Unity Bundle 2026 (Heathen Engineering)

| Field | Value |
|-------|-------|
| **Asset** | Toolkits for Unity Bundle 2026 |
| **Publisher** | Heathen Engineering |
| **Source** | Asset Store (bundle purchase) |
| **Version** | N/A |
| **Price** | Paid (bundle) |
| **Category** | Bundle |
| **Session** | 40 |
| **Verdict** | Approved |
| **Label** | -- |

**What It Is:** Bundle purchase asset -- buying this on the Asset Store unlocks the individual Heathen Engineering toolkits as separate downloads/installs. The Asset Store package itself contains only a README explaining this. All actual content is in the individual packages (ENTRY-207 through ENTRY-212 and ENTRY-130, ENTRY-131).

**Package:** No code content. README only.

**Note:** Same pattern as OccaSoftware's Megapack (ENTRY-180). The bundle is a purchase mechanism, not a content package. Evaluate each Heathen toolkit individually via its own ENTRY.

**Individual Package Map:**
| Bundle Item | ENTRY | Verdict |
|-------------|-------|---------|
| Toolkit for On-Screen Keyboard 2026 | ENTRY-130 | Conditional |
| Toolkit for UX 2026 | ENTRY-131 | Approved |
| Toolkit for Verlet Motion 2026 | ENTRY-207 | Approved |
| Toolkit for Ballistics 2026 | ENTRY-208 | Approved |
| Toolkit for Unity Physics 2026 | ENTRY-209 | Approved |
| Toolkit for Steamworks 2026 | ENTRY-210 | Approved |
| Toolkit for Discord Social Preview | ENTRY-211 | Conditional |
| UX Flat Icons [Free] | ENTRY-212 | Approved |

**Verdict Rationale:** Approved as bundle. 6/8 individual packages are Approved; 2 are Conditional (On-Screen Keyboard, Discord Social). Strong engineering standards across all packages (Unity 6 native, consistent `API.*` pattern, clean namespaces). Heathen is a professional publisher with long release history and active maintenance.

---

## ENTRY-214: Dialogue System for Unity 2.2.66 (Pixel Crushers)

| Field | Value |
|-------|-------|
| **Asset** | Dialogue System for Unity |
| **Publisher** | Pixel Crushers |
| **Source** | Asset Store (`Assets/Plugins/Pixel Crushers/Dialogue System/`) |
| **Version** | 2.2.66 |
| **Price** | Paid |
| **Category** | Scripting / Narrative Framework |
| **Session** | 41 |
| **Verdict** | Approved |
| **Label** | Recommended |

**What It Is:** The industry-standard Unity dialogue and narrative system. Full conversation graph editor, Lua-based scripting, localization, quest tracking, save/load, NPC relationship variables, branching cutscenes. Integrates with virtually every major Unity asset (Cinemachine, TextMesh Pro, Final IK, Inventory systems, etc.).

**Package:** `Assets/Plugins/Pixel Crushers/Dialogue System/`

**Scale:** 727 C# scripts. No asmdef (Assembly-CSharp). 2 demo scenes.

**Key Classes:**
- `DialogueSystemController` -- main singleton manager. Add to scene to enable the system.
- `DialogueSystemEvents` -- UnityEvent hooks for conversation start/end, line spoken, quest changes
- `LuaConsole` -- runtime Lua REPL for debugging dialogue conditions
- `YarnCustomCommands` -- Yarn 2/3 dialogue format importer support
- `ExtraDatabases` -- runtime database loading for DLC/streaming content

**Architecture:** Data-driven. Conversations are assets (DialogueDatabase ScriptableObject). Lua conditions/scripts inline in dialogue nodes. Editor tool at `Tools > Pixel Crushers > Dialogue System`. Third-party integration scripts for 30+ assets included.

**Features:**
- Branching dialogue trees with conditions, scripts, and variables
- Quest system (active, success, failure states + tracking UI)
- NPC relationship/affinity variables
- Localization via CSV export/import
- Save/load system (works with SaveSystem package or manual)
- TextMesh Pro support (`TMP_PRESENT` scripting symbol)
- ChatMapper, Articy X, Yarn import
- CSV/Screenplay export for writers

**Concerns:**
- No asmdef -- compiles into Assembly-CSharp. Named asmdef projects that need to reference the dialogue system must add an explicit dependency or use a wrapper.
- 727 scripts is the largest single asset in the Sandbox by script count. Compile time is non-trivial.
- Lua knowledge required for non-trivial conditions and scripts.

**Overlap Analysis:**
- No other dialogue system evaluated. This is the standard -- no credible alternative in the Sandbox.

**Verdict Rationale:** Approved with **Default** label. Every TecVooDoo project with NPCs, narrative, or any character dialogue needs this. Pixel Crushers has maintained this asset for 10+ years with consistent updates. The breadth of integration support means it fits into any architecture. No project should reinvent a dialogue system when this exists.

**Project Relevance:** HOK (Charon NPC lines, ferryman flavor text), FearSteez (story beats, enemy dialogue), all Visual Novel concepts, GRIMMORPG, any NPC-containing game.

---

## ENTRY-215: Dialogue System Addon -- Procedural Dialogue 1.0.5 (Pixel Crushers)

| Field | Value |
|-------|-------|
| **Asset** | Dialogue System Addon for Procedural Dialogue |
| **Publisher** | Pixel Crushers |
| **Source** | Asset Store (`Assets/Plugins/Pixel Crushers/Dialogue System Addon for Procedural Dialogue/`) |
| **Version** | 1.0.5 |
| **Price** | Paid |
| **Category** | Scripting / Add-On |
| **Session** | 41 |
| **Verdict** | Approved |
| **Label** | -- |
| **Dependency** | Requires Dialogue System for Unity (ENTRY-214) |

**What It Is:** Add-on for Dialogue System that generates grammatically correct procedural text at runtime. Handles noun pluralization, verb conjugation, gendered grammar, and irregular word forms in English. Enables fully dynamic NPC lines ("You killed 3 wolves" vs "You killed 1 wolf", gendered pronouns, etc.).

**Package:** `Assets/Plugins/Pixel Crushers/Dialogue System Addon for Procedural Dialogue/`

**Scale:** 26 C# scripts. 1 demo scene. Data files: `Data/Resources/English/` (irregular nouns, irregular verbs, phonetic rule variants).

**Key Features:**
- Plural/singular noun resolution (irregular forms: goose/geese, etc.)
- Verb conjugation with irregular forms
- Gendered grammar support (v1.0.5, Dec 2025)
- Custom resource files for game-specific vocabulary
- Integrates via Dialogue System's Lua scripting layer

**Release History:**
- v1.0.5 (Dec 2025): Gendered grammars
- v1.0.4 (Sep 2025): Input System instructions
- v1.0.3 (Jun 2025): Custom resource files, Lua syntax fixes

**Overlap Analysis:**
- Extension of ENTRY-214 -- no standalone use. Only relevant when Dialogue System is in the project.

**Verdict Rationale:** Approved (no label -- dependency). Genuinely fills the gap of procedural grammar that Dialogue System's core doesn't handle. Any project with quantity-sensitive or gender-sensitive dialogue (inventory descriptions, kill counts, gendered NPC references) benefits from this. Modest cost for the polish it provides.

**Project Relevance:** HOK (fish count references: "caught 3 bass"), any RPG/narrative game with variable NPC dialogue.

---

## ENTRY-216: Ragdoll Animator 2 1.0.4.1 (FImpossible Creations)

| Field | Value |
|-------|-------|
| **Asset** | Ragdoll Animator 2 |
| **Publisher** | FImpossible Creations (Filip Moeglich) |
| **Source** | Asset Store (`Assets/FImpossible Creations/Plugins - Animating/Ragdoll Animator 2/`) |
| **Version** | 1.0.4.1 |
| **Price** | Paid |
| **Category** | Physics / Animation |
| **Session** | 41 |
| **Verdict** | Approved |
| **Label** | Recommended |

**What It Is:** Physically-animated ragdoll blending system. Unlike traditional ragdoll (full physics takeover on death), RA2 blends physics and animation continuously -- characters can stumble while still playing movement animations, recover from hits while ragdolling, or transition smoothly between animated and full-ragdoll states. Operates via a "dummy" physics skeleton driven by ConfigurableJoint chains.

**Package:** `Assets/FImpossible Creations/Plugins - Animating/Ragdoll Animator 2/`

**Scale:** 95 C# scripts. No asmdef. No bundled demo scenes (demos distributed as separate .unitypackage).

**Key Classes:**
- `RagdollAnimator2` (main component) -- attach to character root. Implements `IRagdollAnimator2HandlerOwner`.
- `RagdollChainBone` -- per-bone physics chain configuration
- `RagdollAnimator2Preset` (ScriptableObject) -- reusable ragdoll configurations
- `RA2PhysicallyAnimatedChain` -- chain-level physics controller
- `RA2SetJointConnectedBody` -- joint wiring utility

**Architecture:** "Dummy" skeleton -- a hidden physics clone tracks the visible animated skeleton. Physics influence blends onto the visual skeleton. 20+ extra feature modules (dismemberment, pose manipulator, auto-get-up, kinematic anchors, etc.).

**v1.0.4.1 Changes:** Adds Clay Beasts example; fixes `SetJointMatchingParameters` for Unity 6+.

**Concerns:**
- No bundled demo scenes -- must import separately from a .unitypackage.
- ConfigurableJoint-based physics adds CPU overhead proportional to character count.
- Requires proper ragdoll bone setup (colliders, joints) -- not zero-setup.

**Overlap Analysis:**
- **vs PuppetMaster (ENTRY-224):** Both are physics puppet systems but different scope. RA2 = blend between animation and ragdoll (hit reactions, stumbling, partial physics). PuppetMaster = full muscle puppet simulation (complex behavioral control, prop interaction, networked puppets). Use RA2 for hit reactions and death; use PuppetMaster for complex puppet behaviors. They can coexist.
- **vs Unity built-in ragdoll:** Unity's built-in ragdoll is all-or-nothing (full physics on death). RA2 adds the blend layer, partial physics, and recovery -- a genuine upgrade.

**Verdict Rationale:** Approved with **Default 3D** label. Any 3D game with characters that receive damage, stumble, or die benefits from physics-blended ragdoll. RA2's blend system gives hits weight and physicality without full ragdoll chaos. FImpossible Creations is a prolific, well-maintained publisher with a strong asset ecosystem.

**Project Relevance:** HOK (Charon stumbling on waves, fish flapping on deck), FearSteez (hit reactions, knockdowns), any 3D action/combat game.

---

## ENTRY-217: F Texture Tools 1.1.5 (FImpossible Creations)

| Field | Value |
|-------|-------|
| **Asset** | F Texture Tools |
| **Publisher** | FImpossible Creations (Filip Moeglich) |
| **Source** | Asset Store (`Assets/FImpossible Creations/Editor/Editor Tools/F Texture Tools/`) |
| **Version** | 1.1.5 |
| **Price** | Paid |
| **Category** | Editor Tool / Texture Processing |
| **Session** | 41 |
| **Verdict** | Approved |
| **Label** | Default |

**What It Is:** Suite of 9 texture processing windows built directly into the Unity Editor. Covers the most common texture workflow tasks: resizing, channel packing, seamless generation, normal map creation, color replacement, equalization, and blending -- all without leaving Unity.

**Package:** `Assets/FImpossible Creations/Editor/Editor Tools/F Texture Tools/`

**Scale:** 18 C# scripts (editor-only). Namespace `FIMSpace.FTextureTools`. No asmdef. No demo scenes.

**Tool Windows (all via context menu `FImpossible Creations > Texture Tools > ...`):**
- `FQuickResizeWindow` -- fast power-of-two scaling
- `FResizeWindow` -- advanced scaling with filter options
- `FSeamlessWindow` -- seamless tiling via edge stamping
- `FTexEqualizeWindow` -- dark/overexposed area correction
- `FColorReplacerWindow` -- hue/saturation selective replacement
- `FNormalToolWindow` -- normal map generation, DX/OpenGL format conversion
- `FBlendToolWindow` -- texture and normal map blending
- `FChannelledGenerator` -- RGBA channel composition (like Texture Channel Packer ENTRY-178, but built-in here)
- `FChannelInserter` -- embed a channel into an existing texture

**Supported Formats:** .jpg, .png, .exr, .tga

**Overlap Analysis:**
- **vs Texture Channel Packer (ENTRY-178):** Both do RGBA channel composition. ENTRY-178 is a dedicated channel packer; F Texture Tools includes it as one of 9 tools. F Texture Tools is more comprehensive overall but the channel packer in ENTRY-178 may have more options. Both can coexist.

**Verdict Rationale:** Approved with **Default** label. Any project that deals with textures (all of them) benefits from having resize, seamless gen, normal map, and channel packing directly in the editor. Free alternative to external tools like Photoshop plugins or Substance for these specific operations. `FExtensibleProcessWindow` base class allows custom tools to be built on the same framework.

**Project Relevance:** All projects -- DEFAULT.

---

## ENTRY-218: Ground Fitter 1.2.2 (FImpossible Creations)

| Field | Value |
|-------|-------|
| **Asset** | Ground Fitter |
| **Publisher** | FImpossible Creations (Filip Moeglich) |
| **Source** | Asset Store (`Assets/FImpossible Creations/Plugins - Animating/Ground Fitter/`) |
| **Version** | 1.2.2 |
| **Price** | Paid |
| **Category** | Scripting / Animation |
| **Session** | 41 |
| **Verdict** | Approved |
| **Label** | -- |

**What It Is:** Dynamic terrain slope alignment system. Rotates a character (or any object) to match the ground surface beneath it in real time using raycasts. Supports character controllers, root motion, NavMesh agents, and direct transform control. Goes beyond a simple "tilt to slope" -- uses a ZoneCast (X-pattern multi-ray) for averaged surface normal to prevent jitter on rough terrain.

**Package:** `Assets/FImpossible Creations/Plugins - Animating/Ground Fitter/`

**Scale:** 15 C# scripts. Namespace `FIMSpace.GroundFitter`. No asmdef. 3 demo scenes (NavMesh, patrolling).

**Key Components:**
- `FGroundFitter` -- main component, full configuration
- `FSimpleFitter` -- minimal single-component variant for quick setup
- `FGroundRotator` -- bone-rotation-only variant (v1.2.2), for adjusting specific bones rather than the whole character
- `FGroundFitter_Input` / `FGroundFitter_Movement` / `FGroundFitter_MovementLook` -- locomotion add-ons
- `FGroundFitter_RootMotionHelper` -- root motion integration

**Configuration Options:**
- ZoneCast width and ray count
- Rotation limits (forward tilt, side tilt, Y-axis correction)
- Smoothing speed
- Gravity mode
- Forward/sideways/diagonal movement handling

**Overlap Analysis:**
- Unity has no built-in slope alignment. This fills a genuine gap.
- **vs manual IK foot placement (Final IK, etc.):** Ground Fitter aligns the whole body to terrain; IK foot placement corrects individual feet. Complementary -- Ground Fitter handles the body lean, IK handles the feet. Both can run simultaneously.

**Verdict Rationale:** Approved with **Default 3D** label. Every 3D game with characters moving on uneven terrain (hills, stairs, slopes) needs slope alignment. Manual solutions are boilerplate; Ground Fitter handles it cleanly with demo-proven setups. The `FGroundRotator` bone-level variant (v1.2.2) is particularly useful for partial-body alignment (tail fins, vehicle suspension).

**Project Relevance:** HOK (Charon tilting with raft pitch/roll on river), FearSteez (characters on sloped terrain), any 3D game with non-flat ground.

---

## ENTRY-219: FS Melee Combat System 2.0.6 (Fantacode Studios)

| Field | Value |
|-------|-------|
| **Asset** | FS Melee Combat System |
| **Publisher** | Fantacode Studios |
| **Source** | Asset Store (`Assets/Fantacode Studios/Melee Combat System/`) |
| **Version** | 2.0.6 |
| **Price** | Paid |
| **Category** | Scripting / Combat Framework |
| **Session** | 41 |
| **Verdict** | Approved |
| **Label** | -- |

**What It Is:** Third-person melee combat framework. Combo system, AI opponents, blocking, hit reactions, cover, and animator integration. Ships as a complete working system -- add to a character to get functional close-quarters combat with combos, AI, and UI.

**Package:** `Assets/Fantacode Studios/Melee Combat System/`

**Scale:** 33 C# scripts (melee-specific). Namespace `FS_CombatCore`. No asmdef. 4 demo scenes (Main, Sword, AI vs AI, Powerful Enemy). Shared dependencies: Combat Core (19 scripts) + Third Person Controller (106 scripts) + CoverSystem (14 scripts).

**Key Classes:**
- `FighterCore` -- primary combat state machine
- `CombatAIController` / `CombatAIManager` -- opponent AI
- `CombatInputManager` -- New Input System bindings
- `ReactionsData` / `DeathReactionsData` / `CombatHitData` (ScriptableObjects) -- data-driven hit/death configuration

**Architecture:** Built on Fantacode's shared `FS_Core` + `FS_ThirdPerson` base. All three Fantacode combat systems (Melee, Shooter, Rope) share this base, meaning switching from one to another is additive rather than conflicting.

**Overlap Analysis:**
- **vs Beat Em Up Template (ENTRY-166):** ENTRY-166 is a complete game template with hardcoded logic. FS Melee is a clean, modular component system. For FearSteez: don't fork ENTRY-166 -- use FS Melee as the combat framework and cherry-pick ENTRY-166 tuning values (speeds, hitbox timings). ENTRY-166 is reference; FS Melee is the build foundation.
- **FS Shooter (ENTRY-221) explicitly integrates with this** -- `FS_CombatCore` namespace is a direct dependency of the Shooter system. Melee + Shooter can coexist on one character.

**Verdict Rationale:** Approved with **Default 3D** label. Any 3D action game needs a melee foundation. Clean namespace, modular design, New Input System, 4 demo scenes, AI opponents included. Superior to rolling a custom combat system for any game that isn't combat-design-first.

**Project Relevance:** FearSteez (PRIMARY -- the beat em up combat foundation), any 3D action/adventure project.

---

## ENTRY-220: FS Rope Swinging System 1.2.4 (Fantacode Studios)

| Field | Value |
|-------|-------|
| **Asset** | FS Rope Swinging System |
| **Publisher** | Fantacode Studios |
| **Source** | Asset Store (`Assets/Fantacode Studios/Rope Swinging System/`) |
| **Version** | 1.2.4 |
| **Price** | Paid |
| **Category** | Scripting / Character Movement |
| **Session** | 41 |
| **Verdict** | Approved |
| **Label** | -- |

**What It Is:** Grapple hook and rope swinging movement system for third-person characters. Extend a hook to a surface, swing through the air, release and fly. Built on Fantacode's shared FS_Core + FS_ThirdPerson base, so it layers cleanly onto any project already using FS Melee or FS Shooter.

**Package:** `Assets/Fantacode Studios/Rope Swinging System/`

**Scale:** 12 C# scripts. Namespace `FS_SwingSystem`. No asmdef. 1 demo scene. Shared base: Combat Core + Third Person Controller.

**Key Classes:**
- `SwingHookObject` -- the grapple hook projectile/attachment
- `SwingHookItem` -- equipment/inventory item wrapper (uses EquippableItem pattern)

**Architecture:** Item/equipment design. The hook is an equippable item, which integrates with Fantacode's item system shared across all three combat packages.

**Overlap Analysis:**
- **vs Heathen Verlet (ENTRY-207):** Verlet is rope simulation (physics chain); FS Rope is a gameplay movement mechanic (grapple + swing). No overlap -- different purposes.
- Complements FS Melee and FS Shooter -- all three share the same base and can be used together in one project.

**Verdict Rationale:** Approved (no label -- niche mechanic). Rope swinging is not a universal game mechanic, so no Default label. But for any platformer, action game with vertical traversal, or Spiderman-style game, this is ready-made. The Fantacode ecosystem coherence makes it easy to add alongside Melee/Shooter.

**Project Relevance:** Low for current portfolio (no rope-swing games planned). High if any future platformer/action-adventure game gets greenlit.

---

## ENTRY-221: FS Shooter System 1.2 (Fantacode Studios)

| Field | Value |
|-------|-------|
| **Asset** | FS Shooter System |
| **Publisher** | Fantacode Studios |
| **Source** | Asset Store (`Assets/Fantacode Studios/Shooter System/`) |
| **Version** | 1.2 |
| **Price** | Paid |
| **Category** | Scripting / Combat Framework |
| **Session** | 41 |
| **Verdict** | Approved |
| **Label** | -- |

**What It Is:** Third- and first-person shooter framework. Weapon equip/fire/reload, cover mechanics, AI, and full first-person support. Shares Fantacode's FS_Core + FS_ThirdPerson + CoverSystem base with FS Melee -- both systems can run simultaneously on the same character.

**Package:** `Assets/Fantacode Studios/Shooter System/`

**Scale:** 38 C# scripts. Namespace `FS_ShooterSystem`. No asmdef. 3 demo scenes (Main Shooter, Authored Behavior, First Person). Shared: Combat Core + Third Person Controller + CoverSystem.

**Key Classes:**
- `ShooterUI` -- weapon HUD, ammo counter, crosshair management

**Features:**
- Third-person and first-person perspectives (separate demo)
- Cover system (enter/exit cover, blind-fire from cover)
- "Authored Behavior" mode -- scripted AI behavior sequences
- New Input System bindings

**Overlap Analysis:**
- **Directly integrates with FS Melee (ENTRY-219)** -- `FS_CombatCore` is a listed dependency. A character can have both Melee and Shooter active, switching between them (shoot from range, melee up close).
- First-person demo makes this viable for FPS games, not just third-person.

**Verdict Rationale:** Approved with **Default 3D** label. Any 3D game with ranged combat benefits from a ready-made shooter framework. The cover system and first-person support expand its range well beyond third-person TPS. FS Melee + FS Shooter together cover the full action combat spectrum.

**Project Relevance:** FearSteez (ranged enemies, possible dual melee/shoot), any 3D action/FPS/TPS project.

---

## ENTRY-222: Fish Alive Freshwater Set 1.2 (Denys Almaral)

| Field | Value |
|-------|-------|
| **Asset** | Fish Alive Freshwater Set |
| **Publisher** | Denys Almaral |
| **Source** | Asset Store (`Assets/DenysAlmaral/FishAlive/`) |
| **Version** | 1.2 |
| **Price** | Paid |
| **Category** | Animation / AI |
| **Session** | 41 |
| **Verdict** | Approved |
| **Label** | -- |
| **Note** | Supersedes ENTRY-033 (early preliminary evaluation) |

**What It Is:** Procedural fish swimming simulation with schooling behavior, avoidance, and interactive reach targets. Fish animate autonomously using FishMotion -- a procedural swim cycle driven by forward velocity and body wave parameters. No animator required. Supports individual fish, groups/schools, and river avoidance scenarios.

**Package:** `Assets/DenysAlmaral/FishAlive/` (shared folder with Marine Set)

**Scale:** 12 C# scripts (shared with Marine Set). Namespace `FishAlive`. No asmdef (Assembly-CSharp). 3 freshwater demo scenes: Aquarium, Avoidance/River, Benchmark.

**Key Classes:**
- `FishMotion` -- main swim simulation MonoBehaviour. Key methods: `SetAutoMotion(bool)`, `SetReachMode(bool)`, `bone_mouth` (Transform reference for lure/bait targeting)
- `GroupOfFish` -- school manager. Handles collective movement, formation, scatter
- `FishInteract` -- interaction triggers (react to player, lures, environmental events)
- `ReachPoint` -- waypoint/target system for guided fish behavior
- `SwimConfig` (ScriptableObject) -- per-species swim parameters
- `SpeedBubbles` -- particle effect component for speed-based bubbles

**Freshwater Species:** River fish, aquarium fish, avoidance-capable schooling fish.

**Known Integration Notes (from HOK project):**
- Namespace `FishAlive`, compiles into Assembly-CSharp
- Key access pattern: get `FishMotion` component, call `SetAutoMotion(false)`, then drive `bone_mouth` transform toward lure
- `SetReachMode(true)` for guided navigation to a point
- No asmdef -- named asmdefs in HOK need explicit reference or wrapper

**Overlap Analysis:**
- **vs Fish Alive Marine Set (ENTRY-223):** Same scripts, different art. Freshwater fish models + freshwater-appropriate behaviors (river current avoidance). Use Freshwater for HOK (river/lake setting), Marine for ocean/reef settings.

**Verdict Rationale:** Approved with **Default 3D** label. Procedural fish swimming with zero animator setup is a significant time saver. The `FishMotion` API is clean and well-suited to HOK's fishing mechanic (lure targeting via `bone_mouth`). Any 3D game with water and fish benefits from this.

**Project Relevance:** HOK (PRIMARY -- biting fish, schooling behavior, lure targeting), any 3D game with aquatic life.

---

## ENTRY-223: Fish Alive Marine Set 1.2 (Denys Almaral)

| Field | Value |
|-------|-------|
| **Asset** | Fish Alive Marine Set |
| **Publisher** | Denys Almaral |
| **Source** | Asset Store (`Assets/DenysAlmaral/FishAlive/`) |
| **Version** | 1.2 |
| **Price** | Paid |
| **Category** | Animation / AI |
| **Session** | 41 |
| **Verdict** | Approved |
| **Label** | -- |
| **Note** | Shares folder and all scripts with Freshwater Set (ENTRY-222) |

**What It Is:** Procedural marine fish simulation. Same `FishMotion` system as Freshwater Set but includes ocean/reef fish models, coral reef demo scene, and marine-appropriate schooling behaviors. Sharks, tropical fish, open-water schooling.

**Package:** `Assets/DenysAlmaral/FishAlive/` (same folder as Freshwater Set)

**Scale:** 12 scripts shared with ENTRY-222. 2 marine demo scenes: Coral Reef, Marine Benchmark.

**Marine Species:** Coral reef fish, sharks, open-water schoolers, tropical species.

**vs Freshwater Set:**
| | Freshwater (222) | Marine (223) |
|-|-----------------|--------------|
| Demo scenes | Aquarium, River/Avoidance, Benchmark | Coral Reef, Benchmark |
| Fish models | River/lake species | Reef/ocean species |
| Behavior focus | River current avoidance | Open water schooling |
| HOK relevance | HIGH (Acheron = river) | LOW (freshwater setting) |
| Scripts | Shared | Shared |

**Verdict Rationale:** Approved with **Default 3D** label. Marine set evaluated alongside Freshwater for art comparison. The Freshwater set is the active choice for HOK (river setting). Marine set is the correct choice for any ocean/reef game. Both share the same clean `FishMotion` API. Having both evaluated means no re-research when an ocean project starts.

**Project Relevance:** HOK (Freshwater preferred). Marine set relevant for any future ocean/reef game.

---

## ENTRY-224: PuppetMaster 1.4 (RootMotion)

| Field | Value |
|-------|-------|
| **Asset** | PuppetMaster |
| **Publisher** | RootMotion (Pärtel Lang) |
| **Source** | Asset Store (`Assets/Plugins/RootMotion/PuppetMaster/`) |
| **Version** | 1.4 |
| **Price** | Paid |
| **Category** | Physics / Character Simulation |
| **Session** | 41 |
| **Verdict** | Approved |
| **Label** | Recommended |

**What It Is:** Full muscle-based physics puppet simulation system. Characters become physically simulated "puppets" driven by configurable muscles (joint drives). Supports partial to full physics takeover, prop interaction, networked ragdolls, behavioral state machines, and animated-to-physics blending. The most comprehensive physics character system available for Unity.

**Package:** `Assets/Plugins/RootMotion/PuppetMaster/`

**Scale:** 154 C# scripts (PuppetMaster core). Total RootMotion bundle: ~175 scripts including Baker (animation baking, 8 scripts) + RagdollManager (ragdoll setup utility, 6 scripts) + Shared Demo Assets. No asmdef. 31 demo scenes.

**Key Classes:**
- `PuppetMaster` -- main simulation manager. Attach to character root. Manages muscle states.
- `PuppetMasterLite` -- simplified variant for basic use cases
- `Muscle` -- per-bone physics wrapper. Configures joint drives, collision, pinning.
- `Actuator` -- drives individual bones toward animation targets
- `PropMuscle` / `PropRoot` -- physical prop attachment/interaction
- `MuscleCollisionBroadcaster` -- collision events between muscles and environment
- `PressureSensor` -- ground pressure/force detection
- `RigidbodyController` -- physics-based character controller variant
- `PuppetMasterHumanoidConfig` (ScriptableObject) -- humanoid muscle preset

**Bundled Sub-Packages:**
- **Baker** -- bakes animation + puppet simulation back into animation clips (record physically-simulated motion)
- **RagdollManager** -- ragdoll setup wizard for humanoid rigs
- **Final IK integration** (`_Integration/`) -- IK solver layer over puppet simulation

**Demo Scenes (31 total):** Melee, board, character controllers, interaction, animator demos -- most comprehensive demo suite of any Sandbox asset.

**Overlap Analysis:**
- **vs Ragdoll Animator 2 (ENTRY-216):** Different layers of the same problem. RA2 = blend animation + physics (hit reactions, stumbling). PuppetMaster = full behavioral puppet control (complex interactions, networked, Baker). Use RA2 for lightweight hit reactions; use PuppetMaster when full puppet simulation is needed. They can coexist on different characters.
- **vs Unity built-in ragdoll:** No comparison -- PuppetMaster is an order of magnitude more capable.

**Concerns:**
- Significant setup overhead. Each character needs muscles configured per-bone.
- CPU-intensive for large crowds. Best for hero characters and important NPCs.
- The full 31-demo suite adds significant project size -- demos can be deleted after review.

**Verdict Rationale:** Approved with **Default 3D** label. PuppetMaster is the gold standard for Unity physics characters. Baker alone (bake puppet simulation to clips) is a major workflow tool. Any 3D game with physical character interaction -- hit reactions, ragdoll death, physical puzzle characters -- is better with PuppetMaster. RootMotion (Final IK, Full Body IK, PuppetMaster) is among the most trusted Unity publishers.

**Project Relevance:** HOK (Charon physical reactions to waves and obstacles), FearSteez (full ragdoll enemy system), any 3D action/physics game.

---

## ENTRY-225: Body Poser 1.4 (Revolving Gear Studios)

| Field | Value |
|-------|-------|
| **Asset** | Body Poser |
| **Publisher** | Revolving Gear Studios |
| **Source** | Asset Store (`Assets/BodyPoser/`) |
| **Version** | 1.4 |
| **Price** | Paid |
| **Category** | Editor Tool / Scene Authoring |
| **Session** | 41 |
| **Verdict** | Approved |
| **Label** | -- |

**What It Is:** Humanoid pose editor for Unity. Lets you grab any humanoid character in the scene view and manually pose it by rotating bones with handles. Captures ragdoll physics poses (drop a character and capture where it lands). Batch tool for posing multiple characters at once. Designed for static scene dressing -- corpses, seated characters, sleeping figures -- without requiring animations.

**Package:** `Assets/BodyPoser/`

**Scale:** 3 C# scripts. No asmdef. 1 demo scene.

**Key Classes:**
- `BodyPoser` (MonoBehaviour) -- attach to humanoid character. Enables scene handle pose editing. Stores pose as JSON.
- `BodyPoseBatchTool` (MonoBehaviour) -- scene component for batch multi-character operations
- `BodyPoseBatchToolWindow` (EditorWindow) -- editor UI for batch operations
- `BonePose` -- per-bone state data
- `PoseDataWrapper` -- JSON serialization wrapper. Poses stored in `Assets/BodyPoser/TempPoseData/`

**Workflow:**
1. Add `BodyPoser` to humanoid character
2. In scene view, drag bone handles to pose
3. OR: enable ragdoll, let physics settle, click "Capture Ragdoll Pose"
4. Click "Apply Pose" -- removes physics, freezes character in pose
5. Batch tool: paste same pose across many characters

**Overlap Analysis:**
- **vs PuppetMaster Baker (ENTRY-224):** Baker bakes live simulation to animation clips. Body Poser edits static poses. Complementary -- Baker for motion, Body Poser for static dressing.
- **vs manual bone rotation:** Body Poser adds scene handles, JSON storage, and batch operations. Genuine time saver over manual transform editing.

**Verdict Rationale:** Approved with **Default 3D** label. Any 3D game with humanoid characters needs static posed figures somewhere -- NPC sitting at a desk, corpse on the ground, sleeping character in a cutscene. Body Poser makes this a minutes-long task instead of hours of manual bone rotation. 3-script footprint is negligible.

**Project Relevance:** HOK (posed ferryman Charon, defeated souls in the boat), FearSteez (defeated enemies, seated NPCs), all 3D projects with scene-dressed humanoids.

---

## ENTRY-226: Flexalon 3D Layouts 4.4.1 (Virtual Maker)

| Field | Value |
|-------|-------|
| **Asset** | Flexalon 3D Layouts |
| **Publisher** | Virtual Maker |
| **Source** | Asset Store (`Assets/Flexalon/`) |
| **Version** | 4.4.1 |
| **Price** | Paid |
| **Category** | Scripting / Layout System |
| **Session** | 42 |
| **Verdict** | Approved |
| **Label** | Recommended |

**What It Is:** CSS Flexbox-inspired layout system for Unity, covering both 3D world-space objects and uGUI Canvas UI. Rather than manually positioning GameObjects, you attach layout components and Flexalon computes positions automatically -- and recomputes them when content changes. Supports animated layout transitions, drag-and-drop interaction, and procedural content generation from data sources.

**Package:** `Assets/Flexalon/` (`com.virtualmaker.flexalon`)

**Scale:** 82 C# scripts, 4 asmdefs (`Flexalon`, `Flexalon.Editor`, `Flexalon.Samples`, `Flexalon.Samples.Editor`). 24 demo scenes (11 3D + 13 UI).

**Layout Types (7):**
- `FlexalonFlexibleLayout` -- linear axis layout with gap modes: Fixed, SpaceBetween, SpaceEvenly, SpaceAround. Wrapping, fill sizing. The CSS `flexbox` equivalent.
- `FlexalonGridLayout` -- 2D/3D grid with rectangular or hexagonal cells. `FlexalonGridCell` for explicit cell placement. `GetCellPositionWorldSpace()` API for runtime queries.
- `FlexalonCircleLayout` -- circle or spiral positioning on any plane (XY/XZ/ZY). Multiple radius modes.
- `FlexalonCurveLayout` -- positions children along Bézier splines. Infinite curve modes (PingPong, ExtendLine, Repeat). Tangent modes: Manual, Smooth, Corner.
- `FlexalonAlignLayout` -- aligns all children to parent on specified axes. Simple wall/floor/edge placement.
- `FlexalonShapeLayout` -- concentric polygon formations (3+ sides). Crowd/unit formations.
- `FlexalonRandomLayout` -- random placement within bounds with deterministic seed.

**Key Supporting Components:**
- `FlexalonObject` -- attach to any child to configure size (Fixed/Fill/Component), margin, padding, anchor, pivot, min/max size
- `FlexalonConstraint` -- positions one object relative to any other (cross-layout composition)
- `FlexalonCloner` -- procedurally generates children from a prefab list or `FlexalonDataSource`. Calls `FlexalonDataBinding.SetData()` for dynamic content.
- `FlexalonLerpAnimator` / `FlexalonCurveAnimator` / `FlexalonRigidBodyAnimator` -- animate objects to their new layout positions on change
- `FlexalonInteractable` + `FlexalonDragTarget` -- click, drag, and drop objects between layouts. Generates placeholder objects during drag for visual feedback.
- `FlexalonColliderAdapter` -- auto-resizes BoxCollider/SphereCollider to match layout bounds

**Input System Support:** Auto-detects mouse (legacy), New Input System (`FlexalonInputSystemProvider`), XR Interaction Toolkit (`FlexalonXRInputProvider`), Oculus SDK (`FlexalonOculusInputProvider`).

**Architecture:** Hierarchical layout tree. `Flexalon` singleton manages all `FlexalonNode`s. Components mark themselves dirty; Flexalon recomputes on next Update. `FlexalonAdapter` interface handles size measurement for any Unity component (MeshRenderer, Image, TextMeshPro, RectTransform). All optional dependencies compile-guarded via `versionDefines`.

**v4.4.1 Changes (Unity 6 compat):** Fixed `FlexalonRandomModifier` compile error; template Input System updates.

**v4.4 (Major):** Auto-detects New Input System; Screen Space Camera raycasting; `SpaceEvenly`/`SpaceAround` gap modes; `FlexalonDpiScaler` for OS-aware Canvas scaling.

**Overlap Analysis:**
- **vs Unity's built-in Layout Group (HorizontalLayoutGroup, GridLayoutGroup):** Unity's built-in groups are Canvas-only, 2D-only, no animation, no interaction, no data binding. Flexalon replaces them entirely for any project that needs more than basic stacking. The 3D world-space support is unique -- Unity has nothing comparable.
- **vs Heathen UX Toolkit (ENTRY-131):** Heathen UX is a component framework (buttons, sliders, panels). Flexalon is a layout engine. Complementary -- Heathen UX components can be children of Flexalon layouts.

**Concerns:**
- No asmdef in Pixel Crushers' Dialogue System means if both are in a project, care needed with namespace resolution. Flexalon itself has clean asmdefs.
- `FlexalonCloner` + `FlexalonDataSource` pattern requires implementing an interface -- not zero-setup for dynamic lists. Straightforward once understood but needs initial wiring.

**Verdict Rationale:** Approved with **Default** label. Unity's built-in layout system stops at Canvas HorizontalLayoutGroup and GridLayoutGroup. Flexalon extends this to 3D world space, adds animation, drag-and-drop interaction, and data-driven generation. Any project with a non-trivial UI or 3D arranged objects (card hand, inventory grid, formation system, curved menu) saves significant time with Flexalon. Clean asmdefs, 24 demo scenes, active maintenance, Unity 6 compatible.

**Project Relevance:** DLYH (letter grid layout, word arrangement), FearSteez (HUD, ability icons), HOK (inventory, fish collection UI), Shrunken Head Toss (score UI, casualgame grid), any project with a game board, card layout, or complex UI.

**MCP Tools (Session 52-55):** 8 custom tools built -- `flexalon-list-layouts`, `flexalon-create-grid-layout`, `flexalon-create-circle-layout`, `flexalon-create-flexible-layout`, `flexalon-create-random-layout`, `flexalon-add-child`, `flexalon-add-prefab-children`, `flexalon-set-object-size`. All 8 tools confirmed working ✅. Bug fixed: `flexalon-create-random-layout` crashed with NullReferenceException because `FlexalonLayoutBase` has `[RequireComponent(typeof(FlexalonObject))]` -- auto-adds `FlexalonObject` when `AddComponent<FlexalonRandomLayout>()` is called; original code then called `AddComponent<FlexalonObject>()` which returned null (duplicate). Fix: `GetComponent<FlexalonObject>()` instead. Use `instanceID` not `name` to reference layouts in tool calls.

---

## ENTRY-227: Aline 1.7.9 (Aron Granberg)

| Field | Value |
|-------|-------|
| **Asset** | Aline |
| **Publisher** | Aron Granberg |
| **Source** | Packages/ UPM (`com.arongranberg.aline`) |
| **Version** | 1.7.9 (Feb 2026) |
| **Price** | Paid |
| **Category** | Editor Tool / Debug Visualization |
| **Session** | 43 |
| **Verdict** | Approved |
| **Label** | Default |

**What It Is:** Replacement for Unity's built-in `Gizmos` and `Debug.DrawLine` APIs. Draws lines, shapes, and text both in the editor and at runtime in-game. Burst-compatible -- draw calls can be issued from Jobs. Supports URP and HDRP via render pipeline feature hooks.

**Package:** `Packages/com.arongranberg.aline/`

**Scale:** 28 C# scripts, 3 asmdefs (`ALINE`, `DrawingEditor`, `PackageToolsEditor`). 5 demo scenes.

**Key Classes:**
- `Draw` (static) -- main API. `Draw.Line()`, `Draw.WireSphere()`, `Draw.SolidBox()`, `Draw.Label()`, etc. Exposes `.ingame` and `.editor` builders plus `Draw.xy` / `Draw.xz` for 2D planes.
- `CommandBuilder` -- fluent builder for constructing draw calls; Burst-safe
- `CommandBuilder2D` -- 2D drawing variant
- `DrawingManager` -- lifecycle singleton; auto-initializes
- `MonoBehaviourGizmos` -- base class for components that want persistent gizmo drawing
- `AlineURPRenderPassFeature` / `AlineHDRPCustomPass` -- render pipeline integration
- `SDFFont` -- text rendering via signed-distance-field fonts

**Primitive Support:** Lines, polylines, splines, Bezier curves, polygons, circles, spheres, boxes, cylinders, capsules, cones, rings (WireRing/SolidRing added v1.7.9), triangles, quads, text labels (2D + 3D, configurable alignment).

**v1.7.9 (Feb 2026):** Added WireRing/SolidRing; fixed VR foveated rendering; new SciFi Interface example scene.

**Dependencies:** `com.unity.burst`, `com.unity.collections`, `com.unity.mathematics` (all standard Unity packages).

**Overlap Analysis:**
- **vs Unity built-in Gizmos/Debug.DrawLine:** Unity's built-in is editor-only, cannot be called from Burst Jobs, has limited primitive set, no text. Aline supersedes it entirely for any non-trivial debugging. No reason to use built-in Gizmos when Aline is present.
- **Complements A* Pathfinding Project** (same author) -- Aron Granberg also makes the A* Pathfinding Project; Aline is used internally for path visualization there.

**Verdict Rationale:** Approved with **Default** label. Every project needs debug visualization during development. Aline's in-game rendering (not just editor) and Burst compatibility make it strictly superior to Unity's built-in tools. Minimal footprint (28 scripts), clean API, no runtime overhead when `#if UNITY_EDITOR` guards are used properly.

**Project Relevance:** All projects during development. HOK (spline/path visualization), FearSteez (hitbox/sensor debugging), any project with AI (visualize detection ranges, paths, raycasts).

---

## ENTRY-228: Photon PUN 2+ 2.5.2 (Exit Games)

| Field | Value |
|-------|-------|
| **Asset** | Photon PUN 2+ |
| **Publisher** | Exit Games GmbH |
| **Source** | Asset Store (`Assets/Photon/`) |
| **Version** | 2.5.2 (Asset Store) / SDK 4.1.8.17 |
| **Price** | Free (usage-based cloud pricing) |
| **Category** | Scripting / Networking |
| **Session** | 43 |
| **Verdict** | Approved |
| **Label** | -- |

**What It Is:** The de facto standard Unity multiplayer networking library. Photon PUN (Photon Unity Networking) provides lobby/room management, object synchronization, RPCs, transform/animator/physics sync, and chat -- all via Photon's managed cloud relay servers. PUN 2+ is the current generation; PUN Free and PUN+ are identical in code (PUN+ unlocks more CCU on the Photon dashboard).

**Package:** `Assets/Photon/` (4 subfolders: PhotonUnityNetworking, PhotonRealtime, PhotonChat, PhotonLibs)

**Scale:** 217 C# scripts. No asmdef (Assembly-CSharp). 4 demo scenes (Asteroids, Procedural, SlotRacer, PUN Basics Tutorial).

**Key Classes:**
- `PhotonNetwork` (static) -- main API. `Connect()`, `CreateRoom()`, `JoinRoom()`, `Instantiate()`, `Destroy()`
- `PhotonView` -- attach to any networked GameObject. Handles ownership, observation, and RPC routing. Execution order -16000 (runs before other scripts)
- `PhotonTransformView` / `PhotonTransformViewClassic` -- sync position/rotation/scale
- `PhotonAnimatorView` -- sync Animator parameters and states
- `PhotonRigidbodyView` / `PhotonRigidbody2DView` -- sync physics velocity
- `Room` / `RoomInfo` -- room state, properties, player list
- `ChatClient` / `ChatChannel` -- async chat layer (separate Photon Chat service)
- `PunTurnManager` -- turn-based game utility
- `PunTeams` -- team assignment extension

**Architecture:** Client-server via Photon cloud relay (no peer-to-peer). Ownership model: each `PhotonView` has an owner; only owner sends state. RPCs are attribute-tagged methods (`[PunRPC]`) called via `photonView.RPC()`. Setup via `PUN Wizard` editor window (Alt+P).

**Concerns:**
- No asmdef -- compiles into Assembly-CSharp, same as Dialogue System (ENTRY-214). Both being in the same project is fine but compile time grows.
- Photon cloud pricing: free up to 20 CCU, then paid tiers. Fine for prototyping; plan costs for shipped multiplayer games.
- PUN 2 is the current Asset Store version. Photon also has Fusion (newer architecture) and Quantum (deterministic). PUN 2 is proven but not the latest Photon technology.

**Overlap Analysis:**
- Unity's built-in Netcode for GameObjects (NGO) is the only credible alternative. PUN 2 has years of proven production use and a larger ecosystem of tutorials/integrations. For most projects, PUN 2 is lower friction than NGO.

**Verdict Rationale:** Approved (no label -- not universally needed). PUN 2 is the standard choice when a TecVooDoo project needs online multiplayer. The free tier supports prototyping; the cloud infrastructure handles relay/matchmaking. No project needs this until multiplayer is a design requirement, but it's the clear choice when that need arises.

**Project Relevance:** FearSteez (online co-op/vs planned), any future multiplayer title. Low priority for current single-player projects (HOK, DLYH, SHT).

---

## ENTRY-229: Behavior Designer Pro 2.1.12 (Opsive)

| Field | Value |
|-------|-------|
| **Asset** | Behavior Designer Pro |
| **Publisher** | Opsive |
| **Source** | Packages/ UPM (`com.opsive.behaviordesigner`) + `Assets/Opsive/BehaviorDesigner/` |
| **Version** | 2.1.12 |
| **Price** | Paid |
| **Category** | AI / Behavior Trees |
| **Session** | 43 |
| **Verdict** | Approved |
| **Label** | Recommended |

**What It Is:** Visual behavior tree editor and runtime for Unity. Drag-and-drop tree authoring, 16 demo scenes, full DOTS/ECS support (unique to BD Pro vs classic BD). Provides the task library, graph editor, variable system, and event bus for authoring arbitrarily complex NPC AI without writing a state machine by hand.

**Package:** `Packages/com.opsive.behaviordesigner/` + `Assets/Opsive/BehaviorDesigner/Add-Ons/`

**Scale:** 262 C# scripts combined (222 UPM + 40 add-on assets). 4 asmdefs. 16 demo scenes (MeleeCombat, HideAndSeek, Events, TurnBased, Entities/ECS, Subtrees, UtilityTheory, etc.).

**Core Task Types:**
- `Sequence` -- run children left-to-right; fails on first failure (AND logic)
- `Selector` / `PrioritySelector` -- run until success; short-circuits on first success (OR logic)
- `Parallel` / `ParallelSelector` -- run all children simultaneously
- `RandomSequence` / `RandomSelector` -- shuffled execution order
- `UtilitySelector` -- utility theory AI; scores candidates and picks highest
- `Inverter`, `Repeater`, `Cooldown`, `ReturnSuccess/Failure` -- decorators
- Custom `Action` + `Conditional` subclasses for all game-specific logic

**Variable System:** Shared variables (int, float, bool, string, Vector3, GameObject, etc.) passed between tasks and external scripts. `BoolComparison`, `Vector3Comparison`, `GameObjectComparison` conditionals included.

**Event System:** `SendEvent` / `HasReceivedEvent` / `OnReceivedEvent` for cross-tree and cross-object communication. Collision/trigger events (`HasEnteredCollision2D`, `OnTriggerEnter2D`, etc.) as BD tasks.

**DOTS/ECS:** `BehaviorTreeComponent` (IComponentData), `ECSTask` base -- behavior trees can run on ECS entities. Unique to BD Pro. Shared dependencies: `com.opsive.shared`, `com.opsive.graphdesigner`, `com.unity.burst`, `com.unity.entities`.

**Overlap Analysis:**
- **vs SensorToolkit2 (ENTRY-231):** SensorToolkit2 has a Behavior Designer integration pack. The two are designed to work together: SensorToolkit handles detection (who can I see/hear), BD handles decision (what do I do about it).
- **vs Senses Pack (ENTRY-230):** Senses Pack is a BD-native sensory layer that competes with SensorToolkit2's sensing capabilities. See ENTRY-230 for the overlap breakdown.
- **PlayMaker integration (ENTRY-233):** BD Pro ships a PlayMaker integration pack. BD behavior trees can be triggered and communicated with from PlayMaker FSM states. Combined with SensorToolkit2's PlayMaker integration, this enables a full visual AI pipeline: SensorToolkit detects -> PlayMaker routes high-level game state -> BD executes detailed NPC behavior tree. All three layers wirable without C#.

**Verdict Rationale:** Approved with **Default** label. Every game with non-trivial NPC AI benefits from a visual behavior tree tool. BD Pro is the industry leader -- years of Unity Asset Store presence, Opsive's strong support record, DOTS-ready architecture, and the broadest ecosystem of add-ons (Senses Pack, Movement Pack, etc.). The Default label applies because even simple AI (patrolling enemies, reactive NPCs) is cleaner in BD than hand-rolled state machines.

**Project Relevance:** FearSteez (enemy AI: patrol, detect, engage, retreat), HOK (Charon reactive behaviors), any project with NPC decision-making.

---

## ENTRY-230: Senses Pack for Behavior Designer 1.0.3 (Opsive)

| Field | Value |
|-------|-------|
| **Asset** | Senses Pack for Behavior Designer |
| **Publisher** | Opsive |
| **Source** | Asset Store (`Assets/Opsive/BehaviorDesigner/Add-Ons/SensesPack/`) |
| **Version** | 1.0.3 |
| **Price** | Paid |
| **Category** | AI / Add-On |
| **Session** | 43 |
| **Verdict** | Conditional |
| **Label** | -- |
| **Dependency** | Requires Behavior Designer Pro (ENTRY-229) |

**What It Is:** Sensory perception add-on for Behavior Designer. Adds 5 simulated senses as BD tasks: Vision (luminance/line-of-sight), Hearing (sound amplitude/frequency), Smell (scent trails/diffusion), Temperature (thermal zones), Touch (proximity). Each sense has emitters (signal sources) and sensors (detectors) that BD tasks query.

**Package:** `Assets/Opsive/BehaviorDesigner/Add-Ons/SensesPack/`

**Scale:** 34 C# scripts. 2 asmdefs. No standalone demo scenes (demo scripts provided).

**Key Sensor Types:**
- `Visibility` -- line-of-sight raycast. Detects objects within FOV cone.
- `Luminance` / `LuminanceEmitter` -- light-level detection. Objects emit light; sensor detects brightness.
- `Sound` / `SoundEmitter` -- audio detection by amplitude/frequency
- `Tracer` / `TraceEmitter` -- scent trail following. Emitters leave traces; sensor follows trail.
- `Temperature` / `TemperatureVolume` -- thermal zone detection. `SceneTemperature` global manager.
- `Distance` -- simple range/proximity sensor
- `SurfaceIdentifier` / `SurfaceManager` -- material-based surface properties for sound/scent behavior
- `OctreeNode` -- spatial partitioning for sensor efficiency

**BD Tasks provided:** `CanDetectObject`, `CanDetectSurface`, `FollowTraceTrail`, `WithinRange`, `GetSensorAmount`

**Overlap Analysis:**
- **vs SensorToolkit2 (ENTRY-231):** Significant overlap in vision/detection. SensorToolkit2 provides `LOSSensor` (line-of-sight), `ArcSensor` (FOV cone), `RangeSensor` (proximity) -- covering Senses Pack's Visibility, Distance, and Touch senses. SensorToolkit2 is more performant (Burst jobs), has more sensor geometry options, and is standalone (not BD-dependent). **If SensorToolkit2 is in the project, Senses Pack's vision/distance/touch are redundant.** Senses Pack's unique value is the smell/trace system and the deep BD task integration (no wiring needed).

**Verdict Rationale:** Conditional. If Behavior Designer is in the project AND scent/trail following or thermal sensing are game requirements, Senses Pack is the right choice. If only vision/hearing/proximity is needed, SensorToolkit2 (ENTRY-231) covers those with better performance and broader use. Don't install both unless the scent/temperature systems are specifically needed -- the overlap in vision/detection creates redundant sensor pathways.

**Project Relevance:** HOK/FearSteez only if scent/thermal mechanics are implemented (low probability). SensorToolkit2 covers the common cases more efficiently.

---

## ENTRY-231: SensorToolkit2 2.5.17 (Micosmo Games)

| Field | Value |
|-------|-------|
| **Asset** | SensorToolkit2 |
| **Publisher** | Micosmo Games |
| **Source** | Asset Store (`Assets/SensorToolkit/`) |
| **Version** | 2.5.17 |
| **Price** | Paid |
| **Category** | AI / Sensors |
| **Session** | 43 |
| **Verdict** | Approved |
| **Label** | Recommended |

**What It Is:** Comprehensive sensor and detection system for Unity AI. Attach sensors to any GameObject to detect nearby objects by range, line-of-sight, field-of-view arc, NavMesh reachability, or trigger overlap -- all without writing custom physics queries. Includes a Velocity Obstacle steering system (Burst-accelerated) for crowd navigation and AI avoidance.

**Package:** `Assets/SensorToolkit/`

**Scale:** 157 C# scripts. 2 asmdefs (`Micosmo.SensorToolkit`, `Micosmo.SensorToolkit.Editor`). 16 demo scenes (Stealth, Arena Shooter, Spaceships, Terrain, Steering-Crowd, Steering-Hunters, etc.).

**Sensor Components:**
- `RangeSensor` / `RangeSensor2D` -- sphere/box/capsule volume detection. Most common starting point.
- `ArcSensor` / `ArcSensor2D` -- cone FOV detection. Use for enemy vision cones.
- `LOSSensor` / `LOSSensor2D` -- line-of-sight with Bresenham algorithm + quality mode (Sobol low-variance point sampling). Handles complex geometry.
- `RaySensor` / `RaySensor2D` -- single/multi-ray detection. Obstacle/cover detection.
- `NavMeshSensor` -- detects objects reachable via NavMesh path. Only detects what the AI can actually walk to.
- `TriggerSensor` / `TriggerSensor2D` -- collider trigger wrapper with signal pipeline.
- `BooleanSensor` -- logical combinations (AND/OR/NOT) of any other sensors.
- `SignalProxy` -- wraps ragdoll multi-collider characters so they register as a single detected object.
- `SteeringSensor` -- Velocity Obstacle (VO) crowd avoidance. Burst Job-accelerated. `SteerSeek`, `SteerInterest`.

**Signal Pipeline:** `Signal` structs carry detection data (object, collider, strength, bounds). `SignalProcessor` chain: `IgnoreListProcessor` (tag/layer filter), `MapStrengthByDistanceProcessor` (falloff), `MapStrengthByTagProcessor` (tag-based weights).

**Events:** `OnDetection`, `OnLose`, `OnClear`, `OnObstruction` -- UnityEvents fired per sensor. Subscribe without polling.

**Pulse Modes:** Per-frame, fixed-interval, or Jobs (async non-blocking). All sensors are non-alloc -- detection lists are reused per frame.

**Integrations:** Behavior Designer tasks (ENTRY-229), PlayMaker, Game Creator 2.

**v2.5.0 (major):** Added Velocity Obstacles steering, Burst-jobified `SteeringSensor`, major performance fixes.
**v2.4.0 (breaking):** Assembly definitions added; folder reorganization.

**Overlap Analysis:**
- **vs Senses Pack (ENTRY-230):** Both provide AI detection. SensorToolkit2 is broader, standalone, and Burst-accelerated. Senses Pack is BD-native and adds scent/thermal that SensorToolkit2 lacks. They can coexist but the vision/range/proximity detection layer is redundant if both are imported -- pick the primary detection system and supplement if needed.
- **vs manual Physics.OverlapSphere:** SensorToolkit2 replaces all custom detection code. Non-alloc, event-driven, with LOS testing and NavMesh awareness built in.

**Verdict Rationale:** Approved with **Default 3D** label. Every 3D game with enemies or interactive detection needs sensor queries. SensorToolkit2 replaces dozens of lines of custom raycasting/overlap boilerplate with clean inspector-configured components. The Burst steering sensor fills a crowd AI gap Unity has no built-in answer for. 16 demo scenes covering stealth, shooters, vehicles, and crowds.

**Project Relevance:** FearSteez (enemy detection, stealth sections), HOK (creature awareness of player), any 3D game with aware enemies or detection mechanics.

---

## ENTRY-232: Interactor 0.999b (Nega Games)

| Field | Value |
|-------|-------|
| **Asset** | Interactor |
| **Publisher** | Nega Games |
| **Source** | Asset Store (`Assets/Interactor/`) |
| **Version** | 0.999b |
| **Price** | Paid |
| **Category** | Scripting / Interaction / IK |
| **Session** | 43 |
| **Verdict** | Conditional |
| **Label** | -- |

**What It Is:** Full-body IK interaction system with 9 interaction types. Characters physically reach toward and interact with objects using procedural inverse kinematics -- hands land correctly on door handles, weapons rack naturally, picks up items with two-hand support. Bundles a custom full-body IK solver, A* pathfinding, and a basic inventory system. Designed as a one-stop interaction layer.

**Package:** `Assets/Interactor/`

**Scale:** 95 C# scripts. No asmdef (Assembly-CSharp). No bundled demo scenes.

**Interaction Types (9):**
1. `Default` -- standard reach interaction
2. `Distance` -- long-range (line-of-sight)
3. `Manual` -- scripted/designer-controlled
4. `Touch` -- collision-based proximity
5. `Self` -- character self-interaction (emotes, grooming)
6. `Push` -- physics pushing
7. `PickableOne` -- single-hand pickup and hold
8. `PickableTwo` -- two-hand grab
9. `Multiple` -- simultaneous multi-target

**IK System (built-in, ~8 scripts):**
- `FullBodyIK` -- procedural full-body IK. Covers limbs, spine, head.
- `LimbIK` -- 2-bone IK solver (arms, legs)
- `HeadIK` -- look-at target
- `BodyIK` -- torso/spine lean
- `Effector` (struct) -- IK effector with position, rotation, weight
- `HitReaction` -- animation-driven physical hit response

**Supporting Systems:**
- `Pathfinder` / `PathGrid` -- custom A* grid pathfinding
- `Inventory` / `Item` / `ItemDatabase` (ScriptableObject) -- basic item system with slots, icons, tooltips
- `AnimAssist` -- animation event callbacks and state sync
- `OrbitalReach` / `OrbitalPositioner` -- orbital constraint for IK reach

**Concerns:**
- **Pre-1.0 (0.999b)** -- API may still change. "b" suffix suggests beta. No public changelog found in package.
- **No asmdef** -- adds to Assembly-CSharp compile time. With Dialogue System (727 scripts) and PUN 2 (217 scripts) also in Assembly-CSharp, compile times grow significantly.
- **No demo scenes** -- setup and configuration must be learned from documentation only.
- **Bundled IK vs Final IK/PuppetMaster:** Interactor's built-in IK is functional but less capable than Final IK (RootMotion). If PuppetMaster (ENTRY-224) is in the project, its Final IK integration may conflict or overlap with Interactor's IK.
- **Bundled A* vs A* Pathfinding Project:** Custom grid-only pathfinding. Not suitable as a replacement for A* Pathfinding Project for complex navigation.
- **Bundled inventory vs dedicated systems:** Basic inventory; not suitable as a replacement for Inventory Framework (ENTRY-169) for complex UI inventory needs.

**Verdict Rationale:** Conditional. The 9 interaction types + procedural IK are genuinely impressive and would take months to implement from scratch. However: pre-1.0 status, no demo scenes, no asmdef, and three bundled systems (IK, pathfinding, inventory) that partially duplicate other evaluated assets are real concerns. Recommended for projects where physical IK-driven interaction is a core design pillar (grab mechanics, climbing, two-handed weapons). Not a Default because the pre-1.0 API risk and integration complexity don't justify a blanket import.

**Project Relevance:** HOK (Charon physically gripping the oar, fish handling), FearSteez (weapon grabs, door interactions), any 3D game where character hands must procedurally reach targets.

---

## ENTRY-233: PlayMaker 1.9.9f1 (Hutong Games)

| Field | Value |
|-------|-------|
| **Asset** | PlayMaker |
| **Version** | 1.9.9f1 |
| **Developer** | Hutong Games LLC |
| **Source** | Asset Store (`Assets/PlayMaker/`) |
| **Primary Label** | Recommended |
| **Secondary Labels** | -- |
| **Verdict** | Approved |
| **Date** | 2026-03-02 |
| **Session** | 46 |
| **Scripts** | 1,172 total (1,132 actions, 38 editor, 2 core) |
| **Asmdefs** | 0 -- all in Assembly-CSharp |
| **Pipeline** | FSM-based visual scripting, no asmdef |

**What It Is:** Visual scripting system built on a Finite State Machine (FSM) paradigm. NOT a node graph -- each FSM has States, and you add Actions to States. Events drive Transitions between states. Variables (Bool, Float, Int, String, Vector2/3, Color, Quaternion, Rect, Array, Enum, Object, GameObject) are scoped per-FSM or global. FSMs live as components on GameObjects and can call into or be called from C# code. The core FSM runtime is a precompiled DLL; the 1,132 action scripts are editable source.

**Architecture:**
- `PlayMaker.dll` -- core FSM runtime (precompiled)
- `ConditionalExpression.dll` -- math expression evaluator
- `PlayMakerEditor.dll` + `PlayMakerEditorResources.dll` + `ConditionalExpressionEditor.dll` -- editor tools (precompiled)
- `FsmProcessor.cs` + `UpdateHelper.cs` -- thin runtime utilities (source)
- `Actions/` -- 1,132 action scripts across 54 categories (source, editable)
- `Editor/` -- 38 editor scripts: FSM editor, error window, global variables, log, timeline, addon manager, guided tour, custom action wizard
- `Templates/` -- reusable FSM templates

**Action Categories (54):**
AnimateVariables, Animation, Animator, Application, Array, Audio, Camera, Character, Color, Convert, Debug, Device, Effects, Enum, GameObject, Gamepad, GUI, GUIElement, GUILayout, Input, Level, Lights, Logic, Material, Math, MathExpression, Mesh, Movie, Physics, Physics2D, PlayerInput, PlayerPrefs, ProceduralMaterial, Quaternion, Rect, RectTransform, RenderSettings, SceneManager, Screen, ScriptControl, SpriteRenderer, StateMachine, String, Time, Transform, Trigonometry, Tween, UI, UnityObject, Vector2, Vector3, VideoClip, VideoPlayer, Web

**Key FSM Editor Features:**
- Visual state/transition graph with drag-and-drop states
- Error validation window (catches broken references at design time)
- Global Variables + Global Events windows (shared across FSMs)
- FSM Log window (runtime debug)
- Timeline integration (`FsmTimelineWindow`) -- trigger FSM events from Timeline tracks
- Addon Manager for third-party integration pack management
- Custom Action Wizard -- generates boilerplate for new actions
- Guided Tour for onboarding
- 11 language localizations (de, es-ES, fr, it, ja, nl, pt-BR, sv-SE, tr, zh-CN, zh-TW)

**vs Unity Visual Scripting (Bolt):**
- Playmaker: FSM paradigm, 14 years of ecosystem, 1,100+ built-in actions, hundreds of third-party integration packs
- Unity VS: Node graph paradigm, free/built-in, tighter Unity integration, smaller third-party ecosystem
- Playmaker wins decisively on ecosystem breadth; Unity VS wins on price and native package integration
- For TecVooDoo (code-first): neither replaces code, but Playmaker's ecosystem is the differentiator

**Ecosystem Value:**
Hundreds of Asset Store packages ship Playmaker integration packs. Known integrations include: A* Pathfinding Pro, Cinemachine, Final IK, DOTween, UCC, Behavior Designer, Dialogue System, Inventory systems, and many more. This means visual logic can drive complex systems without custom glue code -- relevant for prototyping or designer-facing workflows.

**Confirmed Sandbox AI Stack (all three have PlayMaker integrations):** SensorToolkit2 (ENTRY-231, detection) + Behavior Designer Pro (ENTRY-229, decision trees) + PlayMaker (ENTRY-233, game state routing) = complete visual AI pipeline. SensorToolkit detects targets -> PlayMaker routes FSM state based on sensor data -> BD executes behavior tree for NPC decision-making. All wirable without writing C#.

**Unity 6 / Input System Compatibility Fix:**
`GamepadStickEvents.cs` and `GamepadReadStickValue.cs` had CS0039/CS0029 errors due to `InputControl` type ambiguity between the global namespace and `UnityEngine.InputSystem.InputControl` in Input System 1.18.0. Fix: change `private InputControl GetControl()` to `private UnityEngine.InputSystem.InputControl GetControl()` in both files. All other 1,170 scripts compiled clean.

**Legacy Add-ons (separate import, in `Editor/Install/`):**
- `LegacyGUI.unitypackage` -- old OnGUI-based UI actions (pre-uGUI)
- `LegacyITween.unitypackage` -- iTween integration actions
- `LegacyNetworking.unitypackage` -- old Unity Networking actions
- `ProfilerActions.unitypackage` -- profiler integration

**No Asmdef Warning:** 1,132 action scripts land in Assembly-CSharp. Combined with Dialogue System (727), PUN 2 (217), Interactor (95) if all co-installed = ~2,171 Assembly-CSharp scripts. Expect longer compile times in projects that combine these.

**Verdict Rationale:** Approved with **Recommended** label. Playmaker is the definitive FSM-based visual scripting system for Unity with an unmatched ecosystem of third-party integrations. For code-first TecVooDoo projects it won't replace C#, but its value is twofold: (1) rapid prototyping of game state and flow without writing boilerplate state machines, (2) enabling designer/non-programmer collaboration. The 1,100+ built-in actions cover virtually every Unity subsystem. Recommended over Unity Visual Scripting for any project that will use third-party integration packs. Loses Recommended if Unity VS ecosystem reaches parity.

**Project Relevance:** Visual novel projects (Encapsulated Fear, Genie in a Test Tube, Murder Malady) -- VERY HIGH (branching narrative state machines are natural FSM territory). HOK (quest logic, cutscene control, NPC state) -- MEDIUM. FearSteez (enemy AI state, game flow) -- MEDIUM. A Quokka Story (metroidvania state) -- MEDIUM. Any project with non-programmer collaborators -- HIGH.

---

## ENTRY-234: UI Toolkit Playmaker Integration 1.3.0 (Kamgam)

| Field | Value |
|-------|-------|
| **Asset** | UI Toolkit Playmaker Integration |
| **Version** | 1.3.0 |
| **Developer** | Kamgam |
| **Source** | Asset Store (`Assets/Kamgam/UIToolkitPlaymaker/`) |
| **Primary Label** | -- |
| **Secondary Labels** | UIT |
| **Verdict** | Approved |
| **Date** | 2026-03-02 |
| **Session** | 46 |
| **Scripts** | 102 |
| **Asmdefs** | 1 (`Kamgam.UIToolkitPlaymaker`) |
| **Pipeline** | Playmaker add-on; requires ENTRY-233 |

**What It Is:** Kamgam integration pack that exposes Unity UI Toolkit (UIDocument / VisualElement API) as Playmaker FSM actions. Allows FSM states to query, read, modify, and respond to events on UI Toolkit elements without writing C# code. Part of the Kamgam ecosystem (same developer as Text Animation 2, ENTRY-117; Color Studio, ENTRY-088; and others).

**Key Action Groups:**
- **Query:** `UITKQueryOneRegisterEvent`, `UITKQueryManyRegisterEvent`, `UITKQueryOneSetVariable`, `UITKQueryManySetVariable` -- find elements by USS selector and store as variables or bind events
- **Get/Set (30+ pairs):** Text, Color, TextColor, BackgroundColor, BackgroundImage, Visible, Enabled, Display, Align, AlignText, FlexDirection, FlexWrap, FontStyle, FontDefinition, Overflow, Position, Layout, Name, TabIndex, Tooltip, PickingMode, UserData, ViewDataKey, Float
- **Tree manipulation:** AddChild, RemoveChild, MoveChild, Clear
- **Class management:** AddClass, RemoveClass, HasClass, ToggleClass
- **Events:** RegisterEvent, RegisterEvents (bulk), TriggerEvent, WaitForDocumentLayout
- **Button/Image/Text extensions:** Dedicated VisualElement subtype helpers

**Architecture:**
- `UITKDocumentActionBase` -- base class for all actions; handles UIDocument reference and element querying
- `VisualElementObject` -- wraps `VisualElement` as a Playmaker FsmObject variable type
- `VisualElementEventHandler` -- bridges UI Toolkit event callbacks to Playmaker FSM events
- `EventObject` -- wraps `EventBase` for passing UI events through FSM variables
- `UIElementTypeUtils` -- type resolution utilities for USS queries
- `UIToolkitVisualElementExtensions.*` -- partial classes extending VisualElement for Button, Image, Query, Text

**Dependencies:** Requires PlayMaker (ENTRY-233). No standalone value without Playmaker installed.

**Kamgam Ecosystem Note:** This is the third Kamgam asset in the Sandbox (alongside Text Animation 2 / ENTRY-117 and Color Studio / ENTRY-088). Kamgam consistently ships clean asmdefs, proper namespaces, examples, and PDFs. Reliable vendor.

**Verdict Rationale:** Approved with **no primary label** (depends on Playmaker which is itself Recommended, not Default). For projects using both Playmaker and UI Toolkit, this is the natural bridge. The 30+ Get/Set action pairs cover the full VisualElement style API visually. The query + event registration actions mean a non-programmer can wire UI button clicks to FSM transitions without touching C#. At ~$15-20 price range (Kamgam tier), solid value for the coverage provided.

**Project Relevance:** DLYH (UI Toolkit game, Playmaker for game state wiring) -- HIGH. Visual novel projects (UI-heavy + FSM-natural) -- HIGH. Any project combining Playmaker + UI Toolkit -- HIGH. No value without Playmaker.

---

## ENTRY-235: Damage Numbers Pro 4.5.1 (Ekin Cantas)

| Field | Value |
|-------|-------|
| **Asset** | Damage Numbers Pro |
| **Version** | 4.5.1 |
| **Developer** | Ekin Cantas |
| **Source** | Asset Store (`Assets/DamageNumbersPro/`) |
| **Primary Label** | Recommended |
| **Secondary Labels** | VFX |
| **Verdict** | Approved |
| **Date** | 2026-03-02 |
| **Session** | 46 |
| **Scripts** | 41 (24 runtime/settings, 3 editor, 14 demo) |
| **Asmdefs** | 1 (`DamageNumbersPro`) |
| **Pipeline** | TMP dependency; optional PlayMaker + Game Creator 2 integrations |

**What It Is:** Floating popup number system built on TextMesh Pro. Handles spawning, pooling, animating, and destroying popup numbers for damage, healing, score, XP, or any numeric event. Three rendering variants cover all use cases: 3D world-space mesh, screen-space GUI, and sprite-based. Ships with a preset ScriptableObject system for saving and reusing configurations.

**Rendering Variants:**
- `DamageNumberMesh` -- 3D world space, faces camera. Best for 3D games with world-positioned hits.
- `DamageNumberGUI` -- screen space UI, always on top of geometry. Best for 2D or fixed-screen HUD feel.
- `DamageNumberSprite` -- sprite-based variant for non-TMP pipelines or icon-based numbers.
- All three inherit from abstract `DamageNumber` base class. Same configuration API across variants.

**Animation / Behavior Settings (13 setting classes):**
- `VelocitySettings` -- initial movement direction and speed
- `LerpSettings` -- animation curves for position/scale/alpha over lifetime
- `ShakeSettings` -- screen shake / wobble effect
- `PushSettings` -- nudge nearby numbers apart to prevent overlap
- `CombinationSettings` -- merge nearby numbers into a single accumulated value
- `CollisionSettings` -- bounce off geometry with physics
- `FollowSettings` -- attach/follow a transform (follow the hit target)
- `DistanceScalingSettings` -- consistent screen size at any distance
- `ColorByNumberSettings` -- color ramp based on value (low = green, high = red)
- `ScaleByNumberSettings` -- bigger number = bigger text
- `DestructionSettings` -- fade/shrink/pop on lifetime end
- `DigitSettings` -- number formatting (decimals, thousands separator, prefix/suffix)
- `TextSettings` -- font, size, alignment, left/right text alongside the number

**3D Specific Features:**
- Camera facing (billboard) or LookAt camera (VR-safe)
- Render through walls option (moves close to camera, scales down)
- Consistent screen size across distances
- FOV-aware scaling

**Preset System:**
- `DNPPreset` ScriptableObject -- saves full configuration as a reusable asset
- Assign preset at spawn time for varied popup styles (crit hit vs normal vs heal vs miss)

**Integrations:**
- `Playmaker.zip` -- PlayMaker integration actions (included, extract to install)
- `Game Creator.zip` -- Game Creator 2 integration (included, extract to install)
- Input System compatible (`#if ENABLE_INPUT_SYSTEM && DNP_NewInputSystem`)

**API (spawn pattern):**
```csharp
// Spawn at world position
damageNumberPrefab.Spawn(transform.position, damageValue);

// Spawn with text prefix/suffix
damageNumberPrefab.Spawn(transform.position, damageValue, "CRIT ");

// Spawn following a target
damageNumberPrefab.Spawn(transform.position, damageValue).SetFollowedTarget(enemy.transform);
```

**Verdict Rationale:** Approved with **Recommended** label. Best-in-class floating number system. The three rendering variants, 13 configurable behavior settings, preset system, and included PlayMaker/GC2 integrations cover every use case. TMP dependency is fine since TMP is Default. Not Default because not every project needs floating popups -- primarily combat/RPG/action games.

**Project Relevance:** HOK (combo/fish catch score popups) -- HIGH. FearSteez (hit numbers, combo counters) -- VERY HIGH. Any action/RPG with damage values -- HIGH. DLYH (score popups) -- MEDIUM.

---

## ENTRY-236: Easy Save 3 3.5.25 (Moodkie)

| Field | Value |
|-------|-------|
| **Asset** | Easy Save 3 |
| **Version** | 3.5.25 |
| **Developer** | Moodkie Interactive |
| **Source** | Asset Store (`Assets/Plugins/Easy Save 3/`) |
| **Primary Label** | Default |
| **Secondary Labels** | -- |
| **Verdict** | Approved |
| **Date** | 2026-03-02 |
| **Session** | 46 |
| **Scripts** | ~215 (194 runtime, 21 editor) |
| **Asmdefs** | 0 by default (Plugins -> Assembly-CSharp-firstpass); optional asmdef generation via `EnableES3AssemblyDefinitions.cs` |
| **Pipeline** | Standalone; PlayMaker integration included; Unity Visual Scripting integration included |

**What It Is:** The de facto standard Unity save/serialization system. Static `ES3` API for saving and loading any data type to multiple backends with optional encryption, compression, and save slot management. Covers everything from simple `ES3.Save("key", value)` to full GameObject serialization, reference graphs, cloud saves, and auto-save components.

**Core API (all static, zero setup required):**
```csharp
ES3.Save("playerHealth", health);
float health = ES3.Load<float>("playerHealth", defaultValue: 100f);
ES3.DeleteKey("playerHealth");
bool exists = ES3.KeyExists("playerHealth");
ES3.DeleteFile();
string[] keys = ES3.GetKeys();
```

**Storage Backends (ES3Settings.Location):**
- `File` -- PersistentDataPath or DataPath (default, cross-platform)
- `PlayerPrefs` -- Unity PlayerPrefs (mobile-safe fallback)
- `InternalMS` -- in-memory stream (no disk I/O, temp data)
- `Resources` -- Unity Resources folder (read-only at runtime)
- `Cache` -- write-behind cache, flush to disk manually

**Serialization Coverage (~100 ES3Type_* classes):**
Primitives (all), Unity value types (Vector2/3/4, Color, Quaternion, Rect, Matrix4x4, Bounds, LayerMask, AnimationCurve, Gradient, Keyframe), Unity objects (GameObject, Transform, Camera, Light, Mesh, Material, Sprite, Texture2D, AudioClip, Font, Shader), Colliders, Rigidbody, ParticleSystem (all 20+ module types), UI (Image, RawImage, Text, RectTransform, EventSystem), Collections (Array, List, Dictionary, ConcurrentDictionary, Queue, Stack, HashSet, Tuple), NativeArray (Burst)

**Advanced Features:**
- **AES encryption** -- single setting to encrypt all save data
- **Gzip compression** -- reduce file size for large datasets
- **JSON, XML, Binary** format support
- **ES3File** -- in-memory file for batch read/write without disk round-trips
- **ES3AutoSave** component -- mark fields/properties for automatic serialization; `ES3AutoSaveMgr` coordinates all auto-save components
- **ES3Prefab + ES3GameObject** -- serialize entire GameObjects and prefab instances including component state and hierarchy
- **ES3ReferenceMgr + ES3GlobalReferences** -- tracks object references across serialization so graphs round-trip correctly
- **Save slot system** -- ES3Slot, ES3SlotManager, ES3CreateSlot for multiple named save slots (new game / load game screens)
- **ES3Spreadsheet** -- CSV-style 2D data tables
- **ES3Cloud / ES3WebClass** -- cloud save backend (requires Moodkie server or custom endpoint)
- **ES3Window** -- editor tool for browsing, editing, and deleting save file contents at design time

**Editor Tools:**
- `ES3Window` -- browse keys/values in any save file
- `AutoSaveWindow` -- configure auto-save settings
- `TypesWindow` -- view all registered type writers
- `ToolsWindow` -- utilities: clear save data, migrate keys, etc.
- `ReferencesWindow` -- inspect reference manager state

**Integrations:**
- `ES3PlayMaker.cs` + `ES3PlayMakerEditor.cs` -- full PlayMaker integration (included in `PlayMaker/` subfolder)
- `[Unity.VisualScripting.IncludeInSettings(true)]` on ES3 class -- Unity Visual Scripting nodes available automatically
- Optional asmdef generation (`EnableES3AssemblyDefinitions.cs` in Editor) for projects that need explicit assembly isolation

**No Asmdef Note:** Default behavior is Plugins folder -> `Assembly-CSharp-firstpass`. This means ES3 types are visible everywhere but also that custom ES3Type writers must be in Assembly-CSharp or a dependent assembly. The optional asmdef mode changes this -- run the `EnableES3AssemblyDefinitions` editor tool if asmdef isolation is needed.

**Verdict Rationale:** Approved with **Default** label. Every Unity project that has player progress, settings, or any persistent state needs a save system. ES3 is the clear industry standard -- comprehensive type coverage, multiple backends, encryption, slot management, cloud saves, and both visual scripting integrations included. The static API requires zero setup: `ES3.Save("key", value)` works immediately without any manager in the scene (ES3GlobalManager auto-creates itself). No serious alternative matches this coverage at this price point.

**Project Relevance:** All TecVooDoo projects -- UNIVERSAL. HOK (save progress, fish caught, inventory), FearSteez (level progress, unlocks), DLYH (high scores, game state), Shrunken Head Toss (scores), visual novels (chapter progress, choices).

---

## ENTRY-237: Grabbit 6.0.1 (Jungle Juice Games)

| Field | Value |
|-------|-------|
| **Asset** | Grabbit |
| **Version** | 6.0.1 (internal: 2023.0.3) |
| **Developer** | Jungle Juice Games |
| **Source** | Asset Store (`Assets/Plugins/Grabbit/`) |
| **Primary Label** | Recommended |
| **Secondary Labels** | QoL |
| **Verdict** | Approved |
| **Date** | 2026-03-02 |
| **Session** | 46 |
| **Scripts** | 17 (5 runtime data, 11 editor, 1 VHACD) |
| **Asmdefs** | 2 (`GrabbitAssembly`, `vhacd`) |
| **Pipeline** | Editor-only tool; near-zero runtime footprint |

**What It Is:** Physics-based scene object placement editor tool. Select objects in the scene, activate the Grabbit EditorTool, and drag objects around -- they collide with each other and surrounding geometry in real time using Unity's physics engine. Objects settle naturally without clipping. Designed for rapid level dressing: place props, furniture, debris, rocks, or any mesh without manually checking for interpenetration.

**Placement Modes (GrabbitMode enum):**
- `PLACE` -- drag selected object(s) with live physics collision. Primary mode.
- `ROTATE` -- rotate with collision constraints preventing geometry overlap
- `ALIGN` -- align object face/surface to nearest geometry
- `FALL` -- simulate gravity; drop object from current position and let it settle
- `POINT` -- point-to-place: click a surface, object moves to that point
- `SETTINGS` -- in-viewport settings panel

**Collision System:**
- Uses VHACD (Volumetric Hierarchical Approximate Convex Decomposition) to generate accurate convex hull colliders from arbitrary mesh geometry
- `VhacdGenerator` produces multi-hull approximations for concave meshes (chairs, vehicles, organic shapes)
- `ColliderBakingMode`: bake on scene open or on selection -- controls when VHACD processing runs
- `ColliderGenerationMode`: use existing colliders only, generate when none exist, generate and ignore existing, or use both
- `ColliderMeshContainer` caches baked collision data to avoid re-generation
- `MaxMeshCollidersCreated` / `ColliderResolution` control performance vs accuracy tradeoff

**Additional Features:**
- Multi-object selection -- drag a group of objects while they collide with each other
- Tag/layer limitation zones -- restrict which objects participate in collision during placement
- Soft collision mode -- objects can partially overlap with resistance rather than hard stop
- Gravity direction control including toward-mouse gravity
- Velocity/drag/iteration physics tuning
- Undo support
- Prefab mode support (`PrefabModeProcessor`)
- Layer override during placement, restore on release

**Runtime Footprint:**
The 5 "runtime" scripts (`GrabbitHandler`, `GrabbitData`, `GrabbitSettings`, `ColliderMeshContainer`, `SerializableDictionary`) are all wrapped in `#if UNITY_EDITOR`. Zero runtime overhead -- nothing ships to build. GrabbitAssembly asmdef has no runtime references.

**Verdict Rationale:** Approved with **Recommended** label. Any 3D project with manual scene/level composition benefits from physics-based placement. The VHACD integration is the key differentiator -- accurate collision for any mesh shape during drag means you can place complex props against each other and they settle realistically without manual adjustment. Not Default because 2D projects and procedurally-generated worlds gain no value from it, and even some 3D projects with simple geometry can get by with Unity's built-in snapping and grid tools.

**Project Relevance:** HOK (Acheron scene dressing -- rocks, props, dock elements) -- HIGH. FearSteez (urban environment props) -- HIGH. Any 3D project with handcrafted levels -- HIGH. 2D projects -- NONE.

---

## ENTRY-238: Weather Maker 8.0.3 (Digital Ruby)

| Field | Value |
|-------|-------|
| **Asset** | Weather Maker |
| **Version** | 8.0.3 (2026-02-28) |
| **Developer** | Digital Ruby (Jeff Johnson) |
| **Source** | Asset Store (`Assets/WeatherMaker/`) |
| **Primary Label** | Recommended |
| **Secondary Labels** | Environment |
| **Verdict** | Approved |
| **Date** | 2026-03-02 |
| **Session** | 46 |
| **Scripts** | 136 (129 runtime, 7 demo) |
| **Asmdefs** | 0 -- Assembly-CSharp |
| **Pipeline** | URP only (Unity 6000+ / URP 17.3+). HDRP not supported. Built-in render path partial support. |

**What It Is:** The most comprehensive all-in-one weather, sky, and atmosphere system on the Asset Store. 8+ years of active development. Covers precipitation, volumetric clouds, sky sphere, day/night cycle, lightning, fog, wind, aurora, meteor showers, water, wetness overlays, spatial weather zones, audio management, and networking -- all driven by a profile/ScriptableObject system with runtime transitions.

**Systems:**
- **Precipitation:** Rain, snow, sleet, hail -- 2D and 3D particle variants (`FallingParticleScript`, `PrecipitationManager`, `PrecipitationProfile`)
- **Sky:** Sky manager, sky sphere, sky plane, star rendering, sun/moon as celestial objects (`WeatherMakerSkyManagerScript`, `WeatherMakerCelestialObjectScript`, `WeatherMakerSkyProfileScript`)
- **Clouds:** Full-screen volumetric clouds, cloud noise generator (procedural), cloud layer profiles, cloud probes, 2D cloud manager (`WeatherMakerCloudNoiseGeneratorScript`, `WeatherMakerCloudVolumetricProfileScript`, `WeatherMakerFullScreenCloudsScript`)
- **Fog:** Full-screen fog, sphere fog, box fog, dampening zones, null zones (`WeatherMakerFogManagerScript`, `WeatherMakerFullScreenFogScript`, `WeatherMakerSphereFogScript`, `WeatherMakerBoxFogScript`)
- **Lightning:** Lightning bolt generator, 2D+3D variants, thunder & lightning manager, configurable strike profiles (`WeatherMakerLightningBoltScript`, `WeatherMakerThunderAndLightningManagerScript`)
- **Day/Night Cycle:** Full sun arc, moon phase, star rotation, ambient light transition (`WeatherMakerDayNightCycleManagerScript`, `WeatherMakerDayNightCycleProfileScript`)
- **Wind:** Wind manager, wind zones, wind profiles (`WeatherMakerWindManagerScript`)
- **Atmosphere:** Atmosphere profile for sky color, scattering, and haze (`WeatherMakerAtmosphereProfileScript`)
- **Aurora Borealis:** Aurora manager and profile (`WeatherMakerAuroraManagerScript`)
- **Meteor Shower:** Configurable meteor shower effect (`WeatherMakerMeteorShowerScript`)
- **Water:** Water profile and script (`WeatherMakerWaterScript`)
- **Wetness:** Full-screen wetness overlay triggered by precipitation (`WeatherMakerFullScreenWetnessOverlayScript`)
- **Overlay Effects:** Snow overlay, wetness overlay, custom full-screen overlays (`WeatherMakerOverlayProfileScript`)
- **Zones:** `WeatherMakerWeatherZoneScript` for location-specific weather (interior vs exterior), `WeatherMakerNullZoneScript` for weather exclusion zones, `WeatherMakerLocationWeatherScript` for GPS/coordinate weather
- **Audio:** Full audio manager with ambient layers, sound zones, looping sources, player sound manager (`WeatherMakerAudioManagerScript`, `WeatherMakerSoundZoneScript`)
- **Lights:** Light manager, volumetric light, shadow map (`WeatherMakerLightManagerScript`)
- **Performance:** `WeatherMakerPerformanceProfileScript`, temporal reprojection for cloud rendering
- **Profile System:** All settings in ScriptableObject profiles -- weather can transition between profiles at runtime with lerp duration

**Third-Party Extension Scripts (14):**
Aquas, CTS, Gaia, MegaSplat, MicroSplat, PlayMaker, RainSnowSeason, RTP Terrain, Uber Shader, Vegetation Studio Pro, Water, WetStuff, WorldManager, HDRP Custom Pass. All in `WeatherMakerExtension*.cs` -- activate when the target asset is present.

**Render Pipeline Support:**
- `WeatherMakerCommandBufferManagerScript.URP.cs` + `WeatherMakerURPRenderFeatureScript` -- URP path (primary)
- `WeatherMakerCommandBufferManagerScript.Builtin.cs` -- Built-in legacy path
- `WeatherMakerHDRPCustomPass.cs` -- HDRP stub (not fully supported per readme)
- **Requires Unity 6000+ and URP 17.3+ for full URP support**

**Networking:** Mirror integration (`WeatherMakerMirrorNetworkScript`) for synchronized weather in multiplayer.

**vs OccaSoftware Atmosphere Ecosystem (ENTRY-181/182/184/185/186/187):**
- OccaSoftware: modular UPM packages (Altos sky, Buto fog, LSPP post-process, Dynamic Cloud Shadows, Auto Exposure, Better Bloom). Lighter per-system, easy to mix and match, no single point of failure.
- Weather Maker: monolithic, but deeper -- adds precipitation, lightning, wind, audio, zones, networking, wetness overlays, celestial simulation.
- **Recommendation:** OccaSoftware for projects wanting a nice sky/atmosphere only. Weather Maker for projects where weather is a gameplay mechanic or immersive simulation (rain affects visibility, lightning triggers events, weather zones change gameplay area).
- Weather Maker's PlayMaker extension means weather state can drive FSM transitions directly.

**Verdict Rationale:** Approved with **Recommended** label. The deepest weather system on the Asset Store with 8+ years of continued development (8.0.3 released 2026-02-28). The extension layer for PlayMaker, Gaia, Vegetation Studio Pro, and terrain shaders means it slots into complex environment pipelines without glue code. URP-only limitation in Unity 6 is fine for TecVooDoo's URP-first approach. Not Default because most TecVooDoo projects are indoor or stylized environments where a full weather simulation is overkill.

**Project Relevance:** HOK (Acheron riverbank -- dynamic fog, rain, lightning storms as mood events) -- VERY HIGH. Alpha Foxtrot Uniform (outdoor 3D action) -- HIGH. A Quokka Story (outdoor platformer) -- HIGH. FearSteez (urban night scenes -- rain for atmosphere) -- MEDIUM. Indoor/2D projects -- NONE.

---

## ENTRY-239: GrabMaster 1.0

| Field | Value |
|-------|-------|
| **Asset** | GrabMaster |
| **Version** | 1.0 |
| **Developer** | Unknown (small indie asset) |
| **Source** | Asset Store (`Assets/Grab Master v1.0/`) |
| **Primary Label** | -- |
| **Secondary Labels** | -- |
| **Verdict** | Approved |
| **Date** | 2026-03-02 |
| **Session** | 46 |
| **Scripts** | 25 |
| **Asmdefs** | 0 -- Assembly-CSharp |
| **Pipeline** | Standalone FPS interaction; both Legacy and New Input System supported |

**What It Is:** A runtime FPS physics grab system for first/third-person games. Pick up Rigidbody objects by raycast, hold them at configurable distance in front of the camera, rotate them, zoom in/out, throw (charged), or push. Extends into a socket system for puzzle snap-to-place mechanics, physical buttons, pressure plates, and impact audio. Clean interface-driven architecture despite being v1.0.

**Core Architecture:**
- `GrabSystem` (MonoBehaviour) -- main controller on the player/camera. Raycast grab, hold, zoom, rotate, charged throw, push. Input fully abstracted behind `IGrabInput` interface.
- `GrabbableObject` (MonoBehaviour, requires Rigidbody) -- marks any physics object as grabbable. Per-object: weight (sets Rigidbody mass), throw force range, rotation allowed, push force, optional grab pivot transform, per-event audio.
- `IGrabbable` / `iGrabInput` / `IFPSInput` / `IInteractable` / `ILookDeviceInput` -- interface layer decoupling all systems
- `GrabEvents` -- static event bus: `RaiseHoldingChanged(bool)`, `RaiseGrabbableInRangeChanged(bool)` for UI crosshair updates

**Input Layer:**
- `LegacyGrabInput` + `LegacyFPSInput` -- old UnityEngine.Input
- `NewGrabInput` + `NewFPSInput` -- Unity Input System package
- Swap by component, no code changes required

**Socket System (puzzle / snap-to-place):**
- `ObjectSocket` -- attach point accepting `SocketableItem` of matching `SocketType`. Optional auto-eject, snap behaviour.
- `SocketableItem` -- item component with a `SocketType` ScriptableObject tag
- `PuzzleSocketGroup` -- coordinates multiple sockets; fires event when all slots filled (unlock door, open chest, etc.)
- `SocketEjector` -- trigger zone that forcefully removes socketed items
- `SocketType` -- ScriptableObject tag defining which items fit which sockets

**Interaction Extensions:**
- `InteractionSystem` -- base proximity/raycast interaction detection
- `PhysicalButton` -- pressable button with press/release events and audio
- `PressurePlate` -- weight-triggered platform with enter/exit events

**Audio:**
- `AudioClipSettings` -- SO with clip, volume range, pitch range for randomization
- `AudioEventPlayer` -- plays `AudioClipSettings` on a pooled AudioSource
- `ImpactSound` -- `OnCollisionEnter` triggered impact audio with velocity threshold

**Code Quality Notes:** Unusually clean for a v1.0 indie asset. Proper interface injection, correct ForceMode usage (Impulse vs VelocityChange), mass-adjusted hold speed, pivot-relative rotation math, no visible per-frame allocations. Well commented. Not Burst/Jobs but appropriate for the task.

**Concerns:**
- v1.0 -- no track record, no changelog found, API may change
- No asmdef -- Assembly-CSharp
- `GMFPSController` is a demo controller only -- not a replacement for UCC/FearSteez controller
- No demo scenes beyond the one bundled scene
- No namespace for the ScriptableObject (SocketType is in `GrabMaster` namespace, consistent)

**vs Interactor (ENTRY-232, Conditional):** GrabMaster is simpler but stable (no pre-1.0 risk, no bundled conflicting IK/pathfinding). Interactor has 9 interaction types and procedural IK but is beta. For FPS grab specifically, GrabMaster's cleaner code and socket system are preferable. For full-body IK-driven interactions, Interactor remains relevant.

**Verdict Rationale:** Approved with **no primary label**. Solid, clean FPS physics interaction starter kit. The socket/puzzle system is genuinely useful for puzzle games and escape-room-style mechanics. However: v1.0, no asmdef, small indie vendor, and limited to FPS grab pattern means it's situational rather than universal. Most projects with complex character systems (HOK with Animancer, FearSteez with UCC) will build their own interaction layer. Best used as a reference implementation or as-is for simpler 3D games. Cherry-pick candidates: the AudioClipSettings/AudioEventPlayer pattern and the SocketType SO system.

**Project Relevance:** FearSteez (weapon/item pickup) -- MEDIUM (likely superseded by UCC interaction). HOK (fish grab, rod interaction) -- MEDIUM (reference only, HOK has custom interaction). A Quokka Story (item interaction) -- HIGH. Miracle Worker / Space Garbage Man (3D point-and-click object interaction) -- HIGH.

---

## ENTRY-240: Corgi Engine 9.4 (More Mountains)

**Date:** 2026-03-02 (Session 46)
**Source:** Asset Store
**Category:** Framework (2D/2.5D Platformer Engine / Character System)
**Verdict:** Approved
**Label:** Recommended | Character
**Namespace:** `MoreMountains.CorgiEngine`

### Overview

Corgi Engine is More Mountains' flagship 2D and 2.5D platformer framework. It provides a complete character ability system built on a custom physics controller (`CorgiController`), a modular AI brain/action/decision system, an inventory system, and full integration with MMFeedbacks (the Feel juice system). It is the 2D counterpart to TopDown Engine. Version 9.4 ships with confirmed Unity 6 URP support and was current as of the evaluation date.

### Asset Structure

```
Assets/CorgiEngine/
  Common/          -- 260 core scripts + art/prefabs/animations
  Demos/           -- 35 demo scripts (excluded from production use)
  ThirdParty/
    MoreMountains/
      InventoryEngine/  -- 38 scripts (item/inventory system)
      MMFeedbacks/      -- 419 scripts (game feel/juice system -- see ENTRY-241)
      MMInterface/      -- 9 scripts (UI utilities)
      MMTools/          -- 382 scripts (general utility library)
```

**Script counts (non-demo):** 260 core + 848 ThirdParty = 1,108 total
**Asmdefs (9):**
- `MoreMountains.CorgiEngine` -- runtime core
- `MoreMountains.CorgiEngine.Editor` -- editor tools
- `MoreMountains.CorgiEngine.InputSystem` -- Input System integration
- `MoreMountains.InventoryEngine` -- inventory runtime
- `MoreMountains.InventoryEngine.Editor` -- inventory editor
- `MoreMountains.Interface` -- UI/HUD helpers
- `MoreMountains.Interface.Editor`
- `MoreMountains.Tools` -- MMTools utility library
- `MoreMountains.Tools.Editor`

### Architecture

**Character System:** Component composition on a `Character` root. Each behavior is a `CharacterAbility` subclass added as a component. The ability manager automatically discovers and sequences abilities.

**CorgiController:** Custom 2D physics controller (not Unity Rigidbody). Handles raycasting-based collision, slopes, one-way platforms, ladders, moving platforms. More precise and tunable than Unity's default physics for 2D platforming.

**47 CharacterAbilities (v9.4):**
`CharacterHorizontalMovement`, `CharacterJump`, `CharacterRun`, `CharacterCrouch`, `CharacterDash`, `CharacterRoll`, `CharacterWallClinging`, `CharacterWalljump`, `CharacterGlide`, `CharacterFly`, `CharacterJetpack`, `CharacterDive`, `CharacterSimpleDive`, `CharacterSwim`, `CharacterLadder`, `CharacterLedgeHang`, `CharacterGrip`, `CharacterBounce`, `CharacterDangling`, `CharacterPush`, `CharacterPushCorgiController`, `CharacterGrabCarryAndThrow`, `CharacterStairs`, `CharacterSlopeOrientation`, `CharacterGroundNormalGravity`, `CharacterGravity`, `CharacterFallDamage`, `CharacterCrushDetection`, `CharacterDamageDash`, `CharacterStun`, `CharacterHandleWeapon`, `CharacterHandleSecondaryWeapon`, `CharacterInventory`, `CharacterButtonActivation`, `CharacterLookUp`, `CharacterPause`, `CharacterSpeed`, `CharacterTimeControl`, `CharacterSwap`, `CharacterSwitchModel`, `CharacterFollowPath`, `CharacterAutoMovement`, `CharacterParticles`, `CharacterSurfaceFeedbacks`, `CharacterPersistence`, `CharacterRestartLevel`, `CharacterAbilityNodeSwap`, `CharacterSpeedAnalysis`

**Weapons (16 types):**
`Weapon` (base), `MeleeWeapon`, `ComboWeapon`, `ProjectileWeapon`, `HitscanWeapon`, `ChargeWeapon`, `Projectile`, `BouncyProjectile`, `ThrownObject`, `WeaponAim`, `WeaponAmmo`, `WeaponAutoAim`, `WeaponIK`, `WeaponLaserSight`, `Bomb`, `AimMarker`

**AI System (Advanced):**

Actions (21): `AIActionDoNothing`, `AIActionMoveTowardsTarget`, `AIActionMoveAwayFromTarget`, `AIActionFaceTarget`, `AIActionFlyTowardsTarget`, `AIActionFlyPatrol`, `AIActionPatrol`, `AIActionPatrolWithinBounds`, `AIActionPatrolAndJump`, `AIActionJump`, `AIActionShoot`, `AIActionChangeWeapon`, `AIActionReload`, `AIActionDash`, `AIActionClimbLadder`, `AIActionCrouchStart/Stop`, `AIActionRunStart/Stop`, `AIActionSelfDestruct`, `AIActionSetPlayerAsTarget`, `AIActionSetLastKnownPositionAsTarget`, `AIActionSetTransformAsTarget`, `AIActionSwapBrain`, `AIActionTakeStairsTowardsTarget`, `AIActionMMFeedbacks`, `AIActionUnityEvents`, `AIActionResetTarget`

Decisions (16): `AIDecisionDetectTargetLine`, `AIDecisionDetectTargetRadius`, `AIDecisionLineOfSightToTarget`, `AIDecisionDistanceToTarget`, `AIDecisionHealth`, `AIDecisionGrounded`, `AIDecisionHit`, `AIDecisionTargetFacingAI`, `AIDecisionTargetIsAlive`, `AIDecisionTargetIsNull`, `AIDecisionReloadNeeded`, `AIDecisionTimeInState`, `AIDecisionTimeSinceStart`, `AIDecisionNextFrame`, `AIDecisionRandom`

**Bundled Systems:**
- **InventoryEngine:** Slot-based inventory, item ScriptableObjects, equipment system, save/load
- **MMFeedbacks (Feel):** Full game feel/juice system. See ENTRY-241 for detail on feedback types
- **MMTools:** Singletons, object pooling, save system, event system, math utilities, camera tools
- **MMInterface:** Progress bars, pause menu, game over screens, floating text

**Input:** Native Input System integration via `MoreMountains.CorgiEngine.InputSystem` asmdef. Legacy Input also supported.

**Cinemachine:** Full integration via `ScriptsCinemachine/` -- camera shake, zoom, follow scripts.

### Import Behavior

**FBX Catalog Scan:** Corgi Engine scans ALL FBX files in the project on first import (same behavior as Animancer Pro and TopDown Engine). In a project with many FBX assets, this causes a multi-minute compile cycle and repeated domain reloads. **Install before importing 3D art assets.** TopDown Engine has the same behavior.

### Overlap Analysis

| System | Overlap | Notes |
|--------|---------|-------|
| UCC (ENTRY-165) | HIGH | Both are character ability frameworks. UCC is 3D + 2D universal; Corgi is 2D/2.5D specialized with custom physics. Not interchangeable. |
| FS Melee (ENTRY-219) | MEDIUM | Corgi has its own MeleeWeapon/ComboWeapon. For FearSteez 2.5D, FS Melee was selected as the build base over Corgi due to UCC integration. |
| Beat Em Up Template (ENTRY-166) | MEDIUM | Template uses Corgi-compatible patterns but is not Corgi. Template used as tuning reference only for FearSteez. |
| A* Pathfinding Pro (ENTRY-164) | LOW | Corgi AI uses its own brain/raycasting detection, not AStar navmesh. Compatible (AStar for larger map pathfinding, Corgi AI for local decisions). |
| Behavior Designer Pro (ENTRY-229) | LOW-MEDIUM | BD Pro can replace Corgi's AIBrain for more complex behavior trees. Both co-exist. |

### Verdict Rationale

Approved, **Recommended | Character**. Corgi Engine is the gold standard for Unity 2D/2.5D platformer development. The CharacterAbility component system is architecturally clean, the CorgiController physics are tunable and reliable, and the bundled MMFeedbacks/InventoryEngine make it a near-complete game framework. For any 2D platformer project (Shrunken Head Toss, A Quokka Story, Necro Ricochet, potential 2D entries in the portfolio), Corgi Engine is the correct starting point.

FearSteez note: Corgi's 2.5D mode is relevant, but FearSteez is being built on UCC + FS Melee. Corgi and FearSteez's stack should not be mixed -- choose one foundation.

### Project Relevance

| Project | Relevance | Notes |
|---------|-----------|-------|
| Shrunken Head Toss | HIGH | 2D casual -- Corgi provides a complete foundation |
| A Quokka Story | HIGH | 2.5D Metroidvania -- Corgi's wall cling, ladders, ledge hang are built-in |
| Necro Ricochet | MEDIUM | 2D party game -- Corgi is heavyweight for a party game, but the physics are good |
| FearSteez | LOW | 2.5D beat em up -- foundation is UCC/FS Melee, not Corgi |
| HOK | LOW | 3D fishing sim -- Corgi is 2D-focused, not applicable |

---

## ENTRY-241: Feel 5.9.1 (More Mountains)

**Date:** 2026-03-02 (Session 46)
**Source:** Asset Store
**Category:** Scripting (Game Feel / Juice / Haptics System)
**Verdict:** Approved
**Label:** Recommended
**Namespace:** `MoreMountains.Feedbacks`, `Lofelt.NiceVibrations`

### Overview

Feel is More Mountains' game feel/juice system. It consists of two parts: **MMFeedbacks** (the primary feedback sequencer/player system with 160+ feedback types) and **NiceVibrations** (mobile/controller haptics via the Lofelt SDK). When Corgi Engine is installed, MMFeedbacks is already present as `ThirdParty/MoreMountains/MMFeedbacks/` -- Feel adds only NiceVibrations and the demo scenes in that case. When installed standalone (without Corgi), Feel provides the full MMFeedbacks system.

### Asset Structure

```
Assets/Feel/
  NiceVibrations/     -- 50 scripts, haptic clips, Lofelt SDK plugins
    Scripts/          -- HapticClip, HapticController, HapticSource, HapticPatterns...
    Plugins/          -- Native iOS/Android Lofelt haptics plugins
  FeelDemos/          -- MMFeedbacks demos (uGUI)
  FeelDemosURP/       -- MMFeedbacks demos (URP post-process)
  FeelDemosHDRP/      -- MMFeedbacks demos (HDRP post-process)
```

**NiceVibrations scripts (non-demo):** ~30 runtime scripts
**Asmdefs (3, all NiceVibrations):**
- `Lofelt.NiceVibrations` -- runtime haptics
- `Lofelt.NiceVibrations.Demo` -- demo scenes
- `Lofelt.NiceVibrations.Editor` -- editor importer

### MMFeedbacks System (bundled in Corgi ThirdParty)

MMFeedbacks provides an `MMF_Player` component that sequences feedback events. Each feedback is a self-contained `MMF_Feedback` subclass playable standalone or as part of a sequence.

**~160 Feedback Types, grouped by category:**

**Transform:** Position, PositionShake, PositionSpring, Rotation, RotationShake, RotationSpring, RotatePositionAround, Scale, ScaleShake, ScaleSpring, SquashAndStretch, SquashAndStretchSpring, LookAt, DestinationTransform

**Physics:** Rigidbody, Rigidbody2D

**Animation:** Animation, AnimationCrossfade, AnimatorPlayState, AnimatorSpeed

**Audio:** AudioSource, AudioSourcePitch, AudioSourceVolume, AudioSourceStereoPan, Sound, MMSoundManagerAllSoundsControl, MMSoundManagerSaveLoad, AudioFilterDistortion, AudioFilterEcho, AudioFilterHighPass, AudioFilterLowPass, AudioFilterReverb, AudioMixerSnapshotTransition

**Camera:** CameraShake, CameraZoom, CameraFieldOfView, CameraOrthographicSize, CameraClippingPlanes, CinemachineImpulse, CinemachineImpulseClear, CinemachineImpulseSource, CinemachineTransition

**Post-Process (Built-in):** Bloom, ChromaticAberration, ColorGrading, DepthOfField, Vignette, LensDistortion, Fog

**Post-Process (URP):** Bloom_URP, ChromaticAberration_URP, ColorAdjustments_URP, DepthOfField_URP, Vignette_URP, LensDistortion_URP, ChannelMixer_URP, FilmGrain_URP, GlobalPPVolumeAutoBlend_URP, WhiteBalance_URP

**Post-Process (HDRP):** Bloom_HDRP, ChromaticAberration_HDRP, ColorAdjustments_HDRP, DepthOfField_HDRP, Vignette_HDRP, LensDistortion_HDRP, ChannelMixer_HDRP, FilmGrain_HDRP, Exposure_HDRP, WhiteBalance_HDRP

**Light:** Light, Light2D_URP

**Material / Shader:** Material, MaterialSetProperty, ShaderController, ShaderGlobal, TextureOffset, TextureScale, Skybox

**VFX:** InstantiateObject, VisualEffect, VisualEffectSetProperty

**Springs (custom spring physics):** SpringColor, SpringFloat, SpringVector2, SpringVector3, SpringVector4

**UI (uGUI):** CanvasGroup, CanvasGroupBlocksRaycasts, Graphic, GraphicCrossFade, Image, ImageAlpha, ImageFill, ImageMaterial, ImageRaycastTarget, ImageSprite, ImageTextureOffset, ImageTextureScale, Fade, Flash, Flicker, Blink, FloatingText

**UI (TMP):** TMPText, TMPColor, TMPAlpha, TMPFontSize, TMPCountTo, TMPCountToLong, TMPTextReveal, TMPDilate, TMPSoftness, TMPOutlineColor, TMPOutlineWidth, TMPCharacterSpacing, TMPLineSpacing, TMPWordSpacing, TMPParagraphSpacing, Text, TextColor, TextFontSize

**UI (UI Toolkit):** UIToolkit, UIToolkitBackgroundColor, UIToolkitBorderColor, UIToolkitBorderRadius, UIToolkitBorderWidth, UIToolkitClass, UIToolkitFontSize, UIToolkitImageTint, UIToolkitOpacity, UIToolkitRotate, UIToolkitScale, UIToolkitSize, UIToolkitStylesheet, UIToolkitText, UIToolkitTextColor, UIToolkitTransformOrigin, UIToolkitTranslate, UIToolkitVisible

**GameObject / Scene:** SetActive, Enable, Destroy, Layer, SetParent, LoadScene, UnloadScene, Collider, Collider2D

**Time / Frame:** TimescaleModifier, FreezeFrame, HoldingPause

**Logic / Control:** Events, RandomEvents, MMGameEvent, Broadcast, BroadcastProxy, RadioSignal, Feedback, Feedbacks, Looper, LooperStart, PlayerChain, PlayerConfiguration, PlayerControl, PlayerCopy, PlayerDebugInput, PlayerEnabler, Playlist

**Renderer:** SpriteRenderer, SpriteRendererAlpha, Sprite, SpriteSheetAnimation, LineRenderer, TrailRenderer, VideoPlayer

**Misc:** Wiggle, FloatController, Property, PPMovingFilter, Haptics, DebugBreak, DebugComment, DebugLog, RectTransformAnchor, RectTransformOffset, RectTransformPivot, RectTransformSizeDelta

**Corgi-Specific:** CorgiEngineEvent, CorgiEngineFloatingText, CorgiEngineSound

### NiceVibrations (Haptics)

Lofelt SDK for iOS/Android haptic feedback. Key classes:
- `HapticClip` -- .haptic file asset (waveform data)
- `HapticController` -- play/stop clips, amplitude/frequency override
- `HapticSource` -- component-based haptic player (analogous to AudioSource)
- `HapticPatterns` -- preset enums (Success, Warning, Failure, LightImpact, MediumImpact, HeavyImpact, RigidImpact, SoftImpact, Selection)
- `MMF_Haptics` -- NiceVibrations bridge feedback type for MMF_Player sequences

Controller haptics (Xbox, PS, Switch) supported via Unity's `Gamepad.current.SetMotorSpeeds()` fallback.

### Install Notes

- Feel does NOT trigger the FBX catalog scan (confirmed in Session 46)
- When Corgi Engine is installed, Feel only adds NiceVibrations -- MMFeedbacks is already present in Corgi ThirdParty
- The demo scenes (FeelDemos, FeelDemosHDRP, FeelDemosURP) reference both NiceVibrations and MMFeedbacks but are optional

### Overlap Analysis

| System | Overlap | Notes |
|--------|---------|-------|
| Corgi Engine (ENTRY-240) | HIGH (MMFeedbacks) | Corgi bundles MMFeedbacks. If Corgi is installed, don't install Feel for MMFeedbacks -- you already have it. Install Feel only for NiceVibrations haptics. |
| Damage Numbers Pro (ENTRY-235) | LOW | DNP handles floating number UI; MMFeedbacks handles the broader juice orchestration. Complementary. |
| Audio Manager (Corgi MMTools) | LOW | MMTools includes MMSoundManager; MMFeedbacks audio feedbacks integrate with it. Same ecosystem. |

### Verdict Rationale

Approved, **Recommended**. MMFeedbacks is the industry reference for Unity game feel/juice. The feedback type breadth (160+ types, covering transform, audio, camera, post-process, UI, and more) makes it applicable to every project in the portfolio. The spring physics system (`SpringFloat`, `SpringVector3`, etc.) is genuinely useful for organic UI and object motion. NiceVibrations adds mobile/controller haptic support that no other evaluated asset provides.

**Install guidance:** If Corgi Engine is installed, do not install Feel solely for MMFeedbacks. Only install Feel when NiceVibrations haptics are needed. If Corgi is not installed and game feel/juice is needed, install Feel standalone.

### Project Relevance

| Project | Relevance | Notes |
|---------|-----------|-------|
| All projects | HIGH (MMFeedbacks) | Game feel benefits every project. Use MMF_Player to sequence hit reactions, UI transitions, level events. |
| Mobile projects | HIGH (NiceVibrations) | DLYH, Shrunken Head Toss -- haptic feedback on mobile; NiceVibrations provides this. |
| FearSteez | HIGH | Hit feedback, combo effects, screen shake -- all covered by MMFeedbacks. Corgi Engine bundles it. |
| HOK | HIGH | Rod pull, fish hit, catch celebration -- MMFeedbacks handles all juice sequencing. |

---

## ENTRY-242: FPS Animation Framework 4.9.3 (Kinemation)

**Date:** 2026-03-02 (Session 46)
**Source:** Asset Store
**Category:** Scripting (Layer-Based FPS Arm/Weapon Animation System)
**Verdict:** Approved
**Label:** Recommended | Animation
**Namespace:** `Kinemation`

### Overview

FPS Animation Framework (FPSAF) is Kinemation's dedicated system for first-person arm and weapon animation. It uses Unity's Playables API and Animation Jobs to build a layer stack on top of any animation clips, adding procedural sway, recoil, IK hand placement, ADS transitions, weapon collision, and camera shake without requiring a custom animator controller. Purchased at 60% off as a dependency of Advanced Look Component (ENTRY-244).

### Asset Structure

```
Assets/KINEMATION/
  FPSAnimationFramework/
    Runtime/        -- 58 scripts
    Editor/         -- editor tools
  Shared/           -- shared Kinemation utilities (52 scripts)
  Plugins/          -- native/platform plugins
  ProceduralRecoilAnimationSystem/ -- 3 scripts (bundled)
```

**Asmdefs (8):**
- `FPSAnimationFramework.Runtime` / `.Editor`
- `KAnimationCore.Runtime` / `.Editor` -- shared core (required by Retarget Pro, Advanced Look Component)
- `RecoilAnimation.Runtime`
- `ScriptableWidget.Runtime` / `.Editor` -- SO-based UI widget system

### Layer Architecture

FPSAF wraps any Animator with a layer stack. Each layer is an `IAnimationLayerJob` processed in order:

| Layer | Purpose |
|-------|---------|
| `PoseSamplerLayer` | Samples base animation clips |
| `BlendingLayer` | Blends between poses (locomotion, ads, etc.) |
| `AdditiveLayer` | Additive offsets (breathing, idle sway) |
| `AdsLayer` | Aim-Down-Sights transition |
| `SwayLayer` | Mouse/stick-driven weapon sway |
| `IkLayer` | Two-bone IK for hand placement |
| `IkMotionLayer` | IK-driven procedural motion |
| `LookLayer` | Look-at integration (bridges to ALC) |
| `CollisionLayer` | Weapon collides with walls/geometry |
| `TurnLayer` | Root motion turn integration |
| `ViewLayer` | Camera view model offset |
| `RecoilPattern` | Procedural recoil curves |

**Key Components:** `FPSAnimator` (main controller), `FPSAnimatorProfile` (SO config), `FPSAnimatorEntity` (per-character setup), `FPSBoneController` (procedural bone override), `FPSCameraController` + `FPSCameraAnimation` + `FPSCameraShake`

### Ecosystem

Part of the Kinemation ecosystem: FPSAF + Retarget Pro (ENTRY-243) + Advanced Look Component (ENTRY-244). KAnimationCore is the shared runtime all three depend on.

### Verdict Rationale

Approved, **Recommended | Animation**. The layer architecture is the correct approach for FPS animation -- procedural layers composited over base clips rather than baking everything into one complex Animator. The Playables/Jobs foundation means it runs efficiently and integrates with Animancer (both use Playables). Primary portfolio target is any FPS or third-person shooter (FS Shooter System, FearSteez ranged mechanics, Alpha Foxtrot Uniform). HOK has no FPS arms but could use the camera shake layers.

**Project Relevance:** FearSteez (FPS/ranged sections) -- HIGH. FS Shooter System integration -- HIGH. Alpha Foxtrot Uniform (3D action) -- HIGH. HOK -- LOW (no FPS view).

---

## ENTRY-243: Retarget Pro 4.2.1 (Kinemation)

**Date:** 2026-03-02 (Session 46)
**Source:** Asset Store
**Category:** Scripting (Runtime Animation Retargeting System)
**Verdict:** Approved
**Label:** Recommended
**Namespace:** `Kinemation`

### Overview

Retarget Pro solves animation retargeting between different character skeletons at runtime. Instead of the offline Humanoid avatar retargeting baked into Unity's importer (which requires Humanoid rig type and loses some fidelity), Retarget Pro works with Generic rigs and allows runtime bone mapping with IK correction. This is a pipeline tool -- it works alongside any animation framework (Animancer, Mecanim, FPSAF).

### Scripts (18 runtime)

`RetargetProComponent` -- main component, hosts RetargetProfile
`DynamicRetargeter` -- runtime bone mapping engine
`RetargetProfile` -- ScriptableObject configuration
`RetargetFeature` / `RetargetFeatureState` -- base feature type
`BasicRetargetFeature` -- direct bone-to-bone copy with scale compensation
`IKRetargetFeature` -- IK-corrected retargeting (more accurate for limbs)
`FPSRetargetFeature` -- integrates with FPS Animation Framework
`BonePoserFeature` -- pose individual bones (for correction)
`CopyBoneFeatureSettings` -- copy specific bone transforms

**Asmdefs:** `RetargetPro.Runtime`, `RetargetPro.Editor`

### Use Cases

- Apply combat animations from one character skeleton to another (FearSteez characters using Frank Climax animations)
- Share a base locomotion set across multiple character types
- Fix T-pose bind pose mismatches between motion-captured source and target rig
- Runtime character customization (swap body parts, adjust proportions)

### Verdict Rationale

Approved, **Recommended**. At $29.99, animation retargeting is one of the most practical pipeline problems in game development. Every project with more than one humanoid character type needs it. The IK correction makes it meaningfully better than Unity's built-in Humanoid retargeting. No animation framework dependency -- works with everything.

**Project Relevance:** FearSteez (retarget Frank Climax anims to player/enemy skeletons) -- HIGH. HOK (retarget animations between character variants) -- MEDIUM. All projects with multiple humanoid characters -- HIGH.

**MCP Tool Evaluation (Session 55):** Evaluated for custom MCP tool potential. Only viable tool would be a batch-bake tool (`BakeAnimation(clip)` is clean API). However, profile setup requires UI -- the `RetargetProfile` ScriptableObject must be configured manually (bone chain mapping, IK features). A single batch-bake tool without profile setup is not useful enough to justify. Decision: no custom MCP tools for Retarget Pro. All practical workflow remains UI-driven.

---

## ENTRY-244: Advanced Look Component 2.0.0 (Kinemation)

**Date:** 2026-03-02 (Session 46)
**Source:** Asset Store
**Category:** Scripting (Look-At IK Component)
**Verdict:** Approved
**Label:** Recommended
**Namespace:** `Kinemation`

### Overview

Advanced Look Component (ALC) is a focused look-at IK tool. Three scripts: the component itself, a settings asset, and an editor drawer. It integrates with FPSAF via `LookLayer` but also works standalone via KAnimationCore. Requires FPS Animation Framework (same KAnimationCore dependency).

**Scripts:** 3 (LookAt, LookLayerJob, LookLayerSettings)
**Dependency:** KAnimationCore (bundled in FPSAF)

### Verdict Rationale

Approved, **Recommended**. At $7.99 it is essentially free. Any game with humanoid characters benefits from look-at IK for NPCs tracking the player, characters looking at objects of interest, or player characters aiming. The tight Kinemation ecosystem integration is a bonus if FPSAF is already in the stack.

---

## ENTRY-245: FS Grappling Hook System 1.2.5 (Fantacode Studios)

**Date:** 2026-03-02 (Session 46)
**Source:** Asset Store
**Category:** Scripting (Physics Grapple Hook / Swing System)
**Verdict:** Approved
**Label:** --
**Namespace:** `FS` (Fantacode Studios convention)

### Overview

Fifth Fantacode Studios asset in the stack, joining FS Melee (ENTRY-219), FS Rope Swinging (ENTRY-220), FS Shooter (ENTRY-221), and the base Combat Core. Provides a physics-based grappling hook with rope simulation and swing arc.

### Scripts (11, no demo separation)

`GrapplingHookController` -- core grapple physics, rope tension, swing arc
`GrapplingGunItem` + `GrapplingGunObject` -- weapon item integration
`EnvironmentScannerGrapplingHook` -- grapple point detection (surface scanning)
`FSSystemsSetupGrappling` -- integration helper for FS system
`CreateGrapplingHookCharacterWindow` -- editor setup wizard
`GrapplingWelcomWindow` -- asset info
`GrapplingInputAction` (note: apostrophe in filename -- possible naming issue)
`Rope` -- rope simulation component

**No asmdef** -- Assembly-CSharp. No demo scripts (all scripts are runtime-relevant).

### Fantacode Studios FS Family

| Asset | Entry | Purpose |
|-------|-------|---------|
| FS Melee Combat System 2.0.6 | ENTRY-219 | Melee combat foundation |
| FS Rope Swinging System 1.2.4 | ENTRY-220 | Rope/swing traversal |
| FS Shooter System 1.2 | ENTRY-221 | Third/first-person shooting |
| FS Grappling Hook System 1.2.5 | ENTRY-245 | Grapple hook traversal |

All FS assets share the `FSSystemsSetup` pattern for integration and are designed to compose.

### Verdict Rationale

Approved, **no label**. Grappling hook traversal is a specific mechanic, not universally needed. However, within the FS family it completes the traversal toolkit alongside FS Rope Swinging. For A Quokka Story (Metroidvania traversal) and FearSteez (environment navigation), grapple hook is a natural fit. The `EnvironmentScannerGrapplingHook` suggests smart surface detection, not just a fixed-point grapple.

**Project Relevance:** A Quokka Story (traversal mechanics) -- HIGH. FearSteez (combat movement) -- MEDIUM. Miracle Worker / Alpha Foxtrot Uniform (3D movement) -- MEDIUM.

---

## ENTRY-246: Frank FS4 - Fighting Set 4 + FS3 1.0 (Frank Climax)

**Date:** 2026-03-02 (Session 46)
**Source:** Asset Store
**Category:** Animation (Fighting / Beat Em Up Animation Library)
**Verdict:** Approved
**Label:** -- | Animation
**Namespace:** N/A (animation-only, no scripts)

### Overview

Animation-only pack bundling two complete fighting animation sets: **FS3** (an older, more extensive set) and **FS4** (a newer fighting set). No scripts -- pure FBX animation data plus character meshes for previewing. Companion to Frank Slash Pack (ENTRY-167, Approved) which covers sword/weapon animations.

### FS3 Animation Set (219 FBX clips)

| Category | Count | Contents |
|----------|-------|---------|
| Basic_Move | 34 | Idle, dash, jump, guard stances, charge, tumbling, turns, crouch |
| Combo | 12 | 12 full combo sequences (all hits in one clip) |
| Combo_Cut | 32 | Individual hit clips for each combo (split for state machine use) |
| Fury | 2 | Fury mode attack + hit reaction |
| Getup | 10 | 10 getup variants (roll F/B/L/R, spring, crouch, mid/low attack) |
| Grapple | 11 | Grapple initiation, success, fail, defender reactions (F/B) |
| Hit | 27 | Hit reactions from all directions, heights, knockback, wall hits |
| Kick | 22 | Ground kicks, air kicks, crouch kicks, blocked variants |
| KO | 6 | Knockout animations (high/mid/low, 2 per) |
| Locomotion | 46 | Walk/run all directions, sprint, turns L/R/180, getup from floor |
| Punch | 13 | Ground punches, air punches, crouch punches, body check |
| Soft_Landing | 4 | Soft landing F/B/L/R |

### FS4 Animation Set (24 multi-clip FBX files)

Each FBX contains multiple animation clips. Categories: Basic, Attack1, Attack2, Defence, Combination_All, Atk_Back, Parry, Parry_reAct, Grab, Grab_reAct, Grab_Fail, Grab_Fail_reAct, Hit, Jump, Air_Atk, Air_Combination, GetUp, KO, Soft_Landing, Atk_Running, Cinematic_Atk, Cinematic_Atk_reAct, Locomotion, Combination_Split.

**Included Meshes:** Frank FS3 (earlier character design) + Frank FS4 (updated design) + Frank FS4 RootMotion variant. Demo Animator Controllers for previewing.

### Frank Climax Ecosystem

| Asset | Entry | Contents |
|-------|-------|---------|
| Frank Slash Pack (11 assets) | ENTRY-167 | Sword, axe, spear, staff, bow, shield, dual-wield + locomotion |
| Frank FS4 - Fighting Set 4 + FS3 | ENTRY-246 | Unarmed fighting (219 FS3 + 24 FS4 FBX files) |

Together these two cover armed combat (Slash Pack) + unarmed combat (FS4+FS3) for beat-em-up games.

### Verdict Rationale

Approved, **-- | Animation**. The FS3 set at 219 clips is remarkably deep -- full directional hit reactions, combo split clips, grapple sequences, and KO states are exactly what a beat-em-up requires. The Combo_Cut splits are particularly valuable -- having each combo hit as a separate clip is required for state machine and Animancer graph transitions (versus full-combo clips that must play end-to-end). FS4 adds a newer style with parry/counter mechanics.

Primary target is FearSteez. Secondary targets: any project needing fighting animations (Necro Ricochet, HumiliNation).

---

## ENTRY-247: fBasic Assets 1.2.7 (FImpossible Creations)

**Date:** 2026-03-02 (Session 46)
**Source:** Asset Store (Free)
**Category:** Scripting (Shared Base Library / Starter Toolkit)
**Verdict:** Approved
**Label:** --

### Overview

fBasic Assets is FImpossible Creations' free shared base library. It installs automatically under `Assets/FImpossible Creations/Plugins - Shared/FBasic Assets/` and is a dependency of most FImpossible Creations paid assets (Ragdoll Animator 2, Ground Fitter, F Texture Tools -- ENTRIES 216-218). It also functions as a standalone starter kit with character controllers, cameras, interaction areas, and 13 unique creature/character meshes.

### Scripts (68 total, no asmdef, Assembly-CSharp)

**Character Controllers:** `FBasic_CharacterController`, `FBasic_CharacterHorizontalBase`, `FBasic_CharacterInputAxis/Keys`, `FBasic_CharacterMovementBase`, `FBasics_RigidbodyMover/Base`, `FBasics_Rigidbody2DMover/Base`
**Cameras:** `FBasic_FreeCameraBehaviour`, `FBasic_TPPCameraBehaviour`
**Interaction:** `FBasic_InteractionAreaBase/Canvas`, `FBasic_TrueInteractionBase`, `FBasic_Draggable`, `FBasic_Pullable`, `FBasic_PullableDrawer/Hinge/Knob/Lever`
**Physics:** `FBasic_AddPhysicalImpact`, `FBasic_RigidbodyMovement`, `FBasic_ProjectileBase`
**Material Animators:** `FBasic_MaterialFloatAnimate`, `FBasic_MaterialOffset`, `FBasic_MaterialRandomColor`, `FBasic_MaterialTiler`, `FBasic_MaterialScriptBase`
**Utilities:** `FBasic_DestroyAfter`, `FBasic_DestroyOthersWithMe`, `FBasic_FadeOutMaterialAndDestroy`, `FBasic_TimedExecutor`, `FBasic_TriggerEvents`, `FBasic_DuplicateObjects`, `FBasic_SphericDuplicateOn`, `FBasic_ObjectVibrate`, `FBasic_RotateTo`, `FBasic_Rotator`, `FBasic_Spinner`, `FBasic_SlideObjectTo`, `FBasic_FollowTarget`, `FBasic_HoldPosition`, `FBasic_OffsetMovement`, `FBasic_TranslateTransformSpace`, `FBasic_FlyMovement`
**Animation:** `FBasic_AnimatorPlayState`
**Conversation:** `FBasic_Conversation`, `FBasic_Conversation_UI`
**Misc:** `FBasics_AgentMover`, `FBasic_PowerUpObject`, `FBasic_SharedPanelAnimations`, `FBasic_CourutineHelper`

**Included Models (13 fantasy creatures/characters):** Feetle, Fheelek, Fhreeped, Filipede, Finosaur, Fiped, Fockatrice, Folf, Fpider, Fultieye, Fuman (human-style), Knob, plus weapon and prop meshes.

### Verdict Rationale

Approved, **no label**. fBasic is a dependency pull-in -- if any FImpossible Creations asset is installed, fBasic is already there. As a standalone it is a useful prototyping toolkit (interaction areas, material animators, basic controllers) but nothing here supersedes existing evaluated assets. The pullable/interactive object system (Pullable, PullableDrawer, PullableKnob, PullableLever) is a cherry-pick candidate for puzzle games. The creature models are charming but stylized for FImpossible's demo scenes.

---

## ENTRY-248: Spoke 1.2.2

**Date:** 2026-03-02 (Session 46)
**Source:** Asset Store
**Category:** Scripting (Reactive Programming / Signals Library)
**Verdict:** Approved
**Label:** --
**Namespace:** `Spoke`

### Overview

Spoke is a reactive programming library for Unity -- the C# equivalent of React Signals, MobX, or SolidJS signals. It provides fine-grained reactive primitives (State, Memo, Effect, Reaction) built on a low-level Epoch/Ticker/SpokeTree runtime. Changes to a `State` automatically propagate to dependent `Memo` and `Effect` nodes without requiring manual observer registration.

### Scripts (33, no asmdef, in Assets/Plugins/Spoke/)

**Runtime Primitives:**
`State<T>` -- observable value container (`IRef<T>` read, write triggers dependency graph)
`Memo<T>` -- derived computed value (re-evaluates when dependencies change)
`Effect` -- side effect that runs when dependencies change
`Reaction` -- like Effect but with old/new value comparison
`Trigger` -- manual signal (event-like, not value-carrying)

**Runtime Engine:**
`Epoch` -- the fundamental execution unit (closures with dependency tracking)
`LambdaEpoch` -- lambda-based epoch for quick use
`Ticker` -- schedules epoch execution in dependency order
`SpokeTree` -- hierarchy of epochs (parent/child lifetime)
`Dock` -- import/export point for cross-tree communication
`Heap` -- priority queue for ticker ordering

**Unity Integration:**
`SpokeBehaviour` -- MonoBehaviour base with Spoke lifecycle (Init/Tick/Dispose)
`UState<T>` -- Unity-optimized state (serializable, Inspector-visible)
`SpokeRuntime` -- singleton runtime manager
`SpokeSingleton<T>` -- SO singleton pattern
`SpokePool` -- object pooling
`SpokeIntrospect` -- debugging/visualization
`UnitySignals` -- bridge between Spoke and Unity events

### Use Case Assessment

Spoke fits best for:
- Reactive UI where many elements depend on shared game state (health, score, inventory count)
- Game state machines where entering a state triggers cascading reactions
- Data binding between model and view without manual refresh calls
- Replacing event bus patterns where ordering and dependency chains matter

It does NOT replace:
- The custom GameEvent/GameEventListener system (different pattern -- Spoke is pull-based reactive, GameEvents are push-based)
- UniTask for async operations
- The SO architecture (Spoke can complement it -- SOs hold data, Spoke reacts to changes)

### Verdict Rationale

Approved, **no label**. Spoke is architecturally interesting but situational. For HOK and most TecVooDoo projects, the existing GameEvent system + SO data + UniTask covers the same ground with less abstraction overhead. Spoke adds value in data-heavy UI (inventory screens, stat pages with many reactive displays) or complex state machines where dependency ordering matters. Not a default import -- evaluate per-project when reactive state management becomes painful without it.

---

## ENTRY-249: Photon Fusion 2.0.9 (Exit Games)

**Date:** 2026-03-02 (Session 46)
**Source:** Asset Store
**Category:** Scripting (Next-Gen Multiplayer Networking SDK)
**Verdict:** Approved
**Label:** Recommended
**Namespace:** `Fusion`

### Overview

Photon Fusion 2 is Exit Games' next-generation Unity multiplayer SDK, positioned as the successor to PUN2 (ENTRY-228, Approved, Recommended). Fusion offers two simulation modes: **Shared State** (simple, PUN-like authority) and **Server/Client** (full dedicated server, deterministic rollback). This install includes BOTH Fusion and PUN2 under the same Photon package.

### Asset Structure

```
Assets/Photon/
  Fusion/            -- Fusion 2 SDK (36 non-demo scripts)
  FusionDemos/       -- demo scenes
  FusionMenu/        -- matchmaking UI
  PhotonLibs/        -- native WebSocket + Photon core libs
  PhotonUnityNetworking/ -- PUN2 (separate SDK, ENTRY-228)
```

**Asmdefs (4):**
- `Fusion.Unity` -- runtime SDK
- `Fusion.Unity.Editor` -- editor tooling
- `Fusion.CodeGen` -- IL code weaver (injects network serialization)
- `PhotonWebSocket` -- WebGL WebSocket transport

### Key Classes

`NetworkCharacterController` -- Fusion-aware character controller
`FusionBootstrap` -- session setup, server/client mode selection
`FusionStatsCanvas` / `FusionStatistics` -- in-game network stats display
`FusionNetworkObjectStatistics` -- per-object bandwidth tracking
`NetworkObjectProviderDefault` -- prefab spawning registry
`FusionHubWindow` -- in-editor dashboard

### Fusion vs PUN2

| Feature | PUN2 (ENTRY-228) | Fusion 2 (ENTRY-249) |
|---------|-----------------|---------------------|
| Architecture | Master client authority | Server/Client or Shared |
| Rollback/Prediction | No | Yes (Client-Server mode) |
| Max players | 16 typical | 100+ with Server mode |
| Code weaver | No | Yes (Fusion.CodeGen) |
| Migration effort | -- | Moderate from PUN2 |
| Best for | Small co-op, turn-based | Action games, larger scale |

### Verdict Rationale

Approved, **Recommended**. Fusion 2 is the correct choice for any new multiplayer project (not PUN2, which is legacy). The code weaver (Fusion.CodeGen) automatically injects network synchronization into marked classes, significantly reducing boilerplate. Having both SDKs installed allows migration project-by-project. For TecVooDoo projects: Dots and Boxes (web, live) uses its own stack; future multiplayer Unity projects should build on Fusion 2.

**Project Relevance:** Necro Ricochet (multiplayer party) -- HIGH. Aunt T's (board/card, multiplayer) -- HIGH. Any future Unity online multiplayer -- HIGH.

---

## ENTRY-250: Motion Warping 3.2.0 (Kinemation)

**Date:** 2026-03-02 (Session 46)
**Source:** Asset Store
**Category:** Scripting (Root Motion Warp / Traversal System)
**Verdict:** Approved
**Label:** Recommended | Animation
**Namespace:** `Kinemation`

### Overview

Motion Warping lets you warp root motion animations to dynamically hit targets at runtime -- without baking separate animation clips per obstacle. A vault animation plays correctly regardless of whether the ledge is 0.8m or 1.2m high; the system stretches/compresses the root motion to match the actual geometry. This solves one of the hardest traversal problems in character animation: making canned animations fit unpredictable level geometry.

### Scripts (20 total, 2 asmdefs)

**Runtime (14):**

| Script | Purpose |
|--------|---------|
| `MotionWarping` | Core component -- hosts warp zones, drives the warp |
| `MotionWarpingAsset` | ScriptableObject config per warp definition |
| `MotionWarpingIk` | IK correction during warp (foot/hand placement) |
| `WarpObstacle` | Tags geometry as a warp target (ledge, vault surface) |
| `WarpProviderInterface` | Interface for custom warp target providers |
| `WarpingUtility` | Math helpers for warp interpolation |
| `TwoBoneIk` | Standalone two-bone IK solver (used by MotionWarpingIk) |
| `MantleComponent` | High ledge mantle traversal |
| `MantleSettings` | SO config for mantle (height range, timing) |
| `HangComponent` | Ledge hang / hang-to-climb |
| `VaultComponent` | Low obstacle vault traversal |
| `VaultSettings` | SO config for vault (height range, timing) |
| `AlignComponent` | Align character to surface before warp begins |
| `ReadOnlyAttribute` | Editor attribute |

**Editor (6):** `MotionWarpingAssetEditor`, `WarpingEditorUtility`, `WarpPosePreviewWidget`, `WarpWidgetInterface`, `WarpWindowWidget`, `ReadOnlyDrawer`

**Asmdefs:** `MotionWarping.Runtime`, `MotionWarping.Editor`

### How It Works

1. Animation clips are authored with root motion for a "standard" obstacle size
2. `MotionWarpingAsset` defines warp zones within the clip (start frame, end frame, warp type)
3. At runtime `WarpObstacle` provides the actual target transform from level geometry
4. `MotionWarping` component stretches/translates root motion between warp zone frames to hit the real target
5. `MotionWarpingIk` corrects hand/foot placement during the warp

Built-in traversal components (Mantle, Vault, Hang, Align) provide ready-to-use examples for the most common cases.

### Kinemation Ecosystem (Complete)

| Asset | Entry | Purpose |
|-------|-------|---------|
| FPS Animation Framework 4.9.3 | ENTRY-242 | Layer-based FPS arm/weapon animation |
| Retarget Pro 4.2.1 | ENTRY-243 | Runtime skeleton retargeting |
| Advanced Look Component 2.0.0 | ENTRY-244 | Look-at IK |
| Motion Warping 3.2.0 | ENTRY-250 | Root motion warp / traversal |

All share `KAnimationCore` (Runtime/Editor). No conflicts between the four -- they address different animation problems.

### Verdict Rationale

Approved, **Recommended | Animation**. Motion warping is a production-quality solution to a genuinely hard problem. The alternative is baking dozens of animation variants per obstacle height, which is unsustainable. For any game with environmental traversal (A Quokka Story, Alpha Foxtrot Uniform, FearSteez parkour/movement, Miracle Worker) this is the correct approach. The bundled Mantle/Vault/Hang components mean common cases work out of the box; custom warp targets are straightforward via `WarpProviderInterface`.

**Project Relevance:** A Quokka Story (Metroidvania climbing/traversal) -- HIGH. FearSteez (parkour, environmental movement) -- HIGH. Alpha Foxtrot Uniform (3D action traversal) -- HIGH. HOK -- LOW (no traversal mechanics).

---

## ENTRY-251: Adventure Creator 1.85.5 (Icebox Studios / Chris Burton)

**Date:** 2026-03-02 (Session 46)
**Source:** Asset Store
**Category:** Framework (2D/2.5D/3D Adventure Game / Point-and-Click Engine)
**Verdict:** Approved
**Label:** Recommended
**Namespace:** `AC`
**Publisher:** Chris Burton (Icebox Studios)

### Overview

Adventure Creator is the Unity standard for point-and-click adventure game development. It provides a complete no-code/low-code framework for 2D, 2.5D, and 3D adventure games: visual ActionList scripting, inventory, dialogue, cutscenes, camera systems, save/load, translations, and a full navigation system. Supports all three perspectives out of the box with dedicated templates and demo scenes for each. Actively maintained (v1.85.5 at time of evaluation, manual covers v1.82).

### Asset Structure

```
Assets/AdventureCreator/
  Scripts/          -- 673 non-demo scripts, 1 asmdef (AC)
  Editor/           -- editor windows and tools
  Prefabs/          -- AC system prefabs
  Resources/        -- runtime resources
  UI/               -- default UI prefabs
  Graphics/         -- icons, cursors
  Default/          -- default ActionList assets
  Demo/             -- 3D demo game
  2D Demo/          -- 2D demo game
```

**Total non-demo scripts:** 673
**Asmdefs:** 1 (`AC`)

### Manager Architecture

AC is configured through 8 global Manager assets, all edited in the Game Editor window (`Adventure Creator > Editors > Game Editor`):

| Manager | Controls |
|---------|---------|
| `SceneManager` | NavMesh, cameras, scene initialization |
| `SettingsManager` | Movement method, input method, interaction style, camera perspective |
| `ActionsManager` | Which Action types are available, custom action registration |
| `VariablesManager` | Global/local variables, scene attributes, timers |
| `InventoryManager` | Items, crafting, documents, objectives, properties |
| `SpeechManager` | Dialogue lines, translations, lip sync, script sheets |
| `CursorManager` | Cursor icons per interaction type |
| `MenuManager` | All in-game menus (AC menus or Unity UI) |

### ActionList Visual Scripting (137 Action nodes)

ActionLists are AC's no-code scripting system -- sequences of Actions that can be triggered by hotspots, conversations, cutscenes, or triggers. 137 built-in Action types covering:

**Character:** `ActionCharAnim`, `ActionCharFace`, `ActionCharFaceDirection`, `ActionCharFollow`, `ActionCharHold`, `ActionCharMove`, `ActionCharPathFind`, `ActionCharPortrait`, `ActionCharRename`, `ActionCharRender`, `ActionPlayerCheck`, `ActionPlayerLock`, `ActionPlayerSwitch`, `ActionPlayerTeleportInactive`

**Camera:** `ActionCamera`, `ActionCameraCheck`, `ActionCameraCrossfade`, `ActionCameraShake`, `ActionCameraSplit`, `ActionCameraTP`

**Dialogue / Speech:** `ActionSpeech`, `ActionSpeechStop`, `ActionSpeechWait`, `ActionConversation`, `ActionDialogOption`, `ActionDialogOptionRename`

**Inventory:** `ActionInventoryCheck`, `ActionInventoryCheckSelected`, `ActionInventoryCrafting`, `ActionInventoryInteraction`, `ActionInventoryPrefab`, `ActionInventorySelect`, `ActionInventorySet`, `ActionInvProperty`

**Variables:** `ActionVarCheck`, `ActionVarCopy`, `ActionVarPopup`, `ActionVarPreset`, `ActionVarSequence`, `ActionVarSet`

**Scene / Flow:** `ActionScene`, `ActionSceneAdd`, `ActionSceneCheck`, `ActionSceneSwitchPrevious`, `ActionRunActionList`, `ActionStopActionList`, `ActionPause`, `ActionPauseActionList`, `ActionEnd`, `ActionEndGame`, `ActionParallel`, `ActionCheckMultiple`, `ActionRandomCheck`

**Object / Transform:** `ActionTeleport`, `ActionTransform`, `ActionTransformRecord`, `ActionParent`, `ActionRename`, `ActionVisible`, `ActionChangeMaterial`, `ActionInstantiate`, `ActionSendMessage`, `ActionRaycast`

**Save / Options:** `ActionSaveHandle`, `ActionSaveCheck`, `ActionManageSaves`, `ActionManageProfiles`, `ActionOptionSet`

**Menu:** `ActionMenuCheck`, `ActionMenuState`, `ActionMenuItem`, `ActionMenuJournal`, `ActionMenuSelect`, `ActionMenuSetInputBox`, `ActionMenuSlotCheck`

**Audio / Media:** `ActionSound`, `ActionSoundShot`, `ActionMusic`, `ActionAmbience`, `ActionMixerSnapshot`, `ActionVolume`, `ActionMovie`

**Animation / FX:** `ActionAnim`, `ActionBlendShape`, `ActionSpriteFade`, `ActionHighlight`, `ActionFade`, `ActionTintMap`, `ActionTimescale`

**Objectives / Documents:** `ActionObjectiveCheck`, `ActionObjectiveCheckType`, `ActionObjectiveSet`, `ActionDocumentCheck`, `ActionDocumentCollection`, `ActionDocumentOpen`

**Timeline:** `ActionTimeline`, `ActionTrackCheck`, `ActionTrackRegion`, `ActionTrackSet`

**Input / QTE:** `ActionInputActive`, `ActionInputCheck`, `ActionInputSimulate`, `ActionQTE`

**Third-Party:** `ActionPlayMaker` (calls PlayMaker FSM events)

### Camera System

7 built-in GameCamera types:
`GameCamera` (standard follow), `GameCameraArray` (fixed angle array), `GameCameraThirdPerson`, `GameCamera25D` (2.5D background with sprite depth), `GameCamera2D`, `GameCamera2DDrag`, `GameCameraAnimated`. Full Cinemachine integration (exclusive or mixed mode). Timeline camera tracks included.

### Navigation

5 pathfinding backends: Unity NavMesh, Mesh Collider, Polygon Collider, A* 2D, Custom. `NavigationEngine` base class for custom implementations.

### Save System (62 scripts)

Full scene state serialization with `Remember*` components for every AC object type (Animator, Collider, Container, Conversation, Hotspot, Material, Moveable, and more). File formats: JSON, XML, Binary, custom. Save profiles, autosave, loading screens, cross-game save imports. Custom save data via `ISave` interface.

### Speech & Dialogue

Built-in dialogue authoring with translation support (CSV export/import via script sheets). Lip sync (automatic, SALSA integration, texture-based). Facial expressions. External tool integration via Dialogue System (ENTRY-214). Unity Localization package integration for translation data.

### Templates (ready-to-use starting points)

`SamplePlayer2D`, `SamplePlayer3D`, `SamplePlayerFP` -- player characters per perspective
`SampleScene2D`, `SampleScene3D` -- scene starters with comments
`NineVerbs` -- classic LucasArts 9-verb interface
`TitleScreen` -- main menu with New/Continue
`GraphicOptions` -- resolution/quality settings menu
`MobileJoystick` -- on-screen touch controls
`TMPro` -- converts all menus to TextMesh Pro
`AnimatedCursor` -- Unity UI animated cursor
`CutsceneBorders` -- letterbox effect for cutscenes

### Integrations

**Built-in:** Addressables, Unity Localization, PlayMaker (variable linking + FSM event calling), SALSA lip sync, TextMesh Pro
**Official downloads (AC website):** AI Tree, articy:draft, Cinemachine, Kinematic Character Controller, Input System, **UCC** (Ultimate Character Controller -- ENTRY-165)
**Community/unofficial:** A* Pathfinding Pro (ENTRY-164), Animal Controller, Final IK, Spine, and others

The UCC integration is significant -- UCC handles the runtime character movement/physics, AC handles all adventure game logic (hotspots, inventory, dialogue, cutscenes). This is the correct stack for 3D adventure games that need more than AC's built-in character controller.

### Verdict Rationale

Approved, **Recommended**. Adventure Creator is the uncontested Unity standard for point-and-click and adventure game development with over a decade of active maintenance. The ActionList visual scripting, 8-manager system, and full-perspective support (2D/2.5D/3D) make it a complete starting point. The UCC integration means complex 3D player movement and AC's adventure logic can coexist without conflict.

Directly relevant to multiple TecVooDoo projects that are in concept/planning and have no engine foundation yet. The 3D point-and-click projects (GRIMMORPG, Space Garbage Man) are the primary targets. The visual novels (Encapsulated Fear, Genie in a Test Tube, Murder Malady & Monsters) could use AC's conversation and cutscene systems as a lighter alternative to dedicated VN engines, though dedicated VN tools may be more appropriate there.

**Note on overlap with Dialogue System (ENTRY-214):** These are complementary, not competing. AC handles all adventure game structure (hotspots, navigation, inventory, cameras, save). Dialogue System handles narrative branching depth. The two have an official integration -- DS can drive AC's conversation system with richer branching logic than AC's built-in Conversation node.

### Project Relevance

| Project | Relevance | Notes |
|---------|-----------|-------|
| GRIMMORPG | HIGH | 3D point-and-click, exactly AC's wheelhouse. UCC + AC stack. |
| Space Garbage Man | HIGH | 3D point-and-click. Same stack. |
| Encapsulated Fear | MEDIUM | Visual novel -- AC can work but dedicated VN tool may suit better |
| Murder Malady & Monsters | MEDIUM | Visual novel -- same as above |
| Genie in a Test Tube | MEDIUM | Visual novel |
| Miracle Worker | MEDIUM | 3D action/adventure -- AC for interactive sequences, custom for combat |
| HOK | LOW | Not an adventure game |
| FearSteez | LOW | Beat em up, no point-and-click mechanics needed |

---

## Ecosystem Maps

> Ecosystem maps pending recovery from session JSONL. Key pipelines documented in prior sessions:
> - Staggart Water Pipeline (039-041)
> - Kamgam Mesh Tools Pipeline (084-088)
> - Animation Pipeline (089-091, 106-108)
> - Audio Pipeline (101-103, 105, 112-113, 115)
> - UI Toolkit Pipeline (116-135)
> - Editor/Tools Pipeline (003-006, 013, 015, 018, 020, 102, 107-110)

---

## Known Issues / Watch Items

| Flag | Severity | Notes |
|------|----------|-------|
| Detailed entries 001-115 missing | HIGH | Recover from JSONL or re-evaluate as needed |
| Ecosystem map tables missing | MEDIUM | Recover from JSONL |
| Chris West / Mega series | TESTING | Loaded Feb 23. MegaFiers had duplicate install (old Mega-Fiers folder + new MegaFiers). Duplicate resolved. Unity crashed during MegaShapes reinstall -- stability concern flagged. |
| OccaSoftware install complete | RESOLVED | 9 packages in Assets/OccaSoftware/ (ENTRY-170 to 178) + 26 UPM packages in Packages/ (ENTRY-181 to 206). ENTRY-179 (LocalGI) rejected Unity 6 incompatible. ENTRY-180 (Megapack) readme only. All 37 evaluated. |
| Heathen Engineering install complete | RESOLVED | 7 UPM packages (com.heathen.*) + Assets/_Heathen Engineering/ (icons). Steamworks.NET (com.rlabrecque.steamworks.net v20.2.0) added to OpenUPM registry as dependency. ENTRY-130, 131 already existed. New: ENTRY-207 through 213. |
| Session 42 batch install complete | RESOLVED | Pixel Crushers (214-215), FImpossible Creations (216-218), Fantacode Studios (219-221), Fish Alive x2 (222-223), PuppetMaster (224), Body Poser (225). ENTRY-033 superseded by 222-223. |
| Session 44 assets pending removal | PENDING | Flexalon (226, Assets/Flexalon), Aline (227, Packages/com.arongranberg.aline), Photon PUN 2+ (228, Assets/Photon), Behavior Designer (229, Packages/com.opsive.behaviordesigner), Interactor (232, Assets/Interactor). Remove before next unrelated batch. |
| Session 46 assets evaluated | COMPLETE | PlayMaker (233), UI Toolkit Playmaker Integration (234), Damage Numbers Pro (235), Easy Save 3 (236), Grabbit (237), Weather Maker (238), GrabMaster (239), Corgi Engine (240), Feel (241), FPS Animation Framework (242), Retarget Pro (243), Advanced Look Component (244), FS Grappling Hook (245), Frank FS4+FS3 (246), fBasic Assets (247), Spoke (248, Conditional -- removed from project), Photon Fusion 2.0.9 (249), Motion Warping (250), Adventure Creator 1.85.5 (251). |

---

## ENTRY-252: Asset Inventory 4 (Wetzold Studios)

| Field | Value |
|-------|-------|
| **Asset** | Asset Inventory 4 |
| **Version** | 4.x (current, Mar 2025 release) |
| **Developer** | Robert Wetzold / Wetzold Studios (Impossible Robert) |
| **Source** | Asset Store |
| **Primary Label** | Default |
| **Secondary Labels** | QoL |
| **Verdict** | Approved |
| **Date** | 2026-03-04 |
| **Session** | 47 |
| **Prior version** | v3.6.1 running in `E:\Unity\AssetInventoryProject` since Feb 2026 |

**What It Is:** Unity editor tool that indexes your entire asset library (Asset Store cache, UPM cache, additional folders) into a single external SQLite database. From any project that has AI4 installed, you can search 676,000+ individual files across all indexed packages and import just the files you need -- without ever importing the full package into the project.

**Core workflow:** Search for "wolf_idle.fbx" → preview it in the AI4 window → right-click → Import with Dependencies → only that file (and its declared material/texture dependencies) lands in the project. Polyperfect, Kevin Iglesias, Synty -- any package you've ever downloaded can be mined this way without polluting the project with 500+ irrelevant assets.

**Key features (v4 over v3):**

| Feature | Notes |
|---------|-------|
| **Adapt to Render Pipeline** | Auto-runs URP converter on import when enabled. Eliminates the post-import manual conversion step that v3 required. |
| **Project Window Toolbar** | Search and import without opening the full AI4 window. |
| **Override Icons in Project Window** | Asset preview thumbnails visible directly in the Project panel. |
| **Custom Preview Pipeline** | Configurable lighting, camera, super-sampling for prefab previews. Much better than the 128px default for complex prefabs. |
| **Play Animations** | Preview animation clips before importing. |
| **FTP/SFTP Connections** | Remote asset sources (not needed for TecVooDoo workflow). |
| **AI Captions** | Adds AI-generated search metadata (off by default, optional). |

**Shared database architecture:**

The database lives at `E:\Unity\03UnityAssetInventory\Documents\AssetInventory\AssetInventory.db` (332 MB as of Mar 2026, 2,652 packages, 676,566 indexed files). This path is OUTSIDE any Unity project. Any Unity project with AI4 installed and pointed at the shared config (`ASSETINVENTORY_CONFIG_PATH` env var → `C:\Users\steph\OneDrive\Documents\AssetInventoryConfig.json`) reads from the same database. No rebuild per project. No duplication.

This makes AI4 a viable default for every project -- the overhead is an editor-only package import (no runtime cost, no domain reload impact worth measuring).

**URP adapter is the headline v4 upgrade for TecVooDoo:**
All active projects use URP. Many Asset Store packages still ship BIRP materials. In v3, importing any BIRP asset required a manual trip through Edit > Render Pipeline > Upgrade. In v4, the "Adapt to Render Pipeline: Activate" setting fires the converter automatically at import time. This alone makes v4 a meaningful upgrade over v3 for daily use.

**Dependency calculation limitation:**
Cross-package dependency resolution only works for packages using text/YAML serialization. Legacy packages using binary serialization won't have deps auto-resolved. You'll see the missing files and can import them manually. This affects a small minority of older packages.

**Install strategy:**
Do NOT maintain a dedicated project for AI4 (the `AssetInventoryProject` approach from v3 is obsolete). Install in every active project and set `ASSETINVENTORY_CONFIG_PATH` so all installs share the same config and database.

**Setup for a new project:**
1. Import Asset Inventory 4 from Asset Store
2. Set system environment variable `ASSETINVENTORY_CONFIG_PATH=C:\Users\steph\OneDrive\Documents\AssetInventoryConfig.json`
3. Restart Unity -- AI4 reads the shared config and connects to existing database
4. No indexing run needed -- database is already current

**Verdict Rationale:** Default. Every TecVooDoo project benefits from instant search-and-selective-import of 2,600+ packages. The external database means zero per-project indexing cost. The v4 URP adapter eliminates the most common post-import friction. Any project without AI4 is working harder than it needs to.

**Project Relevance:** ALL projects -- HIGH. Especially: Sandbox (asset evaluation), HOK (pull specific fish/environment assets), FearSteez (pull characters, animations, environment pieces without importing full packs).

---

## ENTRY-253: Universal Fighting Engine 2 Pro 2.7.0a (Mind Studios)

| Field | Value |
|-------|-------|
| **Asset** | Universal Fighting Engine 2 Pro (UFE2 Pro) |
| **Version** | 2.7.0a |
| **Developer** | Mind Studios |
| **Source** | Asset Store |
| **Primary Label** | None |
| **Secondary Labels** | Combat |
| **Verdict** | Approved (cherry-pick reference only) |
| **Date** | 2026-03-04 |
| **Session** | 47 |
| **Purchase** | Sale: $20 (regular $340) |

**What It Is:** A complete 1v1 fighting game engine in the Street Fighter / Mortal Kombat / Guilty Gear mold. Handles character selection, round management, health bars, input reading (motions, charge moves, sequences), combo system, hitbox authoring, online play (Mirror/Photon), replay system, AI opponent logic, and more. The core engine is compiled (UFE3D.dll + UFE3D.Editor.dll) -- source is not provided. All configuration is via ScriptableObject data assets.

**Does NOT do:**
- Multiple simultaneous enemies (beat 'em up wave structure)
- Animancer integration -- requires Mecanim Animator Controller
- Third-person or top-down camera modes
- Any camera that isn't 1v1 side-view framing

Forum confirmed on ufe3d.com: multiple enemies "require heavy modifications." This is not an architecture limitation that can be patched around -- the entire character/AI model is 1v1.

**Architecture (from source audit):**

The engine compiles into UFE3D.dll. Game data lives in ScriptableObject assets authored via UFE's custom editors. Key SO types:

| SO Type | Purpose |
|---------|---------|
| MoveData | One move (attack, dash, special, etc.) |
| MoveSetData | Full moveset for a character -- references MoveData SOs |
| HitBoxMap | Per-state body collision map (Idle_Map, Crouch_Map, etc.) |
| CharacterInfo | Character stats, appearance, physics, AI, prefab refs |
| GlobalInfo (Config) | Round settings, camera rules, gauge count, input timing |

**MoveData structure (read from .asset -- Stand_N1 light punch):**

```
totalFrames:    30
startUpFrames:  11    // frames before hitbox is active
activeFrames:    5    // frames hitbox is live
recoveryFrames: 14    // frames after hitbox ends

hits[0]:
  activeFramesBegin: 11
  activeFramesEnds:  15
  hurtBoxes[0]:
    bodyPart: 9       // enum -- 9 = right hand
    shape: 1          // sphere
    _radius: 0.5f
  hitStrength: 2      // medium
  hitStunOnHit: 30f   // frames of stun
  hitStop: 0.1f       // freeze time on connection
  shakeCameraOnHit: 1
  pushForce.x: 10f    // opponent knockback

frameLinks[0]:        // combo chain window
  activeFramesBegins: 22
  activeFramesEnds:   30
  linkableMoves:      [Stand_N2, Stand_N3, Crouch_N1]
  onStrike: 1
  onBlock:  1
```

This is full FGC-standard frame data: startup / active / recovery explicit in frames, per-body-part hitbox assignment, per-hit hit stop + camera shake, explicit combo link windows with valid move lists.

**Cherry-pick value for FearSteez:**

| Concept | Current FearSteez | UFE Model | Value |
|---------|------------------|-----------|-------|
| Frame data | Normalized float (ImpactStart 0.3, ImpactEnd 0.6) | Explicit ints (startUpFrames 11, activeFrames 5, recoveryFrames 14) | HIGH -- upgrade FSAttackData to frame counts at 60fps |
| Hitbox assignment | Single sphere, hardcoded offset | Per-hit, per-body-part (enum 9=right hand) | HIGH -- production hitbox model |
| Hit stop | None | hitStop + freezingTime baked into hit SO | MEDIUM -- implement hit stop in FSCombatController |
| Camera shake on hit | None | shakeCameraOnHit baked into hit SO | MEDIUM -- per-attack camera shake data |
| Combo link windows | NormalizedTime >= ImpactEnd (passive) | explicit frameLinks[] with valid move list | MEDIUM -- more precise combo control |
| State gating | None | selfConditions.possibleMoveStates[] | LOW -- needed later for air attacks, crouching |

**What NOT to copy:** UFE's 1v1 round logic, character select flow, mirror-match networking -- none of this is relevant to FearSteez. The AI system is also 1v1-specific.

**Animation system incompatibility:**
UFE uses Mecanim Animator Controllers via its own AnimData system. The hitbox timing is baked against those animation clips at specific frame counts. You cannot drop Animancer into UFE without rewriting the animation driver layer in the DLL (source not available). The cherry-pick is the DATA DESIGN -- port the frame data structure idea into FSAttackData, not the UFE code.

**Verdict Rationale:** Approved -- cherry-pick reference. The MoveData structure is the best available example of production FGC frame data as ScriptableObjects. The hitbox-per-body-part model is exactly the production target for FearSteez. At $20 these concepts are well worth having the reference installed. Not usable as a runtime dependency -- the 1v1 architecture is fundamentally incompatible with beat 'em up multi-enemy waves, and Animancer incompatibility prevents any direct integration.

**No primary label** -- situational. Only relevant if TecVooDoo builds a 1v1 fighting game. Secondary: Combat, for discoverability.

**Project Relevance:**
- **FearSteez:** HIGH (cherry-pick reference for combat data design only -- see above)
- **All other projects:** None

---

## ENTRY-254: Magic Animation Blend 3.2.2 (KINEMATION)

| Field | Value |
|-------|-------|
| **Asset** | Magic Animation Blend |
| **Version** | 3.2.2 |
| **Developer** | KINEMATION |
| **Source** | Asset Store |
| **Primary Label** | None |
| **Secondary Labels** | Animation |
| **Verdict** | Conditional |
| **Date** | 2026-03-04 |
| **Session** | 48 |
| **Purchase** | Sale |

**What It Is:** Per-bone animation layering system for Unity's Mecanim Animator. From KINEMATION -- same developer as Motion Warping (ENTRY-250), FPS Framework, and other Kinemation packages. Uses Unity's PlayableGraph + AnimationScriptPlayable (Jobs/Burst). Injects a high-priority playable (sort order 900) on top of the Animator's existing PlayableGraph.

**Architecture:**

```
MagicBlending       -- MonoBehaviour, requires Animator + KRigComponent
MagicBlendAsset     -- ScriptableObject, defines the blend configuration
KRig                -- ScriptableObject from KINEMATION shared package (KAnimationCore)
KRigComponent       -- MonoBehaviour that maps bones to KRig hierarchy
```

**MagicBlendAsset fields:**
```
KRig rigAsset              -- defines the bone hierarchy
AnimationClip basePose     -- the base layer animation
AnimationClip overlayPose  -- the overlay animation to blend in
List<LayeredBlend>         -- per-bone/chain blend weights
  baseWeight               -- weight of base pose contribution per bone
  additiveWeight           -- additive layer weight
  localWeight              -- local space weight
float globalWeight         -- master weight for whole asset
float blendTime            -- transition time to this asset
AnimationCurve blendCurve  -- custom blend curve
MagicBlendOutType          -- DoNotBlendOut / AutoBlendOut / AutoBlendOutToPreviousAsset
```

**What it does well:** Lets you author a `MagicBlendAsset` SO that defines exactly which bones should blend between a base animation and an overlay, with per-bone weight control. Example: upper body aim overlay blended onto lower body locomotion. Switch to a different `MagicBlendAsset` at runtime to change the overlay. Transition is smooth (blendTime + curve). Three jobs run on the animation thread (Jobs/Burst) so it's performant.

**Critical incompatibility with FearSteez:**

`MagicBlending.Start()` calls `_animator.playableGraph` and searches for an `AnimatorControllerPlayable` in the graph to layer on top of. Animancer replaces the AnimatorControllerPlayable with its own playable tree -- there is NO AnimatorControllerPlayable in an Animancer-only setup. MagicBlend cannot find its anchor playable and will fail to initialize.

This is the same issue as with other Mecanim-dependent layering tools. It cannot coexist with Animancer unless the project uses a hybrid setup (Animancer + Unity Animator Controller together), which FearSteez explicitly avoids.

**HOK relevance:** HOK doesn't use complex animation layering. No current use case. Possibly relevant if a future 3D project uses Mecanim + needs upper/lower body blending (A Quokka Story Metroidvania, or an action/adventure).

**Requires KINEMATION shared package:** `KINEMATION.Shared.KAnimationCore` must be present. This is installed as a dependency when you install any KINEMATION Asset Store package (Motion Warping already brought it in).

**Verdict Rationale:** Conditional. Not usable with Animancer (rules out FearSteez). No current Mecanim project in the active portfolio that needs per-bone animation layering. Value increases significantly for any future non-Animancer 3D project needing body-part animation blending. Secondary: Animation.

**Project Relevance:**
- **FearSteez:** NONE (Animancer incompatible)
- **HOK:** LOW (no current layering need)
- **A Quokka Story / future Mecanim projects:** MEDIUM-HIGH

---

## ENTRY-255: Squash & Stretch Kit 1.1.2

| Field | Value |
|-------|-------|
| **Asset** | Squash & Stretch Kit |
| **Version** | 1.1.2 |
| **Developer** | Long Bunny Labs (Ming-Lun "Allen" Chou) |
| **Source** | Asset Store |
| **Primary Label** | None |
| **Secondary Labels** | Animation, VFX |
| **Verdict** | Conditional |
| **Date** | 2026-03-04 |
| **Session** | 48 |
| **Purchase** | Sale (bundle with Boing Kit) |

**What It Is:** Single `SquashAndStretch` MonoBehaviour that applies velocity-driven squash-and-stretch deformation to any GameObject. Works by inserting two intermediate parent GameObjects (`forwardRotationParent` + `inverseRotationParent`) into the hierarchy to apply scale deformation along the direction of motion without affecting children. Volume-preserving: if stretch = 1.5x on axis, off-axis scale = 1/sqrt(1.5).

**Three modes:**

| Mode | Behavior |
|------|----------|
| Immediate | Instant deformation -- velocity map → stretch, no smoothing |
| Spring | Spring physics smoothing on the stretch value (springHalfLife parameter) |
| SmoothImmediate | Smooth interpolation without full spring oscillation |

**Parameters:** `enableSquash`, `enableStretch`, `maxSquash`, `maxStretch`, `minSpeedThreshold`, `maxSpeedThreshold`, `springHalfLife`. Rigidbody-aware: reads `linearVelocity` directly when Rigidbody is present; falls back to position delta for non-physics objects.

**Critical overlap -- Feel already covers this:**

Feel (already in Sandbox) includes its own squash & stretch system:
- `MMF_SquashAndStretch` -- feedback component, fires on event
- `MMF_SquashAndStretchSpring` -- spring variant
- `MMSpringSquashAndStretch` -- spring math implementation
- `MMSquashAndStretch` -- base component

For any object tied into the Feel feedback pipeline (player hit reactions, enemy deaths, pickup effects), `MMF_SquashAndStretch` is already available and requires no additional package. The standalone Squash & Stretch Kit adds value for:
- Objects not using Feel at all (environment props, particles, UI elements)
- Rigidbody objects where physics-driven continuous deformation is needed (Feel feedback is event-triggered, not continuous)
- Cases where you want the stretch to respond automatically to movement rather than be triggered by a game event

**Verdict Rationale:** Conditional. Redundant for objects in the Feel pipeline. Adds value for physics objects and anything needing continuous motion-driven deformation. No primary label -- situational. Secondary: Animation, VFX. Both this and Boing Kit are from the same developer and complement each other (BoingBones per-bone has its own SquashAndStretch field that calls into this system).

**Project Relevance:**
- **FearSteez:** LOW-MEDIUM -- Feel handles hit reaction juice; this might be useful for mic cord/rope dart physics objects
- **HOK:** LOW -- feel feedback already covers fish/reel reactions
- **All others:** Situational

---

## ENTRY-256: Boing Kit 1.2.47

| Field | Value |
|-------|-------|
| **Asset** | Boing Kit |
| **Version** | 1.2.47 |
| **Developer** | Long Bunny Labs (Ming-Lun "Allen" Chou) |
| **Source** | Asset Store |
| **Primary Label** | None |
| **Secondary Labels** | Animation, Physics |
| **Verdict** | Approved |
| **Date** | 2026-03-04 |
| **Session** | 48 |
| **Purchase** | Sale (bundle with Squash & Stretch Kit) |

**What It Is:** A suite of four spring physics systems for Unity, all from the same developer as Squash & Stretch Kit. Full source code. Uses proper damped second-order spring math (Allen Chou is widely cited for his spring physics articles). No runtime GC -- struct-based Params, pre-allocated arrays.

**Four systems:**

| System | Component | Use |
|--------|-----------|-----|
| **BoingBones** | `BoingBones` | Spring simulation for bone chains (hair, tails, cloth edges, ponytails) |
| **BoingBehavior** | `BoingBehavior` | Single-object position/rotation/scale spring reaction |
| **BoingReactor/Effector** | `BoingReactor` + `BoingEffector` | Field-based: Effectors push Reactors via proximity force field |
| **BoingReactorField** | `BoingReactorField` | GPU/CPU sampler for massive-scale reactor fields (grass, crowds) |

**Spring math (two modes, both exposed):**

```
ExponentialHalfLife      -- smooth exponential decay, no overshoot
OscillationHalfLife      \
OscillationFrequency      > damped second-order oscillation (bouncy)
OscillationDampingRatio  /
```

Available per axis (position, rotation, scale) independently. `SharedBoingParams` SO for reusable configurations.

**BoingBones -- key for FearSteez:**

```csharp
// Per-bone parameters:
float AnimationBlend;     // 0 = full spring physics, 1 = full animation pose
float LengthStiffness;    // resistance to length change along bone
float PoseStiffness;      // resistance to angular deviation from anim pose
float BendAngleCap;       // max deviation angle
float CollisionRadius;    // per-bone sphere collider
float SquashAndStretch;   // integrates with Squash & Stretch Kit
```

`AnimationBlend` is the key parameter -- it lets you blend between animator-driven pose and spring physics **per bone**. During attacks: blend toward 1.0 (keyframed pose takes over, clean hitbox timing). During idle/walk: blend toward 0.0 (spring physics makes hair/cloth react naturally). This is exactly the pattern you'd need for Steez's hair and any loose clothing elements.

**BoingBones vs MagicaCloth 2 for FearSteez:**

| Concern | MagicaCloth 2 | BoingBones |
|---------|--------------|-----------|
| Requires SMR | Yes (for mesh deformation) | No (transform-based) |
| CopySkeletonPose timing conflict | Yes (documented in MEMORY.md) | No |
| Cloth simulation fidelity | Full cloth (wind, self-collision) | Bone chain only (no mesh deform) |
| Setup complexity | High (bone remap, bind poses) | Low (add component to bone root) |
| Animancer compatibility | Timing conflict risk | Clean (LateUpdate-safe) |
| Use case | Steez's mic cord mesh, cape | Hair, ponytail, ear tips, loose chain ends |

**Verdict: use both.** MagicaCloth 2 for mesh-deformation cloth (mic cord, cape fabric). BoingBones for pure bone chain spring physics (hair, small appendages, objects that don't need mesh deformation).

**BoingReactor/Effector -- HOK and environmental use:**

Effectors push Reactors when they pass nearby. A fish breaking the water surface could be an Effector, making nearby vegetation/small objects react (BoingBehavior reactors bounce). Works at scale with BoingReactorField.

**Verdict Rationale:** Approved. BoingBones fills a real gap in the toolkit: it's lighter than MagicaCloth 2, avoids the SMR/skeleton complexity, and is transform-based so it works cleanly with Animancer. The `AnimationBlend` field is the production-quality feature -- lets attacks stay clean while idle movement adds life. Full source, no compiled DLL.

**Project Relevance:**
- **FearSteez:** HIGH -- BoingBones for hair/chain spring physics, complementing MagicaCloth 2
- **HOK:** MEDIUM -- BoingBehavior/Effector for environmental reactivity
- **All projects:** LOW-MEDIUM -- BoingBehavior adds spring feel to any bouncing/reactive object

---

## ENTRY-257: Dialogue System for Unity -- OpenAI + ElevenLabs Addon 1.0.34 (Pixel Crushers)

| Field | Value |
|-------|-------|
| **Asset** | Dialogue System for Unity -- Addon for OpenAI and ElevenLabs |
| **Version** | 1.0.34 |
| **Developer** | Pixel Crushers |
| **Source** | Asset Store |
| **Dependency** | Dialogue System for Unity (ENTRY-214, Approved) |
| **Primary Label** | None |
| **Secondary Labels** | Dialogue, AI |
| **Verdict** | Approved |
| **Date** | 2026-03-04 |
| **Session** | 48 |
| **Purchase** | Sale |

**What It Is:** Addon to Dialogue System for Unity (ENTRY-214) that adds OpenAI GPT text generation and ElevenLabs voice synthesis to DS for Unity dialogue trees. Guarded by `#if USE_OPENAI` scripting define -- must be added in Project Settings > Player > Scripting Define Symbols to activate.

**OpenAI integration (as of 1.0.34):**

Supports current OpenAI model lineup including GPT-5 series and o-series reasoning models. `BaseURL` is configurable -- can point to any OpenAI-compatible API including local Ollama instances. Full API coverage: chat completions, TTS, STT (Whisper + gpt-4o-transcribe), image generation.

| Model tier | ID |
|------------|----|
| GPT-5 nano (default) | gpt-5-nano equivalent |
| GPT-5, GPT-5 mini | Full GPT-5 lineup |
| o4-mini, o3, o1 | Reasoning models |
| Llama3 3.2/3.3 | Via custom Ollama endpoint |

**ElevenLabs integration:**

Full ElevenLabs TTS API. Models: Eleven_v3, Flash_v2_5, Multilingual_v2, Turbo_v2. Voice list endpoint, shared voices, text-to-speech. Per-character ElevenLabs voice ID assignable in the DS for Unity Actors database.

**How it fits into DS for Unity:**

DS for Unity already handles dialogue trees, actor databases, and conversation flow. This addon adds a "procedural dialogue" path: instead of reading a pre-written response from the dialogue database, the actor calls GPT with context (who they are, what they know, the current conversation topic) and returns a generated response. ElevenLabs then voices the result.

Workflow: player input → DS conversation trigger → GPT generates NPC response → ElevenLabs TTS → audio plays as DS for Unity dialogue line.

**Practical latency reality:**

GPT API call + ElevenLabs TTS synthesis = ~1-3 seconds per line at current API speeds. This is fine for deliberate NPC conversations (quest givers, shopkeepers, story characters). It is NOT suitable for combat barks, ambient one-liners, or any real-time reaction dialogue that fires on game events. Those should remain pre-authored.

**API cost model:**

Both OpenAI and ElevenLabs charge per-use:
- GPT-5 nano: very cheap (~$0.01/1K tokens)
- ElevenLabs: per-character TTS, free tier covers basic dev/testing
- For a shipped game: either pre-generate all dialogue at build time (offline mode) or use ElevenLabs Instant mode + GPT nano

**`#if USE_OPENAI` guard:**

All addon code is wrapped in this define. Without it, the addon compiles to nothing -- no accidental API calls or references in the project. Add `USE_OPENAI` to Scripting Defines to activate. This is good practice from Pixel Crushers.

**Verdict Rationale:** Approved. Clean integration with already-Approved DS for Unity. The latency profile limits use to conversational NPC interactions, but that's the appropriate use case. Llama/Ollama support means offline/local inference is possible (no API costs, more latency). Most relevant for the visual novel and point-and-click projects in the TecVooDoo portfolio where NPC dialogue is a core feature. Not a Default -- requires API keys and is project-specific.

**Project Relevance:**
- **FearSteez:** LOW -- v1 has minimal NPC dialogue needs
- **HOK:** MEDIUM -- fishing NPCs with procedurally generated tips/reactions
- **Visual Novels (Encapsulated Fear, Genie in a Test Tube, MMM):** HIGH -- GPT NPC responses are a feature, not a gimmick, in interactive fiction
- **GRIMMORPG (Point 'N Click), Cursed Fantasy:** HIGH

---

## ENTRY-258: FS Parkour and Climbing System 1.9.9 (Fantacode Studios)

| Field | Value |
|-------|-------|
| **Asset** | FS Parkour and Climbing System |
| **Version** | 1.9.9 |
| **Developer** | Fantacode Studios ("FS" = Fantacode Studios, NOT FearSteez) |
| **Source** | Asset Store |
| **Primary Label** | None |
| **Secondary Labels** | Character, Animation |
| **Verdict** | Conditional |
| **Date** | 2026-03-04 |
| **Session** | 48 |
| **Purchase** | Sale |

**What It Is:** Third-person parkour traversal system -- vaults, mantles, climbing, ledge hanging, wall run, predictive jumping. From Fantacode Studios, who also make the `Third Person Controller` and `Free Climb` packages (all share the `FS_ThirdPerson` + `FS_Core` namespaces). Uses Mecanim Animator Controllers.

**Architecture:**

```
ParkourController       -- MonoBehaviour, extends SystemBase (FS_ThirdPerson)
ParkourAction           -- ScriptableObject, defines one parkour move
EnvironmentScannerParkour -- obstacle detection via physics casts
ParkourInputManager     -- input binding
```

`ParkourController` is tightly coupled to Fantacode's `SystemBase` from the `FS_ThirdPerson` library. Adding it to a non-Fantacode character requires adapting or replacing the SystemBase dependency.

**ParkourAction SO -- the cherry-pick target:**

```
string animName           -- animator parameter name for this action
float minHeight           -- minimum obstacle height to trigger
float maxHeight           -- maximum obstacle height to trigger
VaultType vaultType       -- VaultOver (clear it) / VaultOn (land on top) / Any
string obstacleTag        -- restrict to tagged obstacles
float postActionDelay     -- delay before returning control to player
bool rotateToObstacle     -- snap rotation during action
bool useHands             -- hand IK during action
float movementThreshold   -- required speed to trigger
// Target Matching:
AvatarTarget matchBodyPart -- which body part to snap to obstacle
float matchStartTime      -- normalized anim time to start matching
float matchTargetTime     -- normalized anim time to finish matching
Vector3 matchPosWeight    -- axes to constrain (e.g. Y-only = 0,1,0)
```

Unity's `Animator.MatchTarget()` handles the snapping so the same vault animation works on obstacles of varying heights. This is production-quality traversal data design.

**Mecanim-only -- not compatible with Animancer:**

The system passes `animName` strings to Animator parameters and relies on a Mecanim `Parkour Controller.controller`. Cannot be dropped into a FearSteez character (Animancer). Would require a full rewrite of the ParkourController to drive Animancer clips instead.

**FearSteez cherry-pick value:**

FearSteez is 2.5D side-scrolling -- no third-person camera traversal. However, the `ParkourAction` SO pattern is valuable:
- Height-range gating (minHeight/maxHeight) for environment interaction triggers
- Target matching configuration (snap hand/foot to ledge, with axis weights)
- Post-action delay before returning player control
- Obstacle tag filtering for selective interaction

These concepts apply directly to any FearSteez environmental move (ledge grab, vault, ducking under obstacle). The data structure is worth adapting into an `FSTraversalAction` SO for future FearSteez environment interactions -- not the code, just the data model.

**Verdict Rationale:** Conditional. Not directly usable in FearSteez or HOK (Mecanim, TPS coupling). Cherry-pick the `ParkourAction` SO data design for future FearSteez traversal moves. Direct use for a future TPS/Metroidvania project (A Quokka Story) where a Mecanim character controller is acceptable.

**Project Relevance:**
- **FearSteez:** LOW (cherry-pick ParkourAction SO data pattern for future traversal)
- **A Quokka Story (Metroidvania):** HIGH (traversal is core to the genre; this could be used directly if built on Mecanim)
- **HOK, all others:** NONE

---

## ENTRY-259: FishNet Networking Evolution 4.6.22r (First Gear Games)

| Field | Value |
|-------|-------|
| **Asset** | FishNet Networking Evolution |
| **Version** | 4.6.22r |
| **Developer** | First Gear Games |
| **Source** | Asset Store (free) / OpenUPM |
| **Primary Label** | None |
| **Secondary Labels** | Networking |
| **Verdict** | Approved (candidate for FearSteez v3 online co-op) |
| **Date** | 2026-03-04 |
| **Session** | 48 |

**What It Is:** Server-authoritative Unity networking framework with client-side prediction. Positioned as a Mirror successor. Free and open source (paid Pro tier adds support). Large community, active development. Competes directly with Netcode for GameObjects and Photon Fusion 2.

**Architecture:**

```
NetworkManager          -- singleton, manages server/client/host
NetworkObject           -- identity component (on any networked prefab)
NetworkBehaviour        -- base class (extends MonoBehaviour, not NetworkObject)
InstanceFinder          -- static accessor to NetworkManager (equivalent to Photon's NetworkRunner)
```

**RPC system (Cecil IL weaving at compile time):**

```csharp
[ServerRpc]           // client -> server
[ObserversRpc]        // server -> all clients
[TargetRpc]           // server -> specific client
```

Attributes are processed by Cecil at build time (same approach as Mirror/FishNet v3). The `CodeGenerating/` folder contains the full IL weaver source.

**SyncTypes:**

| Type | Notes |
|------|-------|
| `SyncVar<T>` | With `InterpolationContainer` -- interpolates between last two received values |
| `SyncList<T>` | With change callbacks |
| `SyncDictionary<T>` | With operation enum (Add, Set, Remove, Clear) |
| `SyncHashset<T>` | |
| `SyncTimer` / `SyncStopwatch` | Networked timers |

**Client-side prediction system:**

FishNet's prediction system uses `[Replicate]` and `[Reconcile]` attributes (code-gen processed). Includes `PredictionRigidbody` and `PredictionRigidbody2D` components. `ColliderRollback` plugin for lag compensation (server rolls back colliders to a past tick for hit detection). Demos included: CharacterController prediction, Rigidbody prediction.

**Transport:** Tugboat (LiteNetLib, UDP) included. Also includes Yak transport. Mirror transport compatibility via separate package in ThirdPartySupport.

**Demos included:** Additive scene loading, Rigidbody prediction, CharacterController prediction, HashGrid (observer culling), ColliderRollback, Authenticator.

**vs Photon Fusion 2 for FearSteez v3:**

| Concern | FishNet | Photon Fusion 2 |
|---------|---------|----------------|
| Cost | Free (Pro tier for support) | Per-CCU pricing (free tier: 100 CCU) |
| Hosting | Self-host required (or relay service) | Photon cloud relay included |
| Prediction | Full client-side prediction system | Full client-side prediction (Shared/Host mode) |
| API style | Mirror-derived (familiar) | More opinionated (NetworkRunner-centric) |
| Unity 6 support | Yes | Yes |
| WebGL | Via SimpleWebTransport addon | Yes |
| Beat 'em up co-op fit | Good -- server-authoritative suits local + online | Good |

**Key difference on hosting:** FishNet requires you to manage relay/matchmaking yourself (or use a service like Fish-Networking's Relay, or integrate with external relay). Photon Fusion 2 includes Photon's relay infrastructure. For a small indie studio, this is the primary practical difference -- Photon Fusion 2 is zero-ops for networking infrastructure; FishNet requires a hosting decision.

**Verdict Rationale:** Approved as a viable Photon Fusion 2 alternative for FearSteez v3. Eliminates CCU costs entirely. The tradeoff is hosting/relay responsibility. For a game like FearSteez (2-player co-op, low player counts), free-tier Photon Fusion 2 (100 CCU) may cover launch needs anyway -- FishNet becomes relevant at scale or if you want to eliminate Photon dependency entirely. Need relay comparison before committing.

**Project Relevance:**
- **FearSteez v3 online co-op:** HIGH (candidate vs Photon Fusion 2)
- **HOK multiplayer (future):** MEDIUM
- **All others:** LOW

---

## ENTRY-260: PurrNet 1.19.0

| Field | Value |
|-------|-------|
| **Asset** | PurrNet |
| **Version** | 1.19.0 |
| **Source** | Asset Store |
| **Primary Label** | None |
| **Secondary Labels** | Networking |
| **Verdict** | Approved (strong candidate for FearSteez v3, edges out FishNet on API) |
| **Date** | 2026-03-04 |
| **Session** | 48 |

**What It Is:** A modern Unity networking framework with a cleaner API than FishNet, built from the ground up (not Mirror-derived). Free + open source. Notably smaller codebase than FishNet -- easier to read and understand. Active development. Notable unique features: `NetworkBones`, `SyncInput<T>`, and built-in bit-level delta packing.

**Architecture:**

```
NetworkManager          -- singleton, manages server/client/host
NetworkIdentity         -- identity component (base class for everything networked)
NetworkBehaviour        -- : NetworkIdentity (thin wrapper -- just the base class)
PlayerID                -- typed player identifier (scope-aware, not just int)
```

**RPC system (IL weaving via Codegen):**

```csharp
[ServerRpc(channel = Channel.ReliableOrdered, requireOwnership = true, deltaPacked = false)]
[ObserversRpc(bufferLast = false, excludeOwner = false, excludeSender = false)]
[TargetRpc]

// Context guards (not RPCs -- restrict method execution context):
[Server]   // method only runs on server
[Owner]    // method only runs on owner
[Client]   // method only runs on clients
```

`deltaPacked = true` on any RPC enables bit-level delta compression on the parameters -- sends only changed bits since last call. Significant bandwidth savings for frequently called RPCs (position, animation state).

**SyncTypes -- notably richer than FishNet:**

| Type | Unique to PurrNet | Notes |
|------|-------------------|-------|
| `SyncVar<T>` | No | Same as FishNet, with `ownerAuth` + `sendIntervalInSeconds` per-instance |
| `SyncList<T>` | No | |
| `SyncDictionary<T>` | No | |
| `SyncHashset<T>` | No | |
| `SyncArray<T>` | No | Fixed-size array variant |
| `SyncTimer` | No | |
| `SyncQueue<T>` | **Yes** | Networked queue -- pop/push synced |
| `SyncInput<T>` | **Yes** | Dedicated input sync with per-tick buffering |
| `SyncEvent<T>` | **Yes** | Event-style sync -- fires subscribers on all clients |
| `SyncAsset<T>` | **Yes** | Syncs asset references (SO, Texture, etc.) |
| `SyncBigData<T>` | **Yes** | Large data payloads (chunked) |
| `SyncFile`, `SyncRawFile` | **Yes** | File transfer |
| `SyncTextureAsset`, `SyncSpriteFile` | **Yes** | Image data sync |

**`SyncInput<T>` -- critical for FearSteez co-op:**

Input sync is a first-class citizen in PurrNet. Rather than manually sending input via ServerRpc every frame, `SyncInput<T>` handles buffering, timing, and server reconciliation automatically. For a beat 'em up where input latency matters (combos, attack timing), this is a meaningful advantage over rolling your own input sync on top of FishNet's generic SyncVar.

**`NetworkBones` component -- unique:**

PurrNet ships a `NetworkBones` component (`Assets/PurrNet/Runtime/Components/NetworkBones/NetworkBones.cs`) that:
- Automatically discovers all bones in the hierarchy (+ optional `_extraBones[]`)
- Syncs position, rotation, scale per bone with configurable accuracy thresholds (`_positionAccuracy`, `_angleAccuracy`, `_scaleAccuracy`)
- Uses delta packing (`DeltaModule`) -- only sends changed bones
- Interpolates using a buffer (`_minBufferSize`/`_maxBufferSize`)
- `_sendRatePerSecond` configurable (default 10/sec)
- `_ownerAuth` flag

For FearSteez online co-op, animated character bones would be synced with this component rather than a custom solution.

**Transport:** LiteNetLib (UDP) included. Also includes SimpleWebTransport (WebGL). Addons for UTP, Steam, Edgegap (relay hosting service).

**vs FishNet:**

| Concern | FishNet | PurrNet |
|---------|---------|---------|
| API maturity | More battle-tested (Mirror heritage) | Newer, cleaner design |
| Community size | Larger | Smaller but growing |
| `SyncInput<T>` | Not built-in | Built-in |
| `NetworkBones` | Not built-in | Built-in |
| Delta packing | Delta on SyncVar only | Per-RPC `deltaPacked` flag |
| Client prediction | Full (Replicate/Reconcile attributes) | Present but less documented |
| Relay/hosting | Self-managed | Edgegap addon included |

**vs Photon Fusion 2:**

Same hosting tradeoff as FishNet -- PurrNet requires relay management (Edgegap addon simplifies this). Photon Fusion 2 CCU pricing is the only remaining Photon advantage. `SyncInput<T>` is comparable to Fusion's built-in input system.

**Verdict Rationale:** Approved -- edges out FishNet for FearSteez v3 specifically. `SyncInput<T>` handles combo input timing more cleanly than FishNet's generic SyncVar approach. `NetworkBones` eliminates custom bone sync code. Delta packing on RPCs reduces bandwidth for a high-animation-rate beat 'em up. The API is cleaner and more modern. The smaller community is the only risk; if PurrNet stops being maintained, migration to FishNet would be relatively straightforward.

**Recommended eval next step:** Build a minimal 2-player host/client prototype in Sandbox. Spawn two characters, sync position/animation via NetworkBones, send attack input via SyncInput. Confirm latency, input buffering, and NetworkBones accuracy before committing to v3 architecture.

**Project Relevance:**
- **FearSteez v3 online co-op:** HIGH (top candidate, ahead of FishNet and possibly Photon Fusion 2)
- **HOK multiplayer (future):** MEDIUM
- **All others:** LOW

---

## ENTRY-261: Breeze (Breeze Assets)

| Field | Value |
|-------|-------|
| **Asset** | Breeze |
| **Version** | Unknown |
| **Developer** | Breeze Assets |
| **Source** | Asset Store |
| **Primary Label** | -- |
| **Secondary Label** | AI |
| **Verdict** | Deferred |
| **Date** | 2026-03-04 |
| **Session** | 48 |

**What It Is:** NPC AI system covering combat, patrol, and companion behaviors. Desk review only -- purchased alongside FishNet and PurrNet in the Session 48 NPC AI batch. Deferred pending hands-on evaluation.

**Deferred Reason:** Three NPC AI systems (Breeze, GOAP v3, NPC AI Engine) were purchased together for comparison. Not yet installed or tested. Evaluate when FearSteez or HOK NPC AI work resumes.

---

## ENTRY-262: GOAP v3 (crashkonijn)

| Field | Value |
|-------|-------|
| **Asset** | GOAP v3 |
| **Version** | 3.x |
| **Developer** | crashkonijn |
| **Source** | Asset Store |
| **Primary Label** | -- |
| **Secondary Label** | AI |
| **Verdict** | Deferred |
| **Date** | 2026-03-04 |
| **Session** | 48 |

**What It Is:** Goal Oriented Action Planning (GOAP) AI framework. Desk review only -- purchased in Session 48 NPC AI batch. GOAP is a classic AI architecture (F.E.A.R., Tomb Raider) where agents dynamically plan action sequences to achieve goals, rather than using pre-authored behavior trees.

**Deferred Reason:** GOAP requires meaningful implementation work to test properly. Deferred until a project with complex NPC AI (FearSteez enemy AI v2, HOK underworld NPCs) reaches that phase.

---

## ENTRY-263: NPC AI Engine (Convai)

| Field | Value |
|-------|-------|
| **Asset** | NPC AI Engine |
| **Version** | Unknown |
| **Developer** | Convai |
| **Source** | Asset Store |
| **Primary Label** | -- |
| **Secondary Label** | AI |
| **Verdict** | Deferred |
| **Date** | 2026-03-04 |
| **Session** | 48 |

**What It Is:** Conversational NPC system powered by the Convai cloud LLM service. Enables NPCs to have open-ended spoken or typed conversations with players using natural language. Desk review only.

**Deferred Reason:** Convai requires a cloud API subscription and ongoing service costs. Relevant only for projects with conversational NPCs (Dialogue-heavy RPGs, AI-driven characters). No current active project has this requirement. Revisit when a project calls for LLM-driven NPC dialogue.

---

### ENTRY-264 -- Easy Build System (PolarInteractive) | Approved | 2026-03-05

**Source:** Asset Store
**Category:** Building / Construction
**Primary Label:** --
**Secondary Label:** --
**Evaluated in:** SyntyAssets project (E:\Unity\SyntyAssets)

**Stats:**
- 101 scripts, ~17.2K LOC
- No asmdef (all scripts in Assembly-CSharp)
- Proper namespaces throughout (`EasyBuildSystem.*`)
- Copyright: 2015-2022 PolarInteractive
- 11 demo scenes + 5 addon scenes

**Core Architecture:**
- **BuildingManager** (singleton) -- central registry of all BuildingPart references, building types, area of interest, batching settings
- **BuildingPart** (MonoBehaviour) -- individual placeable piece with states: NONE, PREVIEW, DESTROY, EDIT, PLACED, QUEUE. Has GeneralSettings (name, type, thumbnail, identifier), ModelSettings, PreviewSettings, SnappingSettings
- **BuildingPlacer** (singleton) -- handles placement modes: PLACE, DESTROY, EDIT. Raycast-based positioning (first person, third person, top down, isometric, free camera)
- **BuildingSocket** -- snap points on parts. SnappingPointSettings with match by reference or by type. Handles alignment/rotation
- **BuildingArea** -- constrains where building can occur
- **BuildingGroup** -- groups placed parts together (batching, serialization unit)
- **BuildingSaver** -- JSON file save/load, async loading support, auto-save interval
- **BuildingCollection** (ScriptableObject) -- part catalog, list of BuildingPart prefabs
- **BuildingCondition** (abstract base) -- extensible placement validation: collision, terrain, NavMesh, physics, basics, linkable surface
- **BuildingType** (ScriptableObject) -- categorization for parts

**Input System:**
- **Dual input support:** `#if ENABLE_INPUT_SYSTEM` for new Input System (InputActionReference), falls back to `KeyCode`-based old input
- StandaloneInputHandler + MobileInputHandler + BaseInputHandler abstraction
- Gamepad demo scene included

**Integrations (bundled as .unitypackage):**
- FishNet, Mirror, PUN V2 (networking)
- Game Creator 2 + GC2 Inventory
- PlayMaker, Rewired
- RPGBuilder, uSurvival
- XR Interaction Toolkit

**Pipeline Support (bundled as .unitypackage):**
- URP Support, HDRP Support, Assembly Support (for asmdef projects)

**Demo Coverage:**
- First Person, Third Person, Top Down, Isometric, Free Camera
- Building Areas, Building Physics, Building Saver
- Gamepad, Mobile
- Unity Terrain integration
- 5 addon demos: Advanced Buildings, Buggy Constructor, Circular Building Menu, House Buildings, Survival Buildings

**Highlights:**
- Socket-based snapping system is the core value -- define snap points on parts, parts auto-align when placed near compatible sockets
- Condition system is extensible (inherit BuildingCondition, add custom placement rules)
- Save/load with async support and auto-save
- Event-driven: UnityEvents for placing, destroying, registering, state changes
- BuildingBatching for performance (combines placed meshes)
- Area of interest system for large worlds (enable/disable distant sockets)
- Good demo coverage across all common camera perspectives

**Caveats:**
- No asmdef -- all 101 scripts land in Assembly-CSharp. Assembly Support .unitypackage exists but must be manually imported
- Copyright dates 2015-2022 -- no indication of Unity 6 specific updates, though uses `#if ENABLE_INPUT_SYSTEM` correctly
- Singleton pattern on BuildingManager and BuildingPlacer (static Instance)
- URP materials require importing the URP Support .unitypackage separately
- `BuildingPart.cs` has `using UnityEditor;` in a Runtime script (guarded by `#if UNITY_EDITOR` in usage, but the using statement is always present -- may cause build issues)

**Project Relevance:**
- **HOK:** HIGH -- Kharon's dock/pier building, player base construction, fishing spot customization
- **DLYH:** LOW -- word puzzle game, no building mechanics
- **FearSteez:** LOW -- beat 'em up, destructible environments (RayFire) not constructible ones
- **Any survival/crafting project:** HIGH -- this is purpose-built for survival base-building

**Verdict Rationale:** Approved -- solid, mature building system (7+ years of development). Socket-based snapping is well-architected. Extensive demo coverage proves it works across perspectives. The condition system is cleanly extensible. The main weakness is no asmdef by default and the 2022 copyright date suggesting slower update cadence. The bundled networking integrations (FishNet, Mirror, PUN V2) add multiplayer building support without extra work. Not labeled Default because building mechanics are game-specific, not universal.

---

## ENTRY-265: Synty Store Importer

| Field | Value |
|-------|-------|
| **Asset** | Synty Store Importer |
| **Version** | Bundled with SyntyPass packs |
| **Developer** | Synty Studios |
| **Source** | SyntyPass (not Asset Store) |
| **Primary Label** | -- |
| **Secondary Label** | -- |
| **Verdict** | Approved |
| **Date** | 2026-03-05 |
| **Session** | 51 |
| **Evaluated in** | SyntyAssets project (E:\Unity\SyntyAssets) |

**What It Is:** Editor tool bundled inside Synty's SyntyPass .unitypackage downloads (not the Unity Asset Store versions). Provides a GUI window for browsing and importing Synty content packs directly from the local SyntyPass download folder (`E:\Game Assets\Synty\SyntyPass`). Handles pack detection, selective import, and Unity project integration.

**How It Works:**
1. Import any SyntyPass .unitypackage into a Unity project -- the importer tool comes bundled
2. Open the Synty Store Importer window from the Unity menu
3. Point it at the SyntyPass folder containing downloaded .unitypackage files
4. Browse available packs, select what to import, import directly into the project

**Tested Workflow:**
- Successfully imported PolygonCoffeeShop, PolygonShops, PolygonShoppingPlazaMap, PolygonNatureBiomes, SidekickCharacters, PolygonPrototype, PolygonStarter, and PolygonParticleFX into the SyntyAssets project
- Import process is straightforward -- point at folder, click import
- Performance: Shopping Plaza Map caused significant lag due to scene size; Coffee Shop and Shops ran well

**Known Issues:**
- `MissingReferenceException` for destroyed `Texture2D` in `SyntyStoreImporter.cs:302` -- GUI error when the importer window is open. Benign; close the window to stop the error
- Not available on Asset Store -- only comes with SyntyPass downloads

**Verdict Rationale:** Approved. Simple, effective tool for managing SyntyPass content imports. The single-source-of-truth strategy (SyntyPass only, remove Unity Asset Store duplicates) works well with this importer. Combined with Asset Inventory 4 (ENTRY-252) for cross-source indexing and selective file import, this covers the full Synty asset pipeline.

---

## ENTRY-266: PolygonParticleFX (Synty Studios)

| Field | Value |
|-------|-------|
| **Asset** | PolygonParticleFX |
| **Version** | Current SyntyPass |
| **Developer** | Synty Studios |
| **Source** | SyntyPass |
| **Primary Label** | -- |
| **Secondary Labels** | Art, VFX, Low Poly |
| **Verdict** | Approved |
| **Date** | 2026-03-05 |
| **Session** | 51 |
| **Evaluated in** | SyntyAssets project (E:\Unity\SyntyAssets) |

**What It Is:** Comprehensive low-poly particle effects library with ~170 prefabs covering gameplay VFX. Matches the Synty Polygon art style. All effects use Unity's built-in Particle System (Shuriken), no VFX Graph dependency.

**Content Breakdown (~170 prefabs):**

| Category | Count | Examples |
|----------|-------|----------|
| Combat / Weapons | ~40+ | Gunshots (repeating, shotgun, sniper, tracers), shell ejections (small/large/repeating), sword slash/stab, grenades (explosive/flash/smoke + toss variants), artillery, cannon, flamethrower |
| Magic / Fantasy | ~20+ | Fireballs (static + shooting + straight), healing circles, ritual circles, portals (round/thin/sphere), magic blasts, power beams/draws, lightning strike, laser beam, poison (green/purple) |
| Fire / Explosions | ~15+ | Fire (small x3, big x3, huge), explosions (standard, large dark, body, body bloody), nukes (standard + smaller), embers, fire trails |
| Environmental | ~15+ | Rain (+ collision), snow, blizzard, wind (soft/standard/hard), fog (small/big), dust (small/big/blowing), sunbeams (small/large), leaves (green/blossom), steam x3 |
| UI / Game Feel | ~20+ | Pickups (health/ammo/boost/heart/death/question), level up, XP gain, money coins/notes (static/burst/shooting), direction arrows x3, star stunned x2, confetti (burst/falling), fireworks |
| Cartoony | ~5 | Footstep poof, jump poof, jump up, sprint lines, rings |
| Impact | ~8 | Large, small, dirt, metal, stone, wood, water, water ripple |
| Projectile / Trail | ~10+ | Missile, smoke trails (small/large), fire trail, dust trail, debris trail, exhaust trail, bullet trail (sniper line) |
| Shard Explosions | ~8 | Ice, rock, magic, vine (each with explosion + shooting variant) |
| Misc | ~15+ | Blood splats (standard/small), smoke (black/white, small/large variants), sparkles (small/large/trail/orbit x2), sparks, water drip, bubbles (standard/float), fairy, fireflies, rainbow (glow x2, sparkle), hexagon x2, light rays |

**Models (custom FX meshes):**
- `SM_Particle_Smoke_01.fbx`, `SM_LightRayRound 1.fbx` -- custom mesh particles for smoke puffs and light ray effects
- `FX_Heart_01.fbx`, `FX_Money_Coin_01.fbx` -- shaped particles for pickup/reward effects
- `FX_Sphere.fbx`, `FX_Sphere_Pivot_01.fbx`, `FX_Cylinder_02.fbx` -- geometric primitives for effect construction
- `FX_Shard_Rock_02.fbx` -- debris chunk for shard explosion effects

**Materials:** 10 materials (Default, Empty, Emission, Fumes, Ice, Leaves, Rainbow FX, Sparkle, Sun Beams, Bullet Trail texture)

**Comparison with NatureBiomes FX (~93 FX in content packs):**

| Aspect | NatureBiomes / Content Pack FX | PolygonParticleFX |
|--------|-------------------------------|-------------------|
| Purpose | Ambient scene dressing | Gameplay mechanics |
| Wildlife | Birds, butterflies, fish, crabs, frogs, bats, hawks, vultures, dragonflies | None |
| Weather | Rain, snow, fog, clouds, wind | Rain, snow, blizzard, fog, wind, dust |
| Nature | Leaves, petals, aurora, lava embers, wisps, swamp bubbles | Leaves (green/blossom only) |
| Water | Fountains, waterfalls, splashes, ripples | Water drip, water ripple, bubbles |
| Combat | None | Full suite (guns, melee, magic, explosions, impacts, projectiles) |
| UI/Feedback | None | Pickups, level up, XP, money, direction arrows, stunned stars |
| Fire | Basic fire | Fire (7 sizes), fireballs, flamethrower, embers, fire trails |
| Magic | None | Healing, rituals, portals, magic blasts, power beams, lightning, poison, shards |

**Overlap is minimal.** Content pack FX = atmospheric/ambient. ParticleFX = gameplay systems. They serve completely different purposes and complement each other.

**Hands-On Test (SyntyAssets TestScene):**
- Placed FX_Blizzard_Snow_01 over a swamp scene -- heavy hexagonal snowflakes with streak particles, transforms the scene mood immediately
- Placed FX_RainbowSparkle_01 -- circular sparkle ring effect, designed for close-up moments (pickups/magic), not sky-scale arcs
- Placed FX_Nuke_01 -- full mushroom cloud with expanding shockwave ring and smoke column. Impressive scale and visual impact
- All effects are one-shot or looping as appropriate; particle systems activate on play mode

**Verdict Rationale:** Approved with Art + VFX + Low Poly labels. This is the gameplay VFX companion to Synty's content packs. The content packs provide ambient atmosphere; ParticleFX provides combat, magic, impacts, pickups, and UI feedback effects. For any Synty-based project with gameplay (especially a beat-em-up like FearSteez), this pack fills the gap that content packs don't cover. ~170 prefabs across all common gameplay VFX categories. No scripting -- pure particle prefabs ready to instantiate at runtime.

**Project Relevance:**
- **FearSteez:** HIGH -- beat-em-up needs impact effects, slash trails, hit reactions, pickups, level up VFX
- **HOK:** MEDIUM -- fire effects for campfires/torches, water effects, ambient sparkles, explosions for dramatic moments
- **Any Synty project with gameplay:** HIGH

---

## Synty Workflow Findings (Session 51)

**Evaluated in:** SyntyAssets project (E:\Unity\SyntyAssets), March 5, 2026

This session tested end-to-end workflows for building scenes with Synty Polygon assets to determine optimal pipelines.

### Asset Source Strategy

**Single source of truth: SyntyPass only.**

| Aspect | Decision |
|--------|----------|
| Source | SyntyPass downloads at `E:\Game Assets\Synty\SyntyPass` |
| Import tool | Synty Store Importer (bundled in packs) |
| Unity Asset Store copies | Remove to avoid duplicates |
| Cross-project search | Asset Inventory 4 (ENTRY-252) indexes both SyntyPass folder and Unity cache |

### Synty Pack Types

| Type | Example | Description |
|------|---------|-------------|
| **Content Pack** | PolygonShops, PolygonCoffeeShop | Self-contained asset libraries. Models, materials, prefabs, demo scene. Import and use directly. |
| **Map Pack** | PolygonShoppingPlazaMap | Pre-assembled demo scenes that reference OTHER content packs. Import solo and most meshes show as missing (pink). Useful as layout references, not standalone content. |
| **FX Pack** | PolygonParticleFX | Gameplay VFX library. Particle prefabs, no scene geometry. Complements content packs. |
| **Character Pack** | SidekickCharacters | Rigged character meshes + accessories. Separate bone naming conventions from content packs. |

### Greyboxing Pipeline Conclusions

Tested three approaches for building scenes with Synty assets:

| Approach | Test | Result |
|----------|------|--------|
| **PolygonPrototype greybox → Synty final** | Built 2 buildings + road with Prototype pieces | Works but Prototype pieces have corner-based pivots requiring math for wall placement. Replacing with final Synty assets is the same effort as replacing ProBuilder blocks. |
| **ProBuilder greybox → Synty final** | Compared mentally against Prototype test | Simpler pivot system, free-form sizing, faster iteration. Skip the Prototype middleman. |
| **Direct Synty placement (no greybox)** | Built swamp scene with NatureBiomes assets | Nature/organic scenes need no greybox at all. Place final assets directly. |

**Final recommendation:**

| Scene Type | Pipeline |
|------------|----------|
| **Buildings / structures** | ProBuilder greybox → replace with Synty assets (skip Prototype entirely) |
| **Nature / organic** | Skip greybox → place Synty assets directly |
| **Mixed scenes** | ProBuilder for structures, direct placement for nature elements |

**Key insight:** PolygonPrototype has corner-based pivots (origin at 0,0,0 corner, walls extend +X/+Y, floors extend +X/+Z). This means every wall placement requires calculating which corner to place the pivot at based on rotation (front=180 at SE corner, back=0 at NW corner, left=270 at SW corner, right=90 at NE corner). ProBuilder boxes are simpler to work with for blocking out shapes, and the replacement step is equivalent effort either way.

**Nature scene insight:** Organic environments (swamp trees, water, vegetation, rocks, props) don't benefit from greyboxing because there's no structural grid to plan. The assets are irregular by nature, so you place them directly and adjust for feel. Greyboxing would add a step with no payoff.

---

## ENTRY-267: Custom MCP Tool Extensions (TecVooDoo)

**Date:** 2026-03-06 (Sessions 52-55)
**Source:** Internal (built in SyntyAssets project, `Assets/MCPTools/`)
**Category:** Tools (MCP Extensions)
**Verdict:** Approved
**Label:** Default
**Evaluated in:** SyntyAssets project (E:\Unity\SyntyAssets)

### Overview

Custom MCP tool extensions built on top of IvanMurzak's `com.ivanmurzak.unity.mcp` plugin (ENTRY-056). Extends Claude's ability to control Unity via MCP to cover 5 major third-party assets not covered by any existing MCP extension. 35 tools across 6 asset groups.

**Architecture:** Follows the same extension pattern as IvanMurzak's ProBuilder/Animation/ParticleSystem extensions. Each tool group lives in `Assets/MCPTools/<Asset>/Editor/` with its own asmdef and `[McpPluginTool]` attributed methods. `MCPToolsDefineManager.cs` auto-detects installed assets and adds/removes `HAS_*` scripting defines; asmdefs use `defineConstraints` to conditionally compile.

**Key architecture notes:**
- `MainThread` lives in `ReflectorNet.dll` -- asmdef needs `overrideReferences: true` + `ReflectorNet.dll` in precompiledReferences
- Namespace collisions (e.g., `Flexalon.Plane`) resolved with `global::` prefix
- Assets without asmdefs (PWB, FinalIK) use `#if HAS_X ... #endif` file-level guards instead
- FinalIK lives in `Assembly-CSharp-firstpass` (Assets/Plugins/), not Assembly-CSharp

### Custom Tools Built

**Flexalon 3D Layouts (8 tools) -- All ✅**

| Tool | What It Does |
|------|-------------|
| `flexalon-list-layouts` | List all Flexalon layouts in scene |
| `flexalon-create-grid-layout` | Create grid layout with columns, gap, axis |
| `flexalon-create-circle-layout` | Create circle layout with radius, angle, direction |
| `flexalon-create-flexible-layout` | Create flex layout with gap modes |
| `flexalon-create-random-layout` | Create random scatter layout with seed |
| `flexalon-add-child` | Add primitive/existing/prefab child to layout |
| `flexalon-add-prefab-children` | Add N copies of a prefab to layout |
| `flexalon-set-object-size` | Set FlexalonObject Width/Height/Depth |

*Bug found and fixed: `FlexalonLayoutBase [RequireComponent(typeof(FlexalonObject))]` auto-adds FlexalonObject. Must use `GetComponent` not `AddComponent` or you get a null duplicate. Use `instanceID` not `name` for layout references.*

**Prefab World Builder (4 tools) -- All ✅**

| Tool | What It Does |
|------|-------------|
| `pwb-list-palettes` | List all PWB palettes and brushes |
| `pwb-add-to-palette` | Add a prefab to a palette as a new brush |
| `pwb-place-brush` | Place a prefab from a palette brush at a position |
| `pwb-place-line` | Place N instances of a brush in a line |

*Palettes persist across sessions. Use `brushName` partial match. `pwb-place-line` groups output under a named container GO.*

**RayFire 2 (7 tools) -- 5 ✅, 2 ❌ CRASH**

| Tool | What It Does | Status |
|------|-------------|--------|
| `rayfire-add-rigid` | Add RayfireRigid component | ✅ |
| `rayfire-configure-rigid` | Modify rigid params (simTp, dmlTp, physics.mt, etc.) | ✅ |
| `rayfire-add-shatter` | Add RayfireShatter with fragmentation algorithm | ✅ |
| `rayfire-fragment` | Call Fragment() to generate fragments | ✅ |
| `rayfire-list-rigid` | List all RayfireRigid in scene | ✅ |
| `rayfire-demolish` | Trigger runtime demolition | ❌ CRASH |
| `rayfire-apply-damage` | Apply damage to a rigid | ❌ CRASH |

*Runtime demolition (`DemolishForced()`, `ApplyDamage()`) crashes Unity from MCP `MainThread.Run()` context -- RayFire spawns/destroys objects during execution which conflicts. Setup and fragmentation fully scriptable; runtime demolition must be triggered via game code or Inspector.*

**MagicaCloth 2 (6 tools) -- All ✅**

| Tool | What It Does |
|------|-------------|
| `magica-list-cloth` | List all MagicaCloth components in scene |
| `magica-add-bone-cloth` | Add BoneCloth to character armature root |
| `magica-add-mesh-cloth` | Add MeshCloth to a MeshRenderer/SkinnedMeshRenderer |
| `magica-add-sphere-collider` | Add MagicaSphereCollider |
| `magica-add-capsule-collider` | Add MagicaCapsuleCollider |
| `magica-add-wind` | Create a MagicaWindZone (GlobalDirection/Sphere/Box) |

**Final IK (5 tools) -- All ✅**

| Tool | What It Does |
|------|-------------|
| `finalik-list-ik` | List all FinalIK components in scene |
| `finalik-add-fbbik` | Add FullBodyBipedIK with auto-detected biped refs |
| `finalik-set-effector` | Set effector position/weight by name |
| `finalik-add-lookat` | Add LookAtIK with target position |
| `finalik-add-aim` | Add AimIK with target position |

*Pass character root GameObject, not a bone. Auto-detect works on humanoid rigs.*

**Asset Inventory 4 (5 tools) -- All ✅**

| Tool | What It Does |
|------|-------------|
| `asset-inventory-search` | Search indexed assets with text + packageFilter |
| `asset-inventory-search-prefabs` | Search prefabs with text + packageFilter |
| `asset-inventory-list-packages` | List all indexed packages |
| `asset-inventory-import` | Import an asset into the project |

*`packageFilter` param added to search tools (partial match, case-insensitive). Import uses `EditorApplication.delayCall += async () => { await Assets.CopyTo(...); }` pattern (direct `.Wait()` deadlocks).*

### Built-in MCP Extension Evaluation (also Session 55)

Alongside custom tools, all 3 IvanMurzak built-in extensions were fully evaluated with detailed gotcha documentation:

**ProBuilder (13 tools) -- All ✅**
- Prefer semantic `faceDirection` over vertex/face index arrays
- Must re-read `probuilder-get-mesh-info` after each modifying operation (indices change)
- Bridge requires truly open edges (only 1 face sharing the edge); delete a face first

**Animation (6 tools) -- All ✅**
- `SetCurve` `componentType` = full namespace required (`UnityEngine.Transform`, not `Transform`)
- `RemoveCurve` uses internal Unity names (`m_LocalPosition.x`, not `localPosition.x`)
- `animator-modify` uses `props` (not `fields`) for `runtimeAnimatorController` assignment

**ParticleSystem (2 tools) -- ✅ with workaround**
- MinMaxCurve via `value:{}` BROKEN -- values corrupt on assignment
- Workaround: use `*Multiplier` scalar companions (`startLifetimeMultiplier: 4.0` instead of setting `startLifetime: {mode: Constant, constant: 4}`)
- Simple float/bool/int properties work fine; module enable/disable works fine

### Verdict Rationale

Approved, **Default**. This is a first-party capability layer that dramatically expands what Claude can do in Unity. Every project using Flexalon, PWB, RayFire, MagicaCloth2, or FinalIK gains MCP control of those assets. The extension pattern is stable and replicable for future assets. The built-in eval results (ProBuilder, Animation, ParticleSystem gotchas) are standing reference documentation.

---

## ENTRY-268: All In 1 Springs Toolkit 1.7

| Field | Value |
|-------|-------|
| **Asset** | All In 1 Springs Toolkit |
| **Version** | 1.7 |
| **Developer** | Antonio Jia |
| **Source** | Asset Store |
| **Install Path** | `Assets/Plugins/AllIn1SpringsToolkit/` |
| **Primary Label** | -- |
| **Secondary Label** | -- |
| **Verdict** | Conditional |
| **Date** | 2026-03-06 |
| **Session** | 56 |

**What It Is:** Spring physics system for animating any Unity property toward a target value using spring (damped harmonic oscillator) math. Covers transform, Rigidbody, UI, audio, camera, shader, and bone chain spring types. Desk review + code audit.

**Architecture:**

- 51 runtime scripts, 3 asmdefs (`AllIn1SpringsToolkitAssembly`, `.Editor`, `.Demo`)
- Namespace: `AllIn1SpringsToolkit`
- Install path: `Assets/Plugins/AllIn1SpringsToolkit/` (no namespace collision concerns)

**Core Spring Types (BaseSprings/):**

| Type | Covers |
|------|--------|
| `SpringFloat` | Single float |
| `SpringVector2/3/4` | 2D/3D/4D vectors |
| `SpringColor` | RGBA color |
| `SpringRotation` | Quaternion rotation (gimbal-safe) |

**SpringLogic:** Semi-implicit Euler integration for normal forces, falls back to analytical coefficient-based integration when force exceeds 7500 threshold (prevents blow-up on extreme settings). Per-axis enable/disable, clamping, velocity add/set.

**Spring Components (SpringsComponents/) -- 14 MonoBehaviour wrappers:**

| Component | What it animates |
|-----------|----------------|
| `TransformSpringComponent` | Position + rotation + scale |
| `AnchoredPositionSpringComponent` | RectTransform anchoredPosition |
| `RotationSpringComponent` | Rotation only |
| `Vector2/3/4SpringComponent` | Raw vector (any use) |
| `FloatSpringComponent` | Raw float (any use) |
| `ColorSpringComponent` | Renderer / Graphic color |
| `RigidbodySpringComponent` | Physics-based spring force |
| `AudioSourceSpringComponent` | Volume + pitch |
| `CamFovOrSizeSpringComponent` | Camera FOV or orthographic size |
| `LightIntensitySpringComponent` | Light intensity |
| `ShaderFloatSpringComponent` | Material shader property |
| `UiSliderSpringComponent` | UI Slider value |

**SpringBone / SpringSkeleton (Bones/):** `SpringSkeleton` MonoBehaviour defines a bone chain (add to armature root), `SpringBone` is placed on each bone in the chain. Force and drag are configurable per hierarchy depth using normalized level curves on the skeleton. Supports movement inertia. Uses `RotationSpringComponent` internally.

**Overlap Analysis:**

| System | Overlap | Notes |
|--------|---------|-------|
| Feel (ENTRY-241) | HIGH (spring types) | Feel includes `MMSpringFloat`, `MMSpringVector3`, `MMSpringVector2`, `MMSpringQuaternion` in `MMFeedbacks/Springs`. These are event-triggered feedback springs; AllIn1 springs are continuous/persistent. Complementary use cases but overlapping primitive types. |
| Boing Kit (ENTRY-256) | HIGH (bone springs) | Boing Kit `BoingBones` does the same bone chain spring simulation as `SpringSkeleton`. Boing Kit uses `AnimationBlend` per bone for anim/spring mixing; AllIn1 is pure spring. Both cover hair/loose chain spring. **Pick one.** |
| Squash & Stretch Kit (ENTRY-255) | MEDIUM | Both handle spring-mode squash/stretch. AllIn1 `TransformSpringComponent` + clamping can replicate squash/stretch. Squash & Stretch Kit is more focused. |

**Unique capabilities (not in Feel or Boing Kit):**
- `ShaderFloatSpringComponent` -- spring-animate material properties directly
- `AudioSourceSpringComponent` -- spring-animate volume/pitch for organic audio feel
- `RigidbodySpringComponent` -- physics-force-based spring (applies forces, not direct transform)
- `UiSliderSpringComponent` -- UI spring animation
- `CamFovOrSizeSpringComponent` -- camera zoom spring
- `LightIntensitySpringComponent` -- light flicker/spring

**Verdict Rationale:** Conditional. The spring primitive types are largely covered by Feel (which is already Default). The bone chain spring overlaps directly with Boing Kit (already evaluated and in the stack). The unique value is the domain-specific wrappers: ShaderFloat, AudioSource, Rigidbody, UiSlider, Light springs -- none of which Feel or Boing Kit cover. Import this specifically when you need spring animation on shader properties, audio, physics forces, or UI sliders. Don't import to replace Feel springs or Boing Kit bones.

**Concerns:**
- No asmdef-based reference protection -- installs to `Assets/Plugins/` which compiles to `Assembly-CSharp-firstpass` (same as FinalIK). Cannot reference from named asmdefs.
- Significant overlap with already-installed assets reduces standalone value.
- `SpringBone` imports `UnityEditor` at the top of a runtime script (guarded by `#if UNITY_EDITOR`, but the `using` statement is unconditional -- same pattern as Easy Build System ENTRY-264).

**Project Relevance:**
- **FearSteez:** MEDIUM. Camera FOV spring for dynamic zoom (next priority from Status). ShaderFloat spring for hit flash effects. AudioSource spring for organic audio.
- **HOK:** MEDIUM. Camera FOV spring for rod tension. Light intensity spring for torch flicker.
- **Any project with shader-driven effects or audio springs:** HIGH (fills gaps Feel doesn't cover).

---

## ENTRY-269: All In 1 Shader Nodes 1.12

| Field | Value |
|-------|-------|
| **Asset** | All In 1 Shader Nodes |
| **Version** | 1.12 |
| **Developer** | Anthony Rios (AllIn1) |
| **Source** | Asset Store |
| **Install Path** | `Assets/Plugins/AllIn1ShaderNodes/` |
| **Primary Label** | Recommended |
| **Secondary Label** | Shader |
| **Verdict** | Approved |
| **Date** | 2026-03-06 |
| **Session** | 56 |

**What It Is:** Library of pre-built custom shader nodes for both Amplify Shader Editor (ASE) and Unity Shader Graph (SG). Each effect is a ready-to-drop node covering alpha, color, UV, vertex, lighting, and procedural effects. Desk review + code/file audit.

**Architecture:**

- 101 ASE node C# scripts in `Editor/Nodes/ASE/` (12 categories)
- SG support via `.shadersubgraph` subgraph files in `Editor/Nodes/SG/` (11 categories -- no Input Ports or Sprites folders)
- 2 asmdefs: `AllIn1ShaderNodes` (runtime), `AllIn1ShaderNodes.Editor` (editor)
- Namespace: `AllIn1ShaderNodes`
- 7 shared HLSL library files: `AllIn1NodeLibrary_*.hlsl` (the actual effect implementations)
- ASE compatibility .unitypackages for BiRP and URP (must import separately)

**Node Categories (12 ASE / 11 SG):**

| Category | Example Nodes |
|----------|--------------|
| Alpha Effects | AlphaMask, AlphaRemap, AlphaRound, Fade, Fade-Burn, FadeByCamDistance (Near/Far), IntersectionFade, SoftParticles |
| Color Effects | ChromaticAberration, ColorRamp, ContrastBrightness, Glow, Gradient, GradientRadial, Greyscale, HeightGradient, Highlights, Hit, Hologram, HueShift, Luminosity, Matcap, Negative |
| UV Effects | UV scroll, UV rotate, UV distortion, UV warp |
| Vertex Effects | Vertex displacement, vertex offset |
| Lighting Effects | Custom lighting models |
| Diffuse Models | Lambert, Half Lambert, custom diffuse |
| Specular Models | Blinn-Phong, custom specular |
| Depth Effects | Depth-based effects |
| Procedural Shapes | SDF shapes, procedural geometry |
| Light Model | PBR light model nodes |
| Sprites | (ASE only) Sprite-specific nodes |
| Input Ports | (ASE only) Custom input port configurations |
| Utils | (SG only) Utility nodes |

**How It Works:**
- **ASE:** Each C# file registers a custom ASE node (inherits ASE's `ParentNode`). Nodes appear in the ASE node search. Internally, each node injects HLSL from the shared `AllIn1NodeLibrary_*.hlsl` files.
- **SG:** Each `.shadersubgraph` file is a Shader Graph subgraph -- drag into a Shader Graph to use as a node. No code required; Unity's Shader Graph handles it natively.

**Overlap Analysis:**

- **ASE (ENTRY-158):** Direct extension -- these nodes appear inside the ASE graph editor. No conflict; pure addition.
- **AllIn1 Shader (same publisher, ENTRY not in log):** AllIn1 Shader is a pre-built MonoBehaviour shader effect system for non-shader-authors. AllIn1 Shader Nodes is for shader authors using ASE/SG. Complementary -- different audiences.
- **Amplify Shader Pack (ENTRY-159):** ASP is complete pre-built shaders; AllIn1 Nodes are composable building blocks. Complementary.
- No conflict with any other evaluated asset.

**Verdict Rationale:** Approved, **Recommended | Shader**. Any project authoring shaders in ASE or Shader Graph benefits from a library of pre-built effect nodes. The 101 ASE nodes cover the full surface of common shader effects (dissolve, glow, hologram, chromatic aberration, fade, matcap, UV scroll) without writing HLSL. The SG subgraph equivalents extend the value to projects using Shader Graph instead of ASE. The shared HLSL library means the effect implementations are consistent and reusable across both editors. Having this installed means common shader tasks are drag-and-drop operations rather than HLSL authoring sessions.

**Concerns:**
- ASE compatibility requires importing a separate .unitypackage (BiRP or URP version). The base install does not automatically wire ASE support.
- SG subgraphs need to be verified in Unity 6's Shader Graph version -- `.shadersubgraph` format has changed across versions and may need re-saving.
- Installs to `Assets/Plugins/` (Assembly-CSharp-firstpass) -- same naming concern as AllIn1 Springs.

**Project Relevance:** Every project using ASE (Default) or Shader Graph -- HIGH across the board. Glow, hologram, hit flash, fade, matcap -- all covered without custom HLSL.

---

## ENTRY-270: Advanced FPS Counter 1.5.7 (CodeStage)

| Field | Value |
|-------|-------|
| **Asset** | Advanced FPS Counter |
| **Version** | 1.5.7 |
| **Developer** | CodeStage (Dmitriy Yukhanov) |
| **Source** | Asset Store |
| **Install Path** | `Assets/Plugins/CodeStage/AdvancedFPSCounter/` |
| **Primary Label** | -- |
| **Secondary Label** | QoL |
| **Verdict** | Approved |
| **Date** | 2026-03-06 |
| **Session** | 56 |

**What It Is:** Runtime debug overlay displaying FPS, memory usage, and device hardware info. Add to scene via `AFPSCounter.AddToScene()` or Inspector. Toggle on/off with a hotkey (backtick by default) or circle gesture (mobile). Desk review + code audit.

**Architecture:**

- 15 runtime scripts, 3 asmdefs (`CodeStage.AFPSCounter.Runtime`, `.Editor`, `.Examples`)
- Namespace: `CodeStage.AdvancedFPSCounter`
- Singleton MonoBehaviour (`AFPSCounter`), `DontDestroyOnLoad` by default
- Labels rendered via Unity UI (UGUI), not `OnGUI`

**Three Counter Modules:**

| Module | Fields Shown |
|--------|-------------|
| `FPSCounterData` | Current FPS, frame time (MS), Min FPS, Max FPS, Average FPS, Render thread FPS. Color thresholds: Warning (default 50fps, yellow), Critical (default 20fps, red). Configurable average sample count and reset-on-scene-load. |
| `MemoryCounterData` | Total memory, Allocated memory, Mono heap, GFX memory (editor/dev builds only). Per-field show/hide. Precise mode (more accurate, slightly more overhead). MB units. |
| `DeviceInfoCounterData` | Platform/OS, CPU name + core count, GPU name, VRAM, RAM, screen DPI, screen resolution. Static -- reads once at startup. |

**Key Features:**
- `AFPSCounter.AddToScene()` static method -- one line to add
- `AFPSRenderRecorder` -- captures render thread timing separately from main thread (uses `CommandBuffer` timing)
- `CachedNumbers` -- pre-caches string representations of common numbers to minimize GC on each update
- Hotkey toggle (BackQuote default), modifier keys (Ctrl/Shift/Alt), mobile circle gesture toggle
- `keepAlive = true` -- DontDestroyOnLoad by default

**Overlap with Ninja Profiler (ENTRY-206, Default):**

| Feature | Ninja Profiler (206) | Advanced FPS Counter (270) |
|---------|---------------------|---------------------------|
| FPS display | Yes | Yes (+ min/max/avg/render) |
| Memory | Unknown (not documented) | Yes (total/alloc/mono/gfx) |
| Device info | No | Yes (CPU/GPU/RAM/VRAM/DPI) |
| Toggle hotkey | Unknown | Yes (configurable) |
| Mobile gesture | Unknown | Yes (circle gesture) |
| Source | OccaSoftware UPM | Asset Store (Plugins/) |
| Architecture | Modern UPM | Older (UGUI-based) |
| Publisher | OccaSoftware | CodeStage (reputable) |

**Verdict Rationale:** Approved (no primary label). Ninja Profiler (ENTRY-206) already holds the Default slot for runtime performance overlay. Advanced FPS Counter adds memory and device info panels that Ninja Profiler does not document. Worth keeping installed alongside Ninja Profiler -- use Ninja Profiler for lightweight FPS overlay, use AFPS Counter when you need memory breakdown or device capability info in a running build. CodeStage is a reliable publisher (also makes Maintainer). The render thread timing and mobile gesture toggle are genuine additions.

**Concerns:**
- UGUI-based labels -- will not work with UI Toolkit-only projects without a Canvas in the scene
- `Assets/Plugins/` install (Assembly-CSharp-firstpass)
- GFX memory counter only available in Development Build or Editor (stripped from release builds via `#if`)

**Project Relevance:**
- Any project during development -- HIGH (memory counter is useful for profiling outside the editor)
- Mobile projects -- HIGH (circle gesture toggle, device info useful for device-specific debugging)
- Release builds -- LOW (GFX memory stripped; use Ninja Profiler for lightweight release-included overlay)

---

## ENTRY-271: Rope Toolkit 2.2.3

| Field | Value |
|-------|-------|
| **Asset** | Rope Toolkit |
| **Publisher** | Unknown (slug: 154662) |
| **Source** | Asset Store (https://assetstore.unity.com/packages/tools/physics/rope-toolkit-154662) |
| **Version** | 2.2.3 (Sep 23, 2025) |
| **Category** | Physics / Rope Simulation |
| **Session** | 56 |
| **Verdict** | Approved |
| **Label** | Recommended |
| **Evaluated in** | SyntyAssets project (E:\Unity\SyntyAssets) |

**What It Is:** Production-ready particle-based rope physics simulation engine. Uses Unity Jobs + Burst for high-performance multi-threaded simulation. Handles collision, rigidbody coupling, dynamic splitting (cutting), custom mesh rendering, and interpolation. Designed for both desktop and mobile.

**Folder:** `Assets/Toolkits/Rope/`

**Scale:** 15 C# scripts, ~3,048 LOC. No asmdef (global assembly). Namespace: `RopeToolkit`.

**Dependencies:** Unity.Burst (v1.1.2+), Unity.Jobs, Unity.Collections, Unity.Mathematics. All built-in Unity packages -- no third-party dependencies.

**Key Components (2 MonoBehaviours):**

**`Rope`** (1,799 lines) -- Core simulation engine:
- Particle-based rope with constraint satisfaction solver
- Configurable simulation: resolution, massPerMeter, stiffness, energyLoss, substeps, solverIterations
- Collision detection with sphere-cast stride, friction, collision margin, layer masking
- Custom rendering: configurable radius, radialVertices (3-32), or custom mesh chains (e.g., chain links)
- Interpolation modes: None, Interpolate, Extrapolate
- Loop support (rope loops back to start)

**`RopeConnection`** (258 lines) -- Attachment system with 4 modes:
1. **PinRopeToTransform** -- rope particle follows transform (grapple anchor)
2. **PinTransformToRope** -- transform follows rope particle (hanging object)
3. **PullRigidbodyToRope** -- velocity-based pull toward rope (respects physics)
4. **TwoWayCouplingBetweenRigidbodyAndRope** -- bidirectional interaction (swinging objects)

**Public API Surface:**
- **Spawn:** `PushSpawnPoint()` / `PopSpawnPoint()` -- build rope shape from control points
- **Query:** `GetParticleIndexAt(distance)`, `GetClosestParticle(point/ray)`, `GetPositionAt(index)`, `GetVelocityAt(index)`
- **Modify:** `SetPositionAt()`, `SetVelocityAt()`, `SetMassMultiplierAt()` (0=immovable, 2=double mass)
- **Split:** `SplitAt(particleIndex, outNewRopes)` -- dynamic rope cutting, creates 2 new Rope GameObjects
- **Reset:** `ResetToSpawnCurve()` -- useful for object pooling
- **Measure:** `measurements` struct (spawnCurveLength, realCurveLength, segmentCount, particleCount, particleSpacing)
- **Rigidbody:** `RegisterRigidbodyConnection(particleIndex, rb, damping, point, stiffness)` -- frame-by-frame coupling

**Helper Components:**
- `SimpleRopeInteraction` (171 lines) -- mouse-based rope picking, dragging, and splitting
- `PointsExtensions` (206 lines) -- curve math: length, interpolation, closest point, distance constraints
- `RigidbodyExtensions` (92 lines) -- inertia tensor, impulse at point, set velocity at point

**Demo Scenes (3):**
- `Main.unity` -- bridge planks, chain rendering, torque interaction
- `DynamicAttach.unity` -- runtime rope creation/destruction between moving transforms
- `BoxingRing.unity` -- runtime spawning with rope constraints

**Example Scripts:**
- `RopeBridgePlank.cs` (123 lines) -- two-rope suspension bridge with distance constraints and rigidbody sync
- `DynamicAttach.cs` (89 lines) -- runtime rope instantiation and RopeConnection setup

**Performance (per docs):**
- With collisions: ~0.2ms jobs + ~0.7ms main thread
- Without collisions: ~0.15ms jobs + ~0.35ms main thread
- Mobile-friendly with careful configuration (reduce resolution, collision stride)

**Architecture:**
- Jobs + Burst compiled simulation pipeline (~15 internal job structs in Rope.cs)
- NativeArray particle storage for zero-GC simulation
- Spawn curve defined by `List<float3>` control points, sampled at configured resolution
- Custom mesh rendering generates cylinder or repeating custom mesh per segment
- Collision uses sphere-cast with configurable stride (skip N particles between checks)

**Overlap Analysis:**

| Asset | Entry | Approach | Best For |
|-------|-------|----------|----------|
| **Rope Toolkit** | 271 | Jobs/Burst particle sim + rigidbody coupling | Interactive physics rope (swing, pull, cut, bridge) |
| Toolkit for Verlet Motion 2026 | 207 | Managed Verlet on transforms | Transform chains (tails, pendulums, rigid chains) |
| Full Rig (Chris West) | 140 | Catenary analytical | Static rigging (ship lines, dock tethers) |
| Mega Wires (Chris West) | 145 | Verlet + mesh | Power lines, hanging cables |
| MegaShapes rope | 137 | Verlet + loft mesh | Rope bridges, grapple line visuals |
| FS Rope Swinging System | 220 | Gameplay controller | Grapple-swing traversal mechanic |
| FS Grappling Hook System | 245 | Gameplay controller | Hook-based traversal mechanic |

**Key differentiation:** Rope Toolkit is the only rope asset with Jobs/Burst performance, dynamic splitting (cut mechanics), four-mode rigidbody coupling, and a full particle query API. It's a simulation engine, not a gameplay mechanic. FS Rope Swinging/Grappling Hook are gameplay controllers that could USE Rope Toolkit for their visual rope rendering. Heathen Verlet is simpler (transform-based, no Jobs) and better for lightweight chains/tails. Full Rig and Mega Wires are for static/decorative ropes.

**MCP Controllability (Session 56):**

| Operation | Rope | RopeConnection |
|-----------|------|----------------|
| `component-add` | ✅ | ✅ |
| `component-get` | ❌ crash (NativeArray) | not tested (avoid) |
| `component-modify` | ✅ simple fields (radius) | ✅ (type, ropeLocation) |
| `script-execute` read | ✅ all fields + sim settings | ✅ all fields |
| `script-execute` write | ✅ spawnPoints, simulation.*, collisions.* | ✅ |
| `script-execute` API | ✅ PushSpawnPoint, GetCurrentLength | ✅ |

**MCP control path:** Use `script-execute` for all Rope operations. The `component-get` tool crashes the MCP serializer because `Rope` stores `NativeArray<float3>` particle data internally — the reflector tries to serialize it and hangs. `component-modify` works for top-level simple fields but can't set nested structs (simulation, collisions). `script-execute` has full access to the entire API surface.

**Concerns:**
- No asmdef -- compiles into global assembly. With 15 scripts and `RopeToolkit` namespace, this is manageable but not ideal.
- 1,799-line monolithic Rope.cs -- hard to extend, but the public API is clean enough that you interact via methods, not internals.
- No network sync support -- would need custom serialization for multiplayer rope physics.
- **MCP serializer crash** -- `component-get` hangs Unity; must use `script-execute` exclusively. Not a blocker since the script-execute API coverage is complete.

**Verdict Rationale:** Approved with **Recommended** label (Physics domain). This is the best-in-class interactive rope simulation for Unity. Jobs/Burst performance puts it ahead of every other rope asset evaluated (Verlet, Full Rig, Mega Wires, MegaShapes). The dynamic splitting API enables rope-cutting gameplay. Four connection modes cover every attachment use case. The clean public API (particle queries, position/velocity set, rigidbody registration) makes it highly scriptable and potentially MCP-controllable.

**Project Relevance:**
- **HOK:** HIGH -- fishing line physics (cast, tension, reel), dock ropes, boat tethers. `TwoWayCouplingBetweenRigidbodyAndRope` is exactly what fishing rod → line → fish needs.
- **FearSteez:** MEDIUM -- whip physics (weapon), rope swing traversal, environment ropes. `SplitAt()` for rope-cutting combat mechanic.
- **A Quokka Story:** HIGH -- vine swinging, rope puzzles, bridge physics.
- **Alpha Foxtrot Uniform:** MEDIUM -- rappelling, ziplines, tow cables.

---

## ENTRY-272: MCP Controllability Eval — Rope/Physics Assets

| Field | Value |
|-------|-------|
| **Asset** | MCP Eval: 5 Rope/Physics Assets |
| **Source** | Internal (MCP tool testing) |
| **Session** | 56 |
| **Verdict** | Approved |
| **Label** | -- |
| **Evaluated in** | SyntyAssets project (E:\Unity\SyntyAssets) |

**What This Is:** MCP controllability evaluation for 5 rope and physics assets — testing whether Claude can create, read, configure, and control these assets via MCP tools (`component-add`, `component-get`, `component-modify`, `script-execute`).

**Assets Tested:**
1. Rope Toolkit 2.2.3 (ENTRY-271)
2. Toolkit for Unity Physics 2026 (ENTRY-207)
3. Toolkit for Verlet Motion 2026 (ENTRY-207)
4. FS Grappling Hook System (ENTRY-245)
5. FS Rope Swinging System (ENTRY-220)

**Full Results:**

| Asset | Component | Add | Read | Modify | script-execute | Notes |
|---|---|---|---|---|---|---|
| **Rope Toolkit** | `RopeToolkit.Rope` | ✅ | ❌ crash | ✅ simple | ✅ full API | NativeArray crashes serializer |
| **Rope Toolkit** | `RopeToolkit.RopeConnection` | ✅ | — | ✅ | ✅ | type, ropeLocation |
| **Unity Physics** | `Heathen.UnityPhysics.PhysicsData` | ✅ | ✅ | ✅ | — | Full control |
| **Unity Physics** | `Heathen.UnityPhysics.BuoyantBody` | ✅ | ✅ | ✅ | — | buoyantMagnitude, calculationMode, submergedRatio |
| **Unity Physics** | `Heathen.UnityPhysics.ForceEffectField` | ✅ | ✅ | ✅ | — | strength, radius, IsGlobal, curve, forceEffects |
| **Unity Physics** | `Heathen.UnityPhysics.ForceEffectReceiver` | ✅ | ✅ | ✅ | — | useLinear/Angular, sensitivity |
| **Verlet Motion** | `Heathen.UnityPhysics.VerletTransforms` | ✅ | ✅ | ✅ | — | Needs ScriptableObject for tree settings |
| **Verlet Motion** | `Heathen.UnityPhysics.VerletLine` | ✅ | ❌ crash | ❌ crash | — | Complex types crash serializer |
| **FS Grappling Hook** | `FS_GrapplingSystem.GrapplingHookController` | ✅ | ✅ | ✅ | — | Useless without FS PlayerController stack |
| **FS Rope Swinging** | `FS_SwingSystem.SwingController` | ✅ | ✅ | ✅ | — | Useless without FS PlayerController stack |
| **FS Rope Swinging** | `FS_SwingSystem.SwingLedge` | ✅ | ✅ | — | — | Simple hook point marker |

**MCP Serializer Crash Pattern:**
Components that use `Unity.Collections.NativeArray<T>`, `Unity.Mathematics.float3`, or complex Jobs/Burst internal structs crash the MCP reflector when `component-get` attempts to serialize them. The serializer enters an infinite loop or hangs trying to reflect these native types. Affected: `RopeToolkit.Rope`, `Heathen.UnityPhysics.VerletLine`. Workaround: use `script-execute` to read/write these components via C# code.

**Key Findings:**

**Rope Toolkit (Winner):** Despite the `component-get` crash, Rope Toolkit is the most MCP-controllable rope asset because `script-execute` gives full access to its rich public API. Claude can:
- Create ropes with spawn points
- Configure all simulation parameters (stiffness, mass, gravity, substeps)
- Enable/disable collisions with friction settings
- Add RopeConnection components with any of the 4 connection types
- Call PushSpawnPoint/PopSpawnPoint for dynamic rope building
- Query particle positions, velocities, and measurements
- Potentially call SplitAt, SetVelocityAt, SetMassMultiplierAt at runtime

**Unity Physics 2026 (Full MCP):** All 4 components fully controllable via standard MCP pipeline. No workarounds needed. Best MCP experience of the 5 assets. Buoyancy setup is straightforward: add Rigidbody → PhysicsData → BuoyantBody → set activeSurface.

**Verlet Motion 2026 (Partial):** VerletTransforms works for bone physics chains. VerletLine (the rope/cable component) is broken via MCP — same NativeArray crash. Would need script-execute workaround but wasn't tested (lower priority than Rope Toolkit).

**FS Grappling Hook / Rope Swinging (MCP Incompatible):** While the components technically add/read/modify fine, they require the full Fantacode Studios third-person controller infrastructure (PlayerController, LocomotionICharacter, ItemEquipper, AnimGraph, EnvironmentScanner, CameraController) to function. They are gameplay controllers, not standalone systems. MCP can configure their parameters but cannot make them work without the surrounding FS framework.

**Verdict Rationale:** This eval confirms that **Rope Toolkit is the best choice for MCP-controlled rope physics**, and **Unity Physics 2026 is the best choice for MCP-controlled buoyancy/force effects**. The FS assets are gameplay-specific and not independently MCP-controllable. VerletLine is broken via MCP. These findings directly inform the FearSteez meteor hammer weapon prototype: Rope Toolkit + script-execute is the viable path.

---

## ENTRY-273: Naninovel 1.21 (Elringus)

**Date:** 2026-03-09 (evaluated in VNPC project, Session 4)
**Source:** Asset Store
**Category:** Framework (Visual Novel / Storytelling Engine)
**Verdict:** Approved
**Label:** Recommended
**Namespace:** `Naninovel`
**Publisher:** Elringus

### Overview

Comprehensive visual novel / storytelling engine for Unity. Provides: text printers (ADV/NVL styles with typewriter reveal), character actor system (sprites, diced sprites, Live2D, Spine, 3D meshes -- with appearances, positions, lip sync), backgrounds with 30+ transition effects, branching choices, complete save/load with multiple slots, state rollback, skip & auto-advance, voicing system with auto-voicing, BGM/SFX/ambient audio, localization pipeline, special effects (rain, snow, blur, shake, bokeh, glitch, sun), unlockable CG gallery/tips, custom variables and expressions, full UI system (title screen, settings, backlog, 27 UI subsystems), and input processing. Service-oriented architecture. Developed for 10+ years. 5/5 stars, 74 reviews. Unity 6 compatible.

### Asset Structure

```
Packages/com.elringus.naninovel/
  Runtime/          -- 731 scripts (core engine)
    Actor/          -- character, background, printer, choice handler systems
    Audio/          -- BGM, SFX, voice playback
    Camera/         -- camera manipulation
    Commands/       -- 95 executable script commands
    Common/         -- utilities, async, collections, events, tweens (58 files)
    Configuration/  -- 23 configuration classes
    Engine/         -- core engine, service system, initialization
    Script/         -- script parsing, compilation, playback
    State/          -- save/load, rollback
    UI/             -- 27 UI subsystems
    (+ 13 more subsystem folders)
  Editor/           -- 159 scripts (editor tools)
  E2E/              -- 12 scripts (end-to-end testing)
  Prefabs/          -- UI, actor, effect prefabs
  Resources/        -- default resources
  Samples~/         -- Visual Novel sample
```

**Total scripts:** 902 (.cs files: 731 Runtime, 159 Editor, 12 E2E)
**Estimated LOC:** ~25,300
**Asmdefs:** 3 (`Elringus.Naninovel.Runtime`, `Elringus.Naninovel.Editor`, `Elringus.Naninovel.E2E`)

### Command System (95 commands)

All commands extend the `Command` base class and are auto-discovered by the engine. Commands map directly to `@command` syntax in .nani scripts.

**Actors (13):** `ModifyCharacter`, `ModifyBackground`, `ModifyActor`, `ShowActors`, `HideActors`, `HideAllActors`, `HideAllCharacters`, `ArrangeCharacters`, `AnimateActor`, `SlideActor`, `RemoveActors`, `LipSync`

**Audio (8):** `PlayBgm`, `StopBgm`, `PlaySfx`, `StopSfx`, `PlaySfxFast`, `PlayVoice`, `StopVoice`

**Text / Printers (10):** `PrintText`, `AppendText`, `ResetText`, `FormatText`, `ShowPrinter`, `HidePrinter`, `ModifyTextPrinter`, `ClearBacklog`

**Branching / Logic (13):** `AddChoice`, `RequireChoice`, `BeginIf`, `Else`, `EndIf`, `Unless`, `While`, `SelectRandom`, `SetCustomVariable`, `InputCustomVariable`, `ResetState`

**Playback Control (13):** `Goto`, `Gosub`, `Return`, `Stop`, `Skip`, `Wait`, `Await`, `AwaitInput`, `ExecuteAsync`, `Sync`, `Group`, `EnterDialogue`/`ExitDialogue`

**Visuals / Effects (16+):** `ModifyCamera`, `Spawn`, `DestroySpawned`, `SpawnBlur`, `SpawnBokeh`, `SpawnGlitch`, `SpawnRain`, `SpawnShake`, `SpawnSnow`, `SpawnSun`, `TransitionScene`, `PlayMovie`, `ControlTimeline`

**UI / System (12):** `ShowUI`, `HideUI`, `ShowToastUI`, `Lock`, `Unlock`, `AutoSave`, `LoadScene`, `UnloadScene`, `OpenURL`, `PurgeRollback`, `ExitToTitle`

### Actor System (11 implementation types)

| Actor Type | Description |
|------------|-------------|
| `SpriteActor` | Standard sprite-based (Character, Background) |
| `DicedSpriteActor` | Sprite dicing for memory optimization |
| `LayeredActor` | Composite layered characters (body + face + clothes) |
| `GenericActor` | Custom prefab-based actors |
| `VideoActor` | Video as actor appearance |
| `Live2DActor` | Live2D model integration |
| `SpineActor` | Spine skeleton animation |
| `SceneBackground` | Unity scene as background |
| `NarratorCharacter` | Speaker with no visual representation |
| `PlaceholderActor` | Colored shapes with ID labels (dev/testing) |
| `TransientActor` | Runtime-created actors |

Managed by `CharacterManager`, `BackgroundManager`, `TextPrinterManager`, `ChoiceHandlerManager`.

### Configuration System (23 classes)

All extend `Configuration` base, edited via `Naninovel > Configuration` menu: `EngineConfiguration`, `CameraConfiguration`, `InputConfiguration`, `ScriptsConfiguration`, `ScriptPlayerConfiguration`, `CharactersConfiguration`, `BackgroundsConfiguration`, `TextPrintersConfiguration`, `ChoiceHandlersConfiguration`, `AudioConfiguration`, `StateConfiguration`, `LocalizationConfiguration`, `ResourceProviderConfiguration`, `UIConfiguration`, `SpawnConfiguration`, `UnlockablesConfiguration`, `CustomVariablesConfiguration`, `ManagedTextConfiguration`, `MoviesConfiguration`, + 4 base/utility configs.

### UI System (27 subsystems)

Pre-built UI panels covering the complete VN experience: Backlog, ClickThrough, ContinueInput, ControlPanel, TextPrinter, ChoiceHandler, Title, Pause, GameSettings, SaveLoad, Confirmation, CGGallery, Tips, ScriptNavigator, Toast, Movie, Loading, Rollback, ExternalScripts, VariableInput, Debug, and more. All implement `IManagedUI` interface.

### Save / State System

3-tier state: `GameStateMap` (per-playthrough), `GlobalStateMap` (persistent), `SettingsStateMap` (settings). `StateRollbackStack` for undo/rollback. Three save backends: `IOSaveSlotManager` (file system), `PlayerPrefsSaveSlotManager`, `TransientSaveSlotManager` (in-memory).

### Resource System (6 provider types)

`ProjectResourceProvider` (Resources folder), `LocalResourceProvider` (file system), `AddressableResourceProvider` (optional), `VirtualResourceProvider` (custom/mocking). Converters for JPG/PNG→Texture, WAV→AudioClip, TXT→TextAsset, .nani→Script.

### Integrations

**Official extensions:** Live2D, Spine (character animation middleware -- not installed in Sandbox)
**Complementary assets:** Adventure Creator (ENTRY-251) for hybrid VN/P&C, Text Animator (ENTRY-117) for per-character text effects, DOTween Pro, Cinemachine, Timeline
**No official integration:** Dialogue System (ENTRY-214) -- competing approaches for dialogue; use DS for P&C games, Naninovel for VN games

### Verdict Rationale

Approved, **Recommended**. Naninovel is the most complete VN engine available for Unity. 902 scripts, ~25K LOC across 3 assemblies, clean `Naninovel` namespace. Service-oriented architecture with 23 configuration classes provides deep customization without code changes. The .nani script format is ideal for AI-assisted authoring -- plain text, simple syntax, full narrative control. 11 actor types cover every character rendering approach (sprites, Live2D, Spine, 3D, video). Placeholder actors enable full greybox prototyping before any art exists.

Directly relevant to the VNPC project's two visual novels (Genie in a Test Tube, Encapsulated Fear). Not needed for P&C games (Adventure Creator handles those). The Text Animator integration (custom `UITextPrinterPanel` subclass) has been validated in VNPC -- all TA effect tags survive Naninovel's script parser intact.

**Note:** Evaluated and deep-dived in the VNPC project (`E:\Unity\VNPC\VisualNovelPointClick`). Full VNPC-specific evaluation with project relevance table at `VNPC_AssetLog.md` ENTRY-004.

### Project Relevance

| Project | Relevance | Notes |
|---------|-----------|-------|
| VNPC (Genie in a Test Tube) | HIGH | Primary VN engine. Currently in development. |
| VNPC (Encapsulated Fear) | HIGH | Same stack. Second VN to develop. |
| GRIMMORPG | LOW | 3D action RPG, not a VN |
| Space Garbage Man | LOW | 3D P&C, Adventure Creator is better fit |
| HOK | LOW | Not a narrative game |
| FearSteez | LOW | Beat em up, no VN mechanics |
| Miracle Worker | MEDIUM | Could use for narrative/cutscene sequences |

---

## ENTRY-274: Bro Audio 2.2.2

**Date:** 2026-03-11 (AudioProject Session 2)
**Source:** Asset Store
**Category:** Audio (Mixing/API)
**Verdict:** Conditional
**Label:** Default Audio | Mixing, SFX
**Namespace:** `Ami.BroAudio`

Mid-weight audio management framework. Clean static API facade, fluent chaining, interface segregation (ISP). Dominator pattern for auto-resetting ducking/filtering. PlaybackGroup rules. Complementary to Master Audio (lighter, programmer-friendly). 291 scripts, 2 asmdefs. Missing musical time concepts for adaptive audio. Full eval in `E:\Unity\AudioProject\Documents\Audio_AssetLog.md` ENTRY-001.

---

## ENTRY-275: Procedural Music Generator 2.0.0

**Date:** 2026-03-11 (AudioProject Session 2)
**Source:** Asset Store
**Category:** Audio (Procedural Music)
**Verdict:** Conditional
**Label:** Recommended | Music, Procedural
**Namespace:** `ProcGenMusic`

True procedural music generation from music theory. Keys, scales, modes, chord progressions. Leitmotif system (per-instrument preset motifs). 4 instrument groups with runtime toggling. Built-in synth. FMOD backend support. Mod system for extensibility. 165 scripts, 0 asmdefs. Highest relevance to adaptive audio "Peter and the Wolf" vision. Code quality concerns: no asmdef, var throughout, 2578-line God Object ConfigurationData. Full eval in `E:\Unity\AudioProject\Documents\Audio_AssetLog.md` ENTRY-002.

---

## ENTRY-276: Maestro - Midi Player Tool Kit 2.18.0 (Free)

**Date:** 2026-03-11 (AudioProject Session 2)
**Source:** Asset Store
**Category:** Audio (MIDI Synth)
**Verdict:** Conditional
**Label:** Default Audio | MIDI
**Namespace:** `MidiPlayerTK`

Complete MIDI-to-audio SoundFont synthesis engine (FluidSynth port). Per-channel mute/volume/preset-override. MidiStreamPlayer for real-time note generation. 170 scripts, 3 asmdefs. Complements DryWetMIDI (data vs playback). Zero interfaces. Pro version gates key features. Full eval in `E:\Unity\AudioProject\Documents\Audio_AssetLog.md` ENTRY-003.

---

## ENTRY-277: Kalend Music and Playlist Player 1.0

**Date:** 2026-03-11 (AudioProject Session 2)
**Source:** Asset Store
**Category:** Audio (Music Playback)
**Verdict:** Rejected
**Label:** Don't Use
**Namespace:** `Kalend`

Hobbyist jukebox. Static singleton (public static fields for all state). 4-level deep inheritance. Zero interfaces. Bug: 44.1kHz coded as 41100. Duplicate code files. Master Audio playlists are vastly superior. 13 scripts. Full eval in `E:\Unity\AudioProject\Documents\Audio_AssetLog.md` ENTRY-004.

---

## ENTRY-278: Localized Audio 1.0

**Date:** 2026-03-11 (AudioProject Session 2)
**Source:** UPM (`com.fenikkel.localized-audio`)
**Category:** Audio (Localization)
**Verdict:** Rejected
**Label:** Don't Use

327-line singleton wrapper around Unity's built-in `LocalizeAudioClipEvent`. Adds almost nothing. Dead code, bare catch blocks, build-breaking samples. Unity's native localization handles this. 1 script. Full eval in `E:\Unity\AudioProject\Documents\Audio_AssetLog.md` ENTRY-005.

---

## ENTRY-279: VoiceGPT 2.0

**Date:** 2026-03-11 (AudioProject Session 2)
**Source:** Asset Store
**Category:** Audio (TTS/Editor)
**Verdict:** Rejected
**Label:** Don't Use

Editor-only TTS using local StyleTTS2 via Python. 872MB of ML models. Requires Python for Unity + CUDA GPU. Zero runtime API. Monolithic 1200-line EditorWindow. `exec()` config parsing (injection risk). Build-breaking demo script. 4 scripts, 0 asmdefs. Full eval in `E:\Unity\AudioProject\Documents\Audio_AssetLog.md` ENTRY-006.

---

## ENTRY-280: Photon Voice 2 2.63

**Date:** 2026-03-11 (AudioProject Session 2)
**Source:** Asset Store
**Category:** Audio (Networking/Voice)
**Verdict:** Rejected
**Label:** Don't Use
**Namespace:** `Photon.Voice`

Networked voice chat SDK. 337MB. Requires paid Photon Cloud subscription. Drags entire Photon networking stack. Zero capabilities for audio creation, procedural audio, or adaptive music. Good architecture for its domain (clean interfaces) but wrong tool for audio creation. 246 scripts. Full eval in `E:\Unity\AudioProject\Documents\Audio_AssetLog.md` ENTRY-007.

---

## ENTRY-281: Ink Integration for Unity 1.1.8 (Inkle)

**Date:** 2026-02-21 (VNPC Session 1)
**Source:** GitHub (MIT license)
**Category:** Scripting (Narrative)
**Verdict:** Approved
**Label:** Recommended

Open-source narrative scripting language by Inkle Studios. Plain-text `.ink` files with minimal markup for branching stories: knots/stitches, choices (`*`/`+`), diverts (`->`), variables, conditional text, sequences/cycles/shuffles, functions, tunnels, threads, lists, tags, and external function hooks. Unity integration provides C# runtime API, auto-compilation (.ink to .json), and in-editor Ink Player. Pure middleware -- handles narrative logic only, no audio/visuals/UI. Used in 80 Days, Sable, Heaven's Vault, Sea of Thieves, Vampire: The Masquerade Bloodlines 2. AI-Friendliness: Excellent -- most AI-writable format possible, 4 core concepts, auto-compiles in Unity. Integrates with Dialogue System for Unity (official) and Adventure Creator (community). FREE (MIT license).

---

## ENTRY-282: PATWA (com.tecvoodoo.patwa)

**Date:** 2026-03-11 (AudioProject Session 6)
**Source:** Internal (TecVooDoo)
**Category:** Audio (Adaptive Music System)
**Verdict:** Testing
**Label:** --

TecVooDoo's custom adaptive music system. Singleton pattern (`MusicDirector.Instance`) with 22 MCP-controllable tools across 6 tiers: context management, contributor control, mix control, beat clock, reactive bindings, and debug. Purpose-built for MCP controllability. MCP Rating: Exceptionally High -- synchronous getters/setters, string-based stem/contributor IDs, no async barriers, every subsystem exposed through MusicDirector facade.

---

## ENTRY-283: PolygonHorrorCarnival (Synty)

**Date:** 2026-02-17 (SyntyAssets Session)
**Source:** Synty Studios
**Category:** Art (Character)
**Verdict:** Conditional
**Label:** Art

**HOK Use:** Kharon off-duty body base. Slim body type (SM_Chr_Slim_01) -- best lean/tall silhouette in Synty library. Carny skin selected for Kharon off-duty. Root bone scale 1.0 -- no attachment compensation needed. Attachments parent directly to bones at localScale (1,1,1). Horror-themed content -- many skins not suitable for general use. Partial eval.

---

## ENTRY-284: PolygonDungeonRealms (Synty)

**Date:** 2026-02-17 (SyntyAssets Session)
**Source:** Synty Studios
**Category:** Art (Character)
**Verdict:** Conditional
**Label:** Art

**HOK Use:** Kharon on-duty skull and hood. SM_Chr_Attach_Hood_01 fits HorrorCarnival Slim rig head bone well. SM_Chr_Attach_Undead_Knight_Skull_01 is full skull head replacement (original head mesh visible underneath). Both are static meshes (MeshFilter + MeshRenderer). Scale compensation needed on 0.01-scale rigs (localScale=100). Partial eval.

---

## ENTRY-285: PolygonFantasyCharacters (Synty)

**Date:** 2026-02-17 (SyntyAssets Session)
**Source:** Synty Studios
**Category:** Art (Character)
**Verdict:** Conditional
**Label:** Art

**HOK Use:** Kharon on-duty robe. Character_Male_Wizard -- full-length dark robe, strong grim reaper silhouette. Root bone scale 0.01 (centimeter-space FBX). Static mesh attachments need localScale=(100,100,100) on this rig. Bone positions use large local values but correct world positions. Partial eval.

---

## ENTRY-286: PolygonTown (Synty)

**Date:** 2026-02-17 (SyntyAssets Session)
**Source:** Synty Studios
**Category:** Art (Props)
**Verdict:** Conditional
**Label:** Art

**HOK Use:** Kharon's cooler prop. SM_Prop_Cooler_01 -- 0.58m x 0.29m x 0.43m, used as height riser for on-duty Kharon. Partial eval -- full pack not reviewed.

---

## ENTRY-287: PolygonExplorers (Synty)

**Date:** 2026-02-17 (SyntyAssets Session)
**Source:** Synty Studios
**Category:** Art (Character)
**Verdict:** Conditional
**Label:** Art

**HOK Use:** Kharon beard. SM_Chr_Attach_Beard_01 -- static mesh, fits Synty head bone at near-zero offset (localPos 0, 0, 0.01). Partial eval -- only one attachment tested.

---

## ENTRY-288: PolygonFarm (Synty)

**Date:** 2026-02-17 (SyntyAssets Session)
**Source:** Synty Studios
**Category:** Art (Character)
**Verdict:** Conditional
**Label:** Art

**HOK Use:** None (replaced). SM_Chr_Farmer_Male_Old_01 considered for Kharon off-duty but replaced by HorrorCarnival Slim/Carny (better body type). Partial eval.

---

## ENTRY-289: PolygonStreetRacer (Synty)

**Date:** 2026-02-17 (SyntyAssets Session)
**Source:** Synty Studios
**Category:** Art (Character)
**Verdict:** Conditional
**Label:** Art

**HOK Use:** None. Fisherman character inspected for standalone fishing rod -- rod is baked into character mesh, no separate prop. Use GanzSe Fantasy Fishing Props instead. Partial eval.

---

## ENTRY-290: PolygonHorrorMansion (Synty)

**Date:** 2026-02-17 (SyntyAssets Session)
**Source:** Synty Studios
**Category:** Art (Props)
**Verdict:** Conditional
**Label:** Art

**HOK Use:** Kharon scythe weapon + Count mask (backup). SM_Prop_Scythe_01 -- 0.82m x 1.87m, best grim reaper scythe found across all packs. SM_Prop_Mask_Count_01 -- backup on-duty face option. Scythe grip on hand_l: localPos (-0.16, -0.06, -0.03), localRot (70.8, 2.7, 8.7). Partial eval.

---

## ENTRY-291: SidekickCharacters (Synty)

**Date:** 2026-02-17 (SyntyAssets Session)
**Source:** Synty Studios
**Category:** Art (Character)
**Verdict:** Conditional
**Label:** Art

**HOK Use:** Kharon on-duty body (replaces Carny placeholder). Custom character creator -- user built a "Kharon" character. Humanoid rig with built-in IK bones (ik_foot_l/r, ik_hand_l/r) and dedicated attachment bones (prop_l/r, headAttach, faceAttach, hipAttach, backAttach, shoulderAttach, elbowAttach, kneeAttach). Bone naming: lowercase (hand_l, head, pelvis) -- differs from Polygon PascalCase (Hand_L, Head, Hips). Root scale 1.0. Mixamo Humanoid animations retarget correctly. See `FS_Synty_Reference.md` for full bone/attachment reference.

---

## ENTRY-292: City Characters 1.2 (ITHappy)

**Date:** 2026-03-12 (Session 57)
**Source:** Asset Store (~$20 sale, Unity $20 sale week)
**Category:** Art + Character Customization System
**Verdict:** Approved
**Label:** Character
**Path:** `Assets/ithappy/City_Characters/`

**What it is:** Low-poly 3D character system. 1,727 prefabs, 1,427 FBX models, 228 animations, 25 materials, 67 scripts. 6 body types (Adult, Teen, Child, Plus-Size, Senior, Pumped) x 2 genders. 11 customization slots (SkinColor, Face, Hair, FacialHair, Hat, Glasses, Outerwear, Gloves, Pants, Shoes, Accessories) with 27 group categories. 17 face expressions via `FacePicker` runtime component. Editor customization window with live 3D preview. URP conversion package included. Humanoid rigged, retargetable.

**Architecture:**
- Immutable state pattern (`CharacterState`, `SlotState`, `FullBodyState` are readonly structs)
- SO-driven config (`ToolConfig` -> `BodyTypeEntry` -> `GenderEntry` -> `SlotEntry` -> `GroupEntry`)
- Slot-based mesh swapping via `SkinnedMeshRenderer.sharedMesh` reassignment
- Editor namespace: `CharacterCustomizationTool.Editor` / Runtime: `Controller`
- No asmdef -- 67 scripts compile to Assembly-CSharp

**Key API:**
- `CustomizableCharacter`: `Randomize()`, `SetState(CharacterState)`, `InstantiateCharacter()`, `SelectNext/Previous(SlotType)`, `TryGetVariantByName(SlotType, string)`, `SetEnabled(SlotType, bool)`, `GetMeshRenderers()`
- `FacePicker`: `PickFace(FaceType)`, `HasFace(FaceType)`, `SetFaces(Mesh[])` -- 17 expressions (Happy, Sad, Angry, Surprised, Evil, Neutral, etc.)
- `CharacterMover`: walk 1.5 m/s, run 4.0 m/s, IK look-at. Requires CharacterController + Animator.
- Editor: `Tools/Character Customization (Ctrl+Alt+E)` -- live preview, randomizer (16-step pipeline), save as prefab, undo history (10 slots)

**Animations (228 total, per body type):** Idle variants (DanceIdle, LookAround, LookPhone, TalkPhone), Run, Sitting (Bench, Ground, Table), Interaction (TakePhoto, TalkGesture), Props (Stroller).

**Includes:** Dog and cat models (Dachshund, Doberman, Labrador, Pomeranian, Cats).

**Concerns:**
- No asmdef -- 67 scripts in Assembly-CSharp
- Runtime controller is basic (CharacterMover/ThirdPersonCamera) -- replace in any real project
- Art style is its own thing -- won't match Synty Polygon aesthetic
- Editor customization window not available at runtime (Editor namespace)

**Project Relevance:**
- VNPC: HIGH -- NPC population for point-and-click. Body type variety (adult/child/senior) is ideal for populated world scenes.
- 3D Action/Adventure concepts: HIGH -- crowd/NPC filler with customization API.
- 3D Point N Click concepts: HIGH -- same as VNPC.
- HOK/FearSteez: LOW -- different art style from Synty pipeline.

**MCP Potential:** High. `CustomizableCharacter` API is programmatic with string-based variant lookups, slot cycling, and state management. `FacePicker` is trivially controllable. Worth MCP-EVAL if used in VNPC.

**Asset Interactions:** No conflicts with existing evaluated assets. Separate art pipeline from Synty. Runtime controller would be replaced by Adventure Creator (ENTRY-251) or custom input in actual projects.

---

## ENTRY-293: Urban Traffic System Full Pack 2.0 (Aglobex)

**Date:** 2026-03-12 (Session 57)
**Source:** Asset Store (~$300 normal, purchased at $20 sale)
**Category:** AI / Simulation (Urban Traffic)
**Verdict:** Approved
**Label:** AI
**Path:** `Assets/UTS_FullPack/`

**What it is:** Complete urban traffic simulation. 41 scripts (6,691 LOC), 54 vehicle prefabs (27 day + 25 night + 2 trailers), 123 pedestrian prefabs, 68 bicycle/gyroscooter prefabs, 4 semaphore types, 334 materials, 13 demo scenes + 3 ragdoll scenes, 11 custom editor tools, 6 PDF tutorials. Vehicles, pedestrians, cyclists, traffic lights, ragdolls all integrated.

**Architecture:**
- Path hierarchy: `WalkPath` (base) -> `CarWalkPath`, `PeopleWalkPath`, `BcycleGyroPath`, `AudiencePath`
- Vehicle: `CarAIController` (AI) + `CarMove` (WheelCollider physics, 3 drive types, 5 gears) + `CarWheels` (mesh sync) + `EasySuspension`
- Traffic: `SemaphoreSystem` (abstract) -> `OneWaySemaphoreSystem`, `StandardSemaphoreSystem`, `TSemaphoreSystem`, `TogetherArrowSemaphoreSystem`
- Pedestrian: `Passersby` (walk/run AI, 55deg FOV, 3m radius) + `NPCStats` (ragdoll on collision) + `PeopleController` (standing idle cycle)
- Trailer system via ConfigurableJoint (`AddTrailer`)
- Tag-based interaction: "Car", "People", "Bcycle", "PeopleSemaphore"
- Layer-based: People=8, Car=9, Bcycle=12
- No asmdef, no namespace -- 41 scripts in Assembly-CSharp

**Key Systems:**
- Multi-lane paths (1-4 lanes, configurable spacing, 6 direction patterns: Forward/Backward/HugLeft/HugRight/WeaveLeft/WeaveRight)
- Density-based population spawning (0.01-0.50 per meter) with queue-based respawn
- Raycast vehicle AI (forward/left/right rays, 20m range, speed clamping on obstacles)
- Pedestrian FOV detection via Physics.OverlapSphere + raycast LOS verification
- Emission-based traffic lights (material keyword "_EMISSION"), no actual Light components
- Day/night vehicle variants with emissive headlights
- Ragdoll activation on vehicle-pedestrian collision
- Audience/concert crowd layout system

**Key Parameters:**
- Vehicle speed: 0-15 m/s, ±15% randomization per spawn
- Pedestrian: walk 1.2 m/s, run 3.0 m/s
- Semaphore: green 5-10s, yellow 2-3s, red 5-10s, pedestrian 3-5s
- Vehicle AI: distanceToCar 10-15m, distanceToSemaphore 10m, maxAngleToMoveBreak 8deg

**Concerns:**
- No asmdef, no namespace -- 41 scripts in global namespace / Assembly-CSharp
- Bilingual comments (English + Russian) throughout -- functional but noisy
- Tag/layer dependent -- requires specific tags and layers configured in project
- Road assets minimal -- one Big_Road prefab + modular parts; bring your own roads for production
- WheelCollider physics can be finicky with Unity settings

**Project Relevance:**
- 3D Action/Adventure concepts: HIGH -- urban environments need traffic and pedestrian life
- 3D Point N Click concepts: MEDIUM -- could populate city scenes with ambient movement
- HOK/FearSteez/VNPC/DLYH: LOW -- wrong genre

**MCP Potential:** Medium. Paths and semaphore timing configurable via serialized fields (component-modify). Density-based spawning controllable. Tag/layer setup requires manual config. Standard component pipeline sufficient -- no custom MCP tools warranted.

**Asset Interactions:** Could pair with City Characters (ENTRY-292) for pedestrian variety -- swap out included pedestrian prefabs with ITHappy characters for more body type diversity. Road/terrain assets needed from other sources for production environments.

---

## ENTRY-302: Genies Avatar SDK 2.8.5

**Date:** 2026-03-17 (GeniesTest Session 1)
**Source:** Genies Inc. (via Genies Developer Portal / Unity Package Manager)
**Category:** Character Customization + Avatar System (Cloud-Connected)
**Verdict:** Approved
**Label:** Character
**Path:** `Packages/com.genies.avatar-sdk.client/` (UPM package)

**What it is:** Cloud-connected avatar customization SDK. 3,072 C# scripts across 89 asmdefs, ~60 internal modules. Provides full avatar lifecycle: authentication (Email OTP, password, anonymous), avatar loading (default, user, by definition, by userId, test), real-time customization (wearables, hair, tattoos, makeup, body morphs, colors), and a built-in avatar editor UI. Avatars are humanoid with Animator, CharacterController support, and Cinemachine camera integration. Uses UMA (Unified Multipurpose Avatar) internally for mesh generation. Includes UniTask, VContainer, xNode, UnityGLTF, NAF Plugin (KTX textures) as vendored internal dependencies.

**Architecture:**
- Singleton static API: `AvatarSdk.*` -- all public methods are static on a partial class split across 6 files (core, login, loginOtp, loginPassword, loginAnonymous, avatarEditor)
- `ManagedAvatar` -- primary handle returned from all Load* methods. Contains `.Root` (GameObject), `.Component` (ManagedAvatarComponent MonoBehaviour), `.GetDefinition()` (JSON string), `.Dispose()`
- Avatar definition is a JSON blob that fully describes an avatar's appearance -- cacheable, transferable between sessions, loadable via `LoadAvatarByDefinitionAsync`
- `AvatarLoadedNotifier` -- static event bus for Loaded/Destroyed events
- Internal DI via VContainer, service management via `ServiceManager` scopes
- Authentication required for most operations (demo mode available for testing without credentials)
- 89 asmdef files -- excellent assembly isolation, no Assembly-CSharp pollution
- Requires IL2CPP, .NET 4.8, Vulkan (Windows) -- enforced by Bootstrap Wizard

**Key API (all on `AvatarSdk` static class):**
- **Init:** `InitializeAsync()`, `InitializeDemoModeAsync()`
- **Auth:** `TryInstantLoginAsync()`, `StartLoginEmailOtpAsync(email)`, `SubmitEmailOtpCodeAsync(code)`, `StartLoginPasswordAsync(email, password)`, `StartLoginAnonymousAsync(appId)`, `LogOutAsync()`, `IsLoggedIn`, `GetUserIdAsync()`, `GetUserNameAsync()`
- **Avatar Loading:** `LoadDefaultAvatarAsync()`, `LoadUserAvatarAsync()`, `LoadUserAvatarByUserIdAsync(userId)`, `LoadAvatarByDefinitionAsync(json)`, `LoadTestAvatarAsync()`, `PrecacheUserAvatarAssetsAsync()`
- **Avatar Definition:** `GetUserAvatarDefinition()`, `GetUserAvatarDefinition(userId)`, `SaveAvatarDefinitionLocallyAsync()`, `SaveUserAvatarDefinitionAsync()`, `LoadFromLocalAvatarDefinitionAsync(profileId)`
- **Wearables:** `GetDefaultWearablesByCategoryAsync(WearablesCategory)`, `GetUserWearablesByCategoryAsync(UserWearablesCategory)`, `EquipWearableByWearableIdAsync(avatar, id)`, `UnEquipWearableByWearableIdAsync(avatar, id)`, `EquipOutfitAsync()`, `UnEquipOutfitAsync()`, `GetUsersAssetsAsync()`, `GiveAssetToUserAsync(assetId)`
- **Hair:** `GetDefaultHairAssets(HairType)`, `EquipHairAsync()`, `EquipHairByHairAssetIdAsync()`, `UnEquipHairAsync()` -- HairType: Hair, FacialHair, Eyebrows, Eyelashes
- **Tattoos:** `GetDefaultTattoosAsync()`, `EquipTattooAsync(avatar, tattoo, slot)`, `UnEquipTattooAsync(avatar, slot)` -- MegaSkinTattooSlot enum for body regions
- **Makeup:** `GetDefaultMakeupByCategoryAsync(AvatarMakeupCategory)`, `EquipMakeupAsync()`, `UnEquipMakeupAsync()` -- Categories: Lipstick, etc.
- **Body Morphs:** `SetAvatarBodyTypeAsync(avatar, GenderType, BodySize)`, `ModifyAvatarFeatureStat(avatar, stat, float)`, `ModifyAvatarFeatureStats(avatar, Dictionary<stat,float>)`, `GetAvatarFeatureStats(avatar, statType)`
- **Feature Stats:** EyeBrows (Thickness/Length/VerticalPosition/Spacing), Eyes (Size/VerticalPosition/Spacing/Rotation), Jaw (Width/Length), Lips (Width/Fullness/VerticalPosition), Nose (Width/Length/VerticalPosition/Tilt/Projection), Body (NeckThickness/ShoulderBroadness/ChestBustline/ArmsThickness/WaistThickness/BellyFullness/HipsThickness/LegsThickness)
- **Colors:** `SetColorAsync(avatar, IAvatarColor)`, `GetColorAsync(avatar, AvatarColorKind)`, `GetDefaultColorsAsync(ColorType)`, `GetUserColorsAsync(UserColorType)`, `SetSkinColorAsync(avatar, Color)`, `CreateSkinColor()`, `CreateHairColor()`, `CreateFacialHairColor()`, `CreateEyeBrowsColor()`, `CreateEyeLashColor()`, `CreateMakeupColor()`
- **Avatar Features:** `GetDefaultAvatarFeaturesByCategory(AvatarFeatureCategory)`, `SetAvatarFeatureAsync()` -- Categories: Eyes, Jaw, Lips, Nose
- **Avatar Editor (built-in UI):** `OpenAvatarEditorAsync(avatar, camera)`, `CloseAvatarEditorAsync(revertAvatar)`, `IsAvatarEditorOpen`, `SetEditorSaveLocallyAndContinueAsync()`, `SetEditorSaveRemotelyAndExitAsync()`
- **Events:** `Events.UserLoggedIn`, `Events.UserLoggedOut`, `Events.AvatarEditorOpened`, `Events.AvatarEditorClosed`, `Events.EmailOtpSent`, `Events.PasswordVerificationCodeSent`

**Sample Scenes (imported):**
- **DemoMode** -- loads test avatar without login, CharacterController movement, Cinemachine FreeLook, mobile touch UI (virtual joystick + buttons). 9 root objects.
- **Avatar Starter** -- `CreateGeniesAvatar` MonoBehaviour, auto-spawns user avatar on Start
- **Using Multiple Avatars** -- multi-avatar spawn/destroy with avatar editor integration
- **Creating an Avatar Editor** -- full custom avatar editor UI sample

**Dependencies (package.json):**
- Addressables 1.19.19, Animation Rigging 1.2.1, Burst 1.8.15, Cinemachine 3.1.5, KTX 3.5.0, Input System 1.14.0, Mathematics 1.2.6, Newtonsoft JSON 3.2.1, URP 14.0.11, ShaderGraph 12.1.9, TextMeshPro 3.0.9, Timeline 1.7.6, uGUI 1.0.0

**Concerns:**
- **Cloud dependency:** All avatar loading and most customization requires active internet + Genies API server. Avatars are downloaded at runtime, not stored as local assets. Offline-first games can't use this.
- **Authentication wall:** Most API calls require login (demo mode is limited to test avatars). User account system is Genies-owned, not your own auth.
- **Vendor lock-in:** Avatar meshes generated via UMA pipeline internal to SDK. Can't export/modify meshes outside the SDK. Clothing/wearable assets are Genies marketplace items, not standard FBX/prefabs.
- **3,072 scripts:** Massive codebase. Compile time impact is mitigated by 89 asmdefs, but the package is heavy.
- **Vendored UniTask:** SDK bundles its own UniTask internally -- potential conflict if project also has Cysharp UniTask (namespace collision). GeniesTest doesn't have standalone UniTask so no issue here, but Sandbox would conflict.
- **Build requirements:** IL2CPP + .NET 4.8 + Vulkan enforced. Mono backend not supported.
- **Art style:** Genies avatars have their own stylized look -- won't match Synty Polygon or other art pipelines. For FearSteez, this is the avatar system, not a supplement.
- **Clothing packs** (Endless Summer, Campus Comeback, Alpine Winter, After Dark) show in Package Manager but resolve as part of the Genies wearable system, not as standalone packages with local prefabs.

**Project Relevance:**
- FearSteez: LOW -- evaluated for clothing monetization but rejected. Beat 'em up needs local meshes, full rig control, offline combat. Synty Sidekick slot-based mesh swapping + Unity IAP is the correct path for FearSteez branded clothing.
- HOK: LOW -- different character pipeline (Synty + custom)
- VNPC: MEDIUM -- could work for social/lobby NPC avatars with user identity in point-and-click scenes
- DLYH: LOW -- wrong genre
- Social/Metaverse concepts: HIGH -- this is the SDK's sweet spot. User-owned avatars with cloud persistence, wearable marketplace, customization editor.
- 3D Action/Adventure concepts: LOW -- cloud dependency and lack of mesh control make it unsuitable for action games

**MCP Potential:** High. The entire public API is static methods on `AvatarSdk` -- ideal for `script-execute`. Wearable/hair/tattoo/color operations use string IDs and enums. Body morph stats use `Dictionary<AvatarFeatureStat, float>` with -1 to 1 range. All async operations return UniTask. Could build MCP tools for: avatar spawning, wearable cycling, body morph sliders, color preset application, avatar definition save/load. The avatar editor UI is also scriptable (open/close/save).

**Asset Interactions:** UniTask vendored internally -- will conflict with standalone Cysharp UniTask in Sandbox. Cinemachine 3.x and Input System already in Sandbox. No asmdef conflicts expected since SDK uses its own `Genies.*` namespace throughout.

---

## ENTRY-303: Genies Art Forge SDK 1.12.0

**Date:** 2026-03-17 (GeniesTest Session 1)
**Source:** Genies Inc. (via Genies Developer Portal)
**Category:** AI Asset Generation (Editor Tool)
**Verdict:** Conditional
**Label:** --
**Path:** `Packages/com.genies.artforge-sdk.client/`

**What it is:** AI-powered 3D asset generation tool. 140 C# scripts. Editor-only tool for generating 3D models and textures using AI (keywords: "rodin", "openai"). Uses WorkOS OAuth for authentication (separate from Avatar SDK auth). Depends on glTFast 6.14.1 and FBX Exporter 5.1.5 for asset import/export. Includes history view, generation parameters UI, and asset preview.

**Architecture:**
- Editor-only tool (not runtime)
- WorkOS OAuth authentication (separate from Avatar SDK login)
- Uses Rodin AI backend for 3D generation
- glTF/FBX pipeline for asset import into Unity
- History tracking for generated assets

**Concerns:**
- Editor-only -- no runtime use
- Separate authentication from Avatar SDK
- AI generation quality and cost unknown without testing
- Partial eval -- not deeply tested in this session

**Project Relevance:**
- FearSteez: LOW -- character assets come from Genies Avatar SDK, not generated
- General: MEDIUM -- could be useful for quick prototyping props/environment pieces

**MCP Potential:** Low. Editor-only tool with OAuth flow that requires browser interaction.

---

## ENTRY-302: com.unity.charactercontroller 1.4.2 (Unity / Philippe St-Amand)

| Field | Value |
|-------|-------|
| **Asset** | com.unity.charactercontroller |
| **Publisher** | Unity (authored by Philippe St-Amand, creator of Kinematic Character Controller / Rival) |
| **Source** | Unity Registry Package |
| **Category** | Character Controller (ECS/DOTS Kinematic) |
| **Version** | 1.4.2 |
| **Session** | SpaceSucks Session 1 (2026-03-19) |
| **Verdict** | Approved |
| **Label** | Recommended |

**What It Does:** Pure ECS kinematic character controller for Unity DOTS. The character is a kinematic physics body that moves itself through collider casts and overlap resolution. Provides ground detection, slope handling, step detection, moving platform support, deferred impulses, and state save/restore for rollback. Camera-agnostic -- FP and TP implementations provided as importable samples only.

**Package:** `Library/PackageCache/com.unity.charactercontroller@*/`

**Scale:** 60 C# files (18 core, 28 samples, 14 tests), ~11,774 LOC, 2 asmdefs. Namespace: `Unity.CharacterController`.

**Architecture:** Pure ECS (`partial struct : ISystem`), all Burst-compiled, uses `IJobEntity` with `ScheduleParallel()`. No SystemBase or managed code in runtime. Hard dependency on `com.unity.physics` 1.3.15 and `com.unity.entities` 1.3.15.

**Key Components:**
- `KinematicCharacterProperties` (IComponentData) -- config: slope angle, collision iterations, mass, snap-to-ground, grounding toggles
- `KinematicCharacterBody` (IComponentData) -- state: `IsGrounded`, `RelativeVelocity`, `GroundingUp`, `GroundHit`, parent entity
- `KinematicCharacterHit` / `StatefulKinematicCharacterHit` (IBufferElementData) -- hit tracking with Enter/Stay/Exit states
- `KinematicCharacterDeferredImpulse` (IBufferElementData) -- deferred impulses to other bodies

**Key API:**
- Implement `IKinematicCharacterProcessor` interface with callbacks: `UpdateGroundingUp`, `CanCollideWithHit`, `IsGroundedOnHit`, `OnMovementHit`
- `CharacterControlUtilities`: `StandardGroundMove_Interpolated/Accelerated`, `StandardAirMove`, `StandardJump`, `SlerpCharacterUpTowardsDirection`, `ApplyDragToVelocity`
- Toggle `EvaluateGrounding` / `SnapToGround` at runtime to switch between grounded and floating states

**Gravity Direction:** `GroundingUp` is a per-entity `float3` on `KinematicCharacterBody`, recalculated every frame via `UpdateGroundingUp` callback. **Arbitrary gravity is fully supported** -- all grounding, slope detection, step handling use `GroundingUp` (appears 60+ times in core utilities). Wall/ceiling walking works by setting `GroundingUp` to surface normal.

**Zero-G Support:** No built-in zero-G mode, but architecture fully supports it. Disable `EvaluateGrounding` and `SnapToGround` for floating state. `StandardAirMove` requires a `movementPlaneUp` parameter, so true 6DOF needs custom velocity handling. The character always has a concept of "up" -- true spinning 6DOF requires bypassing grounding entirely.

**Samples:** "Standard Characters" -- FirstPerson (processor, view pitch, systems) and ThirdPerson (processor, orbit camera with obstruction). Prefabs included, no sample scenes.

**Concerns:**
- No built-in 6DOF floating mode -- must implement custom
- Ground snapping assumes single "down" direction -- mag-boot attachment needs custom surface detection logic
- `KinematicCharacterAspect` deprecated in Unity 6000.5+ -- use `KinematicCharacterDataAccess` instead
- Moving platforms require `TrackedTransform` component on the platform
- Tightly coupled to `com.unity.physics` -- cannot use without it

**Overlap Analysis:**
- **vs Opsive UCC (ENTRY-165):** Not comparable. UCC is MonoBehaviour, no Burst/Jobs, 58K LOC. This is pure ECS, Burst-compiled, ~12K LOC. UCC has richer built-in abilities (39+) but fights ECS architecture.
- **vs Kinematic Character Controller (Asset Store, same author):** KCC is the MonoBehaviour version. Same author, same design philosophy, different architecture. KCC is mature (v3.4.4, last updated 2022) but MonoBehaviour-only.
- **vs Unity CharacterController (built-in):** Built-in is PhysX-based, no ECS, no custom gravity. This replaces it entirely for DOTS projects.

**Verdict Rationale:** Approved with **Recommended** label. This is the correct character controller foundation for any ECS/DOTS project. Same author as the Asset Store KCC (proven design), pure Burst/Jobs architecture, arbitrary gravity direction support via `GroundingUp`. For SpaceSucks specifically, the per-entity per-frame gravity direction is exactly what mag boots need, and the ability to toggle grounding evaluation enables clean grounded/floating state switching. The main work is implementing custom zero-G movement and mag-boot attachment logic on top of this foundation.

**SpaceSucks Relevance:** CRITICAL. Foundation character controller for the project. Replaces Opsive UCC.

**Other 3D Project Relevance:** HIGH for any ECS/DOTS title. Not applicable to MonoBehaviour projects (use KCC Asset Store version instead).

**TecVooDoo Utilities Candidate:** No -- this is a Unity first-party package, not redistributable.
**TecVooDoo Games Candidate:** No -- same reason.
**MCP Candidate:** Low -- ECS components are not standard MonoBehaviours. The existing MCP `component-add/modify` tools work with MonoBehaviour components. ECS entity configuration would need `script-execute` or custom tooling.

---

## ENTRY-303: KINERACTIVE 1.11 (Clean Shirt Labs)

| Field | Value |
|-------|-------|
| **Asset** | KINERACTIVE |
| **Publisher** | Clean Shirt Labs |
| **Source** | Asset Store |
| **Category** | Scripting (IK Interaction System) |
| **Version** | 1.11 |
| **Session** | SpaceSucks Session 1 (2026-03-19) |
| **Verdict** | Approved |
| **Label** | -- |

**What It Does:** First-person IK-based physical interaction system. Player looks at interactable objects (buttons, switches, levers, dials, sliders, wheels) and presses input to reach out with IK-driven hands and physically interact. Uses Unity's built-in `OnAnimatorIK()` -- does NOT depend on Final IK.

**Package:** `Assets/KINERACTIVE/`

**Scale:** 51 C# files (37 runtime, 14 editor). Namespace: `Kineractive`. No asmdefs.

**Interaction Types:**
- `ButtonTouchable` -- press/toggle buttons with In/Out/Pressed states
- `Rotator` -- discrete rotation steps (on/off switches, door hinges)
- `Mover` -- discrete linear position steps (levers)
- `MoverAnalog` -- continuous linear movement with min/max
- `RotatorAnalog` -- continuous rotation with min/max (dials, wheels, valves)
- `ItemGrabber` -- grab/drop/throw physics objects
- Prefab models: Button Box, Cover Hinge, Rotary Dial Box, Slider Box, Switch Box, Wheel

**Architecture:** MonoBehaviour with `Singleton<T>` manager pattern. Raycast-based detection (configurable rate, distance, layer mask). `InputHandler` component bridges detection to `KineractiveInput` subclasses (ButtonInput, KeycodeInput, AxisInput, AnalogInput, SelfActivatedInput). All Touchable subclasses fire UnityEvents for wiring to game systems.

**Dependencies:** Zero external dependencies. Uses only Unity built-in IK, legacy Input Manager, UnityEngine.UI.

**Zero-G Assessment:** The interaction core (touchables, IK targeting, input) is gravity-agnostic -- all transform-based. The bundled FPS controller (`Player_Gravity.cs`, `Player_Movement.cs`) applies hardcoded downward gravity and uses CharacterController -- must be ignored in SpaceSucks. `Repositioner.cs` only lerps X/Z (ignores Y) -- needs fix for zero-G approach from any angle.

**Concerns:**
- No asmdefs -- compiles in Assembly-CSharp
- Uses legacy Input Manager exclusively -- no New Input System support
- `ItemGrabber` hardcodes `useGravity = true` on drop -- breaks zero-G
- Single shared AudioSource on manager limits simultaneous interaction sounds
- Bundled FPS controller is demo-quality, not production-ready

**Overlap Analysis:**
- **vs GrabMaster (ENTRY-239):** Overlaps on object grab/throw. KINERACTIVE's ItemGrabber is simpler; GrabMaster's grab system is more physics-complete (charge throw, rotation, sockets). Use GrabMaster for physics grab, KINERACTIVE for IK switch/lever/button interactions.
- **vs Final IK + KINERACTIVE (ENTRY-153):** KINERACTIVE has its own IK via `OnAnimatorIK`. Final IK is not required. If both are installed, they can conflict on IK targets.

**Verdict Rationale:** Approved with no special label. The touchable/input/IK interaction layer is solid and directly useful for any game with physical controls (buttons, switches, levers, dials). The UnityEvent-based API is designer-friendly. For SpaceSucks specifically, space station controls (gravity generators, airlock switches, system panels) map directly to KINERACTIVE's interaction model. The bundled FPS controller should be ignored.

**SpaceSucks Relevance:** HIGH. Space station switches, levers, doors, gravity generator controls, airlock panels.
**Other Project Relevance:** HIGH for any FP game with environmental interactions (horror, sim, puzzle).

**TecVooDoo Utilities Candidate:** No -- too large and too specific (interaction system, not a utility).
**TecVooDoo Games Candidate:** Potential. The Touchable hierarchy + InputHandler + IK layer could be extracted as a reusable interaction module with asmdef isolation and New Input System support added. Would need: asmdef, New Input System adapter, zero-G compatible Repositioner, fix ItemGrabber gravity restore.
**MCP Candidate:** Medium. Components are standard MonoBehaviours -- `component-add/modify` works for Touchables and InputHandlers. Main value would be batch setup tools (create interactive objects with proper InputHandler + KineractiveInput + Touchable chains + IK target positioning).

---

## ENTRY-304: customized objects gravity 1.0 (YAHYABK)

| Field | Value |
|-------|-------|
| **Asset** | customized objects gravity |
| **Publisher** | YAHYABK |
| **Source** | Asset Store (free) |
| **Category** | Scripting (Surface Gravity) |
| **Version** | 1.0 |
| **Session** | SpaceSucks Session 1 (2026-03-19) |
| **Verdict** | Rejected |
| **Label** | Don't Use |

**What It Does:** Single 60-line MonoBehaviour that attracts objects toward the nearest surface. Every 5 physics frames, calls `Physics.OverlapSphere()` to find nearby colliders, raycasts to the closest point, and applies `ConstantForce` in the opposite direction of the surface normal.

**Package:** `Assets/cusomized objects gravity/` (publisher typo in folder name)

**Scale:** 1 C# file (~60 lines), no namespace, no asmdef. 4 demo meshes, 1 demo scene.

**Concerns:**
- Single script, no architecture, no events, no API surface
- Hobbyist-quality code (no comments, hardcoded magic numbers, typo in folder name)
- Only supports "attract to nearest surface" -- no gravity zones, directional gravity, zero-G regions, or per-area configuration
- No character controller integration (uses `ConstantForce`, not character motor gravity)
- No transition logic between gravity zones
- `OverlapSphere` every 5 frames is crude and won't scale
- Free but adds zero value over Heathen Unity Physics (ENTRY-209) which is already installed

**Overlap Analysis:**
- **vs Heathen Unity Physics 2026 (ENTRY-209):** Completely superseded. Heathen provides `GravityEffect` (per-object gravity override including zero-G), `ForceEffectField` + `ForceEffectReceiver` (configurable force zones with shapes, strengths, curves), and `AttractEffect` (magnetic pull). All MCP-controllable. Professional architecture (62 scripts, 4 asmdefs, clean namespace).

**Verdict Rationale:** Rejected with **Don't Use** label. Entirely redundant with ENTRY-209 (Heathen Unity Physics 2026), which is already installed in SpaceSucks and provides every feature this asset has plus vastly more. Remove from project.

**SpaceSucks Relevance:** NONE. Use Heathen Unity Physics instead.

**TecVooDoo Candidates:** No (all three). Superseded by existing asset.

---

## ENTRY-305: Camera System 1.6.4 (Gaskellgames)

| Field | Value |
|-------|-------|
| **Asset** | Camera System |
| **Publisher** | Gaskellgames |
| **Source** | Asset Store |
| **Category** | Scripting (Camera) |
| **Version** | 1.6.4 |
| **Session** | SpaceSucks Session 1 (2026-03-19) |
| **Verdict** | Rejected |
| **Label** | Don't Use |

**What It Does:** MonoBehaviour-based camera system with follow, freelook orbit, free-fly, multi-target, and trigger zone switching modes. CameraBrain manages active camera with blend styles (cut, fade, lerp).

**Package:** `Assets/Gaskellgames/CameraSystem/`

**Scale:** 26 C# files (11 runtime, 8 editor). Namespace: `Gaskellgames.CameraSystem`. 1 asmdef with GUID refs to GgCore + InputEventSystem.

**Critical Issue: Non-functional.** Entire codebase wrapped in `#if GASKELLGAMES` and `#if GASKELLGAMES_INPUTEVENTSYSTEM` preprocessor guards. Both required dependencies (GgCore, Input Event System -- separate free Gaskellgames packages) are not installed. All scripts compile to nothing. The package is dead code.

**Missing Features for SpaceSucks:**
- No first-person camera mode (free-fly is detached spectator, not head-mounted)
- No 2.5D camera mode
- No zero-G orientation support (orbit system assumes fixed world-up)
- FreeLook clamps rotation based on fixed height/radius ratios

**Overlap with Cinemachine:** Near-total. CameraBrain ≈ CinemachineBrain, CameraRig ≈ CinemachineCamera, FreelookRig ≈ OrbitalFollow, CameraSwitcher ≈ Priority system, CameraTriggerZone ≈ CinemachineVolume, CameraShaker ≈ CinemachineImpulse, multi-target ≈ CinemachineTargetGroup. Cinemachine also provides: noise profiles, impulse channels, dolly tracks, state-driven cameras, `CinemachineExtension` base class for custom logic (e.g., zero-G up-vector recalculation).

**Verdict Rationale:** Rejected with **Don't Use** label. Non-functional without two additional Gaskellgames package installs. Even if functional, it is a less capable subset of Cinemachine (already installed) with no zero-G support, no FP mode, no 2.5D mode. Use Cinemachine with custom extensions for SpaceSucks camera needs. Remove from project.

**SpaceSucks Relevance:** NONE.

**TecVooDoo Candidates:** No (all three). Redundant with Cinemachine.

---

## ENTRY-306: ECS N-Body Orbit Simulation 1.0.0 (Parallel Cascades)

| Field | Value |
|-------|-------|
| **Asset** | ECS N-Body Orbit Simulation |
| **Publisher** | Parallel Cascades |
| **Source** | Asset Store |
| **Category** | Scripting (ECS Physics Simulation) |
| **Version** | 1.0.0 |
| **Session** | SpaceSucks Session 1 (2026-03-19) |
| **Verdict** | Conditional |
| **Label** | -- |

**What It Does:** Working N-body gravitational simulation built on Unity DOTS. Computes gravitational attraction between all bodies each physics tick, applies velocity changes, handles collisions (smaller body destroyed with momentum transfer), includes VFX explosions, orbit path preview, procedural planet shaders, and a procedural space skybox.

**Package:** `Assets/ParallelCascades/ECSNBodySimulation/` + `Common/` + `ProceduralShaders/` + `ProceduralSpaceSkybox/`

**Scale:** 36 C# files, 6 asmdefs. Namespaces: `ParallelCascades.ECSNBodySimulation.Runtime.*`, `ParallelCascades.Common.Runtime`.

**Architecture:** Pure ECS (`partial struct : ISystem`), all Burst-compiled, uses `IJobEntity` with `ScheduleParallel`. Built on Unity Physics -- uses `PhysicsVelocity` and `PhysicsMass` for integration. O(N^2) brute-force gravity calculation (no Barnes-Hut or spatial partitioning).

**Key Components:**
- `NBodyEntity` -- tag marking participation in N-body sim
- `NBodyDoNotReceiveGravityTag` -- entity exerts gravity but is unaffected (static attractors)
- `NBodyDoNotContributeToGravityTag` -- entity affected by gravity but does not exert it (small satellites)
- `NBodySimulationSettingsSingleton` -- GravitationalConstant, FixedDeltaTime, SimulationBounds
- `SatelliteSpawnerData` -- mass spawning config with Poisson-disk-like placement

**Key Systems:**
- `NBodyGravitySystem` -- core gravity: all-pairs force accumulation, velocity delta application
- `NBodyTriggerCollisionSystem` -- collision handling with momentum transfer
- `NBodyOutOfBoundsSystem` -- soft boundary containment
- `SpawnSatellitesOnInitializeSystem` -- batch entity spawning
- `VFXSystem` -- ECS-to-VFX Graph bridge via GraphicsBuffers

**Scale Limits:** O(N^2) brute force. Excellent <100 bodies, fine 100-500 with Burst, bottlenecks at 1000+. No spatial optimization.

**Extractable Patterns (cherry-pick value):**
1. `VFXManager<T>` / `VFXManagerParented<T>` -- generic ECS-to-VFX Graph bridge via GraphicsBuffers. Not N-body-specific. Reusable for any ECS game needing particle effects.
2. Force accumulation job pattern (collect entities into arrays, iterate, accumulate, apply velocity deltas)
3. Tag-based asymmetric interaction filtering (`DoNotReceive`/`DoNotContribute`)
4. Singleton settings pattern with authoring component + baker
5. Best-candidate spatial distribution algorithm for entity placement
6. Out-of-bounds soft containment system

**Concerns:**
- V1.0.0, single release (Oct 2025), no iteration history
- Self-identity check uses position equality instead of entity index (fragile)
- No repulsion support -- forces are strictly attractive
- No force falloff curve control (inverse-square only)
- No force caps -- extreme forces at close range
- No damping/drag built in
- Primarily a learning resource, not production-ready for gameplay

**Verdict Rationale:** Conditional. Well-structured educational asset demonstrating solid DOTS patterns (proper ISystem, Burst, Jobs, EntityCommandBuffer usage). The N-body simulation itself is unlikely to be used directly in SpaceSucks, but the **cherry-pick patterns are genuinely valuable**: the VFX bridge, force accumulation job, tag-based filtering, and out-of-bounds containment are all reusable in any ECS game. Worth keeping installed as a reference implementation.

**SpaceSucks Relevance:** LOW-MEDIUM. The gravity simulation is not what SpaceSucks needs (it needs localized force zones, not universal gravitational attraction). However, the DOTS architectural patterns are directly applicable -- this is the best ECS reference code in the project. The VFX bridge pattern is HIGH value for ECS-driven dust particle effects.

**TecVooDoo Utilities Candidate:** No -- too domain-specific.
**TecVooDoo Games Candidate:** Potential cherry-picks: VFXManager<T> (ECS-to-VFX bridge), force accumulation job template, out-of-bounds containment system. These are generic ECS gameplay patterns, not N-body-specific.
**MCP Candidate:** Low. Self-contained simulation with no editor tooling API surface. Existing MCP tools could modify authoring components but there is nothing N-body-specific to expose.

---

## MCP Candidates

Tracks assets evaluated for MCP tool potential. "Not listed" means not yet evaluated for MCP use.

**Status values:**
- **Built** -- MCP tools exist (see ENTRY-267 for custom tool set)
- **Evaluated** -- MCP controllability assessed, rated (no custom tools built)
- **Candidate** -- Identified as good MCP candidate, tools not yet built
- **No** -- Evaluated, decided against (reason in Notes)

**Cross-reference:** Full Audio MCP eval details in `Archives/AudioProject/Audio_AssetLog.md` (MCP-EVAL-001 through MCP-EVAL-011). Sandbox MCP evals in ENTRY-267 and ENTRY-272. All new MCP evals go in this document.

### Custom Tools Built

| Asset | ENTRY | Status | Notes |
|-------|-------|--------|-------|
| ProWorldBuilder (PWB) | ENTRY-024 | Built | Tools in ENTRY-267 |
| Final IK | ENTRY-014 | Built | Tools in ENTRY-267 |
| Animancer Pro | ENTRY-012 | Built | Built-in MCP extension (Kybernetik) |
| ProBuilder | -- | Built | Built-in MCP extension (Unity) |
| ParticleSystem | -- | Built | Built-in MCP extension (Unity) -- MinMaxCurve bug, use *Multiplier companions |
| Flexalon Pro | ENTRY-226 | Built | Tools in ENTRY-267 |
| RayFire 2 | ENTRY-168 | Built | Tools in ENTRY-267 -- DemolishForced/ApplyDamage crash from MCP context |
| MagicaCloth 2 | ENTRY-095 | Built | Tools in ENTRY-267 |
| Asset Inventory 4 | ENTRY-252 | Built | Tools in ENTRY-267 |
| Malbers Animal Controller | ENTRY-028 | Built | 8 tools: query, state, mode, speed, stat, damageable, lock-axis |
| Malbers Quest Forge | ENTRY-297 | Built | 5 tools: quest CRUD, objectives, POI management |
| Retarget Pro | ENTRY-243 | Built | 4 tools: batch-bake, create-profile, query-profiles |
| Rope Toolkit | ENTRY-271 | Built | 5 tools: query, simulation, collision, appearance, connection. `#if HAS_ROPE_TOOLKIT` |
| Heathen Unity Physics 2026 | ENTRY-272 | Built | 5 tools: query, physics-data, buoyancy, force-field, force-receiver. `MCPTools.HeathenPhysics.Editor` |
| Heathen Ballistics 2026 | ENTRY-208 | Built | 5 tools: query, aim, trickshot, calculate-solution, visualize. `MCPTools.HeathenBallistics.Editor` |
| Feel | ENTRY-241 | Built | 4 tools: query, configure-player, add-feedback, play. `#if HAS_FEEL` |
| Damage Numbers Pro | ENTRY-235 | Built | 4 tools: query, display, animation, performance. `MCPTools.DamageNumbersPro.Editor` |
| Cinemachine 3.1.6 | ENTRY-176 | Built | 5 tools: cm-query, cm-configure-camera, cm-configure-follow, cm-configure-noise, cm-configure-brain. `MCPTools.Cinemachine.Editor` |
| Animation Rigging 1.4.1 | -- | Built | 5 tools: rig-query, rig-configure-twoboneik, rig-configure-aim, rig-configure-weights. `MCPTools.AnimationRigging.Editor` |
| ALINE | -- | Built | 4 tools: aline-draw-line, aline-draw-sphere, aline-draw-box, aline-label. `MCPTools.ALINE.Editor` |

### MCP Controllability Evaluated -- Audio (AudioProject Sessions 6 + 8)

| Asset | MCP-EVAL | Rating | Key API Pattern | Notes |
|-------|----------|--------|-----------------|-------|
| PATWA (ENTRY-282) | MCP-EVAL-001 | Exceptionally High | Singleton `MusicDirector.Instance`, 22 tools across 6 tiers | Purpose-built for MCP |
| Master Audio 2024 (ENTRY-103) | MCP-EVAL-002 | High | 258 static methods on `MasterAudio` class | Pure static API, string-based IDs |
| Koreographer Professional (ENTRY-101) | MCP-EVAL-003 | High | Singleton `Koreographer.Instance` | Sample-accurate timing, event registration |
| Procedural Music Generator (ENTRY-275) | MCP-EVAL-004 | High | Singleton `MusicGenerator`, 40+ properties | Real-time key/scale/mode/tempo changes |
| Maestro MIDI (ENTRY-276) | MCP-EVAL-005 | High | Component-based `MidiFilePlayer`/`MidiStreamPlayer` | 16-channel control, real-time MIDI injection |
| DryWetMIDI (ENTRY-115) | MCP-EVAL-006 | High | Library classes, fluent `PatternBuilder` | Full MIDI manipulation, event callbacks |
| Bro Audio (ENTRY-274) | MCP-EVAL-007 | High | 49 static methods on `BroAudio` class | Cleanest static API of all audio assets |
| FMOD Studio (ENTRY-113) | MCP-EVAL-008 | High | 62+ static methods on `RuntimeManager` | Dual high/low-level API, VCA routing |
| Chunity (ENTRY-112) | MCP-EVAL-009 | High | 143 methods on `Chuck` class | Real-time audio code execution via MCP |
| UI Toolkit Sound Effects (ENTRY-125) | MCP-EVAL-010 | Medium | ScriptableObject-based + static pool | Inspector-first design, monitoring use |
| Native Audio (ENTRY-105) | MCP-EVAL-011 | Medium | 16 static methods on `NativeAudio` | iOS/Android only, not usable in Editor |
| Audio Preview Tool | -- | Deferred | -- | Editor QoL, low priority |

### MCP Controllability Evaluated -- Sandbox (Session 56)

| Asset | ENTRY | Rating | Notes |
|-------|-------|--------|-------|
| Rope Toolkit | ENTRY-271 | Built | Full control via script-execute; component-get crashes (NativeArray). **Built Session 2 -- 5 tools.** |
| Unity Physics 2026 | ENTRY-272 | Built | All 4 components fully MCP-controllable via standard pipeline. **Built Session 2 -- 5 tools.** |
| Verlet Motion 2026 | ENTRY-272 | Partial | VerletTransforms works; VerletLine crashes serializer (NativeArray) |
| FS Grappling Hook | ENTRY-272 | Low | Components add/read/modify fine but useless without Fantacode full stack |
| FS Rope Swinging | ENTRY-272 | Low | Same -- requires full Fantacode stack |
| Retarget Pro | ENTRY-243 | Built | **Re-evaluated Session 58.** 4 tools: batch-bake, create-profile, query-profiles. Profile creation now scriptable; batch bake fills workflow gap (no batch UI). Key use: polyperfect-to-AC animation retargeting. |

### MCP Controllability Evaluated -- Malbers Ecosystem (Session 58)

| Asset | ENTRY | Rating | Key API Pattern | Notes |
|-------|-------|--------|-----------------|-------|
| Malbers Animal Controller (AC) | ENTRY-028 | High | `MAnimal` partial class, 100+ public methods, ScriptableObject IDs | **BUILT** -- 8 tools in `MCPTools.MalbersAC.Editor`. State/Mode/Stance/Speed/Stats/Damageable/LockAxis configuration. |
| Poly Art: Raccoon (AC) | ENTRY-031 | High | Same as AC -- raccoon is an AC character | Covered by AC tools. |
| Horse Animset Pro | ENTRY-032 | High | AC superset + riding system | Covered by AC tools. |
| Ultimate Selector | ENTRY-029 | Medium | `SelectorController.SelectNextItem()`, `MItem` SOs | Simple API, mainly UI -- not worth custom tools. |
| Malbers Inventory System | ENTRY-001 | Medium | Integrates with AC Stats | Covered by AC stats tools. |
| Low Poly Animated Animals | ENTRY-036 | Low | 3 public methods on `Common_WanderScript` | Spawn + configure via component-modify. No custom tools needed. |
| Drake the Dragonkin | ENTRY-294 | High | AC character -- full AC API | Covered by AC tools. |
| Undead Horse & Knight | ENTRY-295 | High | AC character -- full AC API | Covered by AC tools. |
| Cowboy | ENTRY-296 | N/A | Art asset only | No scriptable components. |
| Malbers Quest Forge | ENTRY-297 | Medium-High | `QuestManager` singleton, SO quest defs, `QuestEventBus` | **BUILT** -- 5 tools in `QuestForge/Editor/`. Quest/Objective/POI creation and querying. |

**Malbers AC MCP Tools (Built Session 58):** 8 tools: `ac-query-animal`, `ac-query-stats`, `ac-configure-state`, `ac-configure-mode`, `ac-configure-speed`, `ac-configure-stat`, `ac-configure-damageable`, `ac-add-lock-axis`. Asmdef pattern with `HAS_MALBERS_AC` define.

**Quest Forge MCP Tools (Built Session 58):** 5 tools: `qf-create-quest`, `qf-query-quests`, `qf-add-objective`, `qf-create-poi`, `qf-query-pois`. `#if HAS_MALBERS_QUESTFORGE` guards (no asmdef, Assembly-CSharp).

### MCP Controllability Evaluated -- Sandbox Session 2 (Mar 20, 2026)

New tools built from Sandbox installed assets. Rope Toolkit and Heathen Physics were evaluated in Session 56; Ballistics, Feel, and DNP are newly assessed.

| Asset | ENTRY | Rating | Key API Pattern | Notes |
|-------|-------|--------|-----------------|-------|
| Heathen Ballistics 2026 | ENTRY-208 | High | `BallisticAim`, `TrickShot`, `BallisticPathLineRender` components + static `Ballistics.Solution()` | Clean dual-mode design: `BallisticAim` for turrets, `TrickShot` for bounce projectiles. Static solver is pure math -- usable in Editor. **BUILT -- 5 tools.** |
| Feel | ENTRY-241 | High | `MMF_Player` component, polymorphic `MMF_Feedback` list via `[SerializeReference]` | 82 feedback types, all addable programmatically via reflection on type name. `MoreMountains.Tools` assembly (via .asmref). `feel-add-feedback` uses `System.Activator.CreateInstance` to support any type string. **BUILT -- 4 tools.** |
| Damage Numbers Pro | ENTRY-235 | High | `DamageNumber` (abstract) → `DamageNumberMesh` (3D) / `DamageNumberGUI` (UI). `DamageNumbersPro` asmdef | All key properties public/serialized: lifetime, fade timing/offsets, movement mode, pooling, spam control. `SetColor()` convenience method. **BUILT -- 4 tools.** |

**Rope Toolkit MCP Tools (Built Session 2):** 5 tools: `rope-query`, `rope-configure-simulation`, `rope-configure-collision`, `rope-configure-appearance`, `rope-add-connection`. `#if HAS_ROPE_TOOLKIT` guards, `Rope.simulation` and `Rope.collisions` are structs (read-modify-write pattern).

**Heathen Physics MCP Tools (Built Session 2):** 5 tools: `hphys-query`, `hphys-configure-physics-data`, `hphys-configure-buoyancy`, `hphys-configure-force-field`, `hphys-configure-force-receiver`. `MCPTools.HeathenPhysics.Editor` asmdef, `defineConstraints: HAS_HEATHEN_PHYSICS`.

**Heathen Ballistics MCP Tools (Built Session 2):** 5 tools: `ballistic-query`, `ballistic-configure-aim`, `ballistic-configure-trickshot`, `ballistic-calculate-solution`, `ballistic-visualize`. `MCPTools.HeathenBallistics.Editor` asmdef, `defineConstraints: HAS_HEATHEN_BALLISTICS`.

**Feel MCP Tools (Built Session 2):** 4 tools: `feel-query`, `feel-configure-player`, `feel-add-feedback`, `feel-play`. `#if HAS_FEEL` guards. Detection: `MoreMountains.Feedbacks.MMF_Player, MoreMountains.Tools`.

**Damage Numbers Pro MCP Tools (Built Session 2):** 4 tools: `dnp-query`, `dnp-configure-display`, `dnp-configure-animation`, `dnp-configure-performance`. `MCPTools.DamageNumbersPro.Editor` asmdef, `defineConstraints: HAS_DAMAGE_NUMBERS_PRO`.

### MCP Controllability Evaluated -- Sandbox Installed Asset Scan (Session 2, Mar 20, 2026)

Full scan of remaining installed Sandbox assets not previously evaluated for MCP candidacy.

| Asset | ENTRY | Rating | Key API Pattern | Notes |
|-------|-------|--------|-----------------|-------|
| Cinemachine 3.1.6 | ENTRY-176 | **Built** | `CinemachineCamera`, `CinemachineFollow`, `CinemachinePositionComposer`, `CinemachineBasicMultiChannelPerlin` components. `Unity.Cinemachine` namespace, Unity package | 5 tools built Session 3: cm-query, cm-configure-camera, cm-configure-follow, cm-configure-noise, cm-configure-brain. |
| Animation Rigging 1.4.1 | -- | **Built** | `TwoBoneIKConstraint`, `MultiAimConstraint`, `MultiParentConstraint`. `UnityEngine.Animations.Rigging` namespace, Unity package | 5 tools built Session 3: rig-query, rig-configure-twoboneik, rig-configure-aim, rig-configure-weights. |
| ALINE | -- | **Built** | `Drawing.Draw` static API, `Drawing.CommandBuilder`. `com.arongranberg.aline` package | 4 tools built Session 3: aline-draw-line, aline-draw-sphere, aline-draw-box, aline-label. Persist via `Draw.WithDuration(N)`. |
| Boing Kit 1.2.47 | ENTRY-260 | Medium | `BoingKit.BoingBones`, `BoingKit.BoingEffector`, `BoingKit.BoingReactorField`. `BoingKit` namespace | Component-based spring physics. BoingBones: lengthStiffness, poseStiffness, collisionRadius, squash/stretch, bendAngleCap. BoingEffector: radius, linearImpulse, angularImpulse, maxImpulseSpeed. Many tunable props but secondary system -- setup usually done once in Inspector. Medium priority. |
| AI Navigation 2.0.12 | -- | Medium | `NavMeshSurface`, `NavMeshModifier`, `NavMeshLink`. `Unity.AI.Navigation` namespace, Unity package | Baking is editor-time (requires filesystem). NavMeshAgent is built-in runtime. NavMeshSurface has clean properties (layerMask, collectObjects, size, useGeometry, defaultArea) but limited runtime value. Best path: `script-execute` for bake triggering. |
| EasyPooling v2025 | -- | Medium | `GUPS.EasyPooling.GlobalPool`, `AGamePool<T>`, `BlueprintPoolDefinition`. `GUPS.EasyPooling` namespace | Method-driven API (Spawn/Despawn). Pool configuration via BlueprintPoolDefinitions (SOs). Not property-dense enough for dedicated MCP tools -- `script-execute` covers the use cases. |
| Toolkit for UX 2026 (Heathen) | -- | Medium | `Heathen.UX.ButtonCursorState`, `CursorAnimator`, `CommandDirector`, `DragItem`, `DropContainer` | Event-driven, UnityEvent-heavy. Cursor state, drag thresholds, drop targets. UI-focused; most config is Inspector-only callbacks. `component-modify` via standard MCP tools covers it. |
| Master Audio 2024 | ENTRY-103 | Medium | `DarkTonic.MasterAudio.MasterAudio` static singleton, 258 methods | Previously rated High in audio eval (MCP-EVAL-002). Revisited: runtime config (volume, mute, pitch) useful but most bus/mixer setup is editor-time. `script-execute` adequate. Audio-specific tools may be better placed in AudioProject context. |
| 3D Object Image for UI Toolkit | -- | Low | `Kamgam.UIToolkitWorldImage.WorldObjectRenderer`, `WorldObjectCamera`, `WorldImage` | Display component -- renders world objects to texture for UI. Setup is hierarchical (AddWorldObject list). Limited numeric config. `component-add/modify` via standard tools is sufficient. |

---

### MCP Controllability Evaluated -- SpaceSucks (Session 1)

| Asset | ENTRY | Rating | Notes |
|-------|-------|--------|-------|
| com.unity.charactercontroller | ENTRY-302 | Low | ECS components, not MonoBehaviour. Needs `script-execute` or custom tooling. |
| KINERACTIVE | ENTRY-303 | Medium | Standard MonoBehaviour components. Batch setup tools would add value. |
| customized objects gravity | ENTRY-304 | N/A | Rejected -- superseded by ENTRY-209. |
| Camera System Gaskellgames | ENTRY-305 | N/A | Rejected -- non-functional, use Cinemachine. |
| GrabMaster | ENTRY-239 | Medium | Standard MonoBehaviour components. `component-add/modify` works for GrabbableObject setup. |
| SensorToolkit 2 | ENTRY-231 | Medium-High | Clean component model maps 1:1 to `component-add/modify`. SignalProcessor chain also MCP-configurable. |
| ECS N-Body Orbit Sim | ENTRY-306 | Low | Self-contained sim, no editor API surface. Authoring components modifiable via standard tools. |

### AI-Friendliness Evaluated -- VNPC (Session 1)

AI-Friendliness assessments from VNPC project. These rate how well Claude can work with each asset's API (code generation, scripting).

| Asset | ENTRY | Rating | Key API Pattern | Notes |
|-------|-------|--------|-----------------|-------|
| Adventure Creator | ENTRY-251 | High | Static `KickStarter.*` class, `EventManager` 100+ hooks | Full C# API, ActionLists creatable dynamically |
| Dialogue System for Unity | ENTRY-214 | Excellent | `DialogueManager` static class, `Template` for DB building | Complete databases buildable programmatically, zero GUI needed |
| Ink Integration | ENTRY-281 | Excellent | Pure plain-text .ink files, 4 core concepts | Most AI-writable format possible, auto-compiles in Unity |
| Naninovel | ENTRY-273 | Excellent | Plain-text .nani scripts, `Engine.GetService<T>()` | Custom commands via C# derive from `Command`, auto-discovered |
| Text Animator | ENTRY-117 | Excellent | Tag-in-string (`<shake>`, `<wave>`, `<bounce>`) | Zero additional code needed, just embed tags in dialogue strings |

---

> **Going forward:** All MCP controllability evals, AI-friendliness assessments, and asset evals happen in Sandbox and are logged in this document -- regardless of which project triggered the need.

---

## TecVooDoo Games Candidates

Tracks game systems identified as candidates for `com.tecvoodoo.games`. "Not listed" means not evaluated as a games candidate. Current package contents: SimpleBoids, BulletHoleSpawner, ProcessorChain, CharacterStateMachine/Transition.

**Status values:**
- **Added** -- Already in TecVooDoo Games
- **Pending** -- Identified candidate, not yet added
- **No** -- Evaluated, decided against

| System | Source | Est. Size | Status | Notes |
|--------|--------|-----------|--------|-------|
| SimpleBoids | Session 34 | ~200 lines | Added | In TVG v1.2.0 Simulation module |
| BulletHoleSpawner | -- | -- | Added | In TVG v1.2.0 Pooling module |
| ProcessorChain | -- | -- | Added | In TVG v1.2.0 Processing module |
| CharacterStateMachine / Transition | -- | -- | Added | In TVG v1.2.0 StateMachine module |
| KINERACTIVE Touchable layer | ENTRY-303 | ~20 scripts | Pending | IK interaction system (buttons, switches, levers, dials). Needs: asmdef, New Input System adapter, zero-G Repositioner fix, gravity restore fix on ItemGrabber. |
| GrabMaster socket/puzzle system | ENTRY-239 | ~8 scripts | Pending | SocketType SO matching, PuzzleSocketGroup coordination, SocketEjector. Clean architecture. Needs: asmdef, zero-G gravity restore fix. |
| GrabMaster AudioClipSettings pattern | ENTRY-239 | ~3 scripts | Pending | AudioClipSettings SO + AudioEventPlayer + ImpactSound. Randomized volume/pitch per clip. Cherry-pick candidate for TVU Audio module. |
| ECS VFXManager<T> bridge | ENTRY-306 | ~2 scripts | Pending | Generic ECS-to-VFX Graph bridge via GraphicsBuffers. Reusable for any ECS game needing particle effects from entities. Cherry-pick from N-Body. |
| ECS force accumulation job template | ENTRY-306 | ~1 script | Pending | Job pattern: collect entities, iterate pairs, accumulate forces, apply velocity deltas. Template for any ECS force system. |
| ECS out-of-bounds containment | ENTRY-306 | ~1 script | Pending | Soft boundary system pushing escaped entities back toward center. Reusable for any ECS game. |

---

## TecVooDoo Utilities Candidates

Tracks utilities identified as candidates for `com.tecvoodoo.utilities`. "Not listed" means not evaluated as a utilities candidate. See `TVU_Status.md` for the add process and current package contents.

**Status values:**
- **Added** -- Already in TecVooDoo Utilities
- **Pending** -- Identified candidate, not yet added
- **No** -- Evaluated, decided against

| Utility | Source | Est. Size | Status | Notes |
|---------|--------|-----------|--------|-------|
| SimpleBoids | Session 34 (NVJOB Boids cherry-pick) | ~200 lines | Added | In TVU v1.0.0 Gameplay module |
| CategoryLogger | Session 34 | ~60 lines | Added | In TVU v1.0.0 Logging module |
| InRangeOf, Quantize, Transform resets, DestroyChildren, HierarchyPath, ToVector2XY/XZ, RoundToInt, SetLayerRecursively, ToHexRGB, TryFromHex | Session 35 retroactive scan | ~15 lines | Pending | Tier 1 -- small, zero-dep, high reuse |
| SlowMotion, CameraShake | Session 35 retroactive scan | ~55 lines | Pending | Tier 2 -- useful but slightly higher complexity |
| GridSystem, Observable\<T\>, EventBus\<T\> | Session 35 retroactive scan | ~440 lines | Pending | Tier 3 -- larger scope, evaluate individually |
| GrabMaster AudioClipSettings/AudioEventPlayer | ENTRY-239 (Session 59) | ~3 scripts | Pending | Randomized clip playback with SO-defined volume/pitch ranges. Good Audio utility candidate. |

---

**End of Document**
