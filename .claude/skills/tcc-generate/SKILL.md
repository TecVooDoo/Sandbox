---
name: tcc-generate
description: |-
  Triggers GenerateColliders on a TCC setup. Bakes hulls into actual Collider components.
  This kicks off a coroutine — for Auto hulls, VHACD runs in background and may take time (Low: ~1s, High: ~10s, Placebo: ~60s).
  Use tcc-query afterwards to check IsGeneratingColliders status and final collider list.
  Returns immediately; the generation completes asynchronously.
---

# Technie Collider / Generate

## How to Call

```bash
unity-mcp-cli run-tool tcc-generate --input '{
  "gameObjectName": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool tcc-generate --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool tcc-generate --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the GameObject with TCC setup. |

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

