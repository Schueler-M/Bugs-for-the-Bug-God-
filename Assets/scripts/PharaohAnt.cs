using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PharaohAnt : MonoBehaviour
{

    public Material Trans_material;

    public BasicMove bm;
    private GameObject[] enemies;
    public float abilityTime=4f;
    public float cooldownTime;
    private bool inCooldown;

    // Start is called before the first frame update
    void Start()
    {
        
        bm.speed = 7f;                                                      //Set velocity. In work
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if(inCooldown==false && Input.GetKeyDown(KeyCode.F)) 
        {
            StartCoroutine(cooldownController());
            inCooldown = true;
            StartCoroutine(powerUp());
            //Trans_material.SetFloat("_Opacity", 1f);
            //foreach(GameObject ene in enemies)
            //{
            //    Physics.IgnoreCollision(ene.GetComponent<Collider>(), GetComponent<Collider>());
            //}
        }
        

    }


    IEnumerator powerUp()    //This coroutine control the time that the powerup is happening
    {
        Trans_material.SetFloat("_Opacity", 1f);
        foreach (GameObject ene in enemies)
        {
            Physics.IgnoreCollision(ene.GetComponent<Collider>(), GetComponent<Collider>());
        }
        yield return new WaitForSeconds(abilityTime);
        Trans_material.SetFloat("_Opacity", 0.5f);
        foreach (GameObject ene in enemies)
        {
            Physics.IgnoreCollision(ene.GetComponent<Collider>(), GetComponent<Collider>(), false);
        }
    }

    IEnumerator cooldownController()
    {
        yield return new WaitForSeconds(cooldownTime);
        inCooldown = false;
    }

}
