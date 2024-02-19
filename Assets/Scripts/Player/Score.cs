using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static int ScoreValue = 0;

    private void OnGUI()
    {
        GUI.Box(new Rect(100, 100, 100, 100), ScoreValue.ToString());
    }
}
