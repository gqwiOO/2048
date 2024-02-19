using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] public float Delay;
    [SerializeField] private GameObject prefab;

        
    public GameObject CreateCube()
    {
        var obj = Instantiate(prefab, transform.position,new Quaternion());
        obj.GetComponent<PointsContainer>().SetValueOnStart();
        return obj;
    }

}
