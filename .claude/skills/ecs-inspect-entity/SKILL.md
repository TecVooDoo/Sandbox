---
name: ecs-inspect-entity
description: |-
  Inspects a specific ECS entity by index and version.
  Lists all components and attempts to read field values from unmanaged IComponentData.
  Requires Play mode.
---

# ECS / Inspect Entity

## How to Call

```bash
unity-mcp-cli run-tool ecs-inspect-entity --input '{
  "entityIndex": 0,
  "entityVersion": 0,
  "worldName": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool ecs-inspect-entity --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool ecs-inspect-entity --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `entityIndex` | `integer` | Yes | Entity index (from ecs-query-entities output). |
| `entityVersion` | `integer` | Yes | Entity version (from ecs-query-entities output). |
| `worldName` | `string` | No | Name of the World. Defaults to DefaultGameObjectInjectionWorld. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "entityIndex": {
      "type": "integer"
    },
    "entityVersion": {
      "type": "integer"
    },
    "worldName": {
      "type": "string"
    }
  },
  "required": [
    "entityIndex",
    "entityVersion"
  ]
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

