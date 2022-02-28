using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUISocial : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    private void Start()
    {

        player = GameObject.FindGameObjectWithTag("GameController").GetComponent<MobileInput>().player;
        this.enabled = false;
    }


    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform);
    }

    public void TurnOff()
    {
        gameObject.SetActive(false);
   
    }

    public void Follow ()
    {
        Debug.Log(player);
        transform.parent.gameObject.GetComponent<AISaurius>().target = player;
    }

    public void Stay()
    {
        Debug.Log(player);
        transform.parent.gameObject.GetComponent<AISaurius>().target = null;
        transform.parent.gameObject.GetComponent<AISaurius>().state = AIBase.State.Idle;


    }
}
