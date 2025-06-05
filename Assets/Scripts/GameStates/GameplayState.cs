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
    }

    public override void Exit()
    {
        Debug.Log("Exiting Gameplay State");
    }

    public override void Update()
    {

    }

    public override void FixedUpdate()
    {
        
    }
}
