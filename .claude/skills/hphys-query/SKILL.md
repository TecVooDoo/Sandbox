---
name: hphys-query
description: |-
  Lists all Heathen Unity Physics components on a GameObject and their key settings.
  Reports PhysicsData (hull, volume, mass), BuoyantBody (magnitude, mode, submergedRatio),
  ForceEffectField (strength, radius, global), and ForceEffectReceiver (linear, angular, sensitivity).
  Use this before configuring to understand the current physics setup.
---

# Heathen Physics / Query Components

## How to Call

```bash
unity-mcp-cli run-tool hphys-query --input '{
  "gameObjectName": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool hphys-query --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool hphys-query --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the GameObject to inspect. |

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

