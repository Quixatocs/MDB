using System.Collections.Generic;
using UnityEngine;

public static class DictionaryExtensions {
    /// <summary>
    /// Will add the value to the dictionary, overriding it if it already exists.
    /// </summary>
    /// <typeparam name="T">The generic type parameter</typeparam>
    public static void SetValue<TKey,TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value) {
        if(dictionary.ContainsKey(key)) {
            dictionary[key] = value;
        } else {
            dictionary.Add(key, value);
        }
    }
}

