---
name: uc-configure-locomotion
description: |-
  Configures UltimateCharacterLocomotion properties on a character.
  Only provided parameters are changed; others are left as-is.
  Use 'uc-query' first to see the current configuration.
  All UCC API access uses reflection for resilience.
---

# UCC / Configure Locomotion

## How to Call

```bash
unity-mcp-cli run-tool uc-configure-locomotion --input '{
  "gameObjectName": "string_value",
  "mass": "string_value",
  "skinWidth": "string_value",
  "useGravity": "string_value",
  "gravityMagnitude": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool uc-configure-locomotion --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool uc-configure-locomotion --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the GameObject with UltimateCharacterLocomotion component. |
| `mass` | `any` | No | Rigidbody mass. Null to keep current. |
| `skinWidth` | `any` | No | Character skin width for collision detection. Null to keep current. |
| `useGravity` | `any` | No | Whether gravity is applied. Null to keep current. |
| `gravityMagnitude` | `any` | No | Gravity magnitude (positive = downward force). Null to keep current. |

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
    "skinWidth": {
      "$ref": "#/$defs/System.Single"
    },
    "useGravity": {
      "$ref": "#/$defs/System.Boolean"
    },
    "gravityMagnitude": {
      "$ref": "#/$defs/System.Single"
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

