using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //Player Object Orientation
    [SerializeField] Transform Orientation;

    //X and Y axis sensitivity
    [SerializeField] float xSensitivity;
    [SerializeField] float ySensitivity;

    //Input Vector
    Vector2 input;

    //Amount to rotate x and y axes
    float xRotation;
    float yRotation;

    private void Start()
    {
        //Lock cursor at the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    //Takes input from input manager and maps the values to a vector
    public void RecieveInput(float x, float y)
    {
        //We have to flip the axes, since we want to rotate on the y axis when moving our mouse along the x axis and vice versa
        input.x = y;
        input.y = x;
    }

    private void Update()
    {
        //Cause Behavior based on input
        Look();
    }

    private void Look()
    {
        //Updates and calculates rotation of camera and player orientation
        yRotation += input.y * Time.deltaTime * ySensitivity;

        //Clamps up and down look to 90 degrees;
        xRotation -= input.x * Time.deltaTime * xSensitivity;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Rotates
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        Orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
