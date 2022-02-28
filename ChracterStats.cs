using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChracterStats : MonoBehaviour
{
    public Saurius myChar;

    public void AddjustHealth(int health)
    {

    }

    public void AddjustFood (int food)
    {
   //     Debug.Log(myChar.curfood);
        myChar.curfood += food;
  //      Debug.Log(myChar.curfood);

        if (myChar.curfood > myChar.food)
        {
            myChar.curfood = myChar.food;
        }
    }

    public void AddjustWater (int water)
    {
        myChar.curwater += water;
        if (myChar.curwater > myChar.water)
        {
            myChar.curwater = myChar.water;
        }
    }

    public void AddjustRest (int rest)
    {

    }

}
