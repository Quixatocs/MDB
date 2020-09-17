using System.Collections.Generic;
using UnityEngine;

public class MovieRuntimeData : MonoBehaviour {
    
    private readonly Dictionary<string, MovieData> titleKeyedData = new Dictionary<string, MovieData>();

    public int NumTitleKeyedItems {
        get { return titleKeyedData.Count; }
    }

    public void ClearTitleKeyedData() {
        titleKeyedData.Clear();
    }

    /// <summary>
    /// Adds a MovieData object keyed against the movie title
    /// Will replace an existing entry if a second is found with the same key
    /// </summary>
    public void AddTitleKeyedData(string key, MovieData movieData) {
        titleKeyedData.SetValue(key, movieData);
    }

    public MovieData GetMovieDataFromTitle(string key) {
        return titleKeyedData[key];
    }
    
    //TODO: Other dictionaries for different searches
    
}
