using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScanGun : MonoBehaviour
{
    public  Text registerText;
    public float totalPrice;
    private const int BufferSize = 5;
    public float[] scans = new float[BufferSize];
    public void scanned(float price)
    {
        for (int i = BufferSize-1; i != 0; i--)
         {
             scans[i] = scans[i - 1];
         }
        scans[0] = price;
        UpdatePrice(price);
    }
    private void UpdatePrice(float price)
    {
        totalPrice += price;
        registerText.text = totalPrice.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        totalPrice = 0;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            UpdatePrice(-scans[0]);
            for (int i = 0; i < BufferSize-1; i++)
            {
                scans[i] = scans[i + 1];
            }

            scans[BufferSize-1] = 0;

        }
    }
}
