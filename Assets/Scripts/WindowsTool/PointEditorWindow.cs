using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NN.Utilities;

public class PointEditorWindow : EditorWindow
{
    [MenuItem("CheatTools/CharacterDesigner")]
    public static void OpenWindow()
    {
        PointEditorWindow window = (PointEditorWindow)GetWindow(typeof(PointEditorWindow));
        window.minSize = new UnityEngine.Vector2(600, 1000);
        window.Show();
    }

    private void OnGUI()
    {
        EditorGUILayout.Space();
        var buttonStyle = new GUIStyle(GUI.skin.button) { fontStyle = FontStyle.Bold, fixedHeight = 30 };
        if (GUILayout.Button("Respawn point Random", buttonStyle))
        {
            EventDispatcher.Publish(Events.RespawnPoint, 0);
        }
        if (GUILayout.Button("Respawn point Grid", buttonStyle))
        {
            EventDispatcher.Publish(Events.RespawnPoint, 1);
        }
    }

}
