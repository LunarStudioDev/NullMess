using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class appearWow : MonoBehaviour
{
     void Update()
    {
        if(Input.GetKeyDown(KeyCode.X)){
            Debug.Log("hi");
            this.gameObject.SetActive(true);
        }
    }
}
