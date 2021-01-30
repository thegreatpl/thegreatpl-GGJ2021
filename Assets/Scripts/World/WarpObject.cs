using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpObject : MonoBehaviour
{
    public string SceneName;

    public List<string> EnableFlags = new List<string>();


    public bool Enabled = true;


    SpriteRenderer SpriteRenderer; 

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (EnableFlags.Count > 0)
        {
            if (GameManager.GM.Flags.ContainsAllItems(EnableFlags))
            {
                Enabled = true;
                SpriteRenderer.enabled = true; 
            }
            else
            {
                Enabled = false;
                SpriteRenderer.enabled = false;

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Enabled)
            return; 

        if (collision.gameObject.tag == "Player")
        {
            GameManager.GM.LoadScene(SceneName); 
        }
    }

    
}
