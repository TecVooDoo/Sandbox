---
name: retarget-query-profiles
description: |-
  Lists all RetargetProfile ScriptableObject assets in the project.
  Shows source/target characters, rig assignments, and feature count for each profile.
---

# Retarget Pro / Query Profiles

## How to Call

```bash
unity-mcp-cli run-tool retarget-query-profiles --input '{
  "searchFolder": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool retarget-query-profiles --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool retarget-query-profiles --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `searchFolder` | `string` | No | Folder to search (e.g. 'Assets/_Sandbox/_AQS/Data/Retarget'). Null to search entire project. |

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
      "$ref": "#/$defs/MCPTools.RetargetPro.Editor.Tool_RetargetPro+QueryProfilesResponse"
    }
  },
  "$defs": {
    "MCPTools.RetargetPro.Editor.Tool_RetargetPro+QueryProfilesResponse": {
      "type": "object",
      "properties": {
        "profileCount": {
          "type": "integer",
          "description": "Number of profiles found"
        },
        "details": {
          "type": "string",
          "description": "Detailed profile listing"
        }
      },
      "required": [
        "profileCount"
      ]
    }
  },
  "required": [
    "result"
  ]
}
```

