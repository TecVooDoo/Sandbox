---
name: ac-query-animal
description: |-
  Reads the full Animal Controller setup on a GameObject.
  Lists all states (name, ID, active, priority), modes (name, ID, active, abilities),
  stances (name, ID, enabled), and speed sets (name, speeds, current index).
  Use this to understand an animal's configuration before making changes.
---

# Malbers AC / Query Animal

## How to Call

```bash
unity-mcp-cli run-tool ac-query-animal --input '{
  "targetRef": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool ac-query-animal --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool ac-query-animal --input-file - <<'EOF'
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

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "targetRef": {
      "$ref": "#/$defs/com.IvanMurzak.Unity.MCP.Runtime.Data.GameObjectRef"
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
      "$ref": "#/$defs/MCPTools.MalbersAC.Editor.Tool_MalbersAC+QueryAnimalResponse"
    }
  },
  "$defs": {
    "MCPTools.MalbersAC.Editor.Tool_MalbersAC+QueryAnimalResponse": {
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
        "activeState": {
          "type": "string",
          "description": "Currently active state name"
        },
        "stateCount": {
          "type": "integer",
          "description": "Number of states configured"
        },
        "modeCount": {
          "type": "integer",
          "description": "Number of modes configured"
        },
        "stanceCount": {
          "type": "integer",
          "description": "Number of stances configured"
        },
        "speedSetCount": {
          "type": "integer",
          "description": "Number of speed sets configured"
        },
        "details": {
          "type": "string",
          "description": "Full detailed breakdown of all states, modes, stances, and speed sets"
        }
      },
      "required": [
        "instanceId",
        "stateCount",
        "modeCount",
        "stanceCount",
        "speedSetCount"
      ]
    }
  },
  "required": [
    "result"
  ]
}
```

