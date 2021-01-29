using Assets.Scripts.Objects;
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
        gameObject.GetComponentInParent<AnimatorScript>().AnimationLayers.Add(this); 
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


    public void ApplyAnimations(AnimationLayerObj animationLayerObj)
    {
        Animations = new Dictionary<string, Sprite[]>(); 
        gameObject.name = animationLayerObj.Name;
        LayerName = animationLayerObj.layer; 
        foreach(var ani in animationLayerObj.Animations)
        {
            Animations.Add(ani.Name, ani.Sprites); 
        }
    }
}
