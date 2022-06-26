using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class playerController : MonoBehaviour
{
    [SerializeField] InputAction movement;
    [SerializeField] InputAction lightControl;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float rotationSpeed = 5f;
    bool isLightOn = false;


    // stores values when player presses w, a, s, or d
    Vector2 movementDirection;
    float horizontalInput;
    float verticalInput;
    
 
    void OnEnable()
    {
        movement.Enable();
        lightControl.Enable();
    }


    void OnDisable()
    {
        movement.Disable();
        lightControl.Disable();
    }


    // Update is called once per frame
    void Update()
    {
        ProcessMovement();
        ProcessRotation();
        ToggleLight();
    }

    
    // moves the player on the x and y axes based on player input 
    void ProcessMovement()
    {
        horizontalInput = movement.ReadValue<Vector2>().x;
        verticalInput = movement.ReadValue<Vector2>().y;

        movementDirection = new Vector2(horizontalInput, verticalInput);
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);
        movementDirection.Normalize();

        transform.Translate(movementDirection * movementSpeed * inputMagnitude * Time.deltaTime, Space.World);
    }


    // rotates the player on the z axis based on player input 
    void ProcessRotation()
    {
        if (movementDirection != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, -movementDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

    }


    // sets the isLightOn bool to true or false on left mouse press, used in
    // lightSpawner to turn light object on and off 
    public bool ToggleLight()
    {
        if(lightControl.IsPressed())
        {
            isLightOn = !isLightOn;
            
        }
        
        return isLightOn;
    }

}
