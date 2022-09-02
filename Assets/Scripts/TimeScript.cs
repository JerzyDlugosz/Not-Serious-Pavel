using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{
    public float currentTime = 0;
    private Text timeLeft;
    private WaveController waveController;
    private GameObject saveGameController;
    public Text enemiesCount;
    private int level;
    public GameObject goalText;

    private void Start()
    {
        saveGameController = GameObject.Find("SaveGameController");
        timeLeft = GameObject.Find("TimeLeftText").GetComponent<Text>();
        enemiesCount = GameObject.Find("EnemyCount").GetComponent<Text>();
        if(GameObject.Find("Level"))
        {
            level = GameObject.Find("Level").GetComponent<level>().levelNumber;
        }
        else
        {
            level = GameObject.Find("LoadLoadedLoading").GetComponent<LoadGame>().levelNumber;
        }
        goalText = GameObject.Find("GoalText");
        goalText.SetActive(false);
    }

    public void StartCour(float Time)
    {
        StartCoroutine(StartCountdown(Time));
        waveController = GameObject.Find("WaveController").GetComponent<WaveController>();
    }

    public IEnumerator StartCountdown(float Time)
    {
        currentTime = Time;
        do
        {
            //Debug.Log("Countdown: " + currentTime);
            yield return new WaitForSeconds(0.1f);
            currentTime = currentTime - 0.1f;
            if(enemiesCount.text == "0")
            {
                ScoreManager.score += (Mathf.RoundToInt(currentTime) * 100);
                currentTime = 0;
            }
            if(Mathf.Round(currentTime) == 0)
            {
                currentTime = 0;
                //Debug.Log(level);
                saveGameController.GetComponent<SaveGame>().GameSave(1, level);
                waveController.RefreshWaves();
            }
            timeLeft.text = currentTime.ToString("F1");
        }
        while (currentTime > 0f);
    }

    private void OnLevelWasLoaded(int levele)
    {
        if (GameObject.Find("Level"))
        {
            level = GameObject.Find("Level").GetComponent<level>().levelNumber;
        }
        else
        {
            level = GameObject.Find("LoadLoadedLoading").GetComponent<LoadGame>().levelNumber;
        }
        if(levele == 1)
        {
            string text = "Cel: Włącz 4 generatory żeby przejść na następną mapę";
            StartCoroutine(TextShowCooldown(4, text));
        }
        if (levele == 6)
        {
            string text = "Cel: Znajdź 4 klucze żeby przejść na następną mapę";
            StartCoroutine(TextShowCooldown(4, text));
        }
        if (levele == 11)
        {
            string text = "Cel: Zabij bossa";
            StartCoroutine(TextShowCooldown(4, text));
        }
    }

    public IEnumerator TextShowCooldown(float time, string text)
    {
        float myTime = time;
        do
        {
            yield return new WaitForSeconds(1f);
            if (myTime == time)
            {
                goalText.SetActive(true);
                goalText.GetComponent<Text>().text = text;
            }

            if (myTime > 0f)
            {
                myTime -= 1f;
            }

            if (myTime <= 0f)
            {
                goalText.SetActive(false);
            }
        } while (myTime > 0f);
    }
}

