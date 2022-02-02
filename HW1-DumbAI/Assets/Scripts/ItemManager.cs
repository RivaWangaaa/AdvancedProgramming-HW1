using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager
{
   public List<GameObject> Items = new List<GameObject>();

   public void Creation(GameObject itemObj)
   {
      Items.Add(itemObj);
   }
}
