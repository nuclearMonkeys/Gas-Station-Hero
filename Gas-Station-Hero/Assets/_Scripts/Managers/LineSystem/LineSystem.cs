using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LineSystem : MonoBehaviour
{
    public static LineSystem instance;
    private const int maxNumCustomer = 6;
    private int totalCustomer;
    public GameObject[] customers = new GameObject[maxNumCustomer];
    public Vector2[] LineSpot = new Vector2[maxNumCustomer];
	public GameObject[] items = new GameObject[10];

    public GameObject customerPrefab;
	public GameObject chips;
    public GameObject customerSpawnPoint;
	public GameObject customer;
	public GameObject panel;
	public GameObject oneCent;
	public GameObject fiveCent;
	public GameObject tenCent;
	public GameObject quarterCent;
	public GameObject oneDollar;
	public GameObject fiveDollar;
	public GameObject tenDollar;
	public GameObject twentyDollar;
	public GameObject register;
	

    /*=======================
     * Start spawning customer 1 at a time
     * =========================*/
    // Start is called before the first frame update
    void Start()
    {
        if (instance)
            Destroy(this);
        instance = this;
        startDay();
    }

    // Update is called once per frame
    void Update()
    {
		customerOrder();
        if (Input.GetKeyUp(KeyCode.Space))
        {
            MoveLine();
        }

        else if (Input.GetKeyUp(KeyCode.L)) 
        {
            print("");
            endDay();
        }
    }

    public void startDay()
    {
        StartCoroutine(SpwanCustomer());
    }
    IEnumerator SpwanCustomer()//part of above
    {
        for (int index = 0; index < maxNumCustomer; index++)
        {
            yield return new WaitForSeconds(1);//change here to adjust spawn rate
            customers[index] = Instantiate(customerPrefab, customerSpawnPoint.transform.localPosition, Quaternion.identity);
            customers[index].GetComponent<SpriteRenderer>().sortingLayerName = "Midground";
            customers[index].GetComponent<InLineCustomerBehavior>().moveUp( LineSpot[index]);
  
        }
    }

    public void endDay()
    {
        for (int i = 0; i < maxNumCustomer; i++)
        {
            InLineCustomerBehavior inLineCustomer = customers[i].GetComponent<InLineCustomerBehavior>();
            if (!inLineCustomer)
                continue;
            inLineCustomer.leave();
        }
    }

    /*================================
     * have the first customer to leave
     * and moves up the whole line by 1
     * then spawn 1 customer at the back of the line
     * ==============================*/
    public void MoveLine()
    {
        customers[totalCustomer % maxNumCustomer].GetComponent<InLineCustomerBehavior>().leave();
        customers[totalCustomer % maxNumCustomer] = Instantiate(customerPrefab, customerSpawnPoint.transform.position, Quaternion.identity);
        customers[totalCustomer % maxNumCustomer].GetComponent<InLineCustomerBehavior>().moveUp(LineSpot[maxNumCustomer - 1]);
        totalCustomer++;
        StartCoroutine(delayedMove());
    }
    IEnumerator delayedMove()//part of above
    {
        for (int i = 0; i < maxNumCustomer - 1; i++)
        {
            customers[(totalCustomer + i) % maxNumCustomer].GetComponent<InLineCustomerBehavior>().moveUp(LineSpot[i]);
            yield return new WaitForSeconds(0.4f);
        }
    }

	

    /*=======================
     * Returns total number of customers served
    * =========================*/
    public int getTotalCustomers()
    {
        return totalCustomer;
    }
	
	public void customerOrder()
	{
		if(customers[0]!= null && !customers[0].GetComponent<InLineCustomerBehavior>().moving && !customers[0].GetComponent<InLineCustomerBehavior>().ordering)
		{
			customers[0].GetComponent<InLineCustomerBehavior>().ordering = true;
			startTransaction();
		}
	}
	
	public void startTransaction()
	{
		customer.SetActive(true);
		float totalPrice = 0;
		for(int i = 0; i < (int)Random.Range(1.0f, 4.0f); i++)
		{
			GameObject t = Instantiate(chips, panel.transform);
			/*
			float temp = (float)System.Math.Round(Random.Range(1.04f, 1.07f),2);
			t.transform.GetChild(0).GetComponent<Barcode>().price = temp;
			*/
			t.name = "Item";
			totalPrice += t.transform.GetChild(1).GetComponent<Barcode>().price;
			items[i] = t;
		}
		float givenMoney = 0;
		Debug.Log(givenMoney);
		Debug.Log(totalPrice);
		
		while(givenMoney < totalPrice)
		{
			if(totalPrice-givenMoney >= 20)
			{
				GameObject t = Instantiate(twentyDollar, panel.transform);
				givenMoney += 20;
				register.GetComponent<CashRegister>().paymentList.Add(t);
			}
			else if(totalPrice-givenMoney >= 10)
			{
				GameObject t = Instantiate(tenDollar, panel.transform);
				givenMoney += 10;
				register.GetComponent<CashRegister>().paymentList.Add(t);
			}
			else if(totalPrice-givenMoney >= 5)
			{
				GameObject t = Instantiate(fiveDollar, panel.transform);
				givenMoney += 5;
				register.GetComponent<CashRegister>().paymentList.Add(t);
			}
			else if(totalPrice-givenMoney >= 1)
			{
				GameObject t = Instantiate(oneDollar, panel.transform);
				givenMoney += 1;
				register.GetComponent<CashRegister>().paymentList.Add(t);
			}
			else if(totalPrice-givenMoney >= .25f)
			{
				GameObject t = Instantiate(quarterCent, panel.transform);
				givenMoney += .25f;
				register.GetComponent<CashRegister>().paymentList.Add(t);
			}
			else if(totalPrice-givenMoney >= .1f)
			{
				GameObject t = Instantiate(tenCent, panel.transform);
				givenMoney += .1f;
				register.GetComponent<CashRegister>().paymentList.Add(t);
			}
			else if(totalPrice-givenMoney >= .05f)
			{
				GameObject t = Instantiate(fiveCent, panel.transform);
				givenMoney += .05f;
				register.GetComponent<CashRegister>().paymentList.Add(t);
			}
			else// if(totalPrice >= .01)
			{
				GameObject t = Instantiate(oneCent, panel.transform);
				givenMoney += .01f;
				register.GetComponent<CashRegister>().paymentList.Add(t);
			}
		}
		
	}
}
