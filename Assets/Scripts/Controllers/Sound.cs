using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip; 
    [HideInInspector]
    public AudioSource sourse;
    public AudioMixerGroup mixer;
    [Range(0f, 1f)] public float volume;
}
