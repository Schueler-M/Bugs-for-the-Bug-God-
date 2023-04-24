using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ant : Player
{
    [Header("Movement")]
    public int curSpeed = 12;
    float m_RotationSpeed = 8f;

    [Header("Dash")]
    float _dashingVel = 15f;
    float _dashingTime = 0.6f;
    float _dashingCooldown = 2f;
    float _dashingDuration = 1.2f;

    HealthBarScript hpBar;
    // Start is called before the first frame update
    public float curhp = 500;
    public int curAtk = 50;
    public int curDef = 30;
    public int startPrice = 300;

    //ability
    public float abilityTime = 3f;
    public float cooldownTime;
    private bool inCooldown;
    private GameObject[] enemies;
    bool inUsing = false;
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
        base._dashingDuration = _dashingDuration;

        //ability
        enemies = GameObject.FindGameObjectsWithTag("Enemy");


    }

    // Update is called once per frame
    void Update()
    {
        hpBar.UpdateHealth(curhp, hp);
        //print("cur" + curhp.ToString());
        //print("hp"+ hp.ToString());

        //ability
        base.inUsing= inUsing;
        if (inCooldown == false && Input.GetKeyDown(KeyCode.F))
        {
            
            StartCoroutine(cooldownController());
            inCooldown = true;
            StartCoroutine(powerUp());
        }

        }

    public void updateHpBar()
    {
        hpBar.UpdateHealth(curhp, hp);
    }

    IEnumerator powerUp()    //This coroutine control the time that the powerup is happening
    {
        inUsing= true;
        //Trans_material.SetFloat("_Opacity", 1f);
        yield return new WaitForSecondsRealtime(abilityTime);
        //Trans_material.SetFloat("_Opacity", 0.5f);
        inUsing = false;

    }

    IEnumerator cooldownController()
    {
        yield return new WaitForSeconds(cooldownTime);
        inCooldown = false;
    }
}
