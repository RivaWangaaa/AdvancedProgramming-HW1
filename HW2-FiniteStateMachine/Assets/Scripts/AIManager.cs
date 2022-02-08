using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager
{
    public List<GameObject> AIs = new List<GameObject>();
    public float aiMoveSpeed = 0.01f;
    public int aiCount = 2;

    private void Awake()
    {
        Service.AIManagerInGame = this;
    }
    public void Creation(GameObject aiObj)
    {
        for (int i = 0; i < aiCount; i++)
        {
            Vector3 randomPos = new Vector3(UnityEngine.Random.Range(-10.0f, 10.0f), 1.0f, UnityEngine.Random.Range(-10.0f, 10.0f));
            GameObject thisAIObj = UnityEngine.Object.Instantiate(aiObj, randomPos, Quaternion.identity);
            if (thisAIObj != null)
            {
                AIs.Add(aiObj);
            }
            else
            {
                Debug.Log("AI object is null");
            }
        }
    }
    
    //AI Move towards the closest item
    public void Updating(GameObject aiObj)
    {

            aiObj.transform.position = Vector3.MoveTowards(aiObj.transform.position,
                Tracking(aiObj).position, aiMoveSpeed);
    }

    //Target the closest item from ai
    public Transform Tracking(GameObject aiObj)
    {
        float minDistance = Mathf.Infinity;
        Transform closestPos;

        if (Service.ItemManagerInGame.Items.Count == 0)
        {
            return null;
        }

        closestPos = Service.ItemManagerInGame.Items[0].transform;

        for (int i = 0; i < Service.ItemManagerInGame.Items.Count; i++)
        {
            float distance = (Service.ItemManagerInGame.Items[i].transform.position - aiObj.transform.position)
                .sqrMagnitude;

            if (distance < minDistance)
            {
                closestPos = Service.ItemManagerInGame.Items[i].transform;
                minDistance = distance;
            }
        }

        return closestPos;
    }
}
