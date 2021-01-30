using Assets.Scripts.Objects;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string StartScene = "MainScene"; 

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
        StartCoroutine(StartNewGame()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator StartNewGame()
    {
        //cleanup old game. 
        if (Player != null)
            Destroy(Player.gameObject);

        if (MainCamera == null)
            MainCamera = Instantiate(Prefabs.FirstOrDefault(x => x.Name == "MainCamera").Prefab).GetComponent<Camera>(); 

        yield return null; 

        var entity = Prefabs.FirstOrDefault(x => x.Name == "Entity");

        var player = Instantiate(entity.Prefab);
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
        Player = player; 
        DontDestroyOnLoad(player);
        yield return null;

        StartCoroutine(LoadScene(StartScene)); 
    }

    public IEnumerator LoadScene(string scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);

        yield return null; 

        World = FindObjectOfType<WorldScript>();

        Player.transform.position = World.SpawnPoint;


        yield return StartCoroutine(SpawnChickens(10)); 
    }




    IEnumerator SpawnChickens(int chickenNumber)
    {
        var chicken = Prefabs.FirstOrDefault(x => x.Name == "Chicken"); 
        var layerprefab = Prefabs.FirstOrDefault(x => x.Name == "AnimationLayer");

        var spawners = World.ChickenSpawners
            .Where(x => Vector3.Distance(x.transform.position, Player.transform.position) > x.MinDistance
                && Vector3.Distance(x.transform.position, Player.transform.position) < x.MaxDistance).ToList();

        if (spawners.Count == 0)
            spawners = World.ChickenSpawners; 

        for (int idx = 0; idx < chickenNumber; idx++)
        {
            var spawner = spawners.GetRandom();
            var chick = Instantiate(chicken.Prefab, spawner.transform.position, chicken.Prefab.transform.rotation);

            var layer = Instantiate(layerprefab.Prefab, chick.transform);
            layer.GetComponent<AnimationLayer>().ApplyAnimations(animationLayers.Where(x => x.layer == "Chicken").GetRandom());
            layer.GetComponent<SpriteRenderer>().color = Color.red;

            var cont = chick.GetComponent<ChickenController>();
            cont.Target = Player.GetComponent<Attributes>();
            cont.RemainingLife = spawner.Lifetime; 
        }

        yield return null; 
    }
}
