using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    public GameObject canvasPopup;
    public GameObject buttonOpen;

    public void ClosePopup()
    {
        canvasPopup.SetActive(false);
        buttonOpen.SetActive(true);
    }

    public void OpenPopup()
    {
        canvasPopup.SetActive(true);
        buttonOpen.SetActive(false);
    }
}
