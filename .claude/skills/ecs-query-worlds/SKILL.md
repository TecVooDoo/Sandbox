---
name: ecs-query-worlds
description: |-
  Lists all active Unity ECS Worlds.
  Shows each world's name, entity count, system count, IsCreated status,
  and whether it is the DefaultGameObjectInjectionWorld.
  Requires Play mode to be active.
---

# ECS / Query Worlds

## How to Call

```bash
unity-mcp-cli run-tool ecs-query-worlds --input '{}'
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

