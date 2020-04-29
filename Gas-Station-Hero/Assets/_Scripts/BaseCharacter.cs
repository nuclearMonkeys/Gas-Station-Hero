using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Delete this later

public class BaseCharacter : MonoBehaviour
{
    public string name = "Knowledge";
	public GameObject background;
    public int currentLevel;
    public int pointsToNextLevel = 5;
    public int points;
    public List<GameObject> buttons;

    [Header("States")]
    public bool hasPointsAboveNext;
    public bool isInteracting;
    public bool hasEndConversation;

    // Start is called before the first frame update
    void Start()
    {
        isInteracting = true;
		currentLevel = background.GetComponent<Stats>().knowledge;
		points = background.GetComponent<Stats>().knowledgeExp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GainPoints(int value) 
    {
        if (points >= pointsToNextLevel || !isInteracting)
            return;
        points += value;
    }

    public void EndConversation() 
    {
        isInteracting = false;
        foreach(GameObject button in buttons) 
        {
            button.SetActive(false);
        }
        print("End Conversation");
    }
}
