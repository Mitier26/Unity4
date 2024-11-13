using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UnityAction1 : MonoBehaviour
{
    UnityAction unityAction;

    UnityAction<int> unityAction1;

    public Button button;

    private void Start()
    {
        unityAction = () => Debug.Log("Button");

        button.onClick.AddListener(unityAction);
        button.onClick.AddListener(() => Debug.Log("Button2"));
    }
}
