using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager
{
    public List<GameObject> Items = new List<GameObject>();
   
    

    private void Awake()
    {
        Service.ItemManagerInGame = this;
    }

    public void Creation(GameObject itemObj)
    {
        Items.Add(itemObj);

    }

    public void Destroy()
    {
      
    }

}

