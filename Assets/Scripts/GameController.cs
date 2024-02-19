using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private GameState _gameState = GameState.Playing;

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
            _gameState = GameState.Lose;
        }
        if (CubeFactory.CheckIfAnyCubeIs2048())
        {
            _gameState = GameState.Win;
        }
    }


    private void OnGUI()
    {

        float width = 400;
        float height = 400;
        if (_gameState == GameState.Lose )
        {
            GUI.Label(new Rect(Screen.width / 2 - width / 4, (Screen.height - height) / 2, width, height), "you lose!", _GUIStyle);
        }
        if(_gameState == GameState.Win )
        {
            GUI.Label(new Rect(Screen.width / 2 - width / 4,(Screen.height - height) / 2, width, height), "You Win!", _GUIStyle);
        }
    }

    enum GameState
    {
        Lose,
        Win,
        Playing
    }
}


