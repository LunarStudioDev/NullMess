using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TypeWriter : MonoBehaviour
{

    public float delay = 0.1f;
    public string oldText;
    private string currentText = "";
    public GameObject textPanel;

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
     textPanel.SetActive(false);
     this.gameObject.SetActive(false);
    }
}

