using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class BasicMove : MonoBehaviour
{
    private InputHandler m_InputHandler;
    [SerializeField] Rigidbody m_Rigidbody;
    public float speed = 5f;                            //movement speed
    public float m_RotationSpeed = 5f;
    private const float k_Epsilon = 0.001f;

    // Start is called before the first frame update
    void Awake()
    {
        m_InputHandler = GetComponent<InputHandler>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 inputVector = m_InputHandler.InputVector;

        if (inputVector.sqrMagnitude < k_Epsilon)
        {
            return;
        }

        Vector3 targetVector = new Vector3(inputVector.x, 0, inputVector.y).normalized;
        Vector3 newPosition = transform.position + targetVector * Time.fixedDeltaTime * speed;

        m_Rigidbody.MovePosition(newPosition);
        RotateTowardMovementVector(targetVector);
    }

    private void RotateTowardMovementVector(Vector3 movement)
    {
        Quaternion targetRotation = Quaternion.LookRotation(movement);
        Quaternion newRotation = Quaternion.Slerp(transform.rotation, targetRotation, m_RotationSpeed * Time.fixedDeltaTime);

        m_Rigidbody.MoveRotation(newRotation);
    }
}


