using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AgentThreat : MonoBehaviour
{
    private NavMeshAgent agent;
    private ThreatWaypoint[] waypoints;



    //Will give us a random waypoint in the array as a variable everytime I access it
    private ThreatWaypoint RandomPoint => waypoints[Random.Range(0, waypoints.Length)];

    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();

        //FindObjectsOfType gets every instance of this componant in the scene
        waypoints = FindObjectsOfType<ThreatWaypoint>();

        //Tell the agent to move to a random position in the scene waypoints
        agent.SetDestination(RandomPoint.Position);
    }

    // Update is called once per frame
    void Update()
    {
        //Has the agent reached its position?
        if (!agent.pathPending && agent.remainingDistance < 0.1f)
        {
            //Tell the agent to move to a random position in the scene waypoints
            agent.SetDestination(RandomPoint.Position);

        }

    }
}
