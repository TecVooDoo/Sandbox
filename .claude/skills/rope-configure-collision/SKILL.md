---
name: rope-configure-collision
description: |-
  Sets collision parameters on a Rope component.
  enabled: toggles collision detection entirely.
  influenceRigidbodies: whether rope particles push attached rigidbodies.
  friction [0-20]: friction coefficient against surfaces.
  stride [1-20]: check every Nth particle (higher = faster but less accurate).
  collisionMargin [0-1.0]: extra buffer around rope particles for collision.
---

# Rope Toolkit / Configure Collision

## How to Call

```bash
unity-mcp-cli run-tool rope-configure-collision --input '{
  "gameObjectName": "string_value",
  "enabled": "string_value",
  "influenceRigidbodies": "string_value",
  "friction": "string_value",
  "stride": "string_value",
  "collisionMargin": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool rope-configure-collision --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool rope-configure-collision --input-file - <<'EOF'
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
| `enabled` | `any` | No | Enable collision detection. |
| `influenceRigidbodies` | `any` | No | Whether rope can push rigidbodies. |
| `friction` | `any` | No | Friction coefficient [0-20]. |
| `stride` | `any` | No | Check every Nth particle [1-20]. Higher = faster, less precise. |
| `collisionMargin` | `any` | No | Extra collision margin [0-1.0]. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
    },
    "enabled": {
      "$ref": "#/$defs/System.Boolean"
    },
    "influenceRigidbodies": {
      "$ref": "#/$defs/System.Boolean"
    },
    "friction": {
      "$ref": "#/$defs/System.Single"
    },
    "stride": {
      "$ref": "#/$defs/System.Int32"
    },
    "collisionMargin": {
      "$ref": "#/$defs/System.Single"
    }
  },
  "$defs": {
    "System.Boolean": {
      "type": "boolean"
    },
    "System.Single": {
      "type": "number"
    },
    "System.Int32": {
      "type": "integer"
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

