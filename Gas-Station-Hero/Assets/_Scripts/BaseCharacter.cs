using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Delete this later

public class BaseCharacter : MonoBehaviour
{
    public string name = "dummy";
    public int currentLevel = 0;
    public int pointsToNextLevel = 5;
    public int points = 0;
    public List<GameObject> buttons;

    [Header("States")]
    public bool hasPointsAboveNext;
    public bool isInteracting;
    public bool hasEndConversation;

    // Start is called before the first frame update
    void Start()
    {
        isInteracting = true;
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
