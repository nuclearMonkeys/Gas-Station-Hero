using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Delete this later
using UnityEngine.SceneManagement;

public class BaseCharacter : MonoBehaviour
{
    public string name = "Knowledge";
	public GameObject background;
    public int currentLevel;
    public int pointsToNextLevel = 5;
    public int points;
    public List<GameObject> buttons;
    private bool isAdded;


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

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "MainScene") 
        {
            isAdded = false;
        }
        else if(SceneManager.GetActiveScene().name == "ResultsTest" && isAdded == false) 
        {
            isAdded = true;
            Results.instance.characters.Add(this.gameObject);
        }
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
