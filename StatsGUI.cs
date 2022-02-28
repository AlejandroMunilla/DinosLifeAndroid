using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsGUI : MonoBehaviour
{
    //Health, food, water, rest
    [SerializeField]
    private List<Texture2D> pics = new List<Texture2D>();
    private List<Rect> rectList = new List<Rect>();
    private List<Rect> labelRectList = new List<Rect>();
    private int picWidth;
    private int labelWith;
    private Saurius saurius;
    private ChracterStats cs;
    private string level = "1";


    void Start()
    {
        picWidth = (int)(Screen.height * 0.05f);
        labelWith = (int)(Screen.height * 0.08f);
        for (int i = 0; i < pics.Count; i++)
        {
   //        Debug.Log (pics[i].name);
            rectList.Add(new Rect(Screen.width * 0.01f, Screen.height - (5 * picWidth) + (i * picWidth), picWidth, picWidth));
            labelRectList.Add(new Rect(Screen.width * 0.01f + picWidth, Screen.height - (5 * picWidth) + (i * picWidth), labelWith, picWidth));
        }
        cs = GetComponent<GameController>().player.GetComponent<ChracterStats>();
        saurius = cs.myChar;
        Invoke("TimeActions", 20);
    }

    private void OnGUI()
    {
        for (int i = 0; i < pics.Count; i++)
        {
            GUI.DrawTexture(rectList[i], pics[i]);
            
        }
        GUI.Label(labelRectList[0], saurius.curhealth + "/" + saurius.health);
        GUI.Label(labelRectList[1], saurius.curfood + "/" + saurius.food);
        GUI.Label(labelRectList[2], saurius.curwater + "/" + saurius.water);
        GUI.Label(labelRectList[3], saurius.currest + "/" + saurius.rest);
        GUI.Label(labelRectList[4], saurius.exp + "/Level " + level);
    }

    private void TimeActions ()
    {
        cs.AddjustFood(-1);
        cs.AddjustWater(-2);
        Invoke("TimeActions", 5);
    }


    private void CalculateLevel ()
    {
        float rate = saurius.exp / 10000;
        level = rate.ToString("F0");
    }
    
}
