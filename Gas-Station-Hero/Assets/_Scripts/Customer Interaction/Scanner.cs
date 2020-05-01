using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		
    }
	public void scanItem(string name)
	{
		if(name == "Candy")
		{
			Debug.Log("Candy");
		}
		else if(name == "Chips")
		{
			Debug.Log("Chips");
		}
		else if(name == "Alcohol")
		{
			Debug.Log("Alcohol");
		}
		else if(name == "Cigarettes")
		{
			Debug.Log("Cigarettes");
		}
	}
}
