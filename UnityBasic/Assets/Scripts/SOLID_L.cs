using Unity.VisualScripting;
using UnityEngine;

public class SOLID_L : MonoBehaviour
{
    // 리스코프 치환 원칙
    // 자식 클래스는 부모 클래스의 역할을 대체할 수 있어야 한다
    // 이는 상속구조에서 일관성을 유지하는데 중요
    
    public class Character
    {
        public void Attack() { }
        public void Move() { }
        public void Idle() { }
    }

    public class Player : Character
    {
        private void Start()
        {
            Attack();
            Move();
            Idle();
        }
    }

    public class Npc : Character
    {
        private void Start()
        {
            Attack(); // 공격하는 기능은 필요 없다.
            Move();
            Idle();
        }
    }

    // Character 와 Player는 리스코프 치환원칙을 잘 지키고 있다.
    // 자식 클래스는 부모 클래스를 대체할 수 있어야 하는데 Npc 는 공격 기능을 할 수 없다.

    public class Character2
    {
        public void Move() { }
        public void Idle() { }
    }

    public class Player2 : Character2
    {
        private void Start()
        {
            Attack();
            Move();
            Idle();
        }

        public void Attack() { }

    }

    public class Npc2 : Character2
    {
        private void Start()
        {
            Move();
            Idle();
        }
    }
    // 기본적으로 Move와Idle만 가지고 있고 필요한 기능은 각 클래스에 정의 한다.
    // 여기서 몬스터가 있다면 Attack이 있을 것이다.
    // 그러면 몬스터에서도 Attack를 구현해야 한다. 이것은 중복 코드!!
}
