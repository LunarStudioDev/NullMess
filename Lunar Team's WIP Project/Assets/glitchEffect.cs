using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class glitchEffect : MonoBehaviour
{
    private Vector3 ogUiPosition;
    private Vector3 updatedUiPosition;
    private Vector3 newUiPosition;
    private Color col;
    private Image img;
    public float delay = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        img = this.GetComponent<Image>();
        ogUiPosition = transform.position;
        updatedUiPosition = transform.position;
        StartCoroutine(waiter());
    }
    void Update(){
        img = this.GetComponent<Image>();
        col = img.color;
        col.a = img.color.a + (0.25f * Time.deltaTime);
        img.color = col;
    }
    IEnumerator waiter(){
     for(int i=0; i < 70; i++){
     transform.position = ogUiPosition;
     transform.localPosition = new Vector3(transform.localPosition.x + (Random.Range(-5f, 5f)), transform.localPosition.y + (Random.Range(-5f, 5f)), transform.localPosition.z);;
     yield return new WaitForSeconds(delay);
     }
     for(int i=0; i < 10; i++){
     transform.position = ogUiPosition;
     transform.localPosition = new Vector3(transform.localPosition.x + (Random.Range(-2.5f, 2.5f)), transform.localPosition.y + (Random.Range(-2.5f, 2.5f)), transform.localPosition.z);;
     yield return new WaitForSeconds(delay);
     }
     for(int i=0; i < 10; i++){
     transform.position = ogUiPosition;
     transform.localPosition = new Vector3(transform.localPosition.x + (Random.Range(-1f, 1f)), transform.localPosition.y + (Random.Range(-1f, 1f)), transform.localPosition.z);;
     yield return new WaitForSeconds(delay);
     }
     transform.position = ogUiPosition;
    }

  

            
}
