using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class worm : Player
{
    float curhp = 60;
    // Start is called before the first frame update
    void Start()
    {
        hp = curhp;
        speed = 1;
        atk = 20;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
