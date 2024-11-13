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
            Debug.Log("����");
        }

        void Buff1() { Debug.Log("����1"); }
        void Buff2() { Debug.Log("����2"); }
        void NoneBuff() { Debug.Log("����"); }
    }

    private void Start()
    {
        Player player = new Player();
        player.Attack(Player.Buff.Buff1);
    }
}
