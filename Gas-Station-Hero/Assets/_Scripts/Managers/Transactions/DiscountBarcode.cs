using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DiscountBarcode : Barcode
{	
	public static DiscountBarcode instance = null;
	
	public GameObject register;
	public GameObject lineSystem;
	public bool canBeScanned = false;
	public bool customerNotEnoughMoney = false;
    // Start is called before the first frame update
    void Start()
    {
        if(instance)
            Destroy(this.gameObject);
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(register.GetComponent<CashRegister>().scannedItems.Count == lineSystem.GetComponent<LineSystem>().totalItems && register.GetComponent<CashRegister>().scannedPaymentCount == register.GetComponent<CashRegister>().paymentList.Count && register.GetComponent<CashRegister>().change > 0)
		{
			customerNotEnoughMoney = true;
			price = register.GetComponent<CashRegister>().change * (-1);
			canBeScanned = true;
		}
		else
		{
			price = 0;
			canBeScanned = false;
		}
    }
}
