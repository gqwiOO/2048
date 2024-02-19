using UnityEngine;

public class SideMovement : MonoBehaviour
{
    [SerializeField] public GameObject LeftBorder;
    [SerializeField] public GameObject RightBorder;
    [HideInInspector] public GameObject CurrentCube;

    private GameObject CubeForFactory;
    private Vector3 _previousPosition;
    private Vector3 _currentPosition;
    private bool _isSwiping;
    private Vector3 _diff;


    private void Update()
    {
        if (Input.GetMouseButton(0) && CurrentCube != null)
        {
            if (_isSwiping)
            {
                _currentPosition = Input.mousePosition;
                _diff = _currentPosition - _previousPosition;
                if(_previousPosition != Vector3.zero)
                {
                    _diff = new Vector3(_diff.x * Time.deltaTime * 0.5f, 0, 0);
                }
                else
                {
                    _diff = Vector3.zero;

                }
                _previousPosition = Input.mousePosition;


                // To move cube when its outside of borders

                if(CurrentCube.transform.position.x <= LeftBorder.GetComponent<Transform>().position.x && _diff.x > 0)
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
        else
        {
            if (_isSwiping)
            {
                _isSwiping = false;
                _previousPosition = Vector3.zero;
                CurrentCube.GetComponent<CubeImpulse>().SetImpulse();
                GetComponent<CubeSound>().PlaySound();
                Invoke("AnotherCreateCubeIDKHOWTODOTHISRIGHT", GetComponent<SpawnCube>().spawner.Delay);
                CubeForFactory = CurrentCube;
                CurrentCube = null;

            }
        }
    }
    void AnotherCreateCubeIDKHOWTODOTHISRIGHT()
    {
        CubeFactory.AddCube(CubeForFactory);
        CurrentCube = GetComponent<SpawnCube>().Create();
    }


}
