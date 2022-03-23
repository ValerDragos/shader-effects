using UnityEngine;
using UnityEngine.UI;

public class CircleGraphic : Graphic
{
    private const float UV_DISTANCE = 1f;

    public Sprite sprite;

    protected RectTransform _cacheRectTransform { get; private set; }

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
        var rect = _cacheRectTransform.rect;
        vh.AddUIVertexQuad(new UIVertex[]
        {
            new UIVertex()
            {
                position = new Vector3(rect.xMin, rect.yMin, 0),
                uv0 = new Vector4(-UV_DISTANCE, -UV_DISTANCE, 0, 0),
                color = color
            },
            new UIVertex()
            {
                position = new Vector3(rect.xMin, rect.yMax, 0),
                uv0 = new Vector4(-UV_DISTANCE, UV_DISTANCE, 0, 0),
                color = color
            },
            new UIVertex()
            {
                position = new Vector3(rect.xMax, rect.yMax, 0),
                uv0 = new Vector4(UV_DISTANCE, UV_DISTANCE, 0, 0),
                color = color
            },
            new UIVertex()
            {
                position = new Vector3(rect.xMax, rect.yMin, 0),
                uv0 = new Vector4(UV_DISTANCE, -UV_DISTANCE, 0, 0),
                color = color
            },
        });

        //float majorRadius = rectTransform.rect.width * 0.5f;
        //float minorRadius = rectTransform.rect.height * 0.5f;
        //Vector2 center = Vector2.one * 0.5f - rectTransform.pivot;
        //center = new Vector2(center.x * majorRadius * 2, center.y * minorRadius * 2);
        //UIVertex vertex = UIVertex.simpleVert;
        //float deltaAngle = Mathf.PI * 2 / divisions;
        //int vertexCount = divisions * 2;
    }
}
