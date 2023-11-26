using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance;
    [SerializeField] List<AudioClip> clipList = new List<AudioClip>();
    public AudioSource audioSource;
    Hashmap<AudioClip> hashmap;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        hashmap = new Hashmap<AudioClip>(clipList.Count);
        foreach(AudioClip clip in clipList) 
        {
            hashmap.Add(clip.name, clip);
        }
    }
    public void PlaySound(string soundName)
    {
        AudioClip clip = hashmap.Get(soundName);
        audioSource.PlayOneShot(clip);
    }
}
