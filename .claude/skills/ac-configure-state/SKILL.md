---
name: ac-configure-state
description: |-
  Configures a state on an MAnimal component by state name or ID.
  Only provided parameters are changed; others are left as-is.
  Use 'ac-query-animal' first to see available states and their current values.
---

# Malbers AC / Configure State

## How to Call

```bash
unity-mcp-cli run-tool ac-configure-state --input '{
  "targetRef": "string_value",
  "stateName": "string_value",
  "active": "string_value",
  "priority": "string_value",
  "input": "string_value",
  "canStrafe": "string_value",
  "canTransitionToItself": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool ac-configure-state --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool ac-configure-state --input-file - <<'EOF'
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
| `stateName` | `string` | Yes | State name to find (e.g. 'Locomotion', 'Jump', 'Fall', 'Swim', 'Fly'). Case-insensitive partial match. |
| `active` | `any` | No | Enable or disable this state. Null to keep current. |
| `priority` | `any` | No | State priority (higher = more important). Null to keep current. |
| `input` | `string` | No | Input name to activate state. Null to keep current. |
| `canStrafe` | `any` | No | Allow strafing in this state. Null to keep current. |
| `canTransitionToItself` | `any` | No | Can transition to itself. Null to keep current. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "targetRef": {
      "$ref": "#/$defs/com.IvanMurzak.Unity.MCP.Runtime.Data.GameObjectRef"
    },
    "stateName": {
      "type": "string"
    },
    "active": {
      "$ref": "#/$defs/System.Boolean"
    },
    "priority": {
      "$ref": "#/$defs/System.Int32"
    },
    "input": {
      "type": "string"
    },
    "canStrafe": {
      "$ref": "#/$defs/System.Boolean"
    },
    "canTransitionToItself": {
      "$ref": "#/$defs/System.Boolean"
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
    "System.Boolean": {
      "type": "boolean"
    },
    "System.Int32": {
      "type": "integer"
    }
  },
  "required": [
    "targetRef",
    "stateName"
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
      "$ref": "#/$defs/MCPTools.MalbersAC.Editor.Tool_MalbersAC+ConfigureStateResponse"
    }
  },
  "$defs": {
    "MCPTools.MalbersAC.Editor.Tool_MalbersAC+ConfigureStateResponse": {
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
        "stateName": {
          "type": "string",
          "description": "State name that was configured"
        },
        "active": {
          "type": "boolean",
          "description": "State active status"
        },
        "priority": {
          "type": "integer",
          "description": "State priority"
        },
        "input": {
          "type": "string",
          "description": "Input name"
        },
        "canStrafe": {
          "type": "boolean",
          "description": "Can strafe in this state"
        }
      },
      "required": [
        "instanceId",
        "active",
        "priority",
        "canStrafe"
      ]
    }
  },
  "required": [
    "result"
  ]
}
```

