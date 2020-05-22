using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KanpurWarningManager : MonoBehaviour
{
    public string dialoguePath;
    public int dialogue_id;
    public int warnings = 0;
    public string string_dialogue_id;

    private bool inTrigger = true;
    private bool dialogueLoaded = true;
    private bool isNewCustomer = true;

    private void runDialogue(bool keyTrigger) 
    {
        if (keyTrigger)
        {
            if(inTrigger && !dialogueLoaded) 
            {
                dialogueLoaded = DialogueManager.instance.loadDialogue(dialoguePath);
            }
        } 
    }

    // Update is called once per frame
    void Update()
    {
        runDialogue(Input.GetKeyDown(KeyCode.C));

        // current command to get new customer is space
        // new dialog will be loaded only if space is pressed 
        }  
    }
}
