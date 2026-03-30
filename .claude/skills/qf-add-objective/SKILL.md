---
name: qf-add-objective
description: |-
  Adds an objective to an existing Quest ScriptableObject.
  Objective types: Kill, Collect, TalkTo, GoToLocation, Interact.
  Each type has specific parameters. Only parameters relevant to the chosen type are used.
---

# Quest Forge / Add Objective

## How to Call

```bash
unity-mcp-cli run-tool qf-add-objective --input '{
  "questAssetPath": "string_value",
  "objectiveType": "string_value",
  "targetId": "string_value",
  "requiredCount": 0,
  "specificId": "string_value",
  "posX": 0,
  "posY": 0,
  "posZ": 0,
  "requiredDistance": 0
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool qf-add-objective --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool qf-add-objective --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `questAssetPath` | `string` | Yes | Asset path of the Quest SO to modify (e.g. 'Assets/_Sandbox/_AQS/Data/Quests/Quest_FindJoey.asset'). |
| `objectiveType` | `string` | Yes | Objective type: 'Kill', 'Collect', 'TalkTo', 'GoToLocation', 'Interact'. |
| `targetId` | `string` | Yes | For Kill: enemy tag to kill (e.g. 'Enemy', 'Snake'). For Collect: item ID. For TalkTo: NPC ID. For GoToLocation: location ID. For Interact: interactable ID. |
| `requiredCount` | `integer` | No | Required count (kills, items, interactions). Default 1. |
| `specificId` | `string` | No | For Kill: specific enemy ID (optional, empty = any with tag). For TalkTo: specific dialogue ID (optional). |
| `posX` | `number` | No | For GoToLocation: target X position. Default 0. |
| `posY` | `number` | No | For GoToLocation: target Y position. Default 0. |
| `posZ` | `number` | No | For GoToLocation: target Z position. Default 0. |
| `requiredDistance` | `number` | No | For GoToLocation: required distance to complete. Default 5. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "questAssetPath": {
      "type": "string"
    },
    "objectiveType": {
      "type": "string"
    },
    "targetId": {
      "type": "string"
    },
    "requiredCount": {
      "type": "integer"
    },
    "specificId": {
      "type": "string"
    },
    "posX": {
      "type": "number"
    },
    "posY": {
      "type": "number"
    },
    "posZ": {
      "type": "number"
    },
    "requiredDistance": {
      "type": "number"
    }
  },
  "required": [
    "questAssetPath",
    "objectiveType",
    "targetId"
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
      "$ref": "#/$defs/MCPTools.QuestForge.Editor.Tool_QuestForge+AddObjectiveResponse"
    }
  },
  "$defs": {
    "MCPTools.QuestForge.Editor.Tool_QuestForge+AddObjectiveResponse": {
      "type": "object",
      "properties": {
        "questAssetPath": {
          "type": "string",
          "description": "Asset path of the quest"
        },
        "questId": {
          "type": "string",
          "description": "Quest ID"
        },
        "objectiveType": {
          "type": "string",
          "description": "Type of objective added"
        },
        "targetId": {
          "type": "string",
          "description": "Target ID for the objective"
        },
        "requiredCount": {
          "type": "integer",
          "description": "Required count"
        },
        "totalObjectives": {
          "type": "integer",
          "description": "Total objectives on the quest"
        }
      },
      "required": [
        "requiredCount",
        "totalObjectives"
      ]
    }
  },
  "required": [
    "result"
  ]
}
```

