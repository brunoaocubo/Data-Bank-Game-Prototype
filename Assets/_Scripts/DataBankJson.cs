using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using static UnityEditor.Progress;


public class DataBankJson : MonoBehaviour
{
    public void SavePlayerInventoryToJson(PlayerInventory inventory)
    {
        string filePath = Application.persistentDataPath + "/PlayerInventory.json";

        // Cria uma lista de objetos JSON para os itens
        
        List<object> jsonItems = new List<object>();
        foreach (Item item in inventory.items)
        {
            // Cria um objeto JSON para cada item com as informações necessárias
            var jsonItem = new
            {
                id = inventory.id,
                itemName = item.itemName,
                value = item.value
            };

            jsonItems.Add(jsonItem);
        }

        // Serializa a lista de itens em JSON
        string json = JsonConvert.SerializeObject(jsonItems, Formatting.Indented);

        // Salva o JSON no arquivo
        System.IO.File.WriteAllText(filePath, json);
    }

    public void SaveNpcInventoryToJson(List<EnemyInventory> inventories)
    {
        string filePath = Application.persistentDataPath + "/NpcsInventory.json";

        // Cria uma lista de objetos JSON para os itens

        List<object> jsonItems = new List<object>();
        foreach (EnemyInventory inventory in inventories)
        {
            foreach (Item item in inventory.items)
            {
                // Cria um objeto JSON para cada item com as informações necessárias
                var jsonItem = new
                {
                    id = inventory.id,
                    itemName = item.itemName,
                    value = item.value
                };

                jsonItems.Add(jsonItem);
            }
        }

        // Serializa a lista de itens em JSON
        string json = JsonConvert.SerializeObject(jsonItems, Formatting.Indented);

        // Salva o JSON no arquivo
        System.IO.File.WriteAllText(filePath, json);
    }
}
