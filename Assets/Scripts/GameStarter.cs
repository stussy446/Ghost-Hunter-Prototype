using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour
{
    [SerializeField] InputAction gameStarter;

    void OnEnable()
    {
        gameStarter.Enable();
    }

    void OnDisable()
    {
        gameStarter.Disable();
    }

    void Update()
    {
        StartGame();
    }


    void StartGame()
    {
        if (gameStarter.WasPressedThisFrame())
        {
            SceneManager.LoadScene(1);
           
        }
    }
}

