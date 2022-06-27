using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class ReloadScene : MonoBehaviour
{

    [SerializeField] InputAction quit;
    [SerializeField] InputAction reload;

    private void OnEnable()
    {
        quit.Enable();
        reload.Enable();
    }

    private void OnDisable()
    {
        quit.Disable();
        reload.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        QuitGame();
        ReloadGame();
    }


    void QuitGame()
    {
        if (quit.IsPressed())
        {
            Application.Quit();
        }
    }

    void ReloadGame()
    {
        if (reload.IsPressed())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
