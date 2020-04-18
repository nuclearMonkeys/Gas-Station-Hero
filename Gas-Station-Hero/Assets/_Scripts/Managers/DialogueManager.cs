using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using LitJson;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance = null;

    public TextMeshProUGUI textDisplay;
    public List<GameObject> buttons = new List<GameObject>();

    private JsonData dialogue;
    private int index;
    private string speaker;

    private bool inDialogue;


    private void Awake() 
    {
        if(!instance) 
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
            return;
        }
    }

    public bool loadDialogue(string path) 
    {
        if(inDialogue)
            return false;

        TextAsset jsonTextFile = Resources.Load<TextAsset>("Dialogues/" + path);
        JsonMapper.ToObject(jsonTextFile.text);
        dialogue = JsonMapper.ToObject(jsonTextFile.text);
        inDialogue = true;
        return true;
    }

    public bool printLine() 
    {
        if(inDialogue) 
        {        
            JsonData line = dialogue[index];

            foreach (JsonData key in line.Keys)
                speaker = key.ToString();

            if (line[0].ToString() == "EOD")
            {
                inDialogue = false;
                textDisplay.text = "";
                return false;            
            }

            // This is not a mistake. YMAL mapping is weird like that
            textDisplay.text = speaker + ": " + dialogue[index][0].ToString();
            index++;
        }
        return true;
    }

    private void DeactivateButtons() 
    {
        foreach(GameObject button in buttons) 
        {
            button.SetActive(false);
            button.GetComponentInChildren<Text>().text = "";
        }

        
    }
    private void ActivateButton(GameObject button) 
    {
        button.SetActive(true);
    }

    private void DialogueTextColot(string character) 
    {

    }
}
