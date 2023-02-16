using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class BasicMove : MonoBehaviour
{
    private InputHandler m_InputHandler;
    Rigidbody m_Rigidbody;
    public float speed = 5f;
    public float rotationSpeed = 5f;

    // Start is called before the first frame update
    void Awake()
    {
        m_InputHandler= GetComponent<InputHandler>();
    }

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetVector = new Vector3(m_InputHandler.InputVector.x, 0, m_InputHandler.InputVector.y).normalized;

        if (targetVector == Vector3.zero)
        {
            return;
        }

        m_Rigidbody.MovePosition(transform.position + targetVector * Time.fixedDeltaTime * speed);

        RotateTowardMovementVector(targetVector);


    }

    private void RotateTowardMovementVector(Vector3 movement)
    {
        Quaternion targetRotation = Quaternion.LookRotation(movement);
        targetRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 360 * Time.fixedDeltaTime);

        m_Rigidbody.MoveRotation(targetRotation);

    }
}
