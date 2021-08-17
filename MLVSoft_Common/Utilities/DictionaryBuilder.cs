using System.Collections.Generic;

namespace MLVSoft_Common.Utilities
{
    public static class DictionaryBuilder<T>
    {
        public static Dictionary<string, List<T>> BuildDictionary(List<string> keysCollection)
        {
            Dictionary<string, List<T>> dictionary = new Dictionary<string, List<T>>(keysCollection.Count);

            foreach (string key in keysCollection)
                dictionary.Add(key, new List<T>());

            return dictionary;
        }
    }
}