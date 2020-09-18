using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Static Class holding the runtime data of the Movie Database which is loaded at app startup
/// </summary>
public static class MovieRuntimeData {
    
    private static Dictionary<string, MovieData> titleKeyedData = new Dictionary<string, MovieData>();

    public static int NumTitleKeyedItems => titleKeyedData.Count;

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

    /// <summary>
    /// Gets an individual movie data from the full title as the key
    /// </summary>
    public static MovieData GetMovieDataFromTitle(string key) {
        return titleKeyedData[key];
    }

    /// <summary>
    /// Gets a list of unique matching Movie titles from the partial input string
    /// </summary>
    public static HashSet<string> GetUniqueMatchingTitles(string partialTitle) {
        HashSet<string> matchingTitles = new HashSet<string>();
        IEnumerable<MovieData> movieDatas = titleKeyedData.PartialMatch(partialTitle);

        foreach (MovieData movieData in movieDatas) {
            matchingTitles.Add(movieData.Title);
        }
        
        return matchingTitles;
    }
    
    //TODO: Other dictionaries for different types of searches
    
}
