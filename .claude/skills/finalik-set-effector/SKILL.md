---
name: finalik-set-effector
description: |-
  Sets an effector target position and/or weight on a FullBodyBipedIK component.
  Effectors: 'Body', 'LeftHand', 'RightHand', 'LeftFoot', 'RightFoot', 'LeftShoulder', 'RightShoulder'.
  Set positionWeight to 1 to fully control the effector, 0 to release it.
---

# Final IK / Set FBBIK Effector

## How to Call

```bash
unity-mcp-cli run-tool finalik-set-effector --input '{
  "targetRef": "string_value",
  "effectorName": "string_value",
  "position": "string_value",
  "positionWeight": "string_value",
  "rotationWeight": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool finalik-set-effector --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool finalik-set-effector --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `targetRef` | `any` | Yes | Reference to the character with FullBodyBipedIK. |
| `effectorName` | `string` | Yes | Effector name: 'Body', 'LeftHand', 'RightHand', 'LeftFoot', 'RightFoot', 'LeftShoulder', 'RightShoulder'. |
| `position` | `any` | No | World position for the effector target. Null to keep current. |
| `positionWeight` | `any` | No | Position weight (0-1). 1 = full IK control, 0 = no IK. Null to keep current. |
| `rotationWeight` | `any` | No | Rotation weight (0-1). Null to keep current. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "targetRef": {
      "$ref": "#/$defs/com.IvanMurzak.Unity.MCP.Runtime.Data.GameObjectRef"
    },
    "effectorName": {
      "type": "string"
    },
    "position": {
      "$ref": "#/$defs/UnityEngine.Vector3"
    },
    "positionWeight": {
      "$ref": "#/$defs/System.Single"
    },
    "rotationWeight": {
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
    },
    "System.Single": {
      "type": "number"
    }
  },
  "required": [
    "targetRef",
    "effectorName"
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
      "$ref": "#/$defs/MCPTools.FinalIK.Editor.Tool_FinalIK+SetEffectorResponse"
    }
  },
  "$defs": {
    "MCPTools.FinalIK.Editor.Tool_FinalIK+SetEffectorResponse": {
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
        "effectorName": {
          "type": "string",
          "description": "Effector name"
        },
        "position": {
          "type": "string",
          "description": "Effector position"
        },
        "positionWeight": {
          "type": "number",
          "description": "Position weight"
        },
        "rotationWeight": {
          "type": "number",
          "description": "Rotation weight"
        }
      },
      "required": [
        "instanceId",
        "positionWeight",
        "rotationWeight"
      ]
    }
  },
  "required": [
    "result"
  ]
}
```

