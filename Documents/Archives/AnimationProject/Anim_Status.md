# AnimationProject -- Status

**Project:** AnimationProject (Animation Creation & Character Animation Experimentation)
**Developer:** TecVooDoo LLC / Rune (Stephen Brandon)
**Unity Version:** 6000.3.11f1 (Unity 6, URP)
**Project Path:** `E:\Unity\AnimationProject`
**Last Updated:** March 18, 2026 (Session 1)

> **ARCHIVE RULE:** This doc holds only the current state and last ~2 sessions. When adding a new session, move older entries to `Anim_StatusArchive.md` (newest first at top of archive). This keeps the status doc fast to read while preserving full history.

---

## Purpose

AnimationProject serves two roles:

1. **Animation Creation** -- Build, test, and export character animations, rigs, and animation systems for use in other TecVooDoo projects (HOK, FearSteez, etc.)
2. **Animation Experimentation** -- Learn and experiment with Unity's animation systems, workflows, and tools. This is a learning-focused project since the developer has limited animation experience.

**Primary output:** Reusable animation clips, tested rigs/prefabs, animation controllers, and workflow knowledge.

**Related projects:**
- FearSteez (active game, needs combat animations): `E:\Unity\FearSteez\Documents\FS_Status.md`
- HOK (active game): `E:\Unity\HookedOnKharon\Documents\HOK_Status.md`
- AudioProject (similar eval/creation project for audio): `E:\Unity\AudioProject\Documents\Audio_Status.md`
- Sandbox (general asset eval): `E:\Unity\Sandbox\Documents\Sandbox_Status.md`

---

## Coding Standards

