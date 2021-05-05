using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Doors : MonoBehaviour
{
    [Header("Red Doors")]
    [SerializeField] private List<GameObject> redDoors;

    [Header("Green Doors")]
    [SerializeField] private List<GameObject> greenDoors;
    
    

    public bool redDoorsOpen = false;

    private float closePos = 0;
    private float openPos = -2.1f;



    // Start is called before the first frame update
    void Start()
    {
        redDoorsOpen = false;
        //closePos = gameObject.transform.position.y;
        //openPos = transform.position.y - 2.1f;
    }



    // Update is called once per frame
    void Update()
    {
        if (redDoorsOpen) // need to put another condition like a counter here to stop it happening every frame.
        {
            // Open all red doors
            foreach (GameObject door in redDoors)
            {
                Vector3 doorPos2;
                Vector3 doorPos = new Vector3(door.gameObject.transform.position.x, door.gameObject.transform.position.y, door.gameObject.transform.position.z);
                
                
                doorPos2 = new Vector3(doorPos.x, 
                    Mathf.Lerp(doorPos.y, openPos, 0.005f),
                    doorPos.z);


                door.transform.position = doorPos2;
            }

            //Close all green doors when red doors are open
            foreach (GameObject door in greenDoors)
            {
                Vector3 doorPos2;
                Vector3 doorPos = new Vector3(door.gameObject.transform.position.x, door.gameObject.transform.position.y, door.gameObject.transform.position.z);


                doorPos2 = new Vector3(doorPos.x,
                    Mathf.Lerp(doorPos.y, closePos, 0.005f),
                    doorPos.z);


                door.transform.position = doorPos2;
            }
        }
        else if (!redDoorsOpen)
        {
            // Close all red doors
            foreach (GameObject door in redDoors)
            {
                Vector3 doorPos2;
                Vector3 doorPos = new Vector3(door.gameObject.transform.position.x, door.gameObject.transform.position.y, door.gameObject.transform.position.z);


                doorPos2 = new Vector3(doorPos.x,
                    Mathf.Lerp(doorPos.y, closePos, 0.005f),
                    doorPos.z);


                door.transform.position = doorPos2;
            }

            // Open all green doors
            foreach (GameObject door in greenDoors)
            {
                Vector3 doorPos2;
                Vector3 doorPos = new Vector3(door.gameObject.transform.position.x, door.gameObject.transform.position.y, door.gameObject.transform.position.z);


                doorPos2 = new Vector3(doorPos.x,
                    Mathf.Lerp(doorPos.y, openPos, 0.005f),
                    doorPos.z);


                door.transform.position = doorPos2;
            }
        }
    }

    public void OpenDoors()
    {
       transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, openPos, 0.005f), transform.position.z);
    }
    public void CloseDoors()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, closePos, 0.005f), transform.position.z);
    }

    


    
}
