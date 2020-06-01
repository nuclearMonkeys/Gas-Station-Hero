using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using LitJson;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance = null;
    //to-do fix bug where buttons dialogue is printed multiple times. Currently supressed with truncation
    // public TextMeshProUGUI textDisplay;
    // public List<GameObject> buttons = new List<GameObject>();
    public GameObject DialogueTrigger;
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
                // customerTextDisplay.text = "";
                // playerTextDisplay.text = "";
                index = 0;
                line_position = "";
                DialogueTrigger.GetComponent<DialogueTrigger>().isInteraction = false;
                // DeactivatePanels();
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
                if(!DialogueTrigger.GetComponent<DialogueTrigger>().isSocialLink) {
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
                else {
                    playerTextDisplay.text = "";
                    playerTextDisplay.text = speaker + ": " +currentLayer[index][0].ToString();
                    index++;
                }
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

    public void DeactivatePanels() 
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
        if(DialogueTrigger.GetComponent<DialogueTrigger>().isShortOnMoney) {
            if( "No, I'm sorry, please leave." == choice[0][0].ToString()) {
                LineSystem.instance.MoveLine();
                CashRegister.instance.scannedPaymentCount = 0;
                DiscountBarcode.instance.alreadyScanned = false;
                CashRegister.instance.totalPrice = 0;
                CashRegister.instance.oneScan = false;
                LineSystem.instance.totalItems = 0;
                LineSystem.instance.customer.SetActive(false);
                Reciept.instance.destroyReciept();
                DiscountBarcode.instance.customerNotEnoughMoney = false;
                CashRegister.instance.change = 0;
                CashRegister.instance.UpdateRegisterDisplay(CashRegister.instance.change);
                while (CashRegister.instance.paymentList.Count != 0)
                {
                    Destroy(CashRegister.instance.paymentList[0]);
                    CashRegister.instance.paymentList.RemoveAt(0);
                }
                CashRegister.instance.scannedItems.RemoveRange(0, CashRegister.instance.scannedItems.Count);
                for (int i = 0; i < CashRegister.instance.BufferSize; i++)
                {
                    CashRegister.instance.scans[i] = 0;
                }
                foreach(GameObject g in LineSystem.instance.items)
                {
                    Destroy(g);
                }
            }
        }
        DeactivateButtons();
    }

    private void Start() {

        DeactivateButtons();
        DeactivatePanels();
    }
}
