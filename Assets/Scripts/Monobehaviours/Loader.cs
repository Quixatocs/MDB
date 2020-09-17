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
        
        Debug.Log($"Number of Records to Load: <{movieDataRecords.Length}>");

        // start at i = 1 because the first record is headers
        for (int i = 1; i < movieDataRecords.Length; i++) {
            MovieData movieData = MovieDataCSVTransformer.LoadMovieDataFromRecord(movieDataRecords[i]);
            Debug.Log(movieData.Title);
            movieRuntimeData.AddTitleKeyedData(movieData.Title, movieData);
        }
        
        Debug.Log($"Number of Records Loaded: <{movieRuntimeData.NumTitleKeyedItems}>");
        
    }

}
