# Recovered ENTRY Blocks (001-115)

Recovered from 59 JSONL files on Feb 24, 2026 (Session 37).

**Total recovered:** 67 of 115 entries.

**Still missing (48):** Entries [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49]

These entries are from the earliest Sandbox sessions (Sessions 1-14 approx) and may predate JSONL logging or use a different project key.

---

### ENTRY-027: DA PolyPaint - Atlas Color Mapper

---

### ENTRY-050: Unity-Theme

| Field | Value |
|-------|-------|
| **Asset** | Unity-Theme |
| **Source** | GitHub (IvanMurzak) |
| **Version** | Latest (TBD) |
| **Category** | UI |
| **Date Started** | 2026-02-11 |
| **Date Completed** | Deferred |
| **Verdict** | Deferred |
| **HOK Applicable** | Yes |

**What It Does:**
Color palette management system with runtime theme switching. Create named color palettes and bind them to UI components (Image, Text, Button, SpriteRenderer, etc.) with instant runtime switching support.

**Why We're Interested:**
- River-specific theming (dark Acheron, bright Lethe, fiery Phlegethon)
- GUID-based color connections (rename colors without breaking references)
- 13+ built-in component binders
- Instant runtime switching: `Theme.Instance.CurrentThemeName = "Acheron"`

**Potential Use Cases:**
- Per-river color schemes for UI elements
- Dynamic mood/atmosphere changes
- Codex visual styling per environment
- Merchant shop theming

**Known Limitations:**
- uGUI only, no UI Toolkit support (HOK uses uGUI via Lean GUI, so not a blocker)

**Integration Concerns:**
- None identified yet. Need to verify compatibility with existing UI packages (Lean GUI, Dialogue System)

**HOK Notes:**
High applicability. Could replace manual material/color management for environment-specific UI theming. Test with simple scene-based theme switching first.

---

### ENTRY-051: Unity-ImageLoader

| Field | Value |
|-------|-------|
| **Asset** | Unity-ImageLoader |
| **Source** | GitHub (IvanMurzak) |
| **Version** | Latest (TBD) |
| **Category** | UI |
| **Date Started** | 2026-02-11 |
| **Date Completed** | Deferred |
| **Verdict** | Deferred |
| **HOK Applicable** | Yes |

**What It Does:**
Asynchronous image loading from remote or local sources with dual-layer caching (RAM + disk). Outputs Texture2D or Sprite objects with smart deduplication to avoid loading same image multiple times.

**Why We're Interested:**
- Codex fish/soul/merchant portrait loading on-demand
- Prevents loading all portraits at startup
- Async/await prevents UI freezing
- Disk cache survives sessions

**Potential Use Cases:**
- Codex entry portraits (load when viewed, cache for quick reopen)
- Merchant portraits in dialogue
- Soul passenger portraits in ferry manifest
- Custom fishing rod/gear icons

**Known Limitations:**
- Documentation doesn't specify supported image formats (assume standard Unity: PNG, JPG)

**Integration Concerns:**
- Need to verify compatibility with Dialogue System's portrait system
- Test with Easy Save 3 to ensure no cache conflicts

**HOK Notes:**
High applicability. Codex could have 40+ fish portraits - loading all at start impacts startup time and memory. On-demand loading with caching is the right pattern. Test with mock codex UI first.

---

### ENTRY-052: Unity-AI-Animation

| Field | Value |
|-------|-------|
| **Asset** | Unity-AI-Animation |
| **Source** | GitHub (IvanMurzak) |
| **Version** | Latest (TBD) |
| **Category** | Tools |
| **Date Started** | 2026-02-11 |
| **Date Completed** | Deferred |
| **Verdict** | Deferred |
| **HOK Applicable** | Maybe |

**What It Does:**
AI-powered animation tools that let Claude Code create and modify AnimationClips and AnimatorControllers via natural language commands. Automates animation setup, curve editing, state machine configuration, and transition management.

**Why We're Interested:**
- Could speed up fish swimming animation variants
- Automate AnimatorController state setup
- Procedural animation for background ambient creatures
- Quick prototyping of soul passenger idle animations

**Potential Use Cases:**
- Creating animation variants for fish species (fast/slow swim cycles)
- Setting up AnimatorController transitions for NPCs
- Prototyping soul passenger animations
- Animating environmental props (swaying reeds, floating debris)

**Known Limitations:**
- Experimental tool (23 stars)
- Requires MCP server setup
- May not integrate well with Malbers AC's animation system

**Integration Concerns:**
- Malbers AC uses its own State/Mode/Stance animation system
- Fish Alive pack already has pre-made animations
- Would this conflict with AC's AnimatorController structure?

**HOK Notes:**
Medium applicability. Most critical animations are covered by existing packs (Fish Alive, Malbers AC content, polyperfect). Could be useful for rapid prototyping or creating animation variants, but likely not critical path. Test only if animation setup becomes a bottleneck.

---

### ENTRY-053: Unity-AI-ParticleSystem

| Field | Value |
|-------|-------|
| **Asset** | Unity-AI-ParticleSystem |
| **Source** | GitHub (IvanMurzak) |
| **Version** | Latest (TBD) |
| **Category** | VFX |
| **Date Started** | 2026-02-11 |
| **Date Completed** | Deferred |
| **Verdict** | Deferred |
| **HOK Applicable** | Maybe |

**What It Does:**
AI-powered particle system creation via natural language commands. Let Claude Code generate particle effects by describing the desired visual (bubbles, splashes, glows, etc.).

**Why We're Interested:**
- Rapid VFX prototyping (fishing line splash, hook impact, bubble trails)
- Soul glow/aura effects
- Environmental atmosphere (cave dust, underwater particles, Phlegethon embers)
- Fishing line tension sparks

**Potential Use Cases:**
- Bobber splash when cast lands
- Underwater bubble trails following hook
- Soul passenger ghostly aura
- River-specific atmospheric particles
- Catch celebration effects

**Known Limitations:**
- Very small community (6 stars)
- Experimental tool
- Unknown if it can create VFX matching existing SW3 aesthetic

**Integration Concerns:**
- Environment/Weather/Nature VFX Pack already installed (Conditional - BiRP conversion needed)
- SW3 Dynamic Effects provides water-specific VFX
- Would AI-generated particles match low-poly art style?

**HOK Notes:**
Low-medium applicability. VFX needs are mostly covered by SW3 ecosystem and Nature VFX pack. Could be useful for rapid iteration if existing VFX don't fit, but not a priority. Test only if VFX pipeline becomes a bottleneck or if Nature VFX pack proves insufficient.

---

### ENTRY-054: Unity-Package-Template

| Field | Value |
|-------|-------|
| **Asset** | Unity-Package-Template |
| **Source** | GitHub (IvanMurzak) |
| **Version** | Latest (TBD) |
| **Category** | Tools |
| **Date Started** | 2026-02-11 |
| **Date Completed** | Deferred |
| **Verdict** | Deferred |
| **HOK Applicable** | Maybe |

**What It Does:**
Template repository for creating Unity packages with proper UPM (Unity Package Manager) structure and versioning. Supports both OpenUPM and NPMJS distribution. Includes CI/CD setup and package.json configuration examples.

**Why We're Interested:**
- TecVooDoo Utilities package needs proper UPM structure
- Could formalize internal package distribution across projects
- Learn package development best practices
- Potential for publishing TecVooDoo tools publicly

**Potential Use Cases:**
- Restructure TecVooDoo Utilities as proper UPM package
- Create reusable HOK-specific utilities as separate package
- Package up custom tools for future projects
- Learn GitHub-based package distribution

**Known Limitations:**
- Template only, not a runtime tool
- Requires GitHub repository setup and versioning discipline

**Integration Concerns:**
- None - this is a development workflow tool, not a runtime dependency

**HOK Notes:**
Medium applicability. Not directly related to HOK gameplay, but useful for internal tooling infrastructure. TecVooDoo Utilities is already in local package format - this would formalize the structure for better version management across projects. Reference when ready to publish or formalize internal packages, not critical for current Sandbox work.

---

### ENTRY-055: Unity-AI-ProBuilder

| Field | Value |
|-------|-------|
| **Asset** | Unity-AI-ProBuilder |
| **Source** | GitHub (IvanMurzak) |
| **Version** | Latest (TBD) |
| **Category** | Tools |
| **Date Started** | 2026-02-11 |
| **Date Completed** | Deferred |
| **Verdict** | Deferred |
| **HOK Applicable** | No |

**What It Does:**
AI-powered 3D modeling tools for Unity ProBuilder. Let Claude Code generate and edit 3D meshes through natural language commands (create shapes, extrude faces, bevel edges, apply materials, etc.).

**Why We're Interested:**
- ProBuilder is already installed in Sandbox
- Could automate level geometry creation
- Natural language 3D modeling for rapid prototyping
- Potential for procedural environment pieces

**Potential Use Cases:**
- Generating simple collision meshes
- Creating placeholder geometry for testing
- Prototyping level layouts
- Custom dock/pier structures

**Known Limitations:**
- Small community (22 stars)
- Requires MCP server setup
- HOK uses asset packs for art, not procedural modeling

**Integration Concerns:**
- HOK art pipeline is asset-based (JustCreate terrain/rocks, polyperfect props)
- UModeler X already covers custom mesh creation needs
- Adding AI-based modeling would introduce new workflow

**HOK Notes:**
Low applicability to HOK. The project uses low-poly asset packs for visual consistency, not procedural modeling. Custom mesh work (if needed) is handled by UModeler X or commissioned from art team. AI-powered ProBuilder might be useful for non-HOK projects requiring rapid level geometry prototyping, but doesn't fit HOK's asset-driven pipeline. Evaluate only if a non-HOK project requires procedural 3D modeling.

---

### ENTRY-056: MCP for Unity / AI Game Developer (IvanMurzak)

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
**Critical infrastructure for all HOK development.** Every scene build (Acheron greybox), every asset evaluation (theme testing, image loader wiring), and every editor tool script was created or executed through this MCP bridge. For HOK migration: install this package first, then use it to bootstrap everything else. The HOK project already has an older version (noted as 9.0.7 in Status doc but needs verification) -- upgrade to match Sandbox version (0.46.0) for full tool parity. Default package designation means it ships with every new TecVooDoo Unity project.

