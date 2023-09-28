using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    //References to scripts that take in input
    [SerializeField] PlayerMove playerMove;
    [SerializeField] MouseLook mouseLook;

    //Reference to FPS InputAction Asset
    FPS controls;

    //References to Input Action Maps
    FPS.MovementActions groundMovement;
    FPS.CameraActions cameraLook;

    //Input vector for movement
    Vector2 movementInput;

    //Input floats for camera rotation
    float mouseX;
    float mouseY;

    bool jump;

    private void Awake()
    {
        //Set controls to FPS asset
        controls = new FPS();

        //Set the input action maps accordingly
        groundMovement = controls.Movement;
        cameraLook = controls.Camera;

        //Map movement input vector to vector updated in the action map
        groundMovement.PlayerMove.performed += ctx => movementInput = ctx.ReadValue<Vector2>();

        //Map x and y values of the mouse based on input map
        cameraLook.MouseX.performed += ctx => mouseX = ctx.ReadValue<float>();
        cameraLook.MouseY.performed += ctx => mouseY = ctx.ReadValue<float>();

        //Map Jump input to movement
        groundMovement.Jump.performed += ctx => jump = ctx.ReadValueAsButton();
    }

    private void Update()
    {
        //Send input values to necessary scripts
        playerMove.RecieveInput(movementInput);
        playerMove.RecieveJump(jump);
        mouseLook.RecieveInput(mouseX, mouseY);
    }

    //Enable and disable input asset
    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}

