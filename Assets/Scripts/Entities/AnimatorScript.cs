using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AnimatorScript : MonoBehaviour
{
    public List<AnimationLayer> AnimationLayers;

    public int AnimationRate = 10; 

    public int count = 0;

    public int currentSprite = 0;

    public string currentAnimation;

    public string QueuedAnimation = null;

    bool _queueLockout = false; 

    public bool RunningQueued
    {
        get { return QueuedAnimation != null || _queueLockout; }
    }

    

    // Start is called before the first frame update
    void Start()
    {
        QueuedAnimation = null; 
        //AnimationLayers = GetComponentsInChildren<AnimationLayer>().ToList();
        currentAnimation = "idledown";
    }

    // Update is called once per frame
    void Update()
    {
        if (count >= AnimationRate)
        {
            foreach (var layer in AnimationLayers)
                layer.SetAnimation(currentAnimation, currentSprite);

            currentSprite++;

            if (AnimationLayers.Count > 0
                && AnimationLayers[0].Animations.ContainsKey(currentAnimation)
                && AnimationLayers[0].Animations[currentAnimation].Length <= currentSprite)
            {
                currentSprite = 0;
                _queueLockout = false; 
                if (QueuedAnimation != null)
                {
                    currentAnimation = QueuedAnimation;
                    QueuedAnimation = null;
                    _queueLockout = true; 
                }
            }


            count = 0; 
        }


        count++; 
    }

    public void SetAnimation(string animation, bool force = false)
    {
        if (currentAnimation == animation)
            return;

        if (RunningQueued && !force)
        {
            return; 
        }
        _queueLockout = false;
        QueuedAnimation = null; 

        currentAnimation = animation;
        count = AnimationRate;
        currentSprite = 0; 
    }

    public void QueueAnimation(string animation)
    {
        QueuedAnimation = animation; 
    }
}
