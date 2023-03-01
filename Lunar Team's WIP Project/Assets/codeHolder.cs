using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class codeHolder : MonoBehaviour, IDropHandler
{
    public GameObject functionCode;
    public moveScript square1;
    //public MoveScript2 square;
    public int id;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null){
            {
                //if(eventData.pointerDrag.GetComponent<DragAndDrop>().id == 1){
               //     
              //  }
            
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = this.GetComponent<RectTransform>().anchoredPosition;
            //functionCode.SetActive(false);
            //square1.moveValue = 1;
            }
        }
    }

}
