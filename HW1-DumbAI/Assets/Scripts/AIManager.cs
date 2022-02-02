using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneTemplate;
using UnityEngine;

public class AIManager
{
    public List<AI> allAIs = new List<AI>();
    public int aiCount = 2;
    public AI newAI = new AI();

    public void UpdateManually()
    {
        for (int i = 0; i < aiCount; i++)
        {
            Vector3 randomPos = new Vector3(Random.Range(-10.0f, 10.0f), 1.0f, Random.Range(-10.0f, 10.0f));
            AI spawnedAI = new AI();
            Spawn(randomPos,spawnedAI);
        }
    }

    public void Spawn(Vector3 positionOfSpawn, AI ai)
    {
        ai.transform.position = positionOfSpawn;
        allAIs.Add(ai);
    }
    
    
}
