using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTrans;
    public RectTransform panel;
    public Canvas myCanvas;
    private CanvasGroup canvasGroup;

    public codeHolder codeHolder;
    public codeHolderfunction3 codeHolderf3;
    public CodeHolderfunction2 codeHolderf2;
    public codeHolderfunction1 codeHolderf1;

    
    public moveScript square;
    public int id = 1;
    public float insideId = 1;
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
            codeHolder.onPick(insideId);
            codeHolderf3.onPick(insideId);
            codeHolderf2.onPick(insideId);
            codeHolderf1.onPick(insideId);
            insideId = 0;
        //codeHolder.functionCode.SetActive(true);
        //square.moveValue = 0;    
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
