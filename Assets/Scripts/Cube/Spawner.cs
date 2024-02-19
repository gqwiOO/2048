using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] public float Delay;
    [SerializeField] private GameObject _prefab;
        

    public GameObject CreateCube()
    {
        var obj = Instantiate(_prefab, transform.position, new Quaternion());
        obj.GetComponent<CubeMaterials>().SetMaterial(obj.GetComponent<PointsContainer>().SetValueOnStart());
        return obj;
    }
}
