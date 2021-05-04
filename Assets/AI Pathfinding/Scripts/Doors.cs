using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    [Header("Red Doors")]
    [SerializeField] private List<GameObject> redDoors; 

    public bool redDoorsOpen = false;

    private float closePos;
    private float openPos;

    // Start is called before the first frame update
    void Start()
    {
        redDoorsOpen = false;
        closePos = gameObject.transform.position.y;
        openPos = transform.position.y - 2.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (redDoorsOpen) // need to put another condition like a counter here to stop it happening every frame.
        {
            foreach (GameObject door in redDoors)
            {
                // not sure why but the door is moving below the ground plane & below the doors container.
                // maybe need to set the position of each door in the loop first? and then move it from that position?
                door.gameObject.transform.position = new Vector3(door.gameObject.transform.position.x, Mathf.Lerp(door.gameObject.transform.position.y, (door.gameObject.transform.position.y - 2.1f), 0.005f), door.gameObject.transform.position.z);
            }
        }
        /*else if (!redDoorsOpen)
        {
            foreach (GameObject door in redDoors)
            {
                door.gameObject.transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, (transform.position.y + 2.1f), 0.005f), transform.position.z);
            }
        }*/
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
