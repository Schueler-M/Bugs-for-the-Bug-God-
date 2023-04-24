using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beetle : Player
{
    [Header("Movement")]
    public int curSpeed = 8;
    float m_RotationSpeed = 3f;

    [Header("Dash")]
    float _dashingVel = 5f;
    float _dashingTime = 0.4f;
    float _dashingCooldown = 3f;
    float _dashingDuration = 1f;


    HealthBarScript hpBar;
    // Start is called before the first frame update
    public float curhp = 1000;
    public int curAtk = 50;
    public int curDef = 80;
    public int startPrice = 1000;
    void Start()
    {
        //movement
        speed = curSpeed;
        base.m_RotationSpeed = m_RotationSpeed;

        //dash
        base.m_RotationSpeed = m_RotationSpeed;
        base._dashingTime = _dashingTime;
        base._dashingCooldown = _dashingCooldown;
        base._dashingDuration = _dashingDuration;

        //beetle ability
        int num = Random.Range(0, 2);

        //I have put more defense instead of armor

        switch (num)
        {
            case 0:
                curDef += 15;
                break;
            case 1:
                curDef += 30;
                break;
        }

        hpBar = transform.Find("HealthBar Canvas").GetComponent<HealthBarScript>();
        hp = curhp;
        atk = curAtk;
        def = curDef;


    }

    // Update is called once per frame
    void Update()
    {
        hpBar.UpdateHealth(curhp, hp);
        //print("cur" + curhp.ToString());
        //print("hp"+ hp.ToString());
    }

    public void updateHpBar()
    {
        hpBar.UpdateHealth(curhp, hp);
    }
}
