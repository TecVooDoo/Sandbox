---
name: tcc-bulk
description: |-
  Sets the same property on ALL hulls of a TCC setup at once.
  Wraps RigidColliderCreator's SetAllTypes / SetAllMaterials / SetAllAsChild / SetAllAsTrigger.
  Provide only the properties you want to change.
  hullType: Box, ConvexHull, Sphere, Face, FaceAsBox, Auto, Capsule.
  materialName: PhysicsMaterial asset name (use 'none' to clear).
  After bulk changes, call tcc-generate to rebuild colliders.
---

# Technie Collider / Bulk Configure

## How to Call

```bash
unity-mcp-cli run-tool tcc-bulk --input '{
  "gameObjectName": "string_value",
  "hullType": "string_value",
  "materialName": "string_value",
  "isChild": "string_value",
  "isTrigger": "string_value",
  "maxPlanes": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool tcc-bulk --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool tcc-bulk --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the GameObject with TCC setup. |
| `hullType` | `string` | No | Apply this hull type to all hulls. |
| `materialName` | `string` | No | Apply this PhysicsMaterial to all hulls (use 'none' to clear). |
| `isChild` | `any` | No | Set isChildCollider on all hulls. |
| `isTrigger` | `any` | No | Set isTrigger on all hulls. |
| `maxPlanes` | `any` | No | Set maxPlanes on all hulls (1-255). |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
    },
    "hullType": {
      "type": "string"
    },
    "materialName": {
      "type": "string"
    },
    "isChild": {
      "$ref": "#/$defs/System.Boolean"
    },
    "isTrigger": {
      "$ref": "#/$defs/System.Boolean"
    },
    "maxPlanes": {
      "$ref": "#/$defs/System.Int32"
    }
  },
  "$defs": {
    "System.Boolean": {
      "type": "boolean"
    },
    "System.Int32": {
      "type": "integer"
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

