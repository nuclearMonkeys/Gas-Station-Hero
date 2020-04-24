using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Results : MonoBehaviour
{
	[Header("Prefabs")]
	public GameObject characterStatusPrefab;

	[Header("Results Variables")]
	public int customers;
	public int savings;
	public int goal;
	public int rent;
	public int utilities;
	public int day;
	public List<GameObject> characters;

	[Header("UI Variables")]
	public GameObject salaryText;
	public GameObject rentText;
	public GameObject utilitiesText;
	public GameObject savingsText;
	public GameObject dayText;



    void Start()
    {

	}

    // Update is called once per frame
    void Update()
    {
		/*
        if(endDay)
		{
			Show screen;
			savings = calculateTotal();
			updateText();
			endDay = False;
		}
		if(leftClick)
		{
			customers = 0;
			Hide Screen;
			Reset and progress day
		}
		*/
    }
	
	void calculateTotal()
	{
		savings += customers * 800;
		savings -= rent;
		savings -= utilities;
		Debug.Log(savings);
	}
	void updateText()
	{
		salaryText.GetComponent<Text>().text = "Salary: +$" + (customers*800).ToString();
		rentText.GetComponent<Text>().text = "Rent: -$" + rent.ToString();
		utilitiesText.GetComponent<Text>().text = "Utilities: -$" + utilities.ToString();
		savingsText.GetComponent<Text>().text = "Savings: $" + savings.ToString();
	}
}
