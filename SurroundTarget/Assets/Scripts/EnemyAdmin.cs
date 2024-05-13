using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAdmin : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform target;
    [SerializeField] private float distToAway = 3f;

    private List<Enemy> enemyList = new List<Enemy>();

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            Vector3 position = new Vector3(Random.Range(-14f, 14f), 1, Random.Range(-14f, 14f));
            GameObject clone = Instantiate(enemyPrefab, position, Quaternion.identity);

            enemyList.Add(clone.GetComponent<Enemy>());
        }

        if(Input.GetKeyDown("1"))
        {
            MoveToTarget();
        }
        else if (Input.GetKeyDown("2"))
        {
            SurroundToTarget();
        }
    }


    public void MoveToTarget()
    {
        for(int i = 0;  i < enemyList.Count; i++)
        {
            enemyList[i].MoveTo(target.position);
        }
    }

    public void SurroundToTarget()
    {
        for(int i = 0; i <enemyList.Count; i++)
        {
            float angle = 360 * i / enemyList.Count;
            angle = Mathf.PI * angle / 180;
            float x = target.position.x + Mathf.Cos(angle) * distToAway;
            float z = target.position.z + Mathf.Sin(angle) * distToAway;

            enemyList[i].MoveTo(new Vector3(x, target.position.y, z));
        }
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < enemyList.Count; i++)
        {
            float angle = 360 * i / enemyList.Count;
            angle = Mathf.PI * angle / 180;
            float x = target.position.x + Mathf.Cos(angle) * distToAway;
            float z = target.position.z + Mathf.Sin(angle) * distToAway;

            Gizmos.color = Color.green;
            Gizmos.DrawSphere(new Vector3(x, target.position.y, z), 0.5f);
        }
    }

}
