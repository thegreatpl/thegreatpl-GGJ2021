using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationLayer : MonoBehaviour
{
    public string LayerName; 

    public SpriteRenderer Sprite;


    public Dictionary<string, Sprite[]> Animations = new Dictionary<string, Sprite[]>(); 

    // Start is called before the first frame update
    void Start()
    {
        Sprite = GetComponent<SpriteRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAnimation(string name, int count)
    {
        if (Animations.ContainsKey(name))
        {
            var currentanim = Animations[name];
            if (currentanim.Length > count)
                Sprite.sprite = currentanim[count]; 
        }
    }
}
