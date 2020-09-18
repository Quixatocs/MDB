
/// <summary>
/// Class representing the Open state of the Movie Database navigator
/// This state would likely be used as the entry point to the Movie Database Navigator from
/// an already running 3D game
/// </summary>
public class OpenMovieDatabaseState : IGUIState {
    public bool IsComplete { get; private set; }
    public IGUIState NextState { get; private set; }
    
    public void OnEnter(GUIController guiController) {
        guiController.OpenMovieDatabaseDialog.SetActive(true);
        guiController.OpenMovieDatabaseButton.onClick.AddListener(OnOpenDatabaseClicked);
    }

    public void OnExit(GUIController guiController) {
        guiController.OpenMovieDatabaseDialog.SetActive(false);
        guiController.OpenMovieDatabaseButton.onClick.RemoveAllListeners();
    }

    private void OnOpenDatabaseClicked() {
        NextState = new SearchMovieDatabaseState();
        IsComplete = true;
    }
}
