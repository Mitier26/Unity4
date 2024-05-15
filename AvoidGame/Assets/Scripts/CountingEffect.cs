using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class CountingEffect : MonoBehaviour
{
    [SerializeField]
    [Range(0.01f, 10f)]
    private float effecTime;

    private TextMeshProUGUI effectText;

    private void Awake()
    {
        effectText = GetComponent<TextMeshProUGUI>();
    }

    public void Play(int start, int end, UnityAction action = null)
    {
        StartCoroutine(Process(start, end, action));
    }

    private IEnumerator Process(int start, int end, UnityAction action)
    {
        float current = 0;
        float percent = 0;

        while(percent < 1)
        {
            current += Time.deltaTime;
            percent = current / effecTime;

            effectText.text = Mathf.Lerp(start, end, percent).ToString("F0");

            yield return null;
        }

        // action이 null이 아니면 action에 있는 메서드를 실행
        action?.Invoke();
    }
}
