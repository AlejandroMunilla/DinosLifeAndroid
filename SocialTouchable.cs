using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocialTouchable : Touchable
{

    public override void Touched()
    {
        base.Touched();
    //    Debug.Log("Touched");
        transform.Find("Canvas").gameObject.SetActive(true);
        transform.Find("Canvas").gameObject.GetComponent<GUISocial>().enabled = true;
        transform.Find("Canvas/Position").position = new Vector3 (transform.position.x, transform.position.y + 1.5f, transform.position.z);

    }

}
