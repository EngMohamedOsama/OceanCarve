using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MSingleton<LevelManager>
{
    [Header("General")]
    public AudioClip music;

    [Header("Debug")]
    [ReadOnly]
    public bool gameStarted = true;
    [ReadOnly]
    public CarveArea carveArea;
    [ReadOnly]
    public Sticker currentSticker;
    [ReadOnly]
    public CarveTool currentCarveTool;

    void Start()
    {
      SoundManager.Instance.PlayMusic(music);
    }
}
