﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using LitJson;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance = null;

    // public TextMeshProUGUI textDisplay;
    // public List<GameObject> buttons = new List<GameObject>();

    public TextMeshProUGUI customerTextDisplay;
    public TextMeshProUGUI playerTextDisplay;
    private JsonData dialogue;
    private int index;
    private string line_position = "\n\n";
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
        if(!inDialogue)
        {
            TextAsset jsonTextFile = Resources.Load<TextAsset>("Dialogues/" + path);
            JsonMapper.ToObject(jsonTextFile.text);
            dialogue = JsonMapper.ToObject(jsonTextFile.text);
            inDialogue = true;
            return true;
        }
        return false;
    }

    public bool printLine() 
    {
        if(inDialogue) 
        {        
            JsonData line = dialogue[index];

            if (line[0].ToString() == "EOD")
            {
                inDialogue = false;
                customerTextDisplay.text = "";
                playerTextDisplay.text = "";
                index = 0;
                line_position = "\n\n";
                return false;          
            }

            foreach (JsonData key in line.Keys)
                speaker = key.ToString();

            // This is not a mistake. YMAL mapping is weird like that
            if("Customer" == speaker) {
                customerTextDisplay.text += dialogue[index][0].ToString() + line_position; 
            }
            else {
                playerTextDisplay.text += dialogue[index][0].ToString() + line_position;
            }
            index++;
            line_position += "\n\n";
        }
        return true;
    }

    // private void DeactivateButtons() 
    // {
    //     foreach(GameObject button in buttons) 
    //     {
    //         button.SetActive(false);
    //         button.GetComponentInChildren<Text>().text = "";
    //     }

        
    // }
    // private void ActivateButton(GameObject button) 
    // {
    //     button.SetActive(true);
    // }

    // private void DialogueTextColot(string character) 
    // {

    // }
}
