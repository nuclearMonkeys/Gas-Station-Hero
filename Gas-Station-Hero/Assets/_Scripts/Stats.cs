using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
		if (instance)
			Destroy(this.gameObject);
		instance = this;

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
    }
	
	void updateLevel()
	{
		if(knowledgeExp >= 5)
		{
			knowledgeExp -= 5;
			knowledge++;
		}
		if(charmExp >= 5)
		{
			charmExp -= 5;
			charmExp++;
		}
		if(courageExp >= 5)
		{
			courageExp -= 5;
			courageExp++;
		}
	}
}
