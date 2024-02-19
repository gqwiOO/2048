using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CubeFactory : MonoBehaviour
{
    public static List<GameObject> CubeList = new List<GameObject>();
    [SerializeField] private GameObject LoseLine;
    public static GameObject LoseLineStatic;


    private void Start()
    {
        LoseLineStatic = LoseLine;
    }


    public static void AddCube(GameObject cube)
    {
        CubeList.Add(cube);
    }


    public static void RemoveCube(GameObject cube)
    {
        CubeList.Remove(cube);
    }


    public static bool CheckIfAnyCubeOutOfLine()
    {
        foreach (var cube in CubeList)
        {
            if(cube != null && cube.GetComponent<Transform>().position.z < LoseLineStatic.transform.position.z)
            {
                return true;
            }
        }
        return false;
    }


    public static bool CheckIfAnyCubeIs2048()
    {
        foreach (var cube in CubeList)
        {
            if (cube != null && cube.GetComponent<PointsContainer>().Value == 2048)
            {
                return true;
            }
        }
        return false;
    }
}
