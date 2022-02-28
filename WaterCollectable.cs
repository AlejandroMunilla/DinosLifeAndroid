using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCollectable :  MonoBehaviour, Collectable
{
    public int Value { get; set; }
    public int value = 5;

    public void OnEnable()
    {
        Value = value;

    }

    public void Collect ()
    {
      
        
    }

    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name + "/" + other.gameObject.tag);
        if ( other.transform.root.gameObject.tag == "Player")
        {
            other.transform.root.gameObject.GetComponent<ChracterStats>().AddjustWater(value);
  
        }
    }

    private void OnTriggerStay (Collider other)
    {
        Debug.Log(other.gameObject.name + "/" + other.transform.root.gameObject.tag);
        if (other.transform.root.gameObject.tag == "Player")
        {
            other.transform.root.gameObject.GetComponent<ChracterStats>().AddjustWater(value);

        }
    }
}
