---
name: ds-query
description: |-
  Queries the Dialogue System database contents and active conversation state.
  Lists conversations (title, actor, conversant, entry count), actors (name, isPlayer),
  variables (name, initial value, type), quest count, and active conversation info.
  Output is limited to 50 items per category. Requires DialogueManager in the scene.
---

# Dialogue System / Query Database

## How to Call

```bash
unity-mcp-cli run-tool ds-query --input '{}'
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
      "type": "string"
    }
  },
  "required": [
    "result"
  ]
}
```

