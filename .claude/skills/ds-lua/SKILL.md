---
name: ds-lua
description: |-
  Executes arbitrary Lua code in the Dialogue System's Lua environment.
  Returns the result as a string, along with type information (bool, float, string, table).
  Use single quotes for strings inside Lua code to avoid escaping issues.
  Examples: 'return Variable["PlayerName"]', 'return GetRelationship(1, 2, "romantic")'.
---

# Dialogue System / Lua Execute

## How to Call

```bash
unity-mcp-cli run-tool ds-lua --input '{
  "code": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool ds-lua --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool ds-lua --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `code` | `string` | Yes | Lua code to execute in the Dialogue System Lua environment. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "code": {
      "type": "string"
    }
  },
  "required": [
    "code"
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

