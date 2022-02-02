using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Service
{
    public static AIManager AIManagerInGame;
    public static ItemManager ItemManagerInGame;
    public static void InitializeServices()
    {
        AIManagerInGame = new AIManager();
        ItemManagerInGame = new ItemManager();
    }


}
