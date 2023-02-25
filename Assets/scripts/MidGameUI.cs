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
    Color ogA;
    Color ogB;
    Color ogC;  
    // Start is called before the first frame update
    void Start()
    {
        imageA = objectImgA.GetComponent<Image>();
        imageB = objectImgB.GetComponent<Image>();
        imageC = objectImgC.GetComponent<Image>();
        ogA = imageA.color;
        ogB = imageB.color;
        ogC = imageC.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addSprite(int index, Sprite s, bool isAlive = true)
    {
        if(index == 0)
        {
            imageA.sprite = s;
            if(!isAlive)
                imageA.color = Color.clear;
            else
                imageA.color = ogA;
        }
        else if (index == 1)
        {
            imageB.sprite = s;
            if (!isAlive)
                imageB.color = Color.clear;
            else
                imageB.color = ogB;
        }
        else if (index == 2)
        {
            imageC.sprite = s;
            if (!isAlive)
                imageC.color = Color.clear;
            else
                imageC.color = ogC;
        }
    }
}
