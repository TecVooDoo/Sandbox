---
name: sensor-configure-steering
description: |-
  Configures a SteeringSensor component on a GameObject.
  Sets seek mode (Position, Direction, Wander, Stop), seek target, arrive/stopping distances,
  resolution, locomotion mode, and spherical mode.
  The SteeringSensor implements context-based steering for AI navigation.
---

# SensorToolkit / Configure Steering Sensor

## How to Call

```bash
unity-mcp-cli run-tool sensor-configure-steering --input '{
  "gameObjectName": "string_value",
  "seekMode": "string_value",
  "seekTargetName": "string_value",
  "arriveDistanceThreshold": "string_value",
  "stoppingDistance": "string_value",
  "resolution": "string_value",
  "locomotionMode": "string_value",
  "isSpherical": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool sensor-configure-steering --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool sensor-configure-steering --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the GameObject with a SteeringSensor component. |
| `seekMode` | `string` | No | Seek mode: 'Position', 'Direction', 'Wander', 'Stop'. Null to keep current. |
| `seekTargetName` | `string` | No | Name of a GameObject to seek toward (sets SeekMode to Position). Null to skip. |
| `arriveDistanceThreshold` | `any` | No | Distance threshold to consider destination reached. Null to keep current. |
| `stoppingDistance` | `any` | No | Distance at which the agent begins slowing down. Null to keep current. |
| `resolution` | `any` | No | Direction bucket count for steering grid resolution. Null to keep current. |
| `locomotionMode` | `string` | No | Locomotion mode: 'None', 'RigidBodyFlying', 'RigidBodyCharacter', 'UnityCharacterController'. Null to keep current. |
| `isSpherical` | `any` | No | Use spherical (3D) steering vectors instead of planar. Null to keep current. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
    },
    "seekMode": {
      "type": "string"
    },
    "seekTargetName": {
      "type": "string"
    },
    "arriveDistanceThreshold": {
      "$ref": "#/$defs/System.Single"
    },
    "stoppingDistance": {
      "$ref": "#/$defs/System.Single"
    },
    "resolution": {
      "$ref": "#/$defs/System.Int32"
    },
    "locomotionMode": {
      "type": "string"
    },
    "isSpherical": {
      "$ref": "#/$defs/System.Boolean"
    }
  },
  "$defs": {
    "System.Single": {
      "type": "number"
    },
    "System.Int32": {
      "type": "integer"
    },
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

