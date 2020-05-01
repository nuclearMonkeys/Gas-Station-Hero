﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LineSystem : MonoBehaviour
{
    private const int maxNumCustomer = 6;
    private int totalCustomer;
    public GameObject[] customers = new GameObject[maxNumCustomer];
    public Vector2[] LineSpot = new Vector2[maxNumCustomer];

    public GameObject customerPrefab;
    public GameObject customerSpawnPoint;
	public GameObject customer;
	public GameObject panel;
	public GameObject itemPrefab;
	



    /*=======================
     * Start spawning customer 1 at a time
     * =========================*/
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
		//Spawn items
		//Keep track of what total should be, and array of all spawned items
		//If register total and saved total are same, success when taking cash
			//Customers leaves, image is deleted and MoveLine() called
			//Add customer completed to counter
		//Else if wrong money/scanned wrong
			//Customer gets mad and leaves
	}
	
    // Start is called before the first frame update
    void Start()
    {
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




}