**Key Lessons (consolidated from 22+ sessions):**
1. **script-execute first, component tools second.** For any non-trivial setup, write a complete C# script and execute via Roslyn. It's more reliable, more capable, and often faster than chaining individual tool calls.
2. **HTML encoding workaround.** C# generics (`List<int>`) become `List&lt;int&gt;` in MCP params. Use `typeof()` casts. `&&` becomes `&amp;&amp;` -- use nested if-statements.
3. **Explicit persistence.** Roslyn scripts run in memory. Scene changes need `EditorSceneManager.SaveScene()`. Asset changes need `AssetDatabase.SaveAssets()`. ScriptableObject changes need `.Save()` or `EditorUtility.SetDirty()` + `AssetDatabase.SaveAssets()`.
4. **Domain reload kills connection.** When Unity recompiles scripts (after script-update-or-create, package install, etc.), the MCP connection drops. Wait for reconnection before issuing the next command. If connection doesn't restore, use Unity menu to manually restart.
5. **Reflection for private fields.** Many third-party packages use `[SerializeField] private` fields (e.g., Unity-Theme's ColorBinderData.colorGuid). Access via `typeof(T).GetField("fieldName", BindingFlags.NonPublic | BindingFlags.Instance)` in script-execute.

---

### ENTRY-057: Unity-AI-Tools-Template

| Field | Value |
|-------|-------|
| **Asset** | Unity-AI-Tools-Template |
| **Source** | GitHub (IvanMurzak) |
| **Package ID** | N/A (template repository, not installable) |
| **Version** | 1.0 (56 commits) |
| **Category** | Tools (Development) |
| **Date Started** | 2026-02-11 |
| **Date Completed** | 2026-02-11 |
| **Verdict** | Deferred |
| **HOK Applicable** | No |

**What It Does:**
GitHub template repository for creating custom MCP tools for Unity. Provides scaffolding to build new tools that integrate with the AI Game Developer (MCP for Unity) platform. Supports both editor-focused and runtime tools. Includes CI/CD workflows, init scripts with auto-renaming, and meta file generation.

**Technical Details:**
- C# 70.2%, PowerShell 26.3%, Shell 3.5%
- MIT license
- 10 stars, 2 forks
- Not an installable package -- GitHub "Use this template" workflow
- Six-step setup: create repo from template, clone, run init, configure package.json, generate metas, add tool code

**Assessment:**
This is for creating **new** MCP tools from scratch. The base MCP package (ENTRY-056) already provides 52 tools, and the AI-Animation (052), AI-ParticleSystem (053), and AI-ProBuilder (055) extensions add domain-specific tools. Creating custom MCP tools would only make sense if HOK needs a specialized tool not covered by existing packages -- e.g., a "fishing-setup" tool that configures Malbers AC fishing states, or a "river-builder" tool that chains SW3 + River Modeler setup.

**Why Deferred:**
No current need for custom MCP tool authoring. The 52 base tools plus 3 available extensions cover all current workflows. Script-execute (Roslyn) handles anything the dedicated tools can't. Revisit only if a repeated multi-step MCP workflow becomes painful enough to justify packaging it as a dedicated tool.

---

### ENTRY-058: Unity-EFCore-SQLite

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

### ENTRY-059: Unity-PlayerPrefsEx

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

### ENTRY-060: Unity-Extensions

| Field | Value |
|-------|-------|
| **Asset** | Unity-Extensions |
| **Source** | GitHub (IvanMurzak) / npm |
| **Package ID** | extensions.unity.base (+ 6 sub-modules) |
| **Version** | 1.9.0 (base) |
| **Category** | Tools (Utility) |
| **Date Started** | 2026-02-11 |
| **Date Completed** | 2026-02-11 |
| **Verdict** | Deferred |
| **HOK Applicable** | Maybe |

**What It Does:**
Collection of modular Unity extension packages distributed via npm. Each module is independently installable. Seven modules total covering base extensions, data saving, networking, IAP, reactive extensions, UI extensions, and shape utilities.

**Available Modules:**

| Module | Package ID | Version | What It Does |
|--------|-----------|---------|-------------|
| Base | `extensions.unity.base` | 1.9.0 | Core utility extensions |
| Saver | `extensions.unity.saver` | 1.0.6 | Data persistence with device encryption |
| Network REST | `extensions.unity.network` | 1.3.3 | REST API client (SOLID principles) |
| IAP Store | `extensions.unity.iap.store` | 2.0.6 | In-app purchase wrapper |
| UniRx Extensions | `extensions.unity.unirx` | 1.1.5 | Reactive extensions for UniRx |
| UI Extensions | `extensions.unity.ui` | 1.3.2 | UI utility extensions |
| Shapes RectTransform | `extensions.unity.shapes.recttransform` | 1.0.2 | RectTransform shape utilities |

**Technical Details:**
- C# 99.9%, MIT license
- 12 stars, npm registry distribution
- Modular -- install only what you need
- Requires scoped registry in manifest.json for `extensions.unity` scope

**Duplication Check:**
- **Saver** overlaps with PlayerPrefsEx (ENTRY-059) for encrypted save data. PlayerPrefsEx is already installed.
- **Network REST** -- no existing REST client installed, but HOK doesn't have network requirements in the current design
- **IAP Store** -- no in-app purchases planned for HOK
- **UniRx Extensions** -- UniRx is a reactive framework; HOK uses SOAP (event channels), not reactive streams. Architectural conflict.
- **UI Extensions** -- need to see actual content to assess. Could overlap with Odin Inspector's UI utilities.
- **Base** -- could have TecVooDoo utility candidates, but README lacks API detail

**TecVooDoo Utility Assessment:**
The README provides no method listings or API examples for any module. Without seeing the actual code, it's impossible to identify cherry-pick candidates for TecVooDoo Utilities. The modules that could contain useful utilities (Base, UI Extensions) need source code review. However, several modules have clear architectural conflicts (UniRx = reactive, not SOAP) or irrelevance (IAP = no monetization plan).

**Why Deferred:**
Insufficient documentation to evaluate without installing. The modules most relevant to TecVooDoo Utilities (Base, UI Extensions) have no public API documentation. The modules with clear documentation (IAP, UniRx, Network) are either irrelevant or architecturally incompatible. Revisit if: (1) TecVooDoo Utilities needs a REST client, (2) the base extensions are documented or source-reviewed, or (3) a specific utility gap emerges that these might fill. Do NOT install the full bundle -- cherry-pick individual modules only after confirming they don't duplicate existing packages.

---

### ENTRY-061: Unity-AudioLoader

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

### ENTRY-062: Unity-AI-Meshy

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

### ENTRY-063: MCP-Plugin-dotnet

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

### ENTRY-064: UBuilder

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

### ENTRY-065: NuGetForUnity (GlitchEnzo)

| Field | Value |
|-------|-------|
| **Asset** | NuGetForUnity |
| **Source** | GitHub (GlitchEnzo) / OpenUPM |
| **Package ID** | com.github-glitchenzo.nugetforunity |
| **Version** | v4.5.0 (latest release) |
| **Category** | Tools (Package Management) |
| **Date Started** | 2026-02-12 |
| **Date Completed** | In Progress |
| **Verdict** | Testing |
| **HOK Applicable** | Yes |

**What It Does:**
Full NuGet package manager inside the Unity Editor. Browse, search, install, update, and uninstall NuGet packages with automatic dependency resolution. Supports custom feeds (Azure Artifacts, GitHub Packages, JFrog Artifactory, local feeds). Includes CLI tool for CI/CD package restoration. Plugin architecture via `INugetPlugin`. MIT license, 4,300+ stars, actively maintained (community-driven, last commit Jan 2026).

**Why Evaluating:**
The current project uses OpenUPM's scoped registry to proxy NuGet packages (`org.nuget.*` entries in manifest.json) for the IvanMurzak MCP ecosystem. This approach broke when MCP v0.46.1 required `org.nuget.microsoft.extensions.options` which OpenUPM had not mirrored. NuGetForUnity manages NuGet packages directly from nuget.org, bypassing the OpenUPM proxy entirely. Evaluating whether it provides a more reliable NuGet dependency chain for the MCP package.

**Key Question:**
Can NuGetForUnity replace the `org.nuget.*` scoped registry entries while keeping MCP for Unity and its extension packages (AI-Animation, AI-ParticleSystem, AI-ProBuilder) fully functional? The two approaches should not be mixed.

**Installation:**
- OpenUPM: `com.github-glitchenzo.nugetforunity`
- Git URL: `https://github.com/GlitchEnzo/NuGetForUnity.git?path=/src/NuGetForUnity`

**Testing Plan:**
1. Install NuGetForUnity
2. Verify it resolves the same Microsoft.* / System.* NuGet dependencies that MCP requires
3. Test removing the `org.nuget.*` scoped registry entries
4. Verify MCP still connects and functions
5. Test whether v0.46.1 can be resolved (the version that broke on OpenUPM)

**Results:**
Testing in progress.

---

### ENTRY-066: Unity Toon Shader (Unity-Technologies)

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

**Installation:** `https://github.com/Unity-Technologies/com.unity.toonshader.git`

---

### ENTRY-067: BuildReportInspector (Unity-Technologies)

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

**Installation:** `https://github.com/Unity-Technologies/BuildReportInspector.git`

---

### ENTRY-068: ML-Agents (Unity-Technologies)

| Field | Value |
|-------|-------|
| **Asset** | Unity ML-Agents Toolkit |
| **Source** | GitHub (Unity-Technologies) / Unity Registry |
| **Package ID** | com.unity.ml-agents |
| **Version** | Release 23 / Unity Package 4.0.0 |
| **Category** | AI |
| **Date Started** | 2026-02-12 |
| **Date Completed** | In Progress |
| **Verdict** | Testing |
| **HOK Applicable** | Yes |

**What It Does:**
ML toolkit for Unity. Train intelligent agents using reinforcement learning (PPO, SAC, MA-POCA), imitation learning, and curriculum learning. 19,100+ stars, 508 contributors, Release 23 (Aug 2025). Python training side + Unity runtime package. 17+ example environments. Trained models export to ONNX for Sentis runtime inference.

**Why Installing:**
HOK has ~45 creature species with predator/prey ecology, a companion AI (Scorch), and merchant NPCs. ML-Agents can train believable fish behaviors (schooling, fleeing, feeding patterns), Scorch's contextual reactions, and ambient creature AI. Pairs with already-installed Sentis for runtime inference. The training pipeline: ML-Agents trains -> exports ONNX -> Sentis runs inference in-game.

**ML-Agents + Sentis Pipeline:**
1. **ML-Agents (training):** Define agent observations (position, nearby fish, water depth, player proximity) and rewards (realistic schooling, avoiding predators, natural movement). Train in simulation.
2. **Export:** ML-Agents produces ONNX models from trained behaviors.
3. **Sentis (runtime):** Load ONNX models in-game. Fish/creature behaviors run through neural network inference instead of hand-coded state machines.
4. **Advantage over scripted AI:** Emergent behaviors -- fish that "feel alive" without manually programming every edge case. The 45-species ecology with predator/prey chains is a perfect ML-Agents use case.

**Installation:** Unity Package: `com.unity.ml-agents` (Unity Registry). Python: `pip install mlagents` (separate).

---

### ENTRY-069: BoatAttack (Unity-Technologies) -- REFERENCE

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

### ENTRY-070: PaddleGameSO (UnityTechnologies) -- REFERENCE

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

### ENTRY-071: Game Programming Patterns Demo (UnityTechnologies) -- REFERENCE

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

### ENTRY-072: Sentis Samples (Unity-Technologies) -- REFERENCE

| Field | Value |
|-------|-------|
| **Asset** | Sentis Samples |
| **Source** | GitHub (Unity-Technologies) |
| **Category** | AI (Reference) |
| **Date Started** | 2026-02-12 |
| **Date Completed** | 2026-02-12 |
| **Verdict** | Deferred (Reference) |
| **HOK Applicable** | Yes |

**What It Is:** 8 sample projects for Unity Sentis inference. 316 stars. Text-to-speech, chat LLM, face/hand/pose detection, digit recognition, board-game AI, depth estimation, star simulation. Working code showing ONNX model loading and inference.

**Reference Value:** The board-game AI sample shows inference patterns applicable to game AI. When ML-Agents produces trained ONNX models for fish/creature behaviors, these samples demonstrate how to load and run them via Sentis. Clone when integrating trained models into HOK.

**URL:** `github.com/Unity-Technologies/sentis-samples`

---

### ENTRY-073: ZString (Cysharp)

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

### ENTRY-074: R3 (Cysharp)

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

### ENTRY-075: MemoryPack (Cysharp)

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

### ENTRY-076: ZLinq (Cysharp)

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

### ENTRY-077: MessagePipe (Cysharp)

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

### ENTRY-078: ObservableCollections (Cysharp)

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

### ENTRY-079: MasterMemory (Cysharp)

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

### ENTRY-080: UnitGenerator (Cysharp)

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

### ENTRY-081: StructureOfArraysGenerator (Cysharp)

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

### ENTRY-082: CsprojModifier (Cysharp)

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

### ENTRY-083: Simple Boids / #NVJOB Boids (NVJOB)

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

### ENTRY-084: Kamgam Mesh Extractor

| Field | Value |
|-------|-------|
| **Asset** | Mesh Extractor (Kamgam) |
| **Source** | Asset Store (Kamgam) |
| **Version** | Current (Feb 2026) |
| **Category** | Tools (Mesh Editing) |
| **Date Started** | 2026-02-17 |
| **Date Completed** | 2026-02-17 |
| **Verdict** | Approved - Default |
| **HOK Applicable** | Yes |

**What It Does:**
Scene-view mesh editing tool. Three-mode workflow: PickObjects (select GameObjects) -> PaintSelection (paint triangles on mesh surface) -> ExtractMesh (generate new assets). Works on both MeshFilter and SkinnedMeshRenderer. Outputs standalone prefabs with mesh, material, cropped textures, and bone data.

**Location:** `Assets/Kamgam/MeshExtractor/`

**What We Tested:**
Extracted the bag from a Poly Universal Pack alchemist character (SkinnedMeshRenderer with atlas texture). Performed both Extract (bag only) and Split (bag + remainder as separate assets).

**Results:**
- Generated complete standalone assets: prefab, mesh (.asset), material, cropped textures (BaseColorMap, albedo, metallic, emission, MaskMap), and BoneData
- Original character mesh left untouched
- Extracted bag prefab had a bounds/culling issue (disappeared when moving camera) -- fixed by enabling "Update When Offscreen" on SkinnedMeshRenderer
- Texture atlas auto-cropping worked correctly -- each piece got its own UV-correct textures
- Cannot fill holes left by extraction (separation tool, not surgery tool)

**Pros:**
- Complete asset pipeline: mesh + material + textures + bone data in one operation
- Works on skinned meshes with bone weight preservation
- Scene-view triangle painting is intuitive
- Supports OBJ export, texture extraction, sub-mesh preservation
- Proper asmdef organization (editor + runtime)

**Cons:**
- Extracted skinned meshes may need "Update When Offscreen" enabled (bounds issue)
- No hole-filling capability -- Blender needed if you want to close gaps after extraction
- Editor-only tool, cannot be driven via MCP/script (scene-view mouse interaction required)

**HOK Notes:**
Gold standard for modular character work. Use for: separating armor/accessories from characters, creating swappable equipment pieces, breaking combined meshes into independent prefabs for LOD or kitbashing.

---

### ENTRY-085: Kamgam Make Mesh Double-Sided

| Field | Value |
|-------|-------|
| **Asset** | Make Mesh Double-Sided (Kamgam) |
| **Source** | Asset Store (Kamgam) |
| **Version** | Current (Feb 2026) |
| **Category** | Tools (Mesh Editing) |
| **Date Started** | 2026-02-17 |
| **Date Completed** | 2026-02-17 |
| **Verdict** | Approved - Default |
| **HOK Applicable** | Yes - Critical |

**What It Does:**
Right-click context menu tool that generates real double-sided meshes by duplicating and inverting vertices/triangles. Shader-independent -- works with any material/shader including custom ones. Two modes: same-material (inside = outside) and duplicate sub meshes (separate material slots for inside vs outside).

**Location:** `Assets/MakeMeshDoubleSided/`

**What We Tested:**
Applied to character mesh in KamgamEval scene. Both standard and duplicate-sub-mesh modes. Also works on prefabs from Project window.

**Results:**
- One right-click, instant conversion
- Saves `<name>.double-sided.asset` next to original mesh
- Auto-enables "Two Sided" shadow casting on the renderer
- Duplicate sub meshes mode correctly creates Element 0 (outside) + Element 1 (inside) material slots
- Doubles triangle count (expected tradeoff -- backface culling handles most of the cost)

**Pros:**
- Dead simple: right-click -> Make Mesh -> Double-sided
- Shader-independent (the whole point -- no custom shader needed)
- Works on MeshFilter, SkinnedMeshRenderer, and prefabs
- Duplicate sub meshes option enables different inside/outside materials (robe lining, etc.)
- Auto-configures two-sided shadows

**Cons:**
- Doubles triangle count (mitigated by backface culling in practice)
- Lightmap artifacts possible with double-sided GI (lighting bleed on front faces)
- No selective application -- entire mesh becomes double-sided

**HOK Notes:**
Directly solves the Unity Terrain single-sided gotcha for cave ceilings. Also critical for: cloth/capes, raft sail interiors, any thin geometry visible from both sides. Eliminates need for custom double-sided shaders in URP.

---

### ENTRY-086: Kamgam Mesh Smoother

| Field | Value |
|-------|-------|
| **Asset** | Mesh Smoother (Kamgam) |
| **Source** | Asset Store (Kamgam) |
| **Version** | Current (Feb 2026) |
| **Category** | Tools (Mesh Editing) |
| **Date Started** | 2026-02-17 |
| **Date Completed** | 2026-02-17 |
| **Verdict** | Approved - Default |
| **HOK Applicable** | Yes |

**What It Does:**
Scene-view mesh smoothing tool. Paint-select triangles on a mesh surface, then apply smoothing operations. Works on both MeshFilter and SkinnedMeshRenderer. Saves modified meshes as assets with bone data preservation.

**Location:** `Assets/Kamgam/MeshSmoother/`

**What We Tested:**
Used on character mesh in KamgamEval scene. Triangle selection and smoothing operations.

**Results:**
- Scene-view painting workflow consistent with MeshExtractor
- Smoothing applies to selected triangles only (targeted, not whole-mesh)
- Bone data preserved on skinned meshes
- Includes OBJ export option
- Proper undo support

**Pros:**
- Targeted smoothing (paint only the area you want)
- Works on skinned meshes with bone weight preservation
- Consistent UI with other Kamgam tools
- Proper asmdef organization (editor + runtime)

**Cons:**
- Cannot create new geometry (no hole filling, no vertex insertion)
- Editor-only, cannot be scripted via MCP
- Smoothing low-poly meshes can lose intentional hard edges

**HOK Notes:**
Useful for cleaning up mesh artifacts after extraction, smoothing terrain mesh edges, or softening low-poly character joints. Pairs well with MeshExtractor.

---

### ENTRY-087: Kamgam Polygon Material Painter

| Field | Value |
|-------|-------|
| **Asset** | Polygon Material Painter (Kamgam) |
| **Source** | Asset Store (Kamgam) |
| **Version** | Current (Feb 2026) |
| **Category** | Tools (Mesh Editing) |
| **Date Started** | 2026-02-17 |
| **Date Completed** | 2026-02-17 |
| **Verdict** | Approved - Default |
| **HOK Applicable** | Yes |

**What It Does:**
Scene-view tool for painting materials onto individual triangles/polygons. Select triangles by painting, assign a different material to the selection. Creates new sub-meshes as needed. Works on MeshFilter and SkinnedMeshRenderer.

**Location:** `Assets/Kamgam/PolygonMaterialPainter/`

**What We Tested:**
Used on character mesh in KamgamEval scene. Triangle selection and material assignment.

**Results:**
- Paint-select triangles, assign material -- creates new submesh automatically
- Per-triangle material assignment without UV editing
- Mesh saved with new submesh structure
- Includes blend shape preservation and OBJ export

**Pros:**
- Per-triangle material control without touching UVs or textures
- Creates submeshes automatically for material separation
- Consistent scene-view painting UI with other Kamgam tools
- Blend shape support
- Proper asmdef organization

**Cons:**
- Each unique material = one draw call (submesh overhead if overused)
- Editor-only, cannot be scripted via MCP
- Not a replacement for proper texture painting (no color/detail, just material swaps)

**HOK Notes:**
Useful for assigning different materials to character parts (metal armor vs cloth vs skin) without re-UV-mapping. Pairs with MeshExtractor for modular character workflows.

---

### ENTRY-088: Kamgam UV Editor

| Field | Value |
|-------|-------|
| **Asset** | UV Editor (Kamgam) |
| **Source** | Asset Store (Kamgam) |
| **Version** | Current (Feb 2026) |
| **Category** | Tools (Mesh Editing) |
| **Date Started** | 2026-02-17 |
| **Date Completed** | 2026-02-17 |
| **Verdict** | Approved - Default |
| **HOK Applicable** | Yes |

**What It Does:**
In-editor UV editing tool. Scene-view triangle selection combined with a UV editor window for moving, rotating, and scaling UV islands. Works on MeshFilter and SkinnedMeshRenderer. Bone data preserved.

**Location:** `Assets/Kamgam/UVEditor/`

**What We Tested:**
Used on character mesh in KamgamEval scene. Triangle selection and UV manipulation.

**Results:**
- Scene-view triangle painting selects UV islands
- UV editor window shows texture atlas with selected triangles highlighted
- Move, rotate, scale UV islands within the editor
- Bone data and mesh structure preserved
- Proper undo support

**Pros:**
- Edit UVs without leaving Unity (no Blender roundtrip)
- Scene-view selection shows exactly which triangles map to which UVs
- Works on skinned meshes with bone weight preservation
- Consistent UI with other Kamgam tools
- Proper asmdef organization (editor + runtime)

**Cons:**
- Not a full UV unwrapper (can't create new UV layouts from scratch)
- Editor-only, cannot be scripted via MCP
- Limited compared to Blender's UV tools for complex re-mapping

**HOK Notes:**
Quick UV fixes without exporting to Blender. Useful for adjusting texture alignment on extracted mesh pieces, fixing UV seams, or repositioning UV islands after mesh extraction.

---

### ENTRY-089: Animancer Pro v8 (Kybernetik)

| Field | Value |
|-------|-------|
| **Asset** | Animancer Pro v8 (Kybernetik) |
| **Source** | Asset Store |
| **Version** | v8.0 (Feb 2026) |
| **Category** | Animation |
| **Date Started** | 2026-02-18 |
| **Date Completed** | 2026-02-18 |
| **Verdict** | Approved - Default |
| **HOK Applicable** | Yes - Critical |

**What It Does:**
Code-driven animation system built on Unity's Playables API. Replaces Animator Controllers with direct C# control over animation playback, blending, layers, mixers, transitions, and events. No state machines or Animator windows needed.

**Location:** `Packages/com.kybernetik.animancer/`

**What We Tested:**
Full hands-on evaluation on Kharon character. Created AnimancerTest.cs with number-key controls for idle, walk, sit, stand-up, step-down, fishing cast/loop. Tested crossfading, layer blending with AvatarMask, integration with Final IK.

**Results:**
- Animation crossfading works flawlessly -- smooth blends between all clip types
- Layer system works for upper/lower body separation (AvatarMask on layer 1)
- Integrates naturally with Final IK (Animancer drives Playables, Final IK corrects in LateUpdate)
- AnimancerState provides NormalizedTime for precise IK release timing during stand-up transitions
- No per-frame allocations, clean Playables-based architecture

**Pros:**
- Eliminates Animator Controller complexity -- all animation logic in code
- Clean package with 4 asmdefs, Animancer namespace, no global pollution
- Excellent layer/mixer system for blending
- State tracking (NormalizedTime, IsPlaying, Events) enables precise transition control
- No dependency on other packages

**Cons:**
- First import catalogs every .fbx in the project -- very slow on large projects with many 3D assets. **Install before importing 3D art assets.**
- Learning curve for developers used to Animator Controller workflows
- Pro version required for layers, mixers, and advanced features (Free version is limited)

**HOK Notes:**
Core animation system for HOK. Replaces Animator Controllers entirely. Code-driven approach aligns perfectly with HOK's custom architecture (no Malbers AC, no SOAP). Combined with Final IK, provides complete animation + IK pipeline. Stand-up transition fix (IK hold until NormalizedTime threshold) demonstrates the precision available.

---

### ENTRY-090: Final IK (RootMotion)

| Field | Value |
|-------|-------|
| **Asset** | Final IK (RootMotion) |
| **Source** | Asset Store |
| **Version** | Current (Feb 2026) |
| **Category** | Animation (IK) |
| **Date Started** | 2026-02-18 |
| **Date Completed** | 2026-02-18 |
| **Verdict** | Approved - Default |
| **HOK Applicable** | Yes - Critical |

**What It Does:**
Full Body Biped IK (FBBIK) with 9 effectors (body, left/right hand, left/right foot, left/right shoulder, left/right thigh). GrounderFBBIK for automatic foot grounding via raycasts. Runs in LateUpdate after all animation. Pure C#, no Jobs/Burst dependency.

**Location:** `Assets/Plugins/RootMotion/` (no asmdefs, lives in Assembly-CSharp)

**What We Tested:**
Added FBBIK and GrounderFBBIK to Kharon. Auto-detected all bone references. Tested foot grounding on raft surface, sit IK with body/foot effectors pinned to cooler targets, Grounder weight fading during sit/stand transitions, coordinated IK release with Animancer's NormalizedTime for stand-up animation.

**Results:**
- Auto bone detection worked perfectly on Kharon's humanoid rig
- GrounderFBBIK correctly pulls feet to raft surface via raycasts (Default layer)
- Body + foot effectors successfully correct seated position (hips raised to cooler height, feet pinned to raft deck)
- Grounder and FBBIK effectors can be blended independently (Grounder off during sit, effectors on)
- Smooth weight transitions via MoveTowards prevent popping
- Stand-up IK hold (keep effectors active until animation lifts character) solved the seated-to-standing transition sink

**Pros:**
- FBBIK auto-detects humanoid bones -- zero manual rigging
- GrounderFBBIK handles foot grounding with no custom code
- 9 independently weighted effectors for full body control
- Runs after animation (LateUpdate) so it corrects any animation system cleanly
- Works with Animancer, Animator Controllers, or any Playables-based system
- Pure C#, no external dependencies

**Cons:**
- No asmdefs -- lives in Assembly-CSharp, cannot be isolated behind assembly boundaries
- GrounderFBBIK fights sit animations (must fade Grounder weight to 0 during seated poses)
- Baker tool for baking IK to clips not tested

**HOK Notes:**
Core IK system for HOK. Paired with Animancer, provides the complete animation pipeline. Key patterns established: Grounder for standing/walking, FBBIK effectors for seated positions, weight fading between states, NormalizedTime-triggered IK release for smooth transitions. No asmdef means it compiles into Assembly-CSharp -- acceptable since HOK scripts are also in Assembly-CSharp.

---

### ENTRY-091: UMotion Pro - Animation Editor (Soxware)

| Field | Value |
|-------|-------|
| **Asset** | UMotion Pro - Animation Editor (Soxware) |
| **Source** | Asset Store |
| **Version** | Current (Feb 2026) |
| **Category** | Animation (Authoring) |
| **Date Started** | 2026-02-18 |
| **Date Completed** | 2026-02-18 |
| **Verdict** | Conditional |
| **HOK Applicable** | Yes |

**What It Does:**
In-editor animation authoring tool with FK/IK posing, layers, constraints, and clip export. Allows creating and editing animations directly in Unity without Blender or Maya. Editor-only, zero runtime footprint.

**Location:** `Assets/Soxware/UMotionPro/` (editor assemblies only)

**What We Tested:**
Stability check on Unity 6 (6000.3.7f1). Two previously reported Unity 6.3 bugs tested: bone handle visibility bug and IK crash bug.

**Results:**
- **Unity 6.3 handle visibility bug: NOT REPRODUCED** -- bone handles visible and selectable
- **Unity 6.3 IK crash bug: NOT REPRODUCED** -- IK mode did not crash Unity
- FK rotation works correctly on individual bones
- Move tool only available when all bones selected, not individual bones in FK mode (expected behavior)
- Set FK to IK had no visible result without IK chain setup (expected -- needs chain configured first)
- **Requires FBX-embedded avatar** -- Kharon's standalone .asset avatar was rejected with "Only avatars created by Unity's model importer are supported". Workaround: drag FBX directly from Project window
- **HideFlags warning** on prefab instances ("Invalid HideFlag Set: HideFlags.DontSave")

**Pros:**
- In-editor animation authoring without external tools
- FK/IK posing, layers, constraints, clip export
- Zero runtime footprint (editor-only)
- Both reported 6.3 bugs did not reproduce -- stable on current Unity 6

**Cons:**
- Requires FBX-embedded avatar (standalone .asset avatars rejected)
- HideFlags warning on prefab instances
- Move tool restricted in FK mode (select all required)
- Learning curve for IK chain setup

**HOK Notes:**
Useful for creating custom animations or tweaking retargeted clips without Blender roundtrip. Kharon's standalone avatar requires using the FBX source directly. Not critical path but valuable for animation polish and one-off clip creation.

---

### ENTRY-092: IK Helper Tool (Kevin Iglesias)

| Field | Value |
|-------|-------|
| **Asset** | IK Helper Tool (Kevin Iglesias) |
| **Source** | Asset Store |
| **Version** | Current (Feb 2026) |
| **Category** | Animation (IK) |
| **Date Started** | 2026-02-18 |
| **Date Completed** | 2026-02-18 |
| **Verdict** | Rejected |
| **HOK Applicable** | No |

**What It Does:**
Single-purpose script (53 lines) that fixes mispositioned hands when retargeting weapon-holding animations between characters with different arm rig lengths. Uses Unity's built-in OnAnimatorIK callback with an IK Switch (weight toggle animated via clip) and IK Effector (hand target position).

**Location:** `Assets/Kevin Iglesias/IKHelperTool/`

**What We Tested:**
Code review and documentation review only (no hands-on needed -- functionality fully understood from source).

**Results:**
- Single hand IK only (left or right, one instance per hand)
- Requires Animator Controller with IK Pass enabled on layer
- Weight driven by IK Switch GameObject's Y position (0 or 1, animated in the clip's dopesheet)
- OnAnimatorIK callback required -- HOK uses Animancer (Playables), would need extra glue
- Everything this tool does is a trivial subset of Final IK's FBBIK hand effectors

**Pros:**
- Simple, lightweight, easy to understand
- Companion tool designed for Kevin Iglesias animation packs

**Cons:**
- Single hand only, per-instance
- Requires Animator Controller + IK Pass (incompatible with Animancer without extra work)
- Entirely superseded by Final IK's FBBIK hand effectors
- No foot, body, or multi-effector support
- Workflow requires manual animation clip editing (Add Property, set keyframes)

**HOK Notes:**
Not needed. Final IK provides hand IK (and everything else) with far more capability and cleaner integration with Animancer. This tool was designed as a companion for Kevin Iglesias weapon animation packs -- HOK has no weapon-holding use case.

---

### ENTRY-093: Human Crafting Animations (Kevin Iglesias)

| Field | Value |
|-------|-------|
| **Asset** | Human Crafting Animations (Kevin Iglesias) |
| **Source** | Asset Store |
| **Version** | Current (Feb 2026) |
| **Category** | Animation (Clips) |
| **Date Started** | 2026-02-18 |
| **Date Completed** | 2026-02-18 |
| **Verdict** | Approved |
| **HOK Applicable** | Yes - Critical |

**What It Does:**
Humanoid animation clip library focused on crafting activities. Includes fishing (throw, idle begin/loop/stop, fighting, pull out), smithing, cooking, mining, chopping, and other crafting motions. Male and female variants. Begin/Loop/Stop split for seamless state machine or code-driven playback.

**Location:** `Assets/Kevin Iglesias/Human Animations/Animations/*/Crafting/`

**What We Tested:**
Used fishing animations on Kharon via Animancer: FishingThrow01 (cast), Fishing01 - Loop (idle fishing). Tested both full-body playback and upper-body layer blending.

**Results:**
- Fishing cast and loop animations retarget cleanly to Kharon's humanoid rig
- Begin/Loop/Stop clip structure works perfectly with Animancer's code-driven playback
- Animations authored for standing pose -- upper body layer blending while seated shows hands at wrong height (expected limitation, not an asset issue)
- Quality is high, smooth motion, proper root motion variants available

**Pros:**
- Comprehensive fishing animation set (throw, idle, fighting, pull out)
- Begin/Loop/Stop structure for clean state transitions
- Male and female variants
- Retargets well to humanoid rigs
- Root motion variants included

**Cons:**
- Fishing animations authored for standing -- need FBBIK hand correction or seated-specific variants for sit-fishing
- Large animation library means many .fbx files (impacts Animancer import scan time)

**HOK Notes:**
Primary fishing animation source for HOK. FishingThrow01 = cast, Fishing01 Loop = idle fishing, FishingFighting01 = fish fighting, FishingPullOut = reeling in. Will need Final IK hand effector correction for seated fishing (animations assume standing torso angle).

---

### ENTRY-094: Human Basic Motions (Kevin Iglesias)

| Field | Value |
|-------|-------|
| **Asset** | Human Basic Motions (Kevin Iglesias) |
| **Source** | Asset Store |
| **Version** | Current (Feb 2026) |
| **Category** | Animation (Clips) |
| **Date Started** | 2026-02-18 |
| **Date Completed** | 2026-02-18 |
| **Verdict** | Approved |
| **HOK Applicable** | Yes - Critical |

**What It Does:**
Humanoid animation clip library covering core locomotion and actions. Includes idle, walk (all 8 directions), run, jump (begin/land), sit (high/medium/low/ground with begin/loop/stop), turn (left/right), and more. Male and female variants. Root motion variants included.

**Location:** `Assets/Kevin Iglesias/Human Animations/Animations/*/Movement/`, `Assets/Kevin Iglesias/Human Animations/Animations/*/Sit/`

**What We Tested:**
Used extensively on Kharon via Animancer: Idle01 (standing idle), Walk01_Forward (walk), SitLow01 - Begin (sit down), SitLow01 - Stop (stand up), Jump01 (begin/land for cooler mount/dismount), Turn01_Left/Right (turning).

**Results:**
- All tested animations retarget cleanly to Kharon's humanoid rig
- Idle and Walk are high quality, smooth loops
- SitLow01 Begin/Loop/Stop provides complete sit-down/seated/stand-up cycle
- Sit animation needed Final IK body/foot effector correction for proper cooler seating (raw animation sits too low)
- Stand-up animation (SitLow01 - Stop) required IK hold-and-release technique (NormalizedTime threshold) for clean transition
- Jump01 Begin/Land split available for cooler mount/dismount sequence
- Turn01 clips available for 90-degree turns

**Pros:**
- Complete locomotion set (idle, walk, run, jump, turn) in one package
- Sit animations in 4 height variants (high/medium/low/ground) with begin/loop/stop
- Begin/Loop/Stop structure works perfectly with code-driven playback (Animancer)
- Root motion and in-place variants
- Male and female variants
- High retargeting quality on humanoid rigs

**Cons:**
- Sit animations may need IK correction depending on seat height (raw animation heights don't match all furniture)
- No step-up/step-down animations (jump clips cover this partially)

**HOK Notes:**
Primary locomotion and idle animation source for HOK. Key clips: Idle01 (default standing), Walk01_Forward (movement), SitLow01 set (cooler sitting), Jump01 Begin/Land (cooler mount/dismount), Turn01 Left/Right (turning to face cooler). Combined with Final IK effector corrections, these animations cover all of Kharon's core behaviors on the raft.

---

### ENTRY-095: Magica Cloth 2 (Magica Soft)

| Field | Value |
|-------|-------|
| **Asset** | Magica Cloth 2 (Magica Soft) |
| **Source** | Asset Store |
| **Version** | 2.17.0 (Feb 2026) |
| **Category** | Physics (Cloth Simulation) |
| **Date Started** | 2026-02-18 |
| **Date Completed** | -- |
| **Verdict** | Testing |
| **HOK Applicable** | Yes |

**What It Does:**
Production-grade cloth and physics simulation. Three modes: MeshCloth (renderer-based), BoneCloth (bone hierarchy), BoneSpring (spring joints). Jobs/Burst-powered at 90Hz default sim frequency. Wind zones, colliders (sphere/capsule/plane), self-collision, paint maps for vertex control. Pre-build caching for performance. Pipeline-agnostic (URP, HDRP, built-in).

**Location:** `Assets/MagicaCloth2/`

**Dependencies:** Unity.Burst, Unity.Collections, Unity.Mathematics (all via Jobs system). 6 asmdefs, `MagicaCloth2` namespace.

**What We Tested So Far:**
- Code review and architecture exploration
- Ran URP demo scenes -- cloth simulation looks excellent
- Demo includes UnityChan character with hair, skirt, and sleeve physics
- Wind, runtime dress-up, and runtime build demos all functional

**Pending:**
- Hands-on test on Kharon character (scheduled for next session)
- BoneCloth mode for cloak/robes
- Performance under HOK scene conditions
- Integration with Animancer + Final IK pipeline

**HOK Potential Use Cases:**
- Kharon's cloak/robe physics
- Fishing line dynamics
- Raft elements (flags, sails, tarps, rope)
- Companion character cloth/fur

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
| Verdict | **Rejected** (upheld) |
| Label | Don't Use |
| Date | 2026-02-24 (re-eval) |
| URP | Yes (separate .rar extraction) |
| HDRP | Yes (separate .rar extraction) |

**Original verdict (ENTRY-096, Session 34):** Rejected, Don't Use. Sail simulation VFX.

**Re-evaluation context:** Does Full Sail gain value when considered alongside the full Chris West ecosystem (MegaFiers 2, MegaShapes, Full Rig, Mega Wires, Mega Flow, Mega Scatter)?

**Assessment:**
- Full Sail simulates cloth-like sail behavior on ships/boats
- HOK's ferry (Kharon's raft) is a 3m x 2m raft -- it has no mast or sails. Sail simulation is irrelevant to HOK.
- No other active TecVooDoo project involves sailing or ships with sails
- The only concept project with potential ship content is Space Garbage Man (3D Point 'N Click), but that's a space setting, not naval
- Full Sail doesn't interact with or enhance any other Chris West asset in a way that changes its value
- Only 6 ratings suggests very niche community
- URP/HDRP shaders ship as .rar archives requiring manual extraction (same pattern as Full Rig)

**Verdict: Rejected upheld.** No current or planned TecVooDoo project needs sail simulation. If a sailing project enters the pipeline, re-evaluate at that time.

---

### ENTRY-097: Dynamic Bone (Will Hong)

| Field | Value |
|-------|-------|
| **Asset** | Dynamic Bone (Will Hong) |
| **Source** | Asset Store |
| **Version** | 1.3.4 |
| **Category** | Physics (Bone Simulation) |
| **Date Started** | 2026-02-20 |
| **Date Completed** | 2026-02-20 |
| **Verdict** | Rejected |
| **HOK Applicable** | No |

**What It Does:**
Verlet-based bone physics simulation for hair, tails, clothing accessories, and jiggle physics. Applies physics to bone hierarchies with damping, elasticity, stiffness, and inertia parameters. Supports sphere, capsule, and plane colliders. Distribution curves for per-bone parameter variation along chains. .NET threading for parallel simulation. Distance-based auto-disable for LOD optimization.

**Location:** `Assets/DynamicBone/`

**Dependencies:** None. Pure C# with System.Threading. No asmdef (Assembly-CSharp). No namespace (global scope).

**What We Tested:**
- Code review: DynamicBone.cs (1,150 lines), DynamicBoneCollider.cs (460 lines), DynamicBoneColliderBase.cs (45 lines), DynamicBonePlaneCollider.cs (94 lines)
- Architecture: 1,792 total lines, 5 scripts, Verlet integration physics
- Threading model: .NET Thread + Semaphore work queue (conditionally disabled on WebGL/IL2CPP)
- Collision: sphere, capsule (with taper), infinite plane

**Results:**
- Mature, well-structured codebase with clean Verlet implementation
- Good parameter control via AnimationCurves for per-bone distribution
- Threading is older .NET pattern (not Jobs/Burst)
- No namespace -- pollutes global scope
- Conditionally disables multithread on IL2CPP + Unity 2022+ (performance concern)

**Verdict Rationale:**
Rejected because MagicaCloth 2 (ENTRY-095, Approved) completely supersedes this asset. MagicaCloth 2's BoneSpring mode provides identical bone-chain physics with Jobs/Burst performance instead of .NET threads. MagicaCloth 2 also offers MeshCloth and BoneCloth modes that Dynamic Bone cannot match. Running two bone physics systems would add complexity with no benefit. Dynamic Bone's lack of namespace and older threading model are additional negatives.

**Superseded By:** MagicaCloth 2 (ENTRY-095) -- BoneSpring mode covers all Dynamic Bone use cases with better performance.

---

### ENTRY-098: All In 1 3D Shader (Seaside Studio)

| Field | Value |
|-------|-------|
| **Asset** | All In 1 3D Shader (Seaside Studio) |
| **Source** | Asset Store |
| **Version** | Current (Feb 2026) |
| **Category** | Shader (Multi-Effect) |
| **Date Started** | 2026-02-20 |
| **Date Completed** | 2026-02-20 |
| **Verdict** | Approved |
| **HOK Applicable** | Yes-Critical |

**What It Does:**
50+ toggleable shader effects in one URP-compatible shader. Keyword-driven system with modular effects: emission, rim lighting, hologram, hue shift, fade/transparency, dissolve, intersection glow, dither, vertex shake/inflate, outline, and many more. Component-based application (AddAllIn1Shader) auto-creates material from existing. Material conversion tool for Standard/URP Lit materials. 3 asmdefs, extensive editor tooling with texture generators.

**Location:** `Assets/Plugins/AllIn13DShader/`

**Dependencies:** None. Pure shader + C# system. 3 asmdefs: runtime, editor, demo. `AllIn13DShader` namespace.

**What We Tested:**
- Code review: 9 runtime scripts (415 lines), 128 editor scripts, 24 shader files
- Applied to polyperfect Low Poly Animated People character (woman-princess-dress-narrow-fantasy)
- Material conversion from existing URP material -- clean, preserved albedo texture
- Tested emission, rim lighting, transparency, hue shift effects
- URP compatibility confirmed

**Results:**
- Material conversion works cleanly on existing character pack models
- Effects toggle on/off without issues
- Extensive parameter control per effect
- Editor UI well-organized with collapsible sections
- Performance impact TBD under full scene load

**HOK Use Case -- Soul Appearance:**
Souls fished from the River Acheron need a ghostly/ethereal look. Key effect combo:
- Emission (self-glow, HDR color) + Rim Lighting (edge glow, Fresnel) for ethereal luminance
- Hue Shift for per-soul color randomization at runtime
- Fade/Alpha for semi-transparency
- Potentially Hologram for special souls or story-important characters

Combined with 300+ existing character models across polyperfect/City People packs, this provides sufficient visual variety for the soul ferry gameplay loop without needing modular character assembly.

---

### ENTRY-099: Character Creator Framework (TelePresent Games)

| Field | Value |
|-------|-------|
| **Asset** | Character Creator Framework (TelePresent Games) |
| **Source** | Asset Store |
| **Version** | Current (Feb 2026) |
| **Category** | Character (Customization System) |
| **Date Started** | 2026-02-20 |
| **Date Completed** | 2026-02-20 |
| **Verdict** | Rejected |
| **HOK Applicable** | No |

**What It Does:**
Modular character customization framework. 15,029 lines across 41 scripts in `TelePresent.CharacterCreatorFramework`. Features: mesh swapping (enable/disable modular clothing GameObjects), MaterialPropertyBlock-based shader overrides, bone morph sliders (scale/move bones for body shape variation), blend shape support, Base64 JSON preset system, auto-generated runtime UI, prefab export with baked modifications. No external dependencies, no asmdef.

**Location:** `Assets/TelePresent/Character Creator Framework/`

**Dependencies:** None. Pure C# system. No asmdef (Assembly-CSharp).

**What We Tested:**
- Code review: 13 core scripts (1,859 lines), 14 editor scripts (9,231 lines), 14 UI scripts (3,168 lines)
- Architecture analysis: CharacterConfiguration SO, CharacterCreatorSystem MonoBehaviour, static utility classes
- Tested included demo prefab (CCF_CharacterExample) with bone morphs and material swapping
- Evaluated for soul variation in HOK

**Results:**
- Framework works as advertised for modular character assembly
- Bone morph sliders functional for body shape variation
- Material parameter control via MaterialPropertyBlock is clean
- Requires modular mesh pieces (separate head/torso/legs) for full mesh-swapping benefit
- Existing character packs are single-mesh, limiting CCF to bone morphs and material changes only

**Verdict Rationale:**
Rejected for HOK because the soul variation problem is solved more simply: 300+ existing character models across three packs (polyperfect, City People, Poly Universal) provide mesh variety, and AllIn1 3D Shader provides ghostly appearance with runtime hue/emission randomization. CCF's bone morphs add marginal value on top of this. The framework is well-built but designed for games with player avatar creation screens -- HOK spawns souls procedurally without player input. Note: could be valuable in a future project with player character customization.

---

### ENTRY-100: Timeflow Animation System (Axon Genesis)

| Field | Value |
|-------|-------|
| **Asset** | Timeflow Animation System (Axon Genesis) |
| **Source** | Asset Store (UPM Package) |
| **Version** | 1.9.3 (Dec 2025) |
| **Category** | Animation (Timeline/Sequencer) |
| **Date Started** | 2026-02-21 |
| **Date Completed** | 2026-02-21 |
| **Verdict** | Conditional |
| **HOK Applicable** | Conditional |

**What It Does:**
Professional track-based timeline and animation sequencing system. 458 scripts (~49,700 lines) in `AxonGenesis` namespace with single asmdef. Visual timeline editor with keyframe curves, animation sequencing with blending, procedural tweening, motion paths, audio sync with spectrum analysis, MIDI input, nested timelines, marker navigation, work area looping, and 133+ demo scenes per render pipeline. Supports Builtin/URP/HDRP. Package lives in `Packages/com.axongenesis.timeflow/`.

**Location:** `Packages/com.axongenesis.timeflow/`

**Dependencies:** Unity.TextMeshPro, Unity.Timeline, Unity.Splines (optional), Unity.Animation.Rigging (optional), URP/HDRP (optional). No external paid dependencies.

**What We Tested:**
- Code review: 277 runtime scripts, 181 editor scripts
- Architecture: TimeflowBehavior base class, TimeflowChannel track system, TimeflowController event hooks
- Key classes: Timeflow (main), TimeflowController (playback), AnimationSequencer, Tween, MotionPath, AudioTrack
- Playback API: Play/Stop/Rewind/Seek, markers, work areas, nested timelines, global time scale

**Results:**
- Extremely feature-rich alternative to Unity's built-in Timeline
- Clean API with ITimeflowPlayback interface for event subscription
- Audio-reactive animation and spectrum analysis built in
- AnimationSequencer integrates with Animation Rigging for IK constraints
- Very heavy codebase (50k lines) for what it adds over built-in Timeline

**Verdict Rationale:**
Conditional because HOK uses Animancer Pro for code-driven animation (not Timeline-based). Timeflow is a powerful visual sequencer that could serve for cutscenes or cinematics, but HOK's cutscene needs are unconfirmed. The 50k-line footprint is substantial. Unity's built-in Timeline + Animancer may cover HOK's needs without this. Keep for potential cutscene/cinematic use. Note: strong overlap with DOTween Pro for tweening.

---

### ENTRY-101: Koreographer Professional Edition (Sonic Bloom)

| Field | Value |
|-------|-------|
| **Asset** | Koreographer Professional Edition (Sonic Bloom) |
| **Source** | Asset Store |
| **Version** | 1.6.3 (May 2024) |
| **Category** | Audio (Music Sync/Rhythm) |
| **Date Started** | 2026-02-21 |
| **Date Completed** | 2026-02-21 |
| **Verdict** | Rejected |
| **HOK Applicable** | No |

**What It Does:**
Professional music synchronization and rhythm engine. DLL-based (SonicBloom.Koreo.dll + SonicBloom.MIDI.dll). Event-driven audio timing at sample precision. Koreography ScriptableObjects define music tracks with tempo sections and event tracks. Payload types: Color, Gradient, Curve, Text, Int, Float. Music players: SimpleMusicPlayer (single track), MultiMusicPlayer (layered). MIDI converter for importing MIDI events. FFT spectrum analysis (Pro). Visual waveform editor for event placement. Integrations with Master Audio, PlayMaker, SECTR Audio, Fabric.

**Location:** `Assets/Koreographer/` + `Assets/Plugins/Koreographer/`

**Dependencies:** None external. DLL-based architecture. No asmdef (Assembly-CSharp). `SonicBloom.Koreo` namespace.

**What We Tested:**
- Architecture review: singleton Koreographer manager, Koreography SO data model, event callback system
- API: RegisterForEvents/UnregisterForEvents, Music Time API (beats, measures, samples)
- Payload system: Color, Gradient, Curve, Text, Int, Float, Asset (Pro)
- Demo scripts: 7 examples (404 lines) showing color, scaling, physics, particles, text
- Documentation: Quick Start Guide + Users Guide PDFs included

**Results:**
- Well-architected event-driven system with sample-precise timing
- Clean callback API with both simple and time-aware delegates
- Master Audio integration available (unitypackage included)
- Comprehensive documentation and demo coverage
- Designed specifically for rhythm games and music-reactive experiences

**Verdict Rationale:**
Rejected for HOK because the game is not rhythm-based. Koreographer is purpose-built for music synchronization, beat detection, and rhythm game mechanics. HOK's fishing/ferry gameplay doesn't require sample-precise audio event timing. Ambient audio and SFX are better served by a general audio manager. Note: excellent asset for any future rhythm game or music visualizer project.

---

### ENTRY-102: Audio Preview Tool (Warped Imagination)

| Field | Value |
|-------|-------|
| **Asset** | Audio Preview Tool (Warped Imagination) |
| **Source** | Asset Store |
| **Version** | Current |
| **Category** | Editor Tool (Audio QoL) |
| **Date Started** | 2026-02-21 |
| **Date Completed** | 2026-02-21 |
| **Verdict** | Approved |
| **HOK Applicable** | Yes |

**What It Does:**
Editor-only quality-of-life tool. Double-click any AudioClip in the Project window to preview it. Double-click again to stop. 3 scripts (350 lines total) in `WarpedImagination.AudioPreviewTool` namespace. Uses reflection on internal `UnityEditor.AudioUtil` API. Version-specific implementations for Unity 2019, 2020+, and Unity 6. Toggle on/off via Preferences > Tools > Audio Preview Tool. Zero runtime impact.

**Location:** `Assets/WarpedImagination/AudioPreviewTool/`

**Dependencies:** None. Editor-only. No asmdef (Assembly-CSharp-Editor).

**What We Tested:**
- Code review: AudioPreviewTool.cs (268 lines), AudioPreviewToolSettings.cs (36 lines), AudioPreviewToolSettingsProvider.cs (46 lines)
- Architecture: OnOpenAsset callback intercepts AudioClip double-clicks
- Unity 6 compatibility: Uses EntityId parameter (UNITY_6000_3_OR_NEWER define)

**Verdict Rationale:**
Approved as a universal editor utility. Tiny footprint, zero risk, zero runtime impact. Makes audio browsing during development significantly faster. No reason not to keep it in any project.

---

### ENTRY-103: Master Audio 2024 (DarkTonic)

| Field | Value |
|-------|-------|
| **Asset** | Master Audio 2024 (DarkTonic) |
| **Source** | Asset Store |
| **Version** | 1.0.3 (Dec 2024) |
| **Category** | Audio (Complete Audio System) |
| **Date Started** | 2026-02-21 |
| **Date Completed** | 2026-02-21 |
| **Verdict** | Approved |
| **HOK Applicable** | Yes-Critical |

**What It Does:**
Enterprise-grade audio management system. 77 scripts (~27,851 lines) in `DarkTonic.MasterAudio` namespace. Core: MasterAudio singleton (10,650 lines) manages Sound Groups, Buses, Custom Events, Playlists. Sound Groups pool AudioSource variations with voice limiting, retrigger prevention, randomization, looping chains. Bus system for mix submixes with ducking, occlusion (raycast-based), and RTPC automation. PlaylistController (2,718 lines) handles music with crossfading, gapless playback, shuffle/sequential modes. EventSounds (3,336 lines) binds game events to audio without code. Mecanim state triggers, footstep surface detection, ambient sound zones. Supports Addressables, multiplayer (FishNet/Mirror/Netcode), Meta XR Audio, Steam Audio. Scene persistence via DontDestroyOnLoad.

**Location:** `Assets/Plugins/DarkTonic/MasterAudio/`

**Dependencies:** None external (built-in Unity only). Optional: Addressables, VideoPlayer. No asmdef by default (unitypackage available). `DarkTonic.MasterAudio` namespace.

**What We Tested:**
- Architecture review: MasterAudio.cs (10,650 lines), PlaylistController.cs (2,718 lines), EventSounds.cs (3,336 lines)
- Sound Group system: MasterAudioGroup, SoundGroupVariation (per-clip settings, filters, randomization)
- Bus system: GroupBus with voice limiting, AudioMixer routing, occlusion
- Custom Event system: named events with distance filtering, ICustomEventReceiver interface
- Playlist system: crossfading, gapless, sections, metadata
- Utility classes: FootstepSounds, AmbientSound, MechanimStateSounds, DynamicSoundGroupCreator
- Demo scenes: 4 examples including bootstrapper pattern

**Results:**
- Production-grade audio system comparable to Wwise/FMOD but fully Unity-integrated
- No-code event binding via EventSounds component for rapid prototyping
- Sound Group pooling eliminates runtime AudioSource allocation
- Playlist crossfading and gapless playback are music-ready
- Mecanim integration for animation-driven audio (footsteps, impacts)
- RTPC for game-state-driven audio parameters
- Well-documented with bootstrapper pattern for scene persistence

**Verdict Rationale:**
Approved as critical for HOK. The Audio namespace is one of HOK's 8 planned namespaces, and Master Audio provides the complete foundation: SFX pooling and management, music playlist system, spatial audio, event-driven triggering, ducking, and Mecanim integration. Building this from scratch would be months of work. Koreographer integration package is included if music sync is ever needed.

---

### ENTRY-104: Audio Manager (Krayzborn Assets)

| Field | Value |
|-------|-------|
| **Asset** | Audio Manager (Krayzborn Assets) |
| **Source** | Asset Store |
| **Version** | Current |
| **Category** | Audio (Simple Manager) |
| **Date Started** | 2026-02-21 |
| **Date Completed** | 2026-02-21 |
| **Verdict** | Rejected |
| **HOK Applicable** | No |

**What It Does:**
Lightweight audio manager with music and SFX playback. 5 scripts (1,091 lines) in `Krayzborn.AudioTools` namespace. Singleton AudioManager with DontDestroyOnLoad. AudioLibrary ScriptableObject organizes clips in categories. Music system with fade transitions via coroutines. SFX system with AudioSource pooling (default 15 sources). LogicButtonUI component for audio-integrated UI buttons. Custom editor inspectors with ReorderableList.

**Location:** `Assets/Krayzborn Assets/Audio Manager/`

**Dependencies:** None. No asmdef (Assembly-CSharp). `Krayzborn.AudioTools` namespace.

**What We Tested:**
- Code review: AudioManager.cs (289 lines), AudioLibrary.cs (119 lines), AudioLibraryEditor.cs (431 lines), LogicButtonUI.cs (131 lines)
- Architecture: singleton + ScriptableObject library + string-based dictionary lookup
- Features: music fade transitions, SFX pooling, per-clip volume/pitch/pan

**Verdict Rationale:**
Rejected because Master Audio 2024 (ENTRY-103) completely supersedes this asset. Master Audio provides everything Krayzborn does (pooling, music, SFX, fading) plus vastly more (buses, ducking, occlusion, RTPC, events, Mecanim integration, playlists, spatial audio). Running a simple audio manager alongside an enterprise system adds no value. The asset is well-built for small projects but unnecessary given Master Audio's presence.

**Superseded By:** Master Audio 2024 (ENTRY-103).

---

### ENTRY-105: Native Audio (Exceed7 Experiments)

| Field | Value |
|-------|-------|
| **Asset** | Native Audio (Exceed7 Experiments) |
| **Source** | Asset Store |
| **Version** | 7.0.0 (Jan 2022) |
| **Category** | Audio (Low-Latency Platform) |
| **Date Started** | 2026-02-21 |
| **Date Completed** | 2026-02-21 |
| **Verdict** | Rejected |
| **HOK Applicable** | No |

**What It Does:**
Bypasses Unity's audio mixer for ultra-low latency audio on iOS (OpenAL) and Android (OpenSL ES). 11 runtime scripts (2,710 lines) in `E7.Native` namespace with asmdef. P/Invoke to native libraries. NativeAudioPointer handles to native memory, NativeSource struct parallels AudioSource. Up to 79% latency reduction vs standard Unity audio. Device audio capability querying. Performance analyzer component.

**Location:** `Assets/Native Audio/`

**Dependencies:** None external. `E7.NativeAudio.asmdef`. iOS/Android native plugins. `E7.Native` namespace.

**What We Tested:**
- Code review: NativeAudio.cs (849 lines), NativeSource.cs (377 lines), DeviceAudioInformation.cs (489 lines)
- Architecture: static facade API, platform-specific P/Invoke bridges
- Constraints: AudioClip must be "Decompress On Load", mono/stereo only, editor throws NotSupportedException

**Verdict Rationale:**
Rejected for HOK because it's iOS/Android only. HOK targets desktop (Windows) as the primary platform. The asset throws NotSupportedException in the editor and has no desktop support. Additionally, Unity's standard audio latency is acceptable for a fishing/ferry game -- this is designed for rhythm games requiring sub-frame timing. Dangerous unload behavior (SIGSEGV on Android) is a maintenance risk. Note: could be valuable for a mobile rhythm game.

---

### ENTRY-106: Default Playables (Unity Technologies)

| Field | Value |
|-------|-------|
| **Asset** | Default Playables (Unity Technologies) |
| **Source** | Asset Store (Unity Official) |
| **Version** | Current |
| **Category** | Animation (Timeline Tracks) |
| **Date Started** | 2026-02-21 |
| **Date Completed** | 2026-02-21 |
| **Verdict** | Approved |
| **HOK Applicable** | Yes |

**What It Does:**
Collection of 7 production-ready Timeline playable track types from Unity Technologies. 35 scripts (3,218 lines), no namespace, no asmdef. Includes: LightControl (animate Light properties), TransformTween (Hermite interpolation movement), ScreenFader (UI fade with color), TextSwitcher (timed text display), TimeDilation (time scale control), NavMeshAgentControl (pathfinding in Timeline), Video (VideoPlayer control). All support clip blending with weighted averaging. Plus TimelinePlayableWizard (1,901 lines) -- a code generator for creating custom Timeline tracks from templates.

**Location:** `Assets/UnityTechnologies/DefaultPlayables/`

**Dependencies:** Unity.Timeline (built-in). No external packages.

**What We Tested:**
- Code review: All 7 playable types analyzed (Track, Clip, Behaviour, Mixer pattern)
- Architecture: Standard blend playable template with ClipCaps.Blending
- TimelinePlayableWizard: code generator creates boilerplate for custom tracks
- Blending: weighted average for floats/colors, greatest-weight for discrete values

**Verdict Rationale:**
Approved as a utility/reference asset. The playable types are directly usable (TimeDilation for slow-mo effects, ScreenFader for transitions, LightControl for cinematic lighting). The TimelinePlayableWizard is valuable for creating custom Timeline tracks when needed. Lightweight, official Unity code, no maintenance burden.

---

### ENTRY-107: Animation Path Visualizer (JulesGilli)

| Field | Value |
|-------|-------|
| **Asset** | Animation Path Visualizer (JulesGilli) |
| **Source** | Asset Store |
| **Version** | 2.0.1 |
| **Category** | Editor Tool (Animation Debug) |
| **Date Started** | 2026-02-21 |
| **Date Completed** | 2026-02-21 |
| **Verdict** | Approved |
| **HOK Applicable** | Yes |

**What It Does:**
Editor-only tool for visualizing animation motion paths in the Scene view. Single script (1,118 lines) in `AnimationPathVisualizerEditor` namespace. Displays 3D trajectory of animated GameObjects with velocity gradient coloring (green slow, red fast). Interactive keyframe editing: click to move keyframes in 3D, adjust tangents with handles, right-click to add/delete keyframes. Supports Animator (Mecanim) and Animation (Legacy) components. Root motion support for humanoid rigs. Multi-object selection with lock. MIT licensed.

**Location:** `Assets/AnimationPathVisualizer/`

**Dependencies:** None. Editor-only. No asmdef (Assembly-CSharp-Editor).

**What We Tested:**
- Code review: AnimationPathVisualizerEditorWindow.cs (1,118 lines)
- Features: path sampling at configurable resolution, Handles-based keyframe editing, tangent manipulation, context menus
- Compatibility: Animator (Mecanim default state) and Animation (Legacy) components

**Verdict Rationale:**
Approved as a universal editor tool. Bridges the gap between the Animation window's 2D curve view and actual 3D Scene visualization. Useful for debugging and refining motion paths on any animated object. Zero runtime impact, MIT licensed, clean single-script implementation.

---

### ENTRY-108: Curve Master (Yan-K / NekoLab)

| Field | Value |
|-------|-------|
| **Asset** | Curve Master (Yan-K / NekoLab) |
| **Source** | Asset Store |
| **Version** | 1.2.1 |
| **Category** | Editor Tool (Curve Editor) |
| **Date Started** | 2026-02-21 |
| **Date Completed** | 2026-02-21 |
| **Verdict** | Approved |
| **HOK Applicable** | Yes |

**What It Does:**
Advanced cubic Bezier curve editor for Unity's Animation/ParticleSystem keyframe manipulation. 33 scripts (4,278 lines) in `AnimationCurveManipulationTool` namespace with 2 asmdefs (editor + runtime). Integrates into Animation Window, Particle System editor, and standalone AnimationCurve window via reflection on internal Unity APIs. Features: visual Bezier control point editor, preset/library system with JSON import/export, batch keyframe operations (reverse, mirror, align, offset by object/property, set values with fixed/random modes). Runtime `[EditWithCurveMaster]` attribute for inspector integration.

**Location:** `Assets/CurveMaster/`

**Dependencies:** None external. 2 asmdefs: `AnimationCurveManipulationTool` (editor), `AnimationCurveManipulationRuntime` (runtime attribute only).

**What We Tested:**
- Code review: AnimationCurveManipulationWindow.cs (661 lines), KeyframeDataUtility.cs (576 lines), CubicBezierEditor.cs (292 lines), BezierUtility.cs (85 lines)
- Architecture: 20 reflection-based binding scripts for deep Unity editor API integration
- Preset system: built-in presets loaded from Resources, user library with JSON export
- Batch operations: reverse, mirror, align, offset, set keys (fixed/random)

**Verdict Rationale:**
Approved as an editor productivity tool. Complements UMotion Pro (ENTRY-091) for animation authoring. Curve Master excels at tangent editing and batch keyframe operations that Unity's built-in curve editor lacks. Useful for polishing animation curves, particle system timing, and any AnimationCurve-based data. The preset library saves time on common easing patterns. Editor-only with negligible runtime footprint (single attribute class).

---

### ENTRY-109: Odin Inspector and Serializer (Sirenix)

| Field | Value |
|-------|-------|
| **Asset** | Odin Inspector and Serializer (Sirenix) |
| **Source** | Asset Store |
| **Version** | 4.0.1.3 (Feb 2026) |
| **Category** | Tools (Inspector/Serialization) |
| **Date Started** | 2026-02-21 |
| **Date Completed** | 2026-02-21 |
| **Verdict** | Approved |
| **Label** | Default |

**What It Does:**
Custom inspector and serialization system. DLL-based architecture (~5.3MB across 9 DLLs). Attribute-driven property drawers replace Unity's default Inspector with richer UI: buttons, dropdowns, grouped fields, conditional visibility, inline editors, tables, and more. Serialization system extends Unity's serializer to support polymorphic types, dictionaries, and complex nested objects. Two source-code modules: Unity.Mathematics (custom drawers for math types, 883 lines) and Unity.Addressables (deep AssetReference integration, 1,934 lines). 4 demo unitypackages included. Sirenix namespace family across all assemblies.

**Location:** `Assets/Plugins/Sirenix/` (shared with Odin Validator)

**Dependencies:** None external. Optional modules for Unity.Mathematics and Unity.Addressables. 2 asmdefs for modules only; core is DLL-based.

**What We Tested:**
- Architecture review: 9 DLLs (runtime + editor), 2 module asmdefs, 5 config assets
- Module source review: MathematicsDrawers.cs (883 lines, 36 matrix processors + vector drawers), AddressablesInspectors.cs (1,934 lines, custom AssetReference drawer/selector/resolver/converter)
- Config system: GeneralDrawerConfig, InspectorConfig, OdinModuleConfig, TypeRegistryUserConfig
- 4 editor shaders for custom UI rendering

**Results:**
- Industry-standard inspector enhancement used across thousands of Unity projects
- Attribute-based workflow means no custom editor scripts needed for most inspector customization
- Serialization system handles types Unity's built-in serializer cannot (polymorphism, dictionaries, interfaces)
- DLL-based distribution means no source code compilation overhead
- Mathematics module provides proper drawers for Unity.Mathematics types (float2/3/4, matrices)
- Addressables module provides full AssetReference browsing, validation, and drag-drop conversion

**Verdict Rationale:**
Approved as a universal default. Eliminates the need to write custom property drawers for common inspector patterns. The attribute system (ShowIf, Required, Button, TableList, InlineEditor, etc.) dramatically reduces editor scripting time across any project. Serialization system solves Unity's serialization gaps. No runtime overhead for inspector-only features.

**Asset Interactions:**
- **Odin Validator (ENTRY-110):** Required dependency for Validator. Inspector provides the attribute and serialization foundation that Validator extends with project-wide validation.
- **Scriptable Sheets (ENTRY-018):** Complementary. Scriptable Sheets is for bulk SO editing; Odin is for per-object inspector enhancement. No conflict.
- **Wingman (ENTRY-020):** Both enhance the Inspector panel. Wingman adds component search/isolation on top; Odin enhances individual component drawers underneath. Compatible.
- **UDebug Panel (ENTRY-013):** Different domains. UDebug is runtime debug UI; Odin is editor inspector enhancement.

**Claude vs Manual:**
- **Claude can do:** Add Odin attributes to scripts ([Button], [ShowIf], [Required], [TableList], [InlineEditor], etc.), configure serialization with [OdinSerialize], write OdinEditorWindow subclasses, set up OdinMenuTree for custom editor windows.
- **Manual required:** Initial attribute exploration (many attributes available), visual tweaking of inspector layouts, custom drawer authoring for unusual types, module configuration in Project Settings.

**Replaces / Replaced By:** Replaces Unity's default inspector for all practical purposes. No other evaluated asset provides equivalent inspector enhancement.

---

### ENTRY-110: Odin Validator (Sirenix)

| Field | Value |
|-------|-------|
| **Asset** | Odin Validator (Sirenix) |
| **Source** | Asset Store |
| **Version** | 4.0.1.3 (Feb 2026) |
| **Category** | Tools (Validation/QA) |
| **Date Started** | 2026-02-21 |
| **Date Completed** | 2026-02-21 |
| **Verdict** | Approved |
| **Label** | Default |

**What It Does:**
Project-wide asset and scene validation tool. Separate Asset Store product that requires Odin Inspector (matching version). Single DLL (416KB) + version check script (197 lines). Automated validation on play mode, build, and project startup with configurable actions (ignore/warn/block). Validation profiles define scope (which scenes and asset folders to validate). Custom rule system for project-specific checks. Background validation, issue tracking, fix workflow. Includes 6 built-in Addressables validators. UI status widget with SDF-rendered spinning icons.

**Location:** `Assets/Plugins/Sirenix/Odin Validator/` (config + version script), DLL in `Assets/Plugins/Sirenix/Assemblies/`

**Dependencies:** Odin Inspector and Serializer (ENTRY-109) -- same Major.Minor.Build version required.

**What We Tested:**
- Architecture review: EnsureCorrectOdinVersion.cs (197 lines, version compatibility checker)
- Config assets: GlobalValidationConfig (18 boolean settings), RuleConfig (custom rules, currently empty), AutomationConfig (play/build/startup triggers), Main Profile (validation scope)
- Built-in Addressables validators: 6 validators (853 lines) for AssetReference validation, duplicate bundle detection, Resources-to-Addressables duplicate detection
- Current config: OnBuild warns on warnings, blocks on errors

**Results:**
- Clean separation from Inspector -- only adds validation layer on top
- Automation config is powerful: can block builds if validation fails
- Profile system allows different validation scopes for different contexts
- Rule system is extensible for project-specific validation
- Background validation catches issues without manual scanning
- Version coupling to Inspector is tight (must match Major.Minor.Build)

**Verdict Rationale:**
Approved as a universal default. Catches issues before they reach builds: missing references, invalid configurations, addressable problems. Build-blocking on errors prevents broken builds from shipping. The automation system (validate on play, validate on build) is set-and-forget once configured. Small footprint (416KB DLL).

**Asset Interactions:**
- **Odin Inspector (ENTRY-109):** Hard dependency. Must be same version.
- Validation rules can check any serialized data that Odin Inspector can see, including custom Odin-serialized types.

**Claude vs Manual:**
- **Claude can do:** Write custom Validator classes, configure automation settings, define validation profiles, create project-specific rules in code.
- **Manual required:** Initial profile setup (selecting scenes/folders to validate), reviewing validation results, configuring automation trigger actions (warn vs block), fixing flagged issues.

**Replaces / Replaced By:** Nothing. Unique project-wide validation tool. No other evaluated asset provides automated build-time validation.

---

### ENTRY-111: DOTween Pro (Demigiant)

| Field | Value |
|-------|-------|
| **Asset** | DOTween Pro (Demigiant) |
| **Source** | Asset Store |
| **Version** | 1.0.410 (Feb 2026) |
| **Category** | Animation (Tweening) |
| **Date Started** | 2026-02-21 |
| **Date Completed** | 2026-02-21 |
| **Verdict** | Approved |
| **Label** | Default |

**What It Does:**
Industry-standard tweening engine for Unity. Fluent API for animating any value, transform, material, UI element, or custom property over time. Pro version adds: DOTweenAnimation visual component (no-code tweening), DOTweenPath (visual path editor), timeline integration, additional shortcuts. Supports easing functions, sequences, callbacks, loops, time scale independence, and safe mode for error handling. UI Toolkit support added in recent versions.

**Location:** Not currently installed in Sandbox project.

**Dependencies:** None. Pure C# system.

**What We Tested:**
- Asset Store listing review (v1.0.410, Feb 2026)
- Cross-reference with evaluated assets for overlap/interaction analysis
- Changelog review: recent additions include UI Toolkit VisualElement shortcuts, define-based module system

**Results:**
- Not installed in Sandbox for hands-on testing; evaluation based on extensive prior use and documentation
- De facto standard tweening library across Unity ecosystem
- Lightweight, well-maintained, frequently updated (latest: Feb 2026)
- Pro version's DOTweenAnimation component enables no-code tweening for designers

**Verdict Rationale:**
Approved as a universal default. DOTween is the industry standard for programmatic tweening in Unity. Lightweight, zero-dependency, fluent API that integrates into any project. The Pro visual components (DOTweenAnimation, DOTweenPath) add no-code options for non-programmers. No reason not to include in every project.

**Asset Interactions:**
- **Timeflow (ENTRY-100):** Overlaps in tweening. DOTween is lighter and code-first; Timeflow is a heavy visual sequencer. DOTween is Default; Timeflow is Conditional (per-project). No conflict if both present -- different use cases (quick code tweens vs complex timelines).
- **Animancer Pro (ENTRY-089):** Different domains. Animancer drives animation clip playback; DOTween drives procedural value animation. Complementary -- use Animancer for character animation, DOTween for UI/camera/transform tweening.
- **Koreographer (ENTRY-101):** Koreographer beat events can trigger DOTween animations for music-synced motion.
- **Master Audio (ENTRY-103):** DOTween can tween audio parameters; Master Audio manages audio playback. No conflict.
- **Default Playables (ENTRY-106):** Default Playables' TransformTween overlaps with DOTween's transform tweening, but Default Playables is Timeline-native while DOTween works anywhere.

**Claude vs Manual:**
- **Claude can do:** Write all DOTween code (transform.DOMove, DOFade, DOSequence, etc.), create complex tween sequences, set up DOTweenAnimation components via MCP, configure easing and callbacks.
- **Manual required:** DOTweenPath visual path editing in Scene view, DOTweenAnimation component's visual preview, initial DOTween setup wizard (one-time).

**Replaces / Replaced By:** Partially overlaps with Timeflow's tweening, but DOTween is lighter and code-first. Not replaced by anything -- it's the standard.

---

### ENTRY-112: Chunity -- ChucK for Unity (Stanford CCRMA)

| Field | Value |
|-------|-------|
| **Asset** | Chunity: ChucK for Unity (Music, Computing, Design Group at Stanford) |
| **Source** | Asset Store |
| **Version** | 2.2.1 (Aug 2025) |
| **Category** | Audio (Procedural Synthesis) |
| **Date Started** | 2026-02-21 |
| **Date Completed** | 2026-02-21 |
| **Verdict** | Conditional |
| **Label** | -- |

**What It Does:**
Embeds the ChucK audio programming language as a native Unity plugin for real-time procedural audio synthesis. 11 core runtime scripts (5,384 lines). ChucK is a strongly-timed language from Stanford/Princeton designed for live-coding sound -- oscillators, filters, envelopes, granular synthesis, FM, physical modeling, all from code. P/Invoke to native libraries on every platform (Windows, Mac, Linux, iOS, Android, WebGL). ChuckMainInstance manages the primary VM on an AudioSource; ChuckSubInstance enables spatial multi-instance synthesis sharing the same VM. Syncer components bridge ChucK global variables (int, float, string, arrays) to C#. Supports MIDI input, microphone input, and OSC via embedded LibLo. Free.

**Location:** Removed from Sandbox after evaluation.

**Dependencies:** None. Self-contained native plugins (~6MB per platform). No namespace, no asmdef -- compiles into Assembly-CSharp.

**What We Tested:**
- Codebase analysis: 11 core scripts, 22 examples, 3 editor scripts
- Native plugin inventory: DLLs/SOs/bundles for all 6 platforms + WebGL
- Architecture review: singleton manager, P/Invoke (95+ DllImport declarations), callback persistence for IL2CPP
- Cross-asset interaction analysis

**Results:**
- Clean architecture with platform-specific type aliases for pointer sizes
- Academic origin (Stanford CCRMA) -- high quality but niche user base
- 12 reviews, 5.0 rating -- small but enthusiastic audience
- No namespace creates potential naming conflicts (Chuck, TheChuck in global scope)
- Learning curve: requires learning ChucK syntax, not just C# API

**Verdict Rationale:**
Conditional. Procedural audio synthesis is a unique capability nothing else in the toolkit provides -- you cannot synthesize sounds from scratch with Master Audio or FMOD. But it requires learning a separate programming language (ChucK), has an academic rather than game-dev focus, and most projects use pre-recorded audio assets. Import only for projects that specifically need procedural/generative sound (interactive instruments, experimental audio, academic projects).

**Asset Interactions:**
- **Master Audio 2024 (ENTRY-103):** Different domains entirely. Master Audio plays back recorded audio; Chunity generates audio from code. Could coexist -- Chunity for procedural SFX, Master Audio for everything else. No integration path.
- **Koreographer (ENTRY-101):** Could pair for music-reactive procedural audio. Koreographer provides beat timing, Chunity generates sounds. No built-in integration.
- **FMOD (ENTRY-113):** Both can generate audio at the engine level but completely different approaches. FMOD is event-based middleware; Chunity is a synthesis language. No overlap in practice.

**Claude vs Manual:**
- **Claude can do:** Write ChucK code strings for synthesis patches, set up ChuckMainInstance/SubInstance via MCP, configure syncer components, write C#-to-ChucK bridge code.
- **Manual required:** Aurally tuning synthesis parameters (oscillator frequencies, filter cutoffs, envelope shapes), designing sound patches by ear, ChucK debugging.

**Replaces / Replaced By:** Nothing. Procedural audio synthesis is a unique niche. Not replaced by any evaluated asset.

---

### ENTRY-113: FMOD for Unity (FMOD / Firelight Technologies)

| Field | Value |
|-------|-------|
| **Asset** | FMOD for Unity 2.03 (FMOD) |
| **Source** | Asset Store |
| **Version** | 2.03.12 (Jan 2026) |
| **Category** | Audio (Complete Middleware System) |
| **Date Started** | 2026-02-21 |
| **Date Completed** | 2026-02-21 |
| **Verdict** | Conditional |
| **Label** | -- |

**What It Does:**
Industry-standard audio middleware. 72 scripts (33,173 lines) across 5 namespaces (FMOD, FMOD.Studio, FMODUnity, FMODUnityResonance, FMODUnityHaptics). Runs a completely separate audio engine parallel to Unity's -- its own DSP graph, mixer hierarchy, spatial system. Does NOT use Unity's AudioSource/AudioMixer. Core components: RuntimeManager (singleton, owns native FMOD.System), StudioEventEmitter (plays events), StudioListener (3D positioning), StudioBankLoader (bank lifecycle). Event-based design: all audio authored in the separate FMOD Studio desktop app, exported as banks, loaded at runtime. Addons: Google Resonance Audio (spatial HRTF), OpenXR Haptics (Quest). Timeline integration via FMODEventPlayable. 5 asmdefs. Native plugins for every platform (Windows x86/x64/ARM64, Mac, Linux, iOS, Android 4 arch, tvOS, WebGL 3 Emscripten versions, VisionOS). Free for indie (<$200K revenue, <$500K funding); $2K-$18K per title for larger studios. 93.9MB installed.

**Location:** Removed from Sandbox after evaluation.

**Dependencies:** Requires FMOD Studio desktop application (separate download) for audio authoring. Optional refs: Timeline, Addressables, URP, InputSystem, OpenXR.

**What We Tested:**
- Full codebase analysis: 72 scripts, 5 asmdefs, native plugin inventory
- Architecture review: RuntimeManager, event system, platform hierarchy, settings asset
- FMOD Studio workflow requirements
- Licensing tiers and revenue caps
- Cross-asset overlap analysis with Master Audio

**Results:**
- Production-grade, battle-tested across AAA titles
- Runs entirely separate audio engine -- two audio systems if combined with Master Audio
- Requires FMOD Studio desktop app for any content authoring (cannot author events in Unity alone)
- Non-standard EULA (not standard Asset Store license)
- 4/5 rating (6 reviews) -- some report EventNotFoundException issues
- 93.9MB footprint vs Master Audio's lighter Unity-native approach

**Verdict Rationale:**
Conditional. FMOD is an industry-standard AAA middleware with capabilities that exceed Master Audio in some areas (adaptive music systems, professional mixing console, platform-specific codecs). However, Master Audio is already Default and covers 95%+ of audio needs while staying Unity-native. Running FMOD means maintaining a separate desktop app, learning a separate workflow, and running a parallel audio engine. Use FMOD only when a project specifically needs: (1) a dedicated sound designer using FMOD Studio, (2) FMOD-specific features like advanced adaptive music or platform codecs, or (3) collaboration with a team already standardized on FMOD. Import per-project.

**Asset Interactions:**
- **Master Audio 2024 (ENTRY-103):** Direct competitor in role (complete audio system). Can technically coexist but runs two separate audio engines. Master Audio wraps Unity AudioSource/AudioMixer; FMOD replaces them entirely. Choose one per project, not both.
- **Koreographer (ENTRY-101):** Koreographer's Master Audio integration works out of the box. FMOD has its own adaptive music system. If using FMOD, Koreographer becomes less necessary (FMOD Studio handles music timing natively).
- **Native Audio (ENTRY-105):** FMOD has its own low-latency platform backends. Native Audio is redundant if using FMOD.
- **Chunity (ENTRY-112):** No overlap. Chunity synthesizes; FMOD plays back authored events.
- **DryWetMidi (ENTRY-115):** Could pair for MIDI-driven FMOD events. No built-in integration.

**Claude vs Manual:**
- **Claude can do:** Write C# code for RuntimeManager calls, set up StudioEventEmitter/StudioListener via MCP, configure FMODStudioSettings, write event playback logic, set FMOD parameters from code.
- **Manual required:** ALL content authoring in FMOD Studio desktop app (events, buses, snapshots, adaptive music, mixing). Bank export workflow. Live update debugging (port 9264). Sound design.

**Replaces / Replaced By:** Competes with Master Audio 2024 (ENTRY-103). Neither replaces the other -- different philosophies (external middleware vs Unity-native). Master Audio is Default; FMOD is per-project.

---

### ENTRY-114: Universal Sound Manager Lite (Kitler Dev)

| Field | Value |
|-------|-------|
| **Asset** | Universal Sound Manager Lite (Kitler Dev) |
| **Source** | Asset Store |
| **Version** | 1.0 (Sep 2025) |
| **Category** | Audio (Simple Manager) |
| **Date Started** | 2026-02-21 |
| **Date Completed** | 2026-02-21 |
| **Verdict** | Rejected |
| **Label** | Don't Use |

**What It Does:**
Minimal audio manager. 5 scripts (352 lines total). Singleton AudioManager with Play(string) and Stop(string) methods. Creates one AudioSource per sound entry on the manager GameObject. AudioData holds Name/Clip/Volume/Pitch/Loop. Editor tool auto-generates AudioConstants.cs with const strings for type-safe references. Setup wizard creates manager GameObject. No namespace, no asmdef. Free.

**Location:** Removed from Sandbox after evaluation.

**Dependencies:** None.

**What We Tested:**
- Full codebase analysis: 3 runtime scripts (137 lines), 2 editor scripts (215 lines)
- API surface: Play() and Stop() only
- Architecture review: singleton, O(n) name lookup, dynamic AudioSource creation
- Feature comparison against Master Audio

**Results:**
- Play and Stop only -- no pause, resume, fade, crossfade, 3D spatial, pooling, priorities, buses, ducking, volume groups, mixer integration, callbacks, or simultaneous playback limiting
- O(n) string comparison lookup for every Play/Stop call
- All AudioSources stacked on one GameObject
- Volume/Pitch ranges go to 4.0 (unusual, typically 0-1)
- No reviews, 4 favorites -- minimal adoption
- Hardcoded file paths in code generator (not portable)

**Verdict Rationale:**
Rejected. Master Audio 2024 (Default) does everything USM Lite does and vastly more. USM Lite's entire feature set (play/stop sounds by name with auto-generated constants) is a tiny subset of Master Audio's capabilities. The 352-line codebase provides no unique value. Even as a lightweight alternative, the lack of pause/resume, fading, 3D audio, and mixer integration makes it unsuitable for any real project.

**Asset Interactions:**
- **Master Audio 2024 (ENTRY-103):** Completely superseded. Master Audio provides pooling, buses, ducking, playlists, 3D audio, events, and every feature USM Lite lacks.

**Claude vs Manual:**
- **Claude can do:** Everything -- the entire asset is trivially simple code.
- **Manual required:** Nothing.

**Replaces / Replaced By:** Replaced by Master Audio 2024 (ENTRY-103). Do not use in any project.

---

### ENTRY-115: DryWetMIDI (Melanchall)

| Field | Value |
|-------|-------|
| **Asset** | DryWetMIDI (Melanchall) |
| **Source** | Asset Store (wraps GitHub: melanchall/drywetmidi) |
| **Version** | 8.0.3 (Dec 2025) |
| **Category** | Audio (MIDI Data/Devices) |
| **Date Started** | 2026-02-21 |
| **Date Completed** | 2026-02-21 |
| **Verdict** | Approved |
| **Label** | Default Audio |

**What It Does:**
Comprehensive .NET MIDI library. DLL-based (Melanchall.DryWetMidi.dll ~492KB + native helpers for Windows/Mac). Read, write, and create Standard MIDI Files (SMF) and RMID files. Send/receive MIDI events to/from hardware devices. MIDI playback and recording. High-level abstractions: notes, chords, patterns. Music theory API (scales, intervals, chords). Pattern-based composition builder. Quantization, note splitting, MIDI-to-CSV. Corrupted file repair. MIT licensed on GitHub (665 stars, 1,534 commits). Two Asset Store versions: full (with native device I/O) and Nativeless (pure managed, no device access). 5.0 rating (13 reviews). Supports Windows, Mac, Linux, iOS, Android, WebGL. Free.

**Location:** Removed from Sandbox after evaluation.

**Dependencies:** None. Self-contained managed DLL + optional native libraries.

**What We Tested:**
- Asset Store listing and GitHub repository review
- DLL and native library inventory (managed DLL + Win32/Win64/Mac native helpers)
- Feature scope analysis: file I/O, device I/O, playback, recording, music theory
- Cross-asset interaction analysis with Koreographer and Master Audio

**Results:**
- Mature library (33 releases, 8.0.3 as of Dec 2025)
- Actively maintained (last update Dec 2025)
- Used by notable projects (Clone Hero, Playtonik)
- Lightweight footprint (~492KB managed DLL)
- 5.0/5 rating -- reviewers highlight MIDI-to-visual sync as killer feature
- MIT license on GitHub, standard EULA on Asset Store

**Verdict Rationale:**
Approved as Default Audio. MIDI data handling is a unique capability nothing else in the toolkit provides. Koreographer handles audio-based beat detection; DryWetMidi handles MIDI file parsing, device communication, and music theory. Together they cover both sides of music-interactive projects. Lightweight DLL, actively maintained, mature, MIT licensed. Essential for any project involving MIDI files, MIDI controllers, music notation, or programmatic composition.

**Asset Interactions:**
- **Koreographer (ENTRY-101):** Strong complementary pairing. Koreographer provides sample-precise audio beat events; DryWetMidi provides MIDI file parsing, note data, and device I/O. Together they cover audio-driven and MIDI-driven music interaction. Koreographer's MIDI Converter imports MIDI events into Koreography tracks -- direct integration path.
- **Master Audio 2024 (ENTRY-103):** No overlap. Master Audio handles audio playback; DryWetMidi handles MIDI data. DryWetMidi could trigger Master Audio sounds from MIDI note events.
- **Chunity (ENTRY-112):** Chunity has built-in MIDI input support via ChucK. DryWetMidi provides higher-level MIDI file operations (read/write/compose) that ChucK doesn't cover. Complementary if both are present.
- **FMOD (ENTRY-113):** No direct integration. MIDI events from DryWetMidi could trigger FMOD events via code.

**Claude vs Manual:**
- **Claude can do:** Write all MIDI file parsing code, note extraction, pattern building, music theory operations, device enumeration, playback setup. The entire API is code-driven.
- **Manual required:** MIDI device hardware setup (physical connections), auditioning MIDI playback, composing musical content.

**Replaces / Replaced By:** Nothing. MIDI data handling is a unique niche not covered by any other evaluated asset.

---

