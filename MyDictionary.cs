
using UnityEngine;
using System;


[Serializable]
[CreateAssetMenu(
    menuName = "DinosLife/NewDictionary",
    fileName = "NewDictionary",
    order = 1)]
public class MyDictionary : ScriptableObject
{
    public string newGame = "NUEVA PARTIDA";
    public string quit = "SALIR";
    public Texture2D flag;
}
