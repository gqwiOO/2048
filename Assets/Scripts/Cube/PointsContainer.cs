using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PointsContainer : MonoBehaviour
{
    [SerializeField] public List<TextMeshProUGUI> Fields;
    public int Value;

    public int SetValueOnStart()
    {
        if(Random.Range(0f,1.0f) <= .75f)
        {
            Value = 2;
            foreach(var field in Fields)
            {
                field.text = $"{Value}";
            }
        }
        else
        {
            Value = 4;
            foreach (var field in Fields)
            {
                field.text = $"{Value}";
            }
        }
        return Value;
    }


    public void UpdateValue()
    {
        Value *= 2;
        foreach (var field in Fields)
        {
            field.text = $"{Value}";
        }
    }
}
