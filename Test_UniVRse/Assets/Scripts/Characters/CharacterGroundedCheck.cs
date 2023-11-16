using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGroundedCheck : MonoBehaviour
{
    [SerializeField] float touchFloorThreshold = 0.5f;
    [SerializeField] LayerMask groundMask;

    bool isGrounded = false;
    public bool IsGrounded { get { return isGrounded; } }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position, touchFloorThreshold, groundMask);
    }
}
