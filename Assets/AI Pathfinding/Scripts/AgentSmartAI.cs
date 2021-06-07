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

        // Start is called before the first frame update
        void Start()
        {
            agent = gameObject.GetComponent<NavMeshAgent>();

            stateMachine.Start(agent);

            collectablesFound = false;
        }

        // Update is called once per frame
        void Update()
        {
            stateMachine.Update();

            MainPathTest();
            SwitchTest();

            /*
            if(stateMachine.currentState == States.FindSwitch && stateMachine.waypointIndex == 3 && agent.remainingDistance <= 5 && !collectablesFound)
            {
                stateMachine.ChangeState(States.FindCollectable); 
            } */           
        }

        public static void EndGame()
        {
            Debug.Log("End Game");
        }

        public void SwitchTest()
        {
            if (stateMachine.currentState == States.FindSwitch)
            {
                if (!agent.pathPending && agent.remainingDistance < 0.2f)
                {

                    stateMachine.ChangeState(States.MainPath);
                }
            }
        }

        public void MainPathTest()
        {
            if (stateMachine.currentState == States.MainPath)
            {
                if (!agent.pathPending && agent.remainingDistance < 0.1f)
                {
                    //stateMachine.currentWaypoint.gameObject.SetActive(false);
                    stateMachine.waypointIndex += 1;
                    stateMachine.ChangeState(States.MainPath);
                }
                if (agent.hasPath && agent.path.status == NavMeshPathStatus.PathPartial && agent.remainingDistance <= 10)
                {
                    stateMachine.ChangeState(States.FindSwitch);
                }
                if (agent.hasPath && agent.pathStatus == NavMeshPathStatus.PathInvalid)
                {
                    stateMachine.ChangeState(States.FindSwitch);
                }
                /*
                if (!agent.pathPending && agent.remainingDistance < 0.01f && waypointIndex == 3)
                {
                    SmartAI.AgentSmartAI.EndGame();
                } 
                */
            }
        }
    }
}