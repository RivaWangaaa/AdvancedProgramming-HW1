using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject aiObj;

    public GameObject itemObj;
    
    public int aiCount = 2;
    
    public int itemCount = 3;

    public AI newAI;
    
    // Start is called before the first frame update
    void Start()
    {
        newAI = new AI(aiObj);
        
        for (int i = 0; i < aiCount; i++)
        {
            Vector3 randomPos = new Vector3(Random.Range(-10.0f, 10.0f), 1.0f, Random.Range(-10.0f, 10.0f));
            GameObject thisAIObj = Instantiate(newAI.aiGameObject, randomPos, Quaternion.identity);
            newAI.aiGameObject = thisAIObj;
            Service.AIManagerInGame.Creation(newAI);
        }
        
        for (int i = 0; i < itemCount; i++)
        {
            Vector3 randomPos = new Vector3(Random.Range(-10.0f, 10.0f), 1.0f, Random.Range(-10.0f, 10.0f));
            GameObject thisItemObj = Instantiate(itemObj, randomPos, Quaternion.identity);
            Service.ItemManagerInGame.Creation(itemObj);
        }
    }
    
}
