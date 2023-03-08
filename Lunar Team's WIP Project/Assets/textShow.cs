using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textShow : MonoBehaviour
{
    public GameObject text9;
    public GameObject text10;
    public GameObject text11;
    public GameObject text12;
    public GameObject text13;
    public GameObject text14;
    public GameObject text15;
    // Start is called before the first frame update
    public void startText(){
        StartCoroutine(showText());
    }

    IEnumerator showText(){
        text9.SetActive(true);
        yield return new WaitForSeconds(15f);
        text9.SetActive(false);
        text10.SetActive(true);
        yield return new WaitForSeconds(15f);
        text10.SetActive(false);
        text11.SetActive(true);
        yield return new WaitForSeconds(15f);
        text11.SetActive(false);
        text12.SetActive(true);
        yield return new WaitForSeconds(15f);
        text12.SetActive(false);
        text13.SetActive(true);
         yield return new WaitForSeconds(15f);
        text13.SetActive(false);
        text14.SetActive(true);
         yield return new WaitForSeconds(15f);
        text14.SetActive(false);
        text15.SetActive(true);
        yield return new WaitForSeconds(15f);

    }
}
