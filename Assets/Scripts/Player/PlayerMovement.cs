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
    void Start()
    {
        _charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        MovePlayer();
    }

    void GetInput()
    {
        _inputVector = 
    }
}
