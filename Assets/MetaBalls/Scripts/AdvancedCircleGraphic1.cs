using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasRenderer))]
public class AdvancedCircleGraphic1 : Graphic
{
    public Sprite sprite;
    [Range(0f, 1f)]
    [SerializeField] private float _ringStart = 0.5f;
    [SerializeField] private float _ringOffset = 0f;

    protected RectTransform _cacheRectTransform { get; private set; }

    private static readonly List<UIVertex> _vertices = null;
    private static readonly List<int> _indices = null;

    static AdvancedCircleGraphic1 ()
    {
        _vertices = new List<UIVertex>(8);
        _indices = new List<int>()
        {
            3, 0, 4,
            0, 1, 5,
            6, 1, 2,
            3, 7, 2,
            4, 0, 5,
            5, 1, 6,
            7, 6, 2,
            3, 4, 7,
            4, 5, 6,
            4, 6, 7
        };
    }

    public override Texture mainTexture
    {
        get
        {
            return sprite != null? sprite.texture : null;
        }
    }

    protected override void Awake()
    {
        base.Awake();
        _cacheRectTransform = GetComponent<RectTransform>();
    }

    protected override void OnPopulateMesh(VertexHelper vh)
    {
        vh.Clear();

        var outerRect = _cacheRectTransform.rect;
        var innerRectSize = outerRect.size* _ringStart;
        var innerRect = new Rect(outerRect.position + (outerRect.size - innerRectSize) * 0.5f, innerRectSize);

        AddRectToVertices(outerRect, 1f);
        AddCrossToVertices(innerRect, _ringOffset);

        vh.AddUIVertexStream(_vertices, _indices);
        _vertices.Clear();
    }

    private void AddRectToVertices (Rect rect, float uv)
    {
        _vertices.Add(new UIVertex()
        {
            position = new Vector3(rect.xMin, rect.yMin, 0),
            uv0 = new Vector4(-uv, -uv, 0, 0),
            color = color
        });
        _vertices.Add(new UIVertex()
        {
            position = new Vector3(rect.xMin, rect.yMax, 0),
            uv0 = new Vector4(-uv, uv, 0, 0),
            color = color
        });
        _vertices.Add(new UIVertex()
        {
            position = new Vector3(rect.xMax, rect.yMax, 0),
            uv0 = new Vector4(uv, uv, 0, 0),
            color = color
        });
        _vertices.Add(new UIVertex()
        {
            position = new Vector3(rect.xMax, rect.yMin, 0),
            uv0 = new Vector4(uv, -uv, 0, 0),
            color = color
        });
    }

    private void AddCrossToVertices(Rect rect, float uv)
    {
        var center = new Vector2(Mathf.Lerp(rect.xMin, rect.xMax, 0.5f), Mathf.Lerp(rect.yMin, rect.yMax, 0.5f));

        _vertices.Add(new UIVertex()
        {
            position = new Vector3(center.x, rect.yMin, 0),
            uv0 = new Vector4(0, -uv, 0, 0),
            color = color
        });
        _vertices.Add(new UIVertex()
        {
            position = new Vector3(rect.xMin, center.y, 0),
            uv0 = new Vector4(-uv, 0, 0, 0),
            color = color
        });
        _vertices.Add(new UIVertex()
        {
            position = new Vector3(center.x, rect.yMax, 0),
            uv0 = new Vector4(0, uv, 0, 0),
            color = color
        });
        _vertices.Add(new UIVertex()
        {
            position = new Vector3(rect.xMax, center.y, 0),
            uv0 = new Vector4(uv, 0, 0, 0),
            color = color
        });
    }
}
