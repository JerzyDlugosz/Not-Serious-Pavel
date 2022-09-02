using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckEnemies : MonoBehaviour
{
    static private Text enemiesRemaining;
    void Start()
    {
        enemiesRemaining = this.GetComponent<Text>();
        this.GetComponent<Text>().text = GameObject.FindGameObjectsWithTag("Enemy").Length.ToString();
    }

    private void OnLevelWasLoaded(int level)
    {
        this.GetComponent<Text>().text = GameObject.FindGameObjectsWithTag("Enemy").Length.ToString();
    }

    static public void RefreshEnemiesCount()
    {
        enemiesRemaining.text = GameObject.FindGameObjectsWithTag("Enemy").Length.ToString();
    }
}
