using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasRenderer))]
public class LineGraphic : AbstractGraphic
{
    private const float UV_DISTANCE = 1f;

    [Range(0f, 1f)]
    [SerializeField]
    private float _middleUV = 0f;

    private static readonly List<UIVertex> _vertices = null;
    private static readonly List<int> _indices = null;

    static LineGraphic()
    {
        _vertices = new List<UIVertex>(6);
        _indices = new List<int>()
        {
            0, 4, 3,
            3, 4, 5,
            4, 1, 5,
            5, 1, 2
        };
    }

    protected override void OnPopulateMesh(VertexHelper vh)
    {
        const float INNER_POINTS_NORMALIZED_HEIGHT = 0.5f;

        vh.Clear();

        var rect = _cacheRectTransform.rect;
        var edgeUV = new Vector4(0, UV_DISTANCE, 0, 0);
        var centerUV = new Vector4(0, _middleUV, 0, 0);
        var centerYPos = Mathf.Lerp(rect.yMin, rect.yMax, INNER_POINTS_NORMALIZED_HEIGHT);

        _vertices.Add(new UIVertex()
        {
            position = new Vector3(rect.xMin, rect.yMin, 0),
            uv0 = edgeUV,
            color = _cornerColors.bottomLeft * color
        });
        _vertices.Add(new UIVertex()
        {
            position = new Vector3(rect.xMin, rect.yMax, 0),
            uv0 = edgeUV,
            color = _cornerColors.topLeft * color
        });
        _vertices.Add(new UIVertex()
        {
            position = new Vector3(rect.xMax, rect.yMax, 0),
            uv0 = edgeUV,
            color = _cornerColors.topRight * color
        });
        _vertices.Add(new UIVertex()
        {
            position = new Vector3(rect.xMax, rect.yMin, 0),
            uv0 = edgeUV,
            color = _cornerColors.bottomRight * color
        });
        _vertices.Add(new UIVertex()
        {
            position = new Vector3(rect.xMin, centerYPos, 0),
            uv0 = centerUV,
            color = GetLeftColor(INNER_POINTS_NORMALIZED_HEIGHT) * color
        });
        _vertices.Add(new UIVertex()
        {
            position = new Vector3(rect.xMax, centerYPos, 0),
            uv0 = centerUV,
            color = GetRightColor(INNER_POINTS_NORMALIZED_HEIGHT) * color
        });

        vh.AddUIVertexStream(_vertices, _indices);
        _vertices.Clear();
    }
}
