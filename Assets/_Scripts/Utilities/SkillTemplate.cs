using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTemplate : MonoBehaviour
{
    [Header("Skill")]
    public bool apilityPermitted = true;


    public virtual void OnFlip()
    {

    }

    private void Update()
    {
        if (!apilityPermitted) return;
        EarlyProcessAbility();
        if (!LevelManager.Instance.gameStarted) return;
        ProcessAbility();
    }

    private void FixedUpdate()
    {
        if (!apilityPermitted) return;
        if (!LevelManager.Instance.gameStarted) return;
        FixedProcessAbility();
    }
    public virtual void EarlyProcessAbility()
    {

    }
    public virtual void ProcessAbility()
    {
        
    }
    public virtual void FixedProcessAbility()
    {
        if ( !apilityPermitted) return;
        if (!LevelManager.Instance.gameStarted) return;
    }
}
