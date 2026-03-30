---
name: hphys-configure-force-receiver
description: |-
  Adds (if missing) and configures a ForceEffectReceiver component.
  ForceEffectReceiver makes a rigidbody respond to ForceEffectField forces.
  useLinear: whether linear forces are applied.
  useAngular: whether angular (torque) forces are applied.
  sensitivity: multiplier on all incoming forces (1.0 = normal, 0.5 = half effect).
  Requires a PhysicsData component on the same GameObject.
---

# Heathen Physics / Configure Force Receiver

## How to Call

```bash
unity-mcp-cli run-tool hphys-configure-force-receiver --input '{
  "gameObjectName": "string_value",
  "useLinear": "string_value",
  "useAngular": "string_value",
  "sensitivity": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool hphys-configure-force-receiver --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool hphys-configure-force-receiver --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the GameObject to add ForceEffectReceiver to. |
| `useLinear` | `any` | No | Accept linear (positional) forces from fields. |
| `useAngular` | `any` | No | Accept angular (torque) forces from fields. |
| `sensitivity` | `any` | No | Sensitivity multiplier for all incoming forces [0-∞]. Default 1.0. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
    },
    "useLinear": {
      "$ref": "#/$defs/System.Boolean"
    },
    "useAngular": {
      "$ref": "#/$defs/System.Boolean"
    },
    "sensitivity": {
      "$ref": "#/$defs/System.Single"
    }
  },
  "$defs": {
    "System.Boolean": {
      "type": "boolean"
    },
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

