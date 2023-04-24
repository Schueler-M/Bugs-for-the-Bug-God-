using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [Header("Dashing")]
    public float _dashingVel = 14f;
    public float _dashingTime = 0.5f;
    public float _dashingCooldown = 2f;
    public float _dashingDuration = 1f;
    
    
    private bool isDashing = false;
    private bool _canDash = true;

    private Rigidbody rb;
    private Vector3 dir;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && _canDash)
        {
            isDashing = true;
            _canDash = false;
            Vector3 facingDirection = transform.forward;
            dir = facingDirection;
            //dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            //if (dir == Vector3.zero)
            //{
            //    //Vector3 facingDirection = transform.forward;
            //    dir = facingDirection;
            //}

            StartCoroutine(dash());
        }
    }

    private IEnumerator dash()
    {
        rb.velocity = dir.normalized * _dashingVel;

        yield return new WaitForSecondsRealtime(_dashingTime);

        float t = 0;
        Vector3 startVelocity = rb.velocity;

        while (t < 1)
        {
            t += Time.deltaTime / _dashingDuration;
            rb.velocity = Vector3.Lerp(startVelocity, Vector3.zero, t);
            yield return null;
        }

        isDashing = false;
        _canDash = true;
    }
}


