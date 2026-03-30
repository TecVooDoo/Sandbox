---
name: feel-play
description: |-
  Controls MMF_Player playback at runtime.
  action options:
    Play -- play feedbacks at object position with full intensity.
    Stop -- stop all currently playing feedbacks.
    Pause -- pause playback mid-sequence.
    Resume -- resume a paused sequence.
    Reset -- reset all feedbacks to their initial state.
    Reverse -- play feedbacks in reverse direction.
  intensity: optional playback intensity multiplier (default 1.0).
  Note: Play/Stop/Pause/Resume only work at runtime (in Play mode). Use this tool for runtime testing.
---

# Feel / Play / Stop / Control Feedbacks

## How to Call

```bash
unity-mcp-cli run-tool feel-play --input '{
  "gameObjectName": "string_value",
  "action": "string_value",
  "intensity": 0
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool feel-play --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool feel-play --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the GameObject with MMF_Player. |
| `action` | `string` | Yes | Action: Play, Stop, Pause, Resume, Reset, or Reverse. |
| `intensity` | `number` | No | Intensity multiplier for Play action (default 1.0). |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
    },
    "action": {
      "type": "string"
    },
    "intensity": {
      "type": "number"
    }
  },
  "required": [
    "gameObjectName",
    "action"
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

