using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScanGun : MonoBehaviour
{
    public  CashRegister REGISTER;
    public void scanning(float price, GameObject item)
    {
		if(!item.transform.GetChild(1).GetComponent<Barcode>().alreadyScanned)
		{
			REGISTER.scanned(price);
			item.transform.GetChild(1).GetComponent<Barcode>().alreadyScanned = true;
			item.GetComponent<Draggable>().CanBeGiven = true;
			REGISTER.scannedItems.Add(item.GetComponent<Draggable>());
		}
    }
   

    // Start is called before the first frame update

    
}
