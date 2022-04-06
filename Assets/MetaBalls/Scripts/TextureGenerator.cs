using System;
using System.IO;
using UnityEngine;

public class TextureGenerator : MonoBehaviour
{
    [SerializeField] private AnimationCurve _curve = null;
    [SerializeField] private int _textureWidth = 1;

    public void Create (string path)
    {
        if (string.IsNullOrEmpty(path)) return;

        var texture = GenerateTexture();

        try
        {
            var pngData = texture.EncodeToPNG();
            File.WriteAllBytes(path, pngData);
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
            
        DestroyImmediate(texture);
    }

    private Texture2D GenerateTexture ()
    {
        var texture = new Texture2D(_textureWidth, 1, TextureFormat.RGBA32, mipChain: false);

        var evaluateOffset = (1f / _textureWidth) * 0.5f;
        float evaluateValue;

        for (int i=0; i< _textureWidth; ++i)
        {
            evaluateValue = (float)i / _textureWidth + evaluateOffset;
            texture.SetPixel(i, 0, new Color(1, 1, 1, _curve.Evaluate(evaluateValue)));
        }

        return texture;
    }

    private void OnValidate()
    {
        _textureWidth = Mathf.Max(1, _textureWidth);
    }
}
