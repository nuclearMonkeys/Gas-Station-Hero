using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    
    public Vector2 ReturningPosition;
    public Vector2 CursorOffset;
    public bool isOverCounter;


    private Transform parent;
    private float updateSpeedSec = 0.7f;
    private bool CanBeGiven;
    private bool falling = false;
    private float speed;

    private void Update() 
    {
        if(falling) 
        {
            Debug.Log("working");
            if (0.1f < ((Vector2)transform.position - ReturningPosition).magnitude)
            {
                transform.position = Vector2.MoveTowards(transform.position, ReturningPosition, speed * Time.deltaTime);
            }
            else
            {
                falling = false;
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData) 
    {
        parent = transform.parent;
        //Debug.Log(transform.position);
        transform.SetParent(parent.parent); 
        ReturningPosition = transform.position;
        CursorOffset = eventData.position - (Vector2)transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData) 
    {
        transform.position = eventData.position - CursorOffset;
    }

    public void OnEndDrag(PointerEventData eventData) 
    {
        transform.SetParent(parent);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        speed = ((Vector2)transform.position - ReturningPosition).magnitude*10;
        falling = true;
        /*
        if (isOverCounter)
        {
            
        }*/
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
