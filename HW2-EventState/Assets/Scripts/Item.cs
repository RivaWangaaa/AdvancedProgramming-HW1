using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Service.AIManagerInGame.AIs.ContainsKey(collision.gameObject))
            {
                string value = Service.AIManagerInGame.AIs[collision.gameObject];
                if (value == "Blue")
                {
                    Debug.Log("Blue team!");
                    Service.EventManagerInGame.Fire(new Event_GoalScored(value));
                }
                else
                {
                    Debug.Log("Red team!");
                    Service.EventManagerInGame.Fire(new Event_GoalScored(value));
                }
            }
            Service.ItemManagerInGame.Items.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
