# Sandbox - Asset Evaluation Log

**Purpose:** Track every asset, package, and technique evaluated in Sandbox. This is the primary document for the project.

**Last Updated:** February 12, 2026 (Session 29)

---

## How to Use This Document

Every asset tested in Sandbox gets an entry here. Entries are never deleted - failed evaluations are just as valuable as successful ones.

### Entry Lifecycle

1. **Add entry** when you start evaluating an asset (status: Testing)
2. **Update verdict** when evaluation is complete
3. **Add notes** about quirks, performance, integration cost
4. **Tag for HOK** if applicable to the active project

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

| # | Asset | Source | Category | Verdict | HOK? | Date |
|---|-------|--------|----------|---------|------|------|
| 001 | Malbers Inventory System | Asset Store | Other | Conditional | Maybe | 2026-02-06 |
| 002 | Procedural Generation Grid (FImpossible Creations) | Asset Store | Tools | Rejected (HOK) | Maybe | 2026-02-06 |
| 003 | vHierarchy 2 | Asset Store | Tools | Approved | Yes | 2026-02-06 |
| 004 | vFolders 2 | Asset Store | Tools | Approved | Yes | 2026-02-06 |
| 005 | vFavorites 2 | Asset Store | Tools | Approved | Yes | 2026-02-06 |
| 006 | Ultimate Preview Window - Pro Edition | Asset Store | Tools | Approved | Yes | 2026-02-06 |
| 007 | Unity Utility Library (Git Amend) | GitHub | Tools | Conditional | Yes | 2026-02-06 |
| 008 | Hierarchy Designer | Asset Store | Tools | Rejected | No | 2026-02-06 |
| 009 | Folder System (Gaskellgames) | Asset Store | Tools | Rejected | No | 2026-02-06 |
| 010 | Visual Console | Asset Store | Tools | Rejected | No | 2026-02-06 |
| 011 | Runtime Debugger Toolkit | Asset Store | Tools | Rejected | No | 2026-02-06 |
| 012 | Backbone Logger | Asset Store | Tools | Conditional | Maybe | 2026-02-06 |
| 013 | UDebug Panel | Asset Store | Tools | Approved - Default | Yes | 2026-02-06 |
| 014 | Code Monkey Toolkit | Asset Store | Tools | Conditional | Maybe | 2026-02-06 |
| 015 | Fullscreen Editor | Asset Store | Tools | Approved - Default | Yes | 2026-02-06 |
| 016 | Scripts Vault - Free | Asset Store | Tools | Rejected | No | 2026-02-06 |
| 017 | RNGNeeds - Probability Distribution | Asset Store | Tools | Conditional | Yes | 2026-02-06 |
| 018 | Scriptable Sheets | Asset Store | Tools | Approved - Default | Yes | 2026-02-06 |
| 019 | Improved Timers (Git Amend) | GitHub | Tools | Conditional | Yes | 2026-02-06 |
| 020 | Wingman | Asset Store | Tools | Approved - Default | Yes | 2026-02-07 |
| 021 | Init(args) | Asset Store | Tools | Rejected | No | 2026-02-07 |
| 022 | DevTrails | Asset Store | Tools | Conditional | Maybe | 2026-02-07 |
| 023 | Binding System 2 | Asset Store | Tools | Rejected | No | 2026-02-07 |
| 024 | Prefab World Builder | Asset Store | Tools | Conditional | Yes | 2026-02-07 |
| 025 | UniTask (Cysharp) | GitHub | Tools | Approved - Default | Yes | 2026-02-07 |
| 026 | UModeler X Plus | Asset Store | Tools | Approved - Default 3D | Yes | 2026-02-07 |
| 027 | DA PolyPaint - Atlas Color Mapper | Asset Store | Tools | Conditional | Yes | 2026-02-07 |
| 028 | Malbers Animal Controller (AC) | Asset Store | Animation | Approved | Yes | 2026-02-07 |
| 029 | Ultimate Selector | Asset Store | UI | Approved | Yes | 2026-02-07 |
| 030 | Fishing for Animal Controller | Asset Store | Other | Approved | Yes | 2026-02-07 |
| 031 | Poly Art: Raccoon | Asset Store | Animation | Approved | Yes | 2026-02-07 |
| 032 | Horse Animset Pro (Riding System) | Asset Store | Animation | Deferred | No | 2026-02-07 |
| 033 | Fish Alive - Animated Polyart Fish | Asset Store | Animation / AI | Approved | Yes | 2026-02-07 |
| 034 | GanzSe Fantasy Low Poly Fishing Props | Asset Store | Art | Approved | Yes | 2026-02-07 |
| 035 | Poly Universal Pack | Asset Store | Art | Approved | Yes | 2026-02-07 |
| 036 | Low Poly Animated Animals (polyperfect) | Asset Store | Animation / Art | Approved | Yes | 2026-02-07 |
| 037 | Low Poly Animated People (polyperfect) | Asset Store | Animation / Art | Approved | Yes | 2026-02-07 |
| 038 | City People Mega-Pack | Asset Store | Animation / Art | Approved | Yes | 2026-02-07 |
| 039 | Stylized Water 3 (Staggart Creations) | Asset Store | Rendering | Approved | Yes - Critical | 2026-02-07 |
| 040 | Dynamic Effects for SW3 (Staggart Creations) | Asset Store | Rendering | Approved | Yes | 2026-02-07 |
| 041 | Underwater Rendering for SW3 (Staggart Creations) | Asset Store | Rendering | Approved | Yes | 2026-02-07 |
| 042 | Ripple Shader Pack (Eldvmo) | Asset Store | Rendering | Rejected | No | 2026-02-08 |
| 043 | Environment / Weather / Nature VFX Pack (Kripto289) | Asset Store | VFX | Conditional | Maybe | 2026-02-08 |
| 044 | Low Poly Modular Terrain Pack (JustCreate) | Asset Store | Art | Approved | Yes | 2026-02-08 |
| 045 | River Modeler (Staggart Creations) | Asset Store | Tools | Approved | Yes | 2026-02-08 |
| 046 | Low Poly Rocks Pack (JustCreate) | Asset Store | Art | Approved | Yes | 2026-02-08 |
| 047 | Free Low Poly - Raft on the Desert (EmaceArt) | Asset Store | Art | Conditional | Maybe | 2026-02-09 |
| 048 | Raft Builder Kit | Asset Store | Art | Conditional | Maybe | 2026-02-09 |
| 049 | Blaze AI Engine (Pathiral) | Asset Store | AI | Deferred | No | 2026-02-09 |
| 050 | Unity-Theme (IvanMurzak) | GitHub | UI | Approved | Yes | 2026-02-11 |
| 051 | Unity-ImageLoader (IvanMurzak) | GitHub | UI | Approved | Yes | 2026-02-11 |
| 052 | Unity-AI-Animation (IvanMurzak) | OpenUPM | Tools (MCP Ext) | Conditional | Maybe (installed) | 2026-02-11 |
| 053 | Unity-AI-ParticleSystem (IvanMurzak) | OpenUPM | VFX (MCP Ext) | Conditional (compilation bug) | Maybe (installed) | 2026-02-11 |
| 054 | Unity-Package-Template (IvanMurzak) | GitHub | Tools (Dev) | Deferred | No | 2026-02-11 |
| 055 | Unity-AI-ProBuilder (IvanMurzak) | OpenUPM | Tools (MCP Ext) | Conditional | Maybe (installed) | 2026-02-11 |
| 056 | MCP for Unity / AI Game Developer (IvanMurzak) | OpenUPM | Tools | Approved - Default | Yes | 2026-02-11 |
| 057 | Unity-AI-Tools-Template (IvanMurzak) | GitHub | Tools (Dev) | Deferred (template) / Approved (concept) | Yes | 2026-02-11 |
| 058 | Unity-EFCore-SQLite (IvanMurzak) | OpenUPM | Data | Deferred | Maybe | 2026-02-11 |
| 059 | Unity-PlayerPrefsEx (IvanMurzak) | OpenUPM | Data | Conditional | Maybe | 2026-02-11 |
| 060 | Unity-Extensions (IvanMurzak) | npm | Tools (Utility) | Rejected | No | 2026-02-11 |
| 061 | Unity-AudioLoader (IvanMurzak) | OpenUPM | Audio | Conditional | Maybe | 2026-02-11 |
| 062 | Unity-AI-Meshy (IvanMurzak) | OpenUPM | Tools (MCP Ext) | Deferred | Maybe | 2026-02-11 |
| 063 | MCP-Plugin-dotnet (IvanMurzak) | GitHub/NuGet | AI / MCP | Deferred | No (non-Unity) | 2026-02-11 |
| 064 | UBuilder (IvanMurzak) | OpenUPM | Tools (Build) | Deferred | Maybe | 2026-02-11 |
| 065 | NuGetForUnity (GlitchEnzo) | GitHub/OpenUPM | Tools (Package Mgmt) | Rejected | No | 2026-02-12 |
| 066 | Unity Toon Shader (Unity-Technologies) | GitHub | Rendering | Testing (Git URL fixed) | Yes | 2026-02-12 |
| 067 | BuildReportInspector (Unity-Technologies) | GitHub | Tools (Build) | Testing (Git URL fixed) | Yes | 2026-02-12 |
| 068 | ML-Agents (Unity-Technologies) | GitHub/Registry | AI | Conditional | Maybe | 2026-02-12 |
| 069 | BoatAttack (Unity-Technologies) | GitHub | Rendering (Reference) | Deferred (Reference) | Yes | 2026-02-12 |
| 070 | PaddleGameSO (UnityTechnologies) | GitHub | Architecture (Reference) | Deferred (Reference) | Yes | 2026-02-12 |
| 071 | Game Programming Patterns (UnityTechnologies) | GitHub | Architecture (Reference) | Deferred (Reference) | Yes | 2026-02-12 |
| 072 | Sentis Samples (Unity-Technologies) | GitHub | AI (Reference) | Deferred (Reference) | Yes | 2026-02-12 |
| 073 | ZString (Cysharp) | GitHub | Tools (Performance) | Deferred | Yes | 2026-02-12 |
| 074 | R3 (Cysharp) | GitHub | Architecture (Reactive) | Deferred | Yes | 2026-02-12 |
| 075 | MemoryPack (Cysharp) | GitHub | Data (Serialization) | Deferred | Yes | 2026-02-12 |
| 076 | ZLinq (Cysharp) | GitHub | Tools (Performance) | Deferred | Maybe | 2026-02-12 |
| 077 | MessagePipe (Cysharp) | GitHub | Architecture (Messaging) | Deferred | Maybe | 2026-02-12 |
| 078 | ObservableCollections (Cysharp) | GitHub | UI (Data Binding) | Deferred | Maybe | 2026-02-12 |
| 079 | MasterMemory (Cysharp) | GitHub | Data (Database) | Deferred | Maybe | 2026-02-12 |
| 080 | UnitGenerator (Cysharp) | GitHub | Tools (Code Gen) | Deferred | Maybe | 2026-02-12 |
| 081 | StructureOfArraysGenerator (Cysharp) | GitHub | Tools (Performance) | Deferred | Maybe | 2026-02-12 |
| 082 | CsprojModifier (Cysharp) | GitHub | Tools (IDE) | Deferred | Maybe | 2026-02-12 |
| 083 | Simple Boids / #NVJOB Boids (NVJOB) | Asset Store | AI (Boids) | Rejected (cherry-pick shader) | Maybe | 2026-02-13 |

---

## Detailed Evaluations

### Entry Template

Use this format for each new evaluation:

---

#### ENTRY-XXX: [Asset Name]

| Field | Value |
|-------|-------|
| **Asset** | [Full name] |
| **Source** | [Asset Store / GitHub / Unity Registry / Custom] |
| **Version** | [Version tested] |
| **Category** | [VFX / AI / UI / Audio / Animation / Rendering / Tools / Networking / Other] |
| **Date Started** | [YYYY-MM-DD] |
| **Date Completed** | [YYYY-MM-DD or In Progress] |
| **Verdict** | [Approved / Conditional / Rejected / Testing / Deferred] |
| **HOK Applicable** | [Yes / No / Maybe] |

**What It Does:**
[Brief description of what the asset provides]

**What We Tested:**
[Specific features or scenarios tested]

**Results:**
[What happened - be specific about behavior, performance, compatibility]

**Pros:**
- [List of positives]

**Cons:**
- [List of negatives]

**Integration Notes:**
[Any gotchas, setup requirements, conflicts with existing packages]

**Performance:**
[Frame impact, memory, build size if relevant]

**Verdict Rationale:**
[Why this verdict was chosen. If Conditional, state the conditions.]

**HOK Notes:**
[How this would apply to HOK specifically. What system would use it? Any conflicts with existing HOK architecture (SOAP, Dreamteck, etc.)?]

---

## Archive

**Archive:** `Sandbox_AssetLog_Archive.md` contains all detailed ENTRY blocks from completed evaluation phases.

**Archived Phases:**
- Editor Tools Phase (Sessions 3-5): ENTRY-001 through ENTRY-027
- Malbers Ecosystem Phase (Session 6): ENTRY-028 through ENTRY-032
- Low-Poly Art Pipeline Phase (Session 7): ENTRY-033 through ENTRY-038
- SW3 Ecosystem Phase (Sessions 8-9): ENTRY-039 through ENTRY-042

**When entries move to archive:** When an evaluation phase is marked COMPLETE in Sandbox_Status.md, move the detailed ENTRY blocks for that phase to Sandbox_AssetLog_Archive.md. Keep the Summary Table row, Category Index entry, Rejection Log entry (if applicable), and Lessons Learned entries in this live document.

**To find archived entry details:** Search Sandbox_AssetLog_Archive.md by entry number (e.g., "ENTRY-013").

---

## Active Evaluations


#### ENTRY-043: Environment / Weather / Nature VFX Pack (Kripto289)

| Field | Value |
|-------|-------|
| **Asset** | Environment / Weather / Nature VFX Pack |
| **Source** | Asset Store (Kripto289) |
| **Version** | 1.1.3 |
| **Category** | VFX |
| **Date Started** | 2026-02-08 |
| **Date Completed** | 2026-02-08 |
| **Verdict** | Conditional |
| **HOK Applicable** | Maybe |

**What It Does:**
Large VFX library containing ~80 effects across weather (rain, snow, fog, lightning), environment (fire, smoke, dust, waterfalls), and nature categories. Uses ParticleSystem (Shuriken) throughout, not VFX Graph. Includes demo scenes, prefabs, textures, and custom shaders.

**What We Tested:**
Folder structure, shader pipeline compatibility, prefab organization, particle system configuration, material setup, texture quality, and overall architecture.

**Results:**
The pack contains a wide variety of environmental effects organized into clear subcategories. However, it was built for the Built-in Render Pipeline (BiRP). Shaders use legacy `CGPROGRAM` / `UnityCG.cginc` includes and will need URP conversion to render correctly on Unity 6 URP. ParticleSystem (Shuriken) prefabs themselves are pipeline-agnostic - only the materials/shaders need updating. Approximately 40% of the effects (cave fog, dust motes, fire, smoke, ambient particles) are directly relevant to a Styx underground cave environment. Weather effects (rain, snow, storms) are less useful for an underground setting.

**Pros:**
- Large variety of environmental effects (~80 prefabs)
- Well-organized folder structure with clear categorization
- ParticleSystem prefabs are pipeline-agnostic (only materials need URP conversion)
- Good texture quality for a low-poly aesthetic
- ~40% of effects directly usable for underground cave setting (fog, dust, fire, smoke, ambient particles)

**Cons:**
- **Built-in RP shaders** - all custom shaders use legacy `CGPROGRAM` / `UnityCG.cginc`, requiring URP conversion
- Legacy ParticleSystem (Shuriken) throughout, not VFX Graph
- No asmdef for any scripts
- Weather effects (rain, snow, storms) less useful for underground Styx cave direction
- Shader conversion effort required before any effects render correctly

**Integration Notes:**
Shader conversion from BiRP to URP is the primary integration cost. Unity's render pipeline converter can handle some shaders automatically, but custom particle shaders typically need manual work. Consider converting only the ~40% of effects that apply to the cave environment rather than the full pack.

**Performance:**
ParticleSystem-based effects are generally performant. Individual effect cost depends on particle count and overdraw. No VFX Graph means no GPU simulation benefits, but also no compute shader requirements.

**Verdict Rationale:**
Conditional because the effects are useful but require shader conversion work before they're functional on URP. The cave-relevant subset (~40%) is worth the conversion effort if no URP-native alternative is found. The weather effects add value if the game eventually includes above-ground areas.

**HOK Notes:**
With the River Styx scene shifting to an underground cave direction, the cave-relevant effects (fog, dust motes, fire/torch particles, smoke, ambient floating particles) could enhance the atmosphere significantly. The main cost is BiRP-to-URP shader conversion. If HOK stays underground-focused for the Styx area, only about half the pack is directly useful. Consider as a VFX donor library rather than a drop-in solution.

---

#### ENTRY-044: Low Poly Modular Terrain Pack (JustCreate)

| Field | Value |
|-------|-------|
| **Asset** | Low Poly Modular Terrain Pack |
| **Source** | Asset Store (JustCreate) |
| **Version** | 1.5 |
| **Category** | Art |
| **Date Started** | 2026-02-08 |
| **Date Completed** | 2026-02-08 |
| **Verdict** | Approved |
| **HOK Applicable** | Yes |

**What It Does:**
Massive modular terrain construction kit with 5,062 FBX meshes and 3,341 prefabs. Covers terrain tiles, cliffs, cave pieces, ground modules, paths, bridges, ramps, and environmental props. Designed for snap-together level construction with consistent low-poly aesthetic. Includes vertex-colored and textured variants.

**What We Tested:**
Asset count and organization, mesh quality, prefab structure, material/shader URP compatibility, modular connection points, texture resolution, polygon counts, and aesthetic fit with HOK's cozy low-poly style.

**Results:**
Excellent modular terrain kit. All materials use URP-compatible shaders out of the box - no conversion needed. Meshes are consistently low-poly with clean topology suitable for cozy game aesthetics. Modular pieces snap together with consistent connection points. The cave pieces (tunnels, cavern modules, stalactite/stalagmite decorations) are particularly relevant given the underground Styx direction. Ground tiles, cliff faces, and path modules provide complete terrain coverage. Vertex-colored variants allow palette-based coloring without additional textures.

**Pros:**
- Massive content library (5,062 FBX, 3,341 prefabs)
- 100% URP-compatible - works out of the box on Unity 6
- Consistent cozy low-poly aesthetic matching HOK art direction
- Modular snap-together design for efficient level building
- Cave pieces included (tunnels, caverns) - directly useful for Styx underground
- Vertex-colored variants for palette-based coloring
- Clean mesh topology with appropriate poly counts for mobile/cozy targets
- Well-organized folder structure

**Cons:**
- Large asset count may increase project import time
- Some pieces may need LOD setup for distant views
- No scripts included - purely visual content (not necessarily a con)

**Integration Notes:**
Drop-in ready for URP projects. Combine with Prefab World Builder (ENTRY-024) for efficient level design workflow. Vertex-colored variants work well with DA PolyPaint (ENTRY-027) for palette consistency.

**Performance:**
Low-poly meshes are inherently performant. Modular design means only visible pieces need rendering. Consider LOD groups for large cave environments with many modules.

**Verdict Rationale:**
Approved. Full URP compatibility, massive content library, cozy low-poly aesthetic that matches HOK, and modular design that supports efficient level building. The cave modules are an unexpected bonus given the Styx underground direction shift. Zero integration friction.

**HOK Notes:**
Primary use: terrain and environment construction for all HOK areas. The cave/tunnel modules are immediately relevant for the River Styx underground environment. Ground tiles, cliffs, and paths serve above-ground areas (fishing spots, villages). Combines naturally with Prefab World Builder for level design. The consistent low-poly style matches HOK's cozy aesthetic alongside Poly Universal Pack (ENTRY-035) and Low Poly Rocks Pack (ENTRY-046).

---

#### ENTRY-045: River Modeler (Staggart Creations)

| Field | Value |
|-------|-------|
| **Asset** | River Modeler |
| **Source** | Asset Store (Staggart Creations) |
| **Version** | 1.0.4 |
| **Category** | Tools |
| **Date Started** | 2026-02-08 |
| **Date Completed** | 2026-02-08 |
| **Verdict** | Approved |
| **HOK Applicable** | Yes |

