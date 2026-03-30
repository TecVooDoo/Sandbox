---
name: astar-configure-grid
description: |-
  Configure a GridGraph in the A* Pathfinding system.
  Sets grid dimensions, node size, center position, slope/step settings, erosion, and neighbour mode.
  Does NOT trigger a scan -- call astar-scan afterwards to apply changes.
---

# A* Pathfinding / Configure Grid Graph

## How to Call

```bash
unity-mcp-cli run-tool astar-configure-grid --input '{
  "graphIndex": "string_value",
  "width": "string_value",
  "depth": "string_value",
  "nodeSize": "string_value",
  "centerX": "string_value",
  "centerY": "string_value",
  "centerZ": "string_value",
  "maxSlope": "string_value",
  "maxStepHeight": "string_value",
  "erodeIterations": "string_value",
  "neighbours": "string_value",
  "cutCorners": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool astar-configure-grid --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool astar-configure-grid --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `graphIndex` | `any` | No | Graph index in AstarPath.data.graphs (default 0). |
| `width` | `any` | No | Grid width in nodes. |
| `depth` | `any` | No | Grid depth in nodes. |
| `nodeSize` | `any` | No | World units per node. |
| `centerX` | `any` | No | Grid center X position. |
| `centerY` | `any` | No | Grid center Y position. |
| `centerZ` | `any` | No | Grid center Z position. |
| `maxSlope` | `any` | No | Max walkable slope in degrees. |
| `maxStepHeight` | `any` | No | Max step/climb height in world units. |
| `erodeIterations` | `any` | No | Obstacle erosion iterations (margin around unwalkable). |
| `neighbours` | `string` | No | Neighbour connection mode: Four, Eight, or Six. |
| `cutCorners` | `any` | No | Allow diagonal movement to cut corners. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "graphIndex": {
      "$ref": "#/$defs/System.Int32"
    },
    "width": {
      "$ref": "#/$defs/System.Int32"
    },
    "depth": {
      "$ref": "#/$defs/System.Int32"
    },
    "nodeSize": {
      "$ref": "#/$defs/System.Single"
    },
    "centerX": {
      "$ref": "#/$defs/System.Single"
    },
    "centerY": {
      "$ref": "#/$defs/System.Single"
    },
    "centerZ": {
      "$ref": "#/$defs/System.Single"
    },
    "maxSlope": {
      "$ref": "#/$defs/System.Single"
    },
    "maxStepHeight": {
      "$ref": "#/$defs/System.Single"
    },
    "erodeIterations": {
      "$ref": "#/$defs/System.Int32"
    },
    "neighbours": {
      "type": "string"
    },
    "cutCorners": {
      "$ref": "#/$defs/System.Boolean"
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
  }
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

