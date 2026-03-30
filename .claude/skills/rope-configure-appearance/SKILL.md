---
name: rope-configure-appearance
description: |-
  Sets visual properties on a Rope component.
  radius [0.001-1.0]: visual rope thickness in world units.
  radialVertices [3-32]: mesh segments around the rope circumference (higher = rounder, more expensive).
  isLoop: connect end point back to start point.
  materialName: name of a material already in the scene or project to assign (optional).
---

# Rope Toolkit / Configure Appearance

## How to Call

```bash
unity-mcp-cli run-tool rope-configure-appearance --input '{
  "gameObjectName": "string_value",
  "radius": "string_value",
  "radialVertices": "string_value",
  "isLoop": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool rope-configure-appearance --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool rope-configure-appearance --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the GameObject with the Rope component. |
| `radius` | `any` | No | Rope visual radius in world units [0.001-1.0]. |
| `radialVertices` | `any` | No | Radial mesh vertex count [3-32]. Higher = rounder. |
| `isLoop` | `any` | No | Whether rope forms a loop (end connects to start). |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
    },
    "radius": {
      "$ref": "#/$defs/System.Single"
    },
    "radialVertices": {
      "$ref": "#/$defs/System.Int32"
    },
    "isLoop": {
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

