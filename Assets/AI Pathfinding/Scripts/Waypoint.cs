
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Vector3 Position => transform.position;

   

    //Implement this OnDrawGizmos if you want to draw gizmos that are also pickable and always drawn
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.1f);
    }
}
