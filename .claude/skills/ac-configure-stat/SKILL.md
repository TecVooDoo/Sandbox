---
name: ac-configure-stat
description: |-
  Configures a specific stat on a Stats component by stat name.
  Only provided parameters are changed; others are left as-is.
  Common stats: Health, Stamina, Energy, Mana.
  Use 'ac-query-stats' first to see available stats.
---

# Malbers AC / Configure Stat

## How to Call

```bash
unity-mcp-cli run-tool ac-configure-stat --input '{
  "targetRef": "string_value",
  "statName": "string_value",
  "active": "string_value",
  "value": "string_value",
  "maxValue": "string_value",
  "minValue": "string_value",
  "regenRate": "string_value",
  "degenRate": "string_value",
  "regenWaitTime": "string_value",
  "immuneTime": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool ac-configure-stat --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool ac-configure-stat --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `targetRef` | `any` | Yes | Reference to the GameObject with Stats component. |
| `statName` | `string` | Yes | Stat name to find (e.g. 'Health', 'Stamina', 'Energy'). Case-insensitive partial match. |
| `active` | `any` | No | Enable or disable this stat. Null to keep current. |
| `value` | `any` | No | Current value. Null to keep current. |
| `maxValue` | `any` | No | Maximum value. Null to keep current. |
| `minValue` | `any` | No | Minimum value. Null to keep current. |
| `regenRate` | `any` | No | Regeneration rate (units per second). Null to keep current. |
| `degenRate` | `any` | No | Degeneration rate (units per second). Null to keep current. |
| `regenWaitTime` | `any` | No | Wait time before regeneration starts (seconds). Null to keep current. |
| `immuneTime` | `any` | No | Immunity time after receiving damage (seconds). Null to keep current. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "targetRef": {
      "$ref": "#/$defs/com.IvanMurzak.Unity.MCP.Runtime.Data.GameObjectRef"
    },
    "statName": {
      "type": "string"
    },
    "active": {
      "$ref": "#/$defs/System.Boolean"
    },
    "value": {
      "$ref": "#/$defs/System.Single"
    },
    "maxValue": {
      "$ref": "#/$defs/System.Single"
    },
    "minValue": {
      "$ref": "#/$defs/System.Single"
    },
    "regenRate": {
      "$ref": "#/$defs/System.Single"
    },
    "degenRate": {
      "$ref": "#/$defs/System.Single"
    },
    "regenWaitTime": {
      "$ref": "#/$defs/System.Single"
    },
    "immuneTime": {
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
    "System.Boolean": {
      "type": "boolean"
    },
    "System.Single": {
      "type": "number"
    }
  },
  "required": [
    "targetRef",
    "statName"
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
      "$ref": "#/$defs/MCPTools.MalbersAC.Editor.Tool_MalbersAC+ConfigureStatResponse"
    }
  },
  "$defs": {
    "MCPTools.MalbersAC.Editor.Tool_MalbersAC+ConfigureStatResponse": {
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
        "statName": {
          "type": "string",
          "description": "Stat name that was configured"
        },
        "active": {
          "type": "boolean",
          "description": "Stat active status"
        },
        "value": {
          "type": "number",
          "description": "Current value"
        },
        "maxValue": {
          "type": "number",
          "description": "Maximum value"
        },
        "minValue": {
          "type": "number",
          "description": "Minimum value"
        },
        "regenRate": {
          "type": "number",
          "description": "Regeneration rate"
        }
      },
      "required": [
        "instanceId",
        "active",
        "value",
        "maxValue",
        "minValue",
        "regenRate"
      ]
    }
  },
  "required": [
    "result"
  ]
}
```

