using UnityEngine;

using System.Collections;



/// <summary>

/// Third person camera.

/// </summary>

public class CameraFollow : MonoBehaviour
{
    Animator animator = null;
    void Start()
    {
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        animator.SetBool("Run", true);
    }
}