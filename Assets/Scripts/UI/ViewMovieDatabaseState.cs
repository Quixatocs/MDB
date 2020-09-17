
public class ViewMovieDatabaseState : IGUIState {
    public bool IsComplete { get; private set; }
    public IGUIState NextState { get; private set; }
    
    public void OnEnter(GUIController guiController) {
        guiController.ViewMovieDatabaseDialog.SetActive(true);
        guiController.ViewMovieDatabaseBackButton.onClick.AddListener(OnBackClicked);
    }

    public void OnExit(GUIController guiController) {
        guiController.ViewMovieDatabaseDialog.SetActive(false);
        guiController.ViewMovieDatabaseBackButton.onClick.RemoveAllListeners();
    }
    
    private void OnBackClicked() {
        NextState = new SearchMovieDatabaseState();
        IsComplete = true;
    }
}
