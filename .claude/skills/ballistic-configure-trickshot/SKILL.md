---
name: ballistic-configure-trickshot
description: |-
  Adds (if missing) and configures a TrickShot component for bounce-trajectory launching.
  TrickShot predicts bounce paths and spawns a projectile template to follow them.
  speed: projectile speed in m/s.
  radius: collision sphere radius for trajectory prediction.
  bounces: number of bounces to simulate (0 = no bounces).
  bounceDamping [0-1]: velocity retained per bounce (0 = stops dead, 1 = no damping).
  distance: max trajectory length. If distanceIsTotalLength=false, this is per-bounce.
  resolution: simulation step size (smaller = more accurate, more expensive, 0.01 recommended).
  templateName: name of a GameObject with BallisticPathFollow to use as projectile template.
---

# Heathen Ballistics / Configure TrickShot

## How to Call

```bash
unity-mcp-cli run-tool ballistic-configure-trickshot --input '{
  "gameObjectName": "string_value",
  "speed": "string_value",
  "radius": "string_value",
  "bounces": "string_value",
  "bounceDamping": "string_value",
  "distance": "string_value",
  "distanceIsTotalLength": "string_value",
  "resolution": "string_value",
  "templateName": "string_value",
  "gravityY": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool ballistic-configure-trickshot --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool ballistic-configure-trickshot --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the GameObject to add TrickShot to. |
| `speed` | `any` | No | Projectile speed in m/s. |
| `radius` | `any` | No | Collision sphere radius for trajectory prediction. |
| `bounces` | `any` | No | Number of bounces to simulate (0 = no bounces). |
| `bounceDamping` | `any` | No | Velocity multiplier retained per bounce [0-1]. 1 = no damping. |
| `distance` | `any` | No | Max trajectory length in world units. |
| `distanceIsTotalLength` | `any` | No | If true, distance is total path length. If false, per-bounce. |
| `resolution` | `any` | No | Trajectory simulation step size. Smaller = more accurate. |
| `templateName` | `string` | No | Name of GameObject with BallisticPathFollow to use as projectile template. |
| `gravityY` | `any` | No | Gravity Y acceleration (default -9.81). |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
    },
    "speed": {
      "$ref": "#/$defs/System.Single"
    },
    "radius": {
      "$ref": "#/$defs/System.Single"
    },
    "bounces": {
      "$ref": "#/$defs/System.Int32"
    },
    "bounceDamping": {
      "$ref": "#/$defs/System.Single"
    },
    "distance": {
      "$ref": "#/$defs/System.Single"
    },
    "distanceIsTotalLength": {
      "$ref": "#/$defs/System.Boolean"
    },
    "resolution": {
      "$ref": "#/$defs/System.Single"
    },
    "templateName": {
      "type": "string"
    },
    "gravityY": {
      "$ref": "#/$defs/System.Single"
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

