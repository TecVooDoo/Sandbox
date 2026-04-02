---
name: bd-control
description: "Control behavior tree execution: start, stop, pause, unpause, or restart a BehaviorTree on a GameObject."
---

# Behavior Designer / Control Tree

## How to Call

```bash
unity-mcp-cli run-tool bd-control --input '{
  "gameObjectName": "string_value",
  "action": "string_value",
  "treeIndex": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool bd-control --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool bd-control --input-file - <<'EOF'
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
| `action` | `string` | Yes | Action to perform: 'start', 'stop', 'pause', 'unpause', or 'restart'. |
| `treeIndex` | `any` | No | Index of the tree if multiple BehaviorTree components exist. Default 0. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
    },
    "action": {
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
    "action"
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

