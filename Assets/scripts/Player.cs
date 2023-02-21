using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Player[] playerBugs;
    public int index = 0;
    public int speed = 1;
    public float hp = 1.0f;
    public int atk = 1;
    public int def = 1;

    Vector2 move_vector;
    Rigidbody rb;
    float swapCooldown = 0.0f;
    GameObject ui_game_obj;
    MidGameUI ui_script_obj;
    bool aim_needs_adjusted;
    Ray aim_ray;
    Camera my_camera;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ui_game_obj = GameObject.Find("MidGameUI");
        ui_script_obj = ui_game_obj.GetComponent<MidGameUI>();
        my_camera = transform.Find("Main Camera").GetComponent<Camera>();
        StartCoroutine(getStartImages());
        //ui_script_obj.addSprite(0, playerBugs[2].GetComponent<SpriteRenderer>().sprite);
        //ui_script_obj.addSprite(1, playerBugs[0].GetComponent<SpriteRenderer>().sprite);
        //ui_script_obj.addSprite(2, playerBugs[1].GetComponent<SpriteRenderer>().sprite);
    }

    void Update()
    {
        swapCooldown -= Time.deltaTime;
        Vector3 Velocity = new Vector3(move_vector.x, 0, move_vector.y).normalized * playerBugs[index].speed;
        //playerBugs[index].hp = hp;
        //print(playerBugs[index].speed);
        rb.velocity = Velocity;

        if (aim_needs_adjusted)
        {
            aim_needs_adjusted = false;

            RaycastHit hit_result;
            if (Physics.Raycast(aim_ray, out hit_result, Mathf.Infinity, LayerMask.GetMask("Ground")))
            {
                print("raycast hit: " + hit_result.point);
                print(1 << 8);
                Vector3 look_at_pt = new Vector3(hit_result.point.x, transform.position.y, hit_result.point.z);
                look_at_pt -= transform.position;
                playerBugs[index].transform.rotation = Quaternion.LookRotation(look_at_pt);
            }
            else { 
                print("hit fail");
            }
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
            print(context.ReadValue<Vector2>());
            my_camera.transform.Translate(my_camera.transform.TransformDirection(transform.forward) * Time.deltaTime * value, Space.World);
        }
        else if (value < 0)
        {
            print("BACKSCROLL");
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
                index = 2;
            }
            ui_script_obj.addSprite(1, playerBugs[index].GetComponent<SpriteRenderer>().sprite);
            if (index <= 0)
            {
                ui_script_obj.addSprite(0, playerBugs[2].GetComponent<SpriteRenderer>().sprite);
                ui_script_obj.addSprite(2, playerBugs[1].GetComponent<SpriteRenderer>().sprite);
            }
            else if (index >= 2)
            {
                ui_script_obj.addSprite(0, playerBugs[1].GetComponent<SpriteRenderer>().sprite);
                ui_script_obj.addSprite(2, playerBugs[0].GetComponent<SpriteRenderer>().sprite);
            }
            else
            {
                ui_script_obj.addSprite(0, playerBugs[0].GetComponent<SpriteRenderer>().sprite);
                ui_script_obj.addSprite(2, playerBugs[2].GetComponent<SpriteRenderer>().sprite);
            }
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
                index = 0;
            }
            if (index < 0)
            {
                index = 2;
            }
            ui_script_obj.addSprite(1, playerBugs[index].GetComponent<SpriteRenderer>().sprite);
            if (index <= 0)
            {
                ui_script_obj.addSprite(0, playerBugs[2].GetComponent<SpriteRenderer>().sprite);
                ui_script_obj.addSprite(2, playerBugs[1].GetComponent<SpriteRenderer>().sprite);
            }
            else if (index >= 2)
            {
                ui_script_obj.addSprite(0, playerBugs[1].GetComponent<SpriteRenderer>().sprite);
                ui_script_obj.addSprite(2, playerBugs[0].GetComponent<SpriteRenderer>().sprite);
            }
            else
            {
                ui_script_obj.addSprite(0, playerBugs[0].GetComponent<SpriteRenderer>().sprite);
                ui_script_obj.addSprite(2, playerBugs[2].GetComponent<SpriteRenderer>().sprite);
            }
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
}
