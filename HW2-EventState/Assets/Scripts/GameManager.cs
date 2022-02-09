using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public GameObject aiObj;

    public GameObject itemObj;
    
    public int aiCount = 6;
    
    public int itemCount = 3;
    
    public const float Setting_TimeLimit = 10;

    public Material redMaterial;
    public Material blueMaterial;
    

    //Finite State Machine
    public FiniteStateMachine<GameManager> _fsm;

    private void Awake()
    {
        Service.GameManagerInGame = this;
        Service.InitializeServices();
        
        _fsm = new FiniteStateMachine<GameManager>(this);
        _fsm.TransitionTo<State_TitleScreen>();
    }

    private void Update()
    {
        _fsm.UpdateManually();
    }
    
    public abstract class BaseState : FiniteStateMachine<GameManager>.State
    {
        public override void OnEnter()
        {
            base.OnEnter();
            Service.UIManagerInGame.startScreen.gameObject.SetActive(false);
            Service.UIManagerInGame.startScreenText.gameObject.SetActive(false);
            Service.UIManagerInGame.endScreen.gameObject.SetActive(false);
            Service.UIManagerInGame.endScreenText.gameObject.SetActive(false);
        }
    }
    public class State_TitleScreen : BaseState
    {
        public override void OnEnter()
        {
            base.OnEnter();

            Service.EventManagerInGame.Register<Event_GameStarted>(Service.ItemManagerInGame.OnGameStart);
            
            Service.UIManagerInGame.startScreen.gameObject.SetActive(true);
            Service.UIManagerInGame.startScreenText.gameObject.SetActive(true);
        }

        public override void Update()
        {
            base.Update();
            if (Input.anyKeyDown)
                TransitionTo<State_InGame>();
        }
    }
    
    private class State_InGame : BaseState
    {
        public override void OnEnter()
        {
            base.OnEnter();
           
            Service.EventManagerInGame.Register<Event_GoalScored>(Service.ItemManagerInGame.AddTeamScore);

            Service.EventManagerInGame.Register<Event_GameTimedOut>(Service.ItemManagerInGame.OnGameTimedOut);
            
            Service.EventManagerInGame.Fire(new Event_GameStarted());

            for (int i = 0; i < Service.GameManagerInGame.aiCount; i++)
            {
                Vector3 randomPos = new Vector3(Random.Range(-10.0f, 10.0f), 1.0f, Random.Range(-10.0f, 10.0f));
                GameObject thisAIObj = Instantiate<GameObject>(Service.GameManagerInGame.aiObj, randomPos, Quaternion.identity);
                if (thisAIObj != null)
                {
                    Service.AIManagerInGame.Creation(thisAIObj,i);
                }
                else
                {
                    Debug.Log("AI object is null");
                }
            }
        
            for (int i = 0; i < Service.GameManagerInGame.itemCount; i++)
            {
                Vector3 randomPos = new Vector3(Random.Range(-10.0f, 10.0f), 1.0f, Random.Range(-10.0f, 10.0f));
                GameObject thisItemObj = Instantiate(Service.GameManagerInGame.itemObj, randomPos, Quaternion.identity);
                Service.ItemManagerInGame.Creation(thisItemObj);
            }
        }

        public override void Update()
        {
            base.Update();
           
            foreach (var KeyValuePair in Service.AIManagerInGame.AIs)
            {
                if (KeyValuePair.Key != null)
                {
                    Service.AIManagerInGame.Updating(KeyValuePair.Key);
                }
            }
        
            Service.ItemManagerInGame.UpdateManually();
            
        }

        public override void OnExit()
        {
            base.OnExit();
            
            Service.EventManagerInGame.Unregister<Event_GoalScored>(Service.ItemManagerInGame.AddTeamScore);
            Service.EventManagerInGame.Unregister<Event_GameStarted>(Service.ItemManagerInGame.OnGameStart);

            Service.EventManagerInGame.Unregister<Event_GameTimedOut>(Service.ItemManagerInGame.OnGameTimedOut);
            
        }
        
    }
    
    public class State_GameOver : BaseState
    {
        private const float timeBeforeAllowReturnToTitle = 3.0f;
        private float timeInGameOver = 0;

        public override void OnEnter()
        {
            base.OnEnter();
            
            timeInGameOver = 0;
            
            Service.UIManagerInGame.endScreen.gameObject.SetActive(true);
            Service.UIManagerInGame.endScreenText.gameObject.SetActive(true);
            
            Service.AIManagerInGame.Destroy();
        }

        public override void Update()
        {
            base.Update();

            timeInGameOver += Time.deltaTime;

            if (timeInGameOver < timeBeforeAllowReturnToTitle) return;
            else{ TransitionTo<State_TitleScreen>(); }
    }
}
}

