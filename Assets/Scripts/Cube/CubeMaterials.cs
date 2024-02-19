using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CubeMaterials : MonoBehaviour
{
    [SerializeField]public List<MaterialSettings> material;


    public void SetMaterial(int value)
    {
        GetComponent<MeshRenderer>().material = material.Where(material => material.Points == value).First().Material;
    }

    [System.Serializable]
    public class MaterialSettings
    {
        public int Points;
        public Material Material;
    }
}
