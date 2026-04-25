---
name: tcc-add-hull
description: |-
  Adds a hull to an existing TCC setup.
  hullType: Box, ConvexHull, Sphere, Face, FaceAsBox, Auto (VHACD), Capsule.
  isChild: if true, generates collider on a child GameObject (default false = same GO).
  isTrigger: if true, generated collider is a trigger.
  materialName: optional PhysicsMaterial asset name.
  paintAllFaces: if true, selects all triangles for this hull (required for Auto/ConvexHull workflows).
  After adding, call tcc-generate to bake colliders.
---

# Technie Collider / Add Hull

## How to Call

```bash
unity-mcp-cli run-tool tcc-add-hull --input '{
  "gameObjectName": "string_value",
  "hullType": "string_value",
  "isChild": false,
  "isTrigger": false,
  "materialName": "string_value",
  "paintAllFaces": false,
  "hullName": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool tcc-add-hull --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool tcc-add-hull --input-file - <<'EOF'
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
| `hullType` | `string` | No | Hull type: Box, ConvexHull, Sphere, Face, FaceAsBox, Auto, Capsule. |
| `isChild` | `boolean` | No | Generate collider on a child GameObject. |
| `isTrigger` | `boolean` | No | Generated collider is a trigger. |
| `materialName` | `string` | No | Optional PhysicsMaterial asset name. |
| `paintAllFaces` | `boolean` | No | Select all faces for this hull (required for Auto/ConvexHull). |
| `hullName` | `string` | No | Optional name override for this hull. |

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
    "isChild": {
      "type": "boolean"
    },
    "isTrigger": {
      "type": "boolean"
    },
    "materialName": {
      "type": "string"
    },
    "paintAllFaces": {
      "type": "boolean"
    },
    "hullName": {
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

