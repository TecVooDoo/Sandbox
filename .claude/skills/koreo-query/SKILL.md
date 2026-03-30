---
name: koreo-query
description: |-
  Returns all loaded Koreography assets, their source clip names, track event IDs, and the current beat time.
  Use this to discover available event IDs before registering callbacks in game code.
---

# Koreographer / Query State

## How to Call

```bash
unity-mcp-cli run-tool koreo-query --input '{}'
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

