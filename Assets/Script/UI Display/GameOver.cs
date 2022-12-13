using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverScreen;
    [SerializeField]
    private Text currentScore;
    [SerializeField]
    private Text finalScore;

    public void SetGameOver()
    {
        gameOverScreen.SetActive(true);
        finalScore.text = "Finale " + currentScore.text;
        currentScore.gameObject.SetActive(false);
        Time.timeScale = 0;
    }

    public void ClickOnRestart()
    {
        SceneManager.LoadScene("4JetLevel");
        Time.timeScale = 1;
    }
}