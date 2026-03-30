---
name: ac-configure-damageable
description: |-
  Configures an MDamageable component on a GameObject.
  MDamageable handles how the animal receives damage, including multipliers and alignment.
  Only provided parameters are changed; others are left as-is.
---

# Malbers AC / Configure Damageable

## How to Call

```bash
unity-mcp-cli run-tool ac-configure-damageable --input '{
  "targetRef": "string_value",
  "multiplier": "string_value",
  "alignToDamage": "string_value",
  "alignTime": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool ac-configure-damageable --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool ac-configure-damageable --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `targetRef` | `any` | Yes | Reference to the GameObject with MDamageable component. |
| `multiplier` | `any` | No | Damage multiplier (1.0 = normal, 2.0 = double damage). Null to keep current. |
| `alignToDamage` | `any` | No | Auto-rotate to face damage source. Null to keep current. |
| `alignTime` | `any` | No | Alignment time in seconds. Null to keep current. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "targetRef": {
      "$ref": "#/$defs/com.IvanMurzak.Unity.MCP.Runtime.Data.GameObjectRef"
    },
    "multiplier": {
      "$ref": "#/$defs/System.Single"
    },
    "alignToDamage": {
      "$ref": "#/$defs/System.Boolean"
    },
    "alignTime": {
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
      "$ref": "#/$defs/MCPTools.MalbersAC.Editor.Tool_MalbersAC+ConfigureDamageableResponse"
    }
  },
  "$defs": {
    "MCPTools.MalbersAC.Editor.Tool_MalbersAC+ConfigureDamageableResponse": {
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
        "multiplier": {
          "type": "number",
          "description": "Damage multiplier"
        },
        "alignToDamage": {
          "type": "boolean",
          "description": "Align to damage source"
        },
        "alignTime": {
          "type": "number",
          "description": "Alignment time in seconds"
        }
      },
      "required": [
        "instanceId",
        "multiplier",
        "alignToDamage",
        "alignTime"
      ]
    }
  },
  "required": [
    "result"
  ]
}
```

