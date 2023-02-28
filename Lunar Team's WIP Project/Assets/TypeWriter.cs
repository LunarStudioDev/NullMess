using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TypeWriter : MonoBehaviour
{

    public float delay = 0.1f;
    public string oldText;
    private string currentText = "";
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TextShow());
    }

    IEnumerator TextShow(){
     for(int i=0; i < (oldText.Length + 1); i++){
        currentText = oldText.Substring(0, i);
        Debug.Log(currentText);
        this.GetComponent<TextMeshProUGUI>().text = currentText;
        yield return new WaitForSeconds(delay);
     }
    }
}

