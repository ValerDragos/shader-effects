using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractGraphic : Graphic
{
    public Texture texture;
    public override Texture mainTexture => texture;
    [SerializeField] 
    protected CornerColors _cornerColors = new CornerColors(Color.white);

    protected RectTransform _cacheRectTransform { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        _cacheRectTransform = GetComponent<RectTransform>();
    }

    protected Color GetColor (Vector2 normalizedPosition)
    {
        var leftColor = GetLeftColor(normalizedPosition.y);
        var rightColor = GetRightColor(normalizedPosition.y);
        return Color.Lerp(leftColor, rightColor, normalizedPosition.x);
    }

    protected Color GetLeftColor (float normalizedPosition)
    {
        return Color.Lerp(_cornerColors.bottomLeft, _cornerColors.topLeft, normalizedPosition);
    }

    protected Color GetRightColor(float normalizedPosition)
    {
        return Color.Lerp(_cornerColors.bottomRight, _cornerColors.topRight, normalizedPosition);
    }

    [Serializable]
    public struct CornerColors
    {
        public Color topLeft;
        public Color topRight;
        public Color bottomLeft;
        public Color bottomRight;

        public CornerColors(Color color) =>
            (topLeft, topRight, bottomLeft, bottomRight) = (color, color, color, color);
    }
}
