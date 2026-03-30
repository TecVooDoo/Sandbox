---
name: rayfire-apply-damage
description: |-
  Applies damage to a RayfireRigid object. If accumulated damage exceeds max, the object is demolished.
  Damage must be enabled on the component.
---

# RayFire / Apply Damage

## How to Call

```bash
unity-mcp-cli run-tool rayfire-apply-damage --input '{
  "targetRef": "string_value",
  "damageAmount": 0,
  "damagePoint": "string_value",
  "damageRadius": 0
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool rayfire-apply-damage --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool rayfire-apply-damage --input-file - <<'EOF'
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
| `damageAmount` | `number` | Yes | Amount of damage to apply. |
| `damagePoint` | `any` | No | World position of the damage point. Default is object center. |
| `damageRadius` | `number` | No | Damage radius (0 for point damage). Default 0. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "targetRef": {
      "$ref": "#/$defs/com.IvanMurzak.Unity.MCP.Runtime.Data.GameObjectRef"
    },
    "damageAmount": {
      "type": "number"
    },
    "damagePoint": {
      "$ref": "#/$defs/UnityEngine.Vector3"
    },
    "damageRadius": {
      "type": "number"
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
    "UnityEngine.Vector3": {
      "type": "object",
      "properties": {
        "x": {
          "type": "number"
        },
        "y": {
          "type": "number"
        },
        "z": {
          "type": "number"
        }
      },
      "required": [
        "x",
        "y",
        "z"
      ],
      "additionalProperties": false
    }
  },
  "required": [
    "targetRef",
    "damageAmount"
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
      "$ref": "#/$defs/MCPTools.RayFire.Editor.Tool_RayFire+ApplyDamageResponse"
    }
  },
  "$defs": {
    "MCPTools.RayFire.Editor.Tool_RayFire+ApplyDamageResponse": {
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
        "damageApplied": {
          "type": "number",
          "description": "Damage applied"
        },
        "currentDamage": {
          "type": "number",
          "description": "Current accumulated damage"
        },
        "maxDamage": {
          "type": "number",
          "description": "Maximum damage threshold"
        },
        "demolished": {
          "type": "boolean",
          "description": "Whether the object was demolished"
        }
      },
      "required": [
        "instanceId",
        "damageApplied",
        "currentDamage",
        "maxDamage",
        "demolished"
      ]
    }
  },
  "required": [
    "result"
  ]
}
```

