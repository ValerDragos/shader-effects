using UnityEngine;

public class Container : MonoBehaviour
{
    [SerializeField]
    private float _force = 0f;

    private Vector2 _halfSize = new Vector2();
    private Vector3 _center = new Vector3();

    private void Awake()
    {
        var rectTransform = GetComponent<RectTransform>();
        var rect = rectTransform.rect;

        var topRight = rectTransform.TransformPoint(rect.max);
        var bottomLeft = rectTransform.TransformPoint(rect.min);

        _halfSize = new Vector2(topRight.x - bottomLeft.x, topRight.y - bottomLeft.y);
        _halfSize *= 0.5f;
        _center = Vector3.Lerp(bottomLeft, topRight, 0.5f);
    }

    public Vector3 GetVelocityVector (Vector3 worldPosition)
    {
        var delta = _center - worldPosition;
        var sign = new Vector2(Mathf.Sign(delta.x), Mathf.Sign(delta.y));

        return new Vector3(
            Mathf.Max(0f, delta.x * sign.x - _halfSize.x) * sign.x * _force,
            Mathf.Max(0f, delta.y * sign.y - _halfSize.y) * sign.y * _force
            );
    }
}
