
public interface ICommand
{
    //command execution
    public void Execute();
    public bool IsComplete { get; }
}
