---
name: astar-query
description: |-
  Query A* pathfinding system state and AI agent info.
  Without gameObjectName: lists all graphs (type, node count, dimensions for GridGraph, characterRadius for RecastGraph).
  With gameObjectName: reports AIPath/AILerp/RichAI settings (maxSpeed, rotationSpeed, endReachedDistance, destination,
  reachedDestination, remainingDistance, hasPath) and Seeker settings (traversableTags).
---

# A* Pathfinding / Query

## How to Call

```bash
unity-mcp-cli run-tool astar-query --input '{
  "gameObjectName": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool astar-query --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool astar-query --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | No | Optional: name of a GameObject with an AI movement agent (AIPath/AILerp/RichAI) to inspect. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
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
      "type": "string"
    }
  },
  "required": [
    "result"
  ]
}
```

