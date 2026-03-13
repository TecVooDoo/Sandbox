# Sandbox - Development Reference

**Purpose:** Stable reference for Sandbox architecture, coding standards, and conventions. Read on demand -- primary interface is `Sandbox_Status.md`.
**Last Updated:** March 12, 2026

---

## What Sandbox Is

Sandbox has three responsibilities:

1. **Asset evaluation environment** -- import, test, and evaluate assets before they go into game projects (HOK, FearSteez, future projects). Primary output: `Sandbox_AssetLog.md`.

2. **Game project incubator** -- subprojects like FearSteez live here during early development before graduating to standalone projects. Code written here is production-quality because it transfers.

3. **TecVooDoo Utilities + MCP Tools development** -- shared libraries used by all projects are built and tested here before being packaged into `DefaultUnityPackages`.

Sandbox is NOT a game project itself. There is no "Sandbox game." Active subprojects have their own docs in `Documents/<ProjectName>/`.

---

## Active Subprojects

| Subproject | Root | Status | Docs |
|------------|------|--------|------|
| FearSteez (legacy) | `Assets/_Sandbox/FearSteez/` | Migrating to standalone | `Documents/FearSteez/` |
| HOK (legacy) | `Assets/Sandbox/HOK/` | Migrated to `E:\Unity\HookedOnKharon` | `E:\Unity\HookedOnKharon\Documents\` |

**Subproject root convention:** `Assets/_Sandbox/<ProjectName>/` (underscore prefix keeps subprojects sorted together and visually distinct from third-party assets).

---

## Folder Structure

```
Assets/
  _Sandbox/               -- TecVooDoo subprojects (underscore sorts to top)
    FearSteez/            -- FearSteez game subproject (migrating)
  Sandbox/                -- Legacy subproject location (HOK migrated)
  [Third-party assets]    -- All other folders = imported packages
Documents/
  Sandbox_Status.md       -- Primary doc: sessions, asset evals, current work
  Sandbox_AssetLog.md     -- 272+ asset evaluations
  FearSteez/              -- FearSteez subproject docs
  HOK/                    -- HOK docs (read-only, source of record is E:\Unity\HookedOnKharon\Documents\)
  SyntyAssets/            -- Absorbed from E:\Unity\SyntyAssets
  AudioProject/           -- Absorbed from E:\Unity\AudioProject
  AssetInventory/         -- Absorbed from E:\Unity\AssetInventoryProject
  SyntySidekicks/         -- Absorbed from E:\Unity\SyntySidekicks (project deleted)
```

---

## Coding Standards

These apply to all code written in Sandbox -- subproject code, evaluation scripts, MCP tools, and editor utilities. Code that transfers to game projects must already meet these standards.

- No `var` keyword -- explicit types always
- No per-frame allocations or LINQ
- Prefer async/await (UniTask) over coroutines
- Prefer interfaces and generics when appropriate -- decouple systems, reduce duplication
- ASCII-only in code, comments, and identifiers
- Keep scripts focused -- extract when a class has more than one clear responsibility. No hard line limit; a 3000-line class that does one thing well is fine.
- `sealed` on MonoBehaviours unless inheritance is intended
- ScriptableObject architecture for game data -- vanilla Unity SOs + GameEvent/GameEventListener (no SOAP asset)
- UI Toolkit only for any UI -- no uGUI Canvas (UIDocument, UXML, USS)

### Evaluation Code (Asset Evals / MCP Scripts)

Eval and test scripts are held to the same standards with one exception: they can be throwaway if clearly marked. Add a comment at the top: `// EVAL ONLY -- not for transfer`. Unmarked code is assumed production-quality.

---

## MCP Standards

Sandbox is the primary MCP evaluation and development environment. Custom MCP tools live in `E:\Unity\SyntyAssets\Assets\MCPTools\` and are packaged at `E:\Unity\DefaultUnityPackages\com.tecvoodoo.mcp-tools\`.

### MCP Gotchas (Battle-tested)

| Issue | Pattern | Fix |
|-------|---------|-----|
| HTML encoding | `<>` and `&&` get encoded in script-execute | Use `typeof()` casts and nested if-statements |
| No auto-persist | Roslyn edits don't save | Call `.Save()` / `SetDirty()` / `SaveAssets()` |
| Domain reload | MCP disconnects | Wait for auto-reconnect -- do not retry commands |
| NativeArray crash | Components with Unity.Collections NativeArrays crash `component-get` | Use `script-execute` for full API access instead |
| MinMaxCurve bug | `value:{}` on ParticleSystem MinMaxCurve corrupts on assignment | Use `*Multiplier` scalar companions (e.g., `startLifetimeMultiplier`) |
| Animation componentType | Must use full namespace | `UnityEngine.Transform` not `Transform` |
| RemoveCurve names | Uses internal names | `m_LocalPosition.x` not `localPosition.x` |
| Flexalon + RequireComponent | `[RequireComponent(typeof(FlexalonObject))]` auto-adds; `AddComponent<FlexalonObject>()` returns null | Use `GetComponent<FlexalonObject>()` after adding layout |
| RayFire runtime methods | `DemolishForced()` / `ApplyDamage()` crash from MCP context | Setup tools only -- no runtime physics calls via MCP |

### MCP Tool Development Pattern

```csharp
// In Assets/MCPTools/ (SyntyAssets project):
[McpPluginTool]
public async Task<string> ToolName(...)
{
    return await MainThread.Run(() => {
        // Unity API calls here
        return "result";
    });
}
```

- asmdef requires `overrideReferences: true` + `ReflectorNet.dll`
- `MCPToolsDefineManager.cs` auto-detects assets, adds `HAS_*` defines
- Assets without asmdefs (PWB, FinalIK) use file-level `#if HAS_X` guards
- `script-execute` is the power tool -- use for anything non-trivial

