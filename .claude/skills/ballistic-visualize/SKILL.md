---
name: ballistic-visualize
description: |-
  Adds (if missing) and configures a BallisticPathLineRender component for trajectory visualization.
  Requires a LineRenderer on the same GameObject (adds one if missing).
  gravityMode: None, Physics (use Physics.gravity), or Custom (use customGravityY).
  Call Simulate() via script or set continuousRun=true to update every frame.
  This tool sets up the visualization component -- it does not trigger a simulation run.
---

# Heathen Ballistics / Visualize Trajectory

## How to Call

```bash
unity-mcp-cli run-tool ballistic-visualize --input '{
  "gameObjectName": "string_value",
  "resolution": "string_value",
  "maxLength": "string_value",
  "maxBounces": "string_value",
  "bounceDamping": "string_value",
  "gravityMode": "string_value",
  "customGravityY": "string_value",
  "continuousRun": "string_value",
  "runOnStart": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool ballistic-visualize --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool ballistic-visualize --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the GameObject to add BallisticPathLineRender to. |
| `resolution` | `any` | No | Simulation step size. Smaller = more accurate [0.01-0.5]. |
| `maxLength` | `any` | No | Max trajectory length in world units. |
| `maxBounces` | `any` | No | Max bounces to visualize. |
| `bounceDamping` | `any` | No | Velocity multiplier retained per bounce [0-1]. |
| `gravityMode` | `string` | No | Gravity mode: None, Physics, or Custom. |
| `customGravityY` | `any` | No | Custom gravity Y value (used when gravityMode=Custom). |
| `continuousRun` | `any` | No | Update trajectory every frame (true) or once (false). |
| `runOnStart` | `any` | No | Run simulation immediately on component Start. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
    },
    "resolution": {
      "$ref": "#/$defs/System.Single"
    },
    "maxLength": {
      "$ref": "#/$defs/System.Single"
    },
    "maxBounces": {
      "$ref": "#/$defs/System.Int32"
    },
    "bounceDamping": {
      "$ref": "#/$defs/System.Single"
    },
    "gravityMode": {
      "type": "string"
    },
    "customGravityY": {
      "$ref": "#/$defs/System.Single"
    },
    "continuousRun": {
      "$ref": "#/$defs/System.Boolean"
    },
    "runOnStart": {
      "$ref": "#/$defs/System.Boolean"
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

