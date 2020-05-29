using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Stats : MonoBehaviour
{
	public static Stats instance;

	public int knowledge;
	int knowledgeCap;
	public int knowledgeExp;
	public int charm;
	int charmCap;
	public int charmExp;
	public int courage;
	int courageCap;
	public int courageExp;
	public int kacper;
	int kacperCap;
	public int customersServed;
	public int savings;

	[Header("Bar Variables")]
	public List<Image> knowledgeBar;
	public List<Image> charmBar;
	public List<Image> courageBar;

    // Start is called before the first frame update
    void Start()
    {
		if (instance)
			Destroy(this.gameObject);
		instance = this;

        knowledge = 1;
		knowledgeBar[0].color = Color.yellow;
		knowledgeCap = 5;
		knowledgeExp = 0;

		charm = 1;
		charmBar[0].color = Color.yellow;
		charmCap = 5;
		charmExp = 0;

		courage = 1;
		courageBar[0].color = Color.yellow;
		courageCap = 5;
		courageExp = 0;

		kacper = 1;
		kacperCap = 4;
    }

    // Update is called once per frame
    void Update()
    {
        updateLevel();
    }
	
	void updateLevel()
	{
		if(knowledgeExp >= 5)
		{
			knowledgeExp -= 5;
			knowledgeBar[knowledge].color = Color.yellow; 
			knowledge++;
		}
		if(charmExp >= 5)
		{
			charmExp -= 5;
			charmBar[charm].color = Color.yellow;
			charmExp++;
		}
		if(courageExp >= 5)
		{
			courageExp -= 5;
			courageBar[courage].color = Color.yellow;
			courageExp++;
		}
	}
}