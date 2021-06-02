using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AgentSmartAI : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private GameObject doorSwitch;

    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();

        agent.SetDestination(doorSwitch.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Character collided");
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.1f)
        {

            

        }
    }
}
