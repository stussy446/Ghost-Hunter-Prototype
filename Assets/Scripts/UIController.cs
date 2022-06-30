using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI exorcismText;
    [SerializeField] TextMeshProUGUI livesText;

    int score = 0;
    

    void Awake()
    {
        int numGameSessions = FindObjectsOfType<UIController>().Length;

        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void AddExorcism(int scoreToAdd)
    {
        score += scoreToAdd;
        exorcismText.text = "Exorcisms: " + score;
    }

    public void SubtractLife(int lives)
    {
        
        livesText.text = "Lives Remaining: " + lives;
    }
}
