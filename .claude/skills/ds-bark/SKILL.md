---
name: ds-bark
description: |-
  Triggers a character bark (short dialogue line above a character's head).
  Either provide a conversationTitle to bark from a conversation, or barkText for raw text.
  If both are provided, barkText takes priority. Requires a speaker GameObject in the scene.
---

# Dialogue System / Bark

## How to Call

```bash
unity-mcp-cli run-tool ds-bark --input '{
  "speakerName": "string_value",
  "conversationTitle": "string_value",
  "listenerName": "string_value",
  "barkText": "string_value",
  "entryID": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool ds-bark --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool ds-bark --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `speakerName` | `string` | Yes | Scene GameObject name for the speaker character. |
| `conversationTitle` | `string` | No | Conversation title to bark from (picks a random valid entry, or use entryID). |
| `listenerName` | `string` | No | Scene GameObject name for the listener character. |
| `barkText` | `string` | No | Raw text string to bark (alternative to conversation-based bark). |
| `entryID` | `any` | No | Specific dialogue entry ID to bark from the conversation. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "speakerName": {
      "type": "string"
    },
    "conversationTitle": {
      "type": "string"
    },
    "listenerName": {
      "type": "string"
    },
    "barkText": {
      "type": "string"
    },
    "entryID": {
      "$ref": "#/$defs/System.Int32"
    }
  },
  "$defs": {
    "System.Int32": {
      "type": "integer"
    }
  },
  "required": [
    "speakerName"
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

