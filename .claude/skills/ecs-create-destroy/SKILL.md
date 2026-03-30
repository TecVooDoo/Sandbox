---
name: ecs-create-destroy
description: |-
  Creates or destroys an ECS entity.
  For 'create': provide componentTypeNames (comma-separated fully qualified type names).
    Creates an entity with those unmanaged IComponentData components attached.
  For 'destroy': provide entityIndex and entityVersion to destroy a specific entity.
  Requires Play mode.
---

# ECS / Create or Destroy Entity

## How to Call

```bash
unity-mcp-cli run-tool ecs-create-destroy --input '{
  "action": "string_value",
  "componentTypeNames": "string_value",
  "entityIndex": 0,
  "entityVersion": 0,
  "worldName": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool ecs-create-destroy --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool ecs-create-destroy --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `action` | `string` | Yes | Action to perform: 'create' or 'destroy'. |
| `componentTypeNames` | `string` | No | For 'create': comma-separated fully qualified component type names (e.g. 'Unity.Transforms.LocalTransform'). Ignored for 'destroy'. |
| `entityIndex` | `integer` | No | For 'destroy': entity index. Ignored for 'create'. |
| `entityVersion` | `integer` | No | For 'destroy': entity version. Ignored for 'create'. |
| `worldName` | `string` | No | Name of the World. Defaults to DefaultGameObjectInjectionWorld. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "action": {
      "type": "string"
    },
    "componentTypeNames": {
      "type": "string"
    },
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
    "action"
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

