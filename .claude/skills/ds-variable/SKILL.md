---
name: ds-variable
description: |-
  Get or set Dialogue System Lua variables.
  For 'get': reads the current value of a variable via Lua.
  For 'set': sets a variable value, auto-detecting type (bool, number, string).
  Variable names should match exactly as defined in the dialogue database.
---

# Dialogue System / Variable

## How to Call

```bash
unity-mcp-cli run-tool ds-variable --input '{
  "variableName": "string_value",
  "action": "string_value",
  "value": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool ds-variable --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool ds-variable --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `variableName` | `string` | Yes | Name of the Dialogue System variable (e.g. 'PlayerName', 'QuestProgress'). |
| `action` | `string` | No | Action: 'get' or 'set'. Default 'get'. |
| `value` | `string` | No | Value to set (for 'set' action). Auto-detects type: 'true'/'false' = bool, numeric = number, otherwise = string. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "variableName": {
      "type": "string"
    },
    "action": {
      "type": "string"
    },
    "value": {
      "type": "string"
    }
  },
  "required": [
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

