using System.Collections;
using UnityEngine;

public class GUIController : MonoBehaviour {

    private Coroutine stateCompleteCheck;
    private IGUIState currentState;

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
            if (currentState.IsComplete) {
                SetState(currentState.NextState);
            }
        }
    }
}
