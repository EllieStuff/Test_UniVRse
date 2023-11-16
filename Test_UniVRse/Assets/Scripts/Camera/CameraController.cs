using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float camSensitivity = 100f;
    [SerializeField] float xMaxRotation = 90f;
    [SerializeField] bool invertXAxis = false, invertYAxis = true;
    
    Transform playerTransform;
    float xCurrRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouseMoveAxis = GetMouseMoveAxis();
        SetCameraRotation(mouseMoveAxis);
    }


    Vector2 GetMouseMoveAxis()
    {
        float mouseMoveSpeed = camSensitivity * Time.deltaTime;
        return new Vector2(Input.GetAxis("Mouse X") * mouseMoveSpeed, Input.GetAxis("Mouse Y") * mouseMoveSpeed);
    }

    void SetCameraRotation(Vector2 _mouseMoveAxis)
    {
        xCurrRotation += invertYAxis ? -_mouseMoveAxis.y : _mouseMoveAxis.y;
        xCurrRotation = Mathf.Clamp(xCurrRotation, -xMaxRotation, xMaxRotation);

        transform.localRotation = Quaternion.Euler(xCurrRotation, 0f, 0f);
        playerTransform.Rotate(Vector3.up * (invertXAxis ? -_mouseMoveAxis.x : _mouseMoveAxis.x));
    }

}
