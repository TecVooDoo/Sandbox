---
name: koreo-beattime
description: |-
  Returns the current beat time for a specific Koreography track (or global if trackName is omitted).
  subdivision divides each beat: 1=quarter notes, 2=eighth, 4=sixteenth.
  Useful for syncing visuals or game events to music in editor scripts.
---

# Koreographer / Get Beat Time

## How to Call

```bash
unity-mcp-cli run-tool koreo-beattime --input '{
  "trackName": "string_value",
  "subdivision": 0
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool koreo-beattime --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool koreo-beattime --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `trackName` | `string` | No | Source clip name of the Koreography to query. Omit for global beat time. |
| `subdivision` | `integer` | No | Beat subdivision: 1=quarter, 2=eighth, 4=sixteenth. Default 1. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "trackName": {
      "type": "string"
    },
    "subdivision": {
      "type": "integer"
    }
  }
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

