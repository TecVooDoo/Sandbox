---
name: hphys-configure-buoyancy
description: |-
  Adds (if missing) and configures a BuoyantBody component.
  BuoyantBody requires a PhysicsData component on the same GameObject.
  buoyantMagnitudeY: the upward buoyancy force (default -19.6 = 2x gravity, opposes sinking).
  calculationMode: Fast (best perf), Simple (moderate), Detailed (most accurate).
  Assign the water surface via activeSurfaceObjectName -- the named GameObject must have a SurfaceTool component.
---

# Heathen Physics / Configure Buoyancy

## How to Call

```bash
unity-mcp-cli run-tool hphys-configure-buoyancy --input '{
  "gameObjectName": "string_value",
  "buoyantMagnitudeY": "string_value",
  "calculationMode": "string_value",
  "activeSurfaceObjectName": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool hphys-configure-buoyancy --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool hphys-configure-buoyancy --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the GameObject (must already have PhysicsData). |
| `buoyantMagnitudeY` | `any` | No | Buoyancy upward force Y component (default -19.6 = 2x gravity counter). Typically negative. |
| `calculationMode` | `string` | No | Buoyancy calculation mode: Fast, Simple, or Detailed. |
| `activeSurfaceObjectName` | `string` | No | Name of the GameObject with a SurfaceTool component (water surface). Optional. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
    },
    "buoyantMagnitudeY": {
      "$ref": "#/$defs/System.Single"
    },
    "calculationMode": {
      "type": "string"
    },
    "activeSurfaceObjectName": {
      "type": "string"
    }
  },
  "$defs": {
    "System.Single": {
      "type": "number"
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

