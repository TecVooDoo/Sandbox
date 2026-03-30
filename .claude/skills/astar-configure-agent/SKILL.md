---
name: astar-configure-agent
description: |-
  Configure an AI movement agent (AIPath, AILerp, or RichAI) on a GameObject.
  Sets speed, rotation, destination threshold, slowdown, waypoint look-ahead, and other movement settings.
  Optionally sets the agent's destination to another GameObject's position via destinationName.
---

# A* Pathfinding / Configure Agent

## How to Call

```bash
unity-mcp-cli run-tool astar-configure-agent --input '{
  "gameObjectName": "string_value",
  "maxSpeed": "string_value",
  "rotationSpeed": "string_value",
  "endReachedDistance": "string_value",
  "slowdownDistance": "string_value",
  "pickNextWaypointDist": "string_value",
  "enableRotation": "string_value",
  "constrainInsideGraph": "string_value",
  "destinationName": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool astar-configure-agent --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool astar-configure-agent --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the GameObject with an AI movement component. |
| `maxSpeed` | `any` | No | Maximum movement speed. |
| `rotationSpeed` | `any` | No | Rotation speed in degrees/sec. |
| `endReachedDistance` | `any` | No | Distance threshold to consider destination reached. |
| `slowdownDistance` | `any` | No | Distance at which agent starts slowing down. |
| `pickNextWaypointDist` | `any` | No | Path waypoint look-ahead distance. |
| `enableRotation` | `any` | No | Enable rotation towards movement direction. |
| `constrainInsideGraph` | `any` | No | Constrain agent position inside walkable graph. |
| `destinationName` | `string` | No | Name of a GameObject whose position becomes the agent's destination. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
    },
    "maxSpeed": {
      "$ref": "#/$defs/System.Single"
    },
    "rotationSpeed": {
      "$ref": "#/$defs/System.Single"
    },
    "endReachedDistance": {
      "$ref": "#/$defs/System.Single"
    },
    "slowdownDistance": {
      "$ref": "#/$defs/System.Single"
    },
    "pickNextWaypointDist": {
      "$ref": "#/$defs/System.Single"
    },
    "enableRotation": {
      "$ref": "#/$defs/System.Boolean"
    },
    "constrainInsideGraph": {
      "$ref": "#/$defs/System.Boolean"
    },
    "destinationName": {
      "type": "string"
    }
  },
  "$defs": {
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

