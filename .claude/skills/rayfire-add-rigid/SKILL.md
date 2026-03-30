---
name: rayfire-add-rigid
description: |-
  Adds a RayfireRigid component to a GameObject, making it destructible.
  Configure simulation type, demolition type, physics material, and damage settings.
  Use 'rayfire-add-shatter' afterward to configure fragmentation.
---

# RayFire / Add Rigid

## How to Call

```bash
unity-mcp-cli run-tool rayfire-add-rigid --input '{
  "targetRef": "string_value",
  "simulationType": "string_value",
  "demolitionType": "string_value",
  "objectType": "string_value",
  "physicsMaterial": "string_value",
  "mass": 0,
  "enableDamage": false,
  "maxDamage": 0,
  "collisionDamage": false,
  "useGravity": false,
  "maxDepth": 0,
  "fadeType": "string_value",
  "fadeLifetime": 0,
  "initialize": false
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool rayfire-add-rigid --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool rayfire-add-rigid --input-file - <<'EOF'
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
| `simulationType` | `string` | No | Simulation type: 'Dynamic', 'Sleeping', 'Inactive', 'Kinematic', 'Static'. Default 'Dynamic'. |
| `demolitionType` | `string` | No | Demolition type: 'None', 'Runtime', 'AwakePrecache', 'AwakePrefragment'. Default 'Runtime'. |
| `objectType` | `string` | No | Object type: 'Mesh', 'MeshRoot', 'ConnectedCluster', 'NestedCluster', 'SkinnedMesh'. Default 'Mesh'. |
| `physicsMaterial` | `string` | No | Physics material: 'HeavyMetal', 'LightMetal', 'DenseRock', 'PorousRock', 'Concrete', 'Brick', 'Glass', 'Rubber', 'Ice', 'Wood'. Default 'Concrete'. |
| `mass` | `number` | No | Mass value. Default 1. |
| `enableDamage` | `boolean` | No | Enable damage tracking. Default true. |
| `maxDamage` | `number` | No | Maximum damage before destruction. Default 100. |
| `collisionDamage` | `boolean` | No | Enable collision-based damage. Default true. |
| `useGravity` | `boolean` | No | Use gravity. Default true. |
| `maxDepth` | `integer` | No | Maximum demolition depth. Default 1. |
| `fadeType` | `string` | No | Fading type for fragments: 'None', 'Destroy', 'MoveDown', 'ScaleDown', 'FallDown'. Default 'None'. |
| `fadeLifetime` | `number` | No | Fragment fade lifetime in seconds. Default 5. |
| `initialize` | `boolean` | No | Initialize component immediately. Default true. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "targetRef": {
      "$ref": "#/$defs/com.IvanMurzak.Unity.MCP.Runtime.Data.GameObjectRef"
    },
    "simulationType": {
      "type": "string"
    },
    "demolitionType": {
      "type": "string"
    },
    "objectType": {
      "type": "string"
    },
    "physicsMaterial": {
      "type": "string"
    },
    "mass": {
      "type": "number"
    },
    "enableDamage": {
      "type": "boolean"
    },
    "maxDamage": {
      "type": "number"
    },
    "collisionDamage": {
      "type": "boolean"
    },
    "useGravity": {
      "type": "boolean"
    },
    "maxDepth": {
      "type": "integer"
    },
    "fadeType": {
      "type": "string"
    },
    "fadeLifetime": {
      "type": "number"
    },
    "initialize": {
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
      "$ref": "#/$defs/MCPTools.RayFire.Editor.Tool_RayFire+AddRigidResponse"
    }
  },
  "$defs": {
    "MCPTools.RayFire.Editor.Tool_RayFire+AddRigidResponse": {
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
        "simulationType": {
          "type": "string",
          "description": "Simulation type set"
        },
        "demolitionType": {
          "type": "string",
          "description": "Demolition type set"
        },
        "physicsMaterial": {
          "type": "string",
          "description": "Physics material type"
        },
        "damageEnabled": {
          "type": "boolean",
          "description": "Damage tracking enabled"
        },
        "maxDamage": {
          "type": "number",
          "description": "Maximum damage"
        }
      },
      "required": [
        "instanceId",
        "damageEnabled",
        "maxDamage"
      ]
    }
  },
  "required": [
    "result"
  ]
}
```

