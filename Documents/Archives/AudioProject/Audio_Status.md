# AudioProject -- Status

**Project:** AudioProject (Audio Creation & Audio Asset Evaluation)
**Developer:** TecVooDoo LLC / Rune (Stephen Brandon)
**Unity Version:** 6000.x (Unity 6, URP)
**Project Path:** `E:\Unity\AudioProject`
**Last Updated:** March 11, 2026 (Session 11)

---

## Purpose

AudioProject serves two roles:

1. **Audio Creation** -- Build, test, and export audio systems, mixing setups, and soundscapes for use in other TecVooDoo projects (HOK, FearSteez, DLYH, etc.)
2. **Audio Asset Evaluation** -- Import, test, and evaluate audio-related assets from the Asset Store. Verdicts and findings recorded in `Audio_AssetLog.md`.

**Origin:** The adaptive audio concept originated in A Quokka Story (AQS) -- a "Peter and the Wolf" style system where different on-screen characters change instruments being played. The AQS project was lost to hardware failure; design docs survived at `E:\TecVooDoo\Projects\Games\2 Planning\A Quokka Story`. The vision expanded from single-instrument-per-entity to a general-purpose adaptive audio engine usable across all projects.

**Primary output:** Reusable audio configurations, tested prefabs/systems, and `Audio_AssetLog.md` evaluations.

**Related projects:**
- Sandbox (general asset eval): `E:\Unity\Sandbox\Documents\Sandbox_Status.md`
- HOK (active game): `E:\Unity\HookedOnKharon\Documents\HOK_Status.md`
- SyntyAssets (art asset eval + MCP eval): `E:\Unity\SyntyAssets\Documents\SyntyAssets_Status.md`
- A Quokka Story (original audio design docs): `E:\TecVooDoo\Projects\Games\2 Planning\A Quokka Story`

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

**Session 11 complete.** Fixed 4 runtime bugs in synthesis/composition showcase: KS squeal (simplified to classic algorithm), Modal inaudible (10x gain boost), Granular same-pitch (added PitchRatio to GranularConfig), Markov silence (missing Seed call). Previous session added thread-safe voice management, NaN protection, and debug diagnostics.

**Needs next:**
- Runtime test of all 4 fixes (user requested next session)
- Effects chain integration (AudioEffects.cs exists but not wired into mixer)
- InstrumentPreset ScriptableObjects
- Mixer/bus architecture (single OnAudioFilterRead summing all voices)
- Velocity curves and dynamics (velocity -> filter cutoff, envelope speed)
- Polyphonic voice management (voice stealing)
- Integration of new synthesis/composition engines with NativeProceduralBackend

### MCP Controllability Summary (Sessions 6 + 8)

| Package | MCP Rating | Key Finding |
|---------|-----------|-------------|
| **PATWA** | Exceptionally High | 22 tools in 6 tiers, singleton, synchronous API |
| **Master Audio 2024** | High | 258 static methods, string-based IDs, pure static |
| **Koreographer Professional** | High | Singleton, event registration, sample-accurate timing |
| **Procedural Music Generator** | High | 40+ properties, real-time key/scale/mode, rich events |
| **Maestro MIDI** | High | 16-channel control, real-time MIDI injection, GM instruments |
| **DryWetMIDI** | High | Fluent chain API, full MIDI manipulation, event callbacks |
| **Bro Audio** | High | 49 static methods, zero inspector dependencies for playback |
| **FMOD Studio** | High | 62+ static methods, dual high/low-level API, VCA routing |
| **Chunity (ChucK)** | High | 143 methods, real-time code execution, bidirectional variable binding |
| **UI Toolkit Sound Effects** | Medium | Pool-based, primarily ScriptableObject-driven, inspector-first |
| **Native Audio** | Medium | 16 static methods, iOS/Android only, not usable in Editor |

### Eval Queue (MCP evals remaining)

| Package | Version | Asset Eval | MCP Eval | Notes |
|---------|---------|-----------|----------|-------|
| Audio Preview Tool | -- | Done (Sandbox) | Low | Editor QoL -- less need for MCP control |

---

## Sessions

*(Sessions logged newest-first)*

### Session 11 (Mar 11, 2026) -- Synthesis Showcase Runtime Fixes

**Status:** Complete. 4 runtime bugs fixed across 3 files. Pending user test next session.

**Motivation:** Session 10's synthesis showcase had 4 runtime issues discovered during testing: KS producing harsh squeal instead of plucked string, Modal barely audible, Granular playing all notes at the same pitch, and Markov composition producing no sound.

**Bug Fixes (4):**
- **Karplus-Strong squeal:** Root cause was the allpass fractional delay, pick position comb filter, and stiffness allpass creating unstable feedback. Fix: Stripped back to classic KS algorithm (circular delay line + two-point averaging lowpass + damping). Removed allpass interpolation, pick position comb, and stiffness allpass entirely. Signal path is now: `delayLine[read] -> averaging lowpass -> damping -> output/feedback`.
- **Modal barely audible:** Root cause was bandpass resonators producing inherently low-amplitude output from noise burst excitation, with volume at only `master * 2.0` (~1.4). Fix: Increased volume multiplier to `master * 10.0` (~7.0). The mixer's soft clip prevents distortion.
- **Granular same pitch for all notes:** Root cause was `PlayGranularVoice()` not receiving the note's frequency -- all grains played from the 220Hz source buffer at unity pitch ratio. Fix: Added `PitchRatio` field to `GranularConfig`, updated `GranularSynthesizer.Trigger()` to use it as base pitch, and `PlayGranularVoice()` now computes `frequency / 220` as the pitch ratio.
- **Markov composition no sound:** Root cause was `MarkovComposer.Seed()` never being called after `TrainFromScale()`, leaving `_seeded = false` so `GenerateNote()` always returned -1. Fix: Added `Seed(root, root+4)` call after training in `SetupCompositionEngines()`.

