﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class openCashCompartment : MonoBehaviour, IPointerClickHandler
{
    public GameObject compartment;
    public void OnPointerClick(PointerEventData eventData)
    {
        compartment.SetActive(!compartment.activeSelf);

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
