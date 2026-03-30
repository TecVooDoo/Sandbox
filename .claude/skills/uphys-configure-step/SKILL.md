---
name: uphys-configure-step
description: |-
  Adds (if missing) and configures a PhysicsStepAuthoring component on a GameObject.
  PhysicsStepAuthoring controls global ECS physics simulation parameters: gravity, solver iterations,
  substep count, multi-threading, collision tolerance, broadphase settings, and depenetration velocity.
  Only one PhysicsStepAuthoring should exist in a scene. Only provided parameters are applied;
  omitted parameters keep their current values.
---

# Unity Physics / Configure Step

## How to Call

```bash
unity-mcp-cli run-tool uphys-configure-step --input '{
  "gameObjectName": "string_value",
  "gravityX": 0,
  "gravityY": 0,
  "gravityZ": 0,
  "solverIterationCount": 0,
  "substepCount": 0,
  "multiThreaded": "string_value",
  "collisionTolerance": 0,
  "enableSolverStabilization": "string_value",
  "synchronizeCollisionWorld": "string_value",
  "incrementalDynamicBroadphase": "string_value",
  "incrementalStaticBroadphase": "string_value",
  "maxDynamicDepenetrationVelocity": 0,
  "maxStaticDepenetrationVelocity": 0
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool uphys-configure-step --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool uphys-configure-step --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the GameObject with (or to add) PhysicsStepAuthoring. |
| `gravityX` | `number` | No | Gravity X component. |
| `gravityY` | `number` | No | Gravity Y component (default -9.81). |
| `gravityZ` | `number` | No | Gravity Z component. |
| `solverIterationCount` | `integer` | No | Number of solver iterations. Higher = more stable, worse performance. Min 1. |
| `substepCount` | `integer` | No | Number of substeps per frame. Higher = smaller timesteps, more stable. Min 1. |
| `multiThreaded` | `any` | No | Enable multi-threaded physics processing. |
| `collisionTolerance` | `number` | No | Collision tolerance. Minimum distance for contact creation. Increase if tunneling occurs. |
| `enableSolverStabilization` | `any` | No | Enable solver stabilization heuristic for better stacking behavior. |
| `synchronizeCollisionWorld` | `any` | No | Synchronize collision world after step for more precise queries. |
| `incrementalDynamicBroadphase` | `any` | No | Enable incremental dynamic broadphase for scenes with many sleeping dynamic bodies. |
| `incrementalStaticBroadphase` | `any` | No | Enable incremental static broadphase for scenes with many static bodies. |
| `maxDynamicDepenetrationVelocity` | `number` | No | Max velocity for separating intersecting dynamic bodies. |
| `maxStaticDepenetrationVelocity` | `number` | No | Max velocity for separating dynamic bodies intersecting with static bodies. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
    },
    "gravityX": {
      "type": "number"
    },
    "gravityY": {
      "type": "number"
    },
    "gravityZ": {
      "type": "number"
    },
    "solverIterationCount": {
      "type": "integer"
    },
    "substepCount": {
      "type": "integer"
    },
    "multiThreaded": {
      "$ref": "#/$defs/System.Boolean"
    },
    "collisionTolerance": {
      "type": "number"
    },
    "enableSolverStabilization": {
      "$ref": "#/$defs/System.Boolean"
    },
    "synchronizeCollisionWorld": {
      "$ref": "#/$defs/System.Boolean"
    },
    "incrementalDynamicBroadphase": {
      "$ref": "#/$defs/System.Boolean"
    },
    "incrementalStaticBroadphase": {
      "$ref": "#/$defs/System.Boolean"
    },
    "maxDynamicDepenetrationVelocity": {
      "type": "number"
    },
    "maxStaticDepenetrationVelocity": {
      "type": "number"
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