**What It Does:**
Spline-based procedural river geometry tool. Draw a spline path in the editor, and River Modeler generates optimized river mesh geometry that follows the path with configurable width, depth, bank slopes, and UV flow. Built by Staggart Creations (same developer as Stylized Water 3), with native SW3 material integration. Namespace: `sc.modeling.river`.

**What We Tested:**
Source code architecture, SW3 integration points, spline system implementation, mesh generation pipeline, editor tooling, namespace discipline, asmdef isolation, and compatibility with Unity 6 URP.

**Results:**
Excellent code quality consistent with Staggart Creations' other packages (SW3, Dynamic Effects, Underwater Rendering). Clean namespace (`sc.modeling.river`), proper asmdef isolation, and well-structured editor/runtime separation. The spline system generates optimized river meshes that automatically receive SW3 materials with correct UV flow direction. Integration with SW3 is seamless - the generated mesh acts as a native SW3 water surface with all features (Gerstner waves, foam, caustics, reflections). Editor tools allow real-time spline editing with immediate mesh preview.

**Pros:**
- Same developer as SW3 - guaranteed integration quality
- Clean namespace (`sc.modeling.river`) and proper asmdef isolation
- Spline-based workflow intuitive for level designers
- Generated meshes are fully SW3-compatible (waves, foam, caustics work automatically)
- Editor tools with real-time preview during spline editing
- Optimized mesh generation (only necessary triangles along the path)
- Configurable width, depth, bank slopes per control point
- UV flow direction follows spline path automatically
- Excellent code quality (no var abuse, clean architecture)

**Cons:**
- Version 1.0.4 - relatively new product (though from an established developer)
- Requires SW3 as a dependency (not standalone)

**Integration Notes:**
Requires Stylized Water 3 (ENTRY-039) as a dependency. Since SW3 is already approved and installed, this is a natural extension. The generated river meshes replace the need to manually model river geometry and UV-map it for SW3 material flow.

**Performance:**
Generated meshes are optimized to the spline path - no wasted triangles on non-visible areas. Runtime cost is identical to any other SW3 water surface since the generated mesh is a standard Unity mesh with SW3 material.

**Verdict Rationale:**
Approved. Same developer as the project's critical water rendering system (SW3), excellent code quality, proper namespace and asmdef discipline, and seamless integration with the existing water pipeline. Eliminates the manual work of modeling river geometry and mapping UVs for correct flow. The River Styx is literally a river - this is the exact tool for the job.

**HOK Notes:**
**Critical for Styx.** The River Styx is the central feature of HOK's underworld. River Modeler provides the exact workflow needed: draw a spline path for the river's course through the underground cave, and get a fully SW3-compatible water surface with correct flow direction. Pairs with SW3 (ENTRY-039), Dynamic Effects (ENTRY-040) for wake/ripples, and Underwater Rendering (ENTRY-041) for submerged areas. The Staggart ecosystem is now four packages deep - all approved, all interoperable.

---

#### ENTRY-046: Low Poly Rocks Pack (JustCreate)

| Field | Value |
|-------|-------|
| **Asset** | Low Poly Rocks Pack |
| **Source** | Asset Store (JustCreate) |
| **Version** | 1.3.8 |
| **Category** | Art |
| **Date Started** | 2026-02-08 |
| **Date Completed** | 2026-02-08 |
| **Verdict** | Approved |
| **HOK Applicable** | Yes |

**What It Does:**
Comprehensive rock and mineral prop library with 1,045 meshes and 1,496 prefabs. Includes boulders, cliff faces, cave rocks, crystals, gemstones, mossy variants, desert rocks, snow-covered rocks, and rock arches. Uses a vertex color + 256x256 texture atlas hybrid approach for material variation with minimal texture memory.

**What We Tested:**
Asset count and organization, mesh quality, material/shader URP compatibility, polygon counts, texture approach, crystal/gemstone models, cave-relevant pieces, and aesthetic compatibility with HOK and the companion Low Poly Modular Terrain Pack (ENTRY-044).

**Results:**
Large, well-organized rock library with consistent low-poly style. All materials URP-compatible out of the box. The vertex color + atlas hybrid approach is clever - vertex colors provide per-rock tint variation while the shared 256x256 atlas keeps texture memory near zero. Crystal and gemstone models are standout pieces, perfect for Styx underground cave aesthetics (glowing crystals, mineral deposits). Cave rock variants (rough, mossy, wet-look) provide good environmental variety. Only 4 arch pieces - may need supplementing for large cave entrances.

**Pros:**
- Massive library (1,045 meshes, 1,496 prefabs)
- 100% URP-compatible - works out of the box
- Crystal and gemstone models perfect for Styx underground aesthetics
- Vertex color + atlas hybrid minimizes texture memory (single 256x256 atlas)
- Multiple rock variants (mossy, snow, desert, cave, cliff)
- Consistent style with Low Poly Modular Terrain Pack (same publisher)
- Well-organized by rock type and environment
- Low poly counts suitable for dense placement

**Cons:**
- No stalactites or stalagmites (gap for cave ceiling/floor formations)
- Only 4 arch pieces (limited for large cave entrances)
- No scripts - purely visual content (not a con for an art pack)

**Integration Notes:**
Same publisher as Low Poly Modular Terrain Pack (ENTRY-044) - styles match perfectly for combined terrain + rock environments. Combine with Prefab World Builder (ENTRY-024) for efficient rock placement. Crystals could be enhanced with emissive materials for Styx glow effects.

**Performance:**
Low-poly meshes with shared atlas texture - very GPU-friendly even with dense placement. Static batching will combine rocks efficiently. Consider LOD groups only for extremely dense rock fields.

**Verdict Rationale:**
Approved. URP-compatible, massive content library, consistent style with the companion terrain pack, and the crystals are an excellent fit for the Styx underground cave direction. The stalactite/stalagmite gap is noted but not blocking - these could be created with UModeler X (ENTRY-026) or sourced separately. The vertex color + atlas approach is technically sound and memory-efficient.

**HOK Notes:**
Primary use: environmental props for all HOK areas, with special focus on the Styx underground cave. Crystals and gemstones create the visual identity of the underworld - glowing minerals along cave walls and embedded in rock formations. Combine with Low Poly Modular Terrain Pack (ENTRY-044) for complete cave environments. The stalactite/stalagmite gap could be filled by UModeler X (ENTRY-026) for custom formations or by sourcing a dedicated cave decoration pack. Mossy rock variants work well for above-ground fishing spots near water.

---

#### ENTRY-047: Free Low Poly - Raft on the Desert (EmaceArt)

| Field | Value |
|-------|-------|
| **Asset** | Free Low Poly - Raft on the Desert |
| **Source** | Asset Store (EmaceArt) |
| **Version** | 1.2 |
| **Category** | Art |
| **Date Started** | 2026-02-09 |
| **Date Completed** | 2026-02-09 |
| **Verdict** | Conditional |
| **HOK Applicable** | Maybe |

**What It Does:**
Desert-themed low-poly environment pack centered around a raft model. Contains 94 FBX meshes and 95 prefabs across categories: the raft vehicle itself, oars, barrels, cauldrons, fireplaces, flags, skulls, poles, desert terrain tiles, rocks, plants/trees, birds, clouds, and wooden furniture. Uses a shared palette texture approach with 6 materials (wood, metal, organic, standard, synthetic, decal) all referencing the same base texture atlas. Includes 6 demo scenes, camera animations, and a skybox.

**What We Tested:**
File inventory, folder structure, material/shader URP compatibility, raft model assessment, prop relevance to HOK's Kharon raft.

**Results:**
URP-compatible out of the box - all materials use URP/Lit shader (GUID 933532a4fcc9baf4fa0491de14d08ed7). Zero scripts. The raft model itself (`EA04_Wehicule_Raft_01a`) is a single low-poly static mesh - a simple wooden platform with log base, adequate for a basic ferry/raft. The oar prop is a nice complementary piece. The desert-themed environment props (cacti, desert terrain, sand rocks) are NOT relevant to HOK's underground cave/river setting. The universal props (barrels, cauldrons, fireplaces, flags, skulls) are potentially useful for Kharon's raft set dressing.

**Pros:**
- URP-compatible (URP/Lit shader on all materials)
- Zero scripts - purely visual, zero integration risk
- Shared palette texture system (easy to restyle for underworld colors)
- Raft model is clean low-poly, suitable as a base for Kharon's ferry
- Oar prop directly useful for a river raft
- Skulls, flags, barrels, cauldrons fit Greek Underworld theme
- Free asset - zero cost

**Cons:**
- Desert-themed environment props are not relevant to underground Styx setting
- Raft is a single static mesh - no modular pieces for customization
- No animations on the raft (would need SW3 AlignToWater for water movement)
- No colliders on prefabs
- No LOD groups
- Many props duplicate what's already in Poly Universal Pack (ENTRY-035) and GanzSe Fishing Props (ENTRY-034)
- Demo scenes include lighting data that overwrote existing SampleScene on import

**Integration Notes:**
The SampleScene import conflict is a packaging issue - the Raft Builder Kit (ENTRY-048) included a SampleScene folder with baked lighting data that overwrote the existing project SampleScene. This has been addressed by creating a new scene at Assets/Sandbox/HOK/Scenes/Acheron.unity.

**Performance:**
Static low-poly meshes, negligible impact. Shared palette texture is memory-efficient.

**Verdict Rationale:**
Conditional. The raft model itself and a handful of props (oar, skulls, barrels, cauldrons) are potentially useful for Kharon's ferry set dressing, but the bulk of the pack is desert-themed content that doesn't apply to HOK's underground river environment. The raft is a starting point, not a final solution - it would need to be combined with additional props, SW3 AlignToWater for buoyancy, and underworld-themed recoloring. Worth keeping for the raft mesh and a few props; the desert environment pieces are dead weight.

**HOK Notes:**
The raft model could serve as Kharon's ferry base platform. It's a simple wooden raft on log floats - thematically appropriate for a Greek Underworld ferryman. Add SW3 AlignToWater component for water-surface following. Dress with fishing props from GanzSe (ENTRY-034), skulls and flags from this pack, and Poly Universal Pack barrels/torches. The palette texture swap via DA PolyPaint (ENTRY-027) can restyle from desert browns to underworld dark tones. However, this is a very basic raft - if HOK needs a more detailed ferry (raised platform, steering area, lanterns, cargo hold), the mesh would need significant UModeler X modifications or a custom build.

---

#### ENTRY-048: Raft Builder Kit

| Field | Value |
|-------|-------|
| **Asset** | Raft Builder Kit |
| **Source** | Asset Store |
| **Version** | 1.0 |
| **Category** | Art |
| **Date Started** | 2026-02-09 |
| **Date Completed** | 2026-02-09 |
| **Verdict** | Conditional |
| **HOK Applicable** | Maybe |

**What It Does:**
Modular raft/survival base construction kit with 91 FBX models and 95 prefabs. Organized into categories: floor tiles (4 variants including elevated), large platform bases (floating rolls, rope platforms, wood sides), walls (10 variants with windows, doors, tarps, pallet construction), stairs (2 types), utility items (grill, smelter, workbench, water purifiers, solar panel, windmill, battery charger, sail, fluid storage), food items (22 types: fish, fruit, meat, mushrooms), small tools (hammer, hook, fishing rods, bow, paddle, axe, shovel, cup, plate, bottle, arrows, oxygen bottle), storage (chests, locker), resources (wire, circuit board, car battery), and a fire pit. Uses individual textures per category (16 materials, separate texture folders) rather than a shared palette.

**What We Tested:**
File inventory, folder structure, material/shader URP compatibility, modular piece assessment, prop relevance to HOK's Kharon raft, art style compatibility.

**Results:**
URP-compatible - all materials use URP/Lit shader. Zero scripts. This is a survival-game raft builder kit, not a simple raft model. The modular pieces are designed for a Raft-style survival game (solar panels, smelters, water purifiers, windmills, circuit boards) which is a very different aesthetic and gameplay context from HOK's Greek Underworld. The art style is semi-realistic low-poly, not as stylized as the polyperfect/JustCreate packs already in use. Individual textures per category (16 materials, each with their own texture folder) means this pack doesn't use the shared palette approach - harder to restyle for underworld theme. The SampleScene conflict (overwrote project SampleScene) is a packaging defect.

**Pros:**
- URP-compatible (URP/Lit shader on all materials)
- Zero scripts - purely visual, zero integration risk
- Modular floor/wall/platform system allows custom raft construction
- Useful props: fishing rods, paddle, fire pit, hooks, chests, food items
- Platform bases with floating rolls could serve as raft foundation
- Modular walls could create a cabin on Kharon's ferry

**Cons:**
- Survival-game aesthetic (solar panels, smelters, circuit boards, oxygen bottles) doesn't fit Greek Underworld theme
- Individual textures per category (16 materials) - not palette-based, harder to restyle
- Art style is semi-realistic low-poly, may not match polyperfect/JustCreate aesthetic
- SampleScene packaging defect (overwrote project SampleScene on import)
- No LOD groups
- No colliders on prefabs
- Food models (watermelon, mango, steak) are survival-game items, not underworld-themed
- Modern/industrial items (battery charger, windmill, wire, circuit board) have no underworld use

**Integration Notes:**
The SampleScene overwrite is the most notable integration issue. The package includes a SampleScene folder at the root with baked lighting data that conflicts with any existing SampleScene. This has been addressed by moving HOK work to Assets/Sandbox/HOK/Scenes/Acheron.unity.

**Performance:**
Static low-poly meshes with individual textures. More draw calls than a shared-palette approach due to 16 separate materials. Negligible for a single raft but less efficient than single-material packs.

**Verdict Rationale:**
Conditional. The modular floor/wall/platform pieces could theoretically be used to construct a more detailed Kharon's ferry than the EmaceArt raft (ENTRY-047). The floating roll platform bases are particularly useful for a raft foundation. However, the survival-game aesthetic (solar panels, smelters, circuit boards) is a poor thematic fit, the semi-realistic art style may clash with established low-poly packs, and the per-category textures make restyling harder than palette-based packs. Cherry-pick the useful structural pieces (platforms, floors, walls, stairs) and a few props (fishing rods, paddle, fire pit, hooks, chests), ignore the survival/industrial items.

**HOK Notes:**
Selective use for Kharon's ferry construction:
- **Use:** LargePlatform1 (base), floating rolls (buoyancy visual), floor tiles (deck), wall variants (cabin walls if ferry has a cabin), stairs (multi-level ferry), fire pit (atmospheric), fishing rods (set dressing), paddle/hooks (props), chests (cargo storage visual)
- **Ignore:** Solar panel, windmill, battery charger, smelter, workbench, water purifiers, oxygen bottle, circuit board, wire, car battery, all food items except maybe fish
- **Challenge:** The 16 separate materials make it harder to restyle compared to EmaceArt's palette approach or polyperfect's shared texture system. May need to create a unified underworld material and remap UVs using DA PolyPaint, or accept the visual inconsistency.
- **Recommendation:** Between the two raft assets, the EmaceArt raft (ENTRY-047) is simpler but better fits the single-mesh ferry concept. The Raft Builder Kit is better if HOK wants a modular, customizable ferry that the player can potentially upgrade. Decision depends on whether Kharon's raft is a static vehicle (EmaceArt) or a player-upgradeable platform (Raft Builder Kit structural pieces).

---

#### ENTRY-049: Blaze AI Engine (Pathiral)

| Field | Value |
|-------|-------|
| **Asset** | Blaze AI Engine |
| **Source** | Asset Store (Pathiral) |
| **Version** | 3.4.17 |
| **Category** | AI |
| **Date Started** | 2026-02-09 |
| **Date Completed** | 2026-02-09 |
| **Verdict** | Deferred |
| **HOK Applicable** | No |

**What It Does:**
Combat-focused enemy/companion AI engine built on a finite state machine (FSM) architecture. Core states: Normal (idle/patrol), Alert (suspicious/investigating), Attack (combat engagement including chase, strafe, melee, ranged, cover). Uses Unity NavMesh for pathfinding. Has its own simplified animation system (name-based clip references, bypasses Animator state machine transitions). Supports Humanoid and Generic rigs, root motion, AI-vs-AI combat, call-for-help chains, enemy scheduling, and detection bars. Optional paid add-ons: Predator (prey/predator behaviors), Enemy Waves (wave spawning). Component-based MonoBehaviour architecture, source included.

**What We Tested:**
Research-only evaluation. Assessed feature set, architecture, and overlap with existing AI systems (Malbers AC AI Brain, polyperfect WanderScript, Fish Alive FishMotion). Asset was briefly installed then removed.

**Results:**
Blaze AI is a well-built combat AI system, but its differentiating features (cover shooter tactics, strafing, melee/ranged scheduling, detection bars, enemy wave spawning) are entirely combat-oriented. HOK is a cozy fishing game with no combat. Every AI need HOK has is already covered by existing installed systems.

**Overlap Analysis:**

| HOK AI Need | Already Covered By |
|---|---|
| Companion creature behavior | Malbers AC AI Brain (follow, stay, patrol, decisions/tasks) |
| Fish behavior | Fish Alive (FishMotion, schooling, feeding) |
| Ambient wildlife | Malbers AC + polyperfect (wander, flee) |
| NPC ferry passengers | Malbers AC AI Brain or simple custom scripts |

**Pros:**
- Well-engineered FSM with per-state modular behavior scripts
- Good performance (single Update call, distance culling, vision cycle frames)
- URP-compatible (no rendering code, pure behavior system)
- Source code included, well-commented
- $35 USD - low monetary cost

**Cons:**
- Combat-focused features are irrelevant to a cozy fishing game
- Own animation system (name-based) conflicts with Malbers AC animation framework (states/modes/stances)
- MonoBehaviour FSM architecture vs Malbers AC ScriptableObject AI Brain - running both on same character creates architectural confusion
- No aquatic/schooling behavior (cannot replace Fish Alive)
- Predator add-on replicates what Malbers AC AI Brain already supports via Look decisions + flee/chase tasks

**Integration Notes:**
Removed from project after research evaluation. No integration performed. If reinstalled later, keep Blaze AI and Malbers AC on separate agent populations to avoid animation system conflicts.

**Performance:**
Not tested at runtime. Advertises good performance characteristics (single Update, distance culling, vision cycle frames, ScriptableObject audio).

**Verdict Rationale:**
Deferred, not Rejected. Blaze AI is a competent asset for the right project, but HOK has no combat AI needs and every non-combat AI need is already covered by Malbers AC + Fish Alive + polyperfect. The animation system conflict with Malbers AC is the most concrete technical concern. If HOK ever introduces hostile underworld creatures with combat behaviors that exceed Malbers AC AI Brain capabilities, Blaze AI could be revisited. Removed from project to avoid unnecessary complexity.

**HOK Notes:**
No current HOK use case. Malbers AC AI Brain provides companion behavior, ambient wildlife AI, and NPC logic. Fish Alive provides all aquatic AI. If future HOK features require sophisticated enemy combat AI (e.g., hostile shades guarding river passages, Cerberus encounter), Blaze AI could fill that gap — but that is speculative and far from current scope.

---

## Evaluations by Category

### VFX
- ENTRY-043: Environment / Weather / Nature VFX Pack / Kripto289 (Conditional - BiRP shaders need URP conversion, ~40% cave-relevant effects, VFX donor library)
- ENTRY-053: Unity-AI-ParticleSystem / IvanMurzak (Conditional but **compilation bug** - empty Runtime assembly prevents Editor from compiling. 2 tools designed for 24 ParticleSystem modules. script-execute covers 100% of ParticleSystem API. Installed, awaiting upstream fix)

### AI / MCP
- ENTRY-033: Fish Alive (Approved - schooling AI, target-following, feeding behavior, obstacle avoidance; see also Animation)
- ENTRY-049: Blaze AI Engine / Pathiral (Deferred - combat-focused FSM, all HOK AI needs covered by Malbers AC + Fish Alive + polyperfect, animation system conflicts with AC)
- ENTRY-063: MCP-Plugin-dotnet / IvanMurzak (Deferred - generic .NET MCP framework, non-Unity. Foundation that Unity-MCP is built on. MCP-enables any .NET app for Claude interop. Relevant for future TecVooDoo .NET projects)

