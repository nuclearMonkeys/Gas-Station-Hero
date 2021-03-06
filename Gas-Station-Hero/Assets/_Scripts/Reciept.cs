﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class Reciept : Draggable
{
	// public GameObject register;
	// public GameObject line_manager;
	// public GameObject statsHolder;
	
	public Vector3 originalLocation;
	public static Reciept instance;
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
		canBeGiven = false;
		originalLocation = transform.position;
		if(instance)
            Destroy(this.gameObject);
        instance = this;
    }
	
	void Update()
	{
		if(CashRegister.instance.paymentList.Count == 0 && LineSystem.instance.itemsEmpty && CashRegister.instance.oneScan)
		{
			canBeGiven = true;
		}
		else
		{
			canBeGiven = false;
		}
	}

    public override void OnEndDrag(PointerEventData eventData) 
    {
        //base.OnBeginDrag(eventData);
		transform.SetParent(parent);
		GetComponent<CanvasGroup>().blocksRaycasts = true;
        if (isOverCounter && canBeGiven && !isTaken)
        {
            //print("you're an allstar");
            LineSystem.instance.MoveLine();
			CashRegister.instance.scannedPaymentCount = 0;
			DiscountBarcode.instance.alreadyScanned = false;
			transform.position = originalLocation;
			CashRegister.instance.totalPrice = 0;
		    Stats.instance.customersServed += 1;
			CashRegister.instance.oneScan = false;
			LineSystem.instance.totalItems = 0;
            KanpurWarningManager.instance.CheckTransaction(true, true);
            LineSystem.instance.customer.SetActive(false);
            Destroy(this.gameObject);
			
        }
        else if (isOverCounter && !canBeGiven)
        {
            gameObject.transform.position = originalLocation;
        }
		
        // This will cause an error if no customer is in front
        // Of the counter
    }
	public void destroyReciept()
	{
		Destroy(this.gameObject);
	}
}
