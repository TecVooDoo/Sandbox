---
name: bd-tick
description: Manually ticks a BehaviorTree. Only works in play mode with UpdateMode set to Manual.
---

# Behavior Designer / Manual Tick

## How to Call

```bash
unity-mcp-cli run-tool bd-tick --input '{
  "gameObjectName": "string_value",
  "count": "string_value",
  "treeIndex": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool bd-tick --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool bd-tick --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the GameObject with BehaviorTree component(s). |
| `count` | `any` | No | Number of ticks to perform. Default 1. |
| `treeIndex` | `any` | No | Index of the tree if multiple BehaviorTree components exist. Default 0. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
    },
    "count": {
      "$ref": "#/$defs/System.Int32"
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

