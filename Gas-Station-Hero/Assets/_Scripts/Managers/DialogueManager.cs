using UnityEngine;
using UnityEngine.UI;
using TMPro;
using LitJson;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance = null;

    public TextMeshProUGUI textDisplay;
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

            if (line[0].ToString() == "EOD")
            {
                inDialogue = false;
                textDisplay.text = "";
                return false;            
            }

            foreach (JsonData key in line.Keys)
                speaker = key.ToString();

            // This is not a mistake. YMAL mapping is weird like that
            textDisplay.text = speaker + ": " + dialogue[index][0].ToString();
            index++;
        }
        return true;
    }
}
