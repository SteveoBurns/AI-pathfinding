using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum States
{
    MainPath,
    FindSwitch,
    FindCollectable

}


public class StateMachine : MonoBehaviour
{
    public Waypoint[] waypoints;
    public SwitchWaypoint[] switchWaypoints;
    public CollectableWaypoint[] collectableWaypoints;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
