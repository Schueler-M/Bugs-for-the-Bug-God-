using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvManager : MonoBehaviour
{

    Inventory inv = new Inventory();
    public Texture sword;
    public Texture hatchet;
    public Texture swatchet;
    // Start is called before the first frame update
    void Start()
    {
        inv.Load();
    }

    // Update is called once per frame
    void Update()
    {
        refreshInv(inv);
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
