using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static State GameState = State.Playing;

    private GUIStyle _GUIStyle;


    private void Start()
    {
        _GUIStyle = new GUIStyle();
        _GUIStyle.fontSize = 48;
    }


    private void Update()
    {
        if (CubeFactory.CheckIfAnyCubeOutOfLine())
        {
            GameState = State.Lose;
        }
        if (CubeFactory.CheckIfAnyCubeIs2048())
        {
            GameState = State.Win;
        }
    }


    private void OnGUI()
    {

        float width = 400;
        float height = 400;
        if (GameState == State.Lose )
        {
            GUI.Label(new Rect(Screen.width / 2 - width / 4, (Screen.height - height) / 2, width, height), "you lose!", _GUIStyle);
        }
        if(GameState == State.Win )
        {
            GUI.Label(new Rect(Screen.width / 2 - width / 4,(Screen.height - height) / 2, width, height), "You Win!", _GUIStyle);
        }
    }

    public enum State
    {
        Lose,
        Win,
        Playing
    }
}


