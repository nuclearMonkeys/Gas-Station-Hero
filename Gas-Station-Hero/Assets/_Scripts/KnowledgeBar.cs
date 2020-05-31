using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KnowledgeBar : MonoBehaviour
{
	public static KnowledgeBar instance;
	
	public List<Image> knowledgeBar;
    // Start is called before the first frame update
    void Start()
    {
		if (instance)
			Destroy(this.gameObject);
		instance = this;
		knowledgeBar.Add(gameObject.transform.GetChild(0).gameObject.GetComponent<Image>());
		knowledgeBar.Add(gameObject.transform.GetChild(1).gameObject.GetComponent<Image>());
		knowledgeBar.Add(gameObject.transform.GetChild(2).gameObject.GetComponent<Image>());
		knowledgeBar.Add(gameObject.transform.GetChild(3).gameObject.GetComponent<Image>());
		knowledgeBar.Add(gameObject.transform.GetChild(4).gameObject.GetComponent<Image>());
        knowledgeBar[0].color = Color.yellow;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < Stats.instance.knowledge; i++)
		{
			knowledgeBar[i].color = Color.yellow;
		}
    }
}
