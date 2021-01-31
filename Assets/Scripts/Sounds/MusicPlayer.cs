using Assets.Scripts.Objects;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//https://gamedevbeginner.com/ultimate-guide-to-playscheduled-in-unity/


public class MusicPlayer : MonoBehaviour
{


    public List<MusicObj> MusicObjs = new List<MusicObj>();


    public List<MusicObj> CurrentMusic; 


    public AudioSource[] AudioSource;


    double nextStartTime = 0;

    int toggle = 0;

    int nextClip = 0; 

    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponents<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (AudioSettings.dspTime > nextStartTime - 1 && CurrentMusic.Count > 0)
        {
            AddClipToPlaylist(); 
            
        }
    }

    public void AddClipToPlaylist()
    {
        AudioClip clipToPlay = CurrentMusic[nextClip].AudioClip;

        // Loads the next Clip to play and schedules when it will start
        AudioSource[toggle].clip = clipToPlay;
        AudioSource[toggle].PlayScheduled(nextStartTime);

        // Checks how long the Clip will last and updates the Next Start Time with a new value
        double duration = (double)clipToPlay.samples / clipToPlay.frequency;
        nextStartTime = nextStartTime + duration;

        // Switches the toggle to use the other Audio Source next
        toggle = 1 - toggle;

        // Increase the clip index number, reset if it runs out of clips
        nextClip = nextClip < CurrentMusic.Count - 1 ? nextClip + 1 : 0;
    }

    /// <summary>
    /// Loads a specific music tag. 
    /// </summary>
    /// <param name="tag"></param>
    public void LoadMusicTag(string tag)
    {
        foreach (var source in AudioSource)
            source.Stop(); 

        CurrentMusic = MusicObjs.Where(x => x.Tags.Contains(tag)).OrderBy(x => Random.value).ToList();
        nextStartTime = AudioSettings.dspTime;
        nextClip = 0; 
    }

    /// <summary>
    /// Gets an accurate clip duration.  
    /// </summary>
    /// <param name="audioClip"></param>
    /// <returns></returns>
    double GetClipDuration(AudioClip audioClip)
    {
        return  (double)audioClip.samples / audioClip.frequency;
    }
}
