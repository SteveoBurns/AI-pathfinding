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
        public static bool collectablesFound = false;
        [SerializeField] private GameObject endPanel;

        // Start is called before the first frame update
        void Start()
        {
            agent = gameObject.GetComponent<NavMeshAgent>();

            stateMachine.Start(agent);

            collectablesFound = false;
            endPanel.SetActive(false);
            Time.timeScale = 1;
        }

        // Update is called once per frame
        void Update()
        {
            stateMachine.Update();

            MainPathTest();
            SwitchTest();                
        }

        public void EndGame()
        {
            endPanel.SetActive(true);
            Time.timeScale = 0;
            Debug.Log("End Game");
        }

        /// <summary>
        /// Handles switching states from the FindSwitches state.
        /// </summary>
        public void SwitchTest()
        {
            if (stateMachine.currentState == States.FindSwitch)
            {
                if (!agent.pathPending && agent.remainingDistance < 0.2f)
                {

                    stateMachine.ChangeState(States.MainPath);
                }

                if (stateMachine.waypointIndex == 4 && agent.remainingDistance <= 5 && !collectablesFound)
                {
                    stateMachine.ChangeState(States.FindCollectable);
                }
            }
        }

        /// <summary>
        /// Handles switching states when in the Main Path state.
        /// </summary>
        public void MainPathTest()
        {
            if (stateMachine.currentState == States.MainPath)
            {
                // Once reached a waypoint run Main path again to go towards the next waypoint in main path.
                if (!agent.pathPending && agent.remainingDistance < 0.1f)
                {                    
                    stateMachine.waypointIndex += 1;
                    stateMachine.ChangeState(States.MainPath);
                }
                // If path is blocked change to find switch stat
                if (agent.hasPath && agent.path.status == NavMeshPathStatus.PathPartial && agent.remainingDistance <= 10)
                {
                    stateMachine.ChangeState(States.FindSwitch);
                }
                // If path is invalid, switch to find switch state.
                if (agent.hasPath && agent.pathStatus == NavMeshPathStatus.PathInvalid)
                {
                    stateMachine.ChangeState(States.FindSwitch);
                }
                // Finish game when reaching the last waypoint.
                if (!agent.pathPending && agent.remainingDistance < 0.01f && stateMachine.waypointIndex == 5)
                {
                    EndGame();
                } 
                
            }
        }
    }
}