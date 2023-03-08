using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponSwitch : MonoBehaviour
{
    public GameObject pistol;
    public GameObject shotgun;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            {

            shotgun.SetActive(false);
            pistol.SetActive(true);
            }
         if (Input.GetKeyDown(KeyCode.Alpha2))
            {
            pistol.SetActive(false);
            shotgun.SetActive(true);
            }
            
    }
}
