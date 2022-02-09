using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager
{
   public List<GameObject> Items = new List<GameObject>();
   
   private int redScore, blueScore;
   
   public float timer = 0;
   
   private float timeLimit = 10;

   private void Awake()
   {
      Service.ItemManagerInGame = this;
   }

   public void StartManually()
   {
      Service.EventManagerInGame.Register<Event_GoalScored>(AddTeamScore);
      Service.EventManagerInGame.Register<Event_GameStarted>(OnGameStart);
   }

   public void UpdateManually()
   {
      timer += Time.deltaTime;

      if (timer >= timeLimit)
      {
         Service.EventManagerInGame.Fire(new Event_GameTimedOut(blueScore, redScore));
      }
   }
   public void Creation(GameObject itemObj)
   {
      Items.Add(itemObj);
   }

   public void Destroy()
   {
      Service.EventManagerInGame.Unregister<Event_GoalScored>(AddTeamScore);
      Service.EventManagerInGame.Unregister<Event_GameStarted>(OnGameStart);
   }
   
   private void OnGameStart(AGPEvent e)
   {
      timer = 0;
      blueScore = 0;
      redScore = 0;
      timeLimit = GameManager.Setting_TimeLimit;
   }

   private void AddTeamScore(AGPEvent e)
   {
         blueScore++;
         redScore++;
   }

}
