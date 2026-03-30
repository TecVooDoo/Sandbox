---
name: ecs-query-entities
description: |-
  Queries entities in an ECS World, optionally filtered by component types.
  Returns entity index+version and component type names for each match.
  Output is capped at 50 entities. Requires Play mode.
---

# ECS / Query Entities

## How to Call

```bash
unity-mcp-cli run-tool ecs-query-entities --input '{
  "componentTypeNames": "string_value",
  "worldName": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool ecs-query-entities --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool ecs-query-entities --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `componentTypeNames` | `string` | No | Comma-separated fully qualified component type names to filter by (e.g. 'Unity.Transforms.LocalTransform,Unity.Rendering.RenderMesh'). Leave empty to list all entities. |
| `worldName` | `string` | No | Name of the World to query. Defaults to DefaultGameObjectInjectionWorld. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "componentTypeNames": {
      "type": "string"
    },
    "worldName": {
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

