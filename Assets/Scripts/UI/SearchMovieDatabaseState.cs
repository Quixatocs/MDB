
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchMovieDatabaseState : IGUIState {
    public bool IsComplete { get; private set; }
    public IGUIState NextState { get; private set; }

    private string currentSearchString;

    private GameObject searchButtonPrefab;
    private Transform searchButtonsHolder;
    
    private readonly List<GameObject> searchButtons = new List<GameObject>();

    public void OnEnter(GUIController guiController) {
        guiController.SearchMovieDatabaseDialog.SetActive(true);
        searchButtonPrefab = guiController.SearchMatchedTitlePrefab;
        searchButtonsHolder = guiController.SearchMatchedTitlesHolder;
        guiController.SearchMovieDatabaseInputField.onValueChanged.AddListener(UpdateCurrentSearchString);
        guiController.SearchMovieDatabaseButton.onClick.AddListener(OnSearchClicked);
        guiController.SearchMovieDatabaseBackButton.onClick.AddListener(OnBackClicked);

        if (!string.IsNullOrEmpty(guiController.SearchMovieDatabaseInputField.text)) {
            currentSearchString = guiController.SearchMovieDatabaseInputField.text;
            OnSearchClicked();
        }
    }

    public void OnExit(GUIController guiController) {
        guiController.SearchMovieDatabaseDialog.SetActive(false);
        guiController.SearchMovieDatabaseInputField.onValueChanged.RemoveAllListeners();
        guiController.SearchMovieDatabaseButton.onClick.RemoveAllListeners();
        guiController.SearchMovieDatabaseBackButton.onClick.RemoveAllListeners();

        foreach (GameObject searchButton in searchButtons) {
            GameObject.Destroy(searchButton);
        }
        searchButtons.Clear();
    }

    private void UpdateCurrentSearchString(string newSearchString) {
        currentSearchString = newSearchString;
    }

    private void OnSearchClicked() {

        HashSet<string> uniqueMovieTitles = MovieRuntimeData.GetUniqueMatchingTitles(currentSearchString);

        foreach (string title in uniqueMovieTitles) {
            GameObject newUIButton = GameObject.Instantiate(searchButtonPrefab, searchButtonsHolder);
            newUIButton.SetActive(true);
            searchButtons.Add(newUIButton);
            SearchButton searchButton = newUIButton.GetComponent<SearchButton>();
            searchButton.titleText.text = title;
            searchButton.viewDataButton.onClick.AddListener(() => {
                MovieData movieDataToDisplay = MovieRuntimeData.GetMovieDataFromTitle(title);
                NextState = new ViewMovieDatabaseState(movieDataToDisplay);
                IsComplete = true;
            });
        }
    }
    
    private void OnBackClicked() {
        NextState = new OpenMovieDatabaseState();
        IsComplete = true;
    }
}
