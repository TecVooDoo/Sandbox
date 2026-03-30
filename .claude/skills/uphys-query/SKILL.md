---
name: uphys-query
description: |-
  Reads all Unity Physics authoring components on a GameObject.
  Reports: Rigidbody (mass, drag, angularDrag, useGravity, isKinematic, interpolation, constraints),
  Collider (type, isTrigger, material, bounds), and PhysicsStepAuthoring (gravity, solver iterations,
  substep count, multi-threaded, collision tolerance). Works with the standard Unity Physics hybrid
  workflow that bakes from built-in Rigidbody and Collider components.
---

# Unity Physics / Query Authoring

## How to Call

```bash
unity-mcp-cli run-tool uphys-query --input '{
  "gameObjectName": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool uphys-query --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool uphys-query --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the GameObject to query for physics authoring components. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
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

