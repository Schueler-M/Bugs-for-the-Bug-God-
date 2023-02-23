using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ant : Player
{
    HealthBarScript hpBar;
    // Start is called before the first frame update
    float curhp = 70;
    int damageHeal = 0;
    void Start()
    {
        hpBar = transform.Find("HealthBar Canvas").GetComponent<HealthBarScript>();
        speed = 10;
        hp = curhp;
        atk = 50;
        def = 30;
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
