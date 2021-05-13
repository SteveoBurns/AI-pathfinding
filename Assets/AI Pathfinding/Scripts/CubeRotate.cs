using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotate : MonoBehaviour
{
    private Vector3 yAxis = new Vector3(0, 1, 0);

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.AngleAxis(1, yAxis) * transform.rotation;
    }
}
