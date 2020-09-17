
public class ViewMovieDatabaseState : IGUIState {
    public bool IsComplete { get; private set; }
    public IGUIState NextState { get; private set; }
    public void OnEnter(GUIController guiController) {
        throw new System.NotImplementedException();
    }

    public void OnExit() {
        throw new System.NotImplementedException();
    }
}
