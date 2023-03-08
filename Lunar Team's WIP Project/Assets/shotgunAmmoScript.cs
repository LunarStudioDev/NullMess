using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class shotgunAmmoScript : MonoBehaviour
{
private TextMeshProUGUI ui;
    public shotgunMisc ammoScript;
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
        Debug.Log("STARTED");
     ui.text = "0";       
     yield return new WaitForSeconds(0.65f);
     ui.text = "1";              
     yield return new WaitForSeconds(0.55f);          
     ui.text = "2";
     yield return new WaitForSeconds(0.55f);
     ui.text = "3";
     yield return new WaitForSeconds(1.051f);
     courotineOn = false;

     }
}
