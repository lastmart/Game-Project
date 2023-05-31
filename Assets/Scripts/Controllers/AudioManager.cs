using System;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Sound[] Sounds;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (var sound in Sounds)
        {
            sound.sourse = gameObject.AddComponent<AudioSource>();
            sound.sourse.clip = sound.clip;
            sound.sourse.outputAudioMixerGroup = sound.mixer;
            sound.sourse.playOnAwake = false;
        }
    }

    public void Play(string clipName)
    {
        var sound = Array.Find(Sounds, sound => sound.name == clipName);
        sound.sourse.Play();
    }
}
