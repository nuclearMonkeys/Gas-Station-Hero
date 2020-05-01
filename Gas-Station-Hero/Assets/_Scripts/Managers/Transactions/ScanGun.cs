using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScanGun : MonoBehaviour
{
    public  CashRegister REGISTER;
    public void scanning(float price, GameObject item)
    {
        REGISTER.scanned(price);

        REGISTER.scannedItems.Add(item.GetComponent<Draggable>());
    }
   

    // Start is called before the first frame update

    
}
