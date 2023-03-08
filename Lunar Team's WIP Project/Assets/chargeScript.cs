using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chargeScript : MonoBehaviour
{

    public Slider slider;
    public bool isChanging = false;
    void Update()
    {
        StartCoroutine(chargeDown());
    }

    public void addCooldown(float addon){
        slider.value = slider.value + addon;
    }
    IEnumerator chargeDown(){
        if(!isChanging){

        if(slider.value > 0){
         isChanging = true;
         while(slider.value > 0){
            yield return new WaitForSeconds(0.1f);
            slider.value = slider.value - 1;
         }
         isChanging = false;
        }
        }

    }
}
