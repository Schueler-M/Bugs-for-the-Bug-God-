using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class spider : Player
{
    [Header("Movement")]
    public int curSpeed = 8;
    float m_RotationSpeed = 6f;

    [Header("Dash")]
    float _dashingVel = 9f;
    float _dashingTime = 0.4f;
    float _dashingCooldown = 3f;
    float _dashingDuration = 1f;

    // Start is called before the first frame update
    public float curhp = 800;
    HealthBarScript hpBar;
    public GameObject projectile;
    public float launchVelocity = 700f;
    private bool shot_taken = false;
    public int curAtk = 80;
    public int curDef = 50;
    public int startPrice = 600;
    void Start()
    {
        hpBar = transform.Find("HealthBar Canvas").GetComponent<HealthBarScript>();
        
        hp = curhp;
        atk = curAtk;
        def = curDef;

        //movement
        speed = curSpeed;
        base.m_RotationSpeed = m_RotationSpeed;

        //dash
        base.m_RotationSpeed = m_RotationSpeed;
        base._dashingTime = _dashingTime;
        base._dashingCooldown = _dashingCooldown;
        base._dashingDuration= _dashingDuration;
    }

    // Update is called once per frame
    void Update()
    {
        //print("cur" + curhp.ToString());
        //print("hp" + hp.ToString());
        hpBar.UpdateHealth(curhp, hp);
        if (Input.GetButtonDown("Fire3") && shot_taken == false)
        {
            shot_taken = true;
            Physics.IgnoreLayerCollision(8, 8, true);
            GameObject web = Instantiate(projectile, transform.position, transform.rotation);
            web.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, launchVelocity, 0));
            StartCoroutine(Reload(5f));
        }

    }

    private IEnumerator Reload(float f)
    {
        shot_taken = false;
        yield return new WaitForSeconds(f);
    }
}
