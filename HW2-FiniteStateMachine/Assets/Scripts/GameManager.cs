using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public GameObject aiObj;

    public GameObject itemObj;
    
    private int aiCount = 2;
    private int itemCount = 15;

    private void Awake()
    {
        Service.GameManagerInGame = this;
        Service.InitializeServices();
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < aiCount; i++)
        {
            Vector3 randomPos = new Vector3(Random.Range(-10.0f, 10.0f), 1.0f, Random.Range(-10.0f, 10.0f));
            GameObject thisAIObj = Instantiate(aiObj, randomPos, Quaternion.identity);
            if (thisAIObj != null)
            {
                Service.AIManagerInGame.Creation(aiObj);
            }
            else
            {
                Debug.Log("AI object is null");
            }
        }
        
        for (int a = 0; a < itemCount; a++)
        {
            Vector3 randomPos = new Vector3(Random.Range(-10.0f, 10.0f), 1.0f, Random.Range(-10.0f, 10.0f));
            GameObject thisItem = Instantiate(itemObj, randomPos, Quaternion.identity);
            Service.ItemManagerInGame.Creation(thisItem);
            if (thisItem != null)
            {
            }
            else
            {
                Debug.Log("Item object is null");
            }
        }
        Service.ItemManagerInGame.Creation(itemObj);
        
    }

    private void Update()
    {
        foreach (var aiInstance in Service.AIManagerInGame.AIs)
        {
            Service.AIManagerInGame.Updating(aiInstance);
        }
    }
}
