using UnityEngine;

public class FactoryTurtle : FactoryBase
{
    [SerializeField] GameObject turtle;
    public override void CreateMonster()
    {
        Instantiate(turtle);
    }
}
