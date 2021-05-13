using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Agent : MonoBehaviour
{
    private NavMeshAgent agent;
    private Waypoint[] waypoints;

    

    //Will give us a random waypoint in the array as a variable everytime I access it
    private Waypoint RandomPoint => waypoints[Random.Range(0, waypoints.Length)];

    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        //FindObjectsOfType gets every instance of this componant in the scene
        waypoints = FindObjectsOfType<Waypoint>();

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

            /*
            if (doors.redDoorsOpen == true)
                doors.redDoorsOpen = false;
            else
                doors.redDoorsOpen = true;
            */
        }

    }
}

