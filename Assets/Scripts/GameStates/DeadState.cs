using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadState : BaseState
{
    private GameStateManager _context;

    public DeadState(GameStateManager context)
    {
        _context = context;
    }

    public override void Enter()
    {
        Debug.Log("Entering Dead State");

        _context.playerMovement.SetCanMove(false);
        //TODO: Death Animation or something...
    }

    public override void Exit()
    {
        Debug.Log("Exiting Dead State");
        _context.playerMovement.SetCanMove(true);
    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            _context.ChangeState(new GameplayState(_context));
        }
    }

    public override void FixedUpdate()
    {
        
    }
}
