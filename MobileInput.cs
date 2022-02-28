using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

public class MobileInput : MonoBehaviour
{

    public GameObject player;
    private ThirdPersonCharacter tpc;
    private ThirdPersonUserControl tpu;
    private MouseOrbit mouseOrbit;
    public Saurius saurius;
    private Keyboard keyboard;
    private Mouse mouse;
    // Start is called before the first frame update
    void Start()
    {
        mouseOrbit = Camera.main.GetComponent<MouseOrbit>();
        tpc = player.GetComponent<ThirdPersonCharacter>();
        tpu = player.GetComponent<ThirdPersonUserControl>();
        mouse = Mouse.current;
        EnhancedTouchSupport.Enable();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

    }


    
    private void Update()
    {

        tpu.Move(JoystickLeft.positionX, JoystickLeft.positionY);
        mouseOrbit.CameraControl(JoystickRight.positionX, JoystickRight.positionY);


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


        }

        if (mouse.leftButton.isPressed)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
     //           Debug.Log(hit.transform.gameObject.name);
                if (hit.transform.gameObject.GetComponent<SocialTouchable>() != null)
                {
                    if (Vector3.Distance (hit.transform.position, player.transform.position) <= 6)
                    {
             //           Debug.Log(hit.transform.gameObject.name);
                        hit.transform.gameObject.GetComponent<SocialTouchable>().Touched();
                    }
                }
             
            }
        }
    }
}
