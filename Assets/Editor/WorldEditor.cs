using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
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
}
