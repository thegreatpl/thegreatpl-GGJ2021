using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class WorldEditor : MonoBehaviour
{

    [MenuItem("WorldEditor/LoadObjects")]
    public static void LoadAllObjects()
    {
        var worldScript = FindObjectOfType<WorldScript>(); 

        if (worldScript == null)
        {
            var worldobj = GameObject.Find("World");
            worldobj.AddComponent<WorldScript>(); 
        }

        //spawners. 
        var spawners = FindObjectsOfType<ChickenSpawner>();
        worldScript.ChickenSpawners = spawners.ToList();


    }

    [MenuItem("WorldEditor/Validate")]
    public static void Validate()
    {
        var scenes = Directory.GetFiles("Assets/Scenes").Where(x => Path.GetExtension(x) == ".unity"); 
        //delete any instances of the GameController. 
        foreach(var scenename in scenes)
        {
            var scene = EditorSceneManager.OpenScene(scenename);

            if (scene.name == "MenuScene")
                continue; 

            var obj = GameObject.Find("GameController"); 
            if (obj != null)
            {
                DestroyImmediate(obj);
                EditorApplication.SaveScene(); 
            }

        }

    }
}
