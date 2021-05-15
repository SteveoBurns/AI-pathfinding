using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the animation for each character
/// </summary>
public class Animate : MonoBehaviour
{
    [SerializeField] private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        // Gets the animator for the character
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Sets the xInput float variable for the animator to the characters x position
        animator.SetFloat("xInput", transform.position.x);
    }
}
