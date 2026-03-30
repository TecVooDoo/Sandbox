---
name: rayfire-list-rigid
description: Lists all RayfireRigid components in the current scene with their configuration summary.
---

# RayFire / List Rigid Objects

## How to Call

```bash
unity-mcp-cli run-tool rayfire-list-rigid --input '{}'
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
      "$ref": "#/$defs/MCPTools.RayFire.Editor.Tool_RayFire+ListRigidResponse"
    }
  },
  "$defs": {
    "MCPTools.RayFire.Editor.Tool_RayFire+ListRigidResponse": {
      "type": "object",
      "properties": {
        "count": {
          "type": "integer",
          "description": "Number of RayfireRigid objects found"
        },
        "details": {
          "type": "string",
          "description": "Details of each rigid object"
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

