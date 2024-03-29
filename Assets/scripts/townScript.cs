using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

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
    Inventory inv = new Inventory();
    public Texture sword;
    public Texture hatchet;
    public Texture swatchet;
    public dataManager data;
    InvDropdown altInvDrop;
    void Start()
    {
        curr = visibleOpt.hub;
        data = GameObject.Find("DataManager").GetComponent<dataManager>();
        try
        {
            altInvDrop = GameObject.Find("AltDropdown").GetComponent<InvDropdown>();
        }
        catch
        {
            ;
        }
        data.addBugsToADropDown();

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
            refreshInv(inv);
        }
    }

    public void purchaseItem1()
    {
        data = GameObject.Find("DataManager").GetComponent<dataManager>();
        if (curr == visibleOpt.blacksmith)
        {
            if (data.gold >= 100)
            {
                altInvDrop = GameObject.Find("AltDropdown").GetComponent<InvDropdown>();
                data.inv.Add("sword");
                data.gold -= 100;
                altInvDrop.refreshAltInv();
                for (int i = 0; i < 9; i++)
                {
                    if (inv.inventory[i] == null)
                    {
                        inv.inventory[i] = "sword";
                        return;
                    }
                }
                Debug.Log("No Open Inv Slot");
            }
        }
    }

    public void purchaseItem2()
    {
        data = GameObject.Find("DataManager").GetComponent<dataManager>();
        if (curr == visibleOpt.blacksmith)
        {
            if (data.gold >= 100)
            {
                altInvDrop = GameObject.Find("AltDropdown").GetComponent<InvDropdown>();
                data.inv.Add("hatchet");
                altInvDrop.refreshAltInv();
                data.gold -= 100;
                for (int i = 0; i < 9; i++)
                {
                    if (inv.inventory[i] == null)
                    {
                        inv.inventory[i] = "hatchet";
                        return;
                    }
                }
                Debug.Log("No Open Inv Slot");
            }
        }
    }

    public void purchaseItem3()
    {
        data = GameObject.Find("DataManager").GetComponent<dataManager>();
        if (curr == visibleOpt.blacksmith)
        {
            if (data.gold >= 150)
            {
                altInvDrop = GameObject.Find("AltDropdown").GetComponent<InvDropdown>();
                data.gold -= 150;
                data.inv.Add("swatchet");
                altInvDrop.refreshAltInv();
                for (int i = 0; i < 9; i++)
                {
                    if (inv.inventory[i] == null)
                    {
                        inv.inventory[i] = "swatchet";
                        return;
                    }
                }

                Debug.Log("No Open Inv Slot");
            }
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

    public void sacLeft()
    {
        if (curr == visibleOpt.blacksmith)
        {
            if (inv.bugs[0] != null)
            {
                inv.bugs[0] = null;
                inv.Save();
            }
        }
    }

    public void sacMid()
    {
        if (curr == visibleOpt.blacksmith)
        {
            if (inv.bugs[1] != null)
            {
                inv.bugs[1] = null;
                inv.Save();
            }
        }
    }

    public void sacRight()
    {
        if (curr == visibleOpt.blacksmith)
        {
            if (inv.bugs[2] != null)
            {
                inv.bugs[2] = null;
                inv.Save();
            }
        }
    }

    public void backToMenu()
    {
        SceneManager.LoadScene("Assets/Scenes/MidMenu.unity");
    }

    public void refreshInv(Inventory inv)
    {
        int count = 1;
        for (int i = 0; i < 9; i++)
        {
            if (inv.inventory[i] != null)
            {
                string objName = "InvSlot (" + count + ")";
                GameObject obj = GameObject.Find(objName);
                RawImage m_RawImage = obj.GetComponent<RawImage>();
                if (inv.inventory[i] == "sword")
                {
                    m_RawImage.texture = sword;
                }
                else if (inv.inventory[i] == "hatchet")
                {
                    m_RawImage.texture = hatchet;
                }
                else if (inv.inventory[i] == "swatchet")
                {
                    m_RawImage.texture = swatchet;
                }
                count += 1;
            }
        }
    }
}
