---
name: astar-scan
description: |-
  Trigger a graph scan or runtime graph update.
  action='scan': Full rescan of all graphs or a specific graph by index.
  action='update': Bounds-based graph update at a specific position. Can modify walkability,
  penalty, and tags within the update bounds. Useful for dynamic obstacle changes.
---

# A* Pathfinding / Scan Graphs

## How to Call

```bash
unity-mcp-cli run-tool astar-scan --input '{
  "action": "string_value",
  "graphIndex": "string_value",
  "boundsX": "string_value",
  "boundsY": "string_value",
  "boundsZ": "string_value",
  "boundsSize": "string_value",
  "penaltyDelta": "string_value",
  "setWalkability": "string_value",
  "setTag": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool astar-scan --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool astar-scan --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `action` | `string` | Yes | Action to perform: 'scan' (full rescan) or 'update' (bounds-based update). |
| `graphIndex` | `any` | No | Specific graph index to scan (null = all graphs). Only used with 'scan' action. |
| `boundsX` | `any` | No | Center X of update bounds (for 'update' action). |
| `boundsY` | `any` | No | Center Y of update bounds (for 'update' action). |
| `boundsZ` | `any` | No | Center Z of update bounds (for 'update' action). |
| `boundsSize` | `any` | No | Size of the cubic update bounds (default 10). |
| `penaltyDelta` | `any` | No | Penalty delta to apply in the update area. |
| `setWalkability` | `any` | No | Set walkability of nodes in update area. |
| `setTag` | `any` | No | Tag value (0-31) to assign to nodes in update area. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "action": {
      "type": "string"
    },
    "graphIndex": {
      "$ref": "#/$defs/System.Int32"
    },
    "boundsX": {
      "$ref": "#/$defs/System.Single"
    },
    "boundsY": {
      "$ref": "#/$defs/System.Single"
    },
    "boundsZ": {
      "$ref": "#/$defs/System.Single"
    },
    "boundsSize": {
      "$ref": "#/$defs/System.Single"
    },
    "penaltyDelta": {
      "$ref": "#/$defs/System.Int32"
    },
    "setWalkability": {
      "$ref": "#/$defs/System.Boolean"
    },
    "setTag": {
      "$ref": "#/$defs/System.Int32"
    }
  },
  "$defs": {
    "System.Int32": {
      "type": "integer"
    },
    "System.Single": {
      "type": "number"
    },
    "System.Boolean": {
      "type": "boolean"
    }
  },
  "required": [
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

