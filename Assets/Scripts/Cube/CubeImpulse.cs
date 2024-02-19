using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeImpulse : MonoBehaviour
{
    [SerializeField] private float _impulse;
    void Start()
    {

    }

    public void SetImpulse()
    {

        GetComponent<Rigidbody>().AddForce(Vector3.forward * _impulse, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
