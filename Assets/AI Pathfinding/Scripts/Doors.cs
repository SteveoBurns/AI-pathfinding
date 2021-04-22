using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public bool isOpen = false;

    private float closePos;
    private float openPos;

    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
        closePos = gameObject.transform.position.y;
        openPos = transform.position.y - 2.1f;
    }

    // Update is called once per frame
    void Update()
    {
        OpenDoors();
    }

    public void OpenDoors()
    {
       transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, openPos, 0.005f), transform.position.z);
    }
}
