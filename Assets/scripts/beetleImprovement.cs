using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beetleImprovement : MonoBehaviour
{
    public Material metal_material;
    public Material chainmail_material;
    [SerializeField] private GameObject beetle;     //I point to the object that I want to change

    public BasicMove bm;
    
    
    // Start is called before the first frame update
    void Start()
    {
        int num = Random.Range(0, 2);
        bm.speed = 5f;
        Renderer rend = beetle.GetComponent<Renderer>();
        switch (num)
        {
            case 0:
                rend.material = metal_material;
                break;
            case 1:
                rend.material = chainmail_material;
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
