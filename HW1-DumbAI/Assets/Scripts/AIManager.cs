using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager
{
    public List<GameObject> AIs = new List<GameObject>();
    public float aiMoveSpeed = 0.1f;

    private void Awake()
    {
        Service.AIManagerInGame = this;
    }
    public void Creation(GameObject aiObj)
    {
        AIs.Add(aiObj);
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
