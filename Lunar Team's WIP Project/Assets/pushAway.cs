using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushAway : MonoBehaviour
{

    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.AddForceAtPosition(Vector3.up* -10, Vector3.left * 50f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
