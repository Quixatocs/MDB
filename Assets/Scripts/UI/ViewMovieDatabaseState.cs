
public class ViewMovieDatabaseState : IGUIState {
    public bool IsComplete { get; private set; }
    public IGUIState NextState { get; private set; }

    private MovieData currentMovieData;

    public ViewMovieDatabaseState(MovieData dataToDisplay) {
        currentMovieData = dataToDisplay;
    }
    
    public void OnEnter(GUIController guiController) {
        guiController.ViewMovieDatabaseDialog.SetActive(true);
        guiController.ViewMovieDatabaseBackButton.onClick.AddListener(OnBackClicked);

        if (currentMovieData == null) return;

        guiController.ViewTitleFieldText.text = currentMovieData.Title;
        guiController.ViewDirectorFieldText.text = currentMovieData.Director.Name;
        guiController.ViewDurationFieldText.text = string.Format("{0} mins", currentMovieData.Duration.ToString());
        guiController.ViewYearFieldText.text = currentMovieData.TitleYear.ToString();
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
