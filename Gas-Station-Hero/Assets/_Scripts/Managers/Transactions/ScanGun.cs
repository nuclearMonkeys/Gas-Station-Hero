using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScanGun : MonoBehaviour
{
    public  CashRegister REGISTER;
    public void scanning(float price)
    {
        REGISTER.scanned(price);
    }
   

    // Start is called before the first frame update


}
