---
name: feel-configure-player
description: |-
  Adds (if missing) and configures an MMF_Player component.
  All parameters are optional -- only provided values are changed.
  intensity [0-1+]: global multiplier on all feedback effects.
  direction: TopToBottom or BottomToTop playback order.
  cooldownDuration: seconds to lock out repeat plays after each play call.
  initialDelay: seconds to wait before starting feedback sequence.
  durationMultiplier: speed multiplier for all feedback durations.
  autoPlayOnStart / autoPlayOnEnable: trigger automatically on scene start or object enable.
  channel: integer channel ID for event-driven triggering via MMF_PlayerEvent.
---

# Feel / Configure MMF Player

## How to Call

```bash
unity-mcp-cli run-tool feel-configure-player --input '{
  "gameObjectName": "string_value",
  "intensity": "string_value",
  "direction": "string_value",
  "cooldownDuration": "string_value",
  "initialDelay": "string_value",
  "durationMultiplier": "string_value",
  "canPlayWhileAlreadyPlaying": "string_value",
  "autoPlayOnStart": "string_value",
  "autoPlayOnEnable": "string_value",
  "channel": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool feel-configure-player --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool feel-configure-player --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the GameObject to add MMF_Player to. |
| `intensity` | `any` | No | Global intensity multiplier [0-∞]. 1.0 = normal. |
| `direction` | `string` | No | Playback order: TopToBottom or BottomToTop. |
| `cooldownDuration` | `any` | No | Seconds to lock out repeat plays. |
| `initialDelay` | `any` | No | Seconds to wait before starting sequence. |
| `durationMultiplier` | `any` | No | Speed multiplier for all feedback durations. |
| `canPlayWhileAlreadyPlaying` | `any` | No | Allow a new play call while already playing. |
| `autoPlayOnStart` | `any` | No | Auto-play on Start(). |
| `autoPlayOnEnable` | `any` | No | Auto-play on OnEnable(). |
| `channel` | `any` | No | Integer channel ID for MMF_PlayerEvent triggering. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
    },
    "intensity": {
      "$ref": "#/$defs/System.Single"
    },
    "direction": {
      "type": "string"
    },
    "cooldownDuration": {
      "$ref": "#/$defs/System.Single"
    },
    "initialDelay": {
      "$ref": "#/$defs/System.Single"
    },
    "durationMultiplier": {
      "$ref": "#/$defs/System.Single"
    },
    "canPlayWhileAlreadyPlaying": {
      "$ref": "#/$defs/System.Boolean"
    },
    "autoPlayOnStart": {
      "$ref": "#/$defs/System.Boolean"
    },
    "autoPlayOnEnable": {
      "$ref": "#/$defs/System.Boolean"
    },
    "channel": {
      "$ref": "#/$defs/System.Int32"
    }
  },
  "$defs": {
    "System.Single": {
      "type": "number"
    },
    "System.Boolean": {
      "type": "boolean"
    },
    "System.Int32": {
      "type": "integer"
    }
  },
  "required": [
    "gameObjectName"
  ]
}
```

## Output

### Output JSON Schema

```json
{
  "type": "object",
  "properties": {
    "result": {
      "type": "string"
    }
  },
  "required": [
    "result"
  ]
}
```

