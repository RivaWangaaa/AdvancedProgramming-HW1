using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager
{
    //public List<GameObject> AIs = new List<GameObject>();
    
    public Dictionary<GameObject, string> AIs = new Dictionary<GameObject, string>();
    public float aiMoveSpeed = 0.01f;

    private void Awake()
    {
        Service.AIManagerInGame = this;
    }
    public void Creation(GameObject aiObj, int aiNum)
    {
        if (aiNum < Service.GameManagerInGame.aiCount / 2)
        {
            AIs.Add(aiObj, "Blue");
            aiObj.GetComponent<Renderer>().material = Service.GameManagerInGame.blueMaterial;
        }
        else
        {
            AIs.Add(aiObj, "Red");
            aiObj.GetComponent<Renderer>().material = Service.GameManagerInGame.redMaterial;
        }
    }
    
    //AI Move towards the closest item
    public void Updating(GameObject aiObj)
    {
        if (Service.ItemManagerInGame.Items.Count != 0)
        {
            aiObj.transform.position = Vector3.MoveTowards(aiObj.transform.position,
                Tracking(aiObj).position, aiMoveSpeed);
        }

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
    
    public void Destroy()
    {
        foreach (var ai in AIs)
        {
            UnityEngine.Object.Destroy(ai.Key.gameObject);
            AIs.Remove(ai.Key);
        }
    }
}
