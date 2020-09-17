using UnityEngine;

public class DataLoader : MonoBehaviour {

    [SerializeField] 
    private TextAsset movieDataCSV;

    void Start()
    {
        string[] movieDataRecords = MovieDataCSVTransformer.SplitRecordsFromMovieData(movieDataCSV.text);
        
        Debug.Log($"Number of Records to Load: <{movieDataRecords.Length}>");

        // start at i = 1 because the first record is headers
        for (int i = 1; i < movieDataRecords.Length; i++) {
            MovieData movieData = MovieDataCSVTransformer.LoadMovieDataFromRecord(movieDataRecords[i]);
            MovieRuntimeData.AddTitleKeyedData(movieData.Title, movieData);
        }
        
        Debug.Log($"Number of Records Loaded: <{MovieRuntimeData.NumTitleKeyedItems}>");
        
    }

}
