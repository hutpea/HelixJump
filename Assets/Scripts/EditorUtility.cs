using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public static class EditorUtility
{
    [MenuItem("Editor Utility/Open Loading #1")]
    public static void OpenLoading()
    {
        string localPath = "Assets/Scenes/Loading.unity";
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene(localPath);
    }
    [MenuItem("Editor Utility/Open Gameplay #2")]
    public static void OpenGameplay()
    {
        string localPath = "Assets/Scenes/Gameplay.unity";
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene(localPath);
    }
    
}
