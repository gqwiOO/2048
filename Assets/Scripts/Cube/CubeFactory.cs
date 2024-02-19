using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CubeFactory : MonoBehaviour
{
    public static List<GameObject> CubeList = new List<GameObject>();
    [SerializeField] private  GameObject LoseLine;

    public  void AddCube(GameObject cube)
    {
        CubeList.Add(cube);
    }

    public void RemoveCube(GameObject cube)
    {
        CubeList.Remove(cube);
    }

    public bool CheckIfAnyCubeOutOfLine()
    {
        foreach (var cube in CubeList)
        {
            if(cube.GetComponent<Transform>().position.z < LoseLine.transform.position.z)
            {
                return true;
            }
        }
        return false;
    }
}
