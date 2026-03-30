---
name: rope-configure-simulation
description: |-
  Sets simulation parameters on a Rope component.
  All parameters are optional -- only provided values are changed.
  stiffness [0.01-1.0]: rope rigidity (higher = stiffer, less droopy).
  energyLoss [0-1.0]: damping/air resistance (higher = settles faster).
  gravityMultiplier [0-1.0]: gravity influence scale (0=weightless).
  substeps [1-10]: physics substeps per frame (higher = more stable but slower).
  solverIterations [1-32]: constraint solver passes (higher = less stretching).
  lengthMultiplier [0-2.0]: dynamic extension/retraction of rope length.
---

# Rope Toolkit / Configure Simulation

## How to Call

```bash
unity-mcp-cli run-tool rope-configure-simulation --input '{
  "gameObjectName": "string_value",
  "stiffness": "string_value",
  "energyLoss": "string_value",
  "gravityMultiplier": "string_value",
  "substeps": "string_value",
  "solverIterations": "string_value",
  "lengthMultiplier": "string_value",
  "resolution": "string_value",
  "enabled": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool rope-configure-simulation --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool rope-configure-simulation --input-file - <<'EOF'
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
| `stiffness` | `any` | No | Rope stiffness [0.01-1.0]. Higher = less droopy. |
| `energyLoss` | `any` | No | Energy loss / damping [0-1.0]. Higher = settles faster. |
| `gravityMultiplier` | `any` | No | Gravity influence scale [0-1.0]. 0 = weightless. |
| `substeps` | `any` | No | Physics substeps per frame [1-10]. |
| `solverIterations` | `any` | No | Constraint solver iterations [1-32]. |
| `lengthMultiplier` | `any` | No | Rope length multiplier [0-2.0]. 1 = normal length. |
| `resolution` | `any` | No | Particles per meter. Higher = smoother, more expensive. |
| `enabled` | `any` | No | Enable/disable simulation independently of rendering. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
    },
    "stiffness": {
      "$ref": "#/$defs/System.Single"
    },
    "energyLoss": {
      "$ref": "#/$defs/System.Single"
    },
    "gravityMultiplier": {
      "$ref": "#/$defs/System.Single"
    },
    "substeps": {
      "$ref": "#/$defs/System.Int32"
    },
    "solverIterations": {
      "$ref": "#/$defs/System.Int32"
    },
    "lengthMultiplier": {
      "$ref": "#/$defs/System.Single"
    },
    "resolution": {
      "$ref": "#/$defs/System.Single"
    },
    "enabled": {
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

