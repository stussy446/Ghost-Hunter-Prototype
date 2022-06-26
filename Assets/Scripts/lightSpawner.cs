using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightSpawner : MonoBehaviour
{
    [SerializeField] GameObject lightObject;
    [SerializeField] playerController pController;

  
    void Update()
    {
        TurnOnLight();
    }


    // turns the light object on when the left mouse button is held down
    void TurnOnLight()
    {
        if (pController.ToggleLight())
        {
            lightObject.SetActive(true);
        }
        else
        {
            lightObject.SetActive(false); 
        }
        
    }
}
