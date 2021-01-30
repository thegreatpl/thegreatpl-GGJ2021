using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{

    public int AnimationSpeed = 20;

    int animationFrame = 0; 

    int count = 0; 

    public List<Sprite> ExplostionSprites;

    public SpriteRenderer SpriteRenderer; 

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
            if (animationFrame >= ExplostionSprites.Count)
            {
                Destroy(gameObject);
                return; 
            }

            SpriteRenderer.sprite = ExplostionSprites[animationFrame];
            animationFrame++;
            count = 0; 
        }
        count++; 
    }
}
