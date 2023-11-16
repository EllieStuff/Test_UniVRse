using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMovement))]
public class CharacterController : MonoBehaviour
{
    protected CharacterMovement characterMovement;

    // Start is called before the first frame update
    void Start()
    {
        GetAllComponents();
    }

    protected virtual void GetAllComponents()
    {
        characterMovement = GetComponent<CharacterMovement>();
    }

    
}
