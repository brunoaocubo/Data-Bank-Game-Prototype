using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string nameItem;
    public int value;

    [System.Obsolete]
    private void Start()
    {
        value = Random.RandomRange(0, 300);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player")) 
        {
            PlayerInventory playerInventory = collision.collider.GetComponent<PlayerInventory>();
            playerInventory.AddItem(this);

            if (playerInventory.items.Contains(this))
            {
                transform.SetParent(playerInventory.containerCollectable.transform);
                gameObject.SetActive(false);
            }                 
        }

        if (collision.collider.CompareTag("NPC"))
        {
            EnemyInventory enemyInventory = collision.collider.GetComponent<EnemyInventory>();
            enemyInventory.AddItem(this);

            if (enemyInventory.items.Contains(this))
            {
                transform.SetParent(enemyInventory.containerCollectable.transform);
                gameObject.SetActive(false);
            }
        }
    }
}
