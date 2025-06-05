using UnityEngine;

public class MenuState : BaseState
{
    private GameStateManager _context;

    public MenuState(GameStateManager context)
    {
        _context = context;
    }

    public override void Enter()
    {
        Debug.Log("Entering Menu State");
    }

    public override void Exit()
    {
        Debug.Log("Exiting Menu State");
    }

    public override void Update()
    {
        //Here, you'd check for input for starting the game. I can't be bothered right now.
        _context.ChangeState(new GameplayState(_context));
    }

    public override void FixedUpdate()
    {
        
    }
}