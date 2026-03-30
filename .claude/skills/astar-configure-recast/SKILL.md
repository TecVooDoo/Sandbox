---
name: astar-configure-recast
description: |-
  Configure a RecastGraph in the A* Pathfinding system.
  Sets character radius, walkable height/climb, slope, voxel resolution, contour error,
  region size, tiling options. Does NOT trigger a scan -- call astar-scan afterwards.
---

# A* Pathfinding / Configure Recast Graph

## How to Call

```bash
unity-mcp-cli run-tool astar-configure-recast --input '{
  "graphIndex": "string_value",
  "characterRadius": "string_value",
  "walkableHeight": "string_value",
  "walkableClimb": "string_value",
  "maxSlope": "string_value",
  "cellSize": "string_value",
  "contourMaxError": "string_value",
  "minRegionSize": "string_value",
  "useTiles": "string_value",
  "editorTileSize": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool astar-configure-recast --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool astar-configure-recast --input-file - <<'EOF'
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
| `characterRadius` | `any` | No | Agent radius for navmesh erosion. |
| `walkableHeight` | `any` | No | Minimum walkable height (character height). |
| `walkableClimb` | `any` | No | Maximum step/climb height. |
| `maxSlope` | `any` | No | Maximum walkable slope in degrees. |
| `cellSize` | `any` | No | Voxel cell size (smaller = more precise, slower). |
| `contourMaxError` | `any` | No | Max edge simplification error. |
| `minRegionSize` | `any` | No | Minimum region size to keep. |
| `useTiles` | `any` | No | Enable tiling for large worlds. |
| `editorTileSize` | `any` | No | Tile size in voxels (when tiling enabled). |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "graphIndex": {
      "$ref": "#/$defs/System.Int32"
    },
    "characterRadius": {
      "$ref": "#/$defs/System.Single"
    },
    "walkableHeight": {
      "$ref": "#/$defs/System.Single"
    },
    "walkableClimb": {
      "$ref": "#/$defs/System.Single"
    },
    "maxSlope": {
      "$ref": "#/$defs/System.Single"
    },
    "cellSize": {
      "$ref": "#/$defs/System.Single"
    },
    "contourMaxError": {
      "$ref": "#/$defs/System.Single"
    },
    "minRegionSize": {
      "$ref": "#/$defs/System.Int32"
    },
    "useTiles": {
      "$ref": "#/$defs/System.Boolean"
    },
    "editorTileSize": {
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

