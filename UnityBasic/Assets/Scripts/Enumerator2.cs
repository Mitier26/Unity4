using UnityEngine;

public class Enumerator2 : MonoBehaviour
{
    public class MyList
    {
        public enumerator GetEnumerator()
        {
            enumerator enumerator = new enumerator();
            return enumerator;
        }

        public class enumerator
        {
            int[] nums = new int[5] { 1, 2, 3, 4, 5 };
            int index = -1;

            public object Current {  get { return nums[index]; } }
            // 현재 요소 반환

            // 다음 요소로 이동, 이동이 성공하면 true, 더 이상 이동 할 수 없으면 false
            public bool MoveNext()
            {
                if (index == nums.Length - 1)
                    return false;

                index++;
                return index < nums.Length;
            }
        }
    }

    private void Start()
    {
        MyList mylist = new MyList();

        MyList.enumerator e = mylist.GetEnumerator();

        while (e.MoveNext()) Debug.Log(e.MoveNext());

        //foreach(var one in mylist)
        //    Debug.Log(one.ToString());
    }
}
