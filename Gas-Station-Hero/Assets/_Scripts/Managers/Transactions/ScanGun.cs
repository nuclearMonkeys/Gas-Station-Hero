using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScanGun : MonoBehaviour
{
    public  Text registerText;
    public float totalPrice;
    public void UpdatePrice(float price)
    {
        totalPrice += price;
        registerText.text = totalPrice.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        totalPrice = 0;
    }
}
