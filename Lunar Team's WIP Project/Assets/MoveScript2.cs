using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript2 : MonoBehaviour
{
public Rigidbody rb;
public float moveValueZ = 0;
public float moveValueY = 0;
public float moveValueX = 0;

public Material matDefault;
public Material matHover;
public playerMovement uiScript;

public GameObject part;

private Vector3 velocity;

public bool isMouseOver = false;



    // Start is called before the first frame update
    void Start()
    {
  
    }

    
        void OnMouseOver()
    {
        uiScript.isCube2On = true;
        Material[] mats = part.GetComponent<Renderer>().materials;
        mats[2] = matHover;
        part.GetComponent<Renderer>().materials = mats;
        isMouseOver = true;
    }

    void OnMouseExit()
    {
        uiScript.isCube2On = false;
        Material[] mats = part.GetComponent<Renderer>().materials;
        mats[2] = matDefault;
        part.GetComponent<Renderer>().materials = mats;
        isMouseOver = false;
    }

    void Update()
    {
    if(isMouseOver){
        if(Input.GetKeyDown(KeyCode.F)){
            changeVelocity();
    }
    }
    }


    void changeVelocity(){
        rb.velocity = new Vector3(moveValueX, moveValueY, moveValueZ);
    }
}
