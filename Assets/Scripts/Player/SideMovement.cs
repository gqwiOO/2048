using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SideMovement : MonoBehaviour
{
    [SerializeField] public GameObject LeftBorder;
    [SerializeField] public GameObject RightBorder;
    [SerializeField] public GameObject currentCube;


    private Vector3 previousPosition;
    private Vector3 currentPosition;
    private bool isSwiping;
    private Vector3 diff;


    private void Update()
    {
        if (Input.GetMouseButton(0) && currentCube != null)
        {
            if (isSwiping)
            {
                currentPosition = Input.mousePosition;
                diff = currentPosition - previousPosition;
                if(previousPosition != Vector3.zero)
                {
                    diff = new Vector3(diff.x * Time.deltaTime * 0.5f, 0, 0);
                }
                else
                {
                    diff = Vector3.zero;

                }
                previousPosition = Input.mousePosition;


                if (currentCube.transform.position.x > LeftBorder.GetComponent<Transform>().position.x)
                {
                    currentCube.GetComponent<CubeMovement>().ModifyPosition(diff);
                    return;
                }
                else
                {
                    currentCube.transform.position = LeftBorder.GetComponent<Transform>().position;
                }
                if (currentCube.transform.position.x < RightBorder.GetComponent<Transform>().position.x)
                {
                    currentCube.GetComponent<CubeMovement>().ModifyPosition(diff);
                    return;
                }
                else
                {
                    currentCube.transform.position = RightBorder.GetComponent<Transform>().position;
                }
                return;
            }
            isSwiping = true;

        }
        else
        {
            if (isSwiping)
            {
                isSwiping = false;
                previousPosition = Vector3.zero;
                currentCube.GetComponent<CubeImpulse>().SetImpulse();
                currentCube = null;
                Invoke("AnotherCreateCubeIDKHOWTODOTHISRIGHT", GetComponent<SpawnCube>().spawner.Delay);
            }
        }
    }
    void AnotherCreateCubeIDKHOWTODOTHISRIGHT()
    {
        currentCube = GetComponent<SpawnCube>().Create();
    }


}
