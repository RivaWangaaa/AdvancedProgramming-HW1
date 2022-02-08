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
            Service.ItemManagerInGame.Items.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
