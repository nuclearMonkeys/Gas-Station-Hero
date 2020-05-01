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

    private float change;
    private bool FullPaymentRecieved = false;
    private const int BufferSize = 5;
    public List<Draggable> scannedItems = new List<Draggable>();
    public float[] scans = new float[BufferSize];
    public void scanned(float price)
    {
        for (int i = BufferSize - 1; i != 0; i--)
        {
            scans[i] = scans[i - 1];
        }
        scans[0] = price;

        totalPrice += price;
        UpdateRegisterDisplay(totalPrice);
    }
    private void UpdateRegisterDisplay(float price)
    {
        registerText.text = price.ToString("F2");
    }


    public void StartNewTransAction()       //CALL THIS BEFORE NEW TRANSACTION!
    {
        FullPaymentRecieved = false;
        totalPrice = 0;
        UpdateRegisterDisplay(0);
    }


    public void OnDrop(PointerEventData eventData)
    {
        GameObject payment = eventData.pointerDrag;
        CashPayment CashPayment = payment.GetComponent<CashPayment>();
        if (payment)
        {
            change = totalPrice - CashPayment.getAmout();
            if (change <= 0)        //when the entire amount due is paid
            {
                TOTAL_SALES_DAILY += totalPrice;
                UpdateRegisterDisplay(change);
                for (int i = 0; i < BufferSize; i++)
                {
                    scans[i] = 0;
                }
                Destroy(payment);
                FullPaymentRecieved = true;
                foreach(Draggable draggable in scannedItems)
                {
                    draggable.CanBeGiven = true;
                }
                scannedItems.RemoveRange(0, scannedItems.Count);
            }
            
        }
    }



    void Start()
    {
        StartNewTransAction();
        TOTAL_SALES_DAILY = 0;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            totalPrice -= scans[0];
            UpdateRegisterDisplay(totalPrice);
            for (int i = 0; i < BufferSize - 1; i++)
            {
                scans[i] = scans[i + 1];
            }
            scans[BufferSize - 1] = 0;
        }
    }
}
