using Assets.Scripts.Objects;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<PrefabObj> Prefabs;


    public WorldScript World;


    public List<AnimationLayerObj> animationLayers; 

    // Start is called before the first frame update
    void Start()
    {
        World = FindObjectOfType<WorldScript>();

        var entity = Prefabs.FirstOrDefault(x => x.Name == "Entity");
        var player = Instantiate(entity.Prefab);
        player.transform.position = World.SpawnPoint;
        player.AddComponent<PlayerController>();

        var layerprefab = Prefabs.FirstOrDefault(x => x.Name == "AnimationLayer");
        var layer = Instantiate(layerprefab.Prefab, player.transform);
        layer.GetComponent<AnimationLayer>().ApplyAnimations(animationLayers[0]); 

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
