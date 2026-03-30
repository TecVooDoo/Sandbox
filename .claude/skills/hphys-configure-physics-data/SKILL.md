---
name: hphys-configure-physics-data
description: |-
  Adds (if missing) and configures a PhysicsData component.
  PhysicsData is the base component for all Heathen physics -- add it first.
  volume and cross-section values drive buoyancy and drag calculations.
  If customHullMeshName is provided, assigns a mesh by that name from MeshFilter children.
  Call without arguments to simply add PhysicsData to a GameObject.
---

# Heathen Physics / Configure PhysicsData

## How to Call

```bash
unity-mcp-cli run-tool hphys-configure-physics-data --input '{
  "gameObjectName": "string_value",
  "volume": "string_value",
  "area": "string_value",
  "xCrossSection": "string_value",
  "yCrossSection": "string_value",
  "zCrossSection": "string_value",
  "debug": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool hphys-configure-physics-data --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool hphys-configure-physics-data --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the GameObject to add PhysicsData to. |
| `volume` | `any` | No | Manual volume override (world units cubed). Leave null to auto-calculate. |
| `area` | `any` | No | Manual surface area override. Leave null to auto-calculate. |
| `xCrossSection` | `any` | No | Cross-section along X axis (for drag). Leave null to auto-calculate. |
| `yCrossSection` | `any` | No | Cross-section along Y axis (for drag). Leave null to auto-calculate. |
| `zCrossSection` | `any` | No | Cross-section along Z axis (for drag). Leave null to auto-calculate. |
| `debug` | `any` | No | Enable debug visualization. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
    },
    "volume": {
      "$ref": "#/$defs/System.Single"
    },
    "area": {
      "$ref": "#/$defs/System.Single"
    },
    "xCrossSection": {
      "$ref": "#/$defs/System.Single"
    },
    "yCrossSection": {
      "$ref": "#/$defs/System.Single"
    },
    "zCrossSection": {
      "$ref": "#/$defs/System.Single"
    },
    "debug": {
      "$ref": "#/$defs/System.Boolean"
    }
  },
  "$defs": {
    "System.Single": {
      "type": "number"
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

