using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_HealthHandler : MonoBehaviour
{
    [SerializeField] private float totalHealth = 6; // Total Health; Variable can change later.(perhaps depending on the creature)
    private float curHealth; // Current Health

    [SerializeField] private HealthBarScript thehealth;

    void Start()
    {
        curHealth = totalHealth; // Setting the current health to the highest amount

        thehealth.UpdateHealth(totalHealth, curHealth); // sending it to main script
    }

    /* 
     // Guide For Using Feature

        curHealth -= 1; // number can be tweaked

        if (curHealth <= 0)
        {
            curHealth = 0;
        }

        thehealth.UpdateHealth(totalHealth, curHealth);
    */

}
