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
        //TODO: have a way to transition from here to GameplayState.
    }

    public override void FixedUpdate()
    {
        
    }
}