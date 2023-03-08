using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class opacityMainMenu : MonoBehaviour
{

private Color color;

    void Start()
    {
        
        color = this.GetComponent<Image>().color;
        StartCoroutine(colorChange());
    }

    IEnumerator colorChange(){
        while(true){
            yield return new WaitForSeconds(0.001f);
            color.a = color.a + 0.0005f;
            this.GetComponent<Image>().color = color;
            
        }
    }
}
