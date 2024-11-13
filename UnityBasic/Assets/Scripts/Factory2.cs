using UnityEngine;
using UnityEngine.UI;

public class Factory2 : MonoBehaviour
{
    [SerializeField] FactoryBase factorySlime;
    [SerializeField] FactoryBase factoryTurtle;

    [SerializeField] Button button1;
    [SerializeField] Button button2;

    private void Start()
    {
        button1.onClick.AddListener(() =>
        {
            factorySlime.CreateMonster();
        });

        button2.onClick.AddListener(() =>
        {
            factoryTurtle.CreateMonster();
        });
    }
}
