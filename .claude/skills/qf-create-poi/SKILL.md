---
name: qf-create-poi
description: |-
  Creates a new PointOfInterest ScriptableObject asset for the minimap/compass system.
  POIs mark locations on the minimap and can be quest objectives, NPCs, merchants, etc.
  Categories: QuestObjective, QuestGiver, Waypoint, Location, Enemy, NPC, Item, Merchant, FastTravel, Custom.
---

# Quest Forge / Create POI

## How to Call

```bash
unity-mcp-cli run-tool qf-create-poi --input '{
  "assetPath": "string_value",
  "poiName": "string_value",
  "category": "string_value",
  "locationId": "string_value",
  "posX": 0,
  "posY": 0,
  "posZ": 0,
  "radius": 0,
  "showOnMinimap": false,
  "showOnCompass": false,
  "enableFastTravel": false,
  "hideUntilDiscovered": false,
  "description": "string_value",
  "priority": 0
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool qf-create-poi --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool qf-create-poi --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `assetPath` | `string` | Yes | Asset path for the new POI SO (e.g. 'Assets/_Sandbox/_AQS/Data/POI/POI_SwampEntrance.asset'). |
| `poiName` | `string` | Yes | Display name of the point of interest. |
| `category` | `string` | No | POI category: 'QuestObjective', 'QuestGiver', 'Waypoint', 'Location', 'Enemy', 'NPC', 'Item', 'Merchant', 'FastTravel', 'Custom'. Default 'Waypoint'. |
| `locationId` | `string` | No | Location ID string (e.g. 'swamp_entrance'). Used for quest objective matching. |
| `posX` | `number` | No | World X position. Default 0. |
| `posY` | `number` | No | World Y position. Default 0. |
| `posZ` | `number` | No | World Z position. Default 0. |
| `radius` | `number` | No | Location radius for proximity detection. Default 5. |
| `showOnMinimap` | `boolean` | No | Show on minimap. Default true. |
| `showOnCompass` | `boolean` | No | Show on compass. Default true. |
| `enableFastTravel` | `boolean` | No | Enable fast travel to this location. Default false. |
| `hideUntilDiscovered` | `boolean` | No | Hide until player discovers this location. Default false. |
| `description` | `string` | No | POI description text. |
| `priority` | `integer` | No | Priority for display ordering (higher = more important). Default 0. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "assetPath": {
      "type": "string"
    },
    "poiName": {
      "type": "string"
    },
    "category": {
      "type": "string"
    },
    "locationId": {
      "type": "string"
    },
    "posX": {
      "type": "number"
    },
    "posY": {
      "type": "number"
    },
    "posZ": {
      "type": "number"
    },
    "radius": {
      "type": "number"
    },
    "showOnMinimap": {
      "type": "boolean"
    },
    "showOnCompass": {
      "type": "boolean"
    },
    "enableFastTravel": {
      "type": "boolean"
    },
    "hideUntilDiscovered": {
      "type": "boolean"
    },
    "description": {
      "type": "string"
    },
    "priority": {
      "type": "integer"
    }
  },
  "required": [
    "assetPath",
    "poiName"
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
      "$ref": "#/$defs/MCPTools.QuestForge.Editor.Tool_QuestForge+CreatePOIResponse"
    }
  },
  "$defs": {
    "MCPTools.QuestForge.Editor.Tool_QuestForge+CreatePOIResponse": {
      "type": "object",
      "properties": {
        "assetPath": {
          "type": "string",
          "description": "Asset path where POI was saved"
        },
        "poiName": {
          "type": "string",
          "description": "POI display name"
        },
        "category": {
          "type": "string",
          "description": "POI category"
        },
        "locationId": {
          "type": "string",
          "description": "Location ID"
        },
        "worldPosition": {
          "type": "string",
          "description": "World position"
        },
        "radius": {
          "type": "number",
          "description": "Location radius"
        },
        "showOnMinimap": {
          "type": "boolean",
          "description": "Shown on minimap"
        },
        "showOnCompass": {
          "type": "boolean",
          "description": "Shown on compass"
        }
      },
      "required": [
        "radius",
        "showOnMinimap",
        "showOnCompass"
      ]
    }
  },
  "required": [
    "result"
  ]
}
```

