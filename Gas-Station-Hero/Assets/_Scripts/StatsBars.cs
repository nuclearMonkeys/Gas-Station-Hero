using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatsBars : MonoBehaviour
{
	public static StatsBars instance;
	
	public List<Image> charmBar;
	public List<Image> courageBar;
    // Start is called before the first frame update
    void Start()
    {
		if (instance)
			Destroy(this.gameObject);
		instance = this;	
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
