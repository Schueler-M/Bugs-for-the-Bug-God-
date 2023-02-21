using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

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
    public Texture sword;
    public Texture hatchet;
    public Texture swatchet;
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
            int count = 1;
            foreach (var item in inv)
            {
                string objName = "Main Camera/Canvas/ShopUI/Inventory/InvSlot (" + count + ")";
                GameObject obj = GameObject.Find(objName);
                RawImage m_RawImage = obj.GetComponent<RawImage>();
                if(item.ToString() == "sword")
                {
                    m_RawImage.texture = sword;
                }
                else if(item.ToString() == "hatchet")
                {
                    m_RawImage.texture = hatchet;
                }
                else if(item.ToString() == "swatchet")
                {
                    m_RawImage.texture = swatchet;
                }
                count += 1;
            }
        }
    }

    public void purchaseItem1()
    {
        if(curr == visibleOpt.blacksmith && inv.Count <= 9)
        {
            inv.Add("sword");
        }
    }

    public void purchaseItem2()
    {
        if (curr == visibleOpt.blacksmith && inv.Count <= 9)
        {
            inv.Add("hatchet");
        }
    }

    public void purchaseItem3()
    {
        if (curr == visibleOpt.blacksmith && inv.Count <= 9)
        {
            inv.Add("swatchet");
        }
    }
}
