using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushAwayRight : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.AddForceAtPosition(Vector3.up* -10, Vector3.right * 50f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
