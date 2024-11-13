using UnityEngine;

public class Singleton6<T> : MonoBehaviour where T : Component
{
    // Á¦³×¸¯ ½Ì±ÛÅæ
    private static T instance;

    public static T Instance
    {
        get
        {
            if(instance == null)
            {
                SetupInstance();
            }
            return instance;
        }
    }

    private static void SetupInstance()
    {
        instance = FindFirstObjectByType<T>();
        if (instance == null)
        {
            GameObject gameObj = new GameObject();
            gameObj.name = typeof(T).Name;
            instance = gameObj.AddComponent<T>();
            DontDestroyOnLoad(gameObj);
        }
    }
}
