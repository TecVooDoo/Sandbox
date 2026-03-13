# Sandbox - Status Archive

**Purpose:** Historical reference for completed work. This document contains old session summaries, version history, and completed experiment details that are no longer needed in the active status doc but may be useful for reference.

**Related Document:** `Sandbox_Status.md` (active status document)

**Last Updated:** February 12, 2026 (Session 28)

---

## Archive Instructions

This document receives content from Sandbox_Status.md to keep the main status doc manageable.

### Version History
- Sandbox_Status.md keeps only the **9 most recent** version entries
- When a session adds a new version, move the oldest entry here
- Add to the TOP of the Version History table (newest archived first)

### Session Summaries
- Sandbox_Status.md keeps only the **Last Session + 3 most recent Previous** summaries
- Archive older session summaries here when they roll off

### Completed Experiments
- Move experiment sections here when marked **COMPLETE** in Sandbox_Status.md
- Replace with a one-line reference in the active doc
- Include the full experiment text as it existed when archived

**Do NOT archive (keep in active doc):**
- Active/in-progress experiments
- Package lists (installed packages, local packages, etc.)
- Coding standards and AI rules
- Cross-project references
- Session close checklist
- Purpose and Quick Context sections

---

## Table of Contents

1. [Archived Session Summaries](#archived-session-summaries)
2. [Version History (Archived)](#version-history-archived)
3. [Completed Experiments](#completed-experiments)

---

## Archived Session Summaries

### Session 26 (Feb 11, 2026)
AI-ProBuilder hands-on evaluation. Installed `com.ivanmurzak.unity.mcp.probuilder` v1.0.24 via MCP package-add. Verified 13 tools registered via Roslyn reflection (CreateShape, CreatePolyShape, GetMeshInfo, Extrude, Bevel, Bridge, ConnectEdges, DeleteFaces, FlipNormals, MergeObjects, SetFaceMaterial, SetPivot, SubdivideEdges). Tested ProBuilder API via script-execute: shape generation (6 types), face extrusion, face deletion, per-face materials, edge connection, PolyShape creation, full cave greybox (7 parts). Key finding: FaceDirection helper enum is the main value-add over script-execute (eliminates 6+ lines of normal calculation per face selection). Key limitation: MCP extension tools installed mid-session not visible until Claude Code restart. ENTRY-055 upgraded from Deferred to Conditional. Also updated all TecVooDoo company documents (Projects.csv, AI_Rules.md, CORE_DevelopmentProtocols.md, Locations.csv, Overview.csv, Games_Design.csv) to reflect current HOK design and Sandbox project. 61 total entries.

### Session 25 (Feb 11, 2026)
Continued Ivan Murzak ecosystem evaluation. Formal MCP for Unity evaluation: ENTRY-056 logged (Approved - Default, 52 tools, 10 categories, replaces old coplay MCP). Full document familiarization -- read all Sandbox docs, HOK design docs, and HOK archives. Deep-dive evaluations: ENTRY-052 (AI-Animation) upgraded to Conditional (6 MCP tools), ENTRY-053 (AI-ParticleSystem) upgraded to Conditional (2 tools, 24 modules), ENTRY-054/055 stay Deferred. Key insight: AI packages are MCP tool extensions -- evaluate as "value over script-execute." Second batch: 5 additional packages evaluated (ENTRY-057 through ENTRY-061). Data category created. Duplication rule (Lesson #22). 61 total entries.

### Session 24 (Feb 11, 2026)
Unity-Theme and Unity-ImageLoader full evaluation with MCP capability testing. First session using Claude Code in VS Code (previously Claude Desktop). Built complete test UI in AssetTestScene via MCP Roslyn script-execute. Created AssetTestController.cs (theme cycling + image loading). 3 HOK river themes created (Acheron, Phlegethon, Lethe). Play mode confirmed: images load, theme switching works across all 5 themes. ENTRY-050 and ENTRY-051 both Approved. Lessons #20-21 added. 55 total entries.

### Session 22 (Feb 11, 2026)
Acheron river width system. Added Set Acheron River Widths menu command to RiverSplineSetup.cs. Base width 20m with ScaleData multipliers per zone (Cave 0.6x/12m, Gorge 0.9x/18m, Reeds 1.25x/25m, Convergence 1.0x/20m, Mouth 1.5x/30m). 15m transition ramps. Not yet executed in Unity. 49 total entries.

### Session 21 (Feb 10, 2026)
Acheron greybox scene build -- planning, scripting, AND in-Unity execution completed. AcheronSceneBuilder.cs (~1030 lines), RiverSplineSetup.cs (Wire River Modeler + Create Acheron River Spline). Scene fully assembled: MT_Mountain gorge walls, U_Terrain cave floor, rock scatter, River Modeler mesh from 11-knot spline. Cave ceiling fix (Lesson #19). Water material: SW3 Lowpoly with custom dark slate palette. Known issue: river/mountain clipping. 49 total entries.

### Session 16 (Feb 9, 2026)
HOK GDD deep design session (continuation). GDD v1.0 through v1.5. Locked 15 design decisions total. Major systems designed and documented: dock/ferry two-timer system (obol decay at dock, soul decay on raft), cooler as tetris-style inventory (seat + height prop + grid inventory), swiss army scythe (fishing rod = scythe/raft pole, one equipped set), raft movement rules (moves in both On/Off-Duty states, must anchor to fish, Scorch propels from below raft when On-Duty). Updated GDD Sections 3, 4, 5, 6, 7, 8, 9, 11. Art Asset List updated with placeholder tracking and art team handoff instructions. No new asset evaluations. 49 total entries in asset log.

### Session 15 (Feb 9, 2026)
HOK redesign -- research and design phase. Abandoned old prototype approach in favor of design-first methodology. Created 7 research/design documents grounded in classical sources. GDD established as primary HOK reference. Evaluated Blaze AI Engine (ENTRY-049, Deferred). Old HOK prototype docs archived. 49 total entries.

### Session 6 (Feb 7, 2026)
Malbers ecosystem evaluation COMPLETE. Evaluated 5 assets (ENTRY-028 through ENTRY-032) plus completed ENTRY-001 (Inventory, previously at Testing). Results: 3 Approved (Animal Controller, Ultimate Selector, Fishing for AC), 1 Approved (Poly Art Raccoon - Scorch replacement candidate), 1 Conditional (Inventory System - slot-based, reference only for HOK grid), 1 Deferred (Horse Animset Pro - no riding use case). ENTRY-001 updated from Testing to Conditional. Key findings: AC's ScriptableVar system shares Ryan Hipple lineage with SOAP (compatible, not competing). Fishing for AC is production-ready HOK core gameplay (3 fishing modes, ScriptableObject fish definitions, native AC State integration). Raccoon Poly Art is a strong Scorch replacement (42+ animations, swim-capable, low-poly, underworld-themed material variants). 32 total entries in asset log.

### Session 5 (Feb 7, 2026)
Transitioned from dev tools to game-related asset evaluations. Head-to-head comparisons: PWB vs PGG (complementary, not competing - PWB kept for HOK, PGG removed but not blacklisted), UModeler X vs DA PolyPaint (complementary - vertex color painting vs UV atlas remapping). UModeler X Plus fully installed and promoted to **Default 3D** package. DA PolyPaint Conditional for HOK palette enforcement. UniTask evaluated for TecVooDoo absorption - rejected (70K LOC, deep PlayerLoop integration, keep as standalone). Logged ENTRY-024 through ENTRY-027. Established evaluation rule: do not penalize third-party assets for `var` or coding style preferences (Lesson #10). Created TecVooDoo Utilities project documentation (`E:\Unity\DefaultUnityPackages\com.tecvoodoo.utilities\Documents\`) with Status and CodeReference docs - architecture planned, cherry-pick candidates catalogued, no code written yet. Next: Malbers ecosystem evaluation (5 packages), low-poly art pipeline evaluation (6 packages).

### Session 4 (Feb 6-7, 2026)
Developer tools batch evaluation COMPLETE. Evaluated 17 assets total (ENTRY-007 through ENTRY-023). Results: 4 Approved (UDebug Panel, Fullscreen Editor, Scriptable Sheets, plus v-series from session 3), 6 Conditional (Git Amend Utils, Improved Timers, RNGNeeds, Wingman, DevTrails, Code Monkey cherry-pick, Backbone Logger pattern ref), 7 Rejected (Hierarchy Designer, Folder System, Visual Console, Runtime Debugger Toolkit, Scripts Vault, Init(args), Binding System 2). TecVooDoo utility library concept established as a local package absorbing best pieces from Git Amend, Improved Timers, Code Monkey Toolkit, and Backbone Logger patterns. Init(args) and Binding System 2 rejected for SOAP architectural conflict.

### Session 3 (Feb 6, 2026)
Asset documentation survey and editor tool evaluations. Catalogued local docs for all 21 installed Asset Store packages. Indexed online documentation for Malbers AC (285 pages), Sunfish Fishing (37 pages), UModeler X (291 pages), Odin Inspector, vHierarchy, and vFolders. Evaluated 4 editor tools: vHierarchy 2, vFolders 2, vFavorites 2, Ultimate Preview Window Pro - all Approved and promoted to default packages for all TecVooDoo Unity projects (ENTRY-003 through ENTRY-006 in Sandbox_AssetLog.md).

### Session 2 (Feb 6, 2026)
MCP connection troubleshooting and resolution. Cleaned stale MCP configs across three Claude config directories. Found and fixed duplicate server process spawning (15 zombie processes). Rolled back to v9.4.0 beta with unity-mcp-main/Server - connection works.

### Session 1 (Feb 6, 2026)
Project setup session. Created documentation (Sandbox_Status.md, Sandbox_AssetLog.md, Sandbox_Troubleshooting.md). Upgraded Unity from 6000.3.0f1 to 6000.3.7f1 to fix false invalid package signature warnings. Installed 19 Asset Store packages for evaluation. Fixed two [SerializeField]-on-class compile errors (Malbers Lootbag.cs, FImpossible FGraph_Scr_Port.Interface.cs). MCP for Unity upgraded to 9.4.1-beta.1 but connection not verified. Asset inventory CSV reviewed: 2,591 assets worth ~$24K, 1,237 URP-compatible.

---

## Version History (Archived)

| Version | Date | Summary |
|---------|------|---------|
| 24 | Feb 10, 2026 | Session 21 (continued): Acheron scene built and running in Unity. RiverSplineSetup.cs created. 11-knot spline X=0 to X=500. Cave ceiling fix (Lesson #19). Water material: SW3 Lowpoly custom dark slate. Known issue: river/mountain clipping. 49 total entries. |
| 23 | Feb 10, 2026 | Session 20: HOK folder structure implemented at Assets/Sandbox/HOK/. Acheron.unity moved to Scenes/Rivers/. 49 total entries. |
| 22 | Feb 10, 2026 | Session 19: Pre-implementation prep. Creature consolidation (~45 species, 5 rivers). Migration Manifest created (4-tier system, 49 entries). Coding guidelines reconciled. 49 total entries. |
| 21 | Feb 9, 2026 | Session 18: Soul destination correction (tiered system). Camera system decision (#41). GDD Sections 6, 7, 11 updated. 49 total entries. |
| 20 | Feb 9, 2026 | Session 17: HOK GDD v1.6. ALL 40 decisions locked -- design phase COMPLETE. 25 decisions this session. Stygian Marsh hub, scene transitions. 49 total entries. |
| 19 | Feb 9, 2026 | Session 16: HOK GDD deep design session. GDD v1.0-v1.5. 15 design decisions locked. 49 total entries. |
| 18 | Feb 9, 2026 | Session 15: HOK redesign -- full research and design phase. 7 HOK documents. Blaze AI evaluated (ENTRY-049, Deferred). 49 total entries. |
| 17 | Feb 9, 2026 | Sessions 13-14: Document archive system. 3 archive files created. 2 raft assets evaluated (ENTRY-047-048). 48 total entries. |
| 16 | Feb 8, 2026 | Session 12: Fixed SW3 InternalErrorShader. River water speed tuned. 4 assets evaluated (ENTRY-043-046). Scene renamed River Acheron. 46 total entries. |
| 15 | Feb 8, 2026 | Session 11 (continued): River Styx scene built via MCP. 35+ objects. SW3 materials broken from Library deletion. |
| 14 | Feb 8, 2026 | Session 11: MCP for Unity troubleshooting resolved. Reinstalled fresh 9.4.1-beta.1 (replaced stale v9.4.0 rollback). Bridge and telemetry both working. Troubleshooting doc updated with Phase 3 resolution. |
| 13 | Feb 8, 2026 | Session 10: Ripple Shader Pack (Eldvmo) evaluated and Rejected. BiRP shaders incompatible with URP, all capabilities covered by SW3 Dynamic Effects. ENTRY-042 logged. Lesson #16 added. 42 total entries. |
| 12 | Feb 7, 2026 | Session 9: TecVooDoo Utilities Sandbox migration. Removed Git Amend packages (improvedtimers, unityutils) from manifest. Resolved stale Library/Bee CS2001 errors. Sandbox compiles clean with com.tecvoodoo.utilities. Local Packages table updated. |
| 11 | Feb 7, 2026 | Session 8: Deep code review + Stylized Water 3 evaluation. polyperfect scripts fully reviewed (Animals 25 scripts, People 23 scripts) - NOT Malbers-compatible. SW3 Approved as CRITICAL for HOK. Malbers Raccoon nul ghost file fixed. 41 total entries. |
| 10 | Feb 7, 2026 | Session 7: Low-poly art pipeline evaluation COMPLETE. 6 new entries (ENTRY-033 through ENTRY-038). Fish Alive, GanzSe Props, Poly Universal, polyperfect Animals/People, City People all Approved. 38 total entries. |
| 9 | Feb 7, 2026 | Session 6: Malbers ecosystem evaluation COMPLETE. 5 new entries (ENTRY-028 through ENTRY-032). AC Approved, Fishing for AC Approved, Ultimate Selector Approved, Raccoon Approved, Inventory Conditional, Horse Deferred. 32 total entries. |
| 8 | Feb 7, 2026 | Session 5: Game-related evaluations started. PWB vs PGG, UModeler X Plus promoted to Default 3D, DA PolyPaint Conditional, UniTask stays standalone. TecVooDoo Utilities docs created. 27 total entries. |
| 7 | Feb 7, 2026 | Session 4: Developer tools batch evaluation COMPLETE. 17 assets evaluated (ENTRY-007 through ENTRY-023). 4 Approved (UDebug Panel, Fullscreen Editor, Scriptable Sheets, Wingman conditional). 6 Conditional (Git Amend Utils, Improved Timers, RNGNeeds, Wingman, DevTrails, Code Monkey cherry-pick). 7 Rejected (Hierarchy Designer, Folder System, Visual Console, Runtime Debugger Toolkit, Scripts Vault, Init(args), Binding System 2). TecVooDoo utility library concept established. Init(args) and Binding System 2 rejected for SOAP architectural conflict. |
| 6 | Feb 6, 2026 | Session 3: Editor tool evaluations complete. vHierarchy 2, vFolders 2, vFavorites 2, Ultimate Preview Window Pro all Approved as default packages for all projects (ENTRY-003 through ENTRY-006). Documentation survey for all installed assets. Online doc indexing for Malbers AC, Sunfish Fishing, UModeler X, Odin, vHierarchy, vFolders. |
| 5 | Feb 6, 2026 | Session 2: MCP troubleshooting resolved. Cleaned duplicate server registrations across 3 Claude config dirs. Fixed 15-zombie-process issue. Rolled back from unity-mcp-beta to unity-mcp-main server (v9.4.0 beta). Connection verified working. |
| 4 | Feb 6, 2026 | Fixed FImpossible Creations FGraph_Scr_Port.Interface.cs compile error (same [SerializeField] on class pattern). MCP connection troubleshooting: server path corrected from unity-mcp-main to unity-mcp-beta. Awaiting restart verification. Documented all session work. |
| 3 | Feb 6, 2026 | Added 19 Asset Store packages for evaluation. Updated Unity Registry packages for 6000.3.7f1 (Burst 1.8.27, Input System 1.18.0, Sentis 2.5.0, AI Toolkit pre.2, etc.). Fixed Malbers Inventory System Lootbag.cs compile error ([SerializeField] on class -> [System.Serializable]). |
| 2 | Feb 6, 2026 | Updated Unity from 6000.3.0f1 to 6000.3.7f1. Resolved false invalid package signature warnings (known bug fixed in 6000.3.5f2+). |
| 1 | Feb 6, 2026 | Initial document creation. Package inventory from Unity Package Manager. HOK conventions inherited. |

---

## Completed Experiments

### Malbers Ecosystem Evaluation - COMPLETE
Animal Controller (Approved), Inventory System (Conditional), Ultimate Selector (Approved), Fishing for AC (Approved), Poly Art Raccoon (Approved - Scorch replacement), Horse Animset Pro (Deferred). Key finding: AC's ScriptableVar system and SOAP share Ryan Hipple lineage - compatible architectures. Fishing for AC is HOK's core gameplay engine. Runtime testing via River Acheron scene build.

### Low-Poly Art Pipeline - COMPLETE
Fish Alive (Approved - complete fish behavior system, complementary to Fishing for AC), GanzSe Fishing Props (Approved - 70 underworld-themed props), Poly Universal Pack (Approved - 6,029 model library), polyperfect Low Poly Animated Animals (Approved - 50+ species, 25 scripts with full predator-prey AI, NOT Malbers-compatible), polyperfect Low Poly Animated People (Approved - 80+ characters, 23 scripts with IK + AI + morpher, NOT Malbers-compatible), City People Mega-Pack (Approved - 157+ characters). All visually compatible with HOK low-poly style. Malbers AC compatibility confirmed incompatible at script level - strip scripts to use models/anims with AC.

### Stylized Water 3 Ecosystem - COMPLETE
Stylized Water 3 (Approved - CRITICAL for HOK, 74 scripts, Gerstner waves, GPU height queries, 49 materials, Render Graph). Dynamic Effects (Approved - displacement, wake, ripples, shoreline waves). Underwater Rendering (Approved - box trigger zones, fog, shading, waterline, mobile support). River Modeler (Approved - spline-based river geometry, native SW3 integration). Exemplary code quality, proper asmdefs, StylizedWater3 namespace. 4 Staggart packages, all interoperable. Runtime testing via River Acheron scene build.

### Editor Tools - COMPLETE
UModeler X Plus, Prefab World Builder, vFavorites/vFolders/vHierarchy, Ultimate Preview, DA PolyPaint. All evaluated. Quality-of-life tools for development workflow.

---

**End of Archive**
