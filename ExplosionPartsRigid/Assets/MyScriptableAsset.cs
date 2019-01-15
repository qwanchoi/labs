using UnityEditor;
using UnityEngine;

public class MyScriptableAsset : ScriptableObject {

    [MenuItem("Example/Create ExampleAsset Instance")]
    static void CreateExampleAssetsInstance()
    {
        var exampleAsset = CreateInstance<MyScriptableAsset>();

        AssetDatabase.CreateAsset(exampleAsset, "Assets/Editor/ExampleAssets.asset");
        AssetDatabase.Refresh();

    }
}
