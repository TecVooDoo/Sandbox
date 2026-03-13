# AudioProject -- Asset Log

**Version:** 1.1 | **Updated:** 2026-03-11

## Verdicts

| Status | Meaning |
|--------|---------|
| APPROVED | Ready to use as-is |
| CONDITIONAL | Usable with noted caveats |
| TESTING | Currently being evaluated |
| DEFERRED | Not evaluated yet -- in queue |
| REJECTED | Not suitable; reason documented |

## Labels

Primary labels follow the TecVooDoo standard:
- **Default** -- Universal, install in every project
- **Default Audio** -- Universal for projects with audio needs (most projects)
- **Recommended** -- Best-in-class in its domain
- **Don't Use** -- Beyond redemption

Secondary labels: SFX, Music, Ambience, Voice, Mixing, Spatial, Procedural, Middleware, MIDI

---

## Summary Table

### Carried from Sandbox (no re-eval needed unless audio-specific testing required)

| Entry | Asset | Version | Sandbox # | Verdict | Label | Domain |
|-------|-------|---------|-----------|---------|-------|--------|
| -- | Master Audio 2024 | 1.0.3 | #103 | Approved | Default | Audio (Complete System) | **HIGH** (MCP evaluated) |
| -- | Koreographer Professional | 1.6.3 | #101 | Approved | Recommended | Audio (Music Sync) | **HIGH** (MCP evaluated) |
| -- | Audio Preview Tool | 1.1.0 | #102 | Approved | Default | Editor (Audio QoL) |
| -- | DryWetMIDI | 8.0.3 | #115 | Approved | Recommended | Audio (MIDI Data/Devices) |
| -- | UI Toolkit Sound Effects | 1.0.1 | #125 | Approved | Default UI | UI (Audio Integration) |
| -- | Native Audio | 7.0.0 | #105 | Conditional | -- | Audio (Low-Latency) |
| -- | Chunity: ChucK For Unity | 2.2.1 | #112 | Conditional | -- | Audio (Procedural Synthesis) |
| -- | FMOD for Unity | 2.03.11 | #113 | Conditional | -- | Audio (Middleware) |

### Evaluated (Session 2)

| Entry | Asset | Version | Verdict | Label | Domain | MCP Eval | Date |
|-------|-------|---------|---------|-------|--------|----------|------|
| 001 | Bro Audio | 2.2.2 | Conditional | Default Audio | Audio (Mixing/API) | High potential | 2026-03-11 |
| 002 | Procedural Music Generator | 2.0.0 | Conditional | Recommended | Audio (Procedural Music) | **HIGH** (evaluated) | 2026-03-11 |
| 003 | Maestro - Midi Player Tool Kit | 2.18.0 | Conditional | Default Audio | Audio (MIDI Synth) | **HIGH** (evaluated) | 2026-03-11 |
| 004 | Kalend Music and Playlist Player | 1.0 | Rejected | Don't Use | Audio (Music Playback) | N/A | 2026-03-11 |
| 005 | Localized Audio | 1.0 | Rejected | Don't Use | Audio (Localization) | N/A | 2026-03-11 |
| 006 | VoiceGPT | 2.0 | Rejected | Don't Use | Audio (Voice/TTS) | N/A | 2026-03-11 |
| 007 | Photon Voice 2 | 2.63 | Rejected | Don't Use | Audio (Networking) | N/A | 2026-03-11 |
| 008 | Timeflow (audio re-eval) | 1.10.1 | Conditional | -- | Audio (Reactive/MIDI) | Low | 2026-03-11 |

### Still Deferred

| Entry | Asset | Version | Verdict | Label | Domain | MCP Eval | Date |
|-------|-------|---------|---------|-------|--------|----------|------|
| -- | Convai / NPC AI Engine | 3.3.4 | DEFERRED | -- | AI (Voice/NPC) | Needed | -- |

### MCP Controllability Evaluations (Session 6)

| Asset | MCP Rating | Key API Surface | Notes |
|-------|-----------|-----------------|-------|
| **PATWA** | **Exceptionally High** | Singleton `MusicDirector.Instance`, synchronous API, 22 tools across 6 tiers | Purpose-built for MCP: `TransitionTo`, `SetMasterVolume`, contributor registration, beat clock query, stem mix control |
| **Master Audio 2024** | **High** | 258 static methods on `MasterAudio` class, string-based IDs | Pure static API: `PlaySound3DAtVector3`, `FadeBusToVolume`, `SetGroupVolume`, `TriggerPlaylistClip`. No instance needed. |
| **Koreographer Professional** | **High** | Singleton `Koreographer.Instance`, rich event registration | `LoadSong`, `GetAllEvents`, `RegisterForEvents`, sample-accurate timing. `SimpleMusicPlayer` for transport control. |
| **Procedural Music Generator** | **High** | `MusicGenerator` singleton, 40+ settable properties | Real-time `SetKeyChange`, `SetMode`, `SetTempo`, `ManualGroupOdds`, `FadeLoadConfiguration`. Rich events: `NotePlayed`, `StateSet`. |
| **Maestro MIDI** | **High** | `MidiFilePlayer`/`MidiStreamPlayer` components, real-time MIDI events | `MPTK_Play`/`MPTK_Stop`, channel enable/volume/preset, `MPTK_PlayEvent` for note injection. No Pro gating on playback. |

