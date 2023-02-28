using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTrans;
    public RectTransform panel;
    public Canvas myCanvas;
    private CanvasGroup canvasGroup;

    public codeHolder codeHolder;
    public moveScript square;
    public int id;
    void Start() {
        rectTrans = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    
    void Update()
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
        canvasGroup.blocksRaycasts = false;
        codeHolder.functionCode.SetActive(true);
        square.moveValue = 0;    
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        
        rectTrans.anchoredPosition += eventData.delta / (panel.localScale / 0.85f);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
        canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

}
