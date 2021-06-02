using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SmartAI;

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

    public class StateMachine 
    {
        private Dictionary<States, StateDelegate> states = new Dictionary<States, StateDelegate>();

        [SerializeField] private States currentState = States.MainPath;

        public Waypoint[] waypoints;
        public SwitchWaypoint[] switchWaypoints;
        public CollectableWaypoint[] collectableWaypoints;

        private int waypointIndex = 0;

        // This is used to change the state from anywhere within the code that has reference to the state machine.
        public void ChangeState(States _newState)
        {
            if (_newState != currentState)
                currentState = _newState;
        }


        // Start is called before the first frame update
        void Start()
        {
            
            states.Add(States.MainPath, MainPath);
            states.Add(States.FindSwitch, FindSwitch );
            states.Add(States.FindCollectable, FindCollectable);

            // How do I find the waypoints if this class can't be in the scene?
            
        }

        // Update is called once per frame
        void Update()
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
     * 
     * 
     */
}