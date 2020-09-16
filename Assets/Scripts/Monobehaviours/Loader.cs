using System;
using UnityEngine;

public class Loader : MonoBehaviour {

    [SerializeField] 
    private TextAsset movieDataCSV;

    [SerializeField] 
    private MovieRuntimeData movieRuntimeData;
    
    void Start()
    {
        string[] movieDataRecords = movieDataCSV.text.Split(
            new[] {"\r\n", "\r", "\n"},
            StringSplitOptions.None
        );
        
        Debug.Log(movieDataRecords.Length);
        
        //Call CSV loader
    }

}
