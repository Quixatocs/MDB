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

    public void AddTitleKeyedData(string key, MovieData movieData) {
        titleKeyedData.SetValue(key, movieData);
    }

    public MovieData GetMovieDataFromTitle(string key) {
        return titleKeyedData[key];
    }
    
    //TODO: Other dictionaries for different searches
    
}
