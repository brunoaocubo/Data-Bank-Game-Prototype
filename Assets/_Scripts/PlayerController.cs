using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] List<Item> items = new List<Item>();

    public void AddItem(Item item) 
    {
        items.Add(item);
    }

    public void RemoveItem(Item item) 
    {
        items.Remove(item);
    }

    public void GetRandomItemFromNpc() 
    {
            
    }

}
