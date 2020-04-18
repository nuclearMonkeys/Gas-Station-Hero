using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LineSystem : MonoBehaviour
{
    //ADJUSTABLE ATTRIBUTES
    public float customerSpeed;





    private const int maxNumCustomer = 6;

    private bool[] SpotEmpty = new bool[maxNumCustomer];
    private Vector2[] CustomerVectors = new Vector2[maxNumCustomer];

    public GameObject customer_prefab;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < maxNumCustomer; i++)
        {
            SpotEmpty[i] = true;
        }
    }


    // Update is called once per frame
    void Update()
    {

    }




}
