using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    public Slider slider;

    public float startHealth = 100f;

    public void SetMaxHealth(float health){
        slider.maxValue = health;
        slider.value = health;
        startHealth = slider.value;
        isHpZero();
    }

    public void SetHealth(float health){
        slider.value = health;
        startHealth = slider.value;
        isHpZero();
    }

    private void isHpZero(){
        if (startHealth < 1){
         SetHealth(100);
        }
    }
}
