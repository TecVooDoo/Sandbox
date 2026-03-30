---
name: uphys-configure-shape
description: |-
  Configures collider components on a GameObject for Unity.Physics baking.
  Works with standard Unity colliders (BoxCollider, SphereCollider, CapsuleCollider, MeshCollider)
  which Unity.Physics bakes into ECS PhysicsCollider at bake time.
  Can set: isTrigger, physics material properties (friction, restitution, combine modes).
  To add a collider, specify shapeType. To configure an existing collider at a specific index, use colliderIndex.
  Only provided parameters are applied; omitted parameters keep their current values.
---

# Unity Physics / Configure Collider

## How to Call

```bash
unity-mcp-cli run-tool uphys-configure-shape --input '{
  "gameObjectName": "string_value",
  "colliderIndex": 0,
  "shapeType": "string_value",
  "isTrigger": "string_value",
  "staticFriction": 0,
  "dynamicFriction": 0,
  "bounciness": 0,
  "frictionCombine": 0,
  "bounceCombine": 0,
  "centerX": 0,
  "centerY": 0,
  "centerZ": 0,
  "sizeX": 0,
  "sizeY": 0,
  "sizeZ": 0,
  "radius": 0,
  "height": 0,
  "direction": 0,
  "convex": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool uphys-configure-shape --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool uphys-configure-shape --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the GameObject to configure. |
| `colliderIndex` | `integer` | No | Collider index to configure if multiple exist (0-based). Default 0. |
| `shapeType` | `string` | No | Add a new collider of this type: Box, Sphere, Capsule, Mesh. Leave empty to configure existing. |
| `isTrigger` | `any` | No | Set collider as trigger. |
| `staticFriction` | `number` | No | Static friction coefficient (0-1+). Creates/assigns a PhysicsMaterial if needed. |
| `dynamicFriction` | `number` | No | Dynamic friction coefficient (0-1+). Creates/assigns a PhysicsMaterial if needed. |
| `bounciness` | `number` | No | Bounciness / restitution (0-1). Creates/assigns a PhysicsMaterial if needed. |
| `frictionCombine` | `integer` | No | Friction combine mode: 0=Average, 1=Minimum, 2=Multiply, 3=Maximum. |
| `bounceCombine` | `integer` | No | Bounce combine mode: 0=Average, 1=Minimum, 2=Multiply, 3=Maximum. |
| `centerX` | `number` | No | Box/Capsule/Sphere center X. |
| `centerY` | `number` | No | Box/Capsule/Sphere center Y. |
| `centerZ` | `number` | No | Box/Capsule/Sphere center Z. |
| `sizeX` | `number` | No | Box size X. |
| `sizeY` | `number` | No | Box size Y. |
| `sizeZ` | `number` | No | Box size Z. |
| `radius` | `number` | No | Sphere/Capsule radius. |
| `height` | `number` | No | Capsule height. |
| `direction` | `integer` | No | Capsule direction axis: 0=X, 1=Y, 2=Z. |
| `convex` | `any` | No | MeshCollider convex flag. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
    },
    "colliderIndex": {
      "type": "integer"
    },
    "shapeType": {
      "type": "string"
    },
    "isTrigger": {
      "$ref": "#/$defs/System.Boolean"
    },
    "staticFriction": {
      "type": "number"
    },
    "dynamicFriction": {
      "type": "number"
    },
    "bounciness": {
      "type": "number"
    },
    "frictionCombine": {
      "type": "integer"
    },
    "bounceCombine": {
      "type": "integer"
    },
    "centerX": {
      "type": "number"
    },
    "centerY": {
      "type": "number"
    },
    "centerZ": {
      "type": "number"
    },
    "sizeX": {
      "type": "number"
    },
    "sizeY": {
      "type": "number"
    },
    "sizeZ": {
      "type": "number"
    },
    "radius": {
      "type": "number"
    },
    "height": {
      "type": "number"
    },
    "direction": {
      "type": "integer"
    },
    "convex": {
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

