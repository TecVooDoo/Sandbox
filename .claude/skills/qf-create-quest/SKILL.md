---
name: qf-create-quest
description: |-
  Creates a new Quest ScriptableObject asset.
  The quest is saved to the specified path and can have objectives added via 'qf-add-objective'.
  Quest types: Main, Side, Daily, Repeatable.
---

# Quest Forge / Create Quest

## How to Call

```bash
unity-mcp-cli run-tool qf-create-quest --input '{
  "assetPath": "string_value",
  "questId": "string_value",
  "questName": "string_value",
  "description": "string_value",
  "questType": "string_value",
  "isRepeatable": false
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool qf-create-quest --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool qf-create-quest --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `assetPath` | `string` | Yes | Asset path for the new quest SO (e.g. 'Assets/_Sandbox/_AQS/Data/Quests/Quest_FindJoey.asset'). |
| `questId` | `string` | Yes | Unique quest ID string (e.g. 'find_joey_01'). Must be unique across all quests. |
| `questName` | `string` | Yes | Display name of the quest. |
| `description` | `string` | Yes | Quest description text. |
| `questType` | `string` | No | Quest type: 'Main', 'Side', 'Daily', 'Repeatable'. Default 'Side'. |
| `isRepeatable` | `boolean` | No | Whether the quest can be repeated after completion. Default false. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "assetPath": {
      "type": "string"
    },
    "questId": {
      "type": "string"
    },
    "questName": {
      "type": "string"
    },
    "description": {
      "type": "string"
    },
    "questType": {
      "type": "string"
    },
    "isRepeatable": {
      "type": "boolean"
    }
  },
  "required": [
    "assetPath",
    "questId",
    "questName",
    "description"
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
      "$ref": "#/$defs/MCPTools.QuestForge.Editor.Tool_QuestForge+CreateQuestResponse"
    }
  },
  "$defs": {
    "MCPTools.QuestForge.Editor.Tool_QuestForge+CreateQuestResponse": {
      "type": "object",
      "properties": {
        "assetPath": {
          "type": "string",
          "description": "Asset path where quest was saved"
        },
        "questId": {
          "type": "string",
          "description": "Quest ID"
        },
        "questName": {
          "type": "string",
          "description": "Quest display name"
        },
        "questType": {
          "type": "string",
          "description": "Quest type"
        },
        "isRepeatable": {
          "type": "boolean",
          "description": "Whether quest is repeatable"
        }
      },
      "required": [
        "isRepeatable"
      ]
    }
  },
  "required": [
    "result"
  ]
}
```

