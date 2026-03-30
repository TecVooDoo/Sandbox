---
name: qf-query-quests
description: |-
  Lists all Quest ScriptableObject assets in the project.
  Shows quest ID, name, type, objective count, and prerequisite count for each quest.
  Use to get an overview of all quests in the project.
---

# Quest Forge / Query Quests

## How to Call

```bash
unity-mcp-cli run-tool qf-query-quests --input '{
  "searchFolder": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool qf-query-quests --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool qf-query-quests --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `searchFolder` | `string` | No | Folder path to search (e.g. 'Assets/_Sandbox/_AQS/Data/Quests'). Null to search entire project. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "searchFolder": {
      "type": "string"
    }
  }
}
```

## Output

### Output JSON Schema

```json
{
  "type": "object",
  "properties": {
    "result": {
      "$ref": "#/$defs/MCPTools.QuestForge.Editor.Tool_QuestForge+QueryQuestsResponse"
    }
  },
  "$defs": {
    "MCPTools.QuestForge.Editor.Tool_QuestForge+QueryQuestsResponse": {
      "type": "object",
      "properties": {
        "questCount": {
          "type": "integer",
          "description": "Number of quests found"
        },
        "details": {
          "type": "string",
          "description": "Detailed quest listing"
        }
      },
      "required": [
        "questCount"
      ]
    }
  },
  "required": [
    "result"
  ]
}
```

