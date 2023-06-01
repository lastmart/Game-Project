using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Sound[] Sounds; 
    
    private void Start()
    {
        foreach (var sound in Sounds)
        {
            sound.sourse = gameObject.AddComponent<AudioSource>();
            sound.sourse.clip = sound.clip;
            sound.sourse.outputAudioMixerGroup = sound.mixer;
            sound.sourse.playOnAwake = false;
            sound.sourse.volume = sound.volume;
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public void Play(string clipName)
    {
        var sound = Array.Find(Sounds, sound => sound.name == clipName);
        sound.sourse.Play();
    }
}