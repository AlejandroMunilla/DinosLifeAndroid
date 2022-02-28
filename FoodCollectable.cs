using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCollectable :  MonoBehaviour, Collectable
{
    public int Value { get; set; }
    public int value = 5;

    public void OnEnable()
    {
        Value = value;

    }

    public void Collect ()
    {
      
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name + "/" + other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<ChracterStats>().AddjustFood(value);
            Collect();
        }
    }
}
