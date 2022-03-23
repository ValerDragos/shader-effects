using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasRenderer))]
public class AdvancedCircleGraphic : Graphic
{
    public Sprite sprite;
    [Range(0f, 1f)]
    [SerializeField] private float _ringStart = 0.5f;
    [SerializeField] private float _ringOffset = 0f;

    protected RectTransform _cacheRectTransform { get; private set; }

    private static readonly List<UIVertex> _vertices = null;
    private static readonly List<int> _indices = null;

    static AdvancedCircleGraphic ()
    {
        _vertices = new List<UIVertex>(8);
        _indices = new List<int>()
        {
            0, 1, 5,
            0, 5, 4,
            1, 6, 5,
            1, 2, 6,
            2, 7, 6,
            2, 3, 7,
            3, 4, 7,
            3, 0, 4,
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
        AddRectToVertices(innerRect, _ringOffset);

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
}
