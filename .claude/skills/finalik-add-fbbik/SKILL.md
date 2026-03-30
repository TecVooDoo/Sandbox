---
name: finalik-add-fbbik
description: |-
  Adds a FullBodyBipedIK component to a character GameObject and auto-detects biped bone references.
  The character must have an Animator with a humanoid avatar, or a standard biped bone hierarchy.
  This is the main IK component for bipeds — controls hands, feet, body, and shoulders.
---

# Final IK / Add Full Body Biped IK

## How to Call

```bash
unity-mcp-cli run-tool finalik-add-fbbik --input '{
  "targetRef": "string_value",
  "autoDetect": false
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool finalik-add-fbbik --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool finalik-add-fbbik --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `targetRef` | `any` | Yes | Reference to the character root GameObject. |
| `autoDetect` | `boolean` | No | Auto-detect biped references from the skeleton. Default true. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "targetRef": {
      "$ref": "#/$defs/com.IvanMurzak.Unity.MCP.Runtime.Data.GameObjectRef"
    },
    "autoDetect": {
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
      "$ref": "#/$defs/MCPTools.FinalIK.Editor.Tool_FinalIK+AddFBBIKResponse"
    }
  },
  "$defs": {
    "MCPTools.FinalIK.Editor.Tool_FinalIK+AddFBBIKResponse": {
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
        "referencesDetected": {
          "type": "boolean",
          "description": "Biped references detected"
        },
        "hasError": {
          "type": "boolean",
          "description": "Setup has errors"
        },
        "errorMessage": {
          "type": "string",
          "description": "Error message if any"
        },
        "rootNode": {
          "type": "string",
          "description": "Root node bone name"
        }
      },
      "required": [
        "instanceId",
        "referencesDetected",
        "hasError"
      ]
    }
  },
  "required": [
    "result"
  ]
}
```

