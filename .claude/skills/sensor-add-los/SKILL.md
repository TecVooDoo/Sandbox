---
name: sensor-add-los
description: |-
  Adds and configures a LOSSensor (Line of Sight) on a GameObject.
  The LOSSensor is a compound sensor that tests line of sight for detections from an input sensor.
  It casts rays at detected objects and calculates the ratio that are unobstructed.
  Configure blocking layers, number of rays, view angle limits, and minimum visibility threshold.
---

# SensorToolkit / Add LOS Sensor

## How to Call

```bash
unity-mcp-cli run-tool sensor-add-los --input '{
  "gameObjectName": "string_value",
  "inputSensorName": "string_value",
  "blocksLineOfSight": "string_value",
  "numberOfRays": "string_value",
  "maxDistance": "string_value",
  "limitViewAngle": "string_value",
  "maxHorizAngle": "string_value",
  "maxVertAngle": "string_value",
  "minimumVisibility": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool sensor-add-los --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool sensor-add-los --input-file - <<'EOF'
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
| `inputSensorName` | `string` | No | Name of the GameObject with the input sensor (e.g. a RangeSensor). If omitted, expects an input sensor on the same GameObject. |
| `blocksLineOfSight` | `any` | No | Layer mask for layers that block line of sight (integer bitmask). |
| `numberOfRays` | `any` | No | Number of rays to cast per object for visibility testing. Range 1-20. Default 1. |
| `maxDistance` | `any` | No | Maximum detection distance. Requires limitDistance to be true. |
| `limitViewAngle` | `any` | No | Enable view angle limits. Default false. |
| `maxHorizAngle` | `any` | No | Maximum horizontal view angle in degrees (0-180). Used when limitViewAngle is true. |
| `maxVertAngle` | `any` | No | Maximum vertical view angle in degrees (0-90). Used when limitViewAngle is true. |
| `minimumVisibility` | `any` | No | Minimum visibility ratio (0-1) for an object to be considered detected. Default 0.5. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
    },
    "inputSensorName": {
      "type": "string"
    },
    "blocksLineOfSight": {
      "$ref": "#/$defs/System.Int32"
    },
    "numberOfRays": {
      "$ref": "#/$defs/System.Int32"
    },
    "maxDistance": {
      "$ref": "#/$defs/System.Single"
    },
    "limitViewAngle": {
      "$ref": "#/$defs/System.Boolean"
    },
    "maxHorizAngle": {
      "$ref": "#/$defs/System.Single"
    },
    "maxVertAngle": {
      "$ref": "#/$defs/System.Single"
    },
    "minimumVisibility": {
      "$ref": "#/$defs/System.Single"
    }
  },
  "$defs": {
    "System.Int32": {
      "type": "integer"
    },
    "System.Single": {
      "type": "number"
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

