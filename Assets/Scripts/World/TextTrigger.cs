using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrigger : MonoBehaviour
{
    public AudioClip OnActiveSound; 

    [TextArea]
    public string Text;

    public int Seconds; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.GM.UIGame.DisplayText(Text, Seconds);
            if (OnActiveSound != null)
                GameManager.GM.SoundEffectPlayerScript.PlayAudio(OnActiveSound); 
        }
    }
}
