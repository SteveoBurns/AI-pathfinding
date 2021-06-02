using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SmartAI
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class AgentSmartAI : MonoBehaviour
    {
        private NavMeshAgent agent;
        [SerializeField] private GameObject doorSwitch;

        public Waypoint[] waypoints;

        // Start is called before the first frame update
        void Start()
        {
            agent = gameObject.GetComponent<NavMeshAgent>();

            agent.SetDestination(doorSwitch.transform.position);

            waypoints = FindObjectsOfType<Waypoint>();
        }


        // Update is called once per frame
        void Update()
        {
            if (!agent.pathPending && agent.remainingDistance < 0.1f)
            {



            }
        }
    }
}