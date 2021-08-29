using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : GeneralSingleton<GameManager>
{
    [Header("General")]
    public int targetMobileFPS = 60;
    private void Start()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        Application.targetFrameRate = targetMobileFPS;
#endif
    }

}
