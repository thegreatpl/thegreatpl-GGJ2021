using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtmosphericNoiseScript : MonoBehaviour
{
    public AudioSource AudioSource; 

    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioSource.Play();
        }
    }
}
