---
name: retarget-batch-bake
description: |-
  Batch-retargets animation clips using a RetargetProfile asset.
  Takes a folder of source AnimationClips and bakes retargeted versions to an output folder.
  The RetargetProfile must already be configured with source/target characters and rigs.
  Use this for retargeting animations between different character skeletons (e.g. polyperfect to Malbers AC).
---

# Retarget Pro / Batch Bake Animations

## How to Call

```bash
unity-mcp-cli run-tool retarget-batch-bake --input '{
  "profilePath": "string_value",
  "sourceFolder": "string_value",
  "outputFolder": "string_value",
  "frameRate": 0,
  "copyClipSettings": false,
  "useRootMotion": false,
  "keyframeAll": false,
  "maxClips": 0
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool retarget-batch-bake --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool retarget-batch-bake --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `profilePath` | `string` | Yes | Asset path to the RetargetProfile SO (e.g. 'Assets/_Sandbox/_AQS/Data/Retarget/PolyToAC.asset'). |
| `sourceFolder` | `string` | Yes | Folder containing source AnimationClip assets to retarget (e.g. 'Assets/polyperfect/Low Poly Animated Animals/Animations/Wolf'). |
| `outputFolder` | `string` | Yes | Output folder for retargeted clips (e.g. 'Assets/_Sandbox/_AQS/Animations/Retargeted'). Created if it doesn't exist. |
| `frameRate` | `number` | No | Frame rate for baked animations (24-240). Default 30. |
| `copyClipSettings` | `boolean` | No | Copy clip settings (loop time, bake into pose, events). Default true. |
| `useRootMotion` | `boolean` | No | Bake root motion curves. Default true. |
| `keyframeAll` | `boolean` | No | Keyframe all bones (true) or optimize curves (false). Default true. |
| `maxClips` | `integer` | No | Max clips to process (0 = all). Useful for testing with a few clips first. Default 0. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "profilePath": {
      "type": "string"
    },
    "sourceFolder": {
      "type": "string"
    },
    "outputFolder": {
      "type": "string"
    },
    "frameRate": {
      "type": "number"
    },
    "copyClipSettings": {
      "type": "boolean"
    },
    "useRootMotion": {
      "type": "boolean"
    },
    "keyframeAll": {
      "type": "boolean"
    },
    "maxClips": {
      "type": "integer"
    }
  },
  "required": [
    "profilePath",
    "sourceFolder",
    "outputFolder"
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
      "$ref": "#/$defs/MCPTools.RetargetPro.Editor.Tool_RetargetPro+BatchBakeResponse"
    }
  },
  "$defs": {
    "MCPTools.RetargetPro.Editor.Tool_RetargetPro+BatchBakeResponse": {
      "type": "object",
      "properties": {
        "profilePath": {
          "type": "string",
          "description": "Profile asset path used"
        },
        "sourceFolder": {
          "type": "string",
          "description": "Source animation folder"
        },
        "outputFolder": {
          "type": "string",
          "description": "Output folder for retargeted clips"
        },
        "totalClipsFound": {
          "type": "integer",
          "description": "Total clips found in source folder"
        },
        "processed": {
          "type": "integer",
          "description": "Successfully processed clips"
        },
        "failed": {
          "type": "integer",
          "description": "Failed clips"
        },
        "details": {
          "type": "string",
          "description": "Per-clip results"
        }
      },
      "required": [
        "totalClipsFound",
        "processed",
        "failed"
      ]
    }
  },
  "required": [
    "result"
  ]
}
```

