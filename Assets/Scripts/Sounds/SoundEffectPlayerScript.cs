using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectPlayerScript : MonoBehaviour
{
    /// <summary>
    /// The audio source that will play the effects. 
    /// </summary>
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

    /// <summary>
    /// Plays an audio clip. 
    /// </summary>
    /// <param name="clip"></param>
    public void PlayAudio(AudioClip clip)
    {
        AudioSource.clip = clip;
        AudioSource.Play(); 
    }
}
