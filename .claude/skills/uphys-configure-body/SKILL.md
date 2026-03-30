---
name: uphys-configure-body
description: |-
  Adds (if missing) and configures a Rigidbody component on a GameObject.
  The Rigidbody is the standard Unity component that Unity.Physics bakes into ECS PhysicsMass,
  PhysicsVelocity, PhysicsDamping, and PhysicsGravityFactor at bake time. Only provided
  parameters are applied; omitted parameters keep their current values.
---

# Unity Physics / Configure Rigidbody

## How to Call

```bash
unity-mcp-cli run-tool uphys-configure-body --input '{
  "gameObjectName": "string_value",
  "mass": 0,
  "drag": 0,
  "angularDrag": 0,
  "useGravity": "string_value",
  "isKinematic": "string_value",
  "interpolation": 0,
  "collisionDetection": 0,
  "constraints": 0,
  "maxLinearVelocity": 0,
  "maxAngularVelocity": 0,
  "automaticCenterOfMass": "string_value",
  "automaticInertiaTensor": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool uphys-configure-body --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool uphys-configure-body --input-file - <<'EOF'
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
| `mass` | `number` | No | Mass in kg. Min 0.0001. |
| `drag` | `number` | No | Linear drag (baked as PhysicsDamping.Linear). |
| `angularDrag` | `number` | No | Angular drag (baked as PhysicsDamping.Angular). |
| `useGravity` | `any` | No | Whether gravity applies to this body. |
| `isKinematic` | `any` | No | If true, body is kinematic (infinite mass, not affected by forces). |
| `interpolation` | `integer` | No | Interpolation mode: 0=None, 1=Interpolate, 2=Extrapolate. |
| `collisionDetection` | `integer` | No | Collision detection mode: 0=Discrete, 1=Continuous, 2=ContinuousDynamic, 3=ContinuousSpeculative. |
| `constraints` | `integer` | No | Rigidbody constraints bitmask (0=None, 2=FreezePositionX, 4=FreezePositionY, 8=FreezePositionZ, 16=FreezeRotationX, 32=FreezeRotationY, 64=FreezeRotationZ, 126=FreezeAll). |
| `maxLinearVelocity` | `number` | No | Max linear velocity cap. |
| `maxAngularVelocity` | `number` | No | Max angular velocity cap. |
| `automaticCenterOfMass` | `any` | No | If true, auto-compute center of mass from colliders. |
| `automaticInertiaTensor` | `any` | No | If true, auto-compute inertia tensor from colliders. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
    },
    "mass": {
      "type": "number"
    },
    "drag": {
      "type": "number"
    },
    "angularDrag": {
      "type": "number"
    },
    "useGravity": {
      "$ref": "#/$defs/System.Boolean"
    },
    "isKinematic": {
      "$ref": "#/$defs/System.Boolean"
    },
    "interpolation": {
      "type": "integer"
    },
    "collisionDetection": {
      "type": "integer"
    },
    "constraints": {
      "type": "integer"
    },
    "maxLinearVelocity": {
      "type": "number"
    },
    "maxAngularVelocity": {
      "type": "number"
    },
    "automaticCenterOfMass": {
      "$ref": "#/$defs/System.Boolean"
    },
    "automaticInertiaTensor": {
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

