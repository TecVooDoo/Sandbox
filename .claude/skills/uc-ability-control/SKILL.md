---
name: uc-ability-control
description: |-
  List, enable, disable, start, or stop abilities on a UCC character.
  Actions: 'list' shows all abilities, 'enable'/'disable' toggles the Enabled flag,
  'start'/'stop' calls TryStartAbility/TryStopAbility.
  For 'enable'/'disable'/'start'/'stop', provide abilityName to match by type name.
  Use abilityIndex if multiple instances of the same ability type exist (default 0).
  All UCC API access uses reflection for resilience.
---

# UCC / Ability Control

## How to Call

```bash
unity-mcp-cli run-tool uc-ability-control --input '{
  "gameObjectName": "string_value",
  "action": "string_value",
  "abilityName": "string_value",
  "abilityIndex": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool uc-ability-control --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool uc-ability-control --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the GameObject with UltimateCharacterLocomotion component. |
| `action` | `string` | Yes | Action to perform: 'list', 'enable', 'disable', 'start', 'stop'. |
| `abilityName` | `string` | No | Ability type name to match (e.g. 'Jump', 'Fall', 'Interact'). Required for enable/disable/start/stop. |
| `abilityIndex` | `any` | No | Index when multiple abilities of the same type exist (default 0). |

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
    "abilityName": {
      "type": "string"
    },
    "abilityIndex": {
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

