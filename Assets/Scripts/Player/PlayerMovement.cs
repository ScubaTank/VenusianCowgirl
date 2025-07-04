using Unity.VisualScripting.InputSystem;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _charController;


    [Header("Movement Attributes")]
    [SerializeField] private float m_gravity = -10f;
    [SerializeField] private float m_playerSpeed = 10f;
    [SerializeField] private float m_momentumDamping = 5f;
    private Vector3 _inputVector; //The unprocessed vector that the player is generating
    private Vector3 _outputVector; //the processed, final vector that should be applied to the player;

    [Header("Mouse Attributes")]
    [SerializeField] private float m_sensitivity = 1.5f;
    [SerializeField] private float m_smoothing = 10f;
    private float _xMousePos;
    private float _smoothedMousePos;
    private float _currLookingPos;

    [Header("Camera Animator")]
    [SerializeField] private Animator m_camera;
    private bool _isMoving;

    private bool _canMove = true;

    void Start()
    {
        _charController = GetComponent<CharacterController>();
    }

    void Update()
    {
        GetInput();
        if (_canMove)
        {
            MovePlayer();
        }

        m_camera.SetBool("isMoving", _isMoving);
    }

    private void GetInput()
    {
        //grab raw mouse, apply sensitivity and smoothing, then set _smoothedMousePos to a lerp between the current and next position. 
        _xMousePos = Input.GetAxisRaw("Mouse X");
        _xMousePos *= m_sensitivity * m_smoothing;
        _smoothedMousePos = Mathf.Lerp(_smoothedMousePos, _xMousePos, 1f / m_smoothing);

        //TODO: CLEAN THIS SHIT UP
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            //grab raw inputvector, normalize so diagonals arent big, set direction to this gameobject's rotation, apply speed and gravity and set to _outputVector.
            _inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            _inputVector.Normalize();
            _inputVector = transform.TransformDirection(_inputVector);
            _isMoving = true;
        }
        else
        {
            //if not moving
            _inputVector = Vector3.Lerp(_inputVector, Vector3.zero, m_momentumDamping * Time.deltaTime);
            _isMoving = false;
        }
        _outputVector = (_inputVector * m_playerSpeed) + (Vector3.up * m_gravity);
    }

    private void MovePlayer()
    {
        //move the current looking position to the _smoothedMousePos
        _currLookingPos += _smoothedMousePos;
        //rotate gameobject to _currLookingPos
        transform.localRotation = Quaternion.AngleAxis(_currLookingPos, transform.up);

        _charController.Move(_outputVector * Time.deltaTime);

    }



    public void SetCanMove(bool canMove)
    {
        _canMove = canMove;
    }
}
