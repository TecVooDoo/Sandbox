---
name: dnp-configure-animation
description: |-
  Configures fade and movement animation on a DamageNumber component.
  Fade In/Out: control timing and whether position/scale is animated during fade.
  Movement modes (mutually exclusive -- enable only one):
    enableLerp: smooth eased movement to a target offset position (default).
    enableVelocity: physics-based movement with drag and gravity.
    enableShaking: idle shake (no net movement).
  lerpOffsetX/Y: destination offset during lerp movement (world units, local space).
  velocityX/Y: initial velocity for velocity mode.
  fadeInDuration/fadeOutDuration: timing for opacity transitions.
  fadeInOffsetX/Y: position offset at start of fade-in (popup animates FROM this offset).
  fadeOutOffsetX/Y: position offset at end of fade-out (popup animates TO this offset).
---

# Damage Numbers Pro / Configure Animation

## How to Call

```bash
unity-mcp-cli run-tool dnp-configure-animation --input '{
  "gameObjectName": "string_value",
  "fadeInDuration": "string_value",
  "fadeOutDuration": "string_value",
  "enableOffsetFadeIn": "string_value",
  "fadeInOffsetX": "string_value",
  "fadeInOffsetY": "string_value",
  "enableOffsetFadeOut": "string_value",
  "fadeOutOffsetX": "string_value",
  "fadeOutOffsetY": "string_value",
  "enableScaleFadeIn": "string_value",
  "enableLerp": "string_value",
  "enableVelocity": "string_value",
  "enableShaking": "string_value",
  "enableStartRotation": "string_value",
  "minRotation": "string_value",
  "maxRotation": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool dnp-configure-animation --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool dnp-configure-animation --input-file - <<'EOF'
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
| `fadeInDuration` | `any` | No | Fade-in duration in seconds. |
| `fadeOutDuration` | `any` | No | Fade-out duration in seconds. |
| `enableOffsetFadeIn` | `any` | No | Enable position offset during fade-in. |
| `fadeInOffsetX` | `any` | No | Fade-in start offset X (number animates from this X position). |
| `fadeInOffsetY` | `any` | No | Fade-in start offset Y (number animates from this Y position). |
| `enableOffsetFadeOut` | `any` | No | Enable position offset during fade-out. |
| `fadeOutOffsetX` | `any` | No | Fade-out end offset X. |
| `fadeOutOffsetY` | `any` | No | Fade-out end offset Y. |
| `enableScaleFadeIn` | `any` | No | Enable scale animation during fade-in (pops in from scaled size). |
| `enableLerp` | `any` | No | Enable smooth lerp movement (default movement mode). |
| `enableVelocity` | `any` | No | Enable physics-based velocity movement. |
| `enableShaking` | `any` | No | Enable idle shaking. |
| `enableStartRotation` | `any` | No | Enable random rotation on spawn. |
| `minRotation` | `any` | No | Min spawn rotation in degrees. |
| `maxRotation` | `any` | No | Max spawn rotation in degrees. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
    },
    "fadeInDuration": {
      "$ref": "#/$defs/System.Single"
    },
    "fadeOutDuration": {
      "$ref": "#/$defs/System.Single"
    },
    "enableOffsetFadeIn": {
      "$ref": "#/$defs/System.Boolean"
    },
    "fadeInOffsetX": {
      "$ref": "#/$defs/System.Single"
    },
    "fadeInOffsetY": {
      "$ref": "#/$defs/System.Single"
    },
    "enableOffsetFadeOut": {
      "$ref": "#/$defs/System.Boolean"
    },
    "fadeOutOffsetX": {
      "$ref": "#/$defs/System.Single"
    },
    "fadeOutOffsetY": {
      "$ref": "#/$defs/System.Single"
    },
    "enableScaleFadeIn": {
      "$ref": "#/$defs/System.Boolean"
    },
    "enableLerp": {
      "$ref": "#/$defs/System.Boolean"
    },
    "enableVelocity": {
      "$ref": "#/$defs/System.Boolean"
    },
    "enableShaking": {
      "$ref": "#/$defs/System.Boolean"
    },
    "enableStartRotation": {
      "$ref": "#/$defs/System.Boolean"
    },
    "minRotation": {
      "$ref": "#/$defs/System.Single"
    },
    "maxRotation": {
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

