using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clothingGeneration : MonoBehaviour
{
    private int counter = 20;   //USED FOR TEST!! DELETE THIS

    public Sprite[] Base = new Sprite[4];
    public Sprite[] Color = new Sprite[4];
    private Color[] COLOR = new Color[6];
    private int[] Index = new int[2];
    // Start is called before the first frame update
    public void makeClothing()
    {
        int random;
        for (short i = 0; i < 2; i++)
        {
            do
            {
                random = Random.Range((int)0, 4);
            } while (random == Index[i]);
            Index[i] = random;
        }
        GetComponent<Image>().sprite = Base[Index[0]];
        transform.GetChild(0).GetComponent<Image>().sprite = Color[Index[0]];
        transform.GetChild(0).GetComponent<Image>().color = COLOR[Index[1]];
    }
    void Start()
    {
        COLOR[3] = new Color(0.7f, 0.1f, 0.1f);      //red
        COLOR[0] = new Color(0.3f, 0.1f, 0.1f);      //red
        COLOR[1] = new Color(0.2f, 0.2f, 0.2f);//black
        COLOR[2] = new Color(0.2f, 0.2f, 0.3f);//blue
    }

    // Update is called once per frame
    void Update()
    {///
        if (counter-- == 0)
        {
            makeClothing();
            counter = 50;
        }
    }
}
