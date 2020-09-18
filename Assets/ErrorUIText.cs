using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ErrorUIText : MonoBehaviour {

    private Text errorText;
    private bool isDisplayingUIError;
    private WaitForSeconds errorDelay = new WaitForSeconds(3);
    
    void Awake() {
        errorText = GetComponent<Text>();
        errorText.text = String.Empty;
    }

    private void OnEnable() {
        errorText.text = String.Empty;
        GUIController.onUIDisplayableError += OnDisplayUIErrorText;
        StopAllCoroutines();
    }
    
    private void OnDisable() {
        errorText.text = String.Empty;
        GUIController.onUIDisplayableError -= OnDisplayUIErrorText;
        StopAllCoroutines();
    }

    private void OnDisplayUIErrorText(string errorMessage) {
        errorText.text = String.Empty;

        if (isDisplayingUIError) {
            StopAllCoroutines();
        }

        StartCoroutine(DisplayUIErrorMessageThenClear(errorMessage));
    }

    private IEnumerator DisplayUIErrorMessageThenClear(string errorMessage) {
        isDisplayingUIError = true;
        errorText.text = errorMessage;
        yield return errorDelay;
        errorText.text = String.Empty;
        isDisplayingUIError = false;
    }
}
