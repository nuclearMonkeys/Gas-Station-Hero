using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class Reciept : Draggable
{
	public GameObject register;
	public GameObject line_manager;
	public GameObject statsHolder;
	
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
		if(register.GetComponent<CashRegister>().paymentList.Count == 0 && line_manager.GetComponent<LineSystem>().items[0] == null && register.GetComponent<CashRegister>().oneScan)
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
			register.GetComponent<CashRegister>().totalPrice = 0;
			statsHolder.GetComponent<Stats>().customersServed += 1;
			line_manager.GetComponent<LineSystem>().customers[0].GetComponent<InLineCustomerBehavior>().ordering = false;
        }
		
        // This will cause an error if no customer is in front
        // Of the counter
    }
}
