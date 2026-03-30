---
name: rayfire-configure-rigid
description: |-
  Modifies properties on an existing RayfireRigid component.
  Only provided parameters are changed; others are left as-is.
---

# RayFire / Configure Rigid

## How to Call

```bash
unity-mcp-cli run-tool rayfire-configure-rigid --input '{
  "targetRef": "string_value",
  "simulationType": "string_value",
  "demolitionType": "string_value",
  "physicsMaterial": "string_value",
  "mass": "string_value",
  "enableDamage": "string_value",
  "maxDamage": "string_value",
  "useGravity": "string_value",
  "maxDepth": "string_value",
  "fadeType": "string_value",
  "fadeLifetime": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool rayfire-configure-rigid --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool rayfire-configure-rigid --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `targetRef` | `any` | Yes | Reference to the target GameObject with RayfireRigid. |
| `simulationType` | `string` | No | Simulation type. Null to keep current. |
| `demolitionType` | `string` | No | Demolition type. Null to keep current. |
| `physicsMaterial` | `string` | No | Physics material type. Null to keep current. |
| `mass` | `any` | No | Mass value. Null to keep current. |
| `enableDamage` | `any` | No | Enable/disable damage. Null to keep current. |
| `maxDamage` | `any` | No | Max damage. Null to keep current. |
| `useGravity` | `any` | No | Use gravity. Null to keep current. |
| `maxDepth` | `any` | No | Max demolition depth. Null to keep current. |
| `fadeType` | `string` | No | Fade type. Null to keep current. |
| `fadeLifetime` | `any` | No | Fade lifetime. Null to keep current. |

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
    "physicsMaterial": {
      "type": "string"
    },
    "mass": {
      "$ref": "#/$defs/System.Single"
    },
    "enableDamage": {
      "$ref": "#/$defs/System.Boolean"
    },
    "maxDamage": {
      "$ref": "#/$defs/System.Single"
    },
    "useGravity": {
      "$ref": "#/$defs/System.Boolean"
    },
    "maxDepth": {
      "$ref": "#/$defs/System.Int32"
    },
    "fadeType": {
      "type": "string"
    },
    "fadeLifetime": {
      "$ref": "#/$defs/System.Single"
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
    },
    "System.Single": {
      "type": "number"
    },
    "System.Boolean": {
      "type": "boolean"
    },
    "System.Int32": {
      "type": "integer"
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
      "$ref": "#/$defs/MCPTools.RayFire.Editor.Tool_RayFire+ConfigureRigidResponse"
    }
  },
  "$defs": {
    "MCPTools.RayFire.Editor.Tool_RayFire+ConfigureRigidResponse": {
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
          "description": "Simulation type"
        },
        "demolitionType": {
          "type": "string",
          "description": "Demolition type"
        },
        "physicsMaterial": {
          "type": "string",
          "description": "Physics material type"
        },
        "mass": {
          "type": "number",
          "description": "Mass"
        },
        "damageEnabled": {
          "type": "boolean",
          "description": "Damage enabled"
        },
        "maxDamage": {
          "type": "number",
          "description": "Max damage"
        }
      },
      "required": [
        "instanceId",
        "mass",
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

