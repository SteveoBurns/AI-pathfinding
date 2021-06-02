using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDoor : MonoBehaviour
{
    [Header("Door to Open")]
    [SerializeField] private GameObject door;
    
    private float openPos = -2.1f;


    public void OnTriggerEnter(Collider collider)
    {
        StartCoroutine(OpenDoor());       
    }
        

    /// <summary>
    /// This handles the opening of the corresponding door.
    /// </summary>
    /// <returns></returns>
    public IEnumerator OpenDoor()
    {        
        while (door.transform.position.y != openPos)
        {
            Vector3 doorPos = new Vector3(door.gameObject.transform.position.x, door.gameObject.transform.position.y, door.gameObject.transform.position.z);

            Vector3 doorPos2 = new Vector3(doorPos.x,
                Mathf.Lerp(doorPos.y, openPos, 0.1f),
                doorPos.z);

            door.transform.position = doorPos2;
            yield return new WaitForFixedUpdate();
        }
    }
}
/*Journal
 * This took a bit to work out that I should put the open door function into a coroutine, and even then, that i should put it into a while loop.
 * But I got it in the end and now it works.
 * 
 * Also, that I had to use on trigger enter vs on collision enter. Im not sure why oncollision enter didn't work, but trigger does, so all G!
 * 
 * 
 */
