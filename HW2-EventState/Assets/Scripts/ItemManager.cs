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
   

   //Call this in GameManager State_InGame Update()
   public void UpdateManually()
   {

      if (timer >= timeLimit)
      {
         Service.EventManagerInGame.Fire(new Event_GameTimedOut(blueScore, redScore));
      }
      else
      {
         timer += Time.deltaTime;
      }

      Service.UIManagerInGame.blueScoreText.text = "Blue Team Score: " + blueScore;
      Service.UIManagerInGame.redScoreText.text = "Red Team Score: " + redScore;
      Service.UIManagerInGame.timerText.text = ((int) (timeLimit - timer)).ToString() + " secs Left";
   }
   
   
   public void Creation(GameObject itemObj)
   {
      Items.Add(itemObj);
   }

   public void OnGameStart(AGPEvent e)
   {
      timer = 0;
      blueScore = 0;
      redScore = 0;
      timeLimit = GameManager.Setting_TimeLimit;
   }

   public void AddTeamScore(AGPEvent e)
   {
      var goalScoredEvent = (Event_GoalScored) e;
      if (goalScoredEvent.teamColorScored == "Blue")
      {
         blueScore++;
         Debug.Log("Blue+1! Blue Score: " + blueScore);
      }
      else
      {
         redScore++; 
         Debug.Log("Red+1! Red Score: " + redScore);
      }
         
   }
   
   public void OnGameTimedOut(AGPEvent e)
   {
      Service.GameManagerInGame._fsm.TransitionTo<GameManager.State_GameOver>();
   }

}
