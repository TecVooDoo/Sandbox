---
name: bd-set-variable
description: Get or set a SharedVariable on a BehaviorTree by name.
---

# Behavior Designer / Set Variable

## How to Call

```bash
unity-mcp-cli run-tool bd-set-variable --input '{
  "gameObjectName": "string_value",
  "variableName": "string_value",
  "action": "string_value",
  "value": "string_value",
  "valueType": "string_value",
  "treeIndex": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool bd-set-variable --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool bd-set-variable --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the GameObject with BehaviorTree. |
| `variableName` | `string` | Yes | Name of the shared variable. |
| `action` | `string` | No | Action: 'get' or 'set'. Default 'get'. |
| `value` | `string` | No | Value to set (for 'set' action). Parsed based on valueType. |
| `valueType` | `string` | No | Type hint: 'bool', 'float', 'int', 'string', 'vector3'. Default 'string'. |
| `treeIndex` | `any` | No | Index of the tree if multiple. Default 0. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
    },
    "variableName": {
      "type": "string"
    },
    "action": {
      "type": "string"
    },
    "value": {
      "type": "string"
    },
    "valueType": {
      "type": "string"
    },
    "treeIndex": {
      "$ref": "#/$defs/System.Int32"
    }
  },
  "$defs": {
    "System.Int32": {
      "type": "integer"
    }
  },
  "required": [
    "gameObjectName",
    "variableName"
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

