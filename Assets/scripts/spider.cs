using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class spider : Player
{
    // Start is called before the first frame update
    public float curhp = 800;
    HealthBarScript hpBar;
    public GameObject projectile;
    public float launchVelocity = 700f;
    private bool shot_taken = false;
    public int curSpeed = 10;
    public int curAtk = 80;
    public int curDef = 50;
    public int startPrice = 600;
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
        //print("cur" + curhp.ToString());
        //print("hp" + hp.ToString());
        hpBar.UpdateHealth(curhp, hp);
        if (Input.GetButtonDown("Fire3") && shot_taken == false)
        {
            shot_taken = true;
            Physics.IgnoreLayerCollision(8, 8, true);
            GameObject web = Instantiate(projectile, transform.position, transform.rotation);
            web.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, launchVelocity, 0));
            StartCoroutine(Reload(5f));
        }

    }

    private IEnumerator Reload(float f)
    {
        shot_taken = false;
        yield return new WaitForSeconds(f);
    }
}
