﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData) 
    {
    }

    public void OnPointerExit(PointerEventData eventData) 
    {
    }

    public void OnDrop(PointerEventData eventData) 
    {
        Debug.Log(eventData.pointerDrag.name + "was dropped on " + gameObject.name);
        
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if(d) 
        {
           // d.parentToReturnTo = this.transform;
        }
    }
}
