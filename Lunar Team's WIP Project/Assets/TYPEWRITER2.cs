using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TYPEWRITER2 : MonoBehaviour
{
public float delay = 0.1f;
    public string oldText;
    private string currentText = "";
    public GameObject textPanel;
    public GameObject text2;    

    public float dissapear = 5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TextShow());
        textPanel.SetActive(true);

    }

    IEnumerator TextShow(){
     for(int i=0; i < (oldText.Length + 1); i++){
        currentText = oldText.Substring(0, i);
        this.GetComponent<TextMeshProUGUI>().text = currentText;
        yield return new WaitForSeconds(delay);
     }
     yield return new WaitForSeconds(dissapear);
     text2.SetActive(true);
     textPanel.SetActive(false);
     this.gameObject.SetActive(false);
    }
}
