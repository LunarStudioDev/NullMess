using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class codeHolder : MonoBehaviour, IDropHandler
{
    public GameObject functionCode;
    public GameObject textHolder;
    public GameObject text7;
    public GameObject text8;
    public moveScript square1;
    //public MoveScript2 square;
    public float id;

    private bool hasBeenDone = true;

    private void Awake()
    {
        hasBeenDone = false;
    }
    private void Start(){
        if(!hasBeenDone){
            textHolder.SetActive(false);
         text7.SetActive(true);
         StartCoroutine(waiter());
        }
        hasBeenDone = true;
    }

    void OnDisable()
    {
        text7.SetActive(false);
        text8.SetActive(false);
    }

    IEnumerator waiter()
    {
    yield return new WaitForSeconds(12f);
    text7.SetActive(false);
    text8.SetActive(true);
    yield return new WaitForSeconds(17f);
    text8.SetActive(false);
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null){
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = this.GetComponent<RectTransform>().anchoredPosition;
                functionCode.SetActive(false);
                square1.moveValue = 1;
                eventData.pointerDrag.GetComponent<DragAndDrop>().insideId = id;

            }
        }
    }
    public void onPick(float insideId){
     if(insideId==id){
        functionCode.SetActive(true); 
        square1.moveValue = 0;
     }
    }

}
