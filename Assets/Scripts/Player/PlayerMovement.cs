using Unity.VisualScripting.InputSystem;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _charController;
    private Vector3 _inputVector; //The unprocessed vector that the player is generating
    private Vector3 _outputVector; //the processed, final vector that should be applied to the player;

    [Header("Movement Attributes")]
    [SerializeField] private float m_gravity = -10f;
    [SerializeField] private float m_playerSpeed = 20f;

    [Header("Mouse Attributes")]
    [SerializeField] private float m_sensitivity = 1.5f;
    [SerializeField] private float m_smoothing = 10f;

    private float _xMousePos;
    private float _smoothedMousePos; 
    private float _currLookingPos;


    void Start()
    {
        _charController = GetComponent<CharacterController>();
    }

    void Update()
    {
        GetInput();
        MovePlayer();
    }

    void GetInput()
    {
        //grab raw mouse, apply sensitivity and smoothing, then set _smoothedMousePos to a lerp between the current and next position. 
        _xMousePos = Input.GetAxisRaw("Mouse X");
        _xMousePos *= m_sensitivity * m_smoothing;
        _smoothedMousePos = Mathf.Lerp(_smoothedMousePos, _xMousePos, 1f / m_smoothing);

        //grab raw inputvector, normalize so diagonals arent big, set direction to this gameobject's rotation, apply speed and gravity and set to _outputVector.
        _inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        _inputVector.Normalize();
        _inputVector = transform.TransformDirection(_inputVector);
        _outputVector = (_inputVector * m_playerSpeed) + (Vector3.up * m_gravity);
    }

    void MovePlayer()
    {
        //move the current looking position to the _smoothedMousePos
        _currLookingPos += _smoothedMousePos;
        //rotate gameobject to _currLookingPos
        transform.localRotation = Quaternion.AngleAxis(_currLookingPos, transform.up);

        _charController.Move(_outputVector * Time.deltaTime);
    }
}
