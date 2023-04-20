using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class special : MonoBehaviour
{
    public float time_to_live = 1;
    public Sprite sprite;
    public string stateName;
    public float stateLength;
    public BugStates state;
    // Start is called before the first frame update
    void Start()
    {
        state.sName = stateName;
        state.sLast = stateLength;

        GetComponent<SpriteRenderer>().sprite = sprite;

    }

    // Update is called once per frame
    void Update()
    {
        time_to_live -= Time.deltaTime;
        transform.Translate(new Vector3(0, 0, 10) * Time.deltaTime);
        if (time_to_live < 0)
        {
            Destroy(this.gameObject);
        }
    }

}
