using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class ReloadScene : MonoBehaviour
{

    [SerializeField] InputAction quit;

    private void OnEnable()
    {
        quit.Enable();
    }

    private void OnDisable()
    {
        quit.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if (quit.IsPressed())
        {
            Application.Quit();
        }
    }
}
