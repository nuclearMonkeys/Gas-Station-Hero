using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


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
	public GameObject crossfadeImage;
	public GameObject buttonNextDay;

    void Start()
    {
		day = Stats.instance.day;
		if (Stats.instance) {
			customers = Stats.instance.customersServed;

			Stats.instance.savings += (customers * 100) - rent - utilities;

			savings = Stats.instance.savings;
		}
		Stats.instance.customersServed = 0;

		salaryText.GetComponent<Text>().text = "Salary: +$" + (customers*100).ToString();
		rentText.GetComponent<Text>().text = "Rent: -$" + rent.ToString();
		utilitiesText.GetComponent<Text>().text = "Utilities: -$" + utilities.ToString();
		savingsText.GetComponent<Text>().text = "Savings: $" + savings.ToString();
		dayText.GetComponent<Text>().text = "End Of Day " + day.ToString();

		crossfadeImage.SetActive(false);
		salaryText.SetActive(false);
		rentText.SetActive(false);
		utilitiesText.SetActive(false);
		savingsText.SetActive(false);
		dayText.SetActive(false);
		buttonNextDay.SetActive(false);

		StartCoroutine(DisplayResultsCoroutine());

		for(int i = 0; i < characters.Count; i++) 
		{
			GameObject charInfoClone = Instantiate(characterInfoPrefab);
			charInfoClone.transform.SetSiblingIndex(0);
			// charInfoClone.transform.parent = canvas.transform;
			// charInfoClone.transform.SetParent(canvas.transform, false);
			CharacterInfo charInfo = charInfoClone.GetComponent<CharacterInfo>();
			BaseCharacter baseCharacter = characters[i].GetComponent<BaseCharacter>();

			charInfo.characterName.text = baseCharacter.name + ":";
			charInfo.characterLevel.text = "Current Level: " + baseCharacter.currentLevel.ToString();
			charInfo.pointsToNextLevel.text = "Points to Next Level: " + baseCharacter.currentLevel.ToString();

			charInfo.pointSlider.maxValue = baseCharacter.pointsToNextLevel;
			charInfo.pointSlider.value = baseCharacter.points;
		}
	}

	// Displays Stats one at a time for every .3 seconds
	private IEnumerator DisplayResultsCoroutine() 
	{
		// crossfadeImage.GetComponent<Animator>().SetBool("fadeOut", true);
		// yield return new WaitForSecondsRealtime(1.7f);
		// crossfadeImage.SetActive(false);
		yield return new WaitForSecondsRealtime(.3f);
		dayText.SetActive(true);
		yield return new WaitForSecondsRealtime(.3f);
		salaryText.SetActive(true);
		yield return new WaitForSecondsRealtime(.3f);
		rentText.SetActive(true);
		yield return new WaitForSecondsRealtime(.3f);
		utilitiesText.SetActive(true);
		yield return new WaitForSecondsRealtime(.3f);
		savingsText.SetActive(true);
		yield return new WaitForSecondsRealtime(.3f);
		buttonNextDay.SetActive(true);
		yield return new WaitForSecondsRealtime(.3f);
	}

	public void ToMainScene() 
	{
		/*
		if(day == 14 && stats checks)
		{
			Move scene to whichever scene has the end
		}
		else if(day == 14 && other stat options)
		{
			Move to a different scene
		}
		else
		{*/
		StartCoroutine(ToMainSceneCoroutine());
		//}
	}

	private IEnumerator ToMainSceneCoroutine() 
	{
		crossfadeImage.SetActive(true);
		crossfadeImage.GetComponent<Animator>().SetBool("fadeIn", true);
		yield return new WaitForSecondsRealtime(1.7f);
		SceneManager.LoadScene("MainScene");
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
	}
	void updateText()
	{
		salaryText.GetComponent<Text>().text = "Salary: +$" + (customers*800).ToString();
		rentText.GetComponent<Text>().text = "Rent: -$" + rent.ToString();
		utilitiesText.GetComponent<Text>().text = "Utilities: -$" + utilities.ToString();
		savingsText.GetComponent<Text>().text = "Savings: $" + savings.ToString();
	}
}
