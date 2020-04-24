using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Results : MonoBehaviour
{
	[Header("Prefabs")]
	public GameObject characterInfoPrefab;

	[Header("Results Variables")]
	public int customers;
	public int savings;
	public int goal;
	public int rent;
	public int utilities;
	public int day;
	public List<GameObject> characters;

	[Header("UI Variables")]
	public Canvas canvas;
	public GameObject salaryText;
	public GameObject rentText;
	public GameObject utilitiesText;
	public GameObject savingsText;
	public GameObject dayText;



    void Start()
    {
		for(int i = 0; i < characters.Count; i++) 
		{
			GameObject charInfoClone = Instantiate(characterInfoPrefab);
			// charInfoClone.transform.parent = canvas.transform;
			charInfoClone.transform.SetParent(canvas.transform, false);
			CharacterInfo charInfo = charInfoClone.GetComponent<CharacterInfo>();
			BaseCharacter baseCharacter = characters[i].GetComponent<BaseCharacter>();

			charInfo.characterName.text = baseCharacter.name + ":";
			charInfo.characterLevel.text = "Current Level: " + baseCharacter.currentLevel.ToString();
			charInfo.pointsToNextLevel.text = "Points to Next Level: " + baseCharacter.currentLevel.ToString();

			charInfo.pointSlider.maxValue = baseCharacter.pointsToNextLevel;
			charInfo.pointSlider.value = baseCharacter.points;
		}
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
