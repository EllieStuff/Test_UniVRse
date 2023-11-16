using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] bool moveEnabled = true;

    Rigidbody rb;

    public bool MoveEnabled { get { return moveEnabled; } set { moveEnabled = value; } }
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    public void Move(Vector3 _moveDirection)
    {
        if (!moveEnabled) return;

        rb.MovePosition(rb.position + _moveDirection * moveSpeed * Time.deltaTime);
    }


}
