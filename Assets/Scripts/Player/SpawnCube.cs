using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCube : MonoBehaviour
{
    [SerializeField] public Spawner spawner;

    void Start()
    {
        GetComponent<SideMovement>().CurrentCube = Create();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject Create()
    {
        return spawner.CreateCube();
    }
}
