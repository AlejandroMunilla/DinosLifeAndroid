using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Texture2D background;
    [SerializeField]
    private Texture2D logo;


    [SerializeField]
    private List<MyDictionary> dictionaries = new List<MyDictionary>();
    private List<Rect> dictionariesRect = new List<Rect>();

    [SerializeField]
    private string targetScene = "DemoScene";
    public GUIStyle myStyle;
    public GUIStyle styleButton;
    public GUISkin mySkin;
    private string newGame = "NUEVA PARTIDA";
    private string quit = "SALIR";
    private int buttonHeight;
    private int buttonWidth;
    private Rect newGameRect;
    private Rect quitRect;

    void Start()
    {

        mySkin = new GUISkin();
        myStyle = mySkin.GetStyle("label");
        myStyle.fontSize = (int)(Screen.height * 0.045f);
        myStyle.normal.textColor = Color.white;
        myStyle.alignment = TextAnchor.MiddleCenter;

        styleButton = mySkin.GetStyle("button");
        styleButton.fontSize = (int)(Screen.height * 0.022f);
        styleButton.normal.textColor = Color.white;
        styleButton.alignment = TextAnchor.MiddleCenter;


        buttonWidth = (int)(Screen.width * 0.06f);
        buttonHeight = buttonWidth;
        buttonHeight = (int)(Screen.height * 0.04f);

        if (dictionaries != null)
        {
            if (dictionaries.Count > 0)
            {
                for (int i = 0; i < dictionaries.Count; i++)
                {
                    int xValue = (int)(Screen.width * 0.02f + (i * buttonWidth));
                    dictionariesRect.Add(new Rect(xValue, Screen.height * 0.19f, buttonWidth, buttonHeight));
                }
            }
        }
        newGameRect = new Rect(Screen.width * 0.3f, Screen.height * 0.55f, Screen.width * 0.2f, Screen.height * 0.08f);
        quitRect = new Rect(Screen.width * 0.3f, Screen.height * 0.63f, Screen.width * 0.2f, Screen.height * 0.08f);

    }

    private void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), background);
        GUI.DrawTexture(new Rect(Screen.width * 0.1f, Screen.height * 0.02f, Screen.width * 0.8f, Screen.width * 0.13f), logo);

        if (GUI.Button(newGameRect, newGame, styleButton))
        {
            SceneManager.LoadScene(targetScene);
        }

        if (GUI.Button(quitRect, quit, styleButton))
        {
            Application.Quit();
        }


        Flags();
    }

    private void Flags()
    {

        for (int i = 0; i < dictionariesRect.Count; i++)
        {
            if (GUI.Button(dictionariesRect[i], new GUIContent(dictionaries[i].flag, dictionaries[i].name), myStyle))
            {
                ChangeLanguage(dictionaries[i]);
            }
        }
    }

    private void ChangeLanguage(MyDictionary lan)
    {
        newGame = lan.newGame;
        quit = lan.quit;
        Debug.Log(lan);
    }
}

