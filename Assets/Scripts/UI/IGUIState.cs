
public interface IGUIState
{
    /// <summary>
    /// Returns true when the state is complete
    /// </summary>
    bool IsComplete { get; }
    
    /// <summary>
    /// Next state for the state machine to go to once this one is complete
    /// </summary>
    IGUIState NextState { get; }
    
    /// <summary>
    /// Method to be called when entering the state
    /// </summary>
    void OnEnter();
}