**Previous session fixes also in this codebase (Session 10 continuation):**
- Thread-safe voice management: `_pendingClearAll` flag for audio-thread-safe `StopAll()`
- NaN/Inf protection in ExtendedSynthMixer with per-sample detection and voice killing
- Voice clearing on synth type switch to prevent zombie voices
- Max voice lifetime (5 seconds) to prevent stuck voices
- Debug dump keys (N = no sound, M = squeal) with full state capture

**Modified Files (3):**
- `Core/Synthesis/KarplusStrongOscillator.cs` -- Simplified to classic KS (removed allpass, pick comb, stiffness)
- `Core/Synthesis/GranularSynthesizer.cs` -- Added `PitchRatio` field to `GranularConfig`, used in `Trigger()`
- `Examples/07_SynthShowcase/SynthShowcaseScene.cs` -- Modal volume 2x->10x, Granular frequency pass-through + pitch ratio, Markov seed after training, updated display strings

---

### Session 10 (Mar 11, 2026) -- Procedural Synthesis & Composition Engines

**Status:** Complete. 8 new files, zero compile errors. ~84 total files across all assemblies.

**Motivation:** Expanding PATWA's procedural capabilities beyond basic waveform synthesis (Session 7-9) with professional-grade synthesis models and algorithmic composition techniques. These engines provide the building blocks for adaptive music generation without external dependencies.

**New Synthesis Files (5 in Core/Synthesis/):**
- `KarplusStrongOscillator.cs` (390 lines) -- Physical string model with allpass interpolation, pick position filtering, stiffness correction, 3 excitation types (noise burst, shaped impulse, bowed continuous)
- `FMSynthEngine.cs` (459 lines) -- 4-operator FM/PM synthesis with DX7-style algorithms (8 topologies), per-operator ADSR envelopes, 5 factory presets (ElectricPiano, Bass, Organ, Bell, Brass)
- `ModalSynthesizer.cs` (499 lines) -- Parallel biquad resonator bank for impact/percussion sounds, 6 material presets (Metal, Wood, Glass, Bell, Drum, Stone)
- `WavetableSynthesizer.cs` (508 lines) -- Morphable wavetable oscillator with harmonic sweep generation and formant vowel factory tables
- `GranularSynthesizer.cs` (766 lines) -- 64-grain pool with 4 window types (Hann, Gaussian, Trapezoid, Blackman-Harris), stereo pan, pitch/position jitter, 4 presets (TextureStretch, CloudPad, StutterEffect, FreezeSustain)

**New Composition Files (3 in Core/MusicTheory/):**
- `MarkovComposer.cs` (615 lines) -- 2nd-order pitch + 1st-order duration/velocity Markov chains, auto-trains from scale degrees, generates melodies with learned statistical patterns
- `GrammarStructureGenerator.cs` (554 lines) -- L-system phrase generation with stack-based interpreter, song form templates (Pop AABA, Blues 12-bar, Sonata exposition-development-recapitulation)
- `ConstraintComposer.cs` (1,073 lines) -- 11 musical constraints (voice leading, range, chord tone, step motion, rhythm density, etc.) with weighted scoring, temperature-based selection, 4 style presets (Classical, Jazz, Ambient, GameplayReactive)

**Totals:** 4,864 lines of new procedural audio code. All pure C# with zero allocations in audio paths, no `var`, thread-safe. 8 new files, ~84 total across all assemblies.

---

### Session 9 (Mar 11, 2026) -- Runtime Test of Procedural Generation Pipeline

**Status:** Complete. End-to-end procedural generation pipeline verified working at runtime. 4 modified files.

**Motivation:** Sessions 7-8 built the MusicTheory and Synthesis engines but had not been runtime-tested. This session created a test scene and debugged the full pipeline from keyboard input through procedural note generation to audible waveform output.

