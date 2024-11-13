using System.Collections.Generic;
using UnityEngine;

public class GenericExample4 : MonoBehaviour
{
    private void Start()
    {
        // Collection 과 Collections.Generic과는 다른 것이 사용된다.
        List<int> list = new List<int>();

        list.Add(10);
        list.Add(20);
        list.Add(30);

        list.RemoveAt(0);

        list.Remove(20);

        list.Insert(1, 50);


        Dictionary<string, string> dic = new Dictionary<string, string>();
        dic["하나"] = "one";
        dic["둘"] = "two";
        dic["셋"] = "three";


        Stack<int> stack = new Stack<int>();
        
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        stack.Push(4);

        while(stack.Count > 0)
        {
            Debug.Log(stack.Pop());
        }

        Queue<int> queue = new Queue<int>();

        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);

        while (queue.Count > 0)
        {
            Debug.Log(queue.Dequeue());
        }
    }
}
