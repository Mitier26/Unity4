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

        // player._buff의 변수 값이 변하면 변하는 값에 따라 델리게이트를 변경한다.
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
            Debug.Log("공격");
        }

        void Buff1() { Debug.Log("버프1"); }
        void Buff2() { Debug.Log("버프2"); }
        void NoneBuff() { Debug.Log("없음"); }
    }

    private void Start()
    {
        Player player = new Player();
        player._Buff = Player.Buff.Buff1;
        player.Attack();
    }
}
