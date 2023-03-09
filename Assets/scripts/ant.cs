using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ant : Player
{
    HealthBarScript hpBar;
    // Start is called before the first frame update
    public float curhp = 500;
    public int curSpeed = 10;
    public int curAtk = 50;
    public int curDef = 30;
    public int startPrice = 300;
    void Start()
    {
        hpBar = transform.Find("HealthBar Canvas").GetComponent<HealthBarScript>();
        speed = curSpeed;
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
