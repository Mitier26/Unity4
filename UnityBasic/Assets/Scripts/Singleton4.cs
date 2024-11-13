using UnityEngine;

public class Singleton4 : MonoBehaviour
{
    private static Singleton4 instance;

    public static Singleton4 Instance
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
        instance = FindFirstObjectByType<Singleton4>();
        if(instance == null)
        {
            GameObject gameObj = new GameObject();
            gameObj.name = typeof(Singleton4).Name;
            instance = gameObj.AddComponent<Singleton4>();
            DontDestroyOnLoad(gameObj);
        }
    }
}
