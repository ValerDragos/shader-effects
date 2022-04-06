using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasRenderer))]
public class SquareGraphic : AbstractGraphic
{
    private const float UV_DISTANCE = 0.7071067811865475f;

    private static readonly List<UIVertex> _vertices = null;
    private static readonly List<int> _indices = null;

    static SquareGraphic()
    {
        _vertices = new List<UIVertex>(5);
        _indices = new List<int>()
        {
            3, 0, 4,
            4, 0, 1,
            2, 4, 1,
            3, 4, 2
        };
    }

    protected override void OnPopulateMesh(VertexHelper vh)
    {
        vh.Clear();
        var rect = _cacheRectTransform.rect;
        var uv0 = new Vector4(UV_DISTANCE, UV_DISTANCE, 0, 0);
        _vertices.Add(new UIVertex()
        {
            position = new Vector3(rect.xMin, rect.yMin, 0),
            uv0 = uv0,
            color = _cornerColors.bottomLeft * color
        });
        _vertices.Add(new UIVertex()
        {
            position = new Vector3(rect.xMin, rect.yMax, 0),
            uv0 = uv0,
            color = _cornerColors.topLeft * color
        });
        _vertices.Add(new UIVertex()
        {
            position = new Vector3(rect.xMax, rect.yMax, 0),
            uv0 = uv0,
            color = _cornerColors.topRight * color
        });
        _vertices.Add(new UIVertex()
        {
            position = new Vector3(rect.xMax, rect.yMin, 0),
            uv0 = uv0,
            color = _cornerColors.bottomRight * color
        });
        _vertices.Add(new UIVertex()
        {
            position = rect.center,
            uv0 = new Vector4(0, 0, 0, 0),
            color = GetColor(new Vector2(0.5f, 0.5f)) * color
        });

        vh.AddUIVertexStream(_vertices, _indices);
        _vertices.Clear();
    }
}
