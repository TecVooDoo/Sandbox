---
name: finalik-list-ik
description: Lists all Final IK components in the current scene with their type and status.
---

# Final IK / List IK Components

## How to Call

```bash
unity-mcp-cli run-tool finalik-list-ik --input '{}'
```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

This tool takes no input parameters.

### Input JSON Schema

```json
{
  "type": "object",
  "additionalProperties": false
}
```

## Output

### Output JSON Schema

```json
{
  "type": "object",
  "properties": {
    "result": {
      "$ref": "#/$defs/MCPTools.FinalIK.Editor.Tool_FinalIK+ListIKResponse"
    }
  },
  "$defs": {
    "MCPTools.FinalIK.Editor.Tool_FinalIK+ListIKResponse": {
      "type": "object",
      "properties": {
        "count": {
          "type": "integer",
          "description": "Number of IK components found"
        },
        "details": {
          "type": "string",
          "description": "Details of each IK component"
        }
      },
      "required": [
        "count"
      ]
    }
  },
  "required": [
    "result"
  ]
}
```

