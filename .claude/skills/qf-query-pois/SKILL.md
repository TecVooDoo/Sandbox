---
name: qf-query-pois
description: |-
  Lists all PointOfInterest ScriptableObject assets in the project.
  Shows name, category, location ID, position, and display settings for each POI.
---

# Quest Forge / Query POIs

## How to Call

```bash
unity-mcp-cli run-tool qf-query-pois --input '{
  "searchFolder": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool qf-query-pois --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool qf-query-pois --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `searchFolder` | `string` | No | Folder path to search (e.g. 'Assets/_Sandbox/_AQS/Data/POI'). Null to search entire project. |

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
      "$ref": "#/$defs/MCPTools.QuestForge.Editor.Tool_QuestForge+QueryPOIsResponse"
    }
  },
  "$defs": {
    "MCPTools.QuestForge.Editor.Tool_QuestForge+QueryPOIsResponse": {
      "type": "object",
      "properties": {
        "poiCount": {
          "type": "integer",
          "description": "Number of POIs found"
        },
        "details": {
          "type": "string",
          "description": "Detailed POI listing"
        }
      },
      "required": [
        "poiCount"
      ]
    }
  },
  "required": [
    "result"
  ]
}
```

