using TMPro;
using UnityEngine;

public class Collision : MonoBehaviour
{

    [SerializeField] public float UpImpulse;


    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.name == "Cube(Clone)" && collision.gameObject.GetComponent<PointsContainer>().Value ==
            GetComponent<PointsContainer>().Value)
        {
            Debug.Log("Collide!");

            Score.ScoreValue += collision.gameObject.GetComponent<PointsContainer>().Value / 2;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * UpImpulse, ForceMode.Impulse);

            GetComponent<Rigidbody>().AddForce(Vector3.up * UpImpulse, ForceMode.Impulse);
            GetComponent<PointsContainer>().UpdateValue(); 

            Destroy(collision.gameObject);
        }
    }
    void CheckIfWin(int value)
    {
        // TODO: Check if win with 2048 cube Value
    }
}
