---
name: dnp-configure-display
description: |-
  Configures display settings on a DamageNumber component.
  lifetime: seconds before the number fades out and despawns (ignored if permanent=true).
  permanent: if true, number persists until manually faded out.
  enableNumber: show/hide the numeric value.
  leftText/rightText: prefix/suffix text alongside the number (e.g. '-' or ' HP').
  topText/bottomText: text above/below the number.
  enable3DGame: enable 3D-specific positioning (face camera, render through walls).
  faceCameraView: rotate to always face the main camera.
  colorR/G/B/A: set the number display color (0-1 range).
---

# Damage Numbers Pro / Configure Display

## How to Call

```bash
unity-mcp-cli run-tool dnp-configure-display --input '{
  "gameObjectName": "string_value",
  "lifetime": "string_value",
  "permanent": "string_value",
  "unscaledTime": "string_value",
  "enableNumber": "string_value",
  "enable3DGame": "string_value",
  "faceCameraView": "string_value",
  "enableLeftText": "string_value",
  "leftText": "string_value",
  "enableRightText": "string_value",
  "rightText": "string_value",
  "enableTopText": "string_value",
  "topText": "string_value",
  "enableBottomText": "string_value",
  "bottomText": "string_value",
  "colorR": "string_value",
  "colorG": "string_value",
  "colorB": "string_value",
  "colorA": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool dnp-configure-display --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool dnp-configure-display --input-file - <<'EOF'
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
| `lifetime` | `any` | No | Seconds before fade-out (ignored if permanent=true). |
| `permanent` | `any` | No | If true, number never fades out automatically. |
| `unscaledTime` | `any` | No | Ignore Time.timeScale (useful during slow-motion). |
| `enableNumber` | `any` | No | Show/hide the numeric value. |
| `enable3DGame` | `any` | No | Enable 3D mode (face camera, depth rendering). |
| `faceCameraView` | `any` | No | Always rotate to face the camera. |
| `enableLeftText` | `any` | No | Enable prefix text on the left of the number. |
| `leftText` | `string` | No | Prefix text string (e.g. '-' for damage, '+' for heal). |
| `enableRightText` | `any` | No | Enable suffix text on the right of the number. |
| `rightText` | `string` | No | Suffix text string (e.g. ' HP', ' DMG'). |
| `enableTopText` | `any` | No | Enable text above the number. |
| `topText` | `string` | No | Text to show above the number. |
| `enableBottomText` | `any` | No | Enable text below the number. |
| `bottomText` | `string` | No | Text to show below the number. |
| `colorR` | `any` | No | Color red channel [0-1]. |
| `colorG` | `any` | No | Color green channel [0-1]. |
| `colorB` | `any` | No | Color blue channel [0-1]. |
| `colorA` | `any` | No | Color alpha channel [0-1]. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
    },
    "lifetime": {
      "$ref": "#/$defs/System.Single"
    },
    "permanent": {
      "$ref": "#/$defs/System.Boolean"
    },
    "unscaledTime": {
      "$ref": "#/$defs/System.Boolean"
    },
    "enableNumber": {
      "$ref": "#/$defs/System.Boolean"
    },
    "enable3DGame": {
      "$ref": "#/$defs/System.Boolean"
    },
    "faceCameraView": {
      "$ref": "#/$defs/System.Boolean"
    },
    "enableLeftText": {
      "$ref": "#/$defs/System.Boolean"
    },
    "leftText": {
      "type": "string"
    },
    "enableRightText": {
      "$ref": "#/$defs/System.Boolean"
    },
    "rightText": {
      "type": "string"
    },
    "enableTopText": {
      "$ref": "#/$defs/System.Boolean"
    },
    "topText": {
      "type": "string"
    },
    "enableBottomText": {
      "$ref": "#/$defs/System.Boolean"
    },
    "bottomText": {
      "type": "string"
    },
    "colorR": {
      "$ref": "#/$defs/System.Single"
    },
    "colorG": {
      "$ref": "#/$defs/System.Single"
    },
    "colorB": {
      "$ref": "#/$defs/System.Single"
    },
    "colorA": {
      "$ref": "#/$defs/System.Single"
    }
  },
  "$defs": {
    "System.Single": {
      "type": "number"
    },
    "System.Boolean": {
      "type": "boolean"
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

