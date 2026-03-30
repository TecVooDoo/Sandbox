---
name: ballistic-calculate-solution
description: |-
  Calculates the launch angle(s) needed to hit a target position from a source position.
  Returns 0, 1, or 2 solutions (low arc and high arc). Use the rotation to orient a launcher.
  This is a pure math calculation -- no scene objects are modified.
  fromX/Y/Z: world position of the projectile launch point.
  toX/Y/Z: world position of the target.
  speed: projectile launch speed in m/s.
  gravity: downward gravity (default 9.81 -- positive = downward pull).
---

# Heathen Ballistics / Calculate Aim Solution

## How to Call

```bash
unity-mcp-cli run-tool ballistic-calculate-solution --input '{
  "fromX": 0,
  "fromY": 0,
  "fromZ": 0,
  "toX": 0,
  "toY": 0,
  "toZ": 0,
  "speed": 0,
  "gravity": 0
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool ballistic-calculate-solution --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool ballistic-calculate-solution --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `fromX` | `number` | Yes | Launch position X. |
| `fromY` | `number` | Yes | Launch position Y. |
| `fromZ` | `number` | Yes | Launch position Z. |
| `toX` | `number` | Yes | Target position X. |
| `toY` | `number` | Yes | Target position Y. |
| `toZ` | `number` | Yes | Target position Z. |
| `speed` | `number` | Yes | Projectile speed in m/s. |
| `gravity` | `number` | No | Gravity magnitude (default 9.81, downward). |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "fromX": {
      "type": "number"
    },
    "fromY": {
      "type": "number"
    },
    "fromZ": {
      "type": "number"
    },
    "toX": {
      "type": "number"
    },
    "toY": {
      "type": "number"
    },
    "toZ": {
      "type": "number"
    },
    "speed": {
      "type": "number"
    },
    "gravity": {
      "type": "number"
    }
  },
  "required": [
    "fromX",
    "fromY",
    "fromZ",
    "toX",
    "toY",
    "toZ",
    "speed"
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

