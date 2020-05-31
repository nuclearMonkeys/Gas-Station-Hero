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
	public int day;

    // Start is called before the first frame update
    void Start()
    {

		day = 0;
        knowledge = 1;
		knowledgeCap = 5;
		knowledgeExp = 0;

		charm = 1;
		charmCap = 5;
		charmExp = 0;

		courage = 1;
		courageCap = 5;
		courageExp = 0;

		kacper = 1;
		kacperCap = 4;
    }

    // Update is called once per frame
    void Update()
    {
        updateLevel();
		if(knowledge > 5)
		{
			knowledge = 5;
		}
		if(charm > 5)
		{
			charm = 5;
		}
		if(courage > 5)
		{
			courage = 5;
		}
    }
	
	void Awake()
	{
		DontDestroyOnLoad(gameObject);
		if(instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}
	
	void updateLevel()
	{
		if(knowledgeExp >= 5)
		{
			knowledgeExp -= 5;
			KnowledgeBar.instance.knowledgeBar[knowledge].color = Color.yellow; 
			knowledge++;
		}
		if(charmExp >= 5)
		{
			charmExp -= 5;
			CharmBar.instance.charmBar[charm].color = Color.yellow;
			charmExp++;
		}
		if(courageExp >= 5)
		{
			courageExp -= 5;
			CourageBar.instance.courageBar[courage].color = Color.yellow;
			courageExp++;
		}
	}
}