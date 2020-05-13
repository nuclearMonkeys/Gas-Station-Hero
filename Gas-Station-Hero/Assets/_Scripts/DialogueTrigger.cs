using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    // public DialogueManager dialogueManager;
    // public GameObject lineManager;
    public string dialoguePath;
    public int dialogue_id;
    public string string_dialogue_id;
    
    private bool inTrigger = true;
    private bool dialogueLoaded = false;
    private bool isNewCustomer = true;

    // Start is called before the first frame update
    // void Start()
    // {
    //     if (dialogueManager == null)
    //     {
    //         dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
    //     }
    // }

    private void runDialogue(bool keyTrigger)
    {
        // Debug.Log("Dialogue Running");

        if (keyTrigger)
        {
            if(inTrigger && !dialogueLoaded && isNewCustomer)
            {
                Debug.Log("Dialogue Loaded");
                isNewCustomer = false;
                dialogue_id = Random.Range(0,3);
                string_dialogue_id = dialogue_id.ToString();
                dialogueLoaded = DialogueManager.instance.loadDialogue(dialoguePath + string_dialogue_id);
                
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
        runDialogue(Input.GetKeyDown(KeyCode.C));

        // current command to get new customer is space
        // new dialog will be loaded only if space is pressed 
        if(Input.GetKeyDown(KeyCode.Space)) {
            isNewCustomer = true;
        }
    }
}
