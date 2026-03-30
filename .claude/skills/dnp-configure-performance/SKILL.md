---
name: dnp-configure-performance
description: |-
  Configures pooling and spam control on a DamageNumber component.
  enablePooling: recycle instances instead of destroy/instantiate (highly recommended for frequent spawning).
  poolSize: max instances kept in pool. Set based on max concurrent numbers expected.
  updateDelay: seconds between position/animation updates (default 0.0125 = 80fps updates). Increase to reduce CPU cost.
  spamGroup: string identifier for grouping nearby numbers (prevents overlap). Numbers with same group combine.
  enableCombination: merge nearby numbers with same spamGroup into one accumulating number.
  enablePush: push other numbers away from newly spawned ones.
---

# Damage Numbers Pro / Configure Performance

## How to Call

```bash
unity-mcp-cli run-tool dnp-configure-performance --input '{
  "gameObjectName": "string_value",
  "enablePooling": "string_value",
  "poolSize": "string_value",
  "updateDelay": "string_value",
  "spamGroup": "string_value",
  "enableCombination": "string_value",
  "enablePush": "string_value",
  "enableDestruction": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool dnp-configure-performance --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool dnp-configure-performance --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the GameObject with DamageNumber component. |
| `enablePooling` | `any` | No | Enable object pooling for this damage number type. |
| `poolSize` | `any` | No | Max pool size (instances kept for reuse). |
| `updateDelay` | `any` | No | Update interval in seconds (default 0.0125 = 80fps). Higher = less CPU. |
| `spamGroup` | `string` | No | Spam group identifier. Numbers with same group can combine. |
| `enableCombination` | `any` | No | Merge nearby same-group numbers into one accumulating number. |
| `enablePush` | `any` | No | Push other numbers away when spawning. |
| `enableDestruction` | `any` | No | Destroy nearby same-group numbers when spawning. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
    },
    "enablePooling": {
      "$ref": "#/$defs/System.Boolean"
    },
    "poolSize": {
      "$ref": "#/$defs/System.Int32"
    },
    "updateDelay": {
      "$ref": "#/$defs/System.Single"
    },
    "spamGroup": {
      "type": "string"
    },
    "enableCombination": {
      "$ref": "#/$defs/System.Boolean"
    },
    "enablePush": {
      "$ref": "#/$defs/System.Boolean"
    },
    "enableDestruction": {
      "$ref": "#/$defs/System.Boolean"
    }
  },
  "$defs": {
    "System.Boolean": {
      "type": "boolean"
    },
    "System.Int32": {
      "type": "integer"
    },
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

