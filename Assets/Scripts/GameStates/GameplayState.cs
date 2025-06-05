using Unity.VisualScripting;
using UnityEngine;

public class GameplayState : BaseState
{
        private GameStateManager _context;

    public GameplayState(GameStateManager context)
    {
        _context = context;
    }

    public override void Enter()
    {
        Debug.Log("Entering Gameplay State");
        //IF IN GAMEPLAY STATE, LOCK AND HIDE MOUSE
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public override void Exit()
    {
        Debug.Log("Exiting Gameplay State");
        //reveal cursor and unlock it 
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public override void Update()
    {

    }

    public override void FixedUpdate()
    {
        
    }
}
