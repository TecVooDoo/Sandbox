# PATWA -- Design Specification

**Full Name:** Peter and the Wolf Adaptive Audio System
**Version:** 0.1 (Draft)
**Date Created:** March 11, 2026
**Last Updated:** March 11, 2026
**Developer:** TecVooDoo LLC / Rune (Stephen Brandon)
**Target:** Asset Store product (zero hard dependencies, works out of the box)
**Origin:** A Quokka Story adaptive audio concept

---

## Table of Contents

1. [Vision](#vision)
2. [Design Principles](#design-principles)
3. [Architecture Overview](#architecture-overview)
4. [Core Layer](#core-layer)
5. [Backend Abstraction](#backend-abstraction)
6. [Audio Browser](#audio-browser)
7. [Beat Sync](#beat-sync)
8. [Audio-Reactive Module](#audio-reactive-module)
9. [Conflict Resolution](#conflict-resolution)
10. [Data Model (ScriptableObjects)](#data-model)
11. [Editor Tooling](#editor-tooling)
12. [Plugin Architecture](#plugin-architecture)
13. [Cherry-Pick Sources](#cherry-pick-sources)
14. [Example Scenes](#example-scenes)
15. [User Integration Paths](#user-integration-paths)
16. [Implementation Phases](#implementation-phases)
17. [Open Questions](#open-questions)

---

## Vision

PATWA is an **adaptive audio orchestration layer** that sits above any audio backend. It makes game audio reactive to gameplay by treating every game entity as a potential music contributor. When an entity spawns, its instrument layers in. When it dies, the layer fades out. When it takes damage, its instrument accents. When energy is low, volume drops.

**One-line pitch:** "PATWA makes any audio middleware adaptive -- register game entities as music contributors and PATWA handles layering, transitions, conflicts, and volume curves automatically."

**What PATWA is NOT:**
- Not an audio engine (does not replace Master Audio, FMOD, Wwise)
- Not a DAW or composition tool
- Not a procedural music generator (though it can orchestrate one)

**What PATWA IS:**
- A conductor layer between game logic and audio playback
- An entity-to-music binding system
- A conflict resolver for overlapping instruments
- An audio library browser/importer
- A beat-quantized transition manager

---

## Design Principles

| # | Principle | Rationale |
|---|-----------|-----------|
| 1 | **Zero hard dependencies** | Must work with only Unity AudioSource. Optional adapters bridge to Master Audio, FMOD, Wwise, PMG, Koreographer, etc. |
| 2 | **Zero-code path exists** | Drop prefab, create SO, assign clips, add bridge component, configure in inspector -- no scripting required for common use cases |
| 3 | **Code path is clean** | Implement `IMusicContributor`, call Register/Unregister, set Intensity -- 3 touch points |
| 4 | **Content-agnostic** | No assumptions about audio content. Works with loops, stems, one-shots, MIDI, procedural output |
| 5 | **Game-agnostic** | No Joey/enemy/biome concepts in core. Users define their own entity-to-music mappings |
| 6 | **Beat-aware** | Transitions snap to musical boundaries (next beat, next bar, next phrase) |
| 7 | **Cherry-pick, don't reinvent** | Adopt proven patterns from installed assets (see Cherry-Pick Sources) |
| 8 | **Interfaces and generics** | Every extensibility point is an interface. Internal implementations are swappable |
| 9 | **No var, explicit types** | TecVooDoo coding standard |
| 10 | **UniTask over coroutines** | For all async operations |

---

## Architecture Overview

```
+------------------------------------------------------------------+
|                         USER'S GAME                               |
|  [Enemy]  [Player]  [NPC]  [Boss]  [Environment]  [UI]           |
|     |         |        |      |          |           |            |
|     +----+----+--------+------+----------+-----------+            |
|          |                                                        |
|     IMusicContributor                                             |
+------------------------------------------------------------------+
           |
           v
+------------------------------------------------------------------+
|                      PATWA CORE                                   |
|                                                                   |
|  +------------------+    +-------------------+    +-----------+   |
|  |  MusicDirector   |--->| ContributorTracker|--->|  MixState |   |
|  | (orchestration)  |    | (registry)        |    | (volumes) |   |
|  +--------+---------+    +-------------------+    +-----------+   |
|           |                                                       |
|  +--------v---------+    +-------------------+    +-----------+   |
|  | TransitionEngine |--->| ConflictResolver  |    | BeatClock |   |
|  | (crossfades)     |    | (instrument prio) |    | (timing)  |   |
|  +------------------+    +-------------------+    +-----------+   |
|           |                                                       |
+------------------------------------------------------------------+
           |
           v
+------------------------------------------------------------------+
|                   BACKEND ABSTRACTION                             |
|                                                                   |
|  IAudioBackend          IProceduralBackend    IBeatSyncProvider   |
|  (play/stop/volume)     (generate layers)     (BPM/beat events)  |
|                                                                   |
+------------------------------------------------------------------+
           |                      |                    |
           v                      v                    v
+----------------+  +------------------+  +-------------------+
| Built-In       |  | Built-In         |  | Built-In          |
| (AudioSource)  |  | (BasicSynth)     |  | (SimpleBeatClock) |
+----------------+  +------------------+  +-------------------+
| MasterAudio    |  | PMG Adapter      |  | Koreographer      |
| Adapter        |  |                  |  | Adapter           |
+----------------+  +------------------+  +-------------------+
| FMOD Adapter   |  | Maestro/MIDI     |  |                   |
|                |  | Adapter          |  |                   |
+----------------+  +------------------+  +-------------------+
| Wwise Adapter  |  | Chunity/ChucK    |  |                   |
| (community)    |  | Adapter          |  |                   |
+----------------+  +------------------+  +-------------------+
```

---

## Core Layer

### MusicDirector

The central MonoBehaviour. Singleton (configurable -- can also be injected via service locator).

```
Namespace: TecVooDoo.PATWA
Assembly: TecVooDoo.PATWA.Core
```

**Responsibilities:**
- Maintain registry of active `IMusicContributor` instances
- Compute target mix state each frame (volumes, active stems)
- Drive `TransitionEngine` for smooth changes
- Delegate playback commands to `IAudioBackend`
- Quantize transitions via `BeatClock`

**Public API:**

```csharp
// Registration
MusicDirector Register(IMusicContributor contributor);
MusicDirector Unregister(IMusicContributor contributor);

// Context
void TransitionTo(MusicContext context, float crossfadeDuration);
void TransitionTo(MusicContext context, TransitionOptions options);
MusicContext CurrentContext { get; }

// Global
float MasterVolume { get; set; }
bool IsMuted { get; set; }
bool IsPaused { get; set; }

// Conflict
IConflictResolver ConflictResolver { get; set; }

// Beat
BeatClock BeatClock { get; }

// Queries
IReadOnlyList<IMusicContributor> ActiveContributors { get; }
MixState CurrentMixState { get; }

// Events
event Action<IMusicContributor> OnContributorRegistered;
event Action<IMusicContributor> OnContributorUnregistered;
event Action<MusicContext, MusicContext> OnContextTransition;  // old, new
```

**Fluent Registration (cherry-picked from Bro Audio):**

```csharp
MusicDirector.Instance
    .Register(contributor)
    .WithFade(1.5f)
    .WithDominance(0.8f)
    .OnNextBeat();
```

### IMusicContributor

The interface any game entity implements to contribute audio layers.

```csharp
public interface IMusicContributor
{
    string ContributorId { get; }
    MusicContributorProfile Profile { get; }
    float Intensity { get; }          // 0-1, drives volume curve
    bool IsActive { get; }            // false = muted but registered
    ContributorState State { get; }   // user-defined enum mapped to behaviors

    event Action<IMusicContributor> OnIntensityChanged;
    event Action<IMusicContributor> OnStateChanged;
    event Action<IMusicContributor> OnDeactivated;
}
```

### ContributorState

Users define their own states via an enum or string. PATWA maps states to volume/behavior via `MusicContributorProfile`.

**Built-in state presets (optional):**

```csharp
public enum DefaultContributorState
{
    Idle,       // default volume
    Active,     // accented
    Weakened,   // reduced volume
    Dominant,   // duck others
    Silent      // muted
}
```

### MixState

Snapshot of current audio mix, computed each frame.

```csharp
public class MixState
{
    public IReadOnlyDictionary<string, float> StemVolumes { get; }
    public IReadOnlyDictionary<string, bool> StemActive { get; }
    public float MasterVolume { get; }
    public MusicContext ActiveContext { get; }
    public float BeatPosition { get; }
}
```

### ContributorTracker

Internal registry. Tracks all registered contributors, their current states, and their assigned stems.

**Responsibilities:**
- Map contributors to stem slots via `MusicContext`
- Track contributor lifecycle (register, state change, unregister)
- Detect instrument conflicts and delegate to `IConflictResolver`
- Compute per-stem target volume from contributor intensity + profile curves

### TransitionEngine

Handles all audio transitions with beat quantization.

```csharp
public class TransitionEngine
{
    // Stem-level transitions
    UniTask FadeIn(string stemId, float duration, AnimationCurve curve);
    UniTask FadeOut(string stemId, float duration, AnimationCurve curve);
    UniTask CrossFade(string fromStem, string toStem, float duration);

    // Context-level transitions
    UniTask TransitionContext(MusicContext from, MusicContext to, TransitionOptions options);
}
```

**TransitionOptions:**

```csharp
public struct TransitionOptions
{
    public float Duration;
    public TransitionMode Mode;        // Cut, Fade, CrossFade, Stinger
    public QuantizeMode Quantize;      // Immediate, NextBeat, NextBar, NextPhrase
    public AnimationCurve FadeCurve;
    public AudioClip StingerClip;      // optional transition sound
}
```

### BeatClock

Internal timing system. Tracks BPM, beat position, bar position.

```csharp
public class BeatClock
{
    public float BPM { get; set; }
    public int BeatsPerBar { get; set; }
    public float CurrentBeat { get; }
    public int CurrentBar { get; }
    public float BeatProgress { get; }     // 0-1 within current beat
    public float BarProgress { get; }      // 0-1 within current bar

    // Quantization
    float TimeToNextBeat { get; }
    float TimeToNextBar { get; }
    float TimeToNextPhrase(int phraseLengthBars);

    // Events
    event Action OnBeat;
    event Action OnBar;
    event Action<int> OnPhrase;  // phrase number

    // External sync
    void SyncTo(IBeatSyncProvider provider);
}
```

Built-in implementation uses `AudioSettings.dspTime` for sample-accurate timing. When Koreographer adapter is installed, `SyncTo()` delegates to Koreographer's beat detection.

---

## Backend Abstraction

### IAudioBackend

The bridge between PATWA and actual audio playback.

```csharp
public interface IAudioBackend
{
    // Lifecycle
    void Initialize(MusicDirector director);
    void Shutdown();

    // Stem management
    string LoadStem(AudioClip clip, StemSettings settings);
    void UnloadStem(string stemId);

    // Playback
    void PlayStem(string stemId);
    void StopStem(string stemId, float fadeTime = 0f);
    void PauseStem(string stemId);
    void ResumeStem(string stemId);

    // Parameters
    void SetStemVolume(string stemId, float volume);
    void SetStemPitch(string stemId, float pitch);
    void SetStemPan(string stemId, float pan);

    // Bus/group
    string CreateBus(string busName);
    void AssignStemToBus(string stemId, string busId);
    void SetBusVolume(string busId, float volume);

    // Info
    bool IsStemPlaying(string stemId);
    float GetStemTime(string stemId);
    float GetStemLength(string stemId);

    // Spatial (optional)
    void SetStemPosition(string stemId, Vector3 position);
    void SetStemSpatialBlend(string stemId, float blend);
}
```

### Built-In Backend: AudioSourceBackend

Ships with PATWA. Uses Unity's `AudioSource` components from a pool.

```csharp
public class AudioSourceBackend : MonoBehaviour, IAudioBackend
{
    [SerializeField] private int _initialPoolSize = 16;
    [SerializeField] private int _maxPoolSize = 32;

    // Uses ObjectPool<AudioSource> pattern (cherry-picked from Bro Audio)
    // DOTween integration for fades (fallback to Lerp if DOTween absent)
}
```

**No external dependencies.** This is what ships by default.

### IProceduralBackend

For backends that generate audio rather than play clips.

```csharp
public interface IProceduralBackend
{
    void Initialize(MusicDirector director);
    void Shutdown();

    string CreateLayer(ProceduralLayerConfig config);
    void DestroyLayer(string layerId);
    void SetLayerParameter(string layerId, string paramName, float value);

    bool IsLayerPlaying(string layerId);
    void StartLayer(string layerId);
    void StopLayer(string layerId, float fadeTime = 0f);
}
```

### IBeatSyncProvider

For external beat tracking systems.

```csharp
public interface IBeatSyncProvider
{
    float CurrentBPM { get; }
    float CurrentBeatPosition { get; }
    int CurrentBar { get; }
    int BeatsPerBar { get; }

    event Action OnBeat;
    event Action OnBar;
}
```

---

## Audio Browser

Editor-only tooling for browsing, previewing, and importing audio files from local folders and archives.

**Cherry-pick source:** Asset Inventory 4's `ArchiveImporter` / `UnityPackageImporter` patterns (phased indexing, header parsing, state machine for progress, SQLite metadata cache).

### AudioBrowser Editor Window

```
+---------------------------------------------------------------------+
| PATWA Audio Browser                                    [Scan] [x]   |
|---------------------------------------------------------------------|
| Source Folders:                                                      |
|   [+] E:\GameAssetsAudio\Audio\                                     |
|   [+] E:\Unity\01UnityAssetSystem\...                               |
|---------------------------------------------------------------------|
| Filters: [Key: Any v] [BPM: 80-140] [Type: Loop v] [Search: ____]  |
|---------------------------------------------------------------------|
| Name              | Key  | BPM | Dur   | Type    | Source     | Tag |
|-------------------|------|-----|-------|---------|------------|-----|
| swamp_bass_01     | Em   | 105 | 4 bar | Loop    | NineVolt.zip| Stem|
| tribal_drums_02   | --   | 110 | 2 bar | Loop    | NineVolt.zip| Stem|
| banjo_melody_03   | Em   | 105 | 8 bar | Loop    | NineVolt.zip| Stem|
|                   |      |     |       |         |            |     |
|---------------------------------------------------------------------|
| [Preview: > || ] [Import Selected] [Assign to Context]              |
+---------------------------------------------------------------------+
```

### Scanning Pipeline

```
Phase 1: Discovery (fast)
  - Walk folder tree, find audio files and archives
  - For archives (zip/rar/7z): read file listing without extraction
  - Build index of file paths, sizes, formats
  - Store in local SQLite DB

Phase 2: Analysis (on-demand, per-file)
  - Extract single file to temp folder
  - Load as AudioClip, detect: duration, sample rate, channels
  - BPM detection (onset detection algorithm)
  - Key detection (chromagram analysis -- optional, can be manual tag)
  - Cache results in DB
  - Clean up temp file

Phase 3: Preview (user-triggered)
  - Extract to temp, load, play in editor
  - Waveform display
  - Loop point preview

Phase 4: Import (user-triggered)
  - Extract selected files to project (configurable destination)
  - Auto-create AudioClip import settings
  - Optionally assign to MusicContext SO stem slots
```

### Supported Formats

| Format | Read | Archive |
|--------|------|---------|
| .wav | Yes | Yes (from zip/rar/7z) |
| .mp3 | Yes | Yes |
| .ogg | Yes | Yes |
| .flac | Yes (convert on import) | Yes |
| .aif/.aiff | Yes | Yes |
| .unitypackage | Audio files only | N/A |

### Audio Metadata DB

SQLite (same pattern as Asset Inventory 4). Stores:

```
AudioFiles table:
  - Id, FilePath, ArchivePath (null if loose file)
  - FileName, Extension, FileSize
  - Duration, SampleRate, Channels
  - DetectedBPM, DetectedKey (nullable)
  - UserTags (comma-separated)
  - StemType (Loop, OneShot, Stem, Ambience, SFX)
  - LastScanned, LastModified

SourceFolders table:
  - Id, FolderPath, LastFullScan, FileCount

Tags table:
  - Id, AudioFileId, TagName, TagValue
```

---

## Beat Sync

### Built-In: SimpleBeatClock

Runs from `AudioSettings.dspTime`. User sets BPM and time signature. Fires `OnBeat`/`OnBar` events. Sufficient for stem-based adaptive music where BPM is known.

### Koreographer Adapter

When Koreographer is installed (detected via scripting define `PATWA_KOREOGRAPHER`):

- `KoreographerBeatSyncProvider : IBeatSyncProvider`
- Reads BPM from Koreography asset
- Beat/bar events come from Koreographer's track analysis
- Supports tempo changes within a track
- Sample-accurate beat detection from audio analysis

---

## Audio-Reactive Module

**Cherry-pick source:** Timeflow's Spectrum -> Sample -> Reactive chain.

Optional module for driving visual/gameplay properties from audio output. Ships with PATWA but does not affect core functionality if unused.

### Pipeline

```
AudioOutput --> SpectrumAnalyzer --> FrequencyBandSampler --> ReactiveDriver --> Target Properties
```

### SpectrumAnalyzer

Wraps `AudioSource.GetSpectrumData()` or `AudioListener.GetSpectrumData()`.

```csharp
public class SpectrumAnalyzer : MonoBehaviour
{
    [SerializeField] private FFTWindow _fftWindow = FFTWindow.BlackmanHarris;
    [SerializeField] private int _sampleCount = 512;
    [SerializeField] private bool _useMicInput = false;

    public float[] SpectrumData { get; }
    public float RMS { get; }           // overall loudness
    public float PeakFrequency { get; }
}
```

### FrequencyBandSampler

Splits spectrum into musical frequency bands with configurable presets.

```csharp
public class FrequencyBandSampler : MonoBehaviour
{
    [SerializeField] private SpectrumAnalyzer _analyzer;
    [SerializeField] private FrequencyBandPreset _preset;  // SubBass, Bass, LowMid, Mid, HighMid, Presence, Brilliance

    public float GetBandValue(int bandIndex);
    public float GetBandValue(string bandName);
    public float[] AllBands { get; }
}
```

**Built-in presets (cherry-picked from Timeflow):**

| Preset | Range | Use Case |
|--------|-------|----------|
| SubBass | 20-60 Hz | Screen shake, ground effects |
| Bass | 60-250 Hz | Character bounce, pulse effects |
| LowMid | 250-500 Hz | Warm glow, smooth animations |
| Mid | 500-2000 Hz | UI reactions, particle emission |
| HighMid | 2000-4000 Hz | Sparkle effects, highlights |
| Presence | 4000-6000 Hz | Sharp visual accents |
| Brilliance | 6000-20000 Hz | Shimmer, high-frequency detail |

### ReactiveDriver

Maps sampled band values to target properties with envelope shaping.

```csharp
public class ReactiveDriver : MonoBehaviour
{
    [SerializeField] private FrequencyBandSampler _sampler;
    [SerializeField] private int _bandIndex;
    [SerializeField] private ReactiveTarget[] _targets;

    [Header("Envelope")]
    [SerializeField] private float _attack = 0.05f;
    [SerializeField] private float _release = 0.3f;
    [SerializeField] private float _threshold = 0.1f;
    [SerializeField] private AnimationCurve _responseCurve;

    [Header("Presets")]
    [SerializeField] private ReactivePreset _preset;  // Bouncey, Floating, Punchy, Soft
}
```

**ReactiveTarget** can drive:
- Transform (scale, position, rotation)
- Material properties (color, emission, float params)
- Light (intensity, range, color)
- ParticleSystem (emission rate, size)
- Any serialized float/color via reflection

---

## Conflict Resolution

When two contributors map to the same instrument slot in a `MusicContext`, PATWA needs a strategy.

### IConflictResolver

```csharp
public interface IConflictResolver
{
    ConflictResolution Resolve(
        IMusicContributor existing,
        IMusicContributor incoming,
        string instrumentSlot,
        MusicContext context
    );
}

public struct ConflictResolution
{
    public ConflictAction ExistingAction;   // Keep, FadeToAccent, Mute, Remove
    public ConflictAction IncomingAction;   // Add, AddAsAccent, Reject
    public float ExistingVolumeMod;         // multiplier (1.0 = unchanged, 0.3 = accent level)
    public float IncomingVolumeMod;
}

public enum ConflictAction
{
    Keep,           // no change
    FadeToAccent,   // reduce to accent volume
    Mute,           // silence but keep registered
    Remove,         // unregister entirely
    Add,            // register normally
    AddAsAccent,    // register at reduced volume
    Reject          // do not register
}
```

### Built-In Resolvers

**PriorityResolver** (default):
- Each `MusicContributorProfile` has a `Priority` field (0-100)
- Higher priority wins the full stem, lower becomes accent
- Equal priority: first registered wins

**LayeredResolver:**
- Both contributors play the stem
- Incoming added at accent volume (configurable, default 0.3x)
- Creates thicker texture, no contributor is silenced

**QueueResolver:**
- First registered plays
- Incoming queued; when existing unregisters, next in queue takes over
- FIFO ordering

**Custom:**
- Users implement `IConflictResolver` for game-specific logic
- Example: AQS "Ninja Joey vs Gator banjo" -- after Ninja rescue, Gator switches to accents

---

## Data Model

### MusicContext (replaces BiomeMusicData)

The central configuration SO. Defines what stems are available and how they map to contributors.

```csharp
[CreateAssetMenu(menuName = "PATWA/Music Context")]
public class MusicContext : ScriptableObject
{
    [Header("Musical Properties")]
    public string ContextName;
    public MusicalKey Key;
    public int BPM;
    public int BeatsPerBar = 4;

    [Header("Stems")]
    public List<StemSlot> Stems;

    [Header("Ambient")]
    public List<AmbientLayer> AmbientLayers;  // always-on background layers

    [Header("Transition")]
    public TransitionOptions DefaultTransitionIn;
    public TransitionOptions DefaultTransitionOut;

    [Header("Limits")]
    public int MaxSimultaneousStems = 12;
    public VoiceLimitMode LimitMode;  // DropLowest, DropNewest, DropOldest
}
```

### StemSlot

```csharp
[Serializable]
public class StemSlot
{
    public string SlotName;              // "Bass", "Drums_Light", "Banjo", etc.
    public string InstrumentTag;         // for conflict resolution matching
    public StemMode Mode;                // PreRecorded, Procedural, MIDI

    [Header("Pre-Recorded")]
    public AudioClip Clip;
    public bool Loop = true;
    public float BaseVolume = 1f;

    [Header("Procedural")]
    public ProceduralLayerConfig ProceduralConfig;

    [Header("MIDI")]
    public MIDILayerConfig MIDIConfig;

    [Header("Behavior")]
    public StemActivation Activation;    // ContributorDriven, AlwaysOn, EnergyThreshold
    public AnimationCurve IntensityToVolume;  // maps contributor intensity to stem volume
    public float FadeInTime = 0.5f;
    public float FadeOutTime = 1.0f;
}

public enum StemMode
{
    PreRecorded,    // AudioClip via IAudioBackend
    Procedural,     // Generated via IProceduralBackend
    MIDI            // MIDI events via Maestro/DryWetMIDI
}

public enum StemActivation
{
    ContributorDriven,  // active when mapped contributor is registered
    AlwaysOn,           // ambient layers
    EnergyThreshold     // active when global energy exceeds threshold
}
```

### MusicContributorProfile

Per-entity-type configuration. Assigned to `IMusicContributor.Profile`.

```csharp
[CreateAssetMenu(menuName = "PATWA/Contributor Profile")]
public class MusicContributorProfile : ScriptableObject
{
    public string ProfileName;
    public int Priority = 50;                         // for conflict resolution (0-100)

    [Header("Stem Mapping")]
    public List<StemMapping> StemMappings;             // which stems this contributor activates

    [Header("Volume Behavior")]
    public AnimationCurve IntensityToVolume;           // intensity -> volume curve
    public float AccentMultiplier = 1.5f;              // volume boost on accent state
    public float WeakenedMultiplier = 0.2f;            // volume reduction on weakened state

    [Header("State Behaviors")]
    public List<MusicBehavior> Behaviors;              // inspector-configurable state->action mappings

    [Header("Dominance")]
    public bool CanDominate = false;                   // can this contributor duck others?
    public float DominanceDuckLevel = 0.3f;            // how much to duck others (0-1)
    public float DominanceFadeTime = 0.5f;
}
```

### StemMapping

```csharp
[Serializable]
public class StemMapping
{
    public string SlotName;          // must match StemSlot.SlotName in a MusicContext
    public string InstrumentTag;     // for conflict detection
}
```

### MusicBehavior

Inspector-configurable state-to-action mappings. Cherry-picked from Feel/MMFeedbacks modular pattern.

```csharp
[Serializable]
public class MusicBehavior
{
    public MusicTrigger Trigger;
    public MusicAction Action;
    public float Duration = 1f;
    public AnimationCurve Curve;
    public float Delay = 0f;
    public QuantizeMode Quantize = QuantizeMode.Immediate;
}

public enum MusicTrigger
{
    OnRegister,          // contributor registered with MusicDirector
    OnUnregister,        // contributor unregistered
    OnStateChanged,      // contributor state changed
    OnIntensityAbove,    // intensity crosses threshold upward
    OnIntensityBelow,    // intensity crosses threshold downward
    OnBeat,              // every beat
    OnBar,               // every bar
    Custom               // fired manually via code
}

public enum MusicAction
{
    FadeIn,
    FadeOut,
    Accent,              // brief volume spike
    DominateOthers,      // duck all other contributors
    ReleaseDominance,    // stop ducking
    TransitionStem,      // swap to different stem variant
    Silence,
    Restore
}

public enum QuantizeMode
{
    Immediate,
    NextBeat,
    NextBar,
    NextPhrase
}
```

### LeitmotifData (Procedural Mode)

Cherry-picked from PMG's Leitmotif structure, simplified.

```csharp
[CreateAssetMenu(menuName = "PATWA/Leitmotif")]
public class LeitmotifData : ScriptableObject
{
    public string ThemeName;
    public MusicalKey Key;
    public int BPM;

    public List<LeitmotifMeasure> Measures;
}

[Serializable]
public class LeitmotifMeasure
{
    public List<LeitmotifBeat> Beats;
}

[Serializable]
public class LeitmotifBeat
{
    public List<LeitmotifNote> Notes;  // supports chords (multiple notes per beat)
}

[Serializable]
public class LeitmotifNote
{
    public int Pitch;          // MIDI note number (60 = middle C)
    public float Velocity;     // 0-1
    public float Duration;     // in beats (1.0 = quarter note)
    public int Instrument;     // index into ProceduralLayerConfig instruments
}
```

### MusicalKey

```csharp
public enum MusicalKey
{
    C, CSharp, D, DSharp, E, F, FSharp, G, GSharp, A, ASharp, B
}

public enum MusicalScale
{
    Major, Minor, Pentatonic, Blues, Dorian, Mixolydian, Chromatic
}
```

---

## Editor Tooling

### MusicDirector Inspector

Custom Odin-powered inspector showing:
- Current context name, BPM, key
- Live contributor list with intensity bars
- Per-stem volume meters (real-time)
- Active conflicts and resolutions
- Beat clock visualization (bouncing dot)

### MusicContext Editor

Custom editor for `MusicContext` SO:
- Stem slot list with drag-drop AudioClip assignment
- Per-slot waveform preview and loop point markers
- "Test" button to play stems in editor
- Validation: warn if stems have mismatched BPM/key
- Integration with Audio Browser for clip assignment

### Contributor Debugger Window

Editor window (Window > PATWA > Contributor Debugger):
- Shows all registered contributors in play mode
- Per-contributor: state, intensity, mapped stems, volume output
- Conflict log with resolution details
- Solo/mute per contributor for debugging

### Audio Browser Window

See Audio Browser section above.

---

## Plugin Architecture

### Folder Structure

```
Assets/TecVooDoo/PATWA/
|
+-- Core/                              [asmdef: TecVooDoo.PATWA.Core]
|   +-- Interfaces/
|   |   +-- IMusicContributor.cs
|   |   +-- IAudioBackend.cs
|   |   +-- IProceduralBackend.cs
|   |   +-- IBeatSyncProvider.cs
|   |   +-- IConflictResolver.cs
|   +-- Director/
|   |   +-- MusicDirector.cs
|   |   +-- ContributorTracker.cs
|   |   +-- TransitionEngine.cs
|   |   +-- MixState.cs
|   +-- Data/
|   |   +-- MusicContext.cs
|   |   +-- MusicContributorProfile.cs
|   |   +-- StemSlot.cs
|   |   +-- StemMapping.cs
|   |   +-- MusicBehavior.cs
|   |   +-- LeitmotifData.cs
|   +-- Timing/
|   |   +-- BeatClock.cs
|   +-- Conflict/
|   |   +-- PriorityResolver.cs
|   |   +-- LayeredResolver.cs
|   |   +-- QueueResolver.cs
|   +-- Bridge/
|       +-- MusicContributorBridge.cs    (MonoBehaviour, zero-code path)
|
+-- BuiltIn/                           [asmdef: TecVooDoo.PATWA.BuiltIn]
|   +-- AudioSourceBackend.cs
|   +-- BasicSynthBackend.cs
|   +-- SimpleBeatClock.cs
|   +-- AudioSourcePool.cs
|
+-- Reactive/                          [asmdef: TecVooDoo.PATWA.Reactive]
|   +-- SpectrumAnalyzer.cs
|   +-- FrequencyBandSampler.cs
|   +-- ReactiveDriver.cs
|   +-- ReactiveTarget.cs
|   +-- Presets/
|       +-- ReactivePreset_Bouncey.asset
|       +-- ReactivePreset_Punchy.asset
|       +-- ReactivePreset_Floating.asset
|       +-- ReactivePreset_Soft.asset
|
+-- Editor/                            [asmdef: TecVooDoo.PATWA.Editor]
|   +-- MusicDirectorEditor.cs
|   +-- MusicContextEditor.cs
|   +-- ContributorDebuggerWindow.cs
|   +-- AudioBrowser/
|   |   +-- AudioBrowserWindow.cs
|   |   +-- AudioScanner.cs
|   |   +-- AudioAnalyzer.cs
|   |   +-- ArchiveReader.cs
|   |   +-- AudioMetadataDB.cs
|   +-- Inspectors/
|       +-- MusicContributorProfileEditor.cs
|       +-- StemSlotDrawer.cs
|
+-- Adapters/                          (optional, one per supported middleware)
|   +-- MasterAudio/                   [asmdef: TecVooDoo.PATWA.MasterAudio]
|   |   +-- MasterAudioBackend.cs
|   +-- FMOD/                          [asmdef: TecVooDoo.PATWA.FMOD]
|   |   +-- FMODBackend.cs
|   +-- Koreographer/                  [asmdef: TecVooDoo.PATWA.Koreographer]
|   |   +-- KoreographerBeatSyncProvider.cs
|   +-- PMG/                           [asmdef: TecVooDoo.PATWA.PMG]
|   |   +-- PMGProceduralBackend.cs
|   +-- Maestro/                       [asmdef: TecVooDoo.PATWA.Maestro]
|       +-- MaestroMIDIBackend.cs
|
+-- Examples/
|   +-- 01_BasicStemLayering/
|   |   +-- BasicStemDemo.unity
|   |   +-- BasicStemDemo_MusicContext.asset
|   |   +-- SimpleContributor.cs
|   +-- 02_EntityDriven/
|   |   +-- EntityDrivenDemo.unity
|   |   +-- EnemySpawner.cs
|   |   +-- EnemyMusicBridge.cs
|   +-- 03_EnergyDriven/
|   |   +-- EnergyDrivenDemo.unity
|   |   +-- PlayerEnergyContributor.cs
|   +-- 04_AudioReactive/
|       +-- AudioReactiveDemo.unity
|       +-- ReactiveVisualizer.cs
|
+-- Documentation/
    +-- QuickStart.md
    +-- API_Reference.md
    +-- AdapterGuide.md
    +-- AudioBrowserGuide.md
```

### Assembly Definitions

Each folder gets its own asmdef to:
- Prevent unnecessary compilation when only one module changes
- Allow adapters to be conditionally compiled (scripting defines)
- Users can delete any adapter folder without breaking core

### Scripting Defines (auto-detected)

| Define | Condition |
|--------|-----------|
| `PATWA_DOTWEEN` | DOTween detected in project |
| `PATWA_MASTER_AUDIO` | Master Audio detected |
| `PATWA_FMOD` | FMOD detected |
| `PATWA_KOREOGRAPHER` | Koreographer detected |
| `PATWA_PMG` | Procedural Music Generator detected |
| `PATWA_MAESTRO` | Maestro MIDI detected |
| `PATWA_ODIN` | Odin Inspector detected |
| `PATWA_UNITASK` | UniTask detected |

When a define is absent, the corresponding adapter asmdef simply won't compile. Core never references adapters directly.

---

## Cherry-Pick Sources

Summary of architectural patterns adopted from evaluated assets.

| Source Asset | Pattern | Used In PATWA |
|---|---|---|
| **Asset Inventory 4** | Archive scanning (zip/rar/7z header reading, phased indexing) | Audio Browser -- scan and import from compressed libraries |
| **Asset Inventory 4** | SQLite metadata caching with state machine progress tracking | Audio Browser -- AudioMetadataDB for persistent file index |
| **Asset Inventory 4** | Single-file extraction from archives (materialization pattern) | Audio Browser -- preview and import individual files |
| **Bro Audio** | Decorator chain (`AudioPlayerDecorator` base) | Effect stacking on stems (volume, filter, pitch decorators) |
| **Bro Audio** | Fluent API (`Play().SetVolume().SetTransition()`) | MusicDirector registration API |
| **Bro Audio** | Dominator pattern (one source ducks all others) | `MusicContributorProfile.CanDominate` + `DominanceDuckLevel` |
| **Bro Audio** | Generic `ObjectPool<T>` with extract/recycle | `AudioSourcePool` in built-in backend |
| **Bro Audio** | 21-interface architecture (IAudioPlayer, IPlayerEffect, etc.) | Interface-first design throughout PATWA |
| **Master Audio** | Bus hierarchy (GroupBus with voice limits, solo/mute) | Lightweight bus system in IAudioBackend |
| **Master Audio** | Sound group variations (shuffle/sequence/polyphony) | StemSlot variation support |
| **Master Audio** | Dual AudioSource crossfade pattern | TransitionEngine context transitions |
| **Master Audio** | Voice management (steal oldest, drop lowest) | MusicContext.VoiceLimitMode |
| **PMG** | Leitmotif data structure (Measures -> Beats -> Notes) | LeitmotifData SO for procedural mode |
| **PMG** | Group-based instrument toggling with ManualGroupOdds | ContributorTracker stem activation |
| **PMG** | GeneratorMod extensibility (abstract mod base) | Future: user-extensible generation modifiers |
| **Maestro** | Real-time MIDI event queuing (thread-safe command queue) | MaestroMIDIBackend adapter |
| **Maestro** | Per-channel instrument/volume/pan control | MIDI layer management in StemSlot.MIDI mode |
| **DOTween** | AudioSource.DOFade / AudioMixer.DOSetFloat | Smooth parameter automation in TransitionEngine |
| **Koreographer** | Beat-synchronized callbacks with sample accuracy | BeatClock.SyncTo(IBeatSyncProvider) |
| **Timeflow** | Spectrum -> Sample -> Reactive chain | Audio-Reactive module (SpectrumAnalyzer -> FrequencyBandSampler -> ReactiveDriver) |
| **Timeflow** | Reactive presets (Bouncey, Floating, Punchy, Soft) | ReactivePreset SOs with attack/release/curve presets |
| **Timeflow** | MIDI File/Receiver with BPM matching | Future: MIDI-driven leitmotif playback |
| **Feel/MMFeedbacks** | Modular feedback stacking (list of components, each does one thing) | MusicBehavior list on MusicContributorProfile |

---

## Example Scenes

### 01: Basic Stem Layering

**Purpose:** Minimum viable demo. Shows stems layering in/out.

**Setup:**
- 4 audio stems (drums, bass, melody, pad) as AudioClips
- 1 MusicContext SO with 4 StemSlots
- 4 buttons on screen, each toggles a contributor
- MusicDirector with AudioSourceBackend

**Demonstrates:** Register/Unregister, fade in/out, MusicContext setup.

### 02: Entity-Driven

**Purpose:** Shows the "Peter and the Wolf" concept.

**Setup:**
- Simple 2D scene with spawner
- 3 enemy types, each with `MusicContributorBridge` component
- Each enemy type has a different `MusicContributorProfile` (different instrument)
- Enemies spawn/despawn, music layers respond

**Demonstrates:** IMusicContributor on game entities, automatic registration, conflict resolution, intensity mapping.

### 03: Energy-Driven

**Purpose:** Shows intensity-to-volume binding.

**Setup:**
- Player with energy bar (slider)
- Player's `MusicContributorBridge` maps energy to intensity
- As energy drops, player's instrument gets quieter
- Low energy triggers drum pattern change via MusicBehavior

**Demonstrates:** IntensityToVolume curve, MusicBehavior triggers, state-driven audio.

### 04: Audio-Reactive

**Purpose:** Shows visual response to music.

**Setup:**
- Music playing through MusicDirector
- Scene objects with ReactiveDriver components
- Objects pulse, glow, scale with different frequency bands
- Preset selector (Bouncey/Punchy/Floating/Soft)

**Demonstrates:** SpectrumAnalyzer, FrequencyBandSampler, ReactiveDriver, presets.

---

## User Integration Paths

### Path 1: Zero Code (Inspector Only)

1. Add `MusicDirector` prefab to scene
2. Create `MusicContext` SO (PATWA > Music Context)
3. Assign AudioClips to stem slots
4. Create `MusicContributorProfile` SOs for each entity type
5. Add `MusicContributorBridge` component to game entities
6. Configure `MusicBehavior` entries in the profile inspector
7. Play

### Path 2: Minimal Code

```csharp
public class EnemyAudio : MonoBehaviour, IMusicContributor
{
    [SerializeField] private MusicContributorProfile _profile;

    public string ContributorId => gameObject.GetInstanceID().ToString();
    public MusicContributorProfile Profile => _profile;
    public float Intensity => _health / _maxHealth;  // health = volume
    public bool IsActive => _isAlive;
    public ContributorState State => _currentState;

    public event Action<IMusicContributor> OnIntensityChanged;
    public event Action<IMusicContributor> OnStateChanged;
    public event Action<IMusicContributor> OnDeactivated;

    private void OnEnable()
    {
        MusicDirector.Instance.Register(this);
    }

    private void OnDisable()
    {
        MusicDirector.Instance.Unregister(this);
    }
}
```

### Path 3: Full Control

```csharp
// Custom backend
MusicDirector.Instance.SetBackend(new FMODBackend());

// Custom conflict resolver
MusicDirector.Instance.ConflictResolver = new MyGameConflictResolver();

// Manual transitions with full options
MusicDirector.Instance.TransitionTo(bossContext, new TransitionOptions
{
    Duration = 2f,
    Mode = TransitionMode.CrossFade,
    Quantize = QuantizeMode.NextBar,
    FadeCurve = AnimationCurve.EaseInOut(0, 0, 1, 1)
});

// Beat-synced events
MusicDirector.Instance.BeatClock.OnBar += () =>
{
    // spawn enemies on the downbeat
};
```

---

## Implementation Phases

### Phase 1: Core + Built-In Backend (MVP)

**Goal:** Working stem layering with AudioSource backend.

| Task | Priority |
|------|----------|
| IMusicContributor interface | P0 |
| MusicDirector (register/unregister, basic mix) | P0 |
| MusicContext SO | P0 |
| MusicContributorProfile SO | P0 |
| AudioSourceBackend (play/stop/volume) | P0 |
| AudioSourcePool | P0 |
| TransitionEngine (fade in/out/crossfade) | P0 |
| BeatClock (simple BPM clock) | P1 |
| PriorityResolver | P1 |
| MusicContributorBridge (zero-code component) | P1 |
| Example Scene 01: Basic Stem Layering | P1 |

**Deliverable:** Can register/unregister contributors, stems fade in/out, basic conflict resolution works.

### Phase 2: Behaviors + Editor Tools

| Task | Priority |
|------|----------|
| MusicBehavior system (trigger -> action) | P0 |
| MusicDirector custom inspector | P0 |
| MusicContext custom editor | P0 |
| ContributorDebugger window | P1 |
| QuantizeMode support in TransitionEngine | P1 |
| LayeredResolver, QueueResolver | P1 |
| Dominance system (duck others) | P1 |
| Example Scene 02: Entity-Driven | P1 |
| Example Scene 03: Energy-Driven | P1 |

**Deliverable:** Full behavior system, polished editor experience, two more example scenes.

### Phase 3: Audio Browser + Adapters

| Task | Priority |
|------|----------|
| AudioBrowser window (scan, preview, import) | P0 |
| Archive reading (zip/rar/7z) | P0 |
| AudioMetadataDB (SQLite) | P0 |
| BPM detection algorithm | P1 |
| MasterAudio adapter | P1 |
| Koreographer adapter | P1 |
| DOTween integration (conditional) | P2 |
| Auto-detection of installed middleware (scripting defines) | P1 |

**Deliverable:** Audio Browser usable, Master Audio and Koreographer adapters working.

### Phase 4: Reactive + Procedural

| Task | Priority |
|------|----------|
| SpectrumAnalyzer | P0 |
| FrequencyBandSampler | P0 |
| ReactiveDriver + presets | P0 |
| Example Scene 04: Audio-Reactive | P1 |
| PMG adapter | P1 |
| Maestro/MIDI adapter | P1 |
| LeitmotifData SO + playback | P2 |
| BasicSynthBackend (simple built-in procedural) | P2 |

**Deliverable:** Audio-reactive visuals working, procedural backends available.

### Phase 5: Polish + Asset Store Prep

| Task | Priority |
|------|----------|
| Documentation (QuickStart, API Reference, guides) | P0 |
| Key detection in Audio Browser | P1 |
| FMOD adapter | P2 |
| Wwise adapter (community contribution template) | P2 |
| UPM package format | P1 |
| Asset Store screenshots/video | P0 |
| Unity 2021 LTS compatibility testing | P1 |
| Performance profiling (max stems, CPU budget) | P1 |

**Deliverable:** Asset Store ready.

---

## Open Questions

| # | Question | Options | Decision |
|---|----------|---------|----------|
| 1 | Singleton vs DI for MusicDirector? | Singleton (simple) / Service Locator / Both | **Both.** Singleton for zero-code path, Service Locator for advanced/testable injection. |
| 2 | SQLite for Audio Browser or ScriptableObject? | SQLite (faster, Asset Inventory pattern) / SO (simpler, no native dep) | **SQLite for inventory/browser, SO for working code.** Browser indexes thousands of files in SQLite (out of version control). Runtime data stays in SOs. |
| 3 | Ship reactive module as core or separate package? | Core (more value) / Separate (smaller core) | **Core.** Own asmdef so deletable, but ships by default for demo value. |
| 4 | UniTask hard dependency or optional? | Hard (cleaner async) / Optional (broader compat) | **Optional.** Prefer async/await (UniTask) over coroutines for performance and low memory. Use `#if PATWA_UNITASK` conditional compilation. Coroutines as fallback for Asset Store buyers without UniTask. Personal preference: async/await is more performant and aligns with low-memory coding guidelines. |
| 5 | BPM detection: built-in or require user to tag? | Built-in (onset detection) / Manual only / Both | **Both.** Manual tagging always available. Built-in onset detection runs on-demand in Audio Browser. Users can correct inaccurate detections. |
| 6 | Odin Inspector: required for editor tools? | Required (better UX) / Optional (fallback to default drawers) | **Optional.** `#if PATWA_ODIN` for enhanced inspectors, default Unity drawers as fallback. Asset Store products cannot require paid dependencies. |
| 7 | Max stem count: configurable or hardcoded? | Configurable per MusicContext / Global setting | **Configurable per MusicContext.** Global default on MusicDirector, per-context override. Different scenes have different stem needs. |
| 8 | Thread safety: main thread only or support Jobs? | Main thread (simpler) / Job system for analysis | **Main thread for MVP (Phase 1-2).** Jobs for Audio Browser analysis in Phase 3 (BPM detection, archive scanning). Core playback stays main thread (Unity AudioSource API requires it). |
| 9 | Name: "PATWA" for Asset Store or something more marketable? | PATWA / Adaptive Audio Director / MusicWeaver / Other | **Deferred.** Internal codename stays PATWA, namespace `TecVooDoo.PATWA`. Asset Store name is a Phase 5 marketing decision. |

---

**End of Design Specification**
