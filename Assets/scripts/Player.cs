using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Player[] playerBugs;
    public int index = 0;
    public int speed = 1;
    public float hp = 1.0f;
    public int atk = 1;
    public int def = 1;
    public float damageHeal = 0;
    public string name;
    public int price = 0;

    Vector2 move_vector;
    Rigidbody rb;
    float swapCooldown = 0.0f;
    GameObject ui_game_obj;
    MidGameUI ui_script_obj;
    bool aim_needs_adjusted;
    Ray aim_ray;
    Camera my_camera;
    GameObject doHit;
    bool isAttacking = false;
    float hitCooldown = 0.0f;
    enemy es;
    ParticleSystem partSys;

    public bool right_camrot = false;
    public bool left_camrot = false;
    public bool mbpr = false;
    public bool mbpl = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ui_game_obj = GameObject.Find("MidGameUI");
        ui_script_obj = ui_game_obj.GetComponent<MidGameUI>();
        my_camera = transform.Find("Main Camera").GetComponent<Camera>();
        StartCoroutine(getStartImages());
        es = GameObject.Find("Enemy").GetComponent<enemy>();
        partSys = transform.GetComponent<ParticleSystem>();
        //ui_script_obj.addSprite(0, playerBugs[2].GetComponent<SpriteRenderer>().sprite);
        //ui_script_obj.addSprite(1, playerBugs[0].GetComponent<SpriteRenderer>().sprite);
        //ui_script_obj.addSprite(2, playerBugs[1].GetComponent<SpriteRenderer>().sprite);
    }

    void Update()
    {
        mbpl = false;
        mbpr = false;

        swapCooldown -= Time.deltaTime;
        hitCooldown -= Time.deltaTime;
        Vector3 getx = transform.forward.normalized * move_vector.y;
        Vector3 gety = transform.right.normalized * move_vector.x;
        Vector3 Velocity =  (getx + gety) * playerBugs[index].speed;
        //playerBugs[index].hp = hp;
        //print(playerBugs[index].speed);
        rb.velocity = Velocity;

        if (aim_needs_adjusted)
        {
            aim_needs_adjusted = false;

            RaycastHit hit_result;
            if (Physics.Raycast(aim_ray, out hit_result, Mathf.Infinity, LayerMask.GetMask("Ground")))
            {
                Vector3 look_at_pt = new Vector3(hit_result.point.x, transform.position.y, hit_result.point.z);
                look_at_pt -= transform.position;
                playerBugs[index].transform.rotation = Quaternion.LookRotation(look_at_pt);
            }
        }
        healHurt();
        if (right_camrot)
        {
            Vector3 rright = new Vector3(0, 1, 0);
            transform.Rotate(rright);
        }

        if (left_camrot)
        {
            Vector3 rleft = new Vector3(0, -1, 0);
            transform.Rotate(rleft);
        }
        
    }
    public void move(InputAction.CallbackContext context)
    {
        move_vector = context.ReadValue<Vector2>();
    }
    public void Zoom(InputAction.CallbackContext context)
    {
        float value = context.ReadValue<Vector2>().y;
        if(value > 0)
        {
            my_camera.transform.position = Vector3.MoveTowards(my_camera.transform.position, transform.position, (.005f * value));
        }
        else if (value < 0)
        {
            my_camera.transform.Translate((-1 * my_camera.transform.forward) * Time.deltaTime * (-1*value), Space.World);
        }
    }

    public void look_at(InputAction.CallbackContext context)
    {
        //print("IN LOOK");
        PlayerInput input_comp = GetComponent<PlayerInput>();
        if (input_comp.currentControlScheme == "Keyboard&Mouse")
        {
            Vector2 look_vector = context.ReadValue<Vector2>();
            //print("Look = " + look_vector + " control = " + input_comp.currentControlScheme);
            Vector2 mouse_pos = Input.mousePosition;

            aim_needs_adjusted = true;
            aim_ray = my_camera.ScreenPointToRay(mouse_pos);
        }

    }

    public void RotateCameraRight(InputAction.CallbackContext context)
    {
        if (mbpr == false)
        {
            right_camrot = !right_camrot;
            mbpr = true;
        }
    }

    public void RotateCameraLeft(InputAction.CallbackContext context)
    {
        if (mbpl == false)
        {
            left_camrot = !left_camrot;
            mbpl = true;
        }
    }

    public void AttackWrapper(InputAction.CallbackContext context)
    {
        StartCoroutine(attack(0.5f));
    }

    public void SwapLeft(InputAction.CallbackContext context)
    {
        //print("swapL");
        if (swapCooldown <= 0.0f)
        {
            swapCooldown = 0.4f;
            playerBugs[index].gameObject.SetActive(false);
            index -= 1;
            if (index < 0)
            {
                if(playerBugs[2].hp > 0)
                    index = 2;
                else index += 1;
            }
            else if (playerBugs[index].hp < 0)
                index += 1;

            getIcons();
            playerBugs[index].gameObject.SetActive(true);

        }
    }
    public void SwapRight(InputAction.CallbackContext context)
    {
        //print("swapR");
        if (swapCooldown <= 0.0f)
        {
            swapCooldown = 0.4f;
            playerBugs[index].gameObject.SetActive(false);
            index += 1;
            if (index > 2)
            {
                if(playerBugs[0].hp > 0)
                    index = 0;
                else index -= 1;
            }
            else if(playerBugs[index].hp < 0)
                index -=1;

            getIcons();
            playerBugs[index].gameObject.SetActive(true);
        }
    }

    IEnumerator getStartImages()
    {
        yield return null;
        ui_script_obj.addSprite(0, playerBugs[2].GetComponent<SpriteRenderer>().sprite);
        ui_script_obj.addSprite(1, playerBugs[0].GetComponent<SpriteRenderer>().sprite);
        ui_script_obj.addSprite(2, playerBugs[1].GetComponent<SpriteRenderer>().sprite);
    }
    private IEnumerator attack(float f)
    {
        if (isAttacking == false)
        {
            doHit = playerBugs[index].transform.Find("HitBox").gameObject;
            isAttacking = true;
            doHit.SetActive(true);
            yield return new WaitForSeconds(f);
            isAttacking = false;
            doHit.SetActive(false);
        }
    }
    void healHurt()
    {
        for (int i = 0; i < playerBugs.Length; i++)
        {
            if (playerBugs[i].hp > 0 & (playerBugs[i].isActiveAndEnabled == false))
            {
                float heal = (playerBugs[i].damageHeal * (Time.deltaTime))/ 30;
                playerBugs[i].hp += heal;
                playerBugs[i].damageHeal -= heal;
                if (playerBugs[i].damageHeal < 0)
                    playerBugs[i].damageHeal = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (hitCooldown <= 0)
            {
                hitCooldown = 0.5f;
                int dmg = (es.enemyBugs[es.index].atk * 2) - playerBugs[index].def;
                playerBugs[index].hp -= dmg;
                playerBugs[index].damageHeal += dmg / 3;
                if (playerBugs[index].hp < 0)
                {
                    partSys.Play();
                    playerBugs[index].gameObject.SetActive(false);
                    for (int i = 0; i < playerBugs.Length; i++)
                    {
                        if (playerBugs[i].hp > 0)
                        {
                            index = i;
                            //Display Particles
                            break;
                        }
                        if (i == 2)
                        {
                            //GAMEOVER
                            SceneManager.LoadScene("Lose_Screen");
                            //Destroy(gameObject);
                        }
                    }
                    getIcons();
                    playerBugs[index].gameObject.SetActive(true);
                }
            }
        }
    }
    void getIcons()
    {
        ui_script_obj.addSprite(1, playerBugs[index].GetComponent<SpriteRenderer>().sprite);
        if (index <= 0)
        {
            ui_script_obj.addSprite(0, playerBugs[2].GetComponent<SpriteRenderer>().sprite, isAlive(2));
            ui_script_obj.addSprite(2, playerBugs[1].GetComponent<SpriteRenderer>().sprite, isAlive(1));
        }
        else if (index >= 2)
        {
            ui_script_obj.addSprite(0, playerBugs[1].GetComponent<SpriteRenderer>().sprite, isAlive(1));
            ui_script_obj.addSprite(2, playerBugs[0].GetComponent<SpriteRenderer>().sprite, isAlive(0));
        }
        else
        {
            ui_script_obj.addSprite(0, playerBugs[0].GetComponent<SpriteRenderer>().sprite, isAlive(0));
            ui_script_obj.addSprite(2, playerBugs[2].GetComponent<SpriteRenderer>().sprite, isAlive(2));
        }
    }
    bool isAlive(int i)
    {
        if (playerBugs[i].hp >= 0)
            return true;
        return false;
    }
}
