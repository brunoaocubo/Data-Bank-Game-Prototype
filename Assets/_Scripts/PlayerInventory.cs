using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public GameObject containerCollectable;

    public void AddItem(Item item) 
    {
        if(items.Count <= 9) 
        {
            items.Add(item);
        }   
    }

    public void RemoveItem(Item item) 
    {
        if(items.Count > 0) 
        {
            items.Remove(item);
        }      
    }
}

