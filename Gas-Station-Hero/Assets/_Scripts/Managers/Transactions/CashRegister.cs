using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CashRegister : MonoBehaviour, IDropHandler
{

    public Text registerText;

    public static CashRegister instance;

    public float TOTAL_SALES_DAILY;             //total amount of payment recieved today
    public float totalPrice;                    //current transaction total

    public float change;
    private bool FullPaymentRecieved = false;
    private const int BufferSize = 5;
    public List<Draggable> scannedItems = new List<Draggable>();
    public float[] scans = new float[BufferSize];
	public List<GameObject> paymentList = new List<GameObject>();
	public bool oneScan = false;
	public int scannedPaymentCount = 0;
	
    public void scanned(float price)
    {
        for (int i = BufferSize - 1; i != 0; i--)
        {
            scans[i] = scans[i - 1];
        }
        scans[0] = price;
		oneScan = true;
        totalPrice += price;
        change += price;
        UpdateRegisterDisplay(change);
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
        if (CashPayment)
        {
            change -= CashPayment.getAmount();
			payment.SetActive(false);
            UpdateRegisterDisplay(change);
			scannedPaymentCount += 1;
            
        }
    }



    void Start()
    {
        if(instance)
            Destroy(this.gameObject);
        instance = this;

        StartNewTransAction();
        TOTAL_SALES_DAILY = 0;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            LineSystem.instance.MoveLine();
			scannedPaymentCount = 0;
			DiscountBarcode.instance.alreadyScanned = false;
			totalPrice = 0;
			oneScan = false;
			LineSystem.instance.totalItems = 0;
            LineSystem.instance.customer.SetActive(false);
			Reciept.instance.destroyReciept();
			DiscountBarcode.instance.customerNotEnoughMoney = false;
			change = 0;
			UpdateRegisterDisplay(change);
			while (paymentList.Count != 0)
			{
				Destroy(paymentList[0]);
				paymentList.RemoveAt(0);
			}
			scannedItems.RemoveRange(0, scannedItems.Count);
			for (int i = 0; i < BufferSize; i++)
            {
                scans[i] = 0;
            }
			foreach(GameObject g in LineSystem.instance.items)
			{
				Destroy(g);
			}
        }
		if (change <= 0)        //when the entire amount due is paid
            {
                TOTAL_SALES_DAILY += totalPrice;
                for (int i = 0; i < BufferSize; i++)
                {
                    scans[i] = 0;
                }
                while (paymentList.Count != 0 && oneScan == true)
				{
					Destroy(paymentList[0]);
					paymentList.RemoveAt(0);
				}
                FullPaymentRecieved = true;/*
                foreach(Draggable draggable in scannedItems)
                {
                    draggable.CanBeGiven = true;
                }*/
                scannedItems.RemoveRange(0, scannedItems.Count);
				
            }
    }
}
