using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : GeneralSingleton<SoundManager>
{
    [Header("General")]
    [Range(.1f,1f)]
    public float musicVolume = 1f;    
    [Range(.1f,1f)]
    public float sfxVolume = 1f;
    [Range(.1f, 1f)]
    public float pitchRange = .5f;
    [Header("Binding")]
    public AudioSource SFXSource;
    public AudioSource MusicSource;

    public void PlaySFX(AudioClip SFX,bool randomPitch = false)
    {
        if (SFX == null) return;
        var pitch = (randomPitch) ? Random.Range(pitchRange, 1) : 1;
        SFXSource.pitch = pitch;
        SFXSource.PlayOneShot(SFX, sfxVolume);
    }

    public void PlayMusic(AudioClip Music)
    {
        if (Music == null) return;
        if (MusicSource.clip == Music) return;
        MusicSource.volume = musicVolume;
        MusicSource.clip = Music;
        MusicSource.Play();
    }
}
