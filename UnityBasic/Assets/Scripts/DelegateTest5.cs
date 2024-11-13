using UnityEngine;

public class DelegateTest5 : MonoBehaviour
{
    
    class Player
    {
        private delegate void Buffdelegate();

        private Buffdelegate _buffdelegate;
        public enum Buff
        {
            None, Buff1, Buff2
        }

        private Buff _buff;

        // player._buff�� ���� ���� ���ϸ� ���ϴ� ���� ���� ��������Ʈ�� �����Ѵ�.
        public Buff _Buff
        {
            get { return _buff; }
            set
            {
                if (_buff == value) return;

                _buff = value;
                if (_buff == Buff.Buff1)
                    _buffdelegate = Buff1;
                else if (_buff == Buff.Buff2)
                    _buffdelegate = Buff2;
                else if (_buff != Buff.None)
                    _buffdelegate = NoneBuff;
            }
        }

        public void Attack()
        {
            _buffdelegate.Invoke();
            Debug.Log("����");
        }

        void Buff1() { Debug.Log("����1"); }
        void Buff2() { Debug.Log("����2"); }
        void NoneBuff() { Debug.Log("����"); }
    }

    private void Start()
    {
        Player player = new Player();
        player._Buff = Player.Buff.Buff1;
        player.Attack();
    }
}
