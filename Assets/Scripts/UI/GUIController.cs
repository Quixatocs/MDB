using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour {

    private static GUIController instance;

    #region Open Movie Database UI Elements

    [Header("Open Movie Database UI")]
    [SerializeField] private GameObject openMovieDatabaseDialog;
    [SerializeField] private Button openMovieDatabaseButton;

    public GameObject OpenMovieDatabaseDialog {
        get => openMovieDatabaseDialog;
    }
    
    public Button OpenMovieDatabaseButton {
        get => openMovieDatabaseButton;
    }

    #endregion

    #region Search Movie Database UI Elements
    
    [Header("Search Movie Database UI")]
    [SerializeField] private GameObject searchMovieDatabaseDialog;
    [SerializeField] private InputField searchMovieDatabaseInputField;
    [SerializeField] private Button searchMovieDatabaseButton;
    
    public GameObject SearchMovieDatabaseDialog {
        get => searchMovieDatabaseDialog;
    }
    
    public InputField SearchMovieDatabaseInputField {
        get => searchMovieDatabaseInputField;
    }
    
    public Button SearchMovieDatabaseButton {
        get => searchMovieDatabaseButton;
    }

    #endregion

    #region View Movie Database UI Elements
    
    [Header("View Movie Database UI")]
    [SerializeField] private GameObject viewMovieDatabaseDialog;
    
    public GameObject ViewMovieDatabaseDialog {
        get => viewMovieDatabaseDialog;
    }

    #endregion
    
    private Coroutine stateCompleteCheck;
    private IGUIState currentState;

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
}
