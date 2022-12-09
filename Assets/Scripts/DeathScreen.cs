using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    [SerializeField] GameObject OldScoreObj;

    public static class HighScore
    {
        public static int score;
    }

    [SerializeField] GameObject newHighScore;
    [SerializeField] TMP_Text finalScore;
    [SerializeField] TMP_Text highScore;

    int currentScore=0;

    void Awake()
    {
        Time.timeScale = 0;
        highScore.text = "";
        currentScore = (int)(CameraScript.Instance.maxY + 3f);
        Destroy(OldScoreObj);

        finalScore.text = "Score: "+ currentScore;

        if (HighScore.score != 0)
        {
            highScore.text = "High Score: " + HighScore.score;
        }

        if (HighScore.score < currentScore)
        {
            newHighScore.SetActive(true);
            HighScore.score = currentScore;
        }

    }

    public void RestartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
}
