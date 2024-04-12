using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    public void Start()
    {
        //PlayeMusic("theme");
    }
    public void PlayeMusic(string name)
    {
        Sound sound = Array.Find(musicSounds, x => x.Name == name);
        if (sound == null)
        {
            return;
        }

        musicSource.clip = sound.AudioClip;
        musicSource.Play();

    }
    public void PlayeSfx(string name)
    {
        Sound sound = Array.Find(sfxSounds, x => x.Name == name);
        if (sound == null)
        {
            return;
        }

        sfxSource.PlayOneShot(sound.AudioClip);

    }
    public void ToggleMusic()
    {
        if (musicSource == null)
        {
            return;
        }
        musicSource.mute = !musicSource.mute;

    }
    public void ToggleSfx()
    {
        if (sfxSource == null)
        {
            return;
        }
        sfxSource.mute = !sfxSource.mute;

    }
    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }
    public void SfxVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}
