
public class OpenMovieDatabaseState : IGUIState {
    public bool IsComplete { get; private set; }
    public IGUIState NextState { get; private set; }
    public void OnEnter(GUIController guiController) {
        guiController.OpenMovieDatabaseDialog.SetActive(true);
        guiController.OpenMovieDatabaseButton.onClick.AddListener(OnOpenDatabaseClicked);
    }

    public void OnExit() {
        throw new System.NotImplementedException();
    }

    private void OnOpenDatabaseClicked() {
        NextState = new SearchMovieDatabaseState();
        IsComplete = true;
    }
}
