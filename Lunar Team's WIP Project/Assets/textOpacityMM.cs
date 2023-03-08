using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class textOpacityMM : MonoBehaviour
{

private Color textColor;
public GameObject background;

    // Update is called once per frame
    void Update()
    {
        textColor.a = background.GetComponent<Image>().color.a;
        var thisText = this.GetComponent<TMP_Text>().color;
        thisText.a = textColor.a;

        this.GetComponent<TMP_Text>().color = thisText;
        
    }
}
