using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camScript : MonoBehaviour
{
    public Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if(hit.transform.name == "Altar")
                {
                    print("Altar");
                }
                else if(hit.transform.name == "Pub")
                {
                    print("Pub");
                }
                else if(hit.transform.name == "Store")
                {
                    print("Store");
                }
            }
        }
    }
}
