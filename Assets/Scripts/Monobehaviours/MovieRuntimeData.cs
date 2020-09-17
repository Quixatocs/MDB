using System.Collections.Generic;
using UnityEngine;

public static class MovieRuntimeData {
    
    private static Dictionary<string, MovieData> titleKeyedData = new Dictionary<string, MovieData>();

    public static int NumTitleKeyedItems {
        get { return titleKeyedData.Count; }
    }

    public static void ClearTitleKeyedData() {
        titleKeyedData.Clear();
    }

    /// <summary>
    /// Adds a MovieData object keyed against the movie title
    /// Will replace an existing entry if a second is found with the same key
    /// </summary>
    public static void AddTitleKeyedData(string key, MovieData movieData) {
        titleKeyedData.SetValue(key, movieData);
    }

    public static MovieData GetMovieDataFromTitle(string key) {
        return titleKeyedData[key];
    }
    
    //TODO: Other dictionaries for different searches
    
}
