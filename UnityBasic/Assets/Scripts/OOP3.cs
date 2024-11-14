using UnityEngine;

public class OOP3 : MonoBehaviour
{
    // 객체지향

    // 상속

    // 다중 상속 : 유니티에서는 다중 상속을 할 수 없다.

    // 추상 클래스
    // virtual 과 abstract 의 차이
    // virtual은 자식에서 구현하지 않아도 작동하지만
    // abstract는 자식에서 '반드시 구현' 해야 한다.
    // abstract가 있으면 인스턴스로 만들 수 없다.
    // 타입으로는 사용할 수 있지만 생성자는 불가능

    // 인터페이스
    // 추상클레스를 대체할 수 있다.
    // 다중 상속이 가능하다.
    // 인스턴스로 생성 할 수 없다.
    public interface IAttack
    {
        public void Attack();
    }
}
