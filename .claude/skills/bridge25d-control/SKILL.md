---
name: bridge25d-control
description: |-
  Controls bridge state: recreate, break, or toggle physics.
  Actions: 'recreate' rebuilds the bridge from its spline, 'break' breaks the bridge
  at a normalized position (0-1 from start to end), 'physics-on'/'physics-off' toggles
  physics simulation on all parts, 'add-proximity' adds a proximity trigger,
  'remove-proximity' removes the proximity trigger.
---

# 2.5D Bridge / Control

## How to Call

```bash
unity-mcp-cli run-tool bridge25d-control --input '{
  "gameObjectName": "string_value",
  "action": "string_value",
  "breakPosition": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool bridge25d-control --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool bridge25d-control --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the Bridge25D GameObject. |
| `action` | `string` | Yes | Action: recreate, break, physics-on, physics-off, add-proximity, remove-proximity. |
| `breakPosition` | `any` | No | For 'break' action: normalized position [0-1] along bridge. |

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
    "breakPosition": {
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

