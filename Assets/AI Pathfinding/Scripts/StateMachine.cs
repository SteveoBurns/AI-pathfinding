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

        [SerializeField] public States currentState = States.MainPath;

        public NavMeshAgent agent;

        public Waypoint[] waypoints;
        public List<SwitchWaypoint> switchWaypoints;
        public CollectableWaypoint[] collectableWaypoints;
        public int waypointIndex = 0;
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
        /// Might have to put used waypoints into a new []?? can use an int index maybe? that will remeber the waypoint in the [] it was up too.
        /// </summary>
        private void MainPath()
        {
            
            Waypoint currentWaypoint = waypoints[waypointIndex];
            agent.SetDestination(currentWaypoint.transform.position);

            if (!agent.pathPending &&  agent.remainingDistance < 0.01f)
            {
                currentWaypoint.gameObject.SetActive(false);
                waypointIndex += 1;
                ChangeState(States.MainPath);                
            }
            if (agent.hasPath && agent.path.status == NavMeshPathStatus.PathPartial && agent.remainingDistance <= 10)
            {
                ChangeState(States.FindSwitch);
            }
            /*
            if (!agent.pathPending && agent.remainingDistance < 0.01f && waypointIndex == 4)
            {
                SmartAI.AgentSmartAI.EndGame();
            } 
            */

            /*What is the index? 
          * set the next way point using the index.
          * if destination reached, index += 1
          * set next waypoint
          * 
          */
        }

        /// <summary>
        /// This will get the switch waypoints and test for the closest one then set that as the destination
        /// Might need a function setdestination on the agent that i can call from here?? for all states?
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


            if (!agent.pathPending && agent.remainingDistance < 0.2f)
            {
                
                ChangeState(States.MainPath);
                
                
            }

            /*get switchwaypoints
             * distance test and set closest as destination
             * when reached, switch to main path.
             */
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
            else
            {
                SmartAI.AgentSmartAI.collectablesFound = true;
                ChangeState(States.MainPath);
            }

            /* get collectable waypoints
             * cycle through all in a for loop?
             * when done switch back to main path.
             */
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
     * 
     */
}