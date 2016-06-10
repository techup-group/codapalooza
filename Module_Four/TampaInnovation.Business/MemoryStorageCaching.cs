using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;

namespace TampaInnovation.Business
{
    /// <summary>
    /// Class CustomStorageCaching.
    /// </summary>
    internal static class MemoryStorageCaching
    {
        /// <summary>
        /// The _cache
        /// </summary>
        private static readonly ObjectCache _cache = MemoryCache.Default;
        /// <summary>
        /// The _keys
        /// </summary>
        private static readonly HashSet<string> _keys = new HashSet<string>();
        /// <summary>
        /// The default cache key
        /// </summary>
        private const string DEFAULT_CACHE_KEY = "__CACHE_{0}_{1}";

        /// <summary>
        /// Adds the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="dataObject">The data object.</param>
        /// <param name="section">The section.</param>
        /// <param name="policy">The policy.</param>
        public static void Set(string key, object dataObject, string section, CacheItemPolicy policy)
        {
            if (dataObject == null)
                return;

            key = string.Format(DEFAULT_CACHE_KEY, section, key);
            _cache.Set(key, dataObject, policy);
            _keys.Add(key);
        }

        /// <summary>
        /// Check if key exists
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="section">The section.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool Exists(string key, string section)
        {
            key = string.Format(DEFAULT_CACHE_KEY, section, key);
            return _cache[key] != null;
        }

        /// <summary>
        /// Gets the object specified by the key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="section">The section.</param>
        /// <returns>T.</returns>
        public static T Get<T>(string key, string section)
        {
            key = string.Format(DEFAULT_CACHE_KEY, section, key);
            object cacheValue = _cache[key];
            return cacheValue == null ? default(T) : (T)cacheValue;
        }

        /// <summary>
        /// Removes the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="section">The section.</param>
        public static void Remove(string key, string section)
        {
            key = string.Format(DEFAULT_CACHE_KEY, section, key);
            _cache.Remove(key);
            _keys.Remove(key);
        }

        /// <summary>
        /// Removes all item for that section.
        /// </summary>
        /// <param name="section">The section.</param>
        public static void RemoveAll(string section)
        {
            List<string> items = _keys.Where(t => t.StartsWith($"__CACHE_{section}")).ToList();
            for (int i = 0; i < items.Count; i++)
            {
                _cache.Remove(items[i]);
                _keys.Remove(items[i]);
            }
        }
    }
}
