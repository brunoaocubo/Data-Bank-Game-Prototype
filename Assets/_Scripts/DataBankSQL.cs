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

    public void SaveDataSql()
    {
        connectionString = "Server =  127.0.0.1; Database = GameBD; User = localhost; Charset = uft8;";
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
    }
}