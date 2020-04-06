using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform parentToReturnTo = null;
    private float updateSpeedSec = 0.7f;
    private bool isOverCounter;

    private void Update() 
    {
        if(isOverCounter) 
        {
            StartCoroutine(DropObject());
        }
    }

    public void OnBeginDrag(PointerEventData eventData) 
    {
        parentToReturnTo = transform.parent;
        transform.SetParent( transform.parent.parent );

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData) 
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData) 
    {
        transform.SetParent( parentToReturnTo );
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        if(parentToReturnTo.CompareTag("OverTheCounter")) 
        {
            isOverCounter = true;
        }
    }

    private IEnumerator DropObject() 
    {
        float elapsed = 0.0f;
        while(elapsed < updateSpeedSec) 
        {
            elapsed += Time.deltaTime;
            transform.position -= new Vector3(0, elapsed * 4.4f, 0);
            yield return new WaitForEndOfFrame();
        }
        print(gameObject.name);
        Destroy(gameObject);
        yield break;
    }
}
