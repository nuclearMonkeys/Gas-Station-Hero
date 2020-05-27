using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateFace : MonoBehaviour
{
    public Sprite[] ShapeSource = new Sprite[8];
    public Sprite[] MouthSource = new Sprite[8];
    public Sprite[] EyeSource = new Sprite[8];
    public Sprite[] HairSource = new Sprite[8];
    public Sprite[] BrowsSource = new Sprite[8];

    private int[] featureIndex = new int[5];
    private Color[] hairColors = new Color[6];

    int counter= 20;
    void makeFace()
    {
        int random;
        for (short i = 0; i < 5; i++)
        {
            do
            {
                random = Random.Range((int)0, 7);
            } while (random == featureIndex[i]);
            featureIndex[i] = random;
        }
        GetComponent<Image>().sprite = ShapeSource[featureIndex[0]];
        transform.GetChild(0).GetComponent<Image>().sprite = BrowsSource[featureIndex[1]];
        transform.GetChild(1).GetComponent<Image>().sprite = EyeSource[featureIndex[1]];
        transform.GetChild(2).GetComponent<Image>().sprite = MouthSource[featureIndex[2]];
        transform.GetChild(3).GetComponent<Image>().sprite = HairSource[featureIndex[3]];
        random = Random.Range((int)0, 9);
        switch (random)
        {
            case 0:
            case 1:
                transform.GetChild(0).GetComponent<Image>().color = hairColors[0];
                transform.GetChild(3).GetComponent<Image>().color = hairColors[0];
                break;
            case 2:
            case 3:
                transform.GetChild(0).GetComponent<Image>().color = hairColors[1];
                transform.GetChild(3).GetComponent<Image>().color = hairColors[1];
                break;
            case 4:
            case 5:
                transform.GetChild(0).GetComponent<Image>().color = hairColors[2];
                transform.GetChild(3).GetComponent<Image>().color = hairColors[2];
                break;
            case 6:
            case 7:
                transform.GetChild(0).GetComponent<Image>().color = hairColors[3];
                transform.GetChild(3).GetComponent<Image>().color = hairColors[3];
                break;
            case 8:
                transform.GetChild(0).GetComponent<Image>().color = hairColors[4];
                transform.GetChild(3).GetComponent<Image>().color = hairColors[4];
                break;

            default:
                transform.GetChild(0).GetComponent<Image>().color = hairColors[5];
                transform.GetChild(3).GetComponent<Image>().color = hairColors[5];
                break;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        hairColors[0] = new Color(1, 1, 0.5f);      //blonde
        hairColors[1] = new Color(0.2f, 0.1f, 0.1f);//brown
        hairColors[2] = new Color(0.2f, 0.2f, 0.2f);//black
        hairColors[3] = new Color(0.7f, 0.35f, 0);  //orange
        hairColors[4] = new Color(1, 1, 0.5f);      //blue
        hairColors[5] = new Color(1, 1, 0.5f);      //green
    }

    // Update is called once per frame
    void Update()
    {
        if (counter-- == 0)
        {
            makeFace();
            counter = 50;
        }
    }
}
