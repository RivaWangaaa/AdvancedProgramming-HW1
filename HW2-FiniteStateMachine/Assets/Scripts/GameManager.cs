using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public GameObject aiObj;

    public GameObject itemObj;

    public int itemCount = 3;

    private void Awake()
    {
        Service.GameManagerInGame = this;
        Service.InitializeServices();
    }

    // Start is called before the first frame update
    void Start()
    {
        Service.AIManagerInGame.Creation(aiObj);
        
    }

    private void Update()
    {
        foreach (var aiInstance in Service.AIManagerInGame.AIs)
        {
            Service.AIManagerInGame.Updating(aiInstance);
        }
    }
}
