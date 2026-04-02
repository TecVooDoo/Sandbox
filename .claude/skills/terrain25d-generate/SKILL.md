---
name: terrain25d-generate
description: |-
  Triggers mesh generation on a Terrain25D's MeshGenerator.
  Also optionally generates 2D colliders and foliage.
  Call after configuring mesh parameters with 'terrain25d-configure-mesh'.
---

# 2.5D Terrain / Generate Mesh

## How to Call

```bash
unity-mcp-cli run-tool terrain25d-generate --input '{
  "gameObjectName": "string_value",
  "generateColliders": "string_value",
  "generateFoliage": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool terrain25d-generate --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool terrain25d-generate --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the root Terrain25D GameObject. |
| `generateColliders` | `any` | No | Also generate 2D polygon colliders. Default: true. |
| `generateFoliage` | `any` | No | Also generate foliage (if FoliageGenerator present). Default: false. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
    },
    "generateColliders": {
      "$ref": "#/$defs/System.Boolean"
    },
    "generateFoliage": {
      "$ref": "#/$defs/System.Boolean"
    }
  },
  "$defs": {
    "System.Boolean": {
      "type": "boolean"
    }
  },
  "required": [
    "gameObjectName"
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

