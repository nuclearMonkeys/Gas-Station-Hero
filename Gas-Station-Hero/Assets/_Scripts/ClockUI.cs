using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockUI : MonoBehaviour
{
    public GameObject lineManager;
    private const float REAL_SECONDS_PER_IN_GAME_DAY = 450f; // 900 seconds = 15 minutes, 8 hour shifts = 5 minutes 
    private Transform clockHourHandTransform;
    private Transform clockMinuteHandTransform;
    private float day;
    public float hourFloat;
    public bool dayEnded = false;
    public GameObject closeUpButton;

    void Start()
    {
        clockMinuteHandTransform = transform.Find("minuteHand");
        clockHourHandTransform = transform.Find("hourHand");
    }

    void clockMovement()
    {
        day += Time.deltaTime / REAL_SECONDS_PER_IN_GAME_DAY; //Day increased by one every 900 seconds
        
        float dayNormalized = day%1f;


        float rotationDegreesPerDay = 360f;
        float hoursPerDay = 12f;
        clockMinuteHandTransform.eulerAngles = new Vector3(0,0, -dayNormalized * rotationDegreesPerDay * hoursPerDay);
        
     
        clockHourHandTransform.eulerAngles = new Vector3(0,0, -dayNormalized * rotationDegreesPerDay);
        
        hourFloat = Mathf.Floor(dayNormalized * hoursPerDay);
    }

    // Update is called once per frame
    void Update() 
    {
        if(dayEnded == false) { 
            clockMovement();
                                 // Adjust to 1f for debug 
            if(12f > hourFloat && hourFloat >= 8f)
            {
                // crossfadeImage.SetActive(true);
                // crossfadeImage.GetComponent<CanvasGroup>().alpha = 0;
                // Color c = crossfadeImage.GetComponent<SpriteRenderer>().color;
                // c.a = 0;
                // crossfadeImage.GetComponent<SpriteRenderer>().color = c; 
				LineSystem.instance.endDayBool = true;
				CashRegister.instance.scannedPaymentCount = 0;
				DiscountBarcode.instance.alreadyScanned = false;
				CashRegister.instance.totalPrice = 0;
				CashRegister.instance.oneScan = false;
				LineSystem.instance.totalItems = 0;
				LineSystem.instance.customer.SetActive(false);
				DiscountBarcode.instance.customerNotEnoughMoney = false;
				CashRegister.instance.change = 0;
				CashRegister.instance.UpdateRegisterDisplay(CashRegister.instance.change);
				while (CashRegister.instance.paymentList.Count != 0)
				{
					Destroy(CashRegister.instance.paymentList[0]);
					CashRegister.instance.paymentList.RemoveAt(0);
				}
				CashRegister.instance.scannedItems.RemoveRange(0, CashRegister.instance.scannedItems.Count);
				for (int i = 0; i < CashRegister.instance.BufferSize; i++)
				{
					CashRegister.instance.scans[i] = 0;
				}
				foreach(GameObject g in LineSystem.instance.items)
				{
					Destroy(g);
				}
                closeUpButton.SetActive(true);
                lineManager.GetComponent<LineSystem>().endDay();
                dayEnded = true;
            }

        }
    }
    
}