**Bugs Fixed (5):**
- **Silent audio:** `AudioSource.Play()` without a clip does not trigger `OnAudioFilterRead` -- added 1-second silent clip + loop to `NativeProceduralBackend`
- **Voice pool exhaustion:** `ActiveSynthVoice.EnvelopePhase` was never updated from `SynthVoiceDriver` state -- now reads `Driver.IsActive`/`CurrentPhase` directly
- **Note-off scheduling:** Voices were never releasing -- added `Release()` trigger after duration expires, properly entering release phase
- **Clicking on stop:** Redundant `source.Stop()` in Update caused audio pops -- removed (pool's Recycle handles it), added `Array.Clear` for inactive buffer zeroing
- **Input System:** Examples asmdef was missing Unity.InputSystem reference

**Tuning:**
- Added 3x GainBoost with soft-clipping (`tanh`) in `SynthVoiceDriver` for audible volume
- Bumped all volume defaults to 1.0/0.8/0.9 in `ProceduralTestScene`

**New Scene:**
- `Examples/06_ProceduralTest/ProceduralTestScene.cs` -- keyboard-driven procedural music test (key change, scale change, BPM, layer toggles, play/stop)

**Modified Files (4):**
- `BuiltIn/NativeProceduralBackend.cs` -- Silent clip generation, voice recycling fix, note-off scheduling, click prevention
- `BuiltIn/SynthVoiceDriver.cs` -- GainBoost with soft-clipping, buffer zeroing on inactive
- `Examples/06_ProceduralTest/ProceduralTestScene.cs` -- Volume defaults bumped
- `Examples/TecVooDoo.PATWA.Examples.asmdef` -- Added Unity.InputSystem reference

**Total:** ~76 files across all assemblies (0 new, 4 modified)

---

### Session 8 (Mar 11, 2026) -- Maestro Synthesis Extraction + MCP Eval Completion

**Status:** Code complete. Pending user compilation verification. 6 new files, 2 modified files.

**Motivation:** Completing the deprecation-proofing effort started in Session 7. Maestro MIDI (FluidSynth C# port) contains ~3,500 lines of pure C# synthesis algorithms that are at risk if the asset is discontinued. Extracted the key DSP, envelope, modulation, and MIDI structures into PATWA's own Synthesis engine. Also completed all remaining MCP controllability evaluations.

**New Files (6 in Core/Synthesis/):**
- `Core/Synthesis/SynthConversion.cs` -- Pitch/amplitude/timing conversion with lookup tables: centitone-to-Hz (1200-entry table + bit shift), centibel-to-amplitude (1441-entry), velocity curves (concave/convex), pan law (sine), timecent-to-seconds, MIDI-to-Hz
- `Core/Synthesis/SynthEnvelope.cs` -- 7-stage ADSR (Delay/Attack/Hold/Decay/Sustain/Release/Finished). SoundFont 2.01 timecent-based timing, key-dependent hold/decay, per-sample processing. Replaces simple 4-stage envelope.
- `Core/Synthesis/SynthLFO.cs` -- Low Frequency Oscillator for vibrato/tremolo/filter modulation. Sine/Triangle/Sawtooth/Square waveforms, configurable delay, frequency, and modulation depth per destination.
- `Core/Synthesis/SynthFilter.cs` -- IIR biquad resonant filter (Direct-II form). Lowpass/Highpass/Bandpass. Smooth coefficient interpolation for glitch-free parameter changes. History compensation for large frequency sweeps.
- `Core/Synthesis/SynthInterpolation.cs` -- Sample interpolation for wavetable playback: None/Linear/Cubic/7th-order Hamming-windowed sinc. 64-bit fixed-point phase tracking. Pre-computed coefficient tables.
- `Core/Synthesis/MidiEventData.cs` -- Lightweight MIDI event value types (NoteOn/NoteOff/CC/PitchBend/ProgramChange), MidiChannelState for modulation, MidiTiming utilities (tick/time/beat conversion, VarInt encoding).

**Additional File:**
- `Core/Synthesis/SynthModulation.cs` -- SoundFont 2.01 modulation engine: 64 modulators per voice, 16 transform cases (positive/negative x unipolar/bipolar x linear/concave/convex/switch), maps MIDI CC/velocity/key/pressure to synthesis generators.

**Modified Files (2):**
- `BuiltIn/SynthVoiceDriver.cs` -- Upgraded from 4-stage to 7-stage ADSR via SynthEnvelope. Added optional LFO vibrato/tremolo and IIR filter. New `ConfigureExtended()` API alongside backward-compatible `Configure()`.
- `BuiltIn/NativeProceduralBackend.cs` -- Added SynthConversion/SynthInterpolation initialization on startup. Switched `MidiNoteToFrequency` to use `SynthConversion.MidiNoteToHz`.

**MCP Evaluations (6 completed):**
- DryWetMIDI: **High** -- fluent chain API, full MIDI manipulation
- Bro Audio: **High** -- 49 static methods, cleanest audio API
- FMOD Studio: **High** -- 62+ static methods, enterprise dual API
- Chunity: **High** -- 143 methods, real-time ChucK code execution
- UI Toolkit Sound Effects: **Medium** -- pool-based, inspector-first
- Native Audio: **Medium** -- iOS/Android only, not usable in Editor

**Architecture:** Maestro is now an optional accelerator like PMG. PATWA Synthesis engine provides:
- SoundFont-grade pitch/amplitude conversion (same tables as FluidSynth)
- Professional-quality envelopes (7-stage vs PMG's basic 4-stage)
- Sample interpolation up to 7th-order sinc (for future wavetable support)
- Full modulation routing (SoundFont 2.01 compliant transforms)
- IIR biquad filter for timbral shaping

**Total:** ~76 files across all assemblies (6 new Synthesis + 70 existing)

---

### Session 7 (Mar 11, 2026) -- MusicTheory Engine Extraction (PMG/Maestro Future-Proofing)

**Status:** Code complete. Pending user compilation verification. 8 new files, 2 modified files.

**Motivation:** PMG (last updated for older Unity, no asmdef, God Object architecture) and Maestro (FluidSynth C# port, no interfaces, Pro-gated features) are both aging codebases at risk of deprecation. Extracted core music theory algorithms into PATWA's own engine so the system can generate music independently.

**New Files (8):**
- `Core/MusicTheory/ScaleDatabase.cs` -- Scale intervals (Major, NaturalMinor, MelodicMinor, HarmonicMinor, HarmonicMajor), chord tone arrays, pentatonic avoid notes, constants
- `Core/MusicTheory/ScaleUtility.cs` -- Scale-degree-to-semitone conversion, chord offset math, MIDI note calculation, key transposition, avoid-note detection
- `Core/MusicTheory/ChordProgressionGenerator.cs` -- T/SD/D functional harmony weighting, tritone substitution, key-change-aware chord avoidance
- `Core/MusicTheory/NoteGenerationConfig.cs` -- Serializable config for melody/rhythm/lead generation parameters
- `Core/MusicTheory/NoteGenerator.cs` -- Melody (chord tone selection), Rhythm (arpeggio/strum/chord), Lead (contour walk with avoid notes)
- `Core/MusicTheory/LeitmotifEngine.cs` -- Leitmotif triggering, scheduling, scale-aware transposition, variation
- `Core/MusicTheory/ProceduralVoice.cs` -- Single voice combining progression + note gen + leitmotif
- `Core/MusicTheory/ProceduralOrchestrator.cs` -- Multi-voice orchestration with group dynamics (random/linear crescendo)
- `BuiltIn/NativeProceduralBackend.cs` -- IProceduralBackend using MusicTheory + waveform synthesis (sin/square/triangle/saw + ADSR)
- `BuiltIn/SynthVoiceDriver.cs` -- OnAudioFilterRead waveform generation with ADSR envelope

**Modified Files (2):**
- `Core/Data/Enums.cs` -- Expanded MusicalScale (added NaturalMinor, MelodicMinor, HarmonicMinor, HarmonicMajor), added MusicalMode, ChordFamily, NoteGenerationType, ArpeggioStyle, DynamicStyle enums
- `Adapters/PMG/PMGProceduralBackend.cs` -- Updated MapMusicalScale for expanded enum

**Architecture:** PMG and Maestro are now optional accelerators. PATWA can generate procedural music independently:
- `ProceduralOrchestrator` manages voices with group dynamics (PMG's 4-group system, lifted)
- `NoteGenerator` handles melody/rhythm/lead contour (PMG's NoteGenerator hierarchy, reimplemented)
- `ChordProgressionGenerator` provides T/SD/D harmony (PMG's ChordProgressions.cs, reimplemented)
- `LeitmotifEngine` handles "Peter and the Wolf" motif triggering (PMG's Leitmotif system, reimplemented)
- `NativeProceduralBackend` + `SynthVoiceDriver` provide basic waveform synthesis (PMG's SynthHandler, simplified)

**Total:** ~70 files across all assemblies

---

### Session 6 (Mar 11, 2026) -- MCP Controllability Evaluations

**Status:** Complete. 5 audio assets evaluated for MCP controllability. All rated HIGH or above.

**Work:**
- Evaluated MCP controllability for 5 core PATWA-stack assets: PATWA itself, Master Audio, Koreographer, PMG, Maestro
- PATWA rated "Exceptionally High" -- 22 MCP tools across 6 tiers (context, contributor, mix, beat, reactive, debug)
- Master Audio: 258 static methods, pure static API, zero instance discovery needed
- Koreographer: singleton, sample-accurate timing queries, string-based event registration
- PMG: 40+ settable properties, real-time key/scale/mode/tempo, group odds for entity control
- Maestro: per-channel MIDI control, real-time note injection, General MIDI instrument mapping
- Updated Audio_AssetLog.md with 5 detailed MCP evaluation entries (MCP-EVAL-001 through 005)
- Updated MCP Controllability summary table and remaining eval queue

**Key Finding:** The entire PATWA adaptive audio stack is highly MCP-controllable. An AI agent could orchestrate the full pipeline: switch contexts (PATWA), adjust mix (Master Audio), sync to beats (Koreographer), control procedural generation (PMG), and inject MIDI notes (Maestro) -- all through simple string/number parameters on singletons and static APIs.

---

### Session 5 (Mar 11, 2026) -- PATWA Phase 5: Polish + Asset Store Prep

**Status:** Complete (pending user compilation verification). 7 new/modified files, compiled clean. All 5 phases code-complete -- MVP milestone.

**Work:**

**New Files (5):**
- LeitmotifData.cs -- ScriptableObject for melodic phrases: MotifNote sequence (MIDI note, start beat, duration, velocity), transposition, tempo adjust, variation parameters, fallback clip
- ReactiveVisualizer.cs (Example 04) -- Spawns frequency-band-reactive cubes with color lerp, debug GUI
- ReactiveLightController.cs (Example 04) -- Audio-reactive light: intensity/color/range driven by band energy
- AdaptiveMusicDemo.cs (Example 05) -- Full integration: context switching (1-4), enemy spawning (Space/X), reactive toggle (R), WASD movement, debug HUD
- package.json -- UPM package structure for com.tecvoodoo.patwa v0.1.0

**Modified Files (2):**
- MusicContext.cs -- Added `#if ODIN_INSPECTOR` conditional attributes (BoxGroup, TabGroup, EnumToggleButtons, etc.)
- MusicContributorProfile.cs -- Added `#if ODIN_INSPECTOR` conditional attributes (TabGroup, ProgressBar, ShowIf, ToggleLeft, etc.)

**Total:** ~60 files across all assemblies

---

### Session 4 (Mar 11, 2026) -- PATWA Phase 4: Reactive + Procedural

**Status:** Complete. All Phase 4 files compiled clean. 8 new files, ~53 total.

**Work:**

**Reactive Module (4 files in Core/Reactive/):**
- SpectrumAnalyzer.cs -- FFT wrapper, AudioListener or AudioSource source, asymmetric rise/fall smoothing, bin-to-frequency helpers
- FrequencyBandSampler.cs -- Standard 8-band preset (Sub-Bass through Air) or custom bands, auto-normalization with ceiling decay
- ReactiveBinding.cs -- ScriptableObject config: source band to target type (material/transform/light/stem/custom), value mapping (direct/curve/threshold/on-off)
- ReactiveDriver.cs -- Reads bands, evaluates bindings, applies to targets via MaterialPropertyBlock/Transform/Light/MixState

**Procedural Adapters (2 files + 2 asmdefs):**
- PMGProceduralBackend.cs -- IProceduralBackend for Procedural Music Generator, maps layers to PMG instruments, key/scale/BPM/intensity control (`#if PATWA_PMG`)
- MaestroMIDIBackend.cs -- IProceduralBackend for Maestro MPTK, MIDI channel allocation (16-channel with GM drum skip), General MIDI instrument mapping, note send/stop, CC controls (`#if PATWA_MAESTRO`)
- TecVooDoo.PATWA.PMG.asmdef -- defineConstraints gated
- TecVooDoo.PATWA.Maestro.asmdef -- defineConstraints gated

**Updated:**
- ScriptingDefineDetector.cs -- Added PMG and Maestro detection entries, cleaned up self-detection logic

**Assembly Definitions:** TecVooDoo.PATWA.Core, TecVooDoo.PATWA.BuiltIn, TecVooDoo.PATWA.Editor, TecVooDoo.PATWA.Examples, TecVooDoo.PATWA.MasterAudio, TecVooDoo.PATWA.Koreographer, TecVooDoo.PATWA.PMG, TecVooDoo.PATWA.Maestro
**Total:** ~53 files across all assemblies

---

### Session 3 (Mar 11, 2026) -- PATWA Phase 1 + Phase 2 + Phase 3 Implementation

**Status:** Complete. All three phases compiled clean. ~30 files across Core, BuiltIn, Editor, Adapters, Examples.

**Work:**
- Removed NPC AI Engine Convai 3.3.4 from project (user decision -- requires API subscription, not relevant to PATWA)
- MCP server updated to v0.51.6 (required computer restart to connect)

**Phase 1 (compiled clean -- 21 files):**
- Core interfaces: IMusicContributor, IAudioBackend, IProceduralBackend, IBeatSyncProvider, IConflictResolver
- Enums/Structs: 15 enums + 5 structs (ContributorState, ConflictAction, TransitionOptions, StemSettings, etc.)
- Data SOs: MusicContext, MusicContributorProfile, StemSlot, StemMapping, MusicBehavior
- Director: MusicDirector, ContributorTracker, TransitionEngine, MixState
- Timing: BeatClock (dsp-accurate, external sync)
- Conflict: PriorityResolver
- Built-In: AudioSourceBackend, AudioSourcePool
- Bridge: MusicContributorBridge (zero-code path)

**Phase 2 (compiled clean -- 13 files):**
- BehaviorExecutor: trigger->action processing, intensity threshold crossing detection, beat/bar triggers, delayed/quantized action scheduling
- LayeredResolver: both contributors play, incoming at configurable accent volume
- QueueResolver: FIFO queue, next in queue takes over when current unregisters
- QuantizeMode in TransitionEngine: scheduled transitions with beat-quantized fades (NextBeat, NextBar, NextPhrase)
- MusicDirectorEditor: live runtime inspector with beat clock visualization, contributor intensity bars, stem volume meters, pause/mute/volume controls
- MusicContextEditor: header summary, stem validation (duplicates, missing clips/tags), stem preview with play button, auto-name/sort actions
- ContributorDebuggerWindow (Window > PATWA > Contributor Debugger): 3-tab view (Contributors, Stems, Conflicts), search/filter, color-coded state indicators
- Example 02 scripts: EnemySpawner (spawn/despawn timer), EnemyMusicBridge (health->intensity, damage->weaken, death->silence)
- Example 03 scripts: PlayerEnergyContributor (energy->intensity, drain/regen/burst, threshold state changes, debug UI)

**Phase 3 (compiled clean -- 11 files):**

*Audio Browser (6 files):*
- AudioFileEntry.cs -- data model for discovered audio files
- AudioMetadataCache.cs -- JSON-based cache with SQLite-ready interface, query filtering
- ArchiveReader.cs -- zip archive reading via System.IO.Compression
- AudioScanner.cs -- folder walking, file/archive discovery
- AudioAnalyzer.cs -- BPM detection via onset detection algorithm
- AudioBrowserWindow.cs -- full editor window with Browse/Source Folders tabs, preview, import

*Adapters (4 files):*
- MasterAudioBackend.cs -- IAudioBackend implementation for Dark Tonic Master Audio (`#if PATWA_MASTER_AUDIO`)
- KoreographerBeatSyncProvider.cs -- IBeatSyncProvider for Sonic Bloom Koreographer (`#if PATWA_KOREOGRAPHER`)
- TecVooDoo.PATWA.MasterAudio.asmdef -- defineConstraints gated
- TecVooDoo.PATWA.Koreographer.asmdef -- defineConstraints gated

*Auto-Detection (1 file):*
- ScriptingDefineDetector.cs -- detects middleware by asmdef name via CompilationPipeline, auto-sets/removes scripting defines

**Bug fix:** Initial ScriptingDefineDetector used namespace scanning which false-positived on installed-but-unused packages. Fixed to use asmdef name detection via CompilationPipeline. Had to manually remove false `PATWA_MASTER_AUDIO` and `PATWA_KOREOGRAPHER` defines from ProjectSettings.

**Assembly Definitions:** TecVooDoo.PATWA.Core, TecVooDoo.PATWA.BuiltIn, TecVooDoo.PATWA.Editor, TecVooDoo.PATWA.Examples, TecVooDoo.PATWA.MasterAudio, TecVooDoo.PATWA.Koreographer
**Total:** ~30 files across all assemblies

---

### Session 2 (Mar 11, 2026) -- Audio Asset Evaluations + PATWA Design Spec

**Status:** Complete. All 8 evals done, PATWA design spec written, all open questions resolved.

**Work:**
- Evaluated 8 audio packages: Bro Audio, Procedural Music Generator, Maestro MIDI, Kalend Music, Localized Audio, VoiceGPT, Photon Voice 2, Timeflow (audio re-eval)
- **Procedural Music Generator** identified as highest-relevance asset for AQS adaptive audio vision -- leitmotif system IS "Peter and the Wolf," group-based instrument toggling, music theory engine
- **Maestro MIDI** fills critical gap as MIDI-to-audio SoundFont synth, complements DryWetMIDI
- **Bro Audio** provides clean programmer-friendly playback API, complementary to Master Audio
- **Timeflow** audio re-eval confirmed: audio-reactive pipeline (Spectrum->Sample->Reactive) and MIDI components useful for visualization, not as audio system
- Rejected 4 packages for removal: Kalend Music (static singleton, bugs), Localized Audio (327-line wrapper), VoiceGPT (editor-only, 872MB), Photon Voice 2 (networking, 337MB)
- Documented 15 cherry-pick candidates across approved packages
- Updated Audio_AssetLog.md with all 8 entries, ecosystem maps, cherry-pick table
- Updated Sandbox_AssetLog.md with 7 new entries
- Added coding standard: "Favor interfaces and generics when possible" to Audio_Status.md and HOK_DevReference.md
- Removed 4 rejected packages from project (Kalend, Localized Audio, VoiceGPT, Photon Voice 2)
- Named the adaptive audio system: **PATWA** (Peter and the Wolf Adaptive)
- Created `Assets/_AudioProject/_PATWA/` folder structure with Scenes moved under it
- Reviewed all AQS design docs (GDD v1, v3, Architecture, Design Decisions, Audio Progress Summary, plus archives)
- Extracted PATWA requirements from AQS audio system design (see below)

**AQS Doc Review -- PATWA Requirements Extracted:**

The AQS audio system had two iterations:
1. **LightSynth (abandoned)** -- `InstrumentRecipe` SO + `LightSynth` class generating clips at runtime. CPU-intensive on i5-8300H hardware. This was the original "procedural" vision.
2. **Stem-based (final)** -- Pre-recorded loops from Nine Volt Audio (30K loops by key/tempo), managed by Master Audio 2024. Simpler, professional quality.

**Key insight:** AQS abandoned procedural audio for pragmatic hardware reasons, not design reasons. PATWA can pursue BOTH approaches -- PMG for procedural generation AND Master Audio for pre-recorded stems.

**Core Architecture from AQS:**
- `IMusicEntity` interface -- any entity (Joey, enemy, NPC) implements this to contribute audio layers
- `MusicManager` service -- `RegisterEntity`/`UnregisterEntity`/`SetEntityVolume`/`TransitionToBiome`
- `BiomeMusicData` SO -- defines stem assignments per context (key, tempo, instrument map)
- Event-driven: `OnJoeyLaunched`/`OnJoeyRecalled`/`OnEnergyChanged`/`OnEnemySpawned`/`OnEnemyDefeated` → MusicManager
- Audio Mixer Groups: separate groups for Joey layers, enemy layers, energy-based drums

**Volume Rules (AQS-specific, generalizable):**
- Mom: always 100% | Joeys in pouch: volume = energy level (0-100%) | Launched: 150% accent | Depleted: 10-20% | Enemies: 60-80%
- Energy-to-volume binding discourages button mashing (spam = quieter music)

**Biome Contexts (AQS-specific):**
- Swamp: E minor, 105 BPM (9 stems) | Suburb: C major, 115 BPM (6 stems) | City: D minor, 125 BPM (6 stems) | Airstrip: E minor, 140 BPM (5 stems)
- Each biome: all stems at same key/tempo for perfect sync

**Special Systems:**
- Instrument conflict resolution -- priority system when entities share instruments (Ninja Joey vs Gator banjo)
- Energy system drives music volume -- creates natural gameplay rhythm
- Max 12 simultaneous stems (original performance target)
- Boss fight music: open question (all instruments chaotic vs structured phases)

**PATWA Generalization Beyond AQS:**
- Any entity type can implement `IMusicEntity` (not just Joeys/enemies)
- Multi-instrument per entity (boss = 3 layers evolving with phase)
- Dual-mode: procedural (PMG) AND pre-recorded stems (Master Audio) per layer
- MIDI-driven layers via Maestro/DryWetMIDI for real-time synthesis
- Style matching/generation from reference tracks (future goal)
- Configurable stem limits per platform

**Key Findings:**
- Adaptive audio stack: **PMG** (procedural generation + leitmotif) + **Master Audio** (mixing/routing) + **Koreographer** (beat sync) + **DryWetMIDI/Maestro** (MIDI data/synthesis)
- PMG's 4-group limit and 20-instrument max will need extension for multi-entity adaptive system
- Maestro Pro version likely needed for `OnMidiEvent` interception (free version gates this)
- No existing asset provides the full adaptive audio controller -- must be custom-built on top of these primitives
- AQS had `InstrumentRecipe` SO pattern for procedural audio -- can be revived alongside PMG's config system

**PATWA Design Spec Written:**
- Created `PATWA_DesignSpec.md` (v0.1) -- full architecture, interfaces, data model, folder structure, cherry-pick sources, 5-phase implementation plan
- Reframed PATWA as Asset Store product: zero hard dependencies, backend abstraction layer, content-agnostic
- Core architecture: MusicDirector (orchestrator) + IMusicContributor (entity interface) + IAudioBackend (playback abstraction) + MusicContext SO (stem config) + MusicContributorProfile SO (per-entity config)
- Cherry-picked patterns from: Asset Inventory 4 (archive scanning for Audio Browser), Bro Audio (decorator/fluent/dominator/pool), Master Audio (bus/crossfade/voice limits), PMG (leitmotif data), DOTween (parameter automation), Feel (modular behavior stacking), Timeflow (audio-reactive chain + MIDI), Koreographer (beat sync)
- Audio Browser editor window designed: scan folders/zips, preview, BPM/key detection, SQLite metadata cache
- Audio-Reactive module: Spectrum -> FrequencyBandSampler -> ReactiveDriver (from Timeflow pattern)
- All 9 open questions resolved: Both (singleton+service locator), SQLite for browser/SO for runtime, Reactive in core, UniTask optional, BPM both, Odin optional, stems configurable per context, main thread MVP/Jobs for browser, name deferred

---

### Session 1 (Mar 10-11, 2026) -- Package Installation & Project Bootstrap

**Status:** All packages installed. Docs updated. MCP connected.

**Work:**
- Configured MCP (port 50774, stdio transport). Both `.vscode/mcp.json` and `.claude/mcp.json` written. MCP connection verified (75/75 tools).
- Built BatchImporter.cs editor script for phased .unitypackage imports from Asset Store cache (`E:\Unity\01UnityAssetSystem\Unity\Asset Store-5.x\`).
- Phase 1: Odin Inspector + Validator (dependency for other assets).
- Phase 2: Asset Inventory 4 (needs to index everything that follows).
- Phase 3: All remaining packages (15 .unitypackage files). Forced shutdown mid-import corrupted Library; deleted Library folder and rebuilt.
- Additional audio packages loaded beyond original QoL+Audio plan: Bro Audio, Chunity, DryWetMIDI, FMOD, Kalend Music, Localized Audio, Maestro, Native Audio, Procedural Music Generator, UI Toolkit Sound Effects, plus VoiceGPT, Photon Voice 2, Convai.
- Cross-referenced all audio packages against Sandbox AssetLog (272 entries) and SyntyAssets AssetLog. Found 10 with existing Sandbox evals, 7 with no eval anywhere.
- Identified AQS audio design docs at `E:\TecVooDoo\Projects\Games\2 Planning\A Quokka Story` for adaptive audio system design recovery.
- Investigated Demigiant DemiLib (DeAudioManager) -- alpha status, Unity 2018+ last tested, not worth importing when Master Audio is already installed.

**Key Findings:**
- Asset Store cache at `E:\Unity\01UnityAssetSystem\Unity\Asset Store-5.x\` has 761 publisher folders -- reliable source for batch imports.
- Forced shutdown during import corrupts Unity Library but not Assets -- delete Library and reopen to recover.
- Sandbox evaluations carry forward: packages already labeled Default/Recommended there don't need re-eval here unless audio-specific capabilities need testing.

### Session 0 (Mar 10, 2026) -- Project Setup

**Status:** Document system created. Fresh Unity 6 project.

**Work:**
- Created document system: Audio_Status.md, Audio_AssetLog.md, Archives/
- Project structure established for hybrid audio creation + asset eval workflow

---

## Audio Creation Tracker

*(Track audio systems/configurations being built for export to other projects)*

| Item | Target Project | Status | Notes |
|------|---------------|--------|-------|
| PATWA (Peter and the Wolf Adaptive) | All (originated from AQS) | Phase 5 Complete (MVP) + MusicTheory + Synthesis + Composition (~84 files) | Entity-driven adaptive audio orchestration layer. All 5 phases + MusicTheory + Synthesis + Composition engines. Procedural pipeline runtime-tested. 5 synthesis models (Karplus-Strong, FM, Modal, Wavetable, Granular) + 3 composition engines (Markov, L-system, Constraint). |

---

## Asset Eval Summary

**Evaluated:** 8 | **Approved:** 0 | **Conditional:** 4 | **Rejected:** 4 | **Deferred:** 1

See `Audio_AssetLog.md` for full evaluations.

---

## Integration Patterns

*(Audio-specific patterns discovered during evaluation and creation work)*

| Pattern | Notes | Source |
|---------|-------|--------|
| CustomPlayFunc hook | UI Toolkit Sound Effects has a hook specifically for Master Audio integration | Sandbox ENTRY-125 |
| Dominator pattern | Auto-resetting ducking/filtering -- one sound suppresses all others with `ForSeconds`/`Until`/`While` | Bro Audio #001 |
| PlaybackGroup rules | Extensible rule-based validation before playback (CombFilteringRule, MaxPlayableCount) | Bro Audio #001 |
| Fluent API chaining | `Play(id).AsBGM().SetTransition().SetVolume()` -- clean builder pattern for audio commands | Bro Audio #001 |
| Leitmotif system | Per-instrument preset melodic motifs triggered by group activation -- "Peter and the Wolf" | PMG #002 |
| Group-based instrument toggling | 4 groups with dynamic on/off, ManualGroupOdds for game-code control | PMG #002 |
| GeneratorMod extensibility | Abstract mod base class for adding custom behavior to procedural generation | PMG #002 |
| Per-channel MIDI control | Enable/mute, volume, forced preset/bank override per MIDI channel | Maestro #003 |
| Audio-reactive chain | Spectrum -> Sample -> Reactive pipeline for driving properties from audio | Timeflow #008 |

---

## Lessons Learned

| # | Lesson |
|---|--------|
| 1 | Forced shutdown during batch .unitypackage import corrupts Library/ but Assets/ survives. Delete Library/ to recover. |
| 2 | PMG's ConfigurationData.cs is a 2578-line God Object -- work around it, don't try to refactor (too intertwined with serialization). |
| 3 | Maestro Free gates `OnMidiEvent` behind `#if MPTK_PRO` -- Pro version likely needed for adaptive audio event interception. |
| 4 | 16-channel MIDI limit means multi-entity adaptive system needs multiple MidiStreamPlayer instances or a channel management layer. |
| 5 | Namespace scanning for middleware auto-detection false-positives on installed-but-unused packages. Use asmdef name detection via CompilationPipeline instead -- only fires when the assembly actually compiles. |
| 6 | `AudioSource.Play()` without a clip assigned does NOT trigger `OnAudioFilterRead`. Must assign a silent clip + enable loop for procedural audio generation via filter callbacks. |
| 7 | Voice pool state tracking must read from the actual driver, not cached copies. `ActiveSynthVoice.EnvelopePhase` drifted from `SynthVoiceDriver` state, causing pool exhaustion. |

---

## Installed Packages

### Audio (Asset Store)
| Package | Version | Sandbox Entry | Sandbox Verdict | Notes |
|---------|---------|--------------|-----------------|-------|
| Master Audio 2024: AAA Sound | 1.0.3 | #103 | Approved / Default | Core audio system |
| Koreographer Professional Edition | 1.6.3 | #101 | Approved / Recommended | BPM sync, beat-reactive |
| Audio Preview Tool | 1.1.0 | #102 | Approved / Default | Editor QoL |
| DryWetMIDI | 8.0.3 | #115 | Approved / Recommended | MIDI data/device library |
| Native Audio | 7.0.0 | #105 | Conditional | Low-latency audio |
| Chunity: ChucK For Unity | 2.2.1 | #112 | Conditional | Procedural synthesis (Stanford CCRMA) |
| FMOD for Unity | 2.03.11 | #113 | Conditional | Audio middleware |
| UI Toolkit Sound Effects & Audio Events | 1.0.1 | #125 | Approved / Default UI | Kamgam; CustomPlayFunc for Master Audio |
| Bro Audio | 2.2.2 | #001 | Conditional / Default Audio | Clean API, Dominator pattern, complements Master Audio |
| Procedural Music Generator | 2.0.0 | #002 | Conditional / Recommended | Leitmotif, group system, music theory -- highest AQS relevance |
| Maestro - Midi Player Tool Kit | 2.18.0 | #003 | Conditional / Default Audio | SoundFont synth, per-channel control, complements DryWetMIDI |
| ~~Kalend Music~~ | ~~1.0~~ | ~~#004~~ | ~~Rejected / Don't Use~~ | **REMOVE** -- static singleton, bugs |
| ~~Localized Audio~~ | ~~1.0~~ | ~~#005~~ | ~~Rejected / Don't Use~~ | **REMOVE** -- 327-line wrapper |
| ~~VoiceGPT~~ | ~~2.0~~ | ~~#006~~ | ~~Rejected / Don't Use~~ | **REMOVE** -- editor-only, 872MB |
| ~~Photon Voice 2~~ | ~~2.63~~ | ~~#007~~ | ~~Rejected / Don't Use~~ | **REMOVE** -- networking, 337MB |
| Convai / NPC AI Engine | 3.3.4 | #263 (Sandbox) | Deferred | Requires API subscription |

### QoL / Editor (Asset Store)
| Package | Version | Sandbox Entry | Notes |
|---------|---------|--------------|-------|
| Odin Inspector and Serializer | 4.0.1.4 | -- | Default |
| Odin Validator | 4.0.1.4 | -- | Default |
| Asset Inventory 4 | 4.0.1 | -- | Default |
| vHierarchy 2 | 2.1.8 | -- | Default |
| vFolders 2 | 2.1.14 | -- | Default |
| vFavorites 2 | 2.0.14 | -- | Default |
| Fullscreen Editor | 2.2.10 | -- | Default |
| UDebug Panel | 1.3.3 | -- | Default |
| Ultimate Preview Window Pro | 1.3.2 | -- | Default |
| Ninja Profiler | 2.0.0 | -- | Default |
| Wingman | 1.2.3 | -- | Default |
| Scriptable Sheets | 1.8.0 | -- | Default |
| F Texture Tools | -- | -- | Default |
| Curve Master | 1.2.2 | -- | Default |
| Markdown for Unity | 1.0.0 | -- | Default |

### Other (Asset Store)
| Package | Version | Sandbox Entry | Notes |
|---------|---------|--------------|-------|
| ALINE | 1.7.9 | #227 | Default |
| DOTween Pro | 1.0.410 | #111 | Default |
| Easy Save 3 | 3.5.25 | #236 | Default |
| Flexalon Pro | 4.4.0 | #226 | Recommended |
| Retarget Pro | 4.2.1 | #243 | Recommended |
| Text Animator for Unity | 3.5.0 | #117 | Default |
| Timeflow Animation System | 1.10.1 | #100 | Conditional (needs audio re-eval) |
| Toolkit for UX 2026 | 5.0.0 | #131 | Default UI |
| UI Toolkit Script Components | 1.1.0 | #126 | Default UI |
| Animation Path Visualizer | 2.0.0 | -- | -- |
| Default Playables | 2.0 | -- | -- |

### Third-Party (UPM / OpenUPM)
| Package | Version | Notes |
|---------|---------|-------|
| AI Game Developer -- Unity MCP | 0.51.5 | IvanMurzak; port 50774 |
| AI Animation | 1.0.30 | IvanMurzak MCP extension |
| AI ProBuilder | 1.0.30 | IvanMurzak MCP extension |
| UniTask | 2.5.10 | Cysharp |
| R3 (NuGet) | 1.3.0 | Cysharp |
| Image Loader | 7.0.1 | IvanMurzak |
| PlayerPrefsEx | 2.1.2 | IvanMurzak |
| Unity Theme | 4.2.0 | IvanMurzak |
| TecVooDoo MCP Tool Extensions | 1.0.0 | Local |
| TecVooDoo Utilities | 1.0.0 | Local |

---

## Known Issues

| Issue | Severity | Status | Notes |
|-------|----------|--------|-------|
| -- | -- | -- | -- |

---

## Session Close Checklist

- [x] Update session summary
- [x] Update Audio Creation Tracker if items changed
- [x] Update Asset Eval Summary count
- [x] Update Integration Patterns if new patterns found
- [x] Update Lessons Learned if applicable
- [x] Update Installed Packages if changed

---

## Reference Documents

| Document | Path |
|----------|------|
| PATWA Design Spec | `E:\Unity\AudioProject\Documents\PATWA_DesignSpec.md` |
| Asset Log | `E:\Unity\AudioProject\Documents\Audio_AssetLog.md` |
| Archives | `E:\Unity\AudioProject\Documents\Archives\` |
| Sandbox Asset Log | `E:\Unity\Sandbox\Documents\Sandbox_AssetLog.md` |
| AQS Design Docs | `E:\TecVooDoo\Projects\Games\2 Planning\A Quokka Story` |
| Memory | `C:\Users\steph\.claude\projects\e--Unity-AudioProject\memory\MEMORY.md` |

---

**End of Document**
