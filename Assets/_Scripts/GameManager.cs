using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [Header("UI Config")]
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private Text stopWatch;

    [Header("Game Config")]
    [SerializeField] private GameObject[] objectsToSpawn;
    [SerializeField] private float spawnInterval = 10f;
    [SerializeField] private int objectsPerSpawn = 1;
    [SerializeField] private int spawnWaves = 5;
    [SerializeField] private float timerGame = 30f;

    [Header("Save DataBank")]
    [SerializeField] private DataBankSQL dataBankSQL;
    [SerializeField] private DataBankJson dataBankJson = new DataBankJson();
    List<EnemyInventory> npcInventories = new List<EnemyInventory>();
    [SerializeField] private PlayerInventory playerInventory = new PlayerInventory();
    [SerializeField] private EnemyInventory[] npcInventory = new EnemyInventory[3];

    private float countTimerGame;
    private float timerSpawn = 0f;
    private bool optionsOn;

    private void Start()
    {
        optionsPanel.SetActive(false);
        countTimerGame = timerGame;
    }

    private void Update()
    {
        stopWatch.text = countTimerGame.ToString("F0");

        if(spawnWaves > 0) 
        {
            timerSpawn += Time.deltaTime;

            if (timerSpawn >= spawnInterval)
            {
                SpawnObjects();
                timerSpawn = 0f;
                spawnWaves--;
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            optionsOn = !optionsOn;
            optionsPanel.SetActive(optionsOn);
        }
        
        if(countTimerGame > 0) 
        {
            countTimerGame -= Time.deltaTime;
        }
        if(timerGame <= 0) 
        {
            countTimerGame = 0f;
        }
    }

    private void SpawnObjects()
    {
        for (int i = 0; i < objectsPerSpawn; i++)
        {
            int randomIndex = Random.Range(0, objectsToSpawn.Length);
            Vector3 randomPos = new Vector3(Random.Range(-17f, 15f), 5, Random.Range(-17f, 15f));

            Instantiate(objectsToSpawn[randomIndex], randomPos, objectsToSpawn[randomIndex].transform.localRotation);
        }
    }

    public void SaveGameJson() 
    {
        npcInventories.Add(npcInventory[0]);
        npcInventories.Add(npcInventory[1]);
        npcInventories.Add(npcInventory[2]);

        dataBankJson.SavePlayerInventoryToJson(playerInventory);
        dataBankJson.SaveNpcInventoryToJson(npcInventories);
    }

    public void SaveGameSQL() 
    {
        dataBankSQL.SaveInventoryData(0, playerInventory.items);
        dataBankSQL.SaveInventoryData(1, npcInventory[0].items);
        dataBankSQL.SaveInventoryData(2, npcInventory[1].items);
        dataBankSQL.SaveInventoryData(3, npcInventory[2].items);
    }

    public void QuitGame() 
    {
        SaveGameSQL();
        Application.Quit();
    }
}
