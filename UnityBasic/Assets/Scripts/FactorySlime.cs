using UnityEngine;

public class FactorySlime : FactoryBase
{
    [SerializeField] GameObject slime;

    public override void CreateMonster()
    {
        Instantiate(slime);
    }
}
