using UnityEngine;
using UnityEditor;

public class GeneralXrCore : EditorWindow
{
    [MenuItem("X-Ray Plugin/Open A-Life Generator")]
    public static void ShowWindow()
    {
        GetWindow<GeneralXrCore>(false, "A-Life Generator", true);
    }

    Object source;

    void OnGUI()
    {
        GUILayout.Label("A-Life Generator", EditorStyles.boldLabel);
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.BeginVertical("box");
        source = EditorGUILayout.ObjectField(source, typeof(Object), true);
        TextAsset newTxtAsset = (TextAsset)source;
        if (GUILayout.Button("Create", GUILayout.Height(25)))
        {
            Alife_Converter converter = new Alife_Converter();
            converter.Parse(newTxtAsset);
            Alife_Generator generator = new Alife_Generator();
            generator.Generation(converter);
        }
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndHorizontal();
    }

}
