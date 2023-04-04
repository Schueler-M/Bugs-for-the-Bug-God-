using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

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

    public Vector3 walk_to;
    public float walk_range;
    private bool player_dest; // player is the destination or not
    private int search_timer;

    AudioSource audioP;

    // Start is called before the first frame update
    void Start()
    {
        audioP = enemyBugs[index].GetComponent<AudioSource>();
        agent = GetComponent<NavMeshAgent>();
        ps = player.GetComponent<Player>();
        speedIndex = 0;
        findBest();
        enemyBugs[1].gameObject.SetActive(false);
        enemyBugs[2].gameObject.SetActive(false);
        partSys = transform.GetComponent<ParticleSystem>();

        walk_range = 50;
        searchPoint();
        search_timer = 400;
    }

    // Update is called once per frame
    void Update()
    {
        
        // If player is a close distance it will move towards the player
        // If player is not close it will move at random
        if (Vector3.Distance(player.transform.position, transform.position) <= 20)
        {
            player_dest = true;
            GameObject curBug = null;
            //Transform[] allChildren = player.GetComponentsInChildren<Transform>();
            Transform pt = player.transform;
            foreach (Transform child in pt)
            {
                if (child.gameObject.activeInHierarchy && (child.gameObject.name == "ant(Clone)" || child.gameObject.name == "Beetle(Clone)" || child.gameObject.name == "Spider(Clone)"))
                {
                    curBug = child.gameObject;
                    break;
                }
            }

            //agent.SetDestination(player.transform.position + (-2 * transform.forward));
            if (curBug != null)
            {
                //print(curBug.name);
                Vector3 bugSize = curBug.GetComponent<BoxCollider>().size;
                //print(bugSize);
                agent.SetDestination(player.transform.position + (-bugSize.z) * transform.forward);
            }
            else
                agent.SetDestination(player.transform.position + (-2 * transform.forward));
        }
        else
        {
            search_timer -= 1;
            if (search_timer <= 0)
            {
                search_timer = 400;
                searchPoint(); // sets a new point after timer is up
            }
            player_dest = false;
            agent.SetDestination(walk_to);
        }
        
        agent.speed = enemyBugs[index].speed;
        hitCooldown -= Time.deltaTime;

        if (Mathf.Abs(agent.remainingDistance) < 5)
        {
            if (player_dest)
            {
                //ps.playerBugs[ps.index].updateHpBar();
                //print("Need DEF Heal: "+needDefHeal.ToString());
                if (needDefHeal == true && index != defIndex)
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
                searchPoint(); // sets a new point when it reaches its destination
            }
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

    private void searchPoint()
    {
        float rand_x = Random.Range(-walk_range,walk_range);
        float rand_z = Random.Range(-walk_range,walk_range);
        walk_to = new Vector3(transform.position.x + rand_x, transform.position.y, transform.position.z + rand_z); // sets a random point for enemy to walk to
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
            if (hitCooldown <= 0)
            {
                hitCooldown = 0.5f;
                int dmg = (ps.playerBugs[ps.index].atk * 2) - enemyBugs[index].def;
                enemyBugs[index].hp -= dmg;
                enemyBugs[index].damageHeal += dmg / 3;
                audioP.clip = ps.hitSound;   
                if (enemyBugs[index].hp < 0)
                {
                    audioP.clip = ps.deathSound;
                    partSys.Play();
                    findBest();
                }
                audioP.Play();
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
        {
            Destroy(gameObject);
            //Do Win Stuff
            dataManager data = GameObject.Find("DataManager").GetComponent<dataManager>();
            Transform[] allChildren = player.GetComponentsInChildren<Transform>(true);
            foreach (Transform child in allChildren)
            {
                print(child);
                if (child.gameObject.name == "ant(Clone)" || child.gameObject.name == "Beetle(Clone)" || child.gameObject.name == "Spider(Clone)")
                {
                    Player psChild = child.GetComponent<Player>();
                    if (psChild.hp > 0)
                    {
                        psChild.resetStats();
                        psChild.upgradePoints += 1;
                        child.gameObject.SetActive(false);
                        child.parent = data.transform;
                    }

                }
            }
            data.bugList.Clear();
            Transform dt = data.transform;
            foreach (Transform child in dt)
            {
                data.bugList.Add(child.gameObject);
            }
            SceneManager.LoadScene("Win_Screen");
        }
    }
    void healHurt()
    {
        float totalHeal = 0;
        for (int i = 0; i < enemyBugs.Length; i++)
        {
            totalHeal += enemyBugs[i].damageHeal; //used for ai, not healing and includes active bug
            if (enemyBugs[i].hp > 0 & (enemyBugs[i].isActiveAndEnabled == false))
            {
                float heal = (enemyBugs[i].damageHeal * (Time.deltaTime))/ 30;
                enemyBugs[i].hp += heal;
                enemyBugs[i].damageHeal -= heal;
                if (enemyBugs[i].damageHeal < 0)
                    enemyBugs[i].damageHeal = 0;

            }

        }
        if(totalHeal < 100)
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
            int chance = Random.Range(0, 3);
            if (chance == 0)
                doHit.GetComponent<SpriteRenderer>().sprite = ps.AtkSprite;
            else if (chance == 1)
                doHit.GetComponent<SpriteRenderer>().sprite = ps.AtkSprite2;
            else if (chance == 2)
                doHit.GetComponent<SpriteRenderer>().sprite = ps.AtkSprite3;
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
