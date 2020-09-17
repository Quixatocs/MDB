
public class SearchMovieDatabaseState : IGUIState {
    public bool IsComplete { get; private set; }
    public IGUIState NextState { get; private set; }
    public void OnEnter(GUIController guiController) {
        guiController.SearchMovieDatabaseDialog.SetActive(true);
        guiController.SearchMovieDatabaseButton.onClick.AddListener(OnSearchClicked);
    }
    
    private void OnSearchClicked() {
        
    }
}
