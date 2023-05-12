using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayUIController : MonoBehaviour
{
    public Text pointText;
    public Text highestScoreText;
    public Text gameOverText;
    public GameObject gameOverPanel;
    public Button restartButton;

    public Transform ball;

    public int currentPoint;
    
    private void Awake()
    {
        currentPoint = 0;
        restartButton.onClick.AddListener(OnRestartButtonClicked);
        highestScoreText.text = "HC:" + GameData.HighestScore.ToString();
    }

    public void ToggleGameOverPanel(bool open, bool isWin)
    {
        if (open)
        {
            gameOverPanel.SetActive(true);
            gameOverText.text = "You " + ((isWin == true) ? "win" : "lose") + "\nYour point:" + currentPoint;
            if (isWin)
            {
                if (currentPoint > GameData.HighestScore)
                {
                    GameData.HighestScore = currentPoint;
                }
            }
        }
        else
        {
            gameOverPanel.SetActive(false);
        }
    }

    private void Update()
    {
        currentPoint = Mathf.CeilToInt(-ball.position.y);
        pointText.text = currentPoint.ToString();
    }

    public void OnRestartButtonClicked()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
