using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadGame : MonoBehaviour
{

    private GameObject player;
    private Text points;
    private Transform playerTransform;
    private int g_SaveFile;
    private WaveController waveController;
    public int levelNumber = 1;
    private Text health;

    private void Awake()
    {
        if (GameObject.Find("Player"))
        {
            player = GameObject.Find("Player");
        }

        if (GameObject.Find("Player"))
        {
            health = GameObject.Find("currentHP").GetComponent<Text>();
        }

        if (GameObject.Find("ScoreText"))
        {
            points = GameObject.Find("ScoreText").GetComponent<Text>();
        }

        if (GameObject.Find("FPSController"))
        {
            playerTransform = GameObject.Find("FPSController").transform;
        }

        if (GameObject.Find("WaveController"))
        {
            waveController = GameObject.Find("WaveController").GetComponent<WaveController>();
        }

        if (GameObject.Find("LoadState") && GameObject.Find("FPSController"))
        {
            playerTransform = GameObject.Find("FPSController").transform;
           
            Load(GameObject.Find("LoadState").GetComponent<LoadState>().secondarySaveFile);
        }
       
    }

    public void Load(int saveFile)
    {
        if (File.Exists(Application.persistentDataPath + $"/gamesave{saveFile}.txt"))
        { 
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + $"/gamesave{saveFile}.txt", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();
            ////Debug.Log($"{playerTransform.position.x},{playerTransform.position.z}");
            Time.timeScale = 1f;
            playerTransform.localPosition = new Vector3(save.savedPositionPosx, save.savedPositionPosy, save.savedPositionPosz);
            Time.timeScale = 0f;
            ////Debug.Log($"{save.savedPositionPosx},{save.savedPositionPosz}");
            player.GetComponent<CharacterStats>().remainingHealth = save.health;
            points.text = save.points.ToString();
            health.text = save.health.ToString();
            if (GameObject.Find("WaveController"))
            {
                waveController = GameObject.Find("WaveController").GetComponent<WaveController>();
                waveController.RefreshPylons(save.nextPylon);
                waveController.RefreshWaves();
            }
            levelNumber = save.level;
            //Debug.Log($"{save.points}");
            //Debug.Log("Game Loaded");
        }
        else
        {
            //Debug.Log("No game saved!");
        }
    }

    public void ChooseLoadFile(int saveFile)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + $"/gamesave{saveFile}.txt", FileMode.Open);
        Save save = (Save)bf.Deserialize(file);
        file.Close();

        Text playerHealthText = GameObject.Find("playerHealthText").GetComponent<Text>();
        playerHealthText.text = save.health.ToString();
        Text playerScoreText = GameObject.Find("playerScoreText").GetComponent<Text>();
        playerScoreText.text = save.points.ToString();
        Text playerLevelText = GameObject.Find("playerLevelText").GetComponent<Text>();
        playerLevelText.text = save.level.ToString();
        g_SaveFile = saveFile;
    }

    public void LoadFile()
    {

        SceneManager.LoadScene(10);
        Load(g_SaveFile);
    }
}
