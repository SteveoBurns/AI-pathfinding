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

        

        // Start is called before the first frame update
        void Start()
        {
            agent = gameObject.GetComponent<NavMeshAgent>();

            stateMachine.Start(agent);
        }

        
              


        // Update is called once per frame
        void Update()
        {
            stateMachine.Update();
            
        }
    }
}