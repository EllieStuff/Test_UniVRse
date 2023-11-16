using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterJump))]
public class PlayerController : CharacterController
{
    CharacterJump characterJump;


    protected override void GetAllComponents()
    {
        base.GetAllComponents();

        characterJump = GetComponent<CharacterJump>();
    }


    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }


    void Move()
    {
        Vector2 moveAxis = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 moveDirection = transform.right * moveAxis.x + transform.forward * moveAxis.y;
        characterMovement.Move(moveDirection);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
            characterJump.Jump();
    }

}
