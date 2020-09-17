
public class SearchMovieDatabaseState : IGUIState {
    public bool IsComplete { get; private set; }
    public IGUIState NextState { get; private set; }
    public void OnEnter(GUIController guiController) {
        guiController.SearchMovieDatabaseDialog.SetActive(true);
        guiController.SearchMovieDatabaseButton.onClick.AddListener(OnSearchClicked);
    }

    public void OnExit(GUIController guiController) {
        guiController.SearchMovieDatabaseDialog.SetActive(false);
        guiController.SearchMovieDatabaseButton.onClick.RemoveAllListeners();
    }

    private void OnSearchClicked() {
        
    }
}
