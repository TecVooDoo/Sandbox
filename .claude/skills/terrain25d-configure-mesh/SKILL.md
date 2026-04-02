---
name: terrain25d-configure-mesh
description: |-
  Configures the MeshGenerator on a Terrain25D GameObject.
  Only provided parameters are changed; others are left as-is.
  Front/Back bevel controls the 3D depth shape. Middle controls the flat connecting section.
  Erosion adds organic edge variation. Snow adds vertex offset on top surfaces.
  Use 'terrain25d-query' first to see current values.
---

# 2.5D Terrain / Configure Mesh Generator

## How to Call

```bash
unity-mcp-cli run-tool terrain25d-configure-mesh --input '{
  "gameObjectName": "string_value",
  "frontBevelWidth": "string_value",
  "frontBevelScale": "string_value",
  "frontBevelDivisions": "string_value",
  "frontBevelType": "string_value",
  "frontClosed": "string_value",
  "frontMiddleWidth": "string_value",
  "backMiddleWidth": "string_value",
  "middleFrontProjectUVs": "string_value",
  "middleUVScale": "string_value",
  "middleZDivisions": "string_value",
  "backBevelWidth": "string_value",
  "backBevelScale": "string_value",
  "backBevelDivisions": "string_value",
  "backBevelType": "string_value",
  "backClosed": "string_value",
  "smoothNormals": "string_value",
  "combineMeshes": "string_value",
  "staticMesh": "string_value",
  "castShadows": "string_value",
  "erosion": "string_value",
  "erosionStrength": "string_value",
  "erosionSegmentLength": "string_value",
  "snowThickness": "string_value",
  "snowSlopeLimit": "string_value",
  "add3DCollider": "string_value",
  "remove2DCollider": "string_value"
}'
```

> For complex input (multi-line strings, code), save the JSON to a file and use:
> ```bash
> unity-mcp-cli run-tool terrain25d-configure-mesh --input-file args.json
> ```
>
> Or pipe via stdin (recommended):
> ```bash
> unity-mcp-cli run-tool terrain25d-configure-mesh --input-file - <<'EOF'
> {"param": "value"}
> EOF
> ```


### Troubleshooting

If `unity-mcp-cli` is not found, either install it globally (`npm install -g unity-mcp-cli`) or use `npx unity-mcp-cli` instead.
Read the /unity-initial-setup skill for detailed installation instructions.

## Input

| Name | Type | Required | Description |
|------|------|----------|-------------|
| `gameObjectName` | `string` | Yes | Name of the root Terrain25D GameObject. |
| `frontBevelWidth` | `any` | No | Front bevel thickness along Z [0.2-30]. |
| `frontBevelScale` | `any` | No | Front bevel inward shrink [0.1-30]. |
| `frontBevelDivisions` | `any` | No | Front bevel subdivisions [0-10]. 0 = no bevel. |
| `frontBevelType` | `string` | No | Front bevel type: Circular or Linear. |
| `frontClosed` | `any` | No | Close the front face. |
| `frontMiddleWidth` | `any` | No | Front middle section width. |
| `backMiddleWidth` | `any` | No | Back middle section width. |
| `middleFrontProjectUVs` | `any` | No | Front-project middle UVs (decal-like). |
| `middleUVScale` | `any` | No | Middle UV scale if not front-projected. |
| `middleZDivisions` | `any` | No | Middle Z divisions [1+]. |
| `backBevelWidth` | `any` | No | Back bevel thickness along Z [0.2-30]. |
| `backBevelScale` | `any` | No | Back bevel inward shrink [0.2-30]. |
| `backBevelDivisions` | `any` | No | Back bevel subdivisions [0-10]. 0 = no bevel. |
| `backBevelType` | `string` | No | Back bevel type: Circular or Linear. |
| `backClosed` | `any` | No | Close the back face. |
| `smoothNormals` | `any` | No | Average normals for smoother surface. |
| `combineMeshes` | `any` | No | Combine into one mesh. |
| `staticMesh` | `any` | No | Mark mesh as static. |
| `castShadows` | `any` | No | Mesh casts shadows. |
| `erosion` | `any` | No | Enable erosion (organic edge variation). |
| `erosionStrength` | `any` | No | Erosion strength [0.5-5]. |
| `erosionSegmentLength` | `any` | No | Erosion segment length [0.2-1]. |
| `snowThickness` | `any` | No | Snow vertex offset thickness [0-2]. |
| `snowSlopeLimit` | `any` | No | Snow slope limit angle [0-90]. |
| `add3DCollider` | `any` | No | Add 3D MeshCollider after generation. |
| `remove2DCollider` | `any` | No | Remove 2D collider after generation. |

### Input JSON Schema

```json
{
  "type": "object",
  "properties": {
    "gameObjectName": {
      "type": "string"
    },
    "frontBevelWidth": {
      "$ref": "#/$defs/System.Single"
    },
    "frontBevelScale": {
      "$ref": "#/$defs/System.Single"
    },
    "frontBevelDivisions": {
      "$ref": "#/$defs/System.Int32"
    },
    "frontBevelType": {
      "type": "string"
    },
    "frontClosed": {
      "$ref": "#/$defs/System.Boolean"
    },
    "frontMiddleWidth": {
      "$ref": "#/$defs/System.Single"
    },
    "backMiddleWidth": {
      "$ref": "#/$defs/System.Single"
    },
    "middleFrontProjectUVs": {
      "$ref": "#/$defs/System.Boolean"
    },
    "middleUVScale": {
      "$ref": "#/$defs/System.Single"
    },
    "middleZDivisions": {
      "$ref": "#/$defs/System.Int32"
    },
    "backBevelWidth": {
      "$ref": "#/$defs/System.Single"
    },
    "backBevelScale": {
      "$ref": "#/$defs/System.Single"
    },
    "backBevelDivisions": {
      "$ref": "#/$defs/System.Int32"
    },
    "backBevelType": {
      "type": "string"
    },
    "backClosed": {
      "$ref": "#/$defs/System.Boolean"
    },
    "smoothNormals": {
      "$ref": "#/$defs/System.Boolean"
    },
    "combineMeshes": {
      "$ref": "#/$defs/System.Boolean"
    },
    "staticMesh": {
      "$ref": "#/$defs/System.Boolean"
    },
    "castShadows": {
      "$ref": "#/$defs/System.Boolean"
    },
    "erosion": {
      "$ref": "#/$defs/System.Boolean"
    },
    "erosionStrength": {
      "$ref": "#/$defs/System.Single"
    },
    "erosionSegmentLength": {
      "$ref": "#/$defs/System.Single"
    },
    "snowThickness": {
      "$ref": "#/$defs/System.Single"
    },
    "snowSlopeLimit": {
      "$ref": "#/$defs/System.Single"
    },
    "add3DCollider": {
      "$ref": "#/$defs/System.Boolean"
    },
    "remove2DCollider": {
      "$ref": "#/$defs/System.Boolean"
    }
  },
  "$defs": {
    "System.Single": {
      "type": "number"
    },
    "System.Int32": {
      "type": "integer"
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

