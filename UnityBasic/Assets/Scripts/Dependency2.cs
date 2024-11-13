using UnityEngine;

public class Dependency2 : MonoBehaviour
{
    public enum AttackType
    {
        BaseAttack,SpecialAttack,MaginAttack
    }

    AttackType attackType;

    private void Start()
    {
        attackType = AttackType.BaseAttack;
        Attack();
    }

    public void Attack()
    {
        switch (attackType)
        {
            case AttackType.BaseAttack: BaseAttack(); break;
            case AttackType.SpecialAttack: SpecialAttack(); break;
            case AttackType.MaginAttack: MagicAttack(); break;
        }
    }

    public void BaseAttack() { Debug.Log("BaseAttack"); }
    public void SpecialAttack() { Debug.Log("SpecialAttack"); }
    public void MagicAttack() { Debug.Log("Magic Attack"); }
}
