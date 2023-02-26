using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class codeHolder : MonoBehaviour, IDropHandler
{
    public GameObject functionCode;
    public moveScript square;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null){
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = this.GetComponent<RectTransform>().anchoredPosition;
            functionCode.SetActive(false);
            square.moveValue = 1;
        }
    }

}
