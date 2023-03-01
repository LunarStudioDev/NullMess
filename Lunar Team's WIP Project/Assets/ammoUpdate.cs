using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ammoUpdate : MonoBehaviour
{
    private TextMeshProUGUI ui;
    public testAnimation ammoScript;
    private bool courotineOn;
    // Start is called before the first frame update
    void Start()
    {
        courotineOn = false;
        ui = this.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!ammoScript.isReloading){
         ui.text = ammoScript.currentAmmo.ToString();
         courotineOn = false;  
        }
        else if(!courotineOn){
            courotineOn = true;
            StartCoroutine(waiter());
        }
          
    }

    IEnumerator waiter(){       
     yield return new WaitForSeconds(0.32f);
     ui.text = "";
     Debug.Log("hi1");                  
     yield return new WaitForSeconds(0.55f);
     Debug.Log("hi2");          
     ui.text = "16";
     
     yield return new WaitForSeconds(0.4f);
     ui.text = "15";
     courotineOn = false;

     }
}
