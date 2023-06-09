using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string nameItem;
    public float value;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            collision.gameObject.GetComponent<PlayerController>().AddItem(this);
        }
        else if (collision.gameObject.tag == "Enemy") 
        {
            collision.gameObject.GetComponent<EnemyController>().AddItem(this);
        }
    }
}
