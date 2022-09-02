using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveController : MonoBehaviour
{
    public List<GameObject> pylons;
    public GameObject wave1Enemies;
    public GameObject wave2Enemies;
    public GameObject wave3Enemies;
    public GameObject wave4Enemies;
    public List<GameObject> Waves;
    public Text text, enemiesCount;
    private void Start()
    {
        Waves = new List<GameObject>() { wave1Enemies, wave2Enemies, wave3Enemies, wave4Enemies };
        text = GameObject.Find("PylonCount").GetComponent<Text>();
        enemiesCount = GameObject.Find("EnemyCount").GetComponent<Text>();
    }

    public void StartWave(int wave)
    {
        switch(wave)
        {
            case 1:
                foreach(Transform enemy in wave1Enemies.transform)
                {
                    enemy.gameObject.SetActive(true);
                    SetStats(enemy);
                }
                break;
            case 2:
                foreach (Transform enemy in wave2Enemies.transform)
                {
                    enemy.gameObject.SetActive(true);
                    SetStats(enemy);
                }
                break;
            case 3:
                foreach (Transform enemy in wave3Enemies.transform)
                {
                    enemy.gameObject.SetActive(true);
                    SetStats(enemy);
                }
                break;
            case 4:
                foreach (Transform enemy in wave4Enemies.transform)
                {
                    enemy.gameObject.SetActive(true);
                    SetStats(enemy);
                }
                break;
            default:
                //Debug.Log("Błąd w WaveController");
                break;
        }
    }

    public void RefreshPylons(int pylonNumber)
    {
        foreach(var pylon in pylons)
        {
            if(pylon.GetComponent<PylonData>().pylonNumber == pylonNumber)
            {
                pylon.SetActive(true);
                pylon.GetComponent<PylonData>().refreshClick = true;
            }
            else
            {
                pylon.SetActive(false);
            }
        }
        if (pylonNumber == 0)
        {
            text.text = "0";
        }
        else
        {
            text.text = (5 - pylonNumber).ToString();
        }
    }

    void SetStats(Transform _enemy )
    {
        if (Statics.difficulty == "Normal")
        {
            _enemy.GetComponent<CharacterStats>().maxHealth *= 1.1f;
            _enemy.GetComponent<CharacterStats>().remainingHealth *= 1.1f;
            _enemy.GetComponent<CharacterStats>().damage *= 1.1f;
            _enemy.GetComponent<CharacterStats>().points += 50;
        }
        if (Statics.difficulty == "Hard")
        {
            _enemy.GetComponent<CharacterStats>().maxHealth *= 1.4f;
            _enemy.GetComponent<CharacterStats>().remainingHealth *= 1.4f;
            _enemy.GetComponent<CharacterStats>().damage *= 1.4f;
            _enemy.GetComponent<CharacterStats>().points += 100;
        }
        if (Statics.difficulty == "Extreme")
        {
            _enemy.GetComponent<CharacterStats>().maxHealth *= 2.0f;
            _enemy.GetComponent<CharacterStats>().remainingHealth *= 2.0f;
            _enemy.GetComponent<CharacterStats>().damage *= 2.0f;
            _enemy.GetComponent<CharacterStats>().points += 150;
        }
        if (Statics.difficulty == "Easy")
        {
            _enemy.GetComponent<CharacterStats>().maxHealth *= 0.6f;
            _enemy.GetComponent<CharacterStats>().remainingHealth *= 0.6f;
            _enemy.GetComponent<CharacterStats>().damage *= 0.6f;
    
        }
    }

    public void RefreshWaves()
    {
       // int i = 1;
        foreach (var wave in Waves)
        {
            //if (i == waveNumber)
            //{
            //    foreach (Transform enemy in wave.transform)
            //    {
            //        enemy.gameObject.SetActive(true);
            //    }
            //}

            foreach (Transform enemy in wave.transform)
            {
                enemy.gameObject.SetActive(false);
            }

           // i++;
        }
        enemiesCount.text = "0";
    }

}
