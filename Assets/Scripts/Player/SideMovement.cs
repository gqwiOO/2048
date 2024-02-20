using System.Linq;
using UnityEngine;

public class SideMovement : MonoBehaviour
{
    [SerializeField] public GameObject LeftBorder;
    [SerializeField] public GameObject RightBorder;
    [SerializeField][Range(0f, 4f)] private float _xAcceleration = 0.1f;

    [HideInInspector] public GameObject CurrentCube;

    private GameObject CubeForFactory;
    private Vector3 _previousPosition;
    private Vector3 _currentPosition;
    private bool _isSwiping;
    private Vector3 _diff;


    private void Update()
    { 
        if (Input.touches.Length > 0 && CurrentCube != null && GameController.GameState == GameController.State.Playing)
        {
            if (_isSwiping)
            {
                // Getting the vector with which cube is moving

                _currentPosition = Input.touches[0].position;
                _diff = _currentPosition - _previousPosition;
                if (_previousPosition != Vector3.zero)
                {
                    _diff = new Vector3(_diff.x * Time.deltaTime * _xAcceleration, 0, 0);
                }
                else
                {
                    _diff = Vector3.zero;
                }
                _previousPosition = Input.touches[0].position;

                // To move cube when its outside of borders

                if (CurrentCube.transform.position.x <= LeftBorder.GetComponent<Transform>().position.x && _diff.x > 0)
                {
                    CurrentCube.GetComponent<CubeMovement>().ModifyPosition(_diff);
                    return;
                }
                if (CurrentCube.transform.position.x >= RightBorder.GetComponent<Transform>().position.x && _diff.x < 0)
                {
                    CurrentCube.GetComponent<CubeMovement>().ModifyPosition(_diff);
                    return;
                }

                // To move cube when its inside of borders

                if (CurrentCube.transform.position.x > LeftBorder.GetComponent<Transform>().position.x &&
                    CurrentCube.transform.position.x < RightBorder.GetComponent<Transform>().position.x
                    )
                {
                    CurrentCube.GetComponent<CubeMovement>().ModifyPosition(_diff);
                    return;
                }
            }
            _isSwiping = true;
        }
        else if (_isSwiping)
        {
            _isSwiping = false;
            _previousPosition = Vector3.zero;
            CurrentCube.GetComponent<CubeImpulse>().SetImpulse();
            GetComponent<CubeSound>().PlaySound();
            Invoke("CreateCubeForDelay", GetComponent<SpawnCube>().spawner.Delay);
            CubeForFactory = CurrentCube;
            CurrentCube = null;
        }          
    }


    void CreateCubeForDelay()
    {
        CubeFactory.AddCube(CubeForFactory);
        CurrentCube = GetComponent<SpawnCube>().Create();
    }
    


}
