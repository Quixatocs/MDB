﻿using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Class to contain extensions to the Dictionary class
/// </summary>
public static class DictionaryExtensions {
    
    /// <summary>
    /// Will add the value to the dictionary, overriding it if it already exists.
    /// </summary>
    public static void SetValue<TKey,TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value) {
        if(dictionary.ContainsKey(key)) {
            dictionary[key] = value;
        } else {
            dictionary.Add(key, value);
        }
    }
    
    /// <summary>
    /// Will return a list of values that partially match the entered search string
    /// </summary>
    public static IEnumerable<T> PartialMatch<T>(this Dictionary<string, T> dictionary, string partialKey) {
        IEnumerable<string> matchingKeys = dictionary.Keys.Where(currentKey => currentKey.Contains(partialKey));

        List<T> matchingValues = new List<T>();

        foreach (string currentKey in matchingKeys) {
            matchingValues.Add(dictionary[currentKey]);
        }

        return matchingValues;
    }
}

