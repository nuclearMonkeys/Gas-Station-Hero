using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Barcode : MonoBehaviour, IDropHandler
{
    public GameObject CounterManager;
    public float price;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnDrop(PointerEventData eventData)
    {
        GameObject d = eventData.pointerDrag;
        if (d.GetComponent<ScanGun>())
        {
            d.GetComponent<Draggable>().ItemFall();
            d.GetComponent<ScanGun>().UpdatePrice(price);
        }
    }
}
