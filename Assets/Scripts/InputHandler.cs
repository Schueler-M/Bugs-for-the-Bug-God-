using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{

    public Vector2 InputVector { get; private set; }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        InputVector = new Vector2(h, v);

    }
}
