using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class Reciept : Draggable
{
	// public GameObject register;
	// public GameObject line_manager;
	// public GameObject statsHolder;
	
	public Vector3 originalLocation;
	
    private bool isTaken = false;

    // public override void Update()
    // {
    //     base.Update();
    //     if (falling)
    //         print("hey now");
    //     if (falling && !isTaken) 
    //     {
    //         // print(falling);
    //         LineSystem.instance.MoveLine();
    //         isTaken = true;
    //     }
    // }

    private void Start() 
    {
        //print(LineSystem.instance);
        //print("Hey now");
		CanBeGiven = false;
		originalLocation = transform.position;
		
    }
	
	void Update()
	{
		if(CashRegister.instance.paymentList.Count == 0 && LineSystem.instance.itemsEmpty && CashRegister.instance.oneScan)
		{
			CanBeGiven = true;
		}
		else
		{
			CanBeGiven = false;
		}
	}

    public override void OnEndDrag(PointerEventData eventData) 
    {
        //base.OnBeginDrag(eventData);
		transform.SetParent(parent);
		GetComponent<CanvasGroup>().blocksRaycasts = true;
        if (isOverCounter && CanBeGiven && !isTaken)
        {
            //print("you're an allstar");
            LineSystem.instance.MoveLine();
			transform.position = originalLocation;
			CashRegister.instance.totalPrice = 0;
		    Stats.instance.customersServed += 1;
			CashRegister.instance.oneScan = false;
			LineSystem.instance.totalItems = 0;
            KanpurWarningManager.instance.CheckTransaction(true, true);
            LineSystem.instance.customer.SetActive(false);
            Destroy(this.gameObject);
			
        }
		
        // This will cause an error if no customer is in front
        // Of the counter
    }
}
