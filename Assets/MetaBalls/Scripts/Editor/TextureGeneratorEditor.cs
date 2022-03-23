using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TextureGenerator))]
public class TextureGeneratorEditor : Editor
{
    private TextureGenerator _textureGenerator = null;

    private void OnEnable()
    {
        _textureGenerator = target as TextureGenerator;
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Generate"))
        {
            var path = EditorUtility.SaveFilePanel(
            "Save texture as PNG",
            Application.dataPath,
            "NewTexture.png",
            "png");

            _textureGenerator.Create(path);
            AssetDatabase.Refresh();
        }
    }
}
