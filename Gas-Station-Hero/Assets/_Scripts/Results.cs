using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Results : MonoBehaviour
{
	public int customers = 0;
	public int savings = 0;
	public int goal;
	public int rent;
	public int utilities;
	public int day;
    // Start is called before the first frame update
    void Start()
    {
		//Show screen
        savings = calculateTotal();
		customers = 0;
		//Reset and progress day
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	int calculateTotal()
	{
		savings += customers * 800;
		savings -= rent;
		savings -= utilities;
		return savings;
	}
}