---

## TecVooDoo Utilities

**Docs:** `E:\TecVooDoo\Projects\Other\TecVooDooUtilities\Documents\`
**Full API:** `TVU_Reference.md` | **Status/tracking:** `TVU_Status.md`
**Package:** `com.tecvoodoo.utilities` v1.0.0
**Source:** `E:\Unity\DefaultUnityPackages\com.tecvoodoo.utilities\`
**Installed in:** All TecVooDoo projects (HOK, FearSteez, Sandbox, future)

### Modules (summary)

| Module | Contents |
|--------|----------|
| `Runtime/Extensions/` | VectorExtensions, TransformExtensions, GameObjectExtensions, CollectionExtensions, ListExtensions, NumberExtensions, ColorExtensions, StringExtensions, LayerMaskExtensions, RigidbodyExtensions |
| `Runtime/Timers/` | Timer (base), CountdownTimer, StopwatchTimer, FrequencyTimer, IntervalTimer, TimerManager, TimerBootstrapper, PlayerLoopUtils |
| `Runtime/Patterns/` | Singleton, PersistentSingleton, RegulatorSingleton |
| `Runtime/Gameplay/` | LookAtCamera, SimpleBoids |
| `Runtime/Logging/` | CategoryLogger |
| `Runtime/` | WaitFor |

### Candidate Identification

During any session -- evals, subproject work, or MCP tool development -- flag code that should go into Utilities if it meets ALL of these:

- **Zero project dependency** -- no references to HOK, FearSteez, or any game-specific types
- **Genuinely reusable** -- would benefit 2+ active projects right now, not hypothetically
- **No equivalent exists** -- check existing modules above first
- **Doesn't belong in MCP tools** -- editor-only helpers go in MCP tools, not Utilities

Good candidates: extension methods on Unity types, generic data structures, math helpers, lightweight design patterns, PlayerLoop utilities, zero-alloc collections.

Poor candidates: game-specific managers, SO types, anything with a project namespace, wrappers around third-party packages (DOTween, Animancer, etc.).

### Tracking

Note utility candidates in `Sandbox_Status.md` session entries with tag `[UTILITIES CANDIDATE]`. When promoted, tag the status entry `[UTILITIES ADDED]` and update `TVU_Status.md` + `TVU_Reference.md`.

---

## Asset Evaluation Standards

When evaluating an asset, capture in `Sandbox_AssetLog.md`:

- **Entry number** (ENTRY-XXX, sequential)
- **Package name + version**
- **Verdict:** Approved / Recommended / Conditional / Deferred / Rejected
- **Purpose** -- what it does and what problem it solves
- **FearSteez / HOK fit** -- is it relevant to active projects?
- **MCP controllability** -- if tested (add/get/modify/script-execute results)
- **Key gotchas** -- anything that bit us during eval
- **Cherry-pick targets** -- if Conditional/Deferred, what specifically is worth using

---

## Development Priorities

1. **Use installed packages first** -- check before writing custom code
2. **SOLID principles** -- interfaces, single responsibility, dependency inversion
3. **Memory efficiency** -- no per-frame allocations
4. **Clean code** -- readable, maintainable
5. **Self-documenting names** -- clear naming over comments

---

## AI Rules

1. **Primary doc is `Sandbox_Status.md`** -- check it first for current work and subproject state
2. **Working directory is `E:\Unity\Sandbox`** -- Unity 6 (6000.3.10f1), URP
3. **Subproject docs are authoritative for their project** -- for FearSteez work, read `Documents/FearSteez/FS_CodeReference.md` and `FS_DevReference.md`
4. **Verify names exist** -- search before referencing files/methods/classes
5. **Read before editing** -- always read files before modifying
6. **ASCII only** -- no smart quotes, em-dashes, or special characters
7. **Be direct** -- honest assessments, no sugar-coating
8. **Flag broken tools/workflows immediately** -- don't silently work around broken MCP, package conflicts, or import errors

---

## Reference Documents

| Document | Purpose |
|----------|---------|
| `Sandbox_Status.md` | Current work, sessions, asset eval log pointer |
| `Sandbox_AssetLog.md` | 272+ asset evaluations with verdicts and gotchas |
| `FearSteez/FS_Status.md` | FearSteez subproject status (migrating to standalone) |
| `SyntyAssets/SyntyAssets_Status.md` | Synty pack evaluations |
| `AudioProject/Audio_Status.md` | AudioProject absorbed docs |

---

**End of Development Reference**
