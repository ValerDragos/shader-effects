using UnityEngine;

public class RotationHandler : MonoBehaviour
{
    [SerializeField] private Vector2 _rotationSpeedRange = new Vector2();

    private Transform _cachedTransform = null;
    private float _rotationSpeed = 0f;

    private void Awake()
    {
        _cachedTransform = transform;
        _rotationSpeed = Mathf.Lerp(_rotationSpeedRange.x, _rotationSpeedRange.y, Random.Range(0f, 1f));
    }

    private void Update()
    {
        Quaternion rotationMultiplier = Quaternion.Euler(0f, 0f, _rotationSpeed * Time.deltaTime);
        _cachedTransform.localRotation *= rotationMultiplier;
    }
}
