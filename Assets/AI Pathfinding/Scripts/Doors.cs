using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Doors : MonoBehaviour
{
    [Header("Red Doors")]
    [SerializeField] private List<GameObject> redDoors;

    [Header("Green Doors")]
    [SerializeField] private List<GameObject> greenDoors;
    
    

    public bool redDoorsOpen = false;

    private float closePos = 0;
    private float openPos = -2.1f;

    private float doorTimer = 0;
    [SerializeField] private float doorTimerLength = 10;


    // Start is called before the first frame update
    void Start()
    {

        redDoorsOpen = false;
        
    }



    // Update is called once per frame
    void Update()
    {
        // Timer for the doors to be automated
        #region Door Timer
        if (doorTimer < doorTimerLength)
            doorTimer += Time.deltaTime;
        else
        {
            redDoorsOpen = !redDoorsOpen;
            doorTimer = 0;
        }    
        #endregion


        if (redDoorsOpen) 
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
    
    


    
}
