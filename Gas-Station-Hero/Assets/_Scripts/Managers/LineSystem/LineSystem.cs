using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LineSystem : MonoBehaviour
{
    //ADJUSTABLE ATTRIBUTES
    public float customerSpeed;


    //TESTING VARIABLES
    public int counter = 500;
    



    private const int maxNumCustomer = 6;
    private int totalCustomer;
    private bool[] SpotEmpty = new bool[maxNumCustomer];
    private GameObject[] customers = new GameObject[maxNumCustomer];
    public Vector2[] CustomerVectors = new Vector2[maxNumCustomer];

    public GameObject customer_prefab;




    //spawn numberof customers outside the door, one at a time
    public void startDay()
    {

        StartCoroutine(SpwanCustomer());
        
            
    }
    IEnumerator SpwanCustomer()
    {
        for (int index = 0; index < maxNumCustomer; index++)
        {
            yield return new WaitForSeconds(3);
            customers[index] = Instantiate(customer_prefab, new Vector3(-3, -10, 0), Quaternion.identity);
            customers[index].GetComponent<InlineCustomerBehavior>().init( CustomerVectors[index]);
        }
    }

    public void MoveLine()
    {
        customers[totalCustomer % maxNumCustomer].GetComponent<InlineCustomerBehavior>().leave();
        StartCoroutine(delayedMove());
        customers[totalCustomer % maxNumCustomer] = Instantiate(customer_prefab, new Vector3(-2, -10, 0), Quaternion.identity);
        customers[totalCustomer % maxNumCustomer].GetComponent<InlineCustomerBehavior>().init(CustomerVectors[maxNumCustomer - 1]);
        totalCustomer++;
    }
    IEnumerator delayedMove()
    {
        for (int i = 1; i < maxNumCustomer - 1; i++)
        {
            yield return new WaitForSeconds(0.5f);
            customers[(totalCustomer + i) % maxNumCustomer].GetComponent<InlineCustomerBehavior>().TargetLoc = CustomerVectors[i - 0];
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        startDay();
    }


    //returns the total number of customers served;
    public int getTotalCustomers()
    {
        return totalCustomer;
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
