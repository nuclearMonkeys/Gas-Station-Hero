using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScanGun : MonoBehaviour
{
    public  CashRegister REGISTER;
    public void scanning(float price, GameObject item)
    {
		if(item.name == "Discount" && item.transform.GetChild(1).GetComponent<DiscountBarcode>().canBeScanned && !item.transform.GetChild(1).GetComponent<Barcode>().alreadyScanned)
		{
			REGISTER.scanned(price);
			item.transform.GetChild(1).GetComponent<DiscountBarcode>().alreadyScanned = true;
			item.transform.GetChild(1).GetComponent<DiscountBarcode>().customerNotEnoughMoney = false;
            print("DISCOUNT SCANNED");
		}
		else if(item.name != "Discount" && !item.transform.GetChild(1).GetComponent<Barcode>().alreadyScanned)
		{
			REGISTER.scanned(price);
            print("ITEM SCANNED");
			item.transform.GetChild(1).GetComponent<Barcode>().alreadyScanned = true;
			item.GetComponent<Draggable>().canBeGiven = true;
			REGISTER.scannedItems.Add(item.GetComponent<Draggable>());
		}
    }
   

    // Start is called before the first frame update

    
}
