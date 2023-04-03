using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;

    public static SoundManager Instance{get {return instance;}}

    public AudioSource  SoundEffect;
    public AudioSource SoundMusic;
    public SoundType[] Sound;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void Start()
    {
        PlayMusic(Sounds.GameMusic);
    }
    public void PlayMusic(Sounds sounds)
    {
        AudioClip clip = GetAudioClip(sounds);

        if(clip != null)
        {
            SoundMusic.clip = clip;
            SoundMusic.Play();
        }
        else
        {
            Debug.Log("Clip not found for soundtype" + sounds);
        }
    }
    public void Play(Sounds sounds)
    {
        AudioClip clip = GetAudioClip(sounds);

        if(clip != null)
            SoundEffect.PlayOneShot(clip);
        else
            Debug.Log("Clip not found for soundtype" + sounds);
    }

    public AudioClip GetAudioClip(Sounds sounds)
    {
        SoundType item = Array.Find(Sound, i => i.soundtype == sounds);

        if(item != null)
            return item.soundclip;
        return null;
        
    }

}

[Serializable]
public class SoundType
{
    public Sounds soundtype;
    public AudioClip soundclip;
}
public enum Sounds
    {
        GameOver,
        LevelComplete,
        Playermovement,
        Playerjump,
        ButtonClick,
        GameMusic,
        Collisionwithenemy
    }