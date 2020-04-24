using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Vector2 ReturningPosition;
    public Vector2 CursorOffset;
    public float MaxSpeed = 2;
    private float updateSpeedSec = 0.7f;
    private bool isOverCounter;
    private bool CanBeGiven;
    private bool falling = false;
    
    private void Update() 
    {
        if(falling) 
        {
            if (0.1f < ((Vector2)transform.position - ReturningPosition).magnitude)
            {
                transform.position = Vector2.MoveTowards(transform.position, ReturningPosition, MaxSpeed * Time.deltaTime);
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData) 
    {
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
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if (isOverCounter)
        {
            //
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
