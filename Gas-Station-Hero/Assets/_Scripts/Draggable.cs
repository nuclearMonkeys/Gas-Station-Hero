using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform parentToReturnTo = null;
    private float updatae;
    private bool isOverCounter;

    private void Update() 
    {
        if(isOverCounter) 
        {
            transform.position -= new Vector3(0, 9.8f * Time.deltaTime, 0);
        }
    }

    public void OnBeginDrag(PointerEventData eventData) 
    {
        Debug.Log("OnBeginDrag");
        parentToReturnTo = transform.parent;
        transform.SetParent( transform.parent.parent );

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData) 
    {
        Debug.Log("OnDrag");
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData) 
    {
        Debug.Log("OnEndDrag");
        transform.SetParent( parentToReturnTo );
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        if(parentToReturnTo.CompareTag("OverTheCounter")) 
        {
            isOverCounter = true;
        }
    }

    private IEnumerator DropObject() 
    {
        
        yield return new WaitForRealTimeSecs(1.0f);
    }
}
