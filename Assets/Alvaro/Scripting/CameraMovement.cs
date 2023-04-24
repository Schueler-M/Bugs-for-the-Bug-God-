using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 12f, -7f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform target;
    [SerializeField] private Camera myCamera;
    [SerializeField] private float zoomSpeed = 0.1f;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

    public void Zoom(InputAction.CallbackContext context)
    {
        float value = context.ReadValue<Vector2>().y;
        float newFieldOfView = myCamera.fieldOfView - (value * zoomSpeed);
        myCamera.fieldOfView = Mathf.Clamp(newFieldOfView, 10f, 100f);
    }



}
