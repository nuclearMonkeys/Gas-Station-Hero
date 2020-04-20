using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LineSystem : MonoBehaviour
{
    //ADJUSTABLE ATTRIBUTES
    public float customerSpeed;

    private const int maxNumCustomer = 6;
    private int totalCustomer;
    private GameObject[] customers = new GameObject[maxNumCustomer];
    public Vector2[] LineSpot = new Vector2[maxNumCustomer];

    public GameObject customer_prefab;




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
            yield return new WaitForSeconds(3);
            customers[index] = Instantiate(customer_prefab, new Vector3(-3, -10, 0), Quaternion.identity);
            customers[index].GetComponent<InlineCustomerBehavior>().moveUp( LineSpot[index]);
        }
    }



    /*================================
     * have the first customer to leave
     * and moves up the whole line by 1
     * then spawn 1 customer at the back of the line
     * ==============================*/
    public void MoveLine()
    {
        customers[totalCustomer % maxNumCustomer].GetComponent<InlineCustomerBehavior>().leave();
        customers[totalCustomer % maxNumCustomer] = Instantiate(customer_prefab, new Vector3(-2, -10, 0), Quaternion.identity);
        customers[totalCustomer % maxNumCustomer].GetComponent<InlineCustomerBehavior>().moveUp(LineSpot[maxNumCustomer - 1]);
        totalCustomer++;
        StartCoroutine(delayedMove());
    }
    IEnumerator delayedMove()//part of above
    {
        for (int i = 0; i < maxNumCustomer - 1; i++)
        {
            customers[(totalCustomer + i) % maxNumCustomer].GetComponent<InlineCustomerBehavior>().moveUp(LineSpot[i]);
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

    // Start is called before the first frame update
    void Start()
    {
        startDay();
    }




    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            MoveLine();
        }
    }




}
