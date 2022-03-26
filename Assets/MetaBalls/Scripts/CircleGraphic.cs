using UnityEngine;
using UnityEngine.UI;

public class CircleGraphic : Graphic
{
    private const float UV_DISTANCE = 1f;

    public Texture texture;
    public override Texture mainTexture => texture;

    protected RectTransform _cacheRectTransform { get; private set; }

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
    }
}
