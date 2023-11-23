using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject pauseMenu;
    public static int currentScore = 0;
    public static GameObject scoreText;
    public static TextMeshProUGUI scoreTextMesh;

    public static int highScore = 0;
    public static GameObject highScoreText;
    public static TextMeshProUGUI highScoreTextMesh;
    
    void Awake() {
        scoreText = GameObject.Find("ScoreText");
        scoreTextMesh = scoreText.GetComponent<TextMeshProUGUI>();
        scoreTextMesh.text = "Score: 0";

        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreTextMesh = GameObject.Find("HighScoreText").GetComponent<TextMeshProUGUI>();
        highScoreTextMesh.text = "High Score: " + highScore.ToString();
        if (pauseMenu != null) pauseMenu.SetActive(false);
        isPaused = false;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isPaused) {
                ResumeGame();
            } else {
                PauseGame();
            }
        }
    }

    public static void updateScore(int scoreVal) {

        currentScore += scoreVal;

        if (scoreTextMesh != null) {
            scoreTextMesh.text = "Score: " + currentScore.ToString();
        }

        if (currentScore > highScore) {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }

    public void StartGame() {
        SceneManager.LoadScene("__Scene_0");
    }

    public void ResumeGame() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void PauseGame() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void QuitToMenu() {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
        isPaused = false;
    }
}
