using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneTemplate;
using UnityEngine;

public class AIManager
{
    public List<AI> AIs = new List<AI>();

    public void Creation(AI ai)
    {
        AIs.Add(ai);
    }
    
    
}
