---
name: tcc-configure-vhacd
description: |-
  Sets VHACD (Auto hull) parameters on a TCC PaintingData.
  preset: Low (fast, rough), Medium (balanced, default), High (slow, precise), Placebo (very slow), Custom.
  When preset is Custom, the other parameters take effect; otherwise preset values override them.
---

# Technie Collider / Configure VHACD

## How to Call

```bash
unity-mcp-cli run-tool tcc-configure-vhacd --input '{
  "gameObjectName": "string_value",
  "preset": "string_value",
  "resolution": "string_value",
  "concavity": "string_value",
  "planeDownsampling": "string_value",
  "convexhullDownsampling": "string_value",
  "minVolumePerCH": "string_value",
  "maxConvexHulls": "string_value",
  "alpha": "string_value",
  "beta": "string_value",
  "pca": "string_value",
  "mode": "string_value",
  "maxNumVerticesPerCH": "string_value",
  "projectHullVertices": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool tcc-configure-vhacd --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool tcc-configure-vhacd --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the GameObject with TCC setup. |
| `preset` | `string` | No | Preset: Low, Medium, High, Placebo, Custom. |
| `resolution` | `any` | No | Voxel resolution (10000-64000000). |
| `concavity` | `any` | No | Concavity threshold (0-1, lower = more decomposition). |
| `planeDownsampling` | `any` | No | Plane downsampling (1-16). |
| `convexhullDownsampling` | `any` | No | Convex hull downsampling (1-16). |
| `minVolumePerCH` | `any` | No | Min volume per hull (0-0.01). |
| `maxConvexHulls` | `any` | No | Max convex hulls. |
| `alpha` | `any` | No | Alpha bias (0-1). |
| `beta` | `any` | No | Beta bias (0-1). |
| `pca` | `any` | No | PCA enable (0 or 1). |
| `mode` | `any` | No | Mode: 0=voxel, 1=tetrahedron. |
| `maxNumVerticesPerCH` | `any` | No | Max vertices per hull (4-1024). |
| `projectHullVertices` | `any` | No | Project hull vertices to original mesh. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
    },
    "preset": {
      "type": "string"
    },
    "resolution": {
      "$ref": "#/$defs/System.UInt32"
    },
    "concavity": {
      "$ref": "#/$defs/System.Single"
    },
    "planeDownsampling": {
      "$ref": "#/$defs/System.UInt32"
    },
    "convexhullDownsampling": {
      "$ref": "#/$defs/System.UInt32"
    },
    "minVolumePerCH": {
      "$ref": "#/$defs/System.Single"
    },
    "maxConvexHulls": {
      "$ref": "#/$defs/System.UInt32"
    },
    "alpha": {
      "$ref": "#/$defs/System.Single"
    },
    "beta": {
      "$ref": "#/$defs/System.Single"
    },
    "pca": {
      "$ref": "#/$defs/System.UInt32"
    },
    "mode": {
      "$ref": "#/$defs/System.UInt32"
    },
    "maxNumVerticesPerCH": {
      "$ref": "#/$defs/System.UInt32"
    },
    "projectHullVertices": {
      "$ref": "#/$defs/System.Boolean"
    }
  },
  "$defs": {
    "System.UInt32": {
      "type": "integer"
    },
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

