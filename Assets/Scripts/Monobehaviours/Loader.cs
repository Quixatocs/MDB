using System;
using UnityEngine;

public class Loader : MonoBehaviour {

    [SerializeField] 
    private TextAsset movieDataCSV;

    [SerializeField] 
    private MovieRuntimeData movieRuntimeData;
    
    void Start()
    {
        
        string[] movieDataRecords = CSVTransformer.SplitRecordsFromMovieData(movieDataCSV.text);
        
        Debug.Log(movieDataRecords.Length);
        
        //Call CSV loader
    }

}
