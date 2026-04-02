---
name: bridge25d-configure
description: |-
  Configures physics, visuals, and damage on a Bridge25D component.
  Only provided parameters are changed; others are left as-is.
  Use 'bridge25d-query' first to see current values.
  Call 'bridge25d-control' with action='recreate' after configuring to apply changes.
---

# 2.5D Bridge / Configure

## How to Call

```bash
unity-mcp-cli run-tool bridge25d-configure --input '{
  "gameObjectName": "string_value",
  "mass": "string_value",
  "linearDrag": "string_value",
  "gravityScale": "string_value",
  "springDampingRatio": "string_value",
  "springFrequency": "string_value",
  "addSpringJointsEvery": "string_value",
  "damageTilBreak": "string_value",
  "massBroken": "string_value",
  "linearDragBroken": "string_value",
  "partLayerIfBroken": "string_value",
  "scale": "string_value",
  "widthVariation": "string_value",
  "randomRotationX": "string_value",
  "randomRotationY": "string_value",
  "startAwake": "string_value",
  "recreateOnReset": "string_value",
  "bridgeEdgePartOffset": "string_value",
  "bridgePartWidthInPrefab": "string_value",
  "bridgePartDepthInPrefab": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool bridge25d-configure --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool bridge25d-configure --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the Bridge25D GameObject. |
| `mass` | `any` | No | Mass per bridge plank. |
| `linearDrag` | `any` | No | Linear drag per plank (higher = less swing). |
| `gravityScale` | `any` | No | Gravity scale per plank. |
| `springDampingRatio` | `any` | No | Spring damping ratio [0-1]. |
| `springFrequency` | `any` | No | Spring frequency (higher = stiffer). |
| `addSpringJointsEvery` | `any` | No | Add spring joints every N parts. 0 = none. [0-5] |
| `damageTilBreak` | `any` | No | Damage threshold before break. |
| `massBroken` | `any` | No | Mass of broken parts. |
| `linearDragBroken` | `any` | No | Linear drag of broken parts. |
| `partLayerIfBroken` | `any` | No | Layer index for broken parts. |
| `scale` | `string` | No | Scale of bridge part meshes (x,y,z as 'x,y,z' string). |
| `widthVariation` | `any` | No | Width variation between planks [0-0.7]. |
| `randomRotationX` | `any` | No | Random X rotation per plank [0-10]. |
| `randomRotationY` | `any` | No | Random Y rotation per plank [0-10]. |
| `startAwake` | `any` | No | Wake physics on start (false = sleep until proximity). |
| `recreateOnReset` | `any` | No | Recreate bridge on checkpoint reset. |
| `bridgeEdgePartOffset` | `any` | No | Edge part outward offset along X. |
| `bridgePartWidthInPrefab` | `any` | No | Plank width in prefab (for spacing calculation). |
| `bridgePartDepthInPrefab` | `any` | No | Plank depth in prefab (Z axis). |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
    },
    "mass": {
      "$ref": "#/$defs/System.Single"
    },
    "linearDrag": {
      "$ref": "#/$defs/System.Single"
    },
    "gravityScale": {
      "$ref": "#/$defs/System.Single"
    },
    "springDampingRatio": {
      "$ref": "#/$defs/System.Single"
    },
    "springFrequency": {
      "$ref": "#/$defs/System.Single"
    },
    "addSpringJointsEvery": {
      "$ref": "#/$defs/System.Int32"
    },
    "damageTilBreak": {
      "$ref": "#/$defs/System.Single"
    },
    "massBroken": {
      "$ref": "#/$defs/System.Single"
    },
    "linearDragBroken": {
      "$ref": "#/$defs/System.Single"
    },
    "partLayerIfBroken": {
      "$ref": "#/$defs/System.Int32"
    },
    "scale": {
      "type": "string"
    },
    "widthVariation": {
      "$ref": "#/$defs/System.Single"
    },
    "randomRotationX": {
      "$ref": "#/$defs/System.Single"
    },
    "randomRotationY": {
      "$ref": "#/$defs/System.Single"
    },
    "startAwake": {
      "$ref": "#/$defs/System.Boolean"
    },
    "recreateOnReset": {
      "$ref": "#/$defs/System.Boolean"
    },
    "bridgeEdgePartOffset": {
      "$ref": "#/$defs/System.Single"
    },
    "bridgePartWidthInPrefab": {
      "$ref": "#/$defs/System.Single"
    },
    "bridgePartDepthInPrefab": {
      "$ref": "#/$defs/System.Single"
    }
  },
  "$defs": {
    "System.Single": {
      "type": "number"
    },
    "System.Int32": {
      "type": "integer"
    },
    "System.Boolean": {
      "type": "boolean"
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

