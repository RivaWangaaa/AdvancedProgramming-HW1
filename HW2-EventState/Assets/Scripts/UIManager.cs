using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public Image startScreen, endScreen;
    public Text redScoreText, blueScoreText, timerText, startScreenText, endScreenText;

    private void Awake()
    {
        Service.UIManagerInGame = this;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
