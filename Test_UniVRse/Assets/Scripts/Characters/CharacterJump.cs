using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterJump : MonoBehaviour
{
    [SerializeField] CharacterGroundedCheck playerGroundedCheck;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] bool jumpEnabled = true;

    Rigidbody rb;

    public bool JumpEnabled { get { return jumpEnabled; } set { jumpEnabled = value; } }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    bool CanJump()
    {
        if (!jumpEnabled) return false;
        if(playerGroundedCheck == null)
        {
            Debug.LogWarning("PlayerGroundedCheck component not found. Player will always be able to jump.");
            return true;
        }

        return playerGroundedCheck.IsGrounded;
    }

    public void Jump()
    {
        if (!CanJump()) return;

        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

    }


}
