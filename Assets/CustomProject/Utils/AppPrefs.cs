
using System;
using UnityEngine;

namespace CustomProject.Utils
{
    public static class AppPrefs
    {
        public static object Get(Type type)
        {
            string typeName = type.Name;
            return GetObject(typeName, type);            
        }

        public static T Get<T>() where T : class
        {
            string typeName = typeof(T).Name;
            return GetObject<T>(typeName);
        }

        public static void Save(Type type, object obj)
        {
            string typeName = type.Name;
            SaveObject(typeName, obj);
        }

        public static void Save<T>(T obj) where T : class
        {
            if (obj != null)
            {
                string typeName = typeof(T).Name;
                SaveObject(typeName, obj);
            }
            else
            {
                Clear<T>();
            }
        }

        public static T Get<T>(string key) where T : class
        {
            return GetObject<T>(key);
        }

        public static void Save<T>(string key, T obj) where T : class
        {
            SaveObject(key, obj);
        }

        public static float GetFloat(string key)
        {
            if (!PlayerPrefs.HasKey(key))
            {
                Debug.LogError($"AppPrefs: Unable to load float value by key {key}");
                return default;
            }

            return PlayerPrefs.GetFloat(key);
        }

        public static int GetInt(string key)
        {
            if (!PlayerPrefs.HasKey(key))
            {
                Debug.LogError($"AppPrefs: Unable to load int value by key {key}");
                return default;
            }

            return PlayerPrefs.GetInt(key);
        }

        public static string GetString(string key)
        {
            if (!PlayerPrefs.HasKey(key))
            {
                Debug.LogError($"AppPrefs: Unable to load string value by key {key}");
                return default;
            }

            return PlayerPrefs.GetString(key);
        }

        public static void SaveFloat(string key, float val)
        {
            PlayerPrefs.SetFloat(key, val);
            PlayerPrefs.Save();
        }

        public static void SaveInt(string key, int val)
        {
            PlayerPrefs.SetInt(key, val);
            PlayerPrefs.Save();
        }

        public static void SaveString(string key, string str)
        {
            PlayerPrefs.SetString(key, str);
            PlayerPrefs.Save();
        }

        public static bool HasKey(string key)
        {
            return PlayerPrefs.HasKey(key);
        }

        public static void Clear(string key)
        {
            if (!PlayerPrefs.HasKey(key))
            {
                Debug.LogError($"AppPrefs: Unable to find key \"{key}\" to remove it");
                return;
            }

            PlayerPrefs.DeleteKey(key);
            PlayerPrefs.Save();
        }

        public static void ClearAll()
        {
            PlayerPrefs.DeleteAll();
        }

        public static void Clear<T>()
        {
            string typeName = typeof(T).Name;
            if (HasKey(typeName))
            {
                PlayerPrefs.DeleteKey(typeName);
                PlayerPrefs.Save();
            }
            else
            {
                Debug.LogWarning($"AppPrefs: Unable to find key \"{typeName}\" to remove it");
            }
        }

        private static void SaveObject<T>(string key, T obj) where T : class
        {
            string serializedObj = JsonUtility.ToJson(obj);

            if (serializedObj == null)
            {
                return;
            }

            PlayerPrefs.SetString(key, serializedObj);
            PlayerPrefs.Save();
        }

        private static object GetObject(string key, Type type)
        {
            if (!PlayerPrefs.HasKey(key))
            {
                return null;
            }

            object obj = null;

            string serializedObj = PlayerPrefs.GetString(key);

            try
            {
                obj = JsonUtility.FromJson(serializedObj, type);
            }
            catch (Exception exp)
            {
                Debug.LogException(exp);
            }

            if (obj == null)
            {
                Debug.LogWarning($"AppPrefs: Unable to deserialize object of type {key}");
            }

            return obj;
        }

        private static T GetObject<T>(string key) where T : class
        {
            if (!PlayerPrefs.HasKey(key))
            {
                return null;
            }

            T obj = null;

            string serializedObj = PlayerPrefs.GetString(key);

            try
            {
                obj = JsonUtility.FromJson<T>(serializedObj);
            }
            catch (Exception exp)
            {
                Debug.LogException(exp);
            }

            if (obj == null)
            {
                Debug.LogWarning($"AppPrefs: Unable to deserialize object of type {key}");
            }

            return obj;
        }
    }
}
