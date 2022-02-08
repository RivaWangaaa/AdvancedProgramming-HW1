using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager
{
   public List<GameObject> Items = new List<GameObject>();
   
   public int itemCount = 3;

   private void Awake()
   {
      Service.ItemManagerInGame = this;
   }

   public void Creation(GameObject itemObj)
   {
      for (int i = 0; i < itemCount; i++)
      {
         Vector3 randomPos = new Vector3(Random.Range(-10.0f, 10.0f), 1.0f, Random.Range(-10.0f, 10.0f));
         GameObject thisItemObj = UnityEngine.Object.Instantiate(itemObj, randomPos, Quaternion.identity);
         Service.ItemManagerInGame.Creation(thisItemObj);
      }
      Items.Add(itemObj);
   }

   public void Destroy()
   {
      
   }

}
