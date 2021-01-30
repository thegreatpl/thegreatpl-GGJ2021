using Assets.Scripts.Objects;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Camera MainCamera; 

    public List<PrefabObj> Prefabs;


    public WorldScript World;


    public List<AnimationLayerObj> animationLayers;


    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        MainCamera = Camera.main;
        DontDestroyOnLoad(this); 
        StartCoroutine(LoadScene()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator LoadScene()
    {
        var entity = Prefabs.FirstOrDefault(x => x.Name == "Entity");

        GameObject player;
        player = GameObject.FindGameObjectWithTag("Player");
        //ensure the player exists. 
        if (player == null)
        {

            player = Instantiate(entity.Prefab);
            player.tag = "Player";
            player.AddComponent<PlayerController>();

            MainCamera.transform.parent = player.transform;

            yield return null;

            var layerprefab = Prefabs.FirstOrDefault(x => x.Name == "AnimationLayer");



            var body = Instantiate(layerprefab.Prefab, player.transform);            
            var legs = Instantiate(layerprefab.Prefab, player.transform);
            var hair = Instantiate(layerprefab.Prefab, player.transform);
            var chest = Instantiate(layerprefab.Prefab, player.transform);

            yield return null;
            var bodyal = body.GetComponent<AnimationLayer>();
            bodyal.ApplyAnimations(animationLayers.Where(x => x.layer == "Body").GetRandom());
            bodyal.Sprite.sortingOrder = 1;
            var hairyal = hair.GetComponent<AnimationLayer>();
            hairyal.ApplyAnimations(animationLayers.Where(x => x.layer == "Hair").GetRandom());
            hairyal.Sprite.sortingOrder = 2;
            var chestyal = chest.GetComponent<AnimationLayer>(); 
            chestyal.ApplyAnimations(animationLayers.Where(x => x.layer == "Chest").GetRandom());
            chestyal.Sprite.sortingOrder = 2;
            var legsyal = legs.GetComponent<AnimationLayer>(); 
            legsyal.ApplyAnimations(animationLayers.Where(x => x.layer == "Legs").GetRandom());
            legsyal.Sprite.sortingOrder = 2;  

            DontDestroyOnLoad(player);
            yield return null; 
        }
        Player = player; 
        World = FindObjectOfType<WorldScript>();

        player.transform.position = World.SpawnPoint;


        yield return StartCoroutine(SpawnChickens(10)); 
    }




    IEnumerator SpawnChickens(int chickenNumber)
    {
        var chicken = Prefabs.FirstOrDefault(x => x.Name == "Chicken"); 
        var layerprefab = Prefabs.FirstOrDefault(x => x.Name == "AnimationLayer");

        for (int idx = 0; idx < chickenNumber; idx++)
        {
            var chick = Instantiate(chicken.Prefab);

            var layer = Instantiate(layerprefab.Prefab, chick.transform);
            layer.GetComponent<AnimationLayer>().ApplyAnimations(animationLayers.Where(x => x.layer == "Chicken").GetRandom());
            layer.GetComponent<SpriteRenderer>().color = Color.red;

            chick.GetComponent<ChickenController>().Target = Player; 
        }

        yield return null; 
    }
}
