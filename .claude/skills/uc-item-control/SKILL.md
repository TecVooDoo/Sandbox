---
name: uc-item-control
description: |-
  Query and control inventory and items on a UCC character.
  Actions: 'list' shows all items in inventory, 'equip' equips an item set by index,
  'unequip' unequips the current item set.
  Use 'uc-query' first to see the character's current inventory state.
  All UCC API access uses reflection for resilience.
---

# UCC / Item Control

## How to Call

```bash
unity-mcp-cli run-tool uc-item-control --input '{
  "gameObjectName": "string_value",
  "action": "string_value",
  "itemSetIndex": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool uc-item-control --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool uc-item-control --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the GameObject with Inventory component. |
| `action` | `string` | Yes | Action to perform: 'list', 'equip', 'unequip'. |
| `itemSetIndex` | `any` | No | Item set index to equip/unequip (used with 'equip' and 'unequip' actions). |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
    },
    "action": {
      "type": "string"
    },
    "itemSetIndex": {
      "$ref": "#/$defs/System.Int32"
    }
  },
  "$defs": {
    "System.Int32": {
      "type": "integer"
    }
  },
  "required": [
    "gameObjectName",
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

