using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public GameObject aiObj;

    public GameObject itemObj;
    
    public int aiCount = 2;
    
    public int itemCount = 3;

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
            GameObject thisAIObj = Instantiate<GameObject>(aiObj, randomPos, Quaternion.identity);
            if (thisAIObj != null)
            {
                Service.AIManagerInGame.Creation(thisAIObj);
            }
            else
            {
                Debug.Log("AI object is null");
            }
        }
        
        for (int i = 0; i < itemCount; i++)
        {
            Vector3 randomPos = new Vector3(Random.Range(-10.0f, 10.0f), 1.0f, Random.Range(-10.0f, 10.0f));
            GameObject thisItemObj = Instantiate(itemObj, randomPos, Quaternion.identity);
            Service.ItemManagerInGame.Creation(thisItemObj);
        }
    }

    private void Update()
    {
        foreach (var aiInstance in Service.AIManagerInGame.AIs)
        {
            Service.AIManagerInGame.Updating(aiInstance);
        }
    }
}
