using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class camScript : MonoBehaviour
{
    public GameObject hubUI, shopUI;
    public Camera camera;
    enum visibleOpt
    {
        hub,
        blacksmith,
        altar,
        pub
    }
    visibleOpt curr;
    ArrayList inv = new ArrayList();
    void Start()
    {
        curr = visibleOpt.hub;
    }

    // Update is called once per frame
    void Update()
    {
        if (curr == visibleOpt.hub)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.name == "Altar")
                    {
                        print("Altar");
                    }
                    else if (hit.transform.name == "Pub")
                    {
                        print("Pub");
                    }
                    else if (hit.transform.name == "Store")
                    {
                        print("Store");
                        hubUI.SetActive(false);
                        shopUI.SetActive(true);
                        curr = visibleOpt.blacksmith;
                    }
                }
            }
        }
        else if(curr == visibleOpt.blacksmith)
        {
            
        }
    }

    public void purchaseItem1()
    {
        inv.Add("Item1");
    }

    public void purchaseItem2()
    {
        inv.Add("Item2");
    }

    public void purchaseItem3()
    {
        inv.Add("Item3");
    }

}
