---
name: sensor-query-detections
description: |-
  Queries runtime detections from sensors on a GameObject (play mode only).
  Returns each detected object's name, distance, and signal strength.
  Can filter by sensor type and tag, and sort by distance or signal strength.
---

# SensorToolkit / Query Detections

## How to Call

```bash
unity-mcp-cli run-tool sensor-query-detections --input '{
  "gameObjectName": "string_value",
  "sensorType": "string_value",
  "sortBy": "string_value",
  "tag": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool sensor-query-detections --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool sensor-query-detections --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the GameObject with sensor components. |
| `sensorType` | `string` | No | Filter to a specific sensor type: 'Range', 'Ray', 'LOS', 'Trigger'. Null for first sensor found. |
| `sortBy` | `string` | No | Sort results by 'distance' or 'strength'. Default 'distance'. |
| `tag` | `string` | No | Filter detections to only objects with this tag. Null for all detections. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
    },
    "sensorType": {
      "type": "string"
    },
    "sortBy": {
      "type": "string"
    },
    "tag": {
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

