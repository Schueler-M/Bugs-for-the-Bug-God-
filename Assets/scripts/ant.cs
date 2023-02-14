using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ant : Player
{
    // Start is called before the first frame update
    float curhp = 70;
    void Start()
    {
        speed = 10;
        hp = curhp;
        atk = 50;
    }

    // Update is called once per frame
    void Update()
    {
        //print("cur" + curhp.ToString());
        //print("hp"+ hp.ToString());
    }
}
