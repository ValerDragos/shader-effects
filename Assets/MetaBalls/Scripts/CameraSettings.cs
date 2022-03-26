using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class CameraSettings : MonoBehaviour
{
    private void Awake()
    {
        var camera = GetComponent<Camera>();
        camera.depthTextureMode = DepthTextureMode.None;
    }
}
