using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [HideInInspector] public static int ScoreValue = 0;
    private GUIStyle _GUIStyle;


    private void Start()
    {
        _GUIStyle = new GUIStyle();
        _GUIStyle.fontSize = 48;

    }
    private void OnGUI()
    {
        GUI.Label(new Rect(100, 100, 200, 200), ScoreValue.ToString(), _GUIStyle);
    }
}
