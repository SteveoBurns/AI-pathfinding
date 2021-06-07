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

            if(stateMachine.currentState == States.FindSwitch && stateMachine.waypointIndex == 3 && agent.remainingDistance <= 5 && !collectablesFound)
            {
                stateMachine.ChangeState(States.FindCollectable); 
            }            
        }

        public static void EndGame()
        {
            Debug.Log("End Game");
        }
    }
}