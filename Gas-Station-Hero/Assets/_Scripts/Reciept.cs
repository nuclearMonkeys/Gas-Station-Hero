using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Reciept : Draggable
{
    private bool isTaken = false;

    // public override void Update()
    // {
    //     base.Update();
    //     if (falling)
    //         print("hey now");
    //     if (falling && !isTaken) 
    //     {
    //         // print(falling);
    //         LineSystem.instance.MoveLine();
    //         isTaken = true;
    //     }
    // }

    private void Start() 
    {
        print(LineSystem.instance);
        print("Hey now");
    }

    public override void OnEndDrag(PointerEventData eventData) 
    {
        base.OnBeginDrag(eventData);
        if (isOverCounter && CanBeGiven && !isTaken)
        {
            print("you're an allstar");
            LineSystem.instance.MoveLine();
            isTaken = true;
        }
        // This will cause an error if no customer is in front
        // Of the counter
    }
}
