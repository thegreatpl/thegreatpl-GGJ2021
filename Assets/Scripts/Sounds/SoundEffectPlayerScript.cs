using Assets.Scripts.Objects;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SoundEffectPlayerScript : MonoBehaviour
{

    public List<MusicObj> SoundEffects = new List<MusicObj>(); 

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


    public void PlayAudio(string name)
    {
        var clip = SoundEffects.FirstOrDefault(x => x.Name == name);
        if (clip != null)
            PlayAudio(clip.AudioClip); 
    }


    public void PlayAudioViaTag(string tag)
    {
        var clip = SoundEffects.Where(x => x.Tags.Contains(tag)).GetRandom();
        if (clip != null)
            PlayAudio(clip.AudioClip); 
    }


    public AudioClip GetRandomOfTag(string tag)
    {
        return SoundEffects.Where(x => x.Tags.Contains(tag)).GetRandom().AudioClip; 
    }
}
