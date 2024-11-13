using UnityEngine;

public class Dependency1 : MonoBehaviour
{
    public void Start()
    {
        
    }

    public void Attack()
    {
        BaseAttack();
        // Attack가 실행하기 위해서는 BaseAttack가 필요하다
    }

    public void BaseAttack() { Debug.Log("공격"); }
}
