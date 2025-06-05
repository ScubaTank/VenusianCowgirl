using UnityEngine;

public class PausedState : BaseState
{
        private GameStateManager _context;

    public PausedState(GameStateManager context)
    {
        _context = context;
    }

    public override void Enter()
    {
        Debug.Log("Entering Paused State");
    }

    public override void Exit()
    {
        Debug.Log("Exiting Paused State");
    }

    public override void Update()
    {

    }

    public override void FixedUpdate()
    {
        
    }
}
