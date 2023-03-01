using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{

    public Rigidbody rb;

        public KeyCode upKey = KeyCode.T;
public KeyCode leftKey = KeyCode.G;

private Vector3 scaleChange;
private Vector3 transChange;

private bool fast;
    // Start is called before the first frame update
    void Start()
    {
        fast = false;
        scaleChange = new Vector3(0, 0.05f, 0);
        transChange = new Vector3(0, 0.025f, 0);
    }

    // Update is called once per frame
    void Update()
    {

    if(Input.GetKey(upKey))
    {
        transform.localScale += scaleChange;
        transform.localPosition += transChange;
    }
    if(Input.GetKeyDown(leftKey)){
        //rb.AddForce(6400, 3200 , 0);
    }

    if(fast){

    }
    }
}
