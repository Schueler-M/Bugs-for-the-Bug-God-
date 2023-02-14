using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public float time_to_live;

    private void Start()
    {
        Destroy(gameObject,time_to_live);
    }
}
