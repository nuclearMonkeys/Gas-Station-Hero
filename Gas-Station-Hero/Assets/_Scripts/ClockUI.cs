using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockUI : MonoBehaviour
{
    public GameObject lineManager;
    private const float REAL_SECONDS_PER_IN_GAME_DAY = 450f; // 900 seconds = 15 minutes, 8 hour shifts = 5 minutes 
    private Transform clockHourHandTransform;
    private Transform clockMinuteHandTransform;
    private float day;
    private float hourFloat;
    private bool dayEnded = false;
    // Start is called before the first frame update
    void Start()
    {
        clockMinuteHandTransform = transform.Find("minuteHand");
        clockHourHandTransform = transform.Find("hourHand");
    }

    void clockMovement()
    {
        day += Time.deltaTime / REAL_SECONDS_PER_IN_GAME_DAY; //Day increased by one every 900 seconds
        
        float dayNormalized = day%1f;


        float rotationDegreesPerDay = 360f;
        float hoursPerDay = 12f;
        clockMinuteHandTransform.eulerAngles = new Vector3(0,0, -dayNormalized * rotationDegreesPerDay * hoursPerDay);
        
     
        clockHourHandTransform.eulerAngles = new Vector3(0,0, -dayNormalized * rotationDegreesPerDay);
        
        hourFloat = Mathf.Floor(dayNormalized * hoursPerDay);
        

    }
    // Update is called once per frame
    void Update() 
    {
        if(dayEnded == false) {
            clockMovement();
            if(12f > hourFloat && hourFloat >= 8f){
                lineManager.GetComponent<LineSystem>().endDay();
                dayEnded = true;
            }

        }
    }
    
}
