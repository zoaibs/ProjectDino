using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignText : MonoBehaviour
{
    public TextMesh displayText;
    public string WhatToPrint;
    // Start is called before the first frame update
    void Start()
    {
        displayText.text = WhatToPrint;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
