using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CashRegister : MonoBehaviour, IDropHandler
{
    public Text registerText;

    public float TOTAL_SALES_DAILY;             //total amount of payment recieved today
    public float totalPrice;                    //current transaction total
    private const int BufferSize = 5;
    public float[] scans = new float[BufferSize];
    public void scanned(float price)
    {
        for (int i = BufferSize - 1; i != 0; i--)
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
        TOTAL_SALES_DAILY = 0;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            UpdatePrice(-scans[0]);
            for (int i = 0; i < BufferSize - 1; i++)
            {
                scans[i] = scans[i + 1];
            }

            scans[BufferSize - 1] = 0;

        }
    }


    public void OnDrop(PointerEventData eventData)
    {
        GameObject payment = eventData.pointerDrag;
        CashPayment CashPayment = payment.GetComponent<CashPayment>();
        if (payment)
        {
            TOTAL_SALES_DAILY += CashPayment.getAmout();
            totalPrice = 0;
            for (int i = 0; i < BufferSize; i++)
            {
                scans[i] = 0;
            }
            Destroy(payment);
        }

    }
}
