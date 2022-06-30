using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSession : MonoBehaviour
{

    [SerializeField] int playerLives = 3;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI exorcismText;
    [SerializeField] TextMeshProUGUI totalscoreText;
    [SerializeField] float secondsToWait = 1f;
    int points = 0;
    [SerializeField] Canvas startScreen;
    [SerializeField] Canvas scoreAndLives;
     

    void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;

        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }


   public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            StartCoroutine(ShowFinalScoreAndDestroy());
            
        }
    }


    public void AddPoints(int pointsToAdd)
    {
        points += pointsToAdd;
        exorcismText.text = "Exorcisms: " + points;
    }


    void TakeLife()
    {
        playerLives--;
        livesText.text = "Lives Remaining: " + playerLives;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }


    void ResetGameSession()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Destroy(gameObject);
    }

    IEnumerator ShowFinalScoreAndDestroy()
    {
        EnableText();
        StopEnemies();
        DisableControls();
        totalscoreText.text = "Your Total Score was: " + points;
        yield return new WaitForSeconds(secondsToWait);
        Destroy(gameObject);
        ResetGameSession();
    }

    void EnableText()
    {
        totalscoreText.enabled = true;
        livesText.enabled = false;
        exorcismText.enabled = false;
    }

    void StopEnemies()
    {
        Damageable[] enemies = FindObjectsOfType<Damageable>();
        foreach (Damageable enemy in enemies)
        {
            Destroy(enemy.gameObject);
        }
    }

    void DisableControls()
    {
        FindObjectOfType<playerController>().enabled = false;
    }
}
