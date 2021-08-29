using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MSingleton<ScoreManager>
{
    [Header("General")]
    public float winMultiplayer;

    [Header("SFX")]
    public AudioClip scoreSFX;

    [Header("Debug")]
    
    [ReadOnly]
    public int levelProgress;
    [ReadOnly]
    public float score = 0;
    [ReadOnly]
    public float totalScore;
    [ReadOnly]
    public float winThreshHold = 0;

    public void AddScore(int value)
    {
        score = Mathf.Clamp(score + value, 0, Mathf.Infinity);
        UIManager.Instance.scoreText.text = score.ToString() + "/" + totalScore.ToString();
        UIManager.Instance.scoreFill.fillAmount = score / totalScore;
    }

    public void ResetScore()
    {
        UIManager.Instance.scoreText.text = score.ToString() + "/" + totalScore.ToString();
        UIManager.Instance.scoreFill.fillAmount = score / totalScore;

        winThreshHold = (totalScore / winMultiplayer);
        UIManager.Instance.winFill.fillAmount = winThreshHold / totalScore;
    }
    public void AddProgress()
    {
        levelProgress += 1;
        if (levelProgress == totalScore)
        {
            UIManager.Instance.scoreBar.SetTrigger("Hide");
            LevelManager.Instance.gameStarted = false;
            if (score >= winThreshHold)
                UIManager.Instance.winPanel.SetActive(true);
            else UIManager.Instance.losePanel.SetActive(true);
        }
    }
}
