using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggCollectableObject : MonoBehaviour
{
    /// <summary>
    /// Unique name for this egg. 
    /// </summary>
    public string EggName;

    public AudioClip EggFoundSound; 

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.GM.Flags.Contains($"{EggName}_Collected"))
            Destroy(gameObject);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {

            

            GameManager.GM.Eggs++; 
            GameManager.GM.Flags.Add($"{EggName}_Collected");
            GameManager.GM.SoundEffectPlayerScript.PlayAudio(EggFoundSound); 
            Destroy(gameObject); 

        }
    }
}
