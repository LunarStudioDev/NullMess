using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chargeGlock : MonoBehaviour
{
    public testAnimation gunScript;
    public Slider slider;
    
    void Update()
    {
        slider.value = gunScript.powerMeter;
    }


}