### UI
- ENTRY-029: Ultimate Selector (Approved - animated selection carousel, 4 layout modes, no AC dependency, HOK bait wheel + fish collection)
- ENTRY-050: Unity-Theme / IvanMurzak (Approved - centralized color palette with runtime theme switching, 14+ component binders, GUID-based color refs, JSON persistence, per-river UI theming)
- ENTRY-051: Unity-ImageLoader / IvanMurzak (Approved - async image loading with dual-layer cache, fluent Future API, reference counting, built-in consumers for Image/RawImage/SpriteRenderer/Material, codex portrait loading)

### Audio
- ENTRY-061: Unity-AudioLoader / IvanMurzak (Conditional - async audio loading with dual-layer cache, mirrors ImageLoader pattern, UniTask-dependent, install when audio architecture is designed)

### Data
- ENTRY-058: Unity-EFCore-SQLite / IvanMurzak (Deferred - EntityFrameworkCore 5.0.17 + SQLite bundle, IL2CPP only, relational DB for creature catalog/progression, wait for data layer design)
- ENTRY-059: Unity-PlayerPrefsEx / IvanMurzak (Conditional - already installed as MCP dependency, AES-256 encryption, extended types incl Vector3/DateTime/JSON, use for settings and simple progression flags)

### Animation
- ENTRY-028: Malbers Animal Controller (Approved - mature character controller, ScriptableObject-driven, SOAP-compatible lineage, 5 asmdefs)
- ENTRY-031: Poly Art: Raccoon (Approved - 42+ animation states, swim-capable, low-poly, Scorch replacement candidate)
- ENTRY-032: Horse Animset Pro (Deferred - pure content, zero scripts, no HOK use case, keep as part of Malbers bundle)
- ENTRY-033: Fish Alive (Approved - 9 species, ~460 tris each, bone-rigged, complete behavior system + schooling; see also AI)
- ENTRY-036: Low Poly Animated Animals / polyperfect (Approved - 50+ species, 25 scripts with full predator-prey AI, NOT Malbers-compatible, marine animals for Styx)
- ENTRY-037: Low Poly Animated People / polyperfect (Approved - 80+ characters, 23 scripts with IK + AI + morpher, NOT Malbers-compatible, fantasy types for underworld NPCs)
- ENTRY-038: City People Mega-Pack (Approved - 157+ characters, demographic diversity, same Polyart style as Fish Alive)

### Art
- ENTRY-034: GanzSe Fantasy Low Poly Fishing Props (Approved - 70 props, fantasy fishing gear, single palette texture, URP-ready)
- ENTRY-035: Poly Universal Pack (Approved - 6,029 static models, 24 categories, prototyping resource)
- ENTRY-044: Low Poly Modular Terrain Pack / JustCreate (Approved - 5,062 FBX, 3,341 prefabs, modular snap-together terrain + cave pieces, 100% URP)
- ENTRY-046: Low Poly Rocks Pack / JustCreate (Approved - 1,045 meshes, 1,496 prefabs, crystals for Styx, vertex color + atlas hybrid)
- ENTRY-047: Free Low Poly - Raft on the Desert / EmaceArt (Conditional - single raft mesh + desert props, palette texture, raft base for Kharon ferry)
- ENTRY-048: Raft Builder Kit (Conditional - modular survival raft pieces, some structural pieces useful for ferry, survival aesthetic mismatch)

### Rendering
- ENTRY-039: Stylized Water 3 / Staggart (Approved - CRITICAL for HOK, Gerstner waves, GPU height queries, 49 materials, Render Graph, buoyancy API)
- ENTRY-040: Dynamic Effects for SW3 / Staggart (Approved - displacement, wake, ripples, shoreline waves, spline support)
- ENTRY-041: Underwater Rendering for SW3 / Staggart (Approved - box trigger zones, underwater fog/shading, waterline, mobile support)
- ENTRY-042: Ripple Shader Pack / Eldvmo (Rejected - BiRP shaders on URP project, all capabilities covered by SW3 Dynamic Effects, code bugs)

