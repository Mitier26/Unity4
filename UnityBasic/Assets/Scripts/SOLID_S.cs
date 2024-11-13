using UnityEngine;

public class SOLID_S : MonoBehaviour
{
    public class Player_O
    {
        public void Attack()
        {

        }

        public void Move()
        {

        }

        public void Idle()
        {

        }
    }

    // 위에 있는 것이 기본 모습
    // 메서드마다 각자의 역활을 하고 있어 S 원칙에 맞다
    // 하지만, 하나의 메서드 마다 300줄 이상의 코드가 있다면 가독성이 떨어 진다.
    // 이때 메서드를 클래스로 만들어 외부로 빼는 것이 코드의 유지 보수에 좋다.
    public class Player
    {
        PlayerAttack playerAttack;
        PlayerMove playerMove;
        PlayerIdle PlayerIdle;

        public void Attack()
        {
            playerAttack.Attack();
        }

        public void Move() 
        {
            playerMove.Move(); 
        }

        public void Idle() 
        {
            PlayerIdle.Idle(); 
        }
    }

    public class PlayerAttack
    {
        public void Attack() { }
    }

    public class PlayerMove
    {
        public void Move() { }
    }

    public class PlayerIdle
    {
        public void Idle() { }
    }

    //--------------------------------------------------------------------
    
    public class Player_S2_1
    {
        public void Attack(bool isAttakc)
        {
            if(isAttakc)
            {
                // 공격
            }
            else
            {
                // 다른 것
            }
        }
        // bool로 인해 2가지의 책임을 가지고 있다.
        // 코드의 내용이 짧다면 그냥 해도 상관은 없지만...
    }

    public class Player_S2_2
    {
        public void Attack() { }
        public void NonAttack() { }

        // 이렇게 하나의 메서드가 하나의 책임을 하는 것이 좋다.
    }
}
