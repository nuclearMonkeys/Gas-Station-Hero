using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scannable : MonoBehaviour
{
	public GameObject scanner;
	bool scanned = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!scanned && gameObject.transform.position.x > scanner.transform.position.x-20 && gameObject.transform.position.x < scanner.transform.position.x+20 && gameObject.transform.position.y > scanner.transform.position.y-20 && gameObject.transform.position.y < scanner.transform.position.y+20)
		{
			scanner.GetComponent<Scanner>().scanItem(gameObject.name);
			scanned = true;
		}
    }
}
