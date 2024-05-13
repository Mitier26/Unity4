using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        GetComponent<MeshRenderer>().material.color = Color.red;

        navMeshAgent = GetComponent<NavMeshAgent>();    
    }

    public void MoveTo(Vector3 position)
    {
        navMeshAgent.SetDestination(position);
    }
}
