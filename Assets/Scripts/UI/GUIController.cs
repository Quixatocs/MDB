using System;
using System.Collections;
using UnityEngine;

public class GUIController : MonoBehaviour {

    private static GUIController instance;

    #region Open Movie Database UI Elements

    [SerializeField] private GameObject openMovieDatabaseDialog;

    public GameObject OpenMovieDatabaseDialog {
        get => openMovieDatabaseDialog;
    }

    #endregion

    #region Search Movie Database UI Elements

    [SerializeField] private GameObject searchMovieDatabaseDialog;
    
    public GameObject SearchMovieDatabaseDialog {
        get => searchMovieDatabaseDialog;
    }

    #endregion

    #region View Movie Database UI Elements
    
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
        //TODO: Start initial state here
        instance.SetState(null);
    }

    /// <summary>
    /// Sets the next state in the statemachine and calls OnEnter for that state
    /// </summary>
    private void SetState(IGUIState nextState) {
        currentState = nextState;
        if (currentState != null) {
            currentState.OnEnter();
            
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
                // We are leaving the statemachine so no need to run the check
                stateCompleteCheck = null;
                yield break;
            }
            
            if (currentState.IsComplete) {
                SetState(currentState.NextState);
            }
        }
    }
}
