using UnityEngine;

public class DelegateTest4_1 : MonoBehaviour
{
    class Player
    {
        public enum Buff
        {
            None, Buff1, Buff2
        }

        public Buff _buff;

        public void BuffCheck(Buff buff)
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
        }

        public void Attack(Buff buff)
        {
            BuffCheck(buff);
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
