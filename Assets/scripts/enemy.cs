using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class enemy : MonoBehaviour
{
    public GameObject player;
    Player ps;
    public int index = 0;
    int speedIndex;
    int atkIndex;
    int defIndex;
    float hitCooldown = 0.0f;
    public Player[] enemyBugs;
    NavMeshAgent agent;
    bool needDefHeal;
    GameObject doHit;
    bool isAttacking = false;
    ParticleSystem partSys;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        ps = player.GetComponent<Player>();
        speedIndex = 0;
        findBest();
        enemyBugs[1].gameObject.SetActive(false);
        enemyBugs[2].gameObject.SetActive(false);
        partSys = transform.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = player.transform.position;
        agent.speed = enemyBugs[index].speed;
        hitCooldown -= Time.deltaTime;
        if (Mathf.Abs(agent.remainingDistance) < 5)
        {
            //ps.playerBugs[ps.index].updateHpBar();
            //print("Need DEF Heal: "+needDefHeal.ToString());
            if(needDefHeal == true && index != defIndex)
            {
                enemyBugs[index].gameObject.SetActive(false);
                index = defIndex;
                enemyBugs[index].gameObject.SetActive(true);
            }
            else if (index != atkIndex && needDefHeal == false)
            {
                enemyBugs[index].gameObject.SetActive(false);
                index = atkIndex;
                enemyBugs[index].gameObject.SetActive(true);
            }
            AttackWrapper();
        }
        else
        {
            if (index != speedIndex)
            {
                enemyBugs[index].gameObject.SetActive(false);
                index = speedIndex;
                enemyBugs[index].gameObject.SetActive(true);
            }

        }
        healHurt();
        transform.rotation = Quaternion.LookRotation(agent.velocity.normalized);

        //Transform.RotateAround(transform.position,Vector3.up,90)
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
            if (hitCooldown <= 0)
            {
                hitCooldown = 0.5f;
                int dmg = (ps.playerBugs[ps.index].atk * 2) - enemyBugs[index].def;
                enemyBugs[index].hp -= dmg;
                enemyBugs[index].damageHeal = dmg / 3;
                if (enemyBugs[index].hp < 0)
                {
                    partSys.Play();
                    findBest();
                }
            }
    }

    void findBest()
    {
        int fastestSpeed = 0;
        int biggestAtk = 0;
        int biggestDef = 0;
        int deadCount = 0;
        for (int i = 0; i < enemyBugs.Length; i++)
        {
            if (enemyBugs[i].hp > 0)
            {
                //print("i: " + i.ToString() + "ATK: " + enemyBugs[i].atk.ToString());
                if (enemyBugs[i].speed > fastestSpeed | fastestSpeed == 0)
                {
                    fastestSpeed = enemyBugs[i].speed;
                    speedIndex = i;
                }
                if (enemyBugs[i].atk > biggestAtk | biggestAtk == 0)
                {
                    biggestAtk = enemyBugs[i].atk;
                    //print("biggestAtk: " + biggestAtk.ToString());
                    atkIndex = i;
                }
                if (enemyBugs[i].def > biggestDef | biggestDef == 0)
                {
                    biggestDef = enemyBugs[i].def;
                    //print("biggestAtk: " + biggestAtk.ToString());
                    defIndex = i;
                }
            }
            else
                deadCount++;
            //print("speedIndex: " + speedIndex.ToString() + " atkIndex: " + atkIndex.ToString() + " defIndex: " + defIndex.ToString());
        }
        if(deadCount >= 3)
            Destroy(gameObject);
    }
    void healHurt()
    {
        float totalHeal = 0;
        for (int i = 0; i < enemyBugs.Length; i++)
        {
            totalHeal += enemyBugs[i].damageHeal; //used for ai, not healing and includes active bug
            if (enemyBugs[i].hp > 0 & (enemyBugs[i].isActiveAndEnabled == false))
            {
                float heal = enemyBugs[i].damageHeal * (Time.deltaTime / 300);
                enemyBugs[i].hp += heal;
                enemyBugs[i].damageHeal -= heal;
                if (enemyBugs[i].damageHeal < 0)
                    enemyBugs[i].damageHeal = 0;

            }

        }
        if(totalHeal < 10)
            needDefHeal = false;
        else
            needDefHeal = true;
        //print("totalHeal: " + totalHeal.ToString());
    }
    private IEnumerator attack(float f)
    {
        if (isAttacking == false)
        {
            doHit = enemyBugs[index].transform.Find("HitBox").gameObject;
            isAttacking = true;
            doHit.SetActive(true);
            yield return new WaitForSeconds(f);
            isAttacking = false;
            doHit.SetActive(false);
        }
    }
    public void AttackWrapper()
    {
        StartCoroutine(attack(0.5f));
    }
}
