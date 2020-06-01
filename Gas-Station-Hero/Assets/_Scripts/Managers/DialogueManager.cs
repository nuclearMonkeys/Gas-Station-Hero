using System.Collections;
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

    public GameObject customerPanelDisplay;
    public GameObject playerPanelDisplay;
    public TextMeshProUGUI customerTextDisplay;
    public TextMeshProUGUI playerTextDisplay;
    public GameObject[] buttons;
    private JsonData currentLayer;
    private JsonData dialogue;
    private int index;
    private string line_position = "";
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
            currentLayer = dialogue;
            ActivatePanels();
            return true;
        }
        return false;
    }

    public bool printLine() 
    {
        if(inDialogue) 
        {        
            JsonData line = currentLayer[index];

            foreach (JsonData key in line.Keys)
                speaker = key.ToString();

            if (speaker == "EOD")
            {
                inDialogue = false;
                customerTextDisplay.text = "";
                playerTextDisplay.text = "";
                index = 0;
                line_position = "";
                DeactivatePanels();
                return false;          
            }
            else if(speaker == "?")
            {
                JsonData options = line[0];
                playerTextDisplay.text = "";
                for(int optionsNumber = 0; optionsNumber < options.Count; optionsNumber++){
                    ActivateButton(buttons[optionsNumber], options[optionsNumber]);
                }
            }
            else {
                // This is not a mistake. YMAL mapping is weird like that
                if("Customer" == speaker) {
                    customerTextDisplay.text += line_position + currentLayer[index][0].ToString(); 
                }
                else {
                    playerTextDisplay.text +=  line_position + currentLayer[index][0].ToString();
                }
                index++;
                line_position += "\n\n";
            }
        }
        return true;
    }

    private void DeactivateButtons() 
    {
        foreach(GameObject button in buttons) 
        {
            button.SetActive(false);
            button.GetComponentInChildren<TextMeshProUGUI>().text = "";
            button.GetComponent<Button>().onClick.RemoveAllListeners();
        }

        
    }

    private void DeactivatePanels() 
    {
        customerPanelDisplay.SetActive(false);
        playerPanelDisplay.SetActive(false);
    }
    private void ActivatePanels() 
    {
        customerPanelDisplay.SetActive(true);
        playerPanelDisplay.SetActive(true);
    }

    private void ActivateButton(GameObject button, JsonData choice) 
    {
        button.SetActive(true);
        button.GetComponentInChildren<TextMeshProUGUI>().text = choice[0][0].ToString();
        button.GetComponent<Button>().onClick.AddListener(delegate { toDoOnClick(choice); });
    }

    void toDoOnClick(JsonData choice) {
        currentLayer = choice[0];
        index = 1;
        printLine();
        DeactivateButtons();
    }

    private void Start() {

        DeactivateButtons();
        DeactivatePanels();
    }
}
