using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KanpurWarningManager : MonoBehaviour
{
    public static KanpurWarningManager instance;

    public string dialoguePath;
    public int dialogue_id;
    public int warnings = 0;
    public string string_dialogue_id;

    private bool inTrigger = true;
    private bool dialogueLoaded = false;
    private bool isNewCustomer = true;

    private void Start() 
    {
        if(instance)
            Destroy(this.gameObject);
        instance = this;
    }

    private void runDialogue(bool keyTrigger) 
    {
        if (keyTrigger)
        {
            if(inTrigger && !dialogueLoaded) 
            {
                dialogueLoaded = DialogueManager.instance.loadDialogue(dialoguePath);
            }
            if(dialogueLoaded) 
            {
                dialogueLoaded = DialogueManager.instance.printLine();
            }
            print(dialogueLoaded);
        } 
    }

    private bool BadTransaction() 
    {
        return CashRegister.instance.totalPrice != 0;
    }

    public void CheckTransaction(bool keyTrigger, bool forceLoad = false) 
    {
        if ((keyTrigger || forceLoad) && BadTransaction()) 
        {
            if(inTrigger && !dialogueLoaded) 
            {
                dialogueLoaded = DialogueManager.instance.loadDialogue(dialoguePath);
            }
            if(dialogueLoaded) 
            {
                dialogueLoaded = DialogueManager.instance.printLine();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckTransaction(Input.GetMouseButtonDown(1));

        // current command to get new customer is space
    }
}
