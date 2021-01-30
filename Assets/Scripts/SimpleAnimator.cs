using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SimpleAnimator : MonoBehaviour
{

    public List<Sprite> AnimationSprites;

    public int AnimationSpeed = 40;

    int animationFrame = 0;

    int count = 0;

    SpriteRenderer SpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (count > AnimationSpeed)
        {
            if (animationFrame >= AnimationSprites.Count)
                animationFrame = 0; 

            SpriteRenderer.sprite = AnimationSprites[animationFrame];
            animationFrame++;
            count = 0;
        }
        count++;
    }
}
