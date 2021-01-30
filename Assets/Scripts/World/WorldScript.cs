using Assets.Scripts.Objects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScript : MonoBehaviour
{

    public List<ChickenSpawner> ChickenSpawners; 

    public Vector2 SpawnPoint;

    /// <summary>
    /// Minimum number of seconds before Chickens are spawned in. 
    /// </summary>
    public int MinSecondsBetweenSpawns = 10;

    /// <summary>
    /// Maximum number of seconds before Chickens are spawned. 
    /// </summary>
    public int MaxSecondsBetweenSpawns = 30;

    /// <summary>
    /// Minimum chickens to be spawned in a spawning. 
    /// </summary>
    public int MinChickesnPerSpawn = 10; 

    /// <summary>
    /// Maximum chickens per spawn. 
    /// </summary>
    public int MaxChickensPerSpawn = 30; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
