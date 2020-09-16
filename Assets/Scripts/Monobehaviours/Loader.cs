using System;
using UnityEngine;

public class Loader : MonoBehaviour {

    [SerializeField] 
    private TextAsset movieDataCSV;

    [SerializeField] 
    private MovieRuntimeData movieRuntimeData;
    
    void Start()
    {
        
        string[] movieDataRecords = MovieDataCSVTransformer.SplitRecordsFromMovieData(movieDataCSV.text);
        
        Debug.Log(movieDataRecords.Length);

        // start at i = 1 because the first record is headers
        for (int i = 1; i < movieDataRecords.Length; i++) {
            Debug.Log(MovieDataCSVTransformer.LoadMovieDataFromRecord(movieDataRecords[i]).Title);
        }
        
        //Call CSV loader
    }

}
