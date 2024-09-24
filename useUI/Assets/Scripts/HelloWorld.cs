using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelloWorld : MonoBehaviour
{
    const string hw = "Hello World";

    private void Start()
    {
        Text message = GetComponent<Text>();
        message.text = hw;
    }
}
