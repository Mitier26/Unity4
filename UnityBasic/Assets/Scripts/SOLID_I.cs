using UnityEngine;

public class SOLID_I : MonoBehaviour
{
    // 인터페이스 분리 원칙
    // 특정 클라이언트를 위한 인터페이스는 범용 인터페이스보다 더 유용해야 한다.
    // 사용하지 않는 메서드에 의존하지 않도록 인터페이스를 작게 분리 한다.

    interface IAttack
    {
        void Attack();
    }
    interface IMove
    {
        void Move();
    }
    interface IIdle
    {
        void Idle();
    }

    // 인터페이스는 다중 상속이 가능 하기 때문에 인터페이스를 분리한다.
    public class Player : IAttack, IMove, IIdle
    {
        public void Attack() { }
        public void Move() { }
        public void Idle() { }
    }

    public class Npc : IMove, IIdle
    {
        public void Move() { }
        public void Idle() { }
    }


}
