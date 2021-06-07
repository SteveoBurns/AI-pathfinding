using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Rotates the cubes on the waypoints
/// </summary>
public class CubeRotate : MonoBehaviour
{
    public float anglePerFrame = .5f;
    private Vector3 yAxis = new Vector3(0, 1, 0);

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.AngleAxis(anglePerFrame, yAxis) * transform.rotation;
        
    }
}
