using System.Collections;
using UnityEngine;

public class GUIController : MonoBehaviour {

    private Coroutine stateCompleteCheck;
    private IGUIState currentState;

    private void SetState(IGUIState nextState) {
        
    }

    private IEnumerator CheckComplete() {
        yield return null;
    }
}
