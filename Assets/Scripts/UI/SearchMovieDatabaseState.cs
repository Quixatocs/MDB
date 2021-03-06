﻿using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class representing the Search state of the Movie Database navigator
/// </summary>
public class SearchMovieDatabaseState : IGUIState {
    
    public bool IsComplete { get; private set; }
    public IGUIState NextState { get; private set; }

    private string currentSearchString;

    private GameObject searchButtonPrefab;
    private Transform searchButtonsHolder;

    private const string NO_SEARCH_FIELD_ENTERED = "No Search Field Entered";
    
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

    /// <summary>
    /// Searches for any partial matches in the input field and displays them as title buttons
    /// </summary>
    private void OnSearchClicked() {

        // Clear any old search
        foreach (GameObject searchButton in searchButtons) {
            GameObject.Destroy(searchButton);
        }
        searchButtons.Clear();
        
        if (string.IsNullOrEmpty(currentSearchString)) {

            GUIController.SendOnUIDisplayableError(NO_SEARCH_FIELD_ENTERED);
            // We don't want to run any of the matching (which could be costly)
            // on an empty string so return here.
            return;
        }
        
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
