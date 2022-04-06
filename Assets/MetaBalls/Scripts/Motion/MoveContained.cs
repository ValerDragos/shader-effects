using UnityEngine;

[RequireComponent(typeof(VelocityHandler))]
public class MoveContained : MonoBehaviour
{
    public Container container = null;

    private VelocityHandler _velocityHandler = null;

    private RectTransform _cacheRectTransform = null;

    private void Awake()
    {
        _velocityHandler = GetComponent<VelocityHandler>();
        _cacheRectTransform = GetComponent<RectTransform>();
    }

    void FixedUpdate()
    {
        _velocityHandler.velocityVector += container.GetVelocityVector(_cacheRectTransform.position) * Time.fixedDeltaTime;
    }
}