### MCP Controllability Evaluations (Session 8)

| Asset | MCP Rating | Key API Surface | Notes |
|-------|-----------|-----------------|-------|
| **DryWetMIDI** | **High** | `MidiFile` + `Playback` + `OutputDevice` + `PatternBuilder`, fluent chain API | Full programmatic MIDI manipulation: load, create, play, stop. Event callbacks for note tracking. |
| **Bro Audio** | **High** | 49 static methods on `BroAudio` class, `IAudioPlayer` per-instance | `Play`/`Stop`/`Pause`/`SetVolume`/`SetPitch`, bus-level control. Zero inspector dependencies for playback. |
| **FMOD Studio** | **High** | 62+ static methods on `RuntimeManager`, FMOD.Studio system direct access | `LoadBank`/`UnloadBank`, event instance control, VCA routing, parameter tweaking. Dual high/low-level API. |
| **Chunity (ChucK)** | **High** | 143 public methods on `Chuck` class, real-time code execution | `RunCode`/`RunFile`, bidirectional variable get/set, event signaling. Live audio programming via MCP. |
| **UI Toolkit Sound Effects** | **Medium** | 10 static methods, pool-based `AudioEvent` management | `GetFromPool`/`ResetAndReturnToPool`. Primarily ScriptableObject-driven, inspector-first design. |
| **Native Audio** | **Medium** | 16 static methods on `NativeAudio`, `NativeSource` per-handle | `Initialize`/`Load`/`Dispose`, platform-gated (iOS/Android only). Not usable in Editor. |

### MCP Controllability -- Still Needed

| Asset | Sandbox Verdict | MCP Eval | Notes |
|-------|----------------|----------|-------|
| Audio Preview Tool | Approved / Default | Low | Editor QoL -- less need for MCP control |

---

## Ecosystem Maps

*(Track how audio assets relate to each other -- complementary, competing, dependency chains)*

### Audio Middleware
- **FMOD** (Conditional) -- full middleware, competing with Master Audio as primary system
- **Master Audio 2024** (Default) -- primary audio system for all TecVooDoo projects

### Music Systems
- **Koreographer** (Recommended) -- BPM sync, beat-reactive events; complements Master Audio
- **Procedural Music Generator** (Recommended) -- real procedural generation from music theory, leitmotif system, group-based instrument toggling. **Highest PATWA relevance.** Complements Koreographer (generation vs sync)
- ~~**Kalend Music** (Rejected)~~ -- hobbyist jukebox, static singleton, Don't Use

### SFX / Mixing Systems
- **Bro Audio** (Conditional) -- clean programmer-friendly API, fluent chaining, Dominator pattern. Complementary to Master Audio (lighter, more code-centric). No musical time concepts
- **Native Audio** (Conditional) -- low-latency native playback; complements Master Audio for latency-critical use

### MIDI
- **DryWetMIDI** (Recommended) -- MIDI data and device library (read/write/manipulate)
- **Maestro** (Conditional) -- MIDI-to-audio SoundFont synth (FluidSynth port). Complementary to DryWetMIDI: DryWetMIDI handles data, Maestro handles playback/synthesis. Per-channel mute/volume/preset-override for adaptive layering

### Procedural Audio
- **Chunity/ChucK** (Conditional) -- real-time procedural synthesis from Stanford CCRMA
- **Procedural Music Generator** (Recommended) -- also listed under Music Systems; procedural composition engine with built-in synth

### Audio-Reactive / Sequencing
- **Timeflow** (Conditional) -- not an audio system, but has Audio Spectrum + Sample + Reactive chain for driving properties from audio. MIDI File/Receiver components. Useful for audio visualization and MIDI-driven animation

### Voice / Dialogue Audio
- ~~**VoiceGPT** (Rejected)~~ -- editor-only TTS, 872MB models, CUDA required, Don't Use
- ~~**Photon Voice 2** (Rejected)~~ -- networking voice chat, paid Photon subscription, Don't Use
- **Convai** (Deferred) -- AI NPC dialogue; requires API subscription

### UI Audio
- **UI Toolkit Sound Effects** (Default UI) -- Kamgam; CustomPlayFunc hook for Master Audio integration

---

## Cherry-Pick Candidates

*(Assets where we might extract specific features rather than using the whole package)*

