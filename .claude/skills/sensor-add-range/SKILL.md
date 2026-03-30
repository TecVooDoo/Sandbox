---
name: sensor-add-range
description: |-
  Adds and configures a RangeSensor or RaySensor on a GameObject.
  For RangeSensor: configures sphere shape with radius, detection layers, detection mode, pulse settings.
  For RaySensor: configures ray length, direction, detection/obstruction layers, pulse settings.
  Use 'sensor-query' afterward to verify the configuration.
---

# SensorToolkit / Add Range or Ray Sensor

## How to Call

```bash
unity-mcp-cli run-tool sensor-add-range --input '{
  "gameObjectName": "string_value",
  "sensorType": "string_value",
  "radius": "string_value",
  "length": "string_value",
  "detectsOnLayers": "string_value",
  "pulseMode": "string_value",
  "pulseInterval": "string_value",
  "ignoreTriggerColliders": "string_value",
  "detectionMode": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool sensor-add-range --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool sensor-add-range --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the target GameObject. |
| `sensorType` | `string` | Yes | Sensor type to add: 'Range' or 'Ray'. |
| `radius` | `any` | No | Sphere radius for RangeSensor. Default 5. |
| `length` | `any` | No | Ray length for RaySensor. Default 10. |
| `detectsOnLayers` | `any` | No | Layer mask for detection layers (integer bitmask). Null to keep default. |
| `pulseMode` | `string` | No | Pulse mode: 'Manual', 'FixedInterval', 'EachFrame'. Default 'EachFrame'. |
| `pulseInterval` | `any` | No | Seconds between pulses when using FixedInterval mode. |
| `ignoreTriggerColliders` | `any` | No | If true, sensor ignores trigger colliders. |
| `detectionMode` | `string` | No | Detection mode: 'Colliders', 'RigidBodies', 'Either'. Default 'Colliders'. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
    },
    "sensorType": {
      "type": "string"
    },
    "radius": {
      "$ref": "#/$defs/System.Single"
    },
    "length": {
      "$ref": "#/$defs/System.Single"
    },
    "detectsOnLayers": {
      "$ref": "#/$defs/System.Int32"
    },
    "pulseMode": {
      "type": "string"
    },
    "pulseInterval": {
      "$ref": "#/$defs/System.Single"
    },
    "ignoreTriggerColliders": {
      "$ref": "#/$defs/System.Boolean"
    },
    "detectionMode": {
      "type": "string"
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
    "gameObjectName",
    "sensorType"
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

