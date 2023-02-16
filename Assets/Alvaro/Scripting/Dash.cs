using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [Header("Dashing")]
    [SerializeField] private float _dashingVel = 14f;
    [SerializeField] private float _dashingTime = 0.5f;
    private bool isDashing;
    private bool _canDash=true;

    private Rigidbody rb;
    private Vector3 dir;


    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && _canDash)
        {
            isDashing = true;
            _canDash= false;
            dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            if(dir == Vector3.zero)
            {
                dir = new Vector3(transform.localScale.x, 0, 0);
            }
            StartCoroutine(stopDashing());
        }

        if (isDashing)
        {
            print("Ho");
            rb.velocity=dir.normalized*_dashingVel;
            return;
        }
    }

    private IEnumerator stopDashing()
    {
        print("Mo");
        yield return new WaitForSeconds(_dashingTime);
        isDashing= false;
        _canDash = true;
    }

    //private void FixedUpdate()
    //{
    //    if(isDashing==true)
    //    {
    //        Dashing();
    //    }
    //}

    //private void Dashing()
    //{
    //    print("Hola");
    //    rb.AddForce(transform.forward * dashSpeed, ForceMode.Impulse);
    //    isDashing = false;
    //    print("Adios");
    //}
}
