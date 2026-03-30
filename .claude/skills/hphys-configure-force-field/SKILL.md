---
name: hphys-configure-force-field
description: |-
  Adds (if missing) and configures a ForceEffectField component.
  ForceEffectField applies forces to nearby ForceEffectReceiver objects within its radius.
  strength: force multiplier applied to receivers.
  radius: sphere radius within which receivers are affected (ignored when isGlobal=true).
  isGlobal: if true, affects all ForceEffectReceiver objects in the scene regardless of distance.
  A SphereCollider with isTrigger=true is required for trigger-based detection -- add one manually or set isGlobal=true.
---

# Heathen Physics / Configure Force Field

## How to Call

```bash
unity-mcp-cli run-tool hphys-configure-force-field --input '{
  "gameObjectName": "string_value",
  "strength": "string_value",
  "radius": "string_value",
  "isGlobal": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool hphys-configure-force-field --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool hphys-configure-force-field --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the GameObject to add ForceEffectField to. |
| `strength` | `any` | No | Force multiplier strength. |
| `radius` | `any` | No | Effect radius in world units. Only used when isGlobal=false. |
| `isGlobal` | `any` | No | If true, affects all receivers globally (no radius check). |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
    },
    "strength": {
      "$ref": "#/$defs/System.Single"
    },
    "radius": {
      "$ref": "#/$defs/System.Single"
    },
    "isGlobal": {
      "$ref": "#/$defs/System.Boolean"
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

