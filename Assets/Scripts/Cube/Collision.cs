using TMPro;
using UnityEngine;


[RequireComponent(typeof(PointsContainer))]
public class Collision : MonoBehaviour
{

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.name == "Cube(Clone)" && collision.gameObject.GetComponent<PointsContainer>().Value ==
            GetComponent<PointsContainer>().Value)
        {
            Score.ScoreValue += collision.gameObject.GetComponent<PointsContainer>().Value / 2;
            
            GetComponent<CubeImpulse>().SetUpImpulse();
            GetComponent<CubeMaterials>().SetMaterial(GetComponent<PointsContainer>().Value * 2);
            GetComponent<PointsContainer>().UpdateValue();

            // Destroy another cube after collision

            Destroy(collision.gameObject);
            CubeFactory.RemoveCube(collision.gameObject);

        }
    }
}
