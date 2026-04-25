---
name: tcc-create
description: |-
  Adds Technie Collider Creator setup to a GameObject and creates a PaintingData asset.
  Opens the RigidColliderCreator window and calls GenerateAsset to create both PaintingData and HullData assets.
  After creation, use tcc-add-hull to add hulls, then tcc-generate to bake colliders.
  The GameObject MUST have a MeshFilter (or SkinnedMeshRenderer) with a sharedMesh.
---

# Technie Collider / Create

## How to Call

```bash
unity-mcp-cli run-tool tcc-create --input '{
  "gameObjectName": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool tcc-create --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool tcc-create --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the GameObject to set up. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
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

