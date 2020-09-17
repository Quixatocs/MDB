using System.Collections.Generic;

public static class DictionaryExtensions {
    
    /// Will add the value to the dictionary, overriding it if it already exists.
    public static void SetValue<TKey,TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value) {
        if(dictionary.ContainsKey(key)) {
            dictionary[key] = value;
        } else {
            dictionary.Add(key, value);
        }
    }
}

