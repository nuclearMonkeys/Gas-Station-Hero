using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public bool isOverCounter = false;
    public bool CanBeGiven;

    public Transform parent;
    protected bool falling = false;
    protected bool given = false;
    protected bool enter = false;
    protected int DisappearCounter = 60;
    protected float speed;
    protected Vector2 ReturningPosition;
    protected Vector2 CursorOffset;

    // This is weird practice, but this is specifically used for reciepts
    public virtual void Update() 
    {
        
        if (enter)
        {
            if (speed <0)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
                speed += 7f;
            }
            else
            {
                speed = 0;
                enter = false;
            }
        }
        else if (falling)//if its falling because it was failed to give to customer, it will return to starting location very fast
        {
            if (0.1f < ((Vector2)transform.position - ReturningPosition).magnitude)
            {
                transform.position = Vector2.MoveTowards(transform.position, ReturningPosition, speed * Time.deltaTime);
            }
            else
            {
                falling = false;
            }
        }
        else if(given)
        {
            if(DisappearCounter-- > 0)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
                speed += 20;
            }
            else
            {
                given = false;
            }
        }
    }


    public void OnBeginDrag(PointerEventData eventData) 
    {
        parent = transform.parent;          //needed to set the layer order
        transform.SetParent(parent.parent); //needed to set the layer order
        ReturningPosition = transform.position;     //if its placed on invalid spot, this is where the item will return to
        CursorOffset = eventData.position - (Vector2)transform.position;    //optional
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }



    public void OnDrag(PointerEventData eventData) 
    {
        transform.position = eventData.position - CursorOffset;
    }



    public virtual void OnEndDrag(PointerEventData eventData) 
    {
        transform.SetParent(parent);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        print("Ended Drag");
        if (isOverCounter)
        {
            if(CanBeGiven)//if the item can be given, it will be given to the customer and disappear
            {
                print("you're an all star");
                transform.SetParent(parent.parent);
                transform.SetSiblingIndex(transform.GetSiblingIndex() - 2);  //Item will now drop behind the counter
                speed = -150;       //will initially go upwards 
                given = true;
				if(gameObject.name == "Item")
				{
					Destroy(gameObject);
				}
                //CALL EXTRA FUNCTIOSN TO TAKE IMPACT!
            }
            else//Will drop the item if the item cannot be given
            {
                ItemFall();
            }
        }
        isOverCounter = false;
    }


    public void ItemFall()
    {
        speed = ((Vector2)transform.position - ReturningPosition).magnitude * 10;
        falling = true;
    }
    /*
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
    }*/

    public void ItemEnter()
    {
        GetComponent<Image>().GetComponent<CanvasRenderer>().SetAlpha(0.1f);

        GetComponent<Image>().CrossFadeAlpha(1f, 0.2f, false);
        speed = -150;
        enter = true;

    }
}
