---
name: uc-configure-attribute
description: |-
  Configures a character attribute (Health, Stamina, etc.) on a UCC character.
  Requires an AttributeManager component. Only provided parameters are changed.
  Use 'uc-query' first to see available attributes and their current values.
  All UCC API access uses reflection for resilience.
---

# UCC / Configure Attribute

## How to Call

```bash
unity-mcp-cli run-tool uc-configure-attribute --input '{
  "gameObjectName": "string_value",
  "attributeName": "string_value",
  "value": "string_value",
  "maxValue": "string_value",
  "minValue": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool uc-configure-attribute --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool uc-configure-attribute --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the GameObject with AttributeManager component. |
| `attributeName` | `string` | Yes | Attribute name to configure (e.g. 'Health', 'Stamina'). Case-insensitive match. |
| `value` | `any` | No | Set the current value. Null to keep current. |
| `maxValue` | `any` | No | Set the maximum value. Null to keep current. |
| `minValue` | `any` | No | Set the minimum value. Null to keep current. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
    },
    "attributeName": {
      "type": "string"
    },
    "value": {
      "$ref": "#/$defs/System.Single"
    },
    "maxValue": {
      "$ref": "#/$defs/System.Single"
    },
    "minValue": {
      "$ref": "#/$defs/System.Single"
    }
  },
  "$defs": {
    "System.Single": {
      "type": "number"
    }
  },
  "required": [
    "gameObjectName",
    "attributeName"
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

