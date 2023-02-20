using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testAnimation : MonoBehaviour
{
    public GameObject armsGun;
    public Animator gunAnim;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)){
            Debug.Log("hi");
            gunAnim.SetTrigger("reload");
        }
        if (Input.GetKeyDown(KeyCode.Mouse0)){
            gunAnim.SetTrigger("fire");
        }
    }
}
