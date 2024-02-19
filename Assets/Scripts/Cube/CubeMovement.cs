using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public void ModifyPosition(Vector3 position)
    {
        transform.position += position;
    }
}
