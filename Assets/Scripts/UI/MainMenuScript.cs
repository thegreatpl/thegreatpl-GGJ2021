using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public GameObject MenuChickenPrefab; 

    public GameObject GameManagerPrefab; 
    // Start is called before the first frame update
    void Start()
    {
        //make sure only one GameManager exists at a time. 
        if (GameManager.GM == null)
            Instantiate(GameManagerPrefab);

        StartCoroutine(SpawnMenuItems()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator SpawnMenuItems()
    {
        yield return null; 

        for(int idx = 0; idx < 5; idx++)
        {
            var layerprefab = GameManager.GM.Prefabs.FirstOrDefault(x => x.Name == "AnimationLayer");
            var chicken = Instantiate(MenuChickenPrefab, new Vector3(Random.Range(-MenuChickenController.range, MenuChickenController.range), Random.Range(-MenuChickenController.range, MenuChickenController.range)), MenuChickenPrefab.transform.rotation);
            var layer = Instantiate(layerprefab.Prefab, chicken.transform);
            layer.GetComponent<AnimationLayer>().ApplyAnimations(GameManager.GM.animationLayers.Where(x => x.layer == "Chicken").GetRandom());
            layer.GetComponent<SpriteRenderer>().color = Color.red;
        }

    }

    public void StartGame()
    {
        GameManager.GM.NewGame(); 
    }


    public void ExitGame()
    {
        Application.Quit(); 
    }
}
