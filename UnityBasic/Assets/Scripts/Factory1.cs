using UnityEngine;

public class Factory1 : MonoBehaviour
{
    [SerializeField] GameObject Slime;
    [SerializeField] GameObject Turtle;

    enum Monster
    {
        Slime, Turtle,
    }

    void CreateMonster(Monster monster)
    {
        switch (monster)
        {
            case Monster.Slime:
                Instantiate(Slime);
                break;
            case Monster.Turtle:
                Instantiate(Turtle);
                break;
        }
    }

    private void Start()
    {
        CreateMonster(Monster.Slime);
        CreateMonster(Monster.Turtle);
    }

    // 현재 코드는 몬스터가 추가 될 때 마다 추가해야 하는 부분이 많아 진다.
    // 간단한 게임에서는 사용해도 무방하지만 규모가 크면 팩토리 패턴을 사용하는 것이 좋다.
}
