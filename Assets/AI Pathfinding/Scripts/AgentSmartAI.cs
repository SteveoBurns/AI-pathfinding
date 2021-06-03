using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using StateMachines;

namespace SmartAI
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class AgentSmartAI : MonoBehaviour
    {
        public StateMachine stateMachine;

        public NavMeshAgent agent;
        [SerializeField] private GameObject doorSwitch;

        public Waypoint[] waypoints;

        // Start is called before the first frame update
        void Start()
        {
            agent = gameObject.GetComponent<NavMeshAgent>();

            agent.SetDestination(doorSwitch.transform.position);

            waypoints = FindObjectsOfType<Waypoint>();
        }

        public void SetDestination(Vector3 _destination)
        {
            agent.SetDestination(_destination);
        }


        // Update is called once per frame
        void Update()
        {
            if(stateMachine.currentState == States.MainPath)
            {
                if (agent.remainingDistance < 0.1f)
                {
                    stateMachine.waypointIndex += 1;
                    stateMachine.ChangeState(States.MainPath);
                }
                if (agent.isStopped)
                {
                    stateMachine.ChangeState(States.FindSwitch);
                }
            }

            
            if (!agent.pathPending && agent.remainingDistance < 0.1f)
            {



            }
        }
    }
}