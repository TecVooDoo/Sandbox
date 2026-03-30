---
name: rayfire-add-shatter
description: |-
  Adds a RayfireShatter component for pre-fragmenting a mesh.
  Choose a fragmentation algorithm and configure its parameters.
  After adding, call Fragment() in the editor to generate fragments.
---

# RayFire / Add Shatter

## How to Call

```bash
unity-mcp-cli run-tool rayfire-add-shatter --input '{
  "targetRef": "string_value",
  "fragmentType": "string_value",
  "fragmentCount": 0,
  "brickColumns": 0,
  "brickRows": 0,
  "radialRings": 0,
  "radialRays": 0,
  "colorPreview": false
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool rayfire-add-shatter --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool rayfire-add-shatter --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `targetRef` | `any` | Yes | Reference to the target GameObject. |
| `fragmentType` | `string` | No | Fragmentation type: 'Voronoi', 'Splinters', 'Slabs', 'Radial', 'Hexagon', 'Bricks', 'Voxels', 'Slices', 'Decompose'. Default 'Voronoi'. |
| `fragmentCount` | `integer` | No | Number of fragments (for Voronoi). Default 10. |
| `brickColumns` | `integer` | No | For Bricks: number of columns. Default 3. |
| `brickRows` | `integer` | No | For Bricks: number of rows. Default 3. |
| `radialRings` | `integer` | No | For Radial: number of rings. Default 3. |
| `radialRays` | `integer` | No | For Radial: number of rays. Default 6. |
| `colorPreview` | `boolean` | No | Enable fragment preview coloring. Default false. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "targetRef": {
      "$ref": "#/$defs/com.IvanMurzak.Unity.MCP.Runtime.Data.GameObjectRef"
    },
    "fragmentType": {
      "type": "string"
    },
    "fragmentCount": {
      "type": "integer"
    },
    "brickColumns": {
      "type": "integer"
    },
    "brickRows": {
      "type": "integer"
    },
    "radialRings": {
      "type": "integer"
    },
    "radialRays": {
      "type": "integer"
    },
    "colorPreview": {
      "type": "boolean"
    }
  },
  "$defs": {
    "System.Type": {
      "type": "string"
    },
    "com.IvanMurzak.Unity.MCP.Runtime.Data.GameObjectRef": {
      "type": "object",
      "properties": {
        "instanceID": {
          "type": "integer",
          "description": "instanceID of the UnityEngine.Object. If it is '0' and 'path', 'name', 'assetPath' and 'assetGuid' is not provided, empty or null, then it will be used as 'null'. Priority: 1 (Recommended)"
        },
        "path": {
          "type": "string",
          "description": "Path of a GameObject in the hierarchy Sample 'character/hand/finger/particle'. Priority: 2."
        },
        "name": {
          "type": "string",
          "description": "Name of a GameObject in hierarchy. Priority: 3."
        },
        "assetType": {
          "$ref": "#/$defs/System.Type",
          "description": "Type of the asset."
        },
        "assetPath": {
          "type": "string",
          "description": "Path to the asset within the project. Starts with 'Assets/'"
        },
        "assetGuid": {
          "type": "string",
          "description": "Unique identifier for the asset."
        }
      },
      "required": [
        "instanceID"
      ],
      "description": "Find GameObject in opened Prefab or in the active Scene."
    }
  },
  "required": [
    "targetRef"
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
      "$ref": "#/$defs/MCPTools.RayFire.Editor.Tool_RayFire+AddShatterResponse"
    }
  },
  "$defs": {
    "MCPTools.RayFire.Editor.Tool_RayFire+AddShatterResponse": {
      "type": "object",
      "properties": {
        "gameObjectName": {
          "type": "string",
          "description": "Name of the GameObject"
        },
        "instanceId": {
          "type": "integer",
          "description": "Instance ID"
        },
        "fragmentType": {
          "type": "string",
          "description": "Fragment type configured"
        },
        "configured": {
          "type": "boolean",
          "description": "Configuration applied"
        }
      },
      "required": [
        "instanceId",
        "configured"
      ]
    }
  },
  "required": [
    "result"
  ]
}
```

