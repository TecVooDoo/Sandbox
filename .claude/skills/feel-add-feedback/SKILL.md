---
name: feel-add-feedback
description: |-
  Adds a feedback to an MMF_Player's FeedbacksList and initializes the player.
  feedbackType options (most useful):
    CameraShake, Position, Scale, Rotation, Light, Particles, Flash,
    Flicker, FreezeFrame, AudioSource, SetActive, Destroy, Enable,
    TimescaleModifier, InstantiateObject
  label: display name shown in inspector. active: whether this feedback runs on play.
  chance [0-100]: probability this feedback fires each play (100 = always).
  targetObjectName: for transform-based feedbacks (Position, Scale, Rotation, Light, Particles, Flicker),
    sets the target automatically using GetComponent on the named GameObject.
  After adding, use feel-configure-player to re-initialize if needed.
---

# Feel / Add Feedback to Player

## How to Call

```bash
unity-mcp-cli run-tool feel-add-feedback --input '{
  "gameObjectName": "string_value",
  "feedbackType": "string_value",
  "label": "string_value",
  "active": false,
  "chance": 0,
  "targetObjectName": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool feel-add-feedback --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool feel-add-feedback --input-file - <<'EOF'
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
| `feedbackType` | `string` | Yes | Feedback type to add. E.g.: CameraShake, Position, Scale, Rotation, Light, Particles, Flash, Flicker, FreezeFrame, AudioSource, TimescaleModifier. |
| `label` | `string` | No | Display label for this feedback in the inspector. |
| `active` | `boolean` | No | Whether this feedback is active. |
| `chance` | `number` | No | Probability this feedback fires [0-100]. 100 = always. |
| `targetObjectName` | `string` | No | Optional: name of a GameObject to auto-assign as this feedback's target (for transform/light/particle feedbacks). |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
    },
    "feedbackType": {
      "type": "string"
    },
    "label": {
      "type": "string"
    },
    "active": {
      "type": "boolean"
    },
    "chance": {
      "type": "number"
    },
    "targetObjectName": {
      "type": "string"
    }
  },
  "required": [
    "gameObjectName",
    "feedbackType"
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

