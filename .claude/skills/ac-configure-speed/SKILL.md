---
name: ac-configure-speed
description: |-
  Configures a speed entry within a speed set on an MAnimal component.
  Speed sets control movement speeds for different states (e.g. Ground has Walk/Trot/Run).
  Only provided parameters are changed; others are left as-is.
  Use 'ac-query-animal' first to see available speed sets and their speeds.
---

# Malbers AC / Configure Speed

## How to Call

```bash
unity-mcp-cli run-tool ac-configure-speed --input '{
  "targetRef": "string_value",
  "speedSetName": "string_value",
  "speedName": "string_value",
  "position": "string_value",
  "lerpPosition": "string_value",
  "rotation": "string_value",
  "animator": "string_value",
  "lerpAnimator": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool ac-configure-speed --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool ac-configure-speed --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `targetRef` | `any` | Yes | Reference to the GameObject with MAnimal component. |
| `speedSetName` | `string` | Yes | Speed set name (e.g. 'Ground', 'Swim', 'Fly'). Case-insensitive partial match. |
| `speedName` | `string` | Yes | Speed name within the set (e.g. 'Walk', 'Trot', 'Run'). Case-insensitive partial match. |
| `position` | `any` | No | Additive position speed (non-root-motion). Null to keep current. |
| `lerpPosition` | `any` | No | Position lerp smoothing. Null to keep current. |
| `rotation` | `any` | No | Additive rotation speed. Null to keep current. |
| `animator` | `any` | No | Animator speed multiplier. Null to keep current. |
| `lerpAnimator` | `any` | No | Animator lerp smoothing. Null to keep current. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "targetRef": {
      "$ref": "#/$defs/com.IvanMurzak.Unity.MCP.Runtime.Data.GameObjectRef"
    },
    "speedSetName": {
      "type": "string"
    },
    "speedName": {
      "type": "string"
    },
    "position": {
      "$ref": "#/$defs/System.Single"
    },
    "lerpPosition": {
      "$ref": "#/$defs/System.Single"
    },
    "rotation": {
      "$ref": "#/$defs/System.Single"
    },
    "animator": {
      "$ref": "#/$defs/System.Single"
    },
    "lerpAnimator": {
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
    }
  },
  "required": [
    "targetRef",
    "speedSetName",
    "speedName"
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
      "$ref": "#/$defs/MCPTools.MalbersAC.Editor.Tool_MalbersAC+ConfigureSpeedResponse"
    }
  },
  "$defs": {
    "MCPTools.MalbersAC.Editor.Tool_MalbersAC+ConfigureSpeedResponse": {
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
        "speedSetName": {
          "type": "string",
          "description": "Speed set name"
        },
        "speedName": {
          "type": "string",
          "description": "Speed entry name"
        },
        "position": {
          "type": "number",
          "description": "Position speed value"
        },
        "lerpPosition": {
          "type": "number",
          "description": "Position lerp value"
        },
        "rotation": {
          "type": "number",
          "description": "Rotation speed value"
        },
        "animator": {
          "type": "number",
          "description": "Animator speed value"
        },
        "lerpAnimator": {
          "type": "number",
          "description": "Animator lerp value"
        }
      },
      "required": [
        "instanceId",
        "position",
        "lerpPosition",
        "rotation",
        "animator",
        "lerpAnimator"
      ]
    }
  },
  "required": [
    "result"
  ]
}
```

