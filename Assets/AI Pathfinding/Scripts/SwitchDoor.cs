using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDoor : MonoBehaviour
{
    [SerializeField] private GameObject door;

    //private float closePos = 0;
    private float openPos = -2.1f;

    public void OnTriggerEnter(Collider collider)
    {
        Debug.Log("collision");
        StartCoroutine(OpenDoor());
        
    }

    private void Update()
    {
        
        //StartCoroutine(OpenDoor());
        
    }


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
