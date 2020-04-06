using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadQuest : MonoBehaviour
{
    List<Quest> quests = new List<Quest>();

    void Start()
    {
        TextAsset questdata = Resources.Load<TextAsset>("TestDialogue");

        string[] data = questdata.text.Split(new char[] {'\n'});
        
        for (int i = 1; i < data.Length - 1; i++) 
        {
            string[] row = data[i].Split(new char[] {','});
            Quest q = new Quest();

            if (row[1] == "")
                continue;

            int.TryParse(row[0], out q.id);
            q.name = row[1];
            q.npc = row[2];
            q.desc = row[3];
            int.TryParse(row[4], out q.status);
            q.rewards = row[5];
            q.task = row[6];
            int.TryParse(row[7], out q.parent);

            quests.Add(q);
        }

        // print(data.Length);
        // print(quests.Count);

        foreach(Quest q in quests) 
        {
            // print(q);
            Debug.Log(q.name + "," + q.desc);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
