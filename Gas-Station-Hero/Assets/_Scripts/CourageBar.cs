using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CourageBar : MonoBehaviour
{
	public static CourageBar instance;
	
	public List<Image> courageBar;
    // Start is called before the first frame update
    void Start()
    {
		if (instance)
			Destroy(this.gameObject);
		instance = this;
		courageBar.Add(gameObject.transform.GetChild(0).gameObject.GetComponent<Image>());
		courageBar.Add(gameObject.transform.GetChild(1).gameObject.GetComponent<Image>());
		courageBar.Add(gameObject.transform.GetChild(2).gameObject.GetComponent<Image>());
		courageBar.Add(gameObject.transform.GetChild(3).gameObject.GetComponent<Image>());
		courageBar.Add(gameObject.transform.GetChild(4).gameObject.GetComponent<Image>());
        courageBar[0].color = Color.yellow;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < Stats.instance.courage; i++)
		{
			courageBar.Add(gameObject.transform.GetChild(i).gameObject.GetComponent<Image>());
		}
    }
}
