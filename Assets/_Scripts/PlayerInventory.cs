using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public GameObject containerCollectable;
    public int id = 0;

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

    public Item GetItemMostValue()
    {
        if (items.Count <= 0)
        {
            return null;
        }

        Item hightestValueItem = items[0];

        for (int i = 1; i < items.Count; i++)
        {
            if (items[i].value > hightestValueItem.value)
            {
                hightestValueItem = items[i];
            }
        }
        return hightestValueItem;
    }
}

