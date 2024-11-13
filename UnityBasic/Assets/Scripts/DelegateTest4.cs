using UnityEngine;

public class DelegateTest4 : MonoBehaviour
{
    // 콜벡
    // 함수를 호출하는 것은 Call
    // 함수를 나중에 호출하는 것은 CallBack

    class Player
    {
        public enum Buff
        {
            None, Buff1, Buff2
        }

        public Buff _buff;

        public void Attack(Buff buff)
        {
            if (buff == Buff.Buff1)
            {
                Buff1();
            }
            else if (buff == Buff.Buff2)
            {
                Buff2();
            }
            else if (buff == Buff.None)
            {
                NoneBuff();
            }
            Debug.Log("공격");
        }

        void Buff1() { Debug.Log("버프1"); }
        void Buff2() { Debug.Log("버프2"); }
        void NoneBuff() { Debug.Log("없음"); }
    }

    private void Start()
    {
        Player player = new Player();
        player.Attack(Player.Buff.Buff1);
    }
}
