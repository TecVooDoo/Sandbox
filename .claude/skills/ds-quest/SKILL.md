---
name: ds-quest
description: |-
  Get or set quest and quest entry states in the Dialogue System.
  Actions: 'get' (returns quest state and descriptions), 'set' (sets quest state),
  'getentry' (gets a quest entry state), 'setentry' (sets a quest entry state),
  'list' (lists all quests with their current states).
  Quest states: 'unassigned', 'active', 'success', 'failure'.
---

# Dialogue System / Quest

## How to Call

```bash
unity-mcp-cli run-tool ds-quest --input '{
  "questName": "string_value",
  "action": "string_value",
  "state": "string_value",
  "entryNumber": "string_value",
  "entryState": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool ds-quest --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool ds-quest --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `questName` | `string` | Yes | Name of the quest (as defined in the dialogue database). |
| `action` | `string` | No | Action: 'get', 'set', 'getentry', 'setentry', 'list'. Default 'get'. |
| `state` | `string` | No | Quest state for 'set' action: 'unassigned', 'active', 'success', 'failure'. |
| `entryNumber` | `any` | No | Quest entry number for 'getentry'/'setentry' (1-based). |
| `entryState` | `string` | No | Quest entry state for 'setentry': 'unassigned', 'active', 'success', 'failure'. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "questName": {
      "type": "string"
    },
    "action": {
      "type": "string"
    },
    "state": {
      "type": "string"
    },
    "entryNumber": {
      "$ref": "#/$defs/System.Int32"
    },
    "entryState": {
      "type": "string"
    }
  },
  "$defs": {
    "System.Int32": {
      "type": "integer"
    }
  },
  "required": [
    "questName"
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

