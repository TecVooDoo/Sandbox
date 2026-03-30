---
name: ballistic-configure-aim
description: |-
  Adds (if missing) and configures a BallisticAim component.
  BallisticAim drives a dual-pivot turret or launcher to aim at a target position.
  initialSpeed: projectile launch speed (m/s).
  yPivotName / xPivotName: names of child GameObjects used as yaw and pitch pivots.
  yLimitMin/Max: yaw rotation limits in degrees (default -180 to 180 = full rotation).
  xLimitMin/Max: pitch rotation limits in degrees (default -180 to 180 = full rotation).
  gravityY: vertical gravity acceleration (default -9.81).
---

# Heathen Ballistics / Configure Aim

## How to Call

```bash
unity-mcp-cli run-tool ballistic-configure-aim --input '{
  "gameObjectName": "string_value",
  "initialSpeed": "string_value",
  "yPivotName": "string_value",
  "xPivotName": "string_value",
  "yLimitMin": "string_value",
  "yLimitMax": "string_value",
  "xLimitMin": "string_value",
  "xLimitMax": "string_value",
  "gravityY": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool ballistic-configure-aim --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool ballistic-configure-aim --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the GameObject to add BallisticAim to. |
| `initialSpeed` | `any` | No | Projectile launch speed in m/s. |
| `yPivotName` | `string` | No | Name of the child GameObject used as the yaw (Y-axis) pivot. |
| `xPivotName` | `string` | No | Name of the child GameObject used as the pitch (X-axis) pivot. |
| `yLimitMin` | `any` | No | Minimum yaw angle limit in degrees. |
| `yLimitMax` | `any` | No | Maximum yaw angle limit in degrees. |
| `xLimitMin` | `any` | No | Minimum pitch angle limit in degrees. |
| `xLimitMax` | `any` | No | Maximum pitch angle limit in degrees. |
| `gravityY` | `any` | No | Gravity Y acceleration (default -9.81). |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
    },
    "initialSpeed": {
      "$ref": "#/$defs/System.Single"
    },
    "yPivotName": {
      "type": "string"
    },
    "xPivotName": {
      "type": "string"
    },
    "yLimitMin": {
      "$ref": "#/$defs/System.Single"
    },
    "yLimitMax": {
      "$ref": "#/$defs/System.Single"
    },
    "xLimitMin": {
      "$ref": "#/$defs/System.Single"
    },
    "xLimitMax": {
      "$ref": "#/$defs/System.Single"
    },
    "gravityY": {
      "$ref": "#/$defs/System.Single"
    }
  },
  "$defs": {
    "System.Single": {
      "type": "number"
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

