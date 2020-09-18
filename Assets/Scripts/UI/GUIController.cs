using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GUIController : MonoBehaviour {

    #region Singleton Instance

    private static GUIController instance;

    #endregion

    #region Open Movie Database UI Elements

    [Header("Open Movie Database UI")]
    [SerializeField] private GameObject openDialog;
    [SerializeField] private Button openButton;

    public GameObject OpenMovieDatabaseDialog {
        get => openDialog;
    }
    
    public Button OpenMovieDatabaseButton {
        get => openButton;
    }

    #endregion

    #region Search Movie Database UI Elements
    
    [Header("Search Movie Database UI")]
    [SerializeField] private GameObject searchDialog;
    [SerializeField] private InputField searchInputField;
    [SerializeField] private Button searchButton;
    [SerializeField] private Button searchBackButton;
    [SerializeField] private GameObject searchMatchedTitlePrefab;
    [SerializeField] private Transform searchMatchedTitlesHolder;
    
    public GameObject SearchMovieDatabaseDialog {
        get => searchDialog;
    }
    
    public InputField SearchMovieDatabaseInputField {
        get => searchInputField;
    }
    
    public Button SearchMovieDatabaseButton {
        get => searchButton;
    }
    
    public Button SearchMovieDatabaseBackButton {
        get => searchBackButton;
    }
    
    public GameObject SearchMatchedTitlePrefab {
        get => searchMatchedTitlePrefab;
    }
    
    public Transform SearchMatchedTitlesHolder {
        get => searchMatchedTitlesHolder;
    }

    #endregion

    #region View Movie Database UI Elements
    
    [Header("View Movie Database UI")]
    [SerializeField] private GameObject viewDialog;
    [SerializeField] private Button viewBackButton;
    [SerializeField] private Image viewPosterImage;
    
    [SerializeField] private Text viewTitleFieldText;
    [SerializeField] private Text viewDirectorFieldText;
    [SerializeField] private Text viewDurationFieldText;
    [SerializeField] private Text viewYearFieldText;
    
    [SerializeField] private Text viewColorFieldText;
    [SerializeField] private Text viewAspectRatioFieldText;
    [SerializeField] private Text viewBudgetFieldText;
    [SerializeField] private Text viewGrossFieldText;
    [SerializeField] private Text viewLanguageFieldText;
    [SerializeField] private Text viewCountryFieldText;
    [SerializeField] private Text viewContentRatingFieldText;
    
    [SerializeField] private Button viewImdbPageButton;

    public GameObject ViewMovieDatabaseDialog {
        get => viewDialog;
    }
    
    public Button ViewMovieDatabaseBackButton {
        get => viewBackButton;
    }
    
    public Image ViewPosterImage {
        get => viewPosterImage;
    }
    
    public Text ViewTitleFieldText {
        get => viewTitleFieldText;
    }
    
    public Text ViewDirectorFieldText {
        get => viewDirectorFieldText;
    }
    
    public Text ViewDurationFieldText {
        get => viewDurationFieldText;
    }
    
    public Text ViewYearFieldText {
        get => viewYearFieldText;
    }

    public Text ViewColorFieldText {
        get => viewColorFieldText;
    }
    
    public Text ViewAspectRatioFieldText {
        get => viewAspectRatioFieldText;
    }
    
    public Text ViewBudgetFieldText {
        get => viewBudgetFieldText;
    }
    
    public Text ViewGrossFieldText {
        get => viewGrossFieldText;
    }
    
    public Text ViewLanguageFieldText {
        get => viewLanguageFieldText;
    }
    
    public Text ViewCountryFieldText {
        get => viewCountryFieldText;
    }
    
    public Text ViewContentRatingFieldText {
        get => viewContentRatingFieldText;
    }
    
    public Button ViewImdbPageButton {
        get => viewImdbPageButton;
    }

    #endregion

    #region State Machine Fields

    private Coroutine stateCompleteCheck;
    private IGUIState currentState;

    #endregion
    
    #region Events Fields

    public delegate void OnUIDisplayableError(string errorMessage);
    public static event OnUIDisplayableError onUIDisplayableError;

    #endregion

    #region Event Methods

    public static void SendOnUIDisplayableError(string errorMessage) {
        onUIDisplayableError?.Invoke(errorMessage);
    }

    #endregion

    #region Monobehaviour Methods

    private void Awake() {
        // Singleton implementation
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    private void Start() {
        instance.SetState(new OpenMovieDatabaseState());
    }

    #endregion

    #region State Machine Methods

    /// <summary>
    /// Sets the next state in the statemachine and calls OnEnter for that state
    /// </summary>
    private void SetState(IGUIState nextState) {
        
        // Exit previous state
        if (currentState != null) {
            currentState.OnExit(this);
        }
        
        currentState = nextState;
        
        if (currentState != null) {
            currentState.OnEnter(this);
            
            if (stateCompleteCheck == null) {
                stateCompleteCheck = StartCoroutine(CheckComplete());
            }
        }
        else {
            if (stateCompleteCheck != null) {
                StopCoroutine(stateCompleteCheck);
                stateCompleteCheck = null;
            }
        }
    }

    /// <summary>
    /// Checks if the current state is complete
    /// </summary>
    private IEnumerator CheckComplete() {
        while (true) {
            yield return new WaitForEndOfFrame();
            
            if (currentState == null) { 
                // We are leaving the statemachine so we can stop running the check
                stateCompleteCheck = null;
                yield break;
            }
            
            if (currentState.IsComplete) {
                SetState(currentState.NextState);
            }
        }
    }

    #endregion

    #region Remote Image Download Methods

    public void LoadRemoteImage(string imageUrl) {
        StartCoroutine(DownloadAndSetRemoteImage(imageUrl));
    }
    private IEnumerator DownloadAndSetRemoteImage(string imageUrl) {
        if (viewPosterImage == null) yield break;
        
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(imageUrl);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError) {
            Debug.Log(request.error);
        }
        else {
            Texture2D downloadedTexture = ((DownloadHandlerTexture) request.downloadHandler).texture;
            if (downloadedTexture != null) {
                viewPosterImage.sprite = Sprite.Create(downloadedTexture, new Rect(0.0f, 0.0f, downloadedTexture.width, downloadedTexture.height), Vector2.zero);
            }
        }
    } 

    #endregion
}
