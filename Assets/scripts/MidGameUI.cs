using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MidGameUI : MonoBehaviour
{
    public GameObject objectImgA;
    public GameObject objectImgB;
    public GameObject objectImgC;
    Image imageA;
    Image imageB;
    Image imageC;
    // Start is called before the first frame update
    void Start()
    {
        imageA = objectImgA.GetComponent<Image>();
        imageB = objectImgB.GetComponent<Image>();
        imageC = objectImgC.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addSprite(int index, Sprite s)
    {
        if(index == 0)
        {
            imageA.sprite = s;
        }
        else if (index == 1)
        {
            imageB.sprite = s;
        }
        else if (index == 2)
        {
            imageC.sprite = s;
        }
    }
}
