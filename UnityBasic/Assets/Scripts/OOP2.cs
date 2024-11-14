using UnityEngine;

public class OOP2 : MonoBehaviour
{
    // 객체지향
    // 다형성
    // 객체가 다양한 형태를 가지루 수 있음을 의미
    // 상속받아서 만들어진 파생클래스를 통해 다형성을 보여줄 수 있다.

    public class Monster
    {
        public virtual void OnDamaged() { }
    }

    public class Orc : Monster
    {
       public override void OnDamaged() 
       {
            Debug.Log("OrcOnDamaged");
       }
    }

    public class Ogre : Monster
    {
        public override void OnDamaged()
        {
            Debug.Log("OgreOnDamaged");
        }
    }

    public class Player
    {
        public void Attack(Monster monster)
        {
            monster.OnDamaged();
        }
    }

    public void Start()
    {
        Monster orc = new Orc();
        Monster ogre = new Ogre();
        Player player = new Player();

        // 각 몬스터의 OnDamaged를 실행할 수 도 있지만 몬스터가 많아지면 문제가 있다.
        // 이때 부모의 함수를 오버라이드 한 것을 사용할 수 있다.

        player.Attack( orc );
        player.Attack( ogre );
    }
}
