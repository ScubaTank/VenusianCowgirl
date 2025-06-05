using UnityEngine;
using UnityEngine.SceneManagement;


//Keeps track of the current state of the game. A persistent singleton created from launch.
public class GameStateManager : Singleton<GameStateManager>
{
    private BaseState _currentState;
    private BaseState _previousState;

    public string CurrentStateName => _currentState?.GetType().Name;

    private void Start()
    {
        //Check if we are in the samplescene. otherwise, assume normal gameplay.
        //TODO: replace this with a proper debug mode.
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            ChangeState(new GameplayState(this));
        }
        else
        {
            ChangeState(new MenuState(this));
        }
        
    }

    private void Update()
    {
        _currentState?.Update();
    }

    private void FixedUpdate()
    {
        _currentState?.FixedUpdate();
    }

    public void ChangeState(BaseState newState)
    {
        _currentState?.Exit();
        _previousState = _currentState;
        _currentState = newState;
        _currentState?.Enter();
    }

    public void RevertToPreviousState()
    {
        if (_previousState != null)
        {
            ChangeState(_previousState);
        }
        else
        {
            Debug.LogWarning("No previous state available to revert to!");
        }
    }
}
