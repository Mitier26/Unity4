using Unity.VisualScripting;
using UnityEngine;

public class GenericExample2 : MonoBehaviour
{
    public void Copy(int[] source, int[] target)
    {
        for(int i= 0; i < source.Length; i++)
        {
            target[i] = source[i];
        }
    }

    public void Copy<T>(T[] source, T[] target)
    {
        for(int i =0; i < source.Length; i++)
        {
            target[i] = source[i];
        }
    }

    private void Start()
    {
        int[] sourceArry = { 1, 2, 3, 4, 5 };
        int[] targetArry = new int[sourceArry.Length];
        Copy(sourceArry, targetArry);
        Copy<int>(sourceArry, targetArry);

        string[] sourceArry2 = { "하나", "둘", "셋", "넷", "다섯" };
        string[] targetArry2 = new string[sourceArry2.Length];
        Copy<string>(sourceArry2, targetArry2);
    }
}
