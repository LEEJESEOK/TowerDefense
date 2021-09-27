using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Tower 추적 > 이동
public class Drone : MonoBehaviour
{
    public Transform target;

    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Tower").transform;

        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(target.position);
    }

    // Tower(target)
    // NavMeshAgent 컴포넌트
    // NavMeshAgent.SetDestination

    // Update is called once per frame
    void Update()
    {
    }
}
