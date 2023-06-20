using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;

public class DataBankSQL : MonoBehaviour
{
    string connectionString;
    string query;
    MySqlConnection MS_Connection;
    MySqlCommand MS_Command;
    MySqlDataReader MS_DataReader;


    public void SaveInventoryData(int id, List<Item> inventoryItems)
    {
        connectionString = "Server = localhost; Database = gamedb; User = root; Charset = utf8;";
        MS_Connection = new MySqlConnection(connectionString);
        MS_Connection.Open();

        foreach (Item item in inventoryItems)
        {
            query = $"INSERT INTO inventario (id, item_name, value) VALUES ({id}, '{item.name}', {item.value})";
            MS_Command = new MySqlCommand(query, MS_Connection);
            MS_Command.ExecuteNonQuery();
        }

        MS_Connection.Close();
    }

    public List<Item> LoadInventoryData(int id)
    {
        List<Item> items = new List<Item>();

        connectionString = "Server=127.0.0.1;Database=GameBD;User=localhost;Charset=utf8;";
        MS_Connection = new MySqlConnection(connectionString);
        MS_Connection.Open();

        query = $"SELECT item_name, value FROM inventario WHERE id = {id}";
        MS_Command = new MySqlCommand(query, MS_Connection);
        MS_DataReader = MS_Command.ExecuteReader();

        while (MS_DataReader.Read())
        {
            string itemName = MS_DataReader.GetString("item_name");
            int value = MS_DataReader.GetInt32("value");

            Item item = new Item(itemName, value);
            items.Add(item);
        }

        MS_Connection.Close();

        return items;
    }


    /*
public void SaveDataSql()
{
    connectionString = "Server = 127.0.0.1; Database = gamedb; User = localhost; Charset = uft8;";
    MS_Connection = new MySqlConnection(connectionString);
    MS_Connection.Open();

    //query = 
    MS_Command = new MySqlCommand(query, MS_Connection);
    MS_Command.ExecuteNonQuery();
    MS_Connection.Close();

}

public void LoadDataPlayer() 
{
    //query = 
    connectionString = "Server =  127.0.0.1; Database = GameBD; User = localhost; Charset = uft8;";
    MS_Connection = new MySqlConnection(connectionString);
    MS_Connection.Open();

    MS_Command = new MySqlCommand(query, MS_Connection);
    MS_DataReader = MS_Command.ExecuteReader();

    while(MS_DataReader.Read()) 
    {
        //Make the logic 
        //player load

    }
    MS_Connection.Close();
}*/
}