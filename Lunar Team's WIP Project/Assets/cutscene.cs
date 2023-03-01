using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Diagnostics;

public class cutscene : MonoBehaviour
{
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
    public GameObject panel;

    public AudioSource audio1;
    private Image img;

    public Animator cameraAnimator;

    public GameObject positionCamera;
    public GameObject hands;
private Color col;
    private bool isDone;

    public playerMovement script1;
    public lookingScript script2;

    public moveCamera script3;

    public GameObject hpUI1;
    public GameObject hpUI2;
    public GameObject hpUI3;
    public GameObject hpUI4;
    void Start()
    {
        isDone = false;
        panel.SetActive(true);
    StartCoroutine(waiter());
    audio1.Play();

    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(isDone){
            //panel2.SetActive(true);
            img = panel.GetComponent<Image>();
            col = img.color;
            col.a = (img.color.a) - (0.25f * Time.deltaTime);
            img.color = col;


        }
    }

    void functionGo(){
        functionGo();
    }
    IEnumerator waiter()
    {
    yield return new WaitForSeconds(3.5f);
    text1.SetActive(true);
    yield return new WaitForSeconds(1.0f);
    Utils.ForceCrash(ForcedCrashCategory.MonoAbort);
    yield return new WaitForSeconds(2.5f);
    text2.SetActive(true);
    yield return new WaitForSeconds(1.75f);
    text3.SetActive(true);
    yield return new WaitForSeconds(1.75f);
    text4.SetActive(true);
    yield return new WaitForSeconds(3.5f);
    //text1.SetActive(false);
    //text2.SetActive(false);
   // text3.SetActive(false);
    text4.SetActive(false);
   // yield return new WaitForSeconds(1f);
    isDone = false;
    hands.SetActive(true);
   // yield return new WaitForSeconds(2f);
    cameraAnimator.SetTrigger("animationTrigger");
    //yield return new WaitForSeconds(1f);
    hpUI1.SetActive(true);
    hpUI2.SetActive(true);
    hpUI3.SetActive(true);
    hpUI4.SetActive(true);
   yield return new WaitForSeconds(5f);
    cameraAnimator.enabled = false;
    positionCamera.SetActive(true);
    script1.enabled = true;
    script2.enabled = true;
    script3.enabled = true;
    hands.SetActive(false);
    //yield return new WaitForSeconds(15f);
    isDone = false;
    panel.SetActive(false);
    }
}
