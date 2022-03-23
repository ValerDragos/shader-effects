using System;
using System.IO;
using UnityEngine;

public class TextureGenerator : MonoBehaviour
{
    private const int TEXTURE_WITH = 256;

    [SerializeField] private AnimationCurve _curve = null;

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
        var texture = new Texture2D(TEXTURE_WITH, 1, TextureFormat.RGBA32, mipChain: false);

        var evaluateOffset = (1f / TEXTURE_WITH) * 0.5f;
        float evaluateValue;

        for (int i=0; i< TEXTURE_WITH; ++i)
        {
            evaluateValue = (float)i / TEXTURE_WITH + evaluateOffset;
            texture.SetPixel(i, 0, new Color(1, 1, 1, _curve.Evaluate(evaluateValue)));
        }

        return texture;
    }
}