- No `var` keyword -- explicit types always
- Prefer async/await (UniTask) over coroutines unless trivial
- No per-frame allocations, no per-frame LINQ
- ASCII-only in docs and identifiers
- ScriptableObject event channels for decoupled communication
- UI Toolkit (UXML + USS + C#) for all UI
- Clear separation between logic and UI
- Favor interfaces and generics when possible
- File target: 800-1200 lines (soft guideline -- a 3000-line file that does one thing well is fine)

### Refactoring Rules

**Golden rule:** Don't refactor for the sake of refactoring. Priority order: SOLID > Memory > Clean > Self-documenting > Reusability.

**When TO refactor:** Has separable responsibilities, repeated code patterns across 3+ files, performance bottleneck identified by profiling, API is confusing to use correctly.

**When NOT TO refactor:** To hit a line count target, single-use helpers, code that is cohesive and naturally together, "might need it later" abstractions, during a feature milestone (do between milestones).

### Development Priorities

1. **SOLID principles first** -- SRP, OCP, LSP, ISP, DIP
2. **Memory efficiency second** -- zero-allocation hot paths, object pooling where appropriate
3. **Clean code third** -- readable, maintainable, consistent formatting
4. **Self-documenting code fourth** -- clear naming over comments
5. **Platform best practices fifth** -- Unity > C#
6. **Use installed assets** -- before writing custom code, check if an installed asset already solves the problem

---

## Current Work

**Session 1 complete.** MCP connected. Kharon On Duty / Off Duty system built with hop-down/up, sit/stand, turn 180, and Final IK foot placement. Animator controller (AC_Kharon) with 11 states and full transition chains. KharonDutyController script drives position arcs, lerps, and IK weight blending via raft-relative transform markers.

**Needs next:**
- Tune foot IK target positions (L/R are swapped from character perspective -- fix marker positions)
- Tune sit/stand position lerp (seatMarker placement relative to cooler)
- Add seated fishing layer (upper body avatar mask over SitLow Loop with Kevin Iglesias fishing clips)
- Add On Duty upper body gestures: point, remove mask/cloak, give-me
- Evaluate Animancer Pro for runtime animation blending (may replace Animator state machine approach)
- Evaluate UMotion Pro + Retarget Pro for custom clip creation workflow

---

## Sessions

*(Sessions logged newest-first)*

### Session 1 (Mar 18, 2026) -- MCP Setup + Kharon Animation System

**Status:** Complete.

**Work:**

**Project Setup:**
- MCP reconnected after VS Code restart: `.mcp.json` (port 52516, stdio, ai-game-developer), `.claude/settings.local.json` (bypassPermissions)
- MCP packages updated: com.ivanmurzak.unity.mcp 0.55.1 -> 0.56.0, com.ivanmurzak.unity.mcp.probuilder 1.0.30 added
- Default packages confirmed in manifest: UniTask, TecVooDoo Games, TecVooDoo MCP Tools, TecVooDoo Utilities, Unity ImageLoader, Unity Theme
- Synty Store Importer cloned from GitHub and installed at `Assets/Plugins/SyntyStudios/Editor/SyntyStoreImporter/`
- Additional Unity feature packages added: Characters & Animation, Development, ECS, Gameplay & Storytelling, Worldbuilding
- Kevin Iglesias Human Animations imported (344 clips: sit, fishing, crafting, combat, movement)

**Kharon Animation System:**
- Kharon is a Synty Sidekick (modular mesh, Kharon-avatar humanoid). Uses Sidekick animations (A_MOD_BL_ prefix)
- Two-state system: **On Duty** (standing on cooler) and **Off Duty** (sitting on cooler). Toggle with Tab key
- Off Duty transition: Hop down from cooler -> SitLow Begin -> Seated idle loop
- On Duty transition: SitLow Stop (stand) -> Turn 180 -> Hop up onto cooler -> Turn 180 -> Standing idle
- Raft prefab from HOK imported with Kharon, Cooler, Scorch (raccoon), Kharon_Fisher, lantern, soul positions
- Old baked-mesh Kharon disabled; replaced with modular Sidekick Kharon under Raft hierarchy
- Position system uses raft-relative Transform markers (HopStart, HopEnd, SeatMarker) so it works on a moving raft
- Hop arc uses front-biased parabola (arcPeakBias=0.3) to clear cooler geometry

**Scripts Created:**
- `KharonDutyController.cs` -- Main controller: sequence-based state machine with Hop/Turn/Lerp step types, FBBIK foot IK integration, Tab toggle
- `KharonHopDown.cs` -- Earlier standalone hop script (superseded by KharonDutyController, can be removed)

**Animation Assets Used:**
- `A_MOD_BL_Idle_Standing_Masc` -- Sidekick standing idle (On Duty)
- `A_MOD_BL_Jump_Idle_Masc` -- Sidekick jump takeoff (hop up/down)
- `A_MOD_BL_Land_IdleSoft_Masc` -- Sidekick soft landing
- `A_MOD_BL_Turn_Standing_180L_Masc` -- Sidekick 180-degree turn
- `HumanM@SitLow01 - Begin/Loop/Stop` -- Kevin Iglesias low sit (cooler height)
- Custom `A_Kharon_StepDown.anim` created via MCP script-execute with humanoid muscle curves (52 curves) -- not used in final system but kept as reference

**Animator Controller (AC_Kharon):**
- 11 states across two transition chains
- Parameters: GoOffDuty (trigger), GoOnDuty (trigger)
- Off Duty chain: OnDuty_Idle -> OD_HopDown_Takeoff -> OD_HopDown_Land -> OD_SitDown -> OffDuty_Idle
- On Duty chain: OffDuty_Idle -> ON_StandUp -> ON_Turn180 -> ON_HopUp_Takeoff -> ON_HopUp_Land -> ON_Turn180_Back -> OnDuty_Idle

**Final IK Integration:**
- FullBodyBipedIK added to Kharon with manual bone references (auto-detect failed on modular Sidekick mesh)
- 4 foot IK targets on raft: FootOnCoolerL/R (Y=0.56), FootSeatedL/R (Y=0.15)
- IK weight fades out during transitions, fades in during idle states
- Known issue: L/R foot targets are swapped from character perspective -- needs fixing

**Kharon Animation Roadmap:**
- Core: Hop down (done), Sit on cooler (done), Stand from seat (done), Hop up (done), Turn 180 (done)
- Pending: Seated fishing (upper body layer over SitLow Loop with Kevin Iglesias fishing clips)
- Pending On Duty gestures: finger point, remove mask/cloak, give-me (upper body layer over standing idle)

---

### Session 0 (Mar 18, 2026) -- Project Setup

**Status:** Complete. Document system created. Fresh Unity 6 project bootstrapped.

**Work:**
- MCP configured: `.mcp.json` (port 52516, stdio, ai-game-developer), `.claude/settings.local.json` (bypassPermissions)
- Default packages added to manifest.json: UniTask, TecVooDoo Games, TecVooDoo MCP Tools, TecVooDoo Utilities, Unity ImageLoader, Unity Theme
- MCP packages present: com.ivanmurzak.unity.mcp (0.55.1), com.ivanmurzak.unity.mcp.animation (1.0.32)
- OpenUPM scoped registry configured
- Document system created: Anim_Status.md

---

## Known Issues

| Issue | Severity | Status | Notes |
|-------|----------|--------|-------|
| Foot IK L/R swapped | Low | Open | FootOnCoolerL/R and FootSeatedL/R positions are swapped from character perspective. Swap the marker positions in scene |
| Sit/stand position tuning needed | Low | Open | SeatMarker position may need adjustment for pelvis to align with cooler surface |

---

## Lessons Learned

| # | Lesson |
|---|--------|
| 1 | MCP animation-modify SetCurve does not support humanoid muscle curves (componentType "Animator" fails). Use script-execute with AnimationUtility.SetEditorCurve and EditorCurveBinding for humanoid clips. |
| 2 | Synty Sidekick modular mesh characters fail FBBIK auto-detect. Must assign BipedReferences manually using Animator.GetBoneTransform(HumanBodyBones). |
| 3 | Root motion on sit/stand clips causes jerky snaps when root motion is disabled. Drive position via script lerp matching clip duration instead of relying on root motion or snapping at end. |
| 4 | Raft Y=90 rotation makes raft-local X/Z confusing. Use world-space marker positions for hop arcs, convert to raft-local only for static offsets. |
| 5 | Kevin Iglesias SitLow clips are the right match for cooler-height seats (RootT.y delta -0.40). SitMedium (-0.287) leaves character floating. |
| 6 | Project uses Input System package -- must use Keyboard.current.xKey.wasPressedThisFrame, not legacy Input.GetKeyDown. |

---

## Installed Packages

### Animation (Asset Store)
| Package | Version | Notes |
|---------|---------|-------|
| Animancer Pro v8 | 8.2.3 | Animation state machine |
| Animation Path Visualizer | 2.0.0 | Editor visualization |
| Human Crafting Animations | 2.2.1 | Animation clips |
| Retarget Pro | 4.2.1 | Animation retargeting |
| UMotion Pro | 1.29p04 | Animation editor |
| Koreographer Professional | 1.6.3 | Beat sync |
| Ultimate Character Controller | 3.3.3p1 | Opsive character system |

### QoL / Editor (Asset Store)
| Package | Version | Notes |
|---------|---------|-------|
| A* Pathfinding Project Pro | 5.4.6 | Navigation |
| ALINE | 1.7.9 | Debug drawing |
| Asset Inventory 4 | 4.1.0 | Asset management |
| Audio Preview Tool | 1.1.0 | Editor QoL |
| Curve Master | 1.2.2 | Animation curves |
| Default Playables | 2.0 | Timeline playables |
| DOTween Pro | 1.0.410 | Tweening |
| Final IK | 2.4 | Inverse kinematics |
| GanzSe Fishing | 1.0 | Low poly props |
| Inventory Framework 2 PRO | 2.0 | UI Toolkit |
| Odin Inspector and Serializer | 4.0.1.4 | Inspector enhancement |
| Poly Art: Raccoon | 4.0 | Character model |
| Poly Universal Pack | 4.8 | Low poly assets |
| POLYGON Alpine Mountain | 1.5.3 | Synty environment |
| Text Animator for Unity | 3.5.0 | Text animation |
| Ultimate Preview Window Pro | 1.3.2 | Preview |
| vFavorites 2 | 2.0.14 | Editor QoL |
| vFolders 2 | 2.1.14 | Editor QoL |
| vHierarchy 2 | 2.1.8 | Editor QoL |
| Wingman | 1.2.3 | Inspector helper |
| Master Audio 2024 | 1.0.3 | Audio system |

### Third-Party (UPM / OpenUPM)
| Package | Version | Notes |
|---------|---------|-------|
| AI Game Developer -- Unity MCP | 0.56.0 | IvanMurzak; port 52516 |
| AI Animation | 1.0.32 | IvanMurzak MCP extension |
| AI ProBuilder | 1.0.30 | IvanMurzak MCP extension |
| UniTask | 2.5.10 | Cysharp (local) |
| R3 (NuGet) | 1.3.0 | Cysharp |
| Image Loader | 7.0.1 | IvanMurzak (local) |
| PlayerPrefsEx | 2.1.3 | IvanMurzak |
| Unity Theme | 4.2.0 | IvanMurzak (local) |
| Animancer | 8.2.3 | Kybernetik |
| Text Animator by Febucci | 3.5.1 | Febucci |
| TecVooDoo MCP Tool Extensions | 1.0.0 | Local |
| TecVooDoo Games | 1.2.0 | Local |
| TecVooDoo Utilities | 1.1.0 | Local |
| Synty Store Importer | -- | GitHub clone (Assets/Plugins/) |

---

## Session Close Checklist

- [x] Update session summary
- [x] Update Known Issues if applicable
- [x] Update Lessons Learned if applicable
- [x] Update Installed Packages if changed

---

## Reference Documents

| Document | Path |
|----------|------|
| Sandbox Asset Log | `E:\Unity\Sandbox\Documents\Sandbox_AssetLog.md` |
| Archives | `E:\Unity\AnimationProject\Documents\Archives\` |
| Memory | `C:\Users\steph\.claude\projects\e--Unity-AnimationProject\memory\MEMORY.md` |

---

**End of Document**
