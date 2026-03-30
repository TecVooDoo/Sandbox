---
name: retarget-create-profile
description: |-
  Creates a RetargetProfile ScriptableObject asset for animation retargeting.
  A profile defines the source and target characters, their rigs, and reference poses.
  Both characters must have KRigComponent attached and KRig assets created.
  After creating a profile, add retarget features via the Inspector, then use 'retarget-batch-bake' to process animations.
---

# Retarget Pro / Create Profile

## How to Call

```bash
unity-mcp-cli run-tool retarget-create-profile --input '{
  "assetPath": "string_value",
  "sourceCharacterPath": "string_value",
  "targetCharacterPath": "string_value",
  "sourceRigPath": "string_value",
  "targetRigPath": "string_value",
  "sourcePosePath": "string_value",
  "targetPosePath": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool retarget-create-profile --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool retarget-create-profile --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `assetPath` | `string` | Yes | Asset path for the new profile (e.g. 'Assets/_Sandbox/_AQS/Data/Retarget/PolyToAC.asset'). |
| `sourceCharacterPath` | `string` | Yes | Asset path to the source character prefab (retarget FROM). Must have KRigComponent. |
| `targetCharacterPath` | `string` | Yes | Asset path to the target character prefab (retarget TO). Must have KRigComponent. |
| `sourceRigPath` | `string` | No | Asset path to the source KRig asset. Null to skip (set manually in Inspector). |
| `targetRigPath` | `string` | No | Asset path to the target KRig asset. Null to skip (set manually in Inspector). |
| `sourcePosePath` | `string` | No | Asset path to the source reference pose AnimationClip (A-pose or T-pose). Null to skip. |
| `targetPosePath` | `string` | No | Asset path to the target reference pose AnimationClip (A-pose or T-pose). Null to skip. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "assetPath": {
      "type": "string"
    },
    "sourceCharacterPath": {
      "type": "string"
    },
    "targetCharacterPath": {
      "type": "string"
    },
    "sourceRigPath": {
      "type": "string"
    },
    "targetRigPath": {
      "type": "string"
    },
    "sourcePosePath": {
      "type": "string"
    },
    "targetPosePath": {
      "type": "string"
    }
  },
  "required": [
    "assetPath",
    "sourceCharacterPath",
    "targetCharacterPath"
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
      "$ref": "#/$defs/MCPTools.RetargetPro.Editor.Tool_RetargetPro+CreateProfileResponse"
    }
  },
  "$defs": {
    "MCPTools.RetargetPro.Editor.Tool_RetargetPro+CreateProfileResponse": {
      "type": "object",
      "properties": {
        "assetPath": {
          "type": "string",
          "description": "Asset path where profile was saved"
        },
        "sourceCharacter": {
          "type": "string",
          "description": "Source character name"
        },
        "targetCharacter": {
          "type": "string",
          "description": "Target character name"
        },
        "hasSourceRig": {
          "type": "boolean",
          "description": "Source rig assigned"
        },
        "hasTargetRig": {
          "type": "boolean",
          "description": "Target rig assigned"
        },
        "hasSourcePose": {
          "type": "boolean",
          "description": "Source pose assigned"
        },
        "hasTargetPose": {
          "type": "boolean",
          "description": "Target pose assigned"
        }
      },
      "required": [
        "hasSourceRig",
        "hasTargetRig",
        "hasSourcePose",
        "hasTargetPose"
      ]
    }
  },
  "required": [
    "result"
  ]
}
```

