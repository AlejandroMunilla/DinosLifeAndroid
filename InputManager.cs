using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputManager : MonoBehaviour
{

    public GameObject player;
    private ThirdPersonCharacter tpc;
    private ThirdPersonUserControl tpu;
    private MouseOrbit mouseOrbit;

    private void Start()
    {
        mouseOrbit = Camera.main.GetComponent<MouseOrbit>();
        tpc = player.GetComponent<ThirdPersonCharacter>();
        tpu = player.GetComponent<ThirdPersonUserControl>();
    }

    void OnEnable()
    {
       
      //  TouchSimulation.Enable();
    }

    void FixedUpdate()
    {
        var keyboard = Keyboard.current;
        var allGamePads = Gamepad.all;

        var gamepad = Gamepad.current;
        if (gamepad == null)
            return; // No gamepad connected.

        if (gamepad.rightTrigger.wasPressedThisFrame)
        {
            // 'Use' code here
        }

        //Get the value of the left stick... and pass it to the player 
        Vector2 move = gamepad.leftStick.ReadValue();
        tpu.Move(move.x, move.y);

      
  


        // 'Move' code here

        if (keyboard.sKey.isPressed)
        {
            Debug.Log("S pressed");
        }


        /*
        for (int cnt =0; cnt < allGamePads.Count; cnt++)
        {
            Debug.Log(allGamePads[cnt]);
        }*/
    }



    private void Update()
    {
        var gamepad = Gamepad.current;
        Vector2 cameraControl = gamepad.rightStick.ReadValue();
        mouseOrbit.CameraControl(cameraControl.x, cameraControl.y);

        if ((Input.touchCount > 0))  //&& (Input.GetTouch(0).phase == TouchPhase.Began))
        {

            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;
            if (Physics.Raycast(raycast, out raycastHit))
            {
                Debug.Log("Something Hit");
                if (raycastHit.collider.gameObject.GetComponent<Touchable>())
                {
                    Debug.Log("Soccer Ball clicked");
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("S pressed");
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 100.0f))
                {
                    Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
                }
            }
        }

        InputSystem.onDeviceChange +=
        (device, change) =>
        {
            switch (change)
            {
                case InputDeviceChange.Added:
                    // New Device.
                    break;
                case InputDeviceChange.Disconnected:
                    // Device got unplugged.
                    break;
                case InputDeviceChange.Reconnected:
                    // Plugged back in.
                    break;
                case InputDeviceChange.Removed:
                    // Remove from Input System entirely; by default, Devices stay in the system once discovered.
                    break;
                default:
                    // See InputDeviceChange reference for other event types.
                    break;
            }
        };
    }
}
