using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverCanvas;
    private FB_ScoreController _FBScoreController;
    void Start()
    {
        Time.timeScale = 1;
        _FBScoreController = FindObjectOfType<FB_ScoreController>();
    }
    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        _FBScoreController.WriteNewScore();
        Time.timeScale = 0;
    }
    public void Replay()
    {
        SceneManager.LoadScene("TheFlappyGame");
    }
}
