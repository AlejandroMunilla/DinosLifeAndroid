using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField]
    private Animation anim;
    private ThirdPersonUserControl tpu;
    public LayerMask mask;
    private void Start()
    {
        anim = GetComponent<Animation>();
        tpu = transform.parent.gameObject.GetComponent<ThirdPersonUserControl>();
    }

    void Update()
    {

        float h = tpu.hInput;
        float v = tpu.vInput;


   //     float h = CrossPlatformInputManager.GetAxis("Horizontal");
   //     float v = CrossPlatformInputManager.GetAxis("Vertical");

        if (h != 0 || v != 0)
        {
            if (!anim.IsPlaying ("run"))
            {
                anim.Play("run");
            }
          
        }
        else
        {
            if (!anim.IsPlaying ("idle"))
            {
                anim.Play("idle");
            }
           
        }

        /*
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit))
        {
         //   Debug.Log(hit.transform.gameObject.name);
            var slopeRotation = Quaternion.FromToRotation(transform.up, hit.normal);
            transform.rotation = Quaternion.Slerp(transform.rotation, slopeRotation * transform.rotation, 10 * Time.deltaTime);
        }*/



    }
}