| Asset | Feature of Interest | Status |
|-------|-------------------|--------|
| Bro Audio | Dominator pattern (auto-resetting ducking/filtering) | Noted |
| Bro Audio | PlaybackGroup rule system (CombFilteringRule, MaxPlayableCount) | Noted |
| Bro Audio | Fluent API chaining pattern (`Play().AsBGM().SetTransition()`) | Noted |
| Bro Audio | InstanceWrapper handover (seamless player swap without breaking refs) | Noted |
| Bro Audio | SpectrumAnalyzer (multi-band, attack/decay, peak/RMS/average) | Noted |
| Procedural Music Generator | Leitmotif system (per-instrument preset motifs) | Noted |
| Procedural Music Generator | ChordProgressions (theory-aware procedural generation) | Noted |
| Procedural Music Generator | NoteGenerator hierarchy (Melody/Rhythm/Lead with scale awareness) | Noted |
| Procedural Music Generator | GeneratorMod extensibility pattern | Noted |
| Procedural Music Generator | Group system (dynamic instrument group on/off) | Noted |
| Maestro | MPTKChannels per-channel enable/volume/forced-preset pattern | Noted |
| Maestro | MidiStreamPlayer real-time event injection | Noted |
| Timeflow | Audio Spectrum + Sample + Reactive chain (audio-reactive property driving) | Noted |
| Timeflow | MIDI File/Receiver components (MIDI-driven animation) | Noted |
| GrabMaster (Sandbox #238) | AudioClipSettings/AudioEventPlayer pattern | Noted |

---

## Detailed Evaluations

*(ENTRY blocks added as assets are evaluated -- newest first)*

---

## ENTRY-001: Bro Audio 2.2.2

| Field | Value |
|-------|-------|
| **Asset** | Bro Audio |
| **Version** | 2.2.2 |
| **Developer** | Ami (Wuyu) |
| **Source** | Asset Store (`Assets/BroAudio/`) |
| **Primary Label** | Default Audio |
| **Secondary Labels** | Mixing, SFX |
| **Verdict** | Conditional |
| **Date** | 2026-03-11 |
| **Session** | 2 |
| **Scripts** | 291 |
| **Asmdefs** | 2 (BroAudio, BroAudio.Editor) |
| **Namespace** | `Ami.BroAudio` |

**What It Is:** Mid-weight audio management framework wrapping Unity AudioSource/AudioMixer behind a clean static API. Supports Music/UI/Ambience/SFX/VoiceOver types, BGM transitions (CrossFade, FadeIn, FadeOut), Dominator system for ducking/filtering, multi-clip modes (Sequence, Random, Shuffle, Velocity, Chained intro/loop/outro), seamless looping with tempo awareness, runtime audio filter chaining, spectrum analyzer, Addressables support, and object pooling.

**Architecture:** Excellent interface segregation -- `IAudioPlayer` composes `IEffectDecoratable`, `IVolumeSettable`, `IMusicDecoratable`, `IAudioStoppable`, `ISchedulable`. Strategy pattern for clip selection, decorator pattern for player behaviors, rule pattern for playback validation. Fluent API: `BroAudio.Play(id).AsBGM().SetTransition(Transition.CrossFade).SetVolume(0.8f)`. Partial class decomposition of AudioPlayer and SoundManager for SRP.

**vs Master Audio (#103, Approved/Default):** Complementary, not competing. Master Audio is heavyweight/editor-centric; Bro Audio is lightweight/programmer-friendly. Bro Audio's Dominator pattern is unique. Both can coexist but require careful AudioMixer routing.

**PATWA Relevance:** Moderate. Per-player volume/pitch control, `OnUpdate` callbacks, `OnAudioFilterRead` access, Dominator for entity suppression, velocity-based clip selection. **Missing:** No layer/stem system, no beat/bar sync, no horizontal re-sequencing, no parameter-driven mixing. Custom adaptive layer required on top.

**Code Concerns:** Coroutines throughout (not UniTask), some `var` usage, LINQ in hot path (`_addedEffects.Any()`), SeamlessLoopHelper entirely commented out, typo `_auidoTypePref`.

**MCP Potential:** High. Static `BroAudio.Play/Stop/SetVolume/SetPitch/SetEffect` API is ideal for `script-execute`. SoundID discovery requires querying `_audioBank` dictionary.

**Verdict Rationale:** Clean architecture with genuinely useful patterns (Dominator, PlaybackGroup rules, fluent API). Useful as playback infrastructure under a custom adaptive controller. Conditional because musical time concepts must be built on top.

---

## ENTRY-002: Procedural Music Generator 2.0.0

| Field | Value |
|-------|-------|
| **Asset** | Procedural Music Generator |
| **Version** | 2.0.0 |
| **Developer** | Music Computing Design Group at Stanford |
| **Source** | Asset Store (`Assets/MusicGeneratorMain/`) |
| **Primary Label** | Recommended |
| **Secondary Labels** | Music, Procedural |
| **Verdict** | Conditional |
| **Date** | 2026-03-11 |
| **Session** | 2 |
| **Scripts** | 165 |
| **Asmdefs** | 0 (Assembly-CSharp) |
| **Namespace** | `ProcGenMusic` |

**What It Is:** True procedural music generation engine from music theory rules. Generates real-time music with keys, scales (Major, Minor variants, Harmonic Major), all 7 church modes, procedural chord progressions (Tonic/Subdominant/Dominant weighting), tritone substitutions. Up to 20 instruments per config across 4 groups with dynamic on/off. Three note generators (Melody/Rhythm/Lead) with arpeggio patterns. **Leitmotif system** for per-instrument preset motifs. Built-in waveform synthesizer (Sin/Square/Triangle/Sawtooth/Custom) with ADSR. FMOD backend support. Mod system for extensibility. JSON-based config presets (~40: Adversity, Ambient, Baroque, DungeonBoss, etc.).

**Architecture:** `PMGAudioHandler` interface abstracts Unity vs FMOD backends. `NoteGenerator` abstract with Melody/Rhythm/Lead. `Measure` abstract with Regular/Repeat. `GeneratorMod` for extensibility. Rich event system (StateSet, NotePlayed, NotesGenerated, GroupsWereChosen). Good XML docs. **Weaknesses:** No asmdef files. `ConfigurationData.cs` is 2578-line God Object. Heavy `var` usage (259 occurrences). Coroutine-based async. `MusicGenerator` is sealed MonoBehaviour with `DontDestroyOnLoad`. No DI.

**PATWA Relevance:** **Highest of all evaluated packages.** Group system maps to entity-driven instruments. `ManualGroupOdds` + `GroupsAreTemporarilyOverriden` for runtime game-code control. Leitmotif system IS "Peter and the Wolf." `NotesGenerated`/`NotePlayed` delegates for intercepting/modifying notes. Config swapping (`FadeLoadConfiguration`) for mood transitions. Mod system for entity-driven behavior. **Limitations:** Only 4 groups, only 20 instruments max, no style interpolation, coroutine config loading.

**Code Concerns:** No asmdef (pollutes Assembly-CSharp). ConfigurationData God Object. `var` everywhere. TODO comments ("Test me, it's been awhile :P"). Self-deprecating comments. `#pragma warning disable 0649` globally. No tests.

**MCP Potential:** Good. `Play/Pause/Stop/SetState`, `LoadConfiguration`, `SetVolume`, `InstrumentSet.OverrideGroupIsPlaying`, Mode/Scale/Key/Tempo all settable at runtime via `script-execute`.

**Verdict Rationale:** Only asset that does real procedural generation with music theory. Leitmotif and group systems directly serve AQS vision. Recommended despite code quality issues because the music generation logic is solid and irreplaceable. Conditional because it needs wrapper/adapter for coding standards compliance, and group/instrument limits need extension.

---

## ENTRY-003: Maestro - Midi Player Tool Kit 2.18.0

| Field | Value |
|-------|-------|
| **Asset** | Maestro - Midi Player Tool Kit (Free) |
| **Version** | 2.18.0 |
| **Developer** | Thierry Bachmann |
| **Source** | Asset Store (`Assets/MidiPlayer/`) |
| **Primary Label** | Default Audio |
| **Secondary Labels** | MIDI |
| **Verdict** | Conditional |
| **Date** | 2026-03-11 |
| **Session** | 2 |
| **Scripts** | 170 |
| **Asmdefs** | 3 (MidiPlayer.Run, MidiPlayer.Demo, MidiPlayer.Editor) |
| **Namespace** | `MidiPlayerTK` |

**What It Is:** Complete MIDI playback and SoundFont synthesis engine -- C# port of FluidSynth. `MidiFilePlayer` for MIDI file playback, `MidiStreamPlayer` for real-time note generation. Full SF2 SoundFont rendering with envelope, filter, LFO, modulation, reverb, chorus. 16-channel architecture with per-channel enable/mute, volume, forced preset/bank override, pitch bend, CC controllers. 3D spatialization with orientation-based panning. MIDI event callbacks. Bundled NAudio fork.

**Architecture:** Clear inheritance: `MidiSynth` -> `MidiFilePlayer`/`MidiStreamPlayer`. Partial classes for concern separation. `MPTKChannels` implements `IEnumerable<MPTKChannel>`. Proper asmdef isolation. **Weaknesses:** Zero interfaces (no `IMidiPlayer`, `ISynthEngine`). God-class files (MidiSynth 3573 lines, fluid_voice 2919 lines). Public fields instead of properties. `#if MPTK_PRO` gating throughout (47 occurrences). FluidSynth port retains C-style naming. Bundled Routine.cs coroutine system (6751 lines).

**vs DryWetMIDI (#115, Approved/Recommended):** Complementary. DryWetMIDI excels at MIDI data processing (R/W, split, merge, quantize, transpose). Maestro excels at turning MIDI into audio (SoundFont synth). Together: DryWetMIDI for composition/manipulation, Maestro for playback. Overlap: both parse MIDI files (NAudio fork vs DryWetMIDI parser).

**PATWA Relevance:** High. Per-channel mute/enable maps to entity enters/leaves. Per-channel volume for distance/importance scaling. Forced preset override for dynamic instrument swapping. MidiStreamPlayer for algorithmic note generation driven by entity behavior. OnEventNotesMidi for intercepting events per entity. 3D spatialization per player. **Limitation:** 16-channel MIDI limit; multi-entity needs multiple MidiStreamPlayer instances or channel management layer.

**Code Concerns:** Zero interfaces (must build wrapper/facade). Pro gates key features (`OnMidiEvent` for modifying events in flight). 47K lines embedded code including full FluidSynth port. `lock(this)` anti-pattern. Deprecated classes still shipped.

**MCP Potential:** Moderate. Prefab-based; MCP can create/configure players, set MIDI files, enable/disable channels, adjust properties. Real-time streaming API needs `script-execute` for MPTKEvent construction.

**Verdict Rationale:** Fills critical gap -- actual MIDI-to-audio synthesis in Unity. Per-channel control maps well to adaptive layering. Conditional because: no interfaces require facade layer, Pro version likely needed for full adaptive audio (OnMidiEvent interception), heavy dependency footprint.

---

## ENTRY-004: Kalend Music and Playlist Player 1.0

| Field | Value |
|-------|-------|
| **Asset** | Kalend Music and Playlist Player |
| **Version** | 1.0 |
| **Developer** | Kalend Music |
| **Source** | Asset Store (`Assets/Kalend/`) |
| **Primary Label** | Don't Use |
| **Verdict** | Rejected |
| **Date** | 2026-03-11 |
| **Session** | 2 |
| **Scripts** | 13 |
| **Asmdefs** | 1 (KalendMusic) |
| **Namespace** | `Kalend` |

**What It Is:** UI-driven music jukebox/playlist player. Sequential playback, shuffle, repeat, scrubber, AudioMixer fading.

**Why Rejected:** Static singleton architecture -- `public static` fields for `currentAudioClip`, `currentAudioSource`, `clipCount`, `currentIndex`. Cannot have two independent players. 4-level deep linear inheritance chain (`AudioSelection` -> `AudioPlayer` -> `ClipSelector` -> `PlaylistSelector`). Zero interfaces, zero generics. **Bug:** 44.1kHz coded as `41100` instead of `44100`. **Bug:** Typo enum `NinteySix`. Duplicate code files (`Utilities.cs` = `LerpTypes.cs`). Dead code (`while` loops with immediate `break`). UI tightly coupled to core audio classes. Master Audio's playlist system provides 20x the functionality.

**PATWA Relevance:** None. Static singleton cannot manage multiple simultaneous audio streams.

---

## ENTRY-005: Localized Audio 1.0

| Field | Value |
|-------|-------|
| **Asset** | Localized Audio |
| **Version** | 1.0 |
| **Developer** | Fenikkel (Pau Fenollosa) |
| **Source** | UPM (`com.fenikkel.localized-audio`) |
| **Primary Label** | Don't Use |
| **Verdict** | Rejected |
| **Date** | 2026-03-11 |
| **Session** | 2 |
| **Scripts** | 1 (327 lines) |
| **Asmdefs** | 0 |

**What It Is:** 327-line singleton wrapper around Unity's built-in `LocalizeAudioClipEvent`. Play/Preload/Stop with live locale swap preserving playback position.

**Why Rejected:** Adds almost nothing over native Unity Localization. Singleton, single AudioSource, coroutine-based, dead code (`_FadeCoroutine` declared but never assigned), bare `catch` blocks, build-breaking sample scripts (reference `UnityEditor` in runtime). If localized audio is needed, Unity's own component or Master Audio handles it.

**PATWA Relevance:** None.

---

## ENTRY-006: VoiceGPT 2.0

| Field | Value |
|-------|-------|
| **Asset** | VoiceGPT |
| **Version** | 2.0 |
| **Developer** | AiKodex |
| **Source** | Asset Store (`Assets/VoiceGPT/`) |
| **Primary Label** | Don't Use |
| **Verdict** | Rejected |
| **Date** | 2026-03-11 |
| **Session** | 2 |
| **Scripts** | 4 |
| **Asmdefs** | 0 |

**What It Is:** Editor-only TTS tool using local StyleTTS2 diffusion model via Python. 58 preset voices, voice cloning, parametric EQ, pitch shifting.

**Why Rejected:** Editor-only (zero runtime API). 872MB of ML models. Requires Python for Unity + CUDA GPU. Monolithic 1200-line EditorWindow god-class. `exec()` config parsing (injection risk). CanvasController references `UnityEditor` in MonoBehaviour (build failure). Bug: German maps to French language code. Better external TTS tools exist (ElevenLabs, etc.) without embedding 872MB in the project.

**PATWA Relevance:** None.

---

## ENTRY-007: Photon Voice 2 2.63

| Field | Value |
|-------|-------|
| **Asset** | Photon Voice 2 |
| **Version** | 2.63 |
| **Developer** | Photon Engine (Exit Games) |
| **Source** | Asset Store (`Assets/Photon/`) |
| **Primary Label** | Don't Use |
| **Verdict** | Rejected |
| **Date** | 2026-03-11 |
| **Session** | 2 |
| **Scripts** | 246 |
| **Asmdefs** | Multiple |
| **Namespace** | `Photon.Voice`, `Photon.Voice.Unity` |

**What It Is:** Networked voice/audio streaming SDK. Opus encoding, WebRTC DSP (AEC/AGC/noise suppression), real-time voice chat over Photon servers.

**Why Rejected:** Wrong tool entirely. 337MB footprint. Requires paid Photon Cloud subscription (AppIdVoice). Drags entire Photon networking stack. Zero capabilities for audio creation, procedural audio, adaptive music, or local audio processing. Architecture is decent for its domain (clean `IEncoder`/`IDecoder`/`IAudioReader` interfaces) but irrelevant here.

**PATWA Relevance:** None unless multiplayer audio streaming needed.

---

## ENTRY-008: Timeflow Animation System 1.10.1 (Audio Re-eval)

| Field | Value |
|-------|-------|
| **Asset** | Timeflow Animation System |
| **Version** | 1.10.1 |
| **Developer** | Axon Genesis |
| **Source** | Asset Store (`Assets/Plugins/Timeflow/`) -- closed-source DLL |
| **Primary Label** | -- |
| **Secondary Labels** | -- |
| **Verdict** | Conditional |
| **Date** | 2026-03-11 |
| **Session** | 2 |
| **Previous Eval** | Sandbox #100, Conditional (animation-focused) |
| **Namespace** | `AxonGenesis` |

**Audio Capabilities Found:**

4 audio components: **Audio Track** (AudioSource wrapper with ADSR, pitch-linked-to-timescale, waveform display), **Audio Spectrum** (FFT analyzer, configurable resolution, mic input, RMS/frequency detection), **Audio Sample** (frequency band sampler with presets -- Subsonic through Supersonic, threshold, decay, shader output), **Audio Reactive** (maps audio analysis to any Timeflow-animatable property, trigger threshold, attack/release envelope, presets: Bouncey/Floating/Punchy/Soft).

4 MIDI components: **MIDI File** (playback with BPM/TPQN control, scene BPM matching), **MIDI Receiver** (live input with ADSR, polyphonic, velocity mapping), **MIDI Cloner**, **MIDI Tween**.

**vs Unity Timeline:** Timeflow adds ADSR envelopes, real-time spectrum analysis, frequency band sampling, audio-reactive property driving, MIDI playback/input, mic input -- none available in Unity Timeline.

**PATWA Relevance:** Moderate. The Spectrum -> Sample -> Reactive chain is unique among installed assets -- useful for audio visualization and audio-responsive gameplay. MIDI components complement DryWetMIDI. **Not an audio system** -- cannot sequence audio events, no mixing/routing/bus system, no integration with Master Audio or FMOD. No AudioMixer routing in prefabs.

**Verdict Rationale:** Keep installed for audio-reactive animation and MIDI-driven visuals. Conditional because it is an animation tool with audio features, not an audio tool. Closed-source DLL limits inspection and extension.

---

## MCP Controllability -- Detailed Evaluations (Session 6)

---

### MCP-EVAL-001: PATWA (com.tecvoodoo.patwa)

| Field | Value |
|-------|-------|
| **Rating** | Exceptionally High |
| **API Pattern** | Singleton (`MusicDirector.Instance`) + static helpers |
| **Parameter Types** | Primitives, strings, ScriptableObject references |
| **Runtime Access** | Full -- all APIs available at runtime |

**MCP Tool Surface (22 tools across 6 tiers):**

1. **Context Management:** `TransitionTo(contextName, duration)`, `GetCurrentContext()`, `ListAvailableContexts()`
2. **Contributor Control:** `RegisterContributor(id, profile)`, `UnregisterContributor(id)`, `SetContributorIntensity(id, value)`, `SetContributorState(id, state)`, `ListActiveContributors()`
3. **Mix Control:** `SetMasterVolume(value)`, `SetStemVolume(slotName, value)`, `MuteStem(slotName)`, `UnmuteStem(slotName)`, `GetMixState()`
4. **Beat Clock:** `GetCurrentBeat()`, `GetCurrentBar()`, `GetBPM()`, `SetBPM(value)`
5. **Reactive:** `SetReactiveBinding(bindingName, enabled)`, `GetBandEnergy(bandIndex)`
6. **Debug:** `GetContributorDebugInfo()`, `GetStemDebugInfo()`, `ForceConflictResolution()`

**Why Exceptional:** Purpose-built singleton pattern with synchronous getters/setters. String-based stem/contributor IDs. No async barriers. ScriptableObject references resolvable by name. Every subsystem exposed through MusicDirector facade.

---

### MCP-EVAL-002: Master Audio 2024

| Field | Value |
|-------|-------|
| **Rating** | High |
| **API Pattern** | Pure static (`MasterAudio.PlaySound3DAtVector3(...)`) |
| **Parameter Types** | Strings (sound group names, bus names, playlist names), floats, Vector3 |
| **Runtime Access** | Full -- 258 static methods, no instance needed |

**Key MCP-Controllable APIs:**
- `PlaySound3DAtVector3(sndGroupName, sourcePosition)` / `StopAllOfSound(sndGroupName)`
- `FadeBusToVolume(busName, targetVolume, fadeTime)` / `SetBusVolumeByName(busName, volume)`
- `SetGroupVolume(sndGroupName, volume)` / `MuteGroup(sndGroupName)` / `UnmuteGroup(sndGroupName)`
- `TriggerPlaylistClip(playlistControllerName, clipName)` / `FadePlaylistToVolume(volume, fadeTime)`
- `SetInnerGroupMixVolume(sndGroupName, variation, volume)` -- per-variation control

**Why High:** Entirely static API -- no instance discovery needed. All identifiers are strings (group names, bus names). 258 methods cover every audio operation. MCP can control the entire audio mix without touching any game objects.

---

### MCP-EVAL-003: Koreographer Professional

| Field | Value |
|-------|-------|
| **Rating** | High |
| **API Pattern** | Singleton (`Koreographer.Instance`) + `SimpleMusicPlayer` component |
| **Parameter Types** | Strings (event IDs, track names), ints (sample positions), floats |
| **Runtime Access** | Full -- event registration, transport, timing queries |

**Key MCP-Controllable APIs:**
- `Koreographer.Instance.LoadSong(koreography, startSampleTime)` / `GetAllEvents(eventID)`
- `SimpleMusicPlayer.LoadSong(koreography)` / `Play()` / `Pause()` / `Stop()` / `SeekToSample(sampleTime)`
- `RegisterForEvents(eventID, callback)` / `UnregisterForEvents(eventID, callback)`
- `GetMusicBeatTime()` / `GetMusicSampleTime()` -- sample-accurate timing queries
- `FlipPayloadOnEvent(eventID)` -- runtime event modification

**Why High:** Singleton access, string-based event IDs, sample-accurate timing. MCP can load songs, seek to positions, register/query beat events, and control transport. Event system maps cleanly to MCP tool patterns.

---

### MCP-EVAL-004: Procedural Music Generator

| Field | Value |
|-------|-------|
| **Rating** | High |
| **API Pattern** | Singleton (`MusicGenerator` with `DontDestroyOnLoad`) |
| **Parameter Types** | Enums (Key, Scale, Mode), ints, floats, strings (config names) |
| **Runtime Access** | Full -- 40+ settable properties, real-time generation control |

**Key MCP-Controllable APIs:**
- `Play()` / `Pause()` / `Stop()` / `SetState(GeneratorState)`
- `SetKeyChange(key)` / `SetMode(mode)` / `SetTempo(bpm)` -- real-time music theory changes
- `FadeLoadConfiguration(configName)` -- mood/preset transitions with crossfade
- `ConfigurationData.ManualGroupOdds[groupIndex]` / `GroupsAreTemporarilyOverriden` -- group control
- `InstrumentSet[i].Volume` / `.Odds` / `.OverrideGroupIsPlaying` -- per-instrument control
- Events: `NotePlayed`, `NotesGenerated`, `StateSet`, `GroupsWereChosen`

**Why High:** Singleton with rich property surface. Real-time key/scale/mode/tempo changes. Group odds for entity-driven instrument toggling. Config swapping for mood transitions. 40+ parameters all settable via simple property assignment.

---

### MCP-EVAL-005: Maestro MIDI (MidiPlayerTK)

| Field | Value |
|-------|-------|
| **Rating** | High |
| **API Pattern** | Component-based (`MidiFilePlayer`, `MidiStreamPlayer`) |
| **Parameter Types** | Ints (channels, notes, programs), floats (volume, tempo), strings (MIDI file names) |
| **Runtime Access** | Full for playback; real-time MIDI events via MidiStreamPlayer |

**Key MCP-Controllable APIs:**
- `MidiFilePlayer.MPTK_MidiName` / `MPTK_Play()` / `MPTK_Stop()` / `MPTK_Pause()`
- `MPTK_Volume` / `MPTK_Speed` / `MPTK_Transpose` -- global transport controls
- `MPTK_Channels[ch].Enable` / `.Volume` / `.ForcedPreset` -- per-channel control (16 channels)
- `MidiStreamPlayer.MPTK_PlayEvent(new MPTKEvent { Command, Channel, Value, Duration })` -- real-time note injection
- `MPTK_ChannelBankGetPreset(channel)` / `MPTK_ChannelPresetChange(channel, preset)` -- instrument switching
- General MIDI: 128 standard instruments addressable by program number

**Why High:** Component discovery via `FindObjectOfType`. Per-channel enable/volume/preset maps directly to MCP tools. Real-time MIDI note injection enables AI-driven composition. Transport controls (play/stop/pause/speed/transpose) are simple property assignments. No Pro gating on core playback features.

---

### MCP-EVAL-006: DryWetMIDI (Melanchall)

| Field | Value |
|-------|-------|
| **Rating** | High |
| **API Pattern** | Library classes (MidiFile, Playback, OutputDevice, PatternBuilder) |
| **Parameter Types** | Custom types (SevenBitNumber, MusicalTimeSpan, NoteName), standard .NET |
| **Runtime Access** | Full -- all operations via code, no Inspector required |

**Key MCP-Controllable APIs:**
- `MidiFile.Read(path)` / `new MidiFile(chunks)` -- load or create MIDI files
- `Playback(midiFile, tempoMap, outputDevice)` -- playback control with `Start`/`Stop`/`MoveToTime`
- `OutputDevice.GetByName(name)` / `GetAll()` -- MIDI output routing
- `PatternBuilder.Note(name, length)` / `.Chord(notes, length)` -- fluent MIDI composition
- Events: `NotesPlaybackStarted`, `NotesPlaybackFinished` -- real-time note tracking

**Why High:** Pure library API with no Inspector dependencies. All MIDI operations (load, create, manipulate, play, route) are fully programmatic. Custom types require mapping but are straightforward. Event-driven callbacks enable real-time MIDI monitoring from MCP tools. Only limitation is requiring external MIDI output device or synth for audio.

---

### MCP-EVAL-007: Bro Audio

| Field | Value |
|-------|-------|
| **Rating** | High |
| **API Pattern** | Static facade (`BroAudio` class, 49 methods) + singleton `SoundManager` |
| **Parameter Types** | SoundID (custom struct), BroAudioType (enum), float for volume/pitch/fade |
| **Runtime Access** | Full -- static methods callable from anywhere |

**Key MCP-Controllable APIs:**
- `BroAudio.Play(SoundID, fadeIn)` -- 6 overloads for positional/non-positional playback
- `BroAudio.Stop(SoundID/BroAudioType, fadeOut)` -- 4 stop methods with fade
- `BroAudio.Pause/UnPause(SoundID, fadeTime)` -- 8 pause methods
- `BroAudio.SetVolume(float, BroAudioType, fadeTime)` -- bus-level volume
- `IAudioPlayer.SetPitch()` / `.GetDuration()` / `.IsPlaying()` -- per-instance control
- `BroAudio.OnBGMChanged` -- event subscription for music state tracking

**Why High:** Cleanest static API surface of any audio asset evaluated. All playback operations are one-line static calls with no object discovery required. SoundID must be pre-configured in LibraryManager editor, but once set up, MCP can trigger any registered sound by ID. Bus-level volume/mute provides mix control.

---

### MCP-EVAL-008: FMOD Studio

| Field | Value |
|-------|-------|
| **Rating** | High |
| **API Pattern** | Static facade (`RuntimeManager`, 62+ methods) + FMOD native API |
| **Parameter Types** | String paths for events/banks, float for parameters, GUID for events |
| **Runtime Access** | Full -- dual high-level and low-level API |

**Key MCP-Controllable APIs:**
- `RuntimeManager.StudioSystem` / `.CoreSystem` -- direct FMOD system access
- `RuntimeManager.LoadBank(name, loadSamples)` / `UnloadBank(name)` -- bank management
- `RuntimeManager.CreateInstance(eventPath)` -- event instance creation
- `EventInstance.start()` / `.stop()` / `.setParameterByName(name, value)` -- per-instance control
- `RuntimeManager.AttachInstanceToGameObject(instance, transform)` -- spatial audio binding

**Why High:** Enterprise-grade API with both high-level convenience methods and low-level system access. String-based event paths map naturally to MCP tool parameters. Parameter tweaking is straightforward. Requires FMOD Studio project with compiled banks -- cannot create audio content at runtime, only control playback and parameters.

---

### MCP-EVAL-009: Chunity (ChucK)

| Field | Value |
|-------|-------|
| **Rating** | High |
| **API Pattern** | Singleton accessor (`Chuck.Manager`), 143 public methods |
| **Parameter Types** | String for code/filenames/variable names, UInt32 for instance IDs |
| **Runtime Access** | Full -- real-time code execution and variable binding |

**Key MCP-Controllable APIs:**
- `Chuck.Manager.Initialize(mixer, name)` -- per-instance setup
- `RunCode(chuckId, code)` -- execute ChucK scripts at runtime (live coding)
- `RunFile(name, filename, args)` -- load and run .ck files
- `SetInt/Float/String(name, varName, value)` -- push parameters into ChucK
- `GetInt/Float/String(name, varName, callback)` -- read values from ChucK
- `SignalEvent(name, varName)` -- trigger ChucK events from C#

**Why High:** Uniquely powerful for MCP -- enables real-time audio programming through code injection. MCP tools can write and execute ChucK scripts dynamically, creating procedural audio on the fly. Bidirectional data binding allows reading synthesis state. Limitation is the ChucK language barrier -- requires domain expertise for meaningful audio generation.

---

### MCP-EVAL-010: UI Toolkit Sound Effects

| Field | Value |
|-------|-------|
| **Rating** | Medium |
| **API Pattern** | ScriptableObject-based configuration + static pool methods |
| **Parameter Types** | SoundEffect (SO), ElementEventType (enum), AudioClip references |
| **Runtime Access** | Partial -- pool management is programmatic, but setup is inspector-first |

**Key MCP-Controllable APIs:**
- `SoundEffects.GetOrCreate()` -- access configured sound effects asset
- `AudioEvent.GetFromPool()` / `GetCopyFromPool(baseObject)` -- instance pooling
- `AudioEvent.ResetAndReturnToPool()` -- resource recycling
- `SoundEffect` trigger via UIElement reference or event bus

**Why Medium:** Designed around ScriptableObject configuration and UI event binding. While the pool system is programmatic, the primary workflow is declarative (attach effects to UI elements in Inspector). MCP can query configured effects and manage the pool, but creating new sound bindings requires ScriptableObject manipulation. Best used as a monitoring/inspection tool rather than active control.

---

### MCP-EVAL-011: Native Audio

| Field | Value |
|-------|-------|
| **Rating** | Medium |
| **API Pattern** | Static facade (`NativeAudio`, 16 methods) + `NativeSource` per-handle |
| **Parameter Types** | AudioClip, string paths, InitializationOptions/LoadOptions structs |
| **Runtime Access** | Full on supported platforms (iOS/Android only) |

**Key MCP-Controllable APIs:**
- `NativeAudio.Initialize(options)` -- one-time setup per platform
- `NativeAudio.Load(AudioClip/path, options)` -- load audio into native buffer
- `NativeSource.Play()` / `.Stop()` / `.SetVolume(float)` / `.SetPan(float)` -- playback control
- `NativeAudio.GetNativeSourceAuto()` -- auto-assign next available source
- `NativeAudio.GetDeviceAudioInformation()` -- device metadata query

**Why Medium:** Clean static API but severely platform-limited. Throws `NotSupportedException` on Windows/Mac/Editor, making it untestable during development. Only useful for mobile-targeted MCP workflows. Limited to 15 sources on iOS. No audio processing chain -- direct playback only. Good for low-latency mobile audio triggers when platform is available.

---

**End of Document**
