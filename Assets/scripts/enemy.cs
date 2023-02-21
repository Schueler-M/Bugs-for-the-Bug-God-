using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public GameObject player;
    Player ps;
    int index = 0;
    int speedIndex;
    int atkIndex;
    public Player[] enemyBugs;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        ps = player.GetComponent<Player>();
        speedIndex = 0;
        int fastestSpeed = 0;
        int biggestAtk = 0;
        for (int i = 0; i < enemyBugs.Length; i++)
        {
            //print("i: " + i.ToString() + "ATK: " + enemyBugs[i].atk.ToString());
            if(enemyBugs[i].speed > fastestSpeed | fastestSpeed == 0)
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
        }
        enemyBugs[1].gameObject.SetActive(false);
        enemyBugs[2].gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = player.transform.position;
        agent.speed = enemyBugs[index].speed;
        if(Mathf.Abs(agent.remainingDistance) < 5)
        {
            
            ps.playerBugs[ps.index].hp -= 5 * Time.deltaTime;
            if (index != atkIndex)
            {
                enemyBugs[index].gameObject.SetActive(false);
                index = atkIndex;
                enemyBugs[index].gameObject.SetActive(true);
            }
        }
        else
        {
            if(index != speedIndex)
            {
                enemyBugs[index].gameObject.SetActive(false);
                index = speedIndex;
                enemyBugs[index].gameObject.SetActive(true);
            }
        
        }

        //Transform.RotateAround(transform.position,Vector3.up,90)
    }
}
