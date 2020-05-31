using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CreditCard : MonoBehaviour
{
    private Image img;

    public void Randomize()
    {
        img.color = new Color(Random.Range(0, 0.5f), Random.Range(0, 0.5f), Random.Range(0, 0.5f));
    }
    // Start is called before the first frame update
    void Start()
    {
        img = transform.GetChild(0).GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
