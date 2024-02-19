using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeImpulse : MonoBehaviour
{
    [SerializeField] private float _ForwardImpulse;
    [SerializeField] private float _UpImpulse;

    public void SetImpulse()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.forward * _ForwardImpulse, ForceMode.Impulse);
    }


    public void SetUpImpulse()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * _UpImpulse, ForceMode.Impulse);
    }
}
