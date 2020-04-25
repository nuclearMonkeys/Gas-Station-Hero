using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    
    public void OnPointerEnter(PointerEventData eventData) //maybe use this for highlighting object
    {
    }

    public void OnPointerExit(PointerEventData eventData) //above
    {
    }

    public void OnDrop(PointerEventData eventData) 
    {
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if(d) 
        {
            d.isOverCounter = true;
        }
    }
}
