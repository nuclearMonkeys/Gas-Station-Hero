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
    
    public bool inTrigger = true;
    public bool dialogueLoaded = false;
    public bool isNewCustomer = false;
    public bool isInteraction = false;
    public string interaction_id;

    // Start is called before the first frame update
    void Start()
    {
        // if (dialogueManager == null)
        // {
        //     dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
        // }
    }
    public void autoDialogue()
    {
        StartCoroutine(Fade());
    }
    
    IEnumerator Fade() {
            if(!dialogueLoaded && isNewCustomer)
                {
                    yield return new WaitForSeconds(1);
                    Debug.Log("Dialogue Loaded");
                    isNewCustomer = false;
                    
                    if(!isInteraction) {
                        dialogue_id = Random.Range(0,3);
                        string_dialogue_id = dialogue_id.ToString();
                    }
                    else {
                        string_dialogue_id = interaction_id;
                    }
                    dialogueLoaded = DialogueManager.instance.loadDialogue(dialoguePath + string_dialogue_id);
                    
                }
            if(dialogueLoaded)
            {
                while(dialogueLoaded){
                    dialogueLoaded = DialogueManager.instance.printLine();
                    yield return new WaitForSeconds(1);
                }
            }

        }
    
    private void runDialogue(bool keyTrigger)
    {
        // Debug.Log("Dialogue Running");

        if (keyTrigger)
        {
            if(inTrigger && !dialogueLoaded && isNewCustomer)
            {
                Debug.Log("Dialogue Loaded");
                isNewCustomer = false;
                
                if(!isInteraction) {
                    dialogue_id = Random.Range(0,3);
                    string_dialogue_id = dialogue_id.ToString();
                }
                else {
                    string_dialogue_id = interaction_id;
                }
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
        if(isInteraction) {
            runDialogue(Input.GetMouseButtonDown(0));
        }
        // else {
        //     autoDialogue();
        // }

        // current command to get new customer is space
        // new dialog will be loaded only if space is pressed 
        if(Input.GetKeyDown(KeyCode.Space)) {
            isNewCustomer = true;
        }
    }
}
