using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MSingleton<UIManager>
{
    [Header("Panels")]
    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject startPanel;

    [Header("Image")]
    public Image scoreFill;
    public Image winFill;

    [Header("Animation")]
    public Animator stickerBar;
    public Animator carveBar;
    public Animator scoreBar;

    [Header("Text")]
    public Text scoreText;

    public void StartLevel()
    {
        startPanel.SetActive(false);
        LevelManager.Instance.gameStarted = true;
        stickerBar.SetTrigger("Show");
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
