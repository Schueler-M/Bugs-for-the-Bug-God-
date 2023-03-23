using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class townScript : MonoBehaviour
{
    public GameObject hubUI, shopUI, altarUI, pubUI;
    public Camera cameraC;
    public enum visibleOpt
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
                Ray ray = cameraC.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.name == "Altar")
                    {
                        goTo(visibleOpt.altar);
                    }
                    else if (hit.transform.name == "Pub")
                    {
                        goTo(visibleOpt.pub);
                    }
                    else if (hit.transform.name == "Store")
                    {
                        goTo(visibleOpt.blacksmith);
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
        if(curr == visibleOpt.blacksmith && inv.Count < 9)
        {
            inv.Add("sword");
        }
    }

    public void purchaseItem2()
    {
        if (curr == visibleOpt.blacksmith && inv.Count < 9)
        {
            inv.Add("hatchet");
        }
    }

    public void purchaseItem3()
    {
        if (curr == visibleOpt.blacksmith && inv.Count < 9)
        {
            inv.Add("swatchet");
        }
    }

    public void goBack()
    {
        goTo(visibleOpt.hub);
    }

    public void goTo(visibleOpt loc)
    {
        if (curr == visibleOpt.blacksmith)
        {
            shopUI.SetActive(false);
        }
        else if(curr == visibleOpt.hub)
        {
            hubUI.SetActive(false);
        }
        else if(curr == visibleOpt.altar)
        {
            altarUI.SetActive(false);
        }
        else if(curr == visibleOpt.pub)
        {
            pubUI.SetActive(false);
        }
        if (loc == visibleOpt.blacksmith)
        {
            shopUI.SetActive(true);
        }
        else if (loc == visibleOpt.hub)
        {
            hubUI.SetActive(true);
        }
        else if (loc == visibleOpt.altar)
        {
            altarUI.SetActive(true);
        }
        else if (loc == visibleOpt.pub)
        {
            pubUI.SetActive(true);
        }
        curr = loc;
    }
}
