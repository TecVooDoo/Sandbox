---
name: ecs-modify-entity
description: |-
  Modifies a field on an unmanaged IComponentData component of an ECS entity.
  Uses reflection to get the component, modify the field, and set it back.
  Only works for unmanaged IComponentData with public fields.
  Requires Play mode.
---

# ECS / Modify Entity

## How to Call

```bash
unity-mcp-cli run-tool ecs-modify-entity --input '{
  "entityIndex": 0,
  "entityVersion": 0,
  "componentTypeName": "string_value",
  "fieldName": "string_value",
  "value": "string_value",
  "worldName": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool ecs-modify-entity --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool ecs-modify-entity --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `entityIndex` | `integer` | Yes | Entity index. |
| `entityVersion` | `integer` | Yes | Entity version. |
| `componentTypeName` | `string` | Yes | Fully qualified component type name (e.g. 'Unity.Transforms.LocalTransform'). |
| `fieldName` | `string` | Yes | Name of the public field to modify. |
| `value` | `string` | Yes | New value as a string. Supports int, float, bool, string. For Vector3/float3 use 'x,y,z' format. |
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
    "componentTypeName": {
      "type": "string"
    },
    "fieldName": {
      "type": "string"
    },
    "value": {
      "type": "string"
    },
    "worldName": {
      "type": "string"
    }
  },
  "required": [
    "entityIndex",
    "entityVersion",
    "componentTypeName",
    "fieldName",
    "value"
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

