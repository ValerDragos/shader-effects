using UnityEngine;

public class VelocityHandler : MonoBehaviour
{
    [SerializeField]
    private Vector2 _startSpeedRange = new Vector2();

    public Vector3 velocityVector = new Vector3();
    private RectTransform _cacheRectTransform = null;

    private void Awake()
    {
        velocityVector = Random.insideUnitCircle * Mathf.Lerp(_startSpeedRange.x, _startSpeedRange.y, Random.Range(0f, 1f));
        _cacheRectTransform = GetComponent<RectTransform>();
    }

    private void LateUpdate()
    {
        _cacheRectTransform.position += velocityVector * Time.fixedDeltaTime;
    }
}
