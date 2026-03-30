---
name: astar-configure-seeker
description: |-
  Configure a Seeker component on a GameObject.
  Sets traversable tag bitmask and per-tag cost penalties.
  traversableTags: bitmask where bit N enables tag N (e.g. -1 = all tags, 1 = only tag 0, 3 = tags 0+1).
  tagCosts: comma-separated penalty values for tags 0-31 (e.g. '0,0,0,1000,0,5000' penalizes tags 3 and 5).
---

# A* Pathfinding / Configure Seeker

## How to Call

```bash
unity-mcp-cli run-tool astar-configure-seeker --input '{
  "gameObjectName": "string_value",
  "traversableTags": "string_value",
  "tagCosts": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool astar-configure-seeker --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool astar-configure-seeker --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the GameObject with a Seeker component. |
| `traversableTags` | `any` | No | Bitmask of traversable tags (-1 = all, 1 = tag0 only, etc.). |
| `tagCosts` | `string` | No | Comma-separated cost penalties for tags 0-31 (e.g. '0,0,0,1000'). |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
    },
    "traversableTags": {
      "$ref": "#/$defs/System.Int32"
    },
    "tagCosts": {
      "type": "string"
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

