
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ViewMovieDatabaseState : IGUIState {
    public bool IsComplete { get; private set; }
    public IGUIState NextState { get; private set; }

    private readonly MovieData currentMovieData;

    public ViewMovieDatabaseState(MovieData dataToDisplay) {
        currentMovieData = dataToDisplay;
    }
    
    public void OnEnter(GUIController guiController) {
        guiController.ViewMovieDatabaseDialog.SetActive(true);
        guiController.ViewMovieDatabaseBackButton.onClick.AddListener(OnBackClicked);

        if (currentMovieData == null) return;

        //Use this key with an API plan to return a poster image URL to load
        string imdbTitleId = currentMovieData.ImdbUrl.Substring(26, 9);
        
        guiController.LoadRemoteImage("https://avatars0.githubusercontent.com/u/1129059");
        
        guiController.ViewTitleFieldText.text = currentMovieData.Title;
        guiController.ViewDirectorFieldText.text = currentMovieData.Director.Name;
        guiController.ViewDurationFieldText.text = $"{currentMovieData.Duration.ToString()} mins";
        guiController.ViewYearFieldText.text = currentMovieData.TitleYear.ToString();

        guiController.ViewColorFieldText.text = currentMovieData.Color;
        guiController.ViewAspectRatioFieldText.text = (currentMovieData.AspectRatio / 100f).ToString();
        guiController.ViewBudgetFieldText.text = $"{MoneyRounder.GetMoneyRoundedToNearestPower(currentMovieData.Budget)} USD";
        guiController.ViewGrossFieldText.text = $"{MoneyRounder.GetMoneyRoundedToNearestPower(currentMovieData.Gross)} USD";
        guiController.ViewLanguageFieldText.text = currentMovieData.Language;
        guiController.ViewCountryFieldText.text = currentMovieData.Country;
        guiController.ViewContentRatingFieldText.text = currentMovieData.ContentRating;
            
        guiController.ViewImdbPageButton.onClick.AddListener(() => OnImdbPageButtonClicked(currentMovieData.ImdbUrl));
    }

    public void OnExit(GUIController guiController) {
        guiController.ViewMovieDatabaseDialog.SetActive(false);
        guiController.ViewMovieDatabaseBackButton.onClick.RemoveAllListeners();
        guiController.ViewPosterImage.sprite = null;
        guiController.ViewImdbPageButton.onClick.RemoveAllListeners();
    }
    
    private void OnBackClicked() {
        NextState = new SearchMovieDatabaseState();
        IsComplete = true;
    }

    private void OnImdbPageButtonClicked(string imdbPageUrl) {
        Application.OpenURL(imdbPageUrl);
    }
}
