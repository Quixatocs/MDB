
public class OpenMovieDatabaseState : IGUIState {
    public bool IsComplete { get; private set; }
    public IGUIState NextState { get; private set; }
    public void OnEnter(GUIController guiController) {
        throw new System.NotImplementedException();
    }
}
