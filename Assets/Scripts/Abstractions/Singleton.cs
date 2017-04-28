﻿using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance = null;

    private static object _lock = new object();

    public static T Instance
    {
        get
        {
            if(appplicationIsQuitting)
            {
                Debug.LogWarning("[Singleton] Instance '" + typeof(T) + "' already destroyed on application quit. Won't create again - returning null.");
                return null;
            }

            lock(_lock)
            {
                if(_instance == null)
                {
                    _instance = (T)FindObjectOfType(typeof(T));

                    if(FindObjectsOfType(typeof(T)).Length > 1)
                    {
                        Debug.LogError("[Singleton] Something went really wrong - there is more than one singleton of type " + typeof(T) + ". Reopening the scene may fix this!");
                        return _instance;
                    }

                    if(_instance == null)
                    {
                        GameObject singleton = new GameObject();
                        _instance = singleton.AddComponent<T>();
                        singleton.name = "(singleton) " + typeof(T).ToString();

                        DontDestroyOnLoad(singleton);

                        Debug.Log("[Singleton] An instance of " + typeof(T) + "is needed in the scene so '" + singleton + "' was created with don't destroy on load.");
                    }
                    else
                    {
                        Debug.Log("[Singleton] Using instance already created: " + _instance.gameObject.name);
                    }
                }
                return _instance;
            }
        }
    }

    private static bool appplicationIsQuitting = false;

    public void OnDestroy()
    {
        appplicationIsQuitting = true;
    }
}
