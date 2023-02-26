using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class collision : MonoBehaviour
{

    public Transform tutajCube;
    
    // Start is called before the first frame update
    void Start()
    {
       Physics.IgnoreCollision(tutajCube.GetComponent<Collider>(), GetComponent<Collider>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
