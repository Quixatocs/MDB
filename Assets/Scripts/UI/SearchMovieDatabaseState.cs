
public class SearchMovieDatabaseState : IGUIState {
    public bool IsComplete { get; private set; }
    public IGUIState NextState { get; private set; }
    public void OnEnter(GUIController guiController) {
        guiController.SearchMovieDatabaseDialog.SetActive(true);
        guiController.SearchMovieDatabaseButton.onClick.AddListener(OnSearchClicked);
    }

    public void OnExit() {
        throw new System.NotImplementedException();
    }

    private void OnSearchClicked() {
        
    }
}
