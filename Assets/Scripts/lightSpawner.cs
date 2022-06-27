using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class lightSpawner : MonoBehaviour
{
    [SerializeField] InputAction flashlight;
    SpriteRenderer spriteRenderer;
    CapsuleCollider2D capsuleColl2D;


    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        capsuleColl2D = gameObject.GetComponent<CapsuleCollider2D>();


    }

    void OnEnable()
    {
        flashlight.Enable();
    }

    private void OnDisable()
    {
        flashlight.Disable();
    }

    void Update()
    {
        TurnOnLight();
    }


    // turns the light object on when the left mouse button is held down
    void TurnOnLight()
    {
        if (flashlight.IsPressed())
        {
            spriteRenderer.enabled = true;
            capsuleColl2D.enabled = true;
        }
        else
        {
            spriteRenderer.enabled = false;
            capsuleColl2D.enabled = false;
        }
        
    }
}
