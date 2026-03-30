---
name: rope-add-connection
description: |-
  Adds or configures a RopeConnection component on a rope GameObject.
  connectionType options:
    PinRopeToTransform -- pins a rope particle to a fixed transform (no rigidbody needed).
    PinTransformToRope -- pins a transform to follow a rope particle position.
    PullRigidbodyToRope -- applies spring force pulling a rigidbody toward a rope point.
    TwoWayCouplingBetweenRigidbodyAndRope -- full two-way physics between rigidbody and rope.
  ropeLocation [0-1]: normalized distance along the rope (0=start, 0.5=middle, 1=end).
  autoFindRopeLocation: if true, ignores ropeLocation and finds nearest point automatically.
  If a RopeConnection already exists, configures the first one found.
---

# Rope Toolkit / Add Connection

## How to Call

```bash
unity-mcp-cli run-tool rope-add-connection --input '{
  "gameObjectName": "string_value",
  "connectionType": "string_value",
  "ropeLocation": 0,
  "autoFindRopeLocation": false,
  "stiffness": "string_value",
  "damping": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool rope-add-connection --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool rope-add-connection --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the GameObject with the Rope component. |
| `connectionType` | `string` | Yes | Connection type: PinRopeToTransform, PinTransformToRope, PullRigidbodyToRope, TwoWayCouplingBetweenRigidbodyAndRope. |
| `ropeLocation` | `number` | No | Normalized position along rope [0-1]. 0=start, 1=end. |
| `autoFindRopeLocation` | `boolean` | No | If true, auto-finds nearest rope point (overrides ropeLocation). |
| `stiffness` | `any` | No | Stiffness for rigidbody connections [0-1.0]. |
| `damping` | `any` | No | Damping for rigidbody connections [0-1.0]. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
    },
    "connectionType": {
      "type": "string"
    },
    "ropeLocation": {
      "type": "number"
    },
    "autoFindRopeLocation": {
      "type": "boolean"
    },
    "stiffness": {
      "$ref": "#/$defs/System.Single"
    },
    "damping": {
      "$ref": "#/$defs/System.Single"
    }
  },
  "$defs": {
    "System.Single": {
      "type": "number"
    }
  },
  "required": [
    "gameObjectName",
    "connectionType"
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

