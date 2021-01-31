using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BossFightManager : MonoBehaviour
{
    public Vector2 BossSpawnLocation; 

    public GameObject BossPrefab; 

    // Start is called before the first frame update
    void Start()
    {
        SpawnBoss(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void SpawnBoss()
    {
        var layerprefab = GameManager.GM.Prefabs.FirstOrDefault(x => x.Name == "AnimationLayer");

        var chick = Instantiate(BossPrefab, BossSpawnLocation, BossPrefab.transform.rotation);

        var layer = Instantiate(layerprefab.Prefab, chick.transform);
        layer.GetComponent<AnimationLayer>().ApplyAnimations(GameManager.GM.animationLayers.Where(x => x.layer == "Chicken").GetRandom());
        layer.GetComponent<SpriteRenderer>().color = Color.black;

        var cont = chick.GetComponent<ChickenController>();
        cont.Target = GameManager.GM.Player.GetComponent<Attributes>();
        cont.RemainingLife = 100000;

        chick.GetComponent<Attributes>().OnDeath += () => { StartCoroutine(EndGame()); }; 
    }


    IEnumerator EndGame()
    {
        GameManager.GM.UIGame.ShowVictoryScreen();
        yield return new WaitForSeconds(20);
        GameManager.GM.LoadMenu(); 
    }
}
