using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor;
using UnityEngine;

public class spider : Player
{
    public GameObject projectile;
    public float launchVelocity = 700f;
    private bool shot_taken = false; 


    // Start is called before the first frame update
    void Start()    
    {
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire3") && shot_taken == false)
        {
            shot_taken = true;
            Physics.IgnoreLayerCollision(8, 8, true);
            GameObject web = Instantiate(projectile, transform.position, transform.rotation);
            web.GetComponent<Rigidbody>().AddRelativeForce(new Vector3 (0, launchVelocity, 0));
            StartCoroutine(Reload(5f));
        }
        
    }

    private IEnumerator Reload(float f)
    {
        yield return new WaitForSeconds(f);
    }
}
