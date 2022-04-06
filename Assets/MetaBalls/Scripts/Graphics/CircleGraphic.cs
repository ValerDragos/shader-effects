using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasRenderer))]
public class CircleGraphic : AbstractGraphic
{
    private const float UV_DISTANCE = 1f;

    protected override void OnPopulateMesh(VertexHelper vh)
    {
        vh.Clear();
        var rect = _cacheRectTransform.rect;
        vh.AddUIVertexQuad(new UIVertex[]
        {
            new UIVertex()
            {
                position = new Vector3(rect.xMin, rect.yMin, 0),
                uv0 = new Vector4(-UV_DISTANCE, -UV_DISTANCE, 0, 0),
                color = _cornerColors.bottomLeft * color
            },
            new UIVertex()
            {
                position = new Vector3(rect.xMin, rect.yMax, 0),
                uv0 = new Vector4(-UV_DISTANCE, UV_DISTANCE, 0, 0),
                color = _cornerColors.topLeft * color
            },
            new UIVertex()
            {
                position = new Vector3(rect.xMax, rect.yMax, 0),
                uv0 = new Vector4(UV_DISTANCE, UV_DISTANCE, 0, 0),
                color = _cornerColors.topRight * color
            },
            new UIVertex()
            {
                position = new Vector3(rect.xMax, rect.yMin, 0),
                uv0 = new Vector4(UV_DISTANCE, -UV_DISTANCE, 0, 0),
                color = _cornerColors.bottomRight * color
            },
        });
    }
}
