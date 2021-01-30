using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{

    public GameObject GameManagerPrefab; 
    // Start is called before the first frame update
    void Start()
    {
        //make sure only one GameManager exists at a time. 
        if (GameManager.GM == null)
            Instantiate(GameManagerPrefab); 
    }

    // Update is called once per frame
    void Update()
    {
        
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
