using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KanpurLevel1 : MonoBehaviour
{
    public GameObject DialogueTrigger;
    public int index = 1;
    private int coolDown = 0;
    private int maxCoolDown = 60;
    // Start is called before the first frame update
    void Start()
    {
        loadKanpursDialog(1);
    }

    public void loadKanpursDialog(int index){
        DialogueTrigger.GetComponent<DialogueTrigger>().interaction_id = "Kanpur" + index.ToString();
		DialogueTrigger.GetComponent<DialogueTrigger>().isInteraction = true;
        DialogueTrigger.GetComponent<DialogueTrigger>().isSocialLink = true;
        DialogueTrigger.GetComponent<DialogueTrigger>().isNewCustomer = true;
    }

    // Update is called once per frame
    void Update()
    {   
            
            
    }
}

