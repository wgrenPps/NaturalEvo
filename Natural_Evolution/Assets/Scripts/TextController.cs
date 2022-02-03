using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;
using TMPro;

public class TextController : MonoBehaviour
{

    public TextMeshProUGUI NightText;
    int DayTotal;
    // Start is called before the first frame update
    void Start()
    {
        DayTotal = Data.DayNum;
    }

    // Update is called once per frame
    void Update()
    {
        var Day = DayTotal - Data.DayNum;
        NightText.text = "Day: " + Day;
    }
}
