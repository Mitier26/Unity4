using UnityEngine;

public class OOP1 : MonoBehaviour
{
    // 캡슐화, 정보은닉
    // 관련있는 데이터와 메소드로 캑체를 만들고 객체 밖에서 알아야 할 필요가 없는 내부 멤버를 숨기는 것을 의미

    // 원칙
    // 특별한 이유가 없으면 필드를 절대 public 으로 선언하지 않는다.
    // 접근이 필요한 경우 접근자/설정자 메서드를 만들어 외부에서 접극하는 경로를 만든다.
    int num = 10;

    public int GetNum()
    {
        return num;
    }

    public void SetNum(int value)
    {
        num = value;
    }

    // int num를 public으로 하면 함수가 필요 없다.
    // 하지만, 프로퍼티로 만들었을 때 좋은 점이 있다.
    // 값을 변경할 때 유효성 검사등 오류 검사를 할 수 있다.

    int num2 = 10;

    public int Num2
    {
        get { return num2; }
        set { num2 = value; }
    }

    // 자동 부여 프로퍼티
    public int Num3 { get; set; }
}
