
public class SearchMovieDatabaseState : IGUIState {
    public bool IsComplete { get; private set; }
    public IGUIState NextState { get; private set; }
    
    public void OnEnter(GUIController guiController) {
        guiController.SearchMovieDatabaseDialog.SetActive(true);
        guiController.SearchMovieDatabaseButton.onClick.AddListener(OnSearchClicked);
        guiController.SearchMovieDatabaseBackButton.onClick.AddListener(OnBackClicked);
    }

    public void OnExit(GUIController guiController) {
        guiController.SearchMovieDatabaseDialog.SetActive(false);
        guiController.SearchMovieDatabaseButton.onClick.RemoveAllListeners();
        guiController.SearchMovieDatabaseBackButton.onClick.RemoveAllListeners();
    }

    private void OnSearchClicked() {
        NextState = new ViewMovieDatabaseState();
        IsComplete = true;
    }
    
    private void OnBackClicked() {
        NextState = new OpenMovieDatabaseState();
        IsComplete = true;
    }
}
