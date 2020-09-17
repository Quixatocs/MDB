﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour {

    private static GUIController instance;

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

    #endregion

    #region View Movie Database UI Elements
    
    [Header("View Movie Database UI")]
    [SerializeField] private GameObject viewDialog;
    [SerializeField] private Button viewBackButton;
    [SerializeField] private Text titleFieldText;
    [SerializeField] private Text directorFieldText;
    [SerializeField] private Text durationFieldText;
    [SerializeField] private Text yearFieldText;
    
    public GameObject ViewMovieDatabaseDialog {
        get => viewDialog;
    }
    
    public Button ViewMovieDatabaseBackButton {
        get => viewBackButton;
    }
    
    public Text TitleFieldText {
        get => titleFieldText;
    }
    
    public Text DirectorFieldText {
        get => directorFieldText;
    }
    
    public Text DurationFieldText {
        get => durationFieldText;
    }
    
    public Text YearFieldText {
        get => yearFieldText;
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
