using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KanpurLevel1 : MonoBehaviour
{
    public GameObject DialogueTrigger;
    // Start is called before the first frame update
    void Start()
    {
        DialogueTrigger.GetComponent<DialogueTrigger>().interaction_id = "Kanpur1";
		DialogueTrigger.GetComponent<DialogueTrigger>().isInteraction = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
