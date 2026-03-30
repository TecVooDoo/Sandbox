---
name: ds-conversation
description: |-
  Start, stop, or check conversations.
  Actions: 'start' (begins a conversation), 'stop' (stops current conversation),
  'stopall' (stops all active conversations), 'check' (checks if conversation has valid entries).
  For 'start' and 'check', provide the conversation title. Optionally specify actor and conversant
  GameObjects by scene name, and an initial entry ID.
---

# Dialogue System / Conversation

## How to Call

```bash
unity-mcp-cli run-tool ds-conversation --input '{
  "action": "string_value",
  "title": "string_value",
  "actorName": "string_value",
  "conversantName": "string_value",
  "entryID": 0
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool ds-conversation --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool ds-conversation --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `action` | `string` | Yes | Action to perform: 'start', 'stop', 'stopall', 'check'. |
| `title` | `string` | No | Conversation title (required for 'start' and 'check'). |
| `actorName` | `string` | No | Scene GameObject name for the actor participant. |
| `conversantName` | `string` | No | Scene GameObject name for the conversant participant. |
| `entryID` | `integer` | No | Initial dialogue entry ID. Default -1 starts from the beginning. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "action": {
      "type": "string"
    },
    "title": {
      "type": "string"
    },
    "actorName": {
      "type": "string"
    },
    "conversantName": {
      "type": "string"
    },
    "entryID": {
      "type": "integer"
    }
  },
  "required": [
    "action"
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

