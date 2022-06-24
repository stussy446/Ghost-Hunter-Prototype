using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    [SerializeField] InputAction movement;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float xClamp = 6.3f;
    [SerializeField] float yClamp = 4.5f;

    // stores values when player presses w, a, s, or d
    float xInput;
    float yInput;
    
 
    void OnEnable()
    {
        movement.Enable();
    }


    void OnDisable()
    {
        movement.Disable();
    }


    // Update is called once per frame
    void Update()
    {
        ProcessMovement();

    }


    void ProcessMovement()
    {
        xInput = movement.ReadValue<Vector2>().x;
        yInput = movement.ReadValue<Vector2>().y;

        transform.position = new Vector2(transform.localPosition.x, transform.localPosition.y);

        float xOffset = xInput * Time.deltaTime * movementSpeed;
        float yOffset = yInput * Time.deltaTime * movementSpeed;

        float rawXPos = transform.localPosition.x + xOffset;
        float rawYPos = transform.localPosition.y + yOffset;

        float clampXPos = Mathf.Clamp(rawXPos, -xClamp, xClamp);
        float clampYPos = Mathf.Clamp(rawYPos, -yClamp, yClamp);


        transform.position = new Vector2(rawXPos, rawYPos);
    }

}
