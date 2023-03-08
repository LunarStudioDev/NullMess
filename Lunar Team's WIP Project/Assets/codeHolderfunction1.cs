using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class codeHolderfunction1 : MonoBehaviour, IDropHandler
{
    public GameObject functionCode;
    
    public textShow showText;

    public MoveScript2 square;
    public float id;

    private bool hasBeenDone = true;

    private void Awake()
    {
        hasBeenDone = false;
    }
    private void Start(){
        if (!hasBeenDone){
        showText.startText();
        }
    hasBeenDone = true;  
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null){
            {
                string numberStorage = eventData.pointerDrag.GetComponentInChildren<TextMeshProUGUI>().text;
                print(numberStorage);
                float desiredNumber = Convert.ToInt16(numberStorage);
                DragAndDrop script = eventData.pointerDrag.GetComponent<DragAndDrop>();
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = this.GetComponent<RectTransform>().anchoredPosition;
                functionCode.SetActive(false);
                square.moveValueY = desiredNumber;
                script.insideId = id;
            }
        }
    }
    public void onPick(float insideId){

     if(insideId==id){

        functionCode.SetActive(true); 
        square.moveValueY = 0;
     }
    }
}
