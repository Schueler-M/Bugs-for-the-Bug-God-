using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Player[] playerBugs; //may need a higher manager
    int index = 0;
    public int speed = 1;
    Vector2 move_vector;
    Rigidbody2D rb;
    float swapCooldown = 0.0f;
    GameObject ui_game_obj;
    MidGameUI ui_script_obj;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ui_game_obj = GameObject.Find("MidGameUI");
        ui_script_obj = ui_game_obj.GetComponent<MidGameUI>();
        ui_script_obj.addSprite(0, playerBugs[2].GetComponent<SpriteRenderer>().sprite);
        ui_script_obj.addSprite(1, playerBugs[0].GetComponent<SpriteRenderer>().sprite);
        ui_script_obj.addSprite(2, playerBugs[1].GetComponent<SpriteRenderer>().sprite);
        print("Changed Images");
    }

    void Update()
    {
        swapCooldown -= Time.deltaTime;
        Vector3 Velocity = new Vector3(move_vector.x, move_vector.y).normalized * playerBugs[index].speed;
        //print(playerBugs[index].speed);
        rb.velocity = Velocity;
    }
    public void move(InputAction.CallbackContext context)
    {
        move_vector = context.ReadValue<Vector2>();
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
}
