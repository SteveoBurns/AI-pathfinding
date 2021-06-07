using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SmartAI;
using UnityEngine.AI;

namespace StateMachines
{
    public enum States
    {
        MainPath,
        FindSwitch,
        FindCollectable

    }

    // The delegate that dictates what the functions for each state will look like.
    public delegate void StateDelegate();

    [System.Serializable]
    public class StateMachine 
    {
        private Dictionary<States, StateDelegate> states = new Dictionary<States, StateDelegate>();

        public AgentSmartAI agentSmartAI;

        [SerializeField] public States currentState = States.MainPath;

        public NavMeshAgent agent;
        [Header("Waypoints")]
        public Waypoint[] waypoints;
        public List<SwitchWaypoint> switchWaypoints;
        public CollectableWaypoint[] collectableWaypoints;
        [Header("Waypoint Indexes")]
        public int waypointIndex = 1;
        public int collectableIndex = 0;
        

        // This is used to change the state from anywhere within the code that has reference to the state machine.
        public void ChangeState(States _newState)
        {
            if (_newState != currentState)
                currentState = _newState;
        }

        public void Start(NavMeshAgent _agent)
        {
            agent = _agent;

            states.Add(States.MainPath, MainPath);
            states.Add(States.FindSwitch, FindSwitch);
            states.Add(States.FindCollectable, FindCollectable);

            collectableIndex = Mathf.Clamp(collectableIndex, 0, 3);
        }

        // Update is called once per frame in AgentSmartAI Update.
        public void Update()
        {
            // These 2 lines are what actaully runs the state machine. It works by attempting to retrive the relevent function for the current state
            //then run the function if it successfully finds it.
            if (states.TryGetValue(currentState, out StateDelegate state))
                state.Invoke();
            else
                Debug.LogError($"No state function set for state {currentState}.");

            
        }

        /// <summary>
        /// This will get the next waypoint for the main path and set the agents destination as that.
        /// </summary>
        private void MainPath()
        {
            if (waypointIndex <= 4)
            {
                Waypoint currentWaypoint = waypoints[waypointIndex -1];

                agent.SetDestination(currentWaypoint.transform.position);

            }
            else
            {
                agentSmartAI.EndGame();
            }            
        }

        /// <summary>
        /// This will get the switch waypoints and test for the closest one then set that as the destination
        /// </summary>
        private void FindSwitch()
        {
            float shortestDistance = Mathf.Infinity;
            SwitchWaypoint closestPoint = null;
            foreach (SwitchWaypoint waypoint in switchWaypoints)
            {
                float distanceToSwitch = Vector3.Distance(agent.transform.position, waypoint.transform.position);
                if (distanceToSwitch < shortestDistance)
                {
                    shortestDistance = distanceToSwitch;
                    closestPoint = waypoint;
                }
            }

            agent.SetDestination(closestPoint.transform.position);

        }

        /// <summary>
        /// This will find all collectable waypoints and work through the list then switch back to the main path.
        /// </summary>
        private void FindCollectable()
        {
            if (collectableIndex <= 2)
            {
                CollectableWaypoint waypoint = collectableWaypoints[collectableIndex];
                agent.SetDestination(waypoint.transform.position);

                if (!agent.pathPending && agent.remainingDistance < 0.01f)
                {
                    collectableIndex += 1;
                    ChangeState(States.FindCollectable);

                    waypoint.gameObject.SetActive(false);
                }
            }
            // Once all collecatbles are found
            else
            {
                SmartAI.AgentSmartAI.collectablesFound = true;
                waypointIndex -= 2; // Have to set this back so the agent can follow the main path again properly.
                ChangeState(States.MainPath);
            }

        }
    }
    /*Journal
     * Could I just put the agent in this script?? 
     * No, I'll leave the tests in the agent class and just change states from there.
     * 
     * Actually, I could make the argument in each function a navmeshagent, then when calling it just reference "this".
     * Nope, cause I'm calling the ChangeStates function, not the functions in the dictionary, duh!
     * 
     * 7/6 - Started having trouble with the agent stopping next to the second main waypoint and not going after the next one.
     * Code was all working fine before that? Could be an issue with the navMesh maybe??
     * Fix - Still not exactly sure what was happening with the agent not recognising the last way point? I put another one in before the last door
     * and the agent then did what it was meant too and switched into the collectable state.
     * 
     * I had to minus from the waypoint index after finding all the collectables so as to not get into the same issue with the agent not recognising the last waypoint, it 
     * not goes to the second last one then goes for the switch and then finally the last waypoint.
     * 
     */
}