### Tools
- ENTRY-002: Procedural Generation Grid (Rejected for HOK - massive runtime framework, wrong tool for hand-crafted worlds)
- ENTRY-003: vHierarchy 2 (Approved - Default Package)
- ENTRY-004: vFolders 2 (Approved - Default Package)
- ENTRY-005: vFavorites 2 (Approved - Default Package)
- ENTRY-006: Ultimate Preview Window Pro (Approved - Default Package)
- ENTRY-007: Unity Utility Library / Git Amend (Conditional - useful parts vs dead weight)
- ENTRY-008: Hierarchy Designer (Rejected - no asmdef, runtime bloat, superseded by vHierarchy)
- ENTRY-009: Folder System / Gaskellgames (Rejected - runtime asmdef, superseded by vFolders)
- ENTRY-010: Visual Console (Rejected - broken thread safety, runtime asmdef with no runtime code)
- ENTRY-011: Runtime Debugger Toolkit (Rejected - catastrophic performance, won't compile for builds)
- ENTRY-012: Backbone Logger (Conditional - good category logging pattern, no asmdef, cherry-pick candidate)
- ENTRY-013: UDebug Panel (Approved - Default Package, A+ architecture, extensible debug framework)
- ENTRY-014: Code Monkey Toolkit (Conditional - cherry-pick only, prototyping-grade but has useful algorithms)
- ENTRY-015: Fullscreen Editor (Approved - Default Package, mature editor tool, zero runtime, multi-monitor)
- ENTRY-016: Scripts Vault - Free (Rejected - security flaws, thread safety issues, no asmdef, math bugs)
- ENTRY-017: RNGNeeds - Probability Distribution (Conditional - excellent for HOK loot/fishing, use as black box)
- ENTRY-018: Scriptable Sheets (Approved - Default Package, spreadsheet SO editor, 11 editor-only asmdefs)
- ENTRY-019: Improved Timers / Git Amend (Conditional - TecVooDoo absorption candidate, PlayerLoop timers)
- ENTRY-020: Wingman (Approved - Default Package, complements Odin, component mini-map/search)
- ENTRY-021: Init(args) (Rejected - conflicts with SOAP, 3198 var usages, redundant with stack)
- ENTRY-022: DevTrails (Conditional - editor-only stats tracker, safe to keep, bugs in own display only)
- ENTRY-023: Binding System 2 (Rejected - SOAP overlap, polling vs event-driven conflict, 850+ var usages)
- ENTRY-024: Prefab World Builder (Conditional - manual prefab placement, editor-only, zero runtime, good for HOK level design)
- ENTRY-025: UniTask (Approved - Default Package, standalone black-box async/await framework, absorption rejected)
- ENTRY-026: UModeler X Plus (Approved - Default 3D, complete in-editor 3D modeling suite, 80+ tools, partial MCP: combine/split/umodelerize/pivot via script-execute, core modeling remains manual)
- ENTRY-027: DA PolyPaint (Conditional - UV-based palette face painting, **fully scriptable via MCP**: Painter API public, RemapTo() batch recolors models to palette, complements UModeler X vertex painting)
- ENTRY-045: River Modeler / Staggart (Approved - spline-based procedural river geometry, native SW3 integration, critical for Styx)
- ENTRY-052: Unity-AI-Animation / IvanMurzak (Conditional - MCP extension, 6 animation tools. Installed, compiles, 6 tools registered. Key value: animator-get-data for inspecting complex state machines. Now installed in Sandbox)
- ENTRY-054: Unity-Package-Template / IvanMurzak (Deferred - GitHub template repo for UPM packages with CI/CD, reference only for TecVooDoo package publishing)
- ENTRY-055: Unity-AI-ProBuilder / IvanMurzak (Conditional - MCP extension, 13 ProBuilder mesh tools, FaceDirection selection, install when greyboxing begins)
- ENTRY-056: MCP for Unity / AI Game Developer / IvanMurzak (Approved - Default, 52 MCP tools, Roslyn script-execute, editor-only bridge, foundational AI workflow infrastructure)
- ENTRY-057: Unity-AI-Tools-Template / IvanMurzak (Deferred template, but **concept Approved**: project-internal custom MCP tools work without template via `[McpPluginToolType]` assembly scanning, asmdef created at `Assets/Sandbox/HOK/Scripts/Editor/McpTools/`)
- ENTRY-060: Unity-Extensions / IvanMurzak (Rejected as package -- hard UniRx+Odin deps, global namespace, code bugs. 7 cherry-pick patterns identified for TecVooDoo Utilities Phase 9)
- ENTRY-062: Unity-AI-Meshy / IvanMurzak (Deferred - MCP extension for Meshy AI 3D generation, text-to-3D and image-to-3D, requires Meshy subscription, evaluate when art pipeline needs acceleration)
- ENTRY-064: UBuilder / IvanMurzak (Deferred - CLI Unity build tool for CI/CD, cross-platform multi-target, evaluate when automated build pipeline needed)

### Networking
(No entries yet)

### Other
- ENTRY-001: Malbers Inventory System (Conditional - slot-based list inventory, AC-integrated, reference architecture for HOK custom grid)
- ENTRY-030: Fishing for Animal Controller (Approved - complete fishing system, native AC State, 3 fishing modes, ScriptableObject fish, HOK core gameplay)

---

## Rejection Log

Assets that were rejected with brief reasons. Full details in the entries above.

| Asset | Reason | Date |
|-------|--------|------|
| Hierarchy Designer | No asmdef, runtime MonoBehaviour, 99KB manager class, promotional bloat. vHierarchy 2 is superior. | 2026-02-06 |
| Folder System (Gaskellgames) | Runtime asmdef for editor-only feature. vFolders 2 is superior. | 2026-02-06 |
| Visual Console | Broken thread safety (declares lock, never uses it), race conditions, runtime asmdef ships empty assembly. | 2026-02-06 |
| Runtime Debugger Toolkit | FPS graph destroys/recreates 100+ GOs 5x/sec, collider debugger FindObjectsOfType every frame, `using UnityEditor` without guard = won't build, unbounded memory leak. | 2026-02-06 |
| Scripts Vault - Free | No asmdef, AES key stored in plaintext next to encrypted data, zero IV, synchronous HTTP on main thread, raw Thread with no sync, FluentTransform Lerp math bug, FPSCounter won't compile on mobile. | 2026-02-06 |
| Init(args) | Architectural conflict with SOAP (competing DI philosophies). 3,198 var usages. 195 LINQ calls in runtime. async void Awake anti-pattern. InternalAPIEditorBridge naming hack. 405 files for problems already solved by SOAP+Odin+UniTask. | 2026-02-07 |
| Binding System 2 | SOAP overlap (polling vs event-driven binding). 850+ var usages. LINQ in 17 runtime files. PauseBind bug. Black-box native DLL. Unique features achievable with DOTween + direct Material calls. | 2026-02-07 |
| Ripple Shader Pack (Eldvmo) | BiRP shaders (CGPROGRAM/UnityCG.cginc) incompatible with URP. Silent raycast bug (layerMask passed as maxDistance). Per-frame GC via .material. Every capability covered by SW3 Dynamic Effects with proper URP integration. Cannot layer onto SW3 water. | 2026-02-08 |

---

## Lessons Learned

Insights from evaluations that apply broadly, not just to a single asset.

| # | Lesson | From Entry |
|---|--------|------------|
| 1 | `[SerializeField]` on a class is a common Asset Store bug. The correct attribute for serializing a class in the Inspector is `[System.Serializable]`. `[SerializeField]` is only valid on fields. Two separate publishers shipped this same bug. Always check for compile errors immediately after importing any Asset Store package. | ENTRY-001, ENTRY-002 |
| 2 | Editor-only tools with proper `asmdef` isolation (`"includePlatforms": ["Editor"]`) are zero-risk additions. They cannot affect builds, runtime performance, or shipping code. Good quality-of-life tools should be standardized across all projects rather than evaluated per-project. The KuBa-CHO v-series (vHierarchy, vFolders, vFavorites) and Voxel Labs Ultimate Preview are all properly isolated. | ENTRY-003 through ENTRY-006 |
| 3 | Utility grab-bag packages need full code review even from trusted sources. Git Amend's Unity Utility Library has genuinely useful zero-alloc helpers alongside dead weight (old Input System code, heavy reflection, LINQ-in-hot-paths patterns) that contradicts project standards. A runtime asmdef with `allowUnsafeCode: true` but no unsafe code is a code smell. Consider cherry-picking good utilities into a project-owned library rather than shipping the whole package. | ENTRY-007 |
| 4 | When multiple assets compete in the same category, do a head-to-head code review before any runtime testing. File count, asmdef isolation, and basic code quality checks (thread safety, allocation patterns, namespace discipline) eliminate most contenders before you ever hit Play. In the debug tools category, 3 of 4 tools were rejected on code review alone. The winner (UDebug Panel, 126 files) was the largest but also the only one with proper asmdef separation, zero-alloc runtime paths, and professional architecture. Size is not bloat if every file has a purpose. | ENTRY-010 through ENTRY-013 |
| 5 | Utility grab-bag packages (Code Monkey Toolkit, Scripts Vault, Git Amend) should be treated as algorithm donors for a project-owned utility library, not as direct dependencies. Even when a package has zero `var` and zero LINQ (Code Monkey), its architectural patterns (ad-hoc singletons, legacy Input, coroutine-only) may be fundamentally incompatible with project standards. Cherry-pick the non-trivial algorithms (grid math, hex grid, camera shake, typewriter effects, PlayerLoop timers) and rewrite to project standards. The simple utilities (singletons, extensions, file I/O) are faster to write from scratch than to refactor. | ENTRY-007, ENTRY-014, ENTRY-016, ENTRY-019 |
| 6 | Third-party probability/math packages with Burst compilation and NativeContainer usage (RNGNeeds) should be consumed as black-box dependencies, not absorbed into a utility library. The performance-critical hot paths are already optimized beyond what a manual rewrite would achieve, and the Burst/Jobs integration is non-trivial to replicate. Consume via Package Manager, don't modify source, and respect the API boundaries (don't call config methods per-frame). | ENTRY-017 |
| 7 | Editor-only tools with zero runtime impact and zero dependencies (Fullscreen Editor, Scriptable Sheets) are low-risk, high-value additions. The key signals are: correct `includePlatforms: ["Editor"]` on all asmdefs, active version maintenance across Unity releases (preprocessor guards for API changes), and evidence of issue tracking (GitHub issue references in code comments). These tools pay for themselves on day one and carry no build risk. | ENTRY-015, ENTRY-018 |
| 8 | Before evaluating any DI/binding/architecture framework, check for SOAP overlap first. SOAP's event-driven ScriptableObject architecture is the project's core pattern. Any package that introduces a competing data flow model (polling, constructor injection, service locators) creates architectural confusion and forces per-component decisions about which system to use. Both Init(args) and Binding System 2 were technically well-engineered but fundamentally incompatible with the SOAP-first project philosophy. | ENTRY-021, ENTRY-023 |
| 10 | Do not penalize third-party assets for `var` usage or other personal coding style preferences. Those standards apply to TecVooDoo-authored code only. The only exception is when code is being absorbed into the TecVooDoo utility library, and even then only during the rewrite - not as an evaluation criterion for the source package. | All |
| 11 | Framework-scale packages that deeply integrate with Unity internals (PlayerLoop, AsyncMethodBuilder, Burst/Jobs) should never be absorbed into a utility library regardless of their license. UniTask's 70K LOC of async infrastructure, task pooling, and PlayerLoop scheduling is maintained for free by its author and battle-tested in thousands of shipped games. The maintenance burden of owning that code (especially across Unity version upgrades) far outweighs the cost of one additional package dependency. Create thin wrappers for project-specific convenience methods instead. | ENTRY-025 |
| 9 | Tools that sound similar can be fundamentally different. Prefab World Builder (manual prefab painting/snapping) and Procedural Generation Grid (procedural world generation framework) appear to compete but are actually complementary. PWB is 56 files, editor-only, zero runtime - a level design brush. PGG is 801 files, 99K lines of runtime code - a procedural generation engine. For hand-crafted worlds (HOK), PWB is the right tool. For procedural worlds, PGG would be. Always compare scope and runtime footprint before assuming two tools compete. | ENTRY-002, ENTRY-024 |
| 12 | When comparing painting/coloring tools, the underlying technique matters more than the feature name. "Vertex color painting" (UModeler X) and "atlas UV remapping" (DA PolyPaint) both let you color mesh faces, but store color data differently (vertex attributes vs UV coordinates pointing to a palette texture). Vertex colors require shader support; UV palette mapping works with any standard diffuse material. For enforcing a project-wide color palette across assets from different publishers, UV palette mapping is the stronger approach. For coloring models during creation, vertex colors are more natural. Both can coexist. | ENTRY-026, ENTRY-027 |
| 13 | When evaluating an asset ecosystem (multiple packages from one publisher), evaluate the core framework first, then integrations in dependency order. Malbers ecosystem order: AC (foundation) -> Inventory (depends on AC events/reactions) -> Ultimate Selector (depends on AC utilities only) -> Fishing for AC (depends on AC State class) -> content packs (depend on AC prefab structure). This reveals architectural patterns early (AC's Ryan Hipple ScriptableVar lineage = SOAP compatible) that inform all subsequent verdicts. Evaluating integrations before the core would miss the compatibility insight. | ENTRY-028 through ENTRY-032 |
| 14 | Third-party ScriptableObject variable systems that share the same Ryan Hipple GDC talk lineage as SOAP are compatible, not competing. Malbers AC implements ScriptableVar (FloatVar, IntVar, BoolVar, RuntimeGameObjects, etc.) with the same UseConstant/Variable toggle pattern as SOAP's ScriptableVariable. Both can coexist in the same project: use SOAP for game-wide architecture (events, game state, save data) and the third-party system for its own internal configuration. No bridge code needed - they operate in parallel namespaces. Check for the Ryan Hipple attribution comment before assuming any SO variable system conflicts with SOAP. | ENTRY-028 |
| 15 | A fishing game needs two separate systems: invisible simulation (bite timing, catch mechanics, difficulty) and visible behavior (animated fish swimming in the water). These systems should be decoupled and bridged through game events, not merged into one monolith. Fishing for AC handles the invisible half (casting, bobber, bite window, tug-of-war) while Fish Alive handles the visible half (schooling, target-following, feeding animation). Neither knows about the other. SOAP events bridge them: "bobber lands" sets Fish Alive targets, "fish caught" removes a visible fish. This separation means either system can be replaced or upgraded independently. | ENTRY-030, ENTRY-033 |
| 17 | When evaluating assets for an underground/cave environment, prioritize: (1) modular terrain pieces with cave modules, (2) rock/mineral props with crystals for visual identity, (3) spline-based river tools for underground waterways, (4) atmospheric VFX (fog, dust, ambient particles). Stalactites/stalagmites are a common gap in rock packs - plan to supplement with UModeler X or dedicated cave decoration packs. Same-publisher art packs (e.g., JustCreate's terrain + rocks) guarantee style consistency and should be evaluated together. | ENTRY-043 through ENTRY-046 |
| 18 | When a project uses a multi-package ecosystem from one publisher (Staggart: SW3, Dynamic Effects, Underwater Rendering, River Modeler), each new package has near-zero integration risk because the developer maintains cross-package compatibility. Evaluate these packages on their unique feature contribution rather than integration concerns. The Staggart water ecosystem at four packages is a mature, interoperable stack. | ENTRY-039 through ENTRY-041, ENTRY-045 |
| 16 | Before evaluating a specialized effect asset, check whether your existing rendering stack already covers the use case. A standalone ripple shader that replaces the water surface cannot coexist with a full water rendering system (SW3) that already includes ripple/displacement effects as an integrated extension. The standalone asset would require running on a separate mesh with separate shaders, losing every visual feature the main water system provides. Additionally, BiRP shaders (`CGPROGRAM`/`UnityCG.cginc`) are not compatible with URP projects -- verify render pipeline compatibility before any code review. | ENTRY-042 |
| 20 | MCP script-execute (Roslyn) is dramatically more capable than MCP component tools for complex setup. Component-add works for adding components by fully-qualified type name, but component-get and component-modify fail on many types (Canvas, UI components, third-party binders). Script-execute can do everything: create full UI hierarchies, add and configure components, wire serialized fields via reflection, initialize package systems, and verify results -- all in a single call. For any non-trivial scene setup, write a static C# method and execute it via Roslyn rather than fighting individual MCP component calls. Note: C# generics and && operators get HTML-encoded in the tool parameter -- use typeof() casts and nested if-statements instead. | ENTRY-050, ENTRY-051 |
| 21 | When evaluating packages from the same author as your MCP bridge (Ivan Murzak: MCP for Unity, Unity-Theme, Unity-ImageLoader), integration quality is higher because the developer understands both the package ecosystem and the MCP tooling. Unity-Theme and Unity-ImageLoader both have clean namespaces, proper asmdef isolation, and JSON-based persistence -- the same engineering discipline visible in MCP for Unity itself. Same-author packages share utility code patterns (Safe.cs, WeakAction.cs, ColorExtensions.cs, DebugLevel enum) creating a consistent codebase. | ENTRY-050, ENTRY-051 |
| 19 | Before evaluating a new AI/behavior system, map your actual AI needs against existing installed systems first. If every need is already covered (companion = Malbers AC AI Brain, fish = Fish Alive, ambient wildlife = polyperfect, NPCs = AC AI Brain or custom), a new AI engine adds architectural complexity with zero benefit. This is especially true when the new system has its own animation pipeline (Blaze AI name-based clips) that conflicts with your existing animation framework (Malbers AC states/modes/stances). Two parallel AI architectures on the same project is a maintenance burden, not a feature. | ENTRY-049 |
| 22 | Always check for duplication when evaluating an asset. If a new asset covers the same domain as an already-installed asset but does it better, the new asset replaces the old one. The old asset gets removed from the project and tagged "Don't use" in the Asset Store. One tool per job -- carrying two packages that solve the same problem doubles maintenance and creates ambiguity about which to use. The only exception is when two tools appear similar but actually operate at different levels (e.g., Lesson #9: PWB manual placement vs PGG procedural generation). | All |
| 26 | Re-evaluate asset Claude/AI capabilities when MCP tooling changes. Assets evaluated before MCP for Unity (Sessions 1-22) assessed "Claude cannot use this" based on pre-MCP limitations. With script-execute (Roslyn), any asset with a public C# API becomes Claude-accessible. DA PolyPaint went from "manual only" to "fully scriptable" -- its Painter class was always public but there was no way to call it until MCP existed. Audit older evaluations when MCP capabilities expand. | ENTRY-026, ENTRY-027 |

---

## Ivan Murzak Unity Tools Phase

Discovered via MCP for Unity creator Ivan Murzak's GitHub profile. Evaluating ecosystem of Unity development tools including UI utilities, AI-powered editor extensions, and package development templates.

---

#### ENTRY-050: Unity-Theme

| Field | Value |
|-------|-------|
| **Asset** | Unity-Theme |
| **Source** | GitHub (IvanMurzak) |
| **Version** | 4.2.0 |
| **Category** | UI |
| **Date Started** | 2026-02-11 |
| **Date Completed** | 2026-02-11 |
| **Verdict** | Approved |
| **HOK Applicable** | Yes |

**What It Does:**
Centralized color palette management with runtime theme switching. Themes define named colors (GUID-based references); 14+ component binders auto-apply colors to Image, TextMeshPro, Light, SpriteRenderer, MeshRenderer, SkinnedMeshRenderer, LineRenderer, Selectable/Button/Toggle (5-state ColorBlock), Outline, Shadow. Singleton access via `Theme.Instance`. JSON persistence at `Assets/Resources/Unity-Theme-Database.json`. Ships with Material Design 3 palette (Light/Dark themes, 23 colors). Editor window at `Window/Unity-Theme` (UIToolkit-based) with color picker, drag-reorder, undo/redo.

**What We Tested:**
Full code review of package source. Runtime API exercised via MCP script-execute: initialized theme system (confirmed 2 default themes, 23 MD3 colors), created 3 HOK river themes (Acheron, Phlegethon, Lethe) with per-river color palettes, added ImageColorBinder to 5 UI swatches via MCP, bound each to a named color via reflection on ColorBinderData.colorGuid, switched themes programmatically and verified all 5 Image.color values updated correctly per theme. Built full test UI scene (Canvas, panels, swatches, button, labels) via MCP Roslyn execution.

**Results:**
Everything works. Theme switching is instant -- `Theme.Instance.CurrentThemeName = "Acheron"` fires `onThemeChanged` event, all subscribed binders re-apply colors in the same frame. Color values confirmed correct across 3 theme switches (Acheron dark slate -> Phlegethon fiery red -> Lethe misty silver). Binders subscribe in OnEnable, unsubscribe in OnDisable -- zero leak risk. `[ExecuteAlways]` means binders work in edit mode without Play. JSON storage is human-readable and version-controllable. Partial class architecture keeps files small.

**Pros:**
- 14+ component binders cover all common UI/rendering targets
- GUID-based color references survive renames
- Instant runtime switching with event-driven auto-update
- Clean namespace (`Unity.Theme`, `Unity.Theme.Binders`) with proper asmdef isolation
- JSON persistence is human-readable and git-friendly
- Editor window with color picker, sort, reorder, undo/redo
- Alpha override per binder (useful for transparent panels sharing a base color)
- `[ExecuteAlways]` -- works in editor without Play mode
- Material Design 3 defaults provide a usable starting palette
- Weak references prevent memory leaks in observer pattern
- Debug level system (Trace through None) for controlled logging

**Cons:**
- uGUI only, no UI Toolkit binders (not a blocker -- HOK uses uGUI)
- Case-sensitive color name lookups (`"Primary"` works, `"primary"` returns null)
- Binder colorGuid is a private serialized field -- MCP component-modify cannot set it directly (requires reflection or inspector)
- No built-in transition/tween between themes (instant snap only -- DOTween could fill this gap)
- Editor window uses UIToolkit (not IMGUI) -- modern but may feel unfamiliar

**Integration Notes:**
Installed as local package from `E:\Unity\DefaultUnityPackages\Unity-Theme\`. No dependency conflicts. Namespace `Unity.Theme` does not collide with anything in the project. Asmdef properly isolated (runtime + editor). Works alongside SOAP -- Theme handles visual palette, SOAP handles game events. No conflict with Lean GUI -- binders operate on the same Image/Text components Lean GUI animates.

**Performance:**
Zero per-frame cost. Binders subscribe to events and only execute on theme change. Color comparisons skip identical values. No allocations during theme switch (colors stored as hex strings, parsed on demand). Suitable for mobile.

**Claude/MCP Capability Assessment:**

| Capability | Claude Can Do? | Notes |
|---|---|---|
| Initialize theme system | Yes | `Theme.Instance` via script-execute |
| Create/delete themes | Yes | `SetOrAddTheme()`, `RemoveTheme()` via script-execute |
| Set color values per theme | Yes | `SetOrAddColor()` with hex strings |
| Switch active theme | Yes | `CurrentThemeName = "X"` or `CurrentThemeIndex = N` |
| Query all colors/themes | Yes | `GetColors()`, `Themes`, `ThemeNames` |
| Create UI with binders | Yes | Build Canvas/panels/text via script-execute, add binders via component-add |
| Bind colors to binders | Partial | Requires reflection to set private `colorGuid` field -- works via script-execute but not via MCP component-modify |
| Use Theme Editor Window | No | Manual -- `Window/Unity-Theme` in Unity Editor |
| Pick colors visually | No | Manual -- color picker in editor window |
| Drag-reorder colors | No | Manual -- editor window only |
| Verify visual results | No | Manual -- need to look at Game/Scene view |

**Verdict Rationale:**
Approved. Clean architecture, zero runtime cost, proper asmdef isolation, event-driven binders that auto-update on theme switch. The HOK river theming use case is a natural fit -- define Acheron/Styx/Lethe/Cocytus/Phlegethon palettes, switch on scene load, and all UI elements update automatically. No transition tween is a minor gap that DOTween can fill. The GUID-based color references mean colors can be renamed freely without breaking bindings.

**HOK Notes:**
Primary use: per-river UI theming. Define 5 river themes + hub theme (Stygian Marsh). On scene load, `Theme.Instance.CurrentThemeName = riverName` switches all UI colors instantly. Bind HUD elements (health bar, inventory panel, codex background, merchant UI) to named palette colors. SOAP event channel can trigger theme switch on river enter/exit. Works alongside Lean GUI transitions -- Lean handles animation, Theme handles color. Consider adding a thin DOTween wrapper for smooth color transitions between rivers (e.g., 0.5s lerp on theme switch).

---

#### ENTRY-051: Unity-ImageLoader

| Field | Value |
|-------|-------|
| **Asset** | Unity-ImageLoader |
| **Source** | GitHub (IvanMurzak) |
| **Version** | 7.0.1 |
| **Category** | UI |
| **Date Started** | 2026-02-11 |
| **Date Completed** | 2026-02-11 |
| **Verdict** | Approved |
| **HOK Applicable** | Yes |

**What It Does:**
Production-grade async image loading library with dual-layer caching (RAM + disk), reference counting, and direct component consumption. Loads Texture2D or Sprite from URLs (web or local) via `ImageLoader.LoadSprite(url)` / `ImageLoader.LoadTexture(url)`. Returns `Future<T>` objects supporting async/await, UniTask, coroutines, and fire-and-forget patterns. Built-in consumers for Image, RawImage, SpriteRenderer, and Material. Placeholder system (loading/error/cancelled states). Component-based auto-cancellation (`CancelOnDestroy`, `CancelOnDisable`). Reference-counted memory management via `Reference<T>`. 39 public static methods. Disk cache at `Application.persistentDataPath/ImageLoader/`.

**What We Tested:**
Full code review of package source (Runtime/, Samples/, Tests/). Verified assembly loads in Unity domain (type found: `Extensions.Unity.ImageLoader.ImageLoader` in `Extensions.Unity.ImageLoader` assembly). Confirmed 39 public static API methods available. Verified settings object: `debugLevel=Warning`, `useMemoryCache=true`, `useDiskCache=true`, `timeout=30s`. Created test script (`AssetTestController.cs`) exercising LoadSprite with Consume pattern, CancelOnDestroy lifecycle, Loaded/Failed callbacks. Wired to 3 Image slots in test UI. Runtime Play mode test confirmed: all 3 images loaded successfully from picsum.photos, Loaded callbacks fired, Consume applied sprites to Image slots.

**Results:**
API is comprehensive and well-designed. The Future pattern is clean -- chain `.Loaded()`, `.Failed()`, `.Consume(image)`, `.CancelOnDestroy(this)`, `.Forget()` in a single fluent call. UniTask dependency already installed in project. 11 sample scripts demonstrate every use case clearly. Reference counting system prevents texture memory leaks. Per-future cache override (`SetUseMemoryCache(false)`, `SetUseDiskCache(false)`) enables fine-grained control. The `Consume()` extension methods directly target Image, RawImage, SpriteRenderer, and Material -- zero boilerplate for common cases.

**Pros:**
- Fluent API: `ImageLoader.LoadSprite(url).Consume(image).CancelOnDestroy(this).Forget()` -- one line
- Dual-layer cache: RAM (synchronous) + disk (persistent across sessions)
- Reference counting prevents texture memory leaks
- 5 async patterns: async/await, UniTask, Task, coroutine, event callbacks
- Built-in consumers for Image, RawImage, SpriteRenderer, Material (with custom property name)
- Placeholder system with per-state sprites (loading, error, cancelled)
- Component-based cancellation (CancelOnDestroy, CancelOnDisable, CancelOnEnable)
- Per-future configuration overrides (cache, debug level, timeout)
- Thread-safe (background loading, main-thread callbacks via UniTask.Post)
- Proper asmdef isolation (`Extensions.Unity.ImageLoader`)
- 11 sample scripts covering all use cases
- WebGL-aware (disk cache auto-disabled on WebGL)
- `ignoreImageNotFoundError` parameter for graceful 404 handling

**Cons:**
- Requires UniTask dependency (already installed -- not actually a con for this project)
- No built-in MonoBehaviour component for inspector-based loading (must write code)
- Disk cache uses PNG encoding -- lossy formats (JPG) get re-encoded to PNG on disk
- No built-in progress/percentage callback for large downloads
- Web loading requires Play mode -- cannot test in editor without entering Play

**Integration Notes:**
Installed as local package from `E:\Unity\DefaultUnityPackages\Unity-ImageLoader\`. Depends on UniTask (com.cysharp.unitask) -- already installed. No namespace conflicts. Asmdef properly isolated. Works alongside SOAP (load events could trigger via SOAP channels). No conflict with Easy Save 3 -- different storage locations (`persistentDataPath/ImageLoader/` vs Easy Save's path). Dialogue System portraits are typically direct Sprite references, not async-loaded -- ImageLoader would supplement, not replace.

**Performance:**
Memory cache hit: <1ms (synchronous dictionary lookup). Disk cache hit: 10-100ms (file I/O + PNG decode). Web download: network-dependent. Lock-protected cache access (minimal contention). Per-image RAM: width * height * bytes-per-pixel. Disk cache: PNG-compressed (50-80% of raw size). LimitedConcurrencyLevelTaskScheduler prevents download floods.

**Claude/MCP Capability Assessment:**

| Capability | Claude Can Do? | Notes |
|---|---|---|
| Write loading scripts | Yes | Full API access, compile via script-update-or-create |
| Configure global settings | Yes | `ImageLoader.settings.*` via script-execute |
| Query cache state | Yes | `CacheContains()`, `MemoryCacheContains()`, `DiskCacheContains()` |
| Clear caches | Yes | `ClearCacheAll()`, `ClearMemoryCacheAll()`, `ClearDiskCacheAll()` |
| Save to cache manually | Yes | `SaveToMemoryCache()`, `SaveToDiskCache()` |
| Create UI with Image slots | Yes | Via script-execute (Canvas, Image, RawImage) |
| Wire serialized references | Yes | Via reflection in script-execute |
| Load images at runtime | No | Requires Play mode -- Claude cannot press Play |
| Verify loaded images visually | No | Manual -- need to see Game view |
| Test placeholder system | No | Requires Play mode + visual verification |

**Verdict Rationale:**
Approved. The API is exactly what HOK needs for on-demand image loading: fluent, async, cached, and lifecycle-aware. The one-liner pattern (`LoadSprite(url).Consume(image).CancelOnDestroy(this).Forget()`) is production-ready with zero boilerplate. Dual-layer caching solves the codex portrait problem (40+ fish, loaded on-demand, cached across sessions). Reference counting prevents the most common Unity texture memory leak pattern. UniTask integration means it follows project async standards. The only limitation is that runtime testing requires Play mode, but the script is ready to run.

**HOK Notes:**
Primary use: Codex portrait loading. Fish/soul/merchant portraits loaded on-demand when player opens codex entry. RAM cache for quick re-access during same session, disk cache for persistence across play sessions. Secondary uses: merchant shop item icons, gear preview images, any UI that displays variable artwork. Pattern: store portrait URLs/paths in ScriptableObject fish data, load via `ImageLoader.LoadSprite(fishData.portraitUrl).Consume(codexImage).CancelOnDestroy(codexPanel).Forget()`. Consider pre-warming cache for current river's fish during loading screen. Disk cache location should be configured early: `ImageLoader.settings.diskSaveLocation = Application.persistentDataPath + "/HOK/ImageCache"`.

---

#### ENTRY-052: Unity-AI-Animation

| Field | Value |
|-------|-------|
| **Asset** | Unity-AI-Animation |
| **Source** | GitHub (IvanMurzak) / OpenUPM |
| **Package ID** | com.ivanmurzak.unity.mcp.animation |
| **Version** | 1.0.24 |
| **Category** | Tools (MCP Extension) |
| **Date Started** | 2026-02-11 |
| **Date Completed** | 2026-02-11 |
| **Verdict** | Conditional |
| **HOK Applicable** | Maybe |

**What It Does:**
MCP tool extension that adds 6 specialized animation tools to the AI Game Developer (MCP for Unity) base package. Provides structured, reliable access to AnimationClip and AnimatorController creation and modification -- more precise than writing ad-hoc Roslyn scripts via script-execute for the same operations.

**MCP Tools Provided (6):**

| Tool | What It Does |
|------|-------------|
| `animation-create` | Generate .anim asset files at specified paths |
| `animation-get-data` | Retrieve clip properties (curves, events, frame rate, wrap mode) via AssetObjectRef |
| `animation-modify` | Edit clips via AnimationModification[] array -- add/remove/modify curves, events |
| `animator-create` | Generate .controller asset files at specified paths |
| `animator-get-data` | Access controller structures (layers, states, parameters, transitions) via AssetObjectRef |
| `animator-modify` | Modify via AnimatorModification[] array -- add/remove layers, states, transitions, parameters |

**Technical Details:**
- C# 89.6%, PowerShell 10.4%, MIT license
- Depends on MCP for Unity base package (com.ivanmurzak.unity.mcp)
- Compatibility: Unity 2022.3, 2023.2, 6000.3 (all verified editmode/playmode/standalone)
- Install: `openupm add com.ivanmurzak.unity.mcp.animation` or .unitypackage installer
- **Installed and verified** in Sandbox (Session 27). 6 tools registered via [McpPluginToolType] assembly scanning.
- Runtime assembly has 12+ data model classes (AnimationKeyframe, AnimationModification, AnimatorConditionData, AnimatorLayerInfo, AnimatorStateInfo, AnimatorTransitionInfo, etc.)

**Hands-On Testing (Session 27 via script-execute):**

Tested the underlying Unity Animation API that these tools wrap:

| Test | Result | Lines of Code |
|------|--------|--------------|
| Create AnimationClip with curves | OK -- 2 position curves, 1 rotation curve, 1 event, loop settings | ~25 lines |
| Create AnimatorController | OK -- 3 parameters (Float, Bool, Trigger) | ~8 lines |
| Add states with transitions | OK -- 3 states (Idle/Walk/Jump), 4 transitions with conditions | ~20 lines |
| Read back and verify | OK -- all data persisted correctly, 6 curve bindings returned | ~10 lines |

Total: ~63 lines of script-execute code to do everything the 6 MCP tools cover.

**Value Over script-execute:**

| Operation | script-execute | MCP Tools | Winner |
|-----------|---------------|-----------|--------|
| Create AnimationClip | ~10 lines (new + SetCurve + save) | 1 tool call (animation-create) | **MCP** -- less code |
| Add curves to clip | ~5 lines per curve (AnimationCurve + SetCurve) | 1 tool call (animation-modify) | **Tie** -- both straightforward |
| Inspect complex state machine | ~30+ lines (iterate layers/states/transitions) | 1 tool call (animator-get-data) | **MCP** -- significant savings |
| Add states + transitions | ~15 lines (AddState + AddTransition + conditions) | 1 tool call (animator-modify) with array | **MCP** -- structured input |
| Ad-hoc / exploratory work | Flexible -- any C# code | Limited to tool parameters | **script-execute** |

Key finding: **animator-get-data is the primary value**. Inspecting a complex AnimatorController (like Malbers AC's, which has dozens of states and transitions) would require 30+ lines of reflection code via script-execute. The MCP tool returns structured data in one call.

**Integration Assessment:**
- Malbers AC uses its own State/Mode/Stance animation system with custom AnimatorControllers. These tools could inspect/modify AC's controllers but should be used carefully to avoid breaking AC's expected state machine structure.
- Fish Alive pack has pre-made animations. Tools could create swim speed variants without manual curve editing.
- polyperfect packs have their own animation systems (NOT AC-compatible). Tools could help bridge by creating new controllers that reference polyperfect model animations.

**Pros:**
- Zero runtime footprint (editor-only MCP extension)
- Compiles and registers correctly on Unity 6 (verified)
- animator-get-data provides significant value for inspecting complex state machines
- Structured modification arrays (AnimationModification[], AnimatorModification[]) prevent partial/invalid edits
- Rich data model classes (12+ types in Runtime assembly) give AI structured context
- Low installation cost (just adds tools to existing MCP)

**Cons:**
- Small community (23 stars)
- Most HOK animations come from asset packs, reducing immediate need
- Risk of modifying Malbers AC controllers in ways that break state machine expectations
- Tools not visible to Claude Code until session restart (Lesson #23)

**HOK Notes:**
Conditional -- install when animation work begins. Not needed during current design phase, but valuable when setting up AnimatorControllers for custom creatures, creating swim speed variants for fish species, or configuring soul passenger idle animations. Do NOT use on Malbers AC controllers without understanding AC's state machine conventions first. **Now installed in Sandbox** for verification; keep installed as zero-cost overhead.

---

#### ENTRY-053: Unity-AI-ParticleSystem

| Field | Value |
|-------|-------|
| **Asset** | Unity-AI-ParticleSystem |
| **Source** | GitHub (IvanMurzak) / OpenUPM |
| **Package ID** | com.ivanmurzak.unity.mcp.particlesystem |
| **Version** | 1.0.12 |
| **Category** | VFX (MCP Extension) |
| **Date Started** | 2026-02-11 |
| **Date Completed** | 2026-02-11 |
| **Verdict** | Conditional (compilation bug -- see below) |
| **HOK Applicable** | Maybe |

**What It Does:**
MCP tool extension that adds 2 specialized particle system tools to the AI Game Developer (MCP for Unity) base package. Provides structured get/modify access to all 24 ParticleSystem modules via ReflectorNet serialization.

**MCP Tools Provided (2):**

| Tool | What It Does |
|------|-------------|
| `particle-system-get` | Retrieve ParticleSystem state with per-module boolean flags (24 modules + includeAll + deepSerialization) |
| `particle-system-modify` | Update any module properties via SerializedMember per-module input (24 module parameters) |

**Supported Modules (24):**
Main, Emission, Shape, Velocity Over Lifetime, Limit Velocity Over Lifetime, Inherit Velocity, Lifetime By Emitter Speed, Force Over Lifetime, Color Over Lifetime, Color By Speed, Size Over Lifetime, Size By Speed, Rotation Over Lifetime, Rotation By Speed, External Forces, Noise, Collision, Trigger, Sub Emitters, Texture Sheet Animation, Lights, Trails, Custom Data, Renderer.

**Technical Details:**
- MIT license
- Depends on MCP for Unity base package (com.ivanmurzak.unity.mcp)
- Compatibility: Unity 2022.3, 2023.2, 6000.3 (claimed)
- Install: `openupm add com.ivanmurzak.unity.mcp.particlesystem` or .unitypackage installer
- **Installed in Sandbox** (Session 27) but **DOES NOT COMPILE** -- see Compilation Bug below

**Compilation Bug (Session 27):**
The package's Runtime folder (`com.IvanMurzak.Unity.MCP.ParticleSystem.Runtime` asmdef) contains NO .cs files -- only the asmdef and a .gitignore. The Editor asmdef references this Runtime assembly. In Unity 6, an asmdef with no source files produces no assembly, and any asmdef referencing it also fails to compile silently. Result: zero assemblies loaded, zero tools registered.

This is a packaging bug. The Animation package (which works) has 12+ .cs data model files in its Runtime folder. The ParticleSystem package's data models (`ParticleSystemData.cs`, `GetParticleSystemResponse.cs`, `ModifyParticleSystemResponse.cs`) are in the Editor folder instead, but they depend on the Runtime assembly existing. The fix would be either: (1) move data models to Runtime, or (2) remove the Runtime reference from the Editor asmdef. This should be reported upstream.

**Hands-On Testing (Session 27 via script-execute):**

Since the MCP tools don't compile, tested ParticleSystem API directly via script-execute:

| Test | Result | Lines of Code |
|------|--------|--------------|
| Create ParticleSystem + configure Main module | OK -- duration, loop, lifetime, speed, size, color, gravity | ~12 lines |
| Configure Emission module with bursts | OK -- rateOverTime, burst creation | ~6 lines |
| Configure Shape module (Cone) | OK -- shapeType, angle, radius | ~4 lines |
| Color over Lifetime (3-key gradient) | OK -- GradientColorKey/AlphaKey setup | ~12 lines |
| Size over Lifetime (AnimationCurve) | OK -- MinMaxCurve with custom curve | ~5 lines |
| Noise module | OK -- strength, frequency, quality | ~5 lines |
| Renderer settings | OK -- renderMode, material assignment | ~4 lines |
| Verify all 24 modules accessible | OK -- all 23 modules + Renderer accessible | ~23 lines |

Total: ~71 lines of script-execute code to create a complete campfire particle effect with 6 configured modules.

**Value Over script-execute (Design Analysis):**

| Operation | script-execute | MCP Tools (if working) | Winner |
|-----------|---------------|----------------------|--------|
| Get all module data | ~50+ lines (serialize each module) | 1 tool call with includeAll=true | **MCP** -- huge savings |
| Modify single module | ~5 lines (get module, set props) | 1 tool call with SerializedMember | **Tie** |
| Configure multiple modules | ~30 lines (proportional to modules) | 1 tool call with multiple params | **MCP** -- less code |
| MinMaxCurve/Gradient setup | Verbose but precise (~10 lines each) | SerializedMember abstraction | **MCP** -- eliminates boilerplate |
| Exploratory / custom logic | Full C# flexibility | Limited to tool params | **script-execute** |

Key finding: **particle-system-get with includeAll would be the primary value** -- inspecting a complete ParticleSystem's 24 modules requires ~50+ lines of serialization code via script-execute. The Modify tool's per-module SerializedMember approach is elegant but not dramatically better than direct property access. The bug prevents any of this from working.

**Integration Assessment:**
- SW3 Dynamic Effects provides water-specific displacement/wake/ripple effects (NOT particle-based). This tool handles Unity's built-in ParticleSystem, which is complementary.
- Environment/Weather/Nature VFX Pack (ENTRY-043, Conditional) is BiRP -- needs URP conversion. AI ParticleSystem could create URP-native particle effects from scratch faster than converting BiRP shaders.
- Low-poly art style means particle effects should be simple (small counts, basic shapes, limited color palettes).

**Pros:**
- Zero runtime footprint (editor-only MCP extension)
- 24-module coverage is comprehensive -- every ParticleSystem feature accessible (in design)
- Structured get with per-module boolean flags is well-designed for selective inspection
- Modify uses ReflectorNet.TryPopulate for safe partial updates (only touch what you specify)
- ParticleSystemData.cs has excellent [Description] attributes on all 24 module fields -- good AI context
- Low installation cost

**Cons:**
- **DOES NOT COMPILE** on Unity 6 due to empty Runtime assembly (packaging bug)
- Very small community (6 stars)
- No template/preset system -- each effect built from scratch
- script-execute works fine for all ParticleSystem operations (tested, all 24 modules accessible)
- Tools not visible to Claude Code until session restart even if fixed (Lesson #23)

**HOK Notes:**
Conditional -- the design is sound and the tool would add genuine value (especially particle-system-get for inspecting complex effects), but the compilation bug makes it non-functional. **Recommendation:** Keep installed (zero cost since it doesn't compile anyway), monitor for upstream fix. Meanwhile, use script-execute for all particle system work -- fully capable as demonstrated in hands-on testing. When VFX work begins for HOK (soul auras, ember particles, cave dust, splash effects), script-execute covers 100% of needs.

---

#### ENTRY-054: Unity-Package-Template

| Field | Value |
|-------|-------|
| **Asset** | Unity-Package-Template |
| **Source** | GitHub (IvanMurzak) |
| **Package ID** | N/A (template repository, not installable) |
| **Version** | 1.0 (56 commits) |
| **Category** | Tools (Development) |
| **Date Started** | 2026-02-11 |
| **Date Completed** | 2026-02-11 |
| **Verdict** | Deferred |
| **HOK Applicable** | No |

**What It Does:**
GitHub template repository for creating Unity packages with proper UPM structure. Includes CI/CD workflows (GitHub Actions for automated testing on PR, deployment on version bump), PowerShell init script, bump-version automation, and distribution setup for OpenUPM, GitHub, and npm.js registries.

**Package Structure Generated:**
```
<root>/
  package.json
  Runtime/        (compiled code)
  Editor/         (editor-specific scripts)
  Tests/          (test assemblies)
  Samples~/       (optional examples)
  Documentation~/
```

**Technical Details:**
- C# 70.2%, PowerShell 26.3%, Shell 3.5%
- MIT license
- 91 stars, actively maintained
- Not an installable package -- it's a GitHub "Use this template" repo

**Assessment:**
This is a reference resource, not something to install. TecVooDoo Utilities (`E:\Unity\DefaultUnityPackages\com.tecvoodoo.utilities\`) is already structured as a local UPM package. The template would only be needed if TecVooDoo packages are ever published to OpenUPM/npm.js for public distribution.

**Why Deferred (unchanged):**
Not applicable to current workflow. TecVooDoo Utilities is distributed as local file packages across projects -- no registry publishing needed. Bookmark for reference if/when TecVooDoo packages go public. No installation needed, no runtime impact.

---

#### ENTRY-055: Unity-AI-ProBuilder

| Field | Value |
|-------|-------|
| **Asset** | Unity-AI-ProBuilder |
| **Source** | GitHub (IvanMurzak) / OpenUPM |
| **Package ID** | com.ivanmurzak.unity.mcp.probuilder |
| **Version** | 1.0.24 |
| **Category** | Tools (MCP Extension) |
| **Date Started** | 2026-02-11 |
| **Date Completed** | 2026-02-11 (hands-on Session 26) |
| **Verdict** | Conditional |
| **HOK Applicable** | Yes (greyboxing) |

**What It Does:**
MCP tool extension that adds 13 specialized ProBuilder tools to the AI Game Developer (MCP for Unity) base package. Enables AI-driven 3D mesh creation and manipulation -- shape generation, face extrusion, edge beveling, material application, object merging, and advanced mesh operations.

**MCP Tools Provided (13 actual, verified via reflection):**

| Tool | Parameters | What It Does |
|------|-----------|-------------|
| `CreateShape` | shapeType, name, parent, position, rotation, scale, size, isLocalSpace | Generate primitive shapes (Cube, Cylinder, Arch, Stair, Door, Pipe, etc.) |
| `CreatePolyShape` | points[][], height, name, parent, position, rotation, flipNormals | Create custom polygon-based extruded meshes from 2D point arrays |
| `GetMeshInfo` | gameObjectRef, detail, includeVertexPositions, includeEdges, maxFaces | Read mesh data (faces, vertices, edges) with configurable detail level |
| `Extrude` | gameObjectRef, faceIndices, faceDirection, distance, extrudeMethod | Extrude faces by index or semantic direction |
| `Bevel` | gameObjectRef, edges[][], amount | Bevel edge operations |
| `Bridge` | gameObjectRef, edgeA[], edgeB[], allowNonManifold | Bridge between two edges |
| `ConnectEdges` | gameObjectRef, edges[][], faceDirection | Connect edges with geometry creation (subdivision) |
| `DeleteFaces` | gameObjectRef, faceIndices, faceDirection | Delete faces by index or semantic direction |
| `FlipNormals` | gameObjectRef, faceIndices, faceDirection | Flip normal directions on selected faces |
| `SetFaceMaterial` | gameObjectRef, materialPath, faceIndices, faceDirection | Apply materials to specific faces by index or direction |
| `SetPivot` | gameObjectRef, pivotLocation, customPosition | Adjust pivot point (Center, FirstVertex, etc.) |
| `MergeObjects` | gameObjectRef[], deleteSourceObjects | Merge multiple ProBuilder objects into one |
| `SubdivideEdges` | gameObjectRef, edges[][], faceDirection, subdivisions | Subdivide edges with configurable count |

**Helper Types:**
- `FaceDirection` enum: Select faces by semantic direction (Up, Down, Left, Right, Forward, Back) instead of by index
- `MeshInfoDetailLevel` enum: Control how much mesh data GetMeshInfo returns
- `MeshPivotLocation` enum: Pivot point presets
- `FaceSelectionHelper`: Calculates face normals and categorizes faces by direction automatically

**Technical Details:**
- Apache-2.0 license (note: different from MIT used by other IvanMurzak packages)
- Depends on MCP for Unity base + Unity ProBuilder package
- Compatibility: Unity 2022.3, 2023.2, 6000.3 (all verified)
- Install: `openupm add com.ivanmurzak.unity.mcp.probuilder` or .unitypackage installer
- 22 stars
- Assembly: `com.IvanMurzak.Unity.MCP.ProBuilder.Editor` (includes test assemblies)
- Clean install: no errors, no warnings from the package itself

**Hands-On Testing (Session 26):**

Installed via MCP package-add. Package installed cleanly with domain reload. Verified assembly loading and tool registration via Roslyn reflection. All 13 tools are registered on the Unity side.

**Important discovery:** MCP extension tools installed mid-session are NOT visible to Claude Code until session restart. Claude Code caches the MCP tool list at session startup. The tools are registered server-side (confirmed via reflection) but Claude Code won't see them until it re-queries the tool list. This means installing an MCP extension requires a Claude Code restart to use the new tools natively.

Tested all ProBuilder operations via script-execute as a baseline:
- Shape creation: Cube, Cylinder, Arch, Stair, Door, Plane -- all work
- Face extrusion: Extrude top face by 2 units -- SUCCESS (6 faces -> 10)
- Face deletion: Delete top face of cube -- SUCCESS (6 faces -> 5, open box)
- Material assignment: Per-face submesh materials (red sides, blue top) -- SUCCESS
- Edge connection: ConnectElements.Connect -- SUCCESS (6 faces -> 10, subdivided)
- PolyShape: Custom 10-point cave room, extruded to 4 units -- SUCCESS (60 verts, 12 faces)
- L-shape floor: Non-convex polygon creation -- SUCCESS
- Full cave greybox: 7-part scene (floor, walls, ceiling, arch, pillar, ledge) -- SUCCESS

**Value Over script-execute (updated with hands-on experience):**

| Aspect | script-execute | AI-ProBuilder MCP Tools |
|--------|---------------|------------------------|
| Face selection | Manual: iterate faces, compute normals, compare vectors (6+ lines) | FaceDirection enum: just say "Up" (1 parameter) |
| Shape creation | Must know exact API: GenerateCube vs GenerateCylinder vs GenerateArch (different signatures) | Unified CreateShape with ShapeType enum |
| Batch operations | One script call for entire scene (efficient) | One tool call per operation (more overhead) |
| Error isolation | One error aborts entire script | Each tool call succeeds or fails independently |
| API knowledge | Must know Unity 6 ProBuilder API (changed from Unity 5/2022) | Tools abstract away API differences |
| Custom shapes | Must use PolyShape component + SetControlPoints + CreateShapeFromPolygon | CreatePolyShape with simple points array |
| Mesh inspection | Must write reflection/iteration code | GetMeshInfo with configurable detail level |

**Key finding:** The FaceDirection helper is the single biggest value-add. In script-execute, selecting faces by direction requires 6+ lines of normal calculation code per operation. The MCP tools reduce this to a single parameter. For iterative greyboxing workflows ("extrude the top face," "delete the front face," "apply this material to all left-facing faces"), this is a significant productivity improvement.

**Limitations:**
- Batch efficiency: Building a 7-part cave took 1 script-execute call; with MCP tools it would take 7+ calls
- Mid-session install: Must restart Claude Code to access new tools (not a package issue, MCP limitation)
- No "undo" tool: Individual operations can't be rolled back through MCP
- ProBuilder API knowledge still useful: For complex multi-step operations, script-execute with full C# is more powerful

**Verdict Change: Deferred -> Conditional**

Upgraded from Deferred to Conditional. The hands-on testing revealed genuine value for greyboxing workflows, specifically the FaceDirection-based face selection which eliminates the most tedious part of script-execute ProBuilder work. The ideal workflow is hybrid: script-execute for initial batch scene setup, then MCP tools for iterative face-level refinement.

**When to install:** When HOK greyboxing begins in earnest (Acheron scene layout, cave interiors, terrain blocking). The tools complement rather than replace script-execute -- use both.

**ProBuilder API Notes for script-execute (Unity 6):**
- Use `ShapeGenerator.GenerateCube/GenerateCylinder/GenerateArch/etc.` (not GenerateShape)
- `positions` returns `IList<Vector3>` (not ReadOnlyCollection)
- Always call `ToMesh()` then `Refresh()` after modifications
- Avoid `using UnityEditor.ProBuilder;` -- `EditorUtility` conflicts with `UnityEditor.EditorUtility`
- Face normals: `UnityEngine.ProBuilder.Math.Normal(v0, v1, v2)` on first 3 indexes of face
- Default material is transient and shows pink (null) in URP -- always assign a URP/Lit material explicitly after shape creation
- `fixed` is a C# keyword -- do not use as a variable name in Roslyn scripts

---

#### ENTRY-056: MCP for Unity / AI Game Developer (IvanMurzak)

| Field | Value |
|-------|-------|
| **Asset** | AI Game Developer -- Unity MCP |
| **Source** | OpenUPM (IvanMurzak) |
| **Version** | 0.46.0 |
| **Category** | Tools |
| **Date Started** | 2026-02-06 (in use since Session 3) |
| **Date Completed** | 2026-02-11 (formal evaluation) |
| **Verdict** | Approved - Default |
| **HOK Applicable** | Yes |

**What It Does:**
AI-powered bridge connecting LLMs (Claude Code, Claude Desktop, Cursor, Windsurf, Copilot, etc.) to the Unity Editor via the Model Context Protocol (MCP). Exposes 52 editor tools across 10 categories, enabling AI agents to create/modify GameObjects, manage scenes, read/write scripts, execute arbitrary C# via Roslyn compilation, manage packages, run tests, control editor state, and query the console. Uses SignalR for real-time communication. Runs entirely in the editor domain -- zero runtime footprint in builds. Apache 2.0 license.

**What We Tested:**
Extensively battle-tested across 22+ sessions. Used for: scene construction (Acheron greybox -- 35+ objects via script-execute), component setup (UI hierarchies, binders, serialized field wiring), script authoring (AssetTestController.cs, AcheronSceneBuilder.cs, RiverSplineSetup.cs), asset queries (shader lists, prefab searches, material creation), theme system setup (Unity-Theme initialization, 3 HOK river themes), image loader wiring (serialized references via reflection), and console log retrieval for debugging.

**Results:**
The package is the single most impactful tool in the Sandbox workflow. It transforms Claude from a code suggestion engine into an active Unity editor operator. The 52 tools break down as follows:

**Tool Inventory (52 tools across 10 categories):**

| Category | Count | Tools |
|----------|-------|-------|
| **Assets** | 16 | find, find-built-in, get-data, copy, move, delete, modify, create-folder, refresh, material-create, shader-list-all, prefab-create, prefab-open, prefab-close, prefab-save, prefab-instantiate |
| **GameObject** | 7 | create, find, destroy, duplicate, modify, set-parent |
| **Component** | 5 | add, get, destroy, modify, list-all |
| **Scene** | 7 | create, open, list-opened, get-data, set-active, save, unload |
| **Script** | 4 | execute (Roslyn), read, update-or-create, delete |
| **Reflection** | 2 | method-find, method-call |
| **Console** | 1 | get-logs |
| **Editor** | 4 | application-get-state, application-set-state, selection-get, selection-set |
| **Package** | 4 | add, remove, list, search |
| **Object** | 2 | get-data, modify |

**Tool Capability Tiers (from field experience):**

| Tier | Tools | Reliability |
|------|-------|-------------|
| **Tier 1 - Bulletproof** | script-execute, script-update-or-create, script-read, gameobject-create, gameobject-find, assets-find, scene-open, scene-save, console-get-logs, package-list | 95%+ success rate, used daily |
| **Tier 2 - Reliable** | component-add, gameobject-modify, gameobject-destroy, assets-refresh, scene-get-data, editor-application-get-state, reflection-method-find | 80%+ success, occasional edge cases |
| **Tier 3 - Situational** | component-get, component-modify, object-get-data, object-modify, gameobject-set-parent | 50-70% success, fails on complex types (Canvas, UI, third-party components) |
| **Tier 4 - Untested** | assets-prefab-*, tests-run, editor-selection-*, package-add/remove/search, scene-create, assets-material-create | Not yet exercised in this project |

**The script-execute Superpower:**
The most important tool by far. Roslyn-based C# compilation and execution in the editor domain. Bypasses every limitation of the component tools by executing arbitrary code with full access to:
- All loaded assemblies (Unity, third-party packages, project code)
- UnityEditor APIs (EditorUtility, AssetDatabase, SerializedObject, Undo)
- Reflection (private fields, serialized backing fields, internal APIs)
- Scene hierarchy manipulation (full GameObject/Component create/configure/wire)

Pattern: Write a `public class Script { public static object Main() { ... } }` method that does everything in one shot. Returns serialized results. This single tool replaces chaining 5-10 individual component/gameobject tools and works on types where component-get/modify fail.

**Pros:**
- 52 tools covering the full Unity editor surface area
- script-execute (Roslyn) is extraordinarily capable -- arbitrary C# with full assembly access
- Zero runtime footprint -- editor-only with proper asmdef isolation (`includePlatforms: ["Editor"]`)
- Apache 2.0 license -- no commercial restrictions
- Same author as Unity-Theme and Unity-ImageLoader -- consistent engineering quality
- Partial class architecture keeps source files small and organized (311 C# files, well-structured)
- Proper namespace discipline (`com.IvanMurzak.Unity.MCP.Editor`, `com.IvanMurzak.Unity.MCP.Runtime`)
- 5 asmdefs with correct platform isolation
- SignalR transport -- real-time bidirectional communication, auto-reconnect
- JSON converters for all Unity struct types (Vector2/3/4, Color, Quaternion, Rect, Bounds, Matrix4x4)
- Reflection converters for Unity Object types (GameObject, Component, Material, Texture, Sprite)
- Thread-safe (mutex-protected singleton, MainThread dispatcher for Unity API calls)
- Configurable logging (Debug through None via LogLevel enum)
- Active development -- 0.46.0 from 0.1.0 initial, rapid iteration
- OpenUPM distribution with scoped registry -- clean package management
- Minimum Unity 2022.3 -- broad compatibility

**Cons:**
- MCP connection drops during Unity domain reload (script compilation, enter/exit Play mode) -- reconnects automatically but can lose in-flight requests
- component-get and component-modify fail on many complex types: Canvas, CanvasScaler, GraphicRaycaster, UI components, third-party MonoBehaviours with custom serialization
- C# generics (`<>`) and `&&` operators get HTML-encoded in script-execute parameters -- must use `typeof()` casts and nested if-statements as workarounds
- Roslyn scripts execute in editor domain but changes are not auto-persisted -- must explicitly call `.Save()`, `EditorUtility.SetDirty()`, or `AssetDatabase.SaveAssets()`
- Private serialized fields (common in third-party packages) require reflection workarounds in script-execute
- No visual verification capability -- cannot see Scene/Game view, must infer correctness from return values
- Large dependency tree (14 NuGet packages including SignalR, Roslyn, R3, Microsoft.Extensions.*)
- CHANGELOG.md is minimal (only 2 entries covering early versions, not current 0.46.0)
- 104 MB package size (mostly Roslyn compiler DLLs)
- Cannot enter Play mode or interact with runtime state (editor-only bridge)

**Integration Notes:**
Installed via OpenUPM scoped registry (`com.ivanmurzak` scope). Dependencies resolve automatically via OpenUPM (`org.nuget.*` scope). No conflicts with any installed package. The NuGet dependency tree (SignalR, Roslyn, Microsoft.Extensions) is isolated within the package's asmdef -- no namespace collisions with project code or other packages.

**Compatibility with Installed Assets:**

| Asset | Compatibility | Notes |
|-------|--------------|-------|
| **Malbers AC** | Good | Can add/configure AC components via script-execute. Cannot use component-modify on AC's custom inspectors. |
| **Stylized Water 3** | Good | Created SW3 materials, configured properties via script-execute. Component tools fail on SW3's complex shader property types. |
| **Unity-Theme** | Excellent | Same author. Initialized themes, created palettes, bound colors all via script-execute. |
| **Unity-ImageLoader** | Excellent | Same author. Wired serialized references via reflection in script-execute. |
| **Odin Inspector** | Neutral | Odin's custom drawers don't affect MCP tool behavior. Serialization differences not observed. |
| **SOAP** | Good | ScriptableObject assets queryable via assets-find/get-data. Event channels work normally. |
| **UniTask** | Neutral | No interaction. UniTask is runtime-only; MCP is editor-only. |
| **River Modeler** | Good | Created spline knots and configured river mesh via script-execute. |
| **JustCreate Packs** | Good | Prefab instantiation via assets-prefab-instantiate works. Bulk placement via script-execute. |

**Performance:**
Zero runtime impact -- entirely editor-domain. Editor overhead: SignalR WebSocket connection consumes minimal resources when idle. script-execute has ~100-500ms latency per call (Roslyn compilation + execution). Component tools are faster (~50-100ms) but less capable. No measurable impact on editor frame rate or responsiveness during normal use.

**Claude/MCP Capability Assessment:**

| Capability | Claude Can Do? | Notes |
|---|---|---|
| Create GameObjects with hierarchy | Yes | gameobject-create or script-execute |
| Add/configure components | Yes | component-add + script-execute for configuration |
| Read/write C# scripts | Yes | script-read, script-update-or-create |
| Execute arbitrary C# | Yes | script-execute (Roslyn) -- the power tool |
| Query asset database | Yes | assets-find, assets-get-data |
| Create/modify materials | Yes | assets-material-create, script-execute |
| Open/save scenes | Yes | scene-open, scene-save |
| Inspect scene hierarchy | Yes | scene-get-data, gameobject-find |
| Read console logs | Yes | console-get-logs |
| Control Play mode | Yes | editor-application-set-state (start/stop/pause) |
| Run unit tests | Yes | tests-run (EditMode/PlayMode) |
| Manage packages (UPM) | Yes | package-add/remove/list/search |
| Wire serialized references | Partial | Requires reflection in script-execute; component-modify fails on many reference types |
| Modify third-party components | Partial | script-execute with reflection works; component-modify often fails |
| See visual results | No | Cannot view Scene/Game/Inspector -- must infer from data |
| Interact with runtime gameplay | No | Editor-only bridge; cannot play-test |
| Use Prefab World Builder | No | PWB is a manual mouse-driven tool |
| Use UModeler X | No | UModeler X requires mouse interaction |

**Verdict Rationale:**
Approved - Default. This package is foundational infrastructure, not optional tooling. Every AI-assisted Unity workflow in Sandbox depends on it. The 52-tool surface area covers asset management, scene construction, script authoring, and editor control. The script-execute Roslyn tool alone justifies the package -- it turns Claude into a Unity editor operator capable of arbitrary scene setup, component configuration, and asset manipulation. The component-get/modify limitations on complex types are a real weakness, but script-execute provides a complete workaround. Same-author provenance as Unity-Theme and Unity-ImageLoader confirms engineering quality. Zero runtime footprint means zero build risk. Apache 2.0 license means zero commercial risk. The only genuine concern is the domain-reload disconnect, which is a Unity platform limitation more than a package bug.

**HOK Notes:**
**Critical infrastructure for all HOK development.** Every scene build (Acheron greybox), every asset evaluation (theme testing, image loader wiring), and every editor tool script was created or executed through this MCP bridge. For HOK migration: install this package first, then use it to bootstrap everything else. The HOK project currently has the old coplay Unity MCP (v9.0.7) which should be replaced with Ivan Murzak's AI Game Developer (com.ivanmurzak.unity.mcp v0.46.0). The coplay MCP was unreliable and has been superseded. Default package designation means it ships with every new TecVooDoo Unity project.

**Key Lessons (consolidated from 22+ sessions):**
1. **script-execute first, component tools second.** For any non-trivial setup, write a complete C# script and execute via Roslyn. It's more reliable, more capable, and often faster than chaining individual tool calls.
2. **HTML encoding workaround.** C# generics (`List<int>`) become `List&lt;int&gt;` in MCP params. Use `typeof()` casts. `&&` becomes `&amp;&amp;` -- use nested if-statements.
3. **Explicit persistence.** Roslyn scripts run in memory. Scene changes need `EditorSceneManager.SaveScene()`. Asset changes need `AssetDatabase.SaveAssets()`. ScriptableObject changes need `.Save()` or `EditorUtility.SetDirty()` + `AssetDatabase.SaveAssets()`.
4. **Domain reload kills connection.** When Unity recompiles scripts (after script-update-or-create, package install, etc.), the MCP connection drops. Wait for reconnection before issuing the next command. If connection doesn't restore, use Unity menu to manually restart.
5. **Reflection for private fields.** Many third-party packages use `[SerializeField] private` fields (e.g., Unity-Theme's ColorBinderData.colorGuid). Access via `typeof(T).GetField("fieldName", BindingFlags.NonPublic | BindingFlags.Instance)` in script-execute.

---

#### ENTRY-057: Unity-AI-Tools-Template

| Field | Value |
|-------|-------|
| **Asset** | Unity-AI-Tools-Template |
| **Source** | GitHub (IvanMurzak) |
| **Package ID** | N/A (template repository, not installable) |
| **Version** | 1.0 (56 commits) |
| **Category** | Tools (Development) |
| **Date Started** | 2026-02-11 |
| **Date Completed** | 2026-02-11 |
| **Verdict** | Deferred (template itself) -- but project-internal custom tools are Approved |
| **HOK Applicable** | Yes (the concept, not the template) |

**What It Does:**
GitHub template repository for creating custom MCP tools for Unity. Provides scaffolding to build new tools that integrate with the AI Game Developer (MCP for Unity) platform. Supports both editor-focused and runtime tools. Includes CI/CD workflows, init scripts with auto-renaming, and meta file generation.

**Technical Details:**
- C# 70.2%, PowerShell 26.3%, Shell 3.5%
- MIT license
- 10 stars, 2 forks
- Not an installable package -- GitHub "Use this template" workflow
- Six-step setup: create repo from template, clone, run init, configure package.json, generate metas, add tool code

**Hands-On Deep Dive (Session 26):**

The template itself is UPM package scaffolding for distributing tools publicly. But the critical discovery is that **you do not need the template to create custom MCP tools**. The MCP for Unity assembly scanner (`UnityMcpPlugin.Build.cs`) scans ALL loaded assemblies for classes decorated with `[McpPluginToolType]`. Any editor script in `Assets/` with the right attributes is auto-discovered.

**Custom Tool Pattern (~30-90 lines per tool):**
```csharp
using System.ComponentModel;
using com.IvanMurzak.McpPlugin;
using com.IvanMurzak.Unity.MCP.Editor.API;

[McpPluginToolType]
[Description("Tools for HOK-specific scene and asset operations")]
public class Tool_HOK
{
    [McpPluginTool("hok-polypaint-remap", Title = "HOK / PolyPaint Remap")]
    [Description("Remap a mesh's vertex colors to a new palette texture")]
    public string RemapToPalette(
        [Description("Path to the target mesh asset")] string meshPath,
        [Description("Path to the palette texture")] string palettePath
    )
    {
        return MainThread.Instance.Run(() =>
        {
            // ... implementation using DA PolyPaint Painter API ...
            return "Success: remapped mesh to palette";
        });
    }
}
```

**Key Pattern Details:**
- `[McpPluginToolType]` on the class -- assembly scanner finds it
- `[McpPluginTool("id", Title="...")]` on each method -- registers as a callable tool
- `[Description("...")]` on class, method, and each parameter -- LLM reads these for tool discovery
- `MainThread.Instance.Run(() => { })` wraps Unity API calls for thread safety
- Return type is serialized as the tool response (string, List, custom types)
- ~40-45% of lines are boilerplate (attributes, descriptions, thread wrapping)

**Custom Tools vs Script-Execute Comparison:**

| Factor | Custom Tool | Script-Execute (Roslyn) |
|--------|-------------|------------------------|
| Parameters | Typed, named, described | Raw C# string |
| HTML encoding | No issues | `<>` and `&&` get encoded |
| Compilation | Pre-compiled | Roslyn compiles each call |
| LLM discovery | Auto-discovered with descriptions | Must know to write C# |
| Safety | Constrained to declared params | Arbitrary code execution |
| Flexibility | Fixed operations | Unlimited |
| Setup cost | ~30-90 lines per tool | Zero |

**Verdict: When to use which:**
- **Script-execute**: Ad-hoc operations, exploration, one-off scene setup, anything novel
- **Custom tools**: Repeated multi-step workflows, operations involving third-party APIs with quirky calling conventions (DA PolyPaint, Malbers AC), operations that benefit from typed parameters

**Potential HOK Custom Tools:**

| Tool ID | What It Would Do | Wraps |
|---------|-----------------|-------|
| `hok-polypaint-remap` | Batch remap mesh face colors to palette texture | DA PolyPaint Painter.RemapTo() |
| `hok-umodeler-combine` | Combine multiple meshes into single optimized mesh | UModeler X MeshOpsCombine |
| `hok-creature-setup` | Configure Malbers AC animal with HOK-standard states | Malbers AC reflection |
| `hok-scene-zone` | Set up a river zone with terrain, water, spawn points | Multi-asset orchestration |

**Required asmdef Setup (verified working):**
Project-internal tools need an editor asmdef with:
- Assembly references: `com.IvanMurzak.Unity.MCP.Editor`, `com.IvanMurzak.Unity.MCP.Runtime`
- Precompiled references: `McpPlugin.dll` (for `[McpPluginToolType]`/`[McpPluginTool]` attributes), `ReflectorNet.dll` (for `MainThread.Instance.Run()`)
- `overrideReferences: true`, `includePlatforms: ["Editor"]`
- `autoReferenced: false` (editor-only tools should not be pulled into runtime)
- `MainThread` lives in `com.IvanMurzak.ReflectorNet.Utils` namespace (not in MCP namespace)

**Why Template Stays Deferred / Concept is Approved:**
The template adds CI/CD, UPM packaging, and public distribution scaffolding -- none of which HOK needs. But the underlying concept of project-internal custom MCP tools is immediately valuable. Any class with `[McpPluginToolType]` in a loaded editor assembly gets discovered. The asmdef structure has been created at `Assets/Sandbox/HOK/Scripts/Editor/McpTools/` to support this.

---

#### ENTRY-058: Unity-EFCore-SQLite

| Field | Value |
|-------|-------|
| **Asset** | Unity-EFCore-SQLite |
| **Source** | GitHub (IvanMurzak) / OpenUPM |
| **Package ID** | extensions.unity.bundle.efcore.sqlite |
| **Version** | 0.1.1 |
| **Category** | Data |
| **Date Started** | 2026-02-11 |
| **Date Completed** | 2026-02-11 |
| **Verdict** | Deferred |
| **HOK Applicable** | Maybe |

**What It Does:**
Ready-to-use bundle integrating EntityFrameworkCore 5.0.17 and SQLite into Unity. Cross-platform (Windows, Android, iOS, macOS). Code-first approach with C# data models, DbContext, and factory pattern. Handles SQLitePCLRaw initialization automatically. Supports AOT compilation (IL2CPP) with nested link.xml files to prevent stripping.

**Technical Details:**
- C# 78.8%, MIT license
- 24 stars, 4 forks, 59 commits
- IL2CPP only (Mono not supported)
- .NET Standard 2.0/2.1 compatible (.NET Framework not supported)
- EntityFrameworkCore locked to 5.0.17 due to Unity .NET Standard 2.1 limitations
- Install: `openupm add extensions.unity.bundle.efcore.sqlite`

**Potential HOK Use Cases:**
- Creature catalog persistence (45+ species, catch history, stats)
- Progression tracking (river unlocks, merchant inventory, soul delivery records)
- Fish codex data (species discovered, sizes caught, rarity tiers)
- Save game data with relational queries

**Duplication Check:**
No existing database package installed. Unity's built-in PlayerPrefs is flat key-value only. PlayerPrefsEx (see ENTRY-059) adds encryption but is still key-value. SQLite provides relational queries, joins, and structured schemas -- different tier of data management entirely.

**Integration Concerns:**
- EntityFrameworkCore 5.0.17 is old (current EFCore is 9.x) -- limited feature set
- IL2CPP only means Mono builds won't work (not an issue for shipping but affects some dev workflows)
- HOK's data layer isn't designed yet -- the GDD doesn't specify a persistence strategy
- SOAP architecture uses ScriptableObjects for runtime data flow, but SO-based persistence has known limitations for complex relational data
- Adds significant dependency weight (EFCore + SQLite native libraries)

**Why Deferred:**
HOK's data/persistence architecture isn't designed yet. The GDD (v1.6) covers gameplay systems but hasn't addressed save games, data persistence, or offline storage strategy. When the data layer is designed (likely post-MVP scoping), evaluate whether SQLite + EFCore is the right approach vs simpler alternatives (JSON files, ScriptableObject serialization, or Unity's built-in persistence). The EFCore 5.0.17 version lock is a yellow flag -- it's 4 major versions behind and won't benefit from performance improvements or new features in EFCore 6-9.

---

#### ENTRY-059: Unity-PlayerPrefsEx

| Field | Value |
|-------|-------|
| **Asset** | Unity-PlayerPrefsEx |
| **Source** | GitHub (IvanMurzak) / OpenUPM |
| **Package ID** | extensions.unity.playerprefsex |
| **Version** | 2.1.2 (installed as MCP dependency) |
| **Category** | Data |
| **Date Started** | 2026-02-11 |
| **Date Completed** | 2026-02-11 |
| **Verdict** | Conditional |
| **HOK Applicable** | Maybe |

**What It Does:**
Extended PlayerPrefs wrapper with encryption and additional type support. Wraps Unity's native PlayerPrefs system with AES-256 encryption, device-specific keys, and support for types beyond int/float/string: BigInteger, DateTime, Vector2/3 variants, and generic JSON serialization for custom data models.

**Technical Details:**
- MIT license, 45 stars, 82 commits
- Zero dependencies (beyond Unity itself)
- Already installed in Sandbox as depth-1 dependency of MCP for Unity
- Dual API: static methods (`PlayerPrefsEx.SetInt()`) and variable instances (`PlayerPrefsInt`, `PlayerPrefsJson<T>`)
- AES-256 encryption optional per-key
- Device-specific encryption keys prevent cross-device data transfer
- Install: `openupm add extensions.unity.playerprefsex` (already resolved via MCP dependency)

**Extended Type Support:**
- Standard: int, float, bool, string
- Extended: BigInteger, DateTime, Vector2, Vector2Int, Vector3, Vector3Int
- Generic: `PlayerPrefsJson<T>` for any serializable class

**Duplication Check:**
No duplication. Unity's built-in PlayerPrefs handles int/float/string only with no encryption. PlayerPrefsEx extends (doesn't replace) PlayerPrefs with encryption and broader type support. Both can coexist since PlayerPrefsEx wraps the same underlying storage.

**Assessment:**
Already installed and working (MCP dependency). Zero-cost addition since it's already in the project. The encryption feature is valuable for save data tamper prevention -- even a cozy fishing game benefits from protecting progression data. The `PlayerPrefsJson<T>` generic serialization is useful for storing complex objects without a full database.

**Integration Concerns:**
- PlayerPrefs-based storage has size limits (varies by platform, typically ~1MB)
- Not suitable for large datasets (creature catalogs, extensive catch history) -- use SQLite (ENTRY-058) or file-based storage for that
- Device-specific encryption means save data isn't portable between devices
- For HOK: good for settings, preferences, simple progression flags. Not for the full save game system.

**HOK Notes:**
Conditional -- already installed, zero cost to use. Good for player settings (audio volume, UI preferences, control bindings), simple progression flags (river unlocked, tutorial completed), and small encrypted data (purchase receipts, anti-cheat tokens). For full save game data, a more robust persistence solution will be needed (JSON files, SQLite, or cloud save). Use PlayerPrefsEx for the lightweight stuff, design the heavy persistence separately.

---

#### ENTRY-060: Unity-Extensions

| Field | Value |
|-------|-------|
| **Asset** | Unity-Extensions |
| **Source** | GitHub (IvanMurzak) / npm |
| **Package ID** | extensions.unity.base (+ 6 sub-modules) |
| **Version** | 1.9.0 (base) |
| **Category** | Tools (Utility) |
| **Date Started** | 2026-02-11 |
| **Date Completed** | 2026-02-11 |
| **Verdict** | Rejected (as package) -- 7 cherry-pick patterns for TecVooDoo Utilities |
| **HOK Applicable** | No (package), Yes (cherry-picked patterns via TecVooDoo Utilities) |

**What It Does:**
Collection of modular Unity extension packages distributed via npm. Each module is independently installable. Seven modules total covering base extensions, data saving, networking, IAP, reactive extensions, UI extensions, and shape utilities.

**Available Modules:**

| Module | Package ID | Version | What It Does |
|--------|-----------|---------|-------------|
| Base | `extensions.unity.base` | 1.9.0 | Core utility extensions (~170+ methods, 26 files) |
| Saver | `extensions.unity.saver` | 1.0.6 | Data persistence with device encryption |
| Network REST | `extensions.unity.network` | 1.3.3 | REST API client (SOLID principles) |
| IAP Store | `extensions.unity.iap.store` | 2.0.6 | In-app purchase wrapper |
| UniRx Extensions | `extensions.unity.unirx` | 1.1.5 | Reactive extensions for UniRx |
| UI Extensions | `extensions.unity.ui` | 1.3.2 | UI utility extensions (~48 methods, DOTween transition system) |
| Shapes RectTransform | `extensions.unity.shapes.recttransform` | 1.0.2 | RectTransform shape utilities (requires paid Shapes asset) |

**Technical Details:**
- C# 99.9%, MIT license
- 12 stars, npm registry distribution
- Modular -- install only what you need
- Requires scoped registry in manifest.json for `extensions.unity` scope

**Deep-Dive Source Review (Session 26):**

Full GitHub source code review of all modules. Three blocking issues prevent installation:

1. **Hard dependency on UniRx AND Odin** -- `BaseMonoBehaviour` inherits `SerializedMonoBehaviour` (Odin). Utility classes use `UniRx.FloatReactiveProperty`. Not optional -- contaminates all component classes.
2. **Global namespace pollution** -- ALL extension files have NO namespace declaration. Would cause ambiguity errors with TecVooDoo's namespaced extensions.
3. **Code quality issues** -- Class name typos (`ExtansionsList`, `ExtansionsHashSet`), bugs (`GetVector2` returns `Vector3`, Vector3Int Z-component errors).

**TecVooDoo Utilities Comparison (16 categories):**

TecVooDoo Utilities wins 12 of 16 categories. IvanMurzak wins only in Transform reset/destroy helpers and recursive layer setting (both trivial 1-5 line methods). Tie in 2 categories (GetOrAdd, Color hex). TecVooDoo has entire systems IvanMurzak lacks: timer system (8 files), 3 singleton variants, cached yields, billboard, string extensions, rigidbody extensions.

**7 Cherry-Pick Patterns Identified:**
Added to TecVooDoo Utilities Phase 9 TODO. All 1-5 line rewrites from scratch:
1. `Transform.Reset/ResetPosition/ResetRotation/ResetScale` -- identity reset
2. `Transform.DestroyChildren/DestroyChildrenImmediate` -- child cleanup
3. `Transform.HierarchyPath` -- debug path string
4. `Vector3.ToVector2XY/ToVector2XZ` -- 2D projection
5. `Vector3.RoundToInt/CeilToInt/ToVector3Int` -- int conversions
6. `GameObject.SetLayerRecursively(int)` -- recursive layer
7. `Color.ToHexRGB` + `TryFromHex` -- RGB hex and safe parsing

**Why Rejected:**
UniRx + Odin hard dependencies are fundamentally incompatible with TecVooDoo Utilities' zero-dependency design. Global namespace pollution would cause compile errors. The 22 clean extension files offer minimal value beyond TecVooDoo's existing coverage. The contaminated base/utility/manager classes (the package's unique value) cannot be extracted without UniRx and Odin. Only 7 trivial patterns worth adding -- all rewritable from scratch in minutes.

---

#### ENTRY-061: Unity-AudioLoader

| Field | Value |
|-------|-------|
| **Asset** | Unity-AudioLoader |
| **Source** | GitHub (IvanMurzak) / OpenUPM |
| **Package ID** | extensions.unity.audioloader |
| **Version** | 1.0.4 |
| **Category** | Audio |
| **Date Started** | 2026-02-11 |
| **Date Completed** | 2026-02-11 |
| **Verdict** | Conditional |
| **HOK Applicable** | Maybe |

**What It Does:**
Asynchronous audio loading with dual-layer caching (RAM + disk). Same architectural pattern as Unity-ImageLoader (ENTRY-051) but for AudioClips. Loads from web URLs or local paths. Dedicated disk I/O thread. Prevents duplicate simultaneous loads. Auto-assignment to AudioSource components.

**Core API:**

| Method | What It Does |
|--------|-------------|
| `AudioLoader.Init()` | Initialize on main thread (required once) |
| `AudioLoader.LoadAudioClip(url)` | Async load from URL/path, returns AudioClip |
| `AudioLoader.SetAudioSource(url, audioSource)` | Load and auto-assign to AudioSource |
| `AudioLoader.CacheContains(url)` | Check if cached (memory or disk) |
| `AudioLoader.ClearCache()` | Clear all caches |
| `AudioLoader.SaveToMemoryCache(url, clip)` | Manual cache injection |

**Technical Details:**
- MIT license, 44 stars, 3 forks
- Depends on UniTask (Cysharp.Threading.Tasks) -- already installed
- Install: `openupm add extensions.unity.audioloader`
- Last updated: September 2023 (older, less actively maintained than ImageLoader)
- Configurable: `useMemoryCache`, `useDiskCache`, `diskSaveLocation`, `debugLevel`

**Duplication Check:**
No audio loading packages installed. River Modeler has an AudioZone component for spline-based ambient audio, and Malbers AC has animation-driven SFX. Neither provides async loading with caching. Unity's built-in `UnityWebRequestMultimedia.GetAudioClip()` can load audio from URLs but has no caching layer. AudioLoader fills a genuine gap.

**Same-Author Ecosystem Value:**
Mirrors ImageLoader's architecture (dual cache, UniTask-based, fluent API pattern). Same engineering discipline: dedicated I/O thread, deduplication of concurrent loads, configurable cache behavior. Learning one package teaches the other. Both depend on UniTask, which is already installed and Approved - Default (ENTRY-025).

**Potential HOK Use Cases:**
- Streaming ambient music per river (Acheron dark drones, Phlegethon crackling, Lethe ethereal)
- Loading SFX variants without bundling all audio in the build
- Dynamic audio content updates without app updates
- Audio asset streaming for memory-constrained platforms

**Integration Concerns:**
- v1.0.4 is relatively old (Sept 2023) compared to other Ivan Murzak packages -- may need compatibility testing with Unity 6
- HOK's audio architecture isn't designed yet -- no Audio Manager, no audio middleware decision
- For a cozy fishing game, most audio can be bundled in the build (Addressables or direct references). Streaming audio from URLs is typically a mobile/live-service pattern.
- Doesn't replace the need for an audio manager, mixer setup, or music system -- it only handles loading

**HOK Notes:**
Conditional -- interesting but not urgent. HOK has no audio infrastructure yet (empty Audio/ folders). When audio work begins, evaluate whether HOK needs URL-based audio streaming or if standard Addressables/direct references are sufficient. AudioLoader is most valuable if: (1) the game streams music to reduce build size, (2) audio content is updated post-launch, or (3) per-river ambient tracks are loaded on demand rather than kept in memory. Install when audio architecture is designed, not before.

---

#### ENTRY-062: Unity-AI-Meshy

| Field | Value |
|-------|-------|
| **Asset** | Unity-AI-Meshy |
| **Source** | GitHub (IvanMurzak) / OpenUPM |
| **Package ID** | com.ivanmurzak.unity.mcp.meshy |
| **Version** | 1.0.x |
| **Category** | Tools (MCP Ext) |
| **Date Started** | 2026-02-11 |
| **Date Completed** | 2026-02-11 |
| **Verdict** | Deferred |
| **HOK Applicable** | Maybe |

**What It Does:**
MCP extension that integrates Meshy AI's 3D model generation with Unity. Generate production-ready 3D models from text prompts or reference images and pull them directly into the Unity Editor. Text-to-3D and image-to-3D workflows via Claude natural language.

**Technical Details:**
- MIT license, 3 stars
- MCP extension (requires MCP for Unity base package)
- Requires Meshy AI subscription (external service, not free)
- Active development (Jan 2026)

**Cross-Project Value (TecVooDoo):**

| Project | Potential Use |
|---------|-------------|
| HOK | Low-poly fish models, environment props, ferry decorations |
| Alpha Foxtrot Uniform | Ancient Egyptian props, military gear, structures |
| Cursed Fantasy | Creature models, biome-specific props, faction architecture |
| Forensic Science Lab (VR) | Lab equipment, evidence items, forensic tools |
| Space Garbage Man | Space station debris, alien garbage, tools |
| Any 3D project | Rapid prototyping placeholder assets |

**Why Deferred:**
Requires active Meshy AI subscription (paid external service). Cannot evaluate without subscription. Quality of AI-generated low-poly models unknown -- Meshy may produce high-poly results that need manual retopology, which defeats the purpose for a low-poly art style. Evaluate when: (1) Meshy subscription is available, or (2) art pipeline needs acceleration beyond what Son can produce. The MCP integration itself is likely solid given IvanMurzak's track record.

---

#### ENTRY-063: MCP-Plugin-dotnet

| Field | Value |
|-------|-------|
| **Asset** | MCP-Plugin-dotnet |
| **Source** | GitHub (IvanMurzak) / NuGet |
| **Package ID** | IvanMurzak.McpPlugin (NuGet) |
| **Version** | Latest |
| **Category** | AI / MCP |
| **Date Started** | 2026-02-11 |
| **Date Completed** | 2026-02-11 |
| **Verdict** | Deferred |
| **HOK Applicable** | No (non-Unity) |

**What It Does:**
Generic .NET MCP framework -- the foundational library that Unity-MCP (ENTRY-056) is built on top of. Lets ANY .NET application expose methods as MCP tools, prompts, and resources to AI assistants like Claude. Hub-and-spoke architecture with SignalR for bidirectional communication.

**Technical Details:**
- Apache-2.0 license, 8 stars
- Platforms: .NET Standard 2.1, .NET 8.0, .NET 9.0
- SignalR-powered communication (single HTTP port, default 8080)
- Attribute-based registration: `[McpPluginTool]`, `[McpPluginPrompt]`, `[McpPluginResource]`
- Automatic reconnection resilience
- Supports stdio (Claude Desktop) and HTTP transport
- Docker support included
- Dependency injection and assembly scanning
- Uses ReflectorNet for complex type handling

**Cross-Project Value (TecVooDoo):**

| Project Type | Potential Use |
|-------------|-------------|
| .NET Desktop Apps | MCP-enable SmartScheduler Pro, ClickSniff, Dementia Support |
| Game Servers | Expose game server tools to Claude for monitoring/admin |
| ASP.NET APIs | AI-assisted API development and testing |
| Console Tools | Build Claude-interactive CLI tools |

**Why Deferred:**
No active non-Unity .NET projects in development. All current TecVooDoo projects are either Unity (use Unity-MCP instead), web (JavaScript/HTML), or writing (no code). Catalog for future reference -- when a .NET desktop app or game server project begins, this is the MCP bridge to use. Same attribute pattern as Unity-MCP means skills transfer directly.

---

#### ENTRY-064: UBuilder

| Field | Value |
|-------|-------|
| **Asset** | UBuilder |
| **Source** | GitHub (IvanMurzak) / OpenUPM |
| **Package ID** | extensions.unity.ubuilder |
| **Version** | Latest |
| **Category** | Tools (Build) |
| **Date Started** | 2026-02-11 |
| **Date Completed** | 2026-02-11 |
| **Verdict** | Deferred |
| **HOK Applicable** | Maybe |

**What It Does:**
Command-line Unity build tool for CI/CD automation. Cross-platform build execution with environment variable and CLI argument configuration. Supports GUI and CLI modes. Handles iOS signing, Android keystore, and pre-build project modification hooks.

**Technical Details:**
- MIT license, 16 stars
- Platforms: Windows, macOS, Linux
- Targets: iOS, Android, Standalone
- Active development (Mar 2025)

**Cross-Project Value (TecVooDoo):**

| Project | Potential Use |
|---------|-------------|
| HOK | Automated Steam builds, platform-specific packaging |
| Don't Lose Your Head | WebGL build automation |
| Shrunken Head Toss | Mobile build pipeline |
| Any Unity project | GitHub Actions CI/CD integration |

**Why Deferred:**
No Unity projects are at the CI/CD pipeline stage yet. HOK is in design/Sandbox phase, DLYH is playtesting manually, Shrunken Head Toss is early development. Evaluate when any Unity project needs automated builds -- likely when HOK approaches alpha or when multiple Unity projects are building simultaneously. Pairs with IvanMurzak's GitHub-Runners repo for self-hosted CI.

---

#### ENTRY-065: NuGetForUnity (GlitchEnzo)

| Field | Value |
|-------|-------|
| **Asset** | NuGetForUnity |
| **Source** | GitHub (GlitchEnzo) / OpenUPM |
| **Package ID** | com.github-glitchenzo.nugetforunity |
| **Version** | v4.5.0 (latest release) |
| **Category** | Tools (Package Management) |
| **Date Started** | 2026-02-12 |
| **Date Completed** | 2026-02-12 |
| **Verdict** | Rejected |
| **HOK Applicable** | No |

**What It Does:**
Full NuGet package manager inside the Unity Editor. Browse, search, install, update, and uninstall NuGet packages with automatic dependency resolution. Supports custom feeds (Azure Artifacts, GitHub Packages, JFrog Artifactory, local feeds). Includes CLI tool for CI/CD package restoration. Plugin architecture via `INugetPlugin`. MIT license, 4,300+ stars, actively maintained (community-driven, last commit Jan 2026).

**Why Evaluated:**
The current project uses OpenUPM's scoped registry to proxy NuGet packages (`org.nuget.*` entries in manifest.json) for the IvanMurzak MCP ecosystem. This approach broke when MCP v0.46.1 required `org.nuget.microsoft.extensions.options` which OpenUPM had not mirrored. Evaluated whether NuGetForUnity could replace the OpenUPM NuGet proxy for more reliable dependency resolution.

**Results -- REJECTED:**
NuGetForUnity operates in a completely separate system from UPM. The two cannot interoperate:

1. **UPM cannot see NuGetForUnity packages.** When `com.ivanmurzak.unity.mcp` declares a dependency on `org.nuget.microsoft.aspnetcore.signalr.client` in its UPM `package.json`, that dependency MUST be resolved through UPM's scoped registry. NuGetForUnity's packages are invisible to UPM's dependency resolver.

2. **Duplicate DLL conflicts.** If both systems install the same package (e.g., `Microsoft.Extensions.Logging`), Unity throws "Multiple precompiled assemblies with the same name" hard errors.

3. **No migration path.** UPM packages that declare `org.nuget.*` dependencies cannot be migrated to NuGetForUnity. The scoped registry must remain.

4. **Unity 6 bug.** Latest release (v4.5.0, July 2024) has a packages-lost bug on Unity 6. Fix is on master but unreleased.

**Conclusion:** NuGetForUnity is only useful for standalone NuGet packages not depended upon by any UPM package. Since all our NuGet dependencies come from the MCP ecosystem's UPM dependency declarations, NuGetForUnity adds no value and would create conflict risk. The OpenUPM scoped registry approach stays.

---

#### ENTRY-066: Unity Toon Shader (Unity-Technologies)

| Field | Value |
|-------|-------|
| **Asset** | Unity Toon Shader |
| **Source** | GitHub (Unity-Technologies) |
| **Package ID** | com.unity.toonshader |
| **Version** | v0.13.1-preview (Dec 2025) |
| **Category** | Rendering |
| **Date Started** | 2026-02-12 |
| **Date Completed** | In Progress |
| **Verdict** | Testing |
| **HOK Applicable** | Yes |

**What It Does:**
Cel-shading solution supporting URP, HDRP, and Built-in pipelines. Toon shading, highlights, rim lighting, emission, MatCap, outlines. 1,400+ stars, 1,229 commits, actively maintained (Feb 2026). MIT license.

**Why Installing:**
HOK's "cozy low-poly" aesthetic could benefit from stylized shading. URP-compatible out of the box. Outlines and cel-shading complement low-poly art.

**Installation:** `https://github.com/Unity-Technologies/com.unity.toonshader.git?path=com.unity.toonshader`

**Installation Note:** Original Git URL without `?path=` failed with "fatal: not in a git directory" because `package.json` is in a subdirectory, not at repo root. Depends on `com.unity.film-internal-utilities` -- watch for resolution errors. Unity 6 compatible (v0.13.0+ requires 6000.0 minimum).

---

#### ENTRY-067: BuildReportInspector (Unity-Technologies)

| Field | Value |
|-------|-------|
| **Asset** | BuildReportInspector |
| **Source** | GitHub (Unity-Technologies) |
| **Package ID** | com.unity.build-report-inspector |
| **Version** | Latest (Feb 2026) |
| **Category** | Tools (Build) |
| **Date Started** | 2026-02-12 |
| **Date Completed** | In Progress |
| **Verdict** | Testing |
| **HOK Applicable** | Yes |

**What It Does:**
Editor inspector for Unity's BuildReport class. Profiles build times, analyzes build composition, detects duplicated assets across bundles, exports to CSV. 393 stars, active (Feb 2026). Works with Unity 6. Install from GitHub for latest (Package Manager version is outdated v0.3).

**Why Installing:**
With 65+ evaluated assets, understanding what actually ships in a build is critical. Essential for optimization when HOK reaches build stage.

**Installation:** `https://github.com/Unity-Technologies/BuildReportInspector.git?path=com.unity.build-report-inspector`

**Installation Note:** Original Git URL without `?path=` failed with "fatal: not in a git directory" because `package.json` is in `com.unity.build-report-inspector/` subdirectory, not at repo root. v0.4.5-preview (GitHub) is newer than v0.3 (Package Manager). Minimum Unity 2019.3 -- fully compatible with Unity 6.

---

#### ENTRY-068: ML-Agents (Unity-Technologies)

| Field | Value |
|-------|-------|
| **Asset** | Unity ML-Agents Toolkit |
| **Source** | GitHub (Unity-Technologies) / Unity Registry |
| **Package ID** | com.unity.ml-agents |
| **Version** | v4.0.1 (Release 23, Dec 2025) |
| **Category** | AI |
| **Date Started** | 2026-02-12 |
| **Date Completed** | 2026-02-12 |
| **Verdict** | Conditional |
| **HOK Applicable** | Maybe |

**What It Does:**
ML toolkit for Unity. Train intelligent agents using reinforcement learning (PPO, SAC, MA-POCA), imitation learning, and curriculum learning. 19,100+ stars, 508 contributors. Python training side + Unity runtime package. 17+ example environments. Trained models export to ONNX for Unity Inference Engine (formerly Sentis/Barracuda) runtime.

**Version Notes:**
- v4.0.0 (Aug 2025): Switched from Barracuda/Sentis to Unity Inference Engine (`com.unity.ai.inference`). Merged extensions package into main package.
- v4.0.1 (Dec 2025): Fixed editor crash on quit, tensor indexing bug, pinned PyTorch <=2.8. Uses Inference Engine v2.4.1.
- **Deprecated label** starting Unity 6.1 in Package Manager, but still actively maintained.
- Python training requires Python 3.10.1-3.10.12 (strict range), PyTorch ~2.2.1 with CUDA 12.1.

**Unity 6.3 ONNX Importer Warning:**
On Unity 6.3 (6000.3.x -- our version), installing both `com.unity.sentis` or `com.unity.barracuda` alongside `com.unity.ai.inference` causes a dual ONNX importer conflict. ML-Agents 4.x pulls in the Inference Engine automatically -- do NOT separately install Sentis or Barracuda.

**ML-Agents + Inference Engine Pipeline:**
1. **Train (Python):** `mlagents-learn config.yaml --run-id=myrun`. Python connects to Unity via gRPC. Uses PPO/SAC.
2. **Export:** Training auto-exports `.onnx` to `results/` directory. No manual conversion.
3. **Deploy (Unity):** Drag `.onnx` onto Agent's Model field. ML-Agents uses Inference Engine internally.
4. **No Python at runtime.** Trained model runs entirely within Unity.
5. **CPU inference recommended** for most ML-Agents models. GPU only for large visual encoders.

**Aquarium Training Pattern:**
Separate simplified training scene (no rendering, simplified physics, parallel environments via `--num-envs 16`). Transfer learned behaviors to production scene via relative observations. Standard ML-Agents workflow -- faster training, no interference with scene development.

**Honest Assessment for HOK Fish AI:**
ML-Agents is **overkill** for HOK's fish behaviors. The ~45 creature species need **predictable, tunable** behaviors (schooling, feeding, fleeing, biting) that designers can adjust per-species. ML-Agents introduces:
- Heavy setup (Python 3.10.12, PyTorch, CUDA, conda environment)
- Hours-to-days training per behavior, retrain on any parameter change
- Black box decisions (cannot inspect why a fish does something)
- Reward shaping is indirect and fragile (reward hacking common)
- Awkward SOAP integration (models are files, not SO events)

**Recommended Alternative for Fish AI:**
- **Schooling:** Craig Reynolds' Boids (separation, alignment, cohesion). Three rules, hundreds of fish, trivial to implement and tune per-species.
- **Behaviors:** Hierarchical state machine or behavior tree (Idle/Schooling/Feeding/Fleeing/Investigating/Biting/Hooked/Fighting).
- **Lure interaction:** Weighted scoring (lure attractiveness x species modifier x depth x time x weather). ScriptableObject-driven, designer-tunable, no retraining.
- All pure C#, debuggable, immediate iteration, natural SOAP fit.

**Where ML-Agents WOULD Help HOK:**
- Automated playtesting (train agents to fish and find exploits/dead zones)
- Adaptive NPCs that learn player patterns (design question -- most fishing games avoid this)
- Complex multi-agent ecosystem simulations beyond hand-authoring scope

**Verdict Rationale:**
Conditional. The package works on Unity 6 and the pipeline is sound. But for HOK's specific fish AI needs, Boids + state machines + ScriptableObjects is the right architecture. ML-Agents stays installed for potential playtesting use and general experimentation. Use v4.0.1 for the crash fix.

**Installation:** `com.unity.ml-agents@4.0.1` (Unity Registry). Python: install from GitHub `release_23` branch (PyPI lags behind).

---

#### ENTRY-069: BoatAttack (Unity-Technologies) -- REFERENCE

| Field | Value |
|-------|-------|
| **Asset** | BoatAttack Demo |
| **Source** | GitHub (Unity-Technologies) |
| **Category** | Rendering (Reference) |
| **Date Started** | 2026-02-12 |
| **Date Completed** | 2026-02-12 |
| **Verdict** | Deferred (Reference) |
| **HOK Applicable** | Yes |

**What It Is:** Boat racing game demo showcasing URP. 2,700+ stars. Demonstrates LOD systems, Shader Graph, post-processing, custom ScriptableRenderPass for planar reflections, Gerstner wave water. Separate `boat-attack-water` repo (370 stars) extracts the water system as a standalone URP package.

**Reference Value:** Literally a boat/water game in URP. Water rendering techniques, LOD approach, and URP render pass patterns directly relevant to HOK. Clone and study when working on water effects, camera systems, or boat/raft movement.

**URLs:** `github.com/Unity-Technologies/BoatAttack`, `github.com/Unity-Technologies/boat-attack-water`

---

#### ENTRY-070: PaddleGameSO (UnityTechnologies) -- REFERENCE

| Field | Value |
|-------|-------|
| **Asset** | PaddleGameSO |
| **Source** | GitHub (UnityTechnologies - DevRel) |
| **Category** | Architecture (Reference) |
| **Date Started** | 2026-02-12 |
| **Date Completed** | 2026-02-12 |
| **Verdict** | Deferred (Reference) |
| **HOK Applicable** | Yes |

**What It Is:** Official Unity demo of ScriptableObject design patterns. 274 stars. Data containers, delegate objects, **event channels**, SO-based enums, runtime sets. Implements a paddle game in multiple architectural variants.

**Reference Value:** This IS the SOAP architecture pattern. The event channel implementation is exactly what SOAP uses. Canonical Unity-official reference for validating HOK's ScriptableObject-based architecture.

**URL:** `github.com/UnityTechnologies/PaddleGameSO`

---

#### ENTRY-071: Game Programming Patterns Demo (UnityTechnologies) -- REFERENCE

| Field | Value |
|-------|-------|
| **Asset** | Game Programming Patterns Demo |
| **Source** | GitHub (UnityTechnologies - DevRel) |
| **Category** | Architecture (Reference) |
| **Date Started** | 2026-02-12 |
| **Date Completed** | 2026-02-12 |
| **Verdict** | Deferred (Reference) |
| **HOK Applicable** | Yes |

**What It Is:** Companion to Unity's "Level up your code with game programming patterns" e-book. 1,700+ stars. Working implementations of Observer, State, Object Pooling, MVC/MVP, Factory, Command patterns.

**Reference Value:** Object Pool pattern for fish spawning, State pattern for game state machine (HOK.Core), Observer pattern validates SOAP event channels, Command pattern for input handling. Clone when implementing HOK systems.

**URL:** `github.com/UnityTechnologies/game-programming-patterns-demo`

---

#### ENTRY-072: Sentis Samples (Unity-Technologies) -- REFERENCE

| Field | Value |
|-------|-------|
| **Asset** | Sentis Samples |
| **Source** | GitHub (Unity-Technologies) |
| **Category** | AI (Reference) |
| **Date Started** | 2026-02-12 |
| **Date Completed** | 2026-02-12 |
| **Verdict** | Deferred (Reference) |
| **HOK Applicable** | Yes |

**What It Is:** 8 sample projects for Unity Sentis / Inference Engine. 316 stars. Text-to-speech, chat LLM, face/hand/pose detection, digit recognition, board-game AI, depth estimation, star simulation. Working code showing ONNX model loading and inference.

**Naming Note:** Barracuda -> Sentis -> Inference Engine (`com.unity.ai.inference`). ML-Agents 4.x pulls in the Inference Engine automatically as a dependency. Do NOT install `com.unity.sentis` separately alongside ML-Agents 4.x on Unity 6.3 (causes dual ONNX importer conflict). These samples may reference older `com.unity.sentis` namespace -- adapt imports if cloning.

**Reference Value:** The board-game AI sample shows inference patterns applicable to game AI. Useful if using Inference Engine directly (without ML-Agents) for custom ONNX models. Clone when integrating trained models into HOK or for non-ML-Agents inference needs.

**URL:** `github.com/Unity-Technologies/sentis-samples`

---

#### ENTRY-073: ZString (Cysharp)

| Field | Value |
|-------|-------|
| **Asset** | ZString - Zero Allocation StringBuilder |
| **Source** | GitHub (Cysharp) |
| **Package ID** | com.cysharp.zstring |
| **Version** | Latest (active, Feb 2026) |
| **Category** | Tools (Performance) |
| **Date Started** | 2026-02-12 |
| **Date Completed** | 2026-02-12 |
| **Verdict** | Deferred |
| **HOK Applicable** | Yes |

**What It Does:**
Struct-based zero-allocation string building for .NET and Unity. 2,684 stars. MIT license. Replaces `string.Format`, `$""` interpolation, and `StringBuilder` with allocation-free alternatives. Auto-detects TextMeshPro and provides TMP integration. Unity 2021.3+.

**HOK Value:**
Direct fix for the "no per-frame allocations" coding rule. Every `$"Score: {score}"` or `string.Concat` allocates on the heap. ZString eliminates this for UI text updates, debug output, and logging. Drop-in improvement with no architectural changes needed. TextMeshPro integration is especially valuable for HOK's UI namespace.

**Install When:** First priority Cysharp package. Install when beginning UI or debug text work.

**URL:** `github.com/Cysharp/ZString`

---

#### ENTRY-074: R3 (Cysharp)

| Field | Value |
|-------|-------|
| **Asset** | R3 - Reactive Extensions (UniRx successor) |
| **Source** | GitHub (Cysharp) |
| **Package ID** | R3 (via OpenUPM or NuGet) |
| **Version** | Latest (active, Feb 2026) |
| **Category** | Architecture (Reactive) |
| **Date Started** | 2026-02-12 |
| **Date Completed** | 2026-02-12 |
| **Verdict** | Deferred |
| **HOK Applicable** | Yes |

**What It Does:**
Modern reactive programming rebuilt from scratch by the UniRx author. 3,604 stars. MIT license. ReactiveProperty for data binding, frame-based operators (DelayFrame, IntervalFrame), subscription leak tracking. Zero-allocation design. Multi-platform (Unity, Godot, WPF, Blazor).

**HOK Value:**
ReactiveProperty complements SOAP event channels with data binding. Frame-based operators are purpose-built for game loops. Zero-allocation design aligns with coding conventions. Complements UniTask -- R3 handles event streams, UniTask handles one-shot async. Does NOT replace SO channels; adds reactive streams on top.

**Install When:** When building HOK's UI namespace. ReactiveProperty + ObservableCollections for data-driven UI.

**URL:** `github.com/Cysharp/R3`

---

#### ENTRY-075: MemoryPack (Cysharp)

| Field | Value |
|-------|-------|
| **Asset** | MemoryPack - Zero Encoding Binary Serializer |
| **Source** | GitHub (Cysharp) |
| **Package ID** | com.cysharp.memorypack |
| **Version** | Latest (Jan 2025, stable) |
| **Category** | Data (Serialization) |
| **Date Started** | 2026-02-12 |
| **Date Completed** | 2026-02-12 |
| **Verdict** | Deferred |
| **HOK Applicable** | Yes |

**What It Does:**
Zero-encoding extreme performance binary serializer. 4,377 stars. MIT license. Source generator based (IL2CPP safe, no runtime reflection). 10-200x faster than MessagePack, JSON, protobuf alternatives. Unity 2021.3+ with IL2CPP support.

**HOK Value:**
Best-in-class for save/load system, progression data persistence, and ScriptableObject data export. Source generator approach means compile-time safety and zero runtime reflection. Ideal for HOK's Data namespace (progression, catch records, save files).

**Install When:** When building HOK's Data namespace / save system.

**URL:** `github.com/Cysharp/MemoryPack`

---

#### ENTRY-076: ZLinq (Cysharp)

| Field | Value |
|-------|-------|
| **Asset** | ZLinq - Zero Allocation LINQ |
| **Source** | GitHub (Cysharp) |
| **Package ID** | ZLinq |
| **Version** | Latest (active, Feb 2026) |
| **Category** | Tools (Performance) |
| **Date Started** | 2026-02-12 |
| **Date Completed** | 2026-02-12 |
| **Verdict** | Deferred |
| **HOK Applicable** | Maybe |

**What It Does:**
Zero-allocation LINQ with Span support and SIMD acceleration. 4,925 stars. MIT license. 99% LINQ operator compatibility via struct-based enumerables. Tree structure queries. .NET Standard 2.0 compatible, targets Unity explicitly.

**HOK Value:**
Could relax the "no LINQ in hot paths" rule to "no *allocating* LINQ." Struct-based enumerables mean LINQ-style queries with zero GC pressure. Newer library (still maturing). Adds a learning curve for maintaining the no-LINQ mental model across the team.

**Install When:** If verbose manual loops become a pain point where LINQ would be cleaner. Evaluate alongside coding standards review.

**URL:** `github.com/Cysharp/ZLinq`

---

#### ENTRY-077: MessagePipe (Cysharp)

| Field | Value |
|-------|-------|
| **Asset** | MessagePipe - High Performance Messaging |
| **Source** | GitHub (Cysharp) |
| **Package ID** | MessagePipe |
| **Version** | Latest (Dec 2024, maintained) |
| **Category** | Architecture (Messaging) |
| **Date Started** | 2026-02-12 |
| **Date Completed** | 2026-02-12 |
| **Verdict** | Deferred |
| **HOK Applicable** | Maybe |

**What It Does:**
High performance in-memory/distributed messaging for .NET and Unity. 1,775 stars. MIT license. DI-first typed pub/sub with filter pipeline, sync/async support, keyed messages. 78x faster than Prism's EventAggregator. Supports VContainer, Zenject, or built-in tiny DI.

**HOK Value:**
Alternative to SOAP event channels with typed pub/sub, complex filtering, and async subscribers. Only consider if SOAP channels hit a limitation. Current SO event channel architecture works well for HOK's scale.

**Install When:** Only if SOAP channels prove insufficient for complex filtering, scoped lifetimes, or async subscriber needs.

**URL:** `github.com/Cysharp/MessagePipe`

---

#### ENTRY-078: ObservableCollections (Cysharp)

| Field | Value |
|-------|-------|
| **Asset** | ObservableCollections |
| **Source** | GitHub (Cysharp) |
| **Package ID** | ObservableCollections |
| **Version** | Latest (Dec 2024, maintained) |
| **Category** | UI (Data Binding) |
| **Date Started** | 2026-02-12 |
| **Date Completed** | 2026-02-12 |
| **Verdict** | Deferred |
| **HOK Applicable** | Maybe |

**What It Does:**
High performance observable collections with synchronized views. 920 stars. MIT license. ObservableList, ObservableDictionary, ObservableHashSet, ring buffers. R3 integration available.

**HOK Value:**
UI data binding -- inventory lists, catch logs, merchant stock that auto-update UI when modified. Pairs naturally with R3 (ENTRY-074) for reactive UI.

**Install When:** When building HOK's UI namespace (inventory, catch log, merchant screens).

**URL:** `github.com/Cysharp/ObservableCollections`

---

#### ENTRY-079: MasterMemory (Cysharp)

| Field | Value |
|-------|-------|
| **Asset** | MasterMemory - In-Memory Typed Database |
| **Source** | GitHub (Cysharp) |
| **Package ID** | MasterMemory |
| **Version** | Latest (Dec 2024, maintained) |
| **Category** | Data (Database) |
| **Date Started** | 2026-02-12 |
| **Date Completed** | 2026-02-12 |
| **Verdict** | Deferred |
| **HOK Applicable** | Maybe |

**What It Does:**
Embedded typed readonly in-memory document database. 1,794 stars. MIT license. Source generator based. 4,700x faster than SQLite with zero allocation per query. Write-once read-many pattern.

**HOK Value:**
Perfect for game master data: creature stats (45 species), item databases, fish species tables, merchant inventories. Typed queries over manual SO lookups. Depends on MessagePack for serialization.

**Install When:** When building HOK's Data namespace. Evaluate alongside MemoryPack (ENTRY-075) and EFCore-SQLite (ENTRY-058) for data layer design decisions.

**URL:** `github.com/Cysharp/MasterMemory`

---

#### ENTRY-080: UnitGenerator (Cysharp)

| Field | Value |
|-------|-------|
| **Asset** | UnitGenerator - Strongly-Typed Value Objects |
| **Source** | GitHub (Cysharp) |
| **Package ID** | UnitGenerator |
| **Version** | Stable (source generator) |
| **Category** | Tools (Code Gen) |
| **Date Started** | 2026-02-12 |
| **Date Completed** | 2026-02-12 |
| **Verdict** | Deferred |
| **HOK Applicable** | Maybe |

**What It Does:**
Source generator for creating value objects / units of measure. 397 stars. MIT license. Prevents type confusion bugs (e.g., HP cannot be assigned to MP). Compile-time enforcement. Unity support documented.

**HOK Value:**
Game stats are prime candidates: `Hp`, `SoulDecay`, `FishWeight`, `Currency`, `ObolusCoin` as distinct types that prevent mixing. Eliminates a class of bugs where you accidentally pass gold amount to an HP parameter. Low overhead, high safety.

**Install When:** When building HOK's Progression namespace / stat systems.

**URL:** `github.com/Cysharp/UnitGenerator`

---

#### ENTRY-081: StructureOfArraysGenerator (Cysharp)

| Field | Value |
|-------|-------|
| **Asset** | StructureOfArraysGenerator - SoA Data Layouts |
| **Source** | GitHub (Cysharp) |
| **Package ID** | StructureOfArraysGenerator |
| **Version** | Latest (Jan 2025, maintained) |
| **Category** | Tools (Performance) |
| **Date Started** | 2026-02-12 |
| **Date Completed** | 2026-02-12 |
| **Verdict** | Deferred |
| **HOK Applicable** | Maybe |

**What It Does:**
Source generator for CPU cache-friendly Structure of Arrays data layout. 327 stars. MIT license. 2-10x faster than traditional Array of Structures for iteration. Unity 2021.3+.

**HOK Value:**
For performance-critical systems with many similar entities: fish schools (Boids), ambient creatures, particle-like behaviors. SoA layout dramatically improves cache hit rates when iterating over position/velocity/state arrays for hundreds of fish.

**Install When:** When implementing HOK's Boids fish AI system or any system iterating 50+ entities per frame.

**URL:** `github.com/Cysharp/StructureOfArraysGenerator`

---

#### ENTRY-082: CsprojModifier (Cysharp)

| Field | Value |
|-------|-------|
| **Asset** | CsprojModifier - IDE Enhancement for Unity |
| **Source** | GitHub (Cysharp) |
| **Package ID** | com.cysharp.csprojmodifier |
| **Version** | v1.3.0 (Nov 2024) |
| **Category** | Tools (IDE) |
| **Date Started** | 2026-02-12 |
| **Date Completed** | 2026-02-12 |
| **Verdict** | Deferred |
| **HOK Applicable** | Maybe |

**What It Does:**
Adds Roslyn analyzers and custom .props/.targets imports to Unity-generated .csproj files. 235 stars. MIT license. Does not affect Unity compilation. Unity 2022.3+.

**HOK Value:**
Enables Roslyn static analyzers in VS Code / Rider for Unity projects. Catches bugs at edit time. Low risk addition for stricter code analysis.

**Install When:** When wanting stricter code analysis beyond what Unity provides by default.

**URL:** `github.com/Cysharp/CsprojModifier`

---

#### ENTRY-083: Simple Boids / #NVJOB Boids (NVJOB)

| Field | Value |
|-------|-------|
| **Asset** | Simple Boids (#NVJOB Boids) |
| **Source** | Asset Store (NVJOB) |
| **Version** | 1.1.1 |
| **Category** | AI (Boids) |
| **Date Started** | 2026-02-13 |
| **Date Completed** | 2026-02-13 |
| **Verdict** | Rejected (cherry-pick shader) |
| **HOK Applicable** | Maybe (shader technique only) |

**What It Does:**
Pseudo-Boids swarm system. NOT real Craig Reynolds Boids -- the README admits this. Entities steer toward invisible attractor-point spheres with random offsets. No separation, no alignment, no cohesion. Fish are completely unaware of each other. Manager pattern (one MonoBehaviour controls all entities via parallel arrays). Includes vertex shader-driven swimming animation (zero CPU cost). 3 mesh types (fish, bird, butterfly) with full PBR textures. MIT license.

**Location:** `Assets/#NVJOB Boids/`

**What We Found:**
- **NVBoids.cs** (300 lines): Entire system. `CreateFlock()` spawns invisible `CreatePrimitive(Sphere)` attractors. `CreateBird()` instantiates N prefabs. `LateUpdate` -> `BirdsMove()` steers each entity toward `(flock position + random offset)` via `RotateTowards`. `BehavioralChange` coroutine reshuffles offsets/speeds every 2-6 seconds.
- **Fish NX Shaders.shader**: Vertex-driven swimming via quadratic Z-axis deformation. Head stays still, tail wags. World-position phase offset desynchronizes individuals. `_ScriptControl` material property for script-driven speed modulation. Built-in RP only (CGPROGRAM, surface surf BlinnPhong).
- **Shark.cs**: Only consumer of the system. Communicates via physics layer (CheckSphere against flock markers), NOT via API. Has a bug: `target.y` used for Z component (line 120).

**Pros:**
- Vertex shader fish swimming is genuinely clever (~10 lines of math, zero CPU cost per entity)
- Manager pattern is correct (parallel arrays, not one MonoBehaviour per fish)
- O(n) per frame (no entity-entity interaction = no O(n^2) neighbor search)
- MIT license, included meshes usable as placeholders

**Cons:**
- Not real Boids (no separation/alignment/cohesion, entities unaware of each other)
- No public API (can't move flocks, add/remove fish, query positions programmatically)
- Hardcoded values (per-entity speed 3-7, SmoothDamp times, danger interval)
- Built-in RP shaders only (magenta in URP)
- Global namespace, no asmdef, coroutine-based (not UniTask)
- Poor naming: typos (`verticalWawe`, `curentFlock`, `acselSh`), everything called "bird" even for fish
- `CreatePrimitive(PrimitiveType.Sphere)` for invisible markers (adds unnecessary colliders)
- No per-entity state, no boundary containment, no ScriptableObject support

**Verdict Rationale:**
Rejected for use as-is. The algorithm is fundamentally wrong for HOK (attractor following, not Boids). Architecture incompatible (no SO, no SOAP, no state machines, no URP, no UniTask). Write HOK's Boids from scratch (400-600 lines for core system with proper separation/alignment/cohesion, Jobs+Burst for spatial hashing, SO-driven per-species params, SOAP events, per-entity state machine).

**Cherry-Pick Value:** Port the vertex shader fish swimming technique to URP Shader Graph. The quadratic Z-axis deformation for tail swing, world-position phase offset for desynchronization, and `_ScriptControl` material property for speed modulation are ~10 lines of pipeline-agnostic math that produce natural fish swimming animation at zero CPU cost. This is the single valuable pattern in the asset.

**HOK Notes:**
Asset stays installed until vertex shader technique is extracted. Once ported to URP Shader Graph custom function node, the asset can be removed. The swimming math applies to all ~45 fish species via per-material parameter tuning (_SwimmingPower, _SwimmingScale, _SwimmingSpeed, _WaveBody, _Wobble).

---

**End of Asset Evaluation Log**
