using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class Reciept : Draggable
{
	public GameObject register;
	public GameObject line_manager;
	public GameObject statsHolder;
	
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
        print(LineSystem.instance);
        print("Hey now");
		CanBeGiven = false;
    }
	
	void Update()
	{
		if(register.GetComponent<CashRegister>().paymentList.Count == 0 && line_manager.GetComponent<LineSystem>().items[0] == null)
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
        base.OnBeginDrag(eventData);
        if (isOverCounter && CanBeGiven && !isTaken)
        {
            print("you're an allstar");
            LineSystem.instance.MoveLine();
            isTaken = true;
			transform.position = ReturningPosition;
			isTaken = false;
			register.GetComponent<CashRegister>().totalPrice = 0;
			statsHolder.GetComponent<Stats>().customersServed += 1;
        }
        // This will cause an error if no customer is in front
        // Of the counter
    }
}
