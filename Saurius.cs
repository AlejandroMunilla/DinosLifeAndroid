using UnityEngine;
using System;


[Serializable]
[CreateAssetMenu(
    menuName = "DinosLife/CharacterTemplate",
    fileName = "Character",
    order = 1)]
public class Saurius : CharacterTemplate
{
    public string race;
    public string age = "Mature";
    public int health = 300;
    public int food = 300;
    public int water = 300;
    public int armour = 3;
    public int rest = 100;
    public int exp = 10000;
    public float speed = 1;
    public int curhealth = 300;
    public int curfood = 300;
    public int curwater = 300;
    public int curarmour = 3;
    public int currest = 100;
    public int curSpeed = 1;
    public GameObject model;
}
