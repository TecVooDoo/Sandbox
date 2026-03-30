---
name: ac-add-lock-axis
description: |-
  Adds or configures a LockAxis component on a GameObject for 2.5D gameplay.
  LockAxis constrains the animal's movement to specific axes.
  For 2.5D side-scrolling: lock Z axis (LockZ=true) so movement stays on the XY plane.
  For 2.5D top-down: lock Y axis (LockY=true) so movement stays on the XZ plane.
---

# Malbers AC / Add Lock Axis

## How to Call

```bash
unity-mcp-cli run-tool ac-add-lock-axis --input '{
  "targetRef": "string_value",
  "lockX": false,
  "lockY": false,
  "lockZ": false,
  "offsetX": 0,
  "offsetY": 0,
  "offsetZ": 0
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool ac-add-lock-axis --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool ac-add-lock-axis --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `targetRef` | `any` | Yes | Reference to the target GameObject (should have MAnimal). |
| `lockX` | `boolean` | No | Lock X axis position. Default false. |
| `lockY` | `boolean` | No | Lock Y axis position. Default false. |
| `lockZ` | `boolean` | No | Lock Z axis position. Default true (standard 2.5D side-scroller). |
| `offsetX` | `number` | No | X offset value when locked. Default 0. |
| `offsetY` | `number` | No | Y offset value when locked. Default 0. |
| `offsetZ` | `number` | No | Z offset value when locked. Default 0. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "targetRef": {
      "$ref": "#/$defs/com.IvanMurzak.Unity.MCP.Runtime.Data.GameObjectRef"
    },
    "lockX": {
      "type": "boolean"
    },
    "lockY": {
      "type": "boolean"
    },
    "lockZ": {
      "type": "boolean"
    },
    "offsetX": {
      "type": "number"
    },
    "offsetY": {
      "type": "number"
    },
    "offsetZ": {
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
      "$ref": "#/$defs/MCPTools.MalbersAC.Editor.Tool_MalbersAC+LockAxisResponse"
    }
  },
  "$defs": {
    "MCPTools.MalbersAC.Editor.Tool_MalbersAC+LockAxisResponse": {
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
        "lockX": {
          "type": "boolean",
          "description": "X axis locked"
        },
        "lockY": {
          "type": "boolean",
          "description": "Y axis locked"
        },
        "lockZ": {
          "type": "boolean",
          "description": "Z axis locked"
        },
        "offset": {
          "type": "string",
          "description": "Lock offset values"
        }
      },
      "required": [
        "instanceId",
        "lockX",
        "lockY",
        "lockZ"
      ]
    }
  },
  "required": [
    "result"
  ]
}
```